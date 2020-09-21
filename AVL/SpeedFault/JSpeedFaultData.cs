using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.SpeedFault
{
    public class JSpeedFaultData:ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public DateTime Datetime { get; set; }
        public float LimitedSpeed { get; set; }
        public float speed { get; set; }

        public int Insert()
        {
            return Insert(true);
        }
        public int Insert(bool checkPermission, bool isWeb = false)
        {
            bool haspermission=true;
            if(checkPermission)
               haspermission= ClassLibrary.JPermission.CheckPermission("AVL.RegisterDevice.JRegisterDevice.Insert");
            if (!haspermission)
                return 0;
            JSpeedFaultDataTable AT = new JSpeedFaultDataTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();

            return Code;
        }
        /// <summary>
        ///اگر
        ///true
        ///شی سرعت غیر مجاز دارد و از سرعت یتعیین شده برای دستگاه بیشتر است.
        /// </summary>
        /// <param name="ol"></param>
        /// <param name="device"></param>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public static bool CheckSpeedFault(AVL.ObjectList.JObjectList ol,AVL.RegisterDevice.JRegisterDevice device, AVL.Coordinate.JCoordinate coordinate)
        {
            if (device.speed != 0 && coordinate.Speed > device.speed)
            {
                AVL.SpeedFault.JSpeedFaultData speed = new AVL.SpeedFault.JSpeedFaultData();
                speed.Datetime = coordinate.DeviceSendDateTime;
                speed.LimitedSpeed = device.speed;
                speed.speed = coordinate.Speed;
                speed.Insert(false, false);
                return true;
            }
            return false;
        }
    
    }
}
