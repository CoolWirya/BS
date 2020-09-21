using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;


namespace Estates
{
    public partial class JSearchGroundForm : JBaseForm
    {
        public int Code = 0;
        public string _SQLQuery = "";
        JGround Ground;

        public JSearchGroundForm()
        {
            InitializeComponent();
            FillComboBox();
           
        }
        
        private void FillComboBox()
        {
           JLand nullLand = new JLand(0);
            nullLand.Code = -1;
            nullLand.Name = "-----------";

            cmbLand.Items.Clear();
            cmbLand.Items.Add(nullLand);
            cmbLand.SelectedItem = nullLand;          
           
           
            JLands lands = new JLands();
            foreach (JLand land in lands.Items)
            {
                cmbLand.Items.Add(land);
               
            }
            JUsageGrounds Usages = new JUsageGrounds();
            JUsageGround NullUsage = new JUsageGround();
            NullUsage.Code = -1;
            NullUsage.Name = "-----------";
            cmbUsage.Items.Clear();
            cmbUsage.Items.Add(NullUsage);
            cmbUsage.SelectedItem = NullUsage;
            Usages.GetData();
            foreach (JUsageGround usage in Usages.items)
            {
                cmbUsage.Items.Add(usage);
                
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            Ground = new JGround();
            if (txtArea.Text != "")
            {
                Ground.Area = Convert.ToInt32(txtArea.Text);
            }
            else
            {
                Ground.Area = 0;
            }
            Ground.BlockNum = txtBlockNum.Text;
            if (((JLand) cmbLand.SelectedItem).Code!=-1 )
            {
                Ground.Land = ((JLand)cmbLand.SelectedItem).Code;
                
            }
           
            Ground.MainAve = txtMainAve.Text;
            Ground.PartNum = txtPartNum.Text;
            if (((JUsageGround) cmbUsage.SelectedItem).Code!= -1)
            {
                Ground.Usage = ((JUsageGround)cmbUsage.SelectedItem).Code;
                
            }
            
            Ground.SubNo = txtSubAve.Text;
            dgvGround.DataSource = JGrounds.SearchGround(Ground);
            Ground.Section = txtSection.Text;
            Ground.PartNum = txtPartNum.Text;
            
        }

        

        private void dgvGround_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Code = Convert.ToInt32(dgvGround.Rows[dgvGround.CurrentRow.Index].Cells[0].Value);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvGround.RowCount == 0)
                return;
            Code = Convert.ToInt32(dgvGround.Rows[dgvGround.CurrentRow.Index].Cells[0].Value);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dgvGround_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void jDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnConfirm_Click(btnConfirm, null);

        }

     
        
    }
}
