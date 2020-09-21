using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares.ShareHolder
{
    public class JProperties : ClassLibrary.JSystem
    {

    }
    public class JPropertiesVar : JProperties
    {
        public int VPCode { get; set; }
        public int PCode { get; set; }
        public string Data { get; set; }

        public JPropertiesVar()
        {
        }

        public bool GetData()
        {
            return GetData(VPCode, PCode);
        }

        public bool GetData(int pVPCode, int pPCode)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesShares.VarPropertyPerson +
                    " WHERE VPCode=" + pVPCode.ToString() +
                    " AND PCode=" + pPCode.ToString());
                System.Data.DataTable _DT = db.Query_DataTable();
                if (_DT.Rows.Count > 0)
                {
                    PCode = pPCode;
                    VPCode = pVPCode;
                    Data = _DT.Rows[0]["Data"].ToString();
                    return true;
                }
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }

        public bool Delete()
        {
            return Delete(VPCode, PCode);
        }

        public bool Delete(int pVPCode, int pPCode)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("DELETE FROM " + JTableNamesShares.VarPropertyPerson +
                    " WHERE VPCode=" + pVPCode.ToString() +
                    " AND PCode=" + pPCode.ToString());
                int ret = db.Query_Execute();
                return true;
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }

        public bool Update()
        {
            return Update(VPCode, PCode, Data);
        }

        public bool Update(string pData)
        {
            return Update(VPCode, PCode, pData);
        }

        public bool Update(int pVPCode, int pPCode, string pData)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("UPDATE " + JTableNamesShares.VarPropertyPerson +
                    " SET VPCode=" + pVPCode.ToString() +
                    " , PCode=" + pPCode.ToString() +
                    " , DATA='" + pData +
                    "' WHERE VPCode=" + pVPCode.ToString() +
                    " AND PCode=" + pPCode.ToString());
                int ret = db.Query_Execute();
                return true;
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return false;

        }

        public bool Insert()
        {
            return Insert(VPCode, PCode, Data);
        }

        public bool Insert(string pData)
        {
            return Insert(VPCode, PCode, pData);
        }

        public bool Insert(int pVPCode, int pPCode, string pData)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                if (GetData(pVPCode, pPCode))
                {
                    return Update(pVPCode, pPCode, pData);
                }
                else
                {
                    db.setQuery("INSERT INTO " + JTableNamesShares.VarPropertyPerson +
                        " (VPCode,PCode,Data) VALUES(" + pVPCode.ToString() +
                        " ," + pPCode.ToString() +
                        " ," + pData + ")");
                    int ret = db.Query_Execute();
                    return true;
                }
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return false;

        }

        public static string GetSQL(string PPersonTableName)
        {
            string _SQL ="";
            string Virgul = "";
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesShares.VarProperty);
                System.Data.DataTable _DT = db.Query_DataTable();
                foreach (System.Data.DataRow _DR in _DT.Rows)
                {
                    _SQL += ",(select Data from General.VarPropertyPerson where PCode=" + PPersonTableName 
                        + ".Code AND VPCode=" + _DR["Code"].ToString() + " ) AS [" + _DR["Title"].ToString() + "]" + Virgul;
                }
                return _SQL;
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return "";            
        }

    }

    public class JPropertiesStatic : JProperties
    {
        public int PrsnCode { get; set; }
        public int PrptCode { get; set; }
        public int PrptTitleCode { get; set; }

        public bool GetData()
        {
            return GetData(PrsnCode, PrptTitleCode);
        }

        public bool GetData(int pPrsnCode, int pPrptTitleCode)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesShares.StaticPropertyPerson +
                    " WHERE PrsnCode=" + pPrsnCode.ToString() + " AND PrptCode IN (SELECT Code FROM " +
                        JTableNamesShares.Properties + " WHERE PrptCode=" + pPrptTitleCode.ToString() + ")");

                System.Data.DataTable _DT = db.Query_DataTable();
                if (_DT.Rows.Count > 0)
                {
                    JTable.SetToClassProperty(this, _DT.Rows[0]);
                    return true;
                }
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }

        public bool Delete()
        {
            return Delete(PrsnCode, PrptTitleCode);
        }

        public bool Delete(int pPrsnCode, int pPrptTitleCode)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("DELETE FROM " + JTableNamesShares.StaticPropertyPerson +
                    " WHERE PrsnCode=" + pPrsnCode.ToString() + " AND PrptCode IN (SELECT Code FROM " +
                        JTableNamesShares.Properties + " WHERE PrptCode=" + pPrptTitleCode.ToString() + ")");
                int ret = db.Query_Execute();
                return true;
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }

        public bool Insert()
        {
            return Insert(PrsnCode,  PrptCode, PrptTitleCode);
        }

        public bool Insert(int pPrsnCode,int pPrptCode, int pPrptTitleCode)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                if (pPrptCode > 0)
                {
                    Delete(PrsnCode, PrptTitleCode);
                    db.setQuery("INSERT INTO " + JTableNamesShares.StaticPropertyPerson +
                        " (PrsnCode, PrptCode) VALUES(" + pPrsnCode.ToString() +
                        " ," + pPrptCode.ToString() + ")");
                    int ret = db.Query_Execute();
                }
                return true;

            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return false;

        }

        public static string GetSQL(string PPersonTableName)
        {
            string _SQL = "";
            string Virgul = "";
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesShares.PropertyTitle);
                System.Data.DataTable _DT = db.Query_DataTable();
                foreach (System.Data.DataRow _DR in _DT.Rows)
                {

                    _SQL += ",(select P.Description from General.[PropertyTitle] PT inner join General.Properties"+
                        " P ON PT.Code = P.PrptCode inner join General.PersonProperty PP ON"+
                        " PP.PrptCode = P.Code Where PP.PrsnCode = "+PPersonTableName + 
                        ".Code AND PT.Code = " + _DR["Code"].ToString() + ")" +
                        "AS [" + _DR["DescriptionTitle"].ToString() + "]";
                }
                return _SQL;
            }
            catch
            {
            }
            finally
            {
                db.Dispose();
            }
            return "";


        }

    }
}
