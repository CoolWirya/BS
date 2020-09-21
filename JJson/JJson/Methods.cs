using JJson.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using WebClassLibrary;

namespace JJson
{
    public class Methods
    {
        public static JNewLineControl NewLine { get { return new JNewLineControl(); } }
        public static JSpaceControl Space { get { return new JSpaceControl(); } }
        public static string GetDescription(JsonRegexType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public static string GetAction(JsonAction type, string name)
        {
            switch (type)
            {
                case JsonAction.CheckState:
                    return "prop('checked')";
                case JsonAction.Value:
                case JsonAction.GregorianDate:
                case JsonAction.JalaliDate:
                case JsonAction.Gender:
                case JsonAction.StateCity:
                case JsonAction.Content:
                    return "val()";
                case JsonAction.Text:
                    return "text()";
                case JsonAction.Html:
                    return "html()";
                case JsonAction.Index:
                    return "prop(\"selectedIndex\")";
                case JsonAction.DropDownText:
                    return "find('option:selected').text()";
                case JsonAction.Attribute:
                    return "attr(\"" + name + "\")";
                case JsonAction.Css:
                    return "css(\"" + name + "\")";
                case JsonAction.Property:
                    return "prop(\"" + name + "\")";
               
                //case JAction.Message:
                //	action = "alert(msg.d);";
                //	break;
                //case JsonAction.Redirect:
                //    action = 
                //    break;
                case JsonAction.ConditionalMessage:
                    return "alert(\"" + name + "\");";
                case JsonAction.CloseWindow:
                    return "CloseDialog(null);";
                case JsonAction.RefreshGrid:
                    return "GetRadWindow().BrowserWindow.RefreshGrid();";
                case JsonAction.CloseWindowAndRefreshGrid:
                    return "GetRadWindow().BrowserWindow.RefreshGrid();CloseDialog(null);";
                case JsonAction.ConditionalValue:
                    return "$(\"#" + name.Split('|')[0] + "\")." + name.Split('|')[1] + ";";
               
                default:
                    return null;
            }
        }

        //private static void RegisterJqueryScript(JsonRequest req, JsonResponse res, System.Web.UI.Page page, string clientId, JsonEvent jevent)
        //{
        //	if (res.Params == null || req.Params == null || req.Params.Count != res.Params.Count)
        //		return;
        //	string action = "";
        //	string response = "";
        //	for (int j = 0; j < res.Params.Count; j++)
        //	{
        //		switch (res.Params[j].Action)
        //		{
        //			case JsonAction.Value:
        //				action = "val($(\"#" + req.Params[j].ControlID + "\").val());";
        //				break;
        //			case JsonAction.Text:
        //				action = "text($(\"#" + req.Params[j].ControlID + "\").text());";
        //				break;
        //			case JsonAction.Index:
        //				action = "prop(\"selectedIndex\",$(\"#" + req.Params[j].ControlID + "\"));";
        //				break;
        //			case JsonAction.Attribute:
        //				action = "attr(\"" + res.Params[j].Name + "\",$(\"#" + req.Params[j].ControlID + "\"));";
        //				break;
        //			case JsonAction.Css:
        //				action = "css(\"" + res.Params[j].Name + "\",$(\"#" + req.Params[j].ControlID + "\"));";
        //				break;
        //			case JsonAction.Property:
        //				action = "prop(\"" + res.Params[j].Name + "\",$(\"#" + req.Params[j].ControlID + "\"));";
        //				break;
        //			case JsonAction.Message:
        //				action = "alert($(\"#" + req.Params[j].ControlID + "\"));";
        //				break;
        //			case JsonAction.Redirect:
        //				action = "window.location =$(\"#" + req.Params[j].ControlID + "\");";
        //				break;
        //			//case JsonAction.DataBind:
        //			//	action = "append($('" + bindableType + "').val(res[i][\"" + res.Params[i].Value + "\"]).html(res[i][\"" + res.Params[i].Name + "\"]));";
        //			//	break;
        //			default:
        //				break;
        //		}
        //		response += (res.Params[j].Action != JsonAction.Redirect ? "$(\"#" + res.Params[j].ControlToSet + "\")." : "") + action + "\r\n";
        //	}
        //	string text = "$(document).ready(function(){" +
        //		"$(\"#" + clientId + "\")." + (jevent != JsonEvent.textchange ? (jevent.ToString() + "(function(){") : "on(\"input\", function () {") +
        //							response +
        //						"});" +
        //				   "});";
        //	page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_" + jevent.ToString() + "_JqueryScript", text, true);
        //}

        public static string RegisterJsonScript(List<JsonRequest> reqs, List<JsonResponse> ress, List<JsonResponse> errs, List<List<JsonValidation>> validations, System.Web.UI.Page page, string clientId, string jevent, bool isComposite = false)
        {
            string jquery = "";
            string removeScriptFromBindableType = "";
            //if (req.Type == JsonRequestType.Direct)
            //{
            //	RegisterJqueryScript(req, res, page, clientId, jevent);
            //	return;
            //}
            for (int c = 0; c < reqs.Count; c++)
            {
                string success = "";
                string response = "";
                string ValuePostfix = "";
                string conditionalResponse = "";
                if (ress[c].Params == null || reqs[c].Params == null)
                    return "";
                //if (res.Type == JsonResponseType.CloseDialog)
                //	response += "CloseDialog(null);";
                //else if (res.Type == JsonResponseType.RefreshGrid)
                //	response += "GetRadWindow().BrowserWindow.RefreshGrid();";
                //else if (res.Type == JsonResponseType.RefreshGridAndClose)
                //	response += "GetRadWindow().BrowserWindow.RefreshGrid();CloseDialog(null);";
                for (int i = 0; i < ress[c].Params.Count; i++)
                {
                    ValuePostfix = ress[c].Type == JsonResponseType.Row ? "_" + i : "";
                    string action = "";
                    if (reqs[c].Type == JsonRequestType.Other || reqs[c].Type == JsonRequestType.SQL || reqs[c].Type == JsonRequestType.Classes)
                    {
                        if (ress[c].Type == JsonResponseType.Row)
                            response += "var value" + ValuePostfix + ";" +
                                "value" + ValuePostfix + "=getRowItemByName(arr,\"" + ress[c].Params[i].ReturnField + "\");";
                        //"for (var i = 0; i < arr.length; i++)" +
                        //"{" +
                        //"	var field = arr[i].split(\":\");" +
                        //"	if (field[0].toLowerCase() == \"" + ress.Params[i].ReturnField.ToLower() + "\"){" +
                        //"		value=field[1];break;}" +
                        //"}";
                    }
                    else
                    {
                    }
                    string bindableType = "";
                    if (ress[c].Params[i].Action == JsonAction.DataBind)
                        switch (ress[c].Params[i].BindControlType)
                        {
                            case JsonBindableType.DropDownList:
                                bindableType = "<option></option>";
                                //bindableType = "<option value=\"@value\" @selected>@text</option>";
                                break;
                            case JsonBindableType.GridView:
                                break;
                            default:
                                break;
                        }
                    else if (ress[c].Params[i].Action == JsonAction.Condition)
                    {
                        if (ress[c].Params[i].Condition != null && ress[c].Params[i].Condition.Count > 0)
                            conditionalResponse = " if(value" + ValuePostfix + ".toString().toLowerCase()" + ress[c].Params[i].Condition[0].Condition + ") {" + GetAction(ress[c].Params[i].Condition[0].Action, ress[c].Params[i].Condition[0].Message) + "}\r\n";
                        for (int j = 1; j < ress[c].Params[i].Condition.Count; j++)
                            conditionalResponse += " else if(value" + ValuePostfix + ".toString().toLowerCase()" + ress[c].Params[i].Condition[j].Condition + ") {" + GetAction(ress[c].Params[i].Condition[j].Action, ress[c].Params[i].Condition[j].Message) + "}\r\n";
                    }
                    switch (ress[c].Params[i].Action)
                    {
                        case JsonAction.CheckState:
                            action = "attr(\"checked\",value" + ValuePostfix + ");";
                            break;
                        case JsonAction.Value:
                        case JsonAction.JalaliDate:
                        case JsonAction.GregorianDate:
                        case JsonAction.Gender:
                        case JsonAction.StateCity:
                        
                            action = "val(value" + ValuePostfix + ");";
                            break;
                        case JsonAction.Text:
                            action = "text(value" + ValuePostfix + ");";
                            break;
                        case JsonAction.Html:
                        case JsonAction.Content:
                            action = "html(value" + ValuePostfix + ")" + (ress[c].Type == JsonResponseType.Dialog ? ".dialog(\"open\");" : ";");
                            break;
                        case JsonAction.Index:
                            action = "prop(\"selectedIndex\",value" + ValuePostfix + ");";
                            break;
                        case JsonAction.Attribute:
                            action = "attr(\"" + ress[c].Params[i].Name + "\",value" + ValuePostfix + ");";
                            break;
                        case JsonAction.Css:
                            action = "css(\"" + ress[c].Params[i].Name + "\",value" + ValuePostfix + ");";
                            break;
                        case JsonAction.Property:
                            action = "prop(\"" + ress[c].Params[i].Name + "\",value" + ValuePostfix + ");";
                            break;
                        case JsonAction.Message:
                            action = "alert(value" + ValuePostfix + ");";
                            break;
                        case JsonAction.Redirect:
                            break;
                        case JsonAction.DataBind:
                            action = "append($(\"" + bindableType + "\").val(res[i][\"" + ress[c].Params[i].Value + "\"]).html(res[i][\"" + ress[c].Params[i].Name + "\"]));";
                            //action = "append('" + bindableType + "').val(res[i][\"" + ress[c].Params[i].Value + "\"]).html(res[i][\"" + ress[c].Params[i].Name + "\"]);";
                            //action = "append(" + bindableType.Replace("@value", "res[i][\"" + ress[c].Params[i].Value + "\"]").Replace("@text", "res[i][\"" + ress[c].Params[i].Name + "\"]") + ");";
                            break;
                        case JsonAction.JText:
                            action = ress[c].Params[i].Value;
                            break;
                        case JsonAction.Editor:
                            action = "elrte('val',value);";
                            break;
                        default:
                            break;
                    }
                    if (ress[c].Params[i].BindControlType == JsonBindableType.DropDownList && ress[c].Params[i].Action == JsonAction.DataBind)
                    {
                        removeScriptFromBindableType = "var c_" + clientId + "=$(\"#" + ress[c].Params[i].ControlToSet + "\");if( (c_" + clientId + " != null &&  c_" + clientId + " != undefined)||true ){ var  cp_" + clientId + "= c_" + clientId + ".parent();$(\"#" + ress[c].Params[i].ControlToSet + "\").empty().remove();var c_class_" + clientId + "=$(\"#" + clientId + "\").attr('class'); cp_" + clientId + ".append($(\"<select id='" + ress[c].Params[i].ControlToSet + "' class=c_class_" + clientId + " />\"));}\r\n";
                        success += "var res =eval('(' + msg.d + ')');if((c_" + clientId + "!=null && c_" + clientId + "!= undefined)||true){for (var i = 0; i < res.length; i++) {$(\"#" + ress[c].Params[i].ControlToSet + "\")." + action + "}}\r\n";
                    }
                    else
                    {
                        string paramPostfix = "";
                        if (ress[c].Params[i].Action == JsonAction.JalaliDate)
                            paramPostfix = "_pers";
                        else if (ress[c].Params[i].Action == JsonAction.GregorianDate)
                            paramPostfix = "_greg";
                        else if (ress[c].Params[i].Action == JsonAction.Gender || ress[c].Params[i].Action == JsonAction.StateCity)
                            paramPostfix = "_value";
                        else if (ress[c].Params[i].Action == JsonAction.Content)
                            paramPostfix = "_text";
                        success +=  (action.ToLower().Contains("alert") || ress[c].Params[i].Action == JsonAction.Condition ? "" : "$(\"#" + ress[c].Params[i].ControlToSet + paramPostfix + "\").") + action + (ress[c].Params[i].Action == JsonAction.Gender || ress[c].Params[i].Action == JsonAction.StateCity ? "$(\"#" + ress[c].Params[i].ControlToSet + paramPostfix + "\").trigger(\"input\");" : "") + "\r\n";
                    }
                }
                string error = "alert(msg.responseText);";
                string data = "";
                //string method = "";
                //for (int i = 0; i < req.Conditions.Count; i++)
                //{
                //    string action = GetAction(req.Conditions[i].Type, "");
                //}
                if (reqs[c].Type == JsonRequestType.Classes)
                    data += reqs[c].data + "->";
                else if (reqs[c].Type == JsonRequestType.SQL)
                    data += reqs[c].data;
                for (int i = 0; i < reqs[c].Params.Count; i++)
                {
                    string paramPostfix = "";
                    if (reqs[c].Params[i].Type == JsonAction.JalaliDate)
                        paramPostfix = "_pers";
                    else if (reqs[c].Params[i].Type == JsonAction.GregorianDate)
                        paramPostfix = "_greg";
                    else if (reqs[c].Params[i].Type == JsonAction.Gender || reqs[c].Params[i].Type == JsonAction.StateCity)
                        paramPostfix = "_value";
                   
                    string action = GetAction(reqs[c].Params[i].Type, reqs[c].Params[i].Name);
                    if (reqs[c].Type == JsonRequestType.SQL)
                    {
                        //data += reqs[c].data;
                        if (reqs[c].Params[i].Type != JsonAction.Constant)
                            data = data.Replace(reqs[c].Params[i].Name, "'+$(\"#" + reqs[c].Params[i].ControlID + paramPostfix + "\")." + action + "+'");
                        else
                            data = data.Replace(reqs[c].Params[i].Name, reqs[c].Params[i].Value);
                    }
                    else if (reqs[c].Type == JsonRequestType.LoadControl)
                    {
                        data = "$(\"#" + reqs[c].Params[i].ControlID + "\").dialog(\"open\");";
                    }
                    else
                    {
                        if (reqs[c].Params[i].Type != JsonAction.Constant)
                            data += reqs[c].Params[i].Name + "::" + "'+$(\"#" + reqs[c].Params[i].ControlID + paramPostfix + "\")." + action + "+'|";
                        else
                            data += reqs[c].Params[i].Name + "::" + reqs[c].Params[i].Value + "|";
                    }
                }
                if (reqs[c].Type != JsonRequestType.SQL)
                    data = data.Substring(0, data.Length - 1);
                #region Old_Codes
                //if (req.Type == JsonRequestType.SQL)
                //{
                //    data += req.data;
                //    for (int i = 0; i < req.Params.Count; i++)
                //    {
                //        string action = "";
                //        switch (req.Params[i].Type)
                //        {
                //            case JsonAction.Value:
                //                action = "val()";
                //                break;
                //            case JsonAction.Text:
                //                action = "text()";
                //                break;
                //            case JsonAction.Html:
                //                action = "html()";
                //                break;
                //            case JsonAction.Index:
                //                action = "prop(\"selectedIndex\")";
                //                break;
                //            case JsonAction.DropDownText:
                //                action = "find('option:selected').text()";
                //                break;
                //            case JsonAction.Attribute:
                //                action = "attr(\"" + req.Params[i].Name + "\")";
                //                break;
                //            case JsonAction.Css:
                //                action = "css(\"" + req.Params[i].Name + "\")";
                //                break;
                //            case JsonAction.Property:
                //                action = "prop(\"" + req.Params[i].Name + "\")";
                //                break;
                //            //case JAction.Message:
                //            //	action = "alert(msg.d);";
                //            //	break;
                //            //case JsonAction.Redirect:
                //            //    action = 
                //            //    break;
                //            default:
                //                break;
                //        }
                //        if (req.Params[i].Type != JsonAction.Constant)
                //            data = data.Replace(req.Params[i].Name, "'+$(\"#" + req.Params[i].ControlID + "\")." + action + "+'");
                //        else
                //            data = data.Replace(req.Params[i].Name, req.Params[i].Value);
                //    }
                //}
                //else
                //{
                //    for (int i = 0; i < req.Params.Count; i++)
                //    {
                //        string action = "";
                //        switch (req.Params[i].Type)
                //        {
                //            case JsonAction.Value:
                //                action = "val()";
                //                break;
                //            case JsonAction.Text:
                //                action = "text()";
                //                break;
                //            case JsonAction.Html:
                //                action = "html()";
                //                break;
                //            case JsonAction.DropDownText:
                //                action = "find('option:selected').text()";
                //                break;
                //            case JsonAction.Index:
                //                action = "prop(\"selectedIndex\")";
                //                break;
                //            case JsonAction.Attribute:
                //                action = "attr(\"" + req.Params[i].Name + "\")";
                //                break;
                //            case JsonAction.Css:
                //                action = "css(\"" + req.Params[i].Name + "\")";
                //                break;
                //            case JsonAction.Property:
                //                action = "prop(\"" + req.Params[i].Name + "\")";
                //                break;
                //            //case JsonAction.Redirect:
                //            //    action = "\"" + req.Params[i].Name + "\"";
                //            //    break;
                //            default:
                //                break;
                //        }
                //        if (req.Params[i].Type != JsonAction.Constant)
                //            data += req.Params[i].Name + ":" + "'+$(\"#" + req.Params[i].ControlID + "\")." + action + "+'|";
                //        else
                //            data += req.Params[i].Name + ":" + req.Params[i].Value + "|";
                //    }
                //    data = data.Substring(0, data.Length - 1);
                //}
                #endregion
                //string RowFunction = "function getRowItemByName(arr, item) {for (var i = 0; i < arr.length; i++) {var data = arr[i].split(\":\");if (data[0].toString().toLocaleLowerCase() == item.toLocaleLowerCase())return data[1];}return \"\";}";
                string ajax = "";
                string successText = "";
                if (ress[c].Type != JsonResponseType.RefreshGridAndClose)
                {
                    //successText += " var boxOpacity = parseInt($('#mainContent').css('opacity')); $('#mainContent').animate({ opacity: boxOpacity == 0 ? 1 : 0});";
                    successText = "function (msg) { " +
                                            (ress[c].Type == JsonResponseType.Row ? "var arr=msg.d.split(\"?!?\");" : "var value=msg.d;") +
                                            response + success + conditionalResponse +
                                            "	},";
                }
                else
                    successText = "function (msg)  { " +
                                            (ress[c].Type == JsonResponseType.Row ? "var arr=msg.d.split(\"?!?\");" : "var value=msg.d;") +
                                            response + success + conditionalResponse +
                                            "},";
                if (reqs[c].Type != JsonRequestType.LoadControl)
                    ajax = "$.ajax({" +
                                            "type: 'POST'," +
                                            "url: '" + reqs[c].URL + "'," +
                                            "async: false," +
                                            "data: '{'" +
                                                    "+ '\"data\":\"" + data + "\", '" +
                                                    "+ '\"requestType\":\"" + reqs[c].Type + "\", '" +
                                                    "+ '\"responseType\":\"" + ress[c].Type + "\"'" +
                                            "    + '}'," +
                                            "contentType: \"application/json; charset=utf-8\"," +
                                            "dataType: \"json\"," +
                                            "success:"+ successText +
                                            "error: function (msg) {" +
                                            error +
                                            "		}});";
                else
                    ajax = data;
                string validationText = "var validationMsg_" + c + "='';";
                if (validations != null && validations.Count > 0 && validations.Count > c && validations[c] != null)
                {
                    foreach (JsonValidation v in validations[c])
                    {
                        string datePostfix = "";
                        if (v.ValueType == JsonAction.JalaliDate)
                            datePostfix = "_pers";
                        else if (v.ValueType == JsonAction.GregorianDate)
                            datePostfix = "_greg";
                        else if (v.ValueType == JsonAction.Gender || v.ValueType == JsonAction.StateCity)
                            datePostfix = "_value";
                        validationText += "if($(\"#" + v.ControlID + datePostfix + "\")." + GetAction(v.ValueType, "") +
                                (
                                v.RegexType == JsonRegexType.Value ?
                                v.CustomRegex + "$(\"#" + v.OtherControlID + datePostfix + "\")." + GetAction(v.OtherValueType, "") + ")" :
                                ".match('" + (v.RegexType == JsonRegexType.Custom ? v.CustomRegex : GetDescription(v.RegexType)) + "')==null)"
                                ) +
                            " validationMsg_" + c + " += \"" + v.Message + "\\r\\n\";";
                    }
                    validationText += "if(validationMsg_" + c + ".length>0) { alert(validationMsg_" + c + ");return false; }";
                }
                string text = //"$(document).ready(function(){" +
                    //"$(\"#" + clientId + "\")." + (jevent != JsonEvent.textchange ? (jevent.ToString() + "(function(){") : "on(\"input\", function () {") +
                                        validationText + ajax + " \r\n";
                //(jevent != JsonEvent.click ? "" : "return false;") +
                //"});" + "\r\n";
                //"});\r\n";
                jquery += text;
            }
            if(clientId != "document")
                jquery = jquery.Length > 0 ? "$(document).ready(function(){" +
                (reqs[0].Type != JsonRequestType.FillForm ? ("$(\"#" + clientId + "\")." + (jevent != "textchange" && !isComposite ? (jevent.ToString() + "(function(){") : "on(\"" + (isComposite ? jevent : "input") + "\", function () {")) : "") +
                removeScriptFromBindableType +
                jquery + (jevent != "click" ? "" : "return false;") +
                (reqs[0].Type != JsonRequestType.FillForm ? "});" : "") + "\r\n" +
                "});\r\n" : "";
            else
                jquery = jquery.Length > 0 ? "$(document).ready(function(){" +
                (reqs[0].Type != JsonRequestType.FillForm ? ("$(document)." + (jevent != "textchange" && !isComposite ? (jevent.ToString() + "(function(){") : "on(\"" + (isComposite ? jevent : "input") + "\", function () {")) : "") +
                removeScriptFromBindableType +
                jquery + (jevent != "click" ? "" : "return false;") +
                (reqs[0].Type != JsonRequestType.FillForm ? "});" : "") + "\r\n" +
                "});\r\n" : "";
            if (jquery.Length <= 0)
                return "";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_" + jevent.ToString() + "_JsonScript", jquery, true);
            var rowResponses = from x in ress where x.Type == JsonResponseType.Row select x;
            if (rowResponses == null || rowResponses.Count() <= 0)
                return "";
            string RowFunction = "function getRowItemByName(arr, item) {for (var i = 0; i < arr.length; i++) {var data = arr[i].split(\":\");if (data[0].toString().toLocaleLowerCase() == item.toLocaleLowerCase())return data[1];}return \"\";}";
            if (!page.ClientScript.IsStartupScriptRegistered("_GetRowByItem"))
                page.ClientScript.RegisterStartupScript(page.GetType(), "_GetRowByItem", RowFunction, true);
            return "<script>" + jquery + RowFunction + "</script>";
        }

       

        public static void RegisterDateScript(Page page, string clientId, string style, string selectedDate, bool isPersian = true)
        {
            //self.showDate(el, self.persianDate.parse(self.options.selectedDate).toString(options.formatDate));
            //string gregDate = "showGregorianDate: true";
            string gregScript = "";// $(\"#" + clientId + "_greg\").val(new jDateFunctions().getGDate($(this).val())._toString(\"YYYY/MM/DD/DW\")); });";
            string text = "$(document).ready(function(){" +
                "$(\"#" + clientId + "_pers\").persianDatepicker(null,\"" + clientId + "_greg\");" + gregScript +
            "});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_datePicker_Script", text, true);
        }

