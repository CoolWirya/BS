using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebBusManagement
{
    public class JBusAccounting
    {
        public const string _ConstClassName = "WebBusManagement.JBusAccounting";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BaseDefine", null, new List<object>() { }) }, "BaseDefine", _ConstClassName + "._BaseDefine", JDomains.Images.MenuImages.BusManagmentDefine, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Documents", null, new List<object>() { }) }, "Documents", _ConstClassName + "._Documents", JDomains.Images.MenuImages.BusManagmentDefine, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Payments", null, new List<object>() { }) }, "Payments", _ConstClassName + "._Payments", JDomains.Images.MenuImages.BusManagmentDefine, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentAndPayment", null, new List<object>() { }) }, "DocumentAndPayment", _ConstClassName + "._DocumentAndPayment", JDomains.Images.MenuImages.BusManagmentReport, null));
            return nodes;
        }

        public string _BaseDefine()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BaseDefine"
                , "~/WebBusManagement/FormsManagement/JAccountingBaseDefineReportControl.ascx"
                , "تعاریف پایه حسابداری"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _DocumentAndPayment()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DocumentAndPayment"
                , "~/WebBusManagement/FormsReports/JDocumentAndPaymentReportControl.ascx"
                , "گزارش اسناد و پرداختی ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        //_Documents
        public string _Documents()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Documents.JAUTDocuments.GetWebQuery();
            jGridView.Title = "Documents";
            jGridView.HiddenColumns = "IsClosed";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DocumentsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _DocumentsNew()
        {
            return _DocumentsNew(null);
        }
        public string _DocumentsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Documents"
                  , "~/WebBusManagement/FormsManagement/JDocumentsUpdateControl.ascx"
                  , "اسناد"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }
        public string _DocumentsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Documents"
                  , "~/WebBusManagement/FormsManagement/JDocumentsUpdateControl.ascx"
                  , "اسناد"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }


        //_Payments
        public string _Payments()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Documents.JAUTPayments.GetWebQuery();
            jGridView.Title = "Payments";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("GetFile", "GetFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentsGetFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PaymentsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PaymentsNew()
        {
            return _PaymentsNew(null);
        }
        public string _PaymentsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Payments"
                  , "~/WebBusManagement/FormsManagement/JPaymentsUpdateControl.ascx"
                  , "پرداختها"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }
        public string _PaymentsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Payments"
                , "~/WebBusManagement/FormsManagement/JPaymentsUpdateControl.ascx"
                , "پرداختها"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, true, true, 600, 350);
        }

        public void _PaymentsGetFile(string code)
        {
            var sb = new System.Text.StringBuilder();
            string SumPrice = GetPaymentPriceSum(code);
            string line = "1   1   " + SumPrice;
            sb.AppendLine(line);
            line = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString() + " " + SumPrice + " D";
            sb.AppendLine(line);

            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT ad.*,fba.AccountNo FROM AUTPaymentDetail ad
                                                                                        LEFT JOIN finBankAccount fba ON ad.OwnerPCode = fba.PCode
                                                                                        WHERE ad.PaymentCode=" + code +@" ORDER BY ad.Code");
            string AccountNumber = "", PaymentPrice = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                AccountNumber = table.Rows[i]["AccountNo"].ToString();
                PaymentPrice = table.Rows[i]["PaymentPrice"].ToString();
                int AcNumber;
                long Price;
                if (int.TryParse(AccountNumber, out AcNumber) == false)
                    AccountNumber = "0";
                if (long.TryParse(PaymentPrice, out Price) == false)
                    PaymentPrice = "0";
                sb.AppendLine(AccountNumber +
                    " " + PaymentPrice + " C");
            }

            Encoding outputEnc = new UTF8Encoding(false); // create encoding with no BOM
            TextWriter file = new StreamWriter(HttpContext.Current.Server.MapPath("~/document.txt"), false, outputEnc); // open file with encoding
            file.WriteLine(sb);
            file.Close();
            System.Diagnostics.Process.Start(HttpContext.Current.Server.MapPath("~/document.txt"));
        }

        public string GetPaymentPriceSum(string PaymentCode)
        {
            string Res = "";
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT * FROM AUTPaymentDetail ad WHERE ad.PaymentCode=" + PaymentCode + " ORDER BY ad.Code");
            Int64 SumPrice = 0;
            for(int i = 0 ; i < Dt.Rows.Count;i++)
            {
                SumPrice += Convert.ToInt64(Dt.Rows[i]["PaymentPrice"].ToString());
            }
            Res = SumPrice.ToString();
            return Res;
        }

    }
}