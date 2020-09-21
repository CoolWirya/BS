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
    public partial class JPetitionForm : ClassLibrary.JBaseForm
    {
        DataTable _dtPetition = new DataTable();
        DataTable _dtPetition1 = new DataTable();
        DataTable _dtFey = new DataTable();
        DataTable _dtFey1 = new DataTable();
        DataTable _dtAsset = new DataTable();
        private int _Code;

        private int _SubjectCode;
        private int _Branch;
        private int _judicial;

        public JPetitionForm()
        {
            InitializeComponent();

            /// مقداردهی پراپرتی های لیست آرشیو
            archivePetition.ClassName = "Legal.JPetition";
            archivePetition.SubjectCode = 0;
            archivePetition.PlaceCode = 0;
        }

        public JPetitionForm(int pCode)
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            archivePetition.ClassName = "Legal.JPetition";
            archivePetition.SubjectCode = 0;
            archivePetition.PlaceCode = 0;
            PatternDt();
            _Code = pCode;
        }

        #region Methods

        private void PatternDt()
        {
            _dtPetition = JPersonPetition.GetAllData(-1);
            _dtPetition1 = JPersonPetition.GetAllData(-1);
            _dtFey = JPersonPetition.GetAllData(-1);
            _dtFey1 = JPersonPetition.GetAllData(-1);
            _dtAsset = JFinancePetition.GetAllByPetition(0);
        }

        private void JPetitionForm_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
                Set_Form();
            FillCombo();
        }

        private void FillCombo()
        {
            JDefineSubjectTypes Subjects = new JDefineSubjectTypes();
            Subjects.SetComboBox(cmbSubject, _SubjectCode);
            //foreach (JSubBaseDefine Subject in Subjects.Items)
            //{
            //    cmbSubject.Items.Add(Subject);
            //    if (_SubjectCode != 0 && _SubjectCode == Subject.Code)
            //        cmbSubject.SelectedItem = Subject;                
            //}
            //------------مجتمع قضائی-----------------

            JJudicialComplexs Jcs = new JJudicialComplexs();
            Jcs.getData();
            JJudicialComplex NullDef = new JJudicialComplex();
            NullDef.Name = "------";
            NullDef.Code = -1;
            cmbJudicalComplex.Items.Add(NullDef);
            cmbJudicalComplex.SelectedItem = NullDef;
            foreach (JJudicialComplex Jc in Jcs.items)
            {
                cmbJudicalComplex.Items.Add(Jc);
                if (_Branch != 0 && _Branch == Jc.Code)
                    cmbJudicalComplex.SelectedItem = Jc;
            }
            if (State == JFormState.Insert)
                cmbJudicalComplex.SelectedIndex = 0;
            //------------شعبه قضائی------------------
            JJudicialComplex tmpJJudicialComplex = new JJudicialComplex();
            cmbBranch.DisplayMember = "Name";
            cmbBranch.ValueMember = "Code";
            cmbBranch.DataSource = JJudicialComplex.ListBranch(((Legal.JJudicialComplex)(cmbJudicalComplex.SelectedItem)).Code);
            if (State == JFormState.Update) cmbBranch.SelectedValue = _judicial;
        }


        private void Set_Form()
        {
            JPetition tmpJPetition = new JPetition(_Code);
            if (tmpJPetition.Type == ClassLibrary.Domains.Legal.JPetitionType.Petition) rbPetition.Checked = true;
            else if (tmpJPetition.Type == ClassLibrary.Domains.Legal.JPetitionType.Fey) rbFey.Checked = true;
            txtNumber.Text = tmpJPetition.Number;
            txtDate.Date = tmpJPetition.Date;
            //cmbSubject.SelectedValue = tmpJPetition.Subject_Code;

            JJudicialBranch tmpJJudicialBranch = new JJudicialBranch(tmpJPetition.judicialCode);
            //cmbJudicalComplex.SelectedValue = tmpJJudicialBranch.JudicialComplex;
            //cmbJudicalComplex_SelectedIndexChanged(null, null);

            //cmbBranch.SelectedValue = tmpJPetition.judicialCode;

            _SubjectCode = tmpJPetition.Subject_Code;
            _Branch = tmpJJudicialBranch.JudicialComplex;
            _judicial = tmpJPetition.judicialCode;

            numPostjudicial.Text = tmpJPetition.PostReferCode.ToString();
            txtRequest.Text = tmpJPetition.RequestDescription;
            txtReasons.Text = tmpJPetition.ReasonsDescription;

            //-----------پر کردن اطلاعات خوامده خواهان
            _dtPetition = JPersonPetition.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Petition);
//          _dtPetition1 = JPersonPetition.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.PetitionAdvocate);
            _dtFey = JPersonPetition.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Fey);