        public static void RegisterGenderScript(Page page, string clientId, string style)
        {
            string text = "$(document).ready(function(){" +
            "$(\"#" + clientId + "_male\").on(\"change\",function () {" +
            " if ($(\"#" + clientId + "_male\").is(':checked')) {$(\"#" + clientId + "_value\").val(\"false\").trigger('input');$(\"#" + clientId + "\").trigger('OnChange');}});" +

            "$(\"#" + clientId + "_female\").on(\"change\",function () {" +
            "if ($(\"#" + clientId + "_female\").is(':checked')) {$(\"#" + clientId + "_value\").val(\"true\").trigger('input');$(\"#" + clientId + "\").trigger('OnChange');;}});" +
            "});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_gender_Script", text, true);
        }

        public static void RegisterEnabledScript(Page page, string clientId, string TString,string FString)
        {
            string text = "$(document).ready(function(){" +
            "$(\"#" + clientId + "_"+ FString +"\").on(\"change\",function () {" +
            " if ($(\"#" + clientId + "_" + FString +"\").is(':checked')) {$(\"#" + clientId + "_value\").val(\"false\").trigger('input');$(\"#" + clientId + "\").trigger('OnChange');}});" +

            "$(\"#" + clientId + "_" + TString + "\").on(\"change\",function () {" +
            "if ($(\"#" + clientId + "_" + TString + "\").is(':checked')) {$(\"#" + clientId + "_value\").val(\"true\").trigger('input');$(\"#" + clientId + "\").trigger('OnChange');;}});" +
            "});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_enabled_Script", text, true);
        }

        public static void RenderGenderScript(Page page, string clientId, string style)
        {
            string text = "$(document).ready(function(){" +
                "$(\"#" + clientId + "_value\").on(\"input\",function () { var state = $(\"#" + clientId + "_value\").val(); " +
                " if (var == 'true') {$(\"#" + clientId + "_female\").prop(\"checked\", true);}" +
                "else {$(\"#" + clientId + "_male\").prop(\"checked\", true);}})});";
        }


        public static void RegisterUploaderScript(Page page, string clientId, string style)
        {
            string text2 = "$(document).ready(function(){" +
             "$(\"#" + clientId + "_submit1\").click(function(){Uploader(" + clientId + "_Uploader1);readURL(" + clientId + "_Uploader1," + clientId + "_img);return false; });" +
             "});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_uploader_Script", text2, true);
        }

        public static void RegisterSliderScript(Page page, string clientId, string style)
        {
            string text = "$(document).ready(function(){" +
                "$(\"#" + clientId + "\").makeSlider('" + clientId + "');});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_slider_Script", text, true);
        }

        public static void RegisterEditorScript(Page page, string clientId, string style)
        {
            string text = "$(document).ready(function(){" +
                "$(\"#" + clientId + "_editor\").elrte({cssClass:'el-rte',height: 450,toolbar :'complete',cssfiles:['Style/elRTE/elrte-inner.css']});});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_editor_Script", text, true);
        }
        public static void RegisterEditorContentScript(Page page,string clientId,string targetId,string InsDate,string UpdDate,string updateMode)
        {
            string text = "function getContent(){var a=$(\"#" + clientId + "_editor\").elrte('val'); $(\"#" + targetId + "\").val(a.replace(/\"/g,'.@&quotes@.'));" +
                "if(updateMode=\"false\"){$(\"#" + InsDate + "\").val(new Date($.now()));}else{$(\"#" + UpdDate + "\").val(new Date($.now()));}}" +
                "$(document).ready(function(){$(\"#" + clientId + "_editor\").elrte('val',$(\"#" + targetId + "\").val())});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_editorc_Script", text, true);
        }
        public static void RegisterCreateWidget(Page page, string clientId)
        {
            string editScript = "$(document).ready(function() {$(\"#" + clientId + "_cancel\").hide();$(\"#" + clientId + "_save\").hide();" +
                " $(\"#" + clientId + "_edit\").click(function(){var content = $(\"#" + clientId + "_content\").html();$(\"#" + clientId + "_content\").remove();" +
                "var neweditor = $('<div id=\"" + clientId + "_content\"></div>');$(\"#" + clientId + "\").eq(0).before(neweditor);$(\"#" + clientId + "_content\").html(content);$(\"#" + clientId + "_content\").elrte({cssClass:'el-rte',height: 450,toolbar :'complete',cssfiles:['css/elrte-inner.css']});" +
                "$(\"#" + clientId + "_edit\").hide();$(\"#" + clientId + "_cancel\").show();$(\"#" + clientId + "_save\").show();" +
                "return false;});});";

            //el-rte ui-resizable
            string saveScript = "$(document).ready(function() {$(\"#" + clientId + "_save\").click(function(){$(\"#" + clientId + "_content\").elrte('destroy');" +
                "$(\"#" + clientId + "_cancel\").hide();$(\"#" + clientId + "_save\").hide();$(\"#" + clientId + "_edit\").show();" +
                "return false;});});";
            string cancelScript = "$(document).ready(function() {$(\"#" + clientId + "_cancel\").click(function(){$(\"#" + clientId + "_content\").elrte('close');" +
                "$(\"#" + clientId + "_cancel\").hide();$(\"#" + clientId + "_save\").hide();$(\"#" + clientId + "_edit\").show();$(\".el-rte ui-resizable\").remove();$(\"#" + clientId + "_content\").css(\"display\", \"block\");" +
                "return false;});});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_createWidget_Script", editScript, true);
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_createWidget_Script2", saveScript, true);
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_createWidget_Script3", cancelScript, true);
        }

        public static void RegisterSetContentScript(Page page,string clientId,string content)
        {
            string text = "$(document).ready(function() {$(\"#" + clientId + "_editor\").elrte('val','" + content + "');});";
           
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_setContent_Script", text, true);
        }

        public static void RegisterFileTreeScript(Page page, string clientId,int SiteCode)
        {
            string text = "";
         //if(SiteCode != 0)
         //    text = "$(document).ready(function() {$(\"#" + clientId + "_fileManager\").gsFileManager({ root: '/Erp/WebErp/CMS/Images/"+SiteCode.ToString()+"',script: '/administrator/CMS/Handler/FileManagerHandler.ashx' }" +
         //       ");" +
         //       //", function(file) { " +
         //       //"alert(file);" +
         //       //"});"+
         //       "});";
         //else
         //    text = "$(document).ready(function() {$(\"#" + clientId + "_fileManager\").gsFileManager({ root: '/Erp/WebErp/CMS/Images/',script: '/administrator/CMS/Handler/FileManagerHandler.ashx' }" +
         //      ");" +
         //      "});";
            text = "$(document).ready(function() {$(\"#" + clientId + "_fileManager\").gsFileManager({ root: '/Amini/ERP/WebERP/WebERP/Images/Controls',script: '/CMS/Handler/FileManagerHandler.ashx' }" +
              ");" +
              "});";
            //string text = "$(document).ready(function() {$(\"#" + clientId + "_fileManager\").elfinder({ url: '@Url.Content(\"~/elfinder.connector\")'," +
            //" height: 600" +
            //   "});});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_fileTree_Script", text, true);
        }

        public static string RegisterMenuScript(Page page, string clientId)
        {
            string text = "function dispatchMenuEvent(el){$(el).parent().siblings().each(function(){$('li a').removeClass('active');});$(el).addClass('active');$(\"#" + clientId + "_value\").val($(el).attr('itemid'));$(\"#" + clientId + "\").trigger(\"OnSelect\");}";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_menu_Script", text, true);
            return "<script>" + text + "</script>";
        }

        public static string RegisterListScript(Page page, string clientId)
        {
            string text = "function dispatchListEvent(el){$(\"#" + clientId + "_value\").val($(el).attr('itemid'));$(\"#" + clientId + "\").trigger(\"OnSelect\");}";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_list_Script", text, true);
            return "<script>" + text + "</script>";
        }

        public static void RegisterTabScript(Page page,string clientId)
        {
            string text = "$(document).ready(function(){$('#tab-container').easytabs();});";
            page.ClientScript.RegisterStartupScript(page.GetType(), clientId + "_tabs_Script", text, true);
        }


        #region Methods

        public static DataTable ExecuteQuery(string query)
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(query);
            return dt;
        }

        public static void ReinitializeSessions(SessionItemCollection sic)
        {
            if(sic != null)
                foreach (SessionItem si in sic)
                    HttpContext.Current.Session[si.Key] = si.Value;
        }

        //RadWindow GenerateWindow(string uId, string title, bool isModal, int width, int height, bool isMaximized, string url)
        //{
        //    if (isModal)
        //        WindowOptions = Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move | Telerik.Web.UI.WindowBehaviors.Resize;
        //    Telerik.Web.UI.RadWindow radWindow = new Telerik.Web.UI.RadWindow();
        //    radWindow.ID = "window_" + uId;
        //    radWindow.Title = title;
        //    radWindow.Modal = isModal;
        //    radWindow.AutoSize = true;
        //    radWindow.AutoSizeBehaviors = Telerik.Web.UI.WindowAutoSizeBehaviors.Height | Telerik.Web.UI.WindowAutoSizeBehaviors.Width;
        //    radWindow.Width = width;
        //    radWindow.MinWidth = width;
        //    radWindow.Height = height;
        //    radWindow.MinHeight = height;
        //    radWindow.VisibleOnPageLoad = true;
        //    radWindow.Visible = true;
        //    radWindow.DestroyOnClose = true;
        //    radWindow.VisibleOnPageLoad = true;
        //    radWindow.VisibleStatusbar = false;
        //    radWindow.AutoSize = false;
        //    radWindow.Behaviors = WindowOptions;
        //    if (isMaximized)
        //        radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
        //    radWindow.Style.Add("z-index", "2001");
        //    radWindow.RenderMode = Telerik.Web.UI.RenderMode.Lightweight;

        //    return radWindow;
        //}

        public static string GetJson(DataTable dt)
        {
            if (dt == null)// || dt.Rows.Count < 1)
                return "[]";
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                    row.Add(col.ColumnName, dr[col]);
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        public static string GetJson(DataTable dt, int rowIndex)
        {
            if (dt == null || dt.Rows.Count < 1)
                return "[]";
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            DataRow dr = dt.Rows[rowIndex];
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
                row.Add(col.ColumnName, dr[col]);
            return serializer.Serialize(row);
        }

        public static string GetJson(DataTable dt, int rowIndex, int colIndex)
        {
            if (dt == null || dt.Rows.Count < 1)
                return "موردی یافت نشد";
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            DataRow dr = dt.Rows[rowIndex];
            row = new Dictionary<string, object>();
            row.Add(dt.Columns[colIndex].ColumnName, dr[colIndex]);
            //return serializer.Serialize(row);
            return dr[colIndex].ToString();
        }

        #endregion
    }
}
