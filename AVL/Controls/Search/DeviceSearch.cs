using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AVL.Controls.Search
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:DeviceSearch runat=server></{0}:DeviceSearch>")]
    public class DeviceSearch : Control,INamingContainer
    {
        private Button btnSearch;
        private TextBox txtImei, txtname;
        private GridView grvItems;
        private RegisterDevice.JRegisterDevice device;
        private System.Data.DataTable data;

        public DeviceSearch():base()
        {
            txtImei = new TextBox();
            txtname = new TextBox();
            btnSearch = new Button();
            grvItems = new GridView();
            grvItems.DataKeyNames = new string[] { "Name", "IMEI" };
            grvItems.PagerSettings.Mode = PagerButtons.NextPrevious;
            grvItems.PageSize = 5;
            grvItems.AllowPaging = true;
            grvItems.PageIndex = 0;
            grvItems.AutoGenerateColumns = false;
            grvItems.AutoGenerateSelectButton = true;
            grvItems.Columns.Add(new BoundField() { HeaderText = "Name", DataField = "Name" });
            grvItems.Columns.Add(new BoundField() { HeaderText = "IMEI", DataField = "IMEI" });
            grvItems.PageIndexChanging += GrvItems_PageIndexChanging;
            grvItems.SelectedIndexChanged += GrvItems_SelectedIndexChanged;
            grvItems.SelectedRowStyle.BackColor=System.Drawing.Color.Yellow ;
            ViewState["where"] = "";

        }

        private void GrvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["imei"] = grvItems.SelectedRow.Cells[2].Text.ToString();
        }

        private void GrvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FillGrid();
            grvItems.PageIndex = e.NewPageIndex;
            grvItems.DataBind();
        }
        

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Name
        {
            get
            {
                return txtname.Text;
            }

            set
            {
                txtname.Text = value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public System.Data.DataTable Datasource
        {
            get
            {
                return data;
            }

            set
            {
                data= value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string IMEI
        {
            get
            {
                return txtImei.Text;
            }

            set
            {
                txtImei .Text= value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public RegisterDevice.JRegisterDevice Device
        {
            get
            {
                return new RegisterDevice.JRegisterDevice((string)ViewState["imei"]);
            }
        }
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Controls.Add(new LiteralControl("<table>"));
            if (ShowImeiBox)
            {
                Controls.Add(new LiteralControl("<tr>"));
                Controls.Add(new LiteralControl("<td>"));
                Controls.Add(new LiteralControl("<p>IMEI</p>"));
                Controls.Add(new LiteralControl("</td>"));
                Controls.Add(new LiteralControl("<td>"));
                txtImei.Text = IMEI;
                Controls.Add(txtImei);
                Controls.Add(new LiteralControl("</td>"));
                Controls.Add(new LiteralControl("</tr>"));
            }
            Controls.Add(new LiteralControl("<tr>"));
            if (ShowNameBox)
            {
                Controls.Add(new LiteralControl("<td>"));
                Controls.Add(new LiteralControl("<p>" + ClassLibrary.JLanguages._Farsi("Name") + "</p>"));
                Controls.Add(new LiteralControl("</td>"));
                Controls.Add(new LiteralControl("<td>"));
                txtname.Text = Name;
                Controls.Add(txtname);
                Controls.Add(new LiteralControl("</td>"));

            }
            Controls.Add(new LiteralControl("<td>"));
                btnSearch.Text = ClassLibrary.JLanguages._Farsi("search");
                btnSearch.Click += BtnSearch_Click;
                Controls.Add(btnSearch);
                Controls.Add(new LiteralControl("</td>"));
                Controls.Add(new LiteralControl("</tr>"));
            Controls.Add(new LiteralControl("<tr>"));
            Controls.Add(new LiteralControl("<td>"));
            Controls.Add(grvItems);
            Controls.Add(new LiteralControl("</td>"));
            Controls.Add(new LiteralControl("</tr>"));
            Controls.Add(new LiteralControl("</table>"));
        }


        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public bool ShowImeiBox
        {
            get; set;
        }
        private bool _shownamebox = true;

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)] 
        public bool ShowNameBox
        {
            get
            {
                return _shownamebox;
            }
            set { _shownamebox = value; }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ViewState["where"] = "";
            grvItems.PageIndex = 0;
            FillGrid();
        }

        private void FillGrid()
        {
            if (data == null)
            {
                string WHERE = "";
                if (!string.IsNullOrEmpty(txtImei.Text))
                    WHERE += " AND IMEI like '%" + txtImei.Text + "%' ";
                if (!string.IsNullOrEmpty(txtname.Text))
                    WHERE += " AND Name like N'%" + txtname.Text + "%' ";

                if (!ClassLibrary.JPermission.CheckPermission("WebAVL.JWebAVL._isMarketer") && !WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin )
                    WHERE += @" AND Code in(
SELECT jd.childDeviceCode FROM [AVLDB].[dbo].[AVLDevice]
        d right join
AVLJoinDevice jd on d.Code=jd.parentDeviceCode where d.personCode="+ WebClassLibrary.SessionManager.Current .MainFrame.CurrentUserCode+ ")";
                if (String.IsNullOrEmpty(WHERE))
                    WHERE = (string)ViewState["where"];
                data = AVL.RegisterDevice.JRegisterDevices.GetDataTable(true, WHERE);
            ViewState["where"] = WHERE;
            }
            grvItems.DataSource = data;
            grvItems.DataBind();
        }

        protected override void OnPreRender(EventArgs e)
        {
            txtImei.Text = "";
            txtname.Text = "";
        }
        
    }
}
