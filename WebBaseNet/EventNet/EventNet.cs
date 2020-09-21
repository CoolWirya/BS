using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;


namespace WebBaseNet.EventNet
{
    public class JEventNet
    {
        public int Code { get; set; }
        public DateTime DateEvent { get; set; }
        public int DefineCode { get; set; }
        public string Descs { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BusCode { get; set; }
        public int PlaceCode { get; set; }

        public JEventNet()
        {
        }
        public JEventNet(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert(bool isWeb = false)
        {
            JEventNetTable AT = new JEventNetTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            JEventNetTable AT = new JEventNetTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete(bool isWeb = false)
        {
            JEventNetTable AT = new JEventNetTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }


        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTNetEvent where code=" + pCode.ToString());
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

    public class JEventNets : JSystem
    {

        public static string GetWebQuery()
        {
            return @"select * from AUTNetEvent";
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"select * from AUTNetEvent";
                if (pCode > 0)
                    query += " where Code = " + pCode;
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
