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
    public partial class JExecutiveSearchForm : ClassLibrary.JBaseForm
    {
        public int _Code;
        public int _DecisionCode=0;

        public JExecutiveSearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JExecutive tmp = new JExecutive();
            tmp.ExecuteDate = txtDate.Date;
            tmp.ExecuteNum = txtNumClase.Text.Trim();
            tmp.ExeNum = txtNumClase2.Text.Trim();
            tmp.ExeDesc = txtDesc.Text.Trim();
            tmp.DecisionCode = _DecisionCode;
            jdgvSearch.DataSource = tmp.Search(txtEndDate.Date);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (jdgvSearch.CurrentRow != null)
            {
                _Code = Convert.ToInt32(jdgvSearch.CurrentRow.Cells["Code"].Value);
                Close();
            }
        }

        private void jdgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void btnSearchPetition_Click(object sender, EventArgs e)
        {
            JDecisionSearchForm tmp = new JDecisionSearchForm();
            tmp.ShowDialog();
            _DecisionCode = tmp._Code;
            JDecision tmpdecision = new JDecision(_DecisionCode);
            txtNumber.Text = tmpdecision.number;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDate.Text = "";
            txtDesc.Text = "";
            txtEndDate.Text = "";
            txtNumber.Text = "";
            txtNumClase.Text = "";
            txtNumClase2.Text = "";
            _DecisionCode = 0;
        }

        private void JExecutiveSearchForm_Load(object sender, EventArgs e)
        {

        }
    }
}
