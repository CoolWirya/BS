using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JDefineFieldForm : JBaseForm
    {

        private int _Code;

        public JDefineFieldForm()
        {
            InitializeComponent();
        }

        public JDefineFieldForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
        }
        private void Set_Form()
        {
            try
            {
                JDefineField tmp = new JDefineField(_Code);
                txtTitle.Text = tmp.Name;
                cmbSubject.SelectedValue = tmp.ClassName;
                cmbSubject_SelectedIndexChanged(null, null);
                rtxtField.Text = tmp.Text;
                txtSeparate.Text = tmp.Separate;
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                // Except.AddException(ex);
            }
        }

        public bool Save()
        {
            //if (textControl1.FileCode == 0)
            try
            {
                JDefineField tmp = new JDefineField();
                tmp.Name = txtTitle.Text;
                tmp.ClassName = cmbSubject.SelectedValue.ToString();
                //Convert.ToInt32(((System.Data.DataRowView)(cmbSubject.SelectedItem)).Row.ItemArray[0]);
                tmp.Text = rtxtField.Text;
                tmp.Separate = txtSeparate.Text;
                if (State != JFormState.Update)
                {
                    _Code = tmp.Insert();
                    if (_Code > 0)
                    {
                        State = JFormState.Update;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    tmp.Code = _Code;
                    if (tmp.Update())
                    {
                        State = JFormState.Update;
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                // Except.AddException(ex);
                return false;
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (MessageBox.Show("DoYouWantToSaveChanges", "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    if (Save())
                        this.Close();
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    this.Close();
            }
            else
                this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            rtxtField.Text.Insert(rtxtField.SelectionStart, "<" + cmbListField.Text + ">");
            //rtxtField.Select = rtxtField.SelectedText;
            rtxtField.AppendText( "<" + cmbListField.Text + ">");
            //rtxtField.Text = rtxtField.Text + "<" + cmbListField.Text + ">";
            btnSave.Enabled = true;
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxtField.Text = "";
            DataTable dt = new DataTable();
            int[] j = { 0 };
            JAction SaveAction = new JAction("FieldList", cmbSubject.SelectedValue + ".FieldList", new object[] { j }, null);
            dt = (DataTable)SaveAction.run();
            cmbListField.Items.Clear();
            if(dt != null)
            for (int i = 0; i < dt.Columns.Count; i++)
                cmbListField.Items.Add(JLanguages._Text(dt.Columns[i].Caption.ToString()));
            btnSave.Enabled = true;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rtxtField_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void JDefineFieldForm_Load(object sender, EventArgs e)
        {
            FillCombo();
            if (State == JFormState.Update)
                Set_Form();
        }

        private void FillCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Text");

            string[] str = {"Finance.JCheque", "Finance.JFish","Finance.JPromissoryNote","Legal.Contract",
                               "Legal.JSellerContract","Legal.JSellerAdvocateContract","Legal.JBuyerContract","Legal.JBuyerAdvocateContract",
                               "Legal.JSellerContractLegal","Legal.JSellerAdvocateContractLegal","Legal.JBuyerContractLegal","Legal.JBuyerAdvocateContractLegal",
                               "Legal.JIntuitionContract"};

            for (int i = 0; i < str.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = str[i];
                dr["Text"] = JLanguages._Text(str[i]);
                dt.Rows.Add(dr);
            }
            cmbSubject.DisplayMember = "Text";
            cmbSubject.ValueMember = "Name";
            cmbSubject.DataSource = dt;
        }

        private void txtSeparate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.State = JFormState.Insert;
            _Code = 0;
            rtxtField.Text = "";
            txtSeparate.Text = "";
            txtTitle.Text = "";
        }

        private void chkCal_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
