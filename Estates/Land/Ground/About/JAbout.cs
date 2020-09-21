using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JAbout:JSystem
    {
        public bool Changed = false;
        #region Constructor
        public JAbout()
        {
        }
        public JAbout(int pCodeGround,JDataBase Db)
        {
            CodeGround = pCodeGround;
            this.GetData(pCodeGround,Db);
        }
        #endregion

        #region property
        /// <summary>
        /// کد حدود اربعه
        /// </summary>
        public int Code
        {
            get;
            set;
        }
        /// <summary>
        /// کدزمین مربوطه
        /// </summary>
        public int CodeGround
        {
            set;
            get;
        }
        /// <summary>
        /// شمال ها
        /// </summary>
        public string North
        {
            get;
            set;
        }
        /// <summary>
        /// جنوب ها
        /// </summary>
        public string South
        {
            get;
            set;
        }
        /// <summary>
        /// غرب ها
        /// </summary>
        public string West
        {
            get;
            set;
        }
        /// <summary>
        /// شرق ها
        /// </summary>
        public string East
        {
            get;
            set;
        }
        /// <summary>
        /// تاریخ ثبت حدود اربعه
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }
        #endregion
        #region method
        public bool Save(JDataBase pDB)
        {
            try
            {                
                    Date = DateTime.Now;
                    JAboutTable AT = new JAboutTable();
                    AT.SetValueProperty(this);

                    if (Code == 0 || JMessages.Question("آیا سابقه تغییرات حدود اربعه ذخیره گردد", "سابقه") == System.Windows.Forms.DialogResult.Yes)
                    {
                        Code = AT.Insert(pDB);
                        if (Code > 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return AT.Update(pDB);
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
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            JDataBase pDB = new JDataBase();
            try
            {                
                    pDB.Params.Clear();
                    pDB.setQuery("DELETE FROM " + JTableNamesEstate.AboutTable + " WHERE Code =" + pCode.ToString());
                    if (pDB.Query_Execute() >= 0)
                    {
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
                pDB.Dispose();
            }
        }
        /// <summary>
        /// اطلاعات مربوط به حدود اربعه یک زمین را بر میگرداند
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode,JDataBase TempDb)
        {
             JDataBase Db;
             if (TempDb == null)
                 Db = new JDataBase();
             else
                 Db = TempDb;
            try
            {
                string Query = "select * from " + JTableNamesEstate.AboutTable + " where CodeGround=" + pCode + " order by Date desc";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
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
                Db.Dispose();
            }
        }

        public static System.Data.DataTable GetDataTable(int pCode)
        {
            if (pCode == 0) return null;
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select Code,North,South,West,East,Date from " + 
                    JTableNamesEstate.AboutTable + " where CodeGround=" + pCode+ " order by Date desc";
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion


    }
}
