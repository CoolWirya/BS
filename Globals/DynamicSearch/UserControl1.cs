using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Microsoft.Win32;

namespace Globals.DynamicSearch
{
    public partial class UserControl1 : UserControl
    {
        private DataTable _DataTable;

        public UserControl1(DataTable pDataTable)
        {
            _DataTable = pDataTable;
            InitializeComponent();
        }

   }
}
