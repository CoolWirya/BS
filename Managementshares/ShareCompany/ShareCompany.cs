using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{

    public class JShareCompany : JManagementshares
    {
        #region Constructor
        public JShareCompany()
        {
        }
        public JShareCompany(int pCode)
        {
            GetData(pCode);
        }

        public bool GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qoury = " select * from ShareCompany where Code=" + pCode;
            try
            {
                Db.setQuery(Qoury);
                DataTable table = Db.Query_DataTable();
                // Db.Query_DataReader();
                if (table.Rows.Count > 0)
                {
                    JTable.SetToClassProperty(this, table.Rows[0]);
                    this.Code = pCode;
                    return true;
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
            return false;
        }

        #endregion

        public static string Query = " SELECT ShareCompany.Code, PCode, name AS Name FROM ShareCompany  Inner Join clsAllPerson on ShareCompany . PCode = clsAllPerson .Code  ";

        #region property
        public int Code { get; set; }
        public int PCode { get; set; }
        public decimal CurrentShareCost { get; set; }
        public decimal CurrentShareCount
        {
            get;
            set;
            //{
            //    return LastIncrease.ShareCount;
            //}
        }

        public int TaxTransfer { get; set; }
        //public JIncreaseShare LastIncrease
        //{
        //    get
        //    {
        //        DataTable tableInc = JIncreaseShares.GetHistory(this.Code);
        //        if (tableInc.Rows.Count > 0)
        //        {
        //            JIncreaseShare increase = new JIncreaseShare(tableInc.Rows[0].Field<int>("Code"));
        //            return increase;
        //        }
        //        return null;
        //    }
        //}


        #endregion

        public bool Update(JDataBase pDB)
        {
            JShareCompanyTable JUBT = new JShareCompanyTable();
            if (JPermission.CheckPermission("ManagementShares.JShareCompany.Update"))
            {
                JUBT.SetValueProperty(this);
                return JUBT.Update(pDB);
            }
            return false;
        }

        public int Insert()
        {
            JShareCompanyTable companyTable = new JShareCompanyTable();
            try
            {
                if (JPermission.CheckPermission("ManagementShares.JShareCompany.Insert"))
                {
                    companyTable.SetValueProperty(this);
                    Code = companyTable.Insert();
                    if (Code > 0)
                    {
                        return Code;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

		public static int GetDefault()
		{
			JShareCompanyTable companyTable = new JShareCompanyTable();
			try
			{
				DataTable DT = companyTable.GetDataTable();
				if (DT.Rows.Count>0)
				{
					return (int)DT.Rows[0]["Code"];
					
				}

				return 0;
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
        public int GetSheetsCount()
        {
            JDataBase db = new JDataBase();
            string sql = " SELECT Count(Code) FROM ShareSheet Where Status =1 AND  CompanyCode =  " + this.Code;
            db.setQuery(sql);
            try
            {
                DataTable table = db.Query_DataTable();
                return Convert.ToInt32(table.Rows[0][0]);
            }
            catch
            {
                return 0;
            }
            finally
            {
                db.DisConnect();
            }
        }

        public int GetPersonSheetsCount()
        {
            JDataBase db = new JDataBase();
            string sql = " Select COUNT(*) From( SELECT Count(*)sheets FROM ShareSheet  Where Status =1 AND  CompanyCode =  " + this.Code + " Group By PCode ) A";
            db.setQuery(sql);
            try
            {
                DataTable table = db.Query_DataTable();
                return Convert.ToInt32(table.Rows[0][0]);
            }
            catch
            {
                return 0;
            }
            finally
            {
                db.DisConnect();
            }
        }

        /// <summary>
        /// افزایش سرمایه شرکت
        /// برگه ها باطل نمیشوند. فقط یک برگه به تعداد مشخصی سهم به برگه ها اضافه میشود.
        /// فقط در صورتی برگه ها باطل میشوند که مبلغ اسمی هر سهم در افزایش سرمایه تغییر کند. این کار با تائید کاربر انجام میشود
        /// </summary>
        /// <returns></returns>
        public bool IncreaseShare(JIncreaseShare pIncreaseInfo, bool DeActiveAll)
        {
            decimal currentShareCount = this.CurrentShareCount;
            int newShareNo = Convert.ToInt32(currentShareCount + 1);

            JShareSheet sheet = new JShareSheet();
            sheet.Az = newShareNo;
            int increaseCount = Convert.ToInt32(pIncreaseInfo.ShareCount - currentShareCount);
            sheet.Ela = newShareNo + increaseCount - 1;
            sheet.ShareCount = sheet.Ela - sheet.Az + 1;
            sheet.CompanyCode = this.Code;
            sheet.NumPrint = 0;
            sheet.Status = JSheetStatus.Active.GetHashCode();
            sheet.PCode = this.PCode;

            this.CurrentShareCost = pIncreaseInfo.Cost;
            this.CurrentShareCount = pIncreaseInfo.ShareCount;
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("Increase");
                pIncreaseInfo.Insert(db);
                /// در صورتی که مبلغ اسمی سهم تغییر کند همه برگه ها غیر فعال میشوند و برگه جدید از یک شروع میشود
                if (DeActiveAll)
                {
                    if (this.DeActiveAllSheets(pIncreaseInfo.Code, db))
                    {
                        sheet.Az = 1;
                        sheet.ShareCount = sheet.Ela - sheet.Az + 1;
                    }
                    else
                        throw new Exception();
                }
                sheet.CourseCode = pIncreaseInfo.Code;
                if (sheet.Insert(db, 0, 0, 0) <= 0)
                    throw new Exception();

                if (!this.Update(db))
                    throw new Exception();

                return db.Commit();
            }
            catch
            {
                db.Rollback("Increase");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// تجمیع برگه ها
        /// </summary>
        /// <param name="pJoinInfo"></param>
        /// <returns></returns>
        public bool JoinAllSheets(JIncreaseShare pJoinInfo)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("Increase");
                pJoinInfo.Insert(db);
                if (pJoinInfo.Code == 0)
                    throw new Exception();
                /// در صورتی که مبلغ اسمی سهم تغییر کند همه برگه ها غیر فعال میشوند و برگه جدید از یک شروع میشود
                // if (this.DeActiveAllSheets(pJoinInfo.Code, db))
                {
                    string sql = @"
                    -------- Insert Log
                    Insert ShareSheetLog (Code, SCode, PCode, NewSCode , NewPCode,   OperationCode, Operation)
                    Select (Select IsNull(MAX(Code),0) from ShareSheetLog) + ROW_NUMBER() Over(Order by Code), Code, PCode, Null, PCode, "
                + pJoinInfo.Code.ToString() + ", " + JShareOperations.IncreaseShare.GetHashCode().ToString() +
                @" from ShareSheet Where Status = 1 ";
                    ////// غیر فعال کردن دارایی ها
                    sql += @"
            --------- Deactive Asset 
                Update finAssetShare  Set Status = 0 Where ACode IN(Select Code From finAsset Where  ClassName  = 'ManagementShares.JShareSheet' and Status = 1)
                Update finAsset Set Status = 0 Where ClassName  = 'ManagementShares.JShareSheet' and Status = 1
                Update ShareSheet Set Status = -1 Where Status = 1  ";

                    ///////// درج برگه سهمهای جدید
                    sql += @"
            -------- Insert New Sheets
                insert ShareSheet (Code, CompanyCode, Az, Ela, ShareCount, PCode, ACode, Status, CourseCode, NumPrint,Period)
                Select (Select MAX(Code) from ShareSheet ) + ROW_NUMBER() Over(Order by PCode), * FROM( Select   " + pJoinInfo.CompanyCode.ToString() +
                    @" CompanyCode , 0 Az,0 Ela , Sum(ShareCount) ShareCount, PCode ,null ACode , 1 Status , " + pJoinInfo.Code.ToString() +
                    @" CourseCode, 0 NumPrint,(isnull((select max(period) from ShareSheet),0))+1 from ShareSheet Where Status = -1 Group by Pcode) A 
                        Update ShareSheet Set Status = 0 Where Status = -1  ";
                    /////////// درج دارایی جدید
                    sql += @"
                -------- Insert Asset
                 Insert finAsset(Code, ClassName, ObjectCode, CreatorPostCode, CreatorUserCode, Comment, Status, MaxCount, DivideType,Value , GroupCode)
                 Select (Select MAX(Code) from finAsset ) + ROW_NUMBER() Over(Order by Code),  'ManagementShares.JShareSheet', Code, " + JMainFrame.CurrentPostCode + "," + JMainFrame.CurrentUserCode
                    + @" ,'' Comment, 1 Status , 0 MaxCount ,1 DivideType , 0 Value, 2 GroupCode  From ShareSheet Where Status = 1
                 Insert finAssetTransfer (Code, ACode, ParentCode, OwnershipType, ClassName, ObjectCode, Comment)
                 Select (Select MAX(Code) from finAssetTransfer ) + ROW_NUMBER() Over(Order by Code), Code, 0 ParentCode , 1 OwnerShipType , 
                'ManagementShares.JIncreaseShare', " + pJoinInfo.Code + ", N'افزایش سرمایه'  from finAsset Where ClassName =  'ManagementShares.JShareSheet' And Status = 1 " +
                     @" Insert finAssetShare (Code, ParentCode, PersonCode, Share, Status, TCode, ACode)
                 Select  (Select MAX(Code) from finAssetShare) + ROW_NUMBER() Over(Order by A.Code),
		         0 ParentCode , S.PCode, S.ShareCount, 1 Status , T.Code TCode , A.Code ACode
                 from ShareSheet S inner Join finAsset A on S.Code = A.ObjectCode And A.ClassName = 'ManagementShares.JShareSheet' and A.Status = 1
		         Inner join finAssetTransfer T on T.ACode = A.Code  And A.ClassName = 'ManagementShares.JShareSheet' and A.Status = 1 ";

                    /////////////// بروزرسانی سابقه بر اساس برگه های درج شده جدید
                    sql += @"
                Update ShareSheetLog Set NewSCode = ShareSheet.Code 
                From ShareSheetLog Inner Join ShareSheet on ShareSheetLog.PCode = ShareSheet .PCode and ShareSheet .Status = 1
                where NewSCode is null ";
                    //// اختصاص شماره سهم به "از و الی"ـ
                    sql += @"
                    UPDATE ShareSheet SET Az = (SELECT ISNULL(SUM(s .ShareCount ), 0) +1
                    FROM ShareSheet AS s WHERE s.Code < ShareSheet.Code  and s.Status =1 )
                    Update ShareSheet Set Ela = Az + ShareCount -1";
                    db.setQuery(sql);
                    if (db.Query_Execute() < 0)
                        throw new Exception();

                    return db.Commit();
                }


                //else
                //    throw new Exception();
            }
            catch
            {
                db.Rollback("Increase");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// شکستن سهم
        /// </summary>
        /// <param name="pJoinInfo"></param>
        /// <returns></returns>
        public bool BreakSheets(JIncreaseShare pBreakInfo)
        {
            JDataBase db = new JDataBase();
            try
            {
                this.CurrentShareCost = this.CurrentShareCost / pBreakInfo.BreakCount;
                this.CurrentShareCount = this.CurrentShareCount * pBreakInfo.BreakCount;

                db.beginTransaction("Increase");
                /// بروزرسانی اطلاعات شرکت
                if (!this.Update(db))
                    throw new Exception();
                /// درج اطلاعات تغییر سرمایه
                pBreakInfo.Insert(db);
                if (pBreakInfo.Code == 0)
                    throw new Exception();
                {
                    string sql = @"
                    -------- Insert Log
                    Insert ShareSheetLog (Code, SCode, PCode, NewSCode , NewPCode,   OperationCode, Operation)
                    Select (Select IsNull(MAX(Code),0) from ShareSheetLog) + ROW_NUMBER() Over(Order by Code), Code, PCode, Null, PCode, "
                + pBreakInfo.Code.ToString() + ", " + JShareOperations.BreakeShare.GetHashCode().ToString() +
                @" from ShareSheet Where Status = 1 ";
                    ////// غیر فعال کردن دارایی ها
                    sql += @"
            --------- Deactive Asset 
                Update finAssetShare  Set Status = 0 Where ACode IN(Select Code From finAsset Where  ClassName  = 'ManagementShares.JShareSheet' and Status = 1)
                Update finAsset Set Status = 0 Where ClassName  = 'ManagementShares.JShareSheet' and Status = 1
                Update ShareSheet Set Status = -1  Where Status = 1 ";

                    ///////// درج برگه سهمهای جدید
                    sql += @"
            -------- Insert New Sheets
                insert ShareSheet (Code, CompanyCode, Az, Ela, ShareCount, PCode, ACode, Status, CourseCode, NumPrint,Period)
                Select (Select MAX(Code) from ShareSheet ) + ROW_NUMBER() Over(Order by PCode), * FROM( Select   " + pBreakInfo.CompanyCode.ToString() +
                    @" CompanyCode , 0 Az,0 Ela , Sum(ShareCount) * " + pBreakInfo.BreakCount + " ShareCount, PCode ,null ACode , 1 Status , " + pBreakInfo.Code.ToString() +
                    @" CourseCode, 0 NumPrint,(isnull((select max(period) from ShareSheet),0))+1 from ShareSheet Where Status = -1 Group by Pcode) A 
                        Update ShareSheet Set Status = 0  Where Status = -1  ";
                    /////////// درج دارایی جدید
                    sql += @"
                -------- Insert Asset
                 Insert finAsset(Code, ClassName, ObjectCode, CreatorPostCode, CreatorUserCode, Comment, Status, MaxCount, DivideType,Value , GroupCode)
                 Select (Select MAX(Code) from finAsset ) + ROW_NUMBER() Over(Order by Code),  'ManagementShares.JShareSheet', Code, " + JMainFrame.CurrentPostCode + "," + JMainFrame.CurrentUserCode
                    + @" ,'' Comment, 1 Status , 0 MaxCount ,1 DivideType , 0 Value, 2 GroupCode  From ShareSheet Where Status = 1
                 Insert finAssetTransfer (Code, ACode, ParentCode, OwnershipType, ClassName, ObjectCode, Comment)
                 Select (Select MAX(Code) from finAssetTransfer ) + ROW_NUMBER() Over(Order by Code), Code, 0 ParentCode , 1 OwnerShipType , 
                'ManagementShares.JIncreaseShare', " + pBreakInfo.Code + ", N'افزایش سرمایه'  from finAsset Where ClassName =  'ManagementShares.JShareSheet' And Status = 1 " +
                     @" Insert finAssetShare (Code, ParentCode, PersonCode, Share, Status, TCode, ACode)
                 Select  (Select MAX(Code) from finAssetShare) + ROW_NUMBER() Over(Order by A.Code),
		         0 ParentCode , S.PCode, S.ShareCount, 1 Status , T.Code TCode , A.Code ACode
                 from ShareSheet S inner Join finAsset A on S.Code = A.ObjectCode And A.ClassName = 'ManagementShares.JShareSheet' and A.Status = 1
		         Inner join finAssetTransfer T on T.ACode = A.Code  And A.ClassName = 'ManagementShares.JShareSheet' and A.Status = 1 ";

                    /////////////// بروزرسانی سابقه بر اساس برگه های درج شده جدید
                    sql += @"
                Update ShareSheetLog Set NewSCode = ShareSheet.Code 
                From ShareSheetLog Inner Join ShareSheet on ShareSheetLog.PCode = ShareSheet .PCode and ShareSheet .Status = 1
                where NewSCode is null ";
                    //// اختصاص شماره سهم به "از و الی"ـ
                    sql += @"
                    UPDATE ShareSheet SET Az = (SELECT ISNULL(SUM(s .ShareCount ), 0) +1
                    FROM ShareSheet AS s WHERE s.Code < ShareSheet.Code  and s.Status =1 )
                    Update ShareSheet Set Ela = Az + ShareCount -1";
                    db.setQuery(sql);
                    if (db.Query_Execute() < 0)
                        throw new Exception();

                    return db.Commit();
                }


                //else
                //    throw new Exception();
            }
            catch
            {
                db.Rollback("Increase");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool DeActiveAllSheets(int IncreaseCode, JDataBase pDB)
        {
            JDataBase db;
            if (pDB == null)
                db = new JDataBase();
            else
                db = pDB;
            try
            {
                //////// درج سابقه برگه سهمها در Log
                string sql = @"
                    -------- Insert Log
                    Insert ShareSheetLog (Code, SCode, PCode, NewSCode , NewPCode,   OperationCode, Operation)
                    Select (Select MAX(Code) from ShareSheetLog) + ROW_NUMBER() Over(Order by Code), Code, PCode, Null, PCode, "
                    + IncreaseCode.ToString() + ", " + JShareOperations.IncreaseShare.GetHashCode().ToString() +
                    @" from ShareSheet Where CompanyCode = " + this.Code + " AND  Status = 1 ";
                ////// غیر فعال کردن دارایی ها
                sql +=
                @"--- Deactive Asset 
                Update finAssetShare  Set Status = 0 Where ACode IN(Select Code From finAsset Where  ClassName  = 'ManagementShares.JShareSheet' and Status = 1)
                Update finAsset Set Status = 0 Where ClassName  = 'ManagementShares.JShareSheet' and Status = 1";

                sql += " UPDATE  ShareSheet SET Status = 0 WHERE Status = " + JSheetStatus.Active.GetHashCode();
                db.setQuery(sql);
                return db.Query_Execute() >= 0;
            }
            finally
            {
                if (pDB == null)
                    db.Dispose();
            }
        }
        public void ShowDialog()
        {
            JShareCompanyForm form = new JShareCompanyForm();
            form.State = JFormState.Insert;
            form.ShowDialog();
        }
        public void ShowDialog(int Code)
        {
            JShareCompanyForm form = new JShareCompanyForm(Code);
            form.ShowDialog();
        }
        /// <summary>
        /// نمایش فرم افزایش سرمایه
        /// </summary>
        public void ShowIncreaseShareForm(int pCompanyCode)
        {
            if (JPermission.CheckPermission("ManagementShares.JShareCompany.ShowIncreaseShareForm"))
            {
                ManagementShares.JIncreaseShareForm inForm = new JIncreaseShareForm(pCompanyCode);
                inForm.ShowDialog();
            }
        }
        /// <summary>
        /// نمایش فرم  تجمیع برگه ها
        /// </summary>
        public void ShowJoinSheetsForm(int pCompanyCode)
        {
            if (JPermission.CheckPermission("ManagementShares.JShareCompany.ShowJoinSheetsForm"))
            {
                ManagementShares.JoinSheetsForm inForm = new ManagementShares.JoinSheetsForm(pCompanyCode);
                inForm.ShowDialog();
            }
        }
           /// <summary>
        /// نمایش فرم شکستن برگه ها
        /// </summary>
        public void ShowBreakSheetsForm(int pCompanyCode)
        {
            if (JPermission.CheckPermission("ManagementShares.JShareCompany.ShowBreakSheetsForm"))
            {
                ManagementShares.JBreakSheetsForm frm = new JBreakSheetsForm(pCompanyCode);
                frm.ShowDialog();
            }
        }
    }
    public class JShareCompanies : JManagementshares
    {

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("JShareCompany", "ManagementShares.JShareCompany.GetNode");
            Nodes.DataTable = GetDataTable(0);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JShareCompany", "ManagementShares.JShareCompany.ShowDialog", null, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
            Nodes.GlobalMenuActions.Insert(new JAction("new...", "ManagementShares.JShareCompany.ShowDialog", null, null));
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Qouery = JShareCompany.Query;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = " WHERE 1=1 ";
            try
            {
                if (pCode > 0)
                    Where = Where + " AND ShareCompany.Code=" + pCode;
                Db.setQuery(Qouery + Where);
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

        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

    }
}