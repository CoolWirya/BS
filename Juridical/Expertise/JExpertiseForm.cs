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
    public partial class JExpertiseForm : JBaseForm
    {
        private int _PetitionCode;
        JExpertise Expertise;
        public JExpertiseForm()
        {
            InitializeComponent();
            Expertise = new JExpertise();
        }

        public JExpertiseForm(int pCode)
        {
            InitializeComponent();
            Expertise = new JExpertise(pCode);
            SetForm();
            _PetitionCode = Expertise.PetitionCode;
            
        }

        

        private void SetForm()
        {           
                txtExpertiseComment.Text = Expertise.Comment;
                JPetition tmpJPetition = new JPetition(Expertise.PetitionCode);
                txtNumber.Text = tmpJPetition.Number;
                JJudicialBranch tmpJJudicialBranch = new JJudicialBranch(tmpJPetition.judicialCode);
                JJudicialComplex tmpJJudicialComplex = new JJudicialComplex(tmpJJudicialBranch.JudicialComplex);
                txtJudicialNew.Text = tmpJJudicialBranch.Name.ToString();
                txtBranchNew.Text = tmpJJudicialComplex.Name.ToString();

                txtSubject.Text = (new JSubBaseDefine(JBaseDefine.PetitionSubjectTypes, tmpJPetition.Subject_Code)).Name;
                dgvFeyn.DataSource = JPersonPetition.GetAllDataType(Expertise.PetitionCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey);           
        }
           

        private void btnSearchPetition_Click(object sender, EventArgs e)
        {
            JPetitionSearchForm tmpfrm = new JPetitionSearchForm();
            tmpfrm.ShowDialog();
            _PetitionCode = tmpfrm._Code;
            JPetition tmpJPetition = new JPetition(_PetitionCode);
            txtNumber.Text = tmpJPetition.Number;
            JJudicialBranch tmpJJudicialBranch = new JJudicialBranch(tmpJPetition.judicialCode);
            JJudicialComplex tmpJJudicialComplex = new JJudicialComplex(tmpJJudicialBranch.JudicialComplex);
            txtJudicialNew.Text = tmpJJudicialBranch.Name.ToString();
            txtBranchNew.Text = tmpJJudicialComplex.Name.ToString();
            txtSubject.Text = (new JSubBaseDefine(JBaseDefine.PetitionSubjectTypes, tmpJPetition.Subject_Code)).Name;
            dgvFeyn.DataSource = JPersonPetition.GetAllDataType(_PetitionCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey);
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            Expertise.PetitionCode = _PetitionCode;
            Expertise.Comment = txtExpertiseComment.Text;
            if (this.State == JFormState.Insert)
            {
                if (Expertise.Insert() > 0)
                {
                    btnSave.Enabled = false;
                    JMessages.Information(JLanguages._Text("Information Save"), "");
                    this.State = JFormState.Update;
                }
            }
            else if(this.State==JFormState.Update)
            {
                if (Expertise.upDate())
                {
                    btnSave.Enabled = false;
                    JMessages.Information(JLanguages._Text("Information Update"), "");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        } 
    }
}
