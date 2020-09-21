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
    public partial class JDecisionForm : ClassLibrary.JBaseForm
    {
        public int _PetitionCode;
        public int _Code;
        DataTable _dtAsset = new DataTable();

        public JDecisionForm()
        {
            InitializeComponent();
            chklistType.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("Legal.DecisionType")));
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveِDecision.ClassName = "Legal.JDecision";
            jArchiveِDecision.SubjectCode = 0;
            jArchiveِDecision.PlaceCode = 0;
        }

        public JDecisionForm(int Code)
        {
            InitializeComponent();
            _Code = Code;
            chklistType.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("Legal.DecisionType")));
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveِDecision.ClassName = "Legal.JDecision";
            jArchiveِDecision.SubjectCode = 0;
            jArchiveِDecision.PlaceCode = 0;
            jArchiveِDecision.ObjectCode = _Code;
        }

        private void PatternDt()
        {
            _dtAsset = JFinanceDecision.GetAllByDecision(0);
        }

        private void JDecisionForm_Load(object sender, EventArgs e)
        {
            PatternDt();
            if (State == JFormState.Update)
                Set_Form();
        }

        #region Methods

        private void Set_Form()
        {
            if (State == JFormState.Update)
            {
                
                JDecision tmp = new JDecision(_Code);
                chkAbsencePerson.Checked = tmp.AbsencePerson;
                _PetitionCode = tmp.PetitionCode;
                txtDate.Date = tmp.Date;
                txtNum.Text = tmp.number;

                if (tmp.Conclusive)
                    rbConclusive.Checked = true;
                else
                    rbNoCon.Checked = true;
                if(tmp.Type)
                    rbRay.Checked=true;
                else
                    rbGharar.Checked=true;
                if (tmp.AgainstCompany == JAgainstCompanyType.AgainstCompany)
                    rbAgaints.Checked = true;
                else if (tmp.AgainstCompany == JAgainstCompanyType.Benefit)
                    rbBenefit.Checked = true;
                else
                    if (tmp.AgainstCompany == JAgainstCompanyType.None)
                        rbNone.Checked = true;
                txtDesc.Text = tmp.DecisionDesc;
                JDecisionType tmpDecisionType = new JDecisionType();
                foreach (DataRow dr in tmpDecisionType.GetAllSubject(_Code).Rows)
                    for (int i = 0; i < chklistType.Items.Count; i++)
                    {
                        if (Convert.ToInt32(dr["Type"]) == Convert.ToInt32(((ClassLibrary.JKeyValue)chklistType.Items[i]).Value))
                        {
                            ((ClassLibrary.JKeyValue)chklistType.Items[i]).Value = Convert.ToInt32(dr["Type"]);
                            chklistType.SetItemChecked(i, true);
                        }
                    }
                _dtAsset = JFinanceDecision.GetAllByDecision(_Code);
                jDGlistAsset.DataSource = _dtAsset;
                btnSave.Enabled = false;
            }

            JPetition tmpJPetition = new JPetition(_PetitionCode);
            txtNumber.Text = tmpJPetition.Number;
            //cmbSubject.SelectedValue = tmpJPetition.Subject_Code;
            JJudicialBranch tmpJJudicialBranch = new JJudicialBranch(tmpJPetition.judicialCode);
            JJudicialComplex tmpJJudicialComplex = new JJudicialComplex(tmpJJudicialBranch.JudicialComplex);
            txtJudicial.Text = tmpJJudicialBranch.Name.ToString();
            txtBranch.Text = tmpJJudicialComplex.Name.ToString();

            txtSubject.Text = (new JSubBaseDefine(JBaseDefine.PetitionSubjectTypes, tmpJPetition.Subject_Code)).Name;
            jdgvFey.DataSource = JPersonPetition.GetAllDataType(_PetitionCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey);
            jdgvPetition.DataSource = JPersonPetition.GetAllDataType(_PetitionCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Petition); ;
        }

        private bool Save()
        {
            try
            {
                if (!CheckField())
                    return false;
                JDecision tmpDecision = new JDecision();
                tmpDecision.PetitionCode = _PetitionCode;
                tmpDecision.Date = txtDate.Date;
                tmpDecision.number = txtNum.Text.Trim();
                tmpDecision.AbsencePerson = chkAbsencePerson.Checked;
                if (rbBenefit.Checked)
                    tmpDecision.AgainstCompany = JAgainstCompanyType.Benefit;
                else if (rbAgaints.Checked)
                    tmpDecision.AgainstCompany = JAgainstCompanyType.AgainstCompany;
                else if (rbNone.Checked)
                    tmpDecision.AgainstCompany = JAgainstCompanyType.None;
                if (rbRay.Checked)
                    tmpDecision.Type = true;
                else
                    tmpDecision.Type = false;
                if (rbConclusive.Checked)
                    tmpDecision.Conclusive = true;
                else
                    tmpDecision.Conclusive = false;
                tmpDecision.DecisionDesc = txtDesc.Text.Trim();
                bool flag = false;
                //-------------موضوعات-----------
                List<int> SubjectCode = new List<int>();
                List<int> SubjectCodeDelete = new List<int>();
                for (int i = 0; i < chklistType.Items.Count; i++)
                {
                    if (chklistType.GetItemChecked(i))
                    {
                        SubjectCode.Add(Convert.ToInt32(((ClassLibrary.JKeyValue)chklistType.Items[i]).Value));
                        flag = true;
                    }
                    else
                        SubjectCodeDelete.Add(Convert.ToInt32(((ClassLibrary.JKeyValue)chklistType.Items[i]).Value));
                }

                jArchiveِDecision.ClassName = "Legal.Jdecision";
                jArchiveِDecision.SubjectCode = 0;
                jArchiveِDecision.PlaceCode = 0;                
                if (State == JFormState.Update)//---------ویرایش------------
                {
                    //----------Update Archive------------
                    tmpDecision.Code = _Code;
                    jArchiveِDecision.ObjectCode = _Code;
                    jArchiveِDecision.ArchiveList();
                    if (tmpDecision.Update(SubjectCode, SubjectCodeDelete,_dtAsset))
                    {
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                }
                else
                {
                    _Code = tmpDecision.Insert(SubjectCode,_dtAsset);
                    if (_Code > 0)
                    {
                        jArchiveِDecision.ObjectCode = tmpDecision.Code;
                        jArchiveِDecision.ArchiveList();
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private bool CheckField()
        {
            if (txtNumber.Text == "")
            {
                JMessages.Error("شکوائیه و یا دادخواست را انتخاب کنید.", "error");
                return false;
            }
            if (chklistType.CheckedItems == null)
            {
                JMessages.Error("نوع رای را مشخص کنید.", "error");
                return false;
            }
            if (txtNum.Text == "")
            {
                JMessages.Error("شماره دادنامه را وارد کنید", "error");
                return false;
            }
            return true;
        }

        #endregion

        #region  Events

        private void btnSearchPetition_Click(object sender, EventArgs e)
        {
            JPetitionSearchForm tmpfrm = new JPetitionSearchForm();
            JPetition tmp = new JPetition(_PetitionCode);
            try
            {
                tmpfrm.ShowDialog();
                _PetitionCode = tmpfrm._Code;
                txtNumber.Text = tmp.Number;
                Set_Form();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                tmpfrm.Dispose();
                tmp.Dispose();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (JMessages.Question("DoYouWantToSaveChanges", "Save") == DialogResult.Yes)
                    if (Save())
                        this.Close();
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    this.Close();
            }
            else
                this.Close();
        }

    

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbBenefit_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbAgaints_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbRay_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbGharar_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbConclusive_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbNoCon_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chklistType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

    #endregion

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            try
            {
                Finance.JAssetSearchForm p = new Finance.JAssetSearchForm();
                if (p.ShowDialog() != DialogResult.OK)
                    return;
                Finance.JAsset tmp = new Finance.JAsset(p._Code);
                if (tmp.Code > 0)
                {
                    if (((_dtAsset.Rows.Count > 0) && (_dtAsset.Select("FinanceCode=" + p._Code.ToString()).Length < 1)) || (_dtAsset.Rows.Count == 0))
                    {
                        DataRow dr = _dtAsset.NewRow();
                        dr["FinanceCode"] = p._Code.ToString();
                        dr["Comment"] = SetCommentText(tmp.ClassName, tmp.ObjectCode);
                        _dtAsset.Rows.Add(dr);
                        jDGlistAsset.DataSource = _dtAsset;
                        btnSave.Enabled = true;
                    }
                    else
                        JMessages.Message("Asset is Repeated ", "", JMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAssetCode"></param>
        private string SetCommentText(string pClassName, int pObjectCode)
        {
            JAction CommentAction = new JAction("GetAssetType", pClassName + ".GetAssetComment", new object[] { pObjectCode }, null);
            string Comment = (string)CommentAction.run();

            JAction unitAction = new JAction("GetAssetType", pClassName + ".GetAssetUnit");
            string unit = (string)unitAction.run();

            return Comment;
        }

        private void btnDelAsset_Click(object sender, EventArgs e)
        {
            try
            {
                if (jDGlistAsset.CurrentRow != null)
                {
                    jDGlistAsset.Rows.Remove(jDGlistAsset.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

    }
}
