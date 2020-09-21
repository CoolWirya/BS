using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JAccPaymentEditCommentUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if(Code>0)
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    DB.setQuery("select * from AUTPayment where Code=" + Code.ToString());
                    DataTable DT = DB.Query_DataTable();
                    if (DT != null && DT.Rows.Count == 1)
                        RadTextBox1.Text = DT.Rows[0]["Description"].ToString();

                }
                catch
                {

                }
                finally
                {
                    DB.Dispose();
                }
            }
        }

     
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                try
                {
                    DB.setQuery("update AUTPayment set Description = N'" + RadTextBox1.Text + "' where Code=" + Code.ToString());
                    DB.Query_Execute();
                }
                catch
                {

                }
                finally
                {
                    DB.Dispose();
                }
            }
        }
    }
}