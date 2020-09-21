using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CMSClassLibrary.Site
{
   public class JSite : JSystem
    {
        public JSite()
        { }

        public JSite (int Code)
        {
            GetData(Code);
        }

        #region Property

        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }

        #endregion Property

        #region serach methods

        

        private bool Find(string Domain)
        {
            JDataBase tempDb = JGlobal.MainFrame.GetDBO();
            try
            {

                string query = @"select Code from CMSSites where (Domain=" + JDataBase.Quote(Domain) + ")";
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
            JSiteTable CT = new JSiteTable();
            return CT.GetData(this, pCode);
        }


        #endregion serach methods

        public bool Insert()
        {
            JDataBase tempDb = new JDataBase();


            try
            {

                    JSiteTable JLT = new JSiteTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert();
                    if (Code > 0)
                    {
                        if (Nodes != null)
                            Nodes.DataTable.Merge(JSites.GetDataTable(Code));

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
                    
                    JSiteTable CT = new JSiteTable();
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
            JSiteTable CT = new JSiteTable();
            CT.SetValueProperty(this);
            return CT.Delete();
        }
    }

   public class JSites : JSystem
   {
       public JSite[] Items = new JSite[0];
       public JSites()
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
           JSiteTable JCT = new JSiteTable();
           return JCT.GetDataTable(pCode);
       }

      

       public static DataTable GetDataTable(string condition)
       {
           string Where = " where 1=1 ";
           Where = Where + " And " + condition;
           string Query = "select Code,Title,Domain,Description from " + JTableNamesCMS.CMSSites + Where;
          // " And " + JPermission.getObjectSql("CMSClassLibrary.JSites.GetDataTable", JTableNamesCMS.CMSSites + ".Code");
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

       #region Node
       public void ListView()
       {
           Nodes.ObjectBase = new JAction("Module", "CMSClassLibrary.JSites.GetNode");
           Nodes.DataTable = GetDataTable();
           JAction newAction = new JAction("New...", "CMSClassLibrary.JSites.ShowDialog", null, null);
           Nodes.GlobalMenuActions.Insert(newAction);
           JToolbarNode JTN = new JToolbarNode();
           JTN.Click = newAction;
           JTN.Icon = JImageIndex.Add;

           Nodes.AddToolbar(JTN);


       }

       #endregion Node
   }
}
