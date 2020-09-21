using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Automation;

namespace Communication
{
    public partial class JfrmMinuteList : Globals.JBaseForm
    {
        private int _register_post_code;
        private int _register_user_code;
        public int Code;
        private int _frmState;
        private int _Letter_Type;

        public JfrmMinuteList(int pRegister_user_code, int pRegister_post_code, int pFrmState,int pLetter_Type)
        {
            InitializeComponent();
            _register_post_code = pRegister_post_code;
            _register_user_code = pRegister_user_code;
            _frmState = pFrmState;
            _Letter_Type = pLetter_Type;
        }

        private void JfrmMinuteList_Load(object sender, EventArgs e)
        {
            JCLetterRegister tmpJCLetterRegister = new JCLetterRegister(0);
            dgMinute.Bind(tmpJCLetterRegister.FindMinute(JMainFrame.CurrentUserCode, JMainFrame.CurrentPostCode,_Letter_Type), "Minute");
            if (_frmState == ClassLibrary.Domains.JGlobal.JfrmState.Refer)
                btnRefer.Visible = true;
            else
                btnConfirm.Visible = true;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Code = Convert.ToInt32(dgMinute.SelectedRow.Cells["Code"].Value.ToString());
            this.Close();
        }

        private void btnRefer_Click(object sender, EventArgs e)
        {
            int _LetterCode = Convert.ToInt32(dgMinute.SelectedRow.Cells["Code"].ToString());
          if (_LetterCode != 0)
             {
                JCLetterRegister tmp = new JCLetterRegister(_LetterCode);
                //int id=tmp.FirstSend();
                //if (id > 0)
                //    {
                //        //JReferMain p = new JReferMain(0, id , true,null,true);
                //        //if (p.ShowDialog() == DialogResult.OK)
                //        //{
                //        //    JMessages.Message("Refer Successfully", "", JMessageType.Information);
                //        //    this.Dispose();
                //        //}
                //    }
                //else
                //    JMessages.Message("Error", "", JMessageType.Error);
             }
            else
                JMessages.Message("Please Selected Minute", "", JMessageType.Information);

            //JDataBase db = JGlobal.MainFrame.GetDBO();
            //JCLetterRegister tmp=new JCLetterRegister(Convert.ToInt32(dgMinute.SelectedRow["Code"].ToString()));
            //int object_Code=tmp.SendToAutomation(Convert.ToInt32(dgMinute.SelectedRow["Code"].ToString()),);
            //JReferMain p = new JReferMain(0,object_Code);
            //p.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
