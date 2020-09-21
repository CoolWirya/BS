using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CMSClassLibrary.Extension
{
    public class JExtension:JSystem
    {
         public JExtension()
        { }

         public JExtension(int Code)
        {
            GetData(Code);
        }

        #region Property

        public int Code { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string Params { get; set; }
        public string Type { get; set; }
        public string ClassName { get; set; }

        #endregion Property

        #region serach methods

        public override string ToString()
        {
            return Name.ToString();
        }

        private bool Find(int pCode)
        {
            JExtensionTable ET = new JExtensionTable();
            return ET.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JExtensionTable ET = new JExtensionTable();
            return ET.GetData(this,pCode);
        }


        #endregion serach methods

         public bool Insert()
        {
            JDataBase tempDb = new JDataBase();

            try
            {
                    JExtensionTable JLT = new JExtensionTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert();
                    if (Code > 0)
                    {
                        if (Nodes != null)
                            Nodes.DataTable.Merge(JExtensions.GetDataTable(Code));

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
                
                    JExtensionTable CT = new JExtensionTable();
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
            JExtensionTable ET = new JExtensionTable();
            ET.SetValueProperty(this);
            return ET.Delete();
        }
      
    }

    public class JExtensions : JSystem
    {
        public JExtension[] Items = new JExtension[0];
        public JExtensions()
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
            JExtensionTable ET = new JExtensionTable();
            return ET.GetDataTable(pCode);
        }


        public static DataTable GetDataTable(string condition)
        {
            string Where = " where 1=1 ";
                Where = Where + " And " + condition;
                string Query = "select Code,Name,State,Params,Type,ClassName from " + JTableNamesCMS.CMSExtensions + Where +
                " And " + JPermission.getObjectSql("CMSClassLibrary.JExtensions.GetDataTable", JTableNamesCMS.CMSExtensions + ".Code");
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

