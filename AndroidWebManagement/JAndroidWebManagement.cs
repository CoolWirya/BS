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
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Projects", null, new List<object>() { }) }, "Projects", _ConstClassName + "._Projects", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SellRequest", null, new List<object>() { }) }, "SellRequest", _ConstClassName + "._SellRequest", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BuyRequest", null, new List<object>() { }) }, "BuyRequest", _ConstClassName + "._BuyRequest", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AboutUsTextAndPic", null, new List<object>() { }) }, "AboutUsTextAndPic", _ConstClassName + "._AboutUsTextAndPic", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGallery", null, new List<object>() { }) }, "PicGallery", _ConstClassName + "._PicGallery", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePrice", null, new List<object>() { }) }, "SharePrice", _ConstClassName + "._SharePrice", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePriceText", null, new List<object>() { }) }, "SharePriceText", _ConstClassName + "._SharePriceText", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendBox", null, new List<object>() { }) }, "SendBox", _ConstClassName + "._SendBox", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InBox", null, new List<object>() { }) }, "InBox", _ConstClassName + "._InBox", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InBoxEnteghad", null, new List<object>() { }) }, "InBoxEnteghad", _ConstClassName + "._InBoxEnteghad", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Apartments", null, new List<object>() { }) }, "Apartments", _ConstClassName + "._Apartments", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ApartmentsRequest", null, new List<object>() { }) }, "ApartmentsRequest", _ConstClassName + "._ApartmentsRequest", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Ground", null, new List<object>() { }) }, "Ground", _ConstClassName + "._Ground", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroundRequest", null, new List<object>() { }) }, "GroundRequest", _ConstClassName + "._GroundRequest", JDomains.Images.MenuImages.Item, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGalleryCategory", null, new List<object>() { }) }, "PicGalleryCategory", _ConstClassName + "._PicGalleryCategory", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGalleryPic", null, new List<object>() { }) }, "PicGalleryPic", _ConstClassName + "._PicGalleryPic", JDomains.Images.MenuImages.Item, null));

            return nodes;
        }

        //_Ground
        public string _Ground()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "._Ground");
            jGridView.SQL = "select * from Android_Ground";
            jGridView.PageOrderByField = "Code desc";
            jGridView.Title = "Ground";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroundNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroundUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._GroundUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _GroundNew()
        {
            return _GroundNew(null);
        }
        public string _GroundNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Ground"
                  , "~/AndroidWebManagement/Forms/JGroundUpdateControl.ascx"
                  , "ثبت زمین ها"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 500);
        }
        public string _GroundUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Ground"
                   , "~/AndroidWebManagement/Forms/JGroundUpdateControl.ascx"
                   , "ویرایش زمین ها"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 500);
        }


        //PicGalleryCategory
        public string _PicGalleryCategory()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "._PicGalleryCategory");
            jGridView.SQL = @"SELECT [Code]
                                      ,[Name]
                                      ,[ArchiveCode]
                                      ,[InsertDate]
                                  FROM [EntPicGalleryLvl1]";
            jGridView.PageOrderByField = "Code desc";
            jGridView.Title = "PicGalleryCategory";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGalleryCategoryNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGalleryCategoryUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PicGalleryCategoryUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PicGalleryCategoryNew()
        {
            return _PicGalleryCategoryNew(null);
        }
        public string _PicGalleryCategoryNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PicGalleryCategory"
                  , "~/AndroidWebManagement/Forms/JPicGalleryCategoryUpdateControl.ascx"
                  , "ثبت دسته بندی گالری تصاویر"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 500);
        }
        public string _PicGalleryCategoryUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PicGalleryCategory"
                   , "~/AndroidWebManagement/Forms/JPicGalleryCategoryUpdateControl.ascx"
                   , "ویرایش دسته بندی گالری تصاویر"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 500);
        }

        //_PicGalleryPic
        public string _PicGalleryPic()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "._PicGalleryPic");
            jGridView.SQL = @"SELECT a.[Code]
                                  ,[Lvl1Code]
                                  ,b.Name Category
                                  ,a.[Name]
                                  ,a.[ArchiveCode]
                                  ,a.[InsertDate]
                              FROM [EntPicGalleryLvl2] a
                              left join [EntPicGalleryLvl1] b 
                              on a.[Lvl1Code] = b.Code";
            jGridView.PageOrderByField = "Code desc";
            jGridView.Title = "PicGalleryPic";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGalleryPicNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PicGalleryPicUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PicGalleryPicUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PicGalleryPicNew()
        {
            return _PicGalleryPicNew(null);
        }
        public string _PicGalleryPicNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PicGalleryPic"
                  , "~/AndroidWebManagement/Forms/JPicGalleryPicUpdateControl.ascx"
                  , "ثبت عکس های گالری تصاویر"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 500);
        }
        public string _PicGalleryPicUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PicGalleryPic"
                   , "~/AndroidWebManagement/Forms/JPicGalleryPicUpdateControl.ascx"
                   , "ویرایش عکس های گالری تصاویر"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 500);
        }

        //_GroundRequest
        public string _GroundRequest()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "._GroundRequest");
            jGridView.SQL = @"SELECT AR.[Code]
                                  ,AR.[UserCode]
	                              ,cap.Name UserName
	                              ,(select top 1 SharePCode from SharePCodeSheet where PersonCode = ar.UserCode and CompanyCode = 1 order by Code desc)SharePCode
                                  ,AR.[ObjectCode]
	                              ,N' متراژ ' + AP.Metraj + N' موقعیت مکانی ' +AP.MogheeyatMakani+N' آدرس '+AP.Address Ground
                                  ,case AR.[Status] when 0 then N'در انتظار پاسخ' when 1 then N'پذیرفته شده' else N'رد شده' end as Status
                                  ,AR.[InsertDate]
                              FROM [dbo].[Andorid_Request] AR
                              left join clsAllPerson cap on cap.Code = AR.[UserCode]
                              left join Android_Ground ap on ap.Code = AR.[ObjectCode]
                              where [RequestType] = 2";
            jGridView.PageOrderByField = "Code desc";
            jGridView.Title = "GroundRequest";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ApartmentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ApartmentsRequestUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ApartmentsRequestUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        //_ApartmentsRequest
        public string _ApartmentsRequest()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "._ApartmentsRequest");
            jGridView.SQL = @"SELECT AR.[Code] Code
                                  ,AR.[UserCode]
	                              ,cap.Name UserName
	                              ,(select top 1 SharePCode from SharePCodeSheet where PersonCode = ar.UserCode and CompanyCode = 1 order by Code desc)SharePCode
                                  ,AR.[ObjectCode]
	                              ,N' پروژه ' + AP.ProjectName + N' طبقه ' +AP.Tabaghe+N' واحد '+AP.ShomareVahed Apartments
                                  ,case AR.[Status] when 0 then N'در انتظار پاسخ' when 1 then N'پذیرفته شده' else N'رد شده' end as Status
                                  ,AR.[InsertDate]
                              FROM [dbo].[Andorid_Request] AR
                              left join clsAllPerson cap on cap.Code = AR.[UserCode]
                              left join Android_Apartments ap on ap.Code = AR.[ObjectCode]
                              where [RequestType] = 1";
            jGridView.PageOrderByField = "Code desc";
            jGridView.Title = "ApartmentsRequest";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ApartmentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ApartmentsRequestUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ApartmentsRequestUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _ApartmentsRequestUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AndroidRequest"
                   , "~/AndroidWebManagement/Forms/JAndroidRequestUpdateControl.ascx"
                   , "ثبت پاسخ درخواست ها"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_Apartments
        public string _Apartments()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "._Apartments");
            jGridView.SQL = "select * from Android_Apartments";
            jGridView.PageOrderByField = "Code desc";
            jGridView.Title = "Apartments";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ApartmentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ApartmentsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ApartmentsUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _ApartmentsNew()
        {
            return _ApartmentsNew(null);
        }
        public string _ApartmentsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Apartment"
                  , "~/AndroidWebManagement/Forms/JApartmentUpdateControl.ascx"
                  , "ثبت آپارتمان ها"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 500);
        }
        public string _ApartmentsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Apartment"
                   , "~/AndroidWebManagement/Forms/JApartmentUpdateControl.ascx"
                   , "ویرایش آپارتمان ها"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 500);
        }

        //_Projects
        public string _Projects()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "._Projects");
            jGridView.SQL = "select * from EntProjects";
            jGridView.PageOrderByField = "Code desc";
            jGridView.Title = "Projects";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ProjectsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ProjectsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ProjectsUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _ProjectsNew()
        {
            return _ProjectsNew(null);
        }
        public string _ProjectsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Projects"
                  , "~/AndroidWebManagement/Forms/JProjectsUpdateControl.ascx"
                  , "ثبت پروژه"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _ProjectsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Projects"
                   , "~/AndroidWebManagement/Forms/JProjectsUpdateControl.ascx"
                   , "ویرایش پروژه"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        public string _News()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_Newss");
            jGridView.SQL = Entertainment.JNewss.GetSqlQuery();
            jGridView.Title = "Newss";
            jGridView.PageOrderByField = " Code desc ";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._NewsUpdate", null, null));
            jGridView.ClassName = "AndroidWebManagement.JAndroidWebManagement._Newss";
            jGridView.ObjectCode = 0;
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
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_SellRequests");
            jGridView.SQL = ManagementShares.TransferRequest.JRequests.GetSellRequestSqlQuery();
            jGridView.Title = "SellRequest";
            jGridView.PageOrderByField = "RequestDate desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("ChangeStatus", "ChangeStatus", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SellRequestChangeStatus", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.ClassName = "AndroidWebManagement.JAndroidWebManagement._SellRequests";
            jGridView.ObjectCode = 0;
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
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_BuyRequest");
            jGridView.SQL = ManagementShares.TransferRequest.JRequests.GetBuyRequestSqlQuery();
            jGridView.Title = "BuyRequest";
            jGridView.PageOrderByField = "RequestDate desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("ChangeStatus", "ChangeStatus", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BuyRequestChangeStatus", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.ClassName = "AndroidWebManagement.JAndroidWebManagement._BuyRequest";
            jGridView.ObjectCode = 0;
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
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_AboutUsTextAndPic");
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
            // ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_PicGallery");
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
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_SharePrice");
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

        //_SharePriceText
        public string _SharePriceText()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_SharePriceText");
            jGridView.SQL = @"select Code,Text,case Type when 1 then N'متن درخواست خرید' else N'متن درخواست فروش' end As [Type],ClassName from entSharePriceText";
            jGridView.Title = "SharePriceText";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Update", "Update", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SharePriceTextUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _SharePriceTextUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SharePriceText"
                   , "~/AndroidWebManagement/Forms/JSharePriceTextUpdateControl.ascx"
                   , "ویرایش"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_SendBox
        public string _SendBox()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_SendBox");
            jGridView.SQL = @"Select  ShareMessage.Code, SenderCode, ReceiverCode, Type ,
                                (select top 1 Name from clsAllPerson where code =  ShareMessage .SenderCode) SenderName ,
                                s.SharePCode ShareCode,
                                (select top 1 Name from clsAllPerson where code =  ShareMessage .ReceiverCode) ReceiverName, 
                                sDate,Title, Body
                                from ShareMessage
                                left join (select PersonCode,MAX(SharepCode)SharepCode from SharePCodeSheet where CompanyCode = 1
								group by PersonCode) s on s.PersonCode = ShareMessage.ReceiverCode
                                where SenderCode =" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            jGridView.Title = "SendBox";
            jGridView.PageOrderByField = "sDate Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendBoxNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Delete", "Delete", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeleteSendBoxNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Delete));
            jGridView.Toolbar.AddButton("SendToAll", "SendToAll", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendToAll", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Menu_Edit));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }


        //SendToAll
        public string _SendToAll()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SendToAll"
                   , "~/AndroidWebManagement/Forms/JSendMessageToAllUpdateControl.ascx"
                   , "ارسال پیام گروهی"
                   , null
                   , WindowTarget.NewWindow
                   , true, false, true, 800, 450);
        }

        public string _DeleteSendBoxNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DeleteSendBoxNew"
                   , "~/AndroidWebManagement/Forms/JDeleteSendBoxNewUpdateControl.ascx"
                   , "حذف پیام"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 400, 220);
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
                   , true, false, true, 800, 450);
        }

        //_InBox
        public string _InBox()
        {
            ManagementShares.JShareCompany Company = new ManagementShares.JShareCompany(1);
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_InBox");
            jGridView.SQL = @"select  ShareMessage.Code, SenderCode, ReceiverCode ,
                                 sps.SharePCode,(select top 1 Name from clsAllPerson where code =  ShareMessage .SenderCode) SenderName 
                                 ,(select top 1 Name from clsAllPerson where code =  ShareMessage .ReceiverCode) ReceiverName, sDate,Title, Body
                                from ShareMessage
                                left join (select * from SharePCodeSheet where CompanyCode = 1) sps on sps.PersonCode = ShareMessage.SenderCode
                                where Type = 2 and ReceiverCode in(" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @"," + Company.PCode + @")";
            jGridView.Title = "InBox";
            jGridView.PageOrderByField = "sDate Desc";
            jGridView.PageSize = 5;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Delete", "Delete", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeleteSendBoxNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Delete));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        //_InBoxEnteghad
        public string _InBoxEnteghad()
        {
            ManagementShares.JShareCompany Company = new ManagementShares.JShareCompany(1);
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_InBoxEnteghad");
           jGridView.SQL = @"Select  ShareMessage.Code, SenderCode, ReceiverCode ,
                                (select top 1 sharePCode from SharePCodeSheet where personcode=SenderCode) SharePCode
								,(select name from clsAllPerson where code=SenderCode) SenderName 
								,(select name from clsAllPerson where code=ReceiverCode) ReceiverName,
								 sDate,Title, Body
                                from ShareMessage
                                where Type = 3 and ReceiverCode in(" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @"," + Company.PCode + @")";
            jGridView.Title = "_InBoxEnteghad";
            jGridView.PageOrderByField = "sDate Desc";
            jGridView.PageSize = 5;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Delete", "Delete", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeleteSendBoxNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Delete));
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