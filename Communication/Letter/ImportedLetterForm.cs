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
using ArchivedDocuments;

namespace Communication
{
    public partial class JImportedLetterForm : ClassLibrary.JBaseForm
    {
        int _Code, _Year;
        int _ReferCode;
        bool UserCanEdit = true;
        int _ParentCode;

        public const string _ConstClassName = "Communication.JCImportedLetter";

        public JImportedLetterForm()
            : this(0, 0 , 0)
        {
        }
        public JImportedLetterForm(int code)
            : this(code, 0 , 0)
        {
        }
        public JImportedLetterForm(int code, int referCode)
            : this(code, referCode, 0)
        {
        }

        public JImportedLetterForm(int code, int referCode, int pParentCode)
        {
            InitializeComponent();
            _Code = code;
            _ReferCode = referCode;
            _ParentCode = pParentCode;

			jPropertyValueUserControl1.ClassName = "Communication.JImportedLetterForm";
			jPropertyValueUserControl1.ObjectCode = 0;
		}

        private bool Save()
        {
            return SaveLetter(0);
        }

        private bool SaveLetter(int letter_status)
        {
            try
            {
                JCLetter jcLetter;
                if (_ReferCode > 0)
                    return true;
                if (_Code == 0)
                    jcLetter = new JCLetter();
                else
                    jcLetter = new JCLetter(_Code);
                jcLetter.ParentCode = _ParentCode;

                if (jcLetter.isSigned)
                {
                    JMessages.Message("نامه امضا شده است و قابل تغییر نیست", "خطا", JMessageType.Error);
                    return true;
                }

                if (txtSender.Text.Trim().Length < 3)
                {
                    JMessages.Message("فرستنده انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                if (cmbReceiver.SelectedValue == null)
                {
                    JMessages.Message("گیرنده انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                if (txtSender.Text.Trim().Length == 0)
                {
                    JMessages.Message("موضوع نامه انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                jcLetter.letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Import; // نامه وارده
                if (_Code == 0)
                {
                    jcLetter.letter_status = letter_status;
                    jcLetter.register_date_time = JDateTime.Now();
                    jcLetter.register_post_code = JMainFrame.CurrentPostCode;
                    jcLetter.register_user_code = JMainFrame.CurrentUserCode;
                    jcLetter.register_user_full_title = JMainFrame.CurrentPostTitle;
                }
                jcLetter.subject_code = 0;// استفاده نشده است
                jcLetter.subject = txtSubject.Text;
                jcLetter.register_no = 0;// استفاده نشده است
                string S = jcLetter.SaveLetterNo(txtLetterNo.Text);
                jcLetter.letter_no = S;

                //(new NoStorage(_ConstClassName, 0, _Year)).SetNumber(Convert.ToInt32(txtLetterNo.Text));

                jcLetter.incoming_no = txtIncomingLetterNo.Text;
                jcLetter.incoming_date = dteIncomingLetterDate.Date;
                jcLetter.incoming_signature_person = txtSignaturePerson.Text;
                jcLetter.sender_post_code = 0;// استفاده نشده است
                jcLetter.sender_code = 0;// استفاده نشده است
                jcLetter.sender_full_title = txtSender.Text;
                jcLetter.sender_external_code = 0;// استفاده نشده است
                jcLetter.receiver_post_code = Convert.ToInt32(cmbReceiver.SelectedValue);
                jcLetter.receiver_code = (new JEOrganizationChart(jcLetter.receiver_post_code)).user_code;
                jcLetter.receiver_full_title = cmbReceiver.Text;
                jcLetter.receiver_external_code = 0;// استفاده نشده است
                jcLetter.secret_level = 0; // استفاده نشده است
                jcLetter.urgency = Convert.ToInt32(cmbUrgency.SelectedValue);
                jcLetter.send_type = ClassLibrary.Domains.JCommunication.JSendType.Automation;
                jcLetter.receiver_type = 0;// استفاده نشده است
                JEOrganizationChart E = new JEOrganizationChart(JMainFrame.CurrentPostCode);
                jcLetter.secretariat_code = E.secretariat_code;// استفاده نشده است
                jcLetter.appendix = "";// استفاده نشده است
                jcLetter.summary = "";// استفاده نشده است
                jcLetter.respite_date_time = JDateTime.Now();// استفاده نشده است
                jcLetter.minute_register_date = JDateTime.Now();
                jcLetter.SignDate = dteIncomingLetterDate.Date;


                //jcLetter.LetterText = ConvertContentToSignLetter(jcLetter);

                if (_Code == 0)
                {
                    _Code = jcLetter.Insert();
                    _Year = Convert.ToInt32(txtYear.Text);
                    //if (NoStorage.VerifyStorage(_ConstClassName, 0, _Year) == false)
                    //NoStorage.CreateNewNoStorage(_ConstClassName, 0, _Year);
					if (JPermission.CheckPermission("You Can Get Auto Number Import Letter After Sign", false))
					{
						NoStorage noStorage = new NoStorage(_ConstClassName, 0, _Year);
						txtLetterNo.Text = noStorage.GetNextNumber().ToString();
                        S = jcLetter.SaveLetterNo(txtLetterNo.Text);
                        jcLetter.letter_no = S;
                    }
                    else
					{
						if (jcLetter.GetLetterNo().Length == 0 && JPermission.CheckPermission("Get Number For JImportedLetterForm Letter", false))
						{
							NoStorageForm noStorage = new NoStorageForm(_ConstClassName, 0);
							noStorage.ShowDialog();
							if (noStorage.NoStorageNumber > 0)
							{
                                S = jcLetter.SaveLetterNo(noStorage.NoStorageNumber.ToString());
                                jcLetter.letter_no = S;
                                if (jcLetter.Update())
								{
									txtLetterNo.Text = jcLetter.GetAllLetterNo();
								}
							}
						}
					}
                }

                if (_Code > 0)
                {
					jArchiveList1.ClassName = _ConstClassName;
					jArchiveList1.ObjectCode = _Code;
                    jArchiveList1.AutomationReferCode = _ReferCode;
                    jPropertyValueUserControl1.ValueObjectCode = _Code;
					
					if (jArchiveImage1.State != JFormState.None)
                    {
                        jArchiveImage1.ObjectCode = _Code;
                        jArchiveImage1.ClassName = _ConstClassName;
                        jcLetter.ImageCode = jArchiveImage1.ArchiveImage();
                    }

					jPropertyValueUserControl1.Save();

                    jArchiveList1.ArchiveList();

					if (jcLetter.GetLetterNo().Length == 0 && JPermission.CheckPermission("Get Number For JImportedLetterForm Letter", false))
					{
						NoStorageForm noStorage = new NoStorageForm(_ConstClassName, 0);
						noStorage.ShowDialog();
						if (noStorage.NoStorageNumber > 0)
						{
                            S = jcLetter.SaveLetterNo(noStorage.NoStorageNumber.ToString());
                            jcLetter.letter_no = S;
                            if (jcLetter.Update())
							{
								txtLetterNo.Text = jcLetter.GetAllLetterNo();
							}
						}
					}
					
					jcLetter.Update();
                }

                if (_Code == 0)
                {
                    JMessages.Error("درج با خطا مواجه شد.", "ثبت نامه");
                    return false;
                }

                JMessages.Message("ذخیره با موفقیت انجام شد", "موفق", JMessageType.Information);
                return true;
            }
            finally
            {
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
        private void WriteInLetter(int FontSize, bool HederFooter, string pText)
        {
            WriteInLetter(FontSize, Color.Black, HederFooter, pText);
        }

        private void WriteInLetter(int FontSize, Color pColor, bool HederFooter, string pText)
        {
            try
            {
                Font font = new Font("B Zar", FontSize, FontStyle.Regular, GraphicsUnit.Pixel);
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
        private string ConvertContentToSignLetter(JCLetter pLetter)
        {
            JEOrganizationChart jeOrgChart = new JEOrganizationChart(pLetter.sender_post_code);

            txtContent.ClearText();
            txtContent.InsertText("\r\n[IMAGES]\r\n");
            return txtContent.Text;
        }
        private void _SetForm()
        {

            try
            {
                //  ---------------------- Set ComboBox Reciever --------------------------
                cmbReceiver.DisplayMember = "Title";
                cmbReceiver.ValueMember = "Code";
                cmbReceiver.DataSource = JEOrganizationChart.GetUserPosts();
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

                        if (Letter.ParentCode > 0)
                    {
                        btnParentLetter.Visible = true;
                        _ParentCode = Letter.ParentCode;
                    }

                    cmbReceiver.SelectedValue = Letter.receiver_post_code;
                    cmbUrgency.SelectedValue = Letter.urgency;
                    txtSubject.Text = Letter.subject;
                    txtSender.Text = Letter.sender_full_title;
                    txtLetterNo.Text = Letter.GetAllLetterNo();
                    txtIncomingLetterNo.Text = Letter.incoming_no;
                    dteIncomingLetterDate.Date = Letter.incoming_date;
                    txtSignaturePerson.Text = Letter.incoming_signature_person;
                    cmbReceiver.SelectedValue = Letter.receiver_post_code;
                    jArchiveImage1.DeleteCompeletly = true;
                    jArchiveImage1.ArchiveCode = Letter.ImageCode;
                }
                else
                {
                    //txtLetterNo.Text = JLetters.GetNewLetterNo().ToString();
                }

                if (_Code > 0 && _ReferCode == 0)
                    _ReferCode = (new Automation.JARefer()).
                            FindRefer("Communication.JCImportedLetter", _Code, 0);

                if (_ReferCode != 0)
                {
                    jArchiveList1.EnabledChange = false;
                    JCLetter Letter = new JCLetter(_Code);
                    if (!ClassLibrary.JPermission.CheckPermission("Communication.JCImportedLetter.CanEditAfterRefer",false))
                    {
                        UserCanEdit = false;
                    }
                    refersText1.TotalRefers = true;
                    refersText1.LoadRefer(_ReferCode);
                    jRefersTextRTB1.LoadRefer(_ReferCode);
                    DataTable DT = Automation.JARefers.GetRefersByObjectCode((new Automation.JARefer(_ReferCode)).object_code);
                    BuildingTree(_ReferCode, DT, "Code", "parent_code", _ReferCode, BuildingTreeUP(DT, "Code", "parent_code", _ReferCode));

                    Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
                    if (jaRefer != null)
                    {
                        if (!UserCanEdit) btnSave.Enabled = false;
                        if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
                            || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent)
                        {
                            btnRefer.Enabled = false;
                        }
                    }
					if (!UserCanEdit || !btnRefer.Enabled)
                    {
                        ShowLetterInfo();
                    }


                }

            }

            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally { }
        }

        private void ShowLetterInfo()
        {
            JCLetter jcLetter = new JCLetter(_Code);
			txtContent.ClearText();
            txtContent.Text = ConvertContentToSignLetter(jcLetter);

			
            jRefersTextRTB1.LoadRefer(_ReferCode);
            WriteInLetter(18, Color.Red, false, RN(1) + "ارجاعات:" + RN(1));
            txtContent.InsertRTFFooter(jRefersTextRTB1.Rtf);
            txtContent.Visible = true;
            // Set Letter Images
            txtContent.MoveIndexTo(txtContent.FindText("[IMAGES]"), 8);
            JArchiveDocument jArchiveDocument = new JArchiveDocument();
            jArchiveDocument.GetData(jcLetter.ImageCode);
			if (chbAllAttachment.Checked)
			{
				foreach (int item in jArchiveDocument.GetArchivesCodes(_ConstClassName, _Code))
				{
					JFile f =jArchiveDocument.RetrieveContent(item);
					txtContent.InsertImage(System.Drawing.Image.FromStream(f.Stream));
                    txtContent.InsertText("\r\n");
				}
			}
			else
			{
				txtContent.InsertImage(jArchiveImage1.Image);
			}
            txtContent.ChangeToViewMode();

            // \\\\\\\\\\\\\\\\\\

            jArchiveImage1.Hide();
            pnlLetterInfo.Hide();
            refersText1.Hide();
        }

        private void InLetterForm_Load(object sender, EventArgs e)
        {
            txtYear.Text = (new System.Globalization.PersianCalendar()).GetYear(JDateTime.Now()).ToString();
            _SetForm();
            if (_Code > 0)
            {
                jArchiveList1.ClassName = _ConstClassName;
                jArchiveList1.ObjectCode = _Code;
                jArchiveList1.AutomationReferCode = _ReferCode;
                btnReply.Enabled = true;
                btnExportReplay.Enabled = true;
            }
            txtYear.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            if (_Code > 0)
            {
                btnReply.Enabled = true;
                btnExportReplay.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
                SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute);
            Refer();
            if (_ReferCode > 0) ShowLetterInfo();
        }
        private void Refer()
        {
            JCLetter Letter = new JCLetter();

            DataTable _DT = Letter.GetData(_Code);
            if (_DT.Rows.Count == 1)
            {
                string _PostCode = Letter.receiver_post_code.ToString();
                foreach (DataRow _row in Letter.LetterCopies.Rows)
                {
                    _PostCode = _PostCode + ";" + _row["receiver_post_code"];
                }

                _DT.Columns.Add("recivers");
                _DT.Rows[0]["recivers"] = _PostCode;

                _DT.Columns.Add("CurrentPostCode");
                _DT.Rows[0]["CurrentPostCode"] = JMainFrame.CurrentPostCode;

                Automation.Refer.frmRecieverSelector frmrs =
                    new Automation.Refer.frmRecieverSelector
                        (_DT, null, "Communication.JCImportedLetter", 0, _Code, "نامه وارده", _ReferCode);
                if (frmrs.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    _ReferCode = frmrs.ReferCode;
                    //if (!UserCanEdit) 
					btnSave.Enabled = false;
                    btnRefer.Enabled = false;
                    jArchiveImage1.Visible = false;
                    txtContent.Visible = true;
                    refersText1.TotalRefers = true;
                    refersText1.LoadRefer(frmrs.ReferCode);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (btnSave.Enabled == false || SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute))
            {

                JCLetter Letter = new JCLetter();
                DataTable _DT = Letter.GetDataForPrint(_Code);
                txtContent.Text = Letter.LetterText;
                txtContent.Visible = true;
                // Set Letter Images
                int pos = txtContent.FindText("[IMAGES]");
                if (pos > 0)
                {
                    try { txtContent.MoveIndexTo(pos, 8); }
                    catch { }
                    txtContent.InsertText("تصاویر نامه وارده بپیوست نامه می باشد.");
                }

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
                JDynamicReportForm jDynamicReportForm = new JDynamicReportForm(JReportDesignCodes.OfficeLetter.GetHashCode());
                jDynamicReportForm.Add(_DT);

                jDynamicReportForm.ShowDialog();
            }
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            this.Close();
            (new JImportedLetterForm(0,0, _Code)).ShowDialog();
        }

        private void btnPrintLetter_Click(object sender, EventArgs e)
        {
            txtContent.Print();
        }

        private void btnWordPad_Click(object sender, EventArgs e)
        {
            txtContent.WordPad();
        }

        private void txtIncomingLetterNo_Enter(object sender, EventArgs e)
        {

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

		private void txtLetterNo_MouseClick(object sender, MouseEventArgs e)
		{

		}

		private void chbAllAttachment_CheckedChanged(object sender, EventArgs e)
		{
			if (!UserCanEdit || !btnRefer.Enabled)
			{
				ShowLetterInfo();
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

        private void btnExportReplay_Click(object sender, EventArgs e)
        {
            this.Close();
            (new JExportedLetterForm(0, 0, _Code)).ShowDialog();
        }

        private void btnParentLetter_Click(object sender, EventArgs e)
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
