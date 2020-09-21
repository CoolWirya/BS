using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebClassLibrary
{
    public class JSessionParser_old
    {
        public static Dictionary<string, object> SessionItems;
        public static bool ParseSession(string sessionId)
        {
            bool state = false;
            MemoryStream ms = new MemoryStream((byte[])WebClassLibrary.JWebDataBase.GetDataTable("SELECT SessionItemShort FROM [ASPState].[dbo].[ASPStateTempSessions] WHERE LEFT(SessionId,LEN(SessionId)-8) = '" + sessionId + "'").Rows[0][0]);
            byte[] buf = ms.ToArray();
            //int len = buf[6];
            //SessionItems = new Dictionary<string, object>(len);
            //List<int> valueIndexes = new List<int>();
            ////state = true;
            ////for (int i = 0; i < buf.Length; i++)
            ////{
            ////    //if (buf[i] == 1 && buf[i + 1] == 8)
            ////    //{
            ////    //    i += 2;
            ////    //    res += "\r\n";
            ////    //}
            ////    //else
            ////        res += buf[i].ToString() + "\t\t";
            ////}
            ////System.Web.HttpContext.Current.Response.Write(res);
            //int i = 14;
            //int j = 0;
            ////while (i < buf.Length - 1 && j < len)
            ////{
            ////    string key = GetKey(buf, i + 1, buf[i]);
            ////    SessionItems.Add(key, null);
            ////    i += buf[i] + 1;
            ////    j++;
            ////}
            //Decode(ms);

            JSessionParser2 js = new JSessionParser2(sessionId, buf);

            return state;
            //HttpStaticObjectsCollection.Deserialize
        }
        static string GetKey(byte[] buf, int start, int len)
        {
            List<byte> b = new List<byte>();
            for (int i = start; i < start + len; i++)
                b.Add(buf[i]);
            return System.Text.Encoding.UTF8.GetString(b.ToArray());
        }
        public static string res = "";

        private static void Decode(MemoryStream ms)
        {
            BinaryReader br = new BinaryReader(ms);
            int num1 = br.ReadInt32();
            bool isStateItem = br.ReadBoolean();
            bool isStatic = br.ReadBoolean();

            //Console.WriteLine("num1={0}, is state item={1}, is static item={2}", num1, isStateItem, isStatic);

            if (isStateItem)
            {
                DecodeStateItems(br);
            }
        }

        private static void DecodeStateItems(BinaryReader br)
        {
            int num1 = br.ReadInt32();
            Console.WriteLine("num1={0}", num1);
            if (num1 > 0)
            {
                Console.WriteLine("check passed");
                int num2 = br.ReadInt32();
                Console.WriteLine("num2={0}", num2);

                int num3 = 0;

                while (num3 < num1)
                {
                    Console.WriteLine("num3={0}", num3);

                    string text1;
                    if (num3 == num2) { Console.WriteLine("num3==num2"); text1 = null; }
                    else { text1 = br.ReadString(); Console.WriteLine("text1={0}", text1); ar.Add(text1); }

                    num3++;
                }

                // dont know what is this used for
                for (num3 = 0; num3 < num1; num3++)
                {
                    if (num3 == 0)
                    {
                        //Console.WriteLine("for loop num3==0");
                    }
                    else
                    {
                        //Console.WriteLine("for loop num3=={0}", br.ReadInt32());
                    }
                }

                int lastOffset = br.ReadInt32();
                //Console.WriteLine("last offset={0}", lastOffset);

                byte[] buffer = new byte[lastOffset];
                int num4 = br.BaseStream.Read(buffer, 0, lastOffset);
                //Console.WriteLine("num4={0}", num4);

                _contentStream = new MemoryStream(buffer);

                for (int i = 0; i < ar.Count; i++)
                {
                    //Console.WriteLine("item={0} value={1}", ar[i].ToString(),
                    //    ReadValueFromStream(new BinaryReader(_contentStream)));
                    SessionItems.Add(ar[i].ToString(), ReadValueFromStream(new BinaryReader(_contentStream)));
                }
            }
        }

        static System.Collections.ArrayList ar = new System.Collections.ArrayList();
        static private MemoryStream _contentStream;

        // copied from reflector
        static object ReadValueFromStream(BinaryReader reader)
        {
            object obj1 = null;
            int[] numArray1;
            int num1;
            switch (((TypeID)reader.ReadByte()))
            {
                case TypeID.String:
                    {
                        return reader.ReadString();
                    }
                case TypeID.Int32:
                    {
                        return reader.ReadInt32();
                    }
                case TypeID.Boolean:
                    {
                        return reader.ReadBoolean();
                    }
                case TypeID.DateTime:
                    {
                        return new DateTime(reader.ReadInt64());
                    }
                case TypeID.Decimal:
                    {
                        numArray1 = new int[4];
                        num1 = 0;
                        goto Label_00CA;
                    }
                case TypeID.Byte:
                    {
                        return reader.ReadByte();
                    }
                case TypeID.Char:
                    {
                        return reader.ReadChar();
                    }
                case TypeID.Single:
                    {
                        return reader.ReadSingle();
                    }
                case TypeID.Double:
                    {
                        return reader.ReadDouble();
                    }
                case TypeID.SByte:
                    {
                        return reader.ReadSByte();
                    }
                case TypeID.Int16:
                    {
                        return reader.ReadInt16();
                    }
                case TypeID.Int64:
                    {
                        return reader.ReadInt64();
                    }
                case TypeID.UInt16:
                    {
                        return reader.ReadUInt16();
                    }
                case TypeID.UInt32:
                    {
                        return reader.ReadUInt32();
                    }
                case TypeID.UInt64:
                    {
                        return reader.ReadUInt64();
                    }
                case TypeID.TimeSpan:
                    {
                        return new TimeSpan(reader.ReadInt64());
                    }
                case TypeID.Guid:
                    {
                        byte[] buffer1 = reader.ReadBytes(0x10);
                        return new Guid(buffer1);
                    }
                case TypeID.IntPtr:
                    {
                        if (IntPtr.Size == 4)
                        {
                            return new IntPtr(reader.ReadInt32());
                        }
                        return new IntPtr(reader.ReadInt64());
                    }
                case TypeID.UIntPtr:
                    {
                        if (UIntPtr.Size == 4)
                        {
                            return new UIntPtr(reader.ReadUInt32());
                        }
                        return new UIntPtr(reader.ReadUInt64());
                    }
                case TypeID.Object:
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter1 = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        return formatter1.Deserialize(reader.BaseStream);
                    }
                case TypeID.Null:
                    {
                        return null;
                    }
                default:
                    {
                        return obj1;
                    }
            }
        Label_00CA:
            if (num1 >= 4)
            {
                return new decimal(numArray1);
            }
            numArray1[num1] = reader.ReadInt32();
            num1++;
            goto Label_00CA;
        }

        public enum TypeID : byte
        {
            // Fields
            Boolean = 3,
            Byte = 6,
            Char = 7,
            DateTime = 4,
            Decimal = 5,
            Double = 9,
            Guid = 0x11,
            Int16 = 11,
            Int32 = 2,
            Int64 = 12,
            IntPtr = 0x12,
            Null = 0x15,
            Object = 20,
            SByte = 10,
            Single = 8,
            String = 1,
            TimeSpan = 0x10,
            UInt16 = 13,
            UInt32 = 14,
            UInt64 = 15,
            UIntPtr = 0x13
        }
    }
}
