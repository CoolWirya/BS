using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JEsStaticNode: JStaticNode
    {
        #region BaseDefine Tree
        /// <summary>
        /// تعاریف اولیه
        /// </summary>
        /// <returns></returns>
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "Estates.JEsBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "Estates.JEsBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "Estates.JEsBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
        /// <summary>
        /// کاربری های زمین
        /// </summary>
        /// <returns></returns>
        public static JNode _GroundUsageNode()
        {
            JNode Node = new JNode(0, "Estates.JUsageGround");
            Node.Name = "UsageGround";
            //Node.Icone = 4;
            Node.Hint = "UsageGround";

            JAction Ac = new JAction("UsageGround", "Estates.JUsageGrounds.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _LandsNode()
        {
            JNode Node = new JNode(0, "Estates.JLand");
            Node.Name = "Lands";
            //Node.Icone = 4;
            Node.Hint = "Lands";

            JAction Ac = new JAction("Lands", "Estates.JLands.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        #endregion BaseDefine Tree

        /// <summary>
        /// زمینها
        /// </summary>
        /// <returns></returns>
        public static JNode _GroundsNode()
        {
            JNode Node = new JNode(0, "Estates.JGrounds");
            Node.Name = "Grounds";
            //Node.Icone = 4;
            Node.Hint = "Grounds";

            JAction Ac = new JAction("BaseDefine", "Estates.JGrounds.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        /// <summary>
        /// تعرفه
        /// </summary>
        /// <returns></returns>
        public static JNode _TarefeNode()
        {
            JNode Node = new JNode(0, "Estates.JGroundSheets");
            Node.Name = "Tarefe";
            //Node.Icone = 4;
            Node.Hint = "Tarefe";

            JAction Ac = new JAction("Tarefe", "Estates.JGroundSheets.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        /// <summary>
        /// درخواست انتقال تعرفه
        /// </summary>
        /// <returns></returns>
        public static JNode _RequestTransferSheet()
        {
            JNode Node = new JNode(0, "Estates.JRequestTransferSheet");
            Node.Name = "RequestTransferSheet";
            //Node.Icone = 4;
            Node.Hint = "RequestTransferSheet";

            JAction Ac = new JAction("RequestTransferSheet", "Estates.JRequestTransferSheets.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _Aggregation()
        {
            JNode Node = new JNode(0, "Estates.JAggregateGround");
            Node.Name = "AggregationGround";
            //Node.Icone = 4;
            Node.Hint = "Aggregation";

            JAction Ac = new JAction("BaseDefine", "Estates.JAggregateGroundAll.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;

        }
        public static JNode _AggregationSeparation()
        {
            JNode Node = new JNode(0,"Estates.JAggregationSeparation");
            Node.Name = "AggregationSeparation";
            //Node.Icone = 4;
            Node.Hint = "Aggregation";

            JAction Ac = new JAction("Aggregation","Estates.JAggregationSeparation.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Aggregation","Estates.JAggregationSeparation.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }

        public static JNode _BreakDown()
        {
            JNode Node = new JNode(0, "Estates.JGroundBreakDown");
            Node.Name = "GroundBreakDown";
            //Node.Icone = 4;
            Node.Hint = "BreakDown";

            JAction Ac = new JAction("BreakDown","Estates.JGroundBreakDownAll.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;

        }

        public static JNode _Partition()
        {
            JNode Node = new JNode(0, "Estates.JGroundPartition");
            Node.Name = "GroundPartition";
            JAction ListView = new JAction("ShowListView", "Estates.JGroundPartitionAll.ListView");
            Node.MouseClickAction = ListView;
            Node.MouseDBClickAction = ListView;
            return Node;
        }

        public static JNode _EstateType()
        {
            JNode Node = new JNode(0, "Estates.JBaseDefineEstates");
            Node.Name="EstateType";
            JAction Ac = new JAction("EstateType", "Estates.JEstateTypes.ListView");
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        public static JNode _DocumentType()
        {
            JNode Node=new JNode(0,"Estates.JDocumentType");
            Node.Name = "DocumentType";
            JAction Ac=new JAction("DocumentType","Estates.JDocumentTypes.ListView");
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

    }

}
