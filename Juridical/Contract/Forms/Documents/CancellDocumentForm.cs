using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal.Contract.Forms.Documents
{
    public struct CancellDocument
    {
        public int CancellType;
        public string CancellDesc;
        public int Code;
    }
    public partial class JCancellDocumentForm : ClassLibrary.JBaseForm
    {

        public CancellDocument CancellDocument = new CancellDocument();
        int DocCode = 0;
        public JCancellDocumentForm(int pDocCode)
        {
            InitializeComponent();
            DocCode = pDocCode;
            _LoadFill();
        }

        public void _LoadFill()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select Code,Descrition from trs_view_cancellation order by code");
                DataTable DT = DB.Query_DataTable();
                cmbCancellType.DataSource = DT;
                cmbCancellType.DisplayMember = "Descrition";
                cmbCancellType.ValueMember = "Code";
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
        }

        public void Save()
        {
            CancellDocument.CancellDesc = txtDesc.Text;
            CancellDocument.CancellType = (int)cmbCancellType.SelectedValue;
            CancellDocument.Code = DocCode;
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
