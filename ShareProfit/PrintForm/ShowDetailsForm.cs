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
    public partial class JShowDetailsForm : JBaseForm
    {
        public JShowDetailsForm(int SheetNo,  int PCode, int CourseCode)
        {
            InitializeComponent();
            JPayment payment = new JPayment();
            grdPayment.DataSource = payment.SelectPayDetails(SheetNo, 0, PCode, CourseCode);
            if (grdPayment.DataSource != null)
            {
                grdPayment.Columns["Code"].Visible = false;
                grdPayment.Columns["payCost"].DefaultCellStyle.Format = "N0";
            }
        }
        /// <summary>
        /// نمایش بر اساس شماره سهم
        /// </summary>
        /// <param name="pAZ"></param>
        /// <param name="pEla"></param>
        /// <param name="CourseCode"></param>
        /// <param name="pStockNo"></param>
        public JShowDetailsForm(int pAZ, int pEla, int CourseCode, bool pStockNo)
        {
            InitializeComponent();
            JPayment payment = new JPayment();
            grdPayment.DataSource = payment.SelectPayDetails(pAZ, pEla, CourseCode);
            if (grdPayment.DataSource != null)
            {
                grdPayment.Columns["Code"].Visible = false;
                grdPayment.Columns["payCost"].DefaultCellStyle.Format = "N0";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
