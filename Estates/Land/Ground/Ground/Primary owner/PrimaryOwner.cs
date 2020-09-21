using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;
using Finance;

namespace Estates
{
    public class JPrimaryOwner:JSystem
    {
        #region Property
        /// <summary>
        /// کد
        /// </summary>
        public int Code { set; get; }
        /// <summary>
        /// کدزمین
        /// </summary>
        public int CodeGround { set; get; }
        /// <summary>
        /// کدمالک اولیه
        /// </summary>
        public int PCode { set; get; }
        /// <summary>
        /// میزان سهم شخص از این زمین
        /// </summary>
        public float Share { get; set; }
        #endregion

        #region Functions
        public int Insert(JDataBase pDB)
        {
                JPrimaryOwnerTable table = new JPrimaryOwnerTable();
                table.SetValueProperty(this);
                return table.Insert(pDB);
        }

        public bool Update(JDataBase pDB)
        {
                JPrimaryOwnerTable table = new JPrimaryOwnerTable();
                table.SetValueProperty(this);
                return table.Update(pDB);
        }

        public bool Delete(JDataBase pDB)
        {
                JPrimaryOwnerTable table = new JPrimaryOwnerTable();
                table.SetValueProperty(this);
                return table.Delete(pDB);          
        }

        #endregion Functions


    }

    public class JPrimaryOwners : JSystem
    {
        public static bool Save(int pGroundCode, DataTable pPrimeryOwners, JDataBase pDb, JAssetTransfer AssetTransfer)
        {
            JPrimaryOwner JPOB = new JPrimaryOwner();
            try
            {
                    foreach (DataRow Row in pPrimeryOwners.Rows)
                    {
                        /// در صورتی که سطر اضافه شده باشد
                        if (Row.RowState == DataRowState.Added)
                        {
                            JPOB.PCode = Convert.ToInt32(Row[JPrimaryOwnerField.PCode.ToString()]);
                            JPOB.Share = Convert.ToSingle(Row[JPrimaryOwnerField.Share.ToString()]);
                            JPOB.CodeGround = pGroundCode;
                            int _Code = JPOB.Insert(pDb);

                            Row[JPrimaryOwnerField.Code.ToString()] = _Code;

                            //Add Relation
                            JRelation tmpJRelation = new JRelation();
                            tmpJRelation.PrimaryClassName = "ClassLibrary.Person";
                            tmpJRelation.PrimaryObjectCode = JPOB.PCode;
                            tmpJRelation.ForeignClassName = "Estates.JPrimaryOwners";
                            tmpJRelation.ForeignObjectCode = _Code;
                            tmpJRelation.Comment = "برای این زمین مالک اولیه ثبت شده است";
                            if (!tmpJRelation.Insert(pDb))
                                return false;

                            #region Insert AssetShare
                            //ذخیره اطلاعات دارایی شخص در جدول دارایی
                            JAssetShare AssetShare = new JAssetShare();
                            AssetShare.ACode = AssetTransfer.ACode;
                            AssetShare.PersonCode = JPOB.PCode;
                            AssetShare.Share = JPOB.Share;
                            AssetShare.ParentCode = 0;
                            AssetShare.Status = JStatusType.Active;
                            AssetTransfer.OwnershipType = JOwnershipType.Definitive;
                            AssetTransfer.AddItems(AssetShare);
                            #endregion
                        }
                        /// در صورتی که سطر حذف شده باشد
                        if (Row.RowState == DataRowState.Deleted)
                        {
                            Row.RejectChanges();
                            if (Row[JPrimaryOwnerField.Code.ToString()] != DBNull.Value)
                            {
                                JPOB.Code = (int)Row[JPrimaryOwnerField.Code.ToString()];
                                JPOB.PCode = Convert.ToInt32(Row[JPrimaryOwnerField.PCode.ToString()]);
                                //AssetTransfer.get
                                AssetTransfer.ChangeItemShare(JPOB.PCode, -1);
                                //حذف دارایی از جدول دارایی های جزء
                                JPOB.Delete(pDb);
                                Row.Delete();

                                //Delete Relation
                                JRelation tmpJRelation = new JRelation();
                                if (!tmpJRelation.Delete("Estates.JPrimaryOwners", JPOB.Code, pDb))
                                    return false;

                            }
                            else
                                Row.Delete();

                        }
                        /// در صورتی که سطر ویرایش شده باشد
                        if (Row.RowState == DataRowState.Modified)
                        {
                            JPOB.Code = (int)Row[JPrimaryOwnerField.Code.ToString()];
                            JPOB.PCode = Convert.ToInt32(Row[JPrimaryOwnerField.PCode.ToString()]);
                            JPOB.Share = Convert.ToSingle(Row[JPrimaryOwnerField.Share.ToString()]);
                            JPOB.CodeGround = pGroundCode;
                            //آپدیت میزان دارایی شخص در جدول دارایی ها
                            if (!AssetTransfer.ChangeItemShare(JPOB.PCode, Convert.ToSingle(Row[JPrimaryOwnerField.Share.ToString()])))
                            {
                                #region Insert AssetShare
                                //ذخیره اطلاعات دارایی شخص در جدول دارایی
                                JAssetShare AssetShare = new JAssetShare();
                                AssetShare.ACode = AssetTransfer.ACode;
                                AssetShare.PersonCode = JPOB.PCode;
                                AssetShare.Share = JPOB.Share;
                                AssetShare.ParentCode = 0;
                                AssetShare.Status = JStatusType.Active;
                                AssetTransfer.OwnershipType = JOwnershipType.Definitive;
                                AssetTransfer.AddItems(AssetShare);
                                #endregion

                            }

                            if (!JPOB.Update(pDb))
                                return false;
                        }
                    }
                    pPrimeryOwners.AcceptChanges();
                    return true;
                }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }


        }
    }
}
