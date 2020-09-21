using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.IO;
using System.Collections.Specialized;
using System.Data;

namespace ArchivedDocuments
{
	/// <summary>
	/// کلاس آرشیو اسناد
	/// </summary>
	public class JArchiveDocument : JSystem
	{
		#region Properties
		/// <summary>
		/// پایگاه داده
		/// </summary>
		private static JDataBase _PrivateDatabase;
		private JDataBase _Database
		{
			get
			{
				if (_PrivateDatabase == null)
					_PrivateDatabase = new JDataBase();
				return _PrivateDatabase;
			}
			set
			{
				_PrivateDatabase = value;
			}
		}
		/// <summary>
		/// محل بایگانی
		/// </summary>
		public int SubjectCode { get; set; }
		/// <summary>
		/// موضوع بایگانی
		/// </summary>
		public int PlaceCode { get; set; }
		/// <summary>
		/// کد آرشیو
		/// </summary>
		public int Code { get; set; }
		/// <summary>
		/// کد کاربر ارسال کننده
		/// </summary>
		public int OwnerUserCode { get; set; }
		/// <summary>
		/// کد پست ارسال کننده
		/// </summary>
		public int OwnerPostCode { get; set; }
		/// <summary>
		/// کد محتوا
		/// </summary>
		public int ArchiveCode { get; set; }
		/// <summary>
		/// نام کلاس
		/// </summary>
		public string ClassName { get; set; }
		/// <summary>
		/// کد شیء
		/// </summary>
		public int ObjectCode { get; set; }
		/// <summary>
		/// شرح آرشیو
		/// </summary>
		public string ArchiveDesc { get; set; }
		/// <summary>
		/// وضعیت
		/// </summary>
		public int Status { get; set; }
		/// <summary>
		/// تاریخ بایگانی
		/// </summary>
		public DateTime ArchiveDate { get; set; }
		/// <summary>
		/// تغییر کدهای بایگانی بصورت خودکار
		/// </summary>
		public bool AutoChange { get; set; }

		/// <summary>
		/// محتوای سند بایگانی شده
		/// </summary>
		public JFile Content
		{
			get
			{
				return _RetrieveContent(this.ArchiveCode);
			}
		}

		/// <summary>
		/// محدودیت سایز فایل جهت آرشیو به کیلو بایت
		/// </summary>
		public int FileSizeLimit = 30000;
		#endregion

		/// <summary>
		/// سازنده کلاس
		/// </summary>
		public JArchiveDocument()
			: this("", 0)
		{

		}
		public JArchiveDocument(string DataBaseClassName, int DataBaseObjectCode)
		{
			//this._Database = JGlobal.MainFrame.GetDBO();
			if (DataBaseClassName == "")
				this._Database = JGlobal.MainFrame.GetArchiveDB();
			else
			{
				System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
				JConnection conn = new JConnection();
				SqlBuilder = conn.GetSQlServerConnection(DataBaseClassName, DataBaseObjectCode);
				this._Database = new JDataBase(SqlBuilder);
			}
		}

		/// <summary>
		/// سازنده کلاس
		/// </summary>
		/// <param name="pSubjectPlace">کد موضوع - مکان</param>
		public JArchiveDocument(int pSubjectCode, int pPlaceCode)
			: this(pSubjectCode, pPlaceCode, "", 0)
		{

		}
		public JArchiveDocument(int pSubjectCode, int pPlaceCode, string DataBaseClassName, int DataBaseObjectCode)
		{
			//this._Database = JGlobal.MainFrame.GetDBO();
			if (DataBaseClassName == "")
				this._Database = JGlobal.MainFrame.GetArchiveDB();
			else
			{
				System.Data.SqlClient.SqlConnectionStringBuilder SqlBuilder;
				JConnection conn = new JConnection();
				SqlBuilder = conn.GetSQlServerConnection(DataBaseClassName, DataBaseObjectCode);
				this._Database = new JDataBase(SqlBuilder);
			}
			this.SubjectCode = pSubjectCode;
			this.PlaceCode = pPlaceCode;
		}

