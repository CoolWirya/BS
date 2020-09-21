using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Parking
{
    class JGateTable : JTable
    {
        public JGateTable()
            : base(JTableNamesParking.Gate)
        {

        }

        /// <summary>
        /// نام 
        /// </summary>
        public string Name;
        /// <summary>
        /// كد مجتمع
        /// </summary>
        public int Market;
        /// <summary>
        /// نام مجتمع
        /// </summary>
        public string MarketName;
        /// <summary>
        /// نوع گيت ورودي / خروجي /ورودي وخروجي
        /// </summary>
        public int TypeGate;
        /// <summary>
        ///نام دستگاه
        /// </summary>
        public string DeviceName;
        /// <summary>
        /// IP سیستم پارکینگ
        /// </summary>
        public string IpSystem;
        /// <summary>
        ///Ip  مركز
        /// </summary>
        public string IpCenter;
        /// <summary>
        ///Ip  كلاينت
        /// </summary>
        public string Ip;
        /// <summary>
        ///Ip  زير شبكه
        /// </summary>
        public string SubIp;
        /// <summary>
        ///Ip  دوربين
        /// </summary>
        public string IpCamera;
        /// <summary>
        ///پورت
        /// </summary>
        public int Port;
        /// <summary>
        ///وضعيت گيت
        /// </summary>
        public Boolean State;
       
    }
}
