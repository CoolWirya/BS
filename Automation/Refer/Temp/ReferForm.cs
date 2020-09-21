using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation
{
    public partial class JAReferForm : JBaseForm
    {
        public JAReferForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GroupBox group1 = new GroupBox();
            group1.Name = "grpReciever" + pnlRecievers.Controls.Count.ToString();
            //group1.BorderStyle = BorderStyle.Fixed3D;
            group1.Dock = DockStyle.Top;
            group1.Height = grpReciever.Height;
            ///
            Label lbName = new Label();
            lbName.Name = "lb" + pnlRecievers.Controls.Count.ToString();
            lbName.Text = lbMainName.Text;
            lbName.Location = lbMainName.Location;
            lbName.AutoSize = true;
            group1.Controls.Add(lbName);
            ///
            Label lbPost = new Label();
            lbPost.Name = "lb" + pnlRecievers.Controls.Count.ToString();
            lbPost.Text = lbOPost.Text;
            lbPost.Location = lbOPost.Location;
            lbPost.AutoSize = true;
            group1.Controls.Add(lbPost); 
            ///
            Label lbref = new Label();
            lbref.Name = "lb" + pnlRecievers.Controls.Count.ToString();
            lbref.Text = lbReferType.Text;
            lbref.Location = lbReferType.Location;
            lbref.AutoSize = true;
            group1.Controls.Add(lbref);

            pnlRecievers.Controls.Add(group1);
        }
    }
}
