using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    public class JStoreStaticNode
    {
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "StoreManagement.JGoodsBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "StoreManagement.JGoodsBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "StoreManagement.JGoodsBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }

        public static JNode _RegisterGoods()
        {
            JNode Node = new JNode(0, "StoreManagement.JGoodss");
            Node.Name = " کالا ";
            JAction Ac = new JAction(" کالا ", "StoreManagement.JGoodss.ListView", new object[] { }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _RegisterServices()
        {
            JNode Node = new JNode(0, "StoreManagement.JServicess");
            Node.Name = " خدمات";
            JAction Ac = new JAction("  خدمات", "StoreManagement.JServicess.ListView", new object[] { }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _PayContract()
        {
            JNode Node = new JNode(0, "StoreManagement.JPaymentContracts");
            Node.Name = " ثبت صورتحساب قراردادها";
            JAction Ac = new JAction("  پیش پرداخت قراردادها", "StoreManagement.JPaymentContracts.ListView", new object[] { }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _RequestGood()
        {
            JNode Node = new JNode(0, "StoreManagement.JBillGoodss");
            Node.Name = "ثبت صورتحساب فروش کالا و خدمات";
            JAction Ac = new JAction("ثبت صورتحساب فروش کالا و خدمات", "StoreManagement.JBillGoodss.ListView", new object[] { }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _ReportBillGoods()
        {
            JNode Node = new JNode(0, "StoreManagement.JStoreStaticNode");
            Node.Name = "ReportBillGoods";
            //Node.Icone = 4;
            Node.Hint = "ReportBillGoods";

            JAction Ac = new JAction("ReportBillGoods", "StoreManagement.JStoreStaticNode.ShowForm", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _ReportBillContract()
        {
            JNode Node = new JNode(0, "StoreManagement.JStoreStaticNode");
            Node.Name = "ReportBillContract";
            //Node.Icone = 4;
            Node.Hint = "ReportBillContract";

            JAction Ac = new JAction("ReportBillContract", "StoreManagement.JStoreStaticNode.ShowContractForm", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public void ShowForm()
        {
            if (!(JPermission.CheckPermission("StoreManagement.JStoreStaticNode.ShowForm")))
                return;
            JReportForm tmp = new JReportForm();
            tmp.ShowDialog();
        }

        public void ShowContractForm()
        {
            //if (!(JPermission.CheckPermission("StoreManagement.JStoreStaticNode.ShowForm")))
            //    return;
            JReportContractForm tmp = new JReportContractForm();
            tmp.ShowDialog();
        }
        /// <summary>
        /// انواع گروه
        /// </summary>
        /// <returns></returns>
        public static JNode _GoodsGroupNode()
        {
            JNode Node = new JNode(0, "StoreManagement.JGoodsGroups");
            Node.Name = "GoodsGroup";
            //Node.Icone = 4;
            Node.Hint = "GoodsGroup";

            JAction Ac = new JAction("GoodsGroup", "StoreManagement.JGoodsGroups.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        /// <summary>
        /// انواع نوع کالا
        /// </summary>
        /// <returns></returns>
        public static JNode _GoodsTypeNode()
        {
            JNode Node = new JNode(0, "StoreManagement.JGoodsTypes");
            Node.Name = "GoodsType";
            //Node.Icone = 4;
            Node.Hint = "GoodsType";

            JAction Ac = new JAction("GoodsType", "StoreManagement.JGoodsTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        /// <summary>
        /// انواع واحد اندازه گیری
        /// </summary>
        /// <returns></returns>
        public static JNode _MeasureNode()
        {
            JNode Node = new JNode(0, "StoreManagement.JMeasureTypes");
            Node.Name = "Measure";
            //Node.Icone = 4;
            Node.Hint = "Measure";

            JAction Ac = new JAction("Measure", "StoreManagement.JMeasureTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        /// <summary>
        /// انواع انبار
        /// </summary>
        /// <returns></returns>
        public static JNode _StorageTypeNode()
        {
            JNode Node = new JNode(0, "StoreManagement.JStorageTypes");
            Node.Name = "Storage";
            //Node.Icone = 4;
            Node.Hint = "Storage";

            JAction Ac = new JAction("Storage", "StoreManagement.JStorageTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
    }
}
