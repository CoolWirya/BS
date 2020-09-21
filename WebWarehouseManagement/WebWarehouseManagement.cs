using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;
using System.Data;



namespace WebWarehouseManagement
{
    public class JWebWarehouseManagement
    {
        public const string _ConstClassName = "WebWarehouseManagement.JWebWarehouseManagement";


        #region "Main Method"
        /// <summary>
        /// متد ساخت و هندل کردن منو و آیتم های پروژه در پروژه مادر
        /// </summary>
        /// <returns></returns>
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GoodRequest", null, new List<object>() { }) }, "درخواست کالا از انبار", _ConstClassName, JDomains.Images.MenuImages.Item, null));

            //--------------------------------------------------
            nodes.Add(new JNode(null, "ثبت و نگهداری قطعات و تجهیزات", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>(){
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GoodsHierarchy", null, new List<object>() { }) }, "GoodsHierarchy", _ConstClassName, JDomains.Images.MenuImages.Item, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TypesOfGoods", null, new List<object>() { }) }, "TypesOfGoods", _ConstClassName, JDomains.Images.MenuImages.Item, null),
             //   new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Manufacturers", null, new List<object>() { }) }, "Manufacturers", _ConstClassName, JDomains.Images.MenuImages.Item, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Goods", null, new List<object>() { }) }, "Goods", _ConstClassName, JDomains.Images.MenuImages.Item, null)
            }));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Warehouses", null, new List<object>() { }) }, "Warehouses", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ReceiptOfGoods", null, new List<object>() { }) }, "ReceiptOfGoods", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BillOfGoods", null, new List<object>() { }) }, "BillOfGoods", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GoodsExistence", null, new List<object>() { }) }, "گزارش موجودی کالا در انبار", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GoodsPerson", null, new List<object>() { }) }, "گزارش تولید کنندگان کالا", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            return nodes;
        }

        #endregion


        #region "Grid Fill Method's & Create Menu Items"
        /// <summary>
        /// متدهای پر کردن گرید فرم مادر و نمایش کنترل های فرم
        /// </summary>
        /// <returns></returns>
        public string _GoodRequest()
        {
            string Query = string.Empty;

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));

            Query = WarehouseManagement.Goods.JWarGoodRequest.GetWebQuery();

            jGridView.SQL = Query;
            //WarehouseManagement.Goods.JTypesOfGoodSes.GetWebQuery();
            jGridView.Title = "GoodsRequest";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".GoodRequestNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("New", "NewDT", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".GoodsRequestNewDT", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));

            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".GoodRequestUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + ".GoodRequestUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _GoodsHierarchy()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("warGoodsHierarchy", "~/WebWarehouseManagement/Forms/JGoodsHierarchyTreeListControl.ascx", "دسته بندی های کالا", null, WindowTarget.NewWindow, true, true, true, 0, 0, true);

        }
        public string _TypesOfGoods()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = WarehouseManagement.Goods.JTypesOfGoodSes.GetWebQuery();
            jGridView.Title = "warTypesOfGoods";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TypesOfGoodsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TypesOfGoodsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._TypesOfGoodsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _Warehouses()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = WarehouseManagement.Warehouse.JWarehousees.GetWebQuery();
            jGridView.Title = "warWarehouses";
          //  jGridView.HiddenColumns = "Code";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._WarehouseNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._WarehouseUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilDistrictUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _Manufacturers()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(WarehouseManagement.Define.JDefine.Manufacturers, "Manufacturers").GenerateWindow(false, false, false), true);
        }
        public string _Goods()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = WarehouseManagement.Goods.JGoodSes.GetWebQuery();
            jGridView.Title = "warGoods";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GoodsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GoodsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._GoodsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _ReceiptOfGoods()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = WarehouseManagement.Goods.JReceiptOfGoodSes.GetWebQuery();
            jGridView.Title = "warReceiptOfGoods";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ReceiptOfGoodsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ReceiptOfGoodsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ReceiptOfGoodsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _BillOfGoods()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = WarehouseManagement.Goods.JBillOfGoodSes.GetWebQuery();
            jGridView.Title = "warBillOfGoods";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BillOfGoodsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BillOfGoodsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._BillOfGoodsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _GoodsExistence()
        {
            return _GoodsExistence(null);
        }
        public string _GoodsExistence(string code)
        {

            return WebClassLibrary.JWebManager.LoadClientControl("GoodsExistence"
                , "~/WebWarehouseManagement/Reports/GoodsExistence.ascx"
                , "گزارش موجودی کالا در انبار"
                , null
                , WindowTarget.NewWindow
                , false, false, true,0, 0,true);
        }

        public string _GoodsPerson()
        {
            return _GoodsPerson(null);
        }
        public string _GoodsPerson(string code)
        {

            return WebClassLibrary.JWebManager.LoadClientControl("GoodsPerson"
                , "~/WebWarehouseManagement/Reports/GoodsPerson.ascx"
                , "گزارش تولید کنندگان کالا {به تفکیک کالا / تولید کننده}"
                , null
                , WindowTarget.NewWindow
                , false, false, true, 0, 0, true);
        }


        #endregion

        public string GoodRequestNew()
        {
            return GoodRequestNew(null);
        }
        public string GoodRequestNew(string Code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GoodRequestNew"
                , "~/WebWarehouseManagement/Forms/JStockRequestUpdateControl.ascx"
                , "در خواست کالا از انبار"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }


        /// <summary>
        /// یک دیتاتیبل دریافت کرده
        /// </summary>
        /// <param name="GoodsDataTable"></param>
        /// <returns></returns>
        public string GoodsRequestNewDT(string GoodsDataTable)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ClassName");
            dt.Columns.Add("ObjectCode");
            dt.Columns.Add("WarCode");
            dt.Columns.Add("UserCode");
            dt.Columns.Add("RequestDate");
            dt.Columns.Add("GoodsCode");
            dt.Columns.Add("GoodsCount");
            DataRow dr;

            dr = dt.NewRow();
            dr["ClassName"] = "_ClassName";
            dr["ObjectCode"] = 0;
            dr["WarCode"] = 2;
            dr["UserCode"] = 1;
            dr["RequestDate"] = DateTime.Now;
            dr["GoodsCode"] = "1,2,3";
            dr["GoodsCount"] = "5,6,7";

            dt.Rows.Add(dr);

            System.Text.StringBuilder script = new System.Text.StringBuilder();

            script.Append("CalssName=" + dt.Rows[0]["ClassName"]);
            script.Append("|");
            script.Append("ObjectCode=" + dt.Rows[0]["ObjectCode"]);
            script.Append("|");
            script.Append("WarCode=" + dt.Rows[0]["WarCode"]);
            script.Append("|");
            script.Append("UserCode=" + dt.Rows[0]["UserCode"]);
            script.Append("|");
            script.Append("RequestDate=" + dt.Rows[0]["RequestDate"]);
            script.Append("|");
            script.Append("GoodsCode=" + dt.Rows[0]["GoodsCode"]);
            script.Append("|");
            script.Append("GoodsCount=" + dt.Rows[0]["GoodsCount"]);


            return WebClassLibrary.JWebManager.LoadClientControl("GoodRequestNew"
                , "~/WebWarehouseManagement/Forms/JStockRequestUpdateControl.ascx"
                , "در خواست کالا از انبار"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("GoodsDataTable", script.ToString()) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }

        public string GoodRequestUpdate(string Code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GoodRequestUpdate"
               , "~/WebWarehouseManagement/Forms/JStockRequestUpdateControl.ascx"
               , "ویرایش کالاهای درخواستی از انبار"
               , new List<Tuple<string, string>>() { new Tuple<string, string>("code", Code) }
               , WindowTarget.NewWindow
               , true, false, true, 600, 400);
        }

        // TypesOfGoods New/Edit
        public string _TypesOfGoodsNew()
        {
            return _TypesOfGoodsNew(null);
        }
        public string _TypesOfGoodsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("User"
                , "~/WebWarehouseManagement/Forms/JTypesOfGoodsUpdateControl.ascx"
                , "انواع کالا"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }

        public string _TypesOfGoodsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("User"
                , "~/WebWarehouseManagement/Forms/JTypesOfGoodsUpdateControl.ascx"
                , "انواع کالا"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 200);
        }

        // Goods New/Edit
        public string _WarehouseNew()
        {
            return _WarehouseNew(null);
        }
        public string _WarehouseNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Warehouse"
                , "~/WebWarehouseManagement/Forms/JWarehouseUpdateControl.ascx"
                , "تعریف انبار"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 550);
        }

        public string _WarehouseUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Warehouse"
                , "~/WebWarehouseManagement/Forms/JWarehouseUpdateControl.ascx"
                , "تعریف انبار"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 550);
        }

        // Goods New/Edit
        public string _GoodsNew()
        {
            return _GoodsNew(null);
        }
        public string _GoodsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Goods"
                , "~/WebWarehouseManagement/Forms/JGoodsUpdateControl.ascx"
                , "تعریف کالا"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 550, false);
        }

        public string _GoodsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Goods"
                , "~/WebWarehouseManagement/Forms/JGoodsUpdateControl.ascx"
                , "تعریف کالا"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 630, 350);
        }

        // ReceiptOfGoods New/Edit
        public string _ReceiptOfGoodsNew()
        {
            return _ReceiptOfGoodsNew(null);
        }
        public string _ReceiptOfGoodsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ReceiptOfGoods"
                , "~/WebWarehouseManagement/Forms/JReceiptOfGoodsUpdateControl.ascx"
                , "رسید ورود کالا به انبار"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 850, 650);
        }

        public string _ReceiptOfGoodsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ReceiptOfGoods"
                , "~/WebWarehouseManagement/Forms/JReceiptOfGoodsUpdateControl.ascx"
                , "رسید ورود کالا به انبار"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                 , true, false, true, 850, 650);
        }

        // BillOfGoods New/Edit
        public string _BillOfGoodsNew()
        {
            return _BillOfGoodsNew(null);
        }
        public string _BillOfGoodsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BillOfGoods"
                , "~/WebWarehouseManagement/Forms/JBillOfGoodsUpdateControl.ascx"
                , "حواله خروج از انبار"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 850, 650);
        }

        public string _BillOfGoodsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BillOfGoods"
                , "~/WebWarehouseManagement/Forms/JBillOfGoodsUpdateControl.ascx"
                , "حواله خروج از انبار"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 850, 650);
        }

        public string ShowRefer(object ReferCode)
        {
            int referCode = 0;
            int.TryParse(ReferCode.ToString(), out referCode);

            return WebClassLibrary.JWebManager.LoadClientControl("StockGoodRequest"
                  , "~/WebWarehouseManagement/Forms/JStockRequestUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("ReferCode", ReferCode.ToString()) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, false, true, 650, 450);
        }

    
    }
}