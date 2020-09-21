using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JAndroidRequestUpdateControl : System.Web.UI.UserControl
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
                System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT AR.[Code]
                              ,AR.[UserCode]
                                ,AR.[RequestType]
	                          ,cap.Name UserName
                              ,AR.[ObjectCode]
	                          ,AP.Metraj + N' - ' +AP.MogheeyatMakani+N' - '+AP.Address Ground
                              ,AR.[Status]
                              ,dbo.DateEnToFa(AR.[InsertDate])InsertDate
                          FROM [dbo].[Andorid_Request] AR
                          left join clsAllPerson cap on cap.Code = AR.[UserCode]
                          left join Android_Ground ap on ap.Code = AR.[ObjectCode] where AR.Code = " + Code,false);
                txtPersonName.Text = Dt.Rows[0]["UserName"].ToString();
                txtRequestDate.Text = Dt.Rows[0]["InsertDate"].ToString();
                txtRequestObject.Text = Dt.Rows[0]["ObjectCode"].ToString();
                if (Dt.Rows[0]["RequestType"].ToString() == "1")
                {
                    txtRequestType.Text = "آپارتمان";
                }
                else
                {
                    txtRequestType.Text = "زمین";
                }
                cmbStatus.SelectedValue = Dt.Rows[0]["Status"].ToString();
            }
        }

        public bool Save()
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"UPDATE [dbo].[Andorid_Request]
                            SET [Status] = " + cmbStatus.SelectedItem.Value + @" where Code = " + Code);
            if (Db.Query_Execute() >= 0)
            {
                return true;
            }
            else { return false; }
        }

        protected void btnSave1_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}