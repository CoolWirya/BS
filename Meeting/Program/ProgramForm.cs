using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;


namespace Meeting
{
    public partial class JProgramForm : ClassLibrary.JBaseForm
    {
        public string _Desc
        {
            get;
            set;
        }
        public JProgram tmpProg;
        private int _Code;

        public JProgramForm()
        {
            InitializeComponent();
        }

        public JProgramForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            tmpProg = new JProgram();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Desc = txtDesc.Text.Trim();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JProgramForm_Load(object sender, EventArgs e)
        {
            txtDesc.Text = _Desc;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
