using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Globalization;
using System.IO;
using FastReport.Utils;
using System.IO.Compression;
using FastReport.Format;


namespace FastReport.Export
{
    internal static class ExportUtils
    {
        public const string XConv = "0123456789ABCDEF";
        private const int BASE = 65521;
        private const int NMAX = 5552;

        public static string FloatToString(float value)
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = String.Empty;            
            provider.NumberDecimalSeparator = ".";
            return Convert.ToString(Math.Round(value, 2), provider);
        }

        public static bool ParseTextToDecimal(string text, FormatBase format, out decimal value)
        {
            value = 0;
            if (format is NumberFormat || format is CurrencyFormat)
                return decimal.TryParse(text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat, out value);
            return false;
        }

        public static string HTMLColor(Color color)
        {
            return "#" + ByteToHex(color.R) + ByteToHex(color.G) + ByteToHex(color.B);           
        }

        public static string ByteToHex(byte Byte)
        {
            return XConv[(Byte >> 4)].ToString() + XConv[(Byte & 0xF)].ToString();
        }

        public static string UInt16Tohex(UInt16 word)
        {
            return ByteToHex((byte)((word >> 8) & 0xFF)) + ByteToHex((byte)(word & 0xFF));
        }

        public static string TruncReturns(string Str)
        {
            int l;
            l = Str.Length;
            if ((l > 1) && (Str.Substring(l - 2, 2) == "\r\n"))
                return Str.Substring(0, l - 2);
            else
                return Str;
        }

        private static string HtmlString(string text, bool htmlTags, bool xmlCRLF)
        {
          StringBuilder Result = new StringBuilder();
          if (text.Length == 1 && text[0] == ' ' && !xmlCRLF)
            Result.Append("&nbsp;");
          else
          {
            for (int i = 0; i < text.Length; i++)
            {
              string tag = String.Empty;
              bool match = false;
              if (htmlTags && text[i] == '<')
              {
                // <b>, <i>, <u>
                if (i + 3 <= text.Length)
                {
                  tag = text.Substring(i, 3).ToLower();
                  match = tag == "<b>" || tag == "<i>" || tag == "<u>";
                  if (match)
                    i += 3;
                }

                // </b>, </i>, </u>
                if (!match && i + 4 <= text.Length && text[i + 1] == '/')
                {
                  tag = text.Substring(i, 4).ToLower();
                  match = tag == "</b>" || tag == "</i>" || tag == "</u>";
                  if (match)
                    i += 4;
                }

                // <sub>, <sup>
                if (!match && i + 5 <= text.Length)
                {
                  tag = text.Substring(i, 5).ToLower();
                  match = tag == "<sub>" || tag == "<sup>";
                  if (match)
                    i += 5;
                }

                // </sub>, </sup>
                if (!match && i + 6 <= text.Length && text[i + 1] == '/')
                {
                  match = true;
                  tag = text.Substring(i, 6).ToLower();
                  match = tag == "</sub>" || tag == "</sup>";
                  if (match)
                    i += 6;
                }

                // <strike>
                if (!match && i + 8 <= text.Length)
                {
                  tag = text.Substring(i, 8).ToLower();
                  match = tag == "<strike>";
                  if (match)
                    i += 8;
                }

                // </strike>
                if (!match && i + 9 <= text.Length)
                {
                  tag = text.Substring(i, 9).ToLower();
                  match = tag == "</strike>";
                  if (match)
                    i += 9;
                }

                // <font color
                if (!match && i + 12 < text.Length && text.Substring(i, 12).ToLower() == "<font color=")
                {
                  int start = i + 12;
                  int end = start;
                  for (; end < text.Length && text[end] != '>'; end++)
                  {
                  }

                  if (end < text.Length)
                  {
                    tag = text.Substring(i, 12) + "\"" + text.Substring(start, end - start) + "\">";
                    i = end + 1;
                    match = true;
                  }
                }

                // </font>
                if (!match && i + 7 <= text.Length)
                {
                  tag = text.Substring(i, 7).ToLower();
                  match = tag == "</font>";
                  if (match)
                    i += 7;
                }
              }

              if (match)
              {
                tag = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(tag);
                Result.Append(tag);
                i--;
              }
              else
              {
                if (text[i] == '&')
                  Result.Append("&amp;");
                else if (i < text.Length - 1 && text[i] == '\r' && text[i + 1] == '\n')
                {
                  if (xmlCRLF)
                    Result.Append("&#10;");
                  else
                    Result.Append("<br>");
                  i++;
                }
                else if (text[i] == '"')
                  Result.Append("&quot;");
                else if (text[i] == '<')
                  Result.Append("&lt;");
                else if (text[i] == '>')
                  Result.Append("&gt;");
                else
                  Result.Append(text[i]);
              }
            }
          }
          return Result.ToString();
        }

