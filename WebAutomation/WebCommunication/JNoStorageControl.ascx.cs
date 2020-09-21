using Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomation.WebCommunication
{
	public partial class JNoStorageControl : System.Web.UI.UserControl
	{
		#region Properties
		private string ClassName;
		//{
		//	get
		//	{
		//		if (ViewState["ClassName"] == null)
		//			return "";
		//		return ViewState["ClassName"].ToString();
		//	}
		//	set
		//	{
		//		ViewState["ClassName"] = value;
		//	}
		//}

		private int ObjectCode;
		//{
		//	get
		//	{
		//		if (ViewState["ObjectCode"] == null)
		//			return 0;
		//		return (int)ViewState["ObjectCode"];
		//	}
		//	set
		//	{
		//		ViewState["ObjectCode"] = value;
		//	}
		//}

		private int SecretariatCode;
		//{
		//	get
		//	{
		//		if (ViewState["SecretariatCode"] == null)
		//			return 0;
		//		return (int)ViewState["SecretariatCode"];
		//	}
		//	set
		//	{
		//		ViewState["SecretariatCode"] = value;
		//	}
		//}

		private int NoStorageNumber;
		//{
		//	get
		//	{
		//		if (ViewState["NoStorageNumber"] == null)
		//			return 0;
		//		return (int)ViewState["NoStorageNumber"];
		//	}
		//	set
		//	{
		//		ViewState["NoStorageNumber"] = value;
		//	}
		//}

		#endregion
		void SetForm()
		{
			//int Year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
			//NoStorage NS = new NoStorage(ClassName, ObjectCode, Year);

			//JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
			//ReservedListListBox.DataTextField = "Number";
			//ReservedListListBox.DataValueField = "Number";
			//ReservedListListBox.DataSource = NSR.GetData();

			//ReserveListListBox.DataTextField = "Number";
			//ReserveListListBox.DataValueField = "Number";
			//ReserveListListBox.DataSource = NSR.GetData();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request["ObjectCode"], out ObjectCode);
			int.TryParse(Request["SecretariatCode"], out SecretariatCode);
			ClassName = Request["ClassName"];
			//SetForm();
		}
	}
}