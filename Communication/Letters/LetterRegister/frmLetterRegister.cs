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
    public partial class JfrmLetterRegister : ClassLibrary.JBaseForm
    {
        /// <summary>
        /// فیلد ها
        /// </summary>
        #region Feilds
        private bool _FlagChange = false;
        public int _LetterCode;
        public int _SecretariatCode;
        private DataTable _dtRelatedLetter = new DataTable();
        private int _LetterType;
        /// <summary>
        /// وضعیت نامه
        /// </summary>
        int _letter_status;
        /// <summary>
        /// 
        /// </summary>
        string _Letter_No = "";
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
        public JfrmLetterRegister(int pLetterType, JFormState pState, int pLetterCode, int pCurrentReferCode)
        {
            InitializeComponent();
            if (DesignMode) return;

            _LetterCode = pLetterCode;
            _LetterType = pLetterType;
            State = pState;
            _Refer_Code = pCurrentReferCode;
            if (pCurrentReferCode > 0)
                refersText1.LoadRefer(pCurrentReferCode);

            InitController();
            VisibleControls(pLetterType);
            _SetCmb();
            _SetState();
            if (pLetterCode > 0)
                SetForm(pLetterCode);

            if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                this.Text = "نامه صادره از سازمان به خارج از سازمان";
            if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                this.Text = "نامه داخلی در سازمان";
            if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                this.Text = "نامه وارده به سازمان از خارج از سازمان";

        }

        #region Functions

        private void InitController()
        {
            try
            {
                UC_LetterCopy1.Initialize();
                _dtRelatedLetter.Columns.Add("Code");
                _dtRelatedLetter.Columns.Add("Letter_no");
                _dtRelatedLetter.Columns.Add("incoming_no");
                _dtRelatedLetter.Columns.Add("Letter_Type");                                
                _dtRelatedLetter.Columns.Add("Letter_Type_Title");
                _dtRelatedLetter.Columns.Add("type");
                _dtRelatedLetter.Columns.Add("type_Title");
                _dtRelatedLetter.Columns.Add("pre_subject");
                SenderLable.Text = "Sender :";

                jArchiveListAttachMent.ClassName = "Communication.JCLetterAttachment";
                jArchiveListAttachMent.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.LetterAttachment.GetHashCode();
                jArchiveListAttachMent.PlaceCode = ArchivedDocuments.JConstantArchivePalces.LetterAttachment.GetHashCode();
                if (jArchiveListAttachMent.FileCount > 0)
                {
                    lbAttachment.Text = "ضمیمه دارد";
                }
                else
                {
                    lbAttachment.Text = "ضمیمه ندارد";
                }

                jArchiveList2.ClassName = "Communication.JCLetter";
                jArchiveList2.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.Letter.GetHashCode();
                jArchiveList2.PlaceCode = ArchivedDocuments.JConstantArchivePalces.Letter.GetHashCode();
                if (_LetterCode > 0)
                {
                    jArchiveListAttachMent.ObjectCode = _LetterCode;
                    jArchiveList2.ObjectCode = _LetterCode;

                    winWordControl1.GetData("Communication.JCLetter", _LetterCode);
                }
                else
                {
                    jArchiveListAttachMent.ObjectCode = -2;
                    jArchiveList2.ObjectCode = -2;
                }
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void VisibleControls(int pLetterType)
        {
            try
            {
                if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                {
                    //  ---------------------- Set ComboBox Sender --------------------------
                    cdbSender.TitleFieldName = "full_title";
                    cdbSender.AccessCodeFieldName = "accesscode";
                    cdbSender.CodeFieldName = "code";
                    string _sql = " AND " + JPermission.getUserSql("Communication.JCLetterRegister.CheckConfirmExports", "orgChart.code");

                    cdbSender.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(0, JMainFrame.GetActiveChartCode().ToString(), true, _sql);
                    cdbSender.SetComboBox();
                    //  ---------------------- Set ComboBox Receiver --------------------------
                    cdbReceiver.TitleFieldName = "Full_Title";
                    cdbReceiver.AccessCodeFieldName = "code";
                    cdbReceiver.CodeFieldName = "code";
                    cdbReceiver.dataTable = JAllPerson.GetDataContractPerson(0, "", -1, JPersonTypes.None, "");
                    cdbReceiver.SetComboBox();
                    //-------------------------------------------------------------------------
                    groupBoxImportLetterInfo.Visible = false;
                    //-------------------------------------------------------------------------
                    dbcntLetterRegister.TabPages.Remove(tabLetterImage);
                    winWordControl1.LoadDocument();
                }

                if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                {
                    //  ---------------------- Set ComboBox Sender --------------------------
                    cdbSender.TitleFieldName = "full_title";
                    cdbSender.AccessCodeFieldName = "accesscode";
                    cdbSender.CodeFieldName = "code";
                    cdbSender.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(0, JMainFrame.GetActiveChartCode().ToString(), true);
                    cdbSender.SetComboBox();
                    //  ---------------------- Set ComboBox Receiver --------------------------
                    cdbReceiver.TitleFieldName = "full_title";
                    cdbReceiver.AccessCodeFieldName = "accesscode";
                    cdbReceiver.CodeFieldName = "code";
                    //if (cdbSender.SelectedItem != null)
                    cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(0, JMainFrame.GetActiveChartCode().ToString(), true);
                    //else
                    //cdbReceiver.dataTable = null;
                    cdbReceiver.SetComboBox();
                    //-------------------------------------------------------------------------
                    groupBoxImportLetterInfo.Visible = false;
                    //-------------------------------------------------------------------------
                    dbcntLetterRegister.TabPages.Remove(tabLetterImage);
                    winWordControl1.LoadDocument();
                    //---------------------------------------------------------------------------چ
                    cmbSendType.Visible = false;
                    labelSendType.Visible = false;
                }

                if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                {
                    //  ---------------------- Set ComboBox Sender --------------------------
                    cdbSender.TitleFieldName = "Full_Title";
                    cdbSender.AccessCodeFieldName = "code";
                    cdbSender.CodeFieldName = "code";

                    cdbSender.dataTable = JAllPerson.GetDataContractPerson(0, "", -1, JPersonTypes.None, "");
                    cdbSender.SetComboBox();
                    //  ---------------------- Set ComboBox Receiver --------------------------
                    cdbReceiver.TitleFieldName = "full_title";
                    cdbReceiver.AccessCodeFieldName = "accesscode";
                    cdbReceiver.CodeFieldName = "code";
                    cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(0, JMainFrame.GetActiveChartCode().ToString(), true);
                    cdbReceiver.SetComboBox();
                    //-------------------------------------------------------------------------
                    groupBoxImportLetterInfo.Visible = true;
                    cmbSendType.Visible = false;
                    labelSendType.Visible = false;
                    //-------------------------------------------------------------------------
                    dbcntLetterRegister.TabPages.Remove(tbpLetterWord);
                }
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void _GetState(JCLetterRegister LRI)
        {
            try
            {
                if (LRI.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                {
                    JCSecretariat tmpCSecretariat = new JCSecretariat(LRI.secretariat_code);
                    //labelState.Text = " نامه به شماره  " + LRI.register_no.ToString() + " در دبیرخانه " + tmpCSecretariat.Name.ToString() + "\n"; ;
                    txtState.Text = " نامه به شماره  " + LRI.register_no.ToString() + " در دبیرخانه " + tmpCSecretariat.Name.ToString() + "\r\n";
                    //txtState.Lines[0] = " نامه به شماره  " + LRI.register_no.ToString() + " در دبیرخانه " + tmpCSecretariat.Name.ToString();
                    JCSecretariatLetter tmp = new JCSecretariatLetter();
                    DataTable dt = tmp.GetList(LRI.Code);
                    int i = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //labelState.Text = labelState.Text + " نامه به شماره  " + dr["register_no"].ToString() + " در دبیرخانه " + dr["Name"].ToString() + "\n";
                        txtState.Text = txtState.Text + " نامه به شماره  " + dr["register_no"].ToString() + " در دبیرخانه " + dr["Name"].ToString() + "\r\n";
                    }
                    State = JFormState.ReadOnly;
                    btnRegMinute.Enabled = false;
                    juC_ReferHistory.ReferGroup = new int[] { 3 };

                    string _Query = @"select * from Letters L where L.Code in
                                    (
	                                        select O.externalcode from Refer R inner join Objects O on R.object_code = O.Code
	                                        where O.action = 'Communication.JCLetterRegister.ReferShow'
	                                        AND O.externalcode = " + LRI.Code +
                                            @" AND R.ReferGroup in  (3) 
	                                        And (R.receiver_post_code=" + JMainFrame.CurrentPostCode + @")
                                    )
                                    AND L.letter_status = 2";

                    JDataBase Db = new JDataBase();
                    try
                    {
                        Db.setQuery(_Query);
                        Db.Query_DataReader();
                        if (Db.DataReader.Read())
                        {
                            btnRefer.Enabled = true;
                        }
                        else
                        {
                            btnRefer.Enabled = false;
                        }

                    }
                    catch
                    {
                    }
                    finally
                    {
                        Db.DisConnect();
                    }
                }
                else
                    if (LRI.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
                    {
                        juC_ReferHistory.ReferGroup = new int[] { 1, 2, 3 };
                        Automation.JAObject obj = new Automation.JAObject();
                        obj.FindObjectByExternalcode(ClassLibrary.Domains.JAutomation.JObjectType.Letters, LRI.Code);
                        DataTable DT = obj.GetLastsRefer(JMainFrame.CurrentPostCode);
                        if (DT.Rows.Count > 0 && (int)(DT.Rows[DT.Rows.Count - 1][Refer.receiver_post_code.ToString()]) == JMainFrame.CurrentPostCode)
                        {
                            //labelState.Text = "نامه امضا شده";
                            txtState.Text = "نامه امضا شده";
                            btnRegMinute.Enabled = true;
                            btnRefer.Enabled = true;
                            JDataBase db = new JDataBase();
                            try
                            {
                                DataTable secretariats = JCSecretariat.GetScretariatUserCodes(JMainFrame.CurrentPostCode, db);
                                if (secretariats.Rows.Count > 0)
                                    btnBack.Visible = true;
                            }
                            finally
                            {
                                db.Dispose();
                            }
                        }
                        else
                        {
                            //labelState.Text = " نامه امضا شده ";
                            txtState.Text = "نامه امضا شده";
                            State = JFormState.ReadOnly;
                            btnRegMinute.Enabled = false;
                            btnRefer.Enabled = false;
                        }
                    }
                    else
                    {
                        juC_ReferHistory.ReferGroup = new int[] { 1, 2 };
                        Automation.JAObject obj = new Automation.JAObject();
                        if ((LRI.Code > 0) && obj.FindObjectByExternalcode(ClassLibrary.Domains.JAutomation.JObjectType.Letters, LRI.Code))
                        {
                            DataTable DT = obj.GetLastsRefer(JMainFrame.CurrentPostCode);
                            if (DT.Rows.Count > 0 && (int)(DT.Rows[DT.Rows.Count - 1][Refer.receiver_post_code.ToString()]) == JMainFrame.CurrentPostCode)
                            {
                                //labelState.Text = " پیش نویش قابل ویرایش ";
                                txtState.Text = " پیش نویش قابل ویرایش ";
                                btnRegMinute.Enabled = true;
                                btnRefer.Enabled = true;
                            }
                            else
                            {
                                //labelState.Text = " پیش نویش غیر قابل ویرایش ";
                                txtState.Text = " پیش نویش غیر قابل ویرایش ";
                                State = JFormState.ReadOnly;
                                btnRegMinute.Enabled = false;
                                btnRefer.Enabled = false;
                            }
                        }
                        else
                        {
                            //labelState.Text = " پیش نویش قابل ویرایش ";
                            txtState.Text = " پیش نویش قابل ویرایش ";
                            btnRegMinute.Enabled = true;
                        }
                    }
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
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
                    cdbReceiver.Enabled = false;
                    cdbSender.Enabled = false;
                    cdbSubject.Enabled = false;
                    UC_LetterCopy1.Enabled = false;
                    txtLetterNo.Enabled = false;
                    jArchiveListAttachMent.EnabledChange = false;
                    jArchiveList2.EnabledChange = false;
                    groupBox2.Enabled = false;
                    
                    groupBoxImportLetterInfo.Enabled = false;
                    txtSummery.Enabled = false;
                    txtAppindix.Enabled = false;
                    txtSubjectMinute.Enabled = false;
                    if (winWordControl1 != null && winWordControl1.document != null)
                    {
                        Object oMissing = System.Reflection.Missing.Value;
                        object Password = (string)"1234567890";
                        winWordControl1.document.Protect(Microsoft.Office.Interop.Word.WdProtectionType.wdAllowOnlyReading,
                            ref oMissing, ref Password, ref oMissing, ref oMissing);
                    }

                }
            }
            catch (Exception ex)
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
                //  ---------------------- Set ComboBox SendType --------------------------
                cmbSendType.DisplayMember = "name";
                cmbSendType.ValueMember = "code";
                dt = (new JRecieveTypeDefine()).GetList();
                dr = dt.NewRow();
                dr["code"] = "-1";
                dr["name"] = "-----------";
                dt.Rows.InsertAt(dr, 0);
                cmbSendType.DataSource = dt;
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

                /// فایل الگو
                cmbPattern.DataSource = JPatternFiles.GetDataTable(0);
                cmbPattern.ValueMember = "Code";
                cmbPattern.DisplayMember = "Name";
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
            try
            {
                if (pLetterCode < 1) return;
                _LetterCode = pLetterCode;
                JCLetterRegisterImport LRI = new JCLetterRegisterImport(pLetterCode);
                //------------------پاسخ ---------------
                if (LRI.Respite_date_time != DateTime.MinValue)
                {
                    chkResponse.Enabled = true;
                    txtPersuit.Date = LRI.Respite_date_time;
                }
                //------------------رونوشت ---------------
                UC_LetterCopy1.SetData(pLetterCode);
                _dtCopyes = UC_LetterCopy1.GetData();
                //------------------عطف ---------------
                _dtRelatedLetter.Clear();
                JCRelatedLetter tmpJCRelatedLetter = new JCRelatedLetter();
                foreach (DataRow dr in tmpJCRelatedLetter.GetDate(pLetterCode).Rows)
                    AddRelatedLetter(Convert.ToInt32(dr["dependent_lettercode"].ToString()), Convert.ToInt32(dr["type"].ToString()));
                jdgvRelated.DataSource = _dtRelatedLetter;
                // _dtRelatedLetter = tmpJCRelatedLetter.GetDate(pLetterCode);
                jdgvRelated.Columns["Letter_Type"].Visible = false;
                jdgvRelated.Columns["type"].Visible = false;

                //------------------ پر کردن اطلاعات فرستنده گیرنده بر اساس نوع نامه -----------------------------------------
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                {
                    if ((new JAllPerson(LRI.receiver_external_code)).Code != 0)
                    {
                        JAllPerson OrganTemp = new JAllPerson(LRI.receiver_external_code);
                        cdbReceiver.SetValue(OrganTemp.Code);
                    }
                    cdbSender.SetValue((new Employment.JEOrganizationChart(LRI.sender_post_code)).AccessCode);
                }
                //----------------------------------
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                {
                    cdbSender.SetValue((new Employment.JEOrganizationChart(LRI.sender_post_code)).AccessCode);
                    cdbReceiver.SetValue((new Employment.JEOrganizationChart(LRI.receiver_post_code)).AccessCode);
                }
                //----------------------------------
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                {
                    if ((new JAllPerson(LRI.sender_external_code)).Code != 0)
                    {
                        JAllPerson OrganTemp = new JAllPerson(LRI.sender_external_code);
                        cdbSender.SetValue(OrganTemp.Code);
                    }
                    cdbReceiver.SetValue((new Employment.JEOrganizationChart(LRI.receiver_post_code)).AccessCode);
                }
                //------------------------------------------------------------------------------------------------------------
                ArchivedDocuments.JSubjectTree sub = new ArchivedDocuments.JSubjectTree();
                cdbSubject.SetValue((new ArchivedDocuments.JSubjectTree()).GetAccessCode(LRI.subject_code));
                txtSubjectMinute.Text = LRI.pre_subject;
                txtAppindix.Text = LRI.appendix;
                txtSummery.Text = LRI.summary;
                txtLetterImportLetterNo.Text = LRI.incoming_no;
                dteLetterImportDate.Text = (JDateTime.FarsiDate(LRI.incoming_date));
                txtSignatured.Text = LRI.incoming_signature_person;
                _SecretariatCode = LRI.secretariat_code;

                cmbReceiveType.SelectedValue = LRI.receiver_type;
                cmbSendType.SelectedValue = LRI.send_type;

                cmbUrgency.SelectedValue = LRI.urgency;
                cmbSecurityLevel.SelectedValue = LRI.secret_level;

                _Letter_No = LRI.letter_no;
                _letter_status = LRI.letter_status;
                _LetterType = LRI.letter_type;

                //----------------------------------درخت ارجاعات -------------------------------------------------------
                juC_ReferHistory.SetData(pLetterCode, ClassLibrary.Domains.JAutomation.JObjectType.Letters);

                _GetState(LRI);
                _FlagChange = false;
                //
                if (LRI.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
                {
                    cdbSender.Enabled = false;
                    cdbReceiver.Enabled = false;
                }
                if (LRI.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                    btnDependent.Visible = true;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void _SetComboBox()
        {
            try
            {
                //  ---------------------- Set ComboBox Sender --------------------------
                cdbSender.AccessCodeFieldName = "access_code";
                cdbSender.TitleFieldName = "full_title";
                cdbSender.CodeFieldName = "code";
                cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
                cdbSender.SetComboBox();

            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        #endregion Functions
        /// <summary>
        /// مجوزدهی
        /// ثبت نامه وابسته توسط دبیرخانه
        /// </summary>
        public void PermissionSecretriat()
        {
            if (!JPermission.CheckPermission("Communication.JfrmLetterRegister.PermissionSecretriat", false))
            {
                btnSearchLetterNo.Enabled = false;
                btnDelete.Enabled = false;
                //dbcntLetterRegister.TabPages.Remove(tbpRelated);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JfrmLetterRegisterImport_Load(object sender, EventArgs e)
        {
            try
            {
                PermissionSecretriat();
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
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void btnSelOrganization_Click(object sender, EventArgs e)
        {
            try
            {
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                {
                    Employment.JEfrmOrganizatinChart Org = new Employment.JEfrmOrganizatinChart();
                    Org.ViewMode = true;
                    if (Org.ShowDialog() == DialogResult.OK)
                    {
                        if (Org.SelectedItem != null)
                            cdbSender.SetValue(Org.SelectedItem["accesscode"]);
                    }
                    Org.Dispose();
                }
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                {
                    Employment.JEfrmOrganizatinChart Org = new Employment.JEfrmOrganizatinChart();
                    Org.ViewMode = true;
                    if (Org.ShowDialog() == DialogResult.OK)
                    {
                        if (Org.SelectedItem != null)
                            cdbSender.SetValue(Org.SelectedItem["accesscode"]);
                    }
                    Org.Dispose();
                    Filter_Receiver();
                }
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                {
                    JFindPersonForm PFind = new JFindPersonForm();
                    if (PFind.ShowDialog() == DialogResult.OK)
                    {
                        if (PFind.SelectedPerson != null)
                            cdbSender.SetValue(PFind.SelectedPerson.Code);
                    }
                    PFind.Dispose();
                }
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void btnReceiver_Click(object sender, EventArgs e)
        {
            try
            {
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                {
                    JFindPersonForm PFind = new JFindPersonForm();
                    if (PFind.ShowDialog() == DialogResult.OK)
                    {
                        if (PFind.SelectedPerson != null)
                            cdbSender.SetValue(PFind.SelectedPerson.Code);
                    }
                    PFind.Dispose();
                }
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                {
                    Employment.JEfrmOrganizatinChart Org = new Employment.JEfrmOrganizatinChart();
                    Org.ViewMode = true;
                    if (Org.ShowDialog() == DialogResult.OK)
                    {
                        if (Org.SelectedItem != null)
                            cdbReceiver.SetValue(Org.SelectedItem["accesscode"]);
                    }
                    Org.Dispose();
                }
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                {
                    Employment.JEfrmOrganizatinChart Org = new Employment.JEfrmOrganizatinChart();
                    Org.ViewMode = true;
                    if (Org.ShowDialog() == DialogResult.OK)
                    {
                        if (Org.SelectedItem != null)
                            cdbReceiver.SetValue(Org.SelectedItem["accesscode"]);
                    }
                    Org.Dispose();
                }
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        /// <summary>
        /// نمایش لیست موضوعات نامه 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubjectList_Click(object sender, EventArgs e)
        {
            try
            {
                ArchivedDocuments.JSubjectForm sub = new ArchivedDocuments.JSubjectForm();
                DialogResult Res = sub.ShowDialog();
                ArchivedDocuments.JSubjectTree Subject = new ArchivedDocuments.JSubjectTree();
                cdbSubject.AccessCodeFieldName = "AccessCode";
                cdbSubject.TitleFieldName = "name";
                cdbSubject.CodeFieldName = "code";
                cdbSubject.dataTable = Subject.GetSubjectList();
                cdbSubject.SetComboBox();
                if (Res == DialogResult.OK)
                    cdbSubject.SetValue(((ClassLibrary.JCustomTreeNode)(sub.SelectedItem)).FieldsValue["AccessCode"].ToString());
                sub.Dispose();
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }


        private void txtAppindix_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
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
            try
            {
                JCLetterRegisterImport LRI = new JCLetterRegisterImport(_LetterCode);
                Data(LRI);
                if (State == JFormState.Insert)
                {
                    _LetterCode = LRI.Insert(_dtCopyes, jArchiveListAttachMent, jArchiveList2, _dtRelatedLetter);
                    if (_LetterCode > 0)
                    {

                        jArchiveListAttachMent.ClassName = "Communication.JCLetterAttachment";
                        jArchiveListAttachMent.ObjectCode = _LetterCode;
                        jArchiveListAttachMent.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.LetterAttachment.GetHashCode();
                        jArchiveListAttachMent.PlaceCode = ArchivedDocuments.JConstantArchivePalces.LetterAttachment.GetHashCode();

                        jArchiveList2.ClassName = "Communication.JCLetter";
                        jArchiveList2.ObjectCode = _LetterCode;
                        jArchiveList2.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.Letter.GetHashCode();
                        jArchiveList2.PlaceCode = ArchivedDocuments.JConstantArchivePalces.Letter.GetHashCode();

                        _letter_status = LRI.letter_status;
                        State = JFormState.Update;
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
                    if (LRI.Update(_LetterCode, _dtCopyes, jArchiveListAttachMent, jArchiveList2, _dtRelatedLetter))
                    {
                        _letter_status = LRI.letter_status;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (LRI.LetterSend)
                {
                    this.Close();
                    //btnRegMinute.Enabled = false;
                    //State = JFormState.ReadOnly;
                    //_SetState();
                    //_GetState(LRI);
                }
                return true;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }


        /// <summary>
        ///عملیات مربوط به مینوت داخلی 
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private bool WorkingMinuteInternal(JCWorkLetterType pAction)
        {
            try
            {
                JCLetterRegisterInternal LRI = new JCLetterRegisterInternal(_LetterCode);
                Data(LRI);
                if (State == JFormState.Insert)
                {
                    _LetterCode = LRI.Insert(_dtCopyes, jArchiveListAttachMent, winWordControl1, _dtRelatedLetter);
                    if (_LetterCode > 0)
                    {

                        jArchiveListAttachMent.ClassName = "Communication.JCLetterAttachment";
                        jArchiveListAttachMent.ObjectCode = _LetterCode;
                        jArchiveListAttachMent.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.LetterAttachment.GetHashCode();
                        jArchiveListAttachMent.PlaceCode = ArchivedDocuments.JConstantArchivePalces.LetterAttachment.GetHashCode();

                        _letter_status = LRI.letter_status;
                        State = JFormState.Update;
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
                    if (LRI.Update(_LetterCode, _dtCopyes, jArchiveListAttachMent, winWordControl1, _dtRelatedLetter, JCWorkLetterType.Save))
                    {
                        _letter_status = LRI.letter_status;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (LRI.LetterSend)
                {
                    this.Close();
                    //btnRegMinute.Enabled = false;
                    //State = JFormState.ReadOnly;
                    //_SetState();
                    //_GetState(LRI);
                }
                return true;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return false;
            }
        }


        /// <summary>
        ///عملیات مربوط به مینوت صادره 
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private bool WorkingMinuteExport(JCWorkLetterType pAction)
        {
            try
            {
                JCLetterRegisterExport LRI = new JCLetterRegisterExport(_LetterCode);
                Data(LRI);
                if (State == JFormState.Insert)
                {
                    _LetterCode = LRI.Insert(_dtCopyes, jArchiveListAttachMent, winWordControl1, _dtRelatedLetter);
                    if (_LetterCode > 0)
                    {

                        jArchiveListAttachMent.ClassName = "Communication.JCLetterAttachment";
                        jArchiveListAttachMent.ObjectCode = _LetterCode;
                        jArchiveListAttachMent.SubjectCode = ArchivedDocuments.JConstantArchiveSubjects.LetterAttachment.GetHashCode();
                        jArchiveListAttachMent.PlaceCode = ArchivedDocuments.JConstantArchivePalces.LetterAttachment.GetHashCode();

                        _letter_status = LRI.letter_status;
                        State = JFormState.Update;
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
                    if (LRI.Update(_LetterCode, _dtCopyes, jArchiveListAttachMent, winWordControl1, _dtRelatedLetter))
                    {
                        _letter_status = LRI.letter_status;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (LRI.LetterSend)
                {
                    this.Close();
                    //btnRegMinute.Enabled = false;
                    //State = JFormState.ReadOnly;
                    //_SetState();
                    //_GetState(LRI);
                }
                return true;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return false;
            }
        }
        /// <summary>
        /// چک کردن ورود اطلاعات فرم
        /// </summary>
        /// <returns></returns>
        private bool CheckData()
        {
            try
            {
                if ((cdbReceiver.SelectedItem == null))// || (cdbReceiver.SelectedItem.Row.ItemArray[0].ToString() != "-1"))
                {
                    JMessages.Error("لطفا گیرنده  را از لیست انتخاب کنید", "error");
                    return false;
                }
                if ((cdbSender.SelectedItem == null))// || (cdbSender.SelectedItem.Row.ItemArray[0].ToString() != "-1"))
                {
                    JMessages.Error("لطفا فرستنده را از لیست انتخاب کنید", "error");
                    return false;
                }
                if (cdbReceiver.SelectedItem.Row.ItemArray[0].ToString() == cdbSender.SelectedItem.Row.ItemArray[0].ToString())
                {
                    JMessages.Error("فرستنده و گیرنده نمی تواند یکسان باشد ", "error");
                    return false;
                }
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                if (txtLetterImportLetterNo.Text == "")
                {
                    JMessages.Error("شماره نامه وارده را وارد کنید", "error");
                    return false;
                }
                //if (cdbSubject.SelectedItem == null)
                //{
                //    JMessages.Error("موضوع را انتخاب کنید", "error");
                //    return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return false;
            }
        }
        /// <summary>
        /// رونوشتها را بصورت متن برمیگرداند
        /// </summary>
        /// <param name="pCopies"></param>
        /// <returns></returns>
        private string GetCopiesText(DataTable pCopies)
        {
            string copies = "";
            foreach (DataRow row in pCopies.Rows)
            {
                copies = copies + row["RecieverText"].ToString() + "\r\n";
            }
            return copies;
        }
        /// <summary>
        /// داده ها ی مشترک برای انواع نامه ها
        /// </summary>
        /// <param name="LRI"></param>
        private void Data(JCLetterRegister LRI)
        {
            try
            {
                LRI.Current_Refer_Code = _Refer_Code;
                //------------------- گیرنده ------------------------------------------
                if (cdbReceiver.SelectedItem != null)
                {

                    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import
                        || _LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    {
                        LRI.receiver_post_code = Convert.ToInt32(cdbReceiver.SelectedItem["Code"]);
                        LRI.receiver_code = (int)cdbReceiver.SelectedItem["pcode"];
                    }

                    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    {
                        LRI.receiver_external_code = Convert.ToInt32(cdbReceiver.SelectedItem["Code"]);
                        LRI.receiver_code = (int)cdbReceiver.SelectedItem["code"];
                    }
                    LRI.receiver_full_title = cdbReceiver.SelectedItem["full_title"].ToString();
                }
                else
                {
                    LRI.receiver_post_code = 0;
                    LRI.receiver_external_code = 0;
                    LRI.receiver_code = 0;
                    LRI.receiver_full_title = "";
                }
                //------------------- فرستنده ------------------------------------------
                if (cdbSender.SelectedItem != null)
                {
                    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export
                        || _LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    {
                        LRI.sender_post_code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                        LRI.sender_code = (int)cdbSender.SelectedItem["pcode"];
                    }

                    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                    {
                        LRI.sender_external_code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                        LRI.sender_code = (int)cdbSender.SelectedItem["code"];
                    }

                    LRI.sender_full_title = cdbSender.SelectedItem["full_title"].ToString();
                }
                else
                {
                    LRI.sender_external_code = 0;
                    LRI.sender_full_title = "";
                    LRI.sender_code = 0;
                    LRI.sender_post_code = 0;
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
                LRI.register_date_time = (new JDataBase().GetCurrentDateTime());
                //------------------ نحوه دریافت ---------------------------------------
                if (cmbReceiveType.SelectedValue != null && cmbReceiveType.SelectedIndex > 0)
                    LRI.receiver_type = Convert.ToInt32(cmbReceiveType.SelectedValue);
                else
                {
                    LRI.receiver_type = 0;
                }
                //------------------ نحوه دریافت ---------------------------------------
                if (cmbSendType.SelectedValue != null && cmbSendType.SelectedIndex > 0)
                    LRI.send_type = Convert.ToInt32(cmbSendType.SelectedValue);
                else
                {
                    LRI.send_type = 0;
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
                LRI.letter_type = _LetterType;
                //------------------ ضمائم --------------------------------------------
                //_dtAttachment = UC_AttachmentManager.GetData();

                //------------------ رونوشت -------------------------------------------
                _dtCopyes = UC_LetterCopy1.GetData();
                LRI.CopiesText = GetCopiesText(_dtCopyes);
                //------------------ مهلت پاسخ -------------------------------------------
                if ((txtPersuit.Date != DateTime.MinValue) && (chkResponse.Checked))
                    LRI.Respite_date_time = txtPersuit.Date;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }
        /// <summary>
        /// ذخیره ضمائم در کنترل عظیمیان
        /// </summary>
        /// <param name="pLetterCode"></param>
        private void SaveAttachmant(int pLetterCode)
        {
        }

        /// <summary>
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private bool WorkingMinute(JCWorkLetterType pAction)
        {
            try
            {
                /// نامه وارده به سازمان
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                    return WorkingMinuteImport(pAction);
                /// نامه صادره از سازمان
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    return WorkingMinuteExport(pAction);
                /// نامه داخلی
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    return WorkingMinuteInternal(pAction);

                return false;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                return false;
            }
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
                    //Hassanzadeh  اگر امضا شد و ارسال به دبیرخانه شد فرم بسته شود
                    if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
                        this.Close();
                    JMessages.Message("Minute Register successfully", "", JMessageType.Information);
                    _FlagChange = false;
                }
                else
                    JMessages.Message("Error", "", JMessageType.Information);
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
        private void AddRelatedLetter(int pCode, int pRelatedType)
        {
            try
            {
                if (jdgvRelated.DataSource != null)
                {
                    jdgvRelated.Columns["Letter_Type"].Visible = false;
                    jdgvRelated.Columns["type"].Visible = false;
                }
                JCLetterRegisterImport LRI = new JCLetterRegisterImport(pCode);
                DataRow dr;
                DataTable dt = new DataTable();
                dr = _dtRelatedLetter.NewRow();
                dt = LRI.GetDataLetter(pCode);
                if ((_dtRelatedLetter.Rows.Count == 0) || ((_dtRelatedLetter.Rows.Count > 0) && (_dtRelatedLetter.Select(" Code =" + pCode.ToString()).Length <= 1)))
                {
                    dr["Code"] = dt.Rows[0]["Code"].ToString();
                    dr["Letter_no"] = dt.Rows[0]["Letter_no"].ToString();
                    dr["incoming_no"] = dt.Rows[0]["incoming_no"].ToString();
                    dr["Letter_Type"] = dt.Rows[0]["Letter_Type"].ToString();
                    if (Convert.ToInt32(dr["Letter_Type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                        dr["Letter_Type_Title"] = "نامه داخلی";
                    else if (Convert.ToInt32(dr["Letter_Type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                        dr["Letter_Type_Title"] = "نامه صادره";
                    else if (Convert.ToInt32(dr["Letter_Type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                        dr["Letter_Type_Title"] = "نامه وارده";
                    //// عطف یا پاسخ
                    if (pRelatedType == ClassLibrary.Domains.JAutomation.JRelatedType.Peyro)
                    {
                        dr["Type"] = 2;
                        dr["type_Title"] = JLanguages._Text("Peyro");
                    }
                    else if (pRelatedType == ClassLibrary.Domains.JAutomation.JRelatedType.Reply)
                    {
                        dr["Type"] = 1;
                        dr["type_Title"] = JLanguages._Text("Reply");
                    }

                    dr["pre_subject"] = dt.Rows[0]["pre_subject"].ToString();
                    _dtRelatedLetter.Rows.Add(dr);
                    jdgvRelated.DataSource = _dtRelatedLetter;
                }
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        /// <summary>
        /// نمایش فرم جستجوی نامه
        /// </summary>
        private void SearchLetter()
        {
            try
            {
                //Employment.JEOrganizationChart tmpChart = new Employment.JEOrganizationChart();
                //JCLetterRegister LRI = new JCLetterRegister(_LetterCode);
                //tmpChart.GetData(JMainFrame.CurrentPostCode);

                //JfrmSearchLetters tmpJfrmSearchLetters = new JfrmSearchLetters(ClassLibrary.Domains.JCommunication.JLetterStatus.Letter, tmpChart.secretariat_code);
                //tmpJfrmSearchLetters.ShowDialog();
                //            DataTable dt = new DataTable();

                JfrmSearchLetter tmpJCSearchLetter = new JfrmSearchLetter();
                tmpJCSearchLetter.ShowDialog();
                if (tmpJCSearchLetter._Code != 0)
                {
                    if (rbAtf.Checked)
                    {
                        AddRelatedLetter(tmpJCSearchLetter._Code, ClassLibrary.Domains.JAutomation.JRelatedType.Peyro);
                    }
                    if (rbPeyro.Checked)
                    {
                        AddRelatedLetter(tmpJCSearchLetter._Code, ClassLibrary.Domains.JAutomation.JRelatedType.Reply);
                    }
                    //tmpJfrmSearchLetters.Dispose();
                    //JfrmLetterRegisterImport tmp = new JfrmLetterRegisterImport(ClassLibrary.Domains.JCommunication.JLetterType.Import, JFormState.ReadOnly, 0, _Refer_Code);
                    //tmp.SetForm(tmpJfrmSearchLetters._Code);
                    //tmp.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
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
                if (!String.IsNullOrEmpty(txtLetterNo.Text))
                {
                    JCLetterRegister tmp = new JCLetterRegister();
                    tmp.letter_no = txtLetterNo.Text.Trim();
                    DataTable dt = new DataTable();
                    JCSearchLetter tmpJCSearchLetter = new JCSearchLetter();
                    string Letter_Type = "(1,2,3)";
                    dt = tmpJCSearchLetter.SearchLetter1(tmp, Letter_Type);
                    if ((dt != null) && (dt.Rows.Count > 0))
                    {
                        if (rbAtf.Checked)
                            AddRelatedLetter(Convert.ToInt32(dt.Rows[0]["Code"]), ClassLibrary.Domains.JAutomation.JRelatedType.Peyro);
                        if (rbPeyro.Checked)
                            AddRelatedLetter(Convert.ToInt32(dt.Rows[0]["Code"]), ClassLibrary.Domains.JAutomation.JRelatedType.Reply);

                    }                    
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvRelated.Rows.Count>0 && jdgvRelated.CurrentRow != null)
                {
                    jdgvRelated.Rows.Remove(jdgvRelated.CurrentRow);
                    _FlagChange = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        /// <summary>
        /// جستجوی گیرنده ها بر اساس انتخاب فرستنده
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cdbSender_Leave(object sender, EventArgs e)
        {
            object tmpCode = cdbReceiver.SelectedValue;
            Filter_Receiver();
            cdbReceiver.SelectedValue = tmpCode;
            //HassanZadeh
            //چک کردن مجوز شخص برای رونوشت ها
            if ((cdbSender.SelectedItem != null) && (UC_LetterCopy1.Sender_Post_Code != Convert.ToInt32(cdbSender.SelectedItem["Code"])))
            {
                if (UC_LetterCopy1.GetData() != null && UC_LetterCopy1.GetData().Rows.Count > 0)
                    if (!(JPermission.CheckPermission("Communication.JCLetterRegister.CheckConfirmExports", 0, Convert.ToInt32(cdbSender.SelectedItem["Code"]), false)))
                    {
                        _dtCopyes = null;
                        UC_LetterCopy1.Clear();
                    }
                UC_LetterCopy1.Sender_Post_Code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
            }
        }
        /// <summary>
        /// جستجوی گیرنده ها بر اساس انتخاب فرستنده
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filter_Receiver()
        {
            //this.UC_LetterCopy1 = new Communication.JUC_Copy(Convert.ToInt32(cdbSender.SelectedItem["Code"]));
            if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                if (cdbSender.SelectedItem != null)
                    UC_LetterCopy1._SetComboBoxs(Convert.ToInt32(cdbSender.SelectedItem["Code"]), ClassLibrary.Domains.JCommunication.JLetterType.Internal);

                if (cdbSender.SelectedItem != null)
                    cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User((int)cdbSender.SelectedItem["Code"], JMainFrame.GetActiveChartCode().ToString(), true);
                else
                    cdbReceiver.dataTable = null;
            }
            cdbReceiver.SetComboBox();
        }

        /// <summary>
        /// کپی از یک مینوت 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(0);
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
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
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
            try
            {
                if (_LetterCode < 1)
                {
                    JMessages.Message("Please Save Contract First", "Error", JMessageType.Error);
                    return;
                }
                /// ارسال به اتوماسیون
                if ((_FlagChange == true) && (btnRegMinute.Enabled = true))
                {
                    if (JMessages.Message("آیا میخواهید نامه ذخیره شود؟", "", JMessageType.Question) == DialogResult.Yes)
                        btnRegMinute_Click(null, null);
                }
                {
                    if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                    {// فقط بر اساس مجوز میتواند به افراد مشخص ارجا بزند
                    }
                    else
                        if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
                        {//به همه میتواند ارجا بزند
                        }

                    //----------HasanZadeh ارسال افراد به 
                    string StrCode = cdbReceiver.SelectedItem["Code"].ToString();
                    //foreach (DataRow dr in _dtCopyes.Rows)                    
                    //    StrCode = StrCode + "," + dr["receiver_post_Code"].ToString();                    
                    JReferMain p;
                    if (_Refer_Code > 0)
                    {
                        //  اگر مینوت امضا شده باشد فقط به فرستنده نامه قابل ارجا می باشد
                        if ((_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept) && (JsecretariatUsers.CheckUser(JMainFrame.CurrentPostCode)))
                        {
                            //Employment.JEOrganizationChart.GetOrgChart_UserSpecfic(JsecretariatUsers.StrCode)                            
                            //JsecretariatUsers.GetData(JCSecretariat.GetDataByUserPCode(JMainFrame.CurrentPostCode));
                            p = new JReferMain(_Refer_Code, JsecretariatUsers.GetAllUserSec(JCSecretariat.GetDataByUserPCode(JMainFrame.CurrentPostCode)), true);
                        }
                        else
                            p = new JReferMain(_Refer_Code, null, true);
                        if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
                            p.Single = true;
                    }
                    else
                    {
                        p = new JReferMain("Communication.JCLetterRegister", _LetterCode,
                    ClassLibrary.Domains.JAutomation.JObjectType.Letters,
                    "Letter", "letter", null, true);//pCurrentReferCode
                        p.Single = true;
                    }

                    if (p.ShowDialog() == DialogResult.OK)
                    {
                        this.Close();
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                //DB.Rollback("Send Letter");
                JBase.Except.AddException(ex);
            }
            finally
            {
                //DB.Dispose();
            }
        }

        private void btnDelMinute_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void JfrmLetterRegisterImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            winWordControl1.CloseControl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (jdgvRelated.Rows.Count>0 && jdgvRelated.SelectedRows != null)
            {
                JfrmLetterRegister tmp = new JfrmLetterRegister(Convert.ToInt32(jdgvRelated.CurrentRow.Cells["Letter_Type"].Value.ToString())
                    , JFormState.ReadOnly, Convert.ToInt32(jdgvRelated.CurrentRow.Cells["Code"].Value.ToString()), _Refer_Code);

                tmp.ShowDialog();
            }
            else
                JMessages.Message("Please Selected Minute ", "", JMessageType.Information);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if ((_FlagChange == true) && (btnRegMinute.Enabled == true))
                if (JMessages.Message("آیا میخواهید نامه ذخیره شود؟", "", JMessageType.Question) == DialogResult.Yes)
                    btnRegMinute_Click(null, null);
            this.Close();
            //this.Dispose(true);
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

        private void juC_ReferHistory_Click(object sender, EventArgs e)
        {
            //juC_ReferHistory.jDataTreeView1_Click(sender, e);
        }

        private void txtAppindix_TextChanged(object sender, EventArgs e)
        {
            _FlagChange = true;
        }

        /// الگوی نامه
        #region PatternLetter

        private void btnPattern_Click(object sender, EventArgs e)
        {
            if (!btnRegMinute.Enabled || !btnRegMinute.Visible)
                return;
            try
            {
                if (CheckData())
                {

                    // if (WorkingMinute(JCWorkLetterType.Save))
                    {
                        if (JMessages.Question("با اعمال الگو، متن جدید جایگزین خواهد شد. آیا میخواهید فایل الگو اعمال شود؟", "") == DialogResult.Yes)
                        {
                            winWordControl1.GetData("Communication.JPatternFile", Convert.ToInt32(cmbPattern.SelectedValue));
                            winWordControl1.LoadDocument();

                            if (_LetterCode != 0)
                            {
                            }
                            else
                            {
                                DataTable table;
                                //JDataBase db = new JDataBase();
                                //DataRow drLetter;
                                //try
                                //{
                                //    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                                //    {
                                //        table = JCLetterRegisterInternals.GetDataTable(-1);
                                //        drLetter = table.NewRow();
                                //        FillDataTableLetter(drLetter);
                                //Employment.JEOrganizationChart tmp = new JEOrganizationChart();
                                //DataTable tmpdt = tmp.InfoLetterInternal(
                                //        Convert.ToInt32(cdbSender.SelectedItem["Code"]), Convert.ToInt32(cdbSender.SelectedItem["pcode"]),
                                //        Convert.ToInt32(cdbReceiver.SelectedItem["Code"]), Convert.ToInt32(cdbReceiver.SelectedItem["code"]));

                                //        drLetter["Sender_Name"] = tmpdt.Rows[0]["Sender_Name"];
                                //        drLetter["Sender_Post_Name"] = tmpdt.Rows[0]["Sender_Post_Name"];
                                //        drLetter["Sender_Title_Job"] = tmpdt.Rows[0]["Sender_Title_Job"];
                                //        drLetter["Receiver_Name"] = tmpdt.Rows[0]["Receiver_Name"];
                                //        drLetter["Receiver_Post_Name"] = tmpdt.Rows[0]["Receiver_Post_Name"];
                                //        drLetter["Receiver_Title_Job"] = tmpdt.Rows[0]["Receiver_Title_Job"];
                                //        table.Rows.Add(drLetter);
                                //    }

                                //    else if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                                //    {
                                //        table = JCLetterRegisterExports.GetDataTable(0);
                                //        drLetter = table.NewRow();
                                //        FillDataTableLetter(drLetter);
                                //        Employment.JEOrganizationChart tmp = new JEOrganizationChart();
                                //        DataTable tmpdt = tmp.InfoLetterExport(
                                //        Convert.ToInt32(cdbSender.SelectedItem["Code"]), Convert.ToInt32(cdbSender.SelectedItem["pcode"]),
                                //        Convert.ToInt32(cdbReceiver.SelectedItem["Code"]), Convert.ToInt32(cdbReceiver.SelectedItem["code"]));

                                //        drLetter["Sender_Name"] = tmpdt.Rows[0]["Sender_Name"];
                                //        drLetter["Sender_Post_Name"] = tmpdt.Rows[0]["Sender_Post_Name"];
                                //        drLetter["Sender_Title_Job"] = tmpdt.Rows[0]["Sender_Title_Job"];
                                //        drLetter["Receiver_Name"] = tmpdt.Rows[0]["Receiver_Name"];
                                //        drLetter["Receiver_External_Name"] = tmpdt.Rows[0]["Receiver_External_Name"];
                                //        table.Rows.Add(drLetter);
                                //    }
                                //    else if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                                //    {
                                //        table = JCLetterRegisterImports.GetDataTable(0);
                                //        drLetter = table.NewRow();
                                //        FillDataTableLetter(drLetter);
                                //        Employment.JEOrganizationChart tmp = new JEOrganizationChart();
                                //        DataTable tmpdt = tmp.InfoLetterImport(
                                //            Convert.ToInt32(cdbSender.SelectedItem["Code"]), Convert.ToInt32(cdbSender.SelectedItem["pcode"]),
                                //            Convert.ToInt32(cdbReceiver.SelectedItem["Code"]), Convert.ToInt32(cdbReceiver.SelectedItem["code"]));

                                //        drLetter["Sender_Name"] = tmpdt.Rows[0]["Sender_Name"];
                                //        drLetter["sender_external_code"] = tmpdt.Rows[0]["Sender_Title_Job"];
                                //        drLetter["Receiver_Name"] = tmpdt.Rows[0]["Receiver_Name"];
                                //        drLetter["Receiver_Post_Name"] = tmpdt.Rows[0]["Receiver_Post_Name"];
                                //        drLetter["Receiver_Title_Job"] = tmpdt.Rows[0]["Receiver_External_Name"];
                                //        table.Rows.Add(drLetter);
                                //    }
                                //    else
                                //        table = null;
                                //    winWordControl1.Reaplce(table);
                                //}
                                //finally
                                //{
                                //    db.Dispose();
                                //}

                            }
                        }
                    }
                }
                btnRegMinute.Enabled = true;
            }
            catch
            {
            }
        }

        /// <summary>
        /// الگوی نامه
        /// داده ها ی مشترک برای انواع نامه ها
        /// 
        /// </summary>
        /// <param name="LRI"></param>
        private void FillDataTableLetter(DataRow drLetter)
        {
            try
            {
                //drLetter["Current_Refer_Code"] = _Refer_Code;
                drLetter["Code"] = 0;
                drLetter["letter_status"] = "پیشنویس";
                //drLetter["register_no"] = "";
                drLetter["letter_no"] = "";
                //drLetter["register_user_code"] = "";
                //drLetter["register_user_full_title"] = "";
                //drLetter["register_date_time"] = "";
                drLetter["secretariatName"] = "";
                drLetter["letter_no"] = "";


                //------------------- گیرنده ------------------------------------------
                if (cdbReceiver.SelectedItem != null)
                {

                    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import
                        || _LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    {
                        drLetter["receiver_post_code"] = Convert.ToInt32(cdbReceiver.SelectedItem["Code"]);
                        drLetter["receiver_code"] = (int)cdbReceiver.SelectedItem["pcode"];
                    }

                    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    {
                        drLetter["receiver_external_code"] = Convert.ToInt32(cdbReceiver.SelectedItem["Code"]);
                        drLetter["receiver_code"] = (int)cdbReceiver.SelectedItem["code"];
                    }
                    drLetter["receiver_full_title"] = cdbReceiver.SelectedItem["full_title"].ToString();
                }
                else
                {
                    drLetter["receiver_post_code"] = 0;
                    drLetter["receiver_external_code"] = 0;
                    drLetter["receiver_code"] = 0;
                    drLetter["receiver_full_title"] = "";
                }
                //------------------- فرستنده ------------------------------------------
                if (cdbSender.SelectedItem != null)
                {
                    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export
                        || _LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    {
                        drLetter["sender_post_code"] = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                        drLetter["sender_code"] = (int)cdbSender.SelectedItem["pcode"];
                    }

                    if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                    {
                        drLetter["sender_external_code"] = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                        drLetter["sender_code"] = (int)cdbSender.SelectedItem["code"];
                    }

                    drLetter["sender_full_title"] = cdbSender.SelectedItem["full_title"].ToString();
                }
                else
                {
                    drLetter["sender_external_code"] = 0;
                    drLetter["sender_full_title"] = "";
                    drLetter["sender_code"] = 0;
                    drLetter["sender_post_code"] = 0;
                }

                //------------------- موضوع ------------------------------------------
                if (cdbSubject.SelectedItem != null)
                {
                    drLetter["subject_code"] = Convert.ToInt32(cdbSubject.SelectedItem["Code"]);
                    drLetter["LetterSubject"] = cdbSubject.Text;
                }
                else
                {
                    drLetter["subject_code"] = 0;
                    drLetter["LetterSubject"] = "";
                }
                //------------------ پیش نویس موضوع -----------------------------------
                drLetter["pre_subject"] = txtSubjectMinute.Text.Trim();
                //------------------ پیوست --------------------------------------------
                drLetter["appendix"] = txtAppindix.Text.Trim();
                //------------------ خلاصه ---------------------------------------------
                drLetter["summary"] = txtSummery.Text.Trim();
                //------------------ شماره نامه وارده ----------------------------------
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                {
                    drLetter["incoming_no"] = txtLetterImportLetterNo.Text.Trim();
                    //------------------ تاریخ نامه وارده ---------------------------------
                    if (dteLetterImportDate.Date != DateTime.MinValue)
                        drLetter["incoming_date"] = dteLetterImportDate.Date;
                    //------------------ امضا کننده نامه وارده ----------------------------
                    drLetter["incoming_signature_person"] = txtSignatured.Text.Trim();
                }
                //------------------ نحوه دریافت ---------------------------------------
                if (cmbReceiveType.SelectedValue != null && cmbReceiveType.SelectedIndex > 0)
                {
                    drLetter["receiver_type"] = Convert.ToInt32(cmbReceiveType.SelectedValue);
                    drLetter["receiver_type_Name"] = cmbReceiveType.Text;
                }
                else
                {
                    drLetter["receiver_type"] = 0;
                    drLetter["receiver_type_Name"] = "";
                }
                //------------------ نحوه دریافت ---------------------------------------
                if (cmbSendType.SelectedValue != null && cmbSendType.SelectedIndex > 0)
                {
                    drLetter["send_type"] = Convert.ToInt32(cmbSendType.SelectedValue);
                    drLetter["send_type_Name"] = cmbSendType.Text;
                }
                else
                {
                    drLetter["send_type"] = 0;
                    drLetter["send_type_Name"] = "";
                }
                //------------------ فوریت --------------------------------------------
                if (cmbUrgency.SelectedValue != null)
                    drLetter["urgency"] = cmbUrgency.Text;
                else
                    drLetter["urgency"] = "";
                //------------------ سطح محرمانگی --------------------------------------
                if (cmbSecurityLevel.SelectedValue != null)
                    drLetter["secret_level"] = cmbSecurityLevel.Text;
                else
                    drLetter["secret_level"] = "";
                //----------------- وضعیت نامه ----------------------------------------
                drLetter["letter_type"] = _LetterType;
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("Back Letter");
                if (_Refer_Code > 0 && _LetterCode > 0)
                {

                    JCLetterRegister LRI = new JCLetterRegister(_LetterCode);
                    if (LRI.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
                    {
                        DataTable secretariats = JCSecretariat.GetScretariatUserCodes(JMainFrame.CurrentPostCode, db);
                        if (secretariats.Rows.Count > 0 &&
                            JCLetterRegister.CheckSecretariat(false, secretariats))
                        {
                            JTextInputDialogForm Tdialog = new JTextInputDialogForm("Refer", "Back...");
                            Tdialog.ShowDialog();
                            if (Tdialog.DialogResult == DialogResult.OK)
                            {
                                JARefer _temprefer = new JARefer(_Refer_Code);
                                JARefer refer = new JARefer();
                                refer.receiver_code = LRI.sender_code;
                                refer.receiver_full_title = LRI.sender_full_title;
                                refer.receiver_post_code = LRI.sender_post_code;

                                refer.description = Tdialog.Text;

                                refer.sender_code = JMainFrame.CurrentUserCode;
                                refer.sender_full_title = JMainFrame.CurrentPostTitle;
                                refer.sender_post_code = JMainFrame.CurrentPostCode;

                                refer.object_code = _temprefer.object_code;
                                refer.ReferLevel = _temprefer.ReferLevel + 1;
                                refer.parent_code = _temprefer.Code;
                                refer.ReferGroup = _temprefer.ReferGroup;

                                refer.refertype = ClassLibrary.Domains.JAutomation.JReferType.Internal;
                                refer.send_date_time = (new JDataBase().GetCurrentDateTime());
                                refer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
                                refer.is_active = true;

                                if (LRI.UpdateManual(_LetterCode, ClassLibrary.Domains.JCommunication.JLetterStatus.Minute, db))
                                {
                                    db.Commit();
                                    db.beginTransaction("Back Letter");
                                    if (refer.Send(db) > 0)
                                    {
                                        db.Commit();
                                        this.Close();
                                        return;
                                    }
                                    else
                                    {
                                        db.Rollback("Back Letter");
                                    }
                                }
                                else
                                {
                                    db.Rollback("Back Letter");
                                }
                            }

                        }
                    }
                }
                db.Rollback("Back Letter");
            }
            catch
            {
                db.Rollback("Back Letter");
            }
            finally
            {
                db.Dispose();
            }
        }

        private void chkResponse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkResponse.Checked)
                txtPersuit.Enabled = true;
            else
                txtPersuit.Enabled = false;
        }

        private void txtPersuit_TextChanged(object sender, EventArgs e)
        {
            _FlagChange = true;
        }

        private void dbcntLetterRegister_DrawItem(object sender, DrawItemEventArgs e)
        {
            ChangeTabColor(e);
        }

        private void ChangeTabColor(DrawItemEventArgs e)
        {
            try
            {
                Font f;

                Brush backBrush;

                Brush foreBrush;

                if (e.Index == this.dbcntLetterRegister.SelectedIndex)
                {

                    f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    f = new Font(e.Font, FontStyle.Bold);
                    backBrush = new System.Drawing.SolidBrush(Color.DarkGray);
                    foreBrush = Brushes.White;
                }
                else
                {
                    f = e.Font;
                    backBrush = new SolidBrush(e.BackColor);
                    foreBrush = new SolidBrush(e.ForeColor);
                }

                string tabName = this.dbcntLetterRegister.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

            }
            catch
            {
            }
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            tbpAttachments.Show();
        }

        private void JfrmLetterRegister_Shown(object sender, EventArgs e)
        {
            cdbSender.Focus();
        }
        ////پاسخ به نامه
        #region Dependent
        
        /// <summary>
        /// سازنده
        /// </summary>
        public JfrmLetterRegister(int pLetterCode, int pLetterType)
        {
            InitializeComponent();
            if (DesignMode) return;

            _LetterType = pLetterType;            
            _LetterCode = 0;            
            State = JFormState.Insert;
            _Refer_Code = 0;
            //if (pCurrentReferCode > 0)
            //    refersText1.LoadRefer(pCurrentReferCode);

            InitController();
            VisibleControls(pLetterType);
            _SetCmb();
            _SetState();
            //if (pLetterCode > 0)
            //   SetForm(pLetterCode);

            if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                this.Text = "نامه صادره از سازمان به خارج از سازمان";
            if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                this.Text = "نامه داخلی در سازمان";
            if (pLetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                this.Text = "نامه وارده به سازمان از خارج از سازمان";
            Dependent(pLetterCode);
        }

        private void Dependent(int pLetterCode)
        {
            JCLetterRegisterImport LRI = new JCLetterRegisterImport(pLetterCode);
            //------------------عطف ---------------
            AddRelatedLetter(pLetterCode, ClassLibrary.Domains.JAutomation.JRelatedType.Reply);
            //------------------ پر کردن اطلاعات فرستنده گیرنده بر اساس نوع نامه -----------------------------------------
            if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                if ((new JAllPerson(LRI.receiver_external_code)).Code != 0)
                {
                    JAllPerson OrganTemp = new JAllPerson(LRI.receiver_external_code);
                   cdbSender.SetValue(OrganTemp.Code);
                }
                cdbReceiver.SetValue((new Employment.JEOrganizationChart(LRI.sender_post_code)).AccessCode);
            }
            //----------------------------------
            if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                cdbReceiver.SetValue((new Employment.JEOrganizationChart(LRI.sender_post_code)).AccessCode);
                cdbSender.SetValue((new Employment.JEOrganizationChart(LRI.receiver_post_code)).AccessCode);
            }
            //----------------------------------
            if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
            {
                if ((new JAllPerson(LRI.sender_external_code)).Code != 0)
                {
                    JAllPerson OrganTemp = new JAllPerson(LRI.sender_external_code);
                   cdbReceiver.SetValue(OrganTemp.Code);
                }
                cdbSender.SetValue((new Employment.JEOrganizationChart(LRI.receiver_post_code)).AccessCode);
            }
            //------------------------------------------------------------------------------------------------------------
        }

        private void btnDependent_Click(object sender, EventArgs e)
        {
            if (_LetterCode > 0)
            {
                if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    _LetterType = ClassLibrary.Domains.JCommunication.JLetterType.Import;
                else if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    _LetterType = ClassLibrary.Domains.JCommunication.JLetterType.Internal;
                else if (_LetterType == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                    _LetterType = ClassLibrary.Domains.JCommunication.JLetterType.Export;

                JfrmLetterRegister tmpfrm = new JfrmLetterRegister(_LetterCode, _LetterType);
                tmpfrm.ShowDialog();
            }
        }
        #endregion

    }

}
