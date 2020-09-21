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
    public partial class JAssertionForm : ClassLibrary.JBaseForm
    {
        DataTable _dtPetition = new DataTable();
        DataTable _dtPetition1 = new DataTable();
        DataTable _dtFey = new DataTable();
        DataTable _dtFey1 = new DataTable();
        private int _Code;

        private int _SubjectCode;
        private int _Branch;
        private int _judicial;

        public JAssertionForm()
        {
            InitializeComponent();
            
            /// مقداردهی پراپرتی های لیست آرشیو
            archivePetition.ClassName = "Legal.JAssertion";
            archivePetition.SubjectCode = 0;
            archivePetition.PlaceCode = 0;

        }

        public JAssertionForm(int pCode)
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            archivePetition.ClassName = "Legal.JAssertion";
            archivePetition.SubjectCode = 0;
            archivePetition.PlaceCode = 0;
            PatternDt();
            _Code = pCode;
        }

        #region Methods

        private void PatternDt()
        {
            _dtPetition = JPersonAssertion.GetAllData(-1);
            _dtPetition1 = JPersonAssertion.GetAllData(-1);
            _dtFey = JPersonAssertion.GetAllData(-1);
            _dtFey1 = JPersonAssertion.GetAllData(-1);
        }

        private void JPetitionForm_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
                Set_Form();
        }        

        private void Set_Form()
        {
            JAssertion tmpJAssertion = new JAssertion(_Code);
            txtNumber.Text = tmpJAssertion.Number;
            txtDate.Date = tmpJAssertion.Date;
            txtAnswer.Text = tmpJAssertion.AnswerDescription.ToString();
            txtAssertion.Text = tmpJAssertion.AssertionDescription;
            txtSubject.Text = tmpJAssertion.Subject.ToString();
            //-----------پر کردن اطلاعات خوامده خواهان
            _dtPetition = JPersonAssertion.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Petition);
            _dtPetition1 = JPersonAssertion.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionAdvocate);
            _dtFey = JPersonAssertion.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey);
            jdgvcomplainant.DataSource = _dtPetition;
            jdgvcomplainant1.DataSource = _dtPetition1;
            jdgvFey.DataSource = _dtFey;

            /// مقداردهی پراپرتی های لیست آرشیو
            archivePetition.ClassName = "Legal.JAssertion";
            archivePetition.SubjectCode = 0;
            archivePetition.PlaceCode = 0;
            archivePetition.ObjectCode = _Code;
            btnSave.Enabled = false;

        }

        private bool Save()
        {
            try
            {
                #region CheckField

                if (jdgvcomplainant.RowCount == 0)
                {
                    JMessages.Error("اظهارکننده انتخاب شود.", "error");
                    return false;
                }
                if (jdgvFey.RowCount == 0)
                {
                    JMessages.Error("مخاطب انتخاب شود.","error");
                    return false;
                }
                if (txtNumber.Text == "")
                {
                    JMessages.Error("شماره اظهارنامه را وارد کنید", "error");
                    return false;
                }
                if (txtDate.Text == "")
                {
                    JMessages.Error("تاریخ را وارد کنید", "error");
                    return false;
                }

                # endregion

                    JAssertion tmpJAssertion = new JAssertion();
                    tmpJAssertion.Number = txtNumber.Text.Trim();
                    tmpJAssertion.Date = txtDate.Date;
                    tmpJAssertion.AnswerDescription = txtAnswer.Text.Trim();
                    tmpJAssertion.AssertionDescription = txtAssertion.Text.Trim();
                    tmpJAssertion.Subject = txtSubject.Text.Trim();
                    archivePetition.ClassName = "Legal.JAssertion";
                    archivePetition.SubjectCode = 0;
                    archivePetition.PlaceCode = 0;
                    //---------ویرایش------------
                    if (State == JFormState.Update)
                    {
                        //----------Update Archive------------
                        tmpJAssertion.Code = _Code;
                        archivePetition.ObjectCode = _Code;
                        archivePetition.ArchiveList();
                        if (tmpJAssertion.Update(_dtPetition, _dtPetition1, _dtFey, _dtFey1))
                        {
                            JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                            return true;
                        }
                        else
                            JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
                    }
                    else
                    {
                        //---------درج------------
                        _Code = tmpJAssertion.Insert(_dtPetition, _dtPetition1, _dtFey, _dtFey1);
                        if (_Code>0)
                        {
                            archivePetition.ObjectCode = tmpJAssertion.Code;
                            archivePetition.ArchiveList();
                            JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                            return true;
                        }
                        else
                            JMessages.Message(" Insert Not Successfuly ", "", JMessageType.Error);
                    }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            return false;
        }

        #endregion

        #region Events

        private void btnAddNamecomplainant_Click(object sender, EventArgs e)
        {
            if (txtNameCom.Text != "")
            {
                DataRow dr = _dtPetition.NewRow();
                dr["PersonCode"] = 0;
                dr["Name"] = txtNameCom.Text.Trim();
                dr["PersonType"] = 0;
                _dtPetition.Rows.Add(dr);
                jdgvcomplainant.DataSource = _dtPetition;
                btnSave.Enabled = true;
            }
        }

        private void BtnAddcomplainant_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if ((((_dtPetition.Rows.Count > 0) && (_dtPetition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition.Rows.Count == 0))&&
                        (((_dtFey.Rows.Count > 0) && (_dtFey.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey.Rows.Count == 0)) &&
                        (((_dtPetition1.Rows.Count > 0) && (_dtPetition1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition1.Rows.Count == 0)) &&
                        (((_dtFey1.Rows.Count > 0) && (_dtFey1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey1.Rows.Count == 0)))
                    {

                        DataRow dr = _dtPetition.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        dr["PersonType"] = p.SelectedPerson.PersonType;
                        _dtPetition.Rows.Add(dr);
                        jdgvcomplainant.DataSource = _dtPetition;
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
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

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbPet_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbPetition_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void jComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtRequest_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtReasons_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void numjudicialCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void numPostjudicial_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void archivePetition_AfterFileAdded(object Sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnAddNameAd_Click(object sender, EventArgs e)
        {
            if (txtNameCom1.Text != "")
            {
                DataRow dr = _dtPetition1.NewRow();
                dr["PersonCode"] = 0;
                dr["Name"] = txtNameCom1.Text.Trim();
                dr["PersonType"] = 0;
                _dtPetition1.Rows.Add(dr);
                jdgvcomplainant1.DataSource = _dtPetition1;
                btnSave.Enabled = true;
            }
        }

        private void btnAddcomplainant1_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if ((((_dtPetition.Rows.Count > 0) && (_dtPetition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition.Rows.Count == 0))&&
                        (((_dtFey.Rows.Count > 0) && (_dtFey.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey.Rows.Count == 0)) &&
                        (((_dtPetition1.Rows.Count > 0) && (_dtPetition1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition1.Rows.Count == 0)) &&
                        (((_dtFey1.Rows.Count > 0) && (_dtFey1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey1.Rows.Count == 0)))
                    {
                        DataRow dr = _dtPetition1.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        dr["PersonType"] = p.SelectedPerson.PersonType;
                        _dtPetition1.Rows.Add(dr);
                        jdgvcomplainant1.DataSource = _dtPetition1;
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                DataRow dr = _dtFey.NewRow();
                dr["PersonCode"] = 0;
                dr["Name"] = txtName.Text.Trim();
                dr["PersonType"] = 0;
                _dtFey.Rows.Add(dr);
                jdgvFey.DataSource = _dtFey;
                btnSave.Enabled = true;
            }
        }

        private void jdgvAddFey_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if ((((_dtPetition.Rows.Count > 0) && (_dtPetition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition.Rows.Count == 0)) &&
                        (((_dtFey.Rows.Count > 0) && (_dtFey.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey.Rows.Count == 0)) &&
                        (((_dtPetition1.Rows.Count > 0) && (_dtPetition1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition1.Rows.Count == 0)) &&
                        (((_dtFey1.Rows.Count > 0) && (_dtFey1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey1.Rows.Count == 0)))
                    {
                        DataRow dr = _dtFey.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        dr["PersonType"] = p.SelectedPerson.PersonType;
                        _dtFey.Rows.Add(dr);
                        jdgvFey.DataSource = _dtFey;
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

 
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (MessageBox.Show("DoYouWantToSaveChanges", "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
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

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnDelcomplainant_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvcomplainant.CurrentRow != null)
                {
                    jdgvcomplainant.Rows.Remove(jdgvcomplainant.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelcomplainant1_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvcomplainant1.CurrentRow != null)
                {
                    jdgvcomplainant1.Rows.Remove(jdgvcomplainant1.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelFey_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvFey.CurrentRow != null)
                {
                    jdgvFey.Rows.Remove(jdgvFey.CurrentRow);
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