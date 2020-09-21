using ClassLibrary;
using ManagementShares;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JTransferUpdateControl : System.Web.UI.UserControl
    {
        int[] SCodes;
        int CompanyCode = 0;
        int PersonCode = 0;
        int TransferCode = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["CompanyCode"], out CompanyCode);
            int.TryParse(Request["TransferCode"], out TransferCode);
            int.TryParse(Request["Code"], out PersonCode);
            if (TransferCode == 0)
            {
                SetForm(true);

                // Person Property
                ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ClassName = "ClassLibrary.JRealPerson";
                ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ObjectCode = 1;
                ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ValueObjectCode = PersonCode;
                ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).KeyColumnWidth = "150px";
                ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ValueColumnWidth = "400px";
                ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).LoadPropertyOnPageLoad();
            }
            else // i.e. TransferCode != 0
            {
                SetForm(false);
            }
        }


        public void SetRow()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select isnull(max(cast(ShIndex as int)),0) as ShIndex,isnull(max(cast(ShNote as int)),0)+1 as ShNote from ShareTransfer st
inner join ShareSheet ss on st.scode=ss.Code
where  IsNumeric(ShIndex)=1 and IsNumeric(ShNote)=1 and ss.CompanyCode=" + CompanyCode.ToString());
                DataTable dt = db.Query_DataTable();
                txtShNote.Text = dt.Rows[0]["ShNote"].ToString();
                txtShIndex.Text = dt.Rows[0]["ShIndex"].ToString();
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }
        private void SetForm(bool NewTransfer)
        {
            try
            {
                DataTable sheets;
                SetRow();
                ((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).PersonType = JPersonTypes.RealPerson;
                ((WebControllers.MainControls.JShareSearchPersonControl)personSeller).PersonType = JPersonTypes.RealPerson;
                if (!NewTransfer)
                {
                    JTransferSheet transfer = new JTransferSheet(TransferCode);
                    sheets = ManagementShares.JShareSheet.GetSheets(transfer.SCode);
                    RadGridReport1.DataSource = sheets;
                    ((WebControllers.MainControls.JShareSearchPersonControl)personSeller).isReadOnly = true;
                    btnSave.Enabled = false;
                    //personBuyer.SearchOnCode = SearchOnCode.Code;
                    ((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).PersonCode = transfer.SPCode;
                    ((WebControllers.MainControls.JShareSearchPersonControl)personSeller).PersonCode = transfer.FPCode;
                    ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(transfer.TDate);
                    txtPrice.Text = transfer.Price.ToString();
                    txtShIndex.Text = transfer.ShIndex.ToString();
                    txtShNote.Text = transfer.ShNote;
                    txtTax.Text = transfer.Tax.ToString();
                    cmbAgent.SelectedValue = transfer.Agent.ToString();
                    cmbMosalehe.SelectedValue = transfer.Mosalehe.ToString();
                    txtSellShare.Text = transfer.TranSum.ToString();

                    //sheets = ManagementShares.JShareSheet.GetSheets(SCodes);
                }
                else
                {
                    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ClassName = "ManagementShares.JTransferSheetForm";
                    ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ObjectCode = 0;

                    ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = "ManagementShares.JTransferSheetForm";

                    ((WebControllers.MainControls.JShareSearchPersonControl)personSeller).isReadOnly = true;
                    ((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).CompanyCode = CompanyCode;
                    ((WebControllers.MainControls.JShareSearchPersonControl)personSeller).CompanyCode = CompanyCode;

                    DateTime currentDate = (new JDataBase()).GetCurrentDateTime();
                    ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(currentDate.Date);
                    txtTimeHour.Text = currentDate.Hour.ToString("00");
                    txtTimeMinute.Text = currentDate.Minute.ToString("00");

                    sheets = ManagementShares.JShareSheet.GetSheets(ManagementShares.JShareSheet.GetCodeSheetPerson(PersonCode, CompanyCode));
                    RadGridReport1.DataSource = sheets;
                    SCodes = JDataBase.DataTableToIntArray(sheets, "Code");
                    txtSellShare.Text = sheets.Rows[0]["ShareCount"].ToString();
                    ((WebControllers.MainControls.JShareSearchPersonControl)personSeller).PersonCode = PersonCode;
                }
                //sheets.Columns.Add("SaleShareCount", typeof(int)).SetOrdinal(0);
                //foreach (DataGridViewColumn col in RadGridReport1.Columns)
                //{
                //    if (col.Name != "SaleShareCount")
                //        col.ReadOnly = true;
                //}
                //foreach (DataRow row in sheets.Rows)
                //{
                //    if (sheets.Rows.Count == 1)
                //    {
                //        row["SaleShareCount"] = row["ShareCount"];
                //    }
                //    else if (sheets.Rows.Count > 1)
                //    {
                //        row["SaleShareCount"] = 0;
                //    }
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }


        protected void RadGridReport1_PreRender(object sender, EventArgs e)
        {
            if (RadGridReport1.DataSource == null) return;
            foreach (DataColumn col in (RadGridReport1.DataSource as DataTable).Columns)
            {
                if (col.ColumnName != "FDate")
                    RadGridReport1.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
            }
            RadGridReport1.MasterTableView.Rebind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Validate
            if (((WebControllers.MainControls.Date.JDateControl)txtDate).Date <= DateTime.MinValue)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً تاریخ را بصورت صحیح وارد کنید.');", "ConfirmDialog");
                return;
            }
            if (Convert.ToDecimal(txtPrice.Text) == 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً قیمت کل را وارد کنید.');", "ConfirmDialog");
                return;
            }
            if (txtShIndex.Text == "")
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً شماره ردیف را وارد کنید.');", "ConfirmDialog");
                return;
            }
            if (txtShNote.Text == "")
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً شماره دفتر را وارد کنید.');", "ConfirmDialog");
                return;
            }
            if (txtTax.Text == "")
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفاً مالیات را وارد کنید.');", "ConfirmDialog");
                return;
            }
            //if (((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).IsBlock || ((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).IsDied)
            //{
            //    WebClassLibrary.JWebManager.RunClientScript("alert('خریدار معتبر نیست.');", "ConfirmDialog");
            //    return;
            //}
            //if (((WebControllers.MainControls.JShareSearchPersonControl)personSeller).IsBlock)
            //{
            //    WebClassLibrary.JWebManager.RunClientScript("alert('فروشنده معتبر نیست.');", "ConfirmDialog");
            //    return;
            //}

            if (JTransferSheet.FindTranfer(txtShNote.Text, txtShIndex.Text,this.CompanyCode))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('شماره دفتر و شماره ردیف تکراری است.');", "ConfirmDialog");
                return;
            }
            DataTable sheets = ManagementShares.JShareSheet.GetSheets(SCodes);
            int pCode = Convert.ToInt32(sheets.Rows[0]["PCode"]);
            foreach (DataRow row in sheets.Rows)
            {
                if (pCode != Convert.ToInt32(row["PCode"]))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('فروشنده برگه های سهم باید یکی باشد.');", "ConfirmDialog");
                    rtabTransfer.Tabs.FindTabByValue("rpvTransactors").Selected = true;
                    rpageTransfer.FindPageViewByID("rpvTransactors").Selected = true;
                    //tabControl1.SelectedTab = tabPage1;
                    return;
                }
            }
            if (((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).PersonCode == 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا سهامدار جدید را انتخاب کنید.');", "ConfirmDialog");
                rtabTransfer.Tabs.FindTabByValue("rpvTransactors").Selected = true;
                rpageTransfer.FindPageViewByID("rpvTransactors").Selected = true;
                //tabControl1.SelectedTab = tabPage1;
                return;
            }
            if (((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).PersonCode == ((WebControllers.MainControls.JShareSearchPersonControl)personSeller).PersonCode)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا سهامدار جدید را انتخاب کنید.');", "ConfirmDialog");
                rtabTransfer.Tabs.FindTabByValue("rpvTransactors").Selected = true;
                rpageTransfer.FindPageViewByID("rpvTransactors").Selected = true;
                //tabControl1.SelectedTab = tabPage1;
                return;
            }
            if (((WebControllers.MainControls.Date.JDateControl)txtDate).Date <= DateTime.MinValue)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا تاریخ انتقال را وارد کنید.');", "ConfirmDialog");
                //tabControl1.SelectedTab = tabInfo;
                return;
            }
            #endregion Validate
            JTransferSheet transfer = new JTransferSheet();
            transfer.TDate = Convert.ToDateTime(((WebControllers.MainControls.Date.JDateControl)txtDate).Date.Date.ToString("yyyy/MM/dd") + " " +
                txtTimeHour.Text + ":" + txtTimeMinute.Text + ":00");
            transfer.FPCode = pCode;
            transfer.Mosalehe = Convert.ToBoolean(cmbMosalehe.SelectedValue);
            transfer.Price = Convert.ToDecimal(txtPrice.Text);
            transfer.ShIndex = Convert.ToInt32(txtShIndex.Text);
            transfer.ShNote = txtShNote.Text;
            transfer.SPCode = ((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).PersonCode;// ManagementShares.ShareCompany.JSharepCode.GetPersonShare(personBuyer.CompanyCode, personBuyer.txtExportCode.IntValue);
            //transfer.CompanyCode = ((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).CompanyCode;
            transfer.Tax = Convert.ToDecimal(txtTax.Text);
            transfer.Agent = Convert.ToBoolean(cmbAgent.SelectedValue);
            transfer.Confirmed = true;

            int CompanyCode = 0;
            try
            {

                foreach (DataRow row in (RadGridReport1.DataSource as DataTable).Rows)
                {

                    int sheetCode = Convert.ToInt32(row["Code"]);
                    int shareCount = Convert.ToInt32(txtSellShare.Text);
                    if (shareCount > 0)
                    {
                        ManagementShares.JShareSheet sheet = new ManagementShares.JShareSheet(sheetCode);
                        CompanyCode = sheet.CompanyCode;
                        int TransferCode = 0;
                        int ResultCode = sheet.TransferSheet(shareCount, ((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).PersonCode, transfer, null, true, ref TransferCode);
                        if (ResultCode == 0)
                            throw new Exception();
                        ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).ValueObjectCode = TransferCode;
                        ((WebControllers.Property.JPropertyViewControl)jPropertyViewControl).Save();
                        ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode = TransferCode;
                        //((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).SaveToArchive();
                    }
                }

                ManagementShares.ShareCompany.JSharepCode SP = new ManagementShares.ShareCompany.JSharepCode();
                SP.Insert(CompanyCode, ((WebControllers.MainControls.JShareSearchPersonControl)personBuyer).PersonCode);

                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات انتقال با موفقیت انجام شد.');", "ConfirmDialog");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        protected void rtabTransfer_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e) 
        {
            if (e.Tab.Value == rpvArchive.ID)
            {
                if (((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode == 0)
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('ابتدا انتقال را ثبت کنید');", "ConfirmDialog");
                }
                else
                {
                    //((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = (new ClassLibrary.JPerson()).GetType().FullName;
                    //((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode = PersonCode;
                    //((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).LoadArchive();
                }
            }
        }
    }
}