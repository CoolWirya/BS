using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCStaticNodes : JStaticNode
    {
        /// <summary>
        /// تعاریف پایه
        /// </summary>
        /// <returns></returns>
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "StoreComplex.JSCBaseDefine");
            Node.Name = "BaseDefine";
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "StoreComplex.JSCBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "StoreComplex.JSCBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
        public static JNode _Reports()
        {
            JNode Node = new JNode(0, "StoreComplex.JReportNodes");
            Node.Name = "Reports";
            Node.Hint = "Reports";

            JAction Ac = new JAction("BaseDefine", "StoreComplex.JReportNodes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "StoreComplex.JReportNodes.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }

        public static JNode _GeneralReport()
        {
            JNode Node = new JNode(0, "StoreComplex.JSCReport");
            Node.Name = " گزارشات کلی ";
            JAction Ac = new JAction(" گزارشات کلی ", "StoreComplex.JSCReport.ShowDialog", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _RenewReport()
        {
            JNode Node = new JNode(0, "StoreComplex.JRenew");
            Node.Name = " گزارش اتمام و تمدید ";
            JAction Ac = new JAction(" گزارش اتمام و تمدید ", "StoreComplex.JRenew.ShowDialog", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _RenewPrivateReport()
        {
            JNode Node = new JNode(0, "StoreComplex.JRenewPrivate");
            Node.Name = " گزارش اتمام و تمدید (انبار اختصاصی)";
            JAction Ac = new JAction("  گزارش اتمام و تمدید (انبار اختصاصی) ", "StoreComplex.JRenewPrivate.ShowDialog", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        public static JNode _Goods()
        {
            JNode Node = new JNode(0, "StoreManagement.JGoodss");
            Node.Name = " کالاها ";
            JAction Ac = new JAction(" کالاها ", "StoreManagement.JGoodss.ListView", new object[] { }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        /// <summary>
        ///گروه کالاها
        /// </summary>
        /// <returns></returns>
        public static JNode _SCGoods()
        {
            JNode Node = new JNode(0, "StoreComplex.JSCGoods");
            Node.Name = "GoodsGroup";
            //Node.Icone = 4;
            Node.Hint = "GoodsGroup";

            JAction Ac = new JAction("GoodsGroups", "StoreManagement.JGoodsGroups.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        /// <summary>
        ///سرویسهای انبارداری مجتمع انبارها
        /// </summary>
        /// <returns></returns>
        public static JNode _SCServices()
        {
            JNode Node = new JNode(0, "StoreComplex.JSCServices");
            Node.Name = "JSCServices";
            //Node.Icone = 4;
            Node.Hint = "JSCServices";

            JAction Ac = new JAction("JSCServices", "StoreComplex.JServiceTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        /// <summary>
        ///واحدها مجتمع انبارها
        /// </summary>
        /// <returns></returns>
        public static JNode _SCStorages()
        {
            JNode Node = new JNode(0, "StoreComplex.JSCStorages");
            Node.Name = "Storages";
            //Node.Icone = 4;
            Node.Hint = "Storages";

            JAction Ac = new JAction("Storages", "StoreComplex.JSCStorages.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        /// <summary>
        ///قراردادهای مجتمع انبارها
        /// </summary>
        /// <returns></returns>
        public static JNode _SCContracts()
        {
            JNode Node = new JNode(0, "StoreComplex.JSCContract");
            Node.Name = "JSCContract";
            //Node.Icone = 4;
            Node.Hint = "JSCContract";

            JAction Ac = new JAction("SCContracts", "StoreComplex.JSCContracts.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
    }
}
