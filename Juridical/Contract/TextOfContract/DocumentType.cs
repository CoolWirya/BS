using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JDocumentTypeForm : JBaseContractForm
    {
        int _Code;

        public JDocumentTypeForm()
        {
            InitializeComponent();
        }

        public JDocumentTypeForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            /// مقداردهی پراپرتی های لیست 
            jDefinePropertyUserControl1.ClassName = "Legal.JDocumentType";
            jDefinePropertyUserControl1.ObjectCode = _Code;
            Set_Form();
        }

        #region "Events"

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JBaseContractForm.JStateContractForm.Update;
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (MessageBox.Show("DoYouWantToSaveChanges", "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    if (Save())
                        this.Close();
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    this.Close();
            }
            else
                this.Close();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        #endregion

        #region Methods

        private void Set_Form()
        {
            JDocumentType tmp = new JDocumentType(_Code);
            txtTitle.Text = tmp.Title;
            jDefinePropertyUserControl1.ObjectCode = tmp.Code;
        }

        private bool Save()
        {
            JDocumentType tmp = new JDocumentType();
            tmp.Title = txtTitle.Text;            
            if (State != JStateContractForm.Update)
            {      
                if (tmp.Insert() > 0)
                {
                    /// مقداردهی پراپرتی های لیست 
                    jDefinePropertyUserControl1.ObjectCode = tmp.Code;
                    jDefinePropertyUserControl1.AcceptChanges();
                    return true;
                }
                else
                    return false;
            }
            else
            {
                tmp.Code = _Code;
                if (tmp.Update())
                {
                    
                    jDefinePropertyUserControl1.AcceptChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        #endregion

        private void JDocumentTypeForm_Load(object sender, EventArgs e)
        {
            jDefinePropertyUserControl1.ClassName = "Legal.JDocumentType";
        }
    }
}
