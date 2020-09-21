using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estates
{
    public partial class JUsageGroundForm : ClassLibrary.JBaseForm
    {
        private JUsageGround _newUsage;
        public JUsageGroundForm()
        {
            InitializeComponent();
            
        }
        public JUsageGroundForm(int pCode)
        {
            InitializeComponent();
            _newUsage = new JUsageGround(pCode);
            ShowData();

        }
      

        private void Save_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim()=="")
            {
                return;
            }

            _newUsage = new JUsageGround(); 
            _newUsage.Name= txtName.Text;
            _newUsage.Density = txtDensity.Text;
            _newUsage.Persent = numPercent.IntValue;
            _newUsage.Parking = txtParking.Text;
            _newUsage.Access  = txtAccess.Text;
            _newUsage.Comment = txtComment.Text;
            if (this.State == ClassLibrary.JFormState.Insert)
            {
                _newUsage.Insert();
            }
            else
            {
                _newUsage.Code = Convert.ToInt32(labCode.Text);
                _newUsage.Update();

            }
            Close();


        }

     

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ShowData()
        {
            labCode.Text = Convert.ToString(_newUsage.Code);
            txtName.Text = _newUsage.Name;
            txtDensity.Text = _newUsage.Density;
            numPercent.Text =Convert.ToString(_newUsage.Persent);
            txtParking.Text = _newUsage.Parking;
            txtAccess.Text = _newUsage.Access;
            txtComment.Text = _newUsage.Comment;

        }
    }
}
