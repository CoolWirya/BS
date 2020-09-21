using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OfficeWord.Controls
{
    public partial class JTextControlForm : ClassLibrary.JBaseForm
    {

        public string ClassName;
        public int ObjectCode;

        public int FileCode
        {
            get
            {
                return textControl1.FileCode;
            }
        }

        public System.Data.DataTable DataTable
        {
            set
            {
                textControl1.AddTable(value);
            }
            get
            {
                return textControl1.datatable;
            }
        }

        public JTextControlForm(string pClassName, int pObjectCode)
        {
            InitializeComponent();
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            textControl1.Load(ClassName, ObjectCode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void Save()
        {
            try
            {
                ArchivedDocuments.JArchiveDataBase _DB = new ArchivedDocuments.JArchiveDataBase();
                textControl1.Save(_DB, ClassName, ObjectCode);
                if (textControl1.FileCode > 0)
                    OfficeWord.JOfficeWord.TagXml(textControl1.FileCode,
                        textControl1.XMLContent, textControl1.TextContent);

                _DB.Dispose();
            }catch
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JTextControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            textControl1.Close();
        }
    }
}
