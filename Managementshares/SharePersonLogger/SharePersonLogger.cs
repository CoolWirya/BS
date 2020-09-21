using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public enum JPersonLoggerTypes
    {
        /// <summary>
        /// از ابتدا
        /// </summary>
        FromFirst = 7,
        /// <summary>
        /// ابطال با تقسیم
        /// </summary>
        DeleteByDivide = 3,
        /// <summary>
        /// ابطال با ادغام
        /// </summary>
        DeleteByJoin = 4,
        /// <summary>
        /// جدید با تقسیم
        /// </summary>
        NewByDivide = 5,
        /// <summary>
        /// جدید با ادغام
        /// </summary>
        NewByJoin = 6,
        /// <summary>
        ///جدید با خرید
        /// </summary>
        Buy = 1,
        /// <summary>
        ///ابطال با فروش
        /// </summary>
        Sell = 2,
        /// <summary>
        /// ابطال با افزایش سرمایه
        /// </summary>
        DeleteByIncrease = 8,
        /// <summary>
        /// ایجاد بعد از افزایش سرمایه
        /// </summary>
        NewByIncrease = 9,
        /// <summary>
        /// برگه فعال
        /// </summary>
        ActiveSheet = 10,

		ReturnTransferSheet = 11,
    }

    public class JSharePersonLogger : JManagementshares
    {
        #region Properties
        public int Code { get; set; }
        public DateTime TDate { get; set; }
        public int SCode { get; set; }
        //public string Title { get; set; }
        public int SheetType { get; set; }
        //public int SumSahm { get; set; }
        public int Az { get; set; }
        public int Ela { get; set; }
        public int PCode { get; set; }

		public int PCode2 { get; set; }
        //public int SumA { get; set; }
        public int InSum { get; set; }
        public int OutSum { get; set; }
        public decimal Cost { get; set; }
        public int OperationCode { get; set; }
        public bool Disabled { get; set; }

		public int Ordered { get; set; }

        #endregion Properties

        public JSharePersonLogger()
        {

        }

        public JSharePersonLogger(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public void GetData(int SCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" SELECT * From SharePersonLogger WHERE Code = " + SCode);
                DataTable sheet = db.Query_DataTable();
                if (sheet.Rows.Count > 0)
                    JTable.SetToClassProperty(this, sheet.Rows[0]);
            }
            finally
            {
                db.DisConnect();
            }
        }

        public JSharePersonLogger(int pSCode, JPersonLoggerTypes pSheetType, int pOperationCode, JDataBase DB)
        {
            try
            {
                DB.setQuery(string.Format("SELECT * FROM [SharePersonLogger] WHERE SCode = {0} AND SheetType = {1} AND OperationCode = {2} ", pSCode , pSheetType.GetHashCode(), pOperationCode));
                DataTable logs = DB.Query_DataTable();
                if (logs.Rows.Count == 1)
                {
                    JTable.SetToClassProperty(this, logs.Rows[0]);
                }
            }
            catch
            {

            }
        }

        public int Insert(JDataBase pDB)
        {
            JSharePersonLoggerTable logTable = new JSharePersonLoggerTable();
            try
            {
                logTable.SetValueProperty(this);
                Code = logTable.Insert(pDB);
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
		public bool Update()
		{
			JDataBase pDB = new JDataBase();
			try
			{
				return Update(pDB);
			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				pDB.Dispose();
			}
		}
		public bool Update(JDataBase pDB)
		{
			JSharePersonLoggerTable logTable = new JSharePersonLoggerTable();
			try
			{
				logTable.SetValueProperty(this);
				return logTable.Update(pDB);
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
        public bool Disable()
        {
            if (JPermission.CheckPermission("ManagementShares.JSharePersonLogger.Delete", true))
            {
                JSharePersonLoggerTable sheetTable = new JSharePersonLoggerTable();
                try
                {
                    sheetTable.SetValueProperty(this);
                    sheetTable.Disabled = true;
                    return sheetTable.Update();
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
            else
                return false;
        }
        public bool Delete(JDataBase pDB)
        {
            JDataBase db;
            if (pDB == null)
                db = new JDataBase();
            else db = pDB;
            JSharePersonLoggerTable logTable = new JSharePersonLoggerTable();
            try
            {
                logTable.SetValueProperty(this);
                return logTable.Delete(db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                if (pDB == null)
                    db.Dispose();
            }
        }

        private static  void SetRow(DataRow row,ref DataRow newRow,int operationType)
        {
            newRow["Code"] = row["Code"];
            newRow["SCode"] = row["SCode"];
            newRow["Az"] = row["Az"];
            newRow["Ela"] = row["Ela"];
            newRow["ShareCount"] = row["ShareCount"];
            newRow["SheetType"] = row["SheetType"];
            newRow["OperationCode"] = row["OperationCode"];
            newRow["Date"] = row["Date"];
            newRow["Title"] = row["Title"];

            newRow["PCode"] = row["PCode"];
            newRow["Name"] = row["Name"];
            newRow["SumA"] = row["SumA"];
            newRow["InSum"] = row["InSum"];
            newRow["OutSum"] = row["OutSum"];
        }

        public static  DataTable GetSheetLog(int pSCode)
        {
            try
            {
            DataTable table = JSharePersonLoggers.GetData(pSCode, 0);
            DataTable logTable = JSharePersonLoggers.GetData(0, 0);

            foreach (DataRow row in table.Rows)
            {
                int operationType = Convert.ToInt16(row["SheetType"]);
                /// خرید
                if (operationType == JPersonLoggerTypes.Buy.GetHashCode())
                {
                    DataRow newRow = logTable.NewRow();
                    SetRow(row, ref newRow, JPersonLoggerTypes.Buy.GetHashCode());
                    logTable.Rows.Add(newRow);
                    continue;
                }
                /// فروش 
                if (operationType == JPersonLoggerTypes.Sell.GetHashCode())
                {
                    continue;
                }
                /// جدید با تقسیم
                if (operationType == JPersonLoggerTypes.NewByDivide.GetHashCode())
                {
                    DataRow newRow = logTable.NewRow();
                    SetRow(row, ref newRow, JPersonLoggerTypes.NewByDivide.GetHashCode());
                    logTable.Rows.Add(newRow);
                    if (newRow["OperationCode"].ToString() != "")
                    {
                        JDivideSheet divide = new JDivideSheet(Convert.ToInt32(newRow["OperationCode"]));
                        logTable.Merge(GetSheetLog(divide.SCode));
                    }
                    continue;
                }
                else
                {
                    continue;
                }
            }
            return logTable;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
        }

        private void GetHistory(int pSCode)
        {

        }
    }
    public class JSharePersonLoggers : JManagementshares
    {
        public static DataTable GetData(int pSCode, int pCode)
        {
            string filter = "";
            if (pCode != 0)
              filter =  " WHERE logger.Code = " + pCode;
            else
                filter = " WHERE logger.SCode = " + pSCode;
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT 
            logger.Code, SCode, Az, Ela, (Ela - Az +1 )  ShareCount, logger.SheetType, OperationCode 
            , (SELECT Fa_Date FROM StaticDates WHERE En_Date = Convert(date, logger .TDate ))Date, ltype.Title,
            PCode,(Select Name From clsAllPerson where Code=PCode) Name,
                 (SELECT Name FROM clsAllPerson WHERE Code = PCode2) PersonName2
			,SumA,InSum,OutSum 
             FROM SharePersonLogger logger  Inner Join SharePersonLoggerType ltype ON logger.SheetType = ltype.Code 
           " + filter + " order by logger.Code  desc");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public void ShowPersonHistory(int pPCode, int companyCode)
        {
            JPersonHistoryForm form = new JPersonHistoryForm(pPCode, companyCode);
            form.ShowDialog();
        }
        public static DataTable GetPersonData(int pPCode, int companyCode)
        {
            string filter = "";
            if (pPCode != 0)
                filter = " WHERE (logger.Disabled IS NULL OR logger.Disabled = 0) AND  logger.PCode = " + pPCode + " AND logger.SCode IN (SELECT Code FROM ShareSheet WHERE CompanyCode = " + companyCode + ")";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@" SELECT 
                logger.Code, (SELECT Fa_Date FROM StaticDates WHERE En_Date = Convert(date, logger .TDate ))Date
                ,SCode,  ltype.Title, Az, Ela, InSum InSumShare, OutSum OutSumShare,  PCode
                ,(SELECT SharePCode FROM SharePCodeSheet WHERE PersonCode = logger.PCode and CompanyCode="+companyCode.ToString()
+@") SharePCode
                ,(SELECT Name FROM clsAllPerson WHERE Code = logger.PCode) PersonName
                ,(SELECT Name FROM clsAllPerson WHERE Code = logger.PCode2) PersonName2
				,logger.Ordered 
                 FROM SharePersonLogger logger  Inner Join SharePersonLoggerType ltype ON logger.SheetType = ltype.Code 
               " + filter + " order  by logger.Ordered , CONVERT(Date, TDate ), logger.Code ASC  ");
                //SumSahm Remain,
                DataTable result;
                DataColumn col = new DataColumn("Remain");
                //DataColumn colSum = new DataColumn("SumRemain");
                result = db.Query_DataTable();
                result.Columns.Add(col);
                //result.Columns.Add(colSum);
                decimal remain = 0;
                foreach (DataRow row in result.Rows)
                {
                    decimal inSum = Convert.ToDecimal(row["InSumShare"]);
                    decimal outSum = Convert.ToDecimal(row["OutSumShare"]);
                    remain = remain + inSum - outSum;
                    row["Remain"] = remain;
                }
                //if(result.Rows.Count>0)
                //    result.Rows[0]["SumRemain"] = remain;
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }

    }

}
