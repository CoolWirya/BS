using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ArchivedDocuments
{
    public partial class JSubjectEditForm : JBaseForm 
    {
        public JSubjectEditForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtAccessCode.Text == "")
            {
                JMessages.Message("Enter AccessCode", "", JMessageType.Information);
                return;
            }
            if (txtTitle.Text == "")
            {
                JMessages.Message("Enter Title", "", JMessageType.Information);
                return;
            }
            
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
