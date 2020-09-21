using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManagementShares
{
    public partial class JExportDataToWebForm : Globals.JBaseForm
    {
        public JExportDataToWebForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            JExportDataToWeb export = new JExportDataToWeb();
            export.ExportToWeb();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
