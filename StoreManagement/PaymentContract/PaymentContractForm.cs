using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreManagement
{
    public partial class JPaymentContractForm : JBaseForm
    {
        DataTable _PayList;
        int _ContractCode;
        decimal _Tax = 0;
        decimal _Duty = 0;

        public JPaymentContractForm()
        {
            InitializeComponent();
        }
        public JPaymentContractForm(int pContractCode)
        {
            InitializeComponent();
            _ContractCode = pContractCode;
        }

        private void Fill()
        {
            jJanusGrid1.DataSource = JPaymentContract.GetDataTableByContract(_ContractCode);
            Calc();
        }

        private void Clear()
        {
            txtPrice.Text = "0";
            txtDate.Date = DateTime.MinValue;
            txtDesc.Text = "";
            txtMaksore.Text = "";

        }


        private void Calc()
        {
            _PayList = (DataTable)jJanusGrid1.DataSource;
            decimal Sum = 0;
            foreach (DataRow dr in _PayList.Rows)
               Sum = Sum + Math.Round(Convert.ToDecimal(dr["Pay"]),0);

            lblTotal.Text = JGeneral.MoneyStr(Sum.ToString());
            if (chkTax.Checked)
            {
                lblTax.Text = ((Convert.ToDecimal(txtPrice.Text) * (_Tax)) / 100).ToString();
                lblDuty.Text = ((Convert.ToDecimal(txtPrice.Text) * (_Duty)) / 100).ToString();
            }
            //lblTotalTax.Text = JGeneral.MoneyStr((Convert.ToDecimal(lblTax.Text) + Convert.ToDecimal(lblDuty.Text) + Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(txtDiscount.IntValue)).ToString());

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error(" تاریخ را وارد کنید ", "");
                    txtDate.Focus();
                    return;
                }
                if ((txtPrice.Text == "") || (txtPrice.Text == "0"))
                {
                    JMessages.Error(" قیمت را وارد کنید ", "");
                    txtPrice.Focus();
                    return;
                }
                #endregion

                _PayList = (DataTable)jJanusGrid1.DataSource;
                if (((_PayList != null) && (_PayList.Select(" PayDate='" + JDateTime.FarsiDate(txtDate.Date) + "' And Pay=" + Convert.ToDecimal(txtPrice.Text)).Length == 0)))
                {
                    JPaymentContract tmpPaymentContract = new JPaymentContract();
                    tmpPaymentContract.Pay = Math.Round(Convert.ToDecimal(txtPrice.Text));
                    tmpPaymentContract.Description = txtDesc.Text;
                    tmpPaymentContract.PayDate = txtDate.Date;
                    tmpPaymentContract.ContractCode = _ContractCode;
                    if (chkTax.Checked)
                    {
                        tmpPaymentContract.Tax = Convert.ToDecimal(lblTax.Text);
                        tmpPaymentContract.Duty = Convert.ToDecimal(lblDuty.Text);
                    }
                    else
                    {
                        tmpPaymentContract.Tax = 0;
                        tmpPaymentContract.Duty = 0;
                    }
                    tmpPaymentContract.TaxMaksore = Convert.ToDecimal(txtMaksore.Text);

                    if (tmpPaymentContract.Insert() > 0)
                    {
                        JMessages.Information(" درج با موفقیت انجام گردید ", "");
                        Clear();
                        Fill();
                        txtPrice.Focus();
                    }
                    else
                        JMessages.Error(" خطا در درج ", "");
                }
                else
                    JMessages.Error(" این پرداختی قبلا ثبت شده است ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (JMessages.Confirm("Are You Sure!", "Delete") == DialogResult.Yes)
                {
                    if (jJanusGrid1.SelectedRow != null)
                    {
                        JPaymentContract tmpPaymentContract = new JPaymentContract();
                        tmpPaymentContract.Code = Convert.ToInt32(jJanusGrid1.SelectedRows[0]["Code"].ToString());
                        if (tmpPaymentContract.Delete())
                        {
                            JMessages.Information(" حذف با موفقیت انجام گردید ", "");
                            Fill();
                        }
                        else
                            JMessages.Error(" عملیات حذف با مشکل مواجه شده است ", "");
                    }
                    else
                        JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JPaymentContractForm_Load(object sender, EventArgs e)
        {
            //_Tax = JBillGoods.GetTax();
            //_Duty = JBillGoods.GetDuty();
            Fill();
            txtMaksore.Focus();
        }

        private void chkTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTax.Checked)
                Calc();
            else
            {
                lblDuty.Text = "0";
                lblTax.Text = "0";
            }
        }

        private void txtMaksore_TextChanged(object sender, EventArgs e)
        {
            if (txtMaksore.Text != "")
                txtPrice.Text = Math.Round((Convert.ToDecimal(txtMaksore.Text) /3 * 100),0).ToString();
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            _Tax = JBillGoods.GetTax(Convert.ToInt32(txtDate.Text.Substring(0, 4)));
            _Duty = JBillGoods.GetDuty(Convert.ToInt32(txtDate.Text.Substring(0, 4)));
        }
    }
}
