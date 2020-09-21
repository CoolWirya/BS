using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

//[assembly: WebResource("JJson.Resources.JNumericTextBox.js", "text/javascript")]
[assembly: TagPrefix("JJson.Controls", "JJson")]
namespace JJson.Controls
{
    [ToolboxData("<{0}:JNumericTextBox runat=server></{0}:JNumericTextBox>")]
    public class JNumericTextBox : TextBox
    {
        public enum TextBoxType
        {
            Integer,
            Decimal
        }

        private int _NumberOfFraction = 0;
        private int _NumberOfInteger = 0;
        private bool _AllowNegative = false;
        private TextBoxType _Type = TextBoxType.Integer;

        public int NumberOfFraction
        {
            get { return _NumberOfFraction; }
            set { _NumberOfFraction = value; }
        }

        public int NumberOfInteger
        {
            get { return _NumberOfInteger; }
            set { _NumberOfInteger = value; }
        }

        public bool AllowNegative
        {
            get { return _AllowNegative; }
            set { _AllowNegative = value; }
        }

        public TextBoxType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            ClientScriptManager scriptManager = this.Page.ClientScript;
            //string resourceFilePath = "JJson.Resources.JNumericTextBox.js";

            // This will register a Javascript block witht the name 'NumericTextBoxScript'
            //scriptManager.RegisterClientScriptInclude("NumericTextBoxScript",
            //	scriptManager.GetWebResourceUrl(this.GetType(), resourceFilePath));
            string pre = "$(document).ready(function(){" +
                "$(\"#" + this.ClientID + "\").keypress(function(e){" +//on(\"input\", function () {" +
                //(this.Type == TextBoxType.Decimal ?
                //    string.Format("return CheckDecimal(this,'{0}','{1}', {2});",
                //    NumberOfInteger, NumberOfFraction, _AllowNegative.ToString().ToLower())
                //    :
                //string.Format("return CheckInteger({0});",
                //				_AllowNegative.ToString().ToLower())
					@"var key= e.keyCode;
								if ((e.which >= 48 && e.which <= 57 && e.shiftKey == false) ||
									// 0-9 numbers        
									//(key >= 96 && key <= 105 && event.shiftKey == false) ||
									// 0-9 numbers (the numeric keys at the right of the keyboard)
									(key >= 37 && key <= 40) || // Left, Up, Right and Down        
									key == 8 || // backspaceASKII
									key == 9 || // tabASKII
									key == 16 || // shift
									key == 17 || // control
									key == 35 || // End
									key == 36 ||// Home
									e.which == 46 ||// dot
									key == 46) // deleteASKII
									return true;
								else if (e.which == 189 && " + _AllowNegative.ToString().ToLower() + @" == true) { // dash (-)
									if (sender.value.indexOf('-', 0) > -1)
										e.preventDefault();
									else
										return true;
								}
								else
									e.preventDefault();" +
                //) +
                    "});});";
            string script = @"function CheckInteger(allowNegative) {alert('123'); var key=e.keyCode||e.which;alert(key);
								if ((key >= 48 && key <= 57 && e.shiftKey == false) ||
									// 0-9 numbers        
									(key >= 96 && key <= 105 && e.shiftKey == false) ||
									// 0-9 numbers (the numeric keys at the right of the keyboard)
									(key >= 37 && key <= 40) || // Left, Up, Right and Down        
									key == 8 || // backspaceASKII
									key == 9 || // tabASKII
									key == 16 || // shift
									key == 17 || // control
									key == 35 || // End
									key == 36 || // Home
									key == 46) // deleteASKII
									return true;
								else if (key == 189 && allowNegative == true) { // dash (-)
									if (sender.value.indexOf('-', 0) > -1)
										return false;
									else
										return true;
								}
								else
									return false;
							}
							function CheckDecimal(sender, numberOfInteger, numberOfFrac, allowNegative) {
								var valueArr;var key=(window.event)?:evt.keyCode:evt.which;
								if ((key >= 37 && key <= 40) || // Left, Up, Right and Down
									key == 8 || // backspaceASKII
									key == 9 || // tabASKII
									key == 16 || // shift
									key == 17 || // control
									key == 35 || // End
									key == 36 || // Home
									key == 46) // deleteASKII
									return true;
								else if (key == 189 && allowNegative == true) { // dash (-)
									if (sender.value.indexOf('-', 0) > -1)
										return false;
									else
										return true;
								}

								valueArr = sender.value.split('.');

								if (key == 190) { // decimal point (.)
									if (valueArr[0] != null && valueArr[1] == null)
										return true;
									else
										return false;
								}

								if ((key >= 48 && key <= 57 && e.shiftKey == false) ||
									// 0-9 numbers        
									(key >= 96 && key <= 105 && e.shiftKey == false)) {
									// 0-9 numbers (the numeric keys at the right of the keyboard)
									if (valueArr[1] == null) {
										if (valueArr[0].indexOf('-', 0) > -1)
											numberOfInteger++;

										if (valueArr[0].length <= numberOfInteger)
											return true;
									}
									else {
										if (valueArr[1].length <= numberOfFrac)
											return true;
									}
								}

								return false;
							}
							function CheckNegative(sender) {
								if (key == 189) { // dash (-)
									if (sender.value.indexOf('-', 0) > 0)
										sender.value = sender.value.replace('-', '');
								}
							}});";
            scriptManager.RegisterStartupScript(this.Page.GetType(), this.ClientID + "JNumericTextBoxScript", pre, true);

            //if (this.Type == TextBoxType.Decimal)
            //	this.Attributes.Add("onkeypress",
            //	   string.Format("return CheckDecimal(this,'{0}','{1}', {2});",
            //	   NumberOfInteger, NumberOfFraction, _AllowNegative.ToString().ToLower()));
            //else if (this.Type == TextBoxType.Integer)
            //	this.Attributes.Add("onkeypress", string.Format("return CheckInteger({0});",
            //						_AllowNegative.ToString().ToLower()));

            //this.Attributes.Add("onkeyup", string.Format("return CheckNegative(this);",
            //					_AllowNegative.ToString().ToLower()));
        }
    }
}
