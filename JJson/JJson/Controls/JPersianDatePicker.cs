using JJson.BaseControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("JJson.Controls", "JJson")]
namespace JJson.Controls
{
	[ToolboxData("<{0}:JPersianDatePicker runat=server ></{0}:JPersianDatePicker>")]
    public class JPersianDatePicker : JBaseCompositeControl
	{
		////months: ["فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"],
		////dowTitle: ["شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنج شنبه", "جمعه"],
		////shortDowTitle: ["ش", "ی", "د", "س", "چ", "پ", "ج"],
		////showGregorianDate: false,
		////persianNumbers: true,
		////formatDate: "YYYY/MM/DD",
		////prevArrow: '\u25c4',
		////nextArrow: '\u25ba',
		////theme: 'default',
		////alwaysShow: false,
		////selectableYears: null,
		////selectableMonths: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
		////cellWidth: 25, 
		////cellHeight: 20, 
		////fontSize: 13,             
		////isRTL: false,
		////calendarPosition: {
		////	x: 0,
		////	y: 0,
		////},
		////onShow: function(calendar) {
		////	calendar.show();
		////},
		////onHide: function(calendar) {
		////	calendar.hide();
		////},

		#region Properties

	

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Localizable(true)]
		public DateTime Date
		{
			get
			{
				EnsureChildControls();
				if (ViewState["Date"] != null)
					return (DateTime)ViewState["Date"];
				//string str = greg.Text;//(this.Parent.FindControl(this.ClientID + "_greg") as TextBox).Text;
				//if (ViewState["Date"] == null && string.IsNullOrEmpty(str))
				//	return DateTime.MinValue;
				//if (string.IsNullOrEmpty(str))
				//	return (DateTime)ViewState["Date"];
				DateTime dt = DateTime.MinValue;
				DateTime.TryParse(greg.Value, out dt);
				return dt;
			}

			set
			{
				EnsureChildControls();
				ViewState["Date"] = value;
				greg.Value = value.ToString("YYYY/mm/DD");
				PersianCalendar pc = new PersianCalendar();
				persian.Text = pc.GetYear(value) + "/" + pc.GetMonth(value) + "/" + pc.GetDayOfMonth(value);
			}
		}


      
		#endregion

		#region Events

		HiddenField greg;
		TextBox persian;

		

		protected override void CreateChildControls()
		{
			//base.CreateChildControls();
            this.Event = JsonCompositeEvent.OnSelect;
			greg = new HiddenField();
			greg.ID = this.ClientID + "_greg";
			greg.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			Controls.Add(greg);

			persian = new TextBox();
			persian.ID = this.ClientID + "_pers";
			persian.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			persian.ReadOnly = true;
			persian.Width = 100;
			Controls.Add(persian);
		}

		protected override void OnPreRender(EventArgs e)
		{
			//this.Width = 100;
			//this.Parent.Controls.Add(new TextBox() { ID = this.ClientID + "_greg", ClientIDMode = System.Web.UI.ClientIDMode.Static });
			base.OnPreRender(e);
            Methods.RegisterJsonScript(Request, OnSuccessControlsAction, OnErrorControlsAction, Validations, this.Page, this.ClientID, this.Event.ToString(),true);
			Methods.RegisterDateScript(this.Page, this.ClientID, "", "");
		}
		#endregion
	}
}

