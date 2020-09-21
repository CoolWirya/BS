using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareProfit.Payment
{
    public partial class JPaymentForm : ClassLibrary.JBaseForm
    {
        public JPaymentForm()
        {
            InitializeComponent();
        }

                private int CourseCode;
        private int DocCode;

        public JPaymentForm1(int pCourseCode)
        {
            CourseCode = pCourseCode;
            //jArchiveList1.ClassName = "ShareProfit.JPaymentForm";
            ///jArchiveList1.ObjectCode = 0;
        }

        public JPaymentForm1(int pCourseCode, int pDocCode)
        {
            CourseCode = pCourseCode;
            DocCode = pDocCode;

            //jArchiveList1.ClassName = "ShareProfit.JPaymentForm";
            //jArchiveList1.ObjectCode = pDocCode;

            LoadData();
        }
        
        private void LoadData()
        {
            JPayment P = new JPayment();
            DataTable DT = P.GetByDocCode(DocCode);
            txtSheetNo.Text = DT.Rows[0]["SheetNo"].ToString();
            dateEdit1.Text = DT.Rows[0]["PayDate"].ToString();

            jDataGridPayment.DataSource = DT;
            for (int i = 0; i <= jDataGridPayment.Columns.Count; i++)
            {
                jDataGridPayment.Columns[i].ReadOnly = true;
            }

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int SheetCode = Convert.ToInt32(txtSheetNo.Text);

            int doccode = JPayment.GetMaxDocCode();

            JPayment P = new JPayment();
            for (int i = 0; i <= jDataGridPayment.Columns.Count; i++)
            {

                P.PayDate = dateEdit2.Text;
                P.SheetNo = SheetCode;
                P.CourseCode = CourseCode;
                P.DocCode = doccode;
                P.erpPCode = 0;
                P.ManagementsharesNo = Convert.ToInt32(jDataGridPayment.Columns["Code"].ToString());
                P.PayCost = Convert.ToInt32(jDataGridPayment.Columns["remained"].ToString());
                P.PayCount = 0;
                P.PayDesc = "";
                P.RegName = JMainFrame.CurrentPostTitle;
                if (P.PayCount > 0)
                    P.insert();


            }
        }

        private void txtSheetNo_Leave(object sender, EventArgs e)
        {
            if (jDataGridPayment.DataSource != null)
                (jDataGridPayment.DataSource as DataTable).Clear();
            jDataGridPayment.DataSource = null;
            try
            {
                int SheetCode = Convert.ToInt32(txtSheetNo.Text);
                JShareSheet S = new JShareSheet(SheetCode);

                JCourse C = new JCourse(CourseCode);
                if (C.ShareCount != S.SharePeriodCount())
                {
                    ClassLibrary.JMessages.Confirm("تعداد سهام موجود در سهام در شرکت در زمان پزداخت سود با تعداد سهام دوره این برگه سهم برابر نمیباشد", "خطا");
                }
                else
                {
                    jDataGridPayment.DataSource = JPayment.SelectPayDetails(S.Az, S.Ela, CourseCode);
                    for (int i = 0; i <= jDataGridPayment.Columns.Count; i++)
                    {
                        jDataGridPayment.Columns[i].ReadOnly = true;
                    }
                    //jDataGridPayment.Columns["remained"].ReadOnly = false;
                    jDataGridPayment.Refresh();
                }
            }
            catch
            {
            }
            finally
            {
            }
        }
    }
}
