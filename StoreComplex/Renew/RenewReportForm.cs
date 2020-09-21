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
    public partial class JRenewReportForm : Globals.JBaseForm
    {
        DateTime today;
        public JRenewReportForm()
        {
            InitializeComponent();
            grdRenewed.ShowToolbar = true;
            grdReport.ShowToolbar = true;
            today = (new ClassLibrary.JDataBase()).GetCurrentDateTime();
            lbDate.Text = JDateTime.FarsiDate(today);
            DateTime preMonth = JDateTime.GregorianDate(JDateTime.AddMonthFarsi(JDateTime.FarsiDate(today), -1));
          //  if (today.DayOfWeek == DayOfWeek.Saturday)
            //    txtFromDate.Date = preMonth.AddDays(-1);
            //else
              //  txtFromDate.Date = preMonth;
            txtToDate.Date = preMonth;
            ShowData();
        }

        private void ShowData()
        {
            DataTable ToRenew = JRenews.GoodsToRenew(txtFromDate.Text, txtToDate.Text);
            grdReport.DataSource = ToRenew;
            if (ToRenew.Rows.Count > 0)
                txtFromDate.Text = ToRenew.Rows[0]["Date"].ToString();
            grdRenewed.DataSource = JRenews.GetDataTable(txtFromDate.Text, txtToDate.Text);
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            JRenewForm form = new JRenewForm(grdReport.SelectedRow.Row, 0);
            if (form.ShowDialog() == DialogResult.OK)
                ShowData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnDelGoods_Click(object sender, EventArgs e)
        {
            if (grdRenewed.SelectedRow != null)
            {
                if (JMessages.Question("آیا میخواهید ردیف انتخاب شده حذف شود؟", "حذف تمدید") == DialogResult.Yes)
                {
                    int code = Convert.ToInt32(grdRenewed.SelectedRow["Code"]);
                    JRenew renew = new JRenew(code);
                    renew.Delete();
                }
            }
        }

        private void btnEditGoods_Click(object sender, EventArgs e)
        {
            if (grdRenewed.SelectedRow != null)
            {
                int code = Convert.ToInt32(grdRenewed.SelectedRow["Code"]);
                JRenewForm form = new JRenewForm(null, code);
                if (form.ShowDialog() == DialogResult.OK)
                    ShowData();
            }
        }

    }
}
