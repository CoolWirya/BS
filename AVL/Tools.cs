using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ClassLibrary;
using System.Security.Cryptography;

namespace AVL
{
    public static class Tools
    {
        public static object InvokeMethod(string AssemblyName,string classname,string methodname,object[] parameters,bool IsInstance=true)
        {
			System.Reflection.Assembly assembly;
			object obj;
			Type t;
			try
			{

				assembly = System.Reflection.Assembly.Load(AssemblyName);
				t = assembly.GetType(classname);
				if (IsInstance)
				{
					obj = assembly.CreateInstance(classname);
					return t.InvokeMember(methodname, System.Reflection.BindingFlags.InvokeMethod, null, obj, parameters);
				}
				else
				{
					return t.InvokeMember(methodname, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public, null, null, parameters);
				}
			}
			catch (Exception er)
			{
				return er;
			}
			finally
			{
				assembly = null;
				obj = null;
				t = null;
				GC.Collect();
			}
        }

        public static bool IsAvlProject()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AVLObjectList");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static int AvlTestInsert(string data, string method)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(string.Format(@" INSERT INTO avlTest (data,method) values (N'{0}','{1}')",
                    data,
                    method));
                DB.Query_Execute();
                DB.setQuery("SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY];");
                System.Data.DataTable DT = DB.Query_DataTable();
                if (DT.Rows.Count == 1)
                    return int.Parse(DT.Rows[0][0].ToString().Trim());
                return 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static bool AvlTestDelete(int pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(string.Format(@"DELETE FROM avlTest WHERE Code = {0}",pCode));
                return DB.Query_Execute() >= 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="Format">Default Format: {0}-{1}-{2} {3}:{4}:{5}
        /// {0}year , {1}month, {2}day, {3}hour, {4}minute, {5}second</param>
        /// <returns></returns>
        public static string ConvertGregorianToPersianDateTime(DateTime date,string Format="{0}-{1}-{2} {3}:{4}:{5}")
        {
            try
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                return string.Format(Format,
                     pc.GetYear(date),
                     pc.GetMonth(date),
                     pc.GetDayOfMonth(date),
                     pc.GetHour(date),
                     pc.GetMinute(date),
                     pc.GetSecond(date));
            }
            catch
            {
                return "";
            }
        }


       public static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream. 
            return encrypted;

        }

      public  static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}
