using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Globals
{
    public partial class JDynamicReportForm : JBaseForm
    {
        public string Action;
        public DataTable DT;
        public string TableName;
        JDynamicReport DRC = new JDynamicReport();

        public JDynamicReportForm(string pAction,DataTable pDT,string pTableName)
        {
            InitializeComponent();
            Action = pAction;
            DT = pDT;
            TableName = pTableName;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            tBReportCaption.Clear();
            rBFastReport.Checked = true;
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            if (rBFastReport.Checked)
                DRC.ReportType = JReportType.FastReport;
            else
                if (rBWord.Checked)
                    DRC.ReportType = JReportType.WordRepor;
            DRC.Caption = tBReportCaption.Text;
            if (DRC.CreateNew(DT, TableName) > 0)
            {
                groupBox1.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DRC.Save())
            {
                groupBox1.Enabled = false;
            }
        }

        private void listBoxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DRC.GetData(((JDynamicReport)listBoxReports.SelectedItem).Code))
            {
                tBReportCaption.Text = DRC.Caption;
                if (DRC.ReportType == JReportType.WordRepor)
                    rBFastReport.Checked = true;
                else
                    rBWord.Checked = true;
            }
        }

        private void getList()
        {
            JDynamicReports DRs = new JDynamicReports(Action);
        }
    }
}
