using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Bascol
{
    class JBascolStaticNodes : JStaticNode
    {
        /// <summary>
        /// تعاریف اولیه
        /// </summary>
        /// <returns></returns>
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "Bascol.JBascolBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "Bascol.JBascolBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "Bascol.JBascolBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
        /// <summary>
        /// ماشین
        /// </summary>
        /// <returns></returns>
        public static JNode _TruckNode()
        {           
            JNode Node = new JNode(0, "Bascol.JTruck");
            Node.Name = "Trucks";
            //Node.Icone = 4;
            Node.Hint = "Trucks";

            JAction Ac = new JAction("Trucks", "Bascol.JTrucks.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static JNode _Products()
        {
            JNode Node = new JNode(0, "Bascol.JProductss");
            Node.Name = "Products";
            JAction Ac = new JAction("Products", "Bascol.JProductss.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.ResCostCenter.GetHashCode();
            return Node;
        }
        /// <summary>
        /// توزین
        /// </summary>
        /// <returns></returns>
        public static JNode _TozinNode()
        {
            JNode Node = new JNode(0, "Bascol.JWeight");
            Node.Name = "Weight";
            //Node.Icone = 4;
            Node.Hint = "Weight";

            JAction Ac = new JAction("Weight", "Bascol.JWeights.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        /// <summary>
        /// گزارش کاربر
        /// </summary>
        /// <returns></returns>
        public static JNode _ReportUser()
        {
            JNode Node = new JNode(0, "Bascol.JReport");
            Node.Name = "ReportUser";
            JAction Ac = new JAction("ReportUser", "Bascol.JReport.ShowReportUserForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.report.GetHashCode();
            return Node;
        }
        /// <summary>
        /// گزارش مدیر
        /// </summary>
        /// <returns></returns>
        public static JNode _ReportManger()
        {

            JNode Node = new JNode(0, "Bascol.JReport");
            Node.Name = "ReportManager";
            JAction Ac = new JAction("ReportManager", "Bascol.JReport.ShowReportMangerForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.report.GetHashCode();
            return Node;
        }
        /// <summary>
        /// گزارش چارت
        /// </summary>
        /// <returns></returns>
        public static JNode _ReportChart()
        {
            JNode Node = new JNode(0, "Bascol.JReport");
            Node.Name = "ReportChart";
            JAction Ac = new JAction("ReportChart", "Bascol.JReport.ShowReportChartForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.report.GetHashCode();
            return Node;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static JNode _ConfigBascol()
        {
            JNode Node = new JNode(0, "Bascol.JConfigBascolForm");
            Node.Name = "ConfigBascol";
            JAction Ac = new JAction("ConfigBascol", "Bascol.JReport.ShowConfigBascolForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.report.GetHashCode();
            return Node;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static JNode _ConfigTax()
        {
            JNode Node = new JNode(0, "Bascol.JConfigBascolForm");
            Node.Name = "ConfigTaxDuty";
            JAction Ac = new JAction("ConfigTaxDuty", "Bascol.JReport.ShowTaxForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.report.GetHashCode();
            return Node;
        }
                /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static JNode _ChangPlok()
        {
            JNode Node = new JNode(0, "Bascol.JChangePlokForm");
            Node.Name = "ChangePlok";
            JAction Ac = new JAction("ChangePlok", "Bascol.JReport.ShowChangePlokForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.report.GetHashCode();
            return Node;
        }
        
    }
}
