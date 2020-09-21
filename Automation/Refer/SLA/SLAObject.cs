using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Automation.Refer.SLA
{
	public class JSLAObject
	{
		#region Properties

		public int Code { get; set; }

		public int SLADefineCode { get; set; }

		public int ObjectsCode { get; set; }

		public Int64 Cost { get; set; }

		#endregion

		#region Constructors

		public JSLAObject()
		{
		}

		public JSLAObject(int pCode)
		{
			Code = pCode;
			if (Code > 0)
				GetData(Code);
		}

		#endregion

		#region Methods

		public int Insert(JDataBase db = null)
		{
			JSLAObjectTable ST = new JSLAObjectTable();
			ST.SetValueProperty(this);
			if (db == null)
				Code = ST.Insert();
			else
				Code = ST.Insert(db);
			return Code;
		}
		public bool Delete()
		{
			JSLAObjectTable ST = new JSLAObjectTable();
			ST.SetValueProperty(this);
			return ST.Delete();
		}
		public bool Update()
		{
			JSLAObjectTable ST = new JSLAObjectTable();
			ST.SetValueProperty(this);
			return ST.Update();
		}

		public bool GetData(int pCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT * FROM SLAObjects WHERE Code = " + pCode.ToString());
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

	public class JSLAObjects
	{
		public static DataTable GetDataTable(int slaDefineCode = 0, int objectsCode = 0)
		{
			JDataBase DB = new JDataBase();
			try
			{
				string query = "SELECT * FROM SLAObjects WHERE 1 = 1";
				query += slaDefineCode > 0 ? " AND SLADefineCode = " + slaDefineCode : "";
				query += slaDefineCode > 0 ? " AND ObjectsCode = " + objectsCode : "";
				DB.setQuery(query);
				return DB.Query_DataTable();
			}
			finally
			{
				DB.Dispose();
			}
		}

		public static Int64 GetDuration(DateTime start, DateTime end)
		{
			return (Int64)end.Subtract(start).TotalMinutes;
		}
	}
}
