using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShareProfit
{
    public partial class JShowReport : ClassLibrary.JBaseForm
    {
        public JShowReport()
        {
            InitializeComponent();
        }

        private void ShowReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
