using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;

namespace RealEstate
{
    public class JBreakDownUnitBuilds : JSystem
    {
        bool _FlagDelete = false;
        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد تفکیک
        /// </summary>
        public int BreakDownCode { get; set; }
        /// <summary>
        /// کد اعیان جدید
        /// </summary>
        public int UnitBuildCode { get; set; }
        #endregion

        #region Method
        public int insert(JDataBase Db)
        {
            JBreakDownUnitBuildsTable JAGsT = new JBreakDownUnitBuildsTable();
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
            JBreakDownUnitBuildsTable JAGsT = new JBreakDownUnitBuildsTable();
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
            JBreakDownUnitBuildsTable JAGsT = new JBreakDownUnitBuildsTable();
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
        public bool DeleteManual(int pAggregateCode, JDataBase Db)
        {
            JBreakDownUnitBuildsTable JAGsT = new JBreakDownUnitBuildsTable();
            try
            {
                _FlagDelete = true;
                // JAGsT.DeleteManual(" AggregateCode=" + pAggregateCode.ToString(),Db);
                return true;//Update(GetDataTable(pAggregateCode), pAggregateCode, 0, Db);
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
        //public bool Update(JUnitBuild[] tmpdt, int pBreakDownCode, int pOldUnitBuildCode, JDataBase db)
        //{
        //    JBreakDownUnitBuildsTable PDT = new JBreakDownUnitBuildsTable();
        //    JUnitBuild tmpJUnitBuild = new JUnitBuild();
        //    try
        //    {
        //        if (tmpdt != null)
        //            for (int i = 0; i < tmpdt.Count;i++ )
        //            {

        //                BreakDownCode = pBreakDownCode;
        //                //UnitBuildCode 
        //                tmpJUnitBuild = (JUnitBuild)(dr["UnitBuildCode"]);
        //                Code = insert(db);
        //                tmpdt[i].Code = Code;
        //                tmpJUnitBuild.GetData(UnitBuildCode);
        //                tmpJUnitBuild.Status = UnitBuildStatus.BreakDown;
        //                tmpJUnitBuild.ParentCode = pOldUnitBuildCode;
        //                tmpJUnitBuild.Update(db, false);
        //                //آپدیت Asset مربوط به تجمیع غیر فعال
        //                JAsset Asset = new JAsset("RealEstate.JUnitBuild", UnitBuildCode, db);
        //                Asset.DeActive(db);
        //                //Asset.Status = JStatusType.Inactive;
        //                //Asset.Update(db);
        //                if (Code < 1)
        //                    return false;


        //                if ((dr.RowState == DataRowState.Deleted) || (_FlagDelete == true))
        //                {
        //                    dr.RejectChanges();
        //                    Code = (int)dr["Code"];
        //                    GetData(Code);
        //                    if (!Delete(db))
        //                        return false;
        //                    tmpJUnitBuild.GetData((int)dr["UnitBuildCode"]);
        //                    tmpJUnitBuild.Status = UnitBuildStatus.Active;
        //                    tmpJUnitBuild.ParentCode = 0;
        //                    tmpJUnitBuild.Update(db);
        //                    //آپدیت Asset مربوط به تجمیع  فعال
        //                    JAsset Asset = new JAsset("RealEstate.JUnitBuild", tmpJUnitBuild.Code, db);
        //                    Asset.Active(db);
        //                    //Asset.Status = JStatusType.Active;
        //                    //Asset.Update(db);
        //                    dr.Delete();
        //                }
        //            }
        //        tmpdt.AcceptChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //        return false;
        //    }
        //    //finally
        //    //{
        //    //    PDT.Dispose();
        //    //}
        //}

        public bool GetData(int pCode)
        {
            string Qouery = "select * from " + JRETableNames.RestBreakDownUnitBuilds + " where Code=" + pCode;
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
                where = " Where A.BreakDownCode=" + pAggregateCode.ToString();
            string Qouery = @"select 
A.Code,
A.UnitBuildCode 'UnitBuildCode',
U.MarketCode,
(select Title from estMarket where U.MarketCode=Code) 'MarketName',
U.Number 'NumberUnitBuild'
from REstBreakDownUnitBuilds A inner join estUnitBuild U on A.UnitBuildCode=U.Code " + where;
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

        public static void GetUnitBuildsBreakDown(ref JUnitBuild[] UnitBuilds, int BreakDownCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qoery = "select Code,BreakDownCode,UnitBuildCode from " + JRETableNames.RestBreakDownUnitBuilds + " where BreakDownCode="
                + JDataBase.Quote(BreakDownCode.ToString());
            try
            {
                int i = 0;
                Db.setQuery(Qoery);
                DataTable BreakDownGrouns = Db.Query_DataTable();
                UnitBuilds = new JUnitBuild[BreakDownGrouns.Rows.Count];
                foreach (DataRow Row in BreakDownGrouns.Rows)
                {
                    int groundCode = Convert.ToInt32(Row["UnitBuildCode"]);
                    UnitBuilds[i] = new JUnitBuild(groundCode);
                    i++;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}
