using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Finance;

namespace Legal
{
    public class JDistraintAssetShare : JSystem
    {
        #region Property

        public int Code
        {
            get;
            set;
        }
        /// <summary>
        /// نوع :توقیف یا ممنوع المعامله
        /// </summary>

        /// <summary>
        /// کددارایی جزء
        /// </summary>
        public int AssetShareCode
        {
            set;
            get;
        }
        /// <summary>
        /// کدجدول اصلی توقیف اموال
        /// </summary>
        public int Distraint
        {
            get;
            set;
        }
        /// <summary>
        /// تعداد سهم توقیف شده
        /// </summary>
        public float Distrainted
        {
            get;
            set;
        }
        /// <summary>
        /// کد دارایی
        /// </summary>
        public int ACode
        {
            get;
            set;
        }
        #endregion
        public JDistraintAssetShare()
        {
        }
  
        #region Search

        public bool GetData(int pCode)
        {
            string Query = " SELECT * FROM legDistraintAssetShare WHERE Code = " + pCode;
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(Query);
                DataTable tb = Db.Query_DataTable();
                if (tb.Rows.Count > 0)
                {
                    JTable.SetToClassProperty(this, tb.Rows[0]);
                    return true;
                }
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
        /// جستجو براساس کد دارایی جزئی
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool find(int pCode, JDataBase Db)
        {
            string Qouery = "select * from legDistraintAssetShare where AssetShareCode=" + JDataBase.Quote(pCode.ToString());
            try
            {
                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
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
                Db.Dispose();
            }



        }
        #endregion
        #region Method
        public int Insert(JDataBase pDb)
        {
            //if (find(this.AssetShareCode, pDb))
            //{
            //    return 0;
            //}
            JDistraintAssetShareTable JDAST = new JDistraintAssetShareTable();

            try
            {
                JDAST.SetValueProperty(this);
                if (JDAST.Insert(pDb) > 0)
                {
                    Histroy.Save(this, JDAST, JDAST.Code, "Insert");
                    if (JDAST.Code > 0)
                    {
                        //Add Relation
                        JRelation tmpJRelation = new JRelation();
                        tmpJRelation.PrimaryClassName = "ClassLibrary.AssetShare";
                        tmpJRelation.PrimaryObjectCode = JDAST.AssetShareCode;
                        tmpJRelation.ForeignClassName = "Legal.JDistraintAssetShare";
                        tmpJRelation.ForeignObjectCode = JDAST.Code;
                        tmpJRelation.Comment = "برای این جزئ دارایی شخص اطلاعات توقیف ثبت شده است";
                        if (!tmpJRelation.Insert(pDb))
                            return -1;
                        return JDAST.Code;
                    }
                    else
                        return -1;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JDAST.Dispose();
            }
        }
        public bool Update(JDataBase pDb)
        {
            JDistraintAssetShareTable JDAST = new JDistraintAssetShareTable();
            try
            {
                JDAST.SetValueProperty(this);
                if (JDAST.Update(pDb))
                {
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
                JDAST.Dispose();
            }

        }
        /// <summary>
        /// ویرایش تعداد سهم توقیف شده
        /// </summary>
        /// <param name="pDB"></param>
        /// <param name="pCode"></param>
        /// <param name="pNewDistrained"></param>
        /// <returns></returns>
        public static bool UpdateManual(JDataBase pDB, int pCode, float pNewDistrained)
        {
            string Query = " UPDATE legDistraintAssetShare SET Distrainted = " + pNewDistrained.ToString() +
                " WHERE Code = " + pCode.ToString();
            pDB.setQuery(Query);
            try
            {
                return pDB.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {

            }
        }

        public bool Delete(JDataBase pDb)
        {
            JDistraintAssetShareTable JDAST = new JDistraintAssetShareTable();
            try
            {
                JDAST.SetValueProperty(this);
                if (JDAST.Delete(pDb))
                {
                    Histroy.Save(this, JDAST, JDAST.Code, "Delete");

                    //Delete Relation
                    JRelation tmpJRelation = new JRelation();
                    if (!tmpJRelation.Delete("Legal.JDistraintAssetShare", JDAST.Code, pDb))
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
            finally
            {
                JDAST.Dispose();
            }
        }
        #endregion
    }

    class JDistraintAssetShares
    {
        public static void Save(int pDistaintCode, DataTable AssetShareTable, JDataBase pDb)
        {
            try
            {
                foreach (DataRow Row in AssetShareTable.Rows)
                {

                    //if (Row.RowState == DataRowState.Modified && !(bool)Row["IsDistraint"])
                    if (Row.RowState == DataRowState.Modified)
                    {
                        if (Row["Code"].ToString() == "")
                        {
                            JDistraintAssetShare distShare = new JDistraintAssetShare();
                            float _distrainted = (float)Convert.ToDecimal(Row["Distrainted"]);
                            //distShare.AssetShareCode = Convert.ToInt32(Row["ShareCode"]);
                            distShare.ACode = Convert.ToInt32(Row["ACode"]);
                            distShare.Distraint = pDistaintCode;
                            distShare.Distrainted = _distrainted;
                            distShare.Insert(pDb);
                        }

                        else if (Row["Code"].ToString() != "")
                        {
                            int _code = Convert.ToInt32(Row["Code"]);
                            float _distrainted = (float)Convert.ToDecimal(Row["Distrainted"]);
                            JDistraintAssetShare.UpdateManual(pDb, _code, _distrainted);
                        }
                    }
                }

                    //{
                    //    JDAS.AssetShareCode = Convert.ToInt32(Row["Code"]);
                    //    JDAS.Distraint = pDistaintCode;
                    //    JDAS.Code = Convert.ToInt32(Row["DistraintCode"]);
                    //    JDAS.Delete(pDb);
                    //    //فعال کردن جزئی از دارای در جدول جزئی از دارائی ها
                    //    JAssetShare AssetShare = new JAssetShare(Convert.ToInt32(Row["Code"]));
                    //    AssetShare.Status = JStatusType.Active;
                    //    AssetShare.Update(pDb);

                    //}

                    //if (Row.RowState == DataRowState.Modified && (bool)Row["IsDistraint"])
                    //{
                    //    try
                    //    {
                    //        JDAS.AssetShareCode = Convert.ToInt32(Row["Code"]);
                    //        JDAS.Distraint = pDistaintCode;
                    //        JDAS.Insert(pDb);
                    //        JAssetShare AssetShare = new JAssetShare(Convert.ToInt32(Row["Code"]));
                    //        AssetShare.Status = JStatusType.Block;
                    //        AssetShare.Update(pDb);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        JSystem.Except.AddException(ex);
                    //    }

                    //}

                AssetShareTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }


        public static bool DelDistraintAssetShare(int pDistaintCode, DataTable AssetShareTable, JDataBase pDb)
        {

            string Query = " DELETE FROM legDistraintAssetShare WHERE Distraint = " + pDistaintCode.ToString();
            pDb.setQuery(Query);
            try
            {
                return pDb.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {

            }
            //JDistraintAssetShare JDAS = new JDistraintAssetShare();
            //foreach (DataRow Row in AssetShareTable.Rows)
            //{
            //    JDAS.AssetShareCode = Convert.ToInt32(Row["Code"]);
            //    JDAS.Delete(pDb);

            //}
        }
        /// <summary>
        /// لیست دارایی های شخص و وضعیت آنها در جدول توقیفی
        /// </summary>
        /// <param name="pPersonCode"></param>
        /// <returns></returns>
        public static DataTable GetPersonShares(Int64 pPersonCode, Int64 pDistraintCode)
        {

            string _query = @" Select DA.Code Code,  FA.Code ACode , FA.Comment, FAS.Share, DA.Distrainted
,Case  FAT.OwnershipType when 1 then 'مالکیت قطعی' when 2 then 'مالکیت سرقفلی' else '' end OwnershipType
, FAT.Comment TransferComment
FROM finAsset FA 
inner join finAssetTransfer FAT on FA.Code = FAT.ACode 
inner join finAssetShare FAS on FAT .Code = FAS.TCode  and FAS.Status = 1
left join  LegDistraintAssetShare DA  on DA.ACode = FA.Code   AND DA.Distraint =" + pDistraintCode +
" Where FAS.PersonCode = " + pPersonCode.ToString();
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(_query);
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

        public static DataTable GetDataTable(int pDistraintCode)
        {
            string qoury = "select Code,AssetShareCode,Distraint from " + JTableNamesLegal.DistraintAssetShare +
                " WHERE Distraint = " + pDistraintCode.ToString();
            JDataBase Db=new JDataBase();
            try
            {
                Db.setQuery(qoury);
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


       







    

