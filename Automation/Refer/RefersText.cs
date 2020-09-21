using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automation
{
    public partial class RefersText : UserControl
    {
        public bool TotalRefers = false;

        public RefersText()
        {
            InitializeComponent();
        }

        public void LoadRefer(int pCurrentRefer)
        {
            if (TotalRefers)
            {
                List<string> next_refers = JARefers.GetReferTextHistoryForList(JARefers.GetLastRefer(pCurrentRefer));
                if (next_refers != null)
                {
                    ClassLibrary.JDataTable dt = new ClassLibrary.JDataTable();
                    dt.Columns.Add("ReferCode");    // 1*
                    dt.Columns.Add("Sender");       // 2*
                    dt.Columns.Add("Reciever");     // 2*
                    dt.Columns.Add("Date");         // 1*
                    dt.Columns.Add("Time");         // 1*
                    dt.Columns.Add("Description");         // 1*
                    for (int i = next_refers.Count - 1; i >= 0; i--)
                    {
                        string[] tmp = next_refers[i].Split('\r');
                        DataRow dr = dt.NewRow();
                        dr["ReferCode"] = Convert.ToInt32(tmp[0]);
                        dr["Sender"] = tmp[1];
                        dr["Reciever"] = tmp[2];
                        dr["Date"] = tmp[3];
                        dr["Time"] = tmp[4];
                        dr["Description"] = tmp[5];
                        dt.Rows.Add(dr);
                    }
                    (dt as ClassLibrary.JDataTable).Tidy("Description", "Description", 70);
                    dgrRefers.DataSource = dt;

                }
            }
        }

        private void dgrRefers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgrRefers.Rows.Count > 0 && dgrRefers.SelectedRows.Count > 0)
                (new Automation.Refer.JAReferDetailsForm(Convert.ToInt32(dgrRefers.SelectedRows[0].Cells[0].Value))).ShowDialog();
        }

        private void dgrRefers_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dgrRefers_MouseDoubleClick(null, null);
        }

        private void dgrRefers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int x = this.Width / 7;
            dgrRefers.Columns[0].Width = x * 1;
            dgrRefers.Columns[1].Width = x * 2;
            dgrRefers.Columns[2].Width = x * 2;
            dgrRefers.Columns[3].Width = x * 1;
            dgrRefers.Columns[4].Width = x * 1;
        }
    }
}
