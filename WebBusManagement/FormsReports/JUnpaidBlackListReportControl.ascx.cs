using BusManagment.UnpaidBlackList;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JUnpaidBlackListReportControl : System.Web.UI.UserControl
    {
        int Code;
		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(base.Request["Code"], out this.Code);
			if (base.IsPostBack)
			{
				return;
			}
			this.LoadPerson();
		}
		public void LoadPerson()
		{
			if (this.Code == 0)
			{
				DataTable allPersonsOnly = this.GetAllPersonsOnly(0);
				this.cmbPerson.DataSource = allPersonsOnly;
				this.cmbPerson.DataTextField = "Name";
				this.cmbPerson.DataValueField = "Code";
				this.cmbPerson.DataBind();
				return;
			}
			JUnpaidBlackList jUnpaidBlackList = new JUnpaidBlackList(this.Code);
			int pCode = jUnpaidBlackList.pCode;
			DataTable allPersonsOnly2 = this.GetAllPersonsOnly(pCode);
			this.cmbPerson.DataSource = allPersonsOnly2;
			this.cmbPerson.DataTextField = "Name";
			this.cmbPerson.DataValueField = "Code";
			this.cmbPerson.DataBind();
		}
		private DataTable GetAllPersonsOnly(int pCode = 0)
		{
			JDataBase jDataBase = new JDataBase();
			try
			{
				if (pCode == 0)
				{
					jDataBase.setQuery("select ObjectCode Code,Value TafsiliCode,b.Name from finComparativeCode a\r\n                                                                        left join clsAllPerson b on a.ObjectCode = b.Code\r\n                                                                        where ClassName = N'ClassLibrary.Person.AllPerson'");
				}
				else
				{
					jDataBase.setQuery("select ObjectCode Code,Value TafsiliCode,b.Name from finComparativeCode a\r\n                                                                        left join clsAllPerson b on a.ObjectCode = b.Code\r\n                                                                        where ClassName = N'ClassLibrary.Person.AllPerson' and ObjectCode =" + pCode);
				}
				DataTable result = jDataBase.Query_DataTable();
				jDataBase.Dispose();
				return result;
			}
			catch
			{
			}
			finally
			{
				jDataBase.Dispose();
			}
			return null;
		}
		protected void btnSave_Click(object sender, EventArgs e)
		{
			int pCode = int.Parse(this.cmbPerson.SelectedValue);
			if (new JUnpaidBlackList
			{
				Code = this.Code,
				pCode = pCode,
				InsertDate = DateTime.Now
			}.Insert(true) > 0)
			{
				JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog", false);
			}
		}
		protected void btnClose_Click(object sender, EventArgs e)
		{
		}
		protected void btnDelete_Click(object sender, EventArgs e)
		{
			JUnpaidBlackList jUnpaidBlackList = new JUnpaidBlackList(this.Code);
			if (jUnpaidBlackList.Delete(true))
			{
				JWebManager.RunClientScript("alert('با موفقیت حذف شد');", "OKDialog", false);
			}
		}
    }

}