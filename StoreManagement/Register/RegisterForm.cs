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
    public partial class JRegisterForm : ClassLibrary.JBaseForm
    {
        DataTable _Storages;
        DataTable _Prepayment;

        DataTable _ItemGoods;
        int _GoodsCode;
        string _GoodsName;
        public int _Code;
        decimal _Tax = 0;
        decimal _Duty = 0;

        public JRegisterForm()
        {
            InitializeComponent();
            ArchiveList.ClassName = "StoreManagement.JRegisterForm";
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
        }
        public JRegisterForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            ArchiveList.ClassName = "StoreManagement.JRegisterForm";
            ArchiveList.ObjectCode = _Code;
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
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
                txtDate_Leave(null, null);
                _ItemGoods = tmpBillGoods.ListOwner;
                if ((_ItemGoods != null) && (_ItemGoods.Rows.Count > 0))
                    if (Convert.ToDecimal(_ItemGoods.Rows[0]["Tax"].ToString()) != 0)
                        chkTax.Checked = true;
                _Storages = tmpBillGoods.StorageList;
                _Prepayment = tmpBillGoods.Prepayment;
                jdgvKala.DataSource = _ItemGoods;
                jdgvStorage.DataSource = _Storages;
                jdgvStorage.Columns["Code"].ReadOnly = true;
                jdgvStorage.Columns["Number"].ReadOnly = true;
                jdgvPrePayment.DataSource = _Prepayment;
                jdgvPrePayment.Columns["Code"].ReadOnly = true;
                jucPersonBuyer.SelectedCode = tmpBillGoods.Buyer;
                jucPersonSeller.SelectedCode = tmpBillGoods.Seller;
                txtDiscount.Text = tmpBillGoods.Discount.ToString();
                txtDocCode.Text = tmpBillGoods.DocNumber.ToString();
                txtDocDate.Date = tmpBillGoods.DocDate;

                if (tmpBillGoods.StatePay == 1)
                    rbNNaghd.Checked = true;
                if (tmpBillGoods.StatePay == 0)
                    rbNaghd.Checked = true;
                if (tmpBillGoods.StatePay == 2)
                    rbTogether.Checked = true;
                
                //lblTax.Text = tmpBillGoods.Tax.ToString();
                //lblDuty.Text = tmpBillGoods.Duty.ToString();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if ((cmbGoodName.SelectedItem == null) && (cmbService.SelectedItem == null))
                {
                    JMessages.Error(" لطفا آیتمی را انتخاب کنید ", "");
                    cmbGoodName.Focus();
                    return;
                }
                if ((txtGoodsCount.Text == "")||(txtGoodsCount.Text == "0"))
                {
                    JMessages.Error(" تعداد را وارد کنید ", "");
                    txtGoodsCount.Focus();
                    return;
                }
                if ((txtGoodsPrice.Text == "") || (txtGoodsPrice.Text == "0"))
                {
                    JMessages.Error(" قیمت را وارد کنید ", "");
                    txtGoodsPrice.Focus();
                    return;
                }
                #endregion

                if ((_GoodsCode != 0) &&
                    ((_ItemGoods != null) && (_ItemGoods.Select(" ObjectCode=" + _GoodsCode).Length == 0)))
                {
                    DataRow dr = _ItemGoods.NewRow();
                    dr["Name"] = _GoodsName;
                    if (rbGoods.Checked)
                    {
                        dr["ClassName"] = "StoreManagement.JGoods";
                        dr["ObjectCode"] = cmbGoodName.SelectedValue.ToString();
                        dr["Measure"] = lblUnit.Text;                        
                    }
                    else
                    {
                        dr["ClassName"] = "StoreManagement.JServices";
                        dr["ObjectCode"] = cmbService.SelectedValue.ToString();
                    }
                    dr["Count"] = Convert.ToDecimal(txtGoodsCount.Text);
                    dr["Price"] = Convert.ToDecimal(txtGoodsPrice.Text);
                    dr["TotalPrice"] = Math.Round((Convert.ToDecimal(txtGoodsCount.Text) * Convert.ToDecimal(txtGoodsPrice.Text)),0);
                    if (chkTax.Checked)
                    {
                        dr["Tax"] = Math.Round(((Convert.ToDecimal(dr["TotalPrice"]) * (_Tax)) / 100),0);
                        dr["Duty"] = Math.Round(((Convert.ToDecimal(dr["TotalPrice"]) * (_Duty)) / 100), 0);
                    }
                    _ItemGoods.Rows.Add(dr);
                    jdgvKala.DataSource = _ItemGoods;                    
                }
                else
                    JMessages.Error(" این کالا قبلا ثبت شده است ", "");
                if (cmbService.Enabled)
                    cmbService.Focus();
                else
                    cmbGoodName.Focus();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

        private void jJanusGrid1_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (e.Row.DataRow != null)
            {
                _GoodsName = ((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[1].ToString();
                _GoodsCode = Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[0]);
                btnAdd_Click(null, null);
                //DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvKala.CurrentRow != null)
                {
                    jdgvKala.Rows.Remove(jdgvKala.CurrentRow);
                    btnSave.Enabled = true;
                    Calc();
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ","");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error(" لطفا تاریخ را وارد کنید ", "");
                    return;
                }
                if (jdgvKala.Rows.Count == 0)
                {
                    JMessages.Error(" لطفا آیتمی را انتخاب کنید ", "");
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
                tmpBillGoods.Serial = txtSerial.Text;
                tmpBillGoods.TankhahCode = txtTankhahCode.Text;
                tmpBillGoods.Description = txtDesc.Text;
                tmpBillGoods.RegDate = txtDate.Date;
                tmpBillGoods.ListOwner = _ItemGoods;
                tmpBillGoods.StorageList = _Storages;
                tmpBillGoods.Prepayment = _Prepayment;
                tmpBillGoods.Buyer = jucPersonBuyer.SelectedCode;
                tmpBillGoods.Seller = jucPersonSeller.SelectedCode;
                tmpBillGoods.BillType = Convert.ToInt32(cmbGroup.SelectedValue);
                tmpBillGoods.CreateDate = DateTime.Now;
                tmpBillGoods.Creator = JMainFrame.CurrentPersonCode;
                tmpBillGoods.DocNumber = txtDocCode.IntValue;
                tmpBillGoods.DocDate = txtDocDate.Date;
                tmpBillGoods.Returned = false;

                if (txtDiscount.Text != "")
                    tmpBillGoods.Discount = Convert.ToDecimal(txtDiscount.Text);
                else
                    tmpBillGoods.Discount = 0;
                if (rbNaghd.Checked)
                    tmpBillGoods.StatePay = 1;
                if(rbNNaghd.Checked)
                    tmpBillGoods.StatePay = 0;
                if (rbTogether.Checked)
                    tmpBillGoods.StatePay = 2;

                if (State == JFormState.Insert)
                {
                    if (tmpBillGoods.Find(tmpBillGoods.Serial, Convert.ToDecimal(lblTotal.Text), tmpBillGoods.Seller, tmpBillGoods.Buyer))
                    {
                        JMessages.Error(" این فاکتور قبلا ثبت شده ", "");
                        return;
                    }
                    bool Rerurn=false;
                    if (_Code > 0)
                        Rerurn = true;
                    _Code = tmpBillGoods.Insert();
                    if (_Code > 0)
                    {
                        ArchiveList.ObjectCode = _Code;
                        ArchiveList.ArchiveList();
                        JMessages.Information(" درج با موفقیت انجام گردید ", "");

                        if (Rerurn == true)
                            Close();
                        Globals.JRegistry.Write("txtDate", txtDate.Date);
                        if (txtStorageResid.IntValue < 0)
                        {
                            //Globals.JRegistry.Write("txtStorageResid", txtStorageResid.Text);
                            txtStorageResid.Text = (txtStorageResid.IntValue - 1).ToString();
                        }
                    }
                    else
                        JMessages.Error(" خطا در درج ", "");
                }
                else if (State == JFormState.Update)
                {
                    tmpBillGoods.Code = _Code;

                    JBillGoods BillGoods = new JBillGoods();
                    BillGoods.GetData(_Code);
                    if (BillGoods.Creator != JMainFrame.CurrentPersonCode)
                    {
                        JMessages.Error(" فقط شخص ایجاد کننده فاکتور می تواند فاکتور را ویرایش کند ", "");
                        return;
                    }
                    tmpBillGoods.Creator = BillGoods.Creator;
                    tmpBillGoods.CreateDate = BillGoods.CreateDate;
                    tmpBillGoods.Returned = BillGoods.Returned;
                    if (tmpBillGoods.Update())
                    {
                        ArchiveList.ArchiveList();
                        JMessages.Information(" ویرایش با موفقیت انجام گردید ", "");
                    }
                    else
                        JMessages.Information(" خطا در ویرایش ", "");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JRegisterForm_Load(object sender, EventArgs e)
        {
            try
            {
                //_Tax = JBillGoods.GetTax();
                //_Duty = JBillGoods.GetDuty();
                cmbGoodName.DisplayMember = "Name";
                cmbGoodName.ValueMember = "Code";
                cmbGoodName.DataSource = JGoodss.GetDataTable(0);
                _GoodsCode = Convert.ToInt32(cmbGoodName.SelectedValue);

                JGoodsGroups tmpGoodsGroup = new JGoodsGroups();            
                tmpGoodsGroup.SetComboBox(cmbGroup, -1);

                JStorageTypes tmpStorageTypes = new JStorageTypes();
                tmpStorageTypes.SetComboBox(cmbStorage, -1);

                cmbService.DisplayMember = "Name";
                cmbService.ValueMember = "Code";
                cmbService.DataSource = JServicess.GetDataTable(0);

                _ItemGoods = JBillListGoods.GetDataTable(-1);
                jdgvKala.DataSource = _ItemGoods;
                _Storages = JStorageBill.GetDataTable(-1);
                jdgvStorage.DataSource = _Storages;
                _Prepayment = JPrepayment.GetDataTable(-1);
                jdgvPrePayment.DataSource = _Prepayment;

                _ItemGoods.Columns[0].ReadOnly = true;
                _ItemGoods.Columns[1].ReadOnly = true;
                jdgvKala.Columns["className"].Visible = false;
                jdgvKala.Columns["ObjectCode"].Visible = false;
                jdgvKala.Columns["BillGoodsCode"].Visible = false;
                jdgvKala.Columns["SumTaxDutyList"].Visible = false;
                jdgvKala.Columns["TotalPriceTaxDuty"].Visible = false;
                jdgvKala.Columns["TotalPriceDiscount"].Visible = false;
                jdgvKala.Columns[1].ReadOnly = true;
                jdgvKala.Columns["TotalPrice"].ReadOnly = true;
                jdgvKala.Columns["Tax"].ReadOnly = true;
                jdgvKala.Columns["Duty"].ReadOnly = true;
                jdgvKala.Columns["Code"].Visible = false;
                //jdgvKala.Columns["Measure"].Visible = false;
                jdgvStorage.Columns["StorageCode"].Visible = false;
                jdgvKala.Columns["DiscountList"].Visible = false;
                //jdgvPrePayment.Columns["BillGoodsCode"].Visible = false;
                if (_Code != 0)
                    Set_Form();
                else
                {
                    if (Globals.JRegistry.Read("txtDate") != null)
                        txtDate.Date = Convert.ToDateTime(Globals.JRegistry.Read("txtDate").ToString().Replace("ق.ظ", " ").Trim());//
                    //if (Globals.JRegistry.Read("txtStorageResid") != null)
                    //    txtStorageResid.Text = (Convert.ToInt32(Globals.JRegistry.Read("txtStorageResid")) - 1).ToString();
                    txtStorageResid.Text = JBillGoods.GetNumber().ToString();
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnableRB()
        {
            if (rbGoods.Checked)
            {
                //txtGoodsCount.Enabled = true;
                //txtGoodsPrice.Enabled = true;
                cmbGoodName.Enabled = true;
                //txtDiscount.Enabled = true;
                cmbService.Enabled = false;  
                cmbGoodName_SelectedIndexChanged(null, null);
            }
            else
            {
                //txtGoodsCount.Enabled = false;
                //txtGoodsPrice.Enabled = false;
                cmbGoodName.Enabled = false;
                //txtDiscount.Enabled = false;
                cmbService.Enabled = true;
                cmbService_SelectedIndexChanged(null, null);
            }
        }

        private void rbService_CheckedChanged(object sender, EventArgs e)
        {
            EnableRB();
        }

        private void rbGoods_CheckedChanged(object sender, EventArgs e)
        {
            EnableRB();
        }

        private void cmbGoodName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtGoodsPrice.Text = ((System.Data.DataRowView)(cmbGoodName.SelectedItem)).Row["Price"].ToString();
                _GoodsCode = Convert.ToInt32(((System.Data.DataRowView)(cmbGoodName.SelectedItem)).Row["Code"]);
                _GoodsName = ((System.Data.DataRowView)(cmbGoodName.SelectedItem)).Row["Name"].ToString();
                lblUnit.Text = ((System.Data.DataRowView)(cmbGoodName.SelectedItem)).Row["Measure"].ToString();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void Calc()
        {
            try
            {
                decimal Sum = 0;
                decimal Duty = 0;
                decimal Tax = 0;                
                foreach (DataRow dr in _ItemGoods.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if (chkTax.Checked)
                        {
                            dr["Tax"] = ((Convert.ToDecimal(dr["TotalPrice"]) * (_Tax)) / 100);
                            dr["Duty"] = ((Convert.ToDecimal(dr["TotalPrice"]) * (_Duty)) / 100);
                        }
                        else
                        {
                            dr["Tax"] = 0;
                            dr["Duty"] = 0;
                        }
                        Sum = Sum + Convert.ToDecimal(dr["TotalPrice"]);
                        if (dr["Duty"].ToString() != "")
                            Duty = Duty + Convert.ToDecimal(dr["Duty"]);
                        if (dr["Tax"].ToString() != "")
                            Tax = Tax + Convert.ToDecimal(dr["Tax"]);                        
                    }
                }
                lblTotal.Text = JGeneral.MoneyStr(Math.Round(Convert.ToDecimal(Sum),0).ToString());
                if (chkTax.Checked)
                {
                    lblTax.Text = Math.Round(Tax,0).ToString();// ((Convert.ToDecimal(lblTotal.Text) * (_Tax)) / 100).ToString();
                    lblDuty.Text = Math.Round(Duty,0).ToString();// ((Convert.ToDecimal(lblTotal.Text) * (_Duty)) / 100).ToString();
                }
                lblTotalTax.Text = JGeneral.MoneyStr(Math.Round((Convert.ToDecimal(lblTax.Text) + Convert.ToDecimal(lblDuty.Text) + Convert.ToDecimal(Sum) - Convert.ToDecimal(txtDiscount.IntValue)),0).ToString());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jdgvKala_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            Calc();
        }

        private void jdgvKala_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Calc();
        }

        private void jdgvKala_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Calc();
        }

        private void JRegisterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
                btnAdd_Click(null, null);
            if ((txtStorageResid.Focused == false)&&(e.KeyCode == Keys.Subtract))
                btnDel_Click(null, null);
            if (e.KeyCode == Keys.F2)
                btnSave_Click(null,null);
            else if (e.KeyCode == Keys.F3)
            {
                jucPersonBuyer.Focus();
                jucPersonBuyer.btnSearch_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                jucPersonSeller.Focus();
                jucPersonSeller.btnSearch_Click(null, null);
            }
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtGoodsPrice.Text = ((System.Data.DataRowView)(cmbService.SelectedItem)).Row["Price"].ToString();
                _GoodsCode = Convert.ToInt32(((System.Data.DataRowView)(cmbService.SelectedItem)).Row["Code"]);
                _GoodsName = ((System.Data.DataRowView)(cmbService.SelectedItem)).Row["Name"].ToString();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!(JPermission.CheckPermission("StoreManagement.JRegisterForm.btnConfirm_Click")))
                return;
            if (_Code > 0)
            {
                JBillGoods tmpBillGoods = new JBillGoods(_Code);
                tmpBillGoods.State = 1;
                if (tmpBillGoods.Update())
                    JMessages.Information(" ویرایش با موفقیت انجام گردید ", "");
                else
                    JMessages.Information(" خطا در ویرایش ", "");
            }
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

        private void FillCombo()
        {
            cmbGoodName.DisplayMember = "Name";
            cmbGoodName.ValueMember = "Code";
            cmbGoodName.DataSource = JGoodss.GetDataTable(0);

            cmbService.DisplayMember = "Name";
            cmbService.ValueMember = "Code";
            cmbService.DataSource = JServicess.GetDataTable(0);
        }

        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            JGoodsForm p = new JGoodsForm();
            p.ShowDialog();
            //if (p.ShowDialog() == DialogResult.OK)
                FillCombo();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            JServicesForm p = new JServicesForm();
            p.ShowDialog();
            //if (p.ShowDialog() == DialogResult.OK)
                FillCombo();
        }

        private void jucPersonSeller_Leave(object sender, EventArgs e)
        {
            cmbGoodName.Focus();
        }

        private void jucPersonBuyer_Leave(object sender, EventArgs e)
        {
            cmbGoodName.Focus();
        }

        private void btnAddStorage_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData

                if ((txtStorageResid.Text == "") || (txtStorageResid.Text == "0"))
                {
                    JMessages.Error(" شماره رسید را وارد کنید ", "");
                    txtGoodsCount.Focus();
                    return;
                }
                if (txtStorageDate.Date == DateTime.MinValue)
                {
                    JMessages.Error(" تاریخ را وارد کنید ", "");
                    txtGoodsPrice.Focus();
                    return;
                }
                if (Convert.ToInt32(txtStorageResid.Text) < 0)
                if (JStorageBill.Find(txtStorageResid.Text, txtTankhahCode.Text))
                {
                    JMessages.Error(" شماره رسید انبار تکراری است ", "");
                    txtStorageResid.Focus();
                    return;
                }
                #endregion

                if ((txtStorageResid.IntValue != 0) &&
                    ((_Storages != null) && (_Storages.Select(" Number=" + txtStorageResid.Text).Length == 0)))
                {
                    DataRow dr = _Storages.NewRow();
                    dr["Number"] = txtStorageResid.Text;
                    dr["Date"] = txtStorageDate.Text.ToString();
                    dr["Discount"] = Convert.ToInt32(txtDiscountStorage.Text);
                    dr["StorageCode"] = Convert.ToInt32(cmbStorage.SelectedValue);
                    dr["Description"] = txtStorageDesc.Text;
                    _Storages.Rows.Add(dr);
                    jdgvStorage.DataSource = _Storages;
                    jdgvStorage.Columns["Code"].ReadOnly = true;
                    jdgvStorage.Columns["Number"].ReadOnly = true;
                }
                else
                    JMessages.Error(" این رسید انبار قبلا ثبت شده است ", "");                
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

        private void btnAddPish_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (txtDatePish.Date == DateTime.MinValue)
                {
                    JMessages.Error(" تاریخ را وارد کنید ", "");
                    txtDatePish.Focus();
                    return;
                }
                if ((txtPricePish.Text == "") || (txtPricePish.Text == "0"))
                {
                    JMessages.Error(" قیمت را وارد کنید ", "");
                    txtPricePish.Focus();
                    return;
                }
                #endregion

                if (((_Prepayment != null) && (_Prepayment.Select(" Price=" +Convert.ToDecimal(txtPricePish.Text).ToString() + " And Date='" + txtDatePish.Date + "'").Length == 0)))
                {
                    DataRow dr = _Prepayment.NewRow();
                    dr["Date"] = txtDatePish.Text;
                    dr["Price"] = Convert.ToDecimal(txtPricePish.Text);
                    dr["Description"] = txtDescPish.Text.ToString();
                    _Prepayment.Rows.Add(dr);
                    jdgvPrePayment.DataSource = _Prepayment;
                    jdgvPrePayment.Columns["Code"].ReadOnly = true;
                }
                else
                    JMessages.Error(" این پیش پرداخت قبلا ثبت شده است ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

        private void Clear()
        {
            try
            {
                txtSerial.Text = "";
                //txtTankhahCode.Text = "";
                txtDesc.Text = "";
                txtDiscount.Text = "0";
                _ItemGoods = JBillListGoods.GetDataTable(-1);
                jdgvKala.DataSource = _ItemGoods;
                _Storages = JStorageBill.GetDataTable(-1);
                jdgvStorage.DataSource = _Storages;
                _Prepayment = JPrepayment.GetDataTable(-1);
                jdgvPrePayment.DataSource = _Prepayment;
                jucPersonBuyer.SelectedCode = 120000000;
                jucPersonSeller.SelectedCode = 120000000;
                lblDuty.Text = "0";
                lblTax.Text = "0";
                lblTotal.Text = "0";
                lblTotalTax.Text = "0";
                _Code = 0;
                _GoodsCode = 0;
                _GoodsName = "";
                State = JFormState.Insert;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
                Close();
            }
        }

        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            Calc();
            //lblTotalTax.Text = (Convert.ToDecimal(lblTotalTax.Text) - txtDiscount.IntValue).ToString();
        }

        private void JRegisterForm_Shown(object sender, EventArgs e)
        {
            txtSerial.Focus();
        }

        private void jdgvKala_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_ItemGoods.Rows.Count > 0)
            {
                _ItemGoods.Rows[e.RowIndex]["TotalPrice"] = Convert.ToDecimal(_ItemGoods.Rows[e.RowIndex]["Count"]) * Convert.ToDecimal(_ItemGoods.Rows[e.RowIndex]["Price"]);
                Calc();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Code == 0)
                {
                    JMessages.Error(" ابتدا فاکتور را ثبت کنید ", "");
                    return;
                }
                DataTable dtinfo = new DataTable();
                dtinfo.Columns.Add("Year");
                dtinfo.Columns.Add("Season");
                dtinfo.Columns.Add("TotalPriceWord");
                dtinfo.Columns.Add("SumTotalPrice", typeof(Decimal));
                dtinfo.Columns.Add("SumTax", typeof(Decimal));
                dtinfo.Columns.Add("SumDuty", typeof(Decimal));
                dtinfo.Columns.Add("TotalPriceTax", typeof(Decimal));
                dtinfo.Columns.Add("SumTaxDuty", typeof(Decimal));
                dtinfo.Columns.Add("SumTotalPriceDiscount", typeof(Decimal));

                string str = "";
                string Year = "";
                string TotalPriceWord = "";

                if (txtDate.Date != DateTime.MinValue)
                    Year = (JDateTime.FarsiDate(txtDate.Date).Split('/'))[0];

                DataTable _DtReport = JBillGoodss.Search(" And Code =" + _Code);

                decimal SumTax = 0;
                decimal Sum = 0;
                int Tax = 0;
                int Duty = 0;
                int Discount = 0;
                foreach (DataRow dr in _DtReport.Rows)
                {
                    if (dr["TotalPrice"].ToString() != "")
                        Sum = Sum + Convert.ToInt32(dr["TotalPrice"]);
                    if (dr["Tax"].ToString() != "")
                        Tax = Tax + Convert.ToInt32(dr["Tax"]);
                    if (dr["Duty"].ToString() != "")
                        Duty = Duty + Convert.ToInt32(dr["Duty"]);
                    if (dr["TotalPriceTax"].ToString() != "")
                        SumTax = SumTax + Convert.ToDecimal(dr["TotalPriceTax"]);
                    if (dr["Discount"].ToString() != "")
                        Discount = Discount + Convert.ToInt32(dr["Discount"]);
                }
                JGeneral tmp = new JGeneral();
                TotalPriceWord = tmp.GetStringNumber((Math.Round(Sum + Tax + Duty - Discount)).ToString());

                dtinfo.Rows.Add(Year, str, TotalPriceWord, Math.Round(Sum), Tax, Duty, Math.Round(Sum + Tax + Duty - Discount), Tax + Duty, Math.Round(Sum - Discount));

                DataTable dtListGoods = JBillListGoods.GetDataTable(0);
                dtListGoods.TableName = " لیست کالاها ";
                //JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.BillGoods.GetHashCode());
                JDynamicReports DRF = new JDynamicReports(JReportDesignCodes.BillGoods.GetHashCode());

                DRF.Add(_DtReport);
                DRF.Add(dtListGoods);
                dtinfo.TableName = "اطلاعات پایه";
                DRF.Add(dtinfo);
                if (_Preview)
                {
                    DRF.Print("چاپ فاکتور", true, false);
                    _Preview = false;
                }
                else
                {
                    DRF.Print("چاپ فاکتور", false, false);
                    //DRF.ShowDialog();

                    Clear();
                    txtSerial.Focus();
                }
            } 
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
                Close();
            }
        }

        private void btnDelStorage_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvStorage.CurrentRow != null)
                {
                    jdgvStorage.Rows.Remove(jdgvStorage.CurrentRow);
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelPish_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvPrePayment.CurrentRow != null)
                {
                    jdgvPrePayment.Rows.Remove(jdgvPrePayment.CurrentRow);
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        bool _Preview = false;
        private void btnPerPrint_Click(object sender, EventArgs e)
        {
            _Preview = true;
            btnPrint_Click(null,null);           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            txtSerial.Focus();
        }

        private void jdgvStorage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (jdgvStorage.CurrentRow != null)
                {
                    txtStorageResid.Text = jdgvStorage.CurrentRow.Cells["Number"].Value.ToString();
                    txtStorageDate.Text = jdgvStorage.CurrentRow.Cells["Date"].Value.ToString();
                    txtStorageDesc.Text = jdgvStorage.CurrentRow.Cells["Description"].Value.ToString();
                    txtDiscountStorage.Text = jdgvStorage.CurrentRow.Cells["Discount"].Value.ToString();
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jdgvPrePayment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (jdgvPrePayment.CurrentRow != null)
                {
                    txtPricePish.Text = jdgvPrePayment.CurrentRow.Cells["Price"].Value.ToString();
                    txtDatePish.Text = jdgvPrePayment.CurrentRow.Cells["Date"].Value.ToString();
                    txtDescPish.Text = jdgvPrePayment.CurrentRow.Cells["Description"].Value.ToString();
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            _Tax = JBillGoods.GetTax(Convert.ToInt32(txtDate.Text.Substring(0,4)));
            _Duty = JBillGoods.GetDuty(Convert.ToInt32(txtDate.Text.Substring(0, 4)));
        }
    }
}


