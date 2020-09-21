using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JBazrasServiceUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(DateTime.Now);
            _SetForm();
            if (!IsPostBack)
            {
                LoadBus();
                LoadLine();
                LoadProcess();
            }
        }

        public void LoadLine()
        {
            DataTable dt = BusManagment.Line.JLines.GetDataTable(0);
            cmbLine.DataSource = dt;
            cmbLine.DataTextField = "LineNumber";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void LoadProcess()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Label");
            DataRow dr = dt.NewRow();
            dr["Code"] = 1;
            dr["Label"] = "خیر";
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["Code"] = 2;
            dr1["Label"] = "بله";
            dt.Rows.Add(dr1);

            cmbProcessAgain.DataSource = dt;
            cmbProcessAgain.DataTextField = "Label";
            cmbProcessAgain.DataValueField = "Code";
            cmbProcessAgain.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select AL.Code LineCode,AB.Code BusCode,  ABR.BusNumber,ABR.DateCard,ABR.MoveDate,ABR.RealMoveDate,AL.LineNumber,AZ.Name ZoneName,CAP1.Name DriverName,CAP1.Code DriverPersonCode,ABR.DriverCode,CAP2.Name BazrasName,ABR.BazrasCode,CAP1.Code BazrasPersonCode from AUTBazRasService ABR
inner join AUTBus AB ON ABR.BusNumber=AB.BUSNumber
inner join AUTLine AL ON AL.LineNumber = AB.LastLineNumber
inner join AUTZone AZ ON AZ.Code=AL.ZoneCode
LEFT join Cards C1 ON C1.RfidNumber = ABR.DriverCode
LEFT join clsAllPerson CAP1 ON CAP1.Code=C1.PCode
LEFT join Cards C2 ON C2.RfidNumber = ABR.BazrasCode
LEFT join clsAllPerson CAP2 ON CAP2.Code=C2.PCode WHERE ABR.Code = " + Code, false);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(Dt.Rows[0]["DriverPersonCode"].ToString()))
                            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = Convert.ToInt32(Dt.Rows[0]["DriverPersonCode"].ToString());
                        if (!string.IsNullOrWhiteSpace(Dt.Rows[0]["BazrasPersonCode"].ToString()))
                            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = Convert.ToInt32(Dt.Rows[0]["BazrasPersonCode"].ToString());
                        ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(Convert.ToDateTime(Dt.Rows[0]["MoveDate"].ToString()));
                        cmbBus.SelectedValue = Dt.Rows[0]["BusCode"].ToString();
                        cmbLine.SelectedValue = Dt.Rows[0]["LineCode"].ToString();
                        txtStartTimeHour.Text = ((System.DateTime)Dt.Rows[0]["DateCard"]).Hour.ToString();
                        txtStartTimeMinute.Text = ((System.DateTime)Dt.Rows[0]["DateCard"]).Minute.ToString();
                        txtFinishTimeHour.Text = ((System.DateTime)Dt.Rows[0]["MoveDate"]).Hour.ToString();
                        txtFinishTimeMinute.Text = ((System.DateTime)Dt.Rows[0]["MoveDate"]).Minute.ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            if (Code > 0)
            {
                BusManagment.Bazras.JBazRasService B = new BusManagment.Bazras.JBazRasService();
                B.GetData(Code);
                B.BazrasCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchBazrasPersonControl1).PersonCode;
                B.BusNumber = int.Parse(cmbBus.SelectedItem.Text);
                B.DateCard = ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate().AddSeconds(int.Parse(txtStartTimeHour.Text) * 3600 + int.Parse(txtStartTimeMinute.Text) * 60);
                B.DriverCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
                B.LineNumber = int.Parse(cmbLine.SelectedItem.Text);
                B.MoveDate = ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate().AddSeconds(int.Parse(txtFinishTimeHour.Text) * 3600 + int.Parse(txtFinishTimeMinute.Text) * 60);
                B.Update(cmbProcessAgain.SelectedItem.Value.ToString() == "2");
                B.Updateit1();
                Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('اطلاعات با موفقیت اصلاح گردید');", true);
                return;

            }
            else
            {
                BusManagment.Bazras.JBazRasService B = new BusManagment.Bazras.JBazRasService();
                B.BazrasCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchBazrasPersonControl1).PersonCode;
                B.BusNumber = int.Parse(cmbBus.SelectedItem.Text);
                B.DateCard = ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate().AddSeconds(int.Parse(txtStartTimeHour.Text) * 3600 + int.Parse(txtStartTimeMinute.Text) * 60);
                B.DriverCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
                B.LineNumber = int.Parse(cmbLine.SelectedItem.Text);
                B.MoveDate = ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate().AddSeconds(int.Parse(txtFinishTimeHour.Text) * 3600 + int.Parse(txtFinishTimeMinute.Text) * 60);
                B.Insert();
               
                return;
            }
            Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('ثبت اطلاعات با خطا مواجه شد');", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            if (Code > 0)
            {
                Db.setQuery(@"delete from [dbo].[AUTBazRasService] where code = " + Code);
                if (Db.Query_Execute() >= 0)
                {
                    WebClassLibrary.JWebManager.CloseAndRefresh();
                }
            }
        }

    }
}