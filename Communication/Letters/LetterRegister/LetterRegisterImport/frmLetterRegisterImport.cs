using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Employment;
using Automation;
using Globals;
using OfficeWord;

namespace Communication
{
    /// <summary>
    ///کلاس فرم ثبت نامه وارده
    /// </summary>
    public partial class JfrmLetterRegisterImport : Globals.JBaseForm
    {
        /// <summary>
        /// فیلد ها
        /// </summary>
        #region Feilds

        public int _LetterCode;
        DataTable _dtRelatedLetter = new DataTable();
        /// <summary>
        /// وضعیت نامه
        /// </summary>
        int _letter_status;
        /// <summary>
        /// 
        /// </summary>
        string _Letter_No="";
        /// <summary>
        /// 
        /// </summary>
        int _Refer_Code = 0;
        /// <summary>
        /// 
        /// </summary>
        JCWorkLetterType WorkLetterType = JCWorkLetterType.Save;
        /// <summary>
        /// 
        /// </summary>
        DataTable _dtAttachment = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        DataTable _dtCopyes = new DataTable();

        #endregion Feilds

        /// <summary>
        /// سازنده
        /// </summary>
        public JfrmLetterRegisterImport(int pStatusForm, JFormState pState, int LetterCode, int pCurrentReferCode)
        {
            InitializeComponent();
            btnRegMinute.Left = 700;
            if (DesignMode) return;
            
            UC_LetterCopy1.Initialize();
            State = pState;
            _Letter_No = "";
            _LetterCode = LetterCode;
            _Refer_Code = pCurrentReferCode;
            _dtRelatedLetter.Columns.Add("Code");
            _dtRelatedLetter.Columns.Add("Letter_no");
            _dtRelatedLetter.Columns.Add("incoming_no");
            _dtRelatedLetter.Columns.Add("type");
            _dtRelatedLetter.Columns.Add("type_Title");
            _dtRelatedLetter.Columns.Add("pre_subject");
            SenderLable.Text = "Sender :";

            jArchiveList1.ClassName = "Communication.JCLetterAttachment";
            jArchiveList1.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.LetterAttachment.GetHashCode();
            jArchiveList1.PlaceCode = ArchivedDocuments.JConstantArchivePalces.LetterAttachment.GetHashCode();

            jArchiveList2.ClassName = "Communication.JCLetter";
            jArchiveList2.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.Letter.GetHashCode();
            jArchiveList2.PlaceCode = ArchivedDocuments.JConstantArchivePalces.Letter.GetHashCode();

            if (_LetterCode > 0)
            {
                jArchiveList1.ObjectCode = _LetterCode;
                jArchiveList2.ObjectCode = _LetterCode;
            }

            _SetCmb();
            
            if (_LetterCode > 0)
                SetForm(_LetterCode);
            _SetState();
            
        }

