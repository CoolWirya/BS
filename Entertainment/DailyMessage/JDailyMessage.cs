using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Entertainment
{
    public class JDailyMessage
    {
        #region Constructor
        public JDailyMessage()
        { 
        }
        public JDailyMessage(int Code)
        {
            GetData(Code);
        }
        #endregion

        #region Properties
        public int Code;
        public DateTime Date;
        public string Text;
        #endregion

        #region Method
        public int Insert()
        {
            try
            {
                JDailyMessageTable jDailyMessageTable = new JDailyMessageTable();
                jDailyMessageTable.Date = this.Date;
                jDailyMessageTable.Text = this.Text;
                return jDailyMessageTable.Insert();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
            return 0;
        }

        public bool Update()
        {
            try
            {
                JDailyMessageTable jDailyMessageTable = new JDailyMessageTable();
                jDailyMessageTable.Code = this.Code;
                jDailyMessageTable.Date = this.Date;
                jDailyMessageTable.Text = this.Text;
                return jDailyMessageTable.Update();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
            return false;
        }

        public bool Delete()
        {
            try
            {
                JDailyMessageTable jDailyMessageTable = new JDailyMessageTable();
                jDailyMessageTable.Code = this.Code;
                jDailyMessageTable.Date = this.Date;
                jDailyMessageTable.Text = this.Text;
                return jDailyMessageTable.Delete();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
            return false;
        }
        #endregion

        #region GetData
        public void GetData(int Code)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = "Select * From DailyMessage Where Code = '" + Code.ToString() + "'";

                db.setQuery(sql);
                db.Query_DataReader();
                if(db.DataReader.Read())
                JTable.SetToClassProperty(this, db.DataReader);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }

        }

        public DataTable GetRandomMessages(DateTime datetime)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = "Select * From entDailyMessage Where Date > '" + datetime.ToString("yyyy/MM/dd") + "' and SUBSTRING(Text,0,12)  != '[MONASEBAT]' order by NEWID()";
                db.setQuery(sql);
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

        public DataTable GetMonasebat(DateTime datetime)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = "Select * From entDailyMessage Where Date = '" + datetime.ToString("yyyy/MM/dd") + "' and SUBSTRING(Text,0,12)  = '[MONASEBAT]'";

                db.setQuery(sql);
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

        public DataTable GetTodayMessage()
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = "Select * From DailyMessage Where Date = '" + DateTime.Now.ToString("yyyy/MM/dd") + "'";

                db.setQuery(sql);
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
        #endregion
    }
}
