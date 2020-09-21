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

namespace Communication.Letters.LetterRegister.LetterRegisterInternal
{
    public partial class JLetterExportForm : JLetterRegisterBaseForm
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
        string _Letter_No = "";
        int _Refer_Code = 0;
        JCWorkLetterType WorkLetterType = JCWorkLetterType.Save;
        DataTable _dtAttachment = new DataTable();
        DataTable _dtCopyes = new DataTable();

        #endregion Feilds

        public JCLetterRegisterInternal LetterRegisterInternal;
        public JLetterExportForm(int pStatusForm, JFormState pState, int LetterCode, int pCurrentReferCode)
        {
            InitializeComponent();
            //LetterRegisterInternal = pLetterRegisterInternal;

            InitializeComponent();
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
        }

        /// <summary>
        /// تنظیم لیست های روی فرم
        /// </summary>
        private void _SetCmb()
        {
            try
            {
                //  ---------------------- Set ComboBox Sender --------------------------
                //cdbSender.TitleFieldName = "full_title";
                //cdbSender.AccessCodeFieldName = "accesscode";
                //cdbSender.CodeFieldName = "code";
                ////  ---------------------- Set ComboBox Receiver --------------------------
                //cdbReceiver.TitleFieldName = "full_title";
                //cdbReceiver.AccessCodeFieldName = "accesscode";
                //cdbReceiver.CodeFieldName = "code";
                //cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0,JMainFrame.GetActiveChartCode());

                if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                {
                    //cdbSender.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, JMainFrame.GetActiveChartCode());
                    //cdbSender.SetComboBox();
                    //cdbReceiver.dataTable = (new JOrganizations()).GetOrganization(0);
                    //cdbReceiver.SetComboBox();
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
                cmbSecurityLevel.DisplayMember = "name";
                cmbSecurityLevel.ValueMember = "value";
                cmbSecurityLevel.DataSource = dt;
                cmbSecurityLevel.SelectedValue = ClassLibrary.Domains.JGlobal.JPrivacy.Normal;
                //  ---------------------- Set ComboBox Urgency --------------------------
                dt = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
                cmbUrgency.DisplayMember = "name";
                cmbUrgency.ValueMember = "value";
                cmbUrgency.DataSource = dt;
                cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;
                //  ---------------------- Set ComboBox Subject --------------------------
                ArchivedDocuments.JSubjectTree Subject = new ArchivedDocuments.JSubjectTree();
                //cdbSubject.AccessCodeFieldName = "AccessCode";
                //cdbSubject.TitleFieldName = "name";
                //cdbSubject.CodeFieldName = "code";
                //cdbSubject.dataTable = Subject.GetSubjectList();
                //cdbSubject.SetComboBox();

                cmbSubject.DisplayMember = "name";
                cmbSubject.ValueMember = "code";
                cmbSubject.DataSource = Subject.GetSubjectList();
                //cmbSubject.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;                
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
            UC_LetterCopy1.SetData(pLetterCode);
            //UC_LetterCopy.SetData(pLetterCode);
            //------------------ضمائم ---------------
            //UC_AttachmentManager.SetDataLast(pLetterCode);
            //------------------عطف ---------------
            _dtRelatedLetter.Clear();
            JCRelatedLetter tmpJCRelatedLetter = new JCRelatedLetter();
            foreach (DataRow dr in tmpJCRelatedLetter.GetDate(pLetterCode).Rows)
                AddRelatedLetter(Convert.ToInt32(dr["dependent_lettercode"].ToString()));
            uC_GridLetter.Bind(_dtRelatedLetter, "RelatedLetter");
            // _dtRelatedLetter = tmpJCRelatedLetter.GetDate(pLetterCode);

            //------------------ پر کردن اطلاعات فرستنده گیرنده بر اساس نوع نامه ---------------
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                //if ((new JOrganization(LRI.receiver_external_code)).Access_Code != 0)
                //    cdbReceiver.SetValue((new JOrganization(LRI.receiver_external_code)).Access_Code);
                //else
                //    txtSender.Text = LRI.receiver_full_title;
                //cdbSender.SetValue((new Employment.JEOrganizationChart(LRI.sender_post_code)).AccessCode);
            }

            ArchivedDocuments.JSubjectTree sub = new ArchivedDocuments.JSubjectTree();
            //cdbSubject.SetValue((new ArchivedDocuments.JSubjectTree()).GetAccessCode(LRI.subject_code));
            txtSubjectMinute.Text = LRI.pre_subject;
            txtAppindix.Text = LRI.appendix;
            txtSummery.Text = LRI.summary;
            //txtLetterImportLetterNo.Text = LRI.incoming_no;
            //dteLetterImportDate.Text = (JDateTime.FarsiDate(LRI.incoming_date));
            //txtSignatured.Text = LRI.incoming_signature_person;
            cmbReceiveType.SelectedValue = LRI.receiver_type;
            cmbUrgency.SelectedValue = LRI.urgency;
            cmbSecurityLevel.SelectedValue = LRI.secret_level;
            _StatusForm = LRI.letter_type;
            _Letter_No = LRI.letter_no;
            _letter_status = LRI.letter_status;
        }

        private void SetValue()
        {
            cdbSender.Text = LetterRegisterInternal.sender_post_code.ToString();   
        }

        private void JLetterExportForm_Load(object sender, EventArgs e)
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
                if (_letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
                {
                    //btnArchive.Visible = false;
                    btnConfirmMinute.Visible = false;
                    btnConSec.Visible = false;
                    btnRegMinute.Visible = false;
                }
            }
            if (_Letter_No != "")
            {
                btnRegMinute.Enabled = false;
                btnConfirmMinute.Enabled = false;
            }
        }


