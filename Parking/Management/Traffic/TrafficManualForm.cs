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
    public partial class JTrafficManualForm : ClassLibrary.JBaseForm
    {
        private JTraffic _JTraffic;

        public JTrafficManualForm(JTraffic Traffic,int _Flag_IN_Out)
        {
            InitializeComponent();
            _FillComboBox();
            _JTraffic = Traffic;
            
            Display(_Flag_IN_Out);

            JDataBase db=new JDataBase();
            txtDateIn.Text = JDateTime.FarsiDate(db.GetCurrentDateTime());

        }

        public void _FillComboBox()
        {
            JDataBase db = new JDataBase();

            // پر كردن نام مجتمع / بازارها
            cmbComplex.DisplayMember = RealEstate.estMarket.Title.ToString();
            cmbComplex.ValueMember = RealEstate.estMarket.Code.ToString();
            cmbComplex.DataSource = RealEstate.jMarkets.GetDataTable(0);

            // پرکردن انواع گروه
            try
            {
                db.setQuery("select * from " + JTableNamesParking.GroupCard + " where MarketCode=" + Properties.Settings.Default.Complex.ToString());
                cmbGroupCard.DataSource = db.Query_DataTable();
                cmbGroupCard.DisplayMember = "TypeGroup";
                cmbGroupCard.ValueMember = "Code";
            }
            catch 
            { 
            }

        }

        public void Display(int Flag)
        {
            if (Flag == 1)
            {
                txtCard.Text = _JTraffic.IDCard.ToString();
                cmbComplex.SelectedValue = _JTraffic.MarketCode;
                cmbGroupCard.SelectedValue = _JTraffic.GroupCard;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int hour,minute;
            hour= Convert.ToInt32(txtTimeIn.Text[0].ToString()+txtTimeIn.Text[1].ToString());
            minute= Convert.ToInt32(txtTimeIn.Text[3].ToString()+txtTimeIn.Text[4].ToString());
            if (txtDateIn.Text == "" && txtTimeIn.Text == "" )
            {
                MessageBox.Show("خطا", "اطفا تمامی اطلاعات را تکمیل نمائید");
            }
            else
            {
                if ((hour >= 0 && hour <= 24) && (minute >= 0 && minute <= 60))
                {
                    _JTraffic.DateIn = JDateTime.GregorianDate(txtDateIn.Text);
                    _JTraffic.TimeIn = txtTimeIn.Text;
                    _JTraffic.ReplacePropertyData(_JTraffic);
                    Close();
                }
                else
                {
                    MessageBox.Show("ساعت ورودی و یا دقیقه درست وارد نشده است","خطا");
                }
            }
            
            //Close();
        }
    }
}
