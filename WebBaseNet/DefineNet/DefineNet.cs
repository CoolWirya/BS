using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace WebBaseNet.BaseNet
{
    public class JDefineNet
    {

        public int Code { get; set; }
        public String DefineName { get; set; }
        public int DefineType { get; set; }
        public int DefineValue { get; set; }
        public DateTime InsertDate { get; set; }
        public int GroupCode { get; set; }
        public int PlaceCode { get; set; }

        public JDefineNet()
        {
        }
        public JDefineNet(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert()
        {
            if (!JPermission.CheckPermission("WebBaseNet.BaseNet.JDefineNet.Insert"))
                return -1;
            JDefineNetTable AT = new JDefineNetTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("WebBaseNet.BaseNet.JDefineNet.Delete"))
                return false;
            JDefineNetTable AT = new JDefineNetTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                return true;
            }
            else return false;
        }
        public bool Update()
        {
            if (!JPermission.CheckPermission("WebBaseNet.BaseNet.JDefineNet.Update"))
                return false;
            JDefineNetTable AT = new JDefineNetTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                return true;
            }
            else
                return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTNetDefine where code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }


    }

    public class JBusNets : JSystem
    {

        public static DataTable GetDataTable(int pCode = 0)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select * from AUTNetDefine where 1=1 "
                + " AND " + JPermission.getObjectSql("BusManagment.Bus.JBuses.GetDataTable", "AUTBus.Code");
                if (pCode > 0)
                    query += " AND Code = " + pCode;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}
