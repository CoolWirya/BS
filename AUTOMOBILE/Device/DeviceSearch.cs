using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
namespace AUTOMOBILE.Device
{
    public partial class JDeviceSearch : ClassLibrary.JBaseForm
    {
        public int SelectedCode = 0;
        public string ID;
        public JDeviceSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string str = txtMac.Text;

                DB.setQuery("SELECT * FROM AUTDevice WHERE MacAddress LIKE '%" + str + "%'");
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
                SelectedCode = (int)((DataRowView)jJanusGridResault.gridEX1.CurrentRow.DataRow).Row["Code"];
                ID = ((DataRowView)jJanusGridResault.gridEX1.CurrentRow.DataRow).Row["ID"].ToString();
            }
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void jJanusGridResault_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMac_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
