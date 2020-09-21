using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AUTOMOBILE.Controls
{
    public partial class JPlaqueControl : UserControl
    {
        public JPlaqueControl()
        {
            InitializeComponent();
        }

        private void txtPlak1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar >= '0' && e.KeyChar <= '9')
              
        }

        private void txtPlak2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPlak1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).TextLength == 2)
                txtPlak2.Focus();
        }

        private void txtPlak2_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).TextLength == 3)
                txtPlak3.Focus();
        }
    }
}
