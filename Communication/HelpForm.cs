using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Communication
{
    public partial class JHelpForm : JBaseForm
    {
        public JHelpForm()
        {
            InitializeComponent();
            ArchiveList.ClassName = "Communication.JHelpForm";
            ArchiveList.SubjectCode = 0;
            ArchiveList.PlaceCode = 0;
            ArchiveList.ObjectCode = 1;
        }

        public void CheckPermission()
        {
            if (JPermission.CheckPermission("Communication.JHelpForm.Insert",false))
                btnSave.Visible = true;
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            CheckPermission();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ArchiveList.ArchiveList();
        }
    }
}
