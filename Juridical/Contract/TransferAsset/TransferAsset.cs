using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;
using Finance;

namespace Legal
{
    /// <summary>
    /// کلاس انتقال دارایی پس از قرارداد
    /// </summary>
    public class JTransferAssetAfterContract
    {
        public JAssetTransfer _AsstTransfer;
        #region Transfer Asset
        /// <summary>
        ///  انتقال قطعی مالکیت پس از درج قرارداد
        /// </summary>
        /// <param name="pContractCode"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public int  TransferDefinite(JSubjectContract contract, JDataBase pDB)
        {
            return TransferGoodwill(contract, 0, 0, pDB, null, null, JOwnershipType.Definitive);
            #region BadCode
            //_AsstTransfer = null;
            //DataTable contractBuyers = JPersonContract.GetAllDataType(contract.FinanceCode, contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, (Finance.JOwnershipType)contract.ContractType.AssetTransferType, pDB);
            //DataTable contractSellers = JPersonContract.GetAllDataType(contract.FinanceCode, contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, (Finance.JOwnershipType)contract.ContractType.AssetTransferType, pDB);
            
            //JAssetTransfer AssetTransfer = new JAssetTransfer(contract.FinanceCode, JOwnershipType.Definitive,pDB);
            //AssetTransfer.ClassName = "Legal.JSubjectContract";
            //AssetTransfer.ObjectCode = contract.Code;
            //AssetTransfer.ACode = contract.FinanceCode;
            //AssetTransfer.Comment = contract.ToString();

            ///// اختصاص سهم فروشندگان
            //foreach (DataRow row in contractSellers.Rows)
            //{
            //    AssetTransfer.ChangeItemShare((int)row["PersonCode"],
            //        AssetTransfer.FindItem((int)row["PersonCode"]).Share - (float)Convert.ToDecimal((row["Share"])));
            //}

            ///// اختصاص سهم خریداران
            //foreach (DataRow row in contractBuyers.Rows)
            //{
            //    JAssetShare tempAsset = AssetTransfer.FindItem((int)row["PersonCode"]);
            //    if (tempAsset != null)
            //        tempAsset.NewShare = tempAsset.Share + (float)Convert.ToDecimal(row["Share"]);
            //    else
            //    {
            //        JAssetShare share = new JAssetShare();
            //        share.ACode = contract.FinanceCode;
            //        share.PersonCode = (int)row["PersonCode"];
            //        share.Share = (float)Convert.ToDecimal((row["Share"]));
            //        share.Status = JStatusType.Active;
            //        AssetTransfer.AddItems(share);
            //    }
            //}
            //if (AssetTransfer.Insert(pDB))
            //{
            //    JPersonContract PC = new JPersonContract();
            //    foreach (JAssetShare AS in AssetTransfer.Items)
            //    {
            //        if (PC.GetData(pDB, contract.Code, AS.PersonCode))
            //        {
            //            PC.NewAssetShare = AS.Code;
            //            if (!PC.Update(pDB))
            //            {
            //                return 0;
            //            }
            //        }
            //    }
            //    _AsstTransfer = AssetTransfer;
            //    return _AsstTransfer.Code;
            //}
            //return 0;
            #endregion BadCode
        }
        /// <summary>
        /// انتقال سرقفلی
        /// </summary>
        /// <param name="pContractCode"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        //public int TransferGoodwill(JSubjectContract contract, JDataBase pDB)
        //{
        //    return TransferGoodwill(contract, 0,0, pDB,null,null);
        //}

        //public int TransferGoodwill(JSubjectContract contract, int pTCode, int POldTcode, JDataBase pDB)
        //{
        //    return TransferGoodwill(contract, pTCode, POldTcode, pDB, null, null);
        //}

