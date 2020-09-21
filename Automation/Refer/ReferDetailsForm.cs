using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation.Refer
{
    public partial class JAReferDetailsForm : JBaseForm
    {
        int _ReferCode;
        public JAReferDetailsForm(int ReferCode)
        {
            InitializeComponent();
            _ReferCode = ReferCode;
        }

        private void ReferDetailsForm_Load(object sender, EventArgs e)
        {
            JARefer jaRefer = new JARefer(_ReferCode);
            lblReferCode.Text = "شماره ارجاع: " + jaRefer.Code.ToString();
            lblSender.Text = "از: " + jaRefer.sender_full_title;
            lblReciever.Text = "به: " + jaRefer.receiver_full_title;
            lblDate.Text = "تاریخ: " + JDateTime.FarsiDate(jaRefer.send_date_time) + " " + jaRefer.send_date_time.Hour.ToString("00") + ":" + jaRefer.send_date_time.Minute.ToString() + ":" + jaRefer.send_date_time.Second.ToString();
            jEditor1.InsertText(jaRefer.description);
            jEditor1.ChangeToViewMode();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
