using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WebClassLibrary
{
	public class JNode
	{
		public JNode()
		{
		}
		public JNode(List<JActionsInfo> actions, string name, string className, string imageURL, List<JNode> childs)
		{
			Actions = actions;
			Name = name;
			ClassName = className;
			_Childs = childs;
			ImageURL = imageURL;
		}

		/// <summary>
		/// EventName[J===]Method[J,,,]Type[J:::]Value[J,,,]type[J:::]value[J,,,]...
		/// </summary>
		/// <param name="pAction"></param>
		/// <returns></returns>
		public static List<JActionsInfo> GetActions(string actions, bool isDecrypted = false)
		{
			if (isDecrypted == false)
				actions = ClassLibrary.JEnryption.DecryptStr(actions, SessionManager.Current.SessionID);
			List<JActionsInfo> jActions = new List<JActionsInfo>();
			if (actions != null && actions != "")
			{
				foreach (string action in actions.Split(new string[] { JDomains.JConsts.SepEvents }, StringSplitOptions.None))
				{
					jActions.Add(new JActionsInfo(action));
				}
			}
			return jActions;
		}

		private List<JActionsInfo> _Actions;
		public List<JActionsInfo> Actions
		{
			get
			{
				return _Actions;
			}
			set
			{
				_Actions = value;
			}
		}

		public string ActionsToString()
		{
			if (Actions != null && Actions.Count() > 0)
			{
				string result = "";
				foreach (JActionsInfo item in Actions)
				{
					result += JDomains.JConsts.SepEvents + item.ActionToString();
				}
				if (result.StartsWith(JDomains.JConsts.SepEvents)) result = result.Substring(JDomains.JConsts.SepEvents.Length);
				return result;
			}
			return "";
		}

		public string Name;
		public string ClassName;
		public int ObjectCode;
		public string ImageURL;
		public List<JNode> _Childs;
	}

	[Serializable()]
	public class JActionsInfo : ISerializable
	{
		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			//You can use any custom name for your name-value pair. But make sure you
			// read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
			// then you should read the same with "EmployeeId"
			info.AddValue("Name", Name);
			info.AddValue("Event", Event);
			info.AddValue("Method", Method);
			info.AddValue("ConstValue", ConstValue);
			info.AddValue("ParameterValue", ParameterValue);
		}

		public JActionsInfo()
		{
		}
		public JActionsInfo(SerializationInfo info, StreamingContext ctxt)
		{
			Name = (string)info.GetValue("Name", typeof(string));
			Event = (JDomains.JActionEvents)info.GetValue("Event", typeof(JDomains.JActionEvents));
			Method = (string)info.GetValue("Method", typeof(string));
			ConstValue = (List<object>)info.GetValue("ConstValue", typeof(List<object>));
			ParameterValue = (List<object>)info.GetValue("ParameterValue", typeof(List<object>));

		}
		public JActionsInfo(string actionInfo)
		{
			string[] temp = actionInfo.Split(new string[] { JDomains.JConsts.SepEquals }, StringSplitOptions.None);
			Event = (JDomains.JActionEvents)System.Enum.Parse(typeof(JDomains.JActionEvents), temp[0]); ;

			temp = temp[1].Split(new string[] { JDomains.JConsts.SepComma }, StringSplitOptions.None);
			Method = temp[0];
			ParameterValue = new List<object>();
			for (int i = 1; i < temp.Length; i++)
			{
				string[] param = temp[i].Split(new string[] { JDomains.JConsts.SepColon }, StringSplitOptions.None);
				string param_type = param[0];
				string param_value = param[1];
				Object TempValue = null;
				if (param_type.ToLower() == "string")
					TempValue = param_value;
				else if (param_type.ToLower() == "int" || param_type.ToLower() == "int32")
					TempValue = Convert.ToInt32(param_value);
				else if (param_type.ToLower() == "decimal")
					TempValue = Convert.ToDecimal(param_value);
				else if (param_type.ToLower() == "int64")
					TempValue = Convert.ToInt64(param_value);
				else if (param_type.ToLower() == "double")
					TempValue = Convert.ToDouble(param_value);
				else if (param_type.ToLower() == "bool" || param_type.ToLower() == "boolean")
					TempValue = Convert.ToBoolean(param_value);
				else
					TempValue = param_value;
				ParameterValue.Add(TempValue);

			}
		}
		public JActionsInfo(string name, JDomains.JActionEvents jEvent, string method, List<object> constValue, List<object> parameterValue)
		{
			Name = name;
			Event = jEvent;
			Method = method;
			ConstValue = constValue;
			ParameterValue = parameterValue;
		}

		public string Name;
		public JDomains.JActionEvents Event;
		public string Method;
		public List<object> ConstValue;
		public List<object> ParameterValue;

		public object runAction()
		{
			if (Method != null && Method != "")
				return new ClassLibrary.JAction(Name, Method, ParameterValue == null ? new object[] { } : ParameterValue.ToArray(), ConstValue == null ? null : ConstValue.ToArray()).run();
			return null;
		}

		public string ActionToString()
		{
			string _Actions = Event.ToString() + JDomains.JConsts.SepEquals + Method + _ParamToString();
			return ClassLibrary.JEnryption.EncryptStr(_Actions, SessionManager.Current.SessionID);
		}

		private string _ParamToString()
		{
			if (ParameterValue == null) return "";
			string RetValue = "";
			string SepComma = JDomains.JConsts.SepComma;
			foreach (object Param in ParameterValue)
			{
				if (Param is string || Param is String)
					RetValue += SepComma + "string" + JDomains.JConsts.SepColon + Param.ToString();
				else if (Param is int || Param is Int32)
					RetValue += SepComma + "int" + JDomains.JConsts.SepColon + Param.ToString();
				else if (Param is decimal || Param is Decimal)
					RetValue += SepComma + "decimal" + JDomains.JConsts.SepColon + Param.ToString();
				else if (Param is Int64)
					RetValue += SepComma + "int64" + JDomains.JConsts.SepColon + Param.ToString();
				else if (Param is double || Param is Double)
					RetValue += SepComma + "double" + JDomains.JConsts.SepColon + Param.ToString();
				else if (Param is bool || Param is Boolean)
					RetValue += SepComma + "bool" + JDomains.JConsts.SepColon + Param.ToString();
				else if (Param is object[])
					RetValue += SepComma + "object[]" + JDomains.JConsts.SepColon + string.Join(",", (from x in (object[])Param select x.ToString()).ToArray());

				SepComma = JDomains.JConsts.SepComma;
			}
			return RetValue;
		}

	}

	public class JActionsInfoManager
	{
		public static JActionsInfo GetEventAction(string actions, string eventName, bool isDecrypted = false)
		{
			//IEnumerable<JActionsInfo> actionInfo = JActionsInfoManager.GetActions(actions, isDecrypted).Where(m => m.Event == eventName);
			//if (actionInfo != null && actionInfo.Count() > 0)
			//{
			//    return actionInfo.First();
			//}
			return null;
		}
	}

	//public class JToolBar
	//{
	//    public string Name;
	//    public string ImageURL;
	//    public ClassLibrary.JAction Action;
	//}
}