        public int TransferGoodwill(JSubjectContract contract, int pTCode, int POldTcode, JDataBase pDB, DataTable contractBuyers, DataTable contractSellers, JOwnershipType pOwnershipType)
        {
            _AsstTransfer = null;
            if (contractBuyers == null)
                contractBuyers = JPersonContract.GetAllDataType(contract.FinanceCode, contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, (Finance.JOwnershipType)contract.ContractType.AssetTransferType, pDB);
            if (contractSellers == null)
                contractSellers = JPersonContract.GetAllDataType(contract.FinanceCode, contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, (Finance.JOwnershipType)contract.ContractType.AssetTransferType, pDB);


            JAssetTransfer AssetTransfer;
            /////////////////////////////
            /////////////////////////////
            if (pTCode == 0)
                AssetTransfer = new JAssetTransfer(contract.FinanceCode, pOwnershipType, "Legal.JSubjectContract", contract.PreContract, pDB);
            else
            {
                AssetTransfer = new JAssetTransfer(pTCode, pDB);
                if (POldTcode > 0)
                {
                    JAssetTransfer oldAssetTransfer = new JAssetTransfer(POldTcode, pDB);
                    oldAssetTransfer.DeActiveAll(pDB);
                    
                    JPersonContract mPC = new JPersonContract();
                    foreach (JAssetShare AS in oldAssetTransfer.Items)
                    {
                        if (mPC.GetData(pDB, pTCode, AS.PersonCode))
                        {
                            mPC.OldAssetShare = AS.Code;
                            if (!mPC.Update(pDB))
                            {
                            }
                        }
                    }

                }
            }

            AssetTransfer.OwnershipType = pOwnershipType;
            AssetTransfer.ClassName = "Legal.JSubjectContract";
            AssetTransfer.ObjectCode = contract.Code;
            AssetTransfer.ACode = contract.FinanceCode;
            AssetTransfer.Comment = contract.ToString();
            /// اختصاص سهم فروشندگان
            if (pTCode != 0 || AssetTransfer.Items.Length > 0)
                foreach (DataRow row in contractSellers.Rows)
                {
                    JAssetShare TempAssetShare = AssetTransfer.FindItem((int)row["PersonCode"]);
                    if (TempAssetShare != null)
                    {
                        float tempshare = TempAssetShare.Share;
                        if ((float)Convert.ToDecimal((row["PersonShare"])) > 0)
                            tempshare = (float)Convert.ToDecimal((row["PersonShare"]));

                        AssetTransfer.ChangeItemShare((int)row["PersonCode"],
                            tempshare - (float)Convert.ToDecimal((row["Share"])));
                    }
                    else
                        if (pTCode > 0 && (float)Convert.ToDecimal((row["PersonShare"])) > (float)Convert.ToDecimal((row["Share"])))
                        {
                            TempAssetShare = new JAssetShare();
                            TempAssetShare.ACode = contract.FinanceCode;
                            TempAssetShare.PersonCode = (int)row["PersonCode"];
                            TempAssetShare.Share = (float)Convert.ToDecimal((row["PersonShare"])) - (float)Convert.ToDecimal((row["Share"]));
                            TempAssetShare.Status = JStatusType.Active;
                            AssetTransfer.AddItems(TempAssetShare);
                        }
                }
            /// اختصاص سهم خریداران
            foreach (DataRow row in contractBuyers.Rows)
            {
                JAssetShare tempAsset = AssetTransfer.FindItem((int)row["PersonCode"]);
                if (tempAsset != null)
                {
                    if (contractSellers.Select("PersonCode="+row["PersonCode"].ToString()).Length > 0 )
                        tempAsset.NewShare = (float)Convert.ToDecimal(contractSellers.Select("PersonCode=" + row["PersonCode"].ToString())[0]["PersonShare"]) + (float)Convert.ToDecimal(row["Share"]);
                    else
                    {
                        tempAsset.NewShare = (float)Convert.ToDecimal(row["Share"]);
                    }

                }
                else
                {
                    JAssetShare share = new JAssetShare();
                    share.ACode = contract.FinanceCode;
                    share.PersonCode = (int)row["PersonCode"];
                    share.Share = (float)Convert.ToDecimal((row["Share"]));
                    share.Status = JStatusType.Active;
                    AssetTransfer.AddItems(share);
                }
            }
            bool isSetAsset = false;
            if (pTCode == 0)
            {
                isSetAsset = AssetTransfer.Insert(pDB);
            }
            else
           
            {
                isSetAsset = AssetTransfer.Update(pDB);
            }
            if (isSetAsset)
            {
                JPersonContract PC = new JPersonContract();
                ///////////////////////////// تغییر وضعیت
                JAsset asset = new JAsset(AssetTransfer.ACode, pDB);
                if (!(asset.ChangeState(JAssetState.General, pDB)))
                    return 0;
                ///////////////////////////////
                foreach (JAssetShare AS in AssetTransfer.Items)
                {
                    if (PC.GetData(pDB, contract.Code, AS.PersonCode))
                    {
                        PC.NewAssetShare = AS.Code;
                        if (!PC.Update(pDB))
                        {
                            return 0;
                        }
                    }
                }
                _AsstTransfer = AssetTransfer;

                return _AsstTransfer.Code;
            }
            return 0;
        }

        public bool TransferRent(JSubjectContract contract, JDataBase pDB)
        {            
            return true;
        }

        /// <summary>
        /// مشخص میکند یک دارایی دارای قرارداد اجاره جاری هست یا خیر
        /// </summary>
        /// <param name="pFinanceCode"></param>
        /// <returns></returns>
        public static bool AssetHasRentContract(int pFinanceCode, DateTime pStartDate)
        {
            string Query = @" SELECT legSubjectContract.* FROM legSubjectContract 
	                INNER JOIN LegContractType on LegSubjectContract.Type = LegContractType.Code
	                INNER JOIN legContractDynamicTypes on legContractDynamicTypes.Code = LegContractType.ContractType
	                Where legContractDynamicTypes.AssetTransferType = " + Finance.JOwnershipType.Rentals.GetHashCode().ToString() +
                    " and LegSubjectContract.FinanceCode = " + pFinanceCode.ToString() +
                    " AND LegSubjectContract.EndDate>=@StatDate" +
                    " and LegSubjectContract.Status = " + JContractStatus.Current.GetHashCode().ToString();
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.Params.Add("StatDate", pStartDate);
                db.setQuery(Query);
                db.Query_DataReader();
                if (db.DataReader.Read())
                    return true;
                else
                    return false;
            }
            finally
            {
                db.Dispose();
            }
        }



        #endregion Transfer Asset
    }
}
