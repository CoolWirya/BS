using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Accounting
{
    //مروبوط به جدول پرداختی ها
    public class JAVLPaid : ClassLibrary.JSystem
    {
        public int code {get;set;}
        public int userCode { get; set; }
        public int State { get; set; }
        public decimal Price {get;set;}
       public DateTime registerDateTime {get;set;}
        public string invoiceNumber {get;set;}
        public string type {get;set;}
        public DateTime documentDateTime { get; set; }
        public string bankName {get;set;}
        public long OrderId { get; set; }
      public string RefId{get;set;}
    public string ResCode{get;set;}
     public string SaleOrderId{get;set;}
     public string SaleReferenceId { get; set; }
        public string branch {get;set;}


        public JAVLPaid()
        {

        }
        public JAVLPaid(int Code)
        {
            GetData(Code);
        }
        public JAVLPaid(int Code,int userCode)
        {
            GetData(Code, userCode);
        }

        /// <summary>
        /// Returns latest gateaway invoice inserted.
        /// </summary>
        /// <returns></returns>
        public static JAVLPaid GetLatestGateawayInvoice(int userCode)
        {
            JAVLPaid paid = new JAVLPaid();

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AVLPaid where invoiceNumber='g' AND State=0 AND type='G'  AND userCode=" + userCode + " AND documentDateTime BETWEEN '" + DateTime.Now.AddMinutes(-15)+ "' AND '" + DateTime.Now.ToString()  + "'");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(paid, DB.DataReader);
                   
                }
                return paid;
            }
            finally
            {
                DB.Dispose();
            }
        }
        public bool Update()
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Accounting.JAVLPaid.Update"))
                return false;
            JAVLPaidTable AT = new JAVLPaidTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                return true;
            }
            else
                return false;
        }
        public int Insert()
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Accounting.JAVLPaid.Insert"))
                return 0;
            JAVLPaidTable AT = new JAVLPaidTable();
            AT.SetValueProperty(this);
            code = AT.Insert();


            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("AVL.Accounting.JAVLPaid", code, 0, 0, 0, "ثبت فیش پرداختی", "", 0);
            return code;
        }
        public bool Delete(bool isWeb=false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Accounting.JAVLPaid.Delete"))
                return false;
            JAVLPaidTable AT = new JAVLPaidTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("AVL.Accounting.JAVLPaid", AT.Code, 0, 0, 0, "حذف فیش", "", 0);
                return true;
            }
            else return false;
        }

        public bool GetData(int Code)
        {
           return GetData(Code, -1);
        }
        public bool GetData(int Code,int userCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AVLPaid where code=" + Code+" AND userCode="+userCode);
                if (userCode == -1)
                    DB.setQuery("select top 1 * from AVLPaid where code=" + Code  );
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
