using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WebClassLibrary
{
    public class JDataManager
    {
        public static byte[] StreamToBytes(System.IO.Stream stream)
        {
            return ReadToEnd(stream);
        }
        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        public static byte[] LoadFile(string virtualPath)
        {
            return System.IO.File.ReadAllBytes(System.Web.HttpContext.Current.Request.MapPath(virtualPath));
        }

        public static string EncryptString(string str)
        {
            return ClassLibrary.JEnryption.EncryptStr(str, WebClassLibrary.SessionManager.Current.SessionID);
        }

        public static string DecryptString(string str)
        {
            return ClassLibrary.JEnryption.DecryptStr(str, WebClassLibrary.SessionManager.Current.SessionID);
        }

        public static DataTable EnumToDataTable(Type enumType)
        {
            ClassLibrary.JKeyValue[] keyval = ClassLibrary.JMainFrame.EnumToListBox(enumType);
            DataTable result = new DataTable();
            result.Columns.Add("Value");
            result.Columns.Add("Key");
            foreach (var item in keyval)
            {
                DataRow dr = result.NewRow();
                dr["Key"] = item.Key;
                dr["Value"] = item.Value;
                result.Rows.Add(dr);
            }
            return result;
        }
    }
}
