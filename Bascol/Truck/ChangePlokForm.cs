using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Bascol
{
    public partial class JChangePlokForm : JBaseForm
    {
        int _Code;

        public JChangePlokForm()
        {
            InitializeComponent();
        }

        private void Fill()
        {
            gridPlok.bind(JReport.GetPlok(), "Plok");

            cmbTruck.DataSource = JTruck.GetDataTable(0); ;
            cmbTruck.DisplayMember = "FullName";
            cmbTruck.ValueMember = "Code";
        }

        private void JChangePlokForm_Load(object sender, EventArgs e)
        {
            _Code = 0;
            Fill();            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string Query = @" 
delete from BascolPlakTruck Where Code= " + _Code + @"
Insert into BascolPlakTruck Values ('" + lblPlok.Text + "'," + cmbTruck.SelectedValue.ToString()+ ")";
            //JDataBase db = new JDataBase();
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase db = tmpJTransferData.CreateConMainServer(false);
            try
            {
                db.setQuery(Query);
                if (db.Query_Execute() > 0)
                {
                    Fill();
                    JMessages.Confirm(" تایید شد ", "");
                }
                else
                    JMessages.Error(" تایید نشد ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        private void gridPlok_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
DataRowView SelectedRow = ((DataRowView)gridPlok.SelectedRow);
            _Code = Convert.ToInt32(SelectedRow.Row["Code"]);
            lblPlok.Text = SelectedRow.Row["PlokNo"].ToString();
            cmbTruck.SelectedValue = Convert.ToInt32(SelectedRow.Row["TruckCode"]);
        }
    }
}