        public static string HtmlString(string text, bool htmlTags)
        {
          return HtmlString(text, htmlTags, false);
        }

        public static string XmlString(string Str, bool htmlTags)
        {
          return HtmlString(Str, htmlTags, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string HtmlURL(string Value)
        {
            StringBuilder Result = new StringBuilder();
            for (int i = 0; i < Value.Length; i++)
            {
                switch (Value[i])
                {
                  case '\\':
                        Result.Append("/");
                        break;
                    case '&':
                    case '<':
                    case '>':
                    case '{':
                    case '}':
                    case ';':
                    case '?':
                    case ' ':
                        Result.Append("%" + ExportUtils.ByteToHex((byte)Value[i]));
                        break;
                    default:
                        Result.Append(Value[i]);
                        break;
                }
            }
            return Result.ToString();
        }

        public static string MD5(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            md5.Initialize();
            byte[] inputBytes = StringToByteArray(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();            
        }

        public static byte[] MD5buf(byte[] buf, int length)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            md5.Initialize();
            return md5.ComputeHash(buf, 0, length);
        }

        public static string MD5Stream(Stream stream)
        {
            long oldpos = stream.Position;
            stream.Position = 0;
            byte[] buff = new byte[stream.Length];
            stream.Read(buff, 0, (int)stream.Length);
            stream.Position = oldpos;
            byte[] hash = MD5buf(buff, buff.Length);
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));
            return sb.ToString();
        }

        public static void Write(Stream stream, string value)
        {
            stream.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
        }

        public static void WriteLn(Stream stream, string value)
        {
            stream.Write(Encoding.UTF8.GetBytes(value), 0, value.Length);
            stream.WriteByte(13);
            stream.WriteByte(10);
        }

        public static void Write(Stream stream, byte value)
        {
            stream.WriteByte(value);
        }

        public static void ZLibDeflate(Stream src, Stream dst)
        {
            dst.WriteByte(0x78);
            dst.WriteByte(0xDA);
            src.Position = 0;
            long adler = 1L;
            using (DeflateStream compressor = new DeflateStream(dst, CompressionMode.Compress, true))
            {
                int bufflength = 2048;
                byte[] buff = new byte[bufflength];
                int i;
                while ((i = src.Read(buff, 0, bufflength)) > 0)
                {
                    adler = Adler32(adler, buff, 0, i);
                    compressor.Write(buff, 0, i);
                }
            }
            dst.WriteByte((byte)(adler >> 24 & 0xFF));
            dst.WriteByte((byte)(adler >> 16 & 0xFF));
            dst.WriteByte((byte)(adler >> 8 & 0xFF));
            dst.WriteByte((byte)(adler & 0xFF));
        }

