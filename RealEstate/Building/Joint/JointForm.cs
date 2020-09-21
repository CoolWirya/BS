using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RealEstate.Building.Joint;
using ClassLibrary;

namespace RealEstate
{
    public partial class JJointForm : Globals.JBaseForm
    {
        private JJoint _JJoint;
        private void FillCombobox()
        {
            cmbComplex.DisplayMember = estMarket.Title.ToString();
            cmbComplex.ValueMember = estMarket.Code.ToString();
            cmbComplex.DataSource = jMarkets.GetDataTable(0);
        }
        public JJointForm(JJoint pJJoint)
        {
            InitializeComponent();
            _JJoint = pJJoint;
            txtCode.Text = _JJoint.Code.ToString();
            txtType.Text = _JJoint.Type.ToString();
            FillCombobox();
            cmbComplex.SelectedValue =Convert.ToInt32( _JJoint.MarketCode);

        }

        public JJointForm()
        {
            InitializeComponent();
            FillCombobox();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            if (State == ClassLibrary.JFormState.Insert)
            {
                _JJoint = new JJoint();
                _JJoint.Type = txtType.Text;
                _JJoint.MarketCode = Convert.ToInt32(cmbComplex.SelectedValue);
                int _code = _JJoint.Insert();
                if (_code>0)
                {
                    JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                   
                }
                else
                {
                    JMessages.Message("  در بروز رسانی اطلاعات مشکلی بروز کرده است یا مورد تکراری است ", "", JMessageType.Information);
                }
              
            }
            else
            {
                _JJoint.Type = txtType.Text;
                _JJoint.MarketCode = Convert.ToInt32(cmbComplex.SelectedValue);
                if (_JJoint.Update())
                {
                    JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                }
                else
                {
                    JMessages.Message("در بروز رسانی اطلاعات مشکلی بروز کرده است ", "", JMessageType.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JJointForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnviromentSetPrimaryowenerForm Def = new EnviromentSetPrimaryowenerForm();
            Def.ShowDialog();
        }

    }
}
