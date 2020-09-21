using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;
using System.Data;
using Finance;

namespace RealEstate
{
    public class JInformationUnitBuild : JRealEstate
    {
        #region Properties
        public int Code { set; get; } 
        public int UnitBuildCode { set; get; }         
        /// <summary>
        /// تلفن
        /// </summary>
        public string Tel  { set;get;}
        /// <summary>
        /// عنوان
        /// </summary>
        public int TelType { set; get; }
        /// <summary>
        /// پیش فرض
        /// </summary>
        public bool DefaultValue { set; get; }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public bool InsertUpdate(int pUnitBuildCode, DataTable pDt)
        {
            try
            {
                JDataBase pDB = JGlobal.MainFrame.GetDBO();
                if (pDt != null)
                    foreach (DataRow dr in pDt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            UnitBuildCode = pUnitBuildCode;
                            Tel = dr["Tel"].ToString();
                            TelType = Convert.ToInt32(dr["TelType"]);
                            DefaultValue = Convert.ToBoolean(dr["DefaultValue"]); 
                            Insert(pDB);
                            if (Code <= 0)
                                return false;
                        }
                        if (dr.RowState == DataRowState.Modified)
                        {
                            UnitBuildCode = pUnitBuildCode;
                            Tel = dr["Tel"].ToString();
                            TelType = Convert.ToInt32(dr["TelType"]);
                            DefaultValue = Convert.ToBoolean(dr["DefaultValue"]);
                            Code = (int)dr["Code"];
                            Update(pDB);
                            if (Code <= 0)
                                return false;
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            delete(pUnitBuildCode,pDB);
                            dr.Delete();
                        }
                    }
                pDt.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase db)
        {
            JInformationUnitBuildTable PDT = new JInformationUnitBuildTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(db);
                Histroy.Save(this, PDT, PDT.Code, "Insert");
                return PDT.Code;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                PDT.Dispose();
            }
            return 0;
        }
      
        /// <summary>
        /// بروزرسانی 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase db)
        {
            JInformationUnitBuildTable PDT = new JInformationUnitBuildTable();
            try
            {
                PDT.SetValueProperty(this);
                return PDT.Update();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(int pCode, JDataBase db)
        {
            JInformationUnitBuildTable PDT = new JInformationUnitBuildTable();
            try
            {
                    GetData(pCode);
                    PDT.SetValueProperty(this);
                    return PDT.Delete();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JRETableNames.InformationUnitBuild + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        /// <summary>
        ///  اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int pUnitBuildCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT 
code,teltype,
(case teltype 
when 1 then 'ثابت'
when 2 then 'همراه'
when 3 then 'منزل'
when 4 then 'محل کار'
when 5 then 'ضروری'
when 6 then 'فاکس'
end) 'TitleType',Tel,DefaultValue               
                FROM " + JRETableNames.InformationUnitBuild + " WHERE UnitBuildCode=" + pUnitBuildCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }            
        }
        #endregion
    }
}
