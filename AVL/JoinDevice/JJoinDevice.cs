using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.JoinDevice
{
    public class JJoinDevice : ClassLibrary.JSystem
    {
        public int code { get; set; }
        public int parentDeviceCode { get; set; }
        public int childDeviceCode { get; set; }
        public DateTime registerDate { get; set; }
        public int Insert()
        {
            JJoinDeviceTable AT = new JJoinDeviceTable();
            AT.SetValueProperty(this);
            code = AT.Insert();
            return code;
        }
        public bool Delete()
        {
            JJoinDeviceTable AT = new JJoinDeviceTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(string whereClause)
        {

            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT top 1 * FROM [AVLJoinDevice] WHERE " + whereClause);
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
        static Random rnd = new Random();
        public static string GenerateJoinKey(string imei)
        {
            AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(imei);
            //AVL.Purchase.JPurchasePlan plan = new AVL.Purchase.JPurchasePlan(d.PurchasePlanCode.ToString());
            //DataTable childs = AVL.JoinDevice.JJoinDevices.GetData(0,d.Code);
            //if (childs.Rows.Count >= plan.personCount)
            //    return "-1," + childs.Rows.Count;
            Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, d.personCode);
            if (cash.paid <= 0)
                return "-1,";
            AVL.AndroidKeys.JAndroidKey k = new AVL.AndroidKeys.JAndroidKey();
            k.ExpireDate = DateTime.Now.AddMinutes(15);
            k.IMEI = imei;
            k.RegKey = rnd.Next(100000, 999999).ToString();
            if (k.Insert() > 0)
            {
                //add device itself to its own group
                //AVL.JoinDevice.JJoinDevice jd = new AVL.JoinDevice.JJoinDevice();
                //AVL.RegisterDevice.JRegisterDevice d = new AVL.RegisterDevice.JRegisterDevice(imei);
                //if (!jd.GetData(" parentDeviceCode= " + d.Code))//check if group made before
                //{
                //    jd.registerDate = DateTime.Now;
                //    jd.parentDeviceCode = jd.childDeviceCode = d.Code;
                //    jd.Insert();
                //}
                return k.RegKey;
            }
            return "0";
        }
    }

    public class JJoinDevices : ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetData(int chidDevice=0,int parentDevice=0)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                //both
                string query = "";// string.Format(@"SELECT *  FROM AVLJoinDevice where [childDeviceCode]={0} and parentDeviceCode={1}", chidDevice,parentDevice);
                if (parentDevice == 0 && chidDevice>0)//just child device code
                    query =string.Format(@"SELECT *  FROM AVLJoinDevice where [childDeviceCode]={0}", chidDevice);
                if(parentDevice>0 && chidDevice==0)//just parent device code
                    query = string.Format(@"SELECT *  FROM AVLJoinDevice where [parentDeviceCode]={0}", parentDevice);
           //     if (parentDevice == 0 && chidDevice == 0) //none
             //       query = "SELECT *  FROM AVLJoinDevice ";
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// گرفتن تمام اطلاعات که چه دستگاه زیرمجموعه یا سرگروه باشد
        /// </summary>
        /// <param name="devieCode"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetAllData(int deviceCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                //both
                string query = "";
                if (deviceCode != 0)
                    query = string.Format(@"SELECT *  FROM AVLJoinDevice where [childDeviceCode]={0} or [parentDeviceCode]={0}", deviceCode);
                else
                    return null;
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }

    public class JJoinDeviceTable : ClassLibrary.JTable
    {
        public JJoinDeviceTable() : base("AVLJoinDevice")
        {
        }
        public int parentDeviceCode;
        public int childDeviceCode;
        public DateTime registerDate;
    }
}
