using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;


namespace WebBaseNet.BusServiseGet 
{
    public class JBusServiseGet : JSystem  
    {

        public int Code { get; set; }
        //public DateTime Date { get; set; }
        // public int BusCode { get; set; }
        // public int BusFailureCode { get; set; }
        public int BusCode { get; set; }
        public int CodeSS { get; set; }
       // public bool IsActive { get; set; }
    
        public JBusServiseGet()
        {
        }
        public JBusServiseGet(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(JDataBase db = null)
        {
            BusServiceGetTable AT = new BusServiceGetTable();
            AT.SetValueProperty(this);
            if (db == null)
                Code = AT.Insert();
            else
                Code = AT.Insert(db);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("WebBaseNet.BusServiseGet", Code, 0, 0, 0, "ثبت مالک اتوبوس", "", 0);
            return Code;
        }

      

        public bool Delete()
        {
            ScheduleServiceTable AT = new ScheduleServiceTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("WebBaseNet.JScheduleService", AT.Code, 0, 0, 0, "حذف مالک اتوبوس", "", 0);
            return AT.Delete();
        }
        public bool Update()
        {
            ScheduleServiceTable AT = new ScheduleServiceTable();
            AT.SetValueProperty(this);
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("WebBaseNet.JScheduleService", AT.Code, 0, 0, 0, "ویرایش مالک اتوبوس", "", 0);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from scheduleservice where Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

    }

    public class JBusServiseGets
    {

        public static void DeleteByBusCode(int pCodeBN, JDataBase DB)
        {
            DB.setQuery(@" Delete from scheduleservice  WHERE CodeBN = " + pCodeBN.ToString());
            DB.Query_Execute();
        }

        public DataTable GetWebOwners(int pCodeBN)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT 
		                scheduleservice.code, TypeService.Date, scheduleservice.IsActive
		                ,(Select Fa_Date FROM StaticDates Where En_Date =  TypeService.StartTime) StartTime
		                ,(Select Fa_Date FROM StaticDates Where En_Date =  TypeService.EndTime) EndTime
		                FROM dbo.scheduleservice  
                        inner join dbo.BaseNet on scheduleservice.CodeBN=BaseNet.Code
                        inner join dbo.TypeService on scheduleservice.Code=TypeService.CodeSS
                        inner join dbo.BusSN on TypeService.CodeSS=BusSN.Code
                             WHERE TypeService.BusCode=" + pCodeBN.ToString());
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

        public static DataTable GetDataTable(int pCodeBN)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT 
		                scheduleservice.code, TypeService.Date, scheduleservice.IsActive
		                ,(Select Fa_Date FROM StaticDates Where En_Date =  TypeService.StartTime) StartTime
		                ,(Select Fa_Date FROM StaticDates Where En_Date =  TypeService.EndTime) EndTime
		                FROM dbo.scheduleservice  
                        inner join dbo.BaseNet on scheduleservice.CodeBN=BaseNet.Code
                        inner join dbo.TypeService on scheduleservice.Code=TypeService.CodeSS
                        inner join dbo.BusSN on TypeService.CodeSS=BusSN.Code

		                " +

                          " WHERE TypeService.BusCode=" + pCodeBN.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCodeBN"></param>
        /// <returns></returns>
        public static DataTable GetAllOwners()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT 
		                BaseNet.code,BaseNet.Name nameofservice,  ScheduleService.TypeService, ScheduleService.IsActive
		                ,(Select Fa_Date FROM StaticDates Where En_Date =  TypeService.StartTime) StartTime
		                ,(Select Fa_Date FROM StaticDates Where En_Date =  TypeService.EndTime) EndTime
		                FROM dbo.ScheduleService  
		                INNER JOIN dbo.BaseNet  ON BaseNet.Code = ScheduleService.CodeBN
		                INNER JOIN dbo.TypeService  ON TypeService.CodeSS = BaseNet.Code ");
                //  (pCodeBN > 0 ? @" WHERE AUTBusOwner.BusCode=" + pCodeBN.ToString() : ""));
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// دریافت تمامی مالکان اتوبوس ها
        /// </summary>
        /// <returns></returns>
        public static DataTable GetBusOwners()
        {

            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBusOwners.GetBusOwners", "cap.Code");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT cap.Code as Code,cap.Name,(cast(Code as varchar) + ' - '+cap.Name)OwnerWithCode FROM clsAllPerson cap WHERE cap.Code IN (
		                SELECT DISTINCT CodePerson FROM AUTBusOwner ao)
                        " + PermitionSql + @"
		                ORDER BY cap.Name");
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }


        /// <param name="pCodeBN"></param>
        /// <returns></returns>
        public static bool CheckHasOneActiveOwner(int pCodeBN)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT Code From AUTBusOwner  WHERE AUTBusOwner.BusCode=" + pCodeBN.ToString() + " AND ISActive = 1 ");
                return (DB.Query_DataTable().Rows.Count == 0);
            }
            finally
            {
                DB.Dispose();
            }
        }
        
    }
}
