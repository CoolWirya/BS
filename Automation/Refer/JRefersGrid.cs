using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation
{
    public partial class JRefersGrid : UserControl
    {
        public bool TotalRefers = false;

        public JRefersGrid()
        {
            InitializeComponent();
        }

        public void LoadRefer(int referCode)
        {
            if (referCode == 0) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Sender");
            dt.Columns.Add("ReadDate");
            dt.Columns.Add("ReferDate");
            dt.Columns.Add("Description");

            List<JARefers.ReferInfo> referInfo = (new JARefers()).GetSpecificReferList(referCode);
            //First Person
            string readdate = "";
            string referdate = "";
            if (referInfo[0].Date != DateTime.MinValue) referdate = "(تاریخ ارجاع: " + GetFullDate(referInfo[0].Date) + ")";
            DataRow dr = dt.NewRow();
            dr["Code"] = referInfo[0].Code;
            dr["Sender"] = "□ " + referInfo[0].SenderName;
            dr["ReadDate"] = "";
            dr["ReferDate"] = referdate;
            dr["Description"] = referInfo[0].Description;
            dt.Rows.Add(dr);
            //Other Persons
            for (int i = 0; i < referInfo.Count; i++)
            {
                dr = dt.NewRow();
                readdate = "";
                referdate = "";
                if (referInfo[i].ReadDate != DateTime.MinValue) readdate = "(تاریخ مشاهده: " + GetFullDate(referInfo[i].ReadDate) + ")";
                if (i + 1 < referInfo.Count)
                {
                    int j = i + 1;
                    if (referInfo[j].Date != DateTime.MinValue) referdate = "(تاریخ ارجاع: " + GetFullDate(referInfo[j].Date) + ")";
                    dr["Description"] = referInfo[j].Description;
                }
                dr["Code"] = referInfo[i].Code;
                dr["Sender"] = Spaces(referInfo[i].Level * 4) + "□ " + referInfo[i].RecieverName;
                dr["ReadDate"] = readdate;
                dr["ReferDate"] = referdate;
                dt.Rows.Add(dr);
            }
            dgrRefers.DataSource = dt;
            dgrRefers.ColumnHeadersVisible = false;
            dgrRefers.Columns["Code"].Visible = false;
            dgrRefers.Columns["Sender"].CellTemplate.Style.ForeColor = Color.Black;
            dgrRefers.Columns["ReadDate"].CellTemplate.Style.ForeColor = Color.DarkBlue;
            dgrRefers.Columns["ReferDate"].CellTemplate.Style.ForeColor = Color.Blue;
            dgrRefers.Columns["Description"].CellTemplate.Style.ForeColor = Color.DarkGreen;
            dgrRefers.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.Window;
            for (int i = 0; i < dgrRefers.Rows.Count; i++)
                if (dgrRefers.Rows[i].Cells["Code"].Value.ToString() == referCode.ToString())
                    dgrRefers.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
        }

        private string GetFullDate(DateTime date)
        {
            string strDate = "";
            if (date != null || date > DateTime.MinValue)
                strDate = date.Hour.ToString("00") + ":" + date.Minute.ToString("00") + "  " + JDateTime.FarsiDate(date).Substring(2);
            return strDate;
        }

        private string Spaces(int x)
        {
            string s = "";
            for (int i = 0; i < x; i++)
            {
                s += " ";
            }
            return s;
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
