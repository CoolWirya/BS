using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;


namespace ManagementShares
{
    public partial class JTransferSheetForm : ClassLibrary.JBaseForm
    {
        int[] SCodes;
        int CompanyCode = 0;
        int PersonCode;
        int TransferCode;
        bool FormStateIsUpdate = false;
        public JTransferSheetForm(int[] sCodes)
        {
            InitializeComponent();
            txtShNote.TextChanged += new EventHandler(TxtShNote_TextChanged);
            jPropertyValueUserControl1.ClassName = "ManagementShares.JTransferSheetForm";
            jPropertyValueUserControl1.ObjectCode = 0;
            jArchiveList1.ClassName = "ManagementShares.JTransferSheetForm";
            SCodes = sCodes;
            personSeller.ReadOnly = true;
            SetGrid(true);
            //SetRow();
            if (sCodes.Length > 0)
            {
                JShareSheet S = new JShareSheet(SCodes[0]);
                CompanyCode = S.CompanyCode;
                personBuyer.CompanyCode = S.CompanyCode;
                personSeller.CompanyCode = S.CompanyCode;
            }
            chMosalehe.CheckedChanged += chMosalehe_CheckedChanged;
        }

        private void TxtShNote_TextChanged(object sender, EventArgs e)
        {
            SetRow(txtShNote.IntValue);
        }

        void chMosalehe_CheckedChanged(object sender, EventArgs e)
        {
            if (chMosalehe.Checked)
                txtPrice.Text = "0";
            txtPrice.Enabled = !chMosalehe.Checked;
        }

        public JTransferSheetForm(int pCode, int PCompanyCode, string pclass = "")
        {
            InitializeComponent();
            txtShNote.TextChanged += new EventHandler(TxtShNote_TextChanged);
            jPropertyValueUserControl1.ClassName = "ManagementShares.JTransferSheetForm";
            jPropertyValueUserControl1.ObjectCode = 0;
            jArchiveList1.ClassName = "ManagementShares.JTransferSheetForm";
            CompanyCode = PCompanyCode;
            PersonCode = pCode;

            SetGrid(false);

            personSeller.ReadOnly = true;
            personBuyer.CompanyCode = PCompanyCode;
            personSeller.CompanyCode = PCompanyCode;
        }


        public void SetRow(int pShNote)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select isnull(max(cast(ShIndex as int)),0)+1 as ShIndex,isnull(max(cast(ShNote as int)),0) as ShNote from ShareTransfer st
inner join ShareSheet ss on st.scode=ss.Code
where  ShNote="+pShNote+" and ss.CompanyCode=" + CompanyCode.ToString());
                DataTable dt = db.Query_DataTable();
                //txtShNote.Text = dt.Rows[0]["ShNote"].ToString();
                this.txtShIndex.Text = dt.Rows[0]["ShIndex"].ToString();
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
        }

        public JTransferSheetForm(int sCode, int pTransferCode)
        {
            InitializeComponent();
            TransferCode = pTransferCode;
            SetGrid(true);
            DataTable sheets = JShareSheet.GetSheets(sCode);
            grdSheets.DataSource = sheets;
            personSeller.ReadOnly = true;
            if(!ClassLibrary.JMainFrame.IsAdmin)
                btnSave.Enabled = false;
            FormStateIsUpdate = true;
            JTransferSheet transfer = new JTransferSheet(pTransferCode);
            //personBuyer.SearchOnCode = SearchOnCode.Code;
            personBuyer.SelectedCode = transfer.SPCode;
            personSeller.SelectedCode = transfer.FPCode;
            txtDate.Date = transfer.TDate;
            txtPrice.Text = transfer.Price.ToString();
            txtShIndex.Text = transfer.ShIndex.ToString();
            txtShNote.Text = transfer.ShNote;
            txtTax.Text = transfer.Tax.ToString();
            chAgent.Checked = transfer.Agent;
            chMosalehe.Checked = transfer.Mosalehe;
            CompanyCode = transfer.CompanyCode;
        }


