using BusManagment.Bus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JAccDocumentsTransferUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now.AddDays(-1));
                LoadOwners();
            }
        }
        public void LoadOwners()
        {
            DataTable dt = JBusOwners.GetBusOwners();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            this.cmbOwner.DataSource = p;
            this.cmbOwner.DataTextField = "Name";
            this.cmbOwner.DataValueField = "Code";
            this.cmbOwner.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dtFrom = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate();
            DateTime dtTo = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate();
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            string[] ParamaNames = new string[3] { "@from_date", "@to_date", "@owner_code" };
            string[] ParamaValues = new string[3] { dtFrom.ToString("yyyy-MM-dd 00:00:00"), dtTo.ToString("yyyy-MM-dd 00:00:00"),
                        cmbOwner.SelectedValue };
            DataTable dt = new DataTable();
            try
            {
                dt = Db.ExecuteProcedure_Query("[dbo].[SP_DocumentsTransfer]", ParamaNames, ParamaValues);
                if (Convert.ToInt32(dt.Rows[0][0]) == 1)
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('انتقال با موفقیت انجام شد');", "ConfirmDialog");
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('انتقال سندهای تایید شده امکان پذیر نیست');", "ConfirmDialog"); 
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                WebClassLibrary.JWebManager.RunClientScript("alert('دوباره تلاش کنید');", "ConfirmDialog");
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}