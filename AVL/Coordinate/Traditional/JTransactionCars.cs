using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Coordinate.Traditional
{
    public class JTransactionCars
    {
        public string CarID { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool GetData(string pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from avlsite_com_1.dbo.TransactionCars where CarID=" + pCode);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
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
}
