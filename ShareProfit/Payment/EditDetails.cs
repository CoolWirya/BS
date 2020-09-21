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
    public partial class JEditDetails : JBaseForm
    {
        public string _Cost;
        public string _Date;
        public string _Desc;
        public string _RegName;

        public JEditDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _Cost= txtCost.SimpleText;
            _Date = txtDate.Text;
            _Desc = txtDesc.Text;
            _RegName = txtRegName.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
