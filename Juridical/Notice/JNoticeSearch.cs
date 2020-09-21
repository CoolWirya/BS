using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JNoticeSearchFrom : JBaseForm
    {
        public int _Code;

        public JNoticeSearchFrom()
        {
            InitializeComponent();
        }

        private void jdgvNotice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jdgvNotice.CurrentRow != null)
            {
                _Code = Convert.ToInt32(jdgvNotice.CurrentRow.Cells["Code"].Value);
                Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JNotice tmp = new JNotice();
            tmp.Reasons = txtReason.Text.Trim();
            tmp.Result = txtResult.Text.Trim();
            tmp.Date = txtDate.Date;
            jdgvNotice.DataSource = tmp.Search(txtEndDate.Date);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Code = Convert.ToInt32(jdgvNotice.CurrentRow.Cells["Code"].Value);
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            txtReason.Text = "";
            txtDate.Text = "";
            txtEndDate.Text = "";
        }
    }
}
