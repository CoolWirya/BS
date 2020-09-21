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
    public partial class JContractPriceForm : JBaseContractForm
    {
        enum PropertiesForm
        {
            GetLastContractData,
        }

        public JContractPriceForm()
        {
            InitializeComponent();
        }

        public JContractPriceForm MakeForm()
        {
            JContractPriceForm form = new JContractPriceForm();
            return form;
        }

    #region Methods

        public void Set_Form()
        {
            Set_Form(ContractForms.Contract);
        }

        public void Set_Form(JSubjectContract pContract)
        {
            try
            {
                txtPrice.Text = pContract.TotalPrice.ToString();
                txtRealPrice.Text = pContract.RealPrice.ToString();
                txtEndPayment.Text = Convert.ToString(pContract.TotalPrice - pContract.RealPrice);
                txtStartPayment.Date = pContract.StartpaymentDate.Date;
                txtDatePrice.Date = pContract.RealPriceDate;
                txtEndPayment.Date = pContract.EndpaymentDate.Date;
                txtCountPayment.Text = pContract.CountPayment.ToString();
                txtEndPrice1.Text = pContract.EndPrice.ToString();
                txtEndPrice2.Text = pContract.EndPrice1.ToString();
                txtEndPrice3.Text = pContract.EndPrice2.ToString();
                txtCostUpToNow.Text = pContract.CostUpToNow.ToString();
                txtPriceCancel.Text = pContract.PriceCancel.ToString();
                txtInstallmentPrice.Text = pContract.InstallmentPrice.ToString();
                CalcPrice();

                if (State == JStateContractForm.View)
                {
                    txtCountPayment.ReadOnly = true;
                    txtDatePrice.ReadOnly = true;
                    txtEndPayment.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                    txtRealPrice.ReadOnly = true;
                    txtRemain.ReadOnly = true;
                    txtStartPayment.ReadOnly = true;
                }

               
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool CheckData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                if (txtDatePrice.Date == DateTime.MinValue && txtRealPrice.MoneyValue !=0)
                {
                    JMessages.Information("Please Enter DatePrice", "Information");
                    return false;
                }
                if (txtPrice.Text == "") 
                {
                    JMessages.Information("Please Enter TotalPrice", "Information");
                    return false;
                }
                if (txtRealPrice.Text == "") 
                {
                    JMessages.Information("Please Enter Price", "Information");
                    return false;
                }
                if (txtRemain.DecimalValue != 0)
                {
                    JMessages.Error("لطفاً مبالغ قرارداد را بصورت صحیح وارد کنید.", "خطا");
                    return false;
                }
                //if (txtRemain.Text == "") 
                //{
                //    JMessages.Information("Please Enter Remain", "Information");
                //    return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool ApplyData()
        {
            try
            {
                ContractForms.Contract.TotalPrice = txtPrice.MoneyValue;
                ContractForms.Contract.RealPrice = txtRealPrice.MoneyValue;
                //ContractForms.Contract.RemainPrice = Convert.ToDecimal(txtRemain.Text);
                ContractForms.Contract.StartpaymentDate = txtStartPayment.Date;
                ContractForms.Contract.EndpaymentDate = txtEndPayment.Date;
                ContractForms.Contract.RealPriceDate = txtDatePrice.Date;
                ContractForms.Contract.CountPayment = txtCountPayment.IntValue;
                ContractForms.Contract.EstenkafRight = txtEstenkafRight.MoneyValue;
                ContractForms.Contract.PriceCancel = txtPriceCancel.MoneyValue;

                ContractForms.Contract.ReturnChCount = txtReturnChCount.IntValue;
                ContractForms.Contract.EndPrice =  txtEndPrice1.DecimalValue;
                ContractForms.Contract.EndPrice1 = txtEndPrice2.MoneyValue;
                ContractForms.Contract.EndPrice2 = txtEndPrice3.MoneyValue;
                ContractForms.Contract.InstallmentPrice = txtInstallmentPrice.DecimalValue;
                ContractForms.Contract.CostUpToNow = txtCostUpToNow.DecimalValue;
                //if (txtCountPayment.Text != "")
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
                pDt.Columns.Add("TotalContractPrice");
                pDt.Columns.Add("TotalContractPriceString");

                pDt.Columns.Add("RealPrice");
                pDt.Columns.Add("RealPriceString");
                pDt.Columns.Add("RealPricePercent");

                pDt.Columns.Add("RemainPrice");
                pDt.Columns.Add("RemainPriceString");
                pDt.Columns.Add("RemainPricePercent");

                pDt.Columns.Add("DateRealPrice");

                pDt.Columns.Add("CountPayment");

                pDt.Columns.Add("StartpaymentDate");

                pDt.Columns.Add("EndpaymentDate");

                pDt.Columns.Add("EstenkafRight");

                pDt.Columns.Add("PriceCancel");                

                pDt.Columns.Add("EstenkafRightString");
                pDt.Columns.Add("PriceCancelString");                

                pDt.Columns.Add("ReturnChCount");

                pDt.Columns.Add("EndPrice");
                pDt.Columns.Add("EndPrice1");
                pDt.Columns.Add("EndPrice2");

                pDt.Columns.Add("EndPricePercent");
                pDt.Columns.Add("EndPricePercent1");
                pDt.Columns.Add("EndPricePercent2");

                pDt.Columns.Add("CostUpToNow");
                pDt.Columns.Add("RealPriceDate");
                pDt.Columns.Add("InstallmentPrice");
                pDt.Columns.Add("InstallmentPriceString");
                pDt.Columns.Add("InstallmentPricePercent");

                if (pSetValue)
                {
                    if (pOffline)
                        Fill_Data();

                    pDt.Rows[0]["TotalContractPrice"] = JMoney.StringToMoney(txtPrice.Text);
                    pDt.Rows[0]["TotalContractPriceString"] = JMoney.NumberToString(JMoney.RemoveMoney(txtPrice.Text));

                    pDt.Rows[0]["RealPrice"] = JMoney.StringToMoney(txtRealPrice.Text);
                    pDt.Rows[0]["RealPriceString"] =JMoney.NumberToString(JMoney.RemoveMoney (txtRealPrice.Text));
                    pDt.Rows[0]["RealPricePercent"] = (100 * Math.Round(txtRealPrice.MoneyValue / txtPrice.MoneyValue, 2)).ToString() + "%";

                    pDt.Rows[0]["RemainPrice"] = JMoney.StringToMoney(txtRemain.Text);
                    pDt.Rows[0]["RemainPriceString"] = JMoney.NumberToString(txtRemain.Text);
                    pDt.Rows[0]["RemainPricePercent"] = (100 * Math.Round(txtRemain.MoneyValue / txtPrice.MoneyValue, 2)).ToString() + "%";

                    pDt.Rows[0]["DateRealPrice"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtDatePrice.Date).ToString());
                    pDt.Rows[0]["CountPayment"] = txtCountPayment.Text;
                    pDt.Rows[0]["StartpaymentDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtStartPayment.Date).ToString());
                    pDt.Rows[0]["EndpaymentDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtEndPayment.Date).ToString());
                    pDt.Rows[0]["EstenkafRight"] = JMoney.StringToMoney(txtEstenkafRight.Text);
                    pDt.Rows[0]["PriceCancel"] = JMoney.StringToMoney(txtPriceCancel.Text);
                    pDt.Rows[0]["EstenkafRightString"] = JMoney.NumberToString(JMoney.RemoveMoney(txtEstenkafRight.Text));
                    pDt.Rows[0]["PriceCancelString"] = JMoney.NumberToString(JMoney.RemoveMoney(txtPriceCancel.Text));
                    pDt.Rows[0]["ReturnChCount"] = txtReturnChCount.Text;
                    pDt.Rows[0]["EndPrice"] = JMoney.StringToMoney(txtEndPrice1.Text);
                    pDt.Rows[0]["EndPrice1"] = JMoney.StringToMoney(txtEndPrice2.Text);
                    pDt.Rows[0]["EndPrice2"] = JMoney.StringToMoney(txtEndPrice3.Text);

                    pDt.Rows[0]["EndPricePercent"] = (100 * Math.Round(txtEndPrice1.MoneyValue / txtPrice.MoneyValue, 2)).ToString() + "%";
                    pDt.Rows[0]["EndPricePercent1"] = (100 * Math.Round(txtEndPrice2.MoneyValue / txtPrice.MoneyValue, 2)).ToString() + "%";
                    pDt.Rows[0]["EndPricePercent2"] = (100 * Math.Round(txtEndPrice3.MoneyValue / txtPrice.MoneyValue, 2)).ToString() + "%";

                    pDt.Rows[0]["InstallmentPrice"] = JMoney.StringToMoney(txtInstallmentPrice.Text);
                    pDt.Rows[0]["InstallmentPricePercent"] = (100 * Math.Round(txtInstallmentPrice.MoneyValue / txtPrice.MoneyValue , 2)).ToString() + "%"; ;
                    pDt.Rows[0]["InstallmentPriceString"] = JMoney.NumberToString(JMoney.RemoveMoney(txtInstallmentPrice.Text));
                    pDt.Rows[0]["CostUpToNow"] = txtCostUpToNow.Text;
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

    #region Events

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                TotalPrice = txtPrice.Int64Value;
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

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalcPrice();
        }
        private void CalcPrice()
        {
            try
            {
                decimal RealPrice = 0;
                decimal Price = 0;
                decimal EndPrice = 0;
                decimal InstallmentPrice = 0;
                decimal UpToNowPrice = 0;
                if (txtRealPrice.Text != "")
                    RealPrice = txtRealPrice.MoneyValue;
                if (txtCostUpToNow.MoneyValue != 0)
                  UpToNowPrice = txtCostUpToNow.MoneyValue;
                if (txtPrice.Text != "")
                    Price = txtPrice.MoneyValue;
                if (txtEndPrice1.Text != "")
                    EndPrice = txtEndPrice1.MoneyValue + txtEndPrice2.MoneyValue + txtEndPrice3.MoneyValue;
                if (txtInstallmentPrice.Text != "")
                    InstallmentPrice = txtInstallmentPrice.MoneyValue;
                if (RealPrice != 0)
                    txtRemain.Text = JMoney.StringToMoney(Convert.ToString(Price - RealPrice - EndPrice-InstallmentPrice));
                if (UpToNowPrice != 0)
                    txtRemain.Text = JMoney.StringToMoney(Convert.ToString(Price - UpToNowPrice - EndPrice-InstallmentPrice));
                if (txtRealPrice.Text != "")
                    lbRealPricePercent.Text = (100 * RealPrice / Price).ToString() + "%";
                if (txtInstallmentPrice.Text != "")
                    lbInstallmentPercent.Text = (100 * InstallmentPrice / Price).ToString() + "%";
                if (txtEndPrice1.Text != "")
                    lbEndPercent.Text = (100 * txtEndPrice1.MoneyValue / Price).ToString() + "%";
                if (txtEndPrice2.Text != "")
                    lbEndPercent2.Text = (100 * txtEndPrice2.MoneyValue / Price).ToString() + "%";
                if (txtEndPrice3.Text != "")
                    lbEndPercent3.Text = (100 * txtEndPrice3.MoneyValue / Price).ToString() + "%";

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void txtRealPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalcPrice();
        }
    #endregion

        private void JContractPriceForm_Load(object sender, EventArgs e)
        {
            if (JContractPropertiesForm.CheckPrperties(this.GetType().FullName, PropertiesForm.GetLastContractData.ToString(), ContractForms.Contract.ContractType.Code))
            {
                JSubjectContract _tempSubjectContract = ContractForms.Contract.GetLastGoodwillContract();
                if (_tempSubjectContract != null)
                    if (this.State == JStateContractForm.Insert)
                        Set_Form(_tempSubjectContract);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }

        private void Fill_Data()
        {
            lbEstenkaf.Visible = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasEstenkafRight"]));
            txtEstenkafRight.Visible = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasEstenkafRight"]));
            lblPriceCancel.Visible = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasPriceCancel"]));
            txtPriceCancel.Visible = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasPriceCancel"]));
          
            Set_Form();
        }

        private void JContractPriceForm_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    lbEstenkaf.Visible = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasEstenkafRight"]));
                    txtEstenkafRight.Visible = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasEstenkafRight"]));
                    lblPriceCancel.Visible = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasPriceCancel"]));
                    txtPriceCancel.Visible = Convert.ToBoolean(Convert.ToInt16(ContractForms.Settings.Items["HasPriceCancel"]));
                }
                catch
                {
                }
                if ((ContractForms.Contract.Code != 0)) //&& (State != JStateContractForm.Update)
                {
                    Set_Form();
                    //State = JStateContractForm.Change;
                }
                else
                {
                    JContractDynamicType CDT = new JContractDynamicType();

                    if (this.ContractForms.Contract.Code == 0)
                    {
                        try
                        {
                            if (ContractForms.Contract.TotalPrice == 0)
                                txtPrice.Text = (new JAction("Price", ContractForms.Contract.ContractType.ClassName + ".GetPrice", new object[] { ContractForms.Contract.FinanceCode }, null).run()).ToString();
                            else
                                txtPrice.Text = this.ContractForms.Contract.TotalPrice.ToString();

                            txtCountPayment.Text = ContractForms.Contract.ContractType.InstallmentCount.ToString();
                            //txtPrice.Text = ContractForms.Contract.ContractType.AllPrice.ToString();
                            if (ContractForms.Contract.ContractType.RealPercent != 0)
                            {
                                lbRealPricePercent.Text = ContractForms.Contract.ContractType.RealPercent.ToString()+"%";
                                txtRealPrice.Text = (txtPrice.MoneyValue * ContractForms.Contract.ContractType.RealPercent / 100).ToString();
                            }
                            if (ContractForms.Contract.ContractType.InstallmentPercent != 0)
                            {
                                lbInstallmentPercent.Text = ContractForms.Contract.ContractType.InstallmentPercent.ToString() + "%";
                                txtInstallmentPrice.Text = (txtPrice.MoneyValue * ContractForms.Contract.ContractType.InstallmentPercent / 100).ToString();
                            }
                            if (ContractForms.Contract.ContractType.EndPricePercent != 0)
                            {
                                lbEndPercent.Text = ContractForms.Contract.ContractType.EndPricePercent.ToString() + "%";
                                txtEndPrice1.Text = (txtPrice.MoneyValue * ContractForms.Contract.ContractType.EndPricePercent / 100).ToString();
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JContractPriceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }

        public JKeyValue[] GetPropertiesList()
        {
            return JMainFrame.EnumToListBoxKey(typeof(PropertiesForm));
        }

        private void txtRealPrice_TextChanged(object sender, EventArgs e)
        {
            //if (txtCostUpToNow.Text == "")
              //  txtCostUpToNow.Text = txtRealPrice.Text;
        }

        private void txtStartPayment_Leave(object sender, EventArgs e)
        {
            if (txtStartPayment.Date != DateTime.MinValue)
                txtEndPayment.Date = JDateTime.GregorianDate(JDateTime.AddMonthFarsi(txtStartPayment.Text, txtCountPayment.IntValue));
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtRealPrice.Text =
                    (float.Parse(txtPrice.Text) *
                    (ContractForms.Contract.ContractType.RealPercent) * 1.0 / 100.0).ToString();
                txtCostUpToNow.Text = txtRealPrice.Text;
                txtInstallmentPrice.Text =
                                    (float.Parse(txtPrice.Text) *
                    ContractForms.Contract.ContractType.InstallmentPercent * 1.0 / 100.0).ToString();
                txtEndPrice1.Text =
                                        (float.Parse(txtPrice.Text) *
                        ContractForms.Contract.ContractType.EndPricePercent * 1.0 / 100.0).ToString();

            }
            catch
            {
            }

        }

        private void txtEndPrice1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
