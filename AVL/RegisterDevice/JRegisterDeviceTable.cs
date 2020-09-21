using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.RegisterDevice
{
    public class JRegisterDeviceTable:ClassLibrary.JTable
    {
       // public int Code;
        public long IMEI;
        public int ObjectCode;
        /// <summary>
        /// This property is related to Code field in DeviceModel table.
        /// </summary>
        public byte DeviceType;//a enumeration :byte
        public byte SendType;
        public string DataFormat;
        public DateTime RegisterDateTime;
        public int personCode;
        public float speed;
        public string Factory;
        public string Model;
        public string OSVersion;
        public string Name;
        public string LastBattery;
        public float LastLat;
        public float LastLng ;
        public DateTime lastSendDate;
        public float lastAltitude ;
        public int lastAngle ;
        public float lastSpeed ;
        public bool speedFault ;
        public bool geofenceFault;
        public bool active;
        public bool isPaid;
        public string keyPass;
        public string Config;
        public int PurchasePlanCode;
        public bool visibility;
        public int marketerCode;
        public bool justAdminSee;
        public JRegisterDeviceTable()
            : base("AVLDevice")
        {
        }
    }
}
