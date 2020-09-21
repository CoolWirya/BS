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
    public partial class JCandidasForm : Globals.JBaseForm
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
            JPollingCandidas polling = new JPollingCandidas(_PollingCode);
            jJanusGrid1.DataSource = polling.GetData(0);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (personAgent.SelectedCode > 0)
            {
                JPollingCandida presence = new JPollingCandida();
                presence.PollingCode = _PollingCode;
                presence.PCode = Convert.ToInt32(personAgent.SelectedCode);
                if (!presence.Exists())
                {
                    presence.Insert();
                    LoadCandida();
                }
                else
                {
                    JMessages.Error("این کد قبلا وارد شده است.", "");
                }
            }
            else
            {
                JMessages.Error("لطفاً کد وکیل را وارد کتید.", "");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow != null)
            {
                int code = Convert.ToInt32(jJanusGrid1.SelectedRow["Code"]);
                JPollingCandida candida = new JPollingCandida(code);
                candida.Delete();
            }
        }

    }
}
