using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace CMSClassLibrary.Extension
{
    public class JSiteTemplate : JSystem
    {
        #region Property

        public int SiteCode { get; set; }
        public int StyleCode { get; set; }
        public int Code { get; set; }


        #endregion

        public JSiteTemplate()
        { }

        public JSiteTemplate(int Code)
        {
            GetData(Code);
        }

        #region serach methods


        private bool Find(int pCode)
        {
            SiteTemplatesTable ET = new SiteTemplatesTable();
            return ET.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            SiteTemplatesTable ET = new SiteTemplatesTable();
            return ET.GetData(this, pCode);
        }


        #endregion serach methods

        public bool Insert()
        {
            JDataBase tempDb = new JDataBase();

            try
            {
                SiteTemplatesTable JLT = new SiteTemplatesTable();
                JLT.SetValueProperty(this);
                Code = JLT.Insert();
                if (Code > 0)
                    return true;
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
                tempDb.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase Db = new JDataBase();
            try
            {
                SiteTemplatesTable CT = new SiteTemplatesTable();
                CT.SetValueProperty(this);
                bool updated = CT.Update();
                return updated;
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
            SiteTemplatesTable ET = new SiteTemplatesTable();
            ET.SetValueProperty(this);
            return ET.Delete();
        }
    }

    public class JSiteTemplates : JSystem
    {
        public JSiteTemplate[] Items = new JSiteTemplate[0];
        public JSiteTemplates()
        {
           // GetData();
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            SiteTemplatesTable ET = new SiteTemplatesTable();
            return ET.GetDataTable(pCode);
        }


        public static DataTable GetDataTable(string condition)
        {
            string Where = " where 1=1 ";
                Where = Where + " And " + condition;
                string Query = "select Code,SiteCode,StyleCode from " + JTableNamesCMS.CMSSiteTemplates + Where ;
               // " And " + JPermission.getObjectSql("CMSClassLibrary.JSiteTemplates.GetDataTable", JTableNamesCMS.CMSSiteTemplates + ".Code");
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
        #endregion GetData
    }
}
