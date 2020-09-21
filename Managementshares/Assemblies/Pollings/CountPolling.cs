using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JCountPolling :JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد انتخابات
        /// </summary>
        public int PollingCode { get; set; }
        /// <summary>
        /// شماره برگه
        /// </summary>
        public int VoteNo { get; set; }
        /// <summary>
        /// تعداد حق رأی
        /// </summary>
        public int RightCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PCode { get; set; }

		public int CompanyCode { get; set; }

        #endregion Properties

        public JCountPolling(int pCompanyCode, string P)
        {
			CompanyCode = pCompanyCode;
        }
		public JCountPolling(int pCode, int pCompanyCode)
        {
			CompanyCode = pCompanyCode;
            JTable.SetToClassProperty(this, GetData(pCode).Rows[0]);
        }
        private  DataTable GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select  * FROM ShareAssemblyPollingCount WHERE Code =" + pCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }
        /// <summary>
        /// گزینه های انتخاب شده برگه سهم
        /// </summary>
        /// <returns></returns>
        public DataTable GetSelectedChoice()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"
                    Select 
                        ShareAssemblyPollingCountChoice.ChoiceCode SelectedCode,
                        ISNULL( clsAllPerson.Name, ShareAssemblyPollingCandida.Title) Title from ShareAssemblyPollingCountChoice 
	                    Inner Join ShareAssemblyPollingCandida ON ShareAssemblyPollingCandida.Code = ShareAssemblyPollingCountChoice .ChoiceCode
	                    Left Join clsAllPerson ON ShareAssemblyPollingCandida.PCode = clsAllperson.Code 
                     WHERE PollingCountCode = " + this.Code;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }
        public int Insert(JDataBase pDB)
        {
            JCountPollingTable table = new JCountPollingTable();
            try
            {
                table.SetValueProperty(this);
                Code = table.Insert(pDB);
                return Code;
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

        public bool Update(JDataBase pDB)
        {
            JCountPollingTable table = new JCountPollingTable();
            try
            {
                table.SetValueProperty(this);
                return table.Update(pDB);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                //       Db.Dispose();
            }
        }

        /// <summary>
        /// ویرایش برگه رأی به همراه گزینه های انتخاب شده
        /// </summary>
        /// <param name="voteChoices"></param>
        public bool UpdateVote(DataTable voteChoices)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.beginTransaction("UpdateVote");
                if (this.Update(db))
                {
                    JCountPollingChoice tmpchoice = new JCountPollingChoice(0);
                    tmpchoice.DeleteAll(this.Code, db);
                    foreach (DataRow row in voteChoices.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            JCountPollingChoice choice = new JCountPollingChoice(0);
                            choice.ChoiceCode = Convert.ToInt32(row["SelectedCode"]);
                            choice.PollingCountCode = this.Code;
                            if (choice.Insert(db) == 0)
                                throw new Exception();
                        }
                    }
                    return db.Commit();
                }
                else
                    throw new Exception();
            }
            catch
            {
                db.Rollback("UpdateVote");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// ذخیره برگه رأی به همراه گزینه های انتخاب شده
        /// </summary>
        /// <param name="voteChoices"></param>
        public bool SaveVote(DataTable voteChoices)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.beginTransaction("InsertVote");
                if (this.Insert(db) > 0)
                {
                    foreach (DataRow row in voteChoices.Rows)
                    {
                        JCountPollingChoice choice = new JCountPollingChoice(0);
                        choice.ChoiceCode = Convert.ToInt32(row["SelectedCode"]);
                        choice.PollingCountCode = this.Code;
                        if (choice.Insert(db) == 0)
                            throw new Exception();
                    }
                    return db.Commit();
                }
                else
                    throw new Exception();
            }
            catch
            {
                db.Rollback("InsertVote");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Delete()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.beginTransaction("DeletePolling");
                JCountPollingTable JPT = new JCountPollingTable();
                JPT.SetValueProperty(this);
                foreach (DataRow row in JCountPollingChoices.GetData(this.Code).Rows)
                {
                    int choiceCode = Convert.ToInt32(row["Code"]);
                    JCountPollingChoice choice = new JCountPollingChoice(choiceCode);
                    if (!choice.Delete(db))
                        throw new Exception();
                }
                if (JPT.Delete(db))
                    return db.Commit();
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                db.Rollback("DeletePolling");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
    }

    public class JCountPollings : JSystem
    {
        int PollingCode;
		int CompanyCode;

        public JCountPollings(int pollingCode, int pCompanyCode)
        {
            PollingCode = pollingCode;
			CompanyCode = pCompanyCode;

        }
        /// <summary>
        /// محاسبه شماره برگه بعدی
        /// </summary>
        /// <returns></returns>
        public int GetNextVoteNo()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT ISNULL(MAX(VoteNo), 0) + 1 NextVoteNo FROM ShareAssemblyPollingCount WHERE [PollingCode] = " + PollingCode.ToString());
                DataTable table = db.Query_DataTable();
                if (table.Rows.Count > 0)
                {
                    return Convert.ToInt32(table.Rows[0][0]);
                }
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
       
        /// <summary>
        /// لیست برگه های شمارش شده
        /// </summary>
        /// <returns></returns>
        public DataTable GetCountedVotes()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"SELECT [Code],[Pollingcode],[Voteno],[Rightcount],
(
select count(*)  from 
ShareAssemblyPollingCountChoice CC where CC.PollingCountCode=ShareAssemblyPollingCount.Code
) count,(select Name from clsAllPerson where Code=(select PersonCode from SharePCodeSheet Where SharePCode=ShareAssemblyPollingCount.PCode and CompanyCode=" + CompanyCode.ToString() + @")) Name 
 FROM ShareAssemblyPollingCount WHERE [PollingCode] = " + PollingCode.ToString());

                //db.setQuery("SELECT [Code],[Pollingcode],[Voteno],[Rightcount] FROM ShareAssemblyPollingCount WHERE [PollingCode] = " + PollingCode.ToString());
                DataTable table = db.Query_DataTable();
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// ********* نتیجه شمارش آراء**********
        /// </summary>
        /// <returns></returns>
        public DataTable GetPollingResult()
        {
            string query = string.Format(@"
      Select 
-- شماره ردیف
[Rowno]
-- عنوان یا نام کاندیدا
, [Title]
-- تعداد آراء کسب شده
, [Votecount]
-- درصد آرای کسب شده
, [Percent]
-- تعداد به همراه درصد
,Cast(Votecount AS NVARCHAR(50)) + '  (' +CAST ( [Percent]AS nvarchar(50))+'%)' count_percent, PCode FROM 
-------------- Query اصلی (A)
  (Select Row_Number() OVER (ORDER BY VoteCount DESC) Rowno
  -- محاسبه دقیق درصد
  ,CAST (Cast((Votecount * 100) AS DECIMAL(18,2)) / ((   SELECT SUM(RightCount) FROM ShareAssemblyPollingCount WHERE [PollingCode] ={0}) * (Select MainMembers FROM ShareAssemblyPolling where Code = {0}))AS DECIMAL (18,2)) [Percent]
  -- عنوان یا نام
  , ISNULL(clsAllPerson.Name, ShareAssemblyPollingCandida.Title) Title
  --تعداد آراء کسب شده
  , Votecount , ShareAssemblyPollingCandida.PCode
   from ShareAssemblyPollingCandida INNER JOIN
		---- کد گزینه انتخاب شده و جمع آراء کسب شده انتخاب میشود (VotesCount)
	       (Select ChoiceCode ,ROUND(Sum (SumVote),0,0) Votecount  from (
				Select ShareAssemblyPollingCount.Code 
				,(MainMembers * RightCount) /(SELECT COUNT(*) FROM ShareAssemblyPollingCountChoice WHERE PollingCountCode = ShareAssemblyPollingCount.Code ) Sumvote 
				 FROM ShareAssemblyPolling 
				 INNER JOIN   ShareAssemblyPollingCount ON ShareAssemblyPolling.Code = ShareAssemblyPollingCount.PollingCode  AND PollingCode = {0}
	        ) CountVotes
	        INNER JOIN ShareAssemblyPollingCountChoice ON ShareAssemblyPollingCountChoice.PollingCountCode = CountVotes.Code
	        GROUP BY ChoiceCode) VotesCount   ON VotesCount.ChoiceCode = ShareAssemblyPollingCandida.Code
	        LEFT JOIN clsAllPerson ON clsAllPerson.Code = ShareAssemblyPollingCandida.PCode
	 )A 
		          ORDER BY VoteCount DESC  ", PollingCode);
             JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(query);
                DataTable table = db.Query_DataTable();
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetPollingResultCandida()
        {
            string query = string.Format(@"
      Select 
-- شماره ردیف
[Rowno]
-- عنوان یا نام کاندیدا
, [Title]
-- تعداد آراء کسب شده
, [Votecount]
-- درصد آرای کسب شده
, [Percent]
-- تعداد به همراه درصد
,Cast(Votecount AS NVARCHAR(50)) + '  (' +CAST ( [Percent]AS nvarchar(50))+'%)' count_percent, PCode FROM 
-------------- Query اصلی (A)
  (Select Row_Number() OVER (ORDER BY Title DESC) Rowno
  -- محاسبه دقیق درصد
  ,CAST (Cast((Votecount * 100) AS DECIMAL(18,2)) / ((   SELECT SUM(RightCount) FROM ShareAssemblyPollingCount WHERE [PollingCode] ={0}) * (Select MainMembers FROM ShareAssemblyPolling where Code = {0}))AS DECIMAL (18,2)) [Percent]
  -- عنوان یا نام
  , ISNULL(clsAllPerson.Name, ShareAssemblyPollingCandida.Title) Title
  --تعداد آراء کسب شده
  , Votecount , ShareAssemblyPollingCandida.PCode
   from ShareAssemblyPollingCandida LEFT JOIN
		---- کد گزینه انتخاب شده و جمع آراء کسب شده انتخاب میشود (VotesCount)
	       (Select ChoiceCode ,ROUND(Sum (SumVote),0,0) Votecount  from (
				Select ShareAssemblyPollingCount.Code 
				,(MainMembers * RightCount) /(SELECT COUNT(*) FROM ShareAssemblyPollingCountChoice WHERE PollingCountCode = ShareAssemblyPollingCount.Code ) Sumvote 
				 FROM ShareAssemblyPolling 
				 INNER JOIN   ShareAssemblyPollingCount ON ShareAssemblyPolling.Code = ShareAssemblyPollingCount.PollingCode  AND PollingCode = {0}
	        ) CountVotes
	        INNER JOIN ShareAssemblyPollingCountChoice ON ShareAssemblyPollingCountChoice.PollingCountCode = CountVotes.Code
	        GROUP BY ChoiceCode) VotesCount   ON VotesCount.ChoiceCode = ShareAssemblyPollingCandida.Code
	        LEFT JOIN clsAllPerson ON clsAllPerson.Code = ShareAssemblyPollingCandida.PCode where PollingCode=" + PollingCode + @"
	 )A 
		          ORDER BY Title ", PollingCode);
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(query);
                DataTable table = db.Query_DataTable();
                return table;
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// تعداد آراء شمارش شده
        /// </summary>
        /// <returns></returns>
        public int GetCountedSum()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT SUM(RightCount) FROM ShareAssemblyPollingCount WHERE [PollingCode] = " + PollingCode.ToString());
                DataTable table = db.Query_DataTable();
                return Convert.ToInt32(table.Rows[0][0]);
            }
            catch
            {
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool CheckExistanceVoteNo(int VoteNo)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT Code FROM ShareAssemblyPollingCount WHERE [PollingCode] = " + PollingCode.ToString()+
                    " AND VoteNo = "+ VoteNo.ToString());
                DataTable table = db.Query_DataTable();
                return table.Rows.Count>0;
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

        public bool CheckExistancePCode(int pPCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT Code FROM ShareAssemblyPollingCount WHERE [PollingCode] = " + PollingCode.ToString() +
                    " AND PCode = " + pPCode.ToString());
                DataTable table = db.Query_DataTable();
                return table.Rows.Count > 0;
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
    }


}
