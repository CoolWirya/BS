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
    public partial class JCandidasForm : ClassLibrary.JBaseForm
    {
        int _PollingCode;
        public JCandidasForm(int PollingCode)
        {
            InitializeComponent();
            _PollingCode = PollingCode;
            LoadCandida();
        }
        private void LoadCandida()
        {
            JPollingCandidas polling = new JPollingCandidas();
            jJanusGrid1.DataSource = polling.GetData(_PollingCode, 0);
            jJanusGrid1.Columns["PollingCode"].Visible = false;
            jJanusGrid1.Columns["Title"].Width = 300;
            jJanusGrid1.ShowNavigator = false;
            jJanusGrid1.ShowToolbar = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (personAgent.SelectedCode > 0 || txtTitle.Text.Trim()!="")
            {
                JPollingCandida candida = new JPollingCandida();
                candida.PollingCode = _PollingCode;
                candida.PCode = personAgent.SelectedCode;
                candida.Title = txtTitle.Text;
                if (!candida.Exists())
                {
                    candida.Insert();
                    LoadCandida();
                }
                else
                {
                    JMessages.Error("این کد قبلا وارد شده است.", "");
                }
            }
            else
            {
                JMessages.Error("لطفاً کد شخص یا عنوان را وارد کتید.", "");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                int code = Convert.ToInt32(jJanusGrid1.SelectedRow["Code"]);
                JPollingCandida candida = new JPollingCandida(code);
                if (candida.Delete())
                    LoadCandida();
            }
        }

    }
}
