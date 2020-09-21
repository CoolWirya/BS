using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Globals.Property
{
    public partial class JDataPropertyMainForm : JBaseForm
    {
        public string _ClassName;

        public JDataPropertyMainForm(string className)
        {
            InitializeComponent();
            _ClassName = "Forms." + className;
        }
    }
}
