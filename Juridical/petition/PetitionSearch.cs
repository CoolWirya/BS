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
    public partial class JPetitionSearchForm : ClassLibrary.JBaseForm
    {
        public int _Code;
        public JPetitionSearchForm()
        {
            InitializeComponent();
        }

        private void FillCombo()
        {
            JDefineSubjectTypes Subjects = new JDefineSubjectTypes();
            cmbSubject.Items.Clear();
            Subjects.SetComboBox(cmbSubject);
            //foreach (JSubBaseDefine Subject in Subjects.Items)
            //    cmbSubject.Items.Add(Subject);
            //------------مجتمع قضائی
            JJudicialComplexs Jcs = new JJudicialComplexs();
            Jcs.getData();
            foreach (JJudicialComplex Jc in Jcs.items)
                cmbJudicalComplex.Items.Add(Jc);               
            //cmbJudicalComplex.SelectedIndex = 0;
            //------------شعبه قضائی
            //JJudicialComplex tmpJJudicialComplex = new JJudicialComplex();
            //cmbBranch.DisplayMember = "Name";
            //cmbBranch.ValueMember = "Code";
            //cmbBranch.DataSource = JJudicialComplex.ListBranch(((Legal.JJudicialComplex)(cmbJudicalComplex.SelectedItem)).Code);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JPetition tmpJPetition = new JPetition();
            if (rbFey.Checked) tmpJPetition.Type = ClassLibrary.Domains.Legal.JPetitionType.Fey;
            else if (rbPetition.Checked) tmpJPetition.Type = ClassLibrary.Domains.Legal.JPetitionType.Petition;
            tmpJPetition.Number = txtNumber.Text.Trim();
            tmpJPetition.Date = txtDate.Date;
            if (cmbSubject.SelectedItem != null)
                tmpJPetition.Subject_Code = Convert.ToInt32(cmbSubject.SelectedValue);
            if (cmbBranch.Text != "")
            tmpJPetition.judicialCode = Convert.ToInt32(cmbBranch.SelectedValue);
            //tmpJPetition.PostReferCode = numPostjudicial.Text;
            //tmpJPetition.judicialCode = Convert.ToInt32(cmbBranch.SelectedValue);
            tmpJPetition.RequestDescription = txtRequest.Text.Trim();
            tmpJPetition.ReasonsDescription = txtReasons.Text.Trim();
            jdgvPetition.DataSource = tmpJPetition.Search(txtDateEnd.Date);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (jdgvPetition.CurrentRow != null)
            {
                _Code = Convert.ToInt32(jdgvPetition.CurrentRow.Cells["Code"].Value);
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void jdgvPetition_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void cmbJudicalComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            JJudicialComplex tmpJJudicialComplex = new JJudicialComplex();
            cmbBranch.DisplayMember = "Name";
            cmbBranch.ValueMember = "Code";
            cmbBranch.DataSource = JJudicialComplex.ListBranch(((Legal.JJudicialComplex)(cmbJudicalComplex.SelectedItem)).Code);
        }

        private void JPetitionSearchForm_Load(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber.Text = "";
            txtDate.Text = "";
            cmbJudicalComplex.Text = "";
            cmbBranch.Text = "";
            cmbSubject.Text = "";
            txtRequest.Text = "";
            txtReasons.Text = "";
            txtDateEnd.Text = "";
        }

    }
}
