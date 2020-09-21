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
    public partial class JRentForm : JBaseContractForm
    {

        public JRentForm()
        {
            InitializeComponent();
            //txtEndDate.Date = ContractForms.Contract.EndDate;
            //txtStartDate.Date = ContractForms.Contract.StartDate;
        }


        public JRentForm MakeForm()
        {
            JRentForm form = new JRentForm();
            return form;
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

        #region Methods

        public void Set_Form()
        {
            try
            {              

                txtSharj.Text = ContractForms.Contract.Sharj.ToString();
                txtPrice.Text = ContractForms.Contract.PriceMonth.ToString();
                txtGh.Text = ContractForms.Contract.Price.ToString();
                txtFineT1.Text = ContractForms.Contract.FineT1.ToString();
                txtFineT2.Text = ContractForms.Contract.FineT2.ToString();
                txtTahrirPrice.Text = ContractForms.Contract.TahrirPrice.ToString();
                txtDesc.Text = ContractForms.Contract.RentDesc;

                ///هزینه های شارژ
              
                switch (ContractForms.Contract.SharjByRenter)
                {
                    case JContractPartiesType.Both:
                        rbBoth.Checked = true;
                        break;
                    case JContractPartiesType.Buyer:
                        rbBuyer.Checked = true;
                        break;
                    case JContractPartiesType.Seller:
                        rbSeller.Checked = true;
                        break;
                    default:
                        rbBoth.Checked = false;
                        rbBuyer.Checked = false;
                        rbSeller.Checked = false;
                        break;
                }
                ///هزینه های حق التحریر
                switch (ContractForms.Contract.TahrirByRenter)
                {
                    case JContractPartiesType.Both:
                        rbTahrirBoth.Checked = true;
                        break;
                    case JContractPartiesType.Buyer:
                        rbTahrirBuyer.Checked = true;
                        break;
                    case JContractPartiesType.Seller:
                        rbTahrirSeller.Checked = true;
                        break;
                    default:
                        rbTahrirBoth.Checked = false;
                        rbTahrirBuyer.Checked = false;
                        rbTahrirSeller.Checked = false;
                        break;
                }

                ///هزینه های مالیات بر مستغلات
                switch (ContractForms.Contract.TaxByRenter)
                {
                    case JContractPartiesType.Both:
                        rbTaxBoth.Checked = true;
                        break;
                    case JContractPartiesType.Buyer:
                        rbTaxBuyer.Checked = true;
                        break;
                    case JContractPartiesType.Seller:
                        rbTahrirSeller.Checked = true;
                        break;
                    default:
                        rbTaxBoth.Checked = false;
                        rbTaxBuyer.Checked = false;
                        rbTaxSeller.Checked = false;
                        break;
                }
                ///هزینه های مالیات بر درآمد
                switch (ContractForms.Contract.IncomeByRenter)
                {
                    case JContractPartiesType.Both:
                        rbIncomeBoth.Checked = true;
                        break;
                    case JContractPartiesType.Buyer:
                        rbIncomeBuyer.Checked = true;
                        break;
                    case JContractPartiesType.Seller:
                        rbIncomeSeller.Checked = true;
                        break;
                    default:
                        rbIncomeBoth.Checked = false;
                        rbIncomeBuyer.Checked = false;
                        rbIncomeSeller.Checked = false;
                        break;
                }
                if (State == JStateContractForm.View)
                {
                    txtEndDate.ReadOnly = true;
                    txtGh.ReadOnly = true;
                    txtMonth.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                    txtSharj.ReadOnly = true;
                    txtStartDate.ReadOnly = true;
                    txtFineT1.ReadOnly = true;
                    txtFineT2.ReadOnly = true;
                    grpCosts.Enabled = false;
                    grpTahrirCosts.Enabled = false;
                    grpTaxCosts.Enabled = false;
                    grpIncomeCosts.Enabled = false;
                    txtDays.ReadOnly = true;
                    txtDesc.ReadOnly = true;
                    txtTahrirPrice.ReadOnly = true;
                }
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool CheckData()
        {
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
            if (txtPrice.Text == "") 
            {
                JMessages.Information("Please Enter Price", "Information");
                return false;
            }
            if (txtSharj.Visible && txtSharj.Text == "") 
            {
                JMessages.Information("Please Enter Sharj", "Information");
                return false;
            }
            if (txtGh.Text == "") 
            {
                JMessages.Information("Please Enter Gh", "Information");
                return false;
            }
            return true;
        }

        public bool ApplyData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                /// هزینه شارژ
                if (rbSeller.Checked)
                    ContractForms.Contract.SharjByRenter = JContractPartiesType.Seller;
                else
                    if (rbBuyer.Checked)
                        ContractForms.Contract.SharjByRenter = JContractPartiesType.Buyer;
                    else
                        if (rbBoth.Checked)
                            ContractForms.Contract.SharjByRenter = JContractPartiesType.Both;
                        else
                            ContractForms.Contract.SharjByRenter = JContractPartiesType.None;

                /// هزینه حق التحریر
                if (rbTahrirSeller.Checked)
                    ContractForms.Contract.TahrirByRenter = JContractPartiesType.Seller;
                else
                    if (rbTahrirBuyer.Checked)
                        ContractForms.Contract.TahrirByRenter = JContractPartiesType.Buyer;
                    else
                        if (rbTahrirBoth.Checked)
                            ContractForms.Contract.TahrirByRenter = JContractPartiesType.Both;
                        else
                            ContractForms.Contract.TahrirByRenter = JContractPartiesType.None;

                /// هزینه های مالیات بر مستغلات
                if (rbTaxSeller.Checked)
                    ContractForms.Contract.TaxByRenter = JContractPartiesType.Seller;
                else
                    if (rbTaxBuyer.Checked)
                        ContractForms.Contract.TaxByRenter = JContractPartiesType.Buyer;
                    else
                        if (rbTaxBoth.Checked)
                            ContractForms.Contract.TaxByRenter = JContractPartiesType.Both;
                        else
                            ContractForms.Contract.TaxByRenter = JContractPartiesType.None;

                /// هزینه های مالیات بر درآمد
                if (rbIncomeSeller.Checked)
                    ContractForms.Contract.IncomeByRenter = JContractPartiesType.Seller;
                else
                    if (rbIncomeBuyer.Checked)
                        ContractForms.Contract.IncomeByRenter = JContractPartiesType.Buyer;
                    else
                        if (rbIncomeBoth.Checked)
                            ContractForms.Contract.IncomeByRenter = JContractPartiesType.Both;
                        else
                            ContractForms.Contract.IncomeByRenter = JContractPartiesType.None;

                ContractForms.Contract.Sharj = txtSharj.DecimalValue;
                ContractForms.Contract.PriceMonth = txtPrice.DecimalValue;
                ContractForms.Contract.Price = txtGh.DecimalValue;
                ContractForms.Contract.Duration = txtMonth.IntValue;
                ContractForms.Contract.Job = Convert.ToInt32(cmbJobs.SelectedValue);
                ContractForms.Contract.FineT1 = txtFineT1.MoneyValue;
                ContractForms.Contract.FineT2 = txtFineT2.MoneyValue;
                ContractForms.Contract.TahrirPrice = txtTahrirPrice.MoneyValue;
                ContractForms.Contract.RentDesc = txtDesc.Text;
                //ContractForms.Contract.SharjByRenter = Convert.ToInt16(chSharjByRenter.Checked);
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
                pDt.Columns.Add("Sharj");
                pDt.Columns.Add("PriceMonth");
                pDt.Columns.Add("PriceMonthString");
                pDt.Columns.Add("Price");
                pDt.Columns.Add("GhPriceString");
                pDt.Columns.Add("DurationMonths");
                pDt.Columns.Add("Job");

                pDt.Columns.Add("FineT1");
                pDt.Columns.Add("FineT2");
                pDt.Columns.Add("SharjByRenter");
                pDt.Columns.Add("DurationDays");
                pDt.Columns.Add("RentDesc");
                pDt.Columns.Add("TahrirByRenter");
                pDt.Columns.Add("TahrirPrice");
                pDt.Columns.Add("TaxByRenter");
                pDt.Columns.Add("IncomeByRenter");
                pDt.Columns.Add("SumRentPrice");
                pDt.Columns.Add("SumRentPriceText");

                if (pSetValue)
                {
                    if (pOffline)
                        Fill_Data();

                    pDt.Rows[0]["Sharj"] = txtSharj.Text;
                    pDt.Rows[0]["PriceMonth"] = txtPrice.Text;
                    pDt.Rows[0]["PriceMonthString"] = JMoney.NumberToString(txtPrice.Text);
                    pDt.Rows[0]["Price"] = txtGh.Text;
                    pDt.Rows[0]["GhPriceString"] = JMoney.NumberToString(txtGh.Text);
                    pDt.Rows[0]["DurationMonths"] = txtMonth.Text;
                    pDt.Rows[0]["DurationDays"] = txtDays.Text;
                    pDt.Rows[0]["Job"] = cmbJobs.Text;

                    pDt.Rows[0]["FineT1"] = txtFineT1.Text;
                    pDt.Rows[0]["FineT2"] = txtFineT2.Text;
                    pDt.Rows[0]["RentDesc"] = txtDesc.Text;
                    pDt.Rows[0]["SumRentPrice"] =JMoney.StringToMoney((txtPrice.MoneyValue * txtMonth.IntValue).ToString());
                    pDt.Rows[0]["SumRentPriceText"] = JMoney.NumberToString((txtPrice.MoneyValue * txtMonth.IntValue).ToString());
                    
                    switch (ContractForms.Contract.SharjByRenter)
                    {
                        case JContractPartiesType.Both:
                            pDt.Rows[0]["SharjByRenter"] = " دو طرف ";
                            break;
                        case JContractPartiesType.Buyer:
                            pDt.Rows[0]["SharjByRenter"] = ContractForms.Settings.Items["T2Lable"];
                            break;
                        case JContractPartiesType.Seller:
                            pDt.Rows[0]["SharjByRenter"] = ContractForms.Settings.Items["T1Lable"];// " موجر ";
                            break;
                        default:
                            break;
                    }

                    switch (ContractForms.Contract.SharjByRenter)
                    {
                        case JContractPartiesType.Both:
                            pDt.Rows[0]["TahrirByRenter"] = " دو طرف ";
                            break;
                        case JContractPartiesType.Buyer:
                            pDt.Rows[0]["TahrirByRenter"] = ContractForms.Settings.Items["T2Lable"];
                            break;
                        case JContractPartiesType.Seller:
                            pDt.Rows[0]["TahrirByRenter"] = ContractForms.Settings.Items["T1Lable"];// " موجر ";
                            break;
                        default:
                            break;
                    }

                    switch (ContractForms.Contract.TaxByRenter)
                    {
                        case JContractPartiesType.Both:
                            pDt.Rows[0]["TaxByRenter"] = " دو طرف ";
                            break;
                        case JContractPartiesType.Buyer:
                            pDt.Rows[0]["TaxByRenter"] = ContractForms.Settings.Items["T2Lable"];
                            break;
                        case JContractPartiesType.Seller:
                            pDt.Rows[0]["TaxByRenter"] = ContractForms.Settings.Items["T1Lable"];// " موجر ";
                            break;
                        default:
                            break;
                    }

                    switch (ContractForms.Contract.IncomeByRenter)
                    {
                        case JContractPartiesType.Both:
                            pDt.Rows[0]["IncomeByRenter"] = " دو طرف ";
                            break;
                        case JContractPartiesType.Buyer:
                            pDt.Rows[0]["IncomeByRenter"] = ContractForms.Settings.Items["T2Lable"];
                            break;
                        case JContractPartiesType.Seller:
                            pDt.Rows[0]["IncomeByRenter"] = ContractForms.Settings.Items["T1Lable"];// " موجر ";
                            break;
                        default:
                            break;
                    }
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
        
        public override bool Save(JDataBase tempdb)
        {
           return true;            
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }

        private void Fill_Data()
        {
            JSubBaseDefine nullDeff = new JSubBaseDefine(0);
            nullDeff.Code = -1;
            nullDeff.Name = "-----------";
            JUnitJobs UnitJobs = new JUnitJobs();
            UnitJobs.SetComboBox(cmbJobs, ContractForms.Contract.Job);

            
                Set_Form();
                State = JStateContractForm.Update;
            txtEndDate.Date = ContractForms.Contract.EndDate;
            txtStartDate.Date = ContractForms.Contract.StartDate;
            if (txtEndDate.Date != DateTime.MinValue && txtStartDate.Date != DateTime.MinValue)
            {
                TimeSpan TS = txtEndDate.Date - txtStartDate.Date;
                txtMonth.Text = (TS.Days / 30).ToString();
                txtDays.Text = (TS.Days + 1).ToString();
            }

            rbSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
            rbBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();
            rbTahrirSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
            rbTahrirBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();
            rbTaxSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
            rbTaxBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();
            rbIncomeSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
            rbIncomeBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();
        }

        private void JRentForm_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";
                JUnitJobs UnitJobs = new JUnitJobs();
                UnitJobs.SetComboBox(cmbJobs, ContractForms.Contract.Job);                

                if ((ContractForms.Contract.Code != 0)// && (State != JStateContractForm.Update)
                    && Visible)
                {
                    Set_Form();
                    State = JStateContractForm.Update;
                }
                    txtEndDate.Date = ContractForms.Contract.EndDate;
                    txtStartDate.Date = ContractForms.Contract.StartDate;
                    if (txtEndDate.Date != DateTime.MinValue && txtStartDate.Date != DateTime.MinValue)
                    {
                        TimeSpan TS = txtEndDate.Date - txtStartDate.Date;
                        txtMonth.Text = (TS.Days / 30).ToString();
                        txtDays.Text = (TS.Days + 1).ToString();
                    }

                    rbSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
                    rbBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();
                    rbTahrirSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
                    rbTahrirBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();
                    rbTaxSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
                    rbTaxBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();
                    rbIncomeSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
                    rbIncomeBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JRentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }
    }
}
