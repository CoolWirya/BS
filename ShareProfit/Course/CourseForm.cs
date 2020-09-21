using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ShareProfit
{
    public partial class JCourseForm : ClassLibrary.JBaseForm
    {
        private JCourse _Course;

        public JCourseForm()
        {
            InitializeComponent();
            _Course = new JCourse();
            _FillComboBox();
        }

		public void DefineProperty()
		{
			if (JPermission.CheckPermission("ManagementShares.JCourseForm.DefineProperty", true))
			{
				Globals.Property.JDefinePropertyForm F = new Globals.Property.JDefinePropertyForm("ManagementShares.JCourseForm", _Course.Code);
				F.ShowDialog();
			}
		}

        public JCourseForm(int  pCourseCode)
        {
            InitializeComponent();

            if (pCourseCode > 0)
            {
            _Course = new JCourse();
            _Course.getData(pCourseCode);

            if (_Course.Code > 0)
                ShowData();
            }
            _FillComboBox();
        }

        private void _FillComboBox()
        {
            cmbCompany.DataSource = ManagementShares.JShareCompanies.GetDataTable();
            cmbCompany.ValueMember = "Code";
            cmbCompany.DisplayMember = "Name";

        }
        private void ShowData()
        {
            txtCode.Text = _Course.Code.ToString();
            txtTitle.Text = _Course.Title;
            txtFinYear.Text = _Course.FinYear.ToString();
            txtCost.Text = _Course.Cost.ToString();
            txtApproveDate.Text = _Course.ApproveDate;
            btnSave.Enabled = false;
            
            txtShareCount.Text = _Course.ShareCount.ToString();

            cmbCompany.SelectedValue = _Course.CompanyCode;

            chkOnlineShare.Checked = _Course.OnlinePayment;
        }

        private void SaveOfflineShare()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string Query =@"
                    insert into sahamsheet
                    select *,{0} from sharesheet where CompanyCode={1} and Status=1";
                DB.setQuery(string.Format(Query, _Course.Code, _Course.CompanyCode));
                DB.Query_Execute();
            }
            finally
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Check Controls
            if (txtTitle.Text =="")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Title" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtTitle.Focus();
                return;
            }
            if (txtCost.Text.Length == 0)
            {
                JMessages.Error("PleaseEnterCost", "");
                txtCost.Focus();
                return;
            } 
            #endregion Check Controls
            try
            {
                _Course.Title = txtTitle.Text;
                _Course.FinYear = Convert.ToInt32(txtFinYear.Text);
                _Course.Cost = Convert.ToDecimal(txtCost.Text);
                _Course.ApproveDate = txtApproveDate.Text;
                _Course.ShareCount = Convert.ToInt32(txtShareCount.Text);
                _Course.OnlinePayment = chkOnlineShare.Checked;
                _Course.CompanyCode = (int)cmbCompany.SelectedValue;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }


            if (State == JFormState.Insert)
            {
                int cCode = _Course.insert();
                if (cCode == 0) return;
                if (!chkOnlineShare.Checked)
                    SaveOfflineShare();
                State = JFormState.Update;
                txtCode.Text = cCode.ToString();
            }
            if (State == JFormState.Update)
            {
                _Course.Update();
            }
            btnSave.Enabled = false;

            State = JFormState.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbPocketPayment_CheckedChanged(object sender, EventArgs e)
        {
        }

		private void btnProperty_Click(object sender, EventArgs e)
		{
			DefineProperty();
		}
    }
}
