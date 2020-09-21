using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Bascol
{
    public partial class JKhalesForm : JBaseForm
    {
        DataTable _dt;
        public int _Weight;

        public JKhalesForm()
        {
            InitializeComponent();
        }

        public JKhalesForm(DataTable pDt)
        {
            InitializeComponent();
            _dt = pDt;
        }

        private void JKhalesForm_Load(object sender, EventArgs e)
        {
            jJanusGrid1.bind(_dt, "JanusKhalesReport", Janus.Windows.GridEX.FilterMode.Automatic, Janus.Windows.GridEX.FilterRowButtonStyle.ClearButton);
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow == null)
                return;
            JWeight tmpWeight = new JWeight(Convert.ToInt32(jJanusGrid1.SelectedRow.Row["Code"]));
            tmpWeight.PrintNo = tmpWeight.PrintNo + 1;
            tmpWeight.Update();
        }

    }
}
