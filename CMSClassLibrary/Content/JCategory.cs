using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace CMSClassLibrary.Content
{
    public class JCategory:JSystem
    {
        public JCategory()
        { }

        public JCategory(int code)
        {
            GetData(code);
        }

        #region Property

        public int Code { get; set; }
        public int ParentCode { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool State { get; set; }
        public string Parameters { get; set; }
        public string Description { get; set; }
        public int Access { get; set; }
        public int Site { get; set; }

        #endregion Property

        #region serach methods

        private bool Find(int pCode)
        {
            JCategoryTable CT = new JCategoryTable();
            return CT.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JCategoryTable CT = new JCategoryTable();
            return CT.GetData(this, pCode);
        }

        #endregion serach methods

        public bool Insert()
        {
            JDataBase tempDb = new JDataBase();

            try
            {
               // if (JPermission.CheckPermission("CMSClassLibrary.JCategory.Insert"))
                //{
                    JCategoryTable JLT = new JCategoryTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert();
                
                    return Code > 0;
                //}
                //else
                  //  return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                tempDb.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase Db = new JDataBase();
            try
            {
               // if (JPermission.CheckPermission("CMSClassLibrary.JCategory.Update"))
                //{
                    JCategoryTable CT = new JCategoryTable();
                    CT.SetValueProperty(this);
                    bool updated = CT.Update();
                    return updated;
               // }
              //  else
                   // return false;
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

        public bool Delete()
        {
            JCategoryTable CT = new JCategoryTable();
            CT.SetValueProperty(this);
            return CT.Delete();
        }
       
    }

    public class JCategories:JSystem
    {
        public static DataTable GetDatatable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JCategoryTable CT = new JCategoryTable();
            return CT.GetDataTable(pCode);
        }

        public static DataTable GetDataTable(string condition)
        {
            string Where = " where 1=1 ";
            Where = Where + " And " + condition;
            string Query = "select Code,ParentCode,State,Name,Title,Parameters,Description,Access,Site from " + JTableNamesCMS.CMSCategories + Where +
            " And " + JPermission.getObjectSql("CMSClassLibrary.JCategories.GetDataTable", JTableNamesCMS.CMSCategories + ".Code");
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
    }
}
