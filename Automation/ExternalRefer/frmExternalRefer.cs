using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Employment;
using Communication;
using Globals;

namespace Automation
{
    public partial class JExternalRefer : Globals.JBaseForm
    {
        public JExternalRefer()
        {
            InitializeComponent();
        }


        private void JExternalRefer_Load(object sender, EventArgs e)
        {
            dgRefer.Bind(Search(), "ExternalRefer");
        }

        private DataTable Search()
        {
            string Expression = "";
            if (!String.IsNullOrEmpty(txtReceiver.Text))
            {
                Expression = " And " + ExternalRefer.receiver_external_code + " Like '%" + txtReceiver.Text + "%'";
                JAExternalRefer tmp = new JAExternalRefer();
                if (ckSent.Checked)
                    Expression = Expression + " And " + ExternalRefer.ConfirmReceiver + "= True ";
                else
                    Expression = Expression + " And " + ExternalRefer.ConfirmReceiver + "= False ";
                return tmp.GetList(Expression);
            }
            else
                return null;
        }

        private void cdbReferExternal_Leave(object sender, EventArgs e)
        {
           dgRefer.Bind(Search(), "ExternalRefer");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            JAExternalRefer tmp=new JAExternalRefer();
            if (dgRefer.SelectedRow != null)
            {
                tmp.GetData(Convert.ToInt32(dgRefer.SelectedRow.Cells["Code"].ToString()));
                tmp.Send_Date = JMainFrame.GlobalDataBase.GetCurrentDateTime();
                tmp.ConfirmReceiver = true;
                if(tmp.Update())
                   JMessages.Message("Update Successfully ", "Update", JMessageType.Information);
                else
                   JMessages.Message("Update Not Successfully ", "Update", JMessageType.Information);
            }
            else
                JMessages.Message("Please Selected Row ", "Selected", JMessageType.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void txtReceiver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)            
                Search();            
        }

    }
}