        #region Functions
        private void _GetState(JCLetterRegisterImport LRI)
        {

            if (LRI.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
            {
                labelState.Text = " نامه به شماره وارده " + LRI.register_no.ToString();
                State = JFormState.ReadOnly;
                btnRegMinute.Enabled = false;
                //btnRegisterInSecretariat.Visible = false;
                //btnRefer.Visible = true;
            }
            else
            {
                Automation.JAObject obj = new Automation.JAObject();
                if ((LRI.Code > 0) && obj.FindObjectByExternalcode(ClassLibrary.Domains.JAutomation.JObjectType.Letters, LRI.Code))
                {
                    DataTable DT = obj.GetLastsRefer();
                    if (DT.Rows.Count > 0 && (int)(DT.Rows[DT.Rows.Count - 1][Refer.receiver_post_code.ToString()]) == JMainFrame.CurrentPostCode)
                    {
                        labelState.Text = " پیش نویش قابل ویرایش ";
                        btnRegMinute.Enabled = true;
                        btnRefer.Enabled = true;
                        //btnRegisterInSecretariat.Visible = true;
                    }
                    else
                    {
                        labelState.Text = " پیش نویش غیر قابل ویرایش ";
                        State = JFormState.ReadOnly;
                        btnRegMinute.Enabled = false;
                        //btnRegisterInSecretariat.Visible = false;
                        btnRefer.Enabled = false;
                    }


                }
                else
                {
                    labelState.Text = " پیش نویش قابل ویرایش ";
                    btnRegMinute.Enabled = true;
                    //btnRegisterInSecretariat.Visible = true;
                    //btnRefer.Visible = true;
                }

            }
        }

        private void _SetState()
        {
            try
            {
                if (State == JFormState.ReadOnly)
                {
                    btnDelete.Enabled = false;
                    btnReceiver.Enabled = false;
                    btnSearchLetterNo.Enabled = false;
                    btnSelOrganization.Enabled = false;
                    btnSubjectList.Enabled = false;
                    //btSearch.Enabled = false;
                    cdbReceiver.Enabled = false;
                    cdbSender.Enabled = false;
                    cdbSubject.Enabled = false;
                    UC_LetterCopy1.Enabled = false;
                    txtLetterNo.Enabled = false;
                    jArchiveList1.EnabledChange = false;
                    jArchiveList2.EnabledChange = false;
                }
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// تنظیم لیست های روی فرم
        /// </summary>
        private void _SetCmb()
        {
            try
            {
                //  ---------------------- Set ComboBox Sender --------------------------
                cdbSender.TitleFieldName = "Full_Title";
                cdbSender.AccessCodeFieldName = "code";
                cdbSender.CodeFieldName = "code";

                cdbSender.dataTable = JAllPerson.GetDataContractPerson(0, "", -1, JPersonTypes.None , "");
                cdbSender.SetComboBox();
                //  ---------------------- Set ComboBox Receiver --------------------------
                cdbReceiver.TitleFieldName = "full_title";
                cdbReceiver.AccessCodeFieldName = "accesscode";
                cdbReceiver.CodeFieldName = "code";
                cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, JMainFrame.GetActiveChartCode());
                cdbReceiver.SetComboBox();


                //  ---------------------- Set ComboBox ReceiveType --------------------------
                cmbReceiveType.DisplayMember = "name";
                cmbReceiveType.ValueMember = "code";
                DataTable dt = new DataTable();
                dt = (new JRecieveTypeDefine()).GetList();
                DataRow dr;
                dr = dt.NewRow();
                dr["code"] = "-1";
                dr["name"] = "-----------";
                dt.Rows.InsertAt(dr, 0);
                cmbReceiveType.DataSource = dt;
                //  ---------------------- Set ComboBox Privacy --------------------------
                dt = ClassLibrary.Domains.JGlobal.JPrivacy.GetData();
                cmbSecurityLevel.DisplayMember = "FarsiName";
                cmbSecurityLevel.ValueMember = "value";
                cmbSecurityLevel.DataSource = dt;
                cmbSecurityLevel.SelectedValue = ClassLibrary.Domains.JGlobal.JPrivacy.Normal;
                //  ---------------------- Set ComboBox Urgency --------------------------
                dt = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
                cmbUrgency.DisplayMember = "FarsiName";
                cmbUrgency.ValueMember = "value";
                cmbUrgency.DataSource = dt;
                cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;
                //  ---------------------- Set ComboBox Subject --------------------------
                ArchivedDocuments.JSubjectTree Subject = new ArchivedDocuments.JSubjectTree();
                cdbSubject.AccessCodeFieldName = "AccessCode";
                cdbSubject.TitleFieldName = "name";
                cdbSubject.CodeFieldName = "code";
                cdbSubject.dataTable = Subject.GetSubjectList();
                cdbSubject.SetComboBox();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// تنظیم اطلاعات فرم
        /// </summary>
        /// <param name="pLetterCode"></param>
        public void SetForm(int pLetterCode)
        {
            _LetterCode = pLetterCode;
            JCLetterRegisterImport LRI = new JCLetterRegisterImport(pLetterCode);
            //------------------رونوشت ---------------
            UC_LetterCopy1.SetData(pLetterCode);
            //------------------عطف ---------------
            _dtRelatedLetter.Clear();
            JCRelatedLetter tmpJCRelatedLetter = new JCRelatedLetter();
            foreach (DataRow dr in tmpJCRelatedLetter.GetDate(pLetterCode).Rows)
                AddRelatedLetter(Convert.ToInt32(dr["dependent_lettercode"].ToString()));
            uC_GridLetter.Bind(_dtRelatedLetter, "RelatedLetter");
            // _dtRelatedLetter = tmpJCRelatedLetter.GetDate(pLetterCode);

            //------------------ پر کردن اطلاعات فرستنده گیرنده بر اساس نوع نامه ---------------
            if ((new JAllPerson(LRI.sender_external_code)).Code != 0)
            {
                JAllPerson OrganTemp = new JAllPerson(LRI.sender_external_code);
                cdbSender.SetValue(OrganTemp.Code);
            }
            else
                cdbSender.Text = LRI.sender_full_title;
            cdbReceiver.SetValue((new Employment.JEOrganizationChart(LRI.receiver_post_code)).AccessCode);
            ArchivedDocuments.JSubjectTree sub = new ArchivedDocuments.JSubjectTree();
            cdbSubject.SetValue((new ArchivedDocuments.JSubjectTree()).GetAccessCode(LRI.subject_code));
            txtSubjectMinute.Text = LRI.pre_subject;
            txtAppindix.Text = LRI.appendix;
            txtSummery.Text = LRI.summary;
            txtLetterImportLetterNo.Text = LRI.incoming_no;
            dteLetterImportDate.Text = (JDateTime.FarsiDate(LRI.incoming_date));
            txtSignatured.Text = LRI.incoming_signature_person;
            cmbReceiveType.SelectedValue = LRI.receiver_type;
            cmbUrgency.SelectedValue = LRI.urgency;
            cmbSecurityLevel.SelectedValue = LRI.secret_level;
            _Letter_No = LRI.letter_no;
            _letter_status = LRI.letter_status;
            _GetState(LRI);


        }

        private void _SetComboBox()
        {
            //  ---------------------- Set ComboBox Sender --------------------------
            cdbSender.AccessCodeFieldName = "access_code";
            cdbSender.TitleFieldName = "full_title";
            cdbSender.CodeFieldName = "code";
            cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
            cdbSender.SetComboBox();

        }

        #endregion Functions


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JfrmLetterRegisterImport_Load(object sender, EventArgs e)
        {
            // ----------------------------  بررسی وجود چارت سازمانی فعال -------------------------
                if ((new JECharts()).GetActiveChartCode() == 0)
                {
                    JMessages.Message(JLanguages._Text("Active chart not set,  Please First Set chart"), JLanguages._Text("Error"), JMessageType.Error);
                    this.Close();
                }
            //_SetCmb();
            // ----------------------------  بررسی وضعیت فرم -------------------------
            if ((_LetterCode != 0))// && (_Refer_Code != 0))
            {
                //SetForm(_LetterCode);

            }
        }

        private void btnSelOrganization_Click(object sender, EventArgs e)
        {
            JFindPersonForm PFind = new JFindPersonForm();
            if (PFind.ShowDialog() == DialogResult.OK)
            {
                if (PFind.SelectedPerson != null)
                    cdbSender.SetValue(PFind.SelectedPerson.Code);
            }
            PFind.Dispose();
        }

        private void btnReceiver_Click(object sender, EventArgs e)
        {
            Employment.JEfrmOrganizatinChart Org = new Employment.JEfrmOrganizatinChart();
            Org.ViewMode = true;
            if (Org.ShowDialog() == DialogResult.OK)
            {
                //  ---------------------- Set ComboBox Receiver --------------------------
                cdbReceiver.TitleFieldName = "full_title";
                cdbReceiver.AccessCodeFieldName = "accesscode";
                cdbReceiver.CodeFieldName = "code";
                cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, (JMainFrame.GetActiveChartCode()));
                cdbReceiver.SetComboBox();
                cdbReceiver.SetValue(Org.SelectedItem["accesscode"]);
            }
            Org.Dispose();
        }

        /// <summary>
        /// نمایش لیست موضوعات نامه 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubjectList_Click(object sender, EventArgs e)
        {
            ArchivedDocuments.JSubjectForm sub = new ArchivedDocuments.JSubjectForm();
            if (sub.ShowDialog() == DialogResult.OK)
            {
                //if (sub.SelectedItem.AccessCode != null )
                //  ---------------------- Set ComboBox Subject --------------------------
                ArchivedDocuments.JSubjectTree Subject = new ArchivedDocuments.JSubjectTree();
                cdbSubject.AccessCodeFieldName = "AccessCode";
                cdbSubject.TitleFieldName = "name";
                cdbSubject.CodeFieldName = "code";
                cdbSubject.dataTable = Subject.GetSubjectList();
                cdbSubject.SetComboBox();

                cdbSubject.SetValue(((ClassLibrary.JCustomTreeNode)(((System.Windows.Forms.TreeNode)(sub.SelectedItem)).Tag)).FieldsValue["AccessCode"].ToString());
                sub.Dispose();
            }
        }


        private void txtAppindix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                if (txtAppindix.Text == "پیوست دارد")
                {
                    txtAppindix.Text = "پیوست ندارد";
                }
                else
                {
                    txtAppindix.Text = "پیوست دارد";
                }
            }
        }

        private void btnNewWordFile_Click(object sender, EventArgs e)
        {
        }

        #region" عملیات مربوط به درج و ویرایش نامه"

        /// <summary>
        ///عملیات مربوط به مینوت وارده 
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private bool WorkingMinuteImport(JCWorkLetterType pAction)
        {
            JCLetterRegisterImport LRI = new JCLetterRegisterImport(_LetterCode);
            Data(LRI);
            if (State == JFormState.Insert)
            {
                _LetterCode = LRI.Insert(_dtCopyes, jArchiveList1,jArchiveList2, _dtRelatedLetter);
                if (_LetterCode > 0)
                {

                    jArchiveList1.ClassName = "Communication.JCLetterAttachment";
                    jArchiveList1.ObjectCode = _LetterCode;
                    jArchiveList1.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.LetterAttachment.GetHashCode();
                    jArchiveList1.PlaceCode = ArchivedDocuments.JConstantArchivePalces.LetterAttachment.GetHashCode();

                    jArchiveList2.ClassName = "Communication.JCLetter";
                    jArchiveList2.ObjectCode = _LetterCode;
                    jArchiveList2.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.Letter.GetHashCode();
                    jArchiveList2.PlaceCode = ArchivedDocuments.JConstantArchivePalces.Letter.GetHashCode();

                    _letter_status = LRI.letter_status;
                    if (LRI.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)

                    {
                        btnRegMinute.Enabled = false;
                        State = JFormState.ReadOnly;
                        _SetState();
                        _GetState(LRI);
                    }
                    State = JFormState.Update;
                    return true;
                }
                else
                {
                    JMessages.Message("Error", "", JMessageType.Information);
                    return false;
                }
            }
            else if (State == JFormState.Update)
            {
                LRI.Code = _LetterCode;
                if (LRI.Update(_LetterCode, _dtCopyes, jArchiveList1,jArchiveList2, _dtRelatedLetter))
                {
                    //if (pAction == JCWorkLetterType.Save)
                        //JMessages.Message("Minute Update successfully", "", JMessageType.Information);
                    _letter_status = LRI.letter_status;
                    if (LRI.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                    {
                        btnRegMinute.Enabled = false;
                        State = JFormState.ReadOnly;
                        _SetState();
                        _GetState(LRI);
                    }
                    return true;
                }
                else
                {
                    //JMessages.Message("Unable Letter Change", "", JMessageType.Information);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// چک کردن ورود اطلاعات فرم
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            if (cdbReceiver.SelectedItem == null)
            {
                JMessages.Error("گیرنده را انتخاب کنید", "error");
                return false;
            }
            if (cdbSubject.SelectedItem == null)
            {
                JMessages.Error("موضوع را انتخاب کنید", "error");
                return false;
            }
            return true;
        }
        /// <summary>
        /// داده ها ی مشترک برای انواع نامه ها
        /// </summary>
        /// <param name="LRI"></param>
        private void Data(JCLetterRegister LRI)
        {
            LRI.Current_Refer_Code = _Refer_Code;
            //------------------- گیرنده ------------------------------------------
            if (cdbReceiver.SelectedItem != null)
            {
                LRI.receiver_post_code = Convert.ToInt32(cdbReceiver.SelectedItem["Code"]);
            }
            else
            {
                LRI.receiver_post_code = 0;
            }
            //------------------- فرستنده ------------------------------------------
            if (cdbSender.SelectedItem != null)
            {
                LRI.sender_external_code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                LRI.sender_full_title = cdbSender.SelectedItem["full_title"].ToString();
            }
            else
            {
                LRI.sender_external_code = 0;
                LRI.sender_full_title = cdbSender.Text;
            }

            //------------------- موضوع ------------------------------------------
            if (cdbSubject.SelectedItem != null)
                LRI.subject_code = Convert.ToInt32(cdbSubject.SelectedItem["Code"]);
            else
            {
                LRI.subject_code = 0;
            }
            //------------------ پیش نویس موضوع -----------------------------------
            LRI.pre_subject = txtSubjectMinute.Text.Trim();
            //------------------ پیوست --------------------------------------------
            LRI.appendix = txtAppindix.Text.Trim();
            //------------------ خلاصه ---------------------------------------------
            LRI.summary = txtSummery.Text.Trim();
            //------------------ شماره نامه وارده ----------------------------------
            LRI.incoming_no = txtLetterImportLetterNo.Text.Trim();
            //------------------ تاریخ نامه وارده ---------------------------------
            if (dteLetterImportDate.Date != DateTime.MinValue)
                LRI.incoming_date = dteLetterImportDate.Date;
            //------------------ امضا کننده نامه وارده ----------------------------
            LRI.incoming_signature_person = txtSignatured.Text.Trim();
            //------------------ نحوه دریافت ---------------------------------------
            if (cmbReceiveType.SelectedValue != null && cmbReceiveType.SelectedIndex > 0)
                LRI.receiver_type = Convert.ToInt32(cmbReceiveType.SelectedValue);
            else
            {
                LRI.receiver_type = 0;
            }
            //------------------ فوریت --------------------------------------------
            if (cmbUrgency.SelectedValue != null)
                LRI.urgency = Convert.ToInt32(cmbUrgency.SelectedValue);
            else
            {
                LRI.urgency = 0;
            }
            //------------------ سطح محرمانگی --------------------------------------
            if (cmbSecurityLevel.SelectedValue != null)
                LRI.secret_level = Convert.ToInt32(cmbSecurityLevel.SelectedValue);
            else
            {
                LRI.secret_level = 0;
            }
            //----------------- وضعیت نامه ----------------------------------------
            LRI.letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Import;
            //------------------ ضمائم --------------------------------------------
            //_dtAttachment = UC_AttachmentManager.GetData();

            //------------------ رونوشت -------------------------------------------
            _dtCopyes = UC_LetterCopy1.GetData();
        }
        /// <summary>
        /// ذخیره ضمائم در کنترل عظیمیان
        /// </summary>
        /// <param name="pLetterCode"></param>
        private void SaveAttachmant(int pLetterCode)
        {
            //jArchiveExe.ClassName = "Communication.JfrmLetterRegisterImport";
            //jArchiveExe.SubjectCode = 0;
            //jArchiveExe.PlaceCode = 0;

            //if (State == JFormState.Insert)
            //{
            //    jArchiveExe.ObjectCode = pLetterCode;
            //    jArchiveExe.ArchiveList();
            //}
            //else
            //{
            //    //----------Update Archive------------
            //    jArchiveExe.ObjectCode = pLetterCode;
            //    jArchiveExe.ArchiveList();
            //}
        }

        /// <summary>
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private bool WorkingMinute(JCWorkLetterType pAction)
        {
            return WorkingMinuteImport(pAction);
        }
        /// <summary>
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegMinute_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (WorkingMinute(JCWorkLetterType.Save))
                {
                    //if (State == JFormState.Insert)
                    JMessages.Message("Minute Register successfully", "", JMessageType.Information);
                    //if (State == JFormState.Update)
                    //JMessages.Message("Minute Update successfully", "", JMessageType.Information);
                    //State = JFormState.Confirm;
                    //else
                    //JMessages.Message("Unable Letter Change", "", JMessageType.Information);
                    //this.Close();

                }
                else
                    JMessages.Message("Error", "", JMessageType.Information);
            }
        }
        /// <summary>
        /// ذخیره فایل Word
        /// </summary>
        /// <returns></returns>
        public bool SaveFile()//ClassLibrary.JDataBase tempdb
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
        }
        #endregion

        /// <summary>
        /// باز کردن فرم جستجوی مینوت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btSearch_Click(object sender, EventArgs e)
        //{
        //    JfrmMinuteList tmpJfrmMinuteList = new JfrmMinuteList(JMainFrame.CurrentUserCode, JMainFrame.CurrentPostCode, ClassLibrary.Domains.JGlobal.JfrmState.Confirm, _StatusForm);
        //    tmpJfrmMinuteList.ShowDialog();
        //    if (tmpJfrmMinuteList.Code != 0)
        //    {
        //        SetForm(tmpJfrmMinuteList.Code);
        //        State = JFormState.Update;
        //        tmpJfrmMinuteList.Dispose();
        //    }
        //}

        /// <summary>
        /// ارجاع مینوت به دبیر خانه و باز کردن فرم ارجاع
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConMinute_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// ثبت دبیرخانه
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConSec_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// نمایش تاریخچه ضمائم مینوت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// اضافه کردن عطف پیرو به لیست
        /// </summary>
        /// <param name="pCode"></param>
        private void AddRelatedLetter(int pCode)
        {
                JCLetterRegisterImport LRI = new JCLetterRegisterImport(pCode);
                DataRow dr;
                DataTable dt=new DataTable();
                dr = _dtRelatedLetter.NewRow();            
                dt=LRI.GetDataLetter(pCode);
                if (dt.Rows.Count > 0)
                {
                    dr["Code"] = dt.Rows[0]["Code"].ToString();
                    dr["Letter_no"] = dt.Rows[0]["Letter_no"].ToString();
                    dr["incoming_no"] = dt.Rows[0]["incoming_no"].ToString();
                    if (rbPeyro.Checked)
                    {
                        dr["type"] = ClassLibrary.Domains.JAutomation.JRelatedType.Peyro;
                        dr["type_Title"] = JLanguages._Text("Peyro"); ;
                    }
                    else
                    {
                            dr["type"] = ClassLibrary.Domains.JAutomation.JRelatedType.reference;
                            dr["type_Title"] = JLanguages._Text("reference"); ;
                    }
                    dr["pre_subject"] = dt.Rows[0]["pre_subject"].ToString();
                    _dtRelatedLetter.Rows.Add(dr);
                    uC_GridLetter.Bind(_dtRelatedLetter, "Minute");
                }
        }

        /// <summary>
        /// نمایش فرم جستجوی نامه
        /// </summary>
        private void SearchLetter()
        {
            JfrmSearchLetters tmpJfrmSearchLetters = new JfrmSearchLetters(ClassLibrary.Domains.JCommunication.JLetterStatus.Letter);
            tmpJfrmSearchLetters.ShowDialog();
            if (tmpJfrmSearchLetters._Code != 0)
            {
                AddRelatedLetter(tmpJfrmSearchLetters._Code);
                tmpJfrmSearchLetters.Dispose();
                //JfrmLetterRegisterImport tmp = new JfrmLetterRegisterImport(ClassLibrary.Domains.JCommunication.JLetterType.Import, JFormState.ReadOnly, 0, _Refer_Code);
                //tmp.SetForm(tmpJfrmSearchLetters._Code);
                //tmp.ShowDialog();
            }
        }

        /// <summary>
        /// جستجوی نامه
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchLetterNo_Click(object sender, EventArgs e)
        {
            SearchLetter();
        }

        private void uC_GridLetter_GridRowDoubleClick(object sender, EventArgs e)
        {
            //JfrmLetterRegisterImport tmp = new JfrmLetterRegisterImport();
            //tmp.SetForm(Convert.ToInt32(uC_GridLetter.SelectedRow["Code"].ToString()));
            //tmp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// جستجوی اطلاعات نامه بر اساس شماره نامه برای عطف
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLetterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                if (!String.IsNullOrEmpty(txtLetterNo.Text))
                {
                    JCLetterRegisterImport LRI = new JCLetterRegisterImport(Convert.ToInt32(txtLetterNo.Text));
                    if (LRI.Code > 0)
                        AddRelatedLetter(LRI.Code);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            uC_GridLetter.RemoveSelectedRows();
        }

        /// <summary>
        /// جستجوی گیرنده ها بر اساس انتخاب فرستنده
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdbSender_Leave(object sender, EventArgs e)
        {
            Filter_Receiver();
        }
        /// <summary>
        /// جستجوی گیرنده ها بر اساس انتخاب فرستنده
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Receiver()
        {
            //this.UC_LetterCopy1 = new Communication.JUC_Copy(Convert.ToInt32(cdbSender.SelectedItem["Code"]));
            if (cdbSender.SelectedItem != null)
                UC_LetterCopy1._SetComboBoxs(Convert.ToInt32(cdbSender.SelectedItem["Code"]), ClassLibrary.Domains.JCommunication.JLetterType.Internal);

        }

        /// <summary>
        /// کپی از یک مینوت 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            JCLetterRegister tmpJCLetterRegister=new JCLetterRegister(0);
            int code = 0;
            if (_LetterCode != 0)
            {
                code = tmpJCLetterRegister.Copy(_LetterCode);
                if (code > 0)
                    JMessages.Message("Minute Register Successfuly with Number :", "", JMessageType.Information);
                else
                    JMessages.Message("Minute Register Not Successfuly with Number :", "", JMessageType.Error);
            }
            else
                JMessages.Message("Please Selected Minute ", "", JMessageType.Information);
        }
        /// <summary>
        /// آرشیو نامه
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArchive_Click(object sender, EventArgs e)
        {
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {

            if (_LetterCode < 1)
            {
                JMessages.Message("Please Save Contract First", "Error", JMessageType.Error);
                return;
            }
            JCLetterRegister tmp = new JCLetterRegister(_LetterCode);
            int id = tmp.GetAutomationObjectCode(_LetterCode);
            if (id == 0)
            {
                JDataBase DB = new JDataBase();
                try
                {
                    id = tmp.SendToAutomation(_LetterCode, DB);
                }
                finally
                {
                    DB.Dispose();
                }
            }

            if (id > 0)
            {
                if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                {// فقط بر اساس مجوز میتواند به افراد مشهص ارجا بزند
                }
                else
                    if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
                    {//به همه میتواند ارجا بزند
                    }

                JReferMain p = new JReferMain(_Refer_Code, id, true);
                if (p.ShowDialog() == DialogResult.OK)
                {
                    JMessages.Message("Refer Successfully", "", JMessageType.Information);
                    this.Close();
                }

            }
            else
                JMessages.Message("Error", "", JMessageType.Error);
        }

        private void btnDelMinute_Click(object sender, EventArgs e)
        {
            JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(_LetterCode);
            if (tmpJCLetterRegister.Delete(_LetterCode))
            {
                JMessages.Message("Delete Minute Successfuly", "", JMessageType.Information);
                this.Dispose();
            }
            else
                JMessages.Message("Delete Minute Not Successfuly", "", JMessageType.Information);
        }

        private void JfrmLetterRegisterImport_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (uC_GridLetter.SelectedRow != null)
            {
                JfrmLetterRegisterImport tmp = new JfrmLetterRegisterImport(ClassLibrary.Domains.JCommunication.JLetterType.Import, JFormState.ReadOnly, Convert.ToInt32(uC_GridLetter.SelectedRow.Cells["Code"].Value.ToString()), _Refer_Code);
                tmp.ShowDialog();
            }
            else
                JMessages.Message("Please Selected Minute ", "", JMessageType.Information);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegisterInSecretariat_Click(object sender, EventArgs e)
        {
            
            //                //-----------------------دادن شماره به نامه توسط دبیرخانه --------------
            //    if ((pAction == JCWorkLetterType.UpdateAndRegister) && (CheckSecretariat(true)))
            //    {
            //        //-------------------- پیشنویس قبلاً امضا نشده باشد
            //        if (letter_status != ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
            //        {
            //            db.Rollback(db.TransactionName);
            //            Except.NewException("Letter Not Accept!");
            //            return false;
            //        }
            //        if (secretariat_code < 1)
            //        {
            //            db.Rollback(db.TransactionName);
            //            Except.NewException("secretariat_code is ZERO!");
            //            return false;
            //        }
            //        JCSecretariat tmpJCSecretariats = new JCSecretariat();
            //        int NewNumber = tmpJCSecretariats.GetRegister_NO(secretariat_code, db);
            //        if (NewNumber < 1)
            //        {
            //            Except.NewException("secretariat_code is ZERO!");
            //            return false;
            //        }
            //        register_no = NewNumber;
            //        letter_no = tmpJCSecretariats.Prifix + NewNumber.ToString() + tmpJCSecretariats.Suffix;
            //        // از پیشنویس به نامه تبدیل شده است
            //        letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Letter;
            //    }

            
            
            
            //if (State == JFormState.Insert || JMessages.Question("Do you want save befor register in secretariat", "Save ... ") == DialogResult.Yes)
            //    btnRegMinute_Click(null, null); // save 

            //JPermissionUser Permission = new JPermissionUser();
            //Permission.
            //JSecretariatLettersTable JMainFrame.CurrentPostCode
            //State = JFormState.Update;
            //if (WorkingMinute(JCWorkLetterType.UpdateAndRegister))//ویرایش و ثبت و دریافت شماره و ارسال به گیرنگان            
                //{
                //JMessages.Message("Send Successfuly to Secretariat", "", JMessageType.Information);
                //JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(_LetterCode);
                //if (tmpJCLetterRegister.SendAttachmentToArchive())
                //    JMessages.Message("Archive Successfuly ", "", JMessageType.Information);
                //else
                //    JMessages.Message("Archive Not Successfuly ", "", JMessageType.Error);
            //}

            //ArchivedDocuments.JArchiveForm tmp = new ArchivedDocuments.JArchiveForm("Communication.JCLetter", _LetterCode);
            ////frmArchiveFiles tmp = new frmArchiveFiles(_LetterCode);
            //foreach (DataRow dr in _dtAttachment.Rows)
            //{
            //    JFile attachment = new JFile();
            //    attachment.Content = (byte[])dr["file_content"];
            //    attachment.FileText = (string)dr["file_text"];
            //    attachment.FileName = dr["file_name"].ToString();
            //    tmp.Files.Add(attachment);
            //}
            //if (tmp.ShowDialog() == DialogResult.OK)
            //{
            //    JDataBase db = new JDataBase();
            //    JCLetterAttachment tmp1 = new JCLetterAttachment();
            //    tmp1.Update(1,,db);
            //    tmpAttachment.Delete(_LetterCode, db);
            //    JMessages.Message("Archive Successfuly ", "", JMessageType.Information); 
            //}

            //this.Dispose();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }      
    }
}
