using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JREsStaticNode: JStaticNode
    {
        #region BaseDefine Tree
        /// <summary>
        /// تعاریف اولیه
        /// </summary>
        /// <returns></returns>
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "RealEstate.JREsBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "RealEstate.JREsBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "RealEstate.JREsBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
        /// <summary>
        /// کاربری های مجتمع
        /// </summary>
        /// <returns></returns>
        public static JNode _MarketUsageNode()
        {
            JNode Node = new JNode(0, "RealEstate.JMarketUsages");
            Node.Name = "MarketsUsage";
            //Node.Icone = 4;
            Node.Hint = "MarketsUsage";

            JAction Ac = new JAction("MarketsUsage", "RealEstate.JDefineMarketUsages.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
            
        }
        /// <summary>
        /// انواع شغلها
        /// </summary>
        /// <returns></returns>
        public static JNode _UnitJobsNode()
        {
            JNode Node = new JNode(0, "RealEstate.JUnitJobs");
            Node.Name = "UnitJobs";
            //Node.Icone = 4;
            Node.Hint = "UnitJobs";

            JAction Ac = new JAction("UnitJobs", "RealEstate.JUnitJobs.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        /// <summary>
        /// انواع مستغلات
        /// </summary>
        /// <returns></returns>
        public static JNode _UnitBuildTypeNode()
        {
            JNode Node = new JNode(0, "RealEstate.JUnitTypes");
            Node.Name = "UnitBuildType";
            //Node.Icone = 4;
            Node.Hint = "UnitBuildType";

            JAction Ac = new JAction("Lands", "RealEstate.JUnitTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        /// <summary>
        /// انواع مشاعات 
        /// </summary>
        /// <returns></returns>
        public static JNode _JointTypes()
        {
            JNode Node = new JNode(0, "RealEstate.JJoints");
            Node.Name = "JointsTypes";
            //Node.Icone = 4;
            Node.Hint = "JointsTypes";
           JAction Ac = new JAction("JJoints", "RealEstate.JJoints.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        public static JNode _JointStatus()
        {

            JNode Node = new JNode(0, "RealEstate.JEnviromentStatus");
            Node.Name = "JointSataus";
            //Node.Icone = 4;
            Node.Hint = "JointSataus";
          
            JAction Ac = new JAction("JJoints", "RealEstate.JEnviromentStatuss.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        public static JNode _JDoorBuilding()
        {
            
            JNode Node = new JNode(0, "RealEstate.JDoorBuilding");
            Node.Name = "JDoorBuilding";
            //Node.Icone = 4;
            Node.Hint = "JDoorBuilding";

            JAction Ac = new JAction("JJoints", "RealEstate.JDoorBuildings.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        #endregion BaseDefine Tree


        public static JNode _MarketNode()
        {
            JNode Node = new JNode(0, "RealEstate.jMarket");
            Node.Name = "Markets";
            //Node.Icone = 4;
            Node.Hint = "Markets";
           
            JAction Ac = new JAction("Markets", "RealEstate.jMarkets.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _BuildNode()
        {
            JNode Node = new JNode(0, "RealEstate.JUnitBuild");
            Node.Name = "UnitBuild";
            //Node.Icone = 4;
            Node.Hint = "UnitBuild";

            JAction Ac = new JAction("JUnitBuild", "RealEstate.JUnitBuilds.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction UnitBuildsListView = new JAction("JMarkets", "RealEstate.JUnitBuilds.ListView", null, null);

            Node.ChildsAction = new JAction("Markets", "RealEstate.jMarkets.GetMarketsNode", new object[] { UnitBuildsListView }, null, true);
            return Node;
        }


        public static JNode _EnviromentsNode()
        {
            JNode Node = new JNode(0, "RealEstate.JEnviroments");
            Node.Name = "JEnviroments";
            Node.Hint = "JEnviroments";

            JAction Ac = new JAction("JUnitBuild", "RealEstate.JEnviroments.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            Node.ChildsAction = new JAction("Markets", "RealEstate.jMarkets.GetMarketsEnviroments", null, null, true);
            return Node;
        }

        public static JNode _RepresentativeOfTheContractNode()
        {
            JNode Node = new JNode(0, "RealEstate.EnviromentSetPrimaryowenerForm");
            Node.Name = "EnviromentSetPrimaryowenerForm";
            Node.Icone = 4;
            Node.Hint = "EnviromentSetPrimaryowenerForm";

            JAction Ac = new JAction("JEnviroment", "RealEstate.EnviromentSetPrimaryowenerForm.ShowForm", null, null, false);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _AggregateNode()
        {
            JNode Node = new JNode(0, "RealEstate.JAggregateUnitBuild");
            Node.Name = "AggregateUnitBuild";
            Node.Hint = "AggregateUnitBuild";

            JAction Ac = new JAction("AggregateUnitBuild", "RealEstate.JAggregateUnitBuildss.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _BreakDownNode()
        {
            JNode Node = new JNode(0, "RealEstate.JBreakDownUnitBuild");
            Node.Name = "BreakDownUnitBuild";
            Node.Hint = "BreakDownUnitBuild";

            JAction Ac = new JAction("BreakDownUnitBuild", "RealEstate.JBreakDownUnitBuildss.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _DefaultOwners()
        {
            JNode Node = new JNode(0, "RealEstate.JDefaultOwner");
            Node.Name = "DefaultOwners";
            //Node.Icone = 4;
            Node.Hint = "DefaultOwners";

            JAction Ac = new JAction("DefaultOwners", "RealEstate.JPrimaryOwnerBuilds.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _DefaultOwnersNode()
        {
            JNode Node = new JNode(0, "RealEstate.JDefaultOwner");
            Node.Name = "DefaultOwners";
            Node.Hint = "DefaultOwners";

            JAction Ac = new JAction("DefaultOwners", "RealEstate.JDefaultOwner.ShowDialog", null, null, false);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            return Node;
        }
        
        public static JNode _ReportUnitBuild()
        {
            JNode Node = new JNode(0, "RealEstate.JReportUnitBuild");
            Node.Name = "ReportUnitBuilds";
            //Node.Icone = 4;
            Node.Hint = "ReportUnitBuilds";

            JAction Ac = new JAction("ReportUnitBuilds", "RealEstate.JReportUnitBuild.ShowForm", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _PrintBillForm()
        {
            JNode Node = new JNode(0, "RealEstate.JPrintBillForm");
            Node.Name = "JPrintBillForm";
            //Node.Icone = 4;
            Node.Hint = "JPrintBillForm";

            JAction Ac = new JAction("JUnitBuild", "RealEstate.JChargeBuilds.ListView", null, null,false);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _PrintBillFormNode()
        {
            JNode Node = new JNode(0, "RealEstate.JPrintBillForm");
            Node.Name = "JPrintBillForm";
            //Node.Icone = 4;
            Node.Hint = "JPrintBillForm";

            JAction _Action = new JAction("JUnitBuild", "RealEstate.JPrintableGhabz.ShowForm", null, null, false);
            _Action.run();
            //Node.MouseClickAction = Ac;
            //Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _JointsNode()
        {
            JNode Node = new JNode(0, "RealEstate.JJoints");
            Node.Name = "JJoints";
            //Node.Icone = 4;
            Node.Hint = "JJoints";

            JAction Ac = new JAction("JUnitBuild", "RealEstate.JJoints.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }


        public static JNode _JointSpacesNode()
        {
            JNode Node = new JNode(0, "RealEstate.JJointSpaces");
            Node.Name = "JJointSpaces";
            //Node.Icone = 4;
            Node.Hint = "JJointSpaces";

            JAction Ac = new JAction("JUnitBuild", "RealEstate.JJointSpaces.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }

        public static JNode _jSearchContract()
        {
            JNode Node = new JNode(0, "Security.JSearchLegal");
            Node.Name = "SearchLegal";
            //Node.Icone = 4;
            Node.Hint = "SearchLegal";
            JAction Ac = new JAction("SearchLegal", "Legal.FrmGetContract.ShowDialog", null, null, false);
            Node.MouseClickAction = Ac;



            return Node;
        }
    }

}
