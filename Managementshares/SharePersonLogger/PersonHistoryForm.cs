using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
	public partial class JPersonHistoryForm : ClassLibrary.JBaseForm
	{
		DataTable historyTable;
		int PCode;
		int CompanyCode;
		public JPersonHistoryForm(int pPCode, int pcompanyCode)
		{
			InitializeComponent();
			PCode = pPCode;
			CompanyCode = pcompanyCode;
			historyTable = JSharePersonLoggers.GetPersonData(pPCode, pcompanyCode);
			ShowData();
			//grdHistory.gridEX1.Tables[0].Columns["SumRemain"].Visible = false;
		}

		private void ShowData()
		{
			grdHistory.DataSource = historyTable;
			if (historyTable != null && historyTable.Rows.Count > 0)
			{
				lbName.Text = historyTable.Rows[0]["PersonName"].ToString();
				lbPCode.Text = historyTable.Rows[0]["SharePCode"].ToString();
			}
			else
			{
				lbName.Text = "";
				lbPCode.Text = "";
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			{
				if (grdHistory.SelectedRow == null)
				{
					ClassLibrary.JMessages.Error("ردیفی انتخاب نشده است", "خطا");
					return;
				}
				if (ClassLibrary.JMessages.Question("آیا میخواهید ردیف انتخاب شده حذف شود؟", "حذف سابقه") == DialogResult.Yes)
				{
					int code = Convert.ToInt32(grdHistory.SelectedRow["Code"]);
					JSharePersonLogger logger = new JSharePersonLogger(code);
					if (logger.Disable())
						grdHistory.SelectedRow.Row.Delete();
					else
						JMessages.Error("عملیات حذف با مشکل مواجه شده است.", "خطا");
				}
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			historyTable = JSharePersonLoggers.GetPersonData(PCode, CompanyCode);
			ShowData();
		}

		private void btnUp_Click(object sender, EventArgs e)
		{
			if (grdHistory.SelectedRow == null)
			{
				ClassLibrary.JMessages.Error("ردیفی انتخاب نشده است", "خطا");
				return;
			}
			if (ClassLibrary.JMessages.Question("آیا میخواهید ردیف انتخاب شده به پایین شود؟", "جابجایی سابقه") == DialogResult.Yes)
			{
				int code = Convert.ToInt32(grdHistory.SelectedRow["Code"]);
				JSharePersonLogger logger = new JSharePersonLogger(code);
				logger.Ordered = logger.Ordered + 1;
				logger.Update();
			}

		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			if (grdHistory.SelectedRow == null)
			{
				ClassLibrary.JMessages.Error("ردیفی انتخاب نشده است", "خطا");
				return;
			}
			if (ClassLibrary.JMessages.Question("آیا میخواهید ردیف انتخاب شده به بالا شود؟", "جابجایی سابقه") == DialogResult.Yes)
			{
				int code = Convert.ToInt32(grdHistory.SelectedRow["Code"]);
				JSharePersonLogger logger = new JSharePersonLogger(code);
				logger.Ordered = logger.Ordered - 1;
				logger.Update();
			}

		}

        private void button1_Click(object sender, EventArgs e)
        {
            //JAddPersonHistoryForm F = new JAddPersonHistoryForm(0, PCode,CompanyCode);
            //F.ShowDialog();
        }

        private void grdHistory_GridRowDoubleClick(object sender, EventArgs e)
        {
        }

        private void grdHistory_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (grdHistory.SelectedRow != null)
            {
                //JAddPersonHistoryForm F = new JAddPersonHistoryForm((int)grdHistory.SelectedRow["Code"], PCode, CompanyCode);
                //F.ShowDialog();
            }
        }
    }
}
