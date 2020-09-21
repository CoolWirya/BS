using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace AUTOMOBILE.AutomobileDefine
{
    public partial class JAutomobileSearch : ClassLibrary.JBaseForm
    {


        public int SelectedCode = 0;
        public JAutomobileSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string str = txtPlak1.Text + cmbPlak.Text + txtPlak2.Text + "-" + txtPlak3.Text;

                DB.setQuery("SELECT * FROM AUTAutomobile WHERE plaque LIKE '%" + str + "%'");
                jJanusGridResault.DataSource = DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (jJanusGridResault.gridEX1.CurrentRow != null)
            {
                SelectedCode =  (int)((DataRowView)jJanusGridResault.gridEX1.CurrentRow.DataRow).Row["Code"];
            }
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
