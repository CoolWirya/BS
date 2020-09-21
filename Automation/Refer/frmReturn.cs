using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace Automation
{
    public partial class JfrmReturn : Globals.JBaseForm
    {
        private int _ReferCode;

        public JfrmReturn()
        {
            InitializeComponent();
        }

        public JfrmReturn(int pReferCode)
        {
            InitializeComponent();
            _ReferCode = pReferCode;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            JARefer tmp = new JARefer(_ReferCode);
            tmp.ReturnRefer(_ReferCode);
            this.Close();
        }

        private void JfrmReturn_Load(object sender, EventArgs e)
        {
            JARefer tmp = new JARefer(_ReferCode);
            lblReceiver.Text = tmp.sender_full_title;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
