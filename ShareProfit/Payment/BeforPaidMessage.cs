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
    public partial class JBeforPaidMessage : Globals.JBaseForm
    {
        public JBeforPaidMessage(DataTable pTable, bool pAllow)
        {
            InitializeComponent();
            grdPaidBefor.DataSource = pTable;
            if (pAllow)
            {
                btnNo.Visible = true;
                btnYes.Visible = true;
                btnOK.Visible = false;
                lbQuestion.Visible = true;
            }
            else
            {
                btnNo.Visible = false;
                btnYes.Visible = false;
                btnOK.Visible = true;
                lbQuestion.Visible = false;
                Text = ClassLibrary.JLanguages._Text("Error");
            }
            /// سه رقم جدا برای ستونهای مبلغ
            for (int i = 1; i < grdPaidBefor.Columns.Count; i++)
            {
                grdPaidBefor.DefaultCellStyle.Format = "N0";
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }    
    }
}
