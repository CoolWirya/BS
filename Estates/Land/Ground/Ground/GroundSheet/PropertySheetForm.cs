using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Estates
{
    public partial class JPropertySheetForm : JBaseForm
    {
        public JPropertySheetForm(int pCode)
        {
            InitializeComponent();
            jDefinePropertyUserControl1.ObjectCode = ClassLibrary.Domains.JGlobal.JPropertyType.SheetGround.GetHashCode(); 
            jDefinePropertyUserControl1.ClassName = "Estates.JSheetGroundForm";
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
