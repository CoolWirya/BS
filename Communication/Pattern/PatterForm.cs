using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication
{
    public partial class JPatterForm : Form
    {
        public JPatterForm()
        {
            InitializeComponent();
            jLetterPattern LP = new jLetterPattern();
            LP.Get();
            jEditorDataTable1.SetRTF(LP.Pattern);
            jEditorDataTable1.AddTable(LP.GetStructLetter());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            jLetterPattern LP = new jLetterPattern();
            LP.Get();
            LP.Pattern = jEditorDataTable1.GetRTF();
            LP.Save();
        }
    }
}
