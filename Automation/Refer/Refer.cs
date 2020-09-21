using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Employment;

namespace Automation
{
	public class JARefer : JAutomation
	{
		#region Properties

		/// <summary>
		/// کد
		/// </summary>
		public int Code { get; set; }
		/// <summary>
		///کد جدول Object
		/// </summary>
		public int object_code { get; set; }
		/// <summary>
		///کد پدر
		/// </summary>
		public int parent_code { get; set; }
		/// <summary>
		///کد وطیفه 
		/// </summary>
		public int task_code { get; set; }
		/// <summary>
		/// نوع ارجاع 
		/// </summary>
		public int refertype { get; set; }
		/// <summary>
		/// کد  فرستنده خارجی
		/// </summary>      
		public int sender_External_code { get; set; }
		/// <summary>
		/// کد پست فرستنده
		/// </summary>      
		public int sender_post_code { get; set; }
		/// <summary>
		/// کد کاربر فرستنده
		/// </summary>
		public int sender_code { get; set; }
		/// <summary>
		/// عنوان کامل فرستنده
		/// </summary>
		public string sender_full_title { get; set; }
		/// <summary>
		/// تاریخ و زمان ارجاع
		/// </summary>
		public DateTime send_date_time { get; set; }
		/// <summary>
		/// کد  گیرنده خارجی
		/// </summary>      
		public int receiver_External_code { get; set; }
		/// <summary>
		/// کد پست گیرنده
		/// </summary>      
		public int receiver_post_code { get; set; }
		/// <summary>
		///کد کاربر گیرنده
		/// </summary>
		public int receiver_code { get; set; }
		/// <summary>
		/// عنوان کامل گیرنده
		/// </summary>
		public string receiver_full_title { get; set; }
		/// <summary>
		/// وضعیت ارجاع
		/// </summary>
		public int status { get; set; }
		/// <summary>
		/// سطح محرمانگی
		/// </summary>
		public int secret_level { get; set; }
		/// <summary>
		/// تاریخ و زمان پاسخ
		/// </summary>
		public DateTime response_date_time { get; set; }
		/// <summary>
		/// تاریخ و زمان مشاهده
		/// </summary>
		public DateTime view_date_time { get; set; }
		/// <summary>
		/// فعال / غیر فعال
		/// </summary>
		public bool is_active { get; set; }
		/// <summary>
		/// دوره پاسخ
		/// </summary>
		public DateTime respite_date_time { get; set; }
		/// <summary>
		/// فوریت
		/// </summary>
		public int urgency { get; set; }
		/// <summary>
		/// پیام عادی
		/// </summary>
		public string message { get; set; }
		/// <summary>
		/// پیام محرمانه
		/// </summary>
		public string message_secret { get; set; }
		/// <summary>
		/// پاسخ عادی
		/// </summary>
		public string response { get; set; }
		/// <summary>
		/// پاسخ عادی
		/// </summary>
		public string response_secret { get; set; }
		/// <summary>
		/// توضیحات
		/// </summary>
		public string description { get; set; }
		/// <summary>
		/// کد کاربر ثبت کننده
		/// </summary>
		public int register_user_code { get; set; }
		/// <summary>
		/// تاریخ و زمان ثبت
		/// </summary>
		public DateTime register_Date_Time { get; set; }
		/// <summary>
		/// ضمائم
		/// </summary>
		public string attachments { get; set; }
		/// <summary>
		/// سطح درخت در درخت ارجا
		/// </summary>
		public int ReferLevel { set; get; }
		/// <summary>
		/// وضعیت شی در زمان ارجا
		/// </summary>
		public string DescriptionObject { get; set; }
		/// <summary>
		/// گروه ارجا
		/// </summary>
		public int ReferGroup { get; set; }
		/// <summary>
		/// وضعبت در گردش کار
		/// </summary>
		public int WorkFlowCode { get; set; }
		#endregion

		// سازنده های کلاس
		#region Constructors
		/// <summary>
		/// سازنده
		/// </summary>
		public JARefer()
		{
		}
		/// <summary>
		/// سازنده
		/// </summary>
		public JARefer(int pCode)
		{
			if (pCode > 0)
				GetData(pCode);
		}
		#endregion

		// Insert , Update , Delete
		#region BaseFunctions
		public int Insert()
		{
			JDataBase db = new JDataBase();
			try
			{
				db.beginTransaction("insertRefer");
				int retcode = Insert(db);
				if (retcode > 0)
				{
					Code = retcode;
					db.Commit();
					JAObject tmpObjects = new JAObject();
					tmpObjects.GetData(object_code, db);
					JNotifiCationManager NCM = new JNotifiCationManager();
					NCM.Show(tmpObjects.title, "یک " + tmpObjects.title + " از " + sender_full_title + " دارید", receiver_post_code, "", Code);

					if (Nodes != null && Nodes.Name == "JKartableInBOX")
						Nodes.Delete(Nodes.CurrentNode);
					return retcode;
				}
				db.Rollback(db.TransactionName);
				return 0;
			}
			catch
			{
				db.Rollback(db.TransactionName);
				return 0;
			}
			finally
			{
				db.DisConnect();
			}
		}

		public int Insert(JDataBase db)
		{
			return Insert(db, true);
		}

		public int Insert(JDataBase db, bool Flag)
		{
			return Insert(db, Flag, false);
		}
		public int Insert(JDataBase db, bool Flag, bool pManualInsert)
		{
			try
			{
				//در ارسال یک شی به خارج ار شرکت ارجاع پلیان یافته تلقی می گردد
				//if(reciver_extrnal_code>0)
				//    status = ClassLibrary.Domains.JAutomation.JReferStatus.Finish;
				if (parent_code > 0)
				{
					JARefer _refer = new JARefer();
					_refer.GetData(parent_code, db);
					ReferLevel = _refer.ReferLevel + 1;
				}

				JReferTable ActionTable = new JReferTable();
				ActionTable.SetValueProperty(this);
				if (pManualInsert == true) ActionTable.Set_ComplexInsert(false);
				Code = ActionTable.Insert(db);
				if (Code > 0)
				{
					if (refertype == ClassLibrary.Domains.JAutomation.JReferType.External)
					{

					}
					// باید وضعیت ارجاع پدر به حالت ارسال شده تغییر داد
					if (Flag == true)
						if (parent_code > 0)
							if (!ChangeStatusRefer(parent_code, ClassLibrary.Domains.JAutomation.JReferStatus.Sent, db))
								return 0;

					JAObject tmpObjects = new JAObject();
					tmpObjects.GetData(object_code, db);
					string Title = "";
					JNotifiCationManager NCM = new JNotifiCationManager();
					NCM.Show(Title, "یک " + tmpObjects.title + " از " + sender_full_title + " دارید", receiver_post_code, "", Code, true);

					//string x = Nodes.Name;
					//if (JKartable.CurrentKartable == JAFolderTypeEnum.Inbox)
					//Nodes.Delete(Nodes.CurrentNode);
				}
				return Code;
			}
			catch
			{
				return 0;
			}
		}
		public int Send()
		{
			JDataBase DB = new JDataBase();
			return Send(DB, true);
		}

		public int Send(JDataBase db)
		{
			return Send(db, true);
		}

		public int Send(JDataBase db, bool Flag)
		{
			return Send(db, Flag, false);
		}

		public int Send(JDataBase db, bool Flag, bool pManualInsert)
		{
			int retCode = 0;
			JAObject Obj = new JAObject();
			Obj.GetData(object_code, db);
			if (Obj.Code > 0)
			{
				// -1  can not send
				// 0 can send
				// >0 auto send in befor and can not send
				retCode = Obj.BeforReferRun(this, db);
			}
			else return 0;

			if (retCode == 0)
				retCode = Insert(db, Flag, pManualInsert);

			if (retCode > 0)
			{
				if (Obj.Code > 0)
					Obj.AfterReferRun(this, db);
				Code = retCode;
				return retCode;
			}
			return 0;
		}

