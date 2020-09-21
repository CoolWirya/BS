using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Automation.Refer.SLA
{
	public class JSLADefine
	{
		#region Properties
		/// <summary>
		/// کد
		/// </summary>
		public int Code { get; set; }

		/// <summary>
		/// کد کاربر
		/// </summary>
		public int UserCode { get; set; }

		/// <summary>
		/// کد والد
		/// </summary>
		public int ParentCode { get; set; }

		/// <summary>
		///  workflow گره های
		/// </summary>
		public string Orders { get; set; }

		/// <summary>
		///  work flow نام کلاس
		/// </summary>
		public string ClassName { get; set; }

		/// <summary>
		///  workflow کد کلاس
		/// </summary>
		public int DynamicClassCode { get; set; }

		#endregion

		#region Constructors

		public JSLADefine()
		{
		}

		public JSLADefine(int pCode)
		{
			Code = pCode;
			if (Code > 0)
				GetData(Code);
		}

		#endregion

		#region Methods

		public int Insert(JDataBase db = null)
		{
			JSLADefineTable ST = new JSLADefineTable();
			ST.SetValueProperty(this);
			if (db == null)
				Code = ST.Insert();
			else
				Code = ST.Insert(db);
			return Code;
		}
		public bool Delete()
		{
			JSLADefineTable ST = new JSLADefineTable();
			ST.SetValueProperty(this);
			return ST.Delete();
		}
		public bool Update()
		{
			JSLADefineTable ST = new JSLADefineTable();
			ST.SetValueProperty(this);
			return ST.Update();
		}

		public bool GetData(int pCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT * FROM SLADefines WHERE Code = " + pCode.ToString());
				DB.Query_DataReader();
				if (DB.DataReader.Read())
				{
					JTable.SetToClassProperty(this, DB.DataReader);
					return true;
				}
				return false;
			}
			finally
			{
				DB.Dispose();
			}
		}

		#endregion
	}

	public class JSLADefines
	{
		public static DataTable GetDataTable(string className, int dynamicClassCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT * FROM SLADefines WHERE ClassName = '" + className + "' AND DynamicClassCode = " + dynamicClassCode);
				return DB.Query_DataTable();
			}
			finally
			{
				DB.Dispose();
			}
		}
	}
}