        private void SetGrid(bool withSCode)
        {
            try
            {
                DataTable sheets;
                if (withSCode)
                {
                    sheets = JShareSheet.GetSheets(SCodes,true,true);
                }
                else
                {
                    sheets = JShareSheet.GetSheets(JShareSheet.GetCodeSheetPerson(PersonCode, CompanyCode),true,true);
                    SCodes = JDataBase.DataTableToIntArray(sheets, "Code");
                }
                sheets.Columns.Add("SaleShareCount", typeof(int)).SetOrdinal(0);
                grdSheets.DataSource = sheets;
                foreach (DataGridViewColumn col in grdSheets.Columns)
                {
                    if (col.Name != "SaleShareCount")
                        col.ReadOnly = true;
                }
                int TempSell = 0;
                foreach (DataRow row in sheets.Rows)
                {
                    TempSell += (int)row["ShareCount"];
                    if (sheets.Rows.Count == 1)
                    {
                        row["SaleShareCount"] = row["ShareCount"];
                    }
                    else if (sheets.Rows.Count > 1)
                    {
                        row["SaleShareCount"] = 0;
                    }
                }
                TxTSellShare.Text = "0";// TempSell.ToString();
                personSeller.SelectedCode = Convert.ToInt32(sheets.Rows[0]["PCode"]);
            }
            catch (Exception ex)
            {

            }
        }
        private void SetGridByPerson(int pCode, int PCompanyCode)
        {
            try
            {
                DataTable sheets = JShareSheet.GetSheets(JShareSheet.GetCodeSheetPerson(pCode, PCompanyCode));
                sheets.Columns.Add("SaleShareCount", typeof(int)).SetOrdinal(0);
                grdSheets.DataSource = sheets;
                foreach (DataGridViewColumn col in grdSheets.Columns)
                {
                    if (col.Name != "SaleShareCount")
                        col.ReadOnly = true;
                }
                int TempSell = 0;
                foreach (DataRow row in sheets.Rows)
                {
                    row["SaleShareCount"] = row["ShareCount"];
                    TempSell += (int)row["ShareCount"];
                }
                TxTSellShare.Text = TempSell.ToString();
                personSeller.SelectedCode = Convert.ToInt32(sheets.Rows[0]["PCode"]);
            }
            catch (Exception ex)
            {

            }
        }

