using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Bascol
{
    public class JReport : JBascol
    {
        public void ShowReportUserForm()
        {
            //if (JPermission.CheckPermission("Bascol.JReport.ShowReportUserForm", true))
            //{
                JReportUserForm p = new JReportUserForm();
                p.ShowDialog();
            //}
        }

        public void ShowReportMangerForm()
        {
            if (JPermission.CheckPermission("Bascol.JReport.ShowReportMangerForm", true))
            {
                JReportManagerForm p = new JReportManagerForm();
                p.ShowDialog();
            }
        }

        public void ShowReportChartForm()
        {
            if (JPermission.CheckPermission("Bascol.JReport.JReportChartForm", true))
            {
                //JReportChartForm p = new JReportChartForm();
                //p.ShowDialog();
            }
        }

        public void ShowConfigBascolForm()
        {
            JConfigBascolForm p = new JConfigBascolForm();
            p.ShowDialog();
        }

        public void ShowTaxForm()
        {
            JConfigTaxForm p = new JConfigTaxForm();
            p.ShowDialog();
        }

        public void ShowChangePlokForm()
        {
            //if (JPermission.CheckPermission("Bascol.JReport.ShowChangePlokForm", true))
            //{
                JChangePlokForm p = new JChangePlokForm();
                p.ShowDialog();
            //}
        }

        public static DataTable GetBascols(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                return GetBascols(pCode, db);
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

        public static DataTable GetBascols(int pCode, JDataBase db)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select * from Bascols " + Where;
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
            }
        }

        public static DataTable GetUsersBascols(int pCode)
        {
            string Where = " where cast(Wdate as date) > '2012-09-04' ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            //string Query = @"select Code,Full_Title Name From VOrganizationChart " + Where
            //    + " And " + JPermission.getObjectSql("Bascol.JReport.GetUsersBascols", "");
            string Query = @"Select distinct PersonCode Code, (select Fam from clsperson where Code=PersonCode) Name
 from BascolWeights " + Where;
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

        public static DataTable GetDataBedehkari(string Str)
        {
//            string Query = @"
//Select * from 
//(
//  SELECT clsAllPerson.Name,
//  (case  When (SUM(pay) - SUM(pay_h))>0 Then Sum(pay)-SUM(pay_h) ELSE 0 end)as debit,
//  (case  When (SUM(pay) - SUM(pay_h)) < 0 Then SUM(pay_h) - SUM(pay) ELSE 0 end)as crdit,PlokNo  
//  FROM (BascolWeights INNER JOIN BascolTruck ON BascolWeights.TruckCode=BascolTruck.Code )
//  INNER JOIN clsAllPerson ON BascolWeights.PersonCode=clsAllPerson.code WHERE pay_h != pay And dele = 0 
//" + Str  + @"
//  GROUP BY PlokNo,clsAllPerson.Name ) A Where (A.crdit <> A.debit )";

            string Query = @"
Select * from 
(
  SELECT clsPerson.Fam,
  (case  When (SUM(pay) - SUM(pay_h))>0 Then Sum(pay)-SUM(pay_h) ELSE 0 end)as debit,
  (case  When (SUM(pay) - SUM(pay_h)) < 0 Then SUM(pay_h) - SUM(pay) ELSE 0 end)as crdit,PlokNo,
  (Select Fa_Date From StaticDates where En_Date = cast(WDate as date))WDate,BascoolCode
  FROM BascolWeights 
  INNER JOIN clsPerson ON BascolWeights.PersonCode=clsPerson.code 
  WHERE pay_h != pay And dele = 0 " + Str + @"
  GROUP BY PlokNo,clsPerson.Fam ,WDate,BascoolCode 
  ) A Where (A.crdit <> A.debit )
  and ( select isnull(sum(pay) - Sum(pay_h),0) from BascolWeights where BascolWeights.PlokNo=A.PlokNo) <> 0";

            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            try
            {
                dbMain.setQuery(Query);
                return dbMain.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                dbMain.Dispose();
            }
        }

        public static DataTable GetDataManager(string pStr)
        {
            string Query = @" Select 
(select Name from clsallperson where Code=PersonCode) 'PersonName',
BascoolCode,BascoolID,
(select Fa_Date from StaticDates where En_Date=Cast(WDate as Date)) 'WDate',
WTime,
PlokNo,
pay,verify,
dele,
(Select Name From subdefine Where code=ProductCode) 'ProductName',
(select Name from BascolTruck where code=TruckCode) 'TruckName',
Weights,
FullW,Code,
BascoolID BascoolID1,
PrintNo,
hamrahno,
pay_h,
Duty,
Tax,
(Select top 1 EmptyWeight from BascolEmptyWeights Where BascoolID=WeightID) FirstWeight,
Weights - (Select top 1 EmptyWeight from BascolEmptyWeights Where BascoolID=WeightID) Khales,
--(Select title from organizationchart where Code=UserPostCode) 'PostName',
UserPostCode,TruckCode   
from BascolWeights Where 1=1 " + pStr + "  order by  WDate,WTime Desc ";
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            //JDataBase db = new JDataBase();
            try
            {
                dbMain.setQuery(Query);
                return dbMain.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                dbMain.Dispose();
            }
        }

        public static DataTable GetDataTop3(string pStr)
        {
            string Query = @" Select Top 3 Code,
BascoolCode,BascoolID,
(select Fa_Date from StaticDates where En_Date=Cast(WDate as Date)) 'WDate',
WTime,
PlokNo,
(Select Name From subdefine Where code=ProductCode) 'ProductName',
Weights,
(select Name from BascolTruck where code=TruckCode) 'TruckName',Pay_h    
from BascolWeights Where dele = 0 " + pStr + " order by WDate desc";
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            //JDataBase db = new JDataBase();
            try
            {
                dbMain.setQuery(Query);
                 return dbMain.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                dbMain.Dispose();
            }
        }

        public static DataTable GetDataMali(string pStr)
        {
            string Query = @" Select 
bascoolcode, 
(Select Name From clsAllPerson Where Code=PersonCode) Name,
Count(Code) Count,
SUM(printno) printno,
Round(sum(pay_h),0,0) pay_h,
Round(SUM(Pay),0,0) Pay,
Round(SUM(Duty),0,0) Duty,
Round(SUM(Tax),0,0) Tax,
Round(Round(SUM(Pay),0,0)- Round(SUM(Duty),0,0) - Round(SUM(Tax),0,0),0,0) Total 
from BascolWeights Where dele = 0 " + pStr + " Group by BascoolCode,PersonCode ";
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            try
            {
                dbMain.setQuery(Query);
                return dbMain.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                dbMain.Dispose();
                return null;
            }
            finally
            {
                dbMain.Dispose();
            }
        }

        public static DataTable GetTotalDataManager(string pStr)
        {
            string Query = @" Select 
sum(pay) pay,
sum(pay_h) pay_h,
Sum(Duty) Duty,
Sum(Tax) Tax from BascolWeights Where dele = 0 " + pStr;
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

        public static DataTable GetPlok()
        {
            string Query = @" Select *,(select Name from BascolTruck where code=TruckCode) 'TruckName'
 from BascolPlakTruck";
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

        public static int GetBascoolNumber()
        {
            string Query = @" Select Number from BascolNumber";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                DataTable dt = db.Query_DataTable();
                if ((dt != null) &&(dt.Rows.Count > 0))
                    return Convert.ToInt32(dt.Rows[0][0]);
                else
                    return -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return -1;
            }
            finally
            {
                db.Dispose();
            }
        }
        public static int GetBascoolType()
        {
            string Query = @" Select Type from BascolNumber";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                DataTable dt = db.Query_DataTable();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                else
                    return -1;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return -1;
            }
            finally
            {
                db.Dispose();
            }
        }
        public static bool SetBascoolNumber(int pNumber,int pType)
        {
            string Query = @" Update BascolNumber Set Number=" + pNumber + ",Type=" + pType;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_Execute() > 0;
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

        public static DataTable GetBlackList()
        {
            return GetBlackList("");
        }

        public static DataTable GetBlackList(string pPlokno)
        {
            JTransferData tmpJTransferData = new JTransferData();
            JDataBase dbMain = tmpJTransferData.CreateConMainServer(false);
            string Where = "";
            if (pPlokno != "")
                Where = " Where (select top 1 plokno from BascolWeights where bascoolid=bascoolblacklist.bascoolid)=N'" + pPlokno + "'";
            try
            {
                dbMain.setQuery(@" select 
bascoolid,
(select top 1 BascoolCode from BascolWeights where bascoolid=bascoolblacklist.bascoolid) BascoolCode,
(select top 1 plokno from BascolWeights where bascoolid=bascoolblacklist.bascoolid) plokno, 
(select top 1 (select Fa_Date from StaticDates where En_Date=cast(WDate as Date)) from BascolWeights where bascoolid=bascoolblacklist.bascoolid) WDate,
(select top 1 WTime from BascolWeights where bascoolid=bascoolblacklist.bascoolid) WTime,
(select top 1 name from clsPerson where Code=(select personcode from BascolWeights where bascoolid=bascoolblacklist.bascoolid)) name
from bascoolblacklist " + Where);
                //dbMain.CommandTimeout = 4;
                return dbMain.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                dbMain.Dispose();
            }
        }
    }
}
