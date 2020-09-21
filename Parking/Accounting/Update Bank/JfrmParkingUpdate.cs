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
    public partial class JfrmParkingUpdate :JBaseForm
    {
        JParkingConfigure prk;
        public JfrmParkingUpdate()
        {
            InitializeComponent();
           
        }

        private void JfrmParkingUpdate_Load(object sender, EventArgs e)
        {
            prk = new JParkingConfigure();
        }

        private void BtnUpdateCard_Click(object sender, EventArgs e)
        {
          grdContractsGoodwill.bind(  prk.CreateParkingTable());
        }

        private void BtnUpdatBase_Click(object sender, EventArgs e)
        {
            grdContractsGoodwill.bind(prk.CreateGateTable());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            grdContractsGoodwill.bind(prk.CreateGroupTable());
        }

        private void BtnParkingRecord_Click(object sender, EventArgs e)
        {
            grdContractsGoodwill.bind(prk.RetriveTraffic(Convert.ToDateTime(txtDateIn.Date),Convert.ToDateTime(TxtDateOut.Date)));
        }
    }
}
