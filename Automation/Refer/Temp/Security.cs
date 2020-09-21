using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation
{
    public partial class JSecurity : UserControl
    {
        public JSecurity()
        {
            InitializeComponent();
            //----------------- انواع فوریت-----------------
            cmbUrgency.DisplayMember = "name";
            cmbUrgency.ValueMember = "value";
            cmbUrgency.DataSource = ClassLibrary.Domains.JGlobal.JUrgency.GetData();
            cmbUrgency.SelectedValue = ClassLibrary.Domains.JGlobal.JUrgency.Normal;
            //----------------- انواع سطح محرمانگی-----------------
            cmbsecuritylevel.DisplayMember = "name";
            cmbsecuritylevel.ValueMember = "value";
            cmbsecuritylevel.DataSource = ClassLibrary.Domains.JGlobal.JPrivacy.GetData();
            cmbsecuritylevel.SelectedValue = ClassLibrary.Domains.JGlobal.JPrivacy.Normal;            
        }


    }
}
