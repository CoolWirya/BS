using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Parking
{
    public partial class DefineComputerSetGate : Globals.JBaseForm
    {
        public DefineComputerSetGate()
        {
            InitializeComponent();
            _FillComboBox();
        }

        public void _FillComboBox()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("select code,Name from "+JTableNamesParking.Gate);
                cmbGate.DisplayMember = "Name";
                cmbGate.ValueMember="Code";
                cmbGate.DataSource = db.Query_DataTable();
            }
            catch{

            }

            // پر كردن نام مجتمع / بازارها
            cmbComplex.DisplayMember = RealEstate.estMarket.Title.ToString();
            cmbComplex.ValueMember = RealEstate.estMarket.Code.ToString();
            cmbComplex.DataSource = RealEstate.jMarkets.GetDataTable(0);

        }
        private void DefineComputerSetGate_Load(object sender, EventArgs e)
        {
            cmbComplex.SelectedValue = (Properties.Settings.Default.Complex);
            cmbGate.SelectedValue = (Properties.Settings.Default.Gate);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Complex = Convert.ToInt32(cmbComplex.SelectedValue);
            Properties.Settings.Default.Gate = Convert.ToInt32(cmbGate.SelectedValue);
            Properties.Settings.Default.Save();
        }
    }
}
