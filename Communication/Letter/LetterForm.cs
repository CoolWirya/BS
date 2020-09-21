using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;
using ClassLibrary;
using Communication.Letter;
using Employment;

namespace Communication
{
    public partial class JLetterForm : ClassLibrary.JBaseForm
    {
        int _Code;
        int _ReferCode;
        int _ParentCode;

        public const string _ConstClassName = "Communication.JCLetter";

        public JLetterForm()
            : this(0, 0)
        {
        }

        public JLetterForm(int pCode)
            : this(pCode, 0)
        {
        }

        public ClassLibrary.JEditorBase txtContent;

        public JLetterForm(int pCode, int pReferCode)
            : this(pCode, pReferCode, 0)
        {
        }

        public JLetterForm(int pCode, int pReferCode, int pParentCode)
        {
            InitializeComponent();
            _ParentCode = pParentCode;
            _Code = pCode;
            _ReferCode = pReferCode;
			jPropertyValueUserControl1.ClassName = "Communication.JLetterForm";
			jPropertyValueUserControl1.ObjectCode = 0;

            txtContent = new JEditorBase();
            txtContent.Parent = panel2;
            panel2.Controls.Add(txtContent);
            txtContent.Dock = DockStyle.Fill;
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
                if (jcLetter.isSigned)
                {
                    JMessages.Message("نامه امضا شده است و قابل تغییر نیست", "خطا", JMessageType.Error);
                    return true;
                }

                if (cmbSender.SelectedValue == null && cmbSender.SelectedValue.ToString().Trim().Length == 0)
                {
                    JMessages.Message("فرستنده انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                if (cmbReceiver.SelectedValue == null)
                {
                    JMessages.Message("گیرنده انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                if (txtSubject.Text.Trim().Length == 0)
                {
                    JMessages.Message("موضوع نامه انتخاب نشده است", "خطا", JMessageType.Error);
                    return false;
                }

                jcLetter.letter_type = ClassLibrary.Domains.JCommunication.JLetterType.Internal; // نامه داخلی
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
                jcLetter.receiver_post_code = Convert.ToInt32(cmbReceiver.SelectedValue);
                jcLetter.receiver_code = (new JEOrganizationChart(jcLetter.receiver_post_code)).user_code;
                jcLetter.receiver_full_title = (cmbReceiver.SelectedItem as DataRowView).Row["Full_Name"].ToString();
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
				jcLetter.LetterText = txtContent.Text;
				jcLetter.NormalLetterText = txtContent.GetNormalText();
                jcLetter.EditorType= txtContent.EditorType;

                if (_Code == 0)
                {
                    _Code = jcLetter.Insert();
                }
                else
                {
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

        /// <summary>
        /// تنظیم فرم
        /// </summary>
        private void _SetForm()
        {
            try
            {
                //  ---------------------- Set ComboBox Sender --------------------------
                cmbSender.DisplayMember = "Full_Title_Slim";
                cmbSender.ValueMember = "code";
                DataTable _dt = (new JEOrganizationChart()).GetParents(JMainFrame.CurrentPostCode);
                (_dt as JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
                cmbSender.DataSource = _dt;

                //  ---------------------- Set ComboBox Urgency --------------------------
                cmbUrgency.DisplayMember = "FarsiName";
                cmbUrgency.ValueMember = "value";
                cmbUrgency.DataSource = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
                cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;

                if (_Code > 0)
                {
                    JCLetter Letter = new JCLetter(_Code);

                    txtContent.EditorType = Letter.EditorType;
                    txtContent.Load();

                    jPropertyValueUserControl1.ValueObjectCode = _Code;
                    if (Letter.ParentCode > 0) _ParentCode = Letter.ParentCode;
                    cmbSender.SelectedValue = Letter.sender_post_code;
                    cmbReceiver.SelectedValue = Letter.receiver_post_code;
                    cmbUrgency.SelectedValue = Letter.urgency;
                    txtSubject.Text = Letter.subject;
                    txtContent.Text = Letter.LetterText;
                    txtLetterNo.Text = Letter.GetLetterNo();

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
                                FindRefer("Communication.JCLetter", _Code, 0);

                    if (_ReferCode != 0)
                    {
                        refersText1.TotalRefers = true;
                        refersText1.LoadRefer(_ReferCode);
                        jRefersTextRTB1.LoadRefer(_ReferCode);

                        DataTable DT = Automation.JARefers.GetRefersByObjectCode((new Automation.JARefer(_ReferCode)).object_code);
                        BuildingTree(_ReferCode, DT, "Code", "parent_code", _ReferCode, BuildingTreeUP(DT, "Code", "parent_code", _ReferCode));
                        //treeViewRefer.DataBindings.Add("Code", DT, "parent_code", true);

                        Automation.JARefer jaRefer = new Automation.JARefer(_ReferCode);
                        if (jaRefer.receiver_post_code != JMainFrame.CurrentPostCode
                            || jaRefer.status == ClassLibrary.Domains.JAutomation.JReferStatus.Sent
                            )
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
                            cmbReceiver.Text = ParentLetter.sender_full_title;
                        else
                            cmbReceiver.SelectedValue = ParentLetter.sender_post_code;
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

                                cmbSender.Enabled = false;
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

        private string GetFullDate(DateTime date)
        {
            return date.Hour.ToString("00") + ":" + date.Minute.ToString("00") + "  " + JDateTime.FarsiDate(date).Substring(2);
        }

        private void BuildingTree(int _ReferCode , DataTable dt, String Key, String Parent, int Root, TreeNode N)
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

        private TreeNode BuildingTreeUP( DataTable dt, String Key, String Parent, int Root)
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
                if (DRs.Length == 1  &&  DRs[0][Parent].ToString()!="0")
                {
                    TreeNode parent_node = BuildingTreeUP(dt, Key, Parent, (int)DRs[0][Parent]);
                    node = new TreeNode();
                    node.Collapse(false);
                    DataRow row = DRs[0];
                    node.Text = row["sender_full_title"].ToString() +"("+ GetFullDate((DateTime)row["send_date_time"]) +")"+
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

        private void SignStateSet(JCLetter Letter)
        {
            if (Letter.isSigned)
            {
                btnReply.Enabled = true;
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

        private void JLetterForm_Load(object sender, EventArgs e)
        {
            if (jArchiveList1 == null)
                jArchiveList1 = new ArchivedDocuments.JArchiveList();
            _SetForm();
            if (_Code > 0)
            {
                jArchiveList1.ClassName = _ConstClassName;
                jArchiveList1.ObjectCode = _Code;
                jArchiveList1.AutomationReferCode = _ReferCode;
                jArchiveList1.LoadList();
            }
            else
            {
                cmbReceiver.Text = "";
            }

        }

        private void SetLetterInfo()
        {
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

        public static string Tab(int Count)
        {
            string ret = "";
            for (int i = 1; i <= Count; i++)
            {
                ret += "\t";
            }
            return ret;
        }

        public static string RN(int Count)
        {
            string ret = "";
            for (int i = 1; i <= Count; i++)
            {
                ret += "\r\n";
            }
            return ret;
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

        private bool ChectSettings(String pText)
        {
            string Value = WebClassLibrary.JWebSettings.GetKey("Communication.JLetterForm." +
        pText.Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\t", ""));
            if (Value == "0")
                return false;
            return true;
        }

        
        private string ConvertContectToSignLetter(JCLetter pLetter)
        {
            JEOrganizationChart jeOrgChart = new JEOrganizationChart(pLetter.sender_post_code);
            Font FontHeader = new System.Drawing.Font("B Titr", 13,FontStyle.Bold);
            Font FontFooter = new System.Drawing.Font("B Titr", 13, FontStyle.Bold);
            Font FontCopies = new System.Drawing.Font("B Roya", 14);
            //Header
            if (ChectSettings("احتراما"))
                WriteInLetter(FontHeader, true, RN(1) + "احتراما" + RN(1));
            if (ChectSettings("موضوع"))
                WriteInLetter(FontHeader, Color.Green, true, RN(1) + "موضوع : " + pLetter.subject + RN(1));
            if (ChectSettings("از"))
                WriteInLetter(FontHeader, Color.Blue, true, "از : ‏" + pLetter.sender_full_title + RN(1) + "به : " + pLetter.receiver_full_title);
            if (ChectSettings("شماره نامه"))
                WriteInLetter(FontHeader, Color.Blue, true, "شماره نامه : " + pLetter.GetLetterNo().ToString() + RN(1));

            //Footer
            if (ChectSettings("باتشکر"))
            {
                WriteInLetter(FontFooter, false, RN(1) + Tab(10) + "باتشکر");
                WriteInLetter(FontFooter, false, RN(1) + Tab(9) + jeOrgChart.Name + ' ' + jeOrgChart.Fam);
                WriteInLetter(FontFooter, false, RN(1) + Tab(9) + jeOrgChart.Job);
                string _Sdate = (pLetter.EditorType == 0) ? JDateTime.FarsiDate(pLetter.SignDate) : JDateTime.FarsiDateReverse(pLetter.SignDate);
                WriteInLetter(FontFooter, false, RN(1) + Tab(9) + _Sdate);
            }

            if (ChectSettings("رونوشت"))
            {
                WriteInLetter(FontHeader, Color.Red, false, RN(1) + "رونوشت : ");

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

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
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
                result = SaveAs(pStatus);
            else
                result = Save();
            if (result)
            {
                jArchiveList1.ClassName = _ConstClassName;
                jArchiveList1.ObjectCode = _Code;
                jArchiveList1.ArchiveList();

				jPropertyValueUserControl1.Save();
            }
            return result;
        }

        private void cmbSender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSender.SelectedValue == null) return;
            ////  ---------------------- Set ComboBox Receiver --------------------------
            cmbReceiver.DisplayMember = "Full_Title_Slim";
            cmbReceiver.ValueMember = "code";
            cmbCopyReceiver.DisplayMember = "Full_Title_Slim";
            cmbCopyReceiver.ValueMember = "code";
            JEOrganizationChart jeOrgChart = new JEOrganizationChart();
            DataTable dt;

            dt = jeOrgChart.GetChart(Convert.ToInt32(cmbSender.SelectedValue), 1);

            (dt as JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
            (dt as DataTable).DefaultView.Sort = "ParentCode";

            cmbReceiver.DataSource = dt;
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

        private void btnAddCopyReceiver_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow DRow in dgrCopies.Rows)
                {
                    if (DRow.Cells[0].Value.ToString() == cmbCopyReceiver.SelectedValue.ToString())
                    {
                        return;
                    }
                }

                dgrCopies.Rows.Add();
                int newRow = dgrCopies.Rows.Count - 1;
                dgrCopies.Rows[newRow].Cells[0].Value = cmbCopyReceiver.SelectedValue;
                dgrCopies.Rows[newRow].Cells[1].Value = (cmbCopyReceiver.SelectedItem as DataRowView).Row["Full_Name"].ToString();
                dgrCopies.Rows[newRow].Cells[2].Value = txtReason.Text;
                cmbSender.Enabled = false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

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
                Automation.Refer.frmRecieverSelector frmrs =
                    new Automation.Refer.frmRecieverSelector
                        (_DT, null, "Communication.JCLetter", 0, _Code, "نامه داخلی", _ReferCode);
                if (frmrs.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    _ReferCode = frmrs.ReferCode;
                    btnSave.Enabled = false;
                    //btnRefer.Enabled = false;
                    btnReply.Enabled = true;
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
                    //string oldTxt = txtContent.Text;
                    //ConvertContectToSignLetter(Letter);
                    //WriteInLetter(18, Color.Red, false, RN(1) + "ارجاعات:" + RN(1));
                    //txtContent.InsertRTFFooter(jRefersTextRTB1.Rtf);
                    _DT.Rows[0]["Full_Letter_Text"] = txtContent.Text;
                    _DT.Rows[0]["LetterCopies"] = letterCopies;
                    DateTime datetime = JDateTime.Now();
                    _DT.Rows[0]["PrintCode"] = datetime.Year.ToString("0000") + datetime.Month.ToString("00") + datetime.Day.ToString("00")
                        + datetime.Hour.ToString("00") + datetime.Minute.ToString("00") + datetime.Second.ToString("00")
                        + JMainFrame.CurrentPostCode.ToString("00000000000") + Letter.Code.ToString("00000000000");
                    //txtContent.Text = oldTxt;
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

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("از امضاء نامه مطمئن هستید؟", "امضا") == DialogResult.Yes)
            {
                if (SaveLetter(ClassLibrary.Domains.JCommunication.JLetterStatus.Minute))
                {
                    JCLetter jcLetter = new JCLetter(_Code);
                    if (!jcLetter.isSigned)
                    {
                        jcLetter.letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Accept;
                        jcLetter.isSigned = true;
                        jcLetter.SignDate = JDateTime.Now();
						jcLetter.LetterText = txtContent.Text;

                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                        int _Year;
                        _Year = pc.GetYear(jcLetter.SignDate);

                        //if (NoStorage.VerifyStorage(_ConstClassName, 0, _Year) == false)
                        //NoStorage.CreateNewNoStorage(_ConstClassName, 0, _Year);
                        NoStorage noStorage = new NoStorage(_ConstClassName, 0, _Year);

                        string S = jcLetter.SaveLetterNo(noStorage.GetNextNumber().ToString());
                        jcLetter.letter_no = S;

                        ConvertContectToSignLetter(jcLetter);

                        if (jcLetter.Update())
                        {
                            txtLetterNo.Text = jcLetter.GetLetterNo();

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
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            this.Close();
            (new JLetterForm(0, 0, _Code)).ShowDialog();
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
        private void JLetterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Shift && e.KeyCode == Keys.F10 && JMainFrame.CurrentPostCode == 1)
            {
            }
        }

        private void JLetterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtContent.Close();
        }
    }
}
