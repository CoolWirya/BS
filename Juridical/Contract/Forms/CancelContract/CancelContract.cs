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
    /// کلاس فسخ قرارداد
    /// </summary>
    public class JCancelContract
    {
        /// <summary>
        /// فسخ  قرارداد انتقال قطعی
        /// </summary>
        /// <param name="pDB"></param>
        /// <param name="pContractCode"></param>
        public static bool CancelDefinit(JDataBase pDB, int pContractCode)
        {
            JSubjectContract contract = new JSubjectContract(pContractCode, pDB);
            /// ترانسفر مربوط به قرارداد بازیابی میشود، یک ترانسفر جدید بر اساس پرنت این قرارداد ایجاد و درج میشود
            JAssetTransfer transfer = new JAssetTransfer(contract.FinanceCode,JOwnershipType.Definitive, pDB);
            JAssetTransfer newTransfer = new JAssetTransfer(transfer.ParentCode, pDB);
            newTransfer.Comment = newTransfer.Comment + " (" + transfer.Comment + " فسخ شد." + ")";
            transfer.Comment = transfer.Comment + " قرارداد فسخ شده ";
            transfer.Update(pDB);

//            /// 2-  اطلاعات طرفین PersonContract مربوط به این قرارداد  خوانده میشود
//            string Query = " SELECT * FROM " + Finance.JTableNamesFinance.AssetShare + @" WHERE Code IN
//                (SELECT OldAssetShare FROM " + JTableNamesLegal.PersonContract + " WHERE ContractSubjectCode = " + pContractCode + ")";
//            pDB.setQuery(Query);
//            DataTable oldShares = pDB.Query_DataTable();


//            /// 3- به ازای هر OldShare در PersonContract یک کد در AssetShare درج مشود
//            foreach (DataRow row in oldShares.Rows)
//            {
//                JAssetShare share = new JAssetShare(Convert.ToInt32(row["Code"]), JStatusType.Inactive, pDB);
//                share.Status = JStatusType.Active;
//                newTransfer.AddItems(share);
//                //share.Insert(pDB);
////            }
//            if (!newTransfer.Insert(pDB))
//                return false;

            
            /// 4- به ازای هر NewShare در PersonContract کد معادل آن در AssetShare غیر فعال میشود
            //Query = " UPDATE " + Finance.JTableNamesFinance.AssetShare + " SET Status = " + Finance.JStatusType.Inactive.GetHashCode().ToString() +
            //    " WHERE Code IN (SELECT NewAssetShare  FROM " + JTableNamesLegal.PersonContract + " WHERE ContractSubjectCode = " + pContractCode + ")";
            string Query = " UPDATE " + Finance.JTableNamesFinance.AssetShare + " SET Status = " + Finance.JStatusType.Inactive.GetHashCode().ToString() +
                " WHERE TCode =" +transfer.Code + " " +
 " UPDATE " + Finance.JTableNamesFinance.AssetShare + " SET Status = " + Finance.JStatusType.Active.GetHashCode().ToString() +
                " WHERE TCode =" + transfer.ParentCode;
            pDB.setQuery(Query);
            pDB.Query_Execute();

            
            
            return true;
        }

        /// <summary>
        /// فسخ  قرارداد صلح سرقفلی
        /// </summary>
        /// <param name="pDB"></param>
        /// <param name="pContractCode"></param>
        public static bool CancelGoodwill(JDataBase pDB, int pContractCode)
        {

            JSubjectContract contract = new JSubjectContract(pContractCode, pDB);
            string Query;
            JAssetTransfer transfer = new JAssetTransfer(contract.FinanceCode, JOwnershipType.Goodwill, pDB);
            transfer.DeActiveAll(pDB);
            return true;           
            
            /// ترانسفر مربوط به قرارداد بازیابی میشود، یک ترانسفر جدید بر اساس پرنت این قرارداد ایجاد و درج میشود
//            JAssetTransfer transfer = new JAssetTransfer(contract.FinanceCode, JOwnershipType.Goodwill, pDB);
//            JAssetTransfer newTransfer ;
//            if (transfer.ParentCode > 0)
//                newTransfer = new JAssetTransfer(transfer.ParentCode, pDB);
//            else
//                newTransfer = new JAssetTransfer(contract.FinanceCode, JOwnershipType.Definitive, pDB);

//            newTransfer.Comment = newTransfer.Comment + " (" + transfer.Comment + " فسخ شد." + ")";


//            /// 2-  اطلاعات طرفین PersonContract مربوط به این قرارداد  خوانده میشود
//            string Query = " SELECT * FROM " + Finance.JTableNamesFinance.AssetShare + @" WHERE Code IN
//                (SELECT OldAssetShare FROM " + JTableNamesLegal.PersonContract + " WHERE ContractSubjectCode = " + pContractCode + ")";
//            pDB.setQuery(Query);
//            DataTable oldShares = pDB.Query_DataTable();


//            /// 3- به ازای هر OldShare در PersonContract یک کد در AssetShare درج مشود
//            foreach (DataRow row in oldShares.Rows)
//            {
//                JAssetShare share;
//                if (newTransfer.ParentCode == 0)
//                    share = new JAssetShare(Convert.ToInt32(row["Code"]), JStatusType.Active, pDB);
//                else
//                    share = new JAssetShare(Convert.ToInt32(row["Code"]), JStatusType.Inactive, pDB);

//                share.Status = JStatusType.Active;
//                newTransfer.AddItems(share);
//            }
//            if (!newTransfer.Insert(pDB))
//                return false;


            /// 4- به ازای هر NewShare در PersonContract کد معادل آن در AssetShare غیر فعال میشود
            //Query = " UPDATE " + Finance.JTableNamesFinance.AssetShare + " SET Status = " + Finance.JStatusType.Inactive.GetHashCode().ToString() +
            //    " WHERE Code IN (SELECT NewAssetShare  FROM " + JTableNamesLegal.PersonContract + " WHERE ContractSubjectCode = " + pContractCode + ")";
            //pDB.setQuery(Query);
            //pDB.Query_Execute();
            
        }
    }
}
