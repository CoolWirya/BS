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

namespace Communication
{
    /// <summary>
    ///کلاس فرم ثبت نامه وارده
    /// </summary>
    public partial class JfrmLetterRegisterExport : Globals.JBaseForm
    {
        /// <summary>
        /// فیلد ها
        /// </summary>
        #region Feilds

        public int _LetterCode;
        DataTable _dtRelatedLetter = new DataTable();
        /// <summary>
        /// وارده / صادره / درون سازمانی
        /// </summary>
        int _StatusForm;
        /// <summary>
        /// وضعیت نامه
        /// </summary>
        int _letter_status;
        string _Letter_No="";
        int _Refer_Code = 0;
        JCWorkLetterType WorkLetterType = JCWorkLetterType.Save;
        DataTable _dtAttachment = new DataTable();
        DataTable _dtCopyes = new DataTable();

        #endregion Feilds

        /// <summary>
        /// سازنده
        /// </summary>
        public JfrmLetterRegisterExport(int pStatusForm, JFormState pState, int LetterCode, int pCurrentReferCode)
        {
            InitializeComponent();

            /// مقداردهی پراپرتی های لیست آرشیو
            //jArchiveExe.ClassName = "Communication.JfrmLetterRegisterImport";
            //jArchiveExe.SubjectCode = 0;
            //jArchiveExe.PlaceCode = 0;
            //jArchiveExe.ObjectCode = LetterCode; 

            winWordControl1.LoadDocument("Legal.JContractdefine");


            if (DesignMode) return;
            UC_LetterCopy1.Initialize();
            _StatusForm = pStatusForm;
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
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                label2.Text = "Letter Internal Information";
                txtSender.Enabled = false;
                this.Text = "form Letter Register Internal";
            }
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                label2.Text = "Letter Export Information";
                label17.Text = "Receiver legal:";
                this.label17.ForeColor = System.Drawing.Color.Maroon;
                this.Text = "form Letter Register Export";
                label8.Text = "Receiver actual:";

