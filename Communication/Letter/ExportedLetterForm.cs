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
using Globals;
using Communication.Letter;
 
namespace Communication
{
    public partial class JExportedLetterForm : ClassLibrary.JBaseForm
    {
        int _Code, _ParentCode, _ReferCode, _Year;

        public const string _ConstClassName = "Communication.JCExportedLetter";
        public ClassLibrary.JEditorBase txtContent;

        public JExportedLetterForm()
            : this(0, 0)
        {
        }

        public JExportedLetterForm(int pCode)
            : this(pCode, 0)
        {
        }

        public JExportedLetterForm(int pCode, int pReferCode)
            : this(pCode, pReferCode, 0)
        {
        }

        public JExportedLetterForm(int pCode, int pReferCode, int pParentCode)
        {
            InitializeComponent();
            _ParentCode = pParentCode;
            _Code = pCode;
            _ReferCode = pReferCode;
			jPropertyValueUserControl1.ClassName = "Communication.JExportedLetterForm";
			jPropertyValueUserControl1.ObjectCode = 0;
			jPropertyValueUserControl1.ValueObjectCode = pCode;


            txtContent = new JEditorBase();
            txtContent.Parent = panel2;
            panel2.Controls.Add(txtContent);
            txtContent.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// تنظیم فرم
        /// </summary>
        private void _SetForm()
        {
            try
            {
                // بررسی مجوز ویرایش شماره دبیرخانه
                txtYear.Text = (new System.Globalization.PersianCalendar()).GetYear(JDateTime.Now()).ToString();
                if (CanEditLetterNo())
                {
                    txtYear.Enabled = true;
                    txtLetterNo.Enabled = true;
                    grbDelivery.Enabled = true;
                }
                //  ---------------------- Set ComboBox Sender --------------------------
                cmbDeliveryType.DisplayMember = "FarsiName";
                cmbDeliveryType.ValueMember = "value";
                DataTable _dt = ClassLibrary.Domains.JCommunication.JSendType.GetData();
                cmbDeliveryType.DataSource = _dt;

                //  ---------------------- Set ComboBox Sender --------------------------
                cmbSender.DisplayMember = "Full_Title_Slim";
                cmbSender.ValueMember = "code";
                _dt = (new JEOrganizationChart()).GetParents(JMainFrame.CurrentPostCode);
                (_dt as JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
                cmbSender.DataSource = _dt;

                //  ---------------------- Set ComboBox Urgency --------------------------
                cmbUrgency.DisplayMember = "FarsiName";
                cmbUrgency.ValueMember = "value";
                cmbUrgency.DataSource = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
                cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;

                if (_Code > 0)
                {
                    jPropertyValueUserControl1.ValueObjectCode = _Code;

                    JCLetter Letter = new JCLetter(_Code);

                    if (JPermission.CheckPermission("Get Number For JImportedLetterForm Letter", false) && Letter.GetLetterNo().Length == 0)
                    {
                        btnNewNumber.Visible = true;
                    }

                    txtContent.EditorType = Letter.EditorType;
                    txtContent.Load();

                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    txtLetterNo.Text = Letter.GetLetterNo();
                    if (Letter.SignDate != null && Letter.SignDate > DateTime.MinValue)
                        txtYear.Text = pc.GetYear(Letter.SignDate).ToString();
                    if (Letter.ParentCode > 0)
                    {
                        _ParentCode = Letter.ParentCode;
                        buttonParent.Visible = true;
                    }
                    cmbSender.SelectedValue = Letter.sender_post_code;
                    txtReciever.Text = Letter.receiver_full_title;
                    cmbUrgency.SelectedValue = Letter.urgency;
                    txtSubject.Text = Letter.subject;
                    txtContent.Text = Letter.LetterText;

                    cmbDeliveryType.SelectedValue = Letter.DeliveryType;
                    dteDelivery.Date = Letter.DeliveryDate;
                    txtDeliveryPerson.Text = Letter.DeliveryPerson;

                    DataTable _DT = Letter.LetterCopies;
                    foreach (DataRow Drow in _DT.Rows)
                    {
                        try
                        {
                            dgrCopies.Rows.Add();
                            int newRow = dgrCopies.Rows.Count - 1;
                            dgrCopies.Rows[newRow].Cells[0].Value = int.Parse(Drow["receiver_Post_Code"].ToString());
                            dgrCopies.Rows[newRow].Cells[1].Value = Drow["receiver_full_title"].ToString();
                            dgrCopies.Rows[newRow].Cells[2].Value = Drow["copy_reason"].ToString();

                            cmbSender.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                    }

                    if (_Code > 0 && _ReferCode == 0)
                        _ReferCode = (new Automation.JARefer()).
                                FindRefer(_ConstClassName, _Code, 0);

                    if (_ReferCode != 0)
                    {
                        refersText1.TotalRefers = true;
                        refersText1.LoadRefer(_ReferCode);
                        jRefersTextRTB1.LoadRefer(_ReferCode);
                        DataTable DT = Automation.JARefers.GetRefersByObjectCode((new Automation.JARefer(_ReferCode)).object_code);
                        BuildingTree(_ReferCode, DT, "Code", "parent_code", _ReferCode, BuildingTreeUP(DT, "Code", "parent_code", _ReferCode));

                        Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
                        if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
                            || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                        {
                            btnSave.Enabled = false;
                            btnRefer.Enabled = false;
                        }

                    }

                    SignStateSet(Letter);

                }
                else
                {
                    txtContent.Load();
                }

                if (_ParentCode > 0)
                {
                    JCLetter ParentLetter = new JCLetter(_ParentCode);
                    txtParent.Text = ParentLetter.subject + " (" + _ParentCode.ToString() + ")";
                    if (_Code == 0)
                    {
                        if (ParentLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                            txtReciever.Text = ParentLetter.sender_full_title;
                        else
                            txtReciever.Text = ParentLetter.sender_full_title;
                        txtSubject.Text = ParentLetter.subject;
                        if (txtSubject.Text.StartsWith("پاسخ:") == false)
                            txtSubject.Text = "پاسخ: " + ParentLetter.subject;
                        DataTable _DT = ParentLetter.LetterCopies;
                        foreach (DataRow Drow in _DT.Rows)
                        {
                            try
                            {
                                dgrCopies.Rows.Add();
                                int newRow = dgrCopies.Rows.Count - 1;
                                dgrCopies.Rows[newRow].Cells[0].Value = int.Parse(Drow["receiver_Post_Code"].ToString());
                                dgrCopies.Rows[newRow].Cells[1].Value = Drow["receiver_full_title"].ToString();
                                dgrCopies.Rows[newRow].Cells[2].Value = Drow["copy_reason"].ToString();

                                cmbSender.SelectedValue = ParentLetter.sender_post_code;
                                cmbSender.Enabled = false;

                                txtReciever.Text = ParentLetter.receiver_full_title;
                            }
                            catch (Exception ex)
                            {
                                JSystem.Except.AddException(ex);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void SignStateSet(JCLetter Letter)
        {
            if (Letter.isSigned)
            {
                btnReply.Enabled = true;
                btnReplayExport.Enabled = true;
                if (_ParentCode > 0)
                {
                    btnParentLetter.Visible = true;
                }
                btnSave.Enabled = false;
                jArchiveList1.EnabledChange = false;
                txtContent.ChangeToViewMode();
                pnlLetterInfo.Hide();
                refersText1.Hide();

                ConvertContectToSignLetter(Letter);
                SetLetterInfo();

                btnSign.Visible = false;
                lblSignStatus.Text = "نامه در تاریخ " + JDateTime.FarsiDate(Letter.SignDate) + " " +
                    Letter.SignDate.Hour.ToString("00") + ":" +
                    Letter.SignDate.Minute.ToString("00") + ":" +
                    Letter.SignDate.Second.ToString("00")
                    + " امضا شده است";
            }
            else if (JMainFrame.CurrentPostCode == Letter.sender_post_code)
            {
                btnSign.Visible = true;
            }
        }

        private void btnAddCopyReceiver_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCopyReceiver.SelectedIndex >= 0)
                    foreach (DataGridViewRow DRow in dgrCopies.Rows)
                    {
                        if (DRow.Cells[0].Value.ToString() == cmbCopyReceiver.SelectedValue.ToString())
                        {
                            return;
                        }
                    }

                dgrCopies.Rows.Add();
                int newRow = dgrCopies.Rows.Count - 1;
                if (cmbCopyReceiver.SelectedIndex >= 0)
                {
                    dgrCopies.Rows[newRow].Cells[0].Value = cmbCopyReceiver.SelectedValue;
                    dgrCopies.Rows[newRow].Cells[1].Value = (cmbCopyReceiver.SelectedItem as DataRowView).Row["Full_Name"].ToString();
                }
                else
                {
                    dgrCopies.Rows[newRow].Cells[0].Value = 0;
                    dgrCopies.Rows[newRow].Cells[1].Value = cmbCopyReceiver.Text;
                }
                dgrCopies.Rows[newRow].Cells[2].Value = txtReason.Text;
                cmbSender.Enabled = false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        public bool CanEditLetterNo()
        {
            if (JPermission.CheckPermission("Communication.JExportedLetterForm.CanEditLetterNo", false))
                return true;
            return false;
        }

        private void JExportedLetterForm_Load(object sender, EventArgs e)
        {
            _SetForm();
            if (_Code > 0)
            {
                jArchiveList1.ClassName = _ConstClassName;
                jArchiveList1.ObjectCode = _Code;
                jArchiveList1.AutomationReferCode = _ReferCode;
                jArchiveList1.LoadList();
            }

        }

        private void cmbSender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSender.SelectedValue == null) return;
            ////  ---------------------- Set ComboBox Receiver --------------------------
            cmbCopyReceiver.DisplayMember = "Full_Title_Slim";
            cmbCopyReceiver.ValueMember = "code";
            JEOrganizationChart jeOrgChart = new JEOrganizationChart();
            DataTable dt;

            dt = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);

            (dt as JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
            cmbCopyReceiver.DataSource = dt.Copy();

            jeOrgChart = new JEOrganizationChart((int)cmbSender.SelectedValue);
            if (jeOrgChart.is_unit)
                lblSignStatus.Text = "نامه هنوز امضا نشده است.";
            else
                lblSignStatus.Text = "فرستنده حق امضاء ندارد.";
            if (JMainFrame.CurrentPostCode == (int)cmbSender.SelectedValue)
            {
                btnSign.Visible = true;
            }
            else
                btnSign.Visible = false;

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
			if (!JCExportedLetter.PermissionLetterExportSign())
			{
				JMessages.Message("شما مجوز امضا نامه صادره را ندارید", "خطای مجوز", JMessageType.Error);
				return;
			}

            if (JMessages.Question("از امضاء نامه مطمئن هستید؟", "امضا") == DialogResult.Yes)
            {
                SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute);
                JCLetter jcLetter = new JCLetter(_Code);
                if (!jcLetter.isSigned)
                {
                    jcLetter.letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Accept;
                    jcLetter.isSigned = true;
                    jcLetter.SignDate = JDateTime.Now();
					jcLetter.LetterText = txtContent.Text;
					int _Year = Convert.ToInt32(txtYear.Text);
					if (JPermission.CheckPermission("You Can Get Auto Number Export Letter After Sign", false))
					{
						NoStorage noStorage = new NoStorage(_ConstClassName, 0, _Year);
                        string S = jcLetter.SaveLetterNo(noStorage.GetNextNumber().ToString());
                        jcLetter.letter_no = S;
					}
					ConvertContectToSignLetter(jcLetter);
                    if (jcLetter.Update())
                    {
                        lblSignStatus.Text = "نامه در تاریخ " + JDateTime.FarsiDate(jcLetter.SignDate) + " " + jcLetter.SignDate.Hour.ToString("00") + ":" + jcLetter.SignDate.Minute.ToString("00") + ":" + jcLetter.SignDate.Second.ToString("00")
                            + " امضا شده است";
                        btnSign.Visible = false;
                        Refer();
                        SignStateSet(jcLetter);
                        this.Close();
                    }
                }
            }

        }

        private string ConvertContectToSignLetter(JCLetter pLetter)
        {
            JEOrganizationChart jeOrgChart = new JEOrganizationChart(pLetter.sender_post_code);

            //Header
            Font FontHeader = new System.Drawing.Font("B Titr", 13, FontStyle.Bold);
            Font FontFooter = new System.Drawing.Font("B Titr", 13, FontStyle.Bold);
            Font FontCopies = new System.Drawing.Font("B Roya", 14);

            if (ChectSettings("احتراما"))
                WriteInLetter(FontHeader, true, "احتراما" + RN(1));
            if (ChectSettings("موضوع"))
                WriteInLetter(FontHeader, Color.Green, true, "موضوع:" + pLetter.subject+RN(1));
            if (ChectSettings("از"))
                WriteInLetter(FontHeader, Color.Blue, true, "از: " + pLetter.sender_full_title +RN(1)+ "به: " + pLetter.receiver_full_title + RN(1));
            if (ChectSettings("شماره نامه"))
                WriteInLetter(FontHeader, Color.Blue, true, "شماره نامه: " + pLetter.GetLetterNo().ToString() + RN(1));

            //Footer
            if (ChectSettings("باتشکر"))
            {
                WriteInLetter(FontFooter, false, RN(1) + Tab(10) + "باتشکر");
                WriteInLetter(FontFooter, false, RN(1) + Tab(9) + jeOrgChart.Name + ' ' + jeOrgChart.Fam);
            }
            if (ChectSettings("چارت"))
            {
                WriteInLetter(FontFooter, false, RN(1) + Tab(9) + jeOrgChart.Job);
            }
            if (ChectSettings("تاریخ امضا"))
                WriteInLetter(FontCopies, false, RN(1) + Tab(9) + JDateTime.FarsiDate(pLetter.SignDate));

            if (ChectSettings("رونوشت"))
            {
                WriteInLetter(FontCopies, Color.Red, false, RN(1) + "رونوشت: ");

                DataTable _DT = pLetter.LetterCopies;
                foreach (DataRow Drow in _DT.Rows)
                {
                    try
                    {
                        WriteInLetter(FontCopies, false, RN(1) + "-" + Drow["receiver_full_title"].ToString()
                            + ":" + Drow["copy_reason"].ToString());
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                }
            }

            return txtContent.Text;
        }

        private void SetLetterInfo()
        {
            //jRefersTextRTB1.LoadRefer(_ReferCode);
            //WriteInLetter(18, Color.Red, false, RN(1) + "ارجاعات:" + RN(1));
            //txtContent.InsertRTFFooter(jRefersTextRTB1.Rtf);

            Font FontCopies = new System.Drawing.Font("B Roya", 14);
            if (txtContent.EditorType == 0)
            {
                jRefersTextRTB1.LoadRefer(_ReferCode);
                WriteInLetter(FontCopies, Color.Blue, false, RN(1) + "ارجاعات :" + RN(1));
                txtContent.InsertRTFFooter(jRefersTextRTB1.Rtf);
            }
            else
            {
                WriteInLetter(FontCopies, Color.Blue, false, RN(1) + "ارجاعات :" + RN(1));
                txtContent.InsertRTFFooter(jRefersTextRTB1.LoadReferText(_ReferCode));
            }
        
        }

        private string Tab(int Count)
        {
            string ret = "";
            for (int i = 1; i <= Count; i++)
            {
                ret += "\t";
            }
            return ret;
        }

        private string RN(int Count)
        {
            string ret = "";
            for (int i = 1; i <= Count; i++)
            {
                ret += "\r\n";
            }
            return ret;
        }

        private bool ChectSettings(String pText)
        {
            string Value = WebClassLibrary.JWebSettings.GetKey("Communication.JExportedLetterForm." +
        pText.Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", ""));
            if (Value == "0")
                return false;
            return true;
        }

        private void WriteInLetter(Font font, bool HederFooter, string pText)
        {
            WriteInLetter(font, Color.Black, HederFooter, pText);
        }

        private void WriteInLetter(Font font, Color pColor, bool HederFooter, string pText)
        {
            try
            {
                if (HederFooter)
                    txtContent.InsertHeader(pText, font, HorizontalAlignment.Right, pColor);
                else
                    txtContent.InsertFooter(pText, font, HorizontalAlignment.Right, pColor);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }


        private void Refer()
        {
            JCLetter Letter = new JCLetter();

            DataTable _DT = Letter.GetData(_Code);
            if (_DT.Rows.Count == 1)
            {
                string _PostCode = "";
                foreach (DataRow _row in Letter.LetterCopies.Rows)
                {
                    if (Convert.ToInt32(_row["receiver_post_code"]) > 0)
                        _PostCode = _PostCode + ";" + _row["receiver_post_code"];
                }
                if (_PostCode.Length > 1) _PostCode = _PostCode.Substring(1);
                _DT.Columns.Add("recivers");
                _DT.Rows[0]["recivers"] = _PostCode;
                Automation.Refer.frmRecieverSelector frmrs =
                    new Automation.Refer.frmRecieverSelector
                        (_DT, null, _ConstClassName, 0, _Code, "نامه صادره", _ReferCode);
                if (frmrs.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    _ReferCode = frmrs.ReferCode;
                    btnSave.Enabled = false;
                    btnRefer.Enabled = false;
                    btnReply.Enabled = true;
                    btnReplayExport.Enabled = true;
                    refersText1.TotalRefers = true;
                    refersText1.LoadRefer(frmrs.ReferCode);
                }
            }
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if ((new JCLetter(_Code)).isSigned == false && btnSign.Visible == true && JMessages.Warning("از ارجاع نامه امضا نشده مطمئن هستید.", "ارجاع بدون امضاء") != DialogResult.OK)
                    return;
                SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute);
            }
            Refer();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == false || SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute))
            {

                JCLetter Letter = new JCLetter();
                DataTable _DT = Letter.GetDataForPrint(_Code);
                // Letter Copies
                string letterCopies = "";
                foreach (DataRow Drow in Letter.LetterCopies.Rows)
                {
                    try
                    {
                        letterCopies += "-" + Drow["receiver_full_title"].ToString()
                            + ":" + Drow["copy_reason"].ToString() + "\r\n";
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                }
                // Add refers to DataTable
                _DT.Columns.Add("Refer_Text");
                _DT.Columns.Add("Refer_NormalText");
                _DT.Columns.Add("Full_Letter_Text");
                _DT.Columns.Add("LetterCopies");
                _DT.Columns.Add("PrintCode");
                if (_DT.Rows.Count > 0)
                {
                    _DT.Rows[0]["Refer_Text"] = jRefersTextRTB1.Rtf;
                    _DT.Rows[0]["Refer_NormalText"] = jRefersTextRTB1.NormalText;
                    _DT.Rows[0]["Full_Letter_Text"] = txtContent.Text;
                    _DT.Rows[0]["LetterCopies"] = letterCopies;
                    DateTime datetime = JDateTime.Now();
                    _DT.Rows[0]["PrintCode"] = datetime.Year.ToString("0000") + datetime.Month.ToString("00") + datetime.Day.ToString("00")
                        + datetime.Hour.ToString("00") + datetime.Minute.ToString("00") + datetime.Second.ToString("00")
                        + JMainFrame.CurrentPostCode.ToString("00000000000") + Letter.Code.ToString("00000000000");
                }

                ClassLibrary.JDynamicReportForm jDynamicReportForm = new ClassLibrary.JDynamicReportForm(JReportDesignCodes.OfficeLetter.GetHashCode());
                jDynamicReportForm.Add(_DT);

                jDynamicReportForm.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            JCLetter Letter = null;
            if (_Code > 0 && btnSave.Enabled)
                Letter = new JCLetter(_Code);
            if (btnSave.Enabled && Letter != null && !Letter.isSigned && JMessages.Question("ایا تغییرات ذخیره گردد", "ذخیره تغییرات") == DialogResult.Yes)
            {
                SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute);
            }
            Close();
        }

        private void btnDeleteCopyReceiver_Click(object sender, EventArgs e)
        {
            if (dgrCopies.Rows.Count > 0 && dgrCopies.SelectedRows.Count > 0)
            {
                dgrCopies.Rows.RemoveAt(dgrCopies.SelectedRows[0].Index);
                if (dgrCopies.Rows.Count == 0)
                    cmbSender.Enabled = true;
            }
        }

        private void btnParentLetter_Click(object sender, EventArgs e)
        {
            JCLetter jcLetter = new JCLetter(_ParentCode);
            if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                (new JImportedLetterForm(_ParentCode)).ShowDialog();
            else if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                (new JLetterForm(_ParentCode)).ShowDialog();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            this.Close();
            (new JImportedLetterForm(0, 0, _Code)).ShowDialog();
        }

        private bool Save()
        {
            return SaveAs(0);
        }

        private bool SaveAs(int letter_status)
        {
            try
            {
                JCLetter jcLetter;
                if (_Code == 0)
                    jcLetter = new JCLetter();
                else
                    jcLetter = new JCLetter(_Code);

                if (jcLetter.ParentCode > 0)
                    btnParentLetter.Visible = true;

                if (jcLetter.isSigned)
                {
                    JMessages.Message("نامه امضا شده است و قابل تغییر نیست", "خطا", JMessageType.Error);
                    return true;
                }

                if (cmbSender.SelectedValue == null)
                {
                    JMessages.Message("فرستنده انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                if (txtReciever.Text.Trim().Length < 3)
                {
                    JMessages.Message("گیرنده انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                if (txtSubject.Text.Trim().Length == 0)
                {
                    JMessages.Message("موضوع نامه انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                jcLetter.letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Export; // نامه صادره
                if (_Code == 0)
                {
                    jcLetter.letter_status = letter_status;
                    jcLetter.register_date_time = JDateTime.Now();
                    jcLetter.register_post_code = JMainFrame.CurrentPostCode;
                    jcLetter.register_user_code = JMainFrame.CurrentUserCode;
                    jcLetter.register_user_full_title = JMainFrame.CurrentPostTitle;
                }
                jcLetter.ParentCode = _ParentCode;
                jcLetter.subject_code = 0;// استفاده نشده است
                jcLetter.subject = txtSubject.Text;
                jcLetter.register_no = 0;// استفاده نشده است

                jcLetter.incoming_no = "";// استفاده نشده است
                jcLetter.incoming_date = JDateTime.Now();// استفاده نشده است
                jcLetter.incoming_signature_person = "";// استفاده نشده است
                jcLetter.sender_post_code = Convert.ToInt32(cmbSender.SelectedValue);
                jcLetter.sender_code = (new JEOrganizationChart(jcLetter.sender_post_code)).user_code;
                jcLetter.sender_full_title = (cmbSender.SelectedItem as DataRowView).Row["Full_Name"].ToString();
                jcLetter.sender_external_code = 0;// استفاده نشده است
                jcLetter.receiver_post_code = 0;
                jcLetter.receiver_code = 0;
                jcLetter.receiver_full_title = txtReciever.Text;
                jcLetter.receiver_external_code = 0;// استفاده نشده است
                jcLetter.secret_level = 0;// استفاده نشده است
                jcLetter.urgency = Convert.ToInt32(cmbUrgency.SelectedValue);
                jcLetter.send_type = ClassLibrary.Domains.JCommunication.JSendType.Automation;
                jcLetter.receiver_type = 0;// استفاده نشده است
                JEOrganizationChart E = new JEOrganizationChart(JMainFrame.CurrentPostCode);
                jcLetter.secretariat_code = E.secretariat_code;// استفاده نشده است
                jcLetter.appendix = "";// استفاده نشده است
                jcLetter.summary = "";// استفاده نشده است
                jcLetter.respite_date_time = JDateTime.Now();// استفاده نشده است
                jcLetter.minute_register_date = JDateTime.Now();
				jcLetter.LetterText = txtContent.Text;
				jcLetter.NormalLetterText = txtContent.GetNormalText();
                jcLetter.DeliveryType = Convert.ToInt32(cmbDeliveryType.SelectedValue);
                jcLetter.DeliveryDate = dteDelivery.Date;
                jcLetter.DeliveryPerson = txtDeliveryPerson.Text;
                jcLetter.EditorType = txtContent.EditorType;

                if (_Code == 0)
                {
                    _Code = jcLetter.Insert();
                    string S = jcLetter.SaveLetterNo(txtLetterNo.Text);
                    jcLetter.letter_no = S;
                    jcLetter.Update();
                }
                else
                {
                    string S = jcLetter.SaveLetterNo(txtLetterNo.Text);
                    jcLetter.letter_no = S;
                    jcLetter.Update();
                }
                if (_Code == 0)
                {
                    JMessages.Error("درج با خطا مواجه شد.", "ثبت نامه");
                    return false;
                }

				jPropertyValueUserControl1.ValueObjectCode = _Code;
                // Insert Copies
                JCLetterCopy jcLetterCopy = new JCLetterCopy();
                jcLetterCopy.DeleteByLetterCode(_Code);
                foreach (DataGridViewRow dgrRow in dgrCopies.Rows)
                {
                    jcLetterCopy = new JCLetterCopy();
                    jcLetterCopy.copy_reason = dgrRow.Cells[2].Value.ToString();
                    jcLetterCopy.copy_type = 0;
                    jcLetterCopy.letter_code = _Code;
                    jcLetterCopy.receiver_external_code = 0;
                    jcLetterCopy.receiver_full_title = dgrRow.Cells[1].Value.ToString();
                    jcLetterCopy.receiver_post_code = Convert.ToInt32(dgrRow.Cells[0].Value);
                    jcLetterCopy.receiver_subsidiaries_code = 0;
                    jcLetterCopy.receiver_user_code = (new JEOrganizationChart(jcLetterCopy.receiver_post_code)).user_code;
                    jcLetterCopy.register_full_title = JMainFrame.CurrentPostTitle;
                    jcLetterCopy.register_post_code = JMainFrame.CurrentPostCode;
                    jcLetterCopy.register_user_code = JMainFrame.CurrentUserCode;
                    jcLetterCopy.respite_date_time = DateTime.MinValue;
                    jcLetterCopy.send_type = ClassLibrary.Domains.JCommunication.JSendType.Automation;
                    jcLetterCopy.Insert();
                }
                JMessages.Message("ذخیره با موفقیت انجام شد", "موفق", JMessageType.Information);
                return true;
            }
            finally
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute))
            {
                Close();
            }

        }

        private bool SaveLetter(int pStatus)
        {
            if (!btnSave.Enabled)
                return true;
            bool result;
			if (_Code == 0)
			{
				result = SaveAs(pStatus);
				//_Code = result;
			}
			else
				result = Save();

            if (JPermission.CheckPermission("Get Number For JExportedLetterForm Letter", false))
            {
                //SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute);
                JCLetter jcLetter = new JCLetter(_Code);
                if (//jcLetter.isSigned && 
                    jcLetter.GetLetterNo().Length == 0
                    )
                {
                    NoStorageForm noStorage = new NoStorageForm(_ConstClassName, 0);
                    noStorage.ShowDialog();
                    if (noStorage.NoStorageNumber > 0)
                    {
                        string S = jcLetter.SaveLetterNo(noStorage.NoStorageNumber.ToString());
                        jcLetter.letter_no = S;
                        if (jcLetter.Update())
                        {
                            txtLetterNo.Text = jcLetter.GetLetterNo();
                        }
                    }
                }
            }

            jArchiveList1.ClassName = _ConstClassName;
            jArchiveList1.ObjectCode = _Code;
            jArchiveList1.ArchiveList();

			jPropertyValueUserControl1.Save();

            return result;
        }

        private void txtYear_Leave(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
                txtLetterNo.Text = "0";
            }
            finally
            {
            }
        }

		private void JExportedLetterForm_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (JPermission.CheckPermission("Get Number For JExportedLetterForm Letter"))
			{
				SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute);
				JCLetter jcLetter = new JCLetter(_Code);
				if (//jcLetter.isSigned && 
					jcLetter.GetLetterNo().Length == 0)
				{
					NoStorageForm noStorage = new NoStorageForm(_ConstClassName, 0);
					noStorage.ShowDialog();
					if (noStorage.NoStorageNumber > 0)
					{
                        string S = jcLetter.SaveLetterNo(noStorage.NoStorageNumber.ToString());
                        jcLetter.letter_no = S;
                        if (jcLetter.Update())
						{
							txtLetterNo.Text = jcLetter.GetLetterNo();
						}
					}
				}
			}
		}

		private void txtLetterNo_MouseDoubleClick(object sender, MouseEventArgs e)
		{

		}

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnReplayExport_Click(object sender, EventArgs e)
        {
            this.Close();
            (new JExportedLetterForm(0, 0, _Code)).ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            JCLetter jcLetter = new JCLetter(_ParentCode);
            if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                (new JImportedLetterForm(_ParentCode)).ShowDialog();
            if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                (new JExportedLetterForm(_ParentCode)).ShowDialog();
            else if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                (new JLetterForm(_ParentCode)).ShowDialog();

        }

        private void btnNewNumber_Click(object sender, EventArgs e)
        {
            JCLetter jcLetter = new JCLetter(_Code);
            NoStorageForm noStorage = new NoStorageForm(_ConstClassName, 0);
            noStorage.ShowDialog();
            if (noStorage.NoStorageNumber > 0)
            {
                string S = jcLetter.SaveLetterNo(noStorage.NoStorageNumber.ToString());
                jcLetter.letter_no = S;
                if (jcLetter.Update())
                {
                    txtLetterNo.Text = jcLetter.GetAllLetterNo();
                    btnNewNumber.Visible = false;
                }
            }

        }

        private string GetFullDate(DateTime date)
        {
            return date.Hour.ToString("00") + ":" + date.Minute.ToString("00") + "  " + JDateTime.FarsiDate(date).Substring(2);
        }

        private void BuildingTree(int _ReferCode, DataTable dt, String Key, String Parent, int Root, TreeNode N)
        {
            try
            {
                DataRow[] DRs;
                if (Root == 0)
                    DRs = dt.Select(Parent + "=0");
                else
                    DRs = dt.Select(Parent + "=" + Root.ToString());
                if (DRs.Length == 0)
                {
                    DataRow row = dt.Select(Key + "=" + Root.ToString())[0];
                    TreeNode node = new TreeNode();
                    node.ExpandAll();
                    node.Text = row["receiver_full_title"].ToString() + "(" + GetFullDate((DateTime)row["send_date_time"]) + ")" +
                        row["description"].ToString().Substring(0, row["description"].ToString().Length % 50);
                    node.ToolTipText = row["description"].ToString();
                    if (N == null)
                        treeViewRefer.Nodes.Add(node);
                    else
                        N.Nodes.Add(node);
                    return;
                }
                foreach (DataRow row in DRs)
                {
                    TreeNode node = new TreeNode();
                    node.Text = row["sender_full_title"].ToString() + "(" + GetFullDate((DateTime)row["send_date_time"]) + ")" +
                        row["description"].ToString().Substring(0, row["description"].ToString().Length % 50);
                    node.ToolTipText = row["description"].ToString();
                    if (N == null)
                        treeViewRefer.Nodes.Add(node);
                    else
                        N.Nodes.Add(node);
                    node.ExpandAll();
                    BuildingTree(_ReferCode, dt, Key, Parent, (int)row[Key], node);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private TreeNode BuildingTreeUP(DataTable dt, String Key, String Parent, int Root)
        {
            try
            {
                DataRow[] DRs;
                TreeNode node;
                if (Root == 0)
                {
                    return null;
                }
                else
                    DRs = dt.Select(Key + "=" + Root.ToString());
                if (DRs.Length == 1 && DRs[0][Parent].ToString() != "0")
                {
                    TreeNode parent_node = BuildingTreeUP(dt, Key, Parent, (int)DRs[0][Parent]);
                    node = new TreeNode();
                    node.Collapse(false);
                    DataRow row = DRs[0];
                    node.Text = row["sender_full_title"].ToString() + "(" + GetFullDate((DateTime)row["send_date_time"]) + ")" +
                        row["description"].ToString().Substring(0, row["description"].ToString().Length % 50);
                    node.ToolTipText = row["description"].ToString();
                    parent_node.Nodes.Add(node);
                    node.ExpandAll();
                    return node;
                }
                else
                {
                    node = new TreeNode();
                    node.ExpandAll();
                    DataRow row = DRs[0];
                    node.Text = row["sender_full_title"].ToString() + "(" + GetFullDate((DateTime)row["send_date_time"]) + ")" +
                        row["description"].ToString().Substring(0, row["description"].ToString().Length % 50);
                    node.ToolTipText = row["description"].ToString();
                    treeViewRefer.Nodes.Add(node);
                    return node;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

    }
}
