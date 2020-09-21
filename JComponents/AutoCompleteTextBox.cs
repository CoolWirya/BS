using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JComponents
{
	[DefaultProperty("Text")]
	[ToolboxData("<{0}:AutoCompleteTextBox runat=server></{0}:AutoCompleteTextBox>")]
	public class AutoCompleteTextBox : CompositeControl, ISerializable
	{
		private TextBox t1;

		public AutoCompleteTextBox()
		{
			t1 = new TextBox();
		}

		public AutoCompleteTextBox(SerializationInfo info, StreamingContext ctxt)
		{
			ID = (string)info.GetValue("ID", typeof(string));
			URL = (string)info.GetValue("URL", typeof(string));
			SQL = (string)info.GetValue("SQL", typeof(string));
			DisplayField = (string)info.GetValue("DisplayField", typeof(string));
			ValueField = (string)info.GetValue("ValueField", typeof(string));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("ID", ID);
			info.AddValue("URL", URL);
			info.AddValue("SQL", SQL);
			info.AddValue("DisplayField", DisplayField);
			info.AddValue("ValueField", ValueField);
		}

		protected override void CreateChildControls()
		{
			base.CreateChildControls();
			t1.ID = "actb";
			t1.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			t1.Width = 400;
			Controls.Add(t1);
		}
		protected override void RecreateChildControls()
		{
			base.RecreateChildControls();
			EnsureChildControls();
		}
		void writeScript()
		{
			string s = @"$(document).ready(function () {
								$('#" + this.ClientID + @"').attr('owner','630N');
								$('#" + this.ClientID + @"').find('[id*=actb]').autocomplete({
									source: function (request, response) {
										$.ajax({
											url: '" + URL + "',"
											+ "data: '{ \"query\": \"" + SQL.Replace("'", "?!?") + "\",\"sf\": \"" + SearchField + "\",\"prefix\": \"' + request.term + '\"}',"
											+ "dataType: 'json',"
											+ "type: 'POST',"
											+ "contentType: 'application/json; charset=utf-8',"
											+ @"success: function (data) {
												var xmlDoc = $.parseXML(data.d);
												var xml = $(xmlDoc);"
												+ "var dt = xml.find(\"datatable\");"
												+ @"var src = [];
												$.each(dt, function () {
													src.push($(this).find('" + DisplayField + @"').text() + '?!?' + $(this).find('" + ValueField + @"').text());
												});
												response($.map(src, function (item) {
													return {
														label: item.split('?!?')[0],
														val: item.split('?!?')[1]
													}
												}))
											},
											error: function (response) {
												alert(response.responseText);
											},
											failure: function (response) {
												alert(response.responseText);
											}
										});
									},
									select: function (e, i) {"
										+ "$('#" + this.ClientID + "').find('[id*=actb]').attr(\"text\",i.item.label);"
										+ "$('#" + this.ClientID + "').attr(\"v63a0Nl\", i.item.val);"
									+ @"},
									minLength: 1
								});
						});";
			if (!this.Page.ClientScript.IsStartupScriptRegistered(this.ClientID + "_script"))
				this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID + "_script", s, true);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			writeScript();
		}

		#region Properties
		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string SQL
		{
			get
			{
				if (ViewState["SQL"] != null)
					return ViewState["SQL"].ToString();
				return null;
			}
			set
			{
				ViewState["SQL"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string URL
		{
			get
			{
				if (ViewState["URL"] != null)
					return ViewState["URL"].ToString();
				return null;
			}
			set
			{
				ViewState["URL"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string DisplayField
		{
			get
			{
				if (ViewState["DisplayField"] != null)
					return ViewState["DisplayField"].ToString();
				return null;
			}
			set
			{
				ViewState["DisplayField"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string ValueField
		{
			get
			{
				if (ViewState["ValueField"] != null)
					return ViewState["ValueField"].ToString();
				return null;
			}
			set
			{
				ViewState["ValueField"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string SearchField
		{
			get
			{
				if (ViewState["SearchField"] != null)
					return ViewState["SearchField"].ToString();
				return null;
			}
			set
			{
				ViewState["SearchField"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string Text
		{
			get
			{
				if (t1 == null)
					return "";
				return t1.Text;
			}
			set
			{
				t1.Text = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string SelectedValue
		{
			set
			{
				this.Attributes["v63a0Nl"] = value;
				ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
				db.setQuery("SELECT " + DisplayField + " FROM (" + SQL + ")AutoCompleteTextBox_t1 WHERE " + ValueField + " = " + value);
				object result = db.Query_ExecutSacler();
				t1.Text = result == null ? "" : result.ToString();
			}
		}
		#endregion
	}
}
