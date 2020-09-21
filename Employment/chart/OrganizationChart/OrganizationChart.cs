using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;
namespace Employment
{
    /// <summary>
    /// کلاس چارت سازمانی
    /// </summary>
    public class JEOrganizationChart
    {
        #region constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JEOrganizationChart()
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        /// <param name="pCode">کد پست سازمانی</param>
        public JEOrganizationChart(int pCode)
        {
            GetData(pCode);
        }
        #endregion constructors

        #region Peroperties
        /// <summary>
        /// کد
        /// </summary>        
        public int code { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public int PostTitleCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int JobTitleCode { get; set; }
        /// <summary>
        /// کد کاربر منتصب
        /// </summary>
        public int user_code { get; set; }
        /// <summary>
        /// واحد هست یا نه
        /// </summary>
        public bool is_unit { get; set; }
        /// <summary>
        /// کد نود پدر
        /// </summary>
        public int parentcode { get; set; }
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code { get; set; }
        /// <summary>
        /// شماره پرسنلی
        /// </summary>        
        public int PersonNumber { get; set; }
        /// <summary>
        /// شماره کارت پرسنل
        /// </summary>        
        public int PersonCartNumber { get; set; }
        /// <summary>
        /// عنوان کامل
        /// </summary>
        public string full_title { get; set; }
        /// <summary>
        /// عنوان کامل
        /// </summary>
        public string full_Name { get; set; }
        public string Name { get; set; }
        public string Fam { get; set; }
        public string Job { get; set; }
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string UserName
        {
            get
            {
                Globals.JUser user = new Globals.JUser(user_code);
                return user.username;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CompanyCode;

        #endregion Peroperties

        #region Forms


		public bool ShowDialog()
		{
			return ShowDialog(JCompanyEmployee.CurrentCompany());
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ShowDialog(int pCompanyCode)
        {
            JEfrmOrganizatinChart OrgChart = new JEfrmOrganizatinChart(pCompanyCode);
            if (OrgChart.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }
            return false;
        }
        #endregion Forms

        #region BaseAction

        /// <summary>
        /// درج یک نود به چارت سازمانی
        /// </summary>
        /// <returns></returns>
		public bool InsertNode()
		{
			return InsertNode(true);
		}
		public bool InsertNode(bool pCheckpermission)
		{
			if (pCheckpermission && !JPermission.CheckPermission("Employment.JEOrganizationChart.InsertNode"))
			{
				return false;
			}
			JECharts ch = new JECharts();
			//if (ch.FindActiveChart(chart_code) == -1)
			//{
			//    JMessages.Message(JLanguages._Text("can not change in disactive chart"), "Error", JMessageType.Error);
			//    return false;
			//}

			//if (Find("",code))
			//    return false;
			string strParentCode = "NULL";
			if (parentcode != 0)
			{
				strParentCode = parentcode.ToString();
			}
			string strUserCode = "NULL";
			if (user_code != 0)
			{
				strUserCode = user_code.ToString();
			}

			int retCode = 0;
			string strInsert = @" DECLARE @Code INT  " +
				JDataBase.GetInsertSQL("organizationchart") +
							   " INSERT INTO organizationchart ( JobTitleCode, PostTitleCode, user_code, is_unit, parentcode, secretariat_code,[Code]) " +
							   " VALUES(" + JobTitleCode + ", " + PostTitleCode + "," + strUserCode + "," +
							   " '" + is_unit + "'," + strParentCode + "," + secretariat_code + ",@Code) " +
							   " SELECT @Code";
			JDataBase db = new JDataBase();
			try
			{
				db.setQuery(strInsert);
				retCode = int.Parse(db.Query_ExecutSacler().ToString());
			}
			catch (Exception ex)
			{
				JSystem.Except.AddException(ex);
			}
			finally
			{
				db.Dispose();
			}
			if (retCode != 0)
			{
				code = retCode;
				//Nodes.Insert(GetNode());
				return true;
			}
			return false;
		}

        /// <summary>
        /// ویرایش یک نود چارت سازمانی
        /// </summary>
        /// <returns></returns>
        public bool UpdateNode()
        {
            if (JPermission.CheckPermission("Employment.JEOrganizationChart.UpdateNode"))
            {
                //JECharts ch = new JECharts();

                //if (ch.FindActiveChart(chart_code) == -1)
                //{
                //    JMessages.Message(JLanguages._Text("can not change in disactive chart"), "Error", JMessageType.Error);
                //    return false;
                //}
                //if (!Find("", code) || code == 0)
                //    return false;

                string strParentCode = "NULL";
                if (parentcode != 0)
                {
                    strParentCode = parentcode.ToString();
                }
                string strUserCode = "NULL";
                if (user_code != 0)
                {
                    strUserCode = user_code.ToString();
                }

                int retCode = 0;
                string strInsert = " UPDATE  organizationchart set" +
                                   "  user_code=" + strUserCode + ", " +
                                   " is_unit='" + is_unit + "',parentcode=" + strParentCode + ", " +
                                   " JobTitleCode = " + JobTitleCode + ", PostTitleCode = " + PostTitleCode + ", " +
                                   " secretariat_code = " + secretariat_code +
                                   " where Code = " + code;
                JDataBase db = new JDataBase();
                try
                {
                    db.setQuery(strInsert);
                    retCode = int.Parse(db.Query_Execute().ToString());
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
                finally
                {
                    db.Dispose();
                }
                if (retCode != 0 && retCode != -1)
                {
                    //Nodes.Insert(GetNode());
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        ///حذف یک نود چارت سازمانی
        /// </summary>
        /// <returns></returns>
        public bool DeleteNode()
        {
            if (JPermission.CheckPermission("Employment.JEOrganizationChart.DeleteNode"))
            {
                JECharts ch = new JECharts();

                //if (ch.FindActiveChart(chart_code) == -1)
                //{
                //    JMessages.Message(JLanguages._Text("can not change in disactive chart"), "Error", JMessageType.Error);
                //    return false;
                //}
                if (ClassLibrary.JMainFrame.IsWeb() == false)
                    if (JMessages.Message(JLanguages._Text("Do you want delete this Item?"), "Question", JMessageType.Question) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return false;
                    }
                if (code == 0)
                {
                    return false;
                }
                string childs = "";
                DataTable dt = new DataTable();
                dt = GetOrganizationCharts(code);
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    childs += dt.Rows[i]["code"] + ",";
                }
                string strDelete = " DELETE FROM organizationchart where Code in (" + childs + code.ToString() + ")";
                int retCode = 0;
                JDataBase db = new JDataBase();
                try
                {
                    db.setQuery(strDelete);
                    retCode = int.Parse(db.Query_Execute().ToString());
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
                finally
                {
                    db.Dispose();
                }
                if (retCode != 0 && retCode != -1)
                {
                    return true;
                }
            }
            return false;

        }
        #endregion BaseAction

        #region GetInfo

        public static DataTable GetUserPosts()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT Code, Full_Title as [Title]
	                            FROM VOrganizationChart vo
	                            order by vo.Fam, vo.Name");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetUserPostsTree(int parentCode = -1)
        {
            JDataBase db = new JDataBase();
            try
            {
                string where = "";
                if (parentCode == 0)
                    where = " where parentcode=0 or parentcode is null ";
                else if (parentCode > 0)
                    where = " where parentcode=" + parentCode + " ";
                db.setQuery(@"SELECT Code, parentcode, Full_Title as [Title]
	                            FROM VOrganizationChart vo " + where + @"
	                            order by vo.Fam, vo.Name");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetAllData()
        {
            JDataBase db = new JDataBase();
            db.setQuery(" SELECT Code, Full_Title from VOrganizationChart order by Full_Title");
            try
            {
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

        public DataTable GetParents(int userPostCode)
        {
            JDataTable result = new JDataTable();
            return GetParents(userPostCode, result);
        }

        public DataTable GetParents(int userPostCode, DataTable result)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * from vorganizationchart where Code = " + userPostCode.ToString());
                DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count == 1)
                {
                    result.Merge(dt);
                    if (dt.Rows[0]["parentcode"].ToString() != "")
                        GetParents((int)dt.Rows[0]["parentcode"], result);
                }
                return result;
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

        public DataTable GetBrothers(int UserPostCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                DataTable result = new DataTable();
                db.setQuery("Select * from vorganizationchart where parentcode = (select parentcode from vorganizationchart where code = " + UserPostCode.ToString() + ") and Code <> " + UserPostCode.ToString());
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetUnits()
        {
            JDataBase db = new JDataBase();
            try
            {
                DataTable result = new DataTable();
                db.setQuery("Select * from vorganizationchart where is_unit = 1");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetChart(int pPostCode, int Level)
        {
            return GetChart(pPostCode.ToString(), Level);
        }
		public DataTable GetChart(int pPostCode, int Level, bool withusint)
		{
			return GetChart(pPostCode.ToString(), Level, withusint);
		}

		public DataTable GetChart(string pPostCodes, int Level)
		{
			return GetChart(pPostCodes, Level, true);
		}
        public DataTable GetChart(string pPostCodes, int Level, bool withusint)
        {
            DataTable dt = new DataTable();
            string[] PostCodes = pPostCodes.Split(new char[] { ';' });
            foreach (string _postcode in PostCodes)
            {
                int _code = int.Parse(_postcode);
                GetData(_code);

                if (is_unit)
                {
                    if (dt.Columns.Count == 0)
                        dt = GetUnits();
                    else
                        dt.Merge(GetUnits());
                }
                else
                {
                    if (dt.Columns.Count == 0)
                    {
                        dt = GetOrgChartByUserPostCode(_code, 1);
                    }
                    else
                    {
                        dt.Merge(GetOrgChartByUserPostCode(_code, 1));
                    }
                }
                DataTable dtChilds = GetChilds(_code, Level);
                DataTable dtBrothers = GetBrothers(_code);
                if (dtChilds != null) dt.Merge(dtChilds);
                if (dtBrothers != null) dt.Merge(dtBrothers);
            }
            dt.DefaultView.Sort = "Full_Title";
            (dt as JDataTable).RemoveDuplicateRows("Full_Title");
            return dt;

        }
        /// <summary>
        /// چارت سازمانی سطح بالا، هم سطح، سطح های پایین
        /// </summary>
        /// <param name="UserPostCode"></param>
        /// <returns></returns>
        public DataTable GetOrgChartByUserPostCode(int UserPostCode, int ChildLevel)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"declare @Code int
                                set @Code = {CODE}
                                select [Code]
                              ,[JobTitleCode]
                              ,[PostTitleCode]
                              ,[user_code]
                              ,[is_unit]
                              ,[parentcode]
                              ,[secretariat_code]
                              ,[PersonCartNumber]
                              ,[PersonNumber]
                              ,[Gender]
                              ,[GenderTitle]
                              ,[Name]
                              ,[Fam]
                              ,[full_title]
                              ,[full_name]
                              ,[pCode]
                              ,[Post]
                              ,[Job] + ' - ' + Fam as [Job]
                              ,[Title] from vorganizationchart where Code = (select parentcode from organizationchart where Code = @Code)
                                union all
                                select [Code]
                              ,[JobTitleCode]
                              ,[PostTitleCode]
                              ,[user_code]
                              ,[is_unit]
                              ,[parentcode]
                              ,[secretariat_code]
                              ,[PersonCartNumber]
                              ,[PersonNumber]
                              ,[Gender]
                              ,[GenderTitle]
                              ,[Name]
                              ,[Fam]
                              ,[full_title]
                              ,[full_name]
                              ,[pCode]
                              ,[Post]
                              ,[Job] + ' - ' + Fam as [Job]
                              ,[Title] from vorganizationChart where parentcode = (select parentcode from organizationchart where Code = @Code) and Code <> @Code ";
                query += GetChilds(UserPostCode, 1, ChildLevel);
                db.setQuery(query.Replace("{CODE}", UserPostCode.ToString()));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetChilds(int UserPostCode, int ChildLevel)
        {
            JDataBase db = new JDataBase();
            try
            {
                DataTable result = new DataTable();
                string query = GetChilds(UserPostCode, 1, ChildLevel);
                if (query.Length > 0)
                {
                    db.setQuery(query.Length > 11 ? query.Substring(11) : query);
                    return db.Query_DataTable();
                }
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public string GetChilds(int UserPostCode, int level, int ChildLevel)
        {
            if (level > ChildLevel) return "";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select Code From vorganizationchart Where parentcode = " + UserPostCode.ToString());
                DataTable dt = db.Query_DataTable();
                if (dt == null || dt.Rows.Count == 0) return "";
                string cquery = "";
                foreach (DataRow dr in dt.Rows)
                {
                    cquery += @" union all select [Code]
                              ,[JobTitleCode]
                              ,[PostTitleCode]
                              ,[user_code]
                              ,[is_unit]
                              ,[parentcode]
                              ,[secretariat_code]
                              ,[PersonCartNumber]
                              ,[PersonNumber]
                              ,[Gender]
                              ,[GenderTitle]
                              ,[Name]
                              ,[Fam]
                              ,[full_title]
                              ,[full_name]
                              ,[pCode]
                              ,[Post]
                              ,[Job] + ' - ' + Fam as [Job]
                              ,[Title] from vorganizationchart where Code = {CHILD_CODE}";
                    cquery = cquery.Replace("{CHILD_CODE}", dr[0].ToString());
                    cquery += GetChilds(Convert.ToInt32(dr[0]), level + 1, ChildLevel);
                }
                return cquery;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// لیست چارت سازمانی شامل زیر مجموعه و پدر و هم سطح های کاربری خاص 
        /// اصلاح برداشتن کد سریع 4/12/89
        /// <param name="User_Post_Code"></param>
        /// <returns></returns>
        public DataTable GetOrgChart_User(int User_Post_Code, string ListPost, bool StatePerson)
        {
            return GetOrgChart_User(User_Post_Code, ListPost, StatePerson, "");
        }

        public DataTable GetOrgChart_User(int User_Post_Code, string ListPost, bool StatePerson, string SQLFilter)
        {
            string tempSTR = "= " + User_Post_Code;
            if (User_Post_Code == 0)
                tempSTR = " is null ";
            JDataBase db = new JDataBase();
            try
            {
                string strSql = "";
                if (StatePerson)
                {
                    strSql = @"
with orgChart as ( 	  select Code,parentcode,title,metier_code,user_code,chart_code,is_unit,accesscode,0 as [level], b.full_title, b.full_name
 from dbo.vorganizationchart b  	  where b.parentcode   " + tempSTR + @"
 union all 
 select b.Code,b.parentcode, 
 b.title,b.metier_code,b.user_code,b.chart_code,b.is_unit,b.accesscode,[level] + 1,b.full_title ,b.full_name 	  from dbo.vorganizationchart b 
 join orgChart on b.parentcode =  orgChart.Code) 	
 
 select *

 from orgChart 	INNER JOIN subdefine ON orgChart.metier_code = subdefine.Code  	inner join 
 (select u.Code,p.Name,p.Fam,p.Gender,p.Code as 'pcode' from users u 	
 inner join  clsPerson p on (u.pcode = p.Code)  )users 
 on users.Code = orgChart.user_code    where 1=1 " +
SQLFilter +
@" 
union All
select Org.Code,Org.parentcode,Org.title,Org.metier_code,Org.user_code,Org.chart_code,Org.is_unit,Org.accesscode,0 as [level],full_title,full_name,
subdefine.*,users.Code,p.Name, p.Fam,p.Gender,users.pcode

 from dbo.VOrganizationChart Org 
INNER JOIN subdefine ON Org.metier_code = subdefine.Code
inner join users  on users.code=Org.user_code inner join clsPerson p on (users.pcode = p.Code) where 
(Org.parentcode in (select parentcode from organizationchart where code=" + User_Post_Code + @") or 
Org.Code in (select parentcode from organizationchart where code=" + User_Post_Code + @" or Org.Code in ("
       + ListPost + "))) and Org.Code <> " + User_Post_Code +
@"union All
select Org.Code,Org.parentcode,Org.title,Org.metier_code,Org.user_code,Org.chart_code,Org.is_unit,Org.accesscode,0 as [level],full_title,full_name,
subdefine.*,users.Code,p.Name, p.Fam,p.Gender,users.pcode

 from dbo.VOrganizationChart Org 
INNER JOIN subdefine ON Org.metier_code = subdefine.Code
inner join users  on users.code=Org.user_code inner join clsPerson p on (users.pcode = p.Code) where 
Org.Code in (        
select Receiver_Post_Code from ClsRelationPersons where Sender_Post_Code=  " + User_Post_Code + ") and Org.Code <> " + User_Post_Code;
                }
                else
                {
                    strSql = @"
with orgChart as ( 	  select Code,parentcode,title,metier_code,user_code,chart_code,is_unit,accesscode,0 as [level] 	 , full_title,full_name
 from dbo.vorganizationchart b  
 union all 	  
 select b.Code,b.parentcode,  		
 b.title,b.metier_code,b.user_code,b.chart_code,b.is_unit,b.accesscode,[level] + 1 ,b.full_title,full_name	  from dbo.vorganizationchart b 
 join orgChart on b.parentcode =  orgChart.Code) 	
 
 select * 	
 
from orgChart 	INNER JOIN subdefine ON orgChart.metier_code = subdefine.Code  	inner join 
 (select u.Code,p.Name,p.Fam,p.Gender,p.Code as 'pcode' from users u 	
 inner join  clsPerson p on (u.pcode = p.Code)  )users 
 on users.Code = orgChart.user_code    

union All
select Org.Code,Org.parentcode,Org.title,Org.metier_code,Org.user_code,Org.chart_code,Org.is_unit,Org.accesscode,0 as [level],full_title,full_name,
subdefine.*,users.Code,p.Name, p.Fam,p.Gender,users.pcode

 from dbo.VOrganizationChart Org 
INNER JOIN subdefine ON Org.metier_code = subdefine.Code
inner join users  on users.code=Org.user_code inner join clsPerson p on (users.pcode = p.Code) ";


                    //with orgChart as ( 	  select Code,parentcode,title,metier_code,user_code,chart_code,is_unit,accesscode,0 as [level] 	 
                    // from dbo.organizationchart b  
                    // union all 	  
                    // select b.Code,b.parentcode,  		
                    // b.title,b.metier_code,b.user_code,b.chart_code,b.is_unit,b.accesscode,[level] + 1 	  from dbo.organizationchart b 
                    // join orgChart on b.parentcode =  orgChart.Code) 	

                    // select *,
                    //ISNULL(users.Fam + ' ', '') + ISNULL(users.Name, '')+ '_' + subdefine.name + '_' + 
                    // orgChart.title+ '_' + convert(nvarchar,orgChart.accesscode) AS full_title 	

                    //from orgChart 	INNER JOIN subdefine ON orgChart.metier_code = subdefine.Code  	inner join 
                    // (select u.Code,p.Name,p.Fam,p.Gender,p.Code as 'pcode' from users u 	
                    // inner join  clsPerson p on (u.pcode = p.Code)  )users 
                    // on users.Code = orgChart.user_code    

                    //union All
                    //select Org.Code,Org.parentcode,Org.title,Org.metier_code,Org.user_code,Org.chart_code,Org.is_unit,Org.accesscode,0 as [level],
                    //subdefine.*,users.Code,p.Name, p.Fam,p.Gender,users.pcode,full_title

                    // from dbo.VOrganizationChart Org 
                    //INNER JOIN subdefine ON Org.metier_code = subdefine.Code
                    //inner join users  on users.code=Org.user_code inner join clsPerson p on (users.pcode = p.Code)
                }

                db.setQuery(strSql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }

        }
        /// <summary>
        /// لیست چارت سازمانی شامل زیر مجموعه و پدر و هم سطح های کاربری خاص 
        /// اصلاح برداشتن کد سریع 4/12/89
        /// <param name="User_Post_Code"></param>
        /// <returns></returns>
        //        public DataTable GetOrgChart_User_Temp333(int User_Post_Code, string ListPost, bool StatePerson)
        //        {
        //            JDataBase db = new JDataBase();
        //            try
        //            {
        //                string strSql = "";
        //                if (StatePerson)
        //                {
        //                    strSql = @"
        //with orgChart as ( 	  select Code,parentcode,title,metier_code,user_code,chart_code,is_unit,accesscode,0 as [level] 	 
        // from dbo.organizationchart b  	  where b.parentcode   = " + User_Post_Code + @"
        // union all 	  
        // select b.Code,b.parentcode,  		
        // b.title,b.metier_code,b.user_code,b.chart_code,b.is_unit,b.accesscode,[level] + 1 	  from dbo.organizationchart b 
        // join orgChart on b.parentcode =  orgChart.Code) 	
        // 
        // select *,orgChart.title+ '_' + subdefine.name + '_' + 
        // ISNULL(users.Fam + ' ', '') + ISNULL(users.Name, '')+ '_' + convert(nvarchar,orgChart.accesscode) AS full_title 	
        // from orgChart 	INNER JOIN subdefine ON orgChart.metier_code = subdefine.Code  	inner join 
        // (select u.Code,p.Name,p.Fam,p.Gender,p.Code as 'pcode' from users u 	
        // inner join  clsPerson p on (u.pcode = p.Code)  )users 
        // on users.Code = orgChart.user_code    
        //
        //union All
        //select Org.Code,Org.parentcode,Org.title,Org.metier_code,Org.user_code,Org.chart_code,Org.is_unit,Org.accesscode,0 as [level],
        //subdefine.*,users.Code,p.Name, p.Fam,p.Gender,users.pcode,
        //Org.title+ '_' + subdefine.name + '_' + 
        // ISNULL(p.Fam + ' ', '') + ISNULL(p.Name, '') AS full_title 
        // from organizationchart Org 
        //INNER JOIN subdefine ON Org.metier_code = subdefine.Code
        //inner join users  on users.code=Org.user_code inner join clsPerson p on (users.pcode = p.Code) where 
        //(Org.parentcode in (select parentcode from organizationchart where code=" + User_Post_Code + @") or 
        //Org.Code in (select parentcode from organizationchart where code=" + User_Post_Code + @" or Org.Code in ("
        //       + ListPost + "))) and Org.Code <> " + User_Post_Code;
        //                }
        //                else
        //                {
        //                    strSql = @"
        //with orgChart as ( 	  select Code,parentcode,title,metier_code,user_code,chart_code,is_unit,accesscode,0 as [level] 	 
        // from dbo.organizationchart b  
        // union all 	  
        // select b.Code,b.parentcode,  		
        // b.title,b.metier_code,b.user_code,b.chart_code,b.is_unit,b.accesscode,[level] + 1 	  from dbo.organizationchart b 
        // join orgChart on b.parentcode =  orgChart.Code) 	
        // 
        // select *,orgChart.title+ '_' + subdefine.name + '_' + 
        // ISNULL(users.Fam + ' ', '') + ISNULL(users.Name, '')+ '_' + convert(nvarchar,orgChart.accesscode) AS full_title 	
        // from orgChart 	INNER JOIN subdefine ON orgChart.metier_code = subdefine.Code  	inner join 
        // (select u.Code,p.Name,p.Fam,p.Gender,p.Code as 'pcode' from users u 	
        // inner join  clsPerson p on (u.pcode = p.Code)  )users 
        // on users.Code = orgChart.user_code    
        //
        //union All
        //select Org.Code,Org.parentcode,Org.title,Org.metier_code,Org.user_code,Org.chart_code,Org.is_unit,Org.accesscode,0 as [level],
        //subdefine.*,users.Code,p.Name, p.Fam,p.Gender,users.pcode,
        //Org.title+ '_' + subdefine.name + '_' + 
        // ISNULL(p.Fam + ' ', '') + ISNULL(p.Name, '') AS full_title 
        // from organizationchart Org 
        //INNER JOIN subdefine ON Org.metier_code = subdefine.Code
        //inner join users  on users.code=Org.user_code inner join clsPerson p on (users.pcode = p.Code) ";
        //                }
        //                db.setQuery(strSql);//+ '_' + convert(nvarchar,Org.accesscode)
        //                return db.Query_DataTable();
        //            }
        //            finally
        //            {
        //                db.Dispose();
        //            }

        //        }

        public static DataTable GetOrgChart_UserSpecfic(string ListPost)
        {
            JDataBase db = new JDataBase();
            try
            {
                string strSql = @"
select Org.Code,Org.parentcode,Org.title,Org.metier_code,Org.user_code,Org.chart_code,Org.is_unit,Org.accesscode,0 as [level],
subdefine.*,users.Code,p.Name, p.Fam,p.Gender,users.pcode,full_title,full_name

 from dbo.VOrganizationChart Org 
INNER JOIN subdefine ON Org.metier_code = subdefine.Code
inner join users  on users.code=Org.user_code inner join clsPerson p on (users.pcode = p.Code)  where Org.Code in (" + ListPost + ")";
                db.setQuery(strSql);//+ '_' + convert(nvarchar,Org.accesscode)
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// لیست چارت سازمانی
        /// </summary>
        /// <param name="ParentNode">کد نودی که از محل درخت را نیاز داریم . 0 برای کل درخت</param>
        /// <param name="pChartCode">کد چارت</param>
        /// <returns></returns>
        public DataTable GetOrganizationCharts(int ParentNode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string parentStart = "is null";
                if (ParentNode > 0)
                    parentStart = " = " + ParentNode.ToString();
                string strSql = "	with orgChart as ( " +
                                "	  select Code,parentcode,JobTitleCode,PostTitleCode,full_title,full_name,user_code,is_unit,0 as [level] " +
                                "	  from dbo.vorganizationchart b  " +
                                "	  where b.parentcode  " + parentStart +
                                "		union all " +
                                "	  select b.Code,b.parentcode,  " +
                                "		b.JobTitleCode,b.PostTitleCode,b.full_title,b.full_name,b.user_code,b.is_unit,[level] + 1 " +
                                "	  from dbo.vorganizationchart b join orgChart on b.parentcode =  orgChart.Code) " +
                                "	select *,  ISNULL(" + JTableNamesClassLibrary.UsersTable + ".Fam + ' ', '') + ISNULL(" + JTableNamesClassLibrary.UsersTable + ".Name, '')+ '_' + CASE WHEN (Select count(*) from subdefine left join EmpJobTitle on EmpJobTitle.TitleCode = subdefine.Code WHERE EmpJobTitle.Code = orgChart.JobTitleCode) = 0 THEN '(عنوان شغلی ندارد)' ELSE (Select name from subdefine left join EmpJobTitle on EmpJobTitle.TitleCode = subdefine.Code WHERE EmpJobTitle.Code = orgChart.JobTitleCode) END + '_' + orgChart.full_title AS full_title2 ,users.pcode " +
                                "	from orgChart " +
                                "	left join (select u.Code,u.PCode,p.Name,p.Fam,p.Gender from " + JTableNamesClassLibrary.UsersTable + " u " +
                                "	inner join  " + JTableNamesClassLibrary.PersonTable + " p on (u.pcode = p.Code)) " + JTableNamesClassLibrary.UsersTable + " on " + JTableNamesClassLibrary.UsersTable + ".Code = orgChart.user_code " +
                                "   ORDER BY [level] ASC";
                db.setQuery(strSql);

                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        ///لیست چارت سازمانی با کاربران مربوط به هر پست 
        /// </summary>
        /// <param name="ParentNode">کد نودی که از محل درخت را نیاز داریم . 0 برای کل درخت</param>
        /// <param name="pChartCode">کد چارت</param>
        /// <returns></returns>
        //public DataTable GetOrganizationChartsUser333(int ParentNode, int pChartCode)
        //{
        //    JDataBase db = new JDataBase();
        //    try
        //    {
        //        string parentStart = "is null";
        //        if (ParentNode > 0)
        //            parentStart = " = " + ParentNode.ToString();
        //        string strSql = "	with orgChart as ( " +
        //                        "	  select Code,parentcode,title,metier_code,user_code,chart_code,is_unit,accesscode,0 as [level] " +
        //                        "	  from dbo.organizationchart b  " +
        //                        "	  where b.parentcode  " + parentStart +
        //                        "		union all " +
        //                        "	  select b.Code,b.parentcode,  " +
        //                        "		b.title,b.metier_code,b.user_code,b.chart_code,b.is_unit,b.accesscode,[level] + 1 " +
        //                        "	  from dbo.VOrganizationchart b join orgChart on b.parentcode =  orgChart.Code) " +
        //                        "	select *, ISNULL(us.Fam + ' ', '') + ISNULL(us.Name, '') + '_' + subdefine.name + '_' + orgChart.title + '_' + convert(nvarchar,orgChart.accesscode) AS full_title " + //

        //                        "	from orgChart " +
        //                        "	INNER JOIN subdefine ON orgChart.metier_code = subdefine.Code  " +
        //                        "	inner join (select u.Code,p.Name,p.Fam,p.Sex from " + JTableNamesClassLibrary.UsersTable + " u " +
        //                        "	inner join  " + JTableNamesClassLibrary.PersonTable + " p on (u.pcode = p.Code)) " + JTableNamesClassLibrary.UsersTable + " on us.Code = orgChart. " + OrganizationChart.user_code +
        //                        "   where chart_code = " + pChartCode +
        //                        "   ORDER BY [level] ASC";

        //        db.setQuery(strSql);
        //        return db.Query_DataTable();
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //}

        /// <summary>
        ///لیست چارت سازمانی برای کاربری خاص 
        ///
        /// </summary>
        /// <param name="ParentNode">کد نودی که از محل درخت را نیاز داریم . 0 برای کل درخت</param>
        /// <param name="pChartCode">کد چارت</param>
        /// <returns></returns>
        //public DataTable GetOrganizationChartsSUser(int ParentNode, int pChartCode,int User_Code)
        //{
        //    JDataBase db = new JDataBase();
        //    string parentStart = "is null";
        //    if (ParentNode > 0)
        //        parentStart = " = " + ParentNode.ToString();
        //    string strSql = "	with orgChart as ( " +
        //                    "	  select Code,parentcode,title,metier_code,user_code,chart_code,is_unit,accesscode,0 as [level] " +
        //                    "	  from dbo.organizationchart b  " +
        //                    "	  where b.parentcode  " + parentStart +
        //                    "		union all " +
        //                    "	  select b.Code,b.parentcode,  " +
        //                    "		b.title,b.metier_code,b.user_code,b.chart_code,b.is_unit,b.accesscode,[level] + 1 " +
        //                    "	  from dbo.organizationchart b join orgChart on b.parentcode =  orgChart.Code) " +
        //                    "	select *,orgChart.title+ '_' + subdefine.name + '_' + ISNULL(" + JTableNamesClassLibrary.UsersTable + ".Fam + ' ', '') + ISNULL(" + JTableNamesClassLibrary.UsersTable + ".Name, '')+ '_' + convert(nvarchar,orgChart.accesscode) AS full_title " +
        //                    "	from orgChart " +
        //                    "	INNER JOIN subdefine ON orgChart.metier_code = subdefine.Code  " +
        //                    "	inner join (select u.Code,p.Name,p.Fam,p.Gender,p.Code as 'pcode' from " + JTableNamesClassLibrary.UsersTable + " u " +
        //                    "	inner join  " + JTableNamesClassLibrary.PersonTable + " p on (u.pcode = p.Code) And " + JTableNamesClassLibrary.UsersTable + ".pCode=" + User_Code.ToString() + " )"  + JTableNamesClassLibrary.UsersTable + " on " + JTableNamesClassLibrary.UsersTable + 
        //                    ".Code = orgChart.user_code " +
        //                    "   where chart_code = " + pChartCode  +
        //                    "   ORDER BY [level] ASC";

        //    db.setQuery(strSql);
        //    return db.Query_DataTable();
        //}
        /// <summary>
        /// پستهای مربوط به یک شخص خاص را برمیگرداند
        /// </summary>
        /// <returns></returns>
        public DataTable GetUserPostsByUser_code(int User_code)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM v" + JTableNamesEmployment.OrganizationChart + " OrgC WHERE OrgC." + OrganizationChart.user_code + "=" + User_code.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// جستجوی  نود چارت شازمانی
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        //public Boolean Find(int pCode)
        //{
        //    JDataBase db = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
        //        db.setQuery("SELECT * FROM " + JTableNamesEmployment.OrganizationChart + " WHERE " + OrganizationChart.code + "=" + JDataBase.Quote(pCode.ToString()));
        //        db.Query_DataReader();
        //        return db.DataReader.HasRows;
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //    return false;
        //}
        /// <summary>
        /// حستحو بر حسب نام
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Find(string pName, int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string pWhere = " Where 1=1 ";
                if (pName != "")
                    pWhere = pWhere + " title='" + pName + "' ";
                if (pCode != 0)
                    pWhere = pWhere + pCode;

                db.setQuery("SELECT * FROM " + JTableNamesEmployment.OrganizationChart + pWhere);
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }

        /// <summary>
        /// خروجی پدر
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetPost(int pCode, bool pParent)
        {
            return GetPost(pCode.ToString(), pParent);
        }

        public static DataTable GetPost(string pCode, bool pParent)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = "";
                if (pParent)
                    Query = @"SELECT Code,job + ' - ' + Fam as job,Full_Title,full_name FROM vorganizationchart 
                    Where 
                    Code = 
                            (Select ParentCode From organizationchart Where Code IN (" + pCode + ") )";
                else
                    Query = "SELECT  Code,job + ' - ' + Fam as job,Full_Title,full_name FROM vorganizationchart Where Code IN (" + pCode + ")";
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
        /// <summary>
        /// حستحو بر Query
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean FindQuery(string Query)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT TOP 1 * FROM " + JTableNamesEmployment.OrganizationChart + " WHERE " + Query);
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }
        /// <summary>
        /// جستجوی  نود چارت سازمانی
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public bool Find()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            string strSQL = "SELECT * FROM " + JTableNamesEmployment.OrganizationChart + " WHERE 1=1 ";
            if (code != null && code != 0) strSQL += " AND Code = " + code.ToString();
            if (parentcode != null && parentcode != 0) strSQL += " AND " + OrganizationChart.parentcode + " = " + parentcode.ToString();
            //if (is_unit != null) strSQL += " AND  is_unit = '" + is_unit.ToString() + "'";
            if (user_code != null && user_code != 0) strSQL += " AND " + OrganizationChart.user_code + " = " + user_code.ToString() + "   ";

            try
            {
                db.setQuery(strSQL);
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                string sql = " select oc.Code,oc.PostTitleCode,oc.JobTitleCode,(select EmpJobTitle.TitleCode from EmpJobTitle where EmpJobTitle.Code = oc.JobTitleCode) as metier_code,oc.user_code,oc.is_unit,oc.parentcode, (select EmpPostTitle.Title from EmpPostTitle where EmpPostTitle.Code = oc.PostTitleCode ) as title, " +
                                "  OC.full_title,OC.Full_Name,OC.Name,OC.Fam,OC.Job,secretariat_code  from dbo.VOrganizationChart oc " +
                                "                               left join (select u.Code,p.Name,p.Fam,p.Gender from " + JTableNamesClassLibrary.UsersTable + " u " +
                                "                               inner join  " + JTableNamesClassLibrary.PersonTable + " p on (u.pcode = p.Code)) " + JTableNamesClassLibrary.UsersTable + " on " + JTableNamesClassLibrary.UsersTable + ".Code = oc.user_code  where oc.Code = " + pCode;

                db.setQuery(sql);
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
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
                db.Dispose();
            }
        }
        #endregion GetInfo

        #region Function
        /// <summary>
        /// غیر فعال کردن کاربر این پست 
        /// </summary>
        /// <returns></returns>
        public bool DisableUser()
        {
            string strInsert = " UPDATE  organizationchart SET " +
                                           "  user_code = NULL WHERE Code = " + code;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(strInsert);
                return db.Query_Execute() >= 0;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion

        #region InfoPersonLetter

        public DataTable InfoLetterInternal(int sender_code, int sender_post_code, int Receiver_code, int Receiver_Post_code)
        {
            JDataBase db = new JDataBase();
            try
            {
                string strSql = @"
Select (select Name + ' '+Fam from clsPerson where Code= " + sender_code + @") As 'Sender_Name',
(select Title from organizationchart Where code=" + sender_post_code + @") as 'Sender_Post_Name',
(select name from subdefine Where code = (select metier_code from organizationchart Where code=" + sender_post_code + @")) as 'Sender_Title_Job',
(select Name + ' '+Fam from clsPerson where Code=" + Receiver_code + @") As 'Receiver_Name',
(select title from organizationchart Where code= " + Receiver_Post_code + @") as 'Receiver_Post_Name',
(select name from subdefine Where code = (select metier_code from organizationchart Where code= " + Receiver_Post_code + @")) as 'Receiver_Title_Job'";
                db.setQuery(strSql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable InfoLetterExport(int sender_code, int sender_post_code, int Receiver_code, int Receiver_external_code)
        {
            JDataBase db = new JDataBase();
            try
            {
                string strSql = @"Select (select Name + ' '+Fam from clsPerson where Code= " + sender_code + @") As 'Sender_Name',
(select Title from organizationchart Where code=" + sender_post_code + @" ) as 'Sender_Post_Name',
(select name from subdefine Where code = (select metier_code from organizationchart Where code= " + sender_post_code + @")) as 'Sender_Title_Job',
(select Name + ' '+Fam from clsPerson where Code= " + Receiver_code + @" ) As 'Receiver_Name',
(select Name  from organization where Code= " + Receiver_external_code + @") As 'Receiver_External_Name'";
                db.setQuery(strSql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable InfoLetterImport(int sender_code, int sender_external_code, int Receiver_code, int Receiver_Post_code)
        {
            JDataBase db = new JDataBase();
            try
            {
                string strSql = @" Select (select Name + ' '+Fam from clsPerson where Code=" + sender_code + @") As 'Sender_Name',
(select Name  from organization where Code=" + sender_external_code + @") As 'Sender_External_Name',
(select Name + ' '+Fam from clsPerson where Code= " + Receiver_code + @") As 'Receiver_Name',
(select title from organizationchart Where code= " + Receiver_Post_code + @") as 'Receiver_Post_Name',

(select name from subdefine Where code = (select metier_code from organizationchart Where code= " + Receiver_Post_code + ")) as 'Receiver_Title_Job'";
                db.setQuery(strSql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion
    }

    public class JEOrganizationCharts
    {
        public static List<int> GetPostCodeByPersonCode(int personCode)
        {
            List<int> postCodes = new List<int>();
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT vc.Code FROM VOrganizationChart vc
                                INNER JOIN users u ON u.code = vc.user_code
                                INNER JOIN clsAllPerson cap ON cap.Code = u.pcode
                                WHERE cap.code = " + personCode);
                var dt = db.Query_DataTable();
                if (dt != null)
                    foreach (DataRow row in dt.Rows)
                    {
                        postCodes.Add(Convert.ToInt32(row["Code"]));
                    }
                return postCodes;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static List<int> GetPostCodeByUserCode(int userCode)
        {
            List<int> postCodes = new List<int>();
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT vc.Code FROM VOrganizationChart vc
                                INNER JOIN users u ON u.code = vc.user_code
                                WHERE u.code = " + userCode);
                var dt = db.Query_DataTable();
                if (dt != null)
                    foreach (DataRow row in dt.Rows)
                    {
                        postCodes.Add(Convert.ToInt32(row["Code"]));
                    }
                return postCodes;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static bool MoveChildren(int srcPostCode, int desPostCode)
        {
            using (DataTable dt = JEOrganizationChart.GetUserPostsTree(srcPostCode))
            {
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int postCode;
                        int.TryParse(row["Code"].ToString(), out postCode);
                        if (postCode > 0)
                        {
                            JEOrganizationChart orgChart = new JEOrganizationChart(postCode);
                            orgChart.parentcode = desPostCode;
                            orgChart.UpdateNode();
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
