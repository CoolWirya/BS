using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Refer.SLA
{
	public class JSLAObjectTable : JTable
	{
		public JSLAObjectTable()
			: base("SLAObjects")
		{
		}

		#region Fields

		public int SLADefineCode { get; set; }

		public int ObjectsCode { get; set; }

		public Int64 Cost { get; set; }

		#endregion

	}
}
