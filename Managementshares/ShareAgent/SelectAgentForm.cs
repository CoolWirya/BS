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
    public partial class JSelectAgentForm : ClassLibrary.JBaseForm
    {
        public int SelectedCode;
        public DateTime SelectedDate;

        private int CompanyCode;
        public JSelectAgentForm(int pCompanyCode)
        {
            InitializeComponent();
            CompanyCode = pCompanyCode;
            LoadData();
        }
        private void LoadData()
        {
            txtDate.Date = DateTime.Today;
            grdAgents.DataSource = JShareAgents.GetDataTable(JAgentStatus.Enable, 0, CompanyCode);
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (grdAgents.gridEX1.SelectedItems.Count > 0 && grdAgents.gridEX1.SelectedItems[0].GetRow().Cells["Code"] != null)
            {
                SelectedCode = (int)grdAgents.gridEX1.SelectedItems[0].GetRow().Cells["Code"].Value;
                SelectedDate = txtDate.Date;
            }
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void grdAgents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        private void btnNewAgent_Click(object sender, EventArgs e)
        {
            JNewAgentForm form = new JNewAgentForm(0,CompanyCode);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
