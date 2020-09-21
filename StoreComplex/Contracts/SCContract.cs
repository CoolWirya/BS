using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCContract : JStoreComplex
    {
        public static string Query = @"
            Select Code, SCCode 
        ,(SELECT Name FROM clsAllPerson WHERE Code = (SELECT TOP 1 PersonCode FROM LegPersonContract where ContractSubjectCode = LegSubjectContract .Code AND Type = 9 )) PersonName
            , (Select name  from subdefine  Where Code = SCGood) SCGood
            ,(Select Fa_DAte From StaticDates Where En_Date = Date) Date
        ,(Select  ContractType From legContractType Where Code = Type ) DynamicType
         ,   Case SCContractType 
	            When 1 then 'قرارداد انبارداری'
	            When 2 then 'قرارداد اجاره انبار اختصاصی'
            else '' end SCType
, (SELECT TOP 1 PersonCode FROM LegPersonContract where ContractSubjectCode = LegSubjectContract .Code AND Type = 9 ) PCode
, Confirmed
             from LegSubjectContract 
             where SCContractType is not null AND SCContractType > 0 
             AND " + JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "ContractType");

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "StoreComplex.JSCContract");
            Nodes.hidColumns = "";

            /// اکشن جدید
            JAction newAction = new JAction("NewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { Convert.ToInt32(pRow["DynamicType"]), 0 });
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JGeneralContract.ShowForms", null, new object[] { Convert.ToInt32(pRow["DynamicType"]), node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن مشاهده
            JAction viewAction = new JAction("View...", "Legal.JGeneralContract.ShowForms", null, new object[] { Convert.ToInt32(pRow["DynamicType"]), node.Code, true });
            node.MouseDBClickAction = viewAction;
            node.EnterClickAction = viewAction;

            /// اکشن فسخ قرارداد
            JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { node.Code });
            if (!Convert.ToBoolean(pRow["Confirmed"]))
                CancelAction.Enabled = false;

            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JSubjectContract.delete", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);

            /// اکشن تائید قرارداد
            JAction confirmAction = new JAction("ConfirmContract...", "Legal.JSubjectContract.ConfirmContract", new object[] { Convert.ToInt32(pRow["DynamicType"]) }, new object[] { node.Code });
            /// ثبت خدمات
            JAction serviceAction = new JAction("NewService...", "StoreComplex.JSCService.ShowDialog", new object[] { Convert.ToInt32(pRow["Code"]), 0 }, null);
            /// نمایش صورتحساب
            JAction billAction = new JAction("Bill...", "StoreComplex.JBillForm.ShowDialog", null, new object[] { Convert.ToInt32(pRow["Code"]) });
            /// مجوزهای ثبت شده
           // JAction AllowTransfersAction = new JAction("AllowTransfersList...", "StoreComplex.JSCAllowTransfer.ShowList", new object[] { Convert.ToInt32(pRow["Code"]) }, new object[] { 0 });
            /// ثبت مجوز
          //  JAction AllowTransferAction = new JAction("NewAllowTransfer...", "StoreComplex.JSCAllowTransfer.ShowDialog", new object[] { Convert.ToInt32(pRow["Code"]), 0 }, new object[] { 0 });
            /// حواله های ثبت شده
            JAction TransfersAction = new JAction("TransfersList...", "StoreComplex.JSCTransfer.ShowList", new object[] { Convert.ToInt32(pRow["Code"]) }, new object[] { 0 });
            /// ثبت حواله
            JAction TransferAction = new JAction("NewTransfer...", "StoreComplex.JSCTransfer.ShowDialog", new object[] { Convert.ToInt32(pRow["PCode"]), Convert.ToInt32(pRow["Code"]), 0 }, new object[] { 0 });
            /// رسیدهای ثبت شده
            JAction ReceiptsAction = new JAction("ReceiptsList...", "StoreComplex.JSCReceipt.ShowList", new object[] { Convert.ToInt32(pRow["Code"]) }, new object[] { 0 });
            /// ثبت رسید
            JAction ReceiptAction = new JAction("NewReceipt...", "StoreComplex.JSCReceipt.ShowDialog", new object[] { Convert.ToInt32(pRow["PCode"]), Convert.ToInt32(pRow["Code"]), 0 }, new object[] { 0 });
            ///ثبت بیمه
            JAction InsuranceAction = new JAction("NewInsurance...", "StoreComplex.JInsurance.ShowDialog", new object[] {Convert.ToInt32(pRow["Code"]), 0 }, new object[] { 0 });
            ///بیمه های ثبت شده
            JAction InsurancesAction = new JAction("InsurancesList...", "StoreComplex.JInsurance.ShowList", new object[] { Convert.ToInt32(pRow["Code"]) }, new object[] { 0 });

            node.Popup.Insert(CancelAction);
            node.Popup.Insert(confirmAction);
            node.Popup.Insert("-");
            node.Popup.Insert(OfficeWord.JWordForm.getAction("Legal.JContractForms", node.Code, true));
            node.Popup.Insert("-");
            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(viewAction);
            node.Popup.Insert(newAction);
            node.Popup.Insert("-");
            node.Popup.Insert(billAction);
            node.Popup.Insert(serviceAction);
            node.Popup.Insert("-");
            node.Popup.Insert(InsurancesAction);
            //node.Popup.Insert(InsuranceAction);
            node.Popup.Insert("-");
            node.Popup.Insert(TransfersAction);
            node.Popup.Insert(TransferAction);
            node.Popup.Insert("-");
            node.Popup.Insert(ReceiptsAction);
            node.Popup.Insert(ReceiptAction);

            return node;
        }

        public static DataTable GetBill(int ContractCode, DateTime FromDate, DateTime ToDate)
        {
            string query = @"SELECT 
                SCService.Code, (Select Fa_Date From StaticDates Where En_Date = Date )Date
                ,subdefine.name ServiceType , ServiceCost , SCService.Description 
                FROM SCService 
                Left Join subdefine on ServiceType = subdefine.Code
                 WHERE ContractCode = " + ContractCode;
            if (FromDate != DateTime.MinValue)
                query += " AND Date >= " + JDataBase.Quote(FromDate.ToShortDateString());
            if (ToDate != DateTime.MinValue)
                query += " AND Date <=" + JDataBase.Quote(ToDate.ToShortDateString());
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
    }

    public class JSCContracts : JStoreComplex
    {
        private DataTable GetDataTable()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(JSCContract.Query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("NewNode", "StoreComplex.JSCContract.GetNode");
            Nodes.DataTable = GetDataTable();

            //اکشن جدید
            JAction newaction = new JAction("new...", "Legal.JContractDynamicType.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
    }
}
