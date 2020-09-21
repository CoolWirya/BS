using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation
{
    public partial class JSendToExport : JBaseForm
    {
        int _LetterCode;

        public JSendToExport()
        {
            InitializeComponent();
        }

        public JSendToExport(int pLetterCode)
        {
            InitializeComponent();
            _LetterCode = pLetterCode;
        }

        private void SendToExport_Load(object sender, EventArgs e)
        {
            Communication.JCLetterRegister tmp = new Communication.JCLetterRegister(_LetterCode);
            if (tmp.letter_type != ClassLibrary.Domains.JCommunication.JLetterType.Export)
            {
                JMessages.Message("لطفا نامه صادره را انتخاب کنید", "", JMessageType.Warning);
                this.Close();
            }

            //-------------- ارجاعات داخل سازمانی ----------
            cmbPostTah.TitleFieldName = "full_title";
            cmbPostTah.AccessCodeFieldName = "accesscode";
            cmbPostTah.CodeFieldName = "code";
            cmbPostTah.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(JMainFrame.CurrentPostCode, "0", true);
            cmbPostTah.SetComboBox();

            //-------------- ارجاعات داخل سازمانی ----------
            cmbTahSender.TitleFieldName = "full_title";
            cmbTahSender.AccessCodeFieldName = "accesscode";
            cmbTahSender.CodeFieldName = "code";
            cmbTahSender.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(JMainFrame.CurrentPostCode, "0", true);
            cmbTahSender.SetComboBox();
            //-------------- ارجاعات داخل سازمانی ----------
            cmbFaxSender.TitleFieldName = "full_title";
            cmbFaxSender.AccessCodeFieldName = "accesscode";
            cmbFaxSender.CodeFieldName = "code";
            cmbFaxSender.dataTable = (new Employment.JEOrganizationChart()).GetOrgChart_User(JMainFrame.CurrentPostCode, "0", true);
            cmbFaxSender.SetComboBox();

            Fill();
        }

        private void Fill()
        {
            jdgvPost.DataSource = JSendExportInfo.GetDataTable(_LetterCode);
        }

        private void btnAddPost_Click(object sender, EventArgs e)
        {
            JSendExportInfo tmp = new JSendExportInfo();
            tmp.Type = ClassLibrary.Domains.JAutomation.JٍٍSendExportType.Post;
            tmp.LetterCode = _LetterCode;
            tmp.Description = "شماره قبض :" + txtGhabzNo.Text + "\n" + "تحویل دهنده:" + cmbPostTah.Text + "\n"
                + "باجه پستی:" + txtPostBaje.Text + "\n" + "شرح ارسال:" + txtPostDesc.Text + "\n" + "تاریخ:"
                + txtPostDate.Text.ToString() + "\n" + "مبلغ قبض :" + txtGhabzPrice.Text + "\n" 
                + "شرح ارسال:" + txtPostDesc.Text;
            tmp.Insert();
            Fill();
        }

        private void btnAddFax_Click(object sender, EventArgs e)
        {
            JSendExportInfo tmp = new JSendExportInfo();
            tmp.Type = ClassLibrary.Domains.JAutomation.JٍٍSendExportType.Fax;
            tmp.LetterCode = _LetterCode;
            tmp.Description = "شماره فکس:" + txtFaxNo.Text + "\n" + "تماس گیرنده:" + cmbFaxSender.Text + "\n"
                + "تاریخ:" + txtDateFax.Date.ToString() + "\n" + "ساعت:" + txtTimeFax.Text + "\n"
                + "شرح ارسال:" + txtDescFax.Text;
            tmp.Insert();
            Fill();
        }

        private void btnAddTah_Click(object sender, EventArgs e)
        {
            JSendExportInfo tmp = new JSendExportInfo();
            tmp.Type = ClassLibrary.Domains.JAutomation.JٍٍSendExportType.Delivery;
            tmp.LetterCode = _LetterCode;
            tmp.Description = "تحویل دهنده:" + cmbTahSender.Text + "\n" + "تحویل گیرنده:" + txtHozGir.Text + "\n"
                + "تاریخ:" + txtTahDate.Date.ToString() + "\n" + "ساعت:" + txtTahTime.Text + "\n" +
                "محل تحویل:" + txtHozMahal.Text + "\n"
                + "شرح ارسال:" + txtHozDesc.Text;
            tmp.Insert();
            Fill();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jdgvPost.CurrentRow != null)
            {
                JSendExportInfo tmp = new JSendExportInfo();
                tmp.Code = Convert.ToInt32(jdgvPost.CurrentRow.Cells[0].Value);
                tmp.Delete();
                Fill();
            }
        }

        private void jdgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (jdgvPost.CurrentRow != null)
            {
                rte.Text = jdgvPost.CurrentRow.Cells[2].Value.ToString();
            }
        }

    }
}
