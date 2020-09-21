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
    public partial class JJudicialComplexForm : ClassLibrary.JBaseForm
    {
        JJudicialComplex _newJudicalComplex;
        public JJudicialComplexForm()
        {
            InitializeComponent();
            
            _newJudicalComplex = new JJudicialComplex();
            FillComboBox();
        }
        public JJudicialComplexForm(int pCode)
        {
            InitializeComponent();
            _newJudicalComplex = new JJudicialComplex(pCode);
            FillComboBox();
            Show();
        }

        private void JJudicialComplex_Load(object sender, EventArgs e)
        {
            if (this.State ==JFormState.Update)
            {
                txtCode.ReadOnly = true;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                string[] Values = { "Name" };
                string[] Params = { "@Value" };
                string msg = JLanguages._Text("PleaseEnter", Params, Values);
                JMessages.Error(msg, "Error");
                txtName.Focus();
                return;
            }
            if (cmbCity.SelectedIndex == -1)
            {
                string[] Values = { "City" };
                string[] Params = { "@Value" };
                string msg = JLanguages._Text("PleaseEnter", Params, Values);
                JMessages.Error(msg, "Error");
                return;
            }
            _newJudicalComplex.Name = txtName.Text;
            _newJudicalComplex.City = Convert.ToInt32(cmbCity.SelectedValue);
            _newJudicalComplex.Address = txtAddress.Text;
            _newJudicalComplex.Tel = txtTel.Text;
            _newJudicalComplex.Fax = txtFax.Text;
            _newJudicalComplex.SupervisorNameComplex = txtSupervisorNameComplex.Text;
            if (this.State ==ClassLibrary.JFormState.Insert)
            {
                _newJudicalComplex.Insert();
            }
            else
            {
                _newJudicalComplex.Update();
            }
            Close();

        }
        private void FillComboBox()
        {
            JCities Cities = new JCities();
            JSubBaseDefine nullDeff = new JSubBaseDefine(0);
            nullDeff.Code = -1;
            nullDeff.Name = "-----------";
            cmbCity.Items.Clear();
            cmbCity.Items.Add(nullDeff);
            cmbCity.SelectedItem = nullDeff;
            Cities.SetComboBox(cmbCity, _newJudicalComplex.Code);
            //foreach (JSubBaseDefine city in Cities.Items)
            //{
            //    cmbCity.Items.Add(city);
            //    if (_newJudicalComplex.Code != 0 && _newJudicalComplex.City == city.Code)
            //        cmbCity.SelectedItem = city;
            //}
        }
        private void Show()
        {

            txtCode.Text = Convert.ToString(_newJudicalComplex.Code);
            txtName.Text = _newJudicalComplex.Name;
            txtAddress.Text = _newJudicalComplex.Address;
            txtTel.Text = Convert.ToString(_newJudicalComplex.Tel);
            txtFax.Text = Convert.ToString(_newJudicalComplex.Fax);
            txtSupervisorNameComplex.Text = _newJudicalComplex.SupervisorNameComplex;
            cmbCity.SelectedValue = _newJudicalComplex.City;
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            if (dataGridViewBranch.DataSource != null)
            {
                ((DataTable)dataGridViewBranch.DataSource).Dispose();
            }
            dataGridViewBranch.DataSource = JJudicialComplex.ListBranch(_newJudicalComplex.Code);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            this.Text = "مجتمع قضائی " + txtName.Text;
        }

        private void btnAddBranch_Click(object sender, EventArgs e)
        {
            //JJudicialBranch branch = new JJudicialBranch();
            //branch.ShowDialog(_newJudicalComplex.Code);
            //dataGridViewBranch.DataSource = JJudicialComplex.ListBranch(_newJudicalComplex.Code);
        }



    }
}
