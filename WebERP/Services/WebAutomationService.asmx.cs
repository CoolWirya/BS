using ClassLibrary;
using Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebERP.Services
{
	/// <summary>
	/// Summary description for WebAutomationService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class WebAutomationService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
	{

		#region Secretariat
		[WebMethod(EnableSession = true)]
		public string SaveSecretariat(string code, string managerPostCode, string name, string prefix, string postfix)
		{
			if (string.IsNullOrWhiteSpace(name))
				return "خطا در پارامترهای ارسالی...!";
			int _code = 0;
			int.TryParse(code, out _code);
			int _managerPostCode = 0;
			int.TryParse(managerPostCode, out _managerPostCode);
			JCSecretariat tmpJSecretariat = new JCSecretariat();
			tmpJSecretariat.Code = _code;
			tmpJSecretariat.Name = name;
			tmpJSecretariat.Manager_user_post_code = _managerPostCode;
			//tmpJSecretariat.Strg_Code = int.Parse(cmbStorageLetterNo.SelectedValue.ToString());
			tmpJSecretariat.Prifix = prefix;
			tmpJSecretariat.Suffix = postfix;
			if (_code == 0)
				if (tmpJSecretariat.Insert(null))
					return "ثبت با موفقیت انجام شد";
				else
					return "خطا در ثبت اطلاعات...!";
			else
				if (tmpJSecretariat.Update(null))
					return "ویرایش با موفقیت انجام شد";
				else
					return "خطا در ویرایش اطلاعات...!";
		}
		#endregion

		#region NoStorage
		[WebMethod(EnableSession = true)]
		public string GetData(string className, string objectCode)
		{
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			if (_objectCode < 0)
				return "خطا در پارامترهای ارسالی...!";
			int year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(className, _objectCode, year);
			JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
			DataSet ds = new DataSet();
			ds.Tables.Add(NSR.GetData());
			return ds.GetXml();
		}

		[WebMethod(EnableSession = true)]
		public string GetLastNumberText(string className, string objectCode)
		{
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			if (_objectCode < 0)
				return "خطا در پارامترهای ارسالی...!";
			int year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(className, _objectCode, year);
			return "آخرین شماره (" + NS.GetNextNumberWithoutUpdate().ToString() + ")";
		}

		[WebMethod(EnableSession = true)]
		public string GetReservedNumbersText(string className, string objectCode, string reserveNumber)
		{
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			if (_objectCode < 0)
				return "خطا در پارامترهای ارسالی...!";
			int _reserveNumber = 0;
			int.TryParse(reserveNumber, out _reserveNumber);
			int year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(className, _objectCode, year);
			return "از شماره(" + NS.GetNextNumberWithoutUpdate().ToString() + ")رزرو تا شماره(" + (_reserveNumber <= 0 ? null : reserveNumber) + "):";
		}

		[WebMethod(EnableSession = true)]
		public string GetNumber(string className, string objectCode)
		{
			if (string.IsNullOrWhiteSpace(className))
				return "";
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			if (_objectCode < 0)
				return "خطا در پارامترهای ارسالی...!";
			int year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(className, _objectCode, year);
			int number = NS.GetNextNumber();
			JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
			NSR.Delete(number);
			return number.ToString();
		}

		[WebMethod(EnableSession = true)]
		public void DeleteReservedNumber(string className, string objectCode, string number)
		{
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			if (_objectCode < 0)
				return;
			int year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(className, _objectCode, year);
			int _number = 0;
			int.TryParse(number, out _number);
			if (_number <= 0)
				return;
			JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
			NSR.Delete(_number);
		}

		[WebMethod(EnableSession = true)]
		public void Reserve(string className, string objectCode, string reserveNumber)
		{
			int _objectCode = 0;
			int.TryParse(objectCode, out _objectCode);
			if (_objectCode < 0)
				return;
			int _reserveNumber = 0;
			int.TryParse(reserveNumber, out _reserveNumber);
			if (_reserveNumber <= 0)
				return;
			int year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			NoStorage NS = new NoStorage(className, _objectCode, year);
			if (NS.GetNextNumberWithoutUpdate() > _reserveNumber)
				return;
			JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
			NSR.ReserveTo(_reserveNumber);
		}
		#endregion

        #region CopyReceiversList
        [WebMethod(EnableSession = true)]
        public CopyReceiversList GetCopyReceiversList(int PostCode)
        {
            CopyReceiversList ret_data = new CopyReceiversList();
            Employment.JEOrganizationChart jeOrgChart = new Employment.JEOrganizationChart();
            DataTable dt;

            dt = jeOrgChart.GetChart(PostCode, 1);

            (dt as ClassLibrary.JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
                DataSet ds = new DataSet();
            if (dt != null && dt.Rows.Count > 0) 
            {
                ds.Tables.Add(dt);
                ret_data.CopyReceivers = ds.GetXml();
            }
            jeOrgChart = new Employment.JEOrganizationChart(PostCode);
            if (jeOrgChart.is_unit)
                ret_data.SignStatus = 1;
            else
                ret_data.SignStatus = 2;
            if (ClassLibrary.JMainFrame.CurrentPostCode == PostCode)
            {
                ret_data.CanSign = true;
            }
            else
                ret_data.CanSign = false;
            return ret_data;
        }
        #endregion

        #region Work Flow

        //#region LoadFlowChart
        //[WebMethod(EnableSession = true)]
        //public string LoadFlowChart()
        //{
        //        //using (System.Web.UI.Page page = new System.Web.UI.Page())
        //        //{
        //            //WebAutomation.WebCommunication.JFlowChart userControl = (WebAutomation.WebCommunication.JFlowChart)page.LoadControl("~/WebAutomation/WebCommunication/JFlowChart.ascx");
        //            using (System.IO.StringWriter writer = new System.IO.StringWriter())
        //            {
        //                //page.Controls.Add(userControl);
        //                WebAutomation.tessst page = new WebAutomation.tessst();
        //                HttpContext.Current.Server.Execute(page, writer, false);
        //                return writer.ToString();
        //            }
        //        //}
        //}
        //#endregion

        #region Loading Work Flow
        [WebMethod(EnableSession = true)]
        public FlowChartLoadOutput LoadFlowChart(int ClassRank)
        {
            FlowChartLoadOutput return_data = new FlowChartLoadOutput();
            string ClassName = "";
            int DynamicClassCode = -1;
            ////  ------------ Get ClassName and DynamicClassCode ---------------
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"with tbl as (
                        SELECT rank() over (order by ClassName asc, DynamicClassCode asc) Code, ClassName, 
                        DynamicClassCode FROM Objects group by ClassName, DynamicClassCode
                    )
                    select ClassName, DynamicClassCode from tbl where Code = " + ClassRank);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassName = DB.DataReader["ClassName"].ToString();
                    DynamicClassCode = Convert.ToInt32(DB.DataReader["DynamicClassCode"].ToString());
                    return_data.ClassName = ClassName;
                    return_data.DynamicClassCode = DynamicClassCode;
                }
            }
            catch (Exception ex)
            {
                 JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }

            ////  ---------------------- Get Form Name --------------------------
            if (DynamicClassCode == 0) 
            {
                if (ClassName == "Communication.JCExportedLetter")
                    return_data.FormName = "نامه صادره";
                if (ClassName == "Communication.JCImportedLetter")
                    return_data.FormName = "نامه وارده";
                if (ClassName == "Communication.JCLetter")
                    return_data.FormName = "نامه داخلی";
            }
            else
            {
                JForms form = new JForms(DynamicClassCode);
                return_data.FormName = form.FormName;
            }
            ////  ---------------------- Get All Types --------------------------
            DataTable dt = EnumToDataTable(typeof(Automation.JNodeType));
            DataSet ds = new DataSet();
            if (dt != null && dt.Rows.Count > 0)
            {
                ds.Tables.Add(dt);
                return_data.Types = ds.GetXml();
            }
            ////  ---------------------- Get All Posts --------------------------
            Automation.JWorkFlow WorkFlow = new Automation.JWorkFlow();
            dt = Employment.JEOrganizationChart.GetAllData();
            ds = new DataSet();
            if (dt != null && dt.Rows.Count > 0)
            {
                ds.Tables.Add(dt);
                return_data.Posts = ds.GetXml();
            }
            ////  ------------------- Get All Conditions ------------------------
            JAction action = new JAction("", ClassName + "." + "GetFlowChartData", new object[] { DynamicClassCode }, null);
            dt = (DataTable)action.run();
            if (dt != null && dt.Columns.Count > 0)
            {
                return_data.Conditions = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray(); 
            }
            ////  ---------------------- Get All Nodes --------------------------
            Automation.JWorkFlow[] WF = Automation.JWorkFlow.GetAllNodes(return_data.ClassName, return_data.DynamicClassCode);
            List<Node> Nodes = new List<Node>();
            if (WF != null && WF.Length > 0)
            {
                for(int i = 0; i < WF.Length; i++)
                {
                    Node Node = new Node();
                    Node.Name = WF[i].Name;
                    Node.Ordered = WF[i].Ordered;
                    Node.NextNodes = WF[i].NextNodes;
                    Node.Left = WF[i].PositionX;
                    Node.Top = WF[i].PositionY;
                    Nodes.Add(Node);
                }
                return_data.Nodes = Nodes.ToArray();
            }
            return return_data;
        }
        public DataTable EnumToDataTable(Type enumType)
        {
            DataTable table = new DataTable("datatable");
            table.Columns.Add("code", Enum.GetUnderlyingType(enumType));
            table.Columns.Add("Full_Title", typeof(string));
            foreach (string name in Enum.GetNames(enumType))
            {
                string PersianName = ClassLibrary.JLanguages._Text(name);
                if (PersianName != null && PersianName.Trim() != String.Empty)
                    table.Rows.Add(Enum.Parse(enumType, name), PersianName.Replace('_', ' '));
                else
                    table.Rows.Add(Enum.Parse(enumType, name), name.Replace('_', ' '));

            }

            return table;
        }
        #endregion

        #region Saving Work Flow
        [WebMethod(EnableSession = true)]
        public SaveFlowChartOutput SaveFlowChart(string ClassName, int DynamicClassCode, NodeDetail[] Nodes)
        {
            SaveFlowChartOutput return_data = new SaveFlowChartOutput();
            int StartNo = 0;
            int StartNodeIndex = -1;
            int ZeroOrderedNodeIndex = -1;
            List<Automation.JWorkFlow> WorkFlowList = new List<Automation.JWorkFlow>();
            for (int i = 0; i < Nodes.Length; i++)
            {
                Automation.JWorkFlow WorkFlow = new Automation.JWorkFlow();
                WorkFlow.GetData(0, ClassName, DynamicClassCode, Nodes[i].Ordered);
                WorkFlowList.Add(WorkFlow);
            }
            Automation.JWorkFlow[] WorkFlows = WorkFlowList.ToArray();
            for (int i = 0; i < Nodes.Length; i++)
            {
                WorkFlows[i].NextNodes = Nodes[i].NextNodes;
                WorkFlows[i].PositionX = Nodes[i].Left;
                WorkFlows[i].PositionY = Nodes[i].Top;
            }
            for (int i = 0; i < Nodes.Length; i++)
            { 
                if (WorkFlows[i].NodeType == Automation.JNodeType.Start)
                { 
                    StartNo++;
                    StartNodeIndex = i;
                }
                if (WorkFlows[i].Ordered == 0)
                    ZeroOrderedNodeIndex = i;
            }
            if (StartNo == 0) 
            {
                return_data.HasError = true;
                return_data.ErrorCode = 1;
                return return_data;
            }
            if (StartNo > 1)
            {
                return_data.HasError = true;
                return_data.ErrorCode = 2;
                return return_data;
            }
            if (StartNodeIndex != ZeroOrderedNodeIndex)
            {
                for (int i = 0; i < Nodes.Length; i++)
                {
                    if (WorkFlows[i].Ordered == 0)
                        WorkFlows[i].Ordered = Nodes[StartNodeIndex].Ordered;
                    else if (WorkFlows[i].NodeType == Automation.JNodeType.Start)
                        WorkFlows[i].Ordered = 0;
                    string[] targets = Nodes[i].NextNodes.Split(',');
                    string _targets = "";
                    for (int j = 0; j < targets.Length; j++)
                    {
                        if (targets[j] == "0")
                            targets[j] = Nodes[StartNodeIndex].Ordered.ToString();
                        else if (targets[j] == Nodes[StartNodeIndex].Ordered.ToString())
                            targets[j] = "0";
                        if (_targets == String.Empty)
                            _targets = targets[j].ToString();
                        else
                            _targets += "," + targets[j].ToString();
                    }
                    WorkFlows[i].NextNodes = _targets;
                }
            }

            for (int i = 0; i < Nodes.Length; i++)
            {
                if (!WorkFlows[i].Update())
                {
                    return_data.HasError = true;
                    return_data.ErrorCode = 3;
                    return return_data;
                }
            }
            return return_data;
        }
        #endregion

        #region Insert New Node in Work Flow
        [WebMethod(EnableSession = true)]
        public bool InsertWorkFlowNode(int Ordered, string ClassName, int DynamicClassCode)
        {
            Automation.JWorkFlow WorkFlow = new Automation.JWorkFlow();
            WorkFlow.Name = "جدید";
            WorkFlow.ClassName = ClassName;
            WorkFlow.DynamicClassCode = DynamicClassCode;
            WorkFlow.Ordered = Ordered;
            WorkFlow.NodeType = Automation.JNodeType.Start;      
            return WorkFlow.Insert() > 0?true:false;
        }
        #endregion

        #region Delete a Node in Work Flow
        [WebMethod(EnableSession = true)]
        public bool DeleteWorkFlowNode(int Ordered, string ClassName, int DynamicClassCode)
        {
            Automation.JWorkFlow WorkFlow = new Automation.JWorkFlow();
            WorkFlow.GetData(0, ClassName, DynamicClassCode, Ordered);
            return WorkFlow.Delete();
        }
        #endregion

        #region Load a Node in Work Flow
        [WebMethod(EnableSession = true)]
        public NodeBase LoadWorkFlowNode(int Ordered, string ClassName, int DynamicClassCode)
        {
            NodeBase ret_data = new NodeBase();
            Automation.JWorkFlow WorkFlow = new Automation.JWorkFlow();
            WorkFlow.GetData(0, ClassName, DynamicClassCode, Ordered);
            ret_data.Name = WorkFlow.Name;
            ret_data.TypeCode = (int)WorkFlow.NodeType;
            ret_data.PostCode = WorkFlow.PostCode;
            ret_data.Condition = WorkFlow.Condition;
            return ret_data;

        }
        #endregion

        #region Update a Node in Work Flow
        [WebMethod(EnableSession = true)]
        public bool UpdateWorkFlowNode(string Name, int TypeCode, int Ordered, string PostCode, string Condition, string ClassName, int DynamicClassCode)
        {
            Automation.JWorkFlow WorkFlow = new Automation.JWorkFlow();
            WorkFlow.GetData(0, ClassName, DynamicClassCode, Ordered);
            WorkFlow.Name = Name;
            WorkFlow.NodeType = (Automation.JNodeType)TypeCode;
            WorkFlow.PostCode = PostCode;
            WorkFlow.Condition = Condition;
            if (WorkFlow.Update())
                return true;
            else
                return false;
        }
        #endregion

        //#region Get AllClasses
        //[WebMethod(EnableSession = true)]
        //public string GetClasses()
        //{
        //    JDataBase DB = new JDataBase();
        //    try
        //    {
        //        string query = "SELECT ClassName, DynamicClassCode FROM Objects group by ClassName, DynamicClassCode";
        //        DB.setQuery(query);
        //        DataTable dt = DB.Query_DataTable();
        //        DataSet ds = new DataSet();
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            ds.Tables.Add(dt);
        //            return ds.GetXml();
        //        }
        //        else
        //            return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //        return "";
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}
        //#endregion

        #endregion
	}

    public class CopyReceiversList 
    {
        public int SignStatus = 0;
        public bool CanSign = false;
        public string CopyReceivers = null;
    }

    public class FlowChartLoadOutput 
    {
        public string FormName = "";
        public string ClassName = "";
        public int DynamicClassCode = -1;
        public string Types = "";
        public string Posts = "";
        public string[] Conditions;
        public Node[] Nodes;
        //public int NodeMax;
    }

    public class NodeBase
    {
        public string Name;
        public int TypeCode;
        public string PostCode;
        public string Condition;
    }

    public class NodeDetail
    {
        public int Ordered;
        public string NextNodes;
        public int Left;
        public int Top;
    }

    public class Node
    {
        public string Name;
        public int Ordered;
        public string NextNodes;
        public int Left;
        public int Top;
    }

    public class SaveFlowChartOutput 
    {
        public bool HasError = false;
        public int ErrorCode = 0;
    }
}
