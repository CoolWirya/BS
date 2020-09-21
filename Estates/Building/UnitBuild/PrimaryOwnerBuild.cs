using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;

namespace Estates
{
    class JPrimaryOwnerBuild
    {
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
        public int AssetShareCode { get; set; }
        #endregion

        #region Method
        public int insert(JDataBase pDb)
        {
            JPrimaryOwnerBuildTable JPOT = new JPrimaryOwnerBuildTable();
            int DefaultCode=999999;
            try
            {
                int Code;
                JPOT.SetValueProperty(this);
                Code = JPOT.Insert(pDb);
                return Code;
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
                return JPOT.Delete(PDb);
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

        #endregion
    }


    class JPrimaryOwnerBuilds
    {
        public static bool Save(int pBuildCode, DataTable pPrimeryOwnerBuild, JDataBase pDb,int AssetCode)
        {
            JPrimaryOwnerBuild JPOB = new JPrimaryOwnerBuild(0);
            try
            {
                foreach (DataRow Row in pPrimeryOwnerBuild.Rows)
                {
                    if (Row.RowState == DataRowState.Added)
                    {
                        JPOB.PCode = Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.PCode.ToString()]);
                        JPOB.Share = Convert.ToSingle(Row[JPrimaryOwnerBuildTableEnum.Share.ToString()]);
                        JPOB.BuildCode = pBuildCode;// Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.BuildCode.ToString()]);
                        int _Code = JPOB.insert(pDb);
                   
                        Row[JPrimaryOwnerBuildTableEnum.Code.ToString()] = _Code;
                        //ذخیره اطلاعات دارایی شخص د رجدول دارایی
                        JAssetShare AssetShare = new JAssetShare();
                        AssetShare.ACode = AssetCode;
                        AssetShare.PersonCode = JPOB.PCode;
                        AssetShare.Share = JPOB.Share;
                        //کدمشارکتی دارایی ثبت شده
                        int AShareCode=AssetShare.Insert();
                        JPOB.Code = _Code;
                        JPOB.AssetShareCode = AShareCode;
                        JPOB.Update(pDb);

                    }
                    if (Row.RowState == DataRowState.Deleted)
                    {
                        Row.RejectChanges();
                        if (Row[JPrimaryOwnerBuildTableEnum.Code.ToString()] != DBNull.Value)
                        {
                            JPOB.Code = (int)Row[JPrimaryOwnerBuildTableEnum.Code.ToString()];
                            JPOB.Delete(pDb);
                            //خذف دارایی شخص از جدول دارایی ها
                            JAssetShare AssetShare = new JAssetShare();
                            AssetShare.Code =(int)Row[JPrimaryOwnerBuildTableEnum.AssetShareCode.ToString()];
                            AssetShare.Delete();
                            Row.Delete();
                        }
                        else
                            Row.Delete();

                    }
                    if (Row.RowState == DataRowState.Modified)
                    {
                        JPOB.Code = (int)Row[JPrimaryOwnerBuildTableEnum.Code.ToString()];
                        JPOB.PCode = Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.PCode.ToString()]);
                        JPOB.Share = Convert.ToSingle(Row[JPrimaryOwnerBuildTableEnum.Share.ToString()]);
                        JPOB.BuildCode = Convert.ToInt32(Row[JPrimaryOwnerBuildTableEnum.BuildCode.ToString()]);
                        //آپدیت میزان دارایی شخص در جدول دارایی ها
                        JAssetShare AssetShare = new JAssetShare();
                        AssetShare.Code = (int)Row[JPrimaryOwnerBuildTableEnum.AssetShareCode.ToString()];
                        AssetShare.Share = Convert.ToSingle(Row[JPrimaryOwnerBuildTableEnum.Share.ToString()]);
                        AssetShare.Update();
                        JPOB.Update(pDb);
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
                + JTableNamesEstate.UnitBuild + "." + JPrimaryOwnerBuildTableEnum.Plaque + " ,Share,AssetShareCode from "
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
    }
}
