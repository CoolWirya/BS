using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JAssemblyPresence : JSystem
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد مجمع
        /// </summary>
        public int ACode { get; set; }
        /// <summary>
        /// کد وکیل )کد شخص(
        /// </summary>
        public int AgentPCode { get; set; }
        /// <summary>
        /// زمان حضور
        /// </summary>
        public DateTime PresenceTime { get; set; }
		///// <summary>
		///// (
		///// </summary>
		//public int VoteRight { get; set; }
		///// <summary>
		///// (
		///// </summary>
		//public bool AddedToList { get; set; }
        #endregion Properties

		int CompanyCode;
        public JAssemblyPresence(int pCompanyCode, String P)
        {
			CompanyCode = pCompanyCode;
        }
		public JAssemblyPresence(int pCompanyCode, int pCode)
        {
			CompanyCode = pCompanyCode;
			Code = pCode;
            //JTable.SetToClassProperty(this, GetData(pCode).Rows[0]);
        }

        public System.Data.DataTable GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select  * FROM ShareAssemblyPresence WHERE Code=" + pCode.ToString();
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool Exists()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(string.Format("SELECT Code FROM ShareAssemblyPresence WHERE Code<> {0} AND ACode = {2} AND AgentPCode={1} ", this.Code, this.AgentPCode, this.ACode));
                return DB.Query_DataTable().Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static bool ExistsSahamdarCode(int pAgentPCode,int pACode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(string.Format("SELECT Code FROM ShareAssemblyPresence WHERE AgentPCode= " + pAgentPCode + " And ACode=" + pACode));
                return DB.Query_DataTable().Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert()
        {
            JAssemblyPresenceTable companyTable = new JAssemblyPresenceTable();
            try
            {
                companyTable.SetValueProperty(this);
                Code = companyTable.Insert();
                if (Code > 0)
                {
                    return Code;
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

        public bool Update()
        {
            JAssemblyPresenceTable companyTable = new JAssemblyPresenceTable();
            try
            {
                companyTable.SetValueProperty(this);
                return companyTable.Update();
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
        public Boolean Delete()
        {
            try
            {
                JAssemblyPresenceTable JPT = new JAssemblyPresenceTable();
                JPT.SetValueProperty(this);
                return (JPT.Delete());
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public class JAssemblyPresences : JSystem
    {
        public int AssemblyCode;
		static int CompanyCode;
        public JAssemblyPresences(int pAssemblyCode, int pCompanyCode)
        {
			CompanyCode = pCompanyCode;
            AssemblyCode = pAssemblyCode;
        }
        /// <summary>
        /// گرفتن تعداد حق رای
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static int GetVoteRight(Int64 pPCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                int VoteRight = 0;
				db.setQuery(" Select IsNull(SUM(ShareCount),0) from ShareSheet Where CompanyCode=" + CompanyCode.ToString() + " And ShareSheet.Status = " + JSheetStatus.Active.GetHashCode() + " and ACode = (select Code From ShareAgent Where Status=1 And PCode=(Select top 1 PersonCode from SharePCodeSheet where companycode = " + CompanyCode.ToString() + " and sharepCode=" + pPCode + "))");
                DataTable dt = db.Query_DataTable();
                if (dt.Rows.Count > 0)
                    VoteRight = Convert.ToInt32(dt.Rows[0][0].ToString());
                if (VoteRight == 0)
                {
					db.setQuery("Select ISNULL(SUM(ShareCount), 0) FROM ShareSheet Where CompanyCode=" + CompanyCode.ToString() + " And Status = 1 AND ACode is null And pCode= " + pPCode);
                    VoteRight = Convert.ToInt32(db.Query_DataTable().Rows[0][0].ToString());
                }
                return VoteRight;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// تعداد اشخاص حاضر
        /// </summary>
        /// <returns></returns>
		public static int GetVoteRightOfExistingAgents(int pAssemblyCode, int pPCode)
		{
			JDataBase DB = new JDataBase();
			try
			{
				string query = @"Select * from
              (
				SELECT ACode,AgentPCode,  
					(
						isnull((Select SUM(ShareCount) FROM ShareSheet Where CompanyCode = "+CompanyCode.ToString()+@" and Status = 1 AND 
						(
							ACode = (Select Code FROM ShareAgent WHERE PCode = clsAllPerson.Code)
							OR
							(ACode is null AND PCode = B.AgentPCode)
						)
						),0)
					)
				 VoteRight
              FROM [ShareAssemblyPresence] B
              Inner Join clsAllPerson ON AgentPCode = clsAllPerson.Code) A
			WHERE ACode = " + pAssemblyCode.ToString() + " And AgentPCode=" + pPCode;
				DB.setQuery(query);
				return Convert.ToInt32(DB.Query_DataTable().Rows[0]["VoteRight"]);

			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
			finally
			{
				DB.Dispose();
			}
		}
        /// <summary>
        /// حاضرین در مجمع
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public System.Data.DataTable GetData(int pVoteRight, bool OnlyNews)
        {
            JDataBase DB = new JDataBase();
            try
            {
				string query = @"select * from
			(
				SELECT A.Code,AgentPCode ,Name,ACode
                  ,Cast (Cast ([PresenceTime] As Time) AS varchar(5)) PresenceTime
                  ,ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where CompanyCode = "+CompanyCode.ToString()+ @" AND Status = 1 AND ACode = (Select Code FROM ShareAgent WHERE PCode = clsAllPerson.Code  and CompanyCode = " + CompanyCode.ToString() + @")), 0) +
                  ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where CompanyCode = " + CompanyCode.ToString() + @" AND Status = 1 AND ACode is null AND pCode = A.AgentPCode), 0) VoteRight
              FROM [ShareAssemblyPresence] A
              Inner Join clsAllPerson ON AgentPCode = clsAllPerson.Code
			  Inner Join ShareAssemblies SA ON SA.Code = A.ACode
			  WHERE SA.CompanyCode = " +CompanyCode.ToString()+@"
			  ) as a

               WHERE ACode=" + AssemblyCode.ToString();
                if (pVoteRight > 0)
                    query += " AND VoteRight = " + pVoteRight;
				//if (OnlyNews)
				//	query += " AND AddedToList = 0 ";
                DB.setQuery(query + " ORDER BY PresenceTime ");
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
        /// حاضرین در مجمع
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" Select  * FROM (SELECT ShareAssemblyPresence.Code ,AgentPCode ,Name, ACode
                  ,Cast (Cast ([PresenceTime] As Time) AS varchar(5)) PresenceTime

				  ,ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where CompanyCode = " + CompanyCode.ToString() + @" AND Status = 1 AND ACode = (Select Code FROM ShareAgent WHERE PCode = clsAllPerson.Code and CompanyCode = " + CompanyCode.ToString() + @")), 0) +
                  ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where CompanyCode = " + CompanyCode.ToString() + @" AND Status = 1 AND ACode is null AND pCode = A.AgentPCode), 0) VoteRight


					FROM [ShareAssemblyPresence]
                      Inner Join clsAllPerson ON AgentPCode = clsAllPerson.Code)A
                       WHERE ACode=" + AssemblyCode.ToString();
                //if (pCode > 0)
                //query += " AND Code = " + pCode;
                if (pCode > 0)
                    query += " AND Code = " + pCode;
                DB.setQuery(query + " ORDER BY PresenceTime ");
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
        /// تعداد اشخاص حاضر
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfExistingAgents()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"  SELECT Count( AgentPCode )  FROM [ShareAssemblyPresence]
              Inner Join clsAllPerson ON AgentPCode = clsAllPerson.Code WHERE ACode = " + AssemblyCode.ToString();
                DB.setQuery(query);
                return Convert.ToInt32(DB.Query_DataTable().Rows[0][0]);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// اشخاصی که قبلا به لیست اضافه شده اند با AddedToList تشخیص داده میشوند
        /// این تابع هه اشخاص را از لیست حذف میکند.
        /// </summary>
        /// <returns></returns>
        public int RemoveAllFromList()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" UPDATE [ShareAssemblyPresence] SET AddedToList = 0 WHERE ACode = " + AssemblyCode.ToString();
                DB.setQuery(query);
                return DB.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int AddAllToList()
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @" UPDATE [ShareAssemblyPresence] SET AddedToList = 1 WHERE ACode = " + AssemblyCode.ToString() + " AND AddedToList = 0 ";
                DB.setQuery(query);
                return DB.Query_Execute();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// تعداد رای حاضر
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfExistingRights()
        {
			JDataBase DB = new JDataBase();
			try
			{
				string query = @" Select ISNULL( Sum(VoteRight), 0) from
              (
				SELECT ACode,  
					(
					  ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where CompanyCode = " + CompanyCode.ToString() + @" AND Status = 1 AND ACode = (Select Code FROM ShareAgent WHERE PCode = clsAllPerson.Code  and CompanyCode = " + CompanyCode.ToString() + @")), 0) +
					  ISNULL( (Select SUM(ShareCount) FROM ShareSheet Where CompanyCode = " + CompanyCode.ToString() + @" AND Status = 1 AND ACode is null AND pCode = B.AgentPCode), 0)
					)
				 VoteRight
              FROM [ShareAssemblyPresence] B
              Inner Join clsAllPerson ON AgentPCode = clsAllPerson.Code) A
              WHERE ACode=" + AssemblyCode.ToString();
				DB.setQuery(query);
				return Convert.ToInt32(DB.Query_DataTable().Rows[0][0]);
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
				return 0;
			}
			finally
			{
				DB.Dispose();
			}
        }
        public JNode[] TreeView()
        {
            return null;
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("JAssembly", "ManagementShares.JAssembly.GetNode");
            Nodes.DataTable = GetData(0, false);

            JAction newAction = new JAction("New...", "ManagementShares.JAssembly.ShowDialog", new object[] { this.AssemblyCode }, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);
        }
    }
}
