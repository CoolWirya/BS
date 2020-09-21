using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.RegisterDevice
{
    public class JRegisterDevice:ClassLibrary.JSystem
    {
		public JRegisterDevice()
		{			
		}
        public JRegisterDevice(int code)
        {
                this.GetData(code.ToString(), false);
        }
        public JRegisterDevice(string IMEI)
        {
            this.GetData(IMEI);
        }
        public JRegisterDevice(int code,bool IsObjectCode)
        {
            this.GetData(code.ToString(), IsObjectCode);
        }

        /// <summary>
        /// کد بازاریاب
        /// </summary>
        public int marketerCode { get; set; }
        //visibility to show own group members
        public bool visibility { get; set; }
        /// <summary>
        ///if true Just admin can see his/her group members. members cant see each other
        /// </summary>
        public bool justAdminSee { get; set; }
        
        public int Code { get; set; }
        public long IMEI { get; set; }
        /// <summary>
        /// It is related to Code of ObjectList table.
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// This property is related to Code field in DeviceModel table.
        /// </summary>
        public byte DeviceType { get; set; }//a enumeration :byte
        public byte SendType { get; set; }
        public string DataFormat { get; set; }
        public DateTime RegisterDateTime { get; set; }
        /// <summary>
        /// User code who registered device
        /// related to users table,code field
        /// </summary>
        public int personCode { get; set; }
        public float speed { get; set; }
        public string Factory { get; set; }
        public string Model { get; set; }
        public string OSVersion { get; set; }
        public string LastBattery { get; set; }
        public float LastLat { get; set; }
        public float LastLng { get; set; }
        public float lastAltitude { get; set; }
        public int lastAngle { get; set; }
        public DateTime lastSendDate { get; set; }
        public float lastSpeed { get; set; }
        public bool speedFault { get; set; }
        public bool geofenceFault { get; set; }
        public bool active { get; set; }
        public bool isPaid { get; set; }
        public int PurchasePlanCode { get; set; }

        public string keyPass { get; set; }
       
        public string Name { get; set; }

        public string Config { get; set; }
    /// <summary>
    /// وقتی یک فاکتور صادر می شود یک کد کالا هم دارد که بعد پرداخت فاکتور در 
    ///webavl/callback.aspx
    /// این متد صدا زده می شود تا عملیاتی برای بعد پرداخت انجام شود.
    /// </summary>
    /// <param name="parameter"></param>
        public void DoOperation(string parameter)
        {
            AVL.RegisterDevice.JRegisterDevice ol = new AVL.RegisterDevice.JRegisterDevice(int.Parse(parameter));
            ol.isPaid = true;
            ol.active = true;
            if (ol.Update(true, false))
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد.');", "ConfirmDialog");
         
        }

        public bool UpdateDetails(string IMEI,string Factory,string Model,string OsVersion)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(string.Format("UPDATE [AVLDevice] SET Factory={0},Model={1},OSVersion={2} WHERE [IMEI] = {3}",
                    Factory,
                    Model,
                    OsVersion,
                    IMEI));
                if (db.Query_Execute() >= 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public int Insert(decimal taxPercent,decimal DeviceRegisterPrice,bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDevice.JRegisterDevice.Insert"))
                return 0;
            this.active = false;
            JRegisterDeviceTable AT = new JRegisterDeviceTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();

            decimal Total = 0;
            //Insert factor
            Accounting.Factor.JFactor factor = new Accounting.Factor.JFactor();
            factor.RegisterDate = DateTime.Now;
            factor.userCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            factor.payState = false;
            //insert active factorItem
            Accounting.Factor.FactorItem.JFactorItem item = new Accounting.Factor.FactorItem.JFactorItem();
            item.count = 1;
            item.describe = "هزینه فعال کردن";
            item.product = 1;
            item.FactorCode = factor.Insert();
           Total= item.TotalUnitPrice = item.unitPrice = DeviceRegisterPrice;
            item.Insert();
            ////insert charge factorItem
            item.describe = "هزینه شارژ سی روز";
            AVL.Device.JDeviceModel m = new AVL.Device.JDeviceModel();
            m.GetData(this.DeviceType.ToString());
            item.unitPrice = (decimal)m.UnitPrice;
            item.count = 30;
            Total += item.TotalUnitPrice = 30 * item.unitPrice;
            item.Insert();
            factor.Tax = taxPercent * Total / 100;
            factor.Total =Total + factor.Tax;
            factor.Discount = 0;
            factor.Update();

            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("AVL.RegisterDevice.JRegisterDevice", Code, 0, 0, 0, "ثبت دستگاه", "", 0);
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JRegisterDevices.GetDataTable(true, "", Code));

            ClassLibrary.JException j = ClassLibrary.JCore.Except;
            //   foreach (Exception ex in ClassLibrary.JSystem.Except)
            //  {
            //       Exception e = ex;
            //   }

            return Code;
        }
        public int Insert(bool isWeb = false,bool checkPermission=true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission("AVL.RegisterDevice.JRegisterDevice.Insert");
            if (!hasPermission)
                return 0;
            JRegisterDeviceTable AT = new JRegisterDeviceTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            

            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("AVL.RegisterDevice.JRegisterDevice", Code, 0, 0, 0,"ثبت دستگاه", "", 0);

            try { if (Code > 0 && !isWeb && Nodes != null)
                    Nodes.DataTable.Merge(JRegisterDevices.GetDataTable(true, "", Code));
            }
            catch
            {

            }
         ClassLibrary.JException j=   ClassLibrary.JCore.Except;
           //   foreach (Exception ex in ClassLibrary.JSystem.Except)
          //  {
         //       Exception e = ex;
        //   }

            return Code;
		}


        public bool Delete(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDevice.JRegisterDevice.Delete"))
                return false;

            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DB.setQuery("delete from AVLCoordinate where DeviceCode=" + Code.ToString());
            DB.Query_Execute(true);

            JRegisterDeviceTable AT = new JRegisterDeviceTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("AVL.RegisterDevice.JRegisterDevice", AT.Code, 0, 0, 0, "حذف دستگاه", "", 0);
                return true;
            }
            else return false;
        }

        public bool Update()
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.RegisterDevice.JRegisterDevice.Update"))
                return false;
            JRegisterDeviceTable AT = new JRegisterDeviceTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                try
                {
                }
                catch (Exception e)
                {
                    ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                    jHistory.Save("AVL.RegisterDevice.JRegisterDevice", AT.Code, 0, 0, 0, "ویرایش دستگاه", "", 0);
                }
                return true;
            }
            else
                return false;
        }

        public bool Update(bool isWeb = false,bool checkPermission=false)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission("AVL.RegisterDevice.JRegisterDevice.Update");
            if (!hasPermission)
                return false;
            JRegisterDeviceTable AT = new JRegisterDeviceTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                try
                {
                }
                catch (Exception e)
                {
                    ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                    jHistory.Save("AVL.RegisterDevice.JRegisterDevice", AT.Code, 0, 0, 0, "ویرایش دستگاه", "", 0);
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// This method return data of item from database with specified code. it is not relevant to ObjectCode.
        /// </summary>
        /// <param name="pobjectCode"></param>
        /// <returns></returns>
        public bool GetData(string pCode,bool IsObjectCode=false)
        {
            if (IsObjectCode)
             return    PerformGetData("select top 1 * from AVLDevice where ObjectCode=" + pCode);
            else
               return  PerformGetData("select top 1 * from AVLDevice where Code=" + pCode);
        }
        public bool GetData(int userCode)
        {
                return PerformGetData("select top 1 * from AVLDevice where personCode=" + userCode);
        }
        public bool GetData(string IMEI)
        {
            return PerformGetData("select top 1 * from AVLDevice where IMEI=" + IMEI);
        }

        public bool PerformGetData(string query)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(query);
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
