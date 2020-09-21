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
    public partial class JKaranehRangeForm : JBaseForm
    {
        int _Code;

        public JKaranehRangeForm()
        {
            InitializeComponent();
        }

        public JKaranehRangeForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
        }

        private void JKaranehRangeForm_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
            {
                JKaranehRange tmpJKaranehRange = new JKaranehRange(_Code);
                txtDate.Date = tmpJKaranehRange.kDate;
                txtTitle.Text = tmpJKaranehRange.title;
                txtDesc.Text = tmpJKaranehRange.description;
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {

        }
    }
}