		public int[] Send(string[] pRecivers, string pDescription, int pWorkFlowCode,
			int pObjectCode, string ptitle, string pClassName, int pDynamicClassName, DataTable pDataTable)
		{
			int[] Ret = new int[0];
			JDataBase db = new JDataBase();
			try
			{
				foreach (string Reciver in pRecivers)
				{
					int d;
					if (int.TryParse(Reciver, out d))
					{

						Employment.JEOrganizationChart jeoc = new Employment.JEOrganizationChart(d);

						Automation.JARefer tmprefer = new Automation.JARefer();
						tmprefer.send_date_time = JDateTime.Now();

						tmprefer.sender_code = JMainFrame.CurrentUserCode;
						tmprefer.sender_full_title = JMainFrame.CurrentPostTitle;
						tmprefer.sender_post_code = JMainFrame.CurrentPostCode;
						tmprefer.receiver_code = Convert.ToInt32(jeoc.user_code);
						tmprefer.receiver_full_title = jeoc.full_Name;
						tmprefer.receiver_post_code = d;
						tmprefer.register_user_code = JMainFrame.CurrentUserCode;
						tmprefer.register_Date_Time = JDateTime.Now();
						tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
						tmprefer.is_active = true;
						tmprefer.ReferGroup = 1;
						tmprefer.parent_code = Code;
						tmprefer.description = pDescription;
						tmprefer.WorkFlowCode = pWorkFlowCode;

						tmprefer.object_code = tmprefer.SendToAutomation(pObjectCode,
																		"", ptitle, pClassName, pDynamicClassName, db,
																		JMainFrame.CurrentPostTitle, JMainFrame.CurrentPostCode,
																	   JMainFrame.CurrentUserCode, false);
						Array.Resize(ref Ret, Ret.Length + 1);
						Ret[Ret.Length - 1] = tmprefer.Send(db, true);
						if (Ret[Ret.Length - 1] > 0)
						{
							(new JWorkFlow(pDataTable, pWorkFlowCode)).RUNSQL();
						}
					}
				}
			}
			finally
			{
				db.Dispose();
			}
			return Ret;
		}

		public int Send(int pRecivers, string pDescription, int pWorkFlowCode,
			int pObjectCode, string ptitle, string pClassName, int pDynamicClassName,
			DataTable pDataTable)
		{
			int Ret;
			JDataBase db = new JDataBase();
			try
			{
				int d = pRecivers;
				{
					Employment.JEOrganizationChart jeoc = new Employment.JEOrganizationChart(d);

					Automation.JARefer tmprefer = new Automation.JARefer();
					tmprefer.send_date_time = JDateTime.Now();

					tmprefer.sender_code = JMainFrame.CurrentUserCode;
					tmprefer.sender_full_title = JMainFrame.CurrentPostTitle;
					tmprefer.sender_post_code = JMainFrame.CurrentPostCode;
					tmprefer.receiver_code = Convert.ToInt32(jeoc.user_code);
					tmprefer.receiver_full_title = jeoc.full_Name;
					tmprefer.receiver_post_code = d;
					tmprefer.register_user_code = JMainFrame.CurrentUserCode;
					tmprefer.register_Date_Time = JDateTime.Now();
					tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
					tmprefer.is_active = true;
					tmprefer.ReferGroup = 1;
					tmprefer.parent_code = Code;
					tmprefer.description = pDescription;
					tmprefer.WorkFlowCode = pWorkFlowCode;
					tmprefer.object_code = tmprefer.SendToAutomation(pObjectCode,
																	"", ptitle, pClassName, pDynamicClassName, db,
																	JMainFrame.CurrentPostTitle, JMainFrame.CurrentPostCode,
																   JMainFrame.CurrentUserCode, false);
					Ret = tmprefer.Send(db, true);
					if (Ret > 0)
					{
						(new JWorkFlow(pDataTable, pWorkFlowCode)).RUNSQL();
					}
				}
			}
			finally
			{
				db.Dispose();
			}
			return Ret;
		}

		public bool Update()
		{
			JDataBase db = new JDataBase();
			try
			{
				if (Update(db))
				{
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
			finally
			{
				db.Dispose();
			}
		}

		public bool Update(JDataBase db)
		{
			JReferTable ActionTable = new JReferTable();
			ActionTable.SetValueProperty(this);
			if (ActionTable.Update(db))
			{
				return true;
			}
			return false;
		}

		public void DeleteObjectAndRefers(string className, int dynamicClassCode, int objectCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Select * from [Objects] Where ClassName=N'" + className + "' AND DynamicClassCode = " + dynamicClassCode.ToString() + " AND ObjectCode = " + objectCode.ToString());
				db.Query_DataReader();
				if (db.DataReader != null && db.DataReader.Read())
				{
					int code = Convert.ToInt32(db.DataReader["Code"]);
					db.Dispose();
					db = new JDataBase();
					db.setQuery("Delete From Refer Where object_code = " + code.ToString());
					db.Query_Execute();
					db.setQuery("Delete From Objects Where Code = " + code.ToString());
					db.Query_Execute();
				}
			}
			finally
			{
				db.Dispose();
			}
		}
		public void DeleteReferByObjectCode(int objectCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Delete From Refer Where object_code = " + objectCode.ToString());
				db.Query_Execute();
				db.setQuery("Delete From Objects Where Code = " + objectCode.ToString());
				db.Query_Execute();
			}
			finally
			{
				db.Dispose();
			}
		}

		public void DeleteRefersByParentReferCode(int ParentReferCode, string archiveClassName, int archiveObjectCode)
		{
			if (ParentReferCode == 0) return;
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Delete From Refer Where parent_code = " + ParentReferCode.ToString());
				db.Query_Execute();
				db.setQuery("update Refer Set status = 1, view_date_time = null Where Code = " + ParentReferCode.ToString());
				db.Query_Execute();
				ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
				jArchDoc.DeleteArchive(archiveClassName, archiveObjectCode, true);

			}
			finally
			{
				db.Dispose();
			}
		}

		public void DeleteReferArchive(string className, int objectCode)
		{

		}

		public bool Delete()
		{
			return Delete(null);
		}

		public bool Delete(JDataBase db)
		{
			try
			{
				//JRefer Refer = new JRefer();
				//Refer.ObjectCode = Code;
				//Refer.Reciever = Creator;
				//Refer.Insert();
				return false;
			}
			catch
			{
				return false;
			}
		}

		public bool Save()
		{
			return Save(null);
		}

		public bool Save(JDataBase db)
		{
			try
			{
				JReferTable ActionTable = new JReferTable();
				ActionTable.SetValueProperty(this);
				if (db == null)
					return ActionTable.Update();
				else
					return ActionTable.Update(db);
			}
			catch
			{
				return false;
			}
		}
		/// <summary>
		/// تغییر وضعیت ارجاع
		/// </summary>
		/// <param name="Code"></param>
		/// <param name="Status"></param>
		/// <returns></returns>
		public static bool ChangeStatusRefer(int Code, int Status, JDataBase db)
		{
			try
			{
				JARefer refer = new JARefer();
				refer.GetData(Code);
				refer.status = Status;
				if (Nodes != null && (Nodes.Name == "JKartableInBOX" || Nodes.Name == "JKartableInFolder"))
					Nodes.Delete(Nodes.CurrentNode);
				return refer.Save(db);
			}
			catch
			{
				return false;
			}
		}
		#endregion BaseFunctions

		//Nodes
		#region Nodes
		#endregion Nodes

		// GetInfo
		#region GetInfo

