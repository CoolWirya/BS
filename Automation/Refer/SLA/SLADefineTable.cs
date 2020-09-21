using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Refer.SLA
{
	public class JSLADefineTable : JTable
	{
		public JSLADefineTable()
			: base("SLADefines")
		{
		}

		#region Fields

		public int UserCode;

		public int ParentCode;

		public string Orders;

		public string ClassName;

		public int DynamicClassCode;

		#endregion
	}
}
