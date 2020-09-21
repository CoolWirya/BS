using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ManagementShares
{
    public partial class JoinSheetForm : ClassLibrary.JBaseForm
    {
        int[] SCodes;
        public JoinSheetForm(int[] sCodes)
        {
            InitializeComponent();
            SCodes = sCodes;
            SetGrid();
        }

        private void SetGrid()
        {
            try
            {
                DataTable sheets = JShareSheet.GetSheets(SCodes);
                grdSheets.DataSource = sheets;
            }
            catch (Exception ex)
            {

            }
        }

		private void btnSave_Click(object sender, EventArgs e)
		{

		}
    }
}
