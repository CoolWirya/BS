using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Janus.Windows.GridEX;

namespace Communication
{
    public partial class JfrmSearchLetters : JBaseForm
    {

        public int _Code;
        public int _Status_Form;
        int _SecretiatCode;

        public JfrmSearchLetters(int pState,int pSecretiatCode)
        {
            InitializeComponent();
            _Status_Form = pState;
            _SecretiatCode = pSecretiatCode;
        }

        private void JfrmSearchLetters_Load(object sender, EventArgs e)
        {
            _SetComboBoxs();
            _SetCmb();
        }

        /// <summary>
        /// تنظیم لیست های روی فرم
        /// </summary>
        private void _SetCmb()
        {
            try
            {
                //  ---------------------- Set ComboBox Sender --------------------------
                cdbSender.AccessCodeFieldName = "accesscode";
                cdbSender.TitleFieldName = "full_title";
                cdbSender.CodeFieldName = "code";
                cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
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
                cmbSecurityLevel.DisplayMember = "Farsiname";
                cmbSecurityLevel.ValueMember = "value";
                cmbSecurityLevel.DataSource = dt;
                cmbSecurityLevel.SelectedValue = ClassLibrary.Domains.JGlobal.JPrivacy.Normal;

                cmbsecuritylevelRefer.DisplayMember = "Farsiname";
                cmbsecuritylevelRefer.ValueMember = "value";
                cmbsecuritylevelRefer.DataSource = dt;
                cmbsecuritylevelRefer.SelectedValue = ClassLibrary.Domains.JGlobal.JPrivacy.Normal;

                //  ---------------------- Set ComboBox Urgency --------------------------
                dt = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
                cmbUrgency.DisplayMember = "Farsiname";
                cmbUrgency.ValueMember = "value";
                cmbUrgency.DataSource = dt;
                cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;

                cmbUrgencyLetter.DisplayMember = "Farsiname";
                cmbUrgencyLetter.ValueMember = "value";
                cmbUrgencyLetter.DataSource = dt;
                cmbUrgencyLetter.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;
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

        private void _SetComboBoxs()
        {
            //-------------- ارجاعات داخل سازمانی ----------
            cdbReferInternal.TitleFieldName = "full_title";
            cdbReferInternal.AccessCodeFieldName = "accesscode";
            cdbReferInternal.CodeFieldName = "code";
            cdbReferInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(JMainFrame.CurrentPostCode, "0",true);
            //cdbReferInternal.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationChartsUser(0, 5);
            cdbReferInternal.SetComboBox();
            //-------------- ارجاعات خارج از سازمان ---------------
            cdbReferExternal.TitleFieldName = "full_title";
            cdbReferExternal.AccessCodeFieldName = "accesscode";
            cdbReferExternal.CodeFieldName = "code";
            cdbReferExternal.dataTable = (new ClassLibrary.JOrganizations()).GetOrganization(0);
            cdbReferExternal.SetComboBox();
            //-------------- ارجاعات به شرکت های اقماری ---------------
            cdbReferSubsidiaries.TitleFieldName = "full_title";
            cdbReferSubsidiaries.AccessCodeFieldName = "access_code";
            cdbReferSubsidiaries.CodeFieldName = "code";
            cdbReferSubsidiaries.dataTable = (new Automation.JASubsidiariess()).GetAllSubsidiaries();
            cdbReferSubsidiaries.SetComboBox();
            //----------------- انواع ارسال برای گیرنده سازمان خارج از لیست-----------------
            cmbSendTypeExternal.DisplayMember = "Farsiname";
            cmbSendTypeExternal.ValueMember = "value";
            cmbSendTypeExternal.DataSource = ClassLibrary.Domains.JCommunication.JSendType.GetData();
            cmbSendTypeExternal.SelectedValue = ClassLibrary.Domains.JCommunication.JSendType.Email;
            //----------------- انواع ارسال برای گیرنده شرکت اقماری-----------------
            cmbSendTypeSubsidiaries.DisplayMember = "Farsiname";
            cmbSendTypeSubsidiaries.ValueMember = "value";
            cmbSendTypeSubsidiaries.DataSource = ClassLibrary.Domains.JCommunication.JSendType.GetData();
            cmbSendTypeSubsidiaries.SelectedValue = ClassLibrary.Domains.JCommunication.JSendType.Email;
        }

        private void tbClear_Click(object sender, EventArgs e)
        {
            txtAppindix.Text = "";
            txtIncomingNo.Text = "";
            txtKeyWords.Text = "";
            txtLetterImportLetterNo.Text = "";
            txtLetterNo.Text = "";
            txtSignatured.Text = "";
            txtSummary.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string RReceiver = String.Empty;
            string SendType = String.Empty;
            if ((cdbReferInternal.SelectedValue != null) && (cdbReferInternal.SelectedValue.ToString() != "-1"))
                RReceiver = cdbReferInternal.SelectedValue.ToString();
            else if ((cdbReferExternal.SelectedValue != null) && (cdbReferExternal.SelectedValue.ToString() != "-1"))
            {
                RReceiver = cdbReferExternal.SelectedValue.ToString();
                SendType = cmbSendTypeExternal.SelectedValue.ToString();
            }
            else if ((cdbReferSubsidiaries.SelectedValue != null) && (cdbReferSubsidiaries.SelectedValue.ToString() != "-1"))
            {
                RReceiver = cdbReferSubsidiaries.SelectedValue.ToString();
                SendType = cmbSendTypeSubsidiaries.SelectedValue.ToString();
            }
            DataTable dt = new DataTable();
            JCSearchLetter tmpJCSearchLetter = new JCSearchLetter();

            dt = tmpJCSearchLetter.SearchLetter(JMainFrame.CurrentUserCode.ToString(),
            txtLetterNo.Text, txtIncomingNo.Text, faDatePickerStartDate.Text, faDatePickerEndDate.Text,
            txtKeyWords.Text, RReceiver, SendType, cmbsecuritylevelRefer.SelectedValue.ToString(),
            cmbUrgency.SelectedValue.ToString(), faDatePickerStartDAteR.Text,
            faDatePickerEndDateR.Text,
            cdbSender.SelectedValue.ToString(), cdbReceiver.SelectedValue.ToString()
            , cdbSubject.SelectedValue.ToString(), txtSubjectMinute.Text,
            txtAppindix.Text, txtSummary.Text,
            txtLetterImportLetterNo.Text, txtSignatured.Text, dteLetterImportDate.Text,
            cmbSecurityLevel.SelectedValue.ToString(),
            cmbReceiveType.SelectedValue.ToString(), cmbUrgencyLetter.SelectedValue.ToString(), _Status_Form, _SecretiatCode);

            if ((dt != null) && (dt.Rows.Count > 0))
            {
                JCLetterRegisterImport LRI = new JCLetterRegisterImport(0);
                jdgvSearch.DataSource = dt;
                jdgvSearch.DataSource = dt;
                jdgvSearch.bind(dt, "Janus", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
            }
            else
                JMessages.Message(JLanguages._Text("Letter Not Found"), JLanguages._Text("Warning"), JMessageType.Warning);
        }

        //private string Search()
        //{
        //    string strsql = "";
        //    //Search Contain
        //    if (!String.IsNullOrEmpty(txtLetterNo.Text)) strsql = " And Letters.Letter_No=" + txtLetterNo.Text;
        //    if (!String.IsNullOrEmpty(txtIncomingNo.Text)) strsql = " And Letters.incoming_no=" + txtLetterNo.Text;
        //    //if (!String.IsNullOrEmpty(txtKeyWords.Text)) strsql = " And Letters.Letter_No=" + txtLetterNo.Text;
        //    //if (!String.IsNullOrEmpty(Date.Text)) strsql = " And Letters.Letter_No=" + txtLetterNo.Text;

        //    //Search Refer            
        //    //------------------- گیرنده ------------------------------------------
        //    if (cdbReferInternal.SelectedItem != null)
        //    {
        //        strsql = strsql + " And Refer.receiver_code=" + cdbReferInternal.SelectedItem["Code"].ToString();
        //    }
        //    else if (cdbReferExternal.SelectedItem != null)
        //    {
        //        strsql = strsql + " And Refer.receiver_code=" + cdbReferExternal.SelectedItem["Code"].ToString();
        //        if (cmbSendTypeExternal.SelectedItem != null)
        //            strsql = strsql + " And Letters.Send_type=" + Convert.ToString(cmbSendTypeExternal.SelectedValue);
        //    }
        //    else if (cdbReferSubsidiaries.SelectedItem != null)
        //    {
        //        strsql = strsql + " And Refer.receiver_code=" + cdbReferSubsidiaries.SelectedItem["Code"].ToString();
        //        if (cmbSendTypeSubsidiaries.SelectedItem != null)
        //            strsql = strsql + " And Letters.Send_type=" + cmbSendTypeSubsidiaries.SelectedValue.ToString();
        //    }

        //    if (cmbsecuritylevelRefer.SelectedItem != null)
        //        strsql = strsql + " And Refer.secret_level=" + cmbsecuritylevelRefer.SelectedValue.ToString();
        //    if (cmbUrgency.SelectedItem != null)
        //        strsql = strsql + " And Refer.urgency=" + cmbUrgency.SelectedValue.ToString();
        //    //Search Letters
        //    if (cdbSubject.SelectedItem != null)
        //        strsql = strsql + " And Letters.subject_code=" + cdbSubject.SelectedItem["Code"].ToString();
        //    if (!String.IsNullOrEmpty(txtAppindix.Text)) strsql = " And Letters.appendix=" + txtAppindix.Text;
        //    if (!String.IsNullOrEmpty(txtSummary.Text)) strsql = " And Letters.summary=" + txtSummary.Text;
        //    if (!String.IsNullOrEmpty(txtIncomingNo.Text)) strsql = " And Letters.incoming_no=" + txtIncomingNo.Text;
        //    if (!String.IsNullOrEmpty(dteLetterImportDate.Text)) strsql = " And Letters.incoming_date=" + dteLetterImportDate.Text;
        //    if (!String.IsNullOrEmpty(txtSignatured.Text)) strsql = " And Letters.incoming_signature_person=" + txtSignatured.Text;
        //    if (cmbSecurityLevel.SelectedItem != null)
        //        strsql = strsql + " And Letters.secret_level=" + cmbSecurityLevel.SelectedValue.ToString();
        //    if (cmbReceiveType.SelectedItem != null)
        //        strsql = strsql + " And Letters.receiver_type=" + cmbReceiveType.SelectedValue.ToString();
        //    if (cmbUrgencyLetter.SelectedItem != null)
        //        strsql = strsql + " And Letters.urgency=" + cmbUrgencyLetter.SelectedValue.ToString();
        //    if (cdbSender.SelectedItem != null)
        //        strsql = strsql + " And Refer.sender_code=" + cdbSender.SelectedItem["Code"].ToString();
        //    if (cdbReceiver.SelectedItem != null)
        //        strsql = strsql + " And Refer.receiver_code=" + cdbReceiver.SelectedItem["Code"].ToString();

        //    return strsql;
        //}

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (jdgvSearch.gridEX1.CurrentRow != null)
                _Code = Convert.ToInt32(jdgvSearch.gridEX1.CurrentRow.Cells[0].Value.ToString());
            else
                _Code = 0;
            this.Close();
        }

        private void jdgvSearch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void jdgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConfirm_Click(null, null);
        }
    }
}

