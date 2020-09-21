using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JTitlePostForm : JBaseForm
    {

        int _Code;
        int _CompanyCode;

        public JTitlePostForm(int pCompanyCode)
        {
            InitializeComponent();
            _CompanyCode = pCompanyCode;
        }

        public JTitlePostForm(int pCode, int pCompanyCode)
        {
            InitializeComponent();
            _Code = pCode;
            _CompanyCode = pCompanyCode;
        }
        private void Set_Form()
        {
            JPostTitle tmpJPostTitle = new JPostTitle(_Code);
            txtJobCode.Text = tmpJPostTitle.PostNumber.ToString();
            txtLevel.Text = tmpJPostTitle.Title;
            cmbParent.SelectedValue = tmpJPostTitle.ParentCode;
            _CompanyCode = tmpJPostTitle.CompanyCode;
        }

        private void JTitleJobForm_Load(object sender, EventArgs e)
        {
            Fill();
            if (_Code > 0)
                Set_Form();
        }

        private void Fill()
        {
            cmbParent.DisplayMember = "Title";
            cmbParent.ValueMember = "code";
            cmbParent.DataSource = JPostTitles.GetDataTable(0,_CompanyCode);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (txtJobCode.Text == "")
                {
                    JMessages.Message(" لطفا کد پست را وارد کنید ", "", JMessageType.Error);
                    return;
                }
                if (txtLevel.Text == "")
                {
                    JMessages.Message(" لطفا نام پست را وارد کنید ", "", JMessageType.Error);
                    return;
                }
                #endregion

                JPostTitle tmpJPostTitle = new JPostTitle(_Code);
                tmpJPostTitle.ParentCode = Convert.ToInt32(cmbParent.SelectedValue);
                tmpJPostTitle.Title = txtLevel.Text;
                tmpJPostTitle.PostNumber = txtJobCode.IntValue ;
                  tmpJPostTitle.CompanyCode= _CompanyCode;
                if (State == JFormState.Insert)
                {
                    if (tmpJPostTitle.Insert(_CompanyCode) > 0)
                    {
                        JMessages.Message("Insert Successfuly", "", JMessageType.Information);                       
                        Fill();
                        txtJobCode.Focus();
                    }
                    else
                        JMessages.Message("Insert Not Successfuly", "", JMessageType.Error);
                }
                else
                {
                    tmpJPostTitle.Code = _Code;
                    if (tmpJPostTitle.Update(_CompanyCode))
                    {
                        JMessages.Message("Update Successfuly", "", JMessageType.Information);
                    }
                    else
                        JMessages.Message("Update Not Successfuly", "", JMessageType.Error);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
