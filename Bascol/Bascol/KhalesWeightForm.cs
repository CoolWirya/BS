using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Bascol
{
    public partial class JKhalesWeightForm : JBaseForm
    {
        public int _BascolCode;
        public int _Weight;
        public DateTime _Date;

        public JKhalesWeightForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            #region CheckData
            if (txtWeight.Text == "")
            {
                JMessages.Error(" وزن را وارد کنید ", "");
                txtWeight.Focus();
                return;
            }
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error(" تاریخ را وارد کنید ", "");
                txtWeight.Focus();
                return;
            }
            #endregion

            _BascolCode = Convert.ToInt32(cmbBascolCode.SelectedValue);
            _Weight = Convert.ToInt32(txtWeight.Text);
            _Date = txtDate.Date;
            this.DialogResult = DialogResult.OK;
        }

        private void JKhalesWeightForm_Load(object sender, EventArgs e)
        {
            cmbBascolCode.DataSource = JReport.GetBascols(0);
            cmbBascolCode.DisplayMember = "Code";
            cmbBascolCode.ValueMember = "Code";

            txtDate.Date = DateTime.Now;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void JKhalesWeightForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape))
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }
    }
}
