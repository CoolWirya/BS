using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreComplex
{
    public partial class JRenewPrivateReportForm : Globals.JBaseForm
    {
        DateTime today;
        public JRenewPrivateReportForm()
        {
            InitializeComponent();
            today = (new ClassLibrary.JDataBase()).GetCurrentDateTime();
            lbDate.Text = JDateTime.FarsiDate(today);
            DateTime preMonth = JDateTime.GregorianDate(JDateTime.AddMonthFarsi(JDateTime.FarsiDate(today), -1));
            txtToDate.Date = preMonth;
            ShowData();
        }

        private void ShowData()
        {
            DataTable ToRenew = JRenewPrivates.StoragesToRenew(txtFromDate.Text, txtToDate.Text);
            grdReport.DataSource = ToRenew;
            if (ToRenew.Rows.Count > 0)
                txtFromDate.Text = ToRenew.Rows[0]["IN_Renew_Date"].ToString();
            grdRenewed.DataSource = JRenewPrivates.GetDataTable(txtFromDate.Text, txtToDate.Text);
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            JRenewPrivateForm form = new JRenewPrivateForm(grdReport.SelectedRow.Row);
            if (form.ShowDialog() == DialogResult.OK)
                ShowData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();

        }
    }
}
