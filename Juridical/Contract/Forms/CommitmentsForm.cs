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
    public partial class JCommitmentsForm : JBaseContractForm
    {
        public JCommitmentsForm()
        {
            InitializeComponent();
        }

        public JCommitmentsForm MakeForm()
        {
            JCommitmentsForm form = new JCommitmentsForm();
            return form;
        }

        #region Methods

        public void Set_Form()
        {
            try
            {
                txtGuarantee.Text = ContractForms.Contract.Guarantee;
                txtCondition.Text = ContractForms.Contract.Condition;

                if (State == JStateContractForm.View)
                {
                    txtCondition.ReadOnly = true;
                    txtGuarantee.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool CheckData()
        {
            try
            {
                ContractForms.Contract.Guarantee = txtGuarantee.Text.Trim();
                ContractForms.Contract.Condition = txtCondition.Text.Trim();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        //public override bool SavePreview(DataTable pDt, bool pSetValue)
        //{
        //    SavePreview(pDt, 
        //}
        public override bool SavePreview(DataTable pDt)
        {
            try
            {
                pDt.Rows[0]["Guarantee"] = txtGuarantee.Text;
                pDt.Rows[0]["Condition"] = txtCondition.Text;
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public override bool SaveBack()
        {
            if (isSave)
            {
                isSave = false;
                State = tempState;
            }
            return true;
        }

        public override bool Save(JDataBase tempdb)
        {
           return true;
        }

        #endregion

        #region Events

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplyData())
                    if (CheckData())
                        ContractForms.NextForm();
                    else
                        JMessages.Information("Please  Enter Correct Data", "Information");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                 ContractForms.BackForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JCommitmentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                if ((ContractForms.Contract.Code != 0) && (State != JStateContractForm.Update))
                {
                    Set_Form();
                    State = JStateContractForm.Update;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }



    }
}
