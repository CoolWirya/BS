using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Globals.Property.PropertyHistory
{
    public partial class JPropertyHistoryView : UserControl
    {
        public string _ClassName;
        public int _ObjectCode, _TableObjectCode;
        public JPropertyHistoryView()
        {
            InitializeComponent();
        }

        private void JPropertyHistoryView_Load(object sender, EventArgs e)
        {
        }

        public void Refresh()
        {
            jDataGrid1.DataSource = (new JPropertyHistory()).GetChangeset(_ClassName, _ObjectCode, _TableObjectCode);
            if (jDataGrid1.DataSource != null)
            {
                jDataGrid1.Columns[0].Visible = false;
                jDataGrid1.Columns[1].Visible = false;
            }
        }

        private void jDataGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int usercode = Convert.ToInt32(jDataGrid1.SelectedRows[0].Cells[1].Value);
            DateTime date = Convert.ToDateTime(jDataGrid1.SelectedRows[0].Cells[0].Value);
            (new JPropertyHistoryViewForm(_ClassName, _ObjectCode, _TableObjectCode, usercode, date)).ShowDialog();
        }
    }
}
