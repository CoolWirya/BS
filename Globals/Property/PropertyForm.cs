using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Globals.Property
{
    public partial class JPropertyForm : Globals.JBaseForm
    {
        public JProperty Property;
        public JPropertyForm(JProperty pProperty)
        {
            InitializeComponent();
            Property = pProperty;

            SetclbControl();
            txbDataType.Items.AddRange(Enum.GetNames(Type.GetType("Globals.Property.JSQLDataType")));
            txbListType.Items.AddRange(Enum.GetNames(Type.GetType("Globals.Property.JProppertyListType")));
            SetTextBox();

        }

        public JPropertyForm(string pClassName,int pObjecyCode, int pCode)
        {
            InitializeComponent();
            Property = new JProperty(pClassName, pObjecyCode);

            SetclbControl();
            txbDataType.Items.AddRange(Enum.GetNames(Type.GetType("Globals.Property.JSQLDataType")));
            txbListType.Items.AddRange(Enum.GetNames(Type.GetType("Globals.Property.JProppertyListType")));

            if (pCode > 0)
            {
                Property.GetData(pCode);
                SetTextBox();
            }

        }

        private void SetclbControl()
        {
			DataTable PostEditDT = Employment.JEOrganizationChart.GetUserPosts();
			DataRow PostEditRow = PostEditDT.NewRow();
			PostEditRow["Title"] = "فقط صادر کننده";
			PostEditRow["Code"] = -1;
			PostEditDT.Rows.InsertAt(PostEditRow, 0);

			clbPostEditList.DataSource = PostEditDT;
            clbPostEditList.DisplayMember = "Title";
            clbPostEditList.ValueMember = "Code";
            SetList(clbPostEditList, Property.ListCanEdit);
            if (Property.ListCanEdit != null && Property.ListCanEdit.Length > 0)
                chkAllEdit.Checked = false;

			DataTable PostViewDT = Employment.JEOrganizationChart.GetUserPosts();
			DataRow PostViewRow = PostViewDT.NewRow();
			PostViewRow["Title"] = "فقط صادر کننده";
			PostViewRow["Code"] = -1;
			PostViewDT.Rows.InsertAt(PostViewRow, 0);

			clbPostViewList.DataSource = PostViewDT;
            clbPostViewList.DisplayMember = "Title";
            clbPostViewList.ValueMember = "Code";
            SetList(clbPostViewList, Property.ListCanView);
            if (Property.ListCanView != null && Property.ListCanView.Length > 0)
                chkAllView.Checked = false;
        }


        private void SetTextBox()
        {
            txbDataType.Text = Property.DataType;
            txbListType.Text = Property.ListType;
            txbListValue.Text = Property.List;
            txbOrder.Text = Property.Ordered.ToString();
            txbTitle.Text = Property.Name.Replace("__", " ");
        }

        private void PropertyForm_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (save())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public void SetList(CheckedListBox pCLB, string pList)
        {
            if (pList==null || pList.Length == 0)
            {
            }
            else
            {
                string[] Values = pList.Split(new char[] { ',' });
                for (int i = 0; i < pCLB.Items.Count; i++)
                {
                    string Index = (pCLB.Items[i] as DataRowView).Row["Code"].ToString();
                    for (int j = 0; j < Values.Length; j++)
                        if (Index == Values[j])
                        {
                            pCLB.SetItemChecked(i, true);
                        }
                }
            }
        }
        
        
        public string GetList(CheckedListBox pCLB)
        {
            string List = "";
            if (pCLB.CheckedItems.Count >= 1)
            {
                List = (pCLB.CheckedItems[0] as DataRowView).Row["Code"].ToString();
                for (int i = 1; i < pCLB.CheckedItems.Count; i++)
                {
                    List += "," + (pCLB.CheckedItems[i] as DataRowView).Row["Code"].ToString();
                }
            }
            return List;
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
                    
                //    if (this.State == ClassLibrary.JFormState.Insert)
                //{
                //    if (Property.Insert() > 0)
                //    {
                //        this.State = ClassLibrary.JFormState.Update;
                //        return true;
                //    }
                //}
                //else
                //    if (this.State == ClassLibrary.JFormState.Update)
                //    {
                //        if (Property.Update())
                //        {
                            return true;
                //        }
                //    }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            return false;
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbListValue.Enabled = (txbListType.Text == JProppertyListType.لیست_ثابت.ToString());
            //txbListValue.Enabled = (txbListType.Text == JProppertyListType.لیست_ثابت.ToString());
        }

        private void txbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAllView_CheckedChanged(object sender, EventArgs e)
        {
            clbPostViewList.Enabled = !chkAllView.Checked;
        }

        private void chkAllEdit_CheckedChanged(object sender, EventArgs e)
        {
            clbPostEditList.Enabled = !chkAllEdit.Checked;
        }
    }
}
