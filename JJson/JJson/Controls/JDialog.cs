using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

[assembly: TagPrefix("JJson.Controls", "JJson")]
namespace JJson.Controls
{
	//[ToolboxData("<div runat=server style=\"display:none;\">\r\n\r\n</div>")]
	[ToolboxData("<{0}:JDialog runat=server>\r\n\r\n</{0}:JDialog>")]
	public class JDialog : Label
	{
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Localizable(true)]
		public List<JDialogButton> Buttons
		{
			get
			{
				if (ViewState["Buttons"] == null)
					return new List<JDialogButton>();
				return (List<JDialogButton>)ViewState["Buttons"];
			}

			set
			{
				ViewState["Buttons"] = value;
			}
		}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(400)]
		[Localizable(true)]
		public new int Width
		{
			get
			{
				if (ViewState["Width"] != null)
					return (int)ViewState["Width"];
				return 400;
			}

			set
			{
				ViewState["Width"] = value;
			}
		}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(600)]
		[Localizable(true)]
		public new int Height
		{
			get
			{
				if (ViewState["Height"] != null)
					return (int)ViewState["Height"];
				return 400;
			}

			set
			{
				ViewState["Height"] = value;
			}
		}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(false)]
		[Localizable(true)]
		public bool AutoOpen
		{
			get
			{
				if (ViewState["AutoOpen"] != null)
					return (bool)ViewState["AutoOpen"];
				return false;
			}

			set
			{
				ViewState["AutoOpen"] = value;
			}
		}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(true)]
		[Localizable(true)]
		public bool IsModal
		{
			get
			{
				if (ViewState["IsModal"] != null)
					return (bool)ViewState["IsModal"];
				return true;
			}

			set
			{
				ViewState["IsModal"] = value;
			}
		}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue("")]
		[Localizable(true)]
		public string DivForLoad
		{
			get
			{
				if (ViewState["DivForLoad"] != null)
					return ViewState["DivForLoad"].ToString();
				return "";
			}

			set
			{
				ViewState["DivForLoad"] = value;
			}
		}

		private string GetAction(JsonAction type, string var)
		{
			switch (type)
			{
				case JsonAction.CheckState:
					return "prop('checked')";
				case JsonAction.Value:
				case JsonAction.GregorianDate:
				case JsonAction.JalaliDate:
					return "val(" + var + ")";
				case JsonAction.Text:
					return "text(" + var + ")";
				case JsonAction.Html:
					return "html(" + var + ")";
				case JsonAction.Index:
					return "prop(\"selectedIndex\")";
				case JsonAction.DropDownText:
					return "find('option:selected').text()";
				case JsonAction.Attribute:
					return "attr(\"" + var + "\")";
				case JsonAction.Css:
					return "css(\"" + var + "\")";
				case JsonAction.Property:
					return "prop(\"" + var + "\")";
				//case JAction.Message:
				//	action = "alert(msg.d);";
				//	break;
				//case JsonAction.Redirect:
				//    action = 
				//    break;
				case JsonAction.ConditionalMessage:
					return "alert(\"" + var + "\");";
				case JsonAction.CloseWindow:
					return "CloseDialog(null);";
				case JsonAction.RefreshGrid:
					return "GetRadWindow().BrowserWindow.RefreshGrid();";
				case JsonAction.CloseWindowAndRefreshGrid:
					return "GetRadWindow().BrowserWindow.RefreshGrid();CloseDialog(null);";
				default:
					return null;
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			string buttons = "var " + this.ClientID + "_buttonsConfig = [";
			//{
			//	text: "انتخاب",
			//	click: function () {
			//		var index = Number($("#<%=(JPersonListControl as WebControllers.MainControls.JPersonListControl).FindControl("hdnRowId").ClientID%>").val()) + 1;
			//		//alert(index);
			//		var personId = $("#addPrimaryOwnerDiv tbody tr:eq(" + index + ") td:eq(0)").html();
			//		//alert(personId);
			//		$("#<%=hdnPersonId.ClientID%>").val(personId);
			//		$("#addPrimaryOwnerDiv").dialog("close");
			//		$("#addPrimaryOwnerDiv_GetSahm").dialog("open");
			//	}
			//},
			//{
			//	text: "بستن",
			//	click: function () {
			//		$("#addPrimaryOwnerDiv").dialog("close");
			//	}
			//}
			//];";
			string button = "";
			for (int i = 0; i < Buttons.Count; i++)
			{
				buttons += i == 0 ? "{" : ",{";
				button += "text: \"" + Buttons[i].Caption + "\", ";
				button += "click: function () {";
				for (int j = 0; j < Buttons[i].Actions.Count; j++)
				{
					for (int k = 0; k < Buttons[i].Actions[j].Params.Count; k++)
					{
						button += "var " + this.ClientID + "_index=Number($(\"#hdnRowId\")." + GetAction(Buttons[i].Actions[j].Params[k].Action, "") + ")+1;\r\n";
						button += "var " + this.ClientID + "_id=$(\"#" + DivForLoad + " grid_Div tbody tr:eq(" + this.ClientID + "_index) td:eq(0)\").html();";
						button += "$(\"#" + Buttons[i].Actions[j].Params[k].ControlToSet + "\")." + GetAction(Buttons[i].Actions[j].Params[k].Action, this.ClientID + "_id") + ";\r\n";
						button += "alert(" + this.ClientID + "_id);\r\n";
						button += "$(\"#" + DivForLoad + "\").dialog(\"close\");\r\n";
					}
				}
				button += "}";
				buttons += button + "}";
			}
			//if (Buttons.Count > 0)
			//buttons += ",{text: \"" + Buttons[Buttons.Count - 1].Caption + "\",click: function () {$(\"#" + DivForLoad + "\").dialog(\"close\");}}";
			buttons += ",{text: \"بستن\",click: function () {$(\"#" + DivForLoad + "\").dialog(\"close\");}}";
			buttons += "];";
			string script = buttons + "\r\n $(document).ready(function(){$(\"#" + DivForLoad + "\").dialog({" +
																	"autoOpen: " + AutoOpen.ToString().ToLower() + "," +
																	"modal: " + IsModal.ToString().ToLower() + "," +
																	"show: {" +
																	"	effect: \"blind\"," +
																	"	duration: 300" +
																	"}," +
																	"hide: {" +
																	"	effect: \"blind\"," +
																	"	duration: 300" +
																	"}," +
																	"width: " + Width + "," +
																	"height: " + Height + "," +
																	"buttons: " + this.ClientID + "_buttonsConfig" +
																"});" +
																"$(\"#" + DivForLoad + "\").parent().appendTo($(\"form:first\"));});";
			base.OnPreRender(e);
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID + "_JDialog_Script", script, true);
		}
		//const string label = "JDialog_";
		//protected override void RenderContents(HtmlTextWriter output)
		//{
		//	output.Write(label + this.ClientID);
		//	output.AddAttribute("style", "display:none");
		//	output.AddAttribute("id", this.ClientID);
		//	output.AddAttribute("runat", "server");
		//	output.RenderBeginTag("div");
		//	output.RenderEndTag();
		//}
	}
}
