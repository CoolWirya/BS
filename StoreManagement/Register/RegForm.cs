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
    public partial class RegForm : ClassLibrary.JBaseForm
    {
        int _Code;
        decimal _Tax = 0;
        decimal _Duty = 0;

        public RegForm()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            DataTable dt = Legal.JContractDynamicTypes.GetDataTable(0);

            #region CheckData
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error(" لطفا تاریخ را وارد کنید ", "");
                return;
            }
            if (jucPersonBuyer.SelectedCode == 0)
            {
                JMessages.Error(" لطفا خریدار را انتخاب کنید ", "");
                return;
            }
            if (jucPersonSeller.SelectedCode == 0)
            {
                JMessages.Error(" لطفا فروشنده را وارد کنید ", "");
                return;
            }
            if (jucPersonSeller.SelectedCode == jucPersonBuyer.SelectedCode)
            {
                JMessages.Error(" فروشنده و خریدار نمی توانند یکسان باشد  ", "");
                return;
            }
            #endregion

            JBillGoods tmpBillGoods = new JBillGoods();
            DataTable _ItemGoods;
            _ItemGoods = JBillListGoods.GetDataTable(-1);
            DataRow dr = _ItemGoods.NewRow();
            dr["Name"] = "";
                dr["ClassName"] = "StoreManagement.JGoods";
            dr["ObjectCode"] = -1;
            dr["Count"] = 1;
            dr["Price"] = Convert.ToDecimal(txtTotal.Text);
            dr["TotalPrice"] =  Convert.ToDecimal(txtTotal.Text);
            dr["Tax"] = ((Convert.ToDecimal(txtTotal.Text) * (_Tax)) / 100);
            dr["Duty"] = ((Convert.ToDecimal(txtTotal.Text) * (_Duty)) / 100);
            _ItemGoods.Rows.Add(dr);

            tmpBillGoods.ListOwner = _ItemGoods;

            tmpBillGoods.Serial = txtSerial.Text;
            tmpBillGoods.TankhahCode = txtTankhahCode.Text;
            tmpBillGoods.Description = txtDesc.Text;
            tmpBillGoods.RegDate = txtDate.Date;
            tmpBillGoods.Buyer = jucPersonBuyer.SelectedCode;
            tmpBillGoods.Seller = jucPersonSeller.SelectedCode;
            tmpBillGoods.BillType = Convert.ToInt32(cmbGroup.SelectedValue);
            tmpBillGoods.CreateDate = DateTime.Now;
            tmpBillGoods.Creator = JMainFrame.CurrentPersonCode;

            //if (chkTax.Checked)
            //{
            //    tmpBillGoods.Tax = ((Convert.ToDecimal(txtTotal.Text) * (_Tax)) / 100);
            //    tmpBillGoods.Duty = ((Convert.ToDecimal(txtTotal.Text) * (_Duty)) / 100);
            //}
            //else
            //{
            //    tmpBillGoods.Tax = 0;
            //    tmpBillGoods.Duty = 0;
            //}

            if (txtDiscount.Text != "")
                tmpBillGoods.Discount = Convert.ToDecimal(txtDiscount.Text);
            else
                tmpBillGoods.Discount = 0;

            if (rbNaghd.Checked)
                tmpBillGoods.StatePay = 1;
            if (rbNNaghd.Checked)
                tmpBillGoods.StatePay = 0;
            if (rbTogether.Checked)
                tmpBillGoods.StatePay = 2;

            if (State == JFormState.Insert)
            {
                if (tmpBillGoods.Find(tmpBillGoods.Serial, Convert.ToDecimal(txtTotal.Text), tmpBillGoods.Seller, tmpBillGoods.Buyer))
                {
                    JMessages.Error(" این فاکتور قبلا ثبت شده ", "");
                    return;
                }           
                 _Code = tmpBillGoods.Insert();
                if (_Code > 0)
                {
                    JMessages.Information(" درج با موفقیت انجام گردید ", "");
                    Clear();
                }
                else
                    JMessages.Error(" خطا در درج ", "");
            }
            else if (State == JFormState.Update)
            {
                tmpBillGoods.Code = _Code;
                if (tmpBillGoods.Update())
                {
                    JMessages.Information(" ویرایش با موفقیت انجام گردید ", "");
                }
                else
                    JMessages.Information(" خطا در ویرایش ", "");
            }
        }

        private void Clear()
        {
            cmbGroup.SelectedValue = -1;
            txtSerial.Text = "0";
            txtTankhahCode.Text = "0";
            txtDesc.Text = "";
            //txtDate.Date = DateTime.MinValue;
            jucPersonBuyer.SelectedCode = 120000000;
            jucPersonSeller.SelectedCode = 120000000;
            txtDiscount.Text = "0";
            txtSerial.Focus();
        }

        private void Set_Form()
        {
            try
            {
                JBillGoods tmpBillGoods = new JBillGoods(_Code);
                cmbGroup.SelectedValue = tmpBillGoods.BillType;
                txtSerial.Text = tmpBillGoods.Serial;
                txtTankhahCode.Text = tmpBillGoods.TankhahCode;
                txtDesc.Text = tmpBillGoods.Description;
                txtDate.Date = tmpBillGoods.RegDate;
                jucPersonBuyer.SelectedCode = tmpBillGoods.Buyer;
                jucPersonSeller.SelectedCode = tmpBillGoods.Seller;
                txtDiscount.Text = tmpBillGoods.Discount.ToString();
                if (tmpBillGoods.StatePay == 1)
                    rbNNaghd.Checked = true;
                if (tmpBillGoods.StatePay == 0)
                    rbNaghd.Checked = true;
                if (tmpBillGoods.StatePay == 2)
                    rbTogether.Checked = true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            try
            {
                //_Tax = JBillGoods.GetTax();
                //_Duty = JBillGoods.GetDuty();                

                JGoodsGroups tmpGoodsGroup = new JGoodsGroups();
                tmpGoodsGroup.SetComboBox(cmbGroup, -1);                

                if (_Code != 0)
                    Set_Form();
                else
                {
                    jucPersonBuyer.SelectedCode = 120000000;
                    jucPersonSeller.SelectedCode = 120000000;
                }
                txtSerial.Focus();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jucPersonSeller_Leave(object sender, EventArgs e)
        {
            txtTotal.Focus();
        }

        private void jucPersonBuyer_Leave(object sender, EventArgs e)
        {
            chkTax.Focus();
        }

        private void cmbGroup_Leave(object sender, EventArgs e)
        {
            jucPersonSeller.Focus();
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            _Tax = JBillGoods.GetTax(Convert.ToInt32(txtDate.Text.Substring(0, 4)));
            _Duty = JBillGoods.GetDuty(Convert.ToInt32(txtDate.Text.Substring(0, 4)));
        }
    }
}
