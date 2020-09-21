using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArchivedDocuments
{
    public partial class JImageForm : ClassLibrary.JBaseForm
    {
        public Image SelectedImage;
        public ClassLibrary.JFile SelectedFile
        {
            get
            {
                try
                {
                    return SelectedFiles[jImageDialog1.CurrentIndex];
                }
                catch
                {
                    return null;
                }
            }
        }
        public ClassLibrary.JFile[] SelectedFiles;
        public JImageForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e )
        {
            SelectedImage = jImageDialog1.SelectedImage;
            SelectedFiles = jImageDialog1.SelectedFile;
            DialogResult = DialogResult.OK;
            jImageDialog1.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void JImageForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
                jImageDialog1.btnScan.PerformClick();
        }

        public void Free()
        {
            jImageDialog1.Free();
        }

    }
}
