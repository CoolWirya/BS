using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class JObjectListItemSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            btnSearch.OnClientClicked = "CallShowMenuObjectList";
        }

        public string Code
        {
            get { return txtCode.Text; }
            set
            {
                AVL.ObjectList.JObjectList dmodel = new AVL.ObjectList.JObjectList(int.Parse(value));

                txtCode.Text = dmodel.Code.ToString();
                txtLabel.Text = dmodel.Label;
            }
        }
    }
}