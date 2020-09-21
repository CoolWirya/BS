using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJson
{
    public enum JsonRequestType
    {
        SQL,
        Classes,
        Direct,
        Other,
        LoadControl,
		FillForm
    }

	public enum JDatePickerStyles
	{
		Default,
		Dark
	}

    public enum JsonBindableType
    {
        DropDownList,
        GridView
    }

    public enum JsonRegexType
    {
        //[Description("[a-zA-Z_\\u00A1-\\uFFFF]+")]
        //Alphabetic,
        [Description("\\\\d+")]
        Numeric,
        [Description("[a-zA-Z0-9_\\u00A1-\\uFFFF]+")]
        Alphanumeric,
		[Description("^(?!(?:0|0\\.0|0\\.00)$)[+]?\\\\d+(\\.\\\\d|\\.\\\\d[0-9])?$")]
		NonZeroDecimal,
		[Description("Dynamic")]
        Value,
        [Description("")]
        Custom
    }

    public enum JsonResponseType
    {
        Table,
        Row,
        Item,
        Control,
        Dialog,
		CloseDialog,
		RefreshGrid,
		RefreshGridAndClose
    }

    public enum JsonEvent
    {
        click,
        change,
        textchange,
        keyup,
        keydown,
        keypress,
        mouseover,
        mouseout,
        blur
    }

    public enum JsonCompositeEvent
    {
        OnChange,
        OnModeChange,
        OnCancelEdit,
        OnEdited,
        OnSelect,
        OnUploadCompleted,
        OnUploadError,
        OnLogin,
        OnRegister
    }

    public enum JsonAction
    {
        Value,
        Text,
        Html,
        DropDownText,
		CheckState,
        Index,
        Attribute,
        Css,
        Property,
        Message,
        Redirect,
        Constant,
        DataBind,
		Condition,
		ConditionalMessage,
		ConditionalValue,
		ConditionalControlID,
		CloseWindow,
		RefreshGrid,
		CloseWindowAndRefreshGrid,
		JalaliDate,
		GregorianDate,
        Gender,
        StateCity,
        JText,
        Editor,
        Content,
        Menu
    }

	public enum JGenderStyle
	{
		Horizontal,
		Vertical
	}

	public enum JState
	{
		State,
		City,
		Both
	}
    public enum JUploaderType
    {
        Image,
        Text
    }

    public enum JCManager
    {
        Edit,
        View
    }
}
