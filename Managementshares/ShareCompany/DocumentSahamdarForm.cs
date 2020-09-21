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
    public partial class JDocumentSahamdarForm : ClassLibrary.JBaseForm
    {
        int _PCode;

        public JDocumentSahamdarForm(int pPCode)
        {
            InitializeComponent();
            jArchiveList1.ClassName = "ManagementShares.JDocumentSahamdarForm";
            jArchiveList1.ObjectCode = pPCode;
            jArchiveList1.SubjectCode = 0;
            _PCode = pPCode;
        }

        private void JDocumentSahamdarForm_Load(object sender, EventArgs e)
        {
            JPerson p = new JPerson(_PCode);
            label1.Text = p.Name + "  " + p.Fam;
        }

        private void JDocumentSahamdarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            jArchiveList1.ArchiveList();
        }
    }
}
