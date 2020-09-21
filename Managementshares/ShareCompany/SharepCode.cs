using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares.ShareCompany
{
	public class JSharepCode
	{

		public int Code { get; set; }
		public int CompanyCode { get; set; }

		public Int64 SharePCode { get; set; }

		public int PersonCode { get; set; }
		public JSharepCode()
		{
		}

		public int Insert(int pCompanyCode, int PCode)
		{
			return Insert(pCompanyCode, PCode, 0);
		}
		public int Insert(int pCompanyCode,int PCode, Int64 pSharePCode)
		{

			if (find(pCompanyCode, PCode))
				return 0;
			JDataBase DB = new JDataBase();
			try
			{
				if (pSharePCode == 0)
				{
					DB.setQuery("SELECT cast(isnull(max(SharePCode),0)+1 as bigint) mCode from SharePCodeSheet WHERE CompanyCode=" + pCompanyCode.ToString());
					System.Data.DataTable dt = DB.Query_DataTable();
                    SharePCode = Int64.Parse(dt.Rows[0]["mCode"].ToString());
				}
				else
				{
					SharePCode = pSharePCode;
				}

				CompanyCode = pCompanyCode;
				PersonCode = PCode;

				JSharePCodeTable SPT = new JSharePCodeTable();
				SPT.SetValueProperty(this);
				return SPT.Insert();
			}
			finally
			{
				DB.Dispose();
			}
		}

		public static Int64 GetData(int pCompanyCode, int PCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT * from SharePCodeSheet WHERE CompanyCode=" + pCompanyCode.ToString() + " and PersonCode=" + PCode.ToString());
				System.Data.DataTable dt = DB.Query_DataTable();
				if (dt.Rows.Count > 0)
					return Int64.Parse(dt.Rows[0]["SharePCode"].ToString());
				else
					return -1;
			}
			finally
			{
				DB.Dispose();
			}
		}

		public bool Update(int pCompanyCode,int PCode, Int64 pOldSharePCode, Int64 pNewSharePCode)
		{
			if (find(pCompanyCode, PCode, pOldSharePCode, true))
			{
				if (!find(pCompanyCode, PCode, pNewSharePCode, false))
				{
					this.SharePCode = pNewSharePCode;

					JSharePCodeTable SPT = new JSharePCodeTable();
					SPT.SetValueProperty(this);
					return SPT.Update();

				}
			}
			return false;
		}
		public static int GetPersonShare(int pCompanyCode, Int64 pSharePCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT * from SharePCodeSheet WHERE   CompanyCode=" + pCompanyCode.ToString() + " and SharePCode=" + pSharePCode.ToString());
				System.Data.DataTable dt = DB.Query_DataTable();
				if (dt.Rows.Count > 0)
					return (int)dt.Rows[0]["PersonCode"];
				else
					return 0;
			}
			finally
			{
				DB.Dispose();
			}
		}
		public bool find(int pCompanyCode, int PCode)
		{
			return find(pCompanyCode, PCode, false);
		}
		public bool find(int pCompanyCode, int PCode,bool pSetData)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT * from SharePCodeSheet WHERE CompanyCode=" + pCompanyCode.ToString() +
					" and PersonCode=" + PCode.ToString());
				System.Data.DataTable dt = DB.Query_DataTable();
				if (pSetData && dt.Rows.Count == 1)
				{
					JSharePCodeTable.SetToClassProperty(this, dt.Rows[0]);
				}
				return dt.Rows.Count == 1;
			}
			finally
			{
				DB.Dispose();
			}
		}

		public bool find(int pCompanyCode,int pCode, Int64 PShareCode,bool pSetData)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("SELECT * from SharePCodeSheet WHERE CompanyCode=" + pCompanyCode.ToString() +
					" and SharePCode=" + PShareCode.ToString() + " and PersonCode=" + pCode.ToString());
				System.Data.DataTable dt = DB.Query_DataTable();
				if (pSetData && dt.Rows.Count == 1)
				{
					JSharePCodeTable.SetToClassProperty(this, dt.Rows[0]);
				}
				return dt.Rows.Count == 1;
			}
			finally
			{
				DB.Dispose();
			}
		}

	}

	public class JSharePCodeTable : JTable
	{
		public int CompanyCode;

		public Int64 SharePCode;

		public int PersonCode;

		public JSharePCodeTable()
			: base("SharePCodeSheet")
		{
		}
	}
}
