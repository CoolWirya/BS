using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Communication
{
	public class JsecretariatUser
	{
		public int Code
		{
			get;
			set;
		}
		public int secCode { get; set; }
		public int pCode { get; set; }

		public JsecretariatUser()
		{
		}

		public JsecretariatUser(int _Code)
		{
			GetData(_Code);
		}

		public int Insert(JDataBase db)
		{
			JsecretariatUserTable ST = new JsecretariatUserTable();
			ST.SetValueProperty(this);
			Code = ST.Insert(db);
			return Code;
		}

		public Boolean Update(JDataBase db)
		{
			JsecretariatUserTable ST = new JsecretariatUserTable();
			ST.SetValueProperty(this);
			return ST.Update(db);
		}

		public Boolean Delete(JDataBase db)
		{
			JsecretariatUserTable ST = new JsecretariatUserTable();
			ST.SetValueProperty(this);
			return ST.Delete(db);
		}

		public bool GetData(int _Code)
		{
			ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
			DB.setQuery("SELECT * FROM secretariatUser WHERE Code = " + _Code.ToString());
			DB.Query_DataReader();
			if (DB.DataReader.Read())
			{
				ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
				return true;
			}
			return false;
		}
		/// <summary>
		///بروزرسانی فقط   
		/// </summary>
		/// <returns></returns>
		public bool Update(DataTable tmpdt, int psecCode, JDataBase db)
		{
			//JMeetingPersonsTable PDT = new JMeetingPersonsTable();
			try
			{
				if (tmpdt != null)
				{
					foreach (DataRow dr in tmpdt.Rows)
					{
						if ((dr.RowState == DataRowState.Added) || ((dr.RowState == DataRowState.Unchanged) && (dr["Code"].ToString() == "")))
						{
							secCode = psecCode;
							pCode = Convert.ToInt32(dr["PCode"]);
							Insert(db);
							dr["Code"] = Code;
							if (Code < 1)
								return false;
						}
						if ((dr.RowState == DataRowState.Modified) && (dr["Code"].ToString() != ""))
						{
							Code = (int)dr["Code"];
							secCode = psecCode;
							pCode = Convert.ToInt32(dr["PCode"]);
							//GetData(Code);
							if (!Update(db))
								return false;
						}
						if (dr.RowState == DataRowState.Deleted)
						{
							dr.RejectChanges();
							Code = (int)dr["Code"];
							GetData(Code);
							if (!Delete(db))
								return false;
							dr.Delete();
						}
					}
					tmpdt.AcceptChanges();
				}
				return true;
			}
			catch (Exception ex)
			{
				//Except.AddException(ex);
				return false;
			}
			finally
			{
			}
		}
	}

	public class JsecretariatUsers
	{
		/// <summary>
		/// کد اشخاص دبیرخانه
		/// </summary>
		public static string StrCode;

		public static DataTable GetAllUserSec(int psecCode)
		{
			ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
			try
			{
				DB.setQuery(@"
select * from VOrganizationChart where Code in(select manager_user_post_code from secretariat where Code = " + psecCode.ToString() + @")
union
select * from VOrganizationChart where Code in(select Pcode from secretariatUser where secCode =" + psecCode.ToString() + ")");
				return DB.Query_DataTable();
			}
			catch (Exception ex)
			{
				//Except.AddException(ex);
				return null;
			}
			finally
			{
				DB.Dispose();
			}
		}


		public static DataTable GetData(int psecCode)
		{
			ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
			try
			{
				DB.setQuery(@"SELECT A.Code,A.PCode,P.full_title FROM secretariatUser A inner join VOrganizationChart P on A.PCode=P.Code Where secCode =" + psecCode.ToString());
				DataTable dt = DB.Query_DataTable();
				StrCode = "";
				foreach (DataRow dr in dt.Rows)
					StrCode = StrCode + "," + dr["Code"];
				return dt;
			}
			catch (Exception ex)
			{
				//Except.AddException(ex);
				return null;
			}
			finally
			{
				DB.Dispose();
			}
		}

		public static bool CheckUser(int pUserPostCode)
		{
			ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
			try
			{
				DB.setQuery(@"select s.* from secretariat s inner join secretariatUser su on s.Code = su.SecCode where su.Pcode = " + JDataBase.Quote(pUserPostCode.ToString()) +
			  @" union
                              select * from secretariat s where s.manager_user_post_code = " + JDataBase.Quote(pUserPostCode.ToString()));

				DataTable dt = DB.Query_DataTable();
				if (dt.Rows.Count > 0)
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				//Except.AddException(ex);
				return false;
			}
			finally
			{
				DB.Dispose();
			}
		}
	}

}
