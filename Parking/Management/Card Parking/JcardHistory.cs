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
    public partial class JcardHistory : JBaseForm
    {
        JParkingConfigure Prkconf;
        Int64 _rfidNumber;
        public JcardHistory(Int64 RfidNumber)
        {
            InitializeComponent();
             Prkconf = new JParkingConfigure();
            _rfidNumber = RfidNumber;
            
        }

        private void JcardHistory_Load(object sender, EventArgs e)
        {
            grdContractsGoodwill.bind(Prkconf.GetCardHistory(_rfidNumber));
        }
    }
}
