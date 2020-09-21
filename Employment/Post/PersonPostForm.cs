using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JEPersonPostForm : JBaseForm
    {
        public JEPersonPostForm()
        {
            InitializeComponent();
            JSubBaseDefines states = new JSubBaseDefines(JBaseDefine.States);
            foreach (JSubBaseDefine state in states.Items)
            {
                cmbState.Items.Add(state);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContractCode.Text == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "کد قرارداد" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Message(msg, "", JMessageType.Error);
                txtContractCode.Focus();
                return;              
            }
            if (cmbState.SelectedIndex == -1)
            {
                JMessages.Message("PleaseSelectState", "", JMessageType.Information);
                cmbState.Focus();
                return;
            }
            JEPersonPost pPost = new JEPersonPost(Convert.ToInt32(txtPCode.Text));
            pPost.ContractCode =Convert.ToInt32(txtContractCode.Text);
            pPost.DateEnd =JDateTime.GregorianDate(txtDateEnd.Text);
            pPost.DateStart = JDateTime.GregorianDate(txtDateStart.Text);
            //pPost.PCode =
            pPost.PostCode = Convert.ToInt32(txtOrganPost.Text);
            pPost.State = ((JSubBaseDefine)cmbState.SelectedItem).Code;
            pPost.Insert();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
