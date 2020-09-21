using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace Estates
{

	/// <summary>
	/// اراضی
	/// </summary>
	public class JLand : JSystem
	{
		#region constructor
		public JLand()
		{

		}
		public JLand(int pCode)
		{
			GetData(pCode);
		}
		#endregion

		#region Property
		/// <summary>
		/// کد اراضی
		/// </summary>
		public int Code
		{
			get;
			set;
		}
		/// <summary>
		/// نام
		/// </summary>
		public string Name
		{
			get;
			set;
		}
		/// <summary>
		/// پلاک ثبتی
		/// </summary>
		public string Plaque
		{
			get;
			set;
		}
		/// <summary>
		/// بخش
		/// </summary>
		public string Section
		{
			set;
			get;
		}

		/// <summary>
		/// مساحت اراضی
		/// </summary>
		/// <returns></returns>    
		public double Area
		{
			get;
			set;
		}
		#endregion

		#region search method

		public override string ToString()
		{
			return this.Name;
		}
		/// <summary>
		/// بررسی  وجود داشتن یک عنوان کاربری در فرم
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		private bool Find(string Name)
		{
			JDataBase tempDb = JGlobal.MainFrame.GetDBO();
			try
			{

				string query = @"select Name from estLand where (Name=" + JDataBase.Quote(Name) + ")";
				tempDb.setQuery(query);
				tempDb.Query_DataReader();
				if (tempDb.DataReader.Read())
				{
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
				tempDb.Dispose();
			}
		}
		public bool GetData(int pCode)
		{
			JDataBase Db = new JDataBase();
			try
			{
				string Query = "select * from " + JTableNamesEstate.LandTable + " where Code=" + pCode + "";
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
				Db.Dispose();
			}
		}


		#endregion

		#region method
		/// <summary>
		/// درج اراضی
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			JDataBase tempDb = new JDataBase();


			try
			{
				if (JPermission.CheckPermission("Estates.JLand.Insert"))
				{
					if (Find(Name))
					{
						JMessages.Error("عنوان تکراری می باشد ", "خطا در درج اطلاعات.");
						return 0;
					}
					JLandTable JLT = new JLandTable();
					JLT.SetValueProperty(this);
					Code = JLT.Insert();
					if (Code > 0)
					{
						if (Nodes != null)
							Nodes.DataTable.Merge(JLands.GetDataTable(Code));

						return Code;
					}
					return 0;
				}
				else
					return 0;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
			finally
			{
				tempDb.Dispose();
			}
		}

		/// <summary>
		/// حذف  اراضی
		/// </summary>
		/// <returns></returns>
		public bool Delete()
		{
			JDataBase Db = new JDataBase();
			try
			{
				if (JPermission.CheckPermission("Estates.JLand.Delete"))
				{
					if (GetGroundCount() > 0)
					{
						JMessages.Message("در این اراضی زمین تعریف شده است و قابل حذف نیست", JLanguages._Text("error"), JMessageType.Error);
						return false;
					}
					if (JMessages.Message(JLanguages._Text("Do you want to remove this Land?"), JLanguages._Text("Question"), JMessageType.Question) != System.Windows.Forms.DialogResult.Yes)
						return false;
					string Query = @"delete " + JTableNamesEstate.LandTable + " where Code=" + Code;
					Db.setQuery(Query);
					if (Db.Query_Execute() < 1)
					{
						return false;
					}
					ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
					AD.DeleteArchive(this.GetType().FullName, Code, true);

					Nodes.Delete(Nodes.CurrentNode);
					return true;
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
			finally
			{
				Db.Dispose();
			}


		}

		/// <summary>
		/// ویرایش یک اراضی
		/// </summary>
		/// <returns></returns>
		public bool Update()
		{
			JDataBase Db = new JDataBase();
			try
			{
				if (JPermission.CheckPermission("Estates.JLand.Update"))
				{
					string Query = @"update " + JTableNamesEstate.LandTable + " set Name='" + Name + "',Plaque='"
						+ Plaque + "',Section='" + Section + "',Area='" + Area + "' where Code='" + Code + "'";
					Db.setQuery(Query);
					if (Db.Query_Execute() < 1)
					{
						return false;
					}
					if (Nodes != null)
						Nodes.Refreshdata(Nodes.CurrentNode, JLands.GetDataTable(Code).Rows[0]);
					return true;
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
			finally
			{
				Db.Dispose();
			}

		}
		public JNode GetNode(DataRow pRow)
		{
			JNode Node = new JNode((int)pRow["Code"], "Estates.JLand");
			Node.Name = pRow["Name"].ToString();
			Node.Icone = JImageIndex.land.GetHashCode();
			Node.Hint = JLanguages._Text("Lands:") + " " + pRow["Name"].ToString() + "\n" +
				JLanguages._Text("Section:") + " " + pRow["Section"].ToString();
			//اکشن ویرایش
			JAction editAction = new JAction("Edit...", "Estates.JLand.ShowDialog", null, new object[] { Node.Code });
			Node.MouseDBClickAction = editAction;
			//اکشن حذف
			JAction DeleteAction = new JAction("Delete", "Estates.JLand.Delete", null, new object[] { Node.Code });
			Node.DeleteClickAction = DeleteAction;
			//اکشن جدید
			JAction newAction = new JAction("New...", "Estates.JLand.ShowDialog", null, null);

			Node.Popup.Insert(DeleteAction);
			Node.Popup.Insert(editAction);
			Node.Popup.Insert(newAction);

			return Node;

		}
		public void ShowDialog()
		{
			if (this.Code == 0)
			{
				JLandForm LandForm = new JLandForm();
				LandForm.State = JFormState.Insert;
				LandForm.ShowDialog();
			}
			else
			{
				JLandForm LandForm = new JLandForm(Code);
				LandForm.State = JFormState.Update;
				LandForm.ShowDialog();
			}
		}
		/// <summary>
		/// تعداد زمین های اراضی را برمی گرداند
		/// </summary>
		/// <returns></returns>
		public int GetGroundCount()
		{
			string Qoury = "select * from " + JTableNamesEstate.GroundTable + " where Land=" + this.Code;
			JDataBase Db = JGlobal.MainFrame.GetDBO();
			try
			{
				Db.setQuery(Qoury);
				int Resualt = (int)Db.Query_ExecutSacler();
				return Resualt;

			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return -1;

			}
			finally
			{
				Db.Dispose();
			}


		}



		#endregion
	}

	public class JLands : JSystem
	{
		public JLand[] Items = new JLand[0];
		public JLands()
		{
			GetData();
		}

		#region GetData
		public DataTable GetDataTable()
		{
			return GetDataTable(0);
		}
		public static DataTable GetDataTable(int pCode)
		{
			string Where = " where 1=1 ";
			if (pCode != 0)
				Where = Where + " And " + JTableNamesEstate.LandTable + ".Code=" + pCode;
			string Query = "select Name,code,Plaque,Section,Area from " + JTableNamesEstate.LandTable + Where +
				" And " + JPermission.getObjectSql("Estates.JLands.GetDataTable", JTableNamesEstate.LandTable + ".Code");
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery(Query);
				return db.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				db.Dispose();
			}
		}

		public void GetData()
		{
			JDataBase DB = JGlobal.MainFrame.GetDBO();
			DB.setQuery("SELECT * FROM " + JTableNamesEstate.LandTable + " Where " + JPermission.getObjectSql("Estates.JLands.GetData"));
			try
			{
				DB.Query_DataReader();
				if (DB.DataReader.HasRows)
				{
					Array.Resize(ref Items, DB.RecordCount);
					int count = 0;
					while (DB.DataReader.Read())
					{
						Items[count] = new JLand();
						Items[count].Area = Convert.ToInt32(DB.DataReader["Area"]);
						Items[count].Code = Convert.ToInt32(DB.DataReader["Code"]);
						Items[count].Section = DB.DataReader["Section"].ToString();
						Items[count].Plaque = DB.DataReader["Plaque"].ToString();
						Items[count].Name = DB.DataReader["Name"].ToString();
						count++;
					}
				}
			}
			finally
			{
				DB.Dispose();
			}
		}
		#endregion GetData

		#region Node
		public void ListView()
		{
			Nodes.ObjectBase = new JAction("Land", "Estates.JLand.GetNode");
			Nodes.DataTable = GetDataTable();
			JAction newAction = new JAction("New...", "Estates.JLand.ShowDialog", null, null);
			Nodes.GlobalMenuActions.Insert(newAction);
			JToolbarNode JTN = new JToolbarNode();
			JTN.Click = newAction;
			JTN.Icon = JImageIndex.Add;

			Nodes.AddToolbar(JTN);


		}

		#endregion Node
	}
}
