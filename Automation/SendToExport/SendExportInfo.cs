using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;


namespace Automation
{
    public class JSendExportInfo : JSystem
    {
        #region Properties

        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///کد نامه
        /// </summary>
        public int LetterCode { get; set; }
        /// <summary>
        ///نوع ارسال
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        ///شرح ارسال
        /// </summary>
        public string Description { get; set; }

        #endregion

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                if (JPermission.CheckPermission("Automation.JSendExportInfo.Insert"))
                {
                    JSendExportInfoTable JLT = new JSendExportInfoTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert(db);
                    if (Code > 0)
                    {
                        return Code;
                    }
                    return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JSendExportInfoTable PDT = new JSendExportInfoTable();
            JDataBase Db = new JDataBase();
            try
            {
                if (JPermission.CheckPermission("Automation.JSendExportInfo.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(Db))
                        return true;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {                
            JDataBase Db = new JDataBase();
            try
            {
                JSendExportInfoTable PDT = new JSendExportInfoTable();
                if (JPermission.CheckPermission("Automation.JSendExportInfo.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                    {
                        return true;
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #region search method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from AutoSendToExport where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static DataTable GetDataTable(int pLetterCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = @"select Code , case type 
when 1 then 'پستی' 
when 2 then 'فکس' 
when 3 then 'تحویل حضوری' end 'SendType',
Description  from AutoSendToExport where LetterCode=" + pLetterCode;
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
        #endregion

        public void ShowDialog(int pLetterCode)
        {
            JSendToExport p = new JSendToExport(pLetterCode);
            p.ShowDialog();
        }
    }
}
