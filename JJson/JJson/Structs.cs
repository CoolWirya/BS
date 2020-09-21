using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJson
{
	[Serializable]
	public struct JsonResponseParam
	{
		public string ControlToSet;
		public string ReturnField;
		public JsonAction Action;
		public string Name;
		public string Value;
		public string CssUnit;
		public JsonBindableType BindControlType;
		public List<JsonConditionParam> Condition;
	}

	[Serializable]
	public struct JDialogButton
	{
		public string Caption;
		public List<JsonResponse> Actions;
	}

	[Serializable]
	public struct JsonResponse
	{
		public JsonResponseType Type;
		public List<JsonResponseParam> Params;
	}

	[Serializable]
	public struct JsonRequest
	{
		public JsonRequestType Type;
		public string data;
		public List<JsonRequestParam> Params;
        //public List<JsonCondition> Conditions;
		public string URL;
	}

    //[Serializable]
    //public struct JsonCondition
    //{
    //    public string Control;
    //    public JsonAction Type;
    //    public List<JsonConditionParam> Params;
    //}

    //[Serializable]
    //public struct JsonConditionParam
    //{
    //    public string Value;
    //    public string Name;
    //}

	[Serializable]
	public struct JsonConditionParam
	{
		public string Condition;
		public JsonAction Action;
		public string Message;
		//public JsonResponseParam resultSet;
	}

	[Serializable]
	public struct JsonRequestParam
	{
		public JsonAction Type;
		public string Value;
		public string Name;
		public string ControlID;
	}

    [Serializable]
    public struct JsonValidation
    {
        public JsonAction ValueType;
        public JsonRegexType RegexType;
        public string CustomRegex;
        public string ControlID;
		public string OtherControlID;
		public JsonAction OtherValueType;
		public string Message;
    }
}
