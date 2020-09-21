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
    public partial class JDefineForm : JBaseForm
    {
        public string _ClassName;
        public JDefineForm(string className)
        {
            InitializeComponent();
            _ClassName = "Forms." + className;
            SetForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetForm()
        {
            jDataGrid1.DataSource = (new JProperty()).GetDataTable(_ClassName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            (new JDefinePropertyForm(_ClassName, (new JProperty()).GetFreeObjectCode(_ClassName))).ShowDialog();
            SetForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (jDataGrid1.SelectedRows.Count > 0)
                (new JDefinePropertyForm(_ClassName, Convert.ToInt32(jDataGrid1.SelectedRows[0].Cells[0].Value))).ShowDialog();
            SetForm();
        }
    }
}
