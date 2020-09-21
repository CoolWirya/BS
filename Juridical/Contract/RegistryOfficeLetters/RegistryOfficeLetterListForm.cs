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
    public partial class JRegistryOfficeLetterListForm : JBaseForm
    {
        public int ContractCode;
        public JRegistryOfficeLetterListForm(int pContractCode)
        {
            InitializeComponent();
            ContractCode = pContractCode;
            SetForm();
        }
        private void SetForm()
        {
            grdLetter.DataSource = JRegistryOfficeLetters.GetList(ContractCode);
            grdLetter.Columns["Code"].Visible = false;
            grdLetter.Columns["ContractCode"].Visible = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            JRegistryOfficeLetterForm letterForm = new JRegistryOfficeLetterForm(0, ContractCode);
            letterForm.ShowDialog();
            SetForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdLetter.DataSource == null)
                return;

            if (grdLetter.Rows.Count == 0)
                return;
            int code = Convert.ToInt32(grdLetter.CurrentRow.Cells["Code"].Value);
            JRegistryOfficeLetterForm letterForm = new JRegistryOfficeLetterForm(code, ContractCode);
            letterForm.ShowDialog();
            SetForm();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grdLetter.DataSource == null)
                return;

            if (grdLetter.Rows.Count == 0)
                return;
            if (grdLetter.SelectedRows == null)
            {
                JMessages.Error("ردیفی انتخاب نشده است","");
                return;
            }
            if (JMessages.Question("آیا می خواهید ردیف مورد نظر حذف شود؟", "حذف؟") == DialogResult.Yes)
            {
                int code = Convert.ToInt32(grdLetter.CurrentRow.Cells["Code"].Value);
                JRegistryOfficeLetter letter = new JRegistryOfficeLetter(code);
                if (letter.Delete())
                    SetForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

    }
}
