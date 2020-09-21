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
    public partial class SearchEmpForm : JBaseForm
    {
        public int _Code;

        public SearchEmpForm()
        {
            InitializeComponent();
        }

        private void SearchEmpForm_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        private void Search()
        {
            try
           {
                string Where = "";
                if (rbActive.Checked)
                    Where = Where + " And Active=1";
                else
                    Where = Where + " And Active=0";
                if (txtName.Text != "")
                    Where = Where + " And PCode in (select Code From clsPerson where Fam Like N'%" + txtName.Text + "%')";
                DataTable dt = JEmployeeInfos.GetDataTableByPCode(0, Where);
                jdgvSeperation.DataSource = dt;
                //jdgvSeperation.Focus();
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
                //return null;
            }
        }

        private void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void rbNoActive_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void jDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jdgvSeperation.CurrentRow != null)
            {
                _Code = Convert.ToInt32(jdgvSeperation.CurrentRow.Cells["Code"].Value.ToString());
                this.Close();
            }
            else
                _Code = 0;
        }

        private void jdgvSeperation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                jDataGrid1_CellDoubleClick(null, null);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            Search();            
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            jdgvSeperation.Focus();
        }
    }
}
