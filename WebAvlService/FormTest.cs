using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebAvlService
{
	public partial class FormTest : Form
	{
		public FormTest()
		{
			InitializeComponent();
		}

		AvlService A;
		private void button1_Click(object sender, EventArgs e)
		{
			A = new AvlService();
			A.RunServices();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			A.Stop();
			A.Dispose();
		}
	}
}
