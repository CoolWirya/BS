using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Estates
{
	public class JUsageGround : JSystem
	{
		//public static List<string> trace
		//{
		//    set;
		//    get;
		//}
		#region Constructor
		public JUsageGround()
		{
			//trace = new List<string>();
		}
		public JUsageGround(int pCode)
		{
			this.GetData(pCode);
		}
		#endregion

		#region property
		public int Code
		{
			set;
			get;
		}
		public string Name
		{
			set;
			get;
		}
		public string Density
		{
			set;
			get;
		}
		public int Persent
		{
			set;
			get;
		}
		public string Parking
		{
			set;
			get;
		}
		public string Access
		{
			set;
			get;
		}
		public string Comment
		{
			set;
			get;
		}
		#endregion

		#region MethodSearch
		/// <summary>
		/// جستجو عنوان کاربری
		/// </summary>
		/// <param name="Name"></param>
		/// <returns></returns>
		/// 
		private bool Find(string Name)
		{
			JDataBase Db = new JDataBase();
			try
			{
				string Query = "select * from " + JTableNamesEstate.GroundUsageTable + " where Name=N'" + Name + "'";
				Db.setQuery(Query);
				Db.Query_DataReader();
				if (Db.DataReader.Read())
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
				Db.Dispose();
			}

		}
		/// <summary>
		/// اطلاعات کاربری را بر حسب کد کاربری بر میگرداند
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		private bool GetData(int pCode)
		{
			JDataBase Db = new JDataBase();
			try
			{
				string Query = "select * from " + JTableNamesEstate.GroundUsageTable + " where Code=" + pCode + "";
				Db.setQuery(Query);
				Db.Query_DataReader();
				if (Db.DataReader.Read())
				{
					JTable.SetToClassProperty(this, Db.DataReader);
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
				Db.Dispose();
			}
		}
		#endregion

		#region method
		public override string ToString()
		{
			return this.Name;
		}
		/// <summary>
		/// درج اطلاعات کاربری 
		/// </summary>
		/// <returns></returns>

		public bool Insert()
		{
			JDataBase tempDb = new JDataBase();
			try
			{
				if (JPermission.CheckPermission("Estates.JUsageGround.Insert"))
				{
					if (Find(this.Name))
					{
						JMessages.Error("کاربری با این عنوان تعریف شده است.", ".خطا در ورود اطلاعات");
						return false;
					}
					JUsageGroundTable UGT = new JUsageGroundTable();
					UGT.SetValueProperty(this);
					Code = UGT.Insert();
					if (Code > 0)
					{
						if (Nodes != null && Nodes.DataTable != null)
							Nodes.DataTable.Merge(JUsageGrounds.GetDataTable(Code));
						return true;
					}
					return false;
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
				tempDb.Dispose();
			}




		}
		public bool Update()
		{
			JDataBase Db = new JDataBase();
			try
			{
				if (JPermission.CheckPermission("Estates.JUsageGround.Update"))
				{
					string Query = @"update " + JTableNamesEstate.GroundUsageTable + " set " +
						 "Name='" + Name + "',Density='" + Density + "',Persent='" + Persent + "',Parking='" + Parking + "',Access='" + Access + "',Comment='" + Comment + "' where Code='" + Code + "'";
					Db.setQuery(Query);
					if (Db.Query_Execute() < 1)
					{
						return false;
					}
					if (Nodes != null && Nodes.DataTable != null)
						Nodes.Refreshdata(Nodes.CurrentNode, JUsageGrounds.GetDataTable(Code).Rows[0]);
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
		/// کاربری را حذف می کند
		/// </summary>
		/// <returns></returns>
		public bool Delete()
		{
			JDataBase Db = new JDataBase();
			try
			{
				if (JPermission.CheckPermission("Estates.JUsageGround.Delete"))
				{
					if (JMessages.Question("You Sure ?", "Delete") != System.Windows.Forms.DialogResult.Yes)
						return false;
					string Query = @"delete " + JTableNamesEstate.GroundUsageTable + " where Code='" + Code + "'";
					Db.setQuery(Query);
					if (Db.Query_Execute() < 1)
					{
						return false;
					}
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

		public JNode GetNode(DataRow pRow)
		{
			JNode Node = new JNode((int)pRow["Code"], "Estates.JUsageGround");
			Node.Name = pRow["Name"].ToString();
			//Node.Icone = JImageIndex.UsageGround.GetHashCode();
			//اکشن ویرایش
			JAction editAction = new JAction("Edit...", "Estates.JUsageGround.ShowDialog", null, new object[] { Node.Code });
			Node.MouseDBClickAction = editAction;
			Node.EnterClickAction = editAction;
			//اکشن حذف
			JAction deleteAction = new JAction("Delete", "Estates.JUsageGround.Delete", null, new object[] { Node.Code });
			Node.DeleteClickAction = deleteAction;
			//اکشن جدید
			JAction newAction = new JAction("New...", "Estates.JUsageGround.ShowDialog", null, null);
			//پاپ آپ منو
			JPopupMenu pMenu = new JPopupMenu("Esates.JUsageGround", Node.Code);
			Array.Resize(ref pMenu.Actions, 3);
			pMenu.Actions[0] = deleteAction;
			pMenu.Actions[1] = newAction;
			pMenu.Actions[2] = editAction;
			Node.Popup = pMenu;
			return Node;
		}
		public void ShowDialog()
		{
			if (this.Code == 0)
			{
				JUsageGroundForm UsageGroundForm = new JUsageGroundForm();
				UsageGroundForm.State = JFormState.Insert;
				UsageGroundForm.ShowDialog();
			}
			else
			{
				JUsageGroundForm UsageGroundForm = new JUsageGroundForm(this.Code);
				UsageGroundForm.State = JFormState.Update;
				UsageGroundForm.ShowDialog();
			}
		}






		#endregion

	}
	public class JUsageGrounds : JSystem
	{
		public JUsageGround[] items = new JUsageGround[0];
		public JUsageGrounds()
		{
			// GetData();
		}
		#region GetData
		public void GetData()
		{
			JDataBase Db = JGlobal.MainFrame.GetDBO();
			try
			{
				Db.setQuery("select * from " + JTableNamesEstate.GroundUsageTable);
				Db.Query_DataReader();
				if (Db.DataReader.HasRows)
				{
					Array.Resize(ref items, Db.RecordCount);
					int count = 0;
					while (Db.DataReader.Read())
					{
						items[count] = new JUsageGround();
						items[count].Name = Db.DataReader["Name"].ToString();
						items[count].Code = Convert.ToInt32(Db.DataReader["code"]);
						count++;
					}
				}
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);


			}
			finally
			{
				Db.Dispose();
			}

		}
		public static DataTable GetDataTable()
		{
			return GetDataTable(0);
		}

		public static DataTable GetDataTable(int pCode)
		{
			string Where = " where " + JPermission.getObjectSql("Estates.JUsageGrounds.GetDataTable",
				JTableNamesEstate.GroundUsageTable + ".Code");
			if (pCode != 0)
				Where += " And " + JTableNamesEstate.GroundUsageTable + ".Code=" + pCode;
			string Query = "select Name,code,Density,Persent,Parking,Access,Comment from " + JTableNamesEstate.GroundUsageTable + Where
				+ " AND " + JPermission.getObjectSql("Estates.JUsageGrounds.GetDataTable");
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
		#endregion GetData

		#region Node
		public void ListView()
		{
			Nodes.ObjectBase = new JAction("Land", "Estates.JUsageGround.GetNode");
			Nodes.DataTable = GetDataTable();
			JAction NewAction = new JAction("New...", "Estates.JUsageGround.ShowDialog", null, null);
			Nodes.GlobalMenuActions.Insert(NewAction);
			JToolbarNode JTN = new JToolbarNode();
			JTN.Click = NewAction;
			JTN.Icon = JImageIndex.Add;
			Nodes.AddToolbar(JTN);

		}
		#endregion Node
	}

}