        public static long Adler32(long adler, byte[] buf, int index, int len)
        {
            if (buf == null) { return 1L; }

            long s1 = adler & 0xffff;
            long s2 = (adler >> 16) & 0xffff;
            int k;

            while (len > 0)
            {
                k = len < NMAX ? len : NMAX;
                len -= k;
                while (k >= 16)
                {
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    s1 += buf[index++] & 0xff; s2 += s1;
                    k -= 16;
                }
                if (k != 0)
                {
                    do
                    {
                        s1 += buf[index++] & 0xff;
                        s2 += s1;
                    }
                    while (--k != 0);
                }
                s1 %= BASE;
                s2 %= BASE;
            }
            return (s2 << 16) | s1;
        }

        public static string ReverseString(string str)
        {
            StringBuilder result = new StringBuilder(str.Length);
            int i, j;
            for (j = 0, i = str.Length - 1; i >= 0; i--, j++)
                result.Append(str[i]);
            return result.ToString();
        }

        public static string StrToHex(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length * 2);
            foreach (char c in s)
                sb.Append(((byte)c).ToString("X2"));
            return sb.ToString();
        }

        public static StringBuilder StrToHex2(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length * 2);
            foreach (char c in s)
                sb.Append(((UInt16)c).ToString("X4"));
            return sb;
        }

        public static string GetID()
        {
            return ExportUtils.MD5(Guid.NewGuid().ToString());
        }

        public static void CopyStream(Stream source, Stream target)
        {           
            source.Position = 0;
            int bufflength = 2048;
            byte[] buff = new byte[bufflength];
            int i;
            while ((i = source.Read(buff, 0, bufflength)) > 0)
                target.Write(buff, 0, i);
        }

        public static byte[] StringToByteArray(string source)
        {
            byte[] result = new byte[source.Length];
            for (int i = 0; i < source.Length; i++)
                result[i] = (byte)source[i];
            return result;
        }

        public static string StringFromByteArray(byte[] array)
        {
            StringBuilder result = new StringBuilder(array.Length);
            foreach (byte b in array)
                result.Append((char)b);
            return result.ToString();
        }

        internal static Color GetColorFromFill(FillBase Fill)
        {
            if (Fill is SolidFill)
                return (Fill as SolidFill).Color;
            else if (Fill is GlassFill)
                return (Fill as GlassFill).Color;
            else if (Fill is HatchFill)
                return (Fill as HatchFill).BackColor;
            else if (Fill is PathGradientFill)
                return (Fill as PathGradientFill).CenterColor;
            else if (Fill is LinearGradientFill)
                return GetMiddleColor((Fill as LinearGradientFill).StartColor, (Fill as LinearGradientFill).EndColor);
            else
                return Color.White;
        }

        private static Color GetMiddleColor(Color color1, Color color2)
        {
            return Color.FromArgb(255, (color1.R + color2.R) / 2, (color1.G + color2.G) / 2, (color1.B + color2.B) / 2);
        }
    }

    internal class RC4
    {
        private byte[] fKey;

        public void Start(byte[] key)
        {
            byte[] k = new byte[256];
            int l = key.GetLength(0);
            if (key.Length > 0 && l <= 256)
            {
                for (int i = 0; i < 256; i++)
                {
                    fKey[i] = (byte)i;
                    k[i] = key[i % l];
                }
            }

            byte j = 0;
            for (int i = 0; i < 256; i++)
            {
                j = (byte)(j + fKey[i] + k[i]);
                byte tmp = fKey[i];
                fKey[i] = fKey[j];
                fKey[j] = tmp;
            }
        }

        public byte[] Crypt(byte[] source)
        {
            byte i = 0;
            byte j = 0;
            int l = source.GetLength(0);
            byte[] result = new byte[l];
            for (int k = 0; k < l; k++)
            {
                i = (byte)(i + 1);
                j = (byte)(j + fKey[i]);
                byte tmp = fKey[i];
                fKey[i] = fKey[j];
                fKey[j] = tmp;
                result[k] = (byte)(source[k] ^ fKey[(byte)(fKey[i] + fKey[j])]);
            }
            return result;
        }

        public RC4()
        {
            fKey = new byte[256];
        }

    }
}
