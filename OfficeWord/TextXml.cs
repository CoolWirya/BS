using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace OfficeWord
{
    public class JTextXml
    {
        #region Properties

        public int Code { get; set; }
        public int FileCode { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Xml { get; set; }

        #endregion

        #region method

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public long Insert()
        {
            JTextXmlTable JLT = new JTextXmlTable();
            try
            {
                JLT.SetValueProperty(this);
                Code = JLT.Insert();
                if (Code > 0)
                    return Code;
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JLT.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JTextXmlTable PDT = new JTextXmlTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete())
                    return true;
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pFileCode)
        {
            JTextXmlTable PDT = new JTextXmlTable();
            try
            {
                if (PDT.DeleteManual(" FileCode=" + pFileCode))
                    return true;
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JTextXmlTable PDT = new JTextXmlTable();
            try
            {                
                PDT.SetValueProperty(this);
                PDT.Code = Code;
                if (PDT.Update())
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable Find(int pFileCode,string pTag, string pXml)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string WHERE = @"select * From TextXml Where 1=1 ";
                if (pFileCode != 0)
                    WHERE = WHERE + " And FileCode = " + pFileCode;
                if (pTag != "")
                    WHERE = WHERE + " And Tag = N'" + pTag + "'";
                if (pXml != "")
                    WHERE = WHERE + " And Xml = N'" + pXml + "'";

                DB.setQuery(WHERE);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        #endregion
    }

    public class JTextXmls
    {
        public static void Delete(int pFileCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string SQL = @"DELETE FROM TextXml Where FileCode = " + pFileCode;
                DB.setQuery(SQL);
                DB.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }

    class JTextXmlTable : JTable
    {
        public JTextXmlTable()
            : base("TextXml")
        {
        }
        public int FileCode;

        public string Tag;
        /// <summary>
        /// 
        /// </summary>
        public string Xml;

    }
}
