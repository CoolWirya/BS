using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ShareProfit
{
    public partial class JShowGrid : ClassLibrary.JBaseForm
    {
        public JShowGrid()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            if (JMessages.Message("AreYouSure?YouWantToDeletePayment?", "Question", JMessageType.Question) == DialogResult.Yes)
            {
                int Az = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Az"].Value);
                int Ela = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Ela"].Value);
                int CourseCode = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["coursecode"].Value);
                int DocCode = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["doccode"].Value);
                int SheetNo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["sheetno"].Value);
                int PCode = Convert.ToInt32(dataGridView1. SelectedRows[0].Cells["pcode"].Value);
                JPayment payment = new JPayment();
                int DelCount = payment.DeletePay(Az, Ela, CourseCode, PCode, SheetNo);
                //btnSearch.PerformClick();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //int CourseCode = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["coursecode"].Value);
            //int DocCode = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["doccode"].Value);
            //JSDocument Document = JSDocument.FindDocument(DocCode);
            //JCourse Course = JCourse.FindCourse(CourseCode);
            //JPaymentForm payment = new JPaymentForm(Document, Course);
            //payment.SheetNo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["sheetno"].Value);
            //payment.ManagementsharesHolderCode = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["pcode"].Value);
            //payment.formState = JFormState.Update;
            //payment.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                JExcel.ExportToExcel(dataGridView1, txtTitle.Text, saveFileDialog1.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (_DSet == null)
              //  return;
            try
            {
                JShowReport showRep = new JShowReport();
                Microsoft.Reporting.WinForms.ReportDataSource repSource = new Microsoft.Reporting.WinForms.ReportDataSource("erpSahamDataSet_DataTable1", dataGridView1.DataSource);
                Microsoft.Reporting.WinForms.ReportParameter param = new Microsoft.Reporting.WinForms.ReportParameter("Title", txtTitle.Text);
                showRep.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { param });
                showRep.reportViewer1.LocalReport.DataSources.Add(repSource);
                showRep.ShowDialog();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
