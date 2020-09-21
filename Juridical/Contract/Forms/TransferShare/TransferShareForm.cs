using ClassLibrary;
using Finance;
using ManagementShares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legal
{
    public partial class JContractTransferShareForm : JBaseContractForm
    {

        private DataTable sheets;
        public JContractTransferShareForm()
        {
            InitializeComponent();
            TransferSheet = new ManagementShares.JTransferSheet();
        }

        public JContractTransferShareForm MakeForm()
        {
            JContractTransferShareForm form = new JContractTransferShareForm();
            return form;
        }

        #region Methods

      public bool CheckData()
        {
            try
            {
                if (State == JStateContractForm.View || State== JStateContractForm.Update) return true;
                #region Validate
                if (JDateTime.GregorianDate(txtDate.Text, txtTime.Text) == DateTime.MinValue)
                {
                    JMessages.Error("لطفاً تاریخ و ساعت را بصورت صحیح وارد کنید.", "خطا");
                    return false;
                }
                //if (txtPrice.FloatValue == 0)
                //{
                //    JMessages.Error("لطفاً قیمت کل را وارد کنید.", "خطا");
                //    return false;
                //}
                //if (txtShIndex.Text == "")
                //{
                //    JMessages.Error("لطفاً شماره ردیف را وارد کنید.", "خطا");
                //    return false;
                //}
                //if (txtShNote.Text == "")
                //{
                //    JMessages.Error("لطفاً شماره دفتر را وارد کنید.", "خطا");
                //    return false;
                //} 
                //if (txtTax.Text == "")
                //{
                //    JMessages.Error("لطفاً مالیات را وارد کنید.", "خطا");
                //    return false;
                //}  

                //if (JTransferSheet.FindTranfer(txtShNote.Text, txtShIndex.Text))
                //{
                //    JMessages.Error("شماره دفتر و شماره ردیف تکراری است.", "خطا");
                //    return false;
                //}
                  
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error("لطفا تاریخ انتقال را وارد کنید.", "خطا");
                    return false;
                }
                #endregion Validate
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        //public override bool SavePreview(DataTable pDt)
        //{
        //    try
        //    {
        //        //pDt.Rows[0]["Guarantee"] = txtGuarantee.Text;
        //        //pDt.Rows[0]["Condition"] = txtCondition.Text;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //        return false;
        //    }
        //}

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
            int transferCode = TransferSheet.Insert(tempdb);
            ContractForms.Contract.ShareTransferCode = transferCode;
            return (transferCode > 0 && ContractForms.Contract.Update(tempdb));
        }

        public ManagementShares.JTransferSheet TransferSheet;
        public bool ApplyData()
        {
            try
            {
                TransferSheet.SCode = Convert.ToInt32(((DataTable)grdSheets.DataSource).Rows[0]["SCode"]);
                TransferSheet.Price = txtPrice.DecimalValue;
                TransferSheet.TDate = JDateTime.GregorianDate(txtDate.Text, txtTime.Text);
                TransferSheet.FPCode = Convert.ToInt32(ContractForms.Contract.T1Person.Rows[0]["PersonCode"]);
                TransferSheet.Mosalehe = chMosalehe.Checked;
                TransferSheet.ShIndex = txtShIndex.IntValue;
                TransferSheet.ShNote = txtShNote.Text;
                TransferSheet.SPCode = Convert.ToInt32(ContractForms.Contract.T2Person.Rows[0]["PersonCode"]);
                TransferSheet.Tax = txtTax.MoneyValue;
                TransferSheet.Agent = chAgent.Checked;
                TransferSheet.Confirmed = false;
                TransferSheet.TranSum = Convert.ToInt32((grdSheets.Rows[0].Cells["SaleShareCount"].Value));
 
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
                  pDt.Columns.Add("SaleShareCountString");
                  pDt.Columns.Add("ShareTotalPrice");
                  pDt.Columns.Add("ShareTotalPriceString");
                  pDt.Columns.Add("TransferDate");
                  pDt.Columns.Add("Tax");
                  pDt.Columns.Add("TaxString");
                  pDt.Columns.Add("SaleShareCount");
                  if (pSetValue)
                  {
                      pDt.Rows[0]["ShareTotalPrice"] = txtPrice.Text;
                      pDt.Rows[0]["ShareTotalPriceString"] = JMoney.NumberToString(JMoney.RemoveMoney(txtPrice.Text));
                      pDt.Rows[0]["TransferDate"] = txtDate.Text;
                      pDt.Rows[0]["Tax"] = txtTax.Text;
                      pDt.Rows[0]["TaxString"] = JMoney.NumberToString(JMoney.RemoveMoney(txtTax.Text));
                      pDt.Rows[0]["SaleShareCount"] = Convert.ToInt32(((DataTable)grdSheets.DataSource).Rows[0]["SaleShareCount"]);
                      pDt.Rows[0]["SaleShareCountString"] = JMoney.NumberToString((((DataTable)grdSheets.DataSource).Rows[0]["SaleShareCount"]).ToString());
                     
                  }
                  return true;
              }
              catch (Exception ex)
              {
                  JSystem.Except.AddException(ex);
                  return false;
              }
          }

        #endregion

        private void JContractTransferShareForm_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (sheets != null) return;

                if (ContractForms.Contract.ShareTransferCode > 0)
                {
                    State = JStateContractForm.Update;
                    ManagementShares.JTransferSheet transefer = new ManagementShares.JTransferSheet(ContractForms.Contract.ShareTransferCode);
                    txtDate.Date = transefer.TDate; txtTime.Text = transefer.TDate.ToString("HH:mm");
                    txtPrice.Text = transefer.Price.ToString();
                    txtShIndex.Text = transefer.ShIndex.ToString();
                    txtShNote.Text = transefer.ShNote;
                    txtTax.Text = transefer.Tax.ToString();
                    chAgent.Checked = transefer.Agent;
                    chMosalehe.Checked = transefer.Mosalehe;


                    ManagementShares.JTransferSheet TS = new JTransferSheet(ContractForms.Contract.ShareTransferCode);
                    sheets = JShareSheet.GetSheets(TS.SCode, false);
                    grdSheets.DataSource = sheets;
                    sheets.Columns.Add("SaleShareCount", typeof(int)).SetOrdinal(0);
                    sheets.Rows[0]["SaleShareCount"] = TS.TranSum;

                }
                else
                {
                    txtDate.Date = ContractForms.Contract.Date; txtTime.Text = DateTime.Now.ToString("HH:mm");
                    JAsset asset = new JAsset(ContractForms.Contract.FinanceCode);
                    JShareSheet sheet = new JShareSheet(asset.ObjectCode);
                    sheets = JShareSheet.GetSheets(sheet.Code);
                    grdSheets.DataSource = sheets;
                    sheets.Columns.Add("SaleShareCount", typeof(int)).SetOrdinal(0);
                    sheets.Rows[0]["SaleShareCount"] = sheets.Rows[0]["ShareCount"];
                    //txtPrice.Text = sheets.Rows[0]["ShareCost"].ToString();
                }
                if (State == JStateContractForm.View)
                {
                    txtDate.ReadOnly = true; txtTime.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                    txtShIndex.ReadOnly = true;
                    txtShNote.ReadOnly = true;
                    txtTax.ReadOnly = true;
                    chAgent.Enabled = false;
                    chMosalehe.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
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

        private void JContractTransferShareForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }

        private void JContractTransferShareForm_Load(object sender, EventArgs e)
        {
            try
            //if (JContractPropertiesForm.CheckPrperties(this.GetType().FullName, PropertiesForm.GetLastContractData.ToString(), ContractForms.Contract.ContractType.Code))
            {
                //JSubjectContract _tempSubjectContract = ContractForms.Contract.GetLastGoodwillContract();
                //if (_tempSubjectContract != null)
                //  if (this.State == JStateContractForm.Insert)
                //    Set_Form(_tempSubjectContract);
                txtPriceBase.Text = JMainFrame.GetKeyValue(".JContractTransferShareForm.txtPriceBase").ToString();
                if (txtPriceBase.Text.Length > 0)
                {
                    try
                    {
                        txtPrice.Text = ((int)((DataTable)grdSheets.DataSource).Rows[0]["SaleShareCount"] * int.Parse(txtPriceBase.Text.Replace(",", "").Replace(".", ""))).ToString();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void grdSheets_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(grdSheets[e.ColumnIndex, e.RowIndex].Value) > Convert.ToInt32(grdSheets.Rows[e.RowIndex].Cells["ShareCount"].Value))
            {
                JMessages.Error("سهم قابل فروش باید کمتر از سهم فعلی باشد.", "error");
            }
            else
            {
                ((DataTable)grdSheets.DataSource).Rows[0]["SaleShareCount"] = 
                    grdSheets[e.ColumnIndex, e.RowIndex].Value;
                ((DataTable)grdSheets.DataSource).AcceptChanges();
                int PriceBase = 0;
                int.TryParse(txtPriceBase.Text, out PriceBase);
                txtPrice.Text = ((int)grdSheets[e.ColumnIndex, e.RowIndex].Value * PriceBase).ToString();
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            decimal i = 0;
            if (decimal.TryParse(txtPrice.Text, out i))
                ContractForms.Contract.TotalPrice = decimal.Parse(txtPrice.Text);
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
            try
            {
                ContractForms.Cancel();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        private void txtPriceBase_TextChanged(object sender, EventArgs e)
        {
            JMainFrame.SetKeyValue(".JContractTransferShareForm.txtPriceBase", txtPriceBase.Text);
            if (txtPriceBase.Text.Length > 0)
            {
                try
                {
                    txtPrice.Text = ((int)((DataTable)grdSheets.DataSource).Rows[0]["SaleShareCount"] * int.Parse(txtPriceBase.Text.Replace(",","").Replace(".",""))).ToString();
                }
                catch
                {
                }
            }

        }

    }
}
