using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace Bascol
{
    public partial class JConfigBascolForm : Globals.JBaseForm
    {
        public JConfigBascolForm()
        {
            InitializeComponent();
        }

        private void JConfigBascolForm_Load(object sender, EventArgs e)
        {
            cmbBascol.DataSource = JReport.GetBascols(0);
            cmbBascol.DisplayMember = "Code";
            cmbBascol.ValueMember = "Code";
            cmbBascol.SelectedValue = JReport.GetBascoolNumber();
            cmbBascolType.SelectedIndex =JReport.GetBascoolType();
            //if (Globals.JRegistry.Read("BascolNum") != null)
            //    cmbBascol.SelectedValue = Convert.ToInt32(Globals.JRegistry.Read("BascolNum"));
            //if (Globals.JRegistry.Read("BascolType") != null)
            //    cmbBascolType.Text = Globals.JRegistry.Read("BascolType").ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(JPermission.CheckPermission("Bascol.JConfigBascolForm.btnSave_Click")))
                return;
            if (JReport.SetBascoolNumber(Convert.ToInt32(cmbBascol.SelectedValue), cmbBascolType.SelectedIndex))
                JMessages.Information(" با موفقیت ثبت شد ", "");
            //Globals.JRegistry.Write("BascolNum", cmbBascol.SelectedValue);
            //Globals.JRegistry.Write("BascolType", cmbBascolType.Text);
        }
    }
}
