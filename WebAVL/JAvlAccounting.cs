using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAVL
{
    public class JAvlAccounting
    {
        public const string _ConstClassName = "WebAVL.JAvlAccounting";

        public List<WebClassLibrary.JNode> GetNodes()
        {
            List<WebClassLibrary.JNode> nodes = new List<WebClassLibrary.JNode>();
            nodes.AddRange(this.AccountNodes());
            return nodes;
        }
        public List<WebClassLibrary.JNode> AccountNodes()
        {
            List<WebClassLibrary.JNode> nodes = new List<WebClassLibrary.JNode>();
            nodes.Add(new WebClassLibrary.JNode(
                new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._recharge", null, null) },
                                     "شارژ پنل کاربری",
                                     _ConstClassName + "._recharge",
                                     WebClassLibrary.JDomains.Images.AvlManagementImages.Cash_register_icon,
                                     null
                ));
            nodes.Add(new WebClassLibrary.JNode(
             new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._AccountSummary", null, null) },
                                  "مرور حساب",
                                  _ConstClassName + "._AccountSummary",
                                  WebClassLibrary.JDomains.Images.AvlManagementImages.Sales_report_icon,
                                  null
             ));
            nodes.Add(new WebClassLibrary.JNode(
             new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NoActionInvoices", null, null) },
                                  "فیش های اقدام نشده",
                                  _ConstClassName + "._NoActionInvoices",
                                  WebClassLibrary.JDomains.Images.MenuImages.Item,
                                  null
             ));
            return nodes;
        }
        public string _AccountSummary()
        {
            string query = "";
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_NoActionInvoices");
            // +WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            query = @"select case s.RegisterDate when null  then s.RegisterDate  else  p.registerDateTime  end as  'تاریخ',s.[Description] as 'شرح', o.Label as 'تفضیلی 1',d.Name as'تفضیلی 2', p.Price as 'بستانکار',s.price as 'بدهکار' from AVLPaid p 
full join AVLSpend s on p.userCode=s.userCode 
full join AVLObjectList o on p.userCode=o.personCode
full join AVLDevice d on d.ObjectCode=o.Code  where o.personCode={0}";
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_AccountSummaryNORMAL";
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
         
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
            {
                query = @"select case s.RegisterDate when null  then s.RegisterDate  else  p.registerDateTime  end as  'تاریخ',s.[Description] as 'شرح', o.Label as 'تفضیلی 1',d.Name as'تفضیلی 2', p.Price as 'بستانکار',s.price as 'بدهکار' from AVLPaid p 
full join AVLSpend s on p.userCode=s.userCode 
full join AVLObjectList o on p.userCode=o.personCode
full join AVLDevice d on d.ObjectCode=o.Code ";
                jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_AccountSummary";
            }
            jGridView.SQL = query;
            jGridView.Title = "Invoices";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Varified", "تایید", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._VarifyInvoice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));

            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _NoActionInvoices()
        {
            string query = "";
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_NoActionInvoices");
            // +WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
            {
                query = @"SELECT * FROM [AVLPaid] WHERE State=0";
                jGridView.ClassName = _ConstClassName.Replace(".", "_") + "__NoActionInvoices";
            }
            jGridView.SQL = query;
            jGridView.Title = "Invoices";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Varified", "تایید", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._VarifyInvoice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _VarifyInvoice(string code)
        {
            AVL.Accounting.JAVLPaid paid = new AVL.Accounting.JAVLPaid(int.Parse(code));
            if (paid.State == (byte)AVL.Accounting.InvoiceStateEnum.Varified)
                return "";
            paid.State = (byte)AVL.Accounting.InvoiceStateEnum.Varified;

            if (paid.Update())
            {
                AVL.Accounting.JCash cash = new AVL.Accounting.JCash(0,paid.userCode);
                if (cash.code > 0)
                {
                    cash.paid += paid.Price;
                    AVL.Accounting.JCashTable cashTable = new AVL.Accounting.JCashTable();
                    cashTable.SetValueProperty(cash);
                    if (cashTable.Update())
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات موفق');", "ConfirmDialog");
                        //     WebClassLibrary.JWebManager.CloseAndRefresh();
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات نا موفق لطفا دوباره سعی کنید. اگر مشکل برقرار بود با پشتیبانی تماس بگیرید.');", "ConfirmDialog");
                    }
                }
                else
                {
                    cash.userCode = paid.userCode;
                    cash.paid = paid.Price;
                    AVL.Accounting.JCashTable cashTable = new AVL.Accounting.JCashTable();
                    cashTable.SetValueProperty(cash);
                    if (cashTable.Insert() > 0)
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات موفق');GetRadWindow().close();", "ConfirmDialog");
                        //     WebClassLibrary.JWebManager.CloseAndRefresh();
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات نا موفق لطفا دوباره سعی کنید. اگر مشکل برقرار بود با پشتیبانی تماس بگیرید.');", "ConfirmDialog");
                    }
                }
            }
            return "";
        }
        public string _UnVarifyInvoice(string code)
        {
            AVL.Accounting.JAVLPaid paid = new AVL.Accounting.JAVLPaid(int.Parse(code));
            if (paid.State == (byte)AVL.Accounting.InvoiceStateEnum.NoAction)
                return "";
            paid.State = (byte)AVL.Accounting.InvoiceStateEnum.NoAction;
            if (paid.Update())
            {
                AVL.Accounting.JCash cash = new AVL.Accounting.JCash(0, paid.userCode);
                if (cash.code > 0)
                {
                    cash.paid -=paid.Price;
                    AVL.Accounting.JCashTable cashTable = new AVL.Accounting.JCashTable();
                    cashTable.SetValueProperty(cash);
                    if (cashTable.Update())
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات موفق');GetRadWindow().close();", "ConfirmDialog");
                        //     WebClassLibrary.JWebManager.CloseAndRefresh();
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات نا موفق لطفا دوباره سعی کنید. اگر مشکل برقرار بود با پشتیبانی تماس بگیرید.');", "ConfirmDialog");
                    }
                }
                else
                {
                    cash.userCode = paid.userCode;
                    cash.paid -= paid.Price;
                    AVL.Accounting.JCashTable cashTable = new AVL.Accounting.JCashTable();
                    cashTable.SetValueProperty(cash);
                    if (cashTable.Insert() > 0)
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات موفق');GetRadWindow().close();", "ConfirmDialog");
                        //     WebClassLibrary.JWebManager.CloseAndRefresh();
                    }
                    else
                    {
                        WebClassLibrary.JWebManager.RunClientScript("alert('عملیات نا موفق لطفا دوباره سعی کنید. اگر مشکل برقرار بود با پشتیبانی تماس بگیرید.');", "ConfirmDialog");
                    }
                }
            }
            return "";
        }

        public string _recharge()
        {

            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_registerInvoice");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_registerInvoiceNORMAL";
            string query = @"SELECT * FROM [AVLPaid] WHERE userCode={0}";
            // +WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
            {
                query = @"SELECT * FROM [AVLPaid]";
                jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_registerInvoice";
            }
            jGridView.SQL = query;


            jGridView.Title = "Invoices";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("NewByGateAway", "شارژ با درگاه", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._rechargeByGateway", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("NewInvoice", "شارژ با فیش", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewInvoice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._EditInvoice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
                jGridView.Toolbar.AddButton("NotVarified", "عدم تایید", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._UnVarifyInvoice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _NewInvoice(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_NewInvoice"
                          , "~/WebAVL/Forms/registerInvoice.ascx"
                          , "ثبت دستی فیش"
                          , null
                          , WebClassLibrary.WindowTarget.NewWindow
                          , true, true, true, 600, 350, true);
        }
        public string _EditInvoice(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_EditInvoice"
                          , "~/WebAVL/Forms/registerInvoice.ascx"
                          , "ویرایش فیش"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                          , WebClassLibrary.WindowTarget.NewWindow
                          , true, true, true, 600, 350, true);
        }

        public string _rechargeByGateway(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Purchase"
                          , "~/WebAVL/Forms/Purchase.ascx"
                          , "پرداخت با درگاه بانک"
                           , null
                          , WebClassLibrary.WindowTarget.NewWindow
                          , true, true, true, 600, 350, true);
        }
      
    }
}