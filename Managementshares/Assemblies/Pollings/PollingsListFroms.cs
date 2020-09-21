using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JPollingsListFroms : ClassLibrary.JBaseForm
    {
        int _AssemblyCode;
		int _CompanyCode;
        public JPollingsListFroms(int ACode, int pCompanyCode)
        {
            InitializeComponent();
			_CompanyCode = pCompanyCode;
            _AssemblyCode = ACode;
            ShowData();
        }
        private void ShowData()
        {
            JPollings pollings = new JPollings(_AssemblyCode);
            jJanusGrid1.DataSource = pollings.GetData(0);
            jJanusGrid1.Columns["Title"].Width = 300;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            JPollingForm form = new JPollingForm(_AssemblyCode, 0);
            if (form.ShowDialog() == DialogResult.OK)
                ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                int pollingCode = Convert.ToInt32(jJanusGrid1.SelectedRow["Code"]);
                JCandidasForm form = new JCandidasForm(pollingCode);
                form.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                int pollingCode = Convert.ToInt32(jJanusGrid1.SelectedRow["Code"]);
                JPollingForm form = new JPollingForm(_AssemblyCode, pollingCode);
                if (form.ShowDialog() == DialogResult.OK)
                    ShowData();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                int pollingCode = Convert.ToInt32(jJanusGrid1.SelectedRow["Code"]);
                JPolling polling = new JPolling(pollingCode);
                if (polling.Delete())
                    ShowData();
            }
        }

        private void btnCountPolling_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                int pollingCode = Convert.ToInt32(jJanusGrid1.SelectedRow["Code"]);
                JCountPollingList form = new JCountPollingList(pollingCode, _AssemblyCode,_CompanyCode);
              //  form.Text = jJanusGrid1.SelectedRow["Title"].ToString();
                form.ShowDialog();
            }
        }
         
    }
}
