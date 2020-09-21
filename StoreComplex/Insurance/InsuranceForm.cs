using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreComplex.Insurance
{
    public partial class InsuranceForm : ClassLibrary.JBaseForm
    {
        int _Code;
        int _ContractCode;
        DataTable _ItemInsurance;

        public InsuranceForm()
        {
            InitializeComponent();
        }

        public InsuranceForm(int pContractCode)
        {
            InitializeComponent();
            _ContractCode = pContractCode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region CheckData
            if (txtStartDate.Date == DateTime.MinValue)
            {
                JMessages.Error(" تاریخ شروع را وارد کنید ","");
                txtStartDate.Focus();
                return;
            }
            if (txtEndDate.Date == DateTime.MinValue)
            {
                JMessages.Error(" تاریخ پایان را وارد کنید ", "");
                txtEndDate.Focus();
                return;
            }
            if (txtEndDate.Date < txtEndDate.Date)
            {
                JMessages.Error(" تاریخ پایان نمی تواند از تاریخ شروع کوچکتر باشد ", "");
                txtStartDate.Focus();
                return;
            }
            #endregion

            try
            {                
                if (((_ItemInsurance != null) && (_ItemInsurance.Select(" StartDate='" + txtStartDate.Date + "'").Length == 0)))
                {
                    DataRow dr = _ItemInsurance.NewRow();
                    dr["CostGoods"] = txtCostGoods.Text;
                    dr["Price"] = txtbimePrice.Text;
                    dr["StartDate"] = (txtStartDate.Text);
                    dr["EndDate"] = txtEndDate.Text;
                    dr["Description"] = txtDesc.Text;
                    _ItemInsurance.Rows.Add(dr);
                    jdgvInsurance.DataSource = _ItemInsurance;
                }
                else
                {
                    JMessages.Error(" این تاریخ بیمه قبلا ثبت شده است ", "");
                    txtStartDate.Focus();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

    }
}
