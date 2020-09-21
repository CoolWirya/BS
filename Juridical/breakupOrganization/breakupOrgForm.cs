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
    public partial class JbreakupOrgForm : JBaseForm
    {

        int _Code;

        public JbreakupOrgForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            ArchiveListBreakup.ClassName = "Legal.JbreakupOrg";
            ArchiveListBreakup.SubjectCode = 0;
            ArchiveListBreakup.PlaceCode = 0;
        }
        public JbreakupOrgForm(int pCode, int pOrgCode)
        {
            InitializeComponent();
            _Code = pCode;
            if (pCode != 0)
                Set_Form();
            else
                jucPerson1.SelectedCode = pOrgCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            ArchiveListBreakup.ClassName = "Legal.JbreakupOrg";
            ArchiveListBreakup.SubjectCode = 0;
            ArchiveListBreakup.PlaceCode = 0;
            ArchiveListBreakup.ObjectCode = _Code;
        }

        private void Set_Form()
        {
            JbreakupOrg tmpbreakupOrg = new JbreakupOrg(_Code);
            jucPerson1.SelectedCode = tmpbreakupOrg.OrgCode;
            txtDate.Date = tmpbreakupOrg.Date;
            txtSubject.Text = tmpbreakupOrg.Description;
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (jucPerson1.SelectedCode == 0)
            {
                JMessages.Error(" لطفا شخص را انتخاب کنید ","");
                return;
            }
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error(" لطفا تاریخ را وارد کنید ", "");
                return;
            }
            JbreakupOrg tmpbreakupOrg = new JbreakupOrg();
            tmpbreakupOrg.OrgCode = jucPerson1.SelectedCode;
            tmpbreakupOrg.Date = txtDate.Date;
            tmpbreakupOrg.Description = txtSubject.Text;
            if (this.State == JFormState.Insert)
            {
                _Code = tmpbreakupOrg.Insert();
                ArchiveListBreakup.ObjectCode = _Code;
                ArchiveListBreakup.ArchiveList();
                if (_Code > 0)
                {
                    JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    State= JFormState.Update;
                    //return true;
                }
                else
                {
                    JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
                    //return false;
                }
            }
            else if (this.State == JFormState.Update)
            {
                if (tmpbreakupOrg.Update())
                {
                    ArchiveListBreakup.ObjectCode = _Code;
                    ArchiveListBreakup.ArchiveList();
                    JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                    //return true;
                }
                else
                {
                    JMessages.Message(" Update Not Successfuly ", "", JMessageType.Error);
                    //return false;
                }
            }
            //else
                //return false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
