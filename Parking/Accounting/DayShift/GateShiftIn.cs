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
    public partial class GateShiftIn :JBaseForm
    {
        JDayProfile _Day;
        JGate _Gate;

        public GateShiftIn(JDayProfile Day, int Gate)
        {
            InitializeComponent();
            _Gate = new JGate(Gate);
            GrdShift.DataSource = Day.ShiftOfGateIn(Gate);
            _Gate.GetData(Gate);
            this.Text = Day.NameShift + " حساب گيت هاي ورودي ";
            _Day = Day;

        }

        private void GateShiftIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridUser.DataSource = _Day.UserOFShiftIn(Convert.ToInt32(GrdShift["Shiftin", GrdShift.CurrentRow.Index].Value.ToString()), _Gate.Code);
        }
    }
}
