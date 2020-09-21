using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using StoreComplex;

namespace Legal
{
    public partial class SCContractForm : JBaseContractForm
    {
        public SCContractForm()
        {
            InitializeComponent();
            SaveOrder = 1;
            LoadComoBox();
        }
        public SCContractForm MakeForm()
        {
            SCContractForm form = new SCContractForm();
            return form;
        }
        private void LoadComoBox()
        {
            JSCGoods goods = new JSCGoods();
            goods.SetComboBox(cmbGoods,0);
            JSCUnits units = new JSCUnits();
            units.SetComboBox(cmbUnits, 0);
            if (this.State == JStateContractForm.Insert)
            {
                txtDate.Date = (new JDataBase()).GetCurrentDateTime();
                txtStartDate.Date = txtDate.Date;
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

        public void Set_Form()
        {
            try
            {
                if (ContractForms.Contract.SCContractType == 1)
                {
                    rbType1.Checked = true;
                    txtPrice.Text = ContractForms.Contract.TotalPrice.ToString();
                }
                else if (ContractForms.Contract.SCContractType == 2)
                {
                    rbType2.Checked = true;
                    txtPrice2.Text = ContractForms.Contract.TotalPrice.ToString();
                }
                tbType1_CheckedChanged(null, null);
                txtContractNumber.Text = ContractForms.Contract.Number;
                txtDate.Date = ContractForms.Contract.Date;
                txtStartDate.Date = ContractForms.Contract.StartDate;
                txtEndDate.Date = ContractForms.Contract.EndDate;
                txtCondition.Text = ContractForms.Contract.Condition;
                cmbSubject.SelectedValue = ContractForms.Contract.Type;
                cmbGoods.SelectedValue = ContractForms.Contract.SCGood;
                cmbUnits.SelectedValue = ContractForms.Contract.SCUnit;
                txtArea.Text = ContractForms.Contract.SCArea.ToString();

                if (txtEndDate.Date != DateTime.MinValue && txtStartDate.Date != DateTime.MinValue)
                {
                    TimeSpan TS = txtEndDate.Date - txtStartDate.Date;
                    txtDuration.Text = (TS.Days / 30).ToString();
                } 
                if (State == JStateContractForm.View)
                {
                    cmbSubject.Enabled = false;
                    txtContractNumber.ReadOnly = true;
                    txtDate.ReadOnly = true;
                    txtStartDate.ReadOnly = true;
                    txtEndDate.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                    txtArea.ReadOnly = true;
                    txtPrice2.ReadOnly = true;
                    cmbGoods.Enabled = false;
                    cmbUnits.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        public bool CheckData()
        {
            if (txtContractNumber.Text.Trim() == "")
            {
                JMessages.Information("لطفا شماره قرارداد را وارد کنید", "Information");
                return false;
            }
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Information("لطفا تاریخ قرارداد را وارد کنید", "Information");
                return false;
            }
            if (txtStartDate.Date == DateTime.MinValue)
            {
                JMessages.Information("Please Enter StartDate", "Information");
                return false;
            }
            if (txtEndDate.Date == DateTime.MinValue)
            {
                JMessages.Information("Please Enter EndDate", "Information");
                return false;
            }
            if (txtPrice.Text == "" && txtPrice2.Text == "")
            {
                JMessages.Information("Please Enter Price", "Information");
                return false;
            }
            if (cmbSubject.SelectedValue == null)
            {
                JMessages.Information("Please Enter Subject", "Information");
                return false;
            }
            if (rbType2.Checked && txtArea.Text == "")
            {
                JMessages.Information("لطفاً مساحت مورد اجاره را وارد کنید.", "Information");
                return false;
            }
            return true;
        }

        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            if (txtStartDate.Date != DateTime.MinValue && txtDuration.IntValue != 0)
                txtEndDate.Date = JDateTime.GregorianDate(JDateTime.AddMonthFarsi(JDateTime.FarsiDate(txtStartDate.Date), txtDuration.IntValue).ToString());
        }

        public bool ApplyData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                if (rbType1.Checked)
                {
                    ContractForms.Contract.SCContractType = 1;
                    ContractForms.Contract.TotalPrice = txtPrice.DecimalValue;
                }
                else if (rbType2.Checked)
                {
                    ContractForms.Contract.SCContractType = 2;
                    ContractForms.Contract.TotalPrice = txtPrice2.DecimalValue;
                }
                ContractForms.Contract.Number = txtContractNumber.Text;
                ContractForms.Contract.Type = Convert.ToInt32(cmbSubject.SelectedValue);
                ContractForms.Contract.Date= txtDate.Date;
                ContractForms.Contract.StartDate = txtStartDate.Date;
                ContractForms.Contract.EndDate = txtEndDate.Date;
                ContractForms.Contract.Condition = txtCondition.Text;
                ContractForms.Contract.SCGood = Convert.ToInt32(cmbGoods.SelectedValue);
                ContractForms.Contract.SCUnit = Convert.ToInt32(cmbUnits.SelectedValue);

                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
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
                //pDt.Columns.Add("Type");
                pDt.Columns.Add("ContractNo");
                pDt.Columns.Add("Date");
                pDt.Columns.Add("TotalPrice");
                pDt.Columns.Add("StartDate");
                pDt.Columns.Add("EndDate");
                pDt.Columns.Add("DurationMonths");
                pDt.Columns.Add("Condition");
                pDt.Columns.Add("GoodType");
                pDt.Columns.Add("SCArea");
                pDt.Columns.Add("Unit");

                if (pSetValue)
                {
                    if (pOffline)
                        Fill_Data();

                    //pDt.Rows[0]["Type"] = cmbSubject.Text;
                    pDt.Rows[0]["ContractNo"] = txtContractNumber.Text;
                    pDt.Rows[0]["Date"] = JGeneral.ReverseDate(txtDate.Text);
                    if (rbType1.Checked)
                        pDt.Rows[0]["TotalPrice"] = txtPrice.Text;
                    else if (rbType2.Checked)
                        pDt.Rows[0]["TotalPrice"] = txtPrice2.Text;

                    pDt.Rows[0]["StartDate"] = JGeneral.ReverseDate(txtStartDate.Text);
                    pDt.Rows[0]["EndDate"] = JGeneral.ReverseDate(txtEndDate.Text);
                    pDt.Rows[0]["DurationMonths"] = txtDuration.Text;
                    pDt.Rows[0]["Condition"] = txtPrice.Text;
                    pDt.Rows[0]["GoodType"] = cmbGoods.Text;
                    pDt.Rows[0]["Unit"] = cmbUnits.Text;
                    pDt.Rows[0]["SCArea"] = txtArea.Text;
                }
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

        public override bool Save(JDataBase DB)
        {
            try
            {
                /// ویرایش قرارداد
                tempState = State;
                if (ContractForms.Contract.Code > 0)
                {
                    if (ContractForms.Contract.Update(DB))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    ContractForms.Contract.Code = ContractForms.Contract.Insert(DB);
                    if (ContractForms.Contract.Code > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();

        }

        private void Fill_Data()
        {
            JSCGoods goods = new JSCGoods();
            goods.SetComboBox(cmbGoods, ContractForms.Contract.SCGood);
            JSCUnits units = new JSCUnits();
            units.SetComboBox(cmbUnits, ContractForms.Contract.SCUnit);

            Set_Form();
            State = JStateContractForm.Update;
            //txtEndDate.Date = ContractForms.Contract.EndDate;
            //txtStartDate.Date = ContractForms.Contract.StartDate;
            //txtCondition.Text = ContractForms.Contract.Condition;
            //txtPrice.Text = ContractForms.Contract.Price.ToString();
            //if (txtEndDate.Date != DateTime.MinValue && txtStartDate.Date != DateTime.MinValue)
            //{
            //    TimeSpan TS = txtEndDate.Date - txtStartDate.Date;
            //    txtDuration.Text = (TS.Days / 30).ToString();
            //}

        }

        private void SCContractForm_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                JSCGoods goods = new JSCGoods();
                goods.SetComboBox(cmbGoods, ContractForms.Contract.SCGood);
                JSCUnits units = new JSCUnits();
                units.SetComboBox(cmbUnits, ContractForms.Contract.SCUnit);
                cmbSubject.DisplayMember = "Title";
                cmbSubject.ValueMember = "Code";
                cmbSubject.DataSource = JContractdefines.GetDataTable(0, ContractForms.Contract.ContractType.Code, null);
        
                if ((ContractForms.Contract.Code != 0)// && (State != JStateContractForm.Update)
                    && Visible)
                {
                    Set_Form();
                    State = JStateContractForm.Update;
                }
                //txtStartDate.Date = ContractForms.Contract.StartDate;
                //txtEndDate.Date = ContractForms.Contract.EndDate;
                //txtPrice.Text = ContractForms.Contract.Price.ToString();
                //txtCondition.Text = ContractForms.Contract.Condition;
                //if (txtEndDate.Date != DateTime.MinValue && txtStartDate.Date != DateTime.MinValue)
                //{
                //    TimeSpan TS = txtEndDate.Date - txtStartDate.Date;
                //    txtDuration.Text = (TS.Days / 30).ToString();
                //} 
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void SCContractForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }

        private void tbType1_CheckedChanged(object sender, EventArgs e)
        {
            grpCost.Visible = rbType1.Checked;
            grpCost2.Visible = rbType2.Checked;
        }


    }
}
