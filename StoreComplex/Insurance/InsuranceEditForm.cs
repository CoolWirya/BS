using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreComplex
{
    public partial class JInsuranceEditForm : Globals.JBaseForm
    {
        int ContractCode;
        int code;
        JInsurance _insurance;
        public JInsuranceEditForm(int pContractCode, int pCode)
        {
            InitializeComponent();
            ContractCode = pContractCode;
            code = pCode;
            _insurance = new JInsurance(code);
            if (code > 0)
            {
                ShowData();
            }
            else
            {
                txtStartDate.Date = DateTime.Now;
                txtEndDate.Date = DateTime.Now.AddYears(1);
            }
        }
        private void ShowData()
        {
            txtStartDate.Date = _insurance.StartDate;
            txtEndDate.Date = _insurance.ExpireDate;
            txtDesc.Text = _insurance.Description;
            txtGoodsCost.Text = _insurance.CostGoods.ToString();
            txtInsuranceCost.Text = _insurance.Price.ToString();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region Validate
            if (txtStartDate.Date == DateTime.MinValue)
            {
                JMessages.Error(" لطفا تاریخ شروع را وارد کنید ", "");
                txtStartDate.Focus();
                return;
            }
            if (txtEndDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ پایان را وارد کنید ", "");
                txtEndDate.Focus();
                return;
            }
            if (txtEndDate.Date < txtEndDate.Date)
            {
                JMessages.Error(" تاریخ پایان نمی تواند از تاریخ شروع کوچکتر باشد ", "");
                txtStartDate.Focus();
                return;
            } 
            #endregion Validate

            _insurance.ContractCode = ContractCode;
            _insurance.CostGoods = txtGoodsCost.DecimalValue;
            _insurance.Description = txtDesc.Text;
            _insurance.ExpireDate = txtEndDate.Date;
            _insurance.Price = txtInsuranceCost.DecimalValue;
            _insurance.StartDate = txtStartDate.Date;
            ///ویرایش
            if (code > 0)
            {
                if (_insurance.Update())
                    DialogResult = DialogResult.OK;
                else
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "خطا");
            }
            ///جدید
            else
            {
                if (_insurance.Insert() > 0)
                    DialogResult = DialogResult.OK;
                else
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "خطا");
            }
        }
    }
}
