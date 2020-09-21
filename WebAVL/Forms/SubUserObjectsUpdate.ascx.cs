using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class SubUserObjectsUpdate : System.Web.UI.UserControl
    {
        public int ParentUserCode;
        public int userCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            userCode = int.Parse(Request["Code"]);
            ParentUserCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            System.Data.DataTable dt = AVL.SubUserObjects.JSubUserObjectss.GetDataTable(ParentUserCode, userCode);
            if (dt == null)
                dt = new System.Data.DataTable();
            foreach (System.Data.DataRow dr in AVL.ObjectList.JObjectLists.GetDataTable(ParentUserCode).Rows)
            {
                try
                {
                    chbObjects.Items.Add(new ListItem(dr["Label"].ToString(), dr["Code"].ToString())
                        {
                            Selected = (dt.Rows[0]["objects"].ToString().Contains(dr["Code"].ToString())) ? true : false
                        });
                }
                catch
                {
                    chbObjects.Items.Add(new ListItem(dr["Label"].ToString(), dr["Code"].ToString()));
                }
            }
        }
    }
}