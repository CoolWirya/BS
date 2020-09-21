using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;
using Estates;

namespace RealEstate
{
    public class JPrimaryOwnerBuild
    {
        public JPrimaryOwnerBuild()
        {
        }

       public JPrimaryOwnerBuild(int pCode)
        {
            BuildCode=pCode;
        }

        #region Property
        public int Code { get; set; }
        /// <summary>
        /// کد اعیان
        /// </summary>
        public int BuildCode { get; set; }
        /// <summary>
        /// کد مالک اولیه
        /// </summary>
        public int PCode { set; get; }
        /// <summary>
        /// میزان سهم شخص از اعیان
        /// </summary>
        public float Share { set; get; }
        /// <summary>
        /// کد مشارکتی دارایی
        /// </summary>
        //public int AssetShareCode { get; set; }
        #endregion

        #region Method
        public int insert(JDataBase pDb)
        {
            JPrimaryOwnerBuildTable JPOT = new JPrimaryOwnerBuildTable();
            int DefaultCode = 999999;
            try
            {
                int Code;
                JPOT.SetValueProperty(this);
                Code = JPOT.Insert(pDb);
                if (Code > 0)
                {

                    //Add Relation
                    JRelation tmpJRelation = new JRelation();
                    tmpJRelation.PrimaryClassName = "ClassLibrary.AllPerson";
                    tmpJRelation.PrimaryObjectCode = JPOT.PCode;
                    tmpJRelation.ForeignClassName = "RealEstate.JPrimaryOwnerBuild";
                    tmpJRelation.ForeignObjectCode = Code;
                    tmpJRelation.Comment = "برای این شخص اعیان تعریف شده است";
                    if (!tmpJRelation.Insert(pDb))
                        return 0;

                    return Code;
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
                JPOT.Dispose();
            }
        }
        public bool Delete(JDataBase PDb)
        {
            try
            {
                JPrimaryOwnerBuildTable JPOT = new JPrimaryOwnerBuildTable();
                JPOT.SetValueProperty(this);
                if (JPOT.Delete(PDb))
                {
                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.CheckRelation("RealEstate.JPrimaryOwnerBuild", Code, PDb))
                        if (!tmpJRelation.Delete("RealEstate.JPrimaryOwnerBuild", Code, PDb))
                            return false;
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
        }

        public bool DeleteRelation(JDataBase PDb,int pUniteCode)
        {
            try
            {
                foreach (DataRow dr in JPrimaryOwnerBuilds.GetDataTable(pUniteCode).Rows)
                {
                    Code = (int)dr["Code"];
                    if (!Delete(PDb))
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Update(JDataBase pDb)
        {
            JPrimaryOwnerBuildTable JPOT = new JPrimaryOwnerBuildTable();
            try
            {
                JPOT.SetValueProperty(this);
                return JPOT.Update(pDb);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JPOT.Dispose();
            }
        }

        public bool Save(int pBuildCode, DataTable pPrimeryOwnerBuild, JDataBase pDb, JAssetTransfer AssetTransfer, JAssetTransfer GoodwillAssetTransfer)
        {
            JPrimaryOwnerBuild JPOB = new JPrimaryOwnerBuild(0);
            try
            {
                foreach (DataRow Row in pPrimeryOwnerBuild.Rows)
                {
                    /// در صورتی که سطر اضافه شده باشد
                    if (Row.RowState == DataRowState.Added)
                    {
                        PCode = Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.PCode.ToString()]);
                        Share = Convert.ToSingle(Row[JPrimaryOwnerBuildTableEnum.Share.ToString()]);
                        BuildCode = pBuildCode;// Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.BuildCode.ToString()]);
                        insert(pDb);

                        Row[JPrimaryOwnerBuildTableEnum.Code.ToString()] = Code;

                        #region Insert AssetShare
                        //ذخیره اطلاعات دارایی شخص د رجدول دارایی
                        JAssetShare AssetShare = new JAssetShare();
                        AssetShare.ACode = AssetTransfer.ACode;
                        AssetShare.PersonCode = PCode;
                        AssetShare.Share = Share;
                        AssetShare.ParentCode = 0;
                        AssetShare.Status = JStatusType.Active;
                        AssetTransfer.OwnershipType = JOwnershipType.Definitive;
                        AssetTransfer.AddItems(AssetShare);
                        #endregion

                        #region Insert AssetShare
                        //ذخیره اطلاعات دارایی شخص د رجدول دارایی
                        JAssetShare GWAssetShare = new JAssetShare();
                        GWAssetShare.ACode = AssetTransfer.ACode;
                        GWAssetShare.PersonCode = PCode;
                        GWAssetShare.Share = Share;
                        GWAssetShare.ParentCode = 0;
                        GWAssetShare.Status = JStatusType.Active;
                        GoodwillAssetTransfer.OwnershipType = JOwnershipType.Goodwill;
                        GoodwillAssetTransfer.AddItems(GWAssetShare);
                        #endregion
                    }
                    /// در صورتی که سطر حذف شده باشد
                    if (Row.RowState == DataRowState.Deleted)
                    {
                        Row.RejectChanges();
                        if (Row[JPrimaryOwnerBuildTableEnum.Code.ToString()] != DBNull.Value)
                        {
                            Code = (int)Row[JPrimaryOwnerBuildTableEnum.Code.ToString()];
                            PCode = Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.PCode.ToString()]);
                            //AssetTransfer.get
                            AssetTransfer.ChangeItemShare(PCode, -1);
                            //حذف دارایی از جدول دارایی های جزء
                            Delete(pDb);
                            Row.Delete();
                        }
                        else
                            Row.Delete();

                    }
                    /// در صورتی که سطر ویرایش شده باشد
                    if (Row.RowState == DataRowState.Modified)
                    {
                        JPOB.Code = (int)Row[JPrimaryOwnerBuildTableEnum.Code.ToString()];
                        JPOB.PCode = Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.PCode.ToString()]);
                        JPOB.Share = Convert.ToSingle(Row[JPrimaryOwnerBuildTableEnum.Share.ToString()]);
                        JPOB.BuildCode = Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.BuildCode.ToString()]);
                        //آپدیت میزان دارایی شخص در جدول دارایی ها
                        AssetTransfer.ChangeItemShare(JPOB.PCode, Convert.ToSingle(Row[JPrimaryOwnerBuildTableEnum.Share.ToString()]));

                        if (!JPOB.Update(pDb))
                            return false;
                    }
                }
                pPrimeryOwnerBuild.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        #endregion
    }


    public class JPrimaryOwnerBuilds:JSystem
    {
        /// <summary>
        /// جدول مربوط به مالکین اولیه یک اعیان  را بر می گرداند
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(int UniteCode)
        {
            string Qouery = "select " + JTableNamesEstate.PrimaryOwnerBuild + ".Code,"
                  + JTableNamesClassLibrary.AllPerson + ".Code " + JPrimaryOwnerBuildTableEnum.PCode + ","
                + JTableNamesClassLibrary.AllPerson + ".Name " + JPrimaryOwnerBuildTableEnum.Name + ","
                //+ JTableNamesClassLibrary.AllPerson + ".Fam " + JPrimaryOwnerBuildTableEnum.fam + ","
                //+ JTableNamesClassLibrary.AllPerson + ".shsh " + JPrimaryOwnerBuildTableEnum.shsh + ","
                + JTableNamesEstate.UnitBuild + ".Code "+JPrimaryOwnerBuildTableEnum.BuildCode+","
                + JTableNamesEstate.UnitBuild + "." + JPrimaryOwnerBuildTableEnum.Plaque + " ,Share from "
                + JTableNamesEstate.PrimaryOwnerBuild + " inner join "
                + JTableNamesClassLibrary.AllPerson + " on " + JTableNamesClassLibrary.AllPerson +
                ".Code=" + JTableNamesEstate.PrimaryOwnerBuild + ".PCode inner join "
                + JTableNamesEstate.UnitBuild + " on " + JTableNamesEstate.UnitBuild + ".Code="
                + JTableNamesEstate.PrimaryOwnerBuild + ".BuildCode";
            string Where = "";
            
                Where = " where " + JTableNamesEstate.PrimaryOwnerBuild + ".BuildCode=" + UniteCode;
            
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(Qouery + Where);
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

        public void ListView()
        {
            Nodes.Insert(JREsStaticNode._DefaultOwnersNode());
        }
    }
}
