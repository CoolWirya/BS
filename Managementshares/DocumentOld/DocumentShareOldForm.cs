using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
namespace ManagementShares
{
    public partial class JDocumentShareOldForm : JBaseForm
    {
        int _CompanyCode;
        int _Code;

        public JDocumentShareOldForm(int pCompanyCode)
        {
            InitializeComponent();
            jArchiveList1.ClassName = "ManagementShares.JDocumentShareOldForm";
            jArchiveList1.SubjectCode = 0;
            _CompanyCode = pCompanyCode;
        }

        private void Set_Form()
        {
            JDocumentShareOld tmpJJobTitle = new JDocumentShareOld(_Code);
            jucPerson1.SelectedCode = tmpJJobTitle.PCode;
            txtDescription.Text = tmpJJobTitle.Description;
            _CompanyCode = tmpJJobTitle.CompanyCode;
        }

        public JDocumentShareOldForm(int pCode, int pCompanyCode)
        {
            InitializeComponent();            
            jArchiveList1.ClassName = "ManagementShares.JDocumentShareOldForm";
            jArchiveList1.SubjectCode = 0;
            jArchiveList1.ObjectCode = pCode;
            _CompanyCode = pCompanyCode;
            _Code = pCode;
        }

        private void btnSabt_Click(object sender, EventArgs e)
        {
            try
            {
                JDocumentShareOld tmpDoc = new JDocumentShareOld();
                tmpDoc.PCode = Convert.ToInt32(jucPerson1.SelectedCode);
                tmpDoc.Description = txtDescription.Text;
                tmpDoc.CompanyCode = _CompanyCode;
                if (State == JFormState.Insert)
                {
                    tmpDoc.Code=tmpDoc.insert();
                    if (tmpDoc.Code > 0)
                    {
                        jArchiveList1.ObjectCode = tmpDoc.Code;
                        jArchiveList1.ArchiveList();

                        JMessages.Message("Insert Successfuly", "", JMessageType.Information);
                    }
                    else
                        JMessages.Message("Insert Not Successfuly", "", JMessageType.Error);
                }
                else
                {
                    tmpDoc.Code = _Code;
                    if (tmpDoc.Update(_CompanyCode))
                    {
                        jArchiveList1.ArchiveList();
                        JMessages.Message("Update Successfuly", "", JMessageType.Information);
                    }
                    else
                        JMessages.Message("Update Not Successfuly", "", JMessageType.Error);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JDocumentShareOldForm_Load(object sender, EventArgs e)
        {
            if (_Code > 0)
                Set_Form();
        }
    }
}
