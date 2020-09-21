using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Employment
{
    public class JEStaticNode : JStaticNode
    {
        public static JNode _BaseDefineNode(int pCompanyCode)
        {
            if (!JPermission.CheckPermission("Employment.JEStaticNode._BaseDefineNode", false))
                return null;
            JNode Node = new JNode(0, "Employment.JEBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = JImageIndex.BaseDefine;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefines", "Employment.JEBaseDefine.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

			JAction CAc = new JAction("BaseDefines", "Employment.JEBaseDefine.TreeView", new object[] { pCompanyCode }, null);
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.BaseDefine.GetHashCode();
            return Node;
        }

        public static JNode _Report(int pCompanyCode)
        {
            JNode Node = new JNode(0, "Employment.JEContract");
            Node.Name = "Report";
            JAction Ac = new JAction("Report", "Employment.JEContract.ReportForm", new object[] { pCompanyCode }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.Help.GetHashCode();
            return Node;
        }

        public static JNode _ReportDetail(int pCompanyCode)
        {
            JNode Node = new JNode(0, "Employment.JEContract");
            Node.Name = "گزارش کارگزینی";
            JAction Ac = new JAction("گزارش کارگزینی", "Employment.JKaraneh.ReportForm", new object[] { pCompanyCode }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.Help.GetHashCode();
            return Node;
        }

        public static JNode _Formula(int pCompanyCode)
        {
            JNode Node = new JNode(0, "Employment.JEContract");
            Node.Name = "فرمول ها";
            JAction Ac = new JAction("فرمول ها", "Employment.JFormula.FormulaForm", new object[] { pCompanyCode }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.Help.GetHashCode();
            return Node;
        }

        public static JNode _Working(int pEmployeeCode)
        {
            JNode Node = new JNode(0, "Employment.JEContract");
            Node.Name = "گزارش کارکرد";
            JAction Ac = new JAction("گزارش کارکرد", "Employment.JWorking.WorkingForm", new object[] { pEmployeeCode }, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.Help.GetHashCode();
            return Node;
        }

        public static JNode _Help()
        {
            JNode Node = new JNode(0, "Employment.JVacationHour");
            Node.Name = "Help";
            JAction Ac = new JAction("Help", "Employment.JVacationHour.HelpForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.Help.GetHashCode();
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
            Node.Name = "Posts";
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
            JNode Node = new JNode(0, "Employment.JShiftType");
            Node.Name = "WorkShifts";
            JAction Ac = new JAction("WorkShifts", "Employment.JShiftTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            return Node;
        }
        public static JNode _Activity()
        {
            JNode Node = new JNode(0, "Employment.JActivityType");
            Node.Name = "Activity";
            JAction Ac = new JAction("Activity", "Employment.JActivityTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }

        public static JNode _HouseStateType()
        {
            JNode Node = new JNode(0, "Employment.JHouseStateType");
            Node.Name = "HouseStateType";
            JAction Ac = new JAction("Activity", "Employment.JHouseStateTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }
        public static JNode _FieldType()
        {
            JNode Node = new JNode(0, "Employment.JFieldType");
            Node.Name = "FieldType";
            JAction Ac = new JAction("Activity", "Employment.JFieldTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }
        public static JNode _DegreeType()
        {
            JNode Node = new JNode(0, "Employment.JDegreeType");
            Node.Name = "DegreeType";
            JAction Ac = new JAction("Activity", "Employment.JDegreeTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }

        public static JNode _MilitaryType()
        {
            JNode Node = new JNode(0, "Employment.JMilitaryType");
            Node.Name = "MilitaryType";
            JAction Ac = new JAction("Activity", "Employment.JmilitaryTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }

        public static JNode _WorkTimeType()
        {
            JNode Node = new JNode(0, "Employment.JMilitaryType");
            Node.Name = "WorkTimeType";
            JAction Ac = new JAction("Activity", "Employment.JmilitaryTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }

        public static JNode _PersonelContractType()
        {
            JNode Node = new JNode(0, "Employment.JPersonelContractType");
            Node.Name = "PersonelContractType";
            JAction Ac = new JAction("Activity", "Employment.JPersonelContractTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _WorkPlaceType()
        {
            JNode Node = new JNode(0, "Employment.JWorkPlaceType");
            Node.Name = "WorkPlaceType";
            JAction Ac = new JAction("WorkPlaceType", "Employment.JWorkPlaceTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _CalcType()
        {
            JNode Node = new JNode(0, "Employment.JCalcType");
            Node.Name = "CalcType";
            JAction Ac = new JAction("CalcType", "Employment.JCalcTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _SeparationType()
        {
            JNode Node = new JNode(0, "Employment.JSeparationType");
            Node.Name = "SeparationType";
            JAction Ac = new JAction("SeparationType", "Employment.JSeparationTypes.ListView", null, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _KaranehRange()
        {
            JNode Node = new JNode(0, "Employment.JKaranehRange");
            Node.Name = "KaranehRange";
            JAction Ac = new JAction("KaranehRange", "Employment.JKaranehRanges.ListView", null, null, true);
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

        public static JNode _Contracts(int pCompanyCode)
        {
            //if (!JPermission.CheckPermission("Employment.JEStaticNode._Contracts", false))
            //    return null;
            JNode Node = new JNode(0, "Employment.JEContract");
            Node.Name = "CoContract";
            Node.Hint = "CoContract";
            JAction DBClick = new JAction("RegisterContract", "Employment.JEContracts.ListView", new object[] {pCompanyCode }, null, true);
            Node.MouseClickAction = DBClick;
            Node.MouseDBClickAction = DBClick;
            Node.Icone = JImageIndex.ContractEmployee.GetHashCode();
            return Node;
        }

        public static JNode[] _ShareComanies()
        {
            JNode[] Nodes = new JNode[0];
            DataTable companies = new DataTable();
            companies = JCompanyEmployee.GetDataTable();
            foreach (DataRow row in companies.Rows)
            {
                Array.Resize(ref Nodes, Nodes.Length + 1);
                JNode node = new JNode(Convert.ToInt32(row["Code"]), "ShareCompany" + Nodes.Length);
                node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareSheets.ListView", new object[] { row["Code"] }, null);
                //node.MouseDBClickAction = new JAction("ShareCompany", "ManagementShares.FormWebUserChange.ShowDialog");
                node.Name = row["Name"].ToString();// (new JOrganization(Convert.ToInt32(row["Code"]))).Name;
                Nodes[Nodes.Length - 1] = node;
                node.Childs = _CompanyOperationNodes(Convert.ToInt32(row["Code"]));
            }             
            return Nodes;
        }

        public static JNode[] _CompanyOperationNodes(int pCompanyCode)
        {
            JNode[] N = new JNode[11];
            if (CheckPermissionMenu())
            {
				N[0] = JEStaticNode._BaseDefineNode(pCompanyCode);
                //N[1] = JEStaticNode._PersonOrganizationPost();
                N[1] = JEStaticNode._Contracts(pCompanyCode);                
                N[4] = JEStaticNode._JobTitleInfo(pCompanyCode);
                N[5] = JEStaticNode._PostTitleInfo(pCompanyCode);
                N[6] = JEStaticNode._VacationPermissions();
                N[7] = JEStaticNode._Report(pCompanyCode);
                N[9] = JEStaticNode._ReportDetail(pCompanyCode);
                N[10] = JEStaticNode._Formula(pCompanyCode);
                JEContract tmp = new JEContract();
                tmp.ReportFormOne(pCompanyCode);
            }
            N[3] = JEStaticNode._EmployeeInfo(pCompanyCode);
            //N[10] = JEStaticNode._ReportDetail(pCompanyCode);
            return N;
        }

        public static bool CheckPermissionMenu()
        {
            if (JPermission.CheckPermission("Employment.JEStaticNode.CheckPermissionMenu", false))
                return true;
            else
                return false;
        }

        public static JNode _EmployeeInfo(int pCompanyCode)
        {
            //if (!JPermission.CheckPermission("Employment.JEStaticNode._EmployeeInfo", false))
            //    return null;
            JNode Node = new JNode(0, "Employment.JEmployeeInfo");
            Node.Name = "EmployeeInfo";
            JAction Ac = new JAction("EmployeeInfo", "Employment.JEmployeeInfos.ListView", new object[] { pCompanyCode }, null, true);
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.EmployeeInfo.GetHashCode();
            return Node;
        }


        public static JNode _JobTitleInfo(int pCompanyCode)
        {
            //if (!JPermission.CheckPermission("Employment.JEStaticNode._EmployeeInfo", false))
            //    return null;
            JNode Node = new JNode(0, "Employment.JJobTitle");
            Node.Name = "JobTitle";
            JAction Ac = new JAction("JobTitle", "Employment.JJobTitles.ListView", new object[] { pCompanyCode }, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.EmployeeInfo.GetHashCode();
            return Node;
        }

        public static JNode _PostTitleInfo(int pCompanyCode)
        {
            //if (!JPermission.CheckPermission("Employment.JEStaticNode._EmployeeInfo", false))
            //    return null;
            JNode Node = new JNode(0, "Employment.JPostTitle");
            Node.Name = "PostTitle";
            JAction Ac = new JAction("PostTitle", "Employment.JPostTitles.ListView", new object[] { pCompanyCode }, null, true);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.EmployeeInfo.GetHashCode();
            return Node;
        }


        public static JNode _VacationPermissions()
        {
            if (!JPermission.CheckPermission("Employment.JEStaticNode._VacationPermissions", false))
                return null;
            JNode Node = new JNode(0, "Employment.VacationPermissions");
            Node.Name = "VacationPermissions";
            JAction Ac = new JAction("VacationPermissions", "ClassLibrary.JPermissionsDefineClass.ListView");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.VacationPermissions.GetHashCode();
            return Node;

            //JNode Node = new JNode(0, "ClassLibrary.JPermissionsDefineClass");
            //Node.Name = "VacationPermissions";
            //JAction Ac = new JAction("VacationPermissions", "ClassLibrary.JPermissionsDefineClass.ListView");
            ////new object[] { ClassLibrary.JPermissionDefinesStatic.VacationDefines }
            //Node.MouseDBClickAction = Ac;
            //return Node;
        }

        public static JNode JVacations()
        {
            JNode Node = new JNode(0, "Employment.JVacations");
            Node.Name = "Vacations";
            //Node.Icone = 4;
            Node.Hint = "Vacations";

            JAction Ac = new JAction("Vacations", "Employment.JVacations.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Vacations", "Employment.JVacations.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.Vacation.GetHashCode();
            return Node;
        }

        public static JNode _VacationTime()
        {
            JNode Node = new JNode(0, "Employment.JVacationHour");
            Node.Name = "VacationTime";
            JAction Ac = new JAction("VacationTime", "Employment.JVacationHours.ListView");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.Vacation.GetHashCode();
            return Node;
        }

        public static JNode _VacationDaily()
        {
            JNode Node = new JNode(0, "Employment.JVacationDaily");
            Node.Name = "VacationDaily";
            JAction Ac = new JAction("VacationDaily", "Employment.JVacationDailys.ListView");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.Vacation.GetHashCode();
            return Node;
        }

        public static JNode _ConfirmWork()
        {
            JNode Node = new JNode(0, "Employment.JConfirmWork");
            Node.Name = "ConfirmWork";
            JAction Ac = new JAction("ConfirmWork", "Employment.JConfirmWorks.ListView");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.Vacation.GetHashCode();
            return Node;
        }

        /// <summary>
        ///جستجو 
        /// </summary>
        /// <returns></returns>
        public static JNode _SearchVacationNode()
        {
            JNode Node = new JNode(0, "Employment.JVacationHour");
            Node.Name = "SearchVacation";
            //Node.Icone = 4;
            Node.Hint = "SearchVacation";

            JAction Ac = new JAction("SearchVacation", "Employment.JVacationHour.ShowSearchForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.Search.GetHashCode();
            return Node;
        }

        public static JNode _Chart()
        {
            //تعریف نود چارت سازمانی
            JNode nodeAssertion = new JNode(0, "Employment.JorgChart");
            nodeAssertion.Name = "DefineChart";
            nodeAssertion.MouseClickAction = new JAction("DefineChart", "Employment.JorgCharts.ListView", null, null, true);
            nodeAssertion.MouseDBClickAction = nodeAssertion.MouseClickAction;
            nodeAssertion.Icone = JImageIndex.OrganizationChart.GetHashCode();
            return nodeAssertion;
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

            //JAction Ac = new JAction("chart", "Employment.JEOrganizationChart.ShowDialog", null, null, false);
			JAction Ac = new JAction("chart", "Employment.JEOrganizationChart.ShowDialog", null, null, false);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }

        public static JNode _PersonPosts()
        {
            JNode Node = new JNode(0, "Employment.JEPersonPosts");
            Node.Name = "PersonPosts";
            Node.Hint = "PersonPosts";

            JAction Ac = new JAction("chart", "Employment.JEPersonPosts.ListView", null, null, false);
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;

            return Node;
        }
    }
}
