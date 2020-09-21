using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace RealEstate
{
    public partial class JJointSpaceForm : ClassLibrary.JBaseForm
    {
        public static int sCode;
        private JJointSpace _JJointSpace;
        private JEnviroment _JEnviroment;

        public JJointSpaceForm(JJointSpace pJJointSpace)
        {
            InitializeComponent();
            _JJointSpace = pJJointSpace;
            _FillComboBox();
        }

        public JJointSpaceForm()
        {
            InitializeComponent();
            _FillComboBox();
        }

        public void _FillComboBox()
        {
            // پر كردن ليست كاربري ها
            JDefineMarketUsages Usages = new JDefineMarketUsages();
            cmbRegister.Items.Clear();
            Usages.SetComboBox(cmbRegister);
            //foreach (JSubBaseDefine Usage in Usages.Items)
            //    cmbRegister.Items.Add(Usage);

            // پر كردن شغل ها
            JUnitJobs UnitJobs = new JUnitJobs();
            cmbJobTitle.Items.Clear();
            UnitJobs.SetComboBox(cmbJobTitle);
            //foreach (JSubBaseDefine job in UnitJobs.Items)
            //{
            //    cmbJobTitle.Items.Add(job);
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region SetValue
            _JJointSpace = new JJointSpace();
            _JJointSpace.CodeEnviroment = txtCodeEnviroment.IntValue;
            _JJointSpace.Area = txtArea.IntValue;
            _JJointSpace.CodeSpace = txtCodeSpace.IntValue;
            _JJointSpace.moneyArea = txtMoneyArea.MoneyValue;
            _JJointSpace.ChargeAmount = txtChargeAmount.MoneyValue;
            _JJointSpace.Topics = txtTopics.Text;
            _JJointSpace.JobTitle = Convert.ToInt32(cmbJobTitle.SelectedValue);
            _JJointSpace.Address=txtAddress.Text;
            _JJointSpace.Register = Convert.ToInt32(cmbRegister.SelectedValue);
            #endregion

            # region Insert
            if (State == ClassLibrary.JFormState.Insert)
            {
                _JJointSpace.Insert();
                JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
            }
            else
            {
                _JJointSpace.Update();
                JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
            }
            #endregion

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JSearchJoint JS = new JSearchJoint();
            JS.ShowDialog();
            _JEnviroment = new JEnviroment();
            _JEnviroment.GetData(sCode);

            #region Set Data
            txtCodeEnviroment.Text = _JEnviroment.Code.ToString();
            txtArea.Text = _JEnviroment.Area.ToString();
            txtChargeAmount.Text = _JEnviroment.moneyBaseCharge.ToString();
            txtCodeSpace.Text = _JEnviroment.CodeEnviroment.ToString();
            #endregion

        }

    }
}
