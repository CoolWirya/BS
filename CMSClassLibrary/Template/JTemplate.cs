using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CMSClassLibrary.Template
{
    public class JTemplate:JSystem
    {
         public JTemplate()
        { }

         public JTemplate(int Code)
        {
            GetData(Code);
        }

        #region Property

        public int Code { get; set; }
        public string Path { get; set; }
        public int ExtensionCode { get; set; }
        public bool IsDefault { get; set; }

        #endregion Property

        #region serach methods



        private bool Find(string path)
        {
            JDataBase tempDb = JGlobal.MainFrame.GetDBO();
            try
            {

                string query = @"select Name from CMSTemplateStyles where (Path=" + JDataBase.Quote(path) + ")";
                tempDb.setQuery(query);
                tempDb.Query_DataReader();
                if (tempDb.DataReader.Read())
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
                tempDb.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JTemplateTable CT = new JTemplateTable();
            return CT.GetData(this, pCode);
        }


        #endregion serach methods

        public bool Insert()
        {
            JDataBase tempDb = new JDataBase();


            try
            {
                    if (Find(Path))
                    {
                        JMessages.Error("عنوان تکراری می باشد ", "خطا در درج اطلاعات.");
                        return false;
                    }
                    JTemplateTable JLT = new JTemplateTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert();
                    if (Code > 0)
                    {
                        if (Nodes != null)
                            Nodes.DataTable.Merge(JTemplates.GetDataTable(Code));

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
                tempDb.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase Db = new JDataBase();
            try
            {
                    JTemplateTable CT = new JTemplateTable();
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
            JTemplateTable CT = new JTemplateTable();
            CT.SetValueProperty(this);
            return CT.Delete();
        }
    }
    public class JTemplates : JSystem
    {
        public JTemplate[] Items = new JTemplate[0];
        public JTemplates()
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
            JTemplateTable CT = new JTemplateTable();
            return CT.GetDataTable(pCode);
        }

        public static DataTable GetDataTable(string condition)
        {
            string Where = " where 1=1 ";
            Where = Where + " And " + condition;
            string Query = "select Code,Path,IsDefault,ExtensionCode from " + JTableNamesCMS.CMSTemplateStyles + Where;
              //  " And " + JPermission.getObjectSql("CMSClassLibrary.JTemplates.GetDataTable", JTableNamesCMS.CMSTemplateStyles + ".Code");
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
