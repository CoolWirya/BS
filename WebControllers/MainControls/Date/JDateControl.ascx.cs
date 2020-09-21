using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.Date
{
	public partial class JDateControl : System.Web.UI.UserControl
	{
		public bool isReadOnly
		{
			set
			{
				if (value == true)
					PersianDateTextBox1.ReadOnly = true;
				else
					PersianDateTextBox1.ReadOnly = false;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			// Add PersianDate StyleSheet to Current Page
			HtmlLink myHtmlLink = new HtmlLink();
			myHtmlLink.Href = ResolveUrl("~/Style/PersianDateStyle.css");
			myHtmlLink.Attributes.Add("rel", "stylesheet");
			myHtmlLink.Attributes.Add("type", "text/css");

			Page.Header.Controls.Add(myHtmlLink);

			if (Page.FindControl("persianDateScriptManager") == null)
			{
				// Add PersianDate Script Manager if it doesn't exist.
				PersianDateControls.PersianDateScriptManager persianDateScriptManager = new PersianDateControls.PersianDateScriptManager();
				persianDateScriptManager.ID = "persianDateScriptManager";
				persianDateScriptManager.CalendarCSS = "calendarCSS";
				persianDateScriptManager.FooterCSS = "footerCSS";
				persianDateScriptManager.ForbidenCSS = "forbidenCSS";
				persianDateScriptManager.FrameCSS = "frameCSS";
				persianDateScriptManager.HeaderCSS = "headerCSS";
				persianDateScriptManager.SelectedCSS = "selectedCSS";
				persianDateScriptManager.WeekDayCSS = "weekDayCSS";
				persianDateScriptManager.WorkDayCSS = "workDayCSS";
				dtScriptManager.Controls.Add(persianDateScriptManager);
			}

			PersianDateTextBox1.IconUrl = "~/" + WebClassLibrary.JDomains.Images.ControlImages.Calendar;
			PersianDateTextBox1.ShowIcon = true;

		}

		public void SetDate(DateTime date)
		{
			PersianDateTextBox1.DateValue = date;
		}

		public DateTime GetDate()
		{
			return Convert.ToDateTime(PersianDateTextBox1.DateValue);
		}

		public DateTime Date
		{
			get { return GetDate(); }
			set { SetDate(value); }
		}

		public string GetFarsiDate()
		{
			try
			{
				return ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime(PersianDateTextBox1.DateValue)).ToString();
			}
			catch
			{
				return null;
			}
		}

		public void SetFarsiDate(string date)
		{
			PersianDateTextBox1.Text = date;
		}
	}
}