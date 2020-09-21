using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using ClassLibrary;
using Finance;
using RealEstate;

namespace Estates
{
	/// <summary>
	/// انواع وضعیت زمین
	/// </summary>
	public enum JGroundStatus
	{
		/// <summary>
		/// اصلی
		/// </summary>
		Main = 1,
		/// <summary>
		/// تفکیک شده
		/// </summary>
		BrokeDown = 2,
		/// <summary>
		/// تجمیع شده
		/// </summary>
		Aggregated = 3,
		/// <summary>
		/// افراز شده
		/// </summary>
		Partitioned = 4

	}
	/// <summary>
	/// زمین
	/// </summary>
	public class JGround : JSystem
	{

		#region constructor
		public JGround()
		{
			_LoadEmptyOwners();
			this.About = new JAbout();
		}
		public JGround(int pCode, JDataBase Db)
		{

			this.GetData(pCode, Db);
			this.About = new JAbout(pCode, Db);
		}
		public JGround(int pCode)
		{
			this.GetData(pCode, null);
			this.About = new JAbout(pCode, null);
		}
		#endregion

		#region Proprty


		/// <summary>
		/// کد زمین
		/// </summary>
		public int Code
		{
			set;
			get;
		}
		/// <summary>
		/// اراضی
		/// </summary>
		public int Land
		{
			set;
			get;
		}
		/// <summary>
		/// پلاک اصلی
		/// </summary>

		public string MainAve
		{
			set;
			get;
		}
		/// <summary>
		/// پلاک فرعی
		/// </summary>
		public string SubNo
		{
			set;
			get;
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
		/// شماره بلوک
		/// </summary>
		public string BlockNum
		{
			set;
			get;
		}
		/// <summary>
		/// شماره قطعه
		/// </summary>
		public string PartNum
		{
			set;
			get;
		}
		/// <summary>
		/// کاربری
		/// </summary>
		public int Usage
		{
			set;
			get;
		}
		/// <summary>
		/// مساحت
		/// </summary>
		public double Area
		{
			set;
			get;
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Date
		{
			set;
			get;
		}

		public string Comment
		{
			set;
			get;
		}


		public string CommentUpdate
		{
			set;
			get;
		}

		public int Person
		{
			set;
			get;
		}
		/// <summary>
		/// نوع ملک:ملکی یا آستانه
		/// </summary>
		public int EstateType
		{
			get;
			set;
		}
		//public int State
		//{
		//    set;
		//    get;
		//}
		/// <summary>
		/// حدود اربعه
		/// </summary>
		public JAbout About
		{
			get;
			set;
		}
		/// <summary>
		/// لیست مالکین اولیه
		/// </summary>
		public DataTable PrimeryOwners
		{
			get;
			set;
		}
		/// <summary>
		/// وضعیت زمین - تفکیک شده ، اصلی، حاصل از تفکیک
		/// </summary>
		public JGroundStatus Status
		{
			set;
			get;
		}
		/// <summary>
		/// ارزش زمین
		/// </summary>
		public decimal Cost
		{
			set;
			get;
		}
		/// <summary>
		/// نام کلاسی که این  زمین را ایجاد کرده است
		/// </summary>
		public string MakeFromName
		{
			set;
			get;
		}
		/// <summary>
		/// کد کلاسی که این زمین را ایجاد کرده است
		/// </summary>
		public int MakeFromCode
		{
			set;
			get;
		}
		/// <summary>
		/// حق ریشه دارد یا نه
		/// </summary>
		public bool RightRoot
		{
			set;
			get;
		}
		/// <summary>
		/// نوع سند زمین
		/// </summary>
		public int DocumentType
		{
			set;
			get;
		}
		/// <summary>
		/// کد تصویر کروکی در آرشیو
		/// </summary>
		public int Korooki { get; set; }
		/// <summary>
		/// تعداد تقصیمات زمین
		/// </summary>
		public int TotalShare { get; set; }
		/// <summary>
		/// کد دارایی
		/// </summary>
		public int FinanceCode { get; set; }
		/// <summary>
		/// شماره سند مالکیت
		/// </summary>
		public string DocumentNumber { get; set; }

		#endregion

		public static decimal MaxShare = 6;
		#region Method
		/// <summary>
		/// جستجو بر اساس پلاک اصلی و فرعی
		/// </summary>
		/// <param name="MainAve"></param>
		/// <param name="SubAve"></param>
		/// <returns></returns>
		public bool Find(string MainAve, string SubAve, JDataBase pDB)
		{
			JDataBase tempdb;
			if (pDB == null)
				tempdb = JGlobal.MainFrame.GetDBO();
			else tempdb = pDB;

			try
			{
				string Query = @"select Code from " + JTableNamesEstate.GroundTable + " where(MainAve=" + JDataBase.Quote(MainAve) + " and SubNo=" + JDataBase.Quote(SubAve) + ")";
				tempdb.setQuery(Query);
				tempdb.Query_DataReader();
				if (tempdb.DataReader.Read())
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
				//tempdb.Dispose();
			}


		}

		public bool FindPartNumBlockNum(string PartNum, string BlockNum, JDataBase pDB)
		{
			JDataBase tempdb;
			if (pDB == null)
				tempdb = JGlobal.MainFrame.GetDBO();
			else tempdb = pDB;

			try
			{
				string Query = @"select Code from " + JTableNamesEstate.GroundTable + " where(BlockNum=" + JDataBase.Quote(BlockNum) + " and PartNum=" + JDataBase.Quote(PartNum) + ")";
				tempdb.setQuery(Query);
				tempdb.Query_DataReader();
				if (tempdb.DataReader.Read())
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
				//tempdb.Dispose();
			}

		}

		/// <summary>
		/// در لیست مالکین اولیه شخص خاصی را جستجو میکند
		/// </summary>
		/// <param name="pPCode">کد شخص</param>
		/// <returns></returns>
		public bool FindPrimaryOwner(int pPCode)
		{
			return PrimeryOwners.Select(" PCode = " + pPCode.ToString()).Count() > 0;
		}

		/// <summary>
		/// دستور سلکت مالکین اولیه
		/// </summary>
		private string _SelectPrimaryOwners =
			"SELECT "
			+ JTableNamesEstate.PrimaryOwnerGround + "." + JPrimaryOwnerField.Code + " ,"
			+ JPrimaryOwnerField.CodeGround + " ,"
					+ JPrimaryOwnerField.PCode + " ,"
					+ JTableNamesClassLibrary.AllPerson + ".Name , "
					+ JPrimaryOwnerField.Share
					+ " FROM " + JTableNamesEstate.PrimaryOwnerGround
					+ " INNER JOIN " + JTableNamesClassLibrary.AllPerson
					+ " ON " + JTableNamesClassLibrary.AllPerson + ".Code = "
					+ JPrimaryOwnerField.PCode;
		/// <summary>
		/// مالکین اولیه
		/// </summary>
		/// <returns></returns>
		private bool _LoadPrimayOwners(JDataBase Db)
		{
			//JDataBase Db = JGlobal.MainFrame.GetDBO();
			try
			{
				Db.setQuery(_SelectPrimaryOwners +
						" WHERE " + JTableNamesEstate.PrimaryOwnerGround + "." +
									JPrimaryOwnerField.CodeGround.ToString() + " = " + this.Code);
				PrimeryOwners = Db.Query_DataTable();
				return true;
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
		///لیست خالی مالکین اولیه
		/// </summary>
		/// <returns></returns>
		private bool _LoadEmptyOwners()
		{
			JDataBase Db = JGlobal.MainFrame.GetDBO();
			try
			{
				Db.setQuery(_SelectPrimaryOwners
					+ " WHERE " + JTableNamesEstate.PrimaryOwnerGround + "." + JPrimaryOwnerField.Code.ToString() + " = 0");
				PrimeryOwners = Db.Query_DataTable();
				return true;
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
		public bool GetData(int pCode)
		{
			return GetData(pCode, null);
		}
		/// <summary>
		/// اطلاعات زمین را بر اساس کد زمین بر می گرداند
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public bool GetData(int pCode, JDataBase tempDb)
		{
			JDataBase Db;
			if (tempDb == null)
			{
				Db = JGlobal.MainFrame.GetDBO();
			}
			else
				Db = tempDb;
			try
			{
				string Query = "select * from " + JTableNamesEstate.GroundTable + " where(Code=" + pCode + ")";
				Db.setQuery(Query);
				Db.Query_DataReader();
				if (Db.DataReader.Read())
				{
					JTable.SetToClassProperty(this, Db.DataReader);
					if (FinanceCode == 0)
					{
						Db.setQuery(@"
                                                    update estGround set FinanceCode=Fa.Code
                                                    from estGround EG
                                                    inner join finAsset Fa
                                                    on EG.Code=FA.ObjectCode and FA.ClassName='Estates.JGround'

                                    ");
						Db.Query_Execute();
					}
					_LoadPrimayOwners(Db);
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
		private bool _DeletePrimayOwners(JDataBase pDB, int AssetTransferCode)
		{
			//حذف از جدول دارایی جزء
			//            JAssetShareTable JAST = new JAssetShareTable();
			//          JAST.DeleteManual("ACode=" + AssetTransferCode, pDB);
			JPrimaryOwnerTable table = new JPrimaryOwnerTable();
			return table.DeleteManual(JPrimaryOwnerField.CodeGround.ToString() + " = " + this.Code, pDB);


		}

		private bool _InsertPrimaryOwners(JDataBase pDB, JAssetTransfer AssetTransfer)
		{
			object SumShare = PrimeryOwners.Compute("SUM(Share)", "");
			if (SumShare == DBNull.Value)
				SumShare = 0;
			if (Convert.ToDecimal(SumShare) != MaxShare)
			{
				JMessages.Error("مجموع میزان سهم برابر با" + MaxShare.ToString() + " نیست", "Error");
				return false;
			}
			foreach (DataRow row in PrimeryOwners.Rows)
			{
				JPrimaryOwner owner = new JPrimaryOwner();
				JTable.SetToClassProperty(owner, row);
				owner.CodeGround = this.Code;
				int ownerCode = owner.Insert(pDB);
				//درج در جدول دارائی های جزئی
				JAssetShare AssetShare = new JAssetShare();
				AssetShare.ACode = AssetTransfer.Code;
				AssetShare.PersonCode = Convert.ToInt32(row[JPrimaryOwnerField.PCode.ToString()]);
				AssetShare.Share = Convert.ToInt32(row[JPrimaryOwnerField.Share.ToString()]);
				//AssetShare.ObjectCode = ownerCode;
				//AssetShare.ClassName = "JPrimaryOwner";
				AssetShare.ParentCode = 0;
				AssetShare.Status = JStatusType.Active;
				AssetShare.Insert(pDB);
				AssetTransfer.AddItems(AssetShare);


				//درج در جدول انتقال دارایی

			}
			return true;
		}

		/// <summary>
		///اطلاعات زمین را درج می کند
		/// </summary>
		/// <returns></returns>
		public int Insert(JDataBase db)
		{
			if (JPermission.CheckPermission("Estates.JGround.Insert"))
			{
				JDataBase tempdb;
				this.Status = JGroundStatus.Main;
				if (db == null)
					tempdb = JGlobal.MainFrame.GetDBO();
				else
					tempdb = db;


				if (Find(MainAve, SubNo, tempdb))
				{
					JMessages.Error("اطلاعات زمین تکراری می باشد", "خطا در ورود اطلاعات");
					return 0;
				}
				if (FindPartNumBlockNum(PartNum, BlockNum, tempdb))
				{
					if (JMessages.Question("زمین با این شماره بلوک و شماره قطعه قبلا ثبت شده است .آیا می خواهید اطلاعات ذخیره شود", "warning") != System.Windows.Forms.DialogResult.Yes)
					{
						return 0;
					}

				}
				try
				{
					int defualtValueDatabase = 999999;
					JGroundTable GroundTable = new JGroundTable();
					GroundTable.SetValueProperty(this);
					if (db == null)
						tempdb.beginTransaction("InsertGround");
					int temp = GroundTable.Insert(defualtValueDatabase, tempdb, false);
					if (temp > 1)
					{
						this.Code = temp;
						///درج حدود اربعه
						this.About.CodeGround = temp;
						this.About.Save(tempdb);
						//در ج در جدول دارایی

						//JAsset Asset = new JAsset();
						//Asset.ObjectCode = this.Code;
						//Asset.ClassName = this.GetType().FullName;
						//Asset.Comment = this.ToString();
						//Asset.Status = JStatusType.Active;
						//Asset.MaxCount = JGround.MaxShare;
						//Asset.DivideType = JDivideType.DecimalDivide;
						////ارزش دارایی
						//int AssetCode=Asset.Insert(tempdb);
						//if (AssetCode > 0)
						//{
						//    JAssetTransfer AssetTransfer = new JAssetTransfer(AssetCode, JOwnershipType.Definitive);
						//    if (AssetTransfer.Code == 0)
						//    {
						//        AssetTransfer.ClassName = "Estates.JGround";
						//        AssetTransfer.ObjectCode = this.Code;
						//        AssetTransfer.ACode = AssetCode;
						//    }
						//    if (!AssetTransfer.Insert(tempdb))
						//    {
						//        tempdb.Rollback("InsertGround");
						//        return 0;
						//    }
						//    ///درج مالکین اولیه
						//    if (_InsertPrimaryOwners(tempdb,AssetTransfer))
						//    {
						JAsset Asset = new JAsset();
						Asset.ClassName = this.GetType().FullName;
						Asset.ObjectCode = this.Code;
						Asset.Comment = this.ToString();
						Asset.Status = JStatusType.Active;
						Asset.MaxCount = MaxShare;
						Asset.DivideType = JDivideType.DecimalDivide;
						Asset.GroupCode = Convert.ToInt32(JGroupType.Ground);
						/// ارزش دارایی
						Asset.Value = Convert.ToDecimal(this.Cost * Convert.ToDecimal(this.Area));
						int Assetcode = Asset.Insert(tempdb);
						if (Assetcode < 1)
						{
							tempdb.Rollback("InsertGround");
							return 0;
						}
						FinanceCode = Assetcode;
						GroundTable.FinanceCode = Assetcode;
						GroundTable.Update(tempdb);
						//assetTransfer
						JAssetTransfer AssetTransfer = new JAssetTransfer(Assetcode, JOwnershipType.Definitive, tempdb);
						if (AssetTransfer.Code == 0)
						{
							AssetTransfer.ClassName = this.MakeFromName;
							if (this.MakeFromCode == 0)
								MakeFromCode = this.Code;
							AssetTransfer.ObjectCode = this.MakeFromCode;
							AssetTransfer.ACode = Assetcode;
							AssetTransfer.Comment = JLanguages._Text("PrimaryOwnersOfGroundPlaque:") + this.MainAve;
						}
						//-----
						//if (_InsertPrimaryOwners(tempdb, AssetTransfer))
						if (JPrimaryOwners.Save(Code, this.PrimeryOwners, tempdb, AssetTransfer))
						{
							if (!AssetTransfer.Insert(tempdb))
							{
								tempdb.Rollback("InsertGround");
								return 0;
							}

							//Add Relation
							JRelation tmpJRelation = new JRelation();
							tmpJRelation.PrimaryClassName = "Estates.JGround";
							tmpJRelation.PrimaryObjectCode = Code;
							tmpJRelation.ForeignClassName = "ClassLibrary.Asset";
							tmpJRelation.ForeignObjectCode = Assetcode;
							tmpJRelation.Comment = "برای این زمین دارائی ثبت شده است";
							if (!tmpJRelation.Insert(tempdb))
								return -1;

							Histroy.Save(this, GroundTable, Code, Comment);

							if (db == null)
							{
								if (tempdb.Commit() && Nodes != null)
									Nodes.DataTable.Merge(JGrounds.GetDataTable(Code));
								return temp;
							}
							else
								return temp;
						}
						else
						{
							tempdb.Rollback("InsertGround");
							return 0;
						}

					}
					else
					{
						tempdb.Rollback("InsertGround");
						return 0;
					}


				}
				catch (Exception ex)
				{
					JSystem.Except.AddException(ex);
					if (db == null)
						tempdb.Rollback("InsertGround");
					return 0;
				}
			}
			else
				return 0;
		}

		/// <summary>
		/// اطلاعات زمین را قبل از به روز رسانی در جدول سابقه زمین درج می کند 
		/// </summary>
		/// <returns></returns>
		public int InsertHistory(string Comment)
		{
			this.Comment = Comment;
			this.Person = JMainFrame.CurrentUserCode;
			try
			{
				JDataBase Db = new JDataBase();
				string Query = @"DECLARE @Code INT " +
				JDataBase.GetInsertSQL(JTableNamesEstate.GroundHistory, "1000000", true) +

				"INSERT INTO " + JTableNamesEstate.GroundHistory +
					" (Code,GroundCode,Land,MainAve,SubNo,Section,BlockNum,PartNum,Usage,Area,Person,Comment)" +
					"values(@Code,@GroundCode,@Land,@MainAve,@SubNo,@Section,@BlockNum,@PartNum,@Usage,@Area,@Person,@Comment)";
				Db.setQuery(Query);
				Db.AddParams("@GroundCode", Code);
				Db.AddParams("@Land", Land);
				Db.AddParams("@MainAve", MainAve);
				Db.AddParams("@SubNo", SubNo);
				Db.AddParams("@Section", Section);
				Db.AddParams("@BlockNum", BlockNum);
				Db.AddParams("@PartNum", PartNum);
				Db.AddParams("@Usage", Usage);
				Db.AddParams("@Area", Area);
				Db.AddParams("@Person", Person);
				Db.AddParams("@Comment", Comment);
				if (Db.Query_Execute() < 1)
				{
					return 0;
				}
				return 1;


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
		/// اطلاعات زمین را به روز رسانی می کند
		/// </summary>
		/// <returns></returns>
		public bool Update()
		{
			if (JPermission.CheckPermission("Estates.JGround.Update"))
			{
				JGroundTable table = new JGroundTable();
				JDataBase Db = JGlobal.MainFrame.GetDBO();
				try
				{
					table.SetValueProperty(this);
					Db.beginTransaction("UpdateGround");
					if (table.Update(Db))
					{

						JAsset asset = new JAsset(this.GetType().FullName, this.Code, Db);
						if (asset.Code == 0)
						{
							asset.ClassName = this.GetType().FullName;
							asset.ObjectCode = this.Code;
							asset.Comment = this.ToString();
							asset.Status = JStatusType.Active;
							asset.MaxCount = MaxShare;
							asset.DivideType = JDivideType.DecimalDivide;
							asset.GroupCode = Convert.ToInt32(JGroupType.Ground);
							/// ارزش دارایی
							asset.Value = Convert.ToDecimal(this.Cost * Convert.ToDecimal(this.Area));
							int Assetcode = asset.Insert(Db);
							if (Assetcode < 1)
							{
								Db.Rollback("UpdateGround");
								return false;
							}
						}
						asset.Value = Convert.ToDecimal(this.Cost * Convert.ToDecimal(this.Area));
						if (asset.Update(Db))
						{
							//assetTransfer
							JAssetTransfer AssetTransfer = new JAssetTransfer(asset.Code, JOwnershipType.Definitive, Db);
							if (AssetTransfer.Items.Length == 0)
							{
								Db.Rollback("UpdateGround");
								JMessages.Error(" خطا در ویرایش و انتقال دارائی لطفا با مدیر سیستم تماس بگیرید ", "");
								return false;
							}
							if (AssetTransfer.Code == 0)
							{
								AssetTransfer.ClassName = "Estates.JPrimaryOwner";
								AssetTransfer.ObjectCode = this.Code;
								AssetTransfer.ACode = asset.Code;
								AssetTransfer.Comment = JLanguages._Text("PrimaryOwnersOfGroundPlaque:") + this.MainAve;
								AssetTransfer.Insert(Db);
							}
							//-----
							if (JPrimaryOwners.Save(this.Code, this.PrimeryOwners, Db, AssetTransfer))
							{
								if (!AssetTransfer.Update(Db))
								{
									Db.Rollback("UpdateGround");
									return false;
								}
								if (this.About.Changed)
								{
									this.About.CodeGround = this.Code;
									this.About.Save(Db);
								}
								Histroy.Save(this, table, Code, "Update");
								Db.Commit();
								Nodes.Refreshdata(Nodes.CurrentNode, JGrounds.GetDataTable(this.Code).Rows[0]);
								return true;
							}
							else
							{
								Db.Rollback("UpdateGround");
								return false;
							}
						}
					}
					Db.Rollback("UpdateGround");
					return false;
				}
				catch (Exception ex)
				{
					JSystem.Except.AddException(ex);
					Db.Rollback("UpdateGround");
					return false;
				}
				finally
				{
					Db.Dispose();
				}
			}
			else
				return false;
		}

		public bool Delete()
		{
			return Delete(null);
		}
		public bool Delete(JDataBase TempDb)
		{
			if (JPermission.CheckPermission("Estates.JGround.Delete"))
			{
				JDataBase DB;
				if (TempDb == null)
					DB = new JDataBase();
				else
					DB = TempDb;
				try
				{
					string[] parameters = { "@Item" };
					string[] values = { "Ground" };
					string msg = JLanguages._Text("YouWantToDelete?", parameters, values);

					if (JMessages.Question(msg, "Delete") == System.Windows.Forms.DialogResult.Yes)
					{
						if (TempDb == null)
						{
							DB.beginTransaction("DeleteGround");
						}
						JAsset Asset = new JAsset(this.GetType().FullName, this.Code);
						Asset.Delete(DB);
						//Asset.GetData("Estates.JGround", this.Code);
						_DeletePrimayOwners(DB, Asset.Code);
						JGroundTable GroundTable = new JGroundTable();
						GroundTable.SetValueProperty(this);

						//Delete Relation
						Asset.GetData("Estates.JGround", GroundTable.Code, DB);
						JRelation tmpJRelation = new JRelation();
						if (!tmpJRelation.Delete("ClassLibrary.Asset", Asset.Code, DB))
						{
							DB.Rollback("DeleteGround");
							return false;
						}

						GroundTable.Delete(DB);
						Histroy.Save(this, GroundTable, Code, "Update");
						if (TempDb == null)
							DB.Commit();
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
					DB.Rollback("DeleteGround");
					JSystem.Except.AddException(ex);
					return false;
				}
				finally
				{
					DB.Dispose();
				}
			}
			else
				return false;

		}

		public static string _SelectQuery =
			@"SELECT  " + JTableNamesEstate.GroundTable + ".Code, " +
			JTableNamesEstate.LandTable + ".Name Land ," +
			JTableNamesEstate.GroundTable + ".MainAve, " + JTableNamesEstate.GroundTable + ".SubNo, " + JTableNamesEstate.LandTable + ".Section, " +
			JTableNamesEstate.GroundTable + ".BlockNum, " +
			JTableNamesEstate.GroundUsageTable + ".Name Usage, " + JTableNamesEstate.GroundTable + ".Area , " + JTableNamesEstate.GroundTable + ".Comment, " + JTableNamesEstate.GroundTable + ".PartNum ," +
			@" CAST(estGround.Cost as float) Cost,FGA.Name 'MOwner',FA.GWOwners,Fa.DFOwners ,FA.Code FinAssetCode,

(Select Count(S.Code) From estSheet S Where S.GCode=estGround.Code AND DeActive=0 ) 'CountPerson',
(Select SUM(Area) From estSheet S Where S.GCode=estGround.Code And DeActive=0 And S.DeliveryDate is not Null) 'DeliveryMetr',
(select SUM(Area) from estRequestTransferSheet R inner join estSheet S on R.SheetCode=S.Code And BuyerCode=0 And S.GCode=estGround.Code) 'RequestSellMetr',
(Select Count(S.Code) From estSheet S Where S.GCode=estGround.Code And S.DeliveryDate is not Null) 'DeliveryCount',
(select Count(R.Code) from estRequestTransferSheet R inner join estSheet S on R.SheetCode=S.Code And BuyerCode=0 And S.GCode=estGround.Code) 'RequestSellCount',

(select SUM(Area) from estRequestTransferSheet R inner join estSheet S on R.SheetCode=S.Code And BuyerCode=0 And S.GCode=estGround.Code)/estGround.Area*100 'درصد' 
            FROM " + JTableNamesEstate.GroundTable +
			" INNER JOIN " + JTableNamesEstate.LandTable + " ON " + JTableNamesEstate.GroundTable + ".Land = estLand.Code" +
			" INNER JOIN " + JTableNamesEstate.GroundUsageTable + " on estUsageGround.Code = " + JTableNamesEstate.GroundTable + ".Usage " +
			" LEFT JOIN vfinAsset FA ON  " + JTableNamesEstate.GroundTable + ".Code = Fa.ObjectCode AND FA.ClassName = 'Estates.JGround' " +
			" LEFT JOIN VGroundAsset FGA ON  " + JTableNamesEstate.GroundTable + ".Code = FGA.ObjectCode ";

		/// <summarsy>
		/// غیر فعال کردن زمین
		/// </summary>
		/// <param name="Db"></param>
		/// <param name="pStatus"></param>
		/// <returns></returns>
		public bool InactiveGround(JDataBase Db, JGroundStatus pStatus)
		{

			if (Db == null)
			{
				Db = JGlobal.MainFrame.GetDBO();
			}
			JGroundTable JGT = new JGroundTable();
			this.Status = pStatus;
			try
			{
				JGT.SetValueProperty(this);
				if (JGT.Update(Db))
				{
					//غیر فعال کردن زمین در جدول دارایی ها
					JAsset Asset = new JAsset("Estates.JGround", this.Code, Db);
					Asset.Status = JStatusType.Inactive;
					if (Asset.Update(Db))
					{
						return true;
					}
					return false;

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
				JGT.Dispose();
			}
		}
		/// <summary>
		/// فعال کردن زمین
		/// </summary>
		/// <param name="Db"></param>
		/// <returns></returns>

		public bool ActivateGround(JDataBase Db)
		{
			// فعال کردن در کلاس دارایی ها
			JAsset asset = new JAsset("Estates.JGround", this.Code, Db);
			asset.Status = JStatusType.Active;
			asset.Update();
			JGroundTable JGT = new JGroundTable();
			this.Status = JGroundStatus.Main;
			try
			{
				JGT.SetValueProperty(this);
				return JGT.Update(Db);
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return false;
			}
			finally
			{
				JGT.Dispose();
			}
		}
		public override string ToString()
		{
			return " کد: " + this.Code + " - " + " بلوک : " + this.BlockNum + " - " + " قطعه : " + this.PartNum + " - " + " مساحت : " + this.Area + " - " + "پلاک اصلی:" + this.MainAve + " - " + "پلاک فرعی:" + this.SubNo;
		}

		#endregion

		#region Node

		public JNode GetNode(DataRow pRow)
		{
			JNode Node = new JNode((int)pRow[JGroundTableEnum.Code.ToString()], "Estates.JGround");
			Node.Icone = JImageIndex.Ground.GetHashCode();
			Node.Name = pRow[JGroundTableEnum.SubNo.ToString()] + "-"
				+ pRow[JGroundTableEnum.BlockNum.ToString()] + "-"
				+ pRow[JGroundTableEnum.Usage.ToString()];//+ pRow[JGroundTableEnum.PartNum.ToString()] + "-"
			//اکشن ویرایش
			JAction editAction = new JAction("Edit", "Estates.JGround.ShowDialog", null, new object[] { Node.Code });
			Node.MouseDBClickAction = editAction;
			Node.EnterClickAction = editAction;
			//اکشن حذف
			JAction deleteAction = new JAction("Delete", "Estates.JGround.Delete", null, new object[] { Node.Code });
			Node.DeleteClickAction = deleteAction;
			//اکشن جدید
			JAction newAction = new JAction("new...", "Estates.JGround.ShowDialog", null, null);
			//اکشن انتقال
			JAction TransferAction = new JAction("Transfer UnitBuild...", "RealEstate.JUnitBuild.ShowTransferDialog", new object[] { (int)pRow["FinAssetCode"] }, null);

			JPopupMenu pMenu = new JPopupMenu("Estates.JGround", Node.Code);
			Node.Hint = JLanguages._Text("Land:") + " " + pRow[JGroundTableEnum.Land.ToString()] +
				"\n" + JLanguages._Text("area:") + " " + pRow[JGroundTableEnum.Area.ToString()] +
				"\n" + JLanguages._Text("MainAve:") + " " + pRow[JGroundTableEnum.MainAve.ToString()];
			pMenu.Insert(newAction);
			pMenu.Insert(editAction);
			pMenu.Insert(deleteAction);
			pMenu.Insert(TransferAction);
			Node.Popup = pMenu;
			return Node;

		}


		public void ShowDialog()
		{
			if (this.Code == 0)
			{
				JGroundForm JGF = new JGroundForm();
				JGF.State = ClassLibrary.JFormState.Insert;
				JGF.ShowDialog();
				if (JGF.DialogResult == System.Windows.Forms.DialogResult.Retry)
				{
					if (JMessages.Question("آیا می خواهید اطلاعات قبلی فرم حفظ شود؟", "") == System.Windows.Forms.DialogResult.Yes)
						ShowDialog(JGF);
					else
						ShowDialog();

				}
			}
			else
			{
				JGroundForm JGF = new JGroundForm(this.Code);
				JGF.State = ClassLibrary.JFormState.Update;
				JGF.ShowDialog();
				if (JGF.DialogResult == System.Windows.Forms.DialogResult.Retry)
				{
					if (JMessages.Question("آیا می خواهید اطلاعات قبلی فرم حفظ شود؟", "") == System.Windows.Forms.DialogResult.Yes)
					{
						this.Code = 0;
						ShowDialog(JGF);
					}
					else
					{
						this.Code = 0;
						ShowDialog();

					}
				}
			}

		}
		public void ShowDialog(JGroundForm GroundForm)
		{
			JGroundForm JGF = new JGroundForm();
			JGF._newGround.Land = GroundForm._newGround.Land;
			JGF._newGround.MainAve = GroundForm._newGround.MainAve;
			JGF._newGround.SubNo = GroundForm._newGround.SubNo;
			JGF._newGround.BlockNum = GroundForm._newGround.BlockNum;
			JGF._newGround.Usage = GroundForm._newGround.Usage;
			JGF.stateClass = StateClasses.Retry;
			JGF.State = ClassLibrary.JFormState.Insert;
			JGF.ShowDialog();
			if (JGF.DialogResult == System.Windows.Forms.DialogResult.Retry)
			{
				if (JMessages.Question("آیا می خواهید اطلاعات قبلی فرم حفظ  شود؟", "") == System.Windows.Forms.DialogResult.Yes)
				{
					ShowDialog(JGF);

				}
				else
				{
					ShowDialog();
				}
			}
		}

		public void SearchDialog()
		{
			JSearchGroundForm PE = new JSearchGroundForm();
			PE.ShowDialog();
		}

		public static string SearchFinanceDialog()
		{
			JSearchGroundForm PE = new JSearchGroundForm();
			PE.ShowDialog();
			return PE._SQLQuery;
		}

		#endregion Node

		#region Asset

		public string GetAssetComment(int Code)
		{
			GetData(Code);
			string Str = "";
			if (!String.IsNullOrEmpty(MainAve)) Str = Str + " کد : " + Code.ToString();
			if (!String.IsNullOrEmpty(MainAve)) Str = Str + " بلوک : " + BlockNum.ToString();
			if (!String.IsNullOrEmpty(MainAve)) Str = Str + " قطعه : " + PartNum.ToString();
			if (!String.IsNullOrEmpty(MainAve)) Str = Str + " پلاک اصلی: " + MainAve.ToString();
			if (!String.IsNullOrEmpty(SubNo)) Str = Str + " :پلاک فرعی  " + SubNo.ToString();
			if (!String.IsNullOrEmpty(Section)) Str = Str + " :بخش " + Section.ToString();
			if (Area > 0) Str = Str + "مساحت: " + Area.ToString();
			return Str;
		}

		public string GetAssetUnit()
		{
			return "DONG";
		}
		/// <summary>
		/// فیلدهای این دارایی را با توجه به فیلدهایی که برای قرارداد داریم برمیگرداند        
		/// </summary>
		/// <returns></returns>
		public DataTable FieldList(string pClassName, int pObjectCode)
		{
			try
			{
				DataTable tmpdt = GetContractData(0);
				DataTable dt = new DataTable();
				dt.Columns.Add("name");
				dt.Columns.Add("text");
				for (int i = 0; i < tmpdt.Columns.Count; i++)
				{
					DataRow dr = dt.NewRow();
					dr["name"] = tmpdt.Columns[i].Caption;
					dr["text"] = JLanguages._Text(tmpdt.Columns[i].Caption);
					dt.Rows.Add(dr);
				}
				return dt;
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
		}

		public DataTable GetContractData(int pCode)
		{
			return GetContractData(pCode, "", 0);
		}
		/// <summary>
		/// اطلاعاتی را که برای قرارداد احتیاج داریم را برمیگرداند
		/// </summary>
		/// <param name="pCode"></param>
		/// <returns></returns>
		public DataTable GetContractData(int pCode, string pClassName, int pObjectCode)
		{
			string _SelectQuery =
			@"SELECT  " +
			JTableNamesEstate.LandTable + ".Name as 'Ground.Land' ," +
			JTableNamesEstate.GroundTable + ".MainAve  as 'Ground.MainAve', " + JTableNamesEstate.GroundTable + ".SubNo  as 'Ground.SubNo', " + JTableNamesEstate.GroundTable + ".Section  as 'Ground.Section', " +
			JTableNamesEstate.GroundTable + ".BlockNum as 'Ground.BlockNum', " +
			JTableNamesEstate.GroundTable + ".PartNum as 'Ground.PartNum', " +
			JTableNamesEstate.GroundUsageTable + ".Name  as 'Ground.Usage', cast(" + JTableNamesEstate.GroundTable + ".Area as varchar)  as 'Ground.Area', " + JTableNamesEstate.GroundTable + ".Comment  as 'Ground.Comment' FROM " + JTableNamesEstate.GroundTable +
			" INNER JOIN " + JTableNamesEstate.LandTable + " ON " + JTableNamesEstate.GroundTable + ".Land = estLand.Code" +
			" INNER JOIN " + JTableNamesEstate.GroundUsageTable + " on estUsageGround.Code = " + JTableNamesEstate.GroundTable + ".Usage";

			JDataBase Db = new JDataBase();
			try
			{
				Db.setQuery(_SelectQuery + " Where " + JTableNamesEstate.GroundTable + ".Code=" + pCode.ToString());
				DataTable tmpdt = new DataTable();
				tmpdt = Db.Query_DataTable();
				tmpdt.Rows[0]["Ground.Area"] = JGeneral.ReverseNumber(tmpdt.Rows[0]["Ground.Area"].ToString().Replace('.', '/'), '/');
				tmpdt.AcceptChanges();
				return tmpdt;
			}
			finally
			{
				Db.Dispose();
			}
		}
		#endregion
	}

	public class JGrounds : JSystem
	{
		public static string _SQLQuery = "";

		public void ListView()
		{
			Nodes.ObjectBase = new JAction("Ground", "Estates.JGround.GetNode");
			Nodes.DataTable = GetDataTable();

			JAction newAction = new JAction("new...", "Estates.JGround.ShowDialog", null, null);
			Nodes.GlobalMenuActions.Insert(newAction);
			JToolbarNode jtn = new JToolbarNode();
			jtn.Click = newAction;
			jtn.Icon = JImageIndex.Add;
			Nodes.AddToolbar(jtn);

			JAction SearchAction = new JAction("Search...", "Estates.JGround.SearchDialog", null, null);
			Nodes.GlobalMenuActions.Insert(SearchAction);
			JToolbarNode TNS = new JToolbarNode();
			TNS.Icon = JImageIndex.mail;
			TNS.Hint = "Search...";
			TNS.Click = SearchAction;
			Nodes.AddToolbar(TNS);

			JAction PriceGroundAction = new JAction("Search...", "Estates.JSahmPrice.ShowForm", null, null);
			Nodes.GlobalMenuActions.Insert(PriceGroundAction);
			JToolbarNode TNS1 = new JToolbarNode();
			TNS1.Icon = JImageIndex.MarketUsage;
			TNS1.Hint = "PriceGround...";
			TNS1.Click = PriceGroundAction;
			Nodes.AddToolbar(TNS1);
		}
		public DataTable GetDataTable()
		{
			return GetDataTable(0);
		}

		public static DataTable GetDataTable(int pCode)
		{
			string Query = JGround._SelectQuery;
			JDataBase db = new JDataBase();
			try
			{
				db.Paging = true;
				string Where = " Where 1=1 ";
				if (pCode != 0)
					Where += " And " + JTableNamesEstate.GroundTable + ".Code LIKE '%" + pCode + "%'";
				db.setQuery(Query + Where + " And " + JPermission.getObjectSql("Estates.JLands.GetDataTable", JTableNamesEstate.LandTable + ".Code ") 
					+ " And " + JPermission.getObjectSql("Estates.JGrounds.GetDataTable", JTableNamesEstate.GroundTable + ".Code "));
				_SQLQuery = Query;
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

		private static string _SearchQuery = JGround._SelectQuery;
		//@"SELECT  " + JTableNamesEstate.GroundTable + ".Code, " +
		//JTableNamesEstate.LandTable + ".Name Land ," +
		//JTableNamesEstate.GroundTable + ".MainAve, " + JTableNamesEstate.GroundTable + ".SubNo, " + JTableNamesEstate.GroundTable + ".Section, " +
		//JTableNamesEstate.GroundTable + ".BlockNum, " +
		//JTableNamesEstate.GroundUsageTable + ".Name Usage, " + JTableNamesEstate.GroundTable + ".Area , " + JTableNamesEstate.GroundTable + ".Comment FROM " + JTableNamesEstate.GroundTable +
		//" INNER JOIN " + JTableNamesEstate.LandTable + " ON " + JTableNamesEstate.GroundTable + ".Land = estLand.Code" +
		//" INNER JOIN " + JTableNamesEstate.GroundUsageTable + " on estUsageGround.Code = " + JTableNamesEstate.GroundTable + ".Usage";

		/// <summary>
		/// جستجوی زمین برای قرعه کشی
		/// </summary>
		/// <returns></returns>
		public static DataTable LotteryGround()
		{
			JDataBase Db = JGlobal.MainFrame.GetDBO();
			try
			{
				Db.setQuery(" Select Code,Cost,Usage From estGround");
				return Db.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				Db.Dispose();
			}
		}

		public static DataTable FindKoroki(int pCodeArchive)
		{
			//JDataBase Db = JGlobal.MainFrame.GetDBO();
			JDataBase Db = JGlobal.MainFrame.GetArchiveDB();
			try
			{
				Db.setQuery(" SELECT Contents From dbo.ArchiveContent Where Code=" + pCodeArchive);
				return Db.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				Db.Dispose();
			}
		}

		/// <summary>
		/// جستجوی زمین برای استفاده در فرم جستجوی زمین
		/// </summary>
		/// <returns></returns>
		public static DataTable SearchGround(JGround Ground)
		{
			string Where = "";
			JDataBase Db = JGlobal.MainFrame.GetDBO();
			if (Ground.Code != 0)
			{
				Where = " where Code=" + JDataBase.Quote(Ground.Code.ToString());
			}
			//
			if (Ground.Area != 0 && Where != "")
			{
				Where += " and Area=" + JDataBase.Quote(Ground.Area.ToString());
			}
			else if (Ground.Area != 0)
			{
				Where += " where Area=" + JDataBase.Quote(Ground.Area.ToString());
			}
			//
			if (Ground.BlockNum != "" && Where != "")
			{
				Where += " and BlockNum=" + JDataBase.Quote(Ground.BlockNum.ToString());
			}
			else if (Ground.BlockNum != "")
			{
				Where += " where BlockNum=" + JDataBase.Quote(Ground.BlockNum.ToString());
			}
			//
			if (Ground.Land != 0 && Where != "")
			{
				Where += " and Land=" + JDataBase.Quote(Ground.Land.ToString());
			}
			else if (Ground.Land != 0)
			{
				Where += " where Land=" + JDataBase.Quote(Ground.Land.ToString());
			}
			//
			if (Ground.MainAve != "" && Where != "")
			{
				Where += " and MainAve=" + JDataBase.Quote(Ground.MainAve.ToString());
			}
			else if (Ground.MainAve != "")
			{
				Where += " where MainAve=" + JDataBase.Quote(Ground.MainAve.ToString());
			}
			if (Ground.SubNo != "" && Where != "")
			{
				Where += " and SubNo=" + JDataBase.Quote(Ground.SubNo.ToString());
			}
			else if (Ground.SubNo != "")
			{
				Where += " where SubNo=" + JDataBase.Quote(Ground.SubNo.ToString());
			}

			if (Ground.Usage != 0 && Where != "")
			{
				Where += " and Usage=" + JDataBase.Quote(Ground.Usage.ToString());
			}
			else if (Ground.Usage != 0)
			{
				Where += " where Usage=" + JDataBase.Quote(Ground.Usage.ToString());
			}
			if (Ground.PartNum != "" && Where != "")
			{
				Where += " and PartNum=" + JDataBase.Quote(Ground.PartNum.ToString());
			}
			else if (Ground.PartNum != "")
			{
				Where += " where PartNum=" + JDataBase.Quote(Ground.PartNum.ToString());

			}
			if (Where == "")
				Where += " where estGround.status=1";
			else
				Where += ",estGround.status=1";

			try
			{
				Db.setQuery(_SearchQuery + Where);
				return Db.Query_DataTable();
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return null;
			}
			finally
			{
				Db.Dispose();
			}
		}
	}
}
