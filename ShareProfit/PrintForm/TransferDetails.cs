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
    public partial class JTransferDetails : Globals.JBaseForm
    {
        public JTransferDetails(int SheetNo)
        {
            InitializeComponent();
            ManagementShares.JSheet sheet = new ManagementShares.JSheet();
            grdDetails.DataSource = sheet.TransferDetails(SheetNo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
