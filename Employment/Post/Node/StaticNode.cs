using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JEStaticNode : JStaticNode
    {
        public static JNode _BaseDefineNode()
        {
            JNode Node = new JNode(0, "Employment.JEBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = JImageIndex.BaseDefine;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefines", "Employment.JEBaseDefine.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            JAction CAc = new JAction("BaseDefines", "Employment.JEBaseDefine.TreeView");
            Node.ChildsAction = CAc;

            return Node;
        }

        public static JNode _OrganizationChart(JTreeTypes treeType)
        {
            JNode Node = new JNode(treeType.GetHashCode(), "Employment.JEChart");
            Node.Code = treeType.GetHashCode();
            Node.Name = "JEChart";

            JAction DBClick = JEStaticAction._TreeDBClick();
            Node.MouseDBClickAction = DBClick;
            return Node;
        }

        public static JNode _OrganizationPost()
        {
            JNode Node = new JNode(0, "Employment.JEPosts");
            Node.Name = "JEPost";
            //Node.Icone = 4;

            JAction Ac = new JAction("OrganizationPosts", "Employment.JEPosts.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            //JAction DBClick = JEStaticAction._PostNew();
            //Node.MouseDBClickAction = DBClick;
            return Node;
        }

        public static JNode _WorkShifts()
        {
            JNode Node = new JNode(0, "Employment.JEWorkShifts");
            Node.Name = "WorkShifts";
            //Node.Icone = JImageIndex.Chart;

            JAction Ac = new JAction("OrganizationPosts", "Employment.JEWorkShifts.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }
        public static JNode _PersonOrganizationPost()
        {
            JNode Node = new JNode(0, "Employment.JPersonPost");
            Node.Name = "PersonOrganizationPosts";

            JAction DBClick = JEStaticAction._PersonPostDBClick();
            Node.MouseDBClickAction = DBClick;
            return Node;
        }

        public static JNode _Contracts()
        {
            JNode Node = new JNode(0, "Employment.JEContract");
            Node.Name = "CoContract";
            //Node.Icone = 4;
            Node.Hint = "CoContract";

            JAction DBClick = new JAction("RegisterContract", "Employment.JEContracts.ListView");
            Node.MouseDBClickAction = DBClick;
            Node.ChildsAction = DBClick;
            return Node;
        }

        public static JNode _RegisterContract()
        {
            JNode Node = new JNode(0, "Employment.JEContract");
            Node.Name = "RegisterContract";
            //Node.Icone = 4;
            Node.Hint = "RegisterContract";

            JAction DBClick = JEStaticAction._ContractDBClick();
            Node.MouseDBClickAction = DBClick;
            return Node;
        }

        public static JNode _Contract(JPerson pPerson, JEContract pContract)
        {
            JNode Node = new JNode(pContract.Code, "Employment.JEContract");
            Node.Name = pPerson.Fam + " " + pPerson.Name;
            Node.Popup.Insert(JEStaticAction._ContractDelete(pContract.Code));

            Node.MouseDBClickAction = JStaticAction._PersonDBClick(pPerson.Code);

            Array.Resize(ref Node.Columns, 3);
            Node.Columns[0] = pPerson.Fam;
            Node.Columns[1] = pContract.DateStart;
            Node.Columns[2] = pContract.DateEnd;
            return Node;
        }
        public static JNode _ChartsNodes()
        {
            JNode Node = new JNode(0, "Employment.JEChart");
            Node.Name = "Chart";
            //Node.Icone = 4;
            Node.Hint = "Chart";

            JAction Ac = new JAction("chart", "Employment.JECharts.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }
        public static JNode _ChartNode(JEChart pChart)
        {
            JNode Node = new JNode(pChart.Code, "Employment.JEChart");
            Node.Name = pChart.Title;

            JAction EditAction = new JAction("Edit...", "Employment.JEChart.UpdateForm", new object[] { pChart.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            Node.Popup.Insert(EditAction);

            JAction DeleteAction = new JAction("Delete", "Employment.JEChart.Delete", new object[] { pChart.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Employment.JEChart.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static JNode _OrganizationChart()
        {
            JNode Node = new JNode(0, "Employment.JEOrganizationChart");
            Node.Name = "OrganizationChart";
            //Node.Icone = 4;
            Node.Hint = "OrganizationChart";

            JAction Ac = new JAction("chart", "Employment.JEOrganizationChart.ShowDialog", null, null, false);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }
    }
}
