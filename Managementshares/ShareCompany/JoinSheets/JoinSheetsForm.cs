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
    public partial class JoinSheetsForm : JBaseForm
    {
        int CompanyCode;
        public JoinSheetsForm(int pCompanyCode)
        {
            InitializeComponent();
            CompanyCode = pCompanyCode;
        }
        private void grdCompanies_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            grdIncreaseHistory.DataSource = JIncreaseShares.GetJoinHistory(CompanyCode);
        }

        private void JoinSheetsForm_Shown(object sender, EventArgs e)
        {
            grdCompanies.DataSource = JShareCompanies.GetDataTable(CompanyCode);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            JoinSheetsNewForm form = new JoinSheetsNewForm(CompanyCode);
            if (form.ShowDialog() == DialogResult.OK)
            {
                grdCompanies_CellEnter(null, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