                ////this.cdbReceiver.Location = new System.Drawing.Point(49, 42);
                ////this.txtSender.Location = new System.Drawing.Point(86, 75);
                ////this.btnReceiver.Location = new System.Drawing.Point(22, 42);
                //this.label17.Location = new System.Drawing.Point(715, 45);
                //this.label8.Location = new System.Drawing.Point(733, 80); 
            }
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
            {
                label5.Text = "Sender legal:";
                label17.Text = "Sender actual:";
                //this.label17.Location = new System.Drawing.Point(723, 45);
                //this.label5.Location = new System.Drawing.Point(738, 16); 
            }

        }
        //########################################################################################

        #region Functions

        /// <summary>
        /// تنظیم لیست های روی فرم
        /// </summary>
        private void _SetCmb()
        {
            try
            {                
                //  ---------------------- Set ComboBox Sender --------------------------
                cdbSender.TitleFieldName = "full_title";
                cdbSender.AccessCodeFieldName = "accesscode";                
                cdbSender.CodeFieldName = "code";
                //  ---------------------- Set ComboBox Receiver --------------------------
                cdbReceiver.TitleFieldName = "full_title";
                cdbReceiver.AccessCodeFieldName = "accesscode";
                cdbReceiver.CodeFieldName = "code";
                //cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0,JMainFrame.GetActiveChartCode());

                if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                {                    
                    cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
                    cdbSender.SetComboBox();
                    cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, JMainFrame.GetActiveChartCode());
                    cdbReceiver.SetComboBox();

                }
                else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                {
                    cdbSender.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, JMainFrame.GetActiveChartCode());
                    cdbSender.SetComboBox();
                    cdbReceiver.dataTable = (new JOrganizations()).GetOrganization(0);
                    cdbReceiver.SetComboBox();
                }
                else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                {
                    cdbSender.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, JMainFrame.GetActiveChartCode());
                    cdbSender.SetComboBox();
                    cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(JMainFrame.CurrentPostCode, "0");
                    cdbReceiver.SetComboBox();
                }
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
            _StatusForm = LRI.letter_type;
            _SetCmb();
            //------------------رونوشت ---------------
            winWordControl1.GetData("Communication.JfrmLetterRegisterImport", pLetterCode);
            winWordControl1.LoadDocument();
            //------------------رونوشت ---------------
            UC_LetterCopy1.SetData(pLetterCode);            
            //UC_LetterCopy.SetData(pLetterCode);
            //------------------ضمائم ---------------
            UC_AttachmentManager.SetDataLast(pLetterCode);            
            //UC_AttachmentManager.SetData(pLetterCode);
            /// مقداردهی پراپرتی های لیست آرشیو
            //jArchiveExe.ClassName = "Communication.JfrmLetterRegisterImport";
            //jArchiveExe.SubjectCode = 0;
            //jArchiveExe.PlaceCode = 0;
            //jArchiveExe.ObjectCode = pLetterCode; 
            //------------------عطف ---------------
            _dtRelatedLetter.Clear();
            JCRelatedLetter tmpJCRelatedLetter=new JCRelatedLetter();
            foreach (DataRow dr in tmpJCRelatedLetter.GetDate(pLetterCode).Rows)
                AddRelatedLetter(Convert.ToInt32(dr["dependent_lettercode"].ToString()));
            uC_GridLetter.Bind(_dtRelatedLetter, "RelatedLetter");
           // _dtRelatedLetter = tmpJCRelatedLetter.GetDate(pLetterCode);

            //------------------ پر کردن اطلاعات فرستنده گیرنده بر اساس نوع نامه ---------------
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
            {
                if ((new JOrganization(LRI.sender_external_code)).Access_Code != 0)
                    cdbSender.SetValue((new JOrganization(LRI.sender_external_code)).Access_Code);
                else
                    txtSender.Text = LRI.sender_full_title;
                cdbReceiver.SetValue((new Employment.JEOrganizationChart(LRI.receiver_post_code)).AccessCode);
            }
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                if ((new JOrganization(LRI.receiver_external_code)).Access_Code != 0)
                    cdbReceiver.SetValue((new JOrganization(LRI.receiver_external_code)).Access_Code);
                else
                    txtSender.Text = LRI.receiver_full_title;
                cdbSender.SetValue((new Employment.JEOrganizationChart(LRI.sender_post_code)).AccessCode);
            }
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                cdbSender.SetValue((new Employment.JEOrganizationChart(LRI.sender_post_code)).AccessCode);
                Filter_Receiver();
                cdbReceiver.SetValue((new Employment.JEOrganizationChart(LRI.receiver_post_code)).AccessCode);   
            }

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
            _StatusForm = LRI.letter_type;            
            _Letter_No = LRI.letter_no;
            _letter_status = LRI.letter_status;
        }

        #endregion Functions
        /// <summary>
        /// تعیین وضعیت دکمه ها در روی فرم
        /// </summary>
        private void ButtomState()
        {
            Automation.JAObject obj = new Automation.JAObject();
            //آیا نامه یا پیشنویس به اتوماسیون ارسال شده است؟
            if ((_LetterCode > 0) && obj.FindObjectByExternalcode(ClassLibrary.Domains.JAutomation.JObjectType.Letters, _LetterCode))
                btnRefer.Visible = false;

            if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
            {
                //btnArchive.Visible = false;
                btnConfirmMinute.Visible = false;
                btnConSec.Visible = true;
                btnRegMinute.Visible = false;
                this.btnConSec.UseVisualStyleBackColor = true;
                this.btnConfirmMinute.BackColor = System.Drawing.Color.ForestGreen;
                this.btnRegMinute.BackColor = System.Drawing.Color.ForestGreen;
            }
            else if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
            {
                //btnArchive.Visible = false;
                btnConfirmMinute.Visible = false;
                btnConSec.Visible = false;
                btnRegMinute.Visible = false;
                this.btnConSec.BackColor = System.Drawing.Color.ForestGreen;
                this.btnConfirmMinute.BackColor = System.Drawing.Color.ForestGreen;
                this.btnRegMinute.BackColor = System.Drawing.Color.ForestGreen;
            }
            else if ((_Letter_No != "")&&(_Letter_No != null))
            {
                btnRegMinute.Visible = false;
                btnConfirmMinute.Visible = false;
                this.btnRegMinute.BackColor = System.Drawing.Color.ForestGreen;
                this.btnConfirmMinute.BackColor = System.Drawing.Color.ForestGreen;
            }
            else if (_LetterCode > 0)
            {
                btnConfirmMinute.Visible = true;
                this.btnRegMinute.BackColor = System.Drawing.Color.ForestGreen;
            }
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                if (JCLetterRegisterInternal.CheckConfirm(false))
                    btnConfirmMinute.Visible = true;
                else
                    btnConfirmMinute.Visible = false;
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    if (JCLetterRegisterExport.CheckConfirm(false))
                        btnConfirmMinute.Visible = true;
                    else
                        btnConfirmMinute.Visible = false;
            if (JCLetterRegister.CheckSecretariat(false) && (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept))
                btnConSec.Visible = true;
            else
                btnConSec.Visible = false;
        }
        //########################################################################################
        private void JfrmLetterRegisterImport_Load(object sender, EventArgs e)
        {
            // ----------------------------  بررسی وجود چارت سازمانی فعال -------------------------
                if ((new JECharts()).GetActiveChartCode() == 0)
                {
                    JMessages.Message(JLanguages._Text("Active chart not set,  Please First Set chart"), JLanguages._Text("Error"), JMessageType.Error);
                    this.Close();
                }
            _SetCmb();
            // ----------------------------  بررسی وضعیت فرم -------------------------
            if ((_LetterCode != 0))// && (_Refer_Code != 0))
            {
                SetForm(_LetterCode);

            }
            else
                winWordControl1.LoadDocument();
            //تعیین وضعیت دکمه ها در روی فرم
            ButtomState();
            if ((_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)|| (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal))
            {
                groupBox1.Visible = false;
                groupBox2.Location = new System.Drawing.Point(421, 1);
                //txtLetterImportLetterNo.Visible = false;
                //dteLetterImportDate.Visible = false;
            }
            //if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
            //    dbcntLetterRegister.TabPages.Remove(dbcntLetterRegister.TabPages["tbpCopy"]);
        }

        private void btnSelOrganization_Click(object sender, EventArgs e)
        {
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
            {
                JfrmOrganizatins jorg = new JfrmOrganizatins();
                if (jorg.ShowDialog() == DialogResult.OK)
                {
                    //  ---------------------- Set ComboBox Sender --------------------------
                    cdbSender.AccessCodeFieldName = "access_code";
                    cdbSender.TitleFieldName = "full_title";
                    cdbSender.CodeFieldName = "code";
                    cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
                    cdbSender.SetComboBox();

                    if (jorg.SelectedRow != null)
                        cdbSender.SetValue(jorg.SelectedRow.Cells["access_code"]);
                }
                jorg.Dispose();
            }
            else if ((_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export) || (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal))
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
        }

        private void btnReceiver_Click(object sender, EventArgs e)
        {
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
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
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                JfrmOrganizatins jorg = new JfrmOrganizatins();
            if (jorg.ShowDialog() == DialogResult.OK)
            {
                //  ---------------------- Set ComboBox Sender --------------------------
                cdbSender.AccessCodeFieldName = "access_code";
                cdbSender.TitleFieldName = "full_title";
                cdbSender.CodeFieldName = "code";
                cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
                cdbSender.SetComboBox();
                
                if(jorg.SelectedRow != null)
                    cdbSender.SetValue(jorg.SelectedRow.Cells["access_code"]);
            }
            jorg.Dispose();
            }
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                
            }
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
            JCOfficeWord jOW = new JCOfficeWord();
            jOW.New();
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
                _LetterCode = LRI.Insert(_dtCopyes, _dtAttachment, _dtRelatedLetter);
                if (_LetterCode > 0)
                {
                    //JMessages.Message("Minute Register successfully", "", JMessageType.Information);
                    this.Dispose();
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
                if (LRI.Update(_LetterCode, _dtCopyes, _dtAttachment, _dtRelatedLetter, pAction))
                {
                    if (pAction == JCWorkLetterType.Save)
                        //JMessages.Message("Minute Update successfully", "", JMessageType.Information);
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
        ///عملیات مربوط به مینوت صادره 
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private bool WorkingMinuteExport(JCWorkLetterType pAction)
        {
            JCLetterRegisterExport LRI = new JCLetterRegisterExport(_LetterCode);
            Data(LRI);
            if (State == JFormState.Insert)
            {
                _LetterCode = LRI.Insert(_dtCopyes, _dtAttachment, _dtRelatedLetter);
                if (_LetterCode > 0)
                {
                    //JMessages.Message("Minute Register successfully", "", JMessageType.Information);
                    this.Dispose();
                    return true;
                }
                else
                {
                    //JMessages.Message("Error", "", JMessageType.Information);
                    return false;
                }
            }
            else if (State == JFormState.Update)
            {
                LRI.Code = _LetterCode;
                if (LRI.Update(_LetterCode, _dtCopyes, _dtAttachment, _dtRelatedLetter, pAction))
                {
                    if (pAction == JCWorkLetterType.Save)
                        //JMessages.Message("Minute Update successfully", "", JMessageType.Information);
                    return true;
                }
                else
                {
                    //JMessages.Message("Unable Letter Change", "", JMessageType.Information);
                    return false; ;
                }
            }
            return true;
        }
        /// <summary>
        ///عملیات مربوط به مینوت داخلی 
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private bool WorkingMinuteInternal(JCWorkLetterType pAction)
        {
            JCLetterRegisterInternal LRI = new JCLetterRegisterInternal(_LetterCode);
            Data(LRI);
            if (State == JFormState.Insert)
            {
                _LetterCode = LRI.Insert(_dtCopyes, _dtAttachment, _dtRelatedLetter);
                if (_LetterCode > 0)
                {
                    SaveFile();
                    //JMessages.Message("Minute Register successfully", "", JMessageType.Information);                    
                    //this.Dispose();
                    return true;
                }
                else
                {
                    //JMessages.Message("Error", "", JMessageType.Information);
                    return false;
                }
            }
            else if (State == JFormState.Update)
            {
                LRI.Code = _LetterCode;
                if (LRI.Update(_LetterCode, _dtCopyes, _dtAttachment, _dtRelatedLetter, pAction))
                {
                    SaveFile();
                    if (pAction == JCWorkLetterType.Save)
                        //JMessages.Message("Minute Update successfully", "", JMessageType.Information);
                    return true;
                }
                else
                {
                    //JMessages.Message("Unable Letter Change", "", JMessageType.Information);
                    return false; ;
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
                JMessages.Error("فرستنده/گیرنده را انتخاب کنید", "error");
                return false;
            }
            if (cdbSender.SelectedItem == null)
            {
                JMessages.Error("گیرنده/فرستنده را انتخاب کنید", "error");
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
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                //------------------- گیرنده ------------------------------------------
                if (cdbReceiver.SelectedItem != null)
                {
                    LRI.receiver_post_code = Convert.ToInt32(cdbReceiver.SelectedItem["Code"]);
                    LRI.receiver_full_title = cdbSender.SelectedItem["full_title"].ToString();
                }
                //------------------- فرستنده ------------------------------------------
                if (cdbSender.SelectedItem != null)
                {
                    LRI.sender_post_code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                    LRI.sender_full_title = cdbSender.SelectedItem["full_title"].ToString();
                    LRI.sender_code = Convert.ToInt32(cdbSender.SelectedItem["User_Code"]);
                }
            }
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                //------------------- گیرنده ------------------------------------------
                if (cdbReceiver.SelectedItem != null)
                {
                    LRI.receiver_external_code = Convert.ToInt32(cdbReceiver.SelectedItem["Code"]);
                    LRI.receiver_full_title = cdbReceiver.SelectedItem["full_title"].ToString();
                }
                else
                    LRI.receiver_full_title = txtSender.Text;
                //------------------- فرستنده ------------------------------------------
                if (cdbSender.SelectedItem != null)
                {
                    LRI.sender_post_code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                    LRI.sender_full_title = cdbSender.SelectedItem["full_title"].ToString();
                }
            }
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
            {
                //------------------- گیرنده ------------------------------------------
                if (cdbReceiver.SelectedItem != null)
                    LRI.receiver_post_code = Convert.ToInt32(cdbReceiver.SelectedItem["Code"]);
                //------------------- فرستنده ------------------------------------------
                if (cdbSender.SelectedItem != null)
                {
                    LRI.sender_external_code = Convert.ToInt32(cdbSender.SelectedItem["Code"]);
                    LRI.sender_full_title = cdbSender.SelectedItem["full_title"].ToString();
                }
                else
                    LRI.sender_full_title = txtSender.Text;
            }

            //------------------- موضوع ------------------------------------------
            if (cdbSubject.SelectedItem != null)
                LRI.subject_code = Convert.ToInt32(cdbSubject.SelectedItem["Code"]);
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
                LRI.incoming_date = Convert.ToDateTime(dteLetterImportDate.Text);
            //------------------ امضا کننده نامه وارده ----------------------------
            LRI.incoming_signature_person = txtSignatured.Text.Trim();
            //------------------ نحوه دریافت ---------------------------------------
            if (cmbReceiveType.SelectedValue != null && cmbReceiveType.SelectedIndex > 0)
                LRI.receiver_type = Convert.ToInt32(cmbReceiveType.SelectedValue);
            //------------------ فوریت --------------------------------------------
            if (cmbUrgency.SelectedValue != null)
                LRI.urgency = Convert.ToInt32(cmbUrgency.SelectedValue);
            //------------------ سطح محرمانگی --------------------------------------
            if (cmbSecurityLevel.SelectedValue != null)
                LRI.secret_level = Convert.ToInt32(cmbSecurityLevel.SelectedValue);
            //----------------- وضعیت نامه ----------------------------------------
            LRI.letter_type = _StatusForm;
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
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                return WorkingMinuteInternal(pAction);
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                return WorkingMinuteExport(pAction);
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                return WorkingMinuteImport(pAction);
            return false;
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
                    if (State == JFormState.Insert)
                        JMessages.Message("Minute Register successfully", "", JMessageType.Information);
                    if (State == JFormState.Update)
                        JMessages.Message("Minute Update successfully", "", JMessageType.Information);
                    //else
                    //JMessages.Message("Unable Letter Change", "", JMessageType.Information);
                }
                else
                    JMessages.Message("Error", "", JMessageType.Information);
            }
            this.Close();
        }
        /// <summary>
        /// ذخیره فایل Word
        /// </summary>
        /// <returns></returns>
        public bool SaveFile()//ClassLibrary.JDataBase tempdb
        {
            try
            {
                JDataBase tempdb = JGlobal.MainFrame.GetDBO();
                bool ret =  winWordControl1.SaveInOfficeWord(tempdb,"Communication.JfrmLetterRegisterImport", _LetterCode, true);
                if (ret)
                {
                    //if (winWordControl1.FileCode > 0)
                    //{
                    //    ContractForms.Contract.FileCode = winWordControl1.FileCode;
                    //}
                }
                return ret;
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
            //چک کردن مجوز کاربر برای امضا نامه داخلی یا صادره
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                if(!JCLetterRegisterInternal.CheckConfirm(true)) return;
            else if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                if(!JCLetterRegisterExport.CheckConfirm(true)) return;
            //اگر مینوت ثبت نشده بود ثبت شود و بعد تایید شود
            bool flag = true;
            if (_LetterCode == 0)
                if (CheckData())
                    if (!WorkingMinute(JCWorkLetterType.Save))
                        flag = false; ;
            if (flag)
            {
                State = JFormState.Update;
                if (WorkingMinute(JCWorkLetterType.UpdateAndSecretariat))// امضا نامه و ارسال به دبیرخانه
                {
                    JMessages.Message("Send Successfuly to Secretariat", "", JMessageType.Information);
                    Close();
                }
                else
                    JMessages.Message("فرستنده نامه با کاربر جاری یکسان نیست", "", JMessageType.Information);
            }
        }

        /// <summary>
        /// ثبت دبیرخانه
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConSec_Click(object sender, EventArgs e)
        {
            State = JFormState.Update;
            if (WorkingMinute(JCWorkLetterType.UpdateAndRegister))//ویرایش و ثبت و دریافت شماره و ارسال به گیرنگان            
            {
                //JMessages.Message("Send Successfuly to Secretariat", "", JMessageType.Information);
                JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(_LetterCode);
                if (tmpJCLetterRegister.SendAttachmentToArchive())
                    JMessages.Message("Archive Successfuly ", "", JMessageType.Information);
                else
                    JMessages.Message("Archive Not Successfuly ", "", JMessageType.Error);
            }

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

            this.Dispose();
        }

        /// <summary>
        /// نمایش تاریخچه ضمائم مینوت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (State != JFormState.Insert)
            {
                if (btnHistory.Text == "+")
                {
                    UC_AttachmentManager.SetData(_LetterCode);
                    btnHistory.Text = "-";
                }
                else
                {
                    UC_AttachmentManager.SetDataLast(_LetterCode);
                    btnHistory.Text = "+";
                }
            }
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
                JfrmLetterRegisterImport tmp = new JfrmLetterRegisterImport(_StatusForm, JFormState.ReadOnly,0,_Refer_Code);
                tmp.SetForm(tmpJfrmSearchLetters._Code);
                tmp.ShowDialog();
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
            if (uC_GridLetter.SelectedRow != null)
            {
                JfrmLetterRegisterImport tmp = new JfrmLetterRegisterImport(_StatusForm, JFormState.Update, 0, _Refer_Code);
                tmp.SetForm(Convert.ToInt32(uC_GridLetter.SelectedRow.Cells["Code"].Value.ToString()));
                tmp.ShowDialog();
            }
            else
                JMessages.Message("Please Selected Minute ", "", JMessageType.Information);
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
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                if ((cdbSender.SelectedItem != null) && (Convert.ToInt32(cdbSender.SelectedItem["Code"].ToString()) != -1))
                {
                    cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(Convert.ToInt32(cdbSender.SelectedItem["Code"]), "0");
                    cdbReceiver.SetComboBox();
                }
            }

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
            if (_LetterCode != 0)
            {
                    JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(_LetterCode);
                    if (tmpJCLetterRegister.ArshiveLetter(_LetterCode))
                      JMessages.Message("Arshive Letter Successfuly", "", JMessageType.Information);
                    else
                      JMessages.Message("Arshive Letter Not Successfuly", "", JMessageType.Information);
            }
            else
                JMessages.Message("Please Selected Minute", "", JMessageType.Information);
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (_LetterCode == 0)
                if (CheckData())
                    if (!WorkingMinute(JCWorkLetterType.Save))
                        flag = false; ;
            if (flag)
            {
                State = JFormState.Update;
                if (WorkingMinute(JCWorkLetterType.Save))
                {
                    JCLetterRegister tmp = new JCLetterRegister(_LetterCode);
                    int id = tmp.FirstSend();
                    if (id > 0)
                    {
                        JReferMain p = new JReferMain(_Refer_Code, id);
                        if (p.ShowDialog() == DialogResult.OK)
                            JMessages.Message("Refer Successfully", "", JMessageType.Information);
                        Close();
                    }
                    else
                        JMessages.Message("Error", "", JMessageType.Error);
                }
            }
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
            winWordControl1.CloseControl();
        }      
    }
}
