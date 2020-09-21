using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Janus.Windows.GridEX;

namespace StoreManagement
{
    public partial class JListGoodsForm : JBaseForm
    {

        public string Name;
        public int Code;

        public JListGoodsForm()
        {
            InitializeComponent();
        }

        private void JListGoodsForm_Load(object sender, EventArgs e)
        {
            jJanusGrid1.DataSource = JGoodss.GetDataTable(0);
        }

        private void jJanusGrid1_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (e.Row.DataRow != null)
            {
                Name = ((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[1].ToString();
                Code = Convert.ToInt32(((System.Data.DataRowView)(e.Row.DataRow)).Row.ItemArray[0]);
                DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}