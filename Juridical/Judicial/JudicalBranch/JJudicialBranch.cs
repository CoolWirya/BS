using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JJudicialBranchForm : ClassLibrary.JBaseForm
    {
        JJudicialBranch _newJudicialBranch;

        public JJudicialBranchForm()
        {
            InitializeComponent();
            _newJudicialBranch = new JJudicialBranch();
            _fillComboBox();

        }
        public JJudicialBranchForm(int pCode)
        {
            InitializeComponent();
            _newJudicialBranch = new JJudicialBranch(pCode);
            showData();
            _fillComboBox();
        }
        public void _fillComboBox()
        {
            JJudicialComplex NullJudicialComplex = new JJudicialComplex();
            NullJudicialComplex.Name = "------------";
            NullJudicialComplex.Code = -1;
            cmbJudicalComplex.Items.Add(NullJudicialComplex);
            cmbJudicalComplex.SelectedItem = NullJudicialComplex;
            JJudicialComplexs Jcs = new JJudicialComplexs();
            Jcs.getData();
            foreach (JJudicialComplex Jc in Jcs.items)
            {
                cmbJudicalComplex.Items.Add(Jc);
                if (_newJudicialBranch.Code != 0 && _newJudicialBranch.JudicialComplex == Jc.Code)
                {
                    cmbJudicalComplex.SelectedItem = Jc;
                }
            }
        }

        private void showData()
        {
            txtCode.Text = Convert.ToString(_newJudicialBranch.Code);
            txtName.Text = _newJudicialBranch.Name;
            cmbJudicalComplex.Text =Convert.ToString(_newJudicialBranch.JudicialComplex);
            txtAddress.Text = _newJudicialBranch.Address;
            txtTel.Text = Convert.ToString(_newJudicialBranch.Tel);
            txtFax.Text = Convert.ToString(_newJudicialBranch.Fax);
        }
        private bool _Save()
         {
            #region CheckField
            #endregion
            _newJudicialBranch = new JJudicialBranch();       
            _newJudicialBranch.Name = txtName.Text;
            _newJudicialBranch.JudicialComplex = ((JJudicialComplex)cmbJudicalComplex.SelectedItem).Code;
            _newJudicialBranch.City = ((JJudicialComplex)cmbJudicalComplex.SelectedItem).City;
            _newJudicialBranch.Address = txtAddress.Text;   
            _newJudicialBranch.Tel = txtTel.Text;
            _newJudicialBranch.Fax = txtFax.Text;
            if (this.State == ClassLibrary.JFormState.Insert)
            {
                int _Code = _newJudicialBranch.Insert();
                txtCode.Text = _Code.ToString();
                return true;
            }
            else if (this.State == ClassLibrary.JFormState.Update)
            {
                _newJudicialBranch.Code = Convert.ToInt32(txtCode.Text);
                _newJudicialBranch.Update();
                return true;
            }
           
            return false;

        }



        private void Save_Click(object sender, EventArgs e)
        {
            if (_Save())
            Close();
            
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (_Save())
            {
                OK.Enabled = false;
                this.State = JFormState.Update;
            }
        }

      

        private void cmbJudicalComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            JSubBaseDefine newcity = new JSubBaseDefine (1,((JJudicialComplex)cmbJudicalComplex.SelectedItem).City);
            labCity.Text = newcity.Name;
            JJudicialComplex JudicialComplex =new JJudicialComplex (((JJudicialComplex)cmbJudicalComplex.SelectedItem).Code);
            txtAddress.Text = JudicialComplex.Address;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
          
    }
}