        private void jucPerson1_AfterCodeSelected(object Sender, EventArgs e)
        {
            ///          DataTable sheets =JShareSheet.GetPersonSheet(personSeller.SelectedCode);
            //    sheets.Columns.Add("ShareCount", typeof(int));
            //    sheets.Columns.Add("Selected", typeof(bool));
            //      grdSheets.DataSource = sheets;
            //    foreach (DataGridViewColumn col in grdSheets.Columns)
            //    {
            //        if (col.Name != "ShareCount")
            //            col.ReadOnly = true;
            //    }
        }
        public int ResultCode;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FormStateIsUpdate)
            {
                JTransferSheet transfer1 = new JTransferSheet(TransferCode);
                transfer1.Price = txtPrice.MoneyValue;
                transfer1.ShIndex = txtShIndex.IntValue;
                transfer1.ShNote = txtShNote.Text;
                transfer1.Tax = txtTax.MoneyValue;
                transfer1.Update(null);
                return;
            }

            #region Validate
            if (JDateTime.GregorianDate(txtDate.Text, txtTime.Text) == DateTime.MinValue)
            {
                JMessages.Error("لطفاً تاریخ و ساعت را بصورت صحیح وارد کنید.", "خطا");
                return;
            }
            if (txtPrice.FloatValue == 0 && txtPrice.Enabled)
            {
                JMessages.Error("لطفاً قیمت کل را وارد کنید.", "خطا");
                return;
            }
            if (txtShIndex.Text == "")
            {
                JMessages.Error("لطفاً شماره ردیف را وارد کنید.", "خطا");
                return;
            }
            if (txtShNote.Text == "")
            {
                JMessages.Error("لطفاً شماره دفتر را وارد کنید.", "خطا");
                return;
            }
            if (txtTax.Text == "")
            {
                JMessages.Error("لطفاً مالیات را وارد کنید.", "خطا");
                return;
            }
            if (personBuyer.IsBlock || personBuyer.IsDied)
            {
                JMessages.Error("خریدار معتبر نیست.", "خطا");
                return;
            }
            if (personSeller.IsBlock)
            {
                JMessages.Error("فروشنده معتبر نیست.", "خطا");
                return;
            }

            if (JTransferSheet.FindTranfer(txtShNote.Text, txtShIndex.Text, this.CompanyCode))
            {
                JMessages.Error("شماره دفتر و شماره ردیف تکراری است.", "خطا");
                return;
            }
            DataTable sheets = JShareSheet.GetSheets(SCodes);
            int pCode = Convert.ToInt32(sheets.Rows[0]["PCode"]);
            foreach (DataRow row in sheets.Rows)
            {
                if (pCode != Convert.ToInt32(row["PCode"]))
                {
                    JMessages.Error("فروشنده برگه های سهم باید یکی باشد.", "خطا");
                    tabControl1.SelectedTab = tabPage1;
                    return;
                }
            }
            if (personBuyer.SelectedCode == 0)
            {
                JMessages.Error("لطفا سهامدار جدید را انتخاب کنید.", "خطا");
                tabControl1.SelectedTab = tabPage1;
                return;
            }
            if (personBuyer.SelectedCode == personSeller.SelectedCode)
            {
                JMessages.Error("لطفا سهامدار جدید را انتخاب کنید.", "خطا");
                tabControl1.SelectedTab = tabPage1;
                return;
            }
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ انتقال را وارد کنید.", "خطا");
                //tabControl1.SelectedTab = tabInfo;
                return;
            }
            #endregion Validate
            //int a = CompanyCode;
            JTransferSheet transfer = new JTransferSheet();
            transfer.TDate = JDateTime.GregorianDate(txtDate.Text, txtTime.Text);
            transfer.FPCode = pCode;
            transfer.Mosalehe = chMosalehe.Checked;
            transfer.Price = txtPrice.MoneyValue;
            transfer.ShIndex = txtShIndex.IntValue;
            transfer.ShNote = txtShNote.Text;
            transfer.SPCode = personBuyer.SelectedCode;// ManagementShares.ShareCompany.JSharepCode.GetPersonShare(personBuyer.CompanyCode, personBuyer.txtExportCode.IntValue);
            transfer.CompanyCode = personBuyer.CompanyCode;
            transfer.Tax = txtTax.MoneyValue;
            transfer.Agent = chAgent.Checked;
            transfer.Confirmed = true;

            int CompanyCode = 0;
            try
            {

                foreach (DataGridViewRow row in grdSheets.Rows)
                {

                    int sheetCode = Convert.ToInt32(row.Cells["Code"].Value);
                    int shareCount = Convert.ToInt32(row.Cells["SaleShareCount"].Value);
                    if (shareCount > 0)
                    {
                        JShareSheet sheet = new JShareSheet(sheetCode);
                        CompanyCode = sheet.CompanyCode;
                        int TransferCode = 0;
                        ResultCode = sheet.TransferSheet(shareCount, personBuyer.SelectedCode, transfer, null, true, ref TransferCode);
                        if (ResultCode == 0)
                            throw new Exception();
                        jPropertyValueUserControl1.ValueObjectCode = TransferCode;
                        jPropertyValueUserControl1.Save();
                        jArchiveList1.ObjectCode = TransferCode;
                        jArchiveList1.ArchiveList();
                    }
                }
                ShareCompany.JSharepCode SP = new ShareCompany.JSharepCode();
                SP.Insert(CompanyCode, personBuyer.SelectedCode);

                JMessages.Information("عملیات انتقال با موفقیت انجام شد.", "");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
            }
        }

        private void grdSheets_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(grdSheets[e.ColumnIndex, e.RowIndex].Value) > Convert.ToInt32(grdSheets.Rows[e.RowIndex].Cells["ShareCount"].Value))
            {
                JMessages.Error("سهم قابل فروش باید کمتر از سهم فعلی باشد.", "error");
                grdSheets[e.ColumnIndex, e.RowIndex].Value = 0;
            }
            else
            {
            }
            TxTSellShare.Text = ChangeTXT().ToString();
        }

        private int ChangeTXT()
        {
            int count = 0;
            for (int i = 0; i < grdSheets.RowCount; i++)
            {
                count += (int)grdSheets["SaleShareCount", i].Value;
            }
            return count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JTransferSheetForm_Shown(object sender, EventArgs e)
        {
            DateTime currentDate = (new JDataBase()).GetCurrentDateTime();
            txtDate.Text = JDateTime.FarsiDate(currentDate);
            txtTime.Text = currentDate.ToString("HH:mm");
        }

        private void personBuyer_Load(object sender, EventArgs e)
        {

        }

        private void grdSheets_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DefineProperty();
        }

        public void DefineProperty()
        {
            if (JPermission.CheckPermission("ManagementShares.JTransferSheetForm.DefineProperty", true))
            {
                Globals.Property.JDefinePropertyForm F = new Globals.Property.JDefinePropertyForm("ManagementShares.JTransferSheetForm", 0);
                F.ShowDialog();
            }
        }

        private void JTransferSheetForm_Load(object sender, EventArgs e)
        {
            jPropertyValueUserControl1.ClassName = "ManagementShares.JTransferSheetForm";
            jPropertyValueUserControl1.ObjectCode = 0;
            jPropertyValueUserControl1.ValueObjectCode = TransferCode;
            jArchiveList1.ClassName = "ManagementShares.JTransferSheetForm";
            jArchiveList1.ObjectCode = TransferCode;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void TxTSellShare_TextChanged(object sender, EventArgs e)
        {

            int itemp = 0;
            if (int.TryParse(TxTSellShare.Text, out itemp) && int.Parse(TxTSellShare.Text) != ChangeTXT())
            {
                grdSheets.Sort(grdSheets.Columns["ShareCount"], ListSortDirection.Ascending);
                for (int i = 0; i < grdSheets.RowCount; i++)
                {
                    if ((int)grdSheets["ShareCount", i].Value > itemp)
                    {
                        grdSheets["SaleShareCount", i].Value = itemp;
                        itemp = 0;
                    }
                    else
                        if ((int)grdSheets["ShareCount", i].Value < itemp)
                        {
                            grdSheets["SaleShareCount", i].Value = grdSheets["ShareCount", i].Value;
                            itemp = itemp - (int)grdSheets["ShareCount", i].Value;
                        }
                        else
                        {
                            grdSheets["SaleShareCount", i].Value = itemp;
                            itemp = 0;
                        }
                }

            }
            try
            {
                JShareSheet S = new JShareSheet(SCodes[0]);
                CompanyCode = S.CompanyCode;
                JShareCompany SC = new JShareCompany(CompanyCode);
                txtTax.Text = (int.Parse(TxTSellShare.Text) * SC.CurrentShareCost * SC.TaxTransfer / 100).ToString();

                txtPrice.Text = (int.Parse(TxTSellShare.Text) * SC.CurrentShareCost).ToString();
            }
            catch
            {
            }
        }
    }
}
