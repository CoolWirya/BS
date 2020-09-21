using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace CMSClassLibrary.Content
{
    public class JContent:JSystem
    {
        #region Property

        public int Code { get; set; }
        public int CategoryCode { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
        public bool State { get; set; }
        public int Status { get; set; }
        public int Access { get; set; }
        public int Site { get; set; }

        #endregion Property

        public JContent ()
        {
        }

        public JContent(int pCode)
        {
            GetData(pCode);
        }

        public bool Find(int pCode)
        {
            JContentTable CT = new JContentTable();
            return CT.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JContentTable CT = new JContentTable();
            return CT.GetData(this, pCode);
        }

        public bool Insert()
        {
            
                JContentTable JCT = new JContentTable();
                JCT.SetValueProperty(this);
                int code = JCT.Insert();
                if (code > 0)
                    return true;
                else
                    return false;
           
        }

        public bool Update()
        {
            JDataBase Db = new JDataBase();
            try
            {
                //if (JPermission.CheckPermission("CMSClassLibrary.JContent.Update"))
                //{
                    JContentTable CT = new JContentTable();
                    CT.SetValueProperty(this);
                    bool updated = CT.Update();
                    return updated;
                //}
                //else
                //    return false;
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
            JContentTable CT = new JContentTable();
            CT.SetValueProperty(this);
            return CT.Delete();
        }

    }

    public class JContents:JSystem
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JContentTable JCT = new JContentTable();
            return JCT.GetDataTable(pCode);
        }

        public static DataTable GetDataTable(string condition)
        {
            string Where = " where 1=1 ";
            Where = Where + " And " + condition;
            string Query = "select Code,CategoryCode,Title,Text,Created,CreatedBy,Modified,ModifiedBy,State,Status,Access,Site from " 
                + JTableNamesCMS.CMSContents + Where +
            " And " + JPermission.getObjectSql("CMSClassLibrary.JContents.GetDataTable", JTableNamesCMS.CMSContents + ".Code");
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
