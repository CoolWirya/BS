using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Reflection;

namespace Automation
{
    public partial class JfrmDefineKartabl : JBaseForm
    {
        private int _Parent_code;
        private int _Code;
        private int _Folder_Type = (int)JAFolderTypeEnum.Inbox;
        public JfrmDefineKartabl(int pCode)
            : this(pCode, 0, 0)
        {
            _Code = pCode;
            if (_Code > 0)
                State = JFormState.Update;
            else
                State = JFormState.None;
        }
        public JfrmDefineKartabl(int pCode, int pParent_Code)
            : this(pCode, pParent_Code, 0)
        {
            _Code = pCode;
            _Parent_code = pParent_Code;
            if (_Code > 0)
                State = JFormState.Update;
            else
                State = JFormState.None;
        }
        public JfrmDefineKartabl(int Code, int Parent_code, int pFoderType)
        {
            InitializeComponent();
            _Parent_code = Parent_code;
            _Code = Code;
            if (pFoderType != 0)
                _Folder_Type = pFoderType;
            if (_Code == 0)
                State = JFormState.Insert;

            if (_Code > 0)
                State = JFormState.Update;

            Set_form();

        }

        private void Set_form()
        {

            cmbPosts.DisplayMember = "Full_Title_Slim";
            cmbPosts.ValueMember = "code";
            DataTable _dt = (new Employment.JEOrganizationChart()).GetParents(JMainFrame.CurrentPostCode);
            (_dt as JDataTable).Tidy("Full_Title", "Full_Title_Slim", 38);
            cmbPosts.DataSource = _dt;

			cmbObject.DisplayMember = "Text";
			cmbObject.ValueMember = "Code";
			cmbObject.DataSource = JObjects.GetDistinctObjects();



            if (_Code != 0)
            {
                JAFolder tmpFolder = new JAFolder();
                tmpFolder.GetData(_Code);
                txtKartablName.Text = tmpFolder.Name;
				txtObjectType.Text = tmpFolder.Subject;
				cmbPosts.SelectedValue = tmpFolder.Sender_User_post_code;
				cmbObject.SelectedValue = tmpFolder.Object_type;
			}

        }

        private void JDefineKartabl_Load(object sender, EventArgs e)
        {
            if (_Code <= 0)
                return;
            JAFolder tmpJKartabl = new JAFolder(_Code);
            txtKartablName.Text = tmpJKartabl.Name;
            _Parent_code = tmpJKartabl.parent_code;
            _Folder_Type = tmpJKartabl.FolderType;
            txtObjectType.Text = tmpJKartabl.Subject;
            chbDeleteFromKaratble.Checked = tmpJKartabl.DeleteFromKartable;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            JAFolder tmpJKartabl = new JAFolder();
            int code = 0;
            tmpJKartabl.Name = txtKartablName.Text;
            tmpJKartabl.parent_code = _Parent_code;
            tmpJKartabl.User_post_code = JMainFrame.CurrentPostCode;
            tmpJKartabl.Create_Date_Time = JMainFrame.GlobalDataBase.GetCurrentDateTime();
            tmpJKartabl.FolderType = _Folder_Type;
            tmpJKartabl.Subject = txtObjectType.Text;
            tmpJKartabl.DeleteFromKartable = chbDeleteFromKaratble.Checked;
            if (cmbPosts.Enabled && cmbPosts.SelectedValue != null)
                tmpJKartabl.Sender_User_post_code = (int)cmbPosts.SelectedValue;
            else
                tmpJKartabl.Sender_User_post_code = 0;

			if (cmbObject.Enabled && cmbObject.SelectedValue != null)
				tmpJKartabl.Object_type = (string)cmbObject.SelectedValue;
			else
				tmpJKartabl.Object_type = "";


            if (State == JFormState.Insert)
            {
                code = tmpJKartabl.Insert();
                if (code > 0)
                {
                    JMessages.Message("Register Successfully", "Kartabl", JMessageType.Information);
                    this.Dispose();
                }
                else
                    JMessages.Message("Register Not Successfully", "Kartabl", JMessageType.Information);
            }
            else if (State == JFormState.Update)
            {
                tmpJKartabl.Code = _Code;
                try
                {
                    if (tmpJKartabl.Update())
                    {
                        JMessages.Message("Update Successfully", "Kartabl", JMessageType.Information);
                        this.Dispose();
                    }
                    else
                    {
                        JMessages.Message("Update Not Successfully", "Kartabl", JMessageType.Information);
                    }
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    JMessages.Message("Update Not Successfully", "Kartabl", JMessageType.Information);

                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void chkPosts_CheckedChanged(object sender, EventArgs e)
		{
			cmbPosts.Enabled = chkPosts.Checked;
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void chkObject_CheckedChanged(object sender, EventArgs e)
		{
			cmbObject.Enabled = chkObject.Checked;
		}

    }
}
