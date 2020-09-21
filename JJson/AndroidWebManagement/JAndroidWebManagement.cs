using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace AndroidWebManagement
{
    public class JAndroidWebManagement
    {
        public const string _ConstClassName = "AndroidWebManagement.JAndroidWebManagement";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._News", null, new List<object>() { }) }, "News", _ConstClassName + "._News", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SellRequest", null, new List<object>() { }) }, "SellRequest", _ConstClassName + "._SellRequest", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BuyRequest", null, new List<object>() { }) }, "BuyRequest", _ConstClassName + "._BuyRequest", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AboutUsTextAndPic", null, new List<object>() { }) }, "AboutUsTextAndPic", _ConstClassName + "._AboutUsTextAndPic", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGallery", null, new List<object>() { }) }, "PicGallery", _ConstClassName + "._PicGallery", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePrice", null, new List<object>() { }) }, "SharePrice", _ConstClassName + "._SharePrice", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendBox", null, new List<object>() { }) }, "SendBox", _ConstClassName + "._SendBox", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InBox", null, new List<object>() { }) }, "InBox", _ConstClassName + "._InBox", JDomains.Images.MenuImages.Item, null));
            return nodes;
        }

        public string _News()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = Entertainment.JNewss.GetSqlQuery();
            jGridView.Title = "News";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._NewsUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _NewsNew()
        {
            return _NewsNew(null);
        }
        public string _NewsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("News"
                  , "~/AndroidWebManagement/Forms/JNewsUpdateControl.ascx"
                  , "ثبت خبر"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _NewsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("News"
                   , "~/AndroidWebManagement/Forms/JNewsUpdateControl.ascx"
                   , "ویرایش خبر"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_SellAndBuyRequest
        public string _SellRequest()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = ManagementShares.TransferRequest.JRequests.GetSellRequestSqlQuery();
            jGridView.Title = "SellRequest";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("ChangeStatus", "ChangeStatus", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SellRequestChangeStatus", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _SellRequestChangeStatus(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SellRequest"
                   , "~/AndroidWebManagement/Forms/JSellChangeStatusUpdateControl.ascx"
                   , "تغییر وضعیت درخواست های فروش"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_BuyRequest
        public string _BuyRequest()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = ManagementShares.TransferRequest.JRequests.GetBuyRequestSqlQuery();
            jGridView.Title = "BuyRequest";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("ChangeStatus", "ChangeStatus", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BuyRequestChangeStatus", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _BuyRequestChangeStatus(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BuyRequest"
                   , "~/AndroidWebManagement/Forms/JBuyRequestChangeStatusUpdateControl.ascx"
                   , "تغییر وضعیت درخواست های خرید"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_AboutUsTextAndPic
        public string _AboutUsTextAndPic()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = Entertainment.JAboutUss.GetSqlQuery();
            jGridView.Title = "News";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AboutUsTextAndPicNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AboutUsTextAndPicUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._AboutUsTextAndPicUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _AboutUsTextAndPicNew()
        {
            return _AboutUsTextAndPicNew(null);
        }
        public string _AboutUsTextAndPicNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("News"
                  , "~/AndroidWebManagement/Forms/JAboutUsTextAndPicUpdateControl.ascx"
                  , "ثبت درباره ما"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _AboutUsTextAndPicUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("News"
                   , "~/AndroidWebManagement/Forms/JAboutUsTextAndPicUpdateControl.ascx"
                   , "ویرایش درباره ما"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_PicGallery
        public string _PicGallery()
        {
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = Entertainment.JPicGallerys.GetSqlQuery(); ;
            jGridView.Title = "PicGallery";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGalleryNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGalleryUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PicGalleryUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PicGalleryNew()
        {
            return _PicGalleryNew(null);
        }
        public string _PicGalleryNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PicGallery"
                   , "~/AndroidWebManagement/Forms/JPicGalleryUpdateControl.ascx"
                   , "ثبت عکس"
                   , null
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        public string _PicGalleryUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PicGallery"
                   , "~/AndroidWebManagement/Forms/JPicGalleryUpdateControl.ascx"
                   , "ویرایش عکس"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }


        //_SharePrice
        public string _SharePrice()
        {
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = "select * from SharePrice";
            jGridView.Title = "SharePrice";
            jGridView.PageOrderByField = "ChangeDate DESC";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePriceNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePriceUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SharePriceUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _SharePriceNew()
        {
            return _SharePriceNew(null);
        }
        public string _SharePriceNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SharePrice"
                   , "~/AndroidWebManagement/Forms/JSharePriceUpdateControl.ascx"
                   , "ثبت قیمت روز سهام"
                   , null
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        public string _SharePriceUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SharePrice"
                   , "~/AndroidWebManagement/Forms/JSharePriceUpdateControl.ascx"
                   , "ویرایش قیمت روز سهام"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_SendBox
        public string _SendBox()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = @"Select  ShareMessage.Code, SenderCode, ReceiverCode, Type ,
                                clsAllPerson .Name SenderName ,cap.Name ReceiverName, sDate,Title, Body
                                from ShareMessage
                                INNER JOIN clsAllPerson ON ShareMessage .SenderCode = clsAllPerson .Code
                                INNER JOIN clsAllPerson cap ON ReceiverCode = cap.Code
                                where SenderCode = " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            jGridView.Title = "SendBox";
            jGridView.PageOrderByField = "sDate Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendBoxNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _SendBoxNew()
        {
            return _SendBoxNew(null);
        }
        public string _SendBoxNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SendBoxNew"
                   , "~/AndroidWebManagement/Forms/JSendMessageUpdateControl.ascx"
                   , "ارسال پیام"
                   , null
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_InBox
        public string _InBox()
        {
            ManagementShares.JShareCompany Company = new ManagementShares.JShareCompany(1);
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = @"Select  ShareMessage.Code, SenderCode, ReceiverCode, Type ,
                                clsAllPerson .Name SenderName ,cap.Name ReceiverName, sDate,Title, Body
                                from ShareMessage
                                INNER JOIN clsAllPerson ON ShareMessage .SenderCode = clsAllPerson .Code
                                INNER JOIN clsAllPerson cap ON ReceiverCode = cap.Code
                                where ReceiverCode in(" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @"," + Company.PCode + @")";
            jGridView.Title = "InBox";
            jGridView.PageOrderByField = "sDate Desc";
            jGridView.PageSize = 5;
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }


        //public string _BusTransaction()
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("BusTransaction"
        //        , "~/WebBusManagement/FormsReports/JBusTransactionReportControl.ascx"
        //        , "گزارش تراکنش اتوبوس ها"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}



    }
}