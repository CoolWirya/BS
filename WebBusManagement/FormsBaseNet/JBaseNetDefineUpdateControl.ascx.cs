using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebBaseNet.EventNet;
using ClassLibrary;


namespace WebBusManagement.FormsBaseNet
{
    public partial class JBaseNetDefineUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                LoadDefine();
                LoadBus();
                LoadPlace();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);

                if (Code > 0)
                {
                    WebBaseNet.EventNet.JEventNet EN = new JEventNet(Code);
                    cmbBus.SelectedValue = EN.BusCode.ToString();
                    cmbNet.SelectedValue = EN.DefineCode.ToString();
                    txtDesc.Text = EN.Descs.ToString();
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(EN.EndTime.Date);
                    ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(EN.StartTime.Date);
                    cmbPlace.SelectedValue = EN.PlaceCode.ToString();

                }
            }
        }

        public bool Save()
        {
            WebBaseNet.EventNet.JEventNet EN = new JEventNet(Code);
            EN.BusCode = int.Parse(cmbBus.SelectedItem.Value);
            EN.DefineCode = int.Parse(cmbNet.SelectedItem.Value);
            EN.Descs = txtDesc.Text;
            EN.StartTime = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).Date;
            EN.EndTime = ((WebControllers.MainControls.Date.JDateControl)txtToDate).Date;
            EN.PlaceCode = int.Parse(cmbPlace.SelectedValue);

            if (Code > 0)
                return EN.Update();
            else
            {
                Code = EN.Insert();
                return Code > 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Save())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد');", "ConfirmDialog");
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void LoadPlace()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT a.[Code],a.[Name] FROM [dbo].[AUTBusEventPlace] a");
                DataTable dt = db.Query_DataTable();
                cmbPlace.DataSource = dt;
                cmbPlace.DataTextField = "Name";
                cmbPlace.DataValueField = "Code";
                cmbPlace.DataBind();
            }
            finally
            {
                db.Dispose();
            }
        }

        public void LoadDefine()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT a.[Code],a.[DefineName] FROM [dbo].[AUTNetDefine] a");
                DataTable dt = db.Query_DataTable();
                cmbNet.DataSource = dt;
                cmbNet.DataTextField = "DefineName";
                cmbNet.DataValueField = "Code";
                cmbNet.DataBind();
            }
            finally
            {
                db.Dispose();
            }
        }


    }
}


      
      
    
     