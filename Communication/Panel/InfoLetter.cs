using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication
{
    public partial class JInfoLetter : UserControl
    {

        public JInfoLetter()
        {
            InitializeComponent();
        }

        private void JInfoLetter_Load(object sender, EventArgs e)
        {
            
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
                JCLetterRegisterImport LRI = new JCLetterRegisterImport(pLetterCode);
                //------------------رونوشت ---------------
                JCLetterCopys JLC = new JCLetterCopys();
                DataTable dtCopy = JLC.GetCopys(pLetterCode);
                foreach (DataRow dr in dtCopy.Rows)
                    lblCopy.Text = lblCopy.Text + dr["receiver_full_title"] + " , ";
                //------------------ پر کردن اطلاعات فرستنده گیرنده بر اساس نوع نامه -----------------------------------------
                lblSender.Text = LRI.sender_full_title;
                lblReceiver.Text = LRI.receiver_full_title;

                //if (LRI.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                //{
                //    lblSender.Text = LRI.sender_full_title;
                //    lblReceiver.Text = LRI.receiver_full_title;

                //}
                ////----------------------------------
                //if (LRI.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                //{
                //    lblSender.Text = LRI.sender_full_title;
                //    lblReceiver.Text = LRI.receiver_full_title;
                //}
                ////----------------------------------
                //if (LRI.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                //{
                //    if ((new JAllPerson(LRI.sender_external_code)).Code != 0)
                //    {
                //        JAllPerson OrganTemp = new JAllPerson(LRI.sender_external_code);
                //        cdbSender.SetValue(OrganTemp.Code);
                //    }
                //    cdbReceiver.SetValue((new Employment.JEOrganizationChart(LRI.receiver_post_code)).AccessCode);
                //}
                //------------------------------------------------------------------------------------------------------------
                ArchivedDocuments.JSubjectTree sub = new ArchivedDocuments.JSubjectTree();
                DataTable dt= sub.GetSubjectList(LRI.subject_code);
                if(dt.Rows.Count >0)
                    lblSubject.Text = dt.Rows[0][1].ToString();
                lblpre_subject.Text = LRI.pre_subject;
                lblAppendixLetter.Text = LRI.appendix;
                lblSummary.Text = LRI.summary;
                //txtLetterImportLetterNo.Text = LRI.incoming_no;
                //dteLetterImportDate.Text = (JDateTime.FarsiDate(LRI.incoming_date));
                //txtSignatured.Text = LRI.incoming_signature_person;
                //_SecretariatCode = LRI.secretariat_code;

                //cmbReceiveType.SelectedValue = LRI.receiver_type;
                //cmbSendType.SelectedValue = LRI.send_type;

                if (ClassLibrary.Domains.JGlobal.JUrgency.Normal == LRI.urgency)
                    lblUrgency.Text = "عادی";
                else if (ClassLibrary.Domains.JGlobal.JUrgency.Quick == LRI.urgency)
                    lblUrgency.Text = "سریع";
                else if (ClassLibrary.Domains.JGlobal.JUrgency.VeryQuick == LRI.urgency)
                    lblUrgency.Text = "خیلی سریع";

                if (ClassLibrary.Domains.JGlobal.JPrivacy.Normal == LRI.secret_level)
                    lblSecurityLevel.Text = "عادی";
                else if (ClassLibrary.Domains.JGlobal.JPrivacy.Secure == LRI.secret_level)
                    lblSecurityLevel.Text = "محرمانه";
                else if (ClassLibrary.Domains.JGlobal.JPrivacy.VerySecure == LRI.secret_level)
                    lblSecurityLevel.Text = "سری";

                lblLetterNo.Text = LRI.letter_no;
                //_letter_status = LRI.letter_status;
                //_LetterType = LRI.letter_type;

                //----------------------------------درخت ارجاعات -------------------------------------------------------
                //juC_ReferHistory.SetData(pLetterCode, ClassLibrary.Domains.JAutomation.JObjectType.Letters);

            }
            catch (Exception ex)
            {
                //JBase.Except.AddException(ex);
            }
        }
    }
}
