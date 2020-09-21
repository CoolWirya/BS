using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Purchase
{
    public class JPurchasePlan : ClassLibrary.JSystem
    {
        public int code { get; set; }
        public string planName { get; set; }
        public double price { get; set; }
        public int personCount { get; set; }
        public int geoCount { get; set; }
        public double monthlySubscription { get; set; }

        public JPurchasePlan(int plancoode)
        {
            GetData(" code=" + plancoode );
        }

        public bool GetData(string where)
        {

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from AVLPurchasePlan where " + where);
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
