using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JLinesServicesUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadShift();
            LoadServicesGrid();
        }

        public void LoadShift()
        {
            DataTable DtShift = new DataTable();
            DtShift = BusManagment.WorkOrder.JShifts.GetDataTable(0);
            cmbShift.DataSource = DtShift;
            cmbShift.DataTextField = "Title";
            cmbShift.DataValueField = "Code";
            cmbShift.DataBind();
        }

        public void LoadServicesGrid()
        {
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.Code N'کد',al.LineNumber N'شماره خط',ash.Title N'شیفت',NumOfSerivec N'تعداد سرویس' from AutLineServices a
                                                                            left join AUTLine al on al.Code = a.LineCode
                                                                            left join AUTShift ash on ash.Code = a.ShiftCode 
                                                                            where a.LineCode = " + Code);
            RadGridReport.DataSource = Dt;
            RadGridReport.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BusManagment.Line.JLineServices LineService = new BusManagment.Line.JLineServices();
            LineService.LineCode = Code;
            LineService.ShiftCode = Convert.ToInt32(cmbShift.SelectedValue);
            LineService.NumOfSerivec = Convert.ToInt32(ntb_NumOfServicePerDay.Text);
            if (EditCode.Value == "0")
            {
                if (LineService.Insert(true) > 0)
                {
                    ntb_NumOfServicePerDay.Text = "";
                    LoadServicesGrid();
                }
            }
            else {
                LineService.Code = Convert.ToInt32(EditCode.Value);
                if(LineService.Update(true))
                {
                    EditCode.Value = "0";
                    ntb_NumOfServicePerDay.Text = "";
                    LoadServicesGrid();
                }
            }
        }

        protected void RadGridReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditCode.Value = RadGridReport.SelectedRow.Cells[1].Text.ToString();
            ntb_NumOfServicePerDay.Text = RadGridReport.SelectedRow.Cells[4].Text.ToString();
            cmbShift.SelectedItem.Text = RadGridReport.SelectedRow.Cells[3].Text.ToString();
            btnDelService.Visible = true; 
        }

        protected void btnDelService_Click(object sender, EventArgs e)
        {
            BusManagment.Line.JLineServices LineService = new BusManagment.Line.JLineServices();
            LineService.Code = Convert.ToInt32(EditCode.Value);
            if(LineService.Delete(true))
            {
                btnDelService.Visible = false;
                EditCode.Value = "0";
                ntb_NumOfServicePerDay.Text = "";
                LoadServicesGrid();
            }
        }
    }
}