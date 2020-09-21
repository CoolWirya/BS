using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace ManagementShares
{
    /// <summary>
    /// کلاس برگه سهم
    /// </summary>
    public class JSheet : JSystem
    {
   

        #region Properties
        /// <summary>
        /// حداکثر طول فیلد برگه سهم
        /// </summary>
        public static int MaxLength = 5;
        /// <summary>
        /// شماره برگه سهم
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد سهامداری
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// غیر فعال 
        /// </summary>
        public int DeActive { get; set; }
        /// <summary>
        /// از
        /// </summary>
        public int Az { get; set; }
        /// <summary>
        /// الی
        /// </summary>
        public int Ela { get; set; }
        #endregion

        public JSheet()
        {

        }
        public JSheet(int pCode)
        {
            GetData(pCode);
        }
        public override string ToString()
        {
            return Code.ToString() + " ( " + Az.ToString() + " - " + Ela.ToString() + " )";
        }

        #region Search
        /// <summary>
        /// جستجو بر اساس شماره برگه
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public int GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetSharesDB();
            try
            {
                DB.setQuery(Query+ " AND Sheet.Code=" + pCode.ToString());
                //"SELECT Code,PCode PersonCode,DeActive,Az,Ela FROM " + JGlobal.MainFrame.GetConfig().SheetSahamTableName +
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    if (Convert.ToInt32(DB.DataReader["DeActive"]) == 0)
                    {
                        this.PCode = Convert.ToInt32(DB.DataReader["PCode"]);
                        this.DeActive = Convert.ToInt32(DB.DataReader["DeActive"]);
                        this.Az = Convert.ToInt32(DB.DataReader["Az"]);
                        this.Ela = Convert.ToInt32(DB.DataReader["Ela"]);
                        this.Code = Convert.ToInt32(DB.DataReader["Code"]);
                        //JTable.SetToClassProperty(this, DB.DataReader);
                        return pCode;
                    }
                    else
                    {
                        /// DeActive Sheet
                        this.PCode = Convert.ToInt32(DB.DataReader["PCode"]);
                        this.DeActive = Convert.ToInt32(DB.DataReader["DeActive"]);
                        this.Az = Convert.ToInt32(DB.DataReader["Az"]);
                        this.Ela = Convert.ToInt32(DB.DataReader["Ela"]);
                        this.Code = Convert.ToInt32(DB.DataReader["Code"]);
                        //JTable.SetToClassProperty(this, DB.DataReader);
                        return -1;
                    }
                }
                else
                {
                    /// No Sheet
                    return 0;
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// بررسی وجود شماره سهم در یک برگه خاص
        /// </summary>
        /// <param name="SheetNo"></param>
        /// <param name="ShareNo"></param>
        /// <returns></returns>
        public static bool FindShare(int pSheetNo, int pShareNo)
        {
            JDataBase DB = JGlobal.MainFrame.GetSharesDB();
//            JDataBase DB = new JDataBase(JManagementshares.DBConfig());
            try
            {
                DB.setQuery(Query+
                    " AND  Code=" + pSheetNo.ToString() + " AND (Az<=" + pShareNo.ToString() + " AND Ela>=" + pShareNo.ToString() + ")");
                //  "SELECT Code FROM " + JGlobal.MainFrame.GetConfig().SheetSahamTableName + " WHERE DeActive = 0
                if (DB.Query_DataTable().Rows.Count > 0)
                {
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
                DB.Dispose();
            }
        }

        public DataTable TransferDetails(int pSheetNo)
        {
            JDataBase DB = JGlobal.MainFrame.GetSharesDB();
            try
            {
                string taransferSheet = JGlobal.MainFrame.GetConfig().DatabaseSaham+
                    "."+JGlobal.MainFrame.GetConfig().SheetSahamTableName.Split('.')[0]+
                    "."+"TransferSheet";
                string totalTransfer = JGlobal.MainFrame.GetConfig().DatabaseSaham+
                    "."+JGlobal.MainFrame.GetConfig().SheetSahamTableName.Split('.')[0]+
                    "."+"TotalTransfer";
                DB.setQuery(@" Select   TDate TransferDate, OP1.Code T1PCode ,  OP1.Name+ ' - ' + OP1.Fam T1Transfer,  
	                OP2.Code T2PCode ,  OP2.Name+ ' - ' + OP2.Fam T2Transfer,
                    Price TransferCost FROM " + taransferSheet + " INNER JOIN " + totalTransfer +
                    " ON " + taransferSheet + ".TCode = " + totalTransfer + ".Code "+
                    " inner join " + JGlobal.MainFrame.GetConfig().PersonSahamTableName + " OP1 on " + totalTransfer + ".FPCode = OP1.Code " +
                    " inner join " + JGlobal.MainFrame.GetConfig().PersonSahamTableName + " OP2 on " + totalTransfer + ".SPCode  = OP2.Code " +
                    " WHERE SCode = " + pSheetNo.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }
        public static string SheetTable;
        public static string PersonTable = ClassLibrary.JGlobal.MainFrame.GetConfig().DatabaseSaham + "." + ClassLibrary.JGlobal.MainFrame.GetConfig().PersonSahamTableName;

        public static string Query;// + ClassLibrary.JGlobal.MainFrame.GetConfig().DatabaseSaham + "." + ClassLibrary.JGlobal.MainFrame.GetConfig().SheetSahamTableName;
       
        #endregion
    }

    public class JSheets : JSystem
    {
       // public JSheet[] Items = new JSheet[0];
        public String OrderName;
        public JSheets()
        {
            OrderName = "Az";
        }

        public DataTable GetLists()
        {
            return GetLists(0,0, true , 0 ,0);
        }

        public DataTable GetLists(int pCode, int pPCode, bool pShowDeactive, int pFromSheet, int pToSheet)
        {
            string Where = "";
            if (pCode != 0)
                Where = Where + " AND Sheet.Code= " + pCode.ToString();
            if (pPCode != 0)
                Where = Where + " AND PCode = " + pPCode.ToString();
            if (!pShowDeactive)
                Where = Where + " AND DeActive = 0 ";
            if (pFromSheet != 0)
                Where = Where + " AND Sheet.Code>=  " + pFromSheet.ToString();
            if (pToSheet != 0)
                Where = Where + " AND Sheet.Code<= " + pToSheet.ToString();

            JDataBase DB = JGlobal.MainFrame.GetSharesDB();
            try
            {
//                JSheet.ChangeSheet(pCode);
                DB.setQuery(JSheet.Query + Where + " ORDER BY " + OrderName);
                DataTable table= DB.Query_DataTable();
                return table;
                //int Count = 0;
                //foreach (DataRow row in table.Rows)
                //{
                //    Array.Resize(ref Items, Count + 1);
                //    Items[Count] = new JSheet();
                //    JTable.SetToClassProperty(Items[Count], row);
                //    Count++;
                //}
            }
            finally
            {
                DB.Dispose();
            }
        }
   }
}