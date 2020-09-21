using Globals.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.FormManager
{
    public partial class JFormPropertyControl : System.Web.UI.UserControl
    {
        public JProperty Property;
        string pClassName;
        int pObjectCode;
        int pCode;
        string JDefinePropertyFormTemporaryURL;
        DataTable _datatable;

        private void SetTextBox()
        {
            txbDataType.Text = Property.DataType;
            txbListType.Text = Property.ListType;
            txbListValue.Text = Property.List;
            txbOrder.Text = Property.Ordered.ToString();
            txbTitle.Text = Property.Name.Replace("__", " ");
        }
        public string GetList(CheckBoxList pCLB)
        {
            string List = "";
            for (int i = 0; i < pCLB.Items.Count; i++)
                if (pCLB.Items[i].Selected)
                    List += (i > 0 ? "," : "") + pCLB.Items[i].Value;
            return List;
        }
        public void SetList(CheckBoxList pCLB, string pList)
        {
            if (pList == null || pList.Length == 0)
            {
            }
            else
            {
                string[] Values = pList.Split(new char[] { ',' });
                for (int i = 0; i < pCLB.Items.Count; i++)
                    for (int j = 0; j < Values.Length; j++)
                        pCLB.Items[i].Selected = pCLB.Items[i].Value == Values[j];
            }
        }
        void UpdateDataTable()
        {
            if (_datatable == null)
                return;
            DataRow DR = _datatable.NewRow();

            DR["Name"] = Property.Name.Replace("__", " ");
            DR["Active"] = Property.Active;
            DR["ClassName"] = Property.ClassName;
            DR["Code"] = Property.Code;
            DR["DataType"] = Property.DataType;
            DR["DefaultValue"] = Property.DefaultValue;
            DR["List"] = Property.List;
            DR["ListType"] = Property.ListType;
            DR["Ordered"] = Property.Ordered;
            DR["ObjectCode"] = Property.ObjectCode;
            DR["ListCanView"] = Property.ListCanView;
            DR["ListCanEdit"] = Property.ListCanEdit;

            _datatable.Rows.Add(DR);
        }
        private bool save()
        {
            try
            {
                Property.DataType = txbDataType.SelectedItem.ToString();
                Property.ListType = txbListType.SelectedItem.ToString();
                Property.List = txbListValue.Text;
                Property.Ordered = int.Parse('0' + txbOrder.Text);
                Property.Name = txbTitle.Text.Replace(" ", "__");

                if (!chkAllEdit.Checked)
                    Property.ListCanEdit = GetList(clbPostEditList);
                else
                    Property.ListCanEdit = "";

                if (!chkAllView.Checked)
                    Property.ListCanView = GetList(clbPostViewList);
                else
                    Property.ListCanView = "";
                UpdateDataTable();
                return true;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            return false;
        }
        WebClassLibrary.JSUIDManager formSUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //formSUID = new WebClassLibrary.JSUIDManager("Forms");
            //pClassName = formSUID.GetObject("ClassName").ToString();
            //pObjectCode = (int)formSUID.GetObject("ObjectCode");
            //pCode = (int)formSUID.GetObject("Code");
            //JDefinePropertyFormTemporaryURL = formSUID.GetObject("JDefinePropertyFormTemporaryURL").ToString();
            //_datatable = (DataTable)formSUID.GetObject("_datatable");
            //Property = new JProperty(pClassName, pObjectCode);

            //SetclbControl();
            ////txbDataType.Items.AddRange( Enum.GetNames(Type.GetType("Globals.Property.JSQLDataType")));
            ////txbListType.Items.AddRange(Enum.GetNames(Type.GetType("Globals.Property.JProppertyListType")));
            //txbDataType.DataSource = Enum.GetNames(typeof(Globals.Property.JSQLDataType));
            //txbDataType.DataBind();
            //txbListType.DataSource = Enum.GetNames(typeof(Globals.Property.JProppertyListType));
            //txbListType.DataBind();
            //if (pCode > 0)
            //{
            //    Property.GetData(pCode);
            //    SetTextBox();
            //}
        }

        protected void chkAllView_CheckedChanged(object sender, EventArgs e)
        {
            clbPostViewList.Enabled = !chkAllView.Checked;
        }

        protected void chkAllEdit_CheckedChanged(object sender, EventArgs e)
        {
            clbPostEditList.Enabled = !chkAllEdit.Checked;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (save())
            {
                formSUID.SetObject("_datatable", _datatable);
                //HttpContext.Current.Response.Redirect(JDefinePropertyFormTemporaryURL);
                WebClassLibrary.JWebManager.CloseWindow();
            }
        }
        private void SetclbControl()
        {
            clbPostEditList.DataSource = Employment.JEOrganizationChart.GetUserPosts();
            clbPostEditList.DataTextField = "Title";
            clbPostEditList.DataValueField = "Code";
            SetList(clbPostEditList, Property.ListCanEdit);
            if (Property.ListCanEdit != null && Property.ListCanEdit.Length > 0)
                chkAllEdit.Checked = false;

            clbPostViewList.DataSource = Employment.JEOrganizationChart.GetUserPosts();
            clbPostViewList.DataTextField = "Title";
            clbPostViewList.DataValueField = "Code";
            SetList(clbPostViewList, Property.ListCanView);
            if (Property.ListCanView != null && Property.ListCanView.Length > 0)
                chkAllView.Checked = false;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseWindow();
        }
    }
}