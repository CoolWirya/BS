using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JSharePriceTextUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                db.setQuery(@"select Code,Text from entSharePriceText where Code = " + Code);
                System.Data.DataTable Dt = new System.Data.DataTable();
                Dt = db.Query_DataTable();
                if (Dt.Rows.Count > 0)
                {
                    txtText.Text = Dt.Rows[0]["Text"].ToString();
                }
            }
        }

        public bool Save()
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
                db.setQuery(@"update entSharePriceText set Text=N'" + txtText.Text + @"' where Code = " + Code);
                return db.Query_Execute() >= 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}