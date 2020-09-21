using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JPropertyEmployeeForm : JBaseForm
    {
        public JPropertyEmployeeForm()
        {
            InitializeComponent();
            jDefinePropertyUserControl1.ObjectCode = 11;
            jDefinePropertyUserControl1.ClassName = "Employment.JEmployeeInfoForm";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (jDefinePropertyUserControl1.AcceptChanges())
                JMessages.Information("ویژگی های تعرفه ثبت شد.", "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
