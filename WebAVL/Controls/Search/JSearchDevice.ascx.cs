using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebAVL.Controls.Search
{
	public partial class JSearchDevice : System.Web.UI.UserControl
	{

        bool _multipleSelection=false;
		public bool MultipleSelection
		{
            get
            {
                return _multipleSelection;
            }
			set
			{
                _multipleSelection = value;
			}
		}
        public List<int> Codes
        {
            get
            {
                List<int> codes = new List<int>();
                foreach(Telerik.Web.UI.GridItem i in grdDevices.Items)
                {
                    codes.Add(int.Parse(i.Cells[2].Text));
                }
                return codes;
            }
        }
        public List<string> Colors
        {   get
            {
                List<string> colors = new List<string>();
                foreach(Telerik.Web.UI.GridItem i in grdDevices.Items)
                {
                    colors.Add(System.Drawing.ColorTranslator.ToHtml( i.BackColor));
                }
                return colors;
            }
        }
		public string Name
		{
			get
			{
				return txtName.Text;
			}
		}
		public string IMEI
		{
			get
			{
				return      txtImei.Text;
			}
        }
        public string Code
        {
            get
            {
                return txtCode.Text;
            }
        }

        public bool Colorfull
        {
            get
            {
                return _colorfull;
            }

            set
            {
                _colorfull = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         //   if(!Page.IsPostBack)
               // WebClassLibrary.SessionManager.Current.Session["deviceSearchListSelectedItems"] = null;
            btnSearch.OnClientClicked = "CallShowMenu";// _" + txtName.ClientID;
		}

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Telerik.Web.UI.GridItemCollection items = WebClassLibrary.SessionManager.Current.Session["deviceSearchListSelectedItems"] as Telerik.Web.UI.GridItemCollection;
            if (items != null)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add(new System.Data.DataColumn("Code"));
                dt.Columns.Add(new System.Data.DataColumn("Name"));
                dt.Columns.Add(new System.Data.DataColumn("IMEI"));
                foreach (Telerik.Web.UI.GridItem i in items)
                    dt.Rows.Add(i.Cells[2].Text, i.Cells[3].Text, i.Cells[4].Text);
                grdDevices.DataSource = dt;
                grdDevices.Rebind();
                txtCode.Text = dt.Rows[0][0].ToString();
                txtName.Text = dt.Rows[0][1].ToString();
                txtImei.Text = dt.Rows[0][2].ToString();
                if(Colorfull)
                foreach (Telerik.Web.UI.GridItem i in grdDevices.Items)
                    i.BackColor = System.Drawing.Color.FromKnownColor((System.Drawing.KnownColor)i.ItemIndex+40);
            }
        }

        private bool _colorfull = false;
        
    }
}