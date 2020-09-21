using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebReports
    {
        public const string _ConstClassName = "WebOilManagement.JWebReports";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();

            #region _37PerformanceZone ۩۩
            ///گزارش عملکرد مناطق 37 گانه =>  
            ///37PerformanceZone
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._37PerformanceZone", null, new List<object>() { }) }, "37PerformanceZone", _ConstClassName + "._37PerformanceZone", JDomains.Images.MenuImages.Item, null));
            #endregion _37PerformanceZone  ۩۩

            #region _ManagerPortalReports ۩۩
            ///گزارش هاي مدیریتی از پرتال
            ///ManagerPortalReports
            /// nodes.Add(new JNode(null, "گزارش هاي مدیریتی از پرتال", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalFunctionsCountReports", null, new List<object>() { }) }, "MalFunctionsCountReports", _ConstClassName + "._MalFunctionsCountReports", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalFunctionsTableDamagesReports", null, new List<object>() { }) }, "MalFunctionsTableDamagesReports", _ConstClassName + "._MalFunctionsTableDamagesReports", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalFunctionStateReports", null, new List<object>() { }) }, "MalFunctionStateReports", _ConstClassName + "._MalFunctionStateReports", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalfunctionSupplierReports", null, new List<object>() { }) }, "MalfunctionSupplierReports", _ConstClassName + "._MalfunctionSupplierReports", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalFunctionsZonetReports", null, new List<object>() { }) }, "MalFunctionsZonetReports", _ConstClassName + "._MalFunctionsZonetReports", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalFunctionUsersCountReports", null, new List<object>() { }) }, "MalFunctionUsersCountReports", _ConstClassName + "._MalFunctionUsersCountReports", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ManagerPortalReports", null, new List<object>() { }) }, "ManagerPortalReports", _ConstClassName + "._ManagerPortalReports", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ManagerPortalReports", null, new List<object>() { }) }, "ManagerPortalReports", _ConstClassName + "._ManagerPortalReports", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ManagerPortalReports", null, new List<object>() { }) }, "ManagerPortalReports", _ConstClassName + "._ManagerPortalReports", JDomains.Images.MenuImages.Item, null));

            #endregion _ManagerPortalReports ۩۩

            #region _CallCenterPerformanceReport ۩۩
            ///گزارش عملکرد CALL CENTER
            ///CallCenterPerformanceReport
            ///nodes.Add(new JNode(null, "گزارش عملکرد CALL CENTER", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CallCenterPerformanceReport", null, new List<object>() { }) }, "گزارش عملکرد CALL CENTER", _ConstClassName + "._CallCenterPerformanceReport", JDomains.Images.MenuImages.Item, null));
            #endregion _CallCenterPerformanceReport ۩۩

            #region _GSPropertiesReport ۩۩
            ///گزارش مشخصات جایگاه ها
            ///GSPropertiesReport
            /// nodes.Add(new JNode(null, "گزارش مشخصات جایگاه ها", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GSPropertiesReport"
                        , null, new List<object>() { }) }, "گزارش مشخصات جایگاه ها", _ConstClassName + "._GSPropertiesReport", JDomains.Images.MenuImages.Item, null));
            #endregion _GSPropertiesReport ۩۩

            #region _HandyLoadReports  ۞۞
            ///گزارش آمار بارگزاری دستی RPM
            ///HandyLoadReport
            ///nodes.Add(new JNode(null, "گزارش آمار بارگذاري دستی RPM", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HandyLoadReports", null, new List<object>() { }) }, "گزارش آمار بارگزاری دستی RPM", _ConstClassName + "._HandyLoadReports", JDomains.Images.MenuImages.Item, null));
            #endregion _HandyLoadReports ۞۞

            #region _LaggingTicketReport ۞۞
            ///گزارش از Ticket هاي باز مانده
            ///LaggingTicketReport
            ///nodes.Add(new JNode(null, "گزارش از Ticket هاي باز مانده", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LaggingTicketReport", null, new List<object>() { }) }, "گزارش از Ticket هاي باز مانده", _ConstClassName + "._LaggingTicketReport", JDomains.Images.MenuImages.Item, null));
            #endregion _LaggingTicketReport ۞۞

            #region _UsedMaterielVsStoreFlowReport
            ///گزارش مقایسه اي بین مصارف تجهیزات و گردش انبار
            ///UsedMaterielVsStoreFlowReport
            ///nodes.Add(new JNode(null, "گزارش مقایسه اي بین مصارف تجهیزات و گردش انبار", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UsedMaterielVsStoreFlowReport", null, new List<object>() { }) }, "گزارش مقایسه اي بین مصارف تجهیزات و گردش انبار", _ConstClassName + "._UsedMaterielVsStoreFlowReport", JDomains.Images.MenuImages.Item, null));
            #endregion _UsedMaterielVsStoreFlowReport

            #region _StoresFlowReport ۞۞
            ///گزارش گیري از تجهیزات در گردش بین انبارها
            ///StoresFlowReport
            ///nodes.Add(new JNode(null, "گزارش گیري از تجهیزات در گردش بین انبارها", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._StoresFlowReport", null, new List<object>() { }) }, "گزارش گیري از تجهیزات در گردش بین انبارها", _ConstClassName + "._StoresFlowReport", JDomains.Images.MenuImages.Item, null));
            #endregion _StoresFlowReport ۞۞

            #region _PeriodicPart_ReaderEventReport ۞۞
            ///رویت کلیه Event هاي یک قطعه  و Reader) ...)در طول یک بازه زمانی
            ///PeriodicPart_ReaderEventReport
            ///nodes.Add(new JNode(null, "رویت کلیه Event هاي یک قطعه  و Reader) ...)در طول یک بازه زمانی", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PeriodicPart_ReaderEventReport", null, new List<object>() { }) }, "رویت کلیه Event هاي یک قطعه  و Reader) ...)در طول یک بازه زمانی", _ConstClassName + "._PeriodicPart_ReaderEventReport", JDomains.Images.MenuImages.Item, null));
            #endregion _PeriodicPart_ReaderEventReport ۞۞

            #region _InstallStateSupplyDuctsReport ۞۞
            ///رویت وضعیت نصب تجهیزات در مجاري عرضه
            ///InstallStateSupplyDuctsReport
            ///nodes.Add(new JNode(null, "رویت وضعیت نصب تجهیزات در مجاري عرضه", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InstallStateSupplyDuctsReport", null, new List<object>() { }) }, "رویت وضعیت نصب تجهیزات در مجاري عرضه", _ConstClassName + "._InstallStateSupplyDuctsReport", JDomains.Images.MenuImages.Item, null));
            #endregion _InstallStateSupplyDuctsReport ۞۞

            #region _MalFunctionVsRepairReports ۞۞
            ///گزارش‌گیری از خرابی‌ها و تعمیرات انجام شده
            ///MalFunctionVsRepairReports
            ///nodes.Add(new JNode(null, "گزارش‌گیری از خرابی‌ها و تعمیرات انجام شده", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalFunctionVsRepairReports", null, new List<object>() { }) }, "گزارش‌گیری از خرابی‌ها و تعمیرات انجام شده", _ConstClassName + "._MalFunctionVsRepairReports", JDomains.Images.MenuImages.Item, null));
            #endregion _MalFunctionVsRepairReports

            #region _GsMalfunctionReport ۞۞
            ///گزارش خرابی‌های هر جایگاه
            ///GsMalfunctionReport
            ///nodes.Add(new JNode(null, "گزارش خرابی‌های هر جایگاه", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GsMalfunctionReport", null, new List<object>() { }) }, "گزارش خرابی‌های هر جایگاه", _ConstClassName + "._GsMalfunctionReport", JDomains.Images.MenuImages.Item, null));
            #endregion _GsMalfunctionReport ۞۞

            #region _SupplierPerformanceVsSLAReport
            ///گزارش عملکرد پیمانکار و مقایسه با SLA
            ///SupplierPerformanceVsSLAReport
            ///nodes.Add(new JNode(null, "گزارش عملکرد پیمانکار و مقایسه با SLA", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SupplierPerformanceVsSLAReport", null, new List<object>() { }) }, "SupplierPerformanceVsSLAReport", _ConstClassName + "._SupplierPerformanceVsSLAReport", JDomains.Images.MenuImages.Item, null));
            #endregion _SupplierPerformanceVsSLAReport

            #region _BackUpStoreRemainPartReport ۞۞
            ///گزارش آمار تجهیزات موجود در انبارهای پشتیبان
            ///BackUpStoreRemainPartReport
            ///nodes.Add(new JNode(null, "گزارش آمار تجهیزات موجود در انبارهای پشتیبان", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BackUpStoreRemainPartReport", null, new List<object>() { }) }, "گزارش آمار تجهیزات موجود در انبارهای پشتیبان", _ConstClassName + "._BackUpStoreRemainPartReport", JDomains.Images.MenuImages.Item, null));
            #endregion _BackUpStoreRemainPartReport ۞۞

            #region _HardDiskReplacementReport ۞۞
            ///گزارش تعویض هارد
            ///HardDiskReplacementReport
            ///nodes.Add(new JNode(null, "گزارش تعویض هارد", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HardDiskReplacementReport", null, new List<object>() { }) }, "گزارش تعویض هارد", _ConstClassName + "._HardDiskReplacementReport", JDomains.Images.MenuImages.Item, null));
            #endregion _HardDiskReplacementReport ۞۞

            #region _CompareIpcLogVsSupplierRepair ۞۞
            ///مقایسه گزارش تعمیرات پیمانکار با IPC Log
            ///CompareIpcLogVsSupplierRepair
            /// nodes.Add(new JNode(null, "مقایسه گزارش تعمیرات پیمانکار با IPC Log", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CompareIpcLogVsSupplierRepair", null, new List<object>() { }) }, "مقایسه گزارش تعمیرات پیمانکار با IPC Log", _ConstClassName + "._CompareIpcLogVsSupplierRepair", JDomains.Images.MenuImages.Item, null));
            #endregion _CompareIpcLogVsSupplierRepair

            #region _NewGSReport ۞۞
            ///گزارش آمار جایگاه‌های جدیدالتاسیس
            ///NewGSReport
            ///nodes.Add(new JNode(null, "گزارش آمار جایگاه‌های جدیدالتاسیس", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewGSReport", null, new List<object>() { }) }, "NewGSReport", _ConstClassName + "._NewGSReport", JDomains.Images.MenuImages.Item, null));
            #endregion _NewGSReport  ۞۞

            #region _SAMReport
            ///گزارش SAM گذاری
            ///SAMReport
            ///nodes.Add(new JNode(null, "گزارش SAM گذاری", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SAMReport", null, new List<object>() { }) }, "SAMReport", _ConstClassName + "._SAMReport", JDomains.Images.MenuImages.Item, null));
            #endregion _SAMReport

            return nodes;
        }

        public string _WebUserControl1()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("WebUserControl1"
                  , "~/WebOilManagement/FormsReports/WebUserControl1.ascx"
                  , "گزارش عملکرد مناطق 37 گانه"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _37PerformanceZone()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("37PerformanceZone"
                  , "~/WebOilManagement/FormsReports/J37PerformanceZoneControl.ascx"
                  , "گزارش عملکرد مناطق 37 گانه"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _CompareIpcLogVsSupplierRepair()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("CompareIpcLogVsSupplierRepair"
                  , "~/WebOilManagement/FormsReports/JCompareIpcLogVsSupplierRepairControl.ascx"
                  , "مقایسه گزارش تعمیرات پیمانکار با IPC Log"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        #region _ManagerPortalReports ۩۩
        /////______________________________________________________________________________________
        public string _MalFunctionsZonetReports()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MalFunctionsZonetReports"
                           , "~/WebOilManagement/FormsReports/JManagerPortalReportsControl.ascx"
                           , "تعداد تیکت های ثبت شده به ازا مناطق نفتی"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", ((int)OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceMalfunctionReport.ZoneTicket).ToString()) }
                           , WindowTarget.NewWindow
                           , false, true, true, 0, 0, true);
        }
        /////______________________________________________________________________________________
        public string _MalFunctionsCountReports()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MalFunctionsCountReports"
                                  , "~/WebOilManagement/FormsReports/JManagerPortalReportsControl.ascx"
                                  , "کل تیکت های ثبت شده"
                                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", ((int)OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceMalfunctionReport.AllTicket).ToString()) }
                                  , WindowTarget.NewWindow
                                  , false, true, true, 0, 0, true);
        }
        /////______________________________________________________________________________________
        public string _MalFunctionsTableDamagesReports()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MalFunctionsTableDamagesReports"
                            , "~/WebOilManagement/FormsReports/JManagerPortalReportsControl.ascx"
                            , "تعداد تیکت های ثیت شده به ازا نوع خرابی"
                            , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", ((int)OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceMalfunctionReport.TypeTicket).ToString()) }
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }
        /////______________________________________________________________________________________
        public string _MalfunctionSupplierReports()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MalfunctionSupplierReports"
               , "~/WebOilManagement/FormsReports/JManagerPortalReportsControl.ascx"
                       , "تعداد تیکت های ثبتی به ازا پیمانکاران"
                       , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", ((int)OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceMalfunctionReport.SupplierTicket).ToString()) }
                       , WindowTarget.NewWindow
                       , false, true, true, 0, 0, true);
        }
        /////______________________________________________________________________________________
        public string _MalFunctionStateReports()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MalFunctionStateReports"
                        , "~/WebOilManagement/FormsReports/JManagerPortalReportsControl.ascx"
                        , "تعدادتیکت ها با وضعیت های مختلف"
                        , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", ((int)OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceMalfunctionReport.StatusTicket).ToString()) }
                        , WindowTarget.NewWindow
                        , false, true, true, 0, 0, true);
        }
        /////______________________________________________________________________________________
        public string _MalFunctionUsersCountReports()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MalFunctionUsersCountReports"
                       , "~/WebOilManagement/FormsReports/JManagerPortalReportsControl.ascx"
                       , "تعداد تیکت ها ی ثبتی توسط هر یک ازکاربران مرکز تماس"
                       , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", ((int)OilProductsDistributionCompany.Failure.JMalfunctiones.PerformanceMalfunctionReport.UsersTicket).ToString()) }
                       , WindowTarget.NewWindow
                       , false, true, true, 0, 0, true);
        }
        /////______________________________________________________________________________________
        #endregion _ManagerPortalReports ۩۩
        /////--------------------------------------------------------------------------------------
        public string _GSPropertiesReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GSPropertiesReport"
                  , "~/WebOilManagement/FormsReports/JGSPropertiesReportControl.ascx"
                  , "گزارش مشخصات جایگاه ها"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _HandyLoadReports()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HandyLoadReports"
                  , "~/WebOilManagement/FormsReports/JHandyLoadReportsControl.ascx"
                  , "گزارش آمار بارگزاری دستی RPM"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _LaggingTicketReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LaggingTicketReport"
                  , "~/WebOilManagement/FormsReports/JLaggingTicketReportControl.ascx"
                  , "گزارش از Ticket هاي باز مانده"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _UsedMaterielVsStoreFlowReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UsedMaterielVsStoreFlowReport"
                  , "~/WebOilManagement/FormsReports/JUsedMaterielVsStoreFlowReportControl.ascx"
                  , "گزارش مقایسه اي بین مصارف تجهیزات و گردش انبار"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _StoresFlowReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("StoresFlowReport"
                  , "~/WebOilManagement/FormsReports/JStoresFlowReportControl.ascx"
                  , "گزارش گیري از تجهیزات در گردش بین انبارها"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);

        }
        /////--------------------------------------------------------------------------------------
        public string _PeriodicPart_ReaderEventReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PeriodicPart_ReaderEventReport"
                  , "~/WebOilManagement/FormsReports/PeriodicPart_ReaderEventReport.ascx"
                  , "رویت کلیه Event هاي یک قطعه  و Reader) ...)در طول یک بازه زمانی"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _InstallStateSupplyDuctsReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InstallStateSupplyDuctsReport"
                  , "~/WebOilManagement/FormsReports/JInstallStateSupplyDuctsReportControl.ascx"
                  , "رویت وضعیت نصب تجهیزات در مجاري عرضه"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _MalFunctionVsRepairReports()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MalFunctionVsRepairReports"
                  , "~/WebOilManagement/FormsReports/JMalFunctionVsRepairReportsRepairControl.ascx"
                  , "گزارش‌گیری از خرابی‌ها و تعمیرات انجام شده"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);

        }
        /////--------------------------------------------------------------------------------------
        public string _GsMalfunctionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GsMalfunctionReport"
                  , "~/WebOilManagement/FormsReports/JGsMalfunctionReportControl.ascx"
                  , "گزارش خرابی‌های هر جایگاه"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _SupplierPerformanceVsSLAReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SupplierPerformanceVsSLAReport"
                  , "~/WebOilManagement/FormsReports/JSupplierPerformanceVsSLAReportControl.ascx"
                  , "گزارش عملکرد پیمانکار و مقایسه با SLA"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _BackUpStoreRemainPartReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BackUpStoreRemainPartReport"
                  , "~/WebOilManagement/FormsReports/JBackUpStoreRemainPartReportControl.ascx"
                  , "گزارش آمار تجهیزات موجود در انبارهای پشتیبان"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _HardDiskReplacementReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HardDiskReplacementReport"
                  , "~/WebOilManagement/FormsReports/JHardDiskReplacementReportControl.ascx"
                  , "گزارش تعویض هارد"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _CallCenterPerformanceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("CallCenterPerformanceReport"
                  , "~/WebOilManagement/FormsReports/JCallCenterPerformanceReportControl.ascx"
                  , "گزارش عملکرد CALL CENTER"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _NewGSReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("NewGSReport"
                  , "~/WebOilManagement/FormsReports/JNewGSReportControl.ascx"
                  , "گزارش آمار جایگاه‌های جدیدالتاسیس"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------
        public string _SAMReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SAMReport"
                  , "~/WebOilManagement/FormsReports/JSAMReportControl.ascx"
                  , "گزارش SAM گذاری"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }
        /////--------------------------------------------------------------------------------------

        public void Malfunction(string Query, string Title)
        {
            //WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            //jGridView.ClassName = _ConstClassName;
            //jGridView.SQL = "Select * From (" + OilProductsDistributionCompany.Failure.JMalfunctiones.GetWebQuery() + " WHERE Code IN (Select Code From (" + Query + "))";
            //jGridView.Title = Title;
            //jGridView.PageSize = 100;
            //jGridView.PageOrderByField = "Code Desc";
            //jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalfunctionNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalfunctionUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._MalfunctionUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            if (Query != string.Empty)
                WebClassLibrary.JWebManager.LoadControl("MalFunctionsView"
                          , "~/WebOilManagement/FormsReports/JMalfunctionViewControl.ascx"
                          , "جزئیات خرابی"
                          , new List<Tuple<string, string>>() { new Tuple<string, string>("Query", Query), new Tuple<string, string>("Title", Title) }
                          , WindowTarget.CurrentWindow
                          , false, true, true, 0, 0, true);

        }

        //public string Malfunction()
        //{ret }
    }
}