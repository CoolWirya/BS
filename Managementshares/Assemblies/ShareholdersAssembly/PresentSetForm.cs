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
    public partial class JPresentSetForm : Form
    {
        private int _AssembliesCode;
        public JPresentSetForm(int pAssembliesCode)
        {
            _AssembliesCode = pAssembliesCode;
            InitializeComponent();
            txtCardCode.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Present(false);
            txtCardCode.Focus();
        }

        private void txtCardCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                Present(true);
                txtCardCode.Clear();
                txtCardCode.Focus();
            }
        }

        private void btnPresent_Click(object sender, EventArgs e)
        {
            Present(true);
            txtCardCode.Focus();
        }

        private void Present(bool pPersent)
        {
            try
            {
                JShareholdersAssembly SHA = new JShareholdersAssembly(int.Parse(txtCardCode.Text));
                if (SHA.CCode == _AssembliesCode)
                {
                    SHA.present = pPersent;
                    SHA.PresentDate = JDateTime.Now();
                    SHA.Update();
                    Refresh();
                }
                else
                {
                    JMessages.Error("Error: Invalid Card", "Error");
                }
            }
            catch (Exception ex)
            {
                JMessages.Error("Error:"+ex.Message, "Error");
            }
        }

        private void txtCardCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
            txtCardCode.Focus();
        }

        private void Refresh()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"
                    select isnull(SUM(Share) ,0) share,COUNT(*) count 
                    from dbo.ShareholdersAssembly where present = 1 AND CCode=" + _AssembliesCode.ToString()
                    );
                DataTable DT = DB.Query_DataTable();
                lbPersonCount.Text = DT.Rows[0]["Count"].ToString();
                lbShareCount.Text = DT.Rows[0]["share"].ToString();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
