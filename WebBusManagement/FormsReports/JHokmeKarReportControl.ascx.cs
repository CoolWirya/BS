using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JHokmeKarReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                LoadLines();
                GetReport();
            }
        }

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }


        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }


        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DriverCode = 0, int LineCode = 0, int StateHokm = 0)
        {
            string WhereStr = "";
            if (StateHokm > 0)
                WhereStr += " and th.status = " + StateHokm.ToString();
            if (BusNumebr > 0)
                WhereStr += " and th.BusNumber = " + BusNumebr;
            if (DriverCode > 0)
                WhereStr += " and th.DriverPCode = " + DriverCode;
            if (LineCode > 0)
                WhereStr += " and th.LineCode = " + LineCode;
            if (StartEventDate.HasValue && EndEventDate.HasValue)
                WhereStr += " and cast(th.startdate as date) between '" + StartEventDate.Value.ToShortDateString() + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JHokmeKarReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JHokmeKarReportControl_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + DriverCode.ToString() + "_" + LineCode.ToString();
            jGridView.SQL = @"select th.Code,cap.Name,e.PersonNumber,s3.name VaziayeHamkari,
                        Az.Name ZoneName,Al.LineNumber ,th.BusNumber,Th.Seri,th.startdate , th.enddate ,
                        case th.status when 0 then N'غیرفعال' else N'فعال' end as status
                        from AutTarrifHokmeKar th
                        left join clsAllPerson cap on cap.Code = th.DriverPCode
						left join subdefine s3 on s3.Code = th.VaziayeHamkariCode
                        left join AUTZone az on az.Code = th.ZoneCode
                        left join AUTLine al on al.code = th.LineCode
						left join (select PCode,MAX(PersonNumber) PersonNumber from EmpEmployee group by PCode) e on e.pCode = th.DriverPCode
						where 1 = 1 " + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JHokmeKar";
            jGridView.PageOrderByField = " startdate Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JHokmeKarReportControl._HokmeKarNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JHokmeKarReportControl._HokmeKarUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JHokmeKarReportControl._HokmeKarUpdate", null, null));
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Bind();

        }
        public string _HokmeKarNew()
        {
            return _HokmeKarNew(null);
        }
        public string _HokmeKarNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HokmeKar"
                 , "~/WebBusManagement/FormsManagement/JHokmeKarUpdateControl.ascx"
                 , "حکم کار رانندگان"
                 , null
                 , WindowTarget.NewWindow
                  , true, false, true, 600, 570);
        }
        public string _HokmeKarUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HokmeKar"
                  , "~/WebBusManagement/FormsManagement/JHokmeKarUpdateControl.ascx"
                  , "حکم کار رانندگان"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 570);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                int StateHokm = int.Parse(RadHokmState.SelectedToggleState.Value);
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                        ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbLine.SelectedValue), StateHokm);
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbLine.SelectedValue), StateHokm);
                }
            }
            catch { }
        }

    }
}