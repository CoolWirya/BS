using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.ObjectList
{
    public class JObjectListTable:ClassLibrary.JTable
    {
        public string ClassName ;
        public int ObjectCode ;
        public int DynamicObjectCode ;
		public DateTime RegisterDateTime;
		public string Label;
        public string Type;
        //فعال یا غیر فعال
        public bool isActive;
        //پرداختی
        public decimal paid;
        //کارکرد
        public decimal cost;
        public int personCode;
        //public DateTime lastSendDate;
        //public float LastLat;
        //public float LastLng;
        //public float lastSpeed;
        //public float lastAltitude;
        //public int lastAngle ;
        //public bool speedFault;
        //public bool geofenceFault;


        public JObjectListTable()
            : base("AVLObjectList")
        {
        }

    }
}
