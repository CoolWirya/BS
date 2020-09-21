using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Legal
{
    public class JRepairContract
    {
        private int _ContractCode;
        private int _OldTransferCode;

        public JSubjectContract Contract;
        public int PreContract;

        public System.Data.DataTable SellerPersonsContract;

        public System.Data.DataTable BuyerPersonsContract;
        public System.Data.DataTable OldBuyers;

        public JRepairContract(int pContactCode, DataTable pOldBuyers, int pOldTransferCode)
        {
            _OldTransferCode = pOldTransferCode;
            _ContractCode = pContactCode;
            OldBuyers = pOldBuyers;
            LoadPersonContract();
        }
        public JRepairContract(int pContactCode)
        {
            _ContractCode = pContactCode;
            _OldTransferCode = getTransferCode(pContactCode);
            LoadPersonContract();
            ///GetPrimaryOwnerTransfer();
        }
        /// <summary>
        /// اصلاح قراردادها از ابتدا
        /// </summary>
        public bool RepairAll()
        {
            string Query = " UPDATE legSubjectContract SET Modified = 0 WHERE FinanceCode = " + Contract.FinanceCode.ToString();
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(Query);
                return DB.Query_Execute() >= 0;
            }
            finally
            {
                DB.Dispose();
            }
            
        }

        private int getTransferCode(int pContractCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(
 @"select Code from finAssetTransfer where ObjectCode IN 
	(select Code from estPrimaryOwnerBuild where BuildCode in 
		(select Code from finAsset where Code in
			(
				select FinanceCode from LegSubjectContract where Code = " + pContractCode.ToString() +
                @"
			)
		 )
	)
 and classname = 'RealEstate.JPrimaryOwnerBuild' and OwnershipType = 2"
                    );
                db.Query_DataReader();
                if (db.DataReader.Read())
                    return (int)db.DataReader["Code"];
                return 0;
            }
            finally
            {
                db.DisConnect();
            }
            return 0;
        }

        private void LoadPersonContract()
        {
            if (Contract == null)
                Contract = new JSubjectContract();
            Contract.GetData(_ContractCode);

            LoadSellerPersonContract();
            LoadBuyerPersonContract();
        }

        private void GetPrimaryOwnerTransfer()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"
                    Select at.Code from finAssetTransfer at inner join finAssetShare sh on at.Code = sh.TCode 
                    inner join finAsset fas on fas.Code = at.ACode
                    where at.OwnershipType=2 and at.ClassName = 'RealEstate.JPrimaryOwnerBuild'
                    and fas.Code = " + Contract.FinanceCode.ToString());
                _OldTransferCode = Convert.ToInt32(db.Query_DataTable().Rows[0][0]);
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
        }
        public void Show()
        {
            JRepairContractForm repairForm = new JRepairContractForm(this);
            //if (OldBuyers == null)
            //    repairForm = new JRepairContractForm(_ContractCode);
            //else
            repairForm.Show();
        }

        private void LoadSellerPersonContract(DataTable oldBuyers)
        {
            SellerPersonsContract.Merge(oldBuyers);
            int i = 0;
            foreach (DataRow row in oldBuyers.Rows)
            {
                try
                {
                    SellerPersonsContract.Select("PersonCode="+row["PersonCode"].ToString())[0]["OldAssetShare"] = row["NewAssetShare"];
                }
                catch (Exception ex)
                { }
                i++;
            }
        }
        private void LoadSellerPersonContract()
        {
            ///if (OldBuyers == null)
                SellerPersonsContract = JPersonContract.GetAllDataType(Contract.FinanceCode, Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, (Finance.JOwnershipType)Contract.ContractType.AssetTransferType, null, true);
                if (OldBuyers != null)
                {
                    foreach (DataRow row in SellerPersonsContract.Rows)
                    {
                        row.Delete();
                    }

                    LoadSellerPersonContract(OldBuyers);
                }
        }
        
        private void LoadBuyerPersonContract()
        {
            BuyerPersonsContract = JPersonContract.GetAllDataType(Contract.FinanceCode, Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, (Finance.JOwnershipType)Contract.ContractType.AssetTransferType, null, true);
        }

        public DataTable RemoveRepeat(DataTable pDT)
        {
            DataTable tempDT = pDT.Clone();
            foreach (DataRow row in pDT.Rows)
            {
                bool finrow = false;
                foreach (DataRow temprow in tempDT.Rows)
                {
                    if (Convert.ToInt32(temprow["PersonCode"]) == Convert.ToInt32(row["PersonCode"]))
                    {
                        temprow["Share"] = Convert.ToDecimal(temprow["Share"]) + Convert.ToDecimal(row["Share"]);
                        finrow = true;
                        break;
                    }
                }
                if (!finrow)
                {
                    DataRow newRow = tempDT.NewRow();
                    newRow["PersonCode"] = row["PersonCode"];
                    newRow["Name"] = row["Name"];
                    newRow["Share"] = Convert.ToDecimal(row["Share"]);
                    newRow["ClassNameEn"] = row["ClassNameEn"];
                    newRow["ContractSubjectCode"] = row["ContractSubjectCode"];
                    tempDT.Rows.Add(newRow);
                }
            }
            return tempDT;
        }

        public  DataTable GetNextSellers()
        {
            DataTable nextSellers = BuyerPersonsContract;
            foreach (DataRow row in SellerPersonsContract.Rows)
            {
               
                if (Convert.ToDecimal(row["PersonShare"]) - Convert.ToDecimal(row["Share"]) > 0)
                {
                    DataRow newRow = nextSellers.NewRow();
                    newRow["PersonCode"] = row["PersonCode"];
                    newRow["Name"] = row["Name"];
                    newRow["Share"] = Convert.ToDecimal(row["PersonShare"]) - Convert.ToDecimal(row["Share"]);
                    newRow["ClassNameEn"] = row["ClassNameEn"];
                    newRow["ContractSubjectCode"] = row["ContractSubjectCode"];
                    nextSellers.Rows.Add(newRow);
                }
            }
            return RemoveRepeat(nextSellers);
        }

        public bool SavePersonContract()
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            try
            {

                Db.beginTransaction("UpdateManualContract");
                if (SaveSellerPersonContract(Db))
                    if (SaveBuyerPersonContract(Db))
                    {
                        Contract.PreContract = PreContract;
                        Contract.Modified = 1;
                        if (Save(Db , true))
                        {
                            Db.Commit();
                            return true;
                        }
                    }
                Db.Rollback("UpdateManualContract");
                return false;
            }
            catch
            {
                Db.Rollback("UpdateManualContract");
                return false;
            }
        }



        private bool Save(ClassLibrary.JDataBase db  , bool pDontCheckConfirm = false)
        {
            //ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                //db.beginTransaction("ConfirmContract");
                if (Contract.Confirmed || pDontCheckConfirm)
                {
                    JContractdefine defineType = new JContractdefine(Contract.Type);
                    JContractDynamicType type = new JContractDynamicType(defineType.ContractType);
                    /// در صورتی که قرارداد قبلا تائید نشده است، دارایی ها مقدار میگیرند
                    {

                        #region Transfer
                        bool transfered = false;
                        JTransferAssetAfterContract TransferAssetAfterContract = new JTransferAssetAfterContract();
                        /// انتقال قطعی
                        if (type.AssetTransferType == Finance.JOwnershipType.Definitive.GetHashCode())
                        {
                            //transfered = TransferAssetAfterContract.TransferDefinite(Contract, db);
                        }
                        // انتقال صلح سرقفلی
                        else
                            if (type.AssetTransferType == Finance.JOwnershipType.GoodwillPeace.GetHashCode())
                            {
                                //transfered = TransferAssetAfterContract.TransferDefinite(Contract, db);
                            }
                            else
                                /// انتقال سرقفلی
                                if (type.AssetTransferType == Finance.JOwnershipType.Goodwill.GetHashCode())
                                {
                                    transfered = TransferAssetAfterContract.TransferGoodwill(Contract, Contract.TransferCode, _OldTransferCode, db,BuyerPersonsContract,SellerPersonsContract,Finance.JOwnershipType.Goodwill) > 0;
                                }
                                else if (type.AssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode())
                                /// انتقال اجاره
                                /// فقط وضعیت قرارداد به امضاء شده تغییر میابد
                                /// 
                                {
                                    transfered = true;
                                }
                                else if (type.AssetTransferType == Finance.JOwnershipType.Other.GetHashCode())
                                /// انتقال خاص
                                /// فقط وضعیت قرارداد به امضاء شده تغییر میابد
                                /// 
                                {
                                    transfered = true;
                                }

                        #endregion Transfer
                    }
                    if (Contract.Update(db))
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }



        private bool SaveSellerPersonContract(ClassLibrary.JDataBase pDB)
        {
            try
            {
                {
                    JPersonContract tmpSeller = new JPersonContract();
                    if (!tmpSeller.Insert(SellerPersonsContract, Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, pDB))
                        return false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
        }

        private bool SaveBuyerPersonContract(ClassLibrary.JDataBase pDB)
        {
            try
            {
                {
                    JPersonContract tmpBuyer = new JPersonContract();
                    if (!tmpBuyer.Insert(BuyerPersonsContract, Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, pDB))
                        return false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
        }

        public DataTable NextContracts()
        {
            int seller = ClassLibrary.Domains.Legal.JPersonPetitionType.Seller.GetHashCode();
            int buyer = ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer.GetHashCode();
            string strSeller = "فروشنده";
            string strBuyer = "خریدار";
            JContractdefine contType = new JContractdefine(Contract.Type);
             JContractDynamicType dynamicType = new JContractDynamicType(contType.ContractType);
            if (dynamicType.AssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode())
            {
                strSeller = "موجر";
                strBuyer = "مستاجر";
            }

            string Query = @" Select   Case  PC.Type when " + seller.ToString() + @" then '" + strSeller + "'  when " +
                                                            buyer.ToString() + @" then '" + strBuyer + @"' else '' end PersonParty
             , PA.Name, PC.Share, Pa.Address, PA.Tel
             , SC.Number ContractNo,
             ( Select Fa_Date from StaticDates Where En_Date =  Cast(SC.Date as Date) )ContractDate,
             ( Select Fa_Date from StaticDates Where En_Date =   Cast(SC.StartDate as Date)) StartDate, 
             ( Select Fa_Date from StaticDates Where En_Date =   Cast(SC.EndDate as Date)) EndDate,
             ( Select Fa_Date from StaticDates Where En_Date =   Cast(SC.DateDeliver as Date)) DateDeliver
             , SC.Status,  SC.TotalPrice,(Select Name From subDefine where Code = SC.Job) Job , SC.Price, SC.PriceMonth, SC.GoodwillPrice
             , PC.PersonCode ,SC.Code ContractCode
             from LegSubjectContract SC 
	            inner join LegContractType LT on SC.Type = LT.Code 
	            inner join legContractDynamicTypes LDT on LT.ContractType = LDT.Code	
	            inner join LegPersonContract PC on SC.Code= PC.ContractSubjectCode
	            inner join PersonAddressView PA on PC .PersonCode = PA.Code 
            where SC.Type IN (SELECT Code FROM LegContractType WHERE ContractType IN(SELECT Code FROM LegContractDynamicTypes WHERE AssetTransferType =  " + dynamicType.AssetTransferType.ToString() + "))" +
            " and SC.FinanceCode = " + Contract.FinanceCode.ToString() + " AND SC.Code <> " + Contract.Code.ToString() +
            " AND Modified = 0 AND Confirmed = 1 Order by SC.Date"; //

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }


    }
}