        private void btnSelOrganization_Click(object sender, EventArgs e)
        {
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Import)
            {
                JfrmOrganizatins jorg = new JfrmOrganizatins();
                if (jorg.ShowDialog() == DialogResult.OK)
                {
                    //  ---------------------- Set ComboBox Sender --------------------------
                    //cdbSender.AccessCodeFieldName = "access_code";
                    //cdbSender.TitleFieldName = "full_title";
                    //cdbSender.CodeFieldName = "code";
                    //cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
                    //cdbSender.SetComboBox();

                    //if (jorg.SelectedRow != null)
                    //    cdbSender.SetValue(jorg.SelectedRow.Cells["access_code"]);
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
                    //cdbReceiver.TitleFieldName = "full_title";
                    //cdbReceiver.AccessCodeFieldName = "accesscode";
                    //cdbReceiver.CodeFieldName = "code";
                    //cdbReceiver.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, (JMainFrame.GetActiveChartCode()));
                    //cdbReceiver.SetComboBox();
                    //cdbReceiver.SetValue(Org.SelectedItem["accesscode"]);
                }
                Org.Dispose();
            }
        }

        private void btnReceiver_Click(object sender, EventArgs e)
        {
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                JfrmOrganizatins jorg = new JfrmOrganizatins();
                if (jorg.ShowDialog() == DialogResult.OK)
                {
                    //  ---------------------- Set ComboBox Sender --------------------------
                    //cdbSender.AccessCodeFieldName = "access_code";
                    //cdbSender.TitleFieldName = "full_title";
                    //cdbSender.CodeFieldName = "code";
                    //cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
                    //cdbSender.SetComboBox();

                    //if (jorg.SelectedRow != null)
                    //    cdbSender.SetValue(jorg.SelectedRow.Cells["access_code"]);
                }
                jorg.Dispose();
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
                //ArchivedDocuments.JSubjectTree Subject = new ArchivedDocuments.JSubjectTree();
                //cmbSubject.AccessCodeFieldName = "AccessCode";
                //cmbSubject.TitleFieldName = "name";
                //cmbSubject.CodeFieldName = "code";
                //cmbSubject.dataTable = Subject.GetSubjectList();
                //cmbSubject.SetComboBox();
                //cmbSubject.SetValue(((ClassLibrary.JCustomTreeNode)(((System.Windows.Forms.TreeNode)(sub.SelectedItem)).Tag)).FieldsValue["AccessCode"].ToString());
                //sub.Dispose();
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

        /// <summary>
        ///عملیات مربوط به مینوت صادره 
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private void WorkingMinuteExport(JCWorkLetterType pAction)
        {
            JCLetterRegisterExport LRI = new JCLetterRegisterExport(_LetterCode);
            Data(LRI);
            if (State == JFormState.Insert)
            {
                _LetterCode = LRI.Insert(_dtCopyes, jArchiveList1, _dtRelatedLetter);
                if (_LetterCode > 0)
                {
                    JMessages.Message("Minute Register successfully", "", JMessageType.Information);
                    this.Dispose();
                }
                else
                    JMessages.Message("Error", "", JMessageType.Information);
            }
            else if (State == JFormState.Update)
            {
                LRI.Code = _LetterCode;
                if (LRI.Update(_LetterCode, _dtCopyes, jArchiveList1, _dtRelatedLetter, pAction))
                    JMessages.Message("Minute Update successfully", "", JMessageType.Information);
                else
                    JMessages.Message("Unable Letter Change", "", JMessageType.Information);
            }
        }

        /// <summary>
        /// داده ها ی مشترک برای انواع نامه ها
        /// </summary>
        /// <param name="LRI"></param>
        private void Data(JCLetterRegister LRI)
        {
            LRI.Current_Refer_Code = _Refer_Code;
             if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                //------------------- گیرنده ------------------------------------------
                if (cdbReceiver.SelectedItem != null)
                {
                    LRI.receiver_external_code = Convert.ToInt32(cdbReceiver.SelectedValue);
                    LRI.receiver_full_title = cdbReceiver.Text.ToString();
                }
                //------------------- فرستنده ------------------------------------------
                if (cdbSender.SelectedItem != null)
                {
                    LRI.sender_post_code = Convert.ToInt32(cdbSender.SelectedValue);
                    LRI.sender_full_title = cdbSender.Text.ToString();
                }
            }            
            //------------------- موضوع ------------------------------------------
             if (cmbSubject.SelectedItem != null)
                 LRI.subject_code = Convert.ToInt32(cmbSubject.SelectedValue);
            //------------------ پیش نویس موضوع -----------------------------------
            LRI.pre_subject = txtSubjectMinute.Text.Trim();
            //------------------ پیوست --------------------------------------------
            LRI.appendix = txtAppindix.Text.Trim();
            //------------------ خلاصه ---------------------------------------------
            LRI.summary = txtSummery.Text.Trim();
            //------------------ شماره نامه وارده ----------------------------------
            //LRI.incoming_no = txtLetterImportLetterNo.Text.Trim();
            //------------------ تاریخ نامه وارده ---------------------------------
            //if (dteLetterImportDate.Text != "    /  /")
            //    LRI.incoming_date = Convert.ToDateTime(dteLetterImportDate.Text);
            //------------------ امضا کننده نامه وارده ----------------------------
            //LRI.incoming_signature_person = txtSignatured.Text.Trim();
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
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        private void WorkingMinute(JCWorkLetterType pAction)
        {
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                WorkingMinuteExport(pAction);            
        }

        /// <summary>
        /// عملیات مربوط به ثبت ویرایش تایید مینوت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegMinute_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// باز کردن فرم جستجوی مینوت
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btSearch_Click(object sender, EventArgs e)
        {
            JfrmMinuteList tmpJfrmMinuteList = new JfrmMinuteList(JMainFrame.CurrentUserCode, JMainFrame.CurrentPostCode, ClassLibrary.Domains.JGlobal.JfrmState.Confirm, _StatusForm);
            tmpJfrmMinuteList.ShowDialog();
            if (tmpJfrmMinuteList.Code != 0)
            {
                SetForm(tmpJfrmMinuteList.Code);
                State = JFormState.Update;
                tmpJfrmMinuteList.Dispose();
            }
        }

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
            State = JFormState.Update;
            WorkingMinute(JCWorkLetterType.UpdateAndRegister);//ویرایش و ثبت و دریافت شماره و ارسال به گیرنگان            
            //JMessages.Message("Send Successfuly to Secretariat", "", JMessageType.Information);

            JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(_LetterCode);
            if (tmpJCLetterRegister.SendAttachmentToArchive())
                JMessages.Message("Archive Successfuly ", "", JMessageType.Information);
            else
                JMessages.Message("Archive Not Successfuly ", "", JMessageType.Error);


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
                //if (btnHistory.Text == "+")
                //{
                //    UC_AttachmentManager.SetData(_LetterCode);
                //    btnHistory.Text = "-";
                //}
                //else
                //{
                //    UC_AttachmentManager.SetDataLast(_LetterCode);
                //    btnHistory.Text = "+";
                //}
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
            DataTable dt = new DataTable();
            dr = _dtRelatedLetter.NewRow();
            dt = LRI.GetDataLetter(pCode);
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
                JfrmLetterRegisterImport tmp = new JfrmLetterRegisterImport(_StatusForm, JFormState.ReadOnly, 0, _Refer_Code);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReferRemove_Click(object sender, EventArgs e)
        {
            uC_GridLetter.RemoveSelectedRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JfrmLetterRegisterImport tmp = new JfrmLetterRegisterImport(_StatusForm, JFormState.Update, 0, _Refer_Code);
            tmp.SetForm(Convert.ToInt32(uC_GridLetter.SelectedRow.Cells["Code"].ToString()));
            tmp.ShowDialog();
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
                UC_LetterCopy1._SetComboBoxs(Convert.ToInt32(cdbSender.SelectedValue), ClassLibrary.Domains.JCommunication.JLetterType.Internal);
            if (_StatusForm == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
            {
                if ((cdbSender.SelectedItem != null) && (Convert.ToInt32(cdbSender.SelectedValue.ToString()) != -1))
                {
                    cdbReceiver.DataSource = (new Employment.JEOrganizationChart()).GetOrgChart_User(Convert.ToInt32(cdbSender.SelectedValue), "0");
                    //cdbReceiver.SetComboBox();
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

        }

        private void btnDelMinute_Click(object sender, EventArgs e)
        {

        }    

    }
}
