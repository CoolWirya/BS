using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Estates
{
    public partial class MessageUpdateGround :ClassLibrary.JBaseForm 
    {
        public MessageUpdateGround()
        {
            InitializeComponent();
        }

        private void MessageUpdateGround_Load(object sender, EventArgs e)
        {

        }
        public string dialogComment;

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            dialogComment = txtDesc.Text;
            
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
