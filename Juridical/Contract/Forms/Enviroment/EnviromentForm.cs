using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using RealEstate;

namespace Legal
{
    public partial class JEnviromentForm : JBaseContractForm
    {
        public JEnviromentForm()
        {
            InitializeComponent();
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
        
        public bool ApplyData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                ContractForms.Contract.PriceMonth = txtRent.DecimalValue;
                ContractForms.Contract.Price = txtPrice.DecimalValue;
                ContractForms.Contract.EnviromentPaymentType = Convert.ToInt32(cmbPayment.SelectedValue);
                ContractForms.Contract.EnviromentPonyType = Convert.ToInt32(cmbPony.SelectedValue);
                ContractForms.Contract.EnviromentUsage = Convert.ToInt32(cmbUsage.SelectedValue);
                ContractForms.Contract.Job = Convert.ToInt32(cmbJobs.SelectedValue);
                ContractForms.Contract.RentDesc = txtDesc.Text;
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckData())
                    if (ApplyData())
                        ContractForms.NextForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        private void SetForm()
        {
            txtDesc.Text = ContractForms.Contract.RentDesc;
            txtPrice.Text = ContractForms.Contract.Price.ToString();;
            txtRent.Text = ContractForms.Contract.PriceMonth.ToString();
            if (State == JStateContractForm.View)
            {
                txtRent.ReadOnly = true;
                txtPrice.ReadOnly = true;
                txtDesc.ReadOnly = true;
                cmbJobs.Enabled = false;
                cmbPayment.Enabled = false;
                cmbPony.Enabled = false;
                cmbUsage.Enabled = false;
            }
        }

        private void Fill_Data()
        {
            /// Set ComboBoxes
            JUnitJobs UnitJobs = new JUnitJobs();
            UnitJobs.SetComboBox(cmbJobs, ContractForms.Contract.Job);
            JEnviromentUsages envUsages = new JEnviromentUsages();
            envUsages.SetComboBox(cmbUsage, ContractForms.Contract.EnviromentUsage);
            JEnviromentPaymentTypes envPayment = new JEnviromentPaymentTypes();
            envPayment.SetComboBox(cmbPayment, ContractForms.Contract.EnviromentPaymentType);
            JEnviromentPonyTypes envPony = new JEnviromentPonyTypes();
            envPony.SetComboBox(cmbPony, ContractForms.Contract.EnviromentPonyType);
            ///

            SetForm();
            State = JStateContractForm.Update;

        }

        private void JEnviromentForm_VisibleChanged(object sender, EventArgs e)
        {
            if (ContractForms.Contract.Code != 0 && Visible)
            {
                Fill_Data();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();

        }

        private void JEnviromentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }

        public JEnviromentForm MakeForm()
        {
            JEnviromentForm form = new JEnviromentForm();
            return form;
        }

        public override bool SavePreview(DataTable pDt)
        {
            return SavePreview(pDt, true, false);
        }

        public override bool SavePreview(DataTable pDt, bool pSetValue)
        {
            return SavePreview(pDt, pSetValue, false);
        }

        public override bool SavePreview(DataTable pDt, bool pSetValue, bool pOffline)
        {
            try
            {
                pDt.Columns.Add("PriceMonth");
                pDt.Columns.Add("PriceMonthString");
                pDt.Columns.Add("Price");
                pDt.Columns.Add("GhPriceString");
                pDt.Columns.Add("Job");
                pDt.Columns.Add("EnviromentPaymentType");
                pDt.Columns.Add("EnviromentPonyType");
                pDt.Columns.Add("EnviromentUsage");
                pDt.Columns.Add("RentDesc");

                if (pSetValue)
                {
                    if (pOffline)
                        Fill_Data();

                    pDt.Rows[0]["PriceMonth"] = txtRent.Text;
                    pDt.Rows[0]["PriceMonthString"] = JMoney.NumberToString(txtRent.Text);
                    pDt.Rows[0]["Price"] = txtPrice.Text;
                    pDt.Rows[0]["GhPriceString"] = JMoney.NumberToString(txtPrice.Text);
                    pDt.Rows[0]["Job"] = cmbJobs.Text;
                    pDt.Rows[0]["EnviromentPaymentType"] = cmbPayment.Text;
                    pDt.Rows[0]["EnviromentPonyType"] = cmbPony.Text;
                    pDt.Rows[0]["EnviromentUsage"] = cmbUsage.Text;
                    pDt.Rows[0]["RentDesc"] = txtDesc.Text;
                  
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
    }
}