		/// <summary>
		/// تنظیم مقادیر کلاس
		/// </summary>
		/// <param name="pCode">کد object</param>
		/// <returns>Boolean</returns>
		public Boolean GetData(int pCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				return GetData(pCode, db);
			}
			finally
			{
				db.DisConnect();
			}
		}

		public Boolean GetData(int pCode, JDataBase db)
		{
			//JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{
				db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Refer + " WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
				db.Query_DataReader();
				if (db.DataReader.Read())
				{
					JTable.SetToClassProperty(this, db.DataReader);
					return true;
				}
				return false;
			}
			finally
			{
				//db.Dispose();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pClassName"></param>
		/// <param name="pObjectCode"></param>
		/// <param name="pDynamicClassCode"></param>
		/// <returns></returns>
		public int FindObjectReferByExternalcode(string pClassName, int pObjectCode, int pDynamicClassCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery(@"select * from Objects where 
                ClassName='" + pClassName + "' and DynamicClassCode=" +
				 pDynamicClassCode.ToString() + " and ObjectCode = " + pObjectCode.ToString());
				DB.Query_DataReader();
				if (DB.DataReader != null && DB.DataReader.Read())
				{
					return (int)DB.DataReader["Code"];
				}
				return 0;
			}
			catch
			{
				return 0;
			}
			finally
			{
				DB.Dispose();
			}
		}

		public int FindRefer(string pClassName, int pObjectCode, int pDynamicClassCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("select Refer.Code as Code from Objects " +
							"inner join Refer on Refer.object_code = Objects.Code " +
							"where " +
							"Objects.ClassName='" + pClassName + "' and Objects.DynamicClassCode=" + pDynamicClassCode.ToString() + " and Objects.ObjectCode = " + pObjectCode.ToString() + " " +
							"and (Refer.parent_code is null or Refer.parent_code = 0)");
				DB.Query_DataReader();
				if (DB.DataReader != null && DB.DataReader.Read())
				{
					return (int)DB.DataReader["Code"];
				}
				return 0;
			}
			catch
			{
				return 0;
			}
			finally
			{
				DB.Dispose();
			}
		}

		public int FindRefer(string pClassName, int pObjectCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("select Refer.Code as Code from Objects " +
							"inner join Refer on Refer.object_code = Objects.Code " +
							"where " +
							"Objects.ClassName='" + pClassName + "' and Objects.ObjectCode = " + pObjectCode.ToString() + " " +
							"and (Refer.parent_code is null or Refer.parent_code = 0)");
				DB.Query_DataReader();
				if (DB.DataReader != null && DB.DataReader.Read())
				{
					return (int)DB.DataReader["Code"];
				}
				return 0;
			}
			catch
			{
				return 0;
			}
			finally
			{
				DB.Dispose();
			}
		}

		public int FindReferByExternalcode(string pClassName, int pObjectCode, int pDynamicClassCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("select Refer.Code as Code from Objects " +
							"inner join Refer on Refer.object_code = Objects.Code " +
							"where " +
							"Objects.ClassName='" + pClassName + "' and Objects.DynamicClassCode=" + pDynamicClassCode.ToString() + " and Objects.ObjectCode = " + pObjectCode.ToString() + " " +
							" And receiver_post_code=" + JMainFrame.CurrentPostCode + " And [status]=1");
				DB.Query_DataReader();
				if (DB.DataReader != null && DB.DataReader.Read())
				{
					return (int)DB.DataReader["Code"];
				}
				return 0;
			}
			catch
			{
				return 0;
			}
			finally
			{
				DB.Dispose();
			}
		}
		/// <summary>
		/// جستجوی ارجاعات یک شی خاص
		/// </summary>
		/// <param name="object_code"></param>
		/// <returns></returns>
		public DataTable FindReferByObjectcode(int object_code)
		{
			JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{

				db.setQuery("SELECT " + JReferTable.getFields() + " FROM " + JTableNamesAutomation.Refer + " WHERE " + ClassLibrary.Refer.object_code + "=" + object_code.ToString());
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
			return null;
		}
		public DataTable FindReferByObjectcode(int object_code, string class_name)
		{
			JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{

				db.setQuery("SELECT " + JReferTable.getFields() + " FROM " + JTableNamesAutomation.Objects + " WHERE ObjectCode =" + object_code.ToString() + " AND ClassName = '" + class_name + "'");
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
			return null;
		}
		/// <summary>
		/// اشیای مشاهده نشده یک گیرنده خاص
		/// </summary>
		/// <param name="receiver_code"></param>
		/// <returns></returns>
		public DataTable FindReferNotViewByReceivercode(int receiver_post_code)
		{
			JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{
				db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Refer + " inner join " +
					JTableNamesAutomation.Objects + " on " +
					JTableNamesAutomation.Refer + "." + ClassLibrary.Objects.Code + "=" +
					JTableNamesAutomation.Objects + ".Code WHERE " + ClassLibrary.Refer.status + "=" +
					ClassLibrary.Domains.JAutomation.JReferStatus.Current.ToString() +
					" And ( " + ClassLibrary.Refer.view_date_time + " is null) And  " + ClassLibrary.Refer.receiver_post_code + "=" + receiver_post_code.ToString());
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
			return null;
		}
		/// <summary>
		/// اشیای ارسال شده یک گیرنده خاص
		/// </summary>
		/// <param name="receiver_code"></param>
		/// <returns></returns>
		public DataTable FindReferSendByReceivercode(int receiver_post_code)
		{
			JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{
				db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Refer + " inner join " +
					JTableNamesAutomation.Objects + " on " +
					JTableNamesAutomation.Refer + "." + ClassLibrary.Objects.Code + "=" +
					JTableNamesAutomation.Objects + ".Code WHERE " + ClassLibrary.Refer.status + "=" +
					ClassLibrary.Domains.JAutomation.JReferStatus.Sent.ToString() +
					" And " + ClassLibrary.Refer.receiver_post_code + "=" + receiver_post_code.ToString());
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
			return null;
		}
		/// <summary>
		/// لیست کلیه اشیای کاربر بر اساس کد و پست
		/// </summary>
		/// <param name="receiver_post_code"></param>
		/// <param name="receiver_code"></param>
		/// <returns></returns>
		public DataTable FindReferByReceivercodeAndpost(int receiver_post_code, int receiver_code, string expression)
		{
			JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{
				if (expression != "")
					db.setQuery("SELECT * FROM " + JTableNamesAutomation.Refer + " inner join " + JTableNamesAutomation.Objects + " on " + JTableNamesAutomation.Refer + "." + ClassLibrary.Refer.object_code + "=Objects.Code WHERE Refer.status=" + ClassLibrary.Domains.JAutomation.JReferStatus.Current.ToString() + " And  Refer.receiver_code=" + receiver_code.ToString() + " And " + JTableNamesAutomation.Refer + "." + ClassLibrary.Refer.receiver_post_code + "=" + receiver_post_code + " And " + expression);
				else
					db.setQuery("SELECT * FROM " + JTableNamesAutomation.Refer + " inner join " + JTableNamesAutomation.Objects + " on " + JTableNamesAutomation.Refer + "." + ClassLibrary.Refer.object_code + "=Objects.Code WHERE Refer.status=" + ClassLibrary.Domains.JAutomation.JReferStatus.Current.ToString() + " And  Refer.receiver_code=" + receiver_code.ToString() + " And " + JTableNamesAutomation.Refer + "." + ClassLibrary.Refer.receiver_post_code + "=" + receiver_post_code);
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
			return null;
		}
		/// <summary>
		/// جستجوی شی خاص بر اساس فرستنده
		/// </summary>
		/// <param name="sender_code"></param>
		/// <returns></returns>
		public DataTable FindReferSenderBySendercode(int sender_code)
		{
			JDataBase db = JGlobal.MainFrame.GetDBO();
			try
			{
				db.setQuery("SELECT * FROM " + JTableNamesAutomation.Refer + " inner join " + JTableNamesAutomation.Objects + " on " + JTableNamesAutomation.Refer + "." + ClassLibrary.Refer.object_code + "= " + JTableNamesAutomation.Objects + "." + Objects.Code + " WHERE " + ClassLibrary.Refer.status + "=1 And " + ClassLibrary.Refer.sender_code + "=" + sender_code.ToString());
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
			return null;
		}

		/// <summary>
		/// ارسال یک نامه به اتوماسیون
		/// در این تابع یک نامه در آبجکت اتوماسیون ثبت گردیده و کد ثبت را باز می گرداند
		/// </summary>
		/// <param name="pLetterCode"></param>
		/// <param name="db"></param>
		/// <returns></returns>
		public int SendToAutomation(
			int pObjectCode,
			string pDescription,
			string pTitle,
			string pClassName,
			int pDynamicClassCode,
			JDataBase pdb,
			string pCurrentPostTitle,
			int pCurrentPostCode,
			int pCurrentUserCode,
			bool pUpdate)
		{
			return SendToAutomation(pObjectCode,
									pDescription,
									pTitle,
									pClassName,
									pDynamicClassCode,
									pdb,
									pCurrentPostTitle,
									pCurrentPostCode,
									pCurrentUserCode,
									pUpdate, false);
		}
		public int SendToAutomation(
			int pObjectCode,
			string pDescription,
			string pTitle,
			string pClassName,
			int pDynamicClassCode,
			JDataBase pdb,
			string pCurrentPostTitle,
			int pCurrentPostCode,
			int pCurrentUserCode,
			bool pUpdate,
			bool pManualInsert)
		{
			JDataBase db;
			if (pdb == null)
				db = new JDataBase();
			else
				db = pdb;
			try
			{
				JAObject tempObj = new JAObject();
				tempObj.Find(pClassName, pObjectCode, pDynamicClassCode, db);
				if (tempObj.Code > 0)
				{
					if (pUpdate)
					{
						tempObj.create_date_time = JDateTime.Now();
						tempObj.description = pDescription;
						tempObj.sender_full_title = pCurrentPostTitle;
						tempObj.sender_post_code = pCurrentPostCode;
						tempObj.sender_user_code = pCurrentUserCode;
						tempObj.title = pTitle;
						tempObj.ObjectCode = pObjectCode;
						tempObj.ClassName = pClassName;
						tempObj.action = pClassName + ".ReferShow";
						tempObj.BeforRefer = pClassName + ".BeforRefer";
						tempObj.ActionGetData = pClassName + ".ActionGetData";
						tempObj.DynamicClassCode = pDynamicClassCode;
						tempObj.Update(db);
					}
					return tempObj.Code;
				}
				else
				{

					Automation.JAObject Obj = new Automation.JAObject();
					Obj.create_date_time = JDateTime.Now();
					Obj.description = pDescription;
					Obj.sender_full_title = pCurrentPostTitle;
					Obj.sender_post_code = pCurrentPostCode;
					Obj.sender_user_code = pCurrentUserCode;
					Obj.title = pTitle;
					Obj.ClassName = pClassName;
					Obj.ObjectCode = pObjectCode;
					Obj.action = pClassName + ".ReferShow";
					Obj.BeforRefer = pClassName + ".BeforRefer";
					Obj.ActionGetData = pClassName + ".ActionGetData";
					Obj.DynamicClassCode = pDynamicClassCode;
					return Obj.Insert(db, pManualInsert);
				}
			}
			catch
			{
				return 0;
			}
			finally
			{
				if (pdb == null)
					db.Dispose();
			}
		}
		/// <summary>
		/// بررسی وجود یک نامه در اتوماسیون و برگرداندن کد آن در صورت وجود
		/// </summary>
		/// <param name="pLetterCode"></param>
		/// <returns></returns>
		//public int GetAutomationObjectCode(int pLetterCode, JDataBase DB)
		//{
		//    try
		//    {
		//        Automation.JAObject Obj = new Automation.JAObject();
		//        Obj.GetData(ClassLibrary.Domains.JAutomation.JObjectType.Letters, pLetterCode, DB);
		//        return Obj.Code;
		//    }
		//    catch
		//    {
		//        return 0;
		//    }
		//}

		public bool ReturnRefer(int pReferCode)
		{
			if (GetData(pReferCode))
			{
				int pSender_code = receiver_code;
				int pSender_post_Code = receiver_post_code;
				string pSender_Full_title = receiver_full_title;
				receiver_code = sender_code;
				receiver_post_code = sender_post_code;
				receiver_full_title = sender_full_title;
				sender_code = pSender_code;
				sender_post_code = pSender_post_Code;
				sender_full_title = pSender_Full_title;
				parent_code = pReferCode;
				status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
				if (Send() > 0)
					return true;
				else
					return false;
			}
			else
				return false;
		}


		/// <summary>
		/// اولین ارجا
		/// </summary>
		/// <param name="pReferCode"></param>
		/// <returns></returns>
		public static JARefer FirstRefer(int pReferCode)
		{
			JARefer T = new JARefer(pReferCode);
			if (T.parent_code == 0)
				return T;
			return FirstRefer(T.parent_code);
		}
		public int FindLastRefer(string pClassName, int pObjectCode, int pDynamicClassCode, int PostCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery("select Refer.Code as Code from Objects " +
							"inner join Refer on Refer.object_code = Objects.Code " +
							"where " +
							"Objects.ClassName='" + pClassName + "' and Objects.DynamicClassCode=" + pDynamicClassCode.ToString() + " and Objects.ObjectCode = " + pObjectCode.ToString() + " " +
							"and Refer.Code not in (select isnull(parent_code,0) from Refer) and receiver_post_code = " + PostCode);
				DB.Query_DataReader();
				if (DB.DataReader != null && DB.DataReader.Read())
				{
					return (int)DB.DataReader["Code"];
				}
				return 0;
			}
			catch
			{
				return 0;
			}
			finally
			{
				DB.Dispose();
			}
		}
		#endregion GetInfo

		// Node
		#region Node
		public JNode GetNode()
		{
			//return JAStaticNode._LetterNode(this);
			return null;
		}
		#endregion Node
	}

	public class JARefers : JAutomation
	{
		// سازنده های کلاس
		#region Constructors
		/// <summary>
		/// سازنده
		/// </summary>
		public JARefers()
		{
		}
		#endregion

		// GetInfo
		#region GetInfo

		public static DataTable GetDescriptionByPostCode(int postCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				string query = @"Select t.* from (select distinct CAST(description as nvarchar(max)) as Title, COUNT(CAST(description as nvarchar(max))) as UsedCount from refer 
                                    where sender_post_code = @UserPostCode and LTRIM(RTRIM(CAST(description as nvarchar(max)))) <> ''
                                    group by CAST(description as nvarchar(MAX))) t
                                    order by t.UsedCount desc";
				db.setQuery(query.Replace("@UserPostCode", postCode.ToString()));
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}

		public static DataTable GetRfer(int pPost_Code, int pFolderCode, int Folder_Type)
		{
			if (pFolderCode != 0)
				return GetReferInFolder(pPost_Code, pFolderCode);
			else
				if (Folder_Type == (int)JAFolderTypeEnum.Inbox)
					return GetReferInInbox(pPost_Code);
				else
					if (Folder_Type == (int)JAFolderTypeEnum.SendItem)
						return GetReferInInbox(pPost_Code);
			return null;
		}
		/// <summary>
		/// اشیا کارتابل فردی خاص فولدر Inbox
		/// </summary>
		/// <param name="pPost_Code"></param>
		/// <returns></returns>
		public static DataTable GetReferInInbox(int pPost_Code)
		{
			return GetReferInInbox(pPost_Code, null, 0);
		}

		public static DataTable GetReferInInbox(int pPost_Code, int pFolderCode)
		{
			return GetReferInInbox(pPost_Code, null, pFolderCode);
		}

		public static DataTable GetReferInInbox(int pPost_Code, string[] NotIn, int IN)
		{
			JDataBase DB = new JDataBase();
			try
			{
				string Where = "";
				if (JMainFrame.Successor)
					Where = " And " + JPermission.getObjectSql("Automation.JARefers.GetReferInInbox", "cast(HashBytes('MD5',LOWER(ClassName)+CAST(DynamicClassCode as varchar)) as int)");
				string _SQL = @"SELECT  
                    R.Code,
                    View_date_Time,
                    O. ClassName, O.ObjectCode , O.DynamicClassCode,

					CASE WHEN O.ClassName = 'Communication.JCLetter' OR
                    O.ClassName = 'Communication.JCImportedLetter' OR
                    O.ClassName = 'Communication.JCExportedLetter' THEN
						(Select l.[Sender_Full_Title]  From Letters l Where l.Code = O.ObjectCode)
					ELSE 

						CASE WHEN O.ClassName = 'ClassLibrary.FormManagers'THEN
							O.Sender_Full_Title
						END

					END 'فرستنده',
					CASE WHEN O.ClassName = 'Communication.JCLetter' OR
                    O.ClassName = 'Communication.JCImportedLetter' OR
                    O.ClassName = 'Communication.JCExportedLetter' THEN
						(Select l.receiver_full_title  From Letters l Where l.Code = O.ObjectCode)
					ELSE 

'-'
					END 'گیرنده',

					 R.Receiver_Full_Title,O.action,
                    CASE ISNULL(view_date_time, 0) 
                        WHEN '1900-01-01 00:00:00.000' THEN CAST(0 as bit) 
                        ELSE CAST(1 as bit)
                        END as N'خوانده شده',
                    CASE WHEN O.ClassName = 'Communication.JCLetter' THEN (Select N'نامه داخلی: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
                    WHEN O.ClassName = 'Communication.JCImportedLetter' THEN (Select N'نامه وارده: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
                    WHEN O.ClassName = 'Communication.JCExportedLetter' THEN (Select N'نامه صادره: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
					ELSE O.Title END [Title]
                    ,
                    CASE WHEN O.ClassName = 'Communication.JCLetter' OR
                    O.ClassName = 'Communication.JCImportedLetter' OR
                    O.ClassName = 'Communication.JCExportedLetter' THEN
						(Select l.[Letter_NO]  From Letters l Where l.Code = O.ObjectCode)
					ELSE
						CASE WHEN O.ClassName = 'ClassLibrary.FormManagers'THEN
							(Select cast(l.NoStorage as nvarchar(20)) From FormObjects l Where l.Code = O.ObjectCode)
						END
					END Letter_Number,
                    CASE WHEN O.ClassName = 'Communication.JCLetter' OR
                    O.ClassName = 'Communication.JCImportedLetter' OR
                    O.ClassName = 'Communication.JCExportedLetter' THEN
						(Select cast(l.[incoming_no] as varchar)  From Letters l Where l.Code = O.ObjectCode)
					ELSE
                        '0'
					END IncomingNo,

                    (Select Fa_Date from StaticDates where En_Date = Cast(R.Send_Date_time as date))+ ' ' +CONVERT(varchar,convert(time(0),send_date_time)) AS 'Send_Date_time',
                    R.sender_full_title as 'Refer_full_title',
                    (Select Fa_Date from StaticDates where En_Date = Cast(R.respite_date_Time as date)) AS N'مهلت پاسخ',
                    case secret_level
                        when 0 Then N'عادی'
                        when 1 Then N'عادی'
                        when 2 Then N'محرمانه'
                        when 3 Then N'سری'
                        end 'سطح',
                    case urgency
                        when 1 Then N'عادی'
                        when 2 Then N'سریع'
                        when 3 Then N'خیلی سریع'
                        end N'فوریت'
                    FROM " + JTableNamesAutomation.Refer + " R INNER JOIN " +
				JTableNamesAutomation.Objects + " O ON R." + ClassLibrary.Refer.object_code + "= O.Code WHERE " + ClassLibrary.Refer.receiver_post_code + "=" + pPost_Code
					+ " AND " + ClassLibrary.Refer.status + "=" + (int)ClassLibrary.Domains.JAutomation.JReferStatus.Current
					+ Where;
                if (IN == 0)
                {
                    _SQL += " AND R.Code NOT IN( SELECT referCode FROM " + JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode in (select Code from Folders where DeleteFromKartable<>0 AND FolderType=" + JAFolderTypeEnum.Inbox.GetHashCode().ToString() + ") AND PostCode=" + JMainFrame.CurrentPostCode.ToString() + ")";
                }
                else
                    _SQL += " AND R.Code IN( SELECT referCode FROM " + JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode in (select Code from Folders where FolderType=" + JAFolderTypeEnum.Inbox.GetHashCode().ToString() + ") AND PostCode=" + JMainFrame.CurrentPostCode.ToString() + "AND ReferFolders.ReferFolderCode =" + IN.ToString() + ")";
				if (NotIn != null && NotIn.Length > 0)
				{
					_SQL += " AND R.Code Not IN (" + String.Join(",", NotIn) + ")";
				}
				DB.setQuery(_SQL + "ORDER BY Send_Date_time DESC ");
				return DB.Query_DataTable();
			}
			finally
			{
				DB.DisConnect();
			}
		}
		/// <summary>
		/// اشیا ارسال شده کارتابل فردی خاص فولدر Send
		/// </summary>
		/// <param name="pPost_Code"></param>
		/// <returns></returns>
		public static DataTable GetReferSend(int pPost_Code)
		{
			return GetReferSend(pPost_Code, 0, null, 0);
		}

		public static DataTable GetReferSend(int pPost_Code, int pCode, int IN)
		{
			return GetReferSend(pPost_Code, pCode, null, IN);
		}

		public static DataTable GetReferSend(int pPost_Code, int pCode, string[] NotIn, int IN)
		{
			JDataBase DB = new JDataBase();
			try
			{
				string Where = "";
				if (JMainFrame.Successor)
					Where = " And " + JPermission.getObjectSql("Automation.JARefers.GetReferInInbox", "cast(HashBytes('MD5',LOWER(ClassName)+CAST(DynamicClassCode as varchar)) as int)");

				string _SQL = @"SELECT 
            R.Code,
            O.Code ,
            O. ClassName, O.ObjectCode, O.DynamicClassCode,
            O.action,
            CASE WHEN (O.ClassName = 'Communication.JCLetter' OR O.ClassName = 'Communication.JCImportedLetter') THEN (Select (CASE l.letter_type WHEN 1 THEN N'نامه وارده: ' + (l.[subject] COLLATE DATABASE_DEFAULT) WHEN 3 THEN N'نامه داخلی: ' END) + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode) 
            ELSE O.Title END [Title],
					CASE WHEN O.ClassName = 'Communication.JCLetter' OR
                    O.ClassName = 'Communication.JCImportedLetter' OR
                    O.ClassName = 'Communication.JCExportedLetter' THEN
						(Select l.[Sender_Full_Title]  From Letters l Where l.Code = O.ObjectCode)
					ELSE 

						CASE WHEN O.ClassName = 'ClassLibrary.FormManagers'THEN
							O.Sender_Full_Title
						END

					END 'فرستنده',
					CASE WHEN O.ClassName = 'Communication.JCLetter' OR
                    O.ClassName = 'Communication.JCImportedLetter' OR
                    O.ClassName = 'Communication.JCExportedLetter' THEN
						(Select l.receiver_full_title  From Letters l Where l.Code = O.ObjectCode)
					ELSE 

						'-'

					END 'گیرنده',
           


            R.Receiver_full_title as 'ارجا به',
            (Select Fa_Date from StaticDates where En_Date = cast(R.Send_Date_time as date))+'---'+CONVERT(varchar,convert(time(0),send_date_time)) AS 'Send_Date_time',
            (Select Fa_Date from StaticDates where En_Date = Cast(R.respite_date_Time as date))+'---'+CONVERT(varchar,convert(time(0),respite_date_Time)) AS 'respite_date_Time',
            DescriptionObject,
            
                    CASE WHEN O.ClassName = 'Communication.JCLetter' THEN (Select N'نامه داخلی: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
                    WHEN O.ClassName = 'Communication.JCImportedLetter' THEN (Select N'نامه وارده: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
                    WHEN O.ClassName = 'Communication.JCExportedLetter' THEN (Select N'نامه صادره: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
					ELSE O.Title END [Title],

					CASE WHEN O.ClassName = 'Communication.JCLetter' OR
                    O.ClassName = 'Communication.JCImportedLetter' OR
                    O.ClassName = 'Communication.JCExportedLetter' THEN
						(Select l.[Letter_NO]  From Letters l Where l.Code = O.ObjectCode)
					ELSE 

						CASE WHEN O.ClassName = 'ClassLibrary.FormManagers'THEN
							(Select cast(l.NoStorage as nvarchar(20)) From FormObjects l Where l.Code = O.ObjectCode)
						END
					END Letter_Number,

                    CASE WHEN O.ClassName = 'Communication.JCLetter' OR
                    O.ClassName = 'Communication.JCImportedLetter' OR
                    O.ClassName = 'Communication.JCExportedLetter' THEN
						(Select cast(l.[incoming_no] as varchar)  From Letters l Where l.Code = O.ObjectCode)
					ELSE
                        '0'						
					END IncomingNo,


			case [status]
            when 1 Then 'جاری'
            when 2 Then 'ارسال شده'
            when 3 Then 'ابطال شده'
            when 4 Then 'تمام شده'
            end 'status',
            case secret_level
            when 1 Then 'عادی'
            when 2 Then 'محرمانه'
            when 3 Then 'سری'
            end 'secret_level',
            case urgency
            when 1 Then 'عادی'
            when 2 Then 'سریع'
            when 3 Then 'خیلی سریع'
            end 'urgency',
            (Select Fa_Date from StaticDates where En_Date = Cast(R.View_date_Time as date))+'---'+CONVERT(varchar,convert(time(0),respite_date_Time)) 'View_date_Time',
            case urgency
            when 0 Then 'غیرفعال'
            when 1 Then 'فعال'
            end 'Active',
            R.response,
            R.response_secret,
            R.description
            FROM " + JTableNamesAutomation.Refer + " R INNER JOIN " +
		JTableNamesAutomation.Objects + " O ON R." + ClassLibrary.Refer.object_code + "= O.Code ";

				if (pCode == 0)
				{
					_SQL += "WHERE R." + ClassLibrary.Refer.sender_post_code + "=" + pPost_Code;
				}
				else
					if (pCode > 0)
					{
						_SQL += " WHERE R.Code = " + pCode.ToString();
					}


				if (NotIn != null && NotIn.Length > 0)
				{
					_SQL += " AND R.Code Not IN (" + String.Join(",", NotIn) + ")";
				}

                if (IN == 0)
                {
                    _SQL += " AND R.Code NOT IN( SELECT referCode FROM " + JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode in (select Code from Folders where  DeleteFromKartable<>0 AND FolderType=" + JAFolderTypeEnum.SendItem.GetHashCode().ToString() + ") AND PostCode=" + JMainFrame.CurrentPostCode.ToString() + ")";
                }
                else
                    _SQL += " AND R.Code IN( SELECT referCode FROM " + JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode in (select Code from Folders where FolderType=" + JAFolderTypeEnum.SendItem.GetHashCode().ToString() + ") AND PostCode=" + JMainFrame.CurrentPostCode.ToString() + " AND ReferFolders.ReferFolderCode =" + IN.ToString() + ")";

				DB.setQuery(_SQL + Where + " ORDER  BY Send_Date_time DESC ");
				return DB.Query_DataTable();
			}
			finally
			{
				DB.DisConnect();
			}

		}




		/// <summary>
		/// 
		/// </summary>
		/// <param name="pPost_Code"></param>
		/// <param name="pFolderCode"></param>
		/// <returns></returns>
		public static DataTable GetReferInFolder(int pPost_Code, int pFolderCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				string _SQL = @"SELECT     R.Code, O.Code AS 'ObjectCode', O.action, O.sender_full_title, R.sender_full_title AS 'Refer_full_title', 
                          (SELECT     Fa_Date
                             FROM         StaticDates
                             WHERE     (En_Date = CAST(R.send_date_time AS date))) + '---' + CONVERT(varchar, CONVERT(time(0), R.send_date_time)) AS 'Send_Date_time',
                          (SELECT     Fa_Date
                             FROM         StaticDates AS StaticDates_2
                             WHERE     (En_Date = CAST(R.respite_date_time AS date))) + '---' + CONVERT(varchar, CONVERT(time(0), R.respite_date_time)) AS 'respite_date_Time', 
                      R.DescriptionObject, CASE [status] WHEN 1 THEN 'جاری' WHEN 2 THEN 'ارسال شده' WHEN 3 THEN 'ابطال شده' WHEN 4 THEN 'تمام شده' END AS 'status', 
                      CASE secret_level WHEN 1 THEN 'عادی' WHEN 2 THEN 'محرمانه' WHEN 3 THEN 'سری' END AS 'secret_level', 
                      CASE urgency WHEN 1 THEN 'عادی' WHEN 2 THEN 'سریع' WHEN 3 THEN 'خیلی سریع' END AS 'urgency',
                          (SELECT     Fa_Date
                             FROM         StaticDates AS StaticDates_1
                             WHERE     (En_Date = CAST(R.view_date_time AS date))) + '---' + CONVERT(varchar, CONVERT(time(0), R.respite_date_time)) AS 'View_date_Time', 
                      CASE urgency WHEN 0 THEN 'غیرفعال' WHEN 1 THEN 'فعال' END AS 'Active', R.response, R.response_secret, R.description
FROM         Refer AS R INNER JOIN
                      Objects AS O ON R.object_code = O.Code
WHERE     (R.Code IN
                          (SELECT     ReferCode
                             FROM         ReferFolders
                             WHERE     (ReferFolderCode = " + pFolderCode.ToString() + ")))";
				DB.setQuery(_SQL);
				return DB.Query_DataTable();
			}
			finally
			{
				DB.DisConnect();
			}

		}
		/// <summary>
		/// Get First ReferCode By A ReferCode in Cycle
		/// </summary>
		/// <param name="referCode"></param>
		/// <returns></returns>
		public static int GetFirstRefer(int referCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("select Code from Refer where parent_code is null and object_code = (Select object_code From Refer Where Code = " + referCode.ToString() + ")");
				db.Query_DataReader();
				if (db.DataReader != null && db.DataReader.Read())
					return Convert.ToInt32(db.DataReader["Code"]);
				return 0;
			}
			finally
			{
				db.Dispose();
			}
		}
		/// <summary>
		/// Get Last ReferCode By A ReferCode in Cycle
		/// </summary>
		/// <param name="referCode"></param>
		/// <returns></returns>
		public static int GetLastRefer(int referCode)
		{
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("select Code from Refer where parent_code = " + referCode.ToString());
				db.Query_DataReader();
				int next_referCode = 0;
				if (db.DataReader != null && db.DataReader.Read())
					next_referCode = Convert.ToInt32(db.DataReader["Code"]);
				if (next_referCode == 0) return referCode;
				return GetLastRefer(next_referCode);
			}
			finally
			{
				db.Dispose();
			}
		}
		/// <summary>
		/// کلاسی برای نگهداری اطلاعات یک ارجاع
		/// </summary>
		public class ReferInfo
		{
			public ReferInfo()
			{ }
			public int Code;
			public int Level;
			public bool isRead;
			public DateTime ReadDate;
			public string SenderName;
			public string RecieverName;
			public DateTime Date;
			public string Description;
		}
		/// <summary>
		/// تمام ارجاعات را به صورت درختی در لیستی از کلاس می گذارد
		/// </summary>
		/// <returns></returns>
		public static List<ReferInfo> GetReferList(int objectCode)
		{
			return GetReferList(null, objectCode, 0);
		}
		public static List<ReferInfo> GetReferList(Nullable<int> referCode, int objectCode, int level)
		{
			List<ReferInfo> lstReferInfo = new List<ReferInfo>();
			if (referCode != null)
			{
				JARefer jaRefer = new JARefer(referCode.Value);

				ReferInfo referInfo = new ReferInfo();
				referInfo.Code = jaRefer.Code;
				referInfo.Level = level;
				referInfo.SenderName = jaRefer.sender_full_title;
				referInfo.RecieverName = jaRefer.receiver_full_title;
				referInfo.Date = jaRefer.send_date_time;
				referInfo.Description = jaRefer.description;

				lstReferInfo.Add(referInfo);
			}
			DataTable cDataTable;
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Select Code From Refer Where object_code = " + objectCode.ToString() + " AND parent_code " + ((referCode == null) ? "is null" : " = " + referCode.Value.ToString()));
				cDataTable = db.Query_DataTable();
			}
			finally { db.Dispose(); }

			if (cDataTable != null && cDataTable.Rows.Count > 0)
			{
				foreach (DataRow item in cDataTable.Rows)
				{
					lstReferInfo.AddRange(GetReferList(Convert.ToInt32(item["Code"]), objectCode, level + 1));
				}
			}
			return lstReferInfo;
		}
		/// <summary>
		/// تمام ارجاعات را به صورت درختی در لیستی از کلاس می گذارد
		/// </summary>
		/// <returns></returns>
		public List<ReferInfo> GetSpecificReferList(int referCode)
		{
			List<ReferInfo> lstParentReferInfo = GetParentSpecificReferList(referCode, (new JARefer(referCode)).object_code, 0);
			List<ReferInfo> lstChildReferInfo = GetChildSpecificReferList(referCode, (new JARefer(referCode)).object_code, 0);
			List<ReferInfo> lstReferInfo = new List<ReferInfo>();
			for (int i = lstParentReferInfo.Count - 1; i >= 1; i--)
			{
				lstReferInfo.Add(lstParentReferInfo[i]);
			}
			lstReferInfo = lstReferInfo.Concat(lstChildReferInfo).ToList();
			int min = Math.Abs(lstReferInfo.Min(m => m.Level));
			foreach (ReferInfo item in lstReferInfo)
				item.Level += min + 1;
			return lstReferInfo;
		}
		private List<ReferInfo> GetParentSpecificReferList(Nullable<int> referCode, int objectCode, int level)
		{
			List<ReferInfo> lstReferInfo = new List<ReferInfo>();
			JARefer jaRefer = null;
			if (referCode != null)
			{
				jaRefer = new JARefer(referCode.Value);

				ReferInfo referInfo = new ReferInfo();
				referInfo.Code = jaRefer.Code;
				referInfo.Level = level;
				referInfo.isRead = (jaRefer.view_date_time == null || jaRefer.view_date_time == DateTime.MinValue) ? false : true;
				referInfo.ReadDate = jaRefer.view_date_time;
				referInfo.SenderName = jaRefer.sender_full_title;
				referInfo.RecieverName = jaRefer.receiver_full_title;
				referInfo.Date = jaRefer.send_date_time;
				referInfo.Description = jaRefer.description;

				lstReferInfo.Add(referInfo);
			}

			if (jaRefer != null && jaRefer.parent_code > 0)
			{
				lstReferInfo.AddRange(GetParentSpecificReferList(jaRefer.parent_code, objectCode, level - 1));
			}
			return lstReferInfo;
		}
		private List<ReferInfo> GetChildSpecificReferList(Nullable<int> referCode, int objectCode, int level)
		{
			List<ReferInfo> lstReferInfo = new List<ReferInfo>();
			if (referCode != null)
			{
				JARefer jaRefer = new JARefer(referCode.Value);

				ReferInfo referInfo = new ReferInfo();
				referInfo.Code = jaRefer.Code;
				referInfo.Level = level;
				referInfo.isRead = (jaRefer.view_date_time == null || jaRefer.view_date_time == DateTime.MinValue) ? false : true;
				referInfo.ReadDate = jaRefer.view_date_time;
				referInfo.SenderName = jaRefer.sender_full_title;
				referInfo.RecieverName = jaRefer.receiver_full_title;
				referInfo.Date = jaRefer.send_date_time;
				referInfo.Description = jaRefer.description;

				lstReferInfo.Add(referInfo);
			}
			DataTable cDataTable;
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery("Select Code From Refer Where object_code = " + objectCode.ToString() + " AND parent_code " + ((referCode == null) ? "is null" : " = " + referCode.Value.ToString()));
				cDataTable = db.Query_DataTable();
			}
			finally { db.Dispose(); }

			if (cDataTable != null && cDataTable.Rows.Count > 0)
			{
				foreach (DataRow item in cDataTable.Rows)
				{
					lstReferInfo.AddRange(GetChildSpecificReferList(Convert.ToInt32(item["Code"]), objectCode, level + 1));
				}
			}
			return lstReferInfo;
		}
		/// <summary>
		/// تابعی که متن تمام ارجاعات قبلی را بر میگرداند
		/// </summary>
		/// <param name="pCurrentReferCode"></param>
		/// <returns></returns>
		public static string GetReferTextHistory(int pCurrentReferCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery(@"SELECT Refer.Code,isnull(parent_code,0) parent_code,description,sender_full_title, receiver_full_title, 
                dbo.MiladitoShamsi(send_date_time) send_date, CONVERT(varchar,convert(time(0),send_date_time)) AS send_time, secret_level 
                ,SC.Fam + ' ' + SC.Name SenderInfo  ,RC.Fam + ' ' + RC.Name RecieverInfo, ReferLevel
                     FROM " + ClassLibrary.JTableNamesAutomation.Refer +
				 @" inner join vorganizationchart SC on Refer.sender_post_code = SC.code
                       inner join vorganizationchart RC on Refer.receiver_post_code = RC.Code            
                       WHERE Refer.Code=" + pCurrentReferCode.ToString());
				//
				//DataTable table =DB.Query_DataTable();
				if (DB.Query_DataReader() && DB.DataReader.Read())
				{
					int parent_code = Convert.ToInt32(DB.DataReader[ClassLibrary.Refer.parent_code.ToString()]);
					string desc = "( " + DB.DataReader["ReferLevel"].ToString() + " )" + Environment.NewLine;
					/// ارجاع محرمانه
					if ((int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.Secure.GetHashCode()
						|| (int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.VerySecure.GetHashCode())
						desc = desc + " - *** ";
					else
						desc = desc + " - " + DB.DataReader[ClassLibrary.Refer.description.ToString()].ToString();
					desc = desc + " [" + DB.DataReader["send_date"].ToString() +
						" ساعت: " + DB.DataReader["send_time"].ToString() + "] ";
					DB.setQuery("SELECT Code FROM " + ClassLibrary.JTableNamesAutomation.Refer + " WHERE Code=" + parent_code.ToString());
					DB.Query_DataReader();
					while (DB.DataReader.Read())
					{
						desc =
							JARefers.GetReferTextHistory((int)DB.DataReader["Code"]) +
							Environment.NewLine + " ----------------------------------------------------- " + Environment.NewLine +
							desc +
							Environment.NewLine;

					}
					DB.DisConnect();
					return desc;
				}
				return "";
			}
			catch (Exception ex)
			{
				return "";
			}
			finally
			{
				DB.Dispose();
			}
		}
		/// <summary>
		/// تابعی که متن تمام ارجاعات قبلی را بر میگرداند
		/// </summary>
		/// <param name="pCurrentReferCode"></param>
		/// <returns></returns>
		public static List<string> GetReferTextHistoryForRTB(int pCurrentReferCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery(@"SELECT Refer.Code,isnull(parent_code,0) parent_code,description,sender_full_title, receiver_full_title, 
                dbo.MiladitoShamsi(send_date_time) send_date, CONVERT(varchar,convert(time(0),send_date_time)) AS send_time, secret_level 
                ,SC.Fam + ' ' + SC.Name SenderInfo  ,RC.Fam + ' ' + RC.Name RecieverInfo, ReferLevel
                     FROM " + ClassLibrary.JTableNamesAutomation.Refer +
				 @" inner join vorganizationchart SC on Refer.sender_post_code = SC.code
                       inner join vorganizationchart RC on Refer.receiver_post_code = RC.Code            
                       WHERE Refer.Code=" + pCurrentReferCode.ToString());
				//
				//DataTable table =DB.Query_DataTable();
				List<string> lstDesc = new List<string>();
				if (DB.Query_DataReader() && DB.DataReader.Read())
				{
					int parent_code = Convert.ToInt32(DB.DataReader[ClassLibrary.Refer.parent_code.ToString()]);
					string desc = "";
					//desc = " ( " + DB.DataReader["ReferLevel"].ToString() + " )";
					/// مشخصات
					desc += DB.DataReader["SenderInfo"].ToString() + "   =>   " + DB.DataReader["RecieverInfo"].ToString();
					/// ارجاع محرمانه
					if ((int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.Secure.GetHashCode()
						|| (int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.VerySecure.GetHashCode())
						desc += "  *** ";
					else
						desc += "  متن ارجاع: " + DB.DataReader[ClassLibrary.Refer.description.ToString()].ToString();
					desc += "   تاریخ و زمان ارسال: " + DB.DataReader["send_date"].ToString() + " - " + DB.DataReader["send_time"].ToString();
					lstDesc.Add(desc);
					DB.Dispose();
					DB = new JDataBase();
					DB.setQuery("SELECT Code FROM " + ClassLibrary.JTableNamesAutomation.Refer + " WHERE Code=" + parent_code.ToString());
					DB.Query_DataReader();
					while (DB.DataReader.Read())
					{
						List<string> lststr = JARefers.GetReferTextHistoryForRTB((int)DB.DataReader["Code"]);
						if (lststr != null)
							lstDesc = lstDesc.Concat(lststr).ToList();
					}
					DB.DisConnect();
					return lstDesc;
				}
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				DB.Dispose();
			}
		}
		/// <summary>
		/// تابعی که متن تمام ارجاعات بعدی را بر میگرداند
		/// </summary>
		/// <param name="pCurrentReferCode"></param>
		/// <returns></returns>
		public static List<string> GetNextReferTextHistoryForRTB(int pCurrentReferCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery(@"SELECT Refer.Code,isnull(parent_code,0) parent_code,description,sender_full_title, receiver_full_title, 
                dbo.MiladitoShamsi(send_date_time) send_date, CONVERT(varchar,convert(time(0),send_date_time)) AS send_time, secret_level 
                ,SC.Fam + ' ' + SC.Name SenderInfo  ,RC.Fam + ' ' + RC.Name RecieverInfo, ReferLevel
                     FROM " + ClassLibrary.JTableNamesAutomation.Refer +
				 @" inner join vorganizationchart SC on Refer.sender_post_code = SC.code
                       inner join vorganizationchart RC on Refer.receiver_post_code = RC.Code            
                       WHERE Refer.Code=" + pCurrentReferCode.ToString());
				//
				//DataTable table =DB.Query_DataTable();
				List<string> lstDesc = new List<string>();
				if (DB.Query_DataReader() && DB.DataReader.Read())
				{
					int parent_code = Convert.ToInt32(DB.DataReader[ClassLibrary.Refer.parent_code.ToString()]);
					string desc = "";
					//desc = " ( " + DB.DataReader["ReferLevel"].ToString() + " )";
					/// مشخصات
					desc += DB.DataReader["SenderInfo"].ToString() + "   =>   " + DB.DataReader["RecieverInfo"].ToString();
					/// ارجاع محرمانه
					if ((int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.Secure.GetHashCode()
						|| (int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.VerySecure.GetHashCode())
						desc += "  *** ";
					else
						desc += "  متن ارجاع: " + DB.DataReader[ClassLibrary.Refer.description.ToString()].ToString();
					desc += "   تاریخ و زمان ارسال: " + DB.DataReader["send_date"].ToString() + " - " + DB.DataReader["send_time"].ToString();
					lstDesc.Add(desc);
					DB.Dispose();
					DB = new JDataBase();
					DB.setQuery("SELECT Code FROM " + ClassLibrary.JTableNamesAutomation.Refer + " WHERE parent_code=" + pCurrentReferCode.ToString());
					DB.Query_DataReader();
					while (DB.DataReader.Read())
					{
						List<string> lststr = JARefers.GetNextReferTextHistoryForRTB((int)DB.DataReader["Code"]);
						if (lststr != null)
							lstDesc = lstDesc.Concat(lststr).ToList();
					}
					DB.DisConnect();
					return lstDesc;
				}
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				DB.Dispose();
			}
		}
		/// <summary>
		/// تابعی که متن تمام ارجاعات بعدی را بر میگرداند
		/// </summary>
		/// <param name="pCurrentReferCode"></param>
		/// <returns></returns>
		public static List<string> GetReferTextHistoryForList(int pCurrentReferCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery(@"SELECT Refer.Code,isnull(parent_code,0) parent_code,description,sender_full_title, receiver_full_title, 
                dbo.MiladitoShamsi(send_date_time) send_date, CONVERT(varchar,convert(time(0),send_date_time)) AS send_time, secret_level 
                ,SC.Fam + ' ' + SC.Name SenderInfo  ,RC.Fam + ' ' + RC.Name RecieverInfo, ReferLevel
                     FROM " + ClassLibrary.JTableNamesAutomation.Refer +
				 @" inner join vorganizationchart SC on Refer.sender_post_code = SC.code
                       inner join vorganizationchart RC on Refer.receiver_post_code = RC.Code            
                       WHERE Refer.Code=" + pCurrentReferCode.ToString());
				//
				//DataTable table =DB.Query_DataTable();
				List<string> lstDesc = new List<string>();
				if (DB.Query_DataReader() && DB.DataReader.Read())
				{
					int parent_code = Convert.ToInt32(DB.DataReader[ClassLibrary.Refer.parent_code.ToString()]);
					string desc = "";
					//desc = " ( " + DB.DataReader["ReferLevel"].ToString() + " )";
					/// مشخصات
					desc += DB.DataReader["Code"].ToString() + "\r" + DB.DataReader["SenderInfo"].ToString() + "\r" + DB.DataReader["RecieverInfo"].ToString();
					/// ارجاع محرمانه
					/*
					if ((int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.Secure.GetHashCode()
						|| (int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.VerySecure.GetHashCode())
						desc += "  *** ";
					else
						desc += "  متن ارجاع: " + DB.DataReader[ClassLibrary.Refer.description.ToString()].ToString();
					 */
					desc += "\r" + DB.DataReader["send_date"].ToString() + "\r" + DB.DataReader["send_time"].ToString() +
						"\r" + DB.DataReader["description"].ToString();
					lstDesc.Add(desc);
					DB.Dispose();
					DB = new JDataBase();
					DB.setQuery("SELECT Code FROM " + ClassLibrary.JTableNamesAutomation.Refer + " WHERE Code=" + parent_code.ToString());
					DB.Query_DataReader();
					while (DB.DataReader.Read())
					{
						List<string> lststr = JARefers.GetReferTextHistoryForList((int)DB.DataReader["Code"]);
						if (lststr != null)
							lstDesc = lstDesc.Concat(lststr).ToList();
					}
					DB.DisConnect();
					return lstDesc;
				}
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				DB.Dispose();
			}
		}

		public static List<string> GetNextReferTextHistoryForList(int pCurrentReferCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery(@"SELECT Refer.Code,isnull(parent_code,0) parent_code,description,sender_full_title, receiver_full_title, 
                dbo.MiladitoShamsi(send_date_time) send_date, CONVERT(varchar,convert(time(0),send_date_time)) AS send_time, secret_level 
                ,SC.Fam + ' ' + SC.Name SenderInfo  ,RC.Fam + ' ' + RC.Name RecieverInfo, ReferLevel
                     FROM " + ClassLibrary.JTableNamesAutomation.Refer +
				 @" inner join vorganizationchart SC on Refer.sender_post_code = SC.code
                       inner join vorganizationchart RC on Refer.receiver_post_code = RC.Code            
                       WHERE Refer.Code=" + pCurrentReferCode.ToString());
				//
				//DataTable table =DB.Query_DataTable();
				List<string> lstDesc = new List<string>();
				if (DB.Query_DataReader() && DB.DataReader.Read())
				{
					int parent_code = Convert.ToInt32(DB.DataReader[ClassLibrary.Refer.parent_code.ToString()]);
					string desc = "";
					//desc = " ( " + DB.DataReader["ReferLevel"].ToString() + " )";
					/// مشخصات
					desc += DB.DataReader["Code"].ToString() + "\r" + DB.DataReader["SenderInfo"].ToString() + "\r" + DB.DataReader["RecieverInfo"].ToString();
					/// ارجاع محرمانه
					/*if ((int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.Secure.GetHashCode()
						|| (int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.VerySecure.GetHashCode())
						desc += "  *** ";
					else
						desc += "\r: " + DB.DataReader[ClassLibrary.Refer.description.ToString()].ToString();
					 */
					desc += "\r" + DB.DataReader["send_date"].ToString() + "\r" + DB.DataReader["send_time"].ToString();
					lstDesc.Add(desc);
					DB.Dispose();
					DB = new JDataBase();
					DB.setQuery("SELECT Code FROM " + ClassLibrary.JTableNamesAutomation.Refer + " WHERE parent_code=" + pCurrentReferCode.ToString());
					DB.Query_DataReader();
					while (DB.DataReader.Read())
					{
						List<string> lststr = JARefers.GetNextReferTextHistoryForList((int)DB.DataReader["Code"]);
						if (lststr != null)
							lstDesc = lstDesc.Concat(lststr).ToList();
					}
					DB.DisConnect();
					return lstDesc;
				}
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				DB.Dispose();
			}
		}

		#endregion GetInfo

		public static string GetReferByObjectCodeForWeb(int ObjectCode)
		{
            return "SELECT [Code], [parent_code], [sender_full_title], [receiver_full_title], [send_date_time], [view_date_time],[description] FROM " + JTableNamesAutomation.Refer + " WHERE " + ClassLibrary.Refer.object_code + "=" + ObjectCode.ToString();
		}

        public static DataTable GetRefersByObjectCode(int ObjectCode)
        {

			JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT [Code], isnull([parent_code],0) parent_code, [sender_full_title], [receiver_full_title], [send_date_time], [view_date_time],[description] FROM " +
                    JTableNamesAutomation.Refer + " WHERE " + ClassLibrary.Refer.object_code + "=" + ObjectCode.ToString());
                return db.Query_DataTable();
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }
        
        public static List<JARefer> GetReferByParentReferCode(int ParentReferCode)
		{
			JDataBase db = new JDataBase();
			List<JARefer> jaReferList = new List<JARefer>();
			try
			{
				db.setQuery(@"SELECT * FROM " + JTableNamesAutomation.Refer + " WHERE [parent_code]=" + JDataBase.Quote(ParentReferCode.ToString()));
				db.Query_DataReader();
				while (db.DataReader.Read())
				{
					JARefer item = new JARefer();
					JTable.SetToClassProperty(item, db.DataReader);
					jaReferList.Add(item);
				}
			}
			finally
			{
				db.Dispose();
			}
			return jaReferList;
		}

		public static bool isReferView(int pReferCode)
		{
			JARefer jaRefer = new JARefer(pReferCode);
			int parentReferCode = jaRefer.parent_code;
			if (parentReferCode == 0)
			{
				if (jaRefer.view_date_time != null && jaRefer.view_date_time > DateTime.MinValue)
					return true;
				return false;
			}
			List<JARefer> jaReferList = GetReferByParentReferCode(parentReferCode);
			bool isView = false;
			foreach (JARefer refer in jaReferList)
			{
				if (refer.view_date_time != null && refer.view_date_time > DateTime.MinValue)
					isView = true;
			}
			return isView;
		}

		public static void ReturnRefer(int pReferCode)
		{
			JARefer jaRefer = new JARefer(pReferCode);
			if (jaRefer.parent_code == 0)
			{
				(new JARefer()).DeleteReferByObjectCode(jaRefer.object_code);
				return;
			}
			else
				(new JARefer()).DeleteRefersByParentReferCode(jaRefer.parent_code, Automation.Refer.frmRecieverSelector._ConstClassName, pReferCode);
		}

		// View Nodes
		#region View
		public JNode[] TreeView()
		{

			//JNode[] N = new JNode[3];
			//N[0] = JAStaticNode._LetterRegisterImportsNode();
			//N[1] = JAStaticNode._LetterRegisterExportsNode();
			//N[2] = JAStaticNode._LetterRegisterInternalsNode();
			//return N;
			return null;
		}
		public void ListView()
		{

			//Nodes.Insert(JAStaticNode._LetterRegisterImportsNode());
			//Nodes.Insert(JAStaticNode._LetterRegisterExportsNode());
			//Nodes.Insert(JAStaticNode._LetterRegisterInternalsNode());
			//foreach (JLetter Sec in Items)
			//{
			//    Nodes.Insert(Sec.GetNode());
			//}
		}

		internal static DataTable GetReferListHistory(int pCurrentRefer)
		{
			JDataBase DB = new JDataBase();
			try
			{
				DB.setQuery(@"SELECT Refer.Code,isnull(parent_code,0) parent_code,description,sender_full_title, receiver_full_title, 
                dbo.MiladitoShamsi(send_date_time) send_date, CONVERT(varchar,convert(time(0),send_date_time)) AS send_time, secret_level 
                 FROM " + ClassLibrary.JTableNamesAutomation.Refer +
				 @" inner join vorganizationchart SC on Refer.sender_post_code = SC.code
                       inner join vorganizationchart RC on Refer.receiver_post_code = RC.Code            
                       WHERE Refer.Code=" + pCurrentRefer.ToString());
				//
				//DataTable table =DB.Query_DataTable();
				if (DB.Query_DataReader() && DB.DataReader.Read())
				{
					int parent_code = Convert.ToInt32(DB.DataReader[ClassLibrary.Refer.parent_code.ToString()]);
					string desc = DB.DataReader["SenderInfo"].ToString() +
						" --> " + DB.DataReader["RecieverInfo"].ToString();
					/// ارجاع محرمانه
					if ((int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.Secure.GetHashCode()
						|| (int)DB.DataReader[ClassLibrary.Refer.secret_level.ToString()] == ClassLibrary.Domains.JGlobal.JPrivacy.VerySecure.GetHashCode())
						desc = desc + " - *** ";
					else
						desc = desc + " - " + DB.DataReader[ClassLibrary.Refer.description.ToString()].ToString();
					desc = desc + " [" + DB.DataReader["send_date"].ToString() +
						" ساعت: " + DB.DataReader["send_time"].ToString() + "] ";
					DB.setQuery("SELECT Code FROM " + ClassLibrary.JTableNamesAutomation.Refer + " WHERE Code=" + parent_code.ToString());
					/*                    DB.Query_DataReader();
										while (DB.DataReader.Read())
										{
											desc =
												JARefers.GetReferTextHistory((int)DB.DataReader["Code"]) +
												Environment.NewLine + " ----------------------------------------------------- " + Environment.NewLine +
												desc +
												Environment.NewLine;

										}
										DB.DisConnect();
					*/
					return DB.Query_DataTable();
				}
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			finally
			{
				DB.Dispose();
			}
		}


		#endregion View


		#region Refer

		#endregion Refer

	}
}
