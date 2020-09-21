using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Globals.Property
{
    public partial class JDefinePropertyForm : JBaseForm
    {
        public JDefinePropertyForm(string pClassName,int pObjectCode)
        {
            InitializeComponent();
            jDefinePropertyUserControl1.ClassName = pClassName;
            jDefinePropertyUserControl1.ObjectCode = pObjectCode;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            jDefinePropertyUserControl1.AcceptChanges();
            btnApply.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            jDefinePropertyUserControl1.AcceptChanges();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void jDefinePropertyUserControl1_AfterPropertyAdded(object Sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void jDefinePropertyUserControl1_AfterPropertyDeleted(object Sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }
    }
}
