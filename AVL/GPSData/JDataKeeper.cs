using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.GPSData
{
    //این کلاس مربوط به جدول 
    // AVLDataKeeper 
    //است که نام جدول هایی که دیتا در آن به صورت بایت ذخیره می شود را دارا است.
    //سرویس نام جدول هایی که در آن بایت ذخیره می شود را گرفته و برای هر کدام
    //یک ترید را اجرا می کند تا اکسترکت شود.
    public class JDataKeeper : ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public string TableName { get; set; }
        public string ExtractorMethod { get; set; }
        public string Description { get; set; }

        public int DeviceModelCode { get; set; }

        public JDataKeeper()
        {

        }

        public JDataKeeper(int DeviceModelCode)
        {
            GetData(0, "", "", DeviceModelCode);
        }
        public JDataKeeper(System.Data.DataRow data)
        {
            ClassLibrary.JTable.SetToClassProperty(this, data);
        }


        public bool GetData(int Code = 0, string MethodName = "",string TableName="", int DeviceModelCode = 0)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                string query = "SELECT * FROM [AVLDataKeeper] WHERE 1=1 ";
                if (Code != 0)
                    query += " AND Code=" + Code;
                if (!string.IsNullOrEmpty(MethodName))
                    query += " AND ExtractorMethod=" + MethodName;
                if (!string.IsNullOrEmpty(TableName))
                    query += " AND TableName=" + TableName;
                if (DeviceModelCode != 0)
                    query += " AND DeviceModelCode=" + DeviceModelCode;


                db.setQuery(query);
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
