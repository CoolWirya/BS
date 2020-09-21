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
    public partial class JfrmSearchLetter : JBaseForm
    {
        public int _Code;

        public JfrmSearchLetter()
        {
            InitializeComponent();
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
                cdbSender.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, JMainFrame.GetActiveChartCode());
                //cdbSender.dataTable = (new JOrganizations()).GetOrganization(0);
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

                //cmbsecuritylevelRefer.DisplayMember = "Farsiname";
                //cmbsecuritylevelRefer.ValueMember = "value";
                //cmbsecuritylevelRefer.DataSource = dt;
                //cmbsecuritylevelRefer.SelectedValue = ClassLibrary.Domains.JGlobal.JPrivacy.Normal;

                //  ---------------------- Set ComboBox Urgency --------------------------
                dt = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
                cmbUrgencyLetter.DisplayMember = "Farsiname";
                cmbUrgencyLetter.ValueMember = "value";
                cmbUrgencyLetter.DataSource = dt;
                cmbUrgencyLetter.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JCLetterRegister tmp = new JCLetterRegister();
            if (cdbSender.SelectedItem != null)
                tmp.sender_post_code = Convert.ToInt32(cdbSender.SelectedItem.Row.ItemArray[0]);
            if (cdbReceiver.SelectedItem != null)
                tmp.receiver_post_code = Convert.ToInt32(cdbReceiver.SelectedItem.Row.ItemArray[0]);
            tmp.subject_code = Convert.ToInt32(cdbSubject.SelectedValue.ToString());
            tmp.pre_subject = txtSubjectMinute.Text.Trim();
            tmp.letter_no = txtLetterNo.Text.Trim();
            tmp.summary = txtKeyWords.Text.Trim();
            tmp.urgency = Convert.ToInt32(cmbUrgencyLetter.SelectedValue.ToString());
            tmp.secret_level = Convert.ToInt32(cmbSecurityLevel.SelectedValue.ToString());
            tmp.receiver_type = Convert.ToInt32(cmbReceiveType.SelectedValue.ToString());

            string Letter_Type = "";
            if ((chkExport.Checked) || (chkImport.Checked) || (chkInternal.Checked))
            {
                Letter_Type = "(0";
                if (chkInternal.Checked) Letter_Type = Letter_Type + ",3";
                if (chkImport.Checked) Letter_Type = Letter_Type + ",1";
                if (chkExport.Checked) Letter_Type = Letter_Type + ",2";
                Letter_Type = Letter_Type + ")";
            }
            
            DataTable dt = new DataTable();
            JCSearchLetter tmpJCSearchLetter = new JCSearchLetter();

            dt = tmpJCSearchLetter.SearchLetter1(tmp, Letter_Type);            
            if ((dt != null) && (dt.Rows.Count > 0))
            {
                JCLetterRegisterImport LRI = new JCLetterRegisterImport(0);
                jdgvSearch.DataSource = dt;
                jdgvSearch.bind(dt, "JanusSearchLetter", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
            }
            else
            {
                JMessages.Message(JLanguages._Text("Letter Not Found"), JLanguages._Text("Warning"), JMessageType.Warning);
                jdgvSearch.DataSource = null;
                jdgvSearch.Refresh();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cdbSender.SelectedValue = -1;
            cdbReceiver.SelectedValue = -1;
            cdbSender.SelectedValue = -1;
            txtSubjectMinute.Text = "";
            txtLetterNo.Text = "";
            txtKeyWords.Text = "";
        }

        private void jdgvSearch_OnRowDBClick(object Sender, RowActionEventArgs e)
        {
            if (e.Row.DataRow != null)
            {               
                //e.Row.DataRow    ClassLibrary.Domains.JCommunication.JLetterType.Import
                JfrmLetterRegister tmp = new JfrmLetterRegister(Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[15])
                    , JFormState.ReadOnly, Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row["Code"]), 0);
                tmp.ShowDialog();
            }
            else
                JMessages.Message("Please Selected Minute ", "", JMessageType.Information);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (jdgvSearch.gridEX1.CurrentRow != null)
                _Code = Convert.ToInt32(jdgvSearch.gridEX1.CurrentRow.Cells[0].Value.ToString());
            else
                _Code = 0;
            this.Close();
        }
    }
}
