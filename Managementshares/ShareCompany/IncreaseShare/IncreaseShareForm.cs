using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;

namespace ManagementShares
{
    public partial class JIncreaseShareForm : JBaseForm
    {
        int CompanyCode;
        public JIncreaseShareForm(int pCompanyCode)
        {
            InitializeComponent();
            CompanyCode = pCompanyCode;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void grdCompanies_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            grdIncreaseHistory.DataSource = JIncreaseShares.GetIncreaseHistory(CompanyCode);
        }

        private void JIncreaseShareForm_Shown(object sender, EventArgs e)
        {
            grdCompanies.DataSource = JShareCompanies.GetDataTable(CompanyCode);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            JNewIncreaseShareForm form = new JNewIncreaseShareForm(CompanyCode);
            if (form.ShowDialog() == DialogResult.OK)
            {
                grdCompanies_CellEnter(null, null);
            }
        }

    }
}