//            _dtFey1 = JPersonPetition.GetAllDataType(_Code, ClassLibrary.Domains.Legal.JPersonPetitionType.FeyAdvocate);
            _dtAsset = JFinancePetition.GetAllByPetition(_Code);
            jdgvcomplainant.DataSource = _dtPetition;
            jdgvcomplainant1.DataSource = _dtPetition1;
            jdgvFey.DataSource = _dtFey;
            jdgvFey1.DataSource = _dtFey1;
            jDGlistAsset.DataSource = _dtAsset;
            /// مقداردهی پراپرتی های لیست آرشیو
            archivePetition.ClassName = "Legal.JPetition";
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
                if (((JJudicialComplex)cmbJudicalComplex.SelectedItem).Code == -1)
                {
                    JMessages.Error(".مجتمع قضایی را انتخاب کنید", "error");
                    return false;
                }
                if (cmbBranch.SelectedItem == null)
                {
                    JMessages.Error(".شعبه قضایی را انتخاب کنید.", "error");
                    return false;
                }
                if (jdgvcomplainant.RowCount == 0 && jdgvcomplainant1.RowCount == 0)
                {
                    JMessages.Error("خواهان انتخاب شود.", "error");
                    return false;
                }
                if (jdgvFey.RowCount == 0 && jdgvFey1.RowCount == 0)
                {
                    JMessages.Error("خوانده  انتخاب شود.", "error");
                    return false;
                }
                if (txtNumber.Text == "")
                {
                    JMessages.Error("شماره دادخواست را وارد کنید", "error");
                    return false;
                }
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error("تاریخ دادخواست را وارد کنید", "error");
                    return false;
                }
                if (((Convert.ToInt32(cmbSubject.SelectedValue)) == null))
                {
                    JMessages.Error("موضوع را انتخاب کنید", "error");
                    return false;
                }
                # endregion

                JPetition tmpJPetition = new JPetition();
                if (rbFey.Checked) tmpJPetition.Type = ClassLibrary.Domains.Legal.JPetitionType.Fey;
                else if (rbPetition.Checked) tmpJPetition.Type = ClassLibrary.Domains.Legal.JPetitionType.Petition;
                tmpJPetition.Number = txtNumber.Text.Trim();
                tmpJPetition.Date = txtDate.Date;
                tmpJPetition.Subject_Code = Convert.ToInt32(cmbSubject.SelectedValue);
                tmpJPetition.judicialCode = Convert.ToInt32(cmbBranch.SelectedValue);
                tmpJPetition.PostReferCode = numPostjudicial.Text;
                tmpJPetition.RequestDescription = txtRequest.Text.Trim();
                tmpJPetition.ReasonsDescription = txtReasons.Text.Trim();
                archivePetition.ClassName = "Legal.JPetition";
                archivePetition.SubjectCode = 0;
                archivePetition.PlaceCode = 0;

                if (State == JFormState.Update)//---------ویرایش------------
                {
                    //----------Update Archive------------
                    tmpJPetition.Code = _Code;
                    archivePetition.ObjectCode = _Code;
                    archivePetition.ArchiveList();
                    if (tmpJPetition.Update(_dtPetition, _dtPetition1, _dtFey, _dtFey1, _dtAsset))
                    {
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                }
                else//---------درج------------
                {
                    _Code = tmpJPetition.Insert(_dtPetition, _dtPetition1, _dtFey, _dtFey1, _dtAsset);
                    if (_Code > 0)
                    {
                        archivePetition.ObjectCode = tmpJPetition.Code;
                        archivePetition.ArchiveList();
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
            return false;
        }

        #endregion

        #region Events

        private void BtnAddcomplainant_Click(object sender, EventArgs e)
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

                        DataRow dr = _dtPetition.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        dr["Type"] = p.SelectedPerson.PersonType;
                        _dtPetition.Rows.Add(dr);
                        jdgvcomplainant.DataSource = _dtPetition;
                        btnSave.Enabled = true;
                    }
                    else
                        JMessages.Message("Person is Repeated ", "", JMessageType.Information);
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

        private void btnAddcomplainant1_Click(object sender, EventArgs e)
        {
            try
            {
                //ClassLibrary.JOtherPersonForm p = new ClassLibrary.JOtherPersonForm();
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                if (p.ShowDialog() != DialogResult.OK)
                    return;
                if (p.SelectedPerson != null)
                {
                    if ((((_dtPetition.Rows.Count > 0) && (_dtPetition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition.Rows.Count == 0)) &&
                        (((_dtFey.Rows.Count > 0) && (_dtFey.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey.Rows.Count == 0)) &&
                        (((_dtPetition1.Rows.Count > 0) && (_dtPetition1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition1.Rows.Count == 0)) &&
                        (((_dtFey1.Rows.Count > 0) && (_dtFey1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey1.Rows.Count == 0)))
                    {
                        DataRow dr = _dtPetition1.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        dr["Type"] = p.SelectedPerson.PersonType;
                        _dtPetition1.Rows.Add(dr);
                        jdgvcomplainant1.DataSource = _dtPetition1;
                        btnSave.Enabled = true;
                    }
                    else
                        JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
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
                        dr["Type"] = p.SelectedPerson.PersonType;
                        _dtFey.Rows.Add(dr);
                        jdgvFey.DataSource = _dtFey;
                        btnSave.Enabled = true;
                    }
                    else
                        JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddFey1_Click(object sender, EventArgs e)
        {
            try
            {
                //   ClassLibrary.JOtherPersonForm p = new ClassLibrary.JOtherPersonForm();
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                if (p.ShowDialog() != DialogResult.OK)
                    return;
                if (p.SelectedPerson != null)
                {
                    if ((((_dtPetition.Rows.Count > 0) && (_dtPetition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition.Rows.Count == 0)) &&
                        (((_dtFey.Rows.Count > 0) && (_dtFey.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey.Rows.Count == 0)) &&
                        (((_dtPetition1.Rows.Count > 0) && (_dtPetition1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPetition1.Rows.Count == 0)) &&
                        (((_dtFey1.Rows.Count > 0) && (_dtFey1.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtFey1.Rows.Count == 0)))
                    {
                        DataRow dr = _dtFey1.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        dr["Type"] = p.SelectedPerson.PersonType;
                        _dtFey1.Rows.Add(dr);
                        jdgvFey1.DataSource = _dtFey1;
                        btnSave.Enabled = true;
                    }
                    else
                        JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        #endregion

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            JJudicialBranch tmpJudicialBranch = new JJudicialBranch(Convert.ToInt32(cmbBranch.SelectedValue));
            txtAddress.Text = tmpJudicialBranch.Address;
            txtTel.Text = tmpJudicialBranch.Tel;
            txtFax.Text = tmpJudicialBranch.Fax;
            txtCity.Text = (new JSubBaseDefine(JBaseDefine.CityCode, tmpJudicialBranch.City)).Name;
        }

        private void cmbJudicalComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            JJudicialComplex tmpJJudicialComplex = new JJudicialComplex();
            cmbBranch.DisplayMember = "Name";
            cmbBranch.ValueMember = "Code";

            cmbBranch.DataSource = JJudicialComplex.ListBranch(((Legal.JJudicialComplex)(cmbJudicalComplex.SelectedItem)).Code);
            cmbBranch.SelectedItem = null;
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

        private void btnDelFey1_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvFey1.CurrentRow != null)
                {
                    jdgvFey1.Rows.Remove(jdgvFey1.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

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

        private void jdgvcomplainant1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (jdgvcomplainant1.SelectedRows != null)
                {
                    JOtherPerson tmp = new JOtherPerson(Convert.ToInt32(jdgvcomplainant1.SelectedRows[jdgvcomplainant1.CurrentRow.Index].Cells[1].Value));
                    ClassLibrary.JOtherPersonForm p = new ClassLibrary.JOtherPersonForm(tmp);
                    p.ShowDialog();
                    if (p.SelectedPerson != null)
                    {
                        jdgvcomplainant1.SelectedRows[jdgvcomplainant1.CurrentRow.Index].Cells[2].Value = p.SelectedPerson.Name;
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jdgvFey1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (jdgvFey1.SelectedRows != null)
                {
                    JOtherPerson tmp = new JOtherPerson(Convert.ToInt32(jdgvFey1.SelectedRows[jdgvFey1.CurrentRow.Index].Cells[1].Value));
                    ClassLibrary.JOtherPersonForm p = new ClassLibrary.JOtherPersonForm(tmp);
                    p.ShowDialog();
                    if (p.SelectedPerson != null)
                    {
                        jdgvFey1.SelectedRows[jdgvFey1.CurrentRow.Index].Cells[2].Value = p.SelectedPerson.Name;
                        btnSave.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        private void RefreshAdvocacyT1()
        {
            DataTable AdvocacyT1 = null;
            foreach (DataRow row in _dtPetition.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;
                int pCode = Convert.ToInt32(row["PersonCode"]);
                if (AdvocacyT1 == null)
                    AdvocacyT1 = JAdvocacys.GetAdvocacy(pCode, txtDate.Date, JAdvocacySubjects.Petition);
                else
                    AdvocacyT1.Merge(JAdvocacys.GetAdvocacy(pCode, txtDate.Date, JAdvocacySubjects.Petition));
            }
            jdgvcomplainant1.DataSource = AdvocacyT1;
            _dtPetition1 = AdvocacyT1;
        }

        private void RefreshAdvocacyT2()
        {
            DataTable AdvocacyT2 = null;
            foreach (DataRow row in _dtPetition.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;
                int pCode = Convert.ToInt32(row["PersonCode"]);
                if (AdvocacyT2 == null)
                    AdvocacyT2 = JAdvocacys.GetAdvocacy(pCode, txtDate.Date, JAdvocacySubjects.Petition);
                else
                    AdvocacyT2.Merge(JAdvocacys.GetAdvocacy(pCode, txtDate.Date, JAdvocacySubjects.Petition));
            }
            jdgvFey1.DataSource = AdvocacyT2;
            _dtFey1 = AdvocacyT2;
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            RefreshAdvocacyT1();
            RefreshAdvocacyT2();
        }

        private void jdgvcomplainant_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RefreshAdvocacyT1();
        }

        private void jdgvcomplainant_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RefreshAdvocacyT1();

        }

        private void jdgvFey_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RefreshAdvocacyT1();
        }

        private void jdgvFey_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RefreshAdvocacyT1();
        }
    }
}