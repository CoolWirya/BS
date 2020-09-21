using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace RealEstate
{
    public partial class JPbill : Form
    {
        public JPbill()
        {
            InitializeComponent();
            _FillComboBox();
        }
        public void _FillComboBox()
        {

            // پر كردن نام مجتمع / بازارها
            DataTable Markets = jMarkets.GetDataTable(0);
            cmbComplex.DisplayMember = estMarket.Title.ToString();
            cmbComplex.ValueMember = estMarket.Code.ToString();
            cmbComplex.DataSource = Markets;
            cmbComplex.SelectedItem = null;

        }
    }
}
