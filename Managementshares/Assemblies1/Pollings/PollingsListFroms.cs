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
    public partial class JPollingsListFroms : JBaseForm
    {
        int _AssemblyCode;
        public JPollingsListFroms(int ACode)
        {
            InitializeComponent();
            _AssemblyCode = ACode;
            ShowData();
        }
        private void ShowData()
        {
            JPollings pollings = new JPollings(_AssemblyCode);
            jJanusGrid1.DataSource = pollings.GetData(0);
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

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
