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
    public partial class BlackListForm : JBaseForm
    {
        public BlackListForm()
        {
            InitializeComponent();
        }

        private void Fill()
        {
            jJanusGrid1.bind(JReport.GetBlackList(), "BlackList");
        }

        private void BlackListForm_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            JWeight tmp=new JWeight();
            tmp.AddBlackList(txtSerial.IntValue);
            Fill();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jJanusGrid1.SelectedRow == null)
            {
                JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
                return;
            }
            JWeight tmp=new JWeight();
            tmp.DelBlackList(Convert.ToInt32(jJanusGrid1.SelectedRow.Row["BascoolID"].ToString()));
            Fill();
        }
    }
}
