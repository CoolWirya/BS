using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Globals
{
    public partial class JLoginUserForm : JBaseForm
    {
        public JLoginUserForm()
        {
            InitializeComponent();
        }

        private void LoginUserForm_Load(object sender, EventArgs e)
        {
            int _Code = 0;
            if (listBox1.SelectedValue != null)
            {
                _Code = (int)listBox1.SelectedValue;
            }
            DataTable DT = JUsers.GetLoginUserList();

            listBox1.DisplayMember = "Fam";
            listBox1.ValueMember = "Code";

            listBox1.DataSource = DT;

            if (_Code > 0)
            {
                listBox1.SelectedValue = _Code;
            }

        }
    }
}
