﻿using System;
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
    public partial class JEmployeeForm : JBaseForm
    {
        public JEmployeeForm()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPersonelNo.Text.Length == 0)
                return;
        }
    }
}