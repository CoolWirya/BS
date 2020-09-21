using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JReportDetailForm : JBaseForm
    {
        int _CompanyCode;
        public JReportDetailForm(int pCompanyCode)
        {
            InitializeComponent();
            _CompanyCode = pCompanyCode;
        }

        private void ReportDetailForm_Load(object sender, EventArgs e)
        {
            cmbRangKaraneh.DisplayMember = "Description";
            cmbRangKaraneh.ValueMember = "code";
            cmbRangKaraneh.DataSource = JKaranehRanges.GetDataTable(0);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Where = "";
            if ((cmbRangKaraneh.SelectedValue != null))
                Where = Where + " And id_KaraneRange=" + ((System.Data.DataRowView)(cmbRangKaraneh.SelectedItem)).Row["Code"].ToString();

            Where = Where + " And id_employee in (select Code from EmpEmployee where CompanyCode= " + _CompanyCode + ")";
            jdgvResult.DataSource = JKaraneh.ReportDataTable(Where);
        }
    }
}
