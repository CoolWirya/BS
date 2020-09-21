using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.AndroidBazarPurchaseJson
{
    public class JAndroidBazarPurchaseJson
    {
        public int deviceCode { get; set; }
        public int Code { get; set; }
        public string orderId { get; set; }
        public string packageName { get; set; }
        public string productId { get; set; }
        public string purchaseTime { get; set; }
        public string purchaseState { get; set; }
        public string developerPayload { get; set; }
        public string purchaseToken { get; set; }

        public JAndroidBazarPurchaseJson() { }
        public JAndroidBazarPurchaseJson(string code) {
            GetData("code='" + code + "'");
        }


        public int Insert()
        {
            JAndroidBazarPurchaseJsonTable j = new JAndroidBazarPurchaseJsonTable();
            j.SetValueProperty(this);
            return j.Insert();
        }

        public bool GetData(string where)
        {

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select * from AndroidBazarPurchaseTable where "+where);
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

    public class JAndroidBazarPurchaseJsonTable : ClassLibrary.JTable
    {
        public int deviceCode;
        public string orderId;
        public string packageName;
        public string productId;
        public string purchaseTime;
        public string purchaseState;
        public string developerPayload;
        public string purchaseToken;
        public JAndroidBazarPurchaseJsonTable()
            : base("AndroidBazarPurchaseTable")
        {

        }
    }
}