		public bool GetData(int pCode, bool isArchiveCode = false)
		{
			if (pCode == 0) return false;
			JDataBase Db = this._Database;
			try
			{
				string Query = "";
				if (isArchiveCode == false)
					Query = "select * from ArchiveInterface where Code=" + pCode + "";
				else
					Query = "select * from ArchiveInterface where ArchiveCode=" + pCode + "";
				Db.setQuery(Query);
				Db.Query_DataReader();
				if (Db.DataReader.Read())
				{
					JTable.SetToClassProperty(this, Db.DataReader);
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
			finally
			{
				JDataBase.dbsOpen.delete(Db);
				//Db.Dispose();
			}
		}

		#region Private Functions
		/// <summary>
		/// درج محتوای فایل
		/// </summary>
		/// <param name="pFile">فایل</param>
		/// <param name="pParentCode">کد سند قبلی برای اسنادی که بروز میشوند</param>
		/// <returns>کد سند آرشیو شده را برمیگرداند</returns>
		private int _ArchiveContent(JFile pFile, int pParentCode)
		{
			///  بررسی سایز فایل
			if (pFile.Content != null && pFile.Size / 1024 > FileSizeLimit)
			{
				JMessages.Error("FileIsTooLarg", "Error");
				return 0;
			}

			/// بررسی وجود فایل در آرشیو 
			bool deleted = false;
			int repeat = SearchFile(pFile, ref deleted);
			if (repeat > 0)
			{
				/// در صورتی که فایل وجود دارد ولی حذف شده، آنرا از حالت حذف خارج میکند
				if (deleted)
					_UnDeleteContent(repeat);
				return repeat;
			}


			JDataBase db = this._Database;
			try
			{
				string InsertSQL =
							@"DECLARE @Code INT " +
							JDataBase.GetInsertSQL(JTableNameArchive.ContentTable, "0", false) +

							@"INSERT INTO " + JTableNameArchive.ContentTable +
							@"(Code, FileType , FileExtension, Contents, Size, Status, ParentCode, ArchiveDate, LastAccess, FileText) VALUES
                        (@Code, @FileType , @FileExtension, @Contents, @Size, @Status, @ParentCode, GetDate(), GetDate(), @FileText ) 
                        SELECT @Code";
				db.setQuery(InsertSQL);
				db.Params.Clear();
				db.AddParams("FileType", pFile.FileType.GetHashCode());
				db.AddParams("FileExtension", pFile.Extension);
				db.AddParams("Contents", pFile.Content);
				db.AddParams("Size", pFile.Size);
				db.AddParams("ParentCode", pParentCode);
				db.AddParams("Status", 1);
				db.AddParams("FileText", pFile.FileText);
				int ContentCode = Convert.ToInt32(db.Query_ExecutSacler());
				return ContentCode;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
			finally
			{
			}
		}

		/// <summary>
		/// آرشیو 
		/// </summary>
		/// <param name="pArchiveCode"></param>
		/// <param name="pClassName"></param>
		/// <param name="pObjectCode"></param>
		/// <param name="pOwner"></param>
		/// <param name="pDesc"></param>
		/// <param name="pStatus"></param>
		/// <param name="pAutoChange"></param>
		/// <returns></returns>
		private int _Archive(int pArchiveCode, string pClassName, int pObjectCode, string pDesc, int pStatus, bool pAutoChange)
		{
			if (pClassName == "" || pObjectCode == 0)
				return 0;
			JDataBase db = this._Database;
			try
			{
				string InsertSQL =
							@"DECLARE @Code INT " +

							JDataBase.GetInsertSQL(JTableNameArchive.ArchiveTable, "0", false) +

							@"INSERT INTO " + JTableNameArchive.ArchiveTable +
							@"(Code, ArchiveCode, ClassName, ObjectCode, Owner, OwnerPostCode ,SubjectCode, ArchiveDesc, ArchiveDate,
                              Status, AutoChange, PlaceCode) VALUES
                            (@Code, @ArchiveCode, @ClassName, @ObjectCode, @Owner, @OwnerPostCode, @SubjectCode, @ArchiveDesc, GetDate(),
                             @Status, @AutoChange, @PlaceCode) 
                SELECT @Code";
				db.setQuery(InsertSQL);
				db.Params.Clear();
				db.AddParams("ArchiveCode", pArchiveCode);
				db.AddParams("ClassName", pClassName);
				db.AddParams("ObjectCode", pObjectCode);
				db.AddParams("Owner", JMainFrame.CurrentUserCode);
				db.AddParams("OwnerPostCode", JMainFrame.CurrentPostCode);
				db.AddParams("SubjectCode", this.SubjectCode);
				db.AddParams("PlaceCode", this.PlaceCode);
				db.AddParams("ArchiveDesc", pDesc);
				db.AddParams("Status", pStatus);
				db.AddParams("AutoChange", pAutoChange);
				int ArchiveCode = Convert.ToInt32(db.Query_ExecutSacler());
				return ArchiveCode;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);

				return 0;
			}
		}

		/// <summary>
		/// بازیابی محتوای آرشیو
		/// </summary>
		/// <param name="pArchiveCode"></param>
		/// <returns></returns>
		//private JFile _RetrieveContent(int pArchiveCode)
		//{
		//    JDataBase DB = this._Database;
		//    try
		//    {
		//        DB.setQuery("SELECT * FROM " + JTableNameArchive.ContentTable + " WHERE Code = " + pArchiveCode.ToString());
		//        if (DB.Query_DataSet())
		//        {
		//            if (DB.DataSet.Tables[0].Rows.Count > 0)
		//            {
		//                System.Data.DataRow row = DB.DataSet.Tables[0].Rows[0];
		//                JFile file = new JFile();
		//                file.Content = (byte[])row["Contents"];
		//                file.Extension = row["FileExtension"].ToString();
		//                file.FileSource = JFile.JFileSource.FromArchive;
		//                DB.setQuery("UPDATE " + JTableNameArchive.ContentTable + " SET LastAccess = GETDATE() WHERE Code = " + pArchiveCode.ToString());
		//                DB.Query_Execute();
		//                return file;
		//            }
		//            return null;
		//        }
		//        return null;
		//    }
		//    catch (Exception ex)
		//    {
		//        JSystem.Except.AddException(ex);
		//        return null;
		//    }
		//}


		/// <summary>
		/// بازیابی اطلاعات مربوط به آرشیو و ست کردن مقادیر کلاس
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		private bool _GetData(int pCode)
		{
			JDataBase DB = this._Database;
			try
			{
				DB.setQuery("SELECT * FROM " + JTableNameArchive.ArchiveTable + " WHERE Code = " + pCode.ToString() + " AND Status = 1");
				if (DB.Query_DataReader() && DB.DataReader.Read())
				{
					JTable.SetToClassProperty(this, DB.DataReader);
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
			finally
			{
				DB.DataReader.Close();
			}
		}

		/// <summary>
		/// حذف محتوای آرشیو
		/// </summary>
		/// <param name="pUserCode">کد کاربر</param>
		/// <param name="pDeleteCompletely"> در صورتی که صحیح باشد به صورت کامل حذف میکند، در غیر اینصورت فقط فیلد وضعیت را صفر میکند</param>
		/// <returns></returns>
		private bool _DeleteContent(int pCode, bool pDeleteCompletely)
		{
			JDataBase DB = this._Database;
			string SelectQuery;
			string DeleteQuery;
			if (pDeleteCompletely)
			{
				SelectQuery = " SELECT COUNT(Code) FROM " + JTableNameArchive.ArchiveTable + " WHERE ArchiveCode=" + pCode.ToString();
				DeleteQuery = @" DELETE FROM " + JTableNameArchive.ContentTable + " WHERE Code = " + pCode.ToString();
				DB.setQuery(SelectQuery);
				if (DB.RecordCount > 0)
				{
					//JMessages.Error("ContentBelongsToAnArchivedDocument", "Error");
					return false;
				}
			}
			else
				DeleteQuery = @" UPDATE " + JTableNameArchive.ContentTable + " SET Status=0 WHERE Code = " + pCode.ToString();
			try
			{
				DB.setQuery(DeleteQuery);
				return DB.Query_Execute() > -1;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
			finally
			{
				if (DB.DataReader != null)
					DB.DataReader.Close();
			}
		}
		/// <summary>
		/// حذف محتوا
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		private bool _DeleteContent(int pCode)
		{
			return _DeleteContent(pCode, true);
		}

		private bool _UnDeleteContent(int pCode)
		{
			JDataBase DB = this._Database;
			//string SelectQuery = @" SELECT Code FROM " + JTableNameArchive.ContentTable + " WHERE Code = " + pCode.ToString() + " AND Status=0";
			try
			{
				//  DB.setQuery(SelectQuery);
				//if (DB.Query_DataSet() && DB.DataSet.Tables[0].Rows.Count > 0)
				{

					string UnDeleteQuery = @" UPDATE " + JTableNameArchive.ContentTable + " SET Status=1 WHERE Code = " + pCode.ToString();
					try
					{
						DB.setQuery(UnDeleteQuery);
						return DB.Query_Execute() > -1;
					}
					catch (Exception ex)
					{
						JSystem.Except.AddException(ex);
						return false;
					}
				}
				return false;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
		}
		/// <summary>
		/// بروزرسانی آرشیو با کد جدید
		/// </summary>
		/// <param name="pNewArchiveCode"></param>
		/// <returns></returns>
		private int _UpdateArchive(int pCode, int pNewArchiveCode, int pOwner, string pDesc)
		{
			string DeleteQuery =
				@" UPDATE " + JTableNameArchive.ArchiveTable + " SET ArchiveCode = @ArchiveCode, Owner=@Owner " +
				" , ArchiveDesc=@ArchiveDesc, ArchiveDate=GetDate() WHERE Code =@Code";

			JDataBase DB = this._Database;
			try
			{
				DB.Params.Clear();
				DB.AddParams("ArchiveCode", pNewArchiveCode);
				DB.AddParams("Owner", pOwner);
				DB.AddParams("ArchiveDesc", pDesc);
				//DB.AddParams("ArchiveDate", DateTime.Now);
				DB.AddParams("Code", pCode);
				DB.setQuery(DeleteQuery);
				return DB.Query_Execute();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
		}

		private int _AutoChangeArchive(int pArchiveCode, int pNewArchiveCode)
		{
			string UpdateQuery =
				 @" UPDATE " + JTableNameArchive.ArchiveTable + " SET ArchiveCode =@NewArchiveCode" +
				 " WHERE ArchiveCode =@ArchiveCode AND AutoChange=1";
			JDataBase DB = this._Database;
			try
			{
				DB.Params.Clear();
				DB.AddParams("NewArchiveCode", pNewArchiveCode);
				DB.AddParams("ArchiveCode", pArchiveCode);
				DB.setQuery(UpdateQuery);
				return DB.Query_Execute();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
			finally
			{
			}
		}

		public bool _DeleteArchive(int pCode, bool pDeleteCompletly)
		{
			string DeleteQuery;
			if (pDeleteCompletly)
			{
				DeleteQuery = "DELETE FROM " + JTableNameArchive.ArchiveTable + " WHERE Code=" + pCode.ToString();
			}
			else
				DeleteQuery = "UPDATE " + JTableNameArchive.ArchiveTable + " SET Status = 0 WHERE Code=" + pCode.ToString();
			JDataBase DB = this._Database;
			try
			{
				DB.setQuery(DeleteQuery);
				DB.Query_Execute();
				return true;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
			finally
			{
			}
		}
		public bool _DeleteArchive(string pClassName, int pObjectCode, bool pDeleteCompletly)
		{
			string DeleteQuery;
			if (pDeleteCompletly)
			{
				DeleteQuery = "DELETE FROM " + JTableNameArchive.ArchiveTable + " WHERE ClassName=" + JDataBase.Quote(pClassName) +
					" AND ObjectCode=" + pObjectCode.ToString();
			}
			else
				DeleteQuery = "UPDATE " + JTableNameArchive.ArchiveTable + " SET Status = 0 WHERE ClassName=" + JDataBase.Quote(pClassName) +
					" AND ObjectCode=" + pObjectCode.ToString();
			JDataBase DB = this._Database;
			try
			{
				DB.setQuery(DeleteQuery);
				return DB.Query_Execute() > -1;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
			finally
			{

			}
		}
		#endregion Private Functions

		#region Public Functions
		/// <summary>
		/// آرشیو یک سند بر اساس اسناد آرشیو شده قبلی
		/// </summary>
		/// <param name="pArchiveCode">کد محتوی</param>
		/// <param name="pClassName">نام کلاس</param>
		/// <param name="pObjectCode">کد شیء</param>
		/// <param name="pOwner">کاربر ارسال کننده</param>
		/// <param name="pDesc">شرح آرشیو</param>
		/// <param name="pAutoChange">تغییر بصورت خودکار</param>
		/// <returns></returns>
		public int ArchiveDocument(int pArchiveCode, string pClassName, int pObjectCode, string pDesc, bool pAutoChange)
		{
			try
			{
				return _Archive(pArchiveCode, pClassName, pObjectCode, pDesc, 1, pAutoChange);
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
		}
		/// <summary>
		/// آرشیو سند بر اساس محتوا
		/// </summary>
		/// <param name="pFile">محتوای آرشیو</param>
		/// <param name="pClassName">نام کلاس</param>
		/// <param name="pObjectCode">کد شیء</param>
		/// <param name="pOwner">کاربر ارسال کننده</param>
		/// <param name="pDesc">شرح آرشیو</param>
		/// <param name="pAutoChange">تغییر بصورت خودکار</param>
		/// <returns></returns>
		public int ArchiveDocument(JFile pFile, string pClassName, int pObjectCode, string pDesc, bool pAutoChange)
		{
			try
			{
				if (pClassName.Length == 0 || pObjectCode == 0)
					return 0;
				int ArchiveCode = _ArchiveContent(pFile, 0);
				if (ArchiveCode <= 0)
					return 0;
				return _Archive(ArchiveCode, pClassName, pObjectCode, pDesc, 1, pAutoChange);
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
		}

		/// <summary>
		/// بازیابی فایلها از آرشیو
		/// </summary>
		/// <param name="pUserCode">کد کاربر بازیابی کننده</param>
		/// <param name="pCode">کد آرشیو</param>
		public bool Retrieve(int pCode)
		{
			try
			{
				/// chack perpmissions (Later...)
				/// ----------

				return _GetData(pCode);
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
		}


		/// <summary>
		/// حذف آرشیو
		/// </summary>
		/// <param name="pCode">کد آرشیو</param>
		/// <param name="pDeleteCompletly">حذف بصورت کامل</param>
		/// <returns></returns>
		public bool DeleteArchive(int pCode, bool pDeleteCompletly)
		{
			return DeleteArchive(pCode, pDeleteCompletly, false);
		}

		/// <summary>
		/// حذف آرشیو همراه با محتوا
		/// </summary>
		/// <param name="pCode"></param>
		/// <param name="pDeleteCompletly"></param>
		/// <param name="pDeleteContent"></param>
		/// <returns></returns>
		public bool DeleteArchive(int pCode, bool pDeleteCompletly, bool pDeleteContent)
		{
			if (!_GetData(pCode))
				return true;
			if (_DeleteArchive(pCode, pDeleteCompletly)) //// <------pDeleteCompletly  /// از محتوا چیزی حذف نمیشود
			{
				if (pDeleteContent)
					return _DeleteContent(this.ArchiveCode, pDeleteCompletly);
				return true;
			}
			return false;
		}

		public bool DeleteArchive(string pClassName, int pObjectCode, bool pDeleteCompletly)
		{
			return _DeleteArchive(pClassName, pObjectCode, pDeleteCompletly);
		}


		/// <summary>
		/// بروزرسانی آرشیو بر اساس محتوای جدید
		/// </summary>
		/// <param name="pFile">محتوای جدید</param>
		/// <param name="pCode">کد آرشیو</param>
		/// <param name="pUserCode">کد کاربر ارسال کننده</param>
		/// <param name="pDesc">شرح آرشیو</param>
		/// <param name="pDeleteOdlContent">حذف محتویات قبلی</param>
		/// <returns>یک یا صفر برمیگرداند</returns>
		public int UpdateArchive(JFile pFile, int pCode, string pDesc, bool pDeleteOdlContent)
		{
			_GetData(pCode);
			/// محتوای جدید درج میشود
			int newArchiveCode = _ArchiveContent(pFile, this.ArchiveCode);
			int newCode = 0;
			if (newArchiveCode > 0)
			{
				newCode = _UpdateArchive(pCode, newArchiveCode, JMainFrame.CurrentUserCode, pDesc);
				/// در صورتی که بروزرسانی انجام نشد، محتوای درج شده حذف میشود
				if (newCode <= 0)
				{
					_DeleteContent(newArchiveCode);
					return 0;
				}
				_AutoChangeArchive(this.ArchiveCode, newArchiveCode);
				_DeleteContent(this.ArchiveCode, false);//// <------pDeleteOdlContent  /// از محتوا چیزی حذف نمیشود
				/// 1 یا 0 برمیگرداند
				return newCode;
			}
			else
				return 0;
		}

		/// <summary>
		/// بروزرسانی محتویات آرشیو با حذف محتویات قبلی
		/// </summary>
		/// <param name="pFile">محتوای جدید</param>
		/// <param name="pCode">کد آرشیو</param>
		/// <param name="pUserCode">کد کاربر ارسال کننده</param>
		/// <param name="pDesc">شرح آرشیو</param>
		/// <returns></returns>
		public int UpdateArchive(JFile pFile, int pCode, int pUserCode, string pDesc)
		{
			return UpdateArchive(pFile, pCode, pDesc, true);
		}

		/// <summary>
		/// بروز رسانی آرشیو بر اساس کد آرشیوهای قبلی
		/// </summary>
		/// <param name="pArchiveCode">کد محتوا</param>
		/// <param name="pCode">کد سند آرشیو</param>
		/// <param name="pUserCode">کاربر ارسال کننده</param>
		/// <param name="pDesc">شرح آرشیو</param>
		/// <param name="pDeleteOdlContent">حذف محتوای قبلی</param>
		/// <returns></returns>
		public int UpdateArchive(int pArchiveCode, int pCode, string pDesc, bool pDeleteOdlContent)
		{
			_GetData(pCode);
			int newCode = _UpdateArchive(pCode, pArchiveCode, JMainFrame.CurrentUserCode, pDesc);
			_AutoChangeArchive(this.ArchiveCode, pArchiveCode);
			_DeleteContent(this.ArchiveCode, false); //// <------pDeleteOdlContent  /// از محتوا چیزی حذف نمیشود
			return newCode;
		}
		/// <summary>
		/// ویرایش توضیحات آرشیو
		/// </summary>
		/// <param name="pCode"></param>
		/// <param name="pDesc"></param>
		/// <returns></returns>
		public bool UpdateDescription(int pCode, string pDesc)
		{
			JDataBase DB = this._Database;
			string UpdateQuery = " UPDATE " + JTableNameArchive.ArchiveTable + " SET " + JArchiveFields.ArchiveDesc +
				"= " + JDataBase.Quote(pDesc) +
				" WHERE Code = " + pCode.ToString();
			DB.setQuery(UpdateQuery);
			try
			{
				return DB.Query_Execute() > -1;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
		}

		/// <summary>
		/// جستجوی یک فایل در آرشیو بر اساس سایز، پسوند و محتوای فایل - 
		/// در صورتی که فایل حذف شده پارامتر خروجی ترو میشود Deleted
		/// </summary>
		/// <param name="pFile">فایل ورودی</param>
		/// <returns>کد فایل آرشیو شده را برمیگرداند</returns>
		public int SearchFile(JFile pFile, ref bool Deleted)
		{
			return 0;
			JDataBase DB = this._Database;
			if (pFile.Content == null)
				return 0;
			DB.setQuery("SELECT Code,Status FROM " + JTableNameArchive.ContentTable + " WHERE Size=" + pFile.Size +
				" AND FileExtension=" + JDataBase.Quote(pFile.Extension) + " AND Contents=@Content");
			try
			{

				DB.Params.Clear();
				DB.AddParams("Content", pFile.Content);
				DB.Query_DataSet();
				if (DB.DataSet.Tables[0].Rows.Count == 0)
					return 0;
				/// در صورتی که فایل حذف (منطقی) شده 
				if ((int)DB.DataSet.Tables[0].Rows[0]["Status"] == 0)
					Deleted = true;
				else
					Deleted = false;

				object result = DB.DataSet.Tables[0].Rows[0]["Code"];
				if (result == null)
					return 0;
				else
					return Convert.ToInt32(result);
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
		}


		public IDictionary<string, object> FieldsValue;
		/// <summary>
		/// بازیابی آرشیو یک شیء خاص
		/// </summary>
		/// <param name="pClassName"></param>
		/// <param name="pObjectCode"></param>
		/// <returns></returns>
		public DataTable Retrieve(string pClassName, int pObjectCode)
		{
			return Retrieve(pClassName, pObjectCode, null);
		}
		public DataTable Retrieve(string pClassName, int pObjectCode, IDictionary<string, int[]> ExtraObjects)
		{
			JDataBase DB = this._Database;
			string SelectQuery = @" SELECT [Code]
                  ,[ArchiveCode]
                  ,[ClassName]
                  ,[ObjectCode]
                  ,[Owner]
                  ,[OwnerPostCode]
                  ,[SubjectCode]
                  ,[ArchiveDesc]
                  ,[Status]
                  ,[EveryOne], CAST([ArchiveDate] as Time) [ArchiveTime]
                  ,(Select Fa_date From StaticDates Where En_Date = Cast([ArchiveDate] as DATE)) [ArchiveDate]
                  ,[AutoChange]
                  ,[PlaceCode] FROM " + JTableNameArchive.ArchiveTable + " WHERE  Status = 1  ";
			if (ExtraObjects != null)
			{
				SelectQuery += " AND ( (ClassName=@ClassName AND ObjectCode=@ObjectCode) ";
				foreach (KeyValuePair<string, int[]> Param in ExtraObjects)
				{
					SelectQuery += string.Format(" OR (ClassName = '{0}' AND ObjectCode IN {1}) ", Param.Key, JDataBase.GetInSQLClause(Param.Value));
				}
				SelectQuery += ")";
			}
			else
				SelectQuery += "AND (ClassName=@ClassName AND ObjectCode=@ObjectCode) ";
			try
			{
				SelectQuery = SelectQuery.Replace("@ClassName", "'" + pClassName + "'");
				SelectQuery = SelectQuery.Replace("@ObjectCode", pObjectCode.ToString());
				DB.setQuery(SelectQuery + " ORDER BY ArchiveDate ");
				return DB.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
			}
		}
		public DataTable RetrieveForWeb(string pClassName, int pObjectCode, IDictionary<string, int[]> ExtraObjects)
		{
			JDataBase DB = this._Database;
			string SelectQuery = @" SELECT at.Code, " +
				  "'<img src=\"Images/FileTypes/' + CASE WHEN LEN(ct.[FileExtension])>0 THEN SUBSTRING(ct.[FileExtension],2,LEN(ct.[FileExtension])) ELSE 'unknown' END + '.png\"/>' as FileIcon " + @"
                  ,at.[ArchiveDesc]
                  ,at.[ArchiveCode]
                  ,CAST(at.[ArchiveDate] as Time(0)) [ArchiveTime]
                  ,at.[ArchiveDate]
                  ,ct.[FileExtension]
                  ,ct.[size]
                  FROM " + JTableNameArchive.ArchiveTable + " at" +
						 " INNER JOIN " + JTableNameArchive.ContentTable + " ct ON ct.Code = at.[ArchiveCode] WHERE  at.Status = 1  ";
			if (ExtraObjects != null)
			{
				SelectQuery += " AND ( (ClassName=@ClassName AND ObjectCode=@ObjectCode) ";
				foreach (KeyValuePair<string, int[]> Param in ExtraObjects)
				{
					SelectQuery += string.Format(" OR (ClassName = '{0}' AND ObjectCode IN {1}) ", Param.Key, JDataBase.GetInSQLClause(Param.Value));
				}
				SelectQuery += ")";
			}
			else
				SelectQuery += "AND (ClassName=@ClassName AND ObjectCode=@ObjectCode) ";
			try
			{
				SelectQuery = SelectQuery.Replace("@ClassName", "'" + pClassName + "'");
				SelectQuery = SelectQuery.Replace("@ObjectCode", pObjectCode.ToString());
				DB.setQuery(SelectQuery + " ORDER BY ArchiveDate ");
				return DB.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
			}
		}
		/// <summary>
		/// بروزرسانی تاریخ آخرین دسترسی
		/// </summary>
		/// <param name="pArchiveCode"></param>
		/// <returns></returns>
		private bool _Access(int pArchiveCode)
		{

			JDataBase DB = this._Database;
			string UpdateQuery = " UPDATE " + JTableNameArchive.ContentTable +
				" SET " + JContentFields.LastAccess + " = GetDate() WHERE Code=" + pArchiveCode.ToString();
			try
			{
				DB.setQuery(UpdateQuery);
				return DB.Query_Execute() >= 0;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
		}

		/// <summary>
		/// بازیابی محتوای آرشیو بر اساس کد محتوا
		/// این تابع فقط در کامپوننت آرشیو لیست بعنوان تابع عمومی استفاده می شود
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public JFile _RetrieveContent(int pArchiveCode)
		{
			JDataBase DB = this._Database;
			try
			{
				/// ثبت تاریخ آخرین دسترسی
				if (_Access(pArchiveCode))
				{
					string SelectQuery = "SELECT * FROM " +
						JTableNameArchive.ContentTable +
						" WHERE " + JContentFields.Status.ToString() + " = 1 " +
						" AND " + JContentFields.Code.ToString() +
						" = " + pArchiveCode.ToString();
					DB.setQuery(SelectQuery);

					if (DB.Query_DataSet())
					{
						if (DB.DataSet.Tables[0].Rows.Count > 0)
						{
							JFile file = new JFile();
							file.FileSource = JFile.JFileSource.FromArchive;
							file.Content = (byte[])DB.DataSet.Tables[0].Rows[0][JContentFields.Contents.ToString()];
							file.Extension = DB.DataSet.Tables[0].Rows[0][JContentFields.FileExtension.ToString()].ToString();
							file.FileName = "Temp";
							return file;
						}
					}
				}
				return null;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
		}

		public List<int> GetArchivesCodes(string pClassName, int pObjectCode)
		{
			List<int> files = new List<int>();
			try
			{
				JDataBase DB = this._Database;
				//string selectQuery = "select ai.ArchiveCode from ERP_Archive.dbo.ArchiveInterface ai INNER JOIN ERP_Sepad.dbo.entPicGallery pg ON ai.Code=pg.ArchiveCode where ai.ClassName='" + pClassName + "' and ai.ObjectCode = " + pObjectCode;
				string selectQuery = "select ai.ArchiveCode from ArchiveInterface ai where ai.ClassName = '" + pClassName + "' and ai.ObjectCode = " + pObjectCode;
				DB.setQuery(selectQuery);
				DataTable dt = DB.Query_DataTable();
				for (int i = 0; i < dt.Rows.Count; i++)
					files.Add((int)dt.Rows[i][0]);
				return files;
			}
			catch
			{
			}
			return files;
		}

		public byte[] RetiriveByteContents(int pArchiveCode)
		{
            JDataBase DB = this._Database;
            try
            {
				string selectQuery = "select Contents from [ArchiveContent] where Contents is not null and status=1 and code =" + pArchiveCode;
				DB.setQuery(selectQuery);
				object obj = DB.Query_ExecutSacler();
				return obj as byte[];
			}
			catch
			{
			}
            finally
            {
                DB.Dispose();
                this._Database = null;
            }
			return null;
		}

		/// <summary>
		/// بازیابی محتوای آرشیو بر اساس کد آرشیو
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public JFile RetrieveContent(string pClassName, int pObjectCode, int pCode)
		{
			return RetrieveContent(pCode);
		}

		public JFile RetrieveContent(int pCode)
		{
			JDataBase DB = this._Database;
			try
			{
				string SelectQuery = "SELECT " + JArchiveFields.ArchiveCode.ToString() +
					"," + JArchiveFields.ClassName.ToString() + 
					"," + JArchiveFields.ObjectCode.ToString() + " FROM " +
					JTableNameArchive.ArchiveTable +
					" WHERE " + JArchiveFields.Status.ToString() + " = 1" +
					" AND " + JArchiveFields.ArchiveCode.ToString() +
					" = " + pCode.ToString();

				DB.setQuery(SelectQuery);
				if (DB.Query_DataReader())
					if (DB.DataReader.Read())
					{
						int ArchiveCode = (int)DB.DataReader[JArchiveFields.ArchiveCode.ToString()];
						try
						{
							ClassName = DB.DataReader[JArchiveFields.ClassName.ToString()].ToString();
							ObjectCode = (int)DB.DataReader[JArchiveFields.ObjectCode.ToString()];
						}
						catch (Exception ex)
						{
							JSystem.Except.AddException(ex);
						}
						return _RetrieveContent(ArchiveCode);
					}
				return null;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				if (!DB.DataReader.IsClosed)
					DB.DataReader.Close();
			}
		}

		#region Transaction
		public bool BeginTran()
		{
			return this._Database.beginTransaction("Archive");
		}

		public bool Commit()
		{
			bool Ret = this._Database.Commit();
			return Ret;
		}

		public bool Rollback()
		{
			bool Ret = this._Database.Rollback("Archive");
			return Ret;
		}
		#endregion Transaction

		/// <summary>
		/// جستجوی یک متن خاص در کل آرشیو
		/// </summary>
		/// <param name="pText"></param>
		/// <returns>خروجی یک رشته اس کیو ال </returns>
		public static string SearchText(string pText)
		{
			return SearchText("", pText, 0);
		}

		/// <summary>
		/// جستجوی یک متن در آرشیوهای یک کلاس خاص
		/// </summary>
		/// <param name="pClassName"></param>
		/// <param name="pText"></param>
		/// <returns>خروجی یک رشته اس کیو ال </returns>
		public static string SearchText(string pClassName, string pText)
		{
			return SearchText(pClassName, pText, 0);
		}
		/// <summary>
		/// جستجوی یک متن در آرشیوهای یک کلاس خاص مربوط به یک شیء خاص
		/// </summary>
		/// <param name="pClassName"></param>
		/// <param name="pText"></param>
		/// <param name="pObjectCode"></param>
		/// <returns></returns>
		public static string SearchText(string pClassName, string pText, int pObjectCode)
		{
			string Query = " SELECT * FROM " + JTableNameArchive.ArchiveTable + " WHERE Status = 1 AND ";
			/// در صورتی که نام کلاس خالی نباشد
			if (pObjectCode != 0)
				Query = Query + JArchiveFields.ObjectCode.ToString() + " = " + pObjectCode.ToString() + " AND ";
			if (pClassName.Trim() != "")
				Query = Query + JArchiveFields.ClassName.ToString() + " = " + JDataBase.Quote(pClassName) + " AND ";
			Query = Query + JArchiveFields.ArchiveCode.ToString() + " IN (SELECT " + JContentFields.Code +
			   " FROM " + JTableNameArchive.ContentTable + " WHERE " + JContentFields.FileText.ToString() +
			   " LIKE " + JDataBase.Quote('%' + pText + '%') + ")";
			return Query;
		}


		#endregion Public Functions

		public override void Dispose()
		{
			this._Database.Dispose();
			this._Database = null;
			base.Dispose();
		}

		public JNode GetNode(DataRow pDR)
		{
			JNode _Node = new JNode((int)pDR["Code"], this.GetType().FullName);
			//درخواست آرشیو
			JAction editAction = new JAction("Request Archive...", "ArchivedDocuments.JRequestArchiveFile.ReferShow", new object[] { 0, _Node.Code, 0 }, null);
			//_Node.MouseDBClickAction = editAction;
			_Node.Popup.Insert(editAction);
			return _Node;
		}

	}

	public class JArchiveDocuments : JSystem
	{
		public DataTable GetData(int pPlaceCode, int pSubjectCode)
		{
			string sql = "";
			if (pPlaceCode > 0)
			{
				sql = " PlaceCode = " + pPlaceCode.ToString();
			}
			if (pSubjectCode > 0)
			{
				if (sql.Length > 0)
					sql += " AND ";
				sql += " SubjectCode = " + pSubjectCode.ToString();
			}
			if (sql.Length > 0)
				sql = " where " + sql;
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery(@"select ai.Code,ai.ArchiveCode,
(select dic.text from dic where dic.name=ai.ClassName) as ClassName,
ai.ObjectCode,
(select P.Name+' '+P.Fam from clsPerson P where code in (select users.pcode from users where code = [Owner])) Name,
(select oc.title from organizationchart oc where oc.Code = OwnerPostCode) PostFullTitle,
ai.SubjectCode,
ai.ArchiveDesc,
ai.Status,
ai.EveryOne,
(select sd.Fa_Date from StaticDates sd where sd.En_Date =  CONVERT(date,ai.ArchiveDate)) ArchiveDate,
--ai.ArchiveDate,
ai.AutoChange,
ai.PlaceCode,
--ac.ArchiveDate,
ac.FileExtension,
ac.FileType,
--ac.LastAccess,
(select sd.Fa_Date from StaticDates sd where sd.En_Date =  CONVERT(date,ac.LastAccess)) LastAccess,
ac.ParentCode,ac.Size,ac.Status 
from ArchiveInterface ai inner join ArchiveContent ac
on ai.ArchiveCode = ac.Code
" + sql);
				return DB.Query_DataTable();
			}
			catch
			{
				return null;
			}
			finally
			{
				DB.Dispose();
			}
			return null;
		}

		public void ListView()
		{
			ListView(0, 0);
		}

		public void ListView(int pPlaceCode, int pSubjectCode)
		{
			Nodes.DataTable = GetData(pPlaceCode, pSubjectCode);
			Nodes.ObjectBase = new JAction("ArchiveDocuments", "ArchivedDocuments.JArchiveDocument.GetNode");
		}

	}

}