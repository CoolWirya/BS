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
    public partial class JReportSheetForm : ClassLibrary.JBaseForm
    {
        private int CompanyCode;

        public JReportSheetForm(int pCompanyCode)
        {
            InitializeComponent();
            CompanyCode = pCompanyCode;
            SetComboBox();
        }

        private void SetComboBox()
        {
            ///شرکتها
            cmbCompany.DataSource = JShareCompanies.GetDataTable(CompanyCode);
            cmbCompany.ValueMember = "Code";
            cmbCompany.DisplayMember = "Name";
            /// وضعیت برگه
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ManagementShares.JSheetStatus")));
            cmbStatus.SelectedIndex = 2;
            /// وضعیت وکالت
            cmbAgent.Items.Clear();
            cmbAgent.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ManagementShares.JSheetAgentStatus")));
            cmbAgent.SelectedIndex = 0;
            /// وضعیت چاپ
            cmbPrintStatus.Items.Clear();
            cmbPrintStatus.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ManagementShares.JSheetPrintStatus")));
            cmbPrintStatus.SelectedIndex = 2;
            ///  متوفی
            cmbDied.Items.Clear();
            cmbDied.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(ClassLibrary.JAllPerson.DiedType));
            cmbDied.SelectedIndex = 2;
            ///  ممنوع المعامله
            cmbBlock.Items.Clear();
            cmbBlock.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(ClassLibrary.JAllPerson.BlockType));
            cmbBlock.SelectedIndex = 2;
            /// وضعیت وکیل
            cmbAgentStatus.Items.Clear();
            cmbAgentStatus.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ManagementShares.JAgentStatus")));
            cmbAgentStatus.SelectedIndex = 2;
            /// وضعیت انتقال
            cmbHasTransfer.Items.Clear();
            cmbHasTransfer.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ManagementShares.JTransferStatus")));
            cmbHasTransfer.SelectedIndex = 0;

            personAgentCode.FilterPerson = " Code IN (Select PCode From ShareAgent WHERE CompanyCode=" + CompanyCode.ToString() + ") ";
            tabControl1.TabPages.Remove(tabGeneral);

            grdAgents.ShowToolbar = true;
            grdPerson.ShowToolbar = true;
            grdSheets.ShowToolbar = true;
            grdTransfer.ShowToolbar = true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sheetFilter = " AND S1.CompanyCode = " + ((DataRowView)cmbCompany.SelectedItem)["Code"].ToString();
            string title = " کلیه برگه های شرکت " + cmbCompany.Text;

            #region Sheets
            /// شماره برگه
            if (txtSheetNo.IntValue != 0)
            {
                sheetFilter += " AND S1.Code = " + txtSheetNo.Text;
                title += "،با شماره برگه: " + txtSheetNo.Text;
            }
            if (txtSheetNoFrom.IntValue != 0)
            {
                sheetFilter += " AND S1.Code >= " + txtSheetNoFrom.Text;
                title += "، از شماره برگه: " + txtSheetNoFrom.Text;
            }
            if (txtSheetNoTo.IntValue != 0)
            {
                sheetFilter += " AND S1.Code <= " + txtSheetNoTo.Text;
                title += "، تا شماره برگه: " + txtSheetNoTo.Text;
            }

            /// تعداد سهم
            if (txtShareCount.IntValue != 0)
            {
                sheetFilter += " AND S1.ShareCount = " + txtShareCount.Text;
                title += "، با تعداد سهم: " + txtShareCount.Text;
            }
            if (txtShareCountMin.IntValue != 0)
            {
                sheetFilter += " AND S1.ShareCount >= " + txtShareCountMin.Text;
                title += "، با تعداد سهم حداقل: " + txtShareCountMin.Text;
            }
            if (txtShareCountMax.IntValue != 0)
            {
                sheetFilter += " AND S1.ShareCount <= " + txtShareCountMax.Text;
                title += "، با تعداد سهم حداکثر: " + txtShareCountMax.Text;
            }
            /// مالک
            if (txtPCodeSheet.IntValue != 0)
            {
                sheetFilter += " AND S1.PCode = " + txtPCodeSheet.Text;
                title += "، کد مالک: " + txtPCodeSheet.Text;
            }
            /// وضعیت برگه
            if (cmbStatus.SelectedItem != null && Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbStatus.SelectedItem)).Value) != (JSheetStatus.All.GetHashCode()))
            {
                sheetFilter += " And S1.Status = " + Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbStatus.SelectedItem)).Value);
                title += "، با وضعیت: " + cmbStatus.Text;
            }
            /// وضعیت چاپ
            if (cmbPrintStatus.SelectedItem != null && Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbPrintStatus.SelectedItem)).Value) != (JSheetPrintStatus.All.GetHashCode()))
            {
                if (Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbPrintStatus.SelectedItem)).Value) == (JSheetPrintStatus.NotPrinted.GetHashCode()))
                    sheetFilter += " And S1.NumPrint = 0 ";
                else
                    sheetFilter += " And S1.NumPrint > 0 ";
                title += "، با وضعیت چاپ: " + cmbPrintStatus.Text;
            }
            /// وضعیت وکالت
            if (cmbAgent.SelectedItem != null && Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbAgent.SelectedItem)).Value) != JSheetAgentStatus.All.GetHashCode())
            {
                if (Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbAgent.SelectedItem)).Value) == JSheetAgentStatus.HasAgent.GetHashCode())
                {
                    sheetFilter += " And S1.ACode IS Not Null And S1.ACode <> 0 ";
                    title += "، دارای وکیل ";
                }
                if (Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbAgent.SelectedItem)).Value) == JSheetAgentStatus.HasNotAgent.GetHashCode())
                {
                    sheetFilter += " And (S1.ACode IS Null OR S1.ACode = 0) ";
                    title += "، بدون وکیل ";
                }
            }
            /// وضعیت نقل و انتقال
            if (cmbHasTransfer.SelectedItem != null && Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbHasTransfer.SelectedItem)).Value) != JTransferStatus.All.GetHashCode())
            {
                if (Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbHasTransfer.SelectedItem)).Value) == JTransferStatus.HasTransfer.GetHashCode())
                {
                    sheetFilter += " And ShareTransfer.Code IS Not Null And ShareTransfer.Code <> 0 ";
                    title += "، دارای نقل و انتقال ";
                }
                if (Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbHasTransfer.SelectedItem)).Value) == JTransferStatus.HasNotTransfer.GetHashCode())
                {
                    sheetFilter += " And (ShareTransfer.Code IS Null OR ShareTransfer.Code = 0) ";
                    title += "، بدون نقل و انتقال ";
                }
            }
            if (txtShareNo.IntValue > 0)
            {
                sheetFilter += " And (" + txtShareNo.Text + " BETWEEN S1.Az AND S1.Ela) ";
                title += "، شامل شماره سهم: " + txtShareNo.Text;
            }
            if (txtShareNoFrom.IntValue > 0)
            {
                sheetFilter += " And (Az>=" + txtShareNoFrom.Text + ") ";
                title += "، از شماره سهم: " + txtShareNoFrom.Text;
            }
            if (txtShareNoTo.IntValue > 0)
            {
                sheetFilter += " And (Ela<=" + txtShareNoTo.Text + ") ";
                title += "، الی شماره سهم: " + txtShareNoTo.Text;
            }
            #endregion Sheets

            #region Person
            string personFilter = "";
            if (txtPCode.IntValue > 0)
            {
                personFilter += " AND  Person.Code = " + txtPCode.Text;
                title += "، کد سهامداری:" + txtPCode.Text;
            }
            if (txtPCodeFrom.IntValue > 0)
            {
                personFilter += " AND  Person.Code >= " + txtPCodeFrom.Text;
                title += "، از کد سهامداری:" + txtPCodeFrom.Text;
            }
            if (txtPCodeTo.IntValue > 0)
            {
                personFilter += " AND  Person.Code <= " + txtPCodeTo.Text;
                title += "، تا کد سهامداری:" + txtPCodeTo.Text;
            }
            if (txtPName.Text.Trim() != "")
            {
                personFilter += " AND  Replace(Person.Name, ' ','') LIKE " + JDataBase.Quote('%' + txtPName.Text.Replace(" ", "") + '%');
                title += "، با نام سهامداری:" + txtPName.Text;
            }
            if (txtPFamily.Text.Trim() != "")
            {
                personFilter += " AND  Replace(Person.Name, ' ','') LIKE " + JDataBase.Quote('%' + txtPFamily.Text.Replace(" ", "") + '%');
                title += "، با نام سهامداری:" + txtPFamily.Text;
            }
            if (txtPNationalCode.Text.Trim() != "")
            {
                personFilter += " AND  Person.FullName LIKE  " + JDataBase.Quote('%' + txtPNationalCode.Text + '%');
                title += "، با کد ملی سهامدار:" + txtPNationalCode.Text;
            }
            if (txtPIDNo.Text.Trim() != "")
            {
                personFilter += " AND  Person.IDNo = " + JDataBase.Quote(txtPIDNo.Text);
                title += "، با ش شناسنامه / ش ثبت:" + txtPIDNo.Text;
            }
            if (txtBirthFrom.Date>DateTime.MinValue)
            {
                personFilter += " AND  Person.BirthDate >= " + JDataBase.Quote(txtBirthFrom.Text,false);
                title += "، تاریخ تولد مالک بعد از:" + txtBirthFrom.Text;
            }
            if (txtBirthDateTo.Date > DateTime.MinValue)
            {
                personFilter += " AND  Person.BirthDate <= " + JDataBase.Quote(txtBirthDateTo.Text,false);
                title += "، تاریخ تولد مالک قبل از:" + txtBirthDateTo.Text;
            }
            if (txtPMinShareCount.IntValue > 0)
            {
                personFilter += " AND vSharePerson.ShareCount >= " + txtPMinShareCount.Text;
                title += "، دارای حداقل تعداد سهم:" + txtPMinShareCount.Text;
            }
            if (txtPMaxShareCount.IntValue > 0)
            {
                personFilter += " AND vSharePerson.ShareCount <= " + txtPMaxShareCount.Text;
                title += "، دارای حداکثر تعداد سهم:" + txtPMaxShareCount.Text;
            }

            ///  متوفی
            if (cmbDied.SelectedItem != null && Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbDied.SelectedItem)).Value) != (ClassLibrary.JDiedStatus.All.GetHashCode()))
            {
                personFilter += " And (Person.Died = " + Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbDied.SelectedItem)).Value);
                if (Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbDied.SelectedItem)).Value) == (ClassLibrary.JDiedStatus.NotDied.GetHashCode()))
                    personFilter += " OR Person.Died = Null ";
                personFilter += ")";
                title += "، " + cmbDied.Text;
            }
            ///  ممنوع المعامله
            if (cmbBlock.SelectedItem != null && Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbBlock.SelectedItem)).Value) != (ClassLibrary.JDiedStatus.All.GetHashCode()))
            {
                personFilter += " And (Person.Blocked= " + Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbBlock.SelectedItem)).Value);
                if (Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbBlock.SelectedItem)).Value) == (ClassLibrary.JBlockStatus.NotBlock.GetHashCode()))
                    personFilter += " OR Person.Blocked = Null ";
                personFilter += ")";
                title += "، با وضعیت : " + cmbBlock.Text;
            }
            #endregion Person

            #region Agent.
            string agentFilter = "";
            if (cmbAgentStatus.SelectedItem != null && Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbAgentStatus.SelectedItem)).Value) != (ManagementShares.JAgentStatus.All.GetHashCode()))
            {
                agentFilter += " And ShareAgent.Status = " + Convert.ToInt16(((ClassLibrary.JKeyValue)(cmbAgentStatus.SelectedItem)).Value);
                title += "، وکیل با وضعیت : " + cmbAgentStatus.Text;
            }
            if (txtAgentStartDateFrom.Date > DateTime.MinValue)
            {
				agentFilter += " And ShareAgent.StartDate >= " + JDataBase.Quote(txtAgentStartDateFrom.Date.ToString("yyyy-MM-dd"), false);
                title += "، با تاریخ شروع وکالت وکیل بعد از : " +(txtAgentStartDateFrom.Text);
            }
            if (txtAgentStartDateTo.Date > DateTime.MinValue)
            {
				agentFilter += " And ShareAgent.StartDate <= " + JDataBase.Quote(txtAgentStartDateTo.Date.ToString("yyyy-MM-dd"), false);
                title += "، با تاریخ شروع وکالت وکیل قبل از : " + (txtAgentStartDateTo.Text);
            }
            if (txtAgentEndDateFrom.Date > DateTime.MinValue)
            {
				agentFilter += " And ShareAgent.EndDate >= " + JDataBase.Quote(txtAgentEndDateFrom.Date.ToString("yyyy-MM-dd"), false);
                title += "، با تاریخ پایان وکالت وکیل بعد از : " +(txtAgentEndDateFrom.Text);
            }
            if (txtAgentEndDateTo.Date > DateTime.MinValue)
            {
				agentFilter += " And ShareAgent.EndDate <= " + JDataBase.Quote(txtAgentEndDateTo.Date.ToString("yyyy-MM-dd"), false);
                title += "، با تاریخ پایان وکالت وکیل قبل از : " +(txtAgentEndDateTo.Text);
            }

            if (txtAgentMinSheet.IntValue > 0)
            {
                agentFilter += " AND vShareAgent.SheetsCount >= " + txtAgentMinSheet.Text;
                title += "، وکیل دارای حداقل تعداد وکالت برگه:" + txtAgentMinSheet.Text;
            }
            if (txtAgentMaxSheet.IntValue > 0)
            {
                agentFilter += " AND vShareAgent.SheetsCount <= " + txtAgentMaxSheet.Text;
                title += "، وکیل دارای حداکثر تعداد وکالت برگه:" + txtAgentMaxSheet.Text;
            }
            if (txtAgentMinShare.IntValue > 0)
            {
                agentFilter += " AND vShareAgent.SharesCount >= " + txtAgentMinShare.Text;
                title += "، وکیل دارای حداقل تعداد وکالت سهم:" + txtAgentMinShare.Text;
            }
            if (txtAgentMaxShare.IntValue > 0)
            {
                agentFilter += " AND vShareAgent.SharesCount <= " + txtAgentMaxShare.Text;
                title += "، وکیل دارای حداکثر تعداد وکالت سهم:" + txtAgentMaxShare.Text;
            }
            if (personAgentCode.SelectedCode > 0)
            {
                agentFilter += " AND ShareAgent.PCode= " + personAgentCode. SelectedCode;
                title += "، کد وکیل:" + personAgentCode.Text;
            }

            #endregion Agent

            #region Transfer
            string transferFilter = "";
            if (txtTranDateFrom.Date > DateTime.MinValue)
            {
                transferFilter += " And ShareTransfer.TDate >= " + JDataBase.Quote(txtTranDateFrom.Date.ToString("yyyy-MM-dd") + " 00:00:00", false);
                title += "، با تاریخ انتقال قبل از : " + (txtTranDateFrom.Text);
            }
            if (txtTranDateTo.Date > DateTime.MinValue)
            {
                transferFilter += " And ShareTransfer.TDate <= " + JDataBase.Quote(txtTranDateTo.Date.ToString("yyyy-MM-dd") + " 23:59:59", false);
                title += "، با تاریخ انتقال قبل از : " + (txtTranDateTo.Text);
            }

            if (personSeller.SelectedCode > 0)
            {
                transferFilter += " AND ShareTransfer.FPCode= " + personSeller.SelectedCode;
                title += "، کد فروشنده:" + personSeller.SelectedCode;
            }
            if (personBuyer.SelectedCode > 0)
            {
                transferFilter += " AND ShareTransfer.SPCode= " + personBuyer.SelectedCode;
                title += "، کد خریدار:" + personBuyer.SelectedCode;
            }
            #endregion Transfer

            ///////////////////////////////// اشخاص /////////////////////

            if (tabResult.SelectedTab == tabSheets)
            {
                string shareCount = "";
                grdSheets.DataSource = JShareReport.SelectSheetsReport(sheetFilter, personFilter, agentFilter, transferFilter, ref  shareCount);
                lbShareCount.Text = shareCount;
            }
            else
                if (tabResult.SelectedTab == tabPerson)
                {
                    grdPerson.DataSource = JShareReport.SelectPerson(sheetFilter, personFilter, agentFilter, transferFilter);
                }
                else
                    if (tabResult.SelectedTab == tabAgents)
                    {
                        grdAgents.DataSource = JShareReport.SelectAgent(sheetFilter, personFilter, agentFilter, transferFilter);
                    }
                    else if (tabResult.SelectedTab == tabTransfer)
                    {
                        string transferShareCount = "";
                        grdTransfer.DataSource = JShareReport.SelectTransfer(sheetFilter, personFilter, agentFilter, transferFilter, ref transferShareCount);
                        lbSumTransfer.Text = transferShareCount;
                    }

            txtTitle.Text = title;
        }

        private void JReportSheetForm_Load(object sender, EventArgs e)
        {
            btnSearchAgent.Top = btnSearch.Top;
            btnSearchAgent.Left = btnSearch.Left;
            btnSearchAgent.Height = btnSearch.Height;
            btnSearchAgent.Width = btnSearch.Width;
            btnSearchAgent.Top = btnSearch.Top;
            btnSearchAgent.Text = btnSearch.Text;

            btnSearchOwner.Top = btnSearch.Top;
            btnSearchOwner.Left = btnSearch.Left;
            btnSearchOwner.Height = btnSearch.Height;
            btnSearchOwner.Width = btnSearch.Width;
            btnSearchOwner.Top = btnSearch.Top;
            btnSearchOwner.Text = btnSearch.Text;
         
            btnSearchGeneral.Top = btnSearch.Top;
            btnSearchGeneral.Left = btnSearch.Left;
            btnSearchGeneral.Height = btnSearch.Height;
            btnSearchGeneral.Width = btnSearch.Width;
            btnSearchGeneral.Top = btnSearch.Top;
            btnSearchGeneral.Text = btnSearch.Text;

			//string NowDateShamsi=JDataBase.SQLMiladiToShamsi(DateTime.Now.ToString("yyyy/MM/dd"),"nvarchar");
			//txtTranDateTo.Text = NowDateShamsi;
			//txtTranDateFrom.Text = NowDateShamsi;

           
        }

        private void tabResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            //   btnSearch.PerformClick();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void tabResult_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintSheet_Click(object sender, EventArgs e)
        {
            JShareSheets sheets = new JShareSheets();
            sheets.PrintShareSheet(grdAgents.Selected);
            //DataTable printTable = grdSheets.SelectedDataTable;
            //if (printTable.Rows.Count == 0)
            //{
            //    JMessages.Error("هیچ رکوردی انتخاب نشده است.", "error");
            //    return;
            //}
            //if (JShareSheets.AddPrintCount(printTable))
            //{
            //    JDynamicReportForm reportForm = new JDynamicReportForm(JReportDesignCodes.Sheet.GetHashCode());
            //    reportForm.Add(grdSheets.SelectedDataTable);
            //    reportForm.ShowDialog();
            //}
            //else
            //{
            //    JMessages.Error("عملیات چاپ برگه سهم با مشکل مواجه شده است.", "خطا");
            //}
        }
    }
}
