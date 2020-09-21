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
    public partial class JOutputCodes : ClassLibrary.JBaseForm
    {
        public JOutputCodes(string pCodes)
        {
            InitializeComponent();
            txtCodes.Text = pCodes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
