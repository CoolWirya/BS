using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Globals
{
    public partial class JReportNameForm : JBaseForm
    {
        public JReportNameForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// عنوان گزارش 
        /// </summary>
        public string NReprot;

        private void Save_Click(object sender, EventArgs e)
        {
            NReprot = txtNameReport.Text;
            Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
