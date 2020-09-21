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
   
    public partial class JAdvocacyForm : ClassLibrary.JBaseForm
    {
        private int NotaryCode = 0;
        private bool _FlagVicarious=false;
        DataTable _dtVicarious;
        DataTable _dtAvocate;
        DataTable _dtSubject = new DataTable();
        int _FinanceCode = 0;
        int _Code;
        /// <summary>
        /// کد نامه انحلال
        /// </summary>
        int _BreakUpLetterCode;
        /// <summary>
        /// کد نامه محضر
        /// </summary>
        int _NotaryCode;

        public JAdvocacyForm()
        {
            InitializeComponent();
            chklistSubject.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("Legal.JAdvocacySubjects")));
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveList1.ClassName = "Legal.JAdvocacy";
            jArchiveList1.SubjectCode = 0;
            jArchiveList1.PlaceCode = 0;

            PatternDt();
            FillCompBox();
        }

        public JAdvocacyForm(int pCode)
        {
            InitializeComponent();
            chklistSubject.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("Legal.JAdvocacySubjects")));
            PatternDt();
            _Code = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveList1.ClassName = "Legal.JAdvocacy";
            jArchiveList1.SubjectCode = 0;
            jArchiveList1.PlaceCode = 0;
            jArchiveList1.ObjectCode = _Code;
            FillCompBox();
        }


        #region Methods

        private void PatternDt()
        {
            _dtAvocate = JAdvocate.GetAllData(-1);
            _dtVicarious = JVicarious.GetAllData(-1);
        }

        private void JAdvocacyForm_Load(object sender, EventArgs e)
        {
            labDecisionDate.Text = "";
            labDesionNumber.Text = "";
            if (State == JFormState.Update)
                Set_Form();
        }

        private void Set_Form()
        {
            try
            {
            JNotaryLetter tmpLetter = new JNotaryLetter();
            JNotary tmp = new JNotary();
            JAdvocacy tmpJAdvocacy = new JAdvocacy(_Code);
            PersonClient.SelectedCode = tmpJAdvocacy.PersonCode;
            chAllAssets.Checked = tmpJAdvocacy.AllAssets;
            if (tmpJAdvocacy.Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.Vicarious)
                _BreakUpLetterCode = tmpJAdvocacy.Breakup_Notary;
                
            if (tmpJAdvocacy.Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.tribunal)
                _BreakUpLetterCode = tmpJAdvocacy.Breakup_tribunal;

            if (tmpJAdvocacy.Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.Notary) rbMovakel.Checked = true;
            else if (tmpJAdvocacy.Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.Vicarious)
            {
                rbGovahi.Checked = true;
                //------اطلاعات نامه ها محضر انحلال
                tmpLetter.GetData(_BreakUpLetterCode);
                if (tmp.GetData(tmpLetter.Notary_Code))
                {
                    NotaryCode = tmpLetter.Notary_Code;
                    JCitiy Sb = new JCitiy();
                    Sb.GetData(tmp.City);
                    numEdit1.Text = NotaryCode + "-" + Sb.Name;
                    LetterNum2.Text = tmpLetter.LetterNumber.ToString();
                    dateEdit1.Text = tmpLetter.Date.ToString();
                }
            }
            else if (tmpJAdvocacy.Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.Die) rbFot.Checked = true;
            else if (tmpJAdvocacy.Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.tribunal)
            {
                rbHokm.Checked = true;
                JDecision Decision = new JDecision(tmpJAdvocacy.Breakup_tribunal);
                txtDecisionCode.Text = Decision.Code.ToString();
                labDecisionDate.Text = JDateTime.FarsiDate(Decision.Date);
                txtDecisionState.Text = Decision.DecisionDesc;
                labDesionNumber.Text = Decision.number;
            }
            else if (tmpJAdvocacy.Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.None) rbNone.Checked = true;
            else if (tmpJAdvocacy.Breakup_Type == ClassLibrary.Domains.Legal.JBreakupType.Dismissal) rbAzl.Checked = true;

            txtStartDate.Date = tmpJAdvocacy.StartDate;
            txtEndDate.Date = tmpJAdvocacy.EndDate;
            txtauthorization.Text = tmpJAdvocacy.Description;

            jcmbNotary.SelectedValue = tmpJAdvocacy.NotaryOffice;
            DateLetter.Date = tmpJAdvocacy.LetterDate;
            txtDesc.Text = tmpJAdvocacy.LetterDesc;
            txtLetterNo.Text = tmpJAdvocacy.LetterNo;
            txtSubject.Text = tmpJAdvocacy.LetterSubject;

            //------اطلاعات نامه محضر 
            _NotaryCode = tmpJAdvocacy.NotaryCode;
            if (_NotaryCode > 0)
            {
                tmpLetter.GetData(tmpJAdvocacy.NotaryCode);
                if (tmp.GetData(tmpLetter.Notary_Code))
                {
                    JCitiy Sb = new JCitiy();
                    Sb.GetData(tmp.City);
                   // txtNotary.Text = tmp.NumNotary + "-" + Sb.Name;
                }

                txtLetterNo.Text = tmpLetter.LetterNumber;
                DateLetter.Text = tmpLetter.Date.ToString();
                txtSubject.Text = tmpLetter.Subject.ToString();
                txtDesc.Text = tmpLetter.Description;
                FillNotary(tmpLetter.Notary_Code);
            }
            //------------------------------------------------------
            txtDescBreakup.Text = tmpJAdvocacy.BreakupDesc;
            //if (tmpJAdvocacy.State == true)
            //    chkAdvocate.Checked = true;
            //else
            //    chkAdvocate.Checked = false;
            if (tmpJAdvocacy.Type == ClassLibrary.Domains.Legal.JAdvocateType.Official)
                rbEdari.Checked = true;
            else if (tmpJAdvocacy.Type == ClassLibrary.Domains.Legal.JAdvocateType.Exclusive)
                rbBelaAzl.Checked=true;
            if (tmpJAdvocacy.Confirm == true)
                chkConfim.Checked = true;
            else
                chkConfim.Checked = false;
            
            _dtVicarious = JVicarious.GetAllData(_Code);
            //jdgvVicarious.DataSource=_dtVicarious;
            _dtAvocate = JAdvocate.GetAllData(_Code);
            jdgvAdvocate.DataSource=_dtAvocate;

            JSubjectAdvocacy tmpJSubjectAdvocacy=new JSubjectAdvocacy();
            //this.chklistSubject.BeginUpdate();
            foreach (DataRow dr in tmpJSubjectAdvocacy.GetAllSubject(_Code).Rows)
                for (int i = 0; i < chklistSubject.Items.Count; i++)
                {
                    if (Convert.ToInt32(dr["SubjectCode"]) == Convert.ToInt32(((ClassLibrary.JKeyValue)chklistSubject.Items[i]).Value))
                    {
                        ((ClassLibrary.JKeyValue)chklistSubject.Items[i]).Value = Convert.ToInt32(dr["SubjectCode"]);
                        chklistSubject.SetItemChecked(i, true);
                    }
                }
            //this.chklistSubject.EndUpdate();

            FillAsset(Convert.ToInt32(this.PersonClient.SelectedCode));
                foreach (DataRow dr in JAdvocacyFinance.GetAllSubject(_Code).Rows)
                    for (int i = 0; i < chklistAsset.Items.Count; i++)
                    {
                        if (Convert.ToInt32(dr["FinanceCode"]) == Convert.ToInt32(((Finance.JAssetShare)chklistAsset.Items[i]).Code))
                        {
                            //((Finance.JAssetShare)chklistAsset.Items[i]).Code = Convert.ToInt32(dr["Code"]);
                            chklistAsset.SetItemChecked(i, true);
                        }
                    }

                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddAvocate_Click(object sender, EventArgs e)
        {
            try
            {
                //ClassLibrary.JOtherPersonForm p = new ClassLibrary.JOtherPersonForm();
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm("Died = 0");
                p.ShowDialog();                
                if (p.SelectedPerson != null)
                {
                    if ((((_dtAvocate.Rows.Count > 0) && (_dtAvocate.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAvocate.Rows.Count == 0))&&
                         ((_dtVicarious.Rows.Count > 0) && (_dtVicarious.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtVicarious.Rows.Count == 0))
                    {

                        DataRow dr = _dtAvocate.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        dr["PersonType"] = p.SelectedPerson.PersonType;
                        _dtAvocate.Rows.Add(dr);
                        jdgvAdvocate.DataSource = _dtAvocate;
                        btnSave.Enabled = true;

                        //ClassLibrary.JPerson tmp = new ClassLibrary.JPerson(p.SelectedPerson.Code);
                        //if (p.SelectedPerson.PersonType == ClassLibrary.JPersonTypes.LegalPerson)
                    }
                }
            }                        
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void FillAsset(int pPersonCode)
        {
            //لیست اموال
            chklistAsset.Items.Clear();
            Finance.JAssetShares shares = new Finance.JAssetShares();
            shares.GetPersonAssetShares(pPersonCode);
            foreach (Finance.JAssetShare share in shares.Items)
                chklistAsset.Items.Add(share);
        }

        private void btnaddClient_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
            //    p.ShowDialog();
            //    if (p.SelectedPerson != null)
            //    {
            //      if(!((_dtVicarious.Rows.Count != 0) && (Convert.ToInt32(_dtVicarious.Rows[0]["PersonCode"]) == p.SelectedPerson.Code)))
            //      {
            //        _FlagVicarious = true;
            //        //jdgvVicarious.Rows.Remove(jdgvVicarious.CurrentRow);
            //        btnSave.Enabled = true;

            //        //_dtVicarious.Rows.Clear();
            //        if (_dtVicarious.Rows.Count > 0)
            //            jdgvVicarious.Rows.Remove(jdgvVicarious.CurrentRow);

            //            //.Delete();//.ClearErrors();// = null;
            //        //jdgvVicarious.DataSource = _dtVicarious;
            //        if ((((_dtVicarious.Rows.Count > 0) && (_dtVicarious.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtVicarious.Rows.Count == 0)) &&
            //            (((_dtAvocate.Rows.Count > 0) && (_dtAvocate.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAvocate.Rows.Count == 0)))
            //        {
            //            DataRow dr = _dtVicarious.NewRow();
            //            dr["PersonCode"] = p.SelectedPerson.Code;
            //            dr["Name"] = p.SelectedPerson.Name;
            //            dr["PersonType"] = p.SelectedPerson.PersonType;
            //            _dtVicarious.Rows.Add(dr);
            //            jdgvVicarious.DataSource = _dtVicarious;
            //            btnSave.Enabled = true;
            //            FillAsset(p.SelectedPerson.Code);
            //        }
            //        else
            //            JMessages.Message("Person is Repeated ", "", JMessageType.Information);
            //      }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //}
        }

        private bool Save()
        {
            #region CheckControl
            if (!chkConfim.Checked)
            {
                JMessages.Error("وکالت حتماً باید به تائید واحد حقوقی برسد.", "error");
                return false;
            }
            if (txtStartDate.Date > txtEndDate.Date)
            {
                JMessages.Error("تاریخ شروع از پایان بزرگتر است", "error");
                return false;
            }
            if (jdgvAdvocate.RowCount == 0)
            {
                JMessages.Error("وکیل را انتخاب کنید","error");
                return false;
            }
            //if (jdgvVicarious.RowCount == 0)
            if(PersonClient.SelectedCode==0)
            {
                JMessages.Error("موکل را انتخاب کنید", "error");
                return false;
            }
            if (txtStartDate.Date == DateTime.MinValue)
            {
                JMessages.Error("تاریخ شروع وکالت را مشخص کنید.", "error");
                return false;
            }
            //if (chklistAsset.Items.Count==0)
            //{
            //    JMessages.Error("دارایی هایی که وکالت داده شده است را مشخص کنید.", "error");
            //    return false;
            //}
            //if (chklistSubject.Items.Count == 0)
            //{
            //    JMessages.Error("موضوع وکالت را مشخص کنید.", "error");
            //    return false;
            //}
            if (txtLetterNo.Text == "")
            {
                JMessages.Error("لطفا شماره وکالت نامه را وارد کنید.", "error");
                return false;
            }

            #endregion
            try
            {
                //------------------اطلاعات انحلال-------------------
                int Breakup = 0;
                JAdvocacy tmpJAdvocacy = new JAdvocacy();
                tmpJAdvocacy.PersonCode = PersonClient.SelectedCode;
                tmpJAdvocacy.AllAssets = chAllAssets.Checked;
                if (rbMovakel.Checked)
                {
                    Breakup = ClassLibrary.Domains.Legal.JBreakupType.Notary;
                    tmpJAdvocacy.Breakup_Notary = NotaryCode;
                }
                else if (rbAzl.Checked) Breakup = ClassLibrary.Domains.Legal.JBreakupType.Dismissal;

                else if (rbGovahi.Checked) Breakup = ClassLibrary.Domains.Legal.JBreakupType.Vicarious;
                else if (rbFot.Checked) Breakup = ClassLibrary.Domains.Legal.JBreakupType.Die;
                else if (rbHokm.Checked)
                {
                    if (!String.IsNullOrEmpty(txtDecisionCode.Text))
                    {
                        Breakup = ClassLibrary.Domains.Legal.JBreakupType.tribunal;
                        tmpJAdvocacy.Breakup_tribunal = Convert.ToInt32(txtDecisionCode.Text);
                    }
                    else
                    {
                        JMessages.Message("حکم را وارد کنید ", "", JMessageType.Information);
                        return false;
                    }
                }
                else if (rbNone.Checked) Breakup = ClassLibrary.Domains.Legal.JBreakupType.None;
                tmpJAdvocacy.StartDate = txtStartDate.Date;
                tmpJAdvocacy.EndDate = txtEndDate.Date;
                tmpJAdvocacy.Description = txtauthorization.Text.Trim();
                tmpJAdvocacy.Breakup_Type = Breakup;
                
                tmpJAdvocacy.NotaryOffice = (int)jcmbNotary.SelectedValue;
                tmpJAdvocacy.LetterDate = DateLetter.Date;
                tmpJAdvocacy.LetterDesc = txtDesc.Text;
                tmpJAdvocacy.LetterNo = txtLetterNo.Text;
                tmpJAdvocacy.LetterSubject = txtSubject.Text;

                if (rbHokm.Checked && txtDecisionCode.Text != "")
                {
                    tmpJAdvocacy.DesionCode = Convert.ToInt32(txtDecisionCode.Text);
                }                
                if (rbGovahi.Checked)
                {
                    if (!String.IsNullOrEmpty(numEdit1.Text))
                        tmpJAdvocacy.Breakup_Notary = _BreakUpLetterCode;
                    else
                    {
                        JMessages.Message("شماره دفتر خانه را وارد کنید ", "", JMessageType.Information);
                        return false;
                    }
                }
                else if (rbHokm.Checked)
                {
                    //if (!String.IsNullOrEmpty(numEdit1.Text))
                    //    tmpJAdvocacy.Breakup_tribunal = _BreakUpLetterCode;
                    //else
                    //{
                    //    JMessages.Message("Please Enter Data ", "", JMessageType.Information);
                    //    return false;
                    //}
                }
                tmpJAdvocacy.BreakupDesc = txtDescBreakup.Text.Trim();
                //------------------اطلاعات نامه محضر-------------------
                tmpJAdvocacy.NotaryCode = _NotaryCode;

                //if (chkAdvocate.Checked)
                //    tmpJAdvocacy.State = true;
                //else
                //    tmpJAdvocacy.State = false;
                if (rbEdari.Checked)
                    tmpJAdvocacy.Type = ClassLibrary.Domains.Legal.JAdvocateType.Official;
                else if (rbBelaAzl.Checked)
                    tmpJAdvocacy.Type = ClassLibrary.Domains.Legal.JAdvocateType.Exclusive;
                if (chkConfim.Checked)
                    tmpJAdvocacy.Confirm = true;
                else
                    tmpJAdvocacy.Confirm = false;
                //-------------موضوعات-----------
                List<int> SubjectCode = new List<int>();
                List<int> SubjectCodeDelete = new List<int>();
                for (int i = 0; i < chklistSubject.Items.Count; i++)
                {
                    if (chklistSubject.GetItemChecked(i))
                        SubjectCode.Add(Convert.ToInt32(((ClassLibrary.JKeyValue)chklistSubject.Items[i]).Value));
                    else
                        SubjectCodeDelete.Add(Convert.ToInt32(((ClassLibrary.JKeyValue)chklistSubject.Items[i]).Value));
                }

                //-------------لیست اموال-----------
                List<int> AssetCode = new List<int>();
                List<int> AssetCodeDelete = new List<int>();
                if (_FlagVicarious == true)
                {

                    AssetCodeDelete = null;
                    for (int i = 0; i < chklistAsset.Items.Count; i++)
                    {
                        if (chklistAsset.GetItemChecked(i))
                            AssetCode.Add(Convert.ToInt32(((Finance.JAssetShare)chklistAsset.Items[i]).Code));
                    }
                }
                else
                    for (int i = 0; i < chklistAsset.Items.Count; i++)
                    {
                        if (chklistAsset.GetItemChecked(i))
                            AssetCode.Add(Convert.ToInt32(((Finance.JAssetShare)chklistAsset.Items[i]).Code));
                        else
                            AssetCodeDelete.Add(Convert.ToInt32(((Finance.JAssetShare)chklistAsset.Items[i]).Code));
                    }
                _FlagVicarious = false;

                    jArchiveList1.ClassName = "Legal.JAdvocacy";
                    jArchiveList1.SubjectCode = 0;
                    jArchiveList1.PlaceCode = 0;

                    //---------ویرایش------------
                    if (State == JFormState.Update)
                    {
                        //----------Update Archive------------
                        tmpJAdvocacy.Code = _Code;
                        jArchiveList1.ObjectCode = _Code;
                        jArchiveList1.ArchiveList();
                        if (tmpJAdvocacy.Update(SubjectCode, SubjectCodeDelete, AssetCode, AssetCodeDelete, _dtVicarious, _dtAvocate, txtStartDate.Date))
                        {
                            JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                            return true;
                        }
                        else
                            JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
                    }
                    else
                    {
                        _Code = tmpJAdvocacy.Insert(SubjectCode, AssetCode, _dtVicarious, _dtAvocate, txtStartDate.Date);
                        if (_Code > 0 )
                        {
                            jArchiveList1.ObjectCode = tmpJAdvocacy.Code;
                            jArchiveList1.ArchiveList();
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
        }
    #endregion

        # region Form Data Changed

        private void txtAdvocateCode_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkConfim_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkAdvocate_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbEdari_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbAzl_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            groupBoxDaftarMahzar.Visible = false;
            GroupBoxDecision.Visible = false;
            GroupBoxDecision.Visible = false;
        }

        private void rbGovahi_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            groupBoxDaftarMahzar.Visible = true;
            GroupBoxDecision.Visible = false;
            GroupBoxDecision.Visible = false;
        }

        private void rbMovakel_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            groupBoxDaftarMahzar.Visible = false;
            GroupBoxDecision.Visible = false;
            GroupBoxDecision.Visible = false;
        }

        private void rbFot_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            groupBoxDaftarMahzar.Visible = false;
            GroupBoxDecision.Visible = false;
            GroupBoxDecision.Visible = false;
        }

        private void rbHokm_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            groupBoxDaftarMahzar.Visible = false;
            GroupBoxDecision.Visible = true;
            
        }

        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtEndDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void JAdvocacyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (btnSave.Enabled == true)
            //{
            //    if (MessageBox.Show("DoYouWantToSaveChanges", "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        if (Save())
            //            this.Close();
            //        else
            //            JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
            //    }
            //    else
            //        this.Close();
            //}
            //else
            //    this.Close();
        }
        

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if(Save())
                Close();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (JMessages.Question ("DoYouWantToSaveChanges", "Save") == DialogResult.Yes)
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

    #endregion

        #region Events

        private void setData(JNotaryLetterSearchForm p)
        {
            _NotaryCode = p.Code;
            JNotary tmp = new JNotary();
            if (tmp.GetData(p.Notary_Code))
            {
                JCitiy Sb = new JCitiy();
                Sb.GetData(tmp.City);
                //txtNotary.Text = tmp.NumNotary + "-" + Sb.Name;
                txtLetterNo.Text = p.LetterNumber;
                DateLetter.Text = p.Date.ToString();
                txtSubject.Text = p.Subject;
                txtDesc.Text = p.Description;
            }
            //}
            FillNotary(p.Notary_Code);
            btnSave.Enabled = true;
        }

        private void btnSearchNotary_Click(object sender, EventArgs e)
        {
            JNotaryLetterSearchForm p = new JNotaryLetterSearchForm();
            p.ShowDialog();
            setData(p);
        }

        private void FillNotary(int Notary_Code)
        {
            JNotary tmp = new JNotary();
            if (tmp.GetData(Notary_Code))
            {
                txtHeadOffice.Text = tmp.HeadOffice;
                txtAssistant.Text = tmp.Assistant;
                txtMobile.Text = tmp.Mobile;
                JCitiy Sb = new JCitiy();
                Sb.GetData(tmp.City);
                txtCity.Text = Sb.Name;
                txtAddress.Text = tmp.Address;
                txtTel.Text = tmp.Tel;
            }
        }

        private void btnSearchNotary1_Click(object sender, EventArgs e)
        {
            JNotaryLetterSearchForm p = new JNotaryLetterSearchForm();
            //if (p.ShowDialog() == DialogResult.OK)
            //{
            p.ShowDialog();
                _BreakUpLetterCode = p.Code;
                JNotary tmp = new JNotary();
                if (tmp.GetData(p.Notary_Code))
                {
                    JCitiy Sb = new JCitiy();
                    Sb.GetData(tmp.City);
                    numEdit1.Text = tmp.NumNotary + "-" + Sb.Name;
                    NotaryCode = p.Code;
                    LetterNum2.Text = p.LetterNumber.ToString();
                    dateEdit1.Text = p.Date.ToString();
                }
            //}
        }

        private void btndelAdvocate_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvAdvocate.CurrentRow != null)
                {
                    jdgvAdvocate.Rows.Remove(jdgvAdvocate.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btndelClient_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (jdgvVicarious.CurrentRow != null)
            //    {
            //        jdgvVicarious.Rows.Remove(jdgvVicarious.CurrentRow);
            //        chklistAsset.Items.Clear();
            //        btnSave.Enabled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    JSystem.Except.AddException(ex);
            //}
        }
        #endregion

        private void chklistSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtauthorization_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDescBreakup_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void jArchiveList1_AfterFileAdded(object Sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSearchDecision_Click(object sender, EventArgs e)
        {
            JDecisionSearchForm JDSF = new JDecisionSearchForm();
            JDSF.ShowDialog();
            int DecisionCode = JDSF._Code;
            JDecision Decision = new JDecision(DecisionCode);
            txtDecisionCode.Text = DecisionCode.ToString();
            labDecisionDate.Text = JDateTime.FarsiDate(Decision.Date);
            txtDecisionState.Text = Decision.DecisionDesc;
            labDesionNumber.Text = Decision.number;

        }

        private void jdgvAdvocate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (jdgvAdvocate.SelectedRows != null)
                {
                    JOtherPerson tmp = new JOtherPerson(Convert.ToInt32(jdgvAdvocate.SelectedRows[jdgvAdvocate.CurrentRow.Index].Cells[1].Value));
                    ClassLibrary.JOtherPersonForm p = new ClassLibrary.JOtherPersonForm(tmp);
                    //ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm("Died = 0");
                    p.ShowDialog();
                    if (p.SelectedPerson != null)
                    {
                        //DataRow dr = _dtAvocate.NewRow();
                        //dr["PersonCode"] = p.SelectedPerson.Code;
                        jdgvAdvocate.SelectedRows[jdgvAdvocate.CurrentRow.Index].Cells[2].Value = p.SelectedPerson.Name;
                        //dr["PersonType"] = p.SelectedPerson.PersonType;
                        //_dtAvocate.Rows.Add(dr);
                        //jdgvAdvocate.DataSource = _dtAvocate;
                        btnSave.Enabled = true;

                        //ClassLibrary.JPerson tmp = new ClassLibrary.JPerson(p.SelectedPerson.Code);
                        //if (p.SelectedPerson.PersonType == ClassLibrary.JPersonTypes.LegalPerson)
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddNotaryLetter_Click(object sender, EventArgs e)
        {
            JNotaryLetterForm NLF = new JNotaryLetterForm();
            NLF.State = JFormState.Insert;
            NLF.ShowDialog();
            if (NLF._NotaryLetterCode != 0)
            {
            }
        }

        private void FillNoteryCombo()
        {
            /// دفترخانه ها
            jcmbNotary.DataSource = JNotarys.GetDataTable();
            jcmbNotary.DisplayMember = "FullName";
            jcmbNotary.ValueMember = "Code";
        }

        private void FillCompBox()
        {
            FillNoteryCombo();
        }

        private void btnAddNotery_Click(object sender, EventArgs e)
        {
            JNotary notery = new JNotary();
            notery.ShowDialog(false);
            FillNoteryCombo();
        }

        private void rbAzl_CheckedChanged_1(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            groupBoxDaftarMahzar.Visible = false;
            GroupBoxDecision.Visible = false;
            GroupBoxDecision.Visible = false;
        }

        private void chAllAssets_CheckedChanged(object sender, EventArgs e)
        {
            chklistAsset.Enabled = !chAllAssets.Checked;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklistSubject.Items.Count; i++)
                chklistSubject.SetItemCheckState(i,CheckState.Checked);
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chklistSubject.Items.Count; i++)
                chklistSubject.SetItemCheckState(i, CheckState.Unchecked);
        }

        private void PersonClient_AfterCodeSelected(object Sender, EventArgs e)
        {
            chklistAsset.Items.Clear();
            FillAsset(PersonClient.SelectedCode);
        }

    }
}
