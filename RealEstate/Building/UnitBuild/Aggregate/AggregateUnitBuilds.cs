using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;
namespace RealEstate
{
    public class JAggregateUnitBuilds : JSystem
    {
        bool _FlagDelete = false;
        #region Property 
        public int Code { get; set; }
        /// <summary>
        /// کد تجمیع
        /// </summary>
        public int AggregateCode { get; set; }
        /// <summary>
        /// کد اعیان قدیم
        /// </summary>
        public int UnitBuildCode { get; set; }
        #endregion

        #region Method
        public int insert(JDataBase Db)
        {
            JAggregateUnitBuildsTable JAGsT = new JAggregateUnitBuildsTable();
            try
            {
                JAGsT.SetValueProperty(this);
                return JAGsT.Insert(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JAGsT.Dispose();
            }
        }
        public bool Update(JDataBase Db)
        {
            JAggregateUnitBuildsTable JAGsT = new JAggregateUnitBuildsTable();
            try
            {
                JAGsT.SetValueProperty(this);
                return JAGsT.Update(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JAGsT.Dispose();
            }
        }
        public bool Delete(JDataBase Db)
        {
            JAggregateUnitBuildsTable JAGsT = new JAggregateUnitBuildsTable();
            try
            {
                JAGsT.SetValueProperty(this);
                return JAGsT.Delete(Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JAGsT.Dispose();
            }
        }
        public bool DeleteManual(int pAggregateCode,JDataBase Db)
        {
            JAggregateUnitBuildsTable JAGsT = new JAggregateUnitBuildsTable();
            try
            {
                _FlagDelete = true;
                // JAGsT.DeleteManual(" AggregateCode=" + pAggregateCode.ToString(),Db);
                return Update(GetDataTable(pAggregateCode), pAggregateCode, 0, Db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            //finally
            //{
            //    JAGsT.Dispose();
            //}
        }
        #endregion

        /// <summary>
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable tmpdt, int pAggregateCode,int pNewUnitBuildCode, JDataBase db)
        {
            JAggregateUnitBuildsTable PDT = new JAggregateUnitBuildsTable();
            JUnitBuild tmpJUnitBuild = new JUnitBuild();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if ((dr.RowState == DataRowState.Added) || ((dr.RowState == DataRowState.Unchanged) && (dr["Code"].ToString() == "")))
                        {
                            AggregateCode = pAggregateCode;
                            UnitBuildCode = Convert.ToInt32(dr["UnitBuildCode"]);
                            Code = insert(db);
                            dr["Code"] = Code;
                            tmpJUnitBuild.GetData(UnitBuildCode);
                            tmpJUnitBuild.Status = UnitBuildStatus.Aggregate;
                            tmpJUnitBuild.ParentCode = pNewUnitBuildCode;
                            tmpJUnitBuild.Update(db, false);
                            //آپدیت Asset مربوط به تجمیع غیر فعال
                            JAsset Asset = new JAsset("RealEstate.JUnitBuild", UnitBuildCode, db);
                            Asset.DeActive(db);
                            //Asset.Status = JStatusType.Inactive;
                            //Asset.Update(db);
                            if (Code < 1)
                                return false;
                        }
                        //if ((dr.RowState == DataRowState.Modified) && (dr["Code"].ToString() != ""))
                        //{
                        //    Code = (int)dr["Code"];
                        //    AggregateCode = pAggregateCode;
                        //    UnitBuildCode = Convert.ToInt32(dr["UnitBuildCode"]);
                        //    //GetData(Code);
                        //    if (!Update(db))
                        //        return false;
                        //}
                        if ((dr.RowState == DataRowState.Deleted) || (_FlagDelete == true))
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            if (!Delete(db))
                                return false;
                            tmpJUnitBuild.GetData((int)dr["UnitBuildCode"]);
                            tmpJUnitBuild.Status = UnitBuildStatus.Active;
                            tmpJUnitBuild.ParentCode = 0;
                            tmpJUnitBuild.Update(db);
                            //آپدیت Asset مربوط به تجمیع  فعال
                            JAsset Asset = new JAsset("RealEstate.JUnitBuild", tmpJUnitBuild.Code, db);
                            //Asset.Active(db);
                            //Asset.Status = JStatusType.Active;
                            //Asset.Update(db);
                            dr.Delete();
                        }
                    }
                tmpdt.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            //finally
            //{
            //    PDT.Dispose();
            //}
        }

        public bool GetData(int pCode)
        {
            string Qouery = "select * from " + JRETableNames.RestAggregateUnitBuilds + " where Code=" + pCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);                    
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

        public static DataTable GetDataTable(int pAggregateCode)
        {
            string where = "";
            if (pAggregateCode > 0)
                where = " Where A.AggregateCode=" + pAggregateCode.ToString();
            string Qouery = @"select 
A.Code,
A.UnitBuildCode 'UnitBuildCode',
U.MarketCode,
(select Title from estMarket where U.MarketCode=Code) 'MarketName',
U.Number 'NumberUnitBuild'
from REstAggregateUnitBuilds A inner join estUnitBuild U on A.UnitBuildCode=U.Code " + where;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery);
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
    }
}
