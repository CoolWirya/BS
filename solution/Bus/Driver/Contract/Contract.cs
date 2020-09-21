using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace BusManagment.Contract
{
    public class JContractDriver
    {
        public int Code { get; set; }
        /// <summary>
        /// Car Code
        /// </summary>
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Code_Driver  { get; set; }
        public int Code_Owner { get; set; }
        public int Insert()
        {
            JBusDeviseTable AT = new JBusDeviseTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            return Code;
        }
        public bool Delete()
        {
            JBusDeviseTable AT = new JBusDeviseTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }
        public bool Update()
        {
            JBusDeviseTable AT = new JBusDeviseTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTBusDevise where code=" + pCode.ToString());
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

        public bool GetDataBus(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTOwner where BusCode=" + pCode.ToString());
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

    public class JContractsDriver
    {
    }
}
