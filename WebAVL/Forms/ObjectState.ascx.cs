using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class ObjectState : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    foreach (System.Data.DataRow dr in AVL.ObjectList.JObjectLists.GetDataTable(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode).Rows)
                    {
                        chbObjects.Items.Add(new ListItem(dr["Type"].ToString(), dr["Code"].ToString())
                        {
                            Selected = (string.IsNullOrEmpty(dr["isActive"].ToString())) ? false : bool.Parse(dr["isActive"].ToString())
                        });
                    }
                }
                catch
                {

                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }
    }
}