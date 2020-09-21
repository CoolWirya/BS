using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace ManagementShares
{
    /// <summary>
    /// کلاس مربوط به سهم 
    /// </summary>
    public class JShare 
    {
        /// <summary>
        /// شماره سهم
        /// </summary>
        public int ShareNo { get; set; }
        /// <summary>
        /// کد سهامدار 
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// شماره برگه ای که سهم در آن قرار دارد
        /// </summary>
        public int SheetNo { get; set; }
        public JShare(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM " + ClassLibrary.JGlobal.MainFrame.GetConfig().DatabaseSaham+"." + ClassLibrary.JGlobal.MainFrame.GetConfig().SheetSahamTableName);
                DataTable table = db.Query_DataTable();
                if (table.Rows.Count > 0)
                {
                    DataRow row= table.Rows[0];
                    this.ShareNo = pCode;
                    this.PCode = Convert.ToInt32(row["PCode"]);
                    this.SheetNo = Convert.ToInt32(row["Code"]);
                 //   JTable.SetToClassProperty(this, table.Rows[0]);
                }
            }
            catch
            {
                
            }
        }
    }
    public class JShares
    {
        public static int MaxLength = 5;
    }
}
