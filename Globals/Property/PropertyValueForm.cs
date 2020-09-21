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
    public partial class JPropertyValueForm : ClassLibrary.JBaseForm
    {
        public JPropertyValueForm(string ClassName, int ObjectCode, int ValueObjectCode)
        {
            InitializeComponent();
            jPropertyValueUserControl1.isMultiple = true;

            jPropertyValueUserControl1.ClassName = ClassName;
            jPropertyValueUserControl1.ObjectCode = ObjectCode;
            jPropertyValueUserControl1.ValueObjectCode = ValueObjectCode;
        }

        public JPropertyValueForm(string ClassName, int ObjectCode, int ValueObjectCode, int TableCode)
        {
            InitializeComponent();
            jPropertyValueUserControl1.isMultiple = true;

            jPropertyValueUserControl1.TableCode = TableCode;
            jPropertyValueUserControl1.ClassName = ClassName;
            jPropertyValueUserControl1.ObjectCode = ObjectCode;
            jPropertyValueUserControl1.ValueObjectCode = ValueObjectCode;
        }

        private void PropertyValueForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            jPropertyValueUserControl1.Save();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
