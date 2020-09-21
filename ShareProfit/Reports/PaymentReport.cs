using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;
using ManagementShares;

namespace ShareProfit
{
    public class JPaymentReport
    {
        public decimal SumPayment = 0;
        public decimal SumManagementsharesCount = 0;

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Courses"></param>
        /// <param name="Documents"></param>
        /// <returns></returns>
        private string CreateSelectCommand(int[] Courses, int[] Documents)
        {
            string SelectCommand = @"SELECT A.pcode, A.sumpay, A.Az, A.Ela, A.Stockcount, A.lastpaydate, A.coursecode , A.doccode, A.sheetno";
            //if (Courses.Length > 0)
            {
                SelectCommand = SelectCommand + ", sahamcourse.title as coursetitle, sahamcourse.finyear ";//, sahamcourse.cost as Stockcost ";
            }
            //if (Documents.Length > 0)
            {
                SelectCommand = SelectCommand + " , sahamdocument.docdesc, cashes.name as paylocname";
            }
             //,P.BirthplaceCode
            SelectCommand = SelectCommand + @"  , P.Name, P.Fam, P.FatherName, P.ShSh, P.shMeli, Cities.City as HomeCityName   
             FROM (SELECT sahampayment.pcode, Sum(paycost)as sumpay ,MIN(Stockno)  Az, MAX(Stockno) Ela
            , max(Stockno) - min(Stockno) +1  as Stockcount , Max(paydate) as lastpaydate, sahampayment.sheetno";
            //if (Courses.Length > 0)
            {
                SelectCommand = SelectCommand + ", sahampayment.coursecode ";
            }
            //if (Documents.Length > 0)
            {
                SelectCommand = SelectCommand + ",sahampayment.doccode ";
            }

            SelectCommand = SelectCommand + @" from sahampayment group by pcode , sheetno";

            //if (Documents.Length > 0)
            {
                SelectCommand = SelectCommand + " ,sahampayment.doccode ";
            }
            //if (Courses.Length > 0)
            {
                SelectCommand = SelectCommand + ", sahampayment.coursecode";
            }
            
            SelectCommand = SelectCommand + " )  as A";

            //if (Courses.Length > 0)
            {
                SelectCommand = SelectCommand + "	inner join sahamcourse on A.coursecode = sahamcourse.Code";
            }
            //if (Documents.Length > 0)
            {
                SelectCommand = SelectCommand + "	inner join sahamdocument on doccode = sahamdocument.code";
                SelectCommand = SelectCommand + " left outer join subdefine cashes on cashes.code= sahamdocument.payloc ";
            }

            SelectCommand = SelectCommand + "	inner join " + JTableNamesClassLibrary.PersonTable + " P on P.Code = A.pcode";
            //JDataBase DB = JGlobal.MainFrame.GetSharesDB();

            SelectCommand = SelectCommand + " inner join " + JGlobal.MainFrame.GetSharesDB().DataBaseName + "." + "General.Cities.Cities on P.BirthplaceCode = Cities.Code ";
            SelectCommand = SelectCommand + " WHERE A.pcode>0";
            if (Courses.Length > 0)
            {
                int Count = 0;
                foreach (int selectedCourse in Courses)
                {
                    if (Count == 0)
                        SelectCommand = SelectCommand + "  AND A.coursecode IN(" + selectedCourse.ToString();
                    else
                    {
                        SelectCommand = SelectCommand + ", " + selectedCourse.ToString();
                    }
                    Count++;
                }
                SelectCommand = SelectCommand + ")";
            }
            if (Documents.Length > 0)
            {
                int Count = 0;
                foreach (int selectedDoc in Documents)
                {
                    if (Count == 0)
                        SelectCommand = SelectCommand + "  AND doccode IN(" + selectedDoc.ToString();
                    else
                    {
                        SelectCommand = SelectCommand + ", " + selectedDoc.ToString();
                    }
                    Count++;
                }
                SelectCommand = SelectCommand + ")";
            }
            return SelectCommand;
        }

        /// <summary>
        /// جستجو از جدول موقت برای اینکه با سرعت بیشتری خروجی داشته باشیم
        /// </summary>
        /// <param name="pPCode"></param>
        /// <param name="pFromSheetNo"></param>
        /// <param name="pToSheetNo"></param>
        /// <param name="pCityCode"></param>
        /// <param name="pCredit"></param>
        /// <param name="pCourses"></param>
        /// <returns></returns>
        public static DataSet ReportFromTempTable(int pPCode, int pFromSheetNo, int pToSheetNo, int pCityCode, int pCredit, int[] pCourses)
        {

            JDataBase DB = JGlobal.MainFrame.GetDBO();

            string SelectFields = @"SELECT * ";
            string From = @" FROM TempPayment ";
            string SelectSum = @" SELECT Sum(SumManagementsharesCount) AS SumManagementsharesCount , Sum(payed) SumPayed ,sum(SumManagementsharesCount * dbo.sahamcourse.cost) SumAllProfit 
              from TempPayment inner join sahamcourse on TempPayment.courseCode = sahamcourse.Code ";

            string WhereClause = " WHERE 1=1 ";
            if (pPCode != 0)
            {
                WhereClause = WhereClause + " AND ManagementsharesHolderCode = " + pPCode.ToString();
            }
            if (pFromSheetNo != 0)
            {
                WhereClause = WhereClause + " AND  SheetNo>=" + pFromSheetNo.ToString();
            }
            if (pToSheetNo != 0)
            {
                WhereClause = WhereClause + " AND SheetNo <=" + pToSheetNo.ToString();
            }
            if (pCityCode != 0)
            {
                WhereClause = WhereClause + " AND City=" + pCityCode.ToString();
            }
            if (pCredit == 0)
            {
                WhereClause = WhereClause + " AND Credit = 0";
            }
            if (pCredit > 0)
            {
                WhereClause = WhereClause + " AND Credit> 0";
            }

            WhereClause = WhereClause + " AND CourseCode IN " + JDataBase.GetInSQLClause(pCourses);

            DB.setQuery(SelectFields + From + WhereClause + " ORDER BY ManagementsharesHolderCode" +
                SelectSum + WhereClause);

            try
            {
                DB.Query_DataSet();
                DataSet DSet = DB.DataSet;
                return DSet;
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
        /// <summary>
        /// جستجو در جداول اصلی سهام  که بر روی سرور قرار دارند
        /// </summary>
        /// <param name="pPCode"></param>
        /// <param name="pFromSheetNo"></param>
        /// <param name="pToSheetNo"></param>
        /// <param name="pCityCode"></param>
        /// <param name="pCredit"></param>
        /// <param name="pCourses"></param>
        /// <returns></returns>
        public static DataSet ReportForm(int pPCode, int pFromSheetNo, int pToSheetNo, int pCityCode, int pCredit, int[] pCourses)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            
            string SelectFields = @" SELECT    s.Code SheetNo,  s.Az,  s.Ela , s.SumSahm AS SumManagementsharesCount , s.PCode as ManagementsharesHolderCode , 
                                o.Name+' '+o.Fam as NameFam, o.FatherName , o.ShSh, o.ShMeli ShMelli, Cities.City,
                                  a.CourseCode, sahamcourse.cost courseCost , dbo.sahamcourse.title, s.SumSahm * sahamcourse.cost AllProfit , pay as  payed , 
                                  (s.SumSahm * sahamcourse.cost - pay)as Credit, ---بستانکار
            			case o.Die when 1 then 'متوفی'	else '' end as Died,
            		    case o.Block when 1 then 'بازداشتی'	else '' end as Blocked";
            string SelectSum = " SELECT Sum(s.SumSahm) AS SumManagementsharesCount , Sum((s.SumSahm * sahamcourse.cost - pay)) SumPayed ,sum(s.SumSahm * dbo.sahamcourse.cost) SumAllProfit ";
            string From = @" 
                                    FROM         (SELECT     s.Code SheetCode, sc.Code CourseCode, SUM(isnull(paycost, 0)) pay
                                    FROM         " +(new JConfig()).DatabaseSaham + @".dbo.temp_sahm AS ts INNER JOIN
                                                          sahamcourse sc ON 1 = 1 LEFT JOIN
                                                          sahampayment sp ON (sp.stockno = ts .Sahm_No AND sp.coursecode = sc.code) INNER JOIN
                                                           " + (new JConfig()).DatabaseSaham + "." +(new JConfig()).SheetSahamTableName + @" s ON ts .Sahm_No >= s.Az AND ts .Sahm_No <= s.Ela "+
                                    //" WHERE     s.Status <>3 "+
                                    " WHERE     s.DeActive = 0 "+
                                    @" GROUP BY s.Code, sc.Code) a INNER JOIN
                                   " + (new JConfig()).DatabaseSaham + "." + (new JConfig()).SheetSahamTableName + @" s ON s.Code = a.SheetCode INNER JOIN
                                   " + (new JConfig()).DatabaseSaham + @".General.OtherPerson o ON s.PCode = o.Code INNER JOIN
                                  dbo.sahamcourse ON a.CourseCode = dbo.sahamcourse.Code   INNER JOIN 
            			           " + (new JConfig()).DatabaseSaham + @".General.Cities Cities On o.MCity = Cities.Code	";


            string WhereClause = " WHERE 1=1 ";
            if (pPCode != 0)
            {
                                WhereClause = WhereClause + " AND PCode = " + pPCode.ToString();
                //WhereClause = WhereClause + " AND ManagementsharesHolderCode = " + pPCode.ToString();
            }
            if (pFromSheetNo!=0)
            {
                                WhereClause = WhereClause + " AND s.Code >=" + pFromSheetNo.ToString();
                //WhereClause = WhereClause + " AND  SheetNo>=" + pFromSheetNo.ToString();
            }
            if (pToSheetNo!=0)
            {
                                WhereClause = WhereClause + " AND s.Code <=" + pToSheetNo.ToString();
                //WhereClause = WhereClause + " AND SheetNo <=" + pToSheetNo.ToString();
            }
            if (pCityCode!=0)
            {
                WhereClause = WhereClause + " AND City=" + pCityCode.ToString();
            }
            if (pCredit==0)
            {
                                WhereClause = WhereClause + " AND (s.SumSahm * sahamcourse.cost - pay)=0";
                //WhereClause = WhereClause + " AND Credit = 0";
            }
            if (pCredit>0)
            {
                                WhereClause = WhereClause + " AND (s.SumSahm * sahamcourse.cost - pay) >0";
                //WhereClause = WhereClause + " AND Credit> 0";
            }

            if (pCourses.Length > 0)
                WhereClause = WhereClause + " AND CourseCode IN " + JDataBase.GetInSQLClause(pCourses);

                DB.setQuery(SelectFields + From + WhereClause + " ORDER BY ManagementsharesHolderCode" +
                            SelectSum + From + WhereClause);
                    //    SelectSum + WhereClause);

            try
            {
            DB.Query_DataSet();
                DataSet DSet = DB.DataSet;
                //table = tmp;
                return DSet;
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


        public static DataTable MainReport(int pPCode, string pName, string pLastName, int pCityCode, int pSheetNo,
                    int[] pCourses, int pCredit, int pPaymentSource, int pShareNoAz, int pShareNoEla, string pFromDate,
                    string pToDate, bool pNotCity, string pPayFromDate, string pPayToDate, int pShareCountFrom, int pShareCountTo
            , bool pSheetDetails, ref string pDate)
        {
            /// در صورتی که پارامتر تاریخ وارد شده است
            bool HasDate = false;
            if (pFromDate != "    /  /" || pToDate != "    /  /")
                HasDate = true;

            bool HasPayDate = false;
            if (pPayFromDate  != "    /  /" || pPayToDate != "    /  /")
                HasPayDate = true;

            /// در صورتی که گزارش بر اساس برگه یا شخص بود
            string SelectFields = "";
            if (pSheetDetails)
                SelectFields = @"SELECT distinct * FROM ";
            else
                SelectFields = @"SELECT PCode, SUM(ShareCount) ShareCount, SUM(AllProfit) AllProfit, SUM(payed) payed, SUM(Credit) Credit, CourseCode, Course, courseCost
            , Name,  LastName , NameFam, FatherName , ShSh, ShMelli, Mobile , CityCode, City, ApproveDate, Died, Arrested   From ";

            SelectFields = SelectFields + @" (SELECT    s.Code SheetNo,  s.Az,  s.Ela , s.SumSahm AS ShareCount , s.PCode as PCode , 
                       CAST( case when  s.Code in(Select SCode from " + JGlobal.MainFrame.GetConfig().DatabaseSaham + "." + JGlobal.MainFrame.GetConfig().SheetSahamTableName.Split('.')[0] + @".[TransferSheet] where SCode = s.Code) then 1 else 0 end as  bit) as Transfered ,
                        a.CourseCode, sahamcourse.cost courseCost , sahamcourse.ApproveDate , dbo.sahamcourse.title Course , s.SumSahm * sahamcourse.cost AllProfit , pay as  payed , 
                        (s.SumSahm * sahamcourse.cost - pay) as Credit, ---بستانکار
                        Name" + ", " + " Fam LastName " + @", o.Name+' '+o.Fam as NameFam, o.FatherName , o.ShSh, o.ShMeli ShMelli, o.Mobile , Cities.Code CityCode,  Cities.City,
            			case o.Die when 1 then " + JDataBase.Quote(JLanguages._Text("Died")) + @" else '' end as Died,
            		    case o.Block when 1 then " + JDataBase.Quote(JLanguages._Text("Arrested")) + " else '' end as Arrested";

            string From = @" FROM ( SELECT  s.Code SheetCode, s.CourseCode CourseCode, SUM(isnull(paycost, 0)) pay,s.PCode 
                        FROM temp_sahm AS ts 
                        INNER JOIN  SahamSheet s
                         ON ts .Sahm_No >= s.Az AND ts .Sahm_No <= s.Ela ";
                       
            if (HasDate)
                From = From + " INNER JOIN ";
            else
                From = From + " LEFT JOIN ";


            From = From + @" sahampayment sp ON (sp.stockno = ts .Sahm_No AND sp.coursecode =   s.CourseCode ";
            /// در صورتی که تاریخ سند وارد شده 
            if (HasDate)
            {
                string strDate = "";
                From = From + " AND  sp.doccode IN (SELECT code From sahamdocument WHERE 1=1 ";
                if (pFromDate != "    /  /")
                {
                    From = From + " AND docdate>=" + JDataBase.Quote(pFromDate);
                    strDate = strDate + "از تاریخ " + pFromDate + " ";
                }
                if (pToDate != "    /  /")
                {
                    From = From + " AND docdate<=" + JDataBase.Quote(pToDate);
                    strDate = strDate + "تا تاریخ " + pToDate;
                }
                From = From + ")";
                pDate = strDate;
            }
            if (pPayFromDate != "    /  /")
            {
                From = From + " AND sp.paydate >=" + JDataBase.Quote(pPayToDate);
            }
            if (pPayToDate != "    /  /")
            {
                From = From + " AND sp.paydate <=" + JDataBase.Quote(pPayToDate);
            }
From = From +
                        @" )  WHERE  s.DeActive = 0
                           GROUP BY s.Code,  s.CourseCode,s.PCode  ) a INNER JOIN "
                         + "  SahamSheet s ON s.Code = a.SheetCode and s.PCode = a.PCode INNER JOIN " //@".Sepad.Sheet
            + JGlobal.MainFrame.GetConfig().DatabaseSaham + "." + JGlobal.MainFrame.GetConfig().PersonSahamTableName + @" o ON s.PCode = o.Code INNER JOIN
                        dbo.sahamcourse ON a.CourseCode = dbo.sahamcourse.Code   INNER JOIN 
			            " + JGlobal.MainFrame.GetConfig().DatabaseSaham + "." + JGlobal.MainFrame.GetConfig().CitiesTableName + " Cities  On o.MCity = Cities.Code) AS MainReport ";

            string WhereClause = " WHERE 1=1 ";

            if (pPCode != 0)
                WhereClause = WhereClause + " AND PCode = " + pPCode.ToString();
            if (pName.Trim() != "")
                WhereClause = WhereClause + " AND Name = " + JDataBase.Quote(pName.Trim(), false);
            if (pLastName.Trim() != "")
                WhereClause = WhereClause + " AND LastName = " + JDataBase.Quote(pLastName.Trim(), false);
            if (pCityCode != 0 && !pNotCity)
                WhereClause = WhereClause + " AND CityCode = " + pCityCode.ToString();
            if (pCityCode != 0 && pNotCity)
                WhereClause = WhereClause + " AND CityCode <> " + pCityCode.ToString();
            if (pSheetNo != 0)
                WhereClause = WhereClause + " AND SheetNo = " + pSheetNo.ToString();
            if (pCourses.Length > 0)
                WhereClause = WhereClause + " AND CourseCode IN " + JDataBase.GetInSQLClause(pCourses);
            if (pCredit == 0)
                WhereClause = WhereClause + " AND Payed = 0";
            if (pCredit > 0)
                WhereClause = WhereClause + " AND Payed > 0";
            if (pShareNoAz > 0)
                WhereClause = WhereClause + " AND Az >=" + pShareNoAz.ToString();
            if (pShareNoEla > 0)
                WhereClause = WhereClause + " AND Ela<=" + pShareNoEla.ToString();
            if (pSheetDetails)
            {
                if (pShareCountFrom > 0)
                    WhereClause = WhereClause + " AND ShareCount >= " + pShareCountFrom.ToString();
                if (pShareCountTo > 0)
                    WhereClause = WhereClause + " AND ShareCount <= " + pShareCountTo.ToString();
            }
            //
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            
            try
            {
                string Query = SelectFields + From + WhereClause;
                if (pSheetDetails)
                    Query = Query + " ORDER BY PCode, CourseCode ";
                else
                {
                    bool whereAnd = false;
                    Query = Query + " Group by PCode,CourseCode, Course, courseCost, Name,  LastName , NameFam, FatherName , ShSh, ShMelli, Mobile ,CityCode, City, ApproveDate, Died, Arrested  ";
                    if (pShareCountFrom > 0 || pShareCountTo > 0)
                        Query = Query + "  Having  ";
                    if (pShareCountFrom > 0)
                    {
                        Query = Query + " SUM(ShareCount) >= " + pShareCountFrom.ToString();
                        whereAnd = true;
                    }
                    if (pShareCountTo > 0)
                    {
                        if (whereAnd) Query=Query+" AND ";
                        Query = Query + " SUM(ShareCount) <= " + pShareCountTo.ToString();
                    }
                }
                DB.setQuery(Query, false);
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

    }
}
