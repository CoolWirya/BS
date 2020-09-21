using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Estates
{
    /// <summary>
    /// مالکین اولیه پیشفرض
    /// </summary>
    public class JDefaultOwner :JSystem
    {

        #region Properties
                
        public int Code { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// سهم
        /// </summary>
        public decimal Share { get; set; }

        #endregion

        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM estDefaultOwners WHERE Type=1 AND Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        public void ShowForm()
        {
        }

        public void ShowDialog()
        {
            JDefaultOwnersForm form = new JDefaultOwnersForm();
            form.ShowDialog();
        }

        /// <summary>
        /// ذخیره تمام اطلاعات جدول در دیتابیس
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            JDataBase DB=JGlobal.MainFrame.GetDBO();
            try
            {
                foreach (DataRow row in DefaultOwners.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        JTable.SetToClassProperty(this, row);
                        this.Insert(DB);
                    }
                    if (row.RowState == DataRowState.Deleted)
                    {
                        row.RejectChanges();
                        JTable.SetToClassProperty(this, row);
                        this.Delete(DB);
                        row.Delete();
                    }
                    if (row.RowState == DataRowState.Modified)
                    {
                        JTable.SetToClassProperty(this, row);
                        this.Update(DB);
                    }
                }

                return true;
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

        public int Insert(JDataBase pDB)
        {
            if (JPermission.CheckPermission("RealEstate.JDefaultOwner.Insert"))
            {
                JDefaultOwnersTable table = new JDefaultOwnersTable();
                table.SetValueProperty(this);
                int Code = table.Insert(pDB);
                if (Code > 0) Histroy.Save(this, table, table.Code, "Insert");
                return Code;
            }
            else
                return 0;
        }


        /// <summary>
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        //public static DataTable GetAllData(int pCode)
        //{
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    try
        //    {
                //DB.setQuery("SELECT A.Code, A.PCode ,P.Code PersonCode,Name,A.Share FROM " + JRETableNames.DefaultOwners + " A inner join clsAllPerson P on A.PersonCode = P.Code WHERE  Code=" + pCode.ToString());
        //        return DB.Query_DataTable();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Except.AddException(ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}

      
        /// <summary>
        /// حذف
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool Delete(JDataBase pDB)
        {
            JDefaultOwnersTable PDT = new JDefaultOwnersTable();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JDefaultOwner.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(pDB))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            return false;
        }

        public bool Update(JDataBase pDB)
        {
            JDefaultOwnersTable PDT = new JDefaultOwnersTable();
            try
            {
                if (JPermission.CheckPermission("RealEstate.JDefaultOwner.Update"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(pDB))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            return false;
        }

        /// <summary>
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        //public bool Update(DataTable tmpdt)
        //{
        //    JDefaultOwnersTable PDT = new JDefaultOwnersTable();
        //    try
        //    {
        //        if (tmpdt != null)
        //            foreach (DataRow dr in tmpdt.Rows)
        //            {                        
        //                if (dr.RowState == DataRowState.Deleted)
        //                {
        //                    dr.RejectChanges();
        //                    Code = (int)dr["Code"];
        //                    GetData(Code);
        //                    delete(Code);
        //                    dr.Delete();
        //                }
        //            }
        //        tmpdt.AcceptChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Except.AddException(ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        PDT.Dispose();
        //    }
        //}

        public DataTable DefaultOwners
        {
            get;
            set;
        }

        public static string Query = " SELECT  estDefaultOwners.*, clsAllPerson.Name  FROM  " +
            "estDefaultOwners inner join clsAllPerson  on clsAllPerson.Code = " +
            "estDefaultOwners.PCode ";

        public static DataTable GetDataTable()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(Query + " Where estDefaultOwners.Type=1 AND" +
                    JPermission.getObjectSql("RealEstate.JDefaultOwner.JDefaultOwner", "estDefaultOwners.Code"));
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

        public JDefaultOwner()
        {
            DefaultOwners = GetDataTable();
        }

        public bool FindDefaulOwner(int pCode)
        {
            if (DefaultOwners.Select("Type=1 AND PCode = " + pCode.ToString()).Length > 0)
            {
                return true;
            }
            else
                return false;
        }
    }

    public class JDefaultOwners : JSystem
    {
        public static List<JDefaultOwner> GetDefaultOwners()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            List<JDefaultOwner> result = new List<JDefaultOwner>();
            try
            {
                db.setQuery(JDefaultOwner.Query);
                DataTable owners = db.Query_DataTable();
                foreach (DataRow row in owners.Rows)
                {
                    JDefaultOwner tempOwner = new JDefaultOwner();
                    JTable.SetToClassProperty(tempOwner, row);
                    result.Add(tempOwner);
                }
                return result;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
