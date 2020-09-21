using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSClassLibrary.Module
{
    public class JModule:JSystem
    {
        public JModule()
        { }

        public JModule (int Code)
        {
            GetData(Code);
        }

        #region Property

        public int Code { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string Parameters { get; set; }
        public int Site { get; set; }
        public string Position { get; set; }
        public int PosOrder { get; set; }
        public int ExtCode { get; set; }
        public bool Home { get; set; }

        #endregion Property

        #region serach methods

        public override string ToString()
        {
            return Name.ToString();
        }

        private bool Find(string name)
        {
            JDataBase tempDb = JGlobal.MainFrame.GetDBO();
            try
            {

                string query = @"select Name from CMSModules where (Name=" + JDataBase.Quote(name) + ")";
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
            JModuleTable CT = new JModuleTable();
            return CT.GetData(this, pCode);
        }


        #endregion serach methods

        public int Insert()
        {
            JDataBase tempDb = new JDataBase();


            try
            {
               // if (JPermission.CheckPermission("CMSClassLibrary.JModule.Insert"))
              //  {
                    if (Find(Name))
                    {
                        JMessages.Error("عنوان تکراری می باشد ", "خطا در درج اطلاعات.");
                        return 0;
                    }
                    JModuleTable JLT = new JModuleTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert();
                    if (Code > 0)
                    {
                        if (Nodes != null)
                            Nodes.DataTable.Merge(JModules.GetDataTable(Code));

                        return Code;
                    }
                    return 0;
               // }
              //  else
                    //return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
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
                if (JPermission.CheckPermission("CMSClassLibrary.JModule.Update"))
                {

                    JModuleTable CT = new JModuleTable();
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
            JModuleTable CT = new JModuleTable();
            CT.SetValueProperty(this);
            return CT.Delete();
        }

        
    }

    public class JModules : JSystem
    {
        public JModule[] Items = new JModule[0];
        public JModules()
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
            JModuleTable MT = new JModuleTable();
            return MT.GetDataTable(pCode);
        }

        public static DataTable GetDataTable(string condition)
        {
            string Where = " where 1=1 ";
                Where = Where + " And " + condition;
                string Query = "select Code,Name,State,Parameters,Site,Position,PosOrder,ExtCode,Home from " + JTableNamesCMS.CMSModules + Where;
               // " And " + JPermission.getObjectSql("CMSClassLibrary.JModules.GetDataTable", JTableNamesCMS.CMSModules + ".Code");
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
            Nodes.ObjectBase = new JAction("Module", "CMSClassLibrary.JModule.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "CMSClassLibrary.JModule.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;

            Nodes.AddToolbar(JTN);


        }

        #endregion Node
    }
}
