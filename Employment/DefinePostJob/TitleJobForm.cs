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
    public partial class JTitleJobForm : JBaseForm
    {
        int _Code;
        int _CompanyCode;

        public JTitleJobForm(int pCompanyCode)
        {
            InitializeComponent();
            _CompanyCode = pCompanyCode;
        }

        public JTitleJobForm(int pCode ,int pCompanyCode)
        {
            InitializeComponent();
            _Code = pCode;
            _CompanyCode = pCompanyCode;
        }
        private void Set_Form()
        {
            JJobTitle tmpJJobTitle = new JJobTitle(_Code);
            txtJobCode.Text = tmpJJobTitle.JobCode.ToString();
            cmbDegree.SelectedValue = tmpJJobTitle.DegreeCode;
            txtExpreince.Text = tmpJJobTitle.Expreince.ToString();
            txtGroup.Text = tmpJJobTitle.Group.ToString();
            cmbMetierTopic.SelectedValue = tmpJJobTitle.TitleCode;
            txtLevel.Text = tmpJJobTitle.Level.ToString();
            _CompanyCode = tmpJJobTitle.CompanyCode;
        }

        private void JTitleJobForm_Load(object sender, EventArgs e)
        {
            JDegreeTypes Degree = new JDegreeTypes();
            Degree.SetComboBox(cmbDegree, -1);

            DataTable dt = new DataTable();
            //---------------- set combobox Metier Topic ---------------
            dt = (new JMetiertopics()).GetList(JEBaseDefine.MetierCode);
            cmbMetierTopic.DisplayMember = "name";
            cmbMetierTopic.ValueMember = "code";
            cmbMetierTopic.DataSource = dt;
            if (_Code > 0)
                Set_Form();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (txtJobCode.Text == "")
                {
                    JMessages.Message(" لطفا کد شغل را وارد کنید ", "", JMessageType.Error);
                    return ;
                }

                if (Convert.ToInt32(cmbMetierTopic.SelectedValue) == -1)
                {
                    JMessages.Message(" لطفا عنوان را انتخاب کنید ", "", JMessageType.Error);
                    return ;
                }
                #endregion

                JJobTitle tmpJJobTitle = new JJobTitle();
                tmpJJobTitle.DegreeCode = Convert.ToInt32(cmbDegree.SelectedValue);
                tmpJJobTitle.Expreince = txtExpreince.IntValue;
                tmpJJobTitle.Group = txtGroup.IntValue;
                tmpJJobTitle.JobCode = txtJobCode.IntValue;
                tmpJJobTitle.Level = txtLevel.IntValue;
                tmpJJobTitle.TitleCode = Convert.ToInt32(cmbMetierTopic.SelectedValue);
                tmpJJobTitle.CompanyCode = _CompanyCode;
                if (State == JFormState.Insert)
                {
                    if (tmpJJobTitle.Insert(_CompanyCode) > 0)
                    {
                        JMessages.Message("Insert Successfuly", "", JMessageType.Information);
                        txtJobCode.Focus();
                    }
                    else
                        JMessages.Message("Insert Not Successfuly", "", JMessageType.Error);
                }
                else
                {
                    tmpJJobTitle.Code = _Code;
                    if (tmpJJobTitle.Update(_CompanyCode))
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
