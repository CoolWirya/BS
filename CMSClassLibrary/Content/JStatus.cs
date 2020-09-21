using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CMSClassLibrary.Content
{
    public class JStatus:JSystem
    {
        #region Property

        public int Code { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int Site { get; set; }

        #endregion Property

        public JStatus ()
        {
        }

        public JStatus(int pCode)
        {
            GetData(pCode);
        }

        public bool Find(int pCode)
        {
            JStatusTable CT = new JStatusTable();
            return CT.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JStatusTable CT = new JStatusTable();
            return CT.GetData(this, pCode);
        }

        public int Insert()
        {
            if (JPermission.CheckPermission("CMSClassLibrary.JStatus.Insert"))
            {
                JStatusTable JCT = new JStatusTable();
                JCT.SetValueProperty(this);
                int code = JCT.Insert();
                return code;
            }
            else
                return 0;
        }

        public bool Update()
        {
            JDataBase Db = new JDataBase();
            try
            {
                if (JPermission.CheckPermission("CMSClassLibrary.JStatus.Update"))
                {
                    JStatusTable CT = new JStatusTable();
                    CT.SetValueProperty(this);
                    bool updated = CT.Update();
                    return updated;
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
                Db.Dispose();
            }
        }

        public bool Delete()
        {
            JStatusTable CT = new JStatusTable();
            CT.SetValueProperty(this);
            return CT.Delete();
        }
    }

    public class JStatuses :JSystem
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JStatusTable JCT = new JStatusTable();
            return JCT.GetDataTable(pCode);
        }

        public static DataTable GetDataTable(string condition)
        {
            string Where = " where 1=1 ";
            Where = Where + " And " + condition;
            string Query = "select Code,Name,State,Site from "
                + JTableNamesCMS.CMSStatus + Where +
            " And " + JPermission.getObjectSql("CMSClassLibrary.JStatuses.GetDataTable", JTableNamesCMS.CMSStatus + ".Code");
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
