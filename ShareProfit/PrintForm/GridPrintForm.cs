using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Globals;

namespace ShareProfit
{
    public partial class JGridPrintForm : ClassLibrary.JBaseForm
    {
        public JGridPrintForm()
        {
            InitializeComponent();
        }
        public JGridPrintForm(DataTable pTable , string pDate)
        {
            InitializeComponent();
            try
            {
                grdReport.DataSource = pTable;
                grdReport.Columns["payed"].DefaultCellStyle.Format = "N0";
                grdReport.Columns["AllProfit"].DefaultCellStyle.Format = "N0";
                grdReport.Columns["CourseCost"].DefaultCellStyle.Format = "N0";
                grdReport.Columns["Credit"].DefaultCellStyle.Format = "N0";

                grdReport.Columns["CityCode"].Visible = false;
                grdReport.Columns["Name"].Visible = false;
                grdReport.Columns["LastName"].Visible = false;
                grdReport.Columns["CourseCode"].Visible = false;
                grdReport.Columns["ApproveDate"].Visible = false;

                lbSumCostAllPayed.Text = ClassLibrary.JGeneral.MoneyStr(pTable.Compute("Sum(AllProfit)", "").ToString());
                lbSumCostPayed.Text = ClassLibrary.JGeneral.MoneyStr(pTable.Compute("Sum(payed)", "").ToString());
                lbSumCredit.Text = ClassLibrary.JGeneral.MoneyStr(pTable.Compute("Sum(Credit)", "").ToString());
                lbSumSahmPayed.Text = pTable.Compute("Sum(ShareCount)", "").ToString();
                txtDate.Text = pDate;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                ClassLibrary.JDynamicReportForm DRF = new ClassLibrary.JDynamicReportForm(ClassLibrary.JReportDesignCodes.ShareProfit.GetHashCode());
                DRF.Add((DataTable)(grdReport.DataSource));
                DRF.ShowDialog();

                //JShowReportForm showRep = new JShowReportForm();
                //Microsoft.Reporting.WinForms.ReportDataSource repSource = new Microsoft.Reporting.WinForms.ReportDataSource("erpManagementDataSet_TempView", grdReport.DataSource);
                //Microsoft.Reporting.WinForms.ReportParameter param = new Microsoft.Reporting.WinForms.ReportParameter("Title", txtTitle.Text);

                //showRep.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { param });
                //showRep.reportViewer1.LocalReport.DataSources.Add(repSource);
                //showRep.reportViewer1.RefreshReport();
                
                //Type tip = showRep.reportViewer1.GetType();
                //FieldInfo[] pr = tip.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                //System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
                //ps.Landscape = true;
                ////ps.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 840, 1180); 
                //ps.Margins.Bottom = 0;
                //ps.Margins.Left = 10;
                //ps.Margins.Right = 0;
                //ps.Margins.Top = 50;

                /////ps...... 


                //foreach (FieldInfo item in pr)
                //{
                //    if (item.Name == "m_pageSettings")
                //    {
                //        item.SetValue(showRep.reportViewer1, ps);

                //    }
                //}

                //showRep.reportViewer1.LocalReport.Refresh();

                //showRep.ShowDialog();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //ClassLibrary.JExcel.ExportToExcel(grdReport, txtTitle.Text, saveFileDialog1.FileName);
                grdReport.ExportToExcel();
            }
        }

        public bool SheetDetails;
        private void ShowDetails()
        {
            if (grdReport.DataSource != null)
                if (grdReport.RowCount > 0)
                {
                    //if (SheetDetails)
                    //{
                    //    int SheetNo = Convert.ToInt32(grdReport.CurrentRow.Cells["SheetNo"].Value);
                    //    int PCode = Convert.ToInt32(grdReport.CurrentRow.Cells["PCode"].Value);

                    //    int Az = Convert.ToInt32(grdReport.CurrentRow.Cells["Az"].Value);
                    //    int Ela = Convert.ToInt32(grdReport.CurrentRow.Cells["Ela"].Value);
                    //    int CourseCode = Convert.ToInt32(grdReport.CurrentRow.Cells["CourseCode"].Value);
                    //    JShowDetailsForm2 details = new JShowDetailsForm2(Az, Ela, CourseCode, true);
                    //    details.ShowDialog();
                    //}
                    //else
                    //{
                    //    int PCode = Convert.ToInt32(grdReport.CurrentRow.Cells["PCode"].Value);
                    //    int CourseCode = Convert.ToInt32(grdReport.CurrentRow.Cells["CourseCode"].Value);
                    //    JShowDetailsForm2 details = new JShowDetailsForm2(0, PCode, CourseCode);
                    //    details.ShowDialog();
                    //}
                }
        }

        private void grdReport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowDetails();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            ShowDetails();
        }

        private void btnCodes_Click(object sender, EventArgs e)
        {
            string codes = "";
            foreach (DataGridViewRow row in grdReport.Rows)
            {
               // if (!codes.Contains(row.Cells["PCode"].Value.ToString()))
                {
                    codes = codes + row.Cells["PCode"].Value.ToString();
                    if (row.Index != grdReport.Rows.Count - 1)
                        codes = codes + ",";
                }
            }
            //JOutputCodes form = new JOutputCodes(codes);
            //form.ShowDialog();
        }

        private void grdReport_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

            }
        }

        private void btnTransferDetails_Click(object sender, EventArgs e)
        {
            if (SheetDetails)
                if (grdReport.DataSource != null)
                    if (grdReport.RowCount > 0)
                    {
                        int SheetNo = Convert.ToInt32(grdReport.CurrentRow.Cells["SheetNo"].Value);
                        //JTransferDetails transferDetails = new JTransferDetails(SheetNo);
                        //transferDetails.ShowDialog();
                    }
        }

        private void grdReport_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdReport.CurrentRow != null)
                    if (grdReport.CurrentRow.Cells["Transfered"].Value != null)
                        btnTransferDetails.Enabled = Convert.ToBoolean(grdReport.CurrentRow.Cells["Transfered"].Value);
            }
            catch
            {
            }
        }

        
    }
}
