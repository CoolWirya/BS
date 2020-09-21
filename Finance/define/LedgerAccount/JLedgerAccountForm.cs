using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Finance
{
    public partial class JLedgerAccountForm : JBaseForm
    {
        public JLedgerAccountForm()
        {
            InitializeComponent();
        }
        public JLedgerAccountForm(int pCode)
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
