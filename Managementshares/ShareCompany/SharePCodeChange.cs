using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares.ShareCompany
{
	public partial class SharePCodeChange : JBaseForm
	{

		int CompanyCode = 1;
		public SharePCodeChange()
			: this(0, 0)
		{
		}
		public SharePCodeChange(int pCompanyCode)
			: this(pCompanyCode, 0)
		{
		}
		public SharePCodeChange(int pCompanyCode, int pSelectCode)
		{
			InitializeComponent();
			if (pCompanyCode > 0)
				CompanyCode = pCompanyCode;
			txtOldSharepCode.Text = "0";
			jucPerson2.SelectedCode = pSelectCode;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void jucPerson2_AfterCodeSelected(object Sender, EventArgs e)
		{
			Int64 i = jucPerson2.ShareSelectedCode;
			if (i > 0)
				txtOldSharepCode.Text = jucPerson2.ShareSelectedCode.ToString();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (Change())
			{
				Close();
			}
			else
			{
				JMessages.Error("Error", "Error");
			}
		}

		private bool Change()
		{
			try
			{
				JSharepCode S = new JSharepCode();
				if (S.find(CompanyCode, jucPerson2.SelectedCode))
				{
					return S.Update(CompanyCode,jucPerson2.SelectedCode, Int64.Parse(txtOldSharepCode.Text), Int64.Parse(txtNewSharepCode.Text));
				}
				else
				{
					return S.Insert(CompanyCode, jucPerson2.SelectedCode, Int64.Parse(txtNewSharepCode.Text)) > 0;
				}
			}
			catch (Exception ex)
			{
				ClassLibrary.JSystem.Except.AddException(ex);

			}
			return false;

		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			if (Change())
			{
				Close();
			}
			else
			{
				JMessages.Error("Error", "Error");
			}
		}

		private void btnAutoGet_Click(object sender, EventArgs e)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT isnull(max(SharePCode),0)+1 mCode from SharePCodeSheet WHERE CompanyCode=" + CompanyCode.ToString());
				System.Data.DataTable dt = DB.Query_DataTable();
				txtNewSharepCode.Text = dt.Rows[0]["mCode"].ToString();
			}
			finally
			{
				DB.Dispose();
			}
		}
	}
}
