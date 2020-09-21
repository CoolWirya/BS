using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JConfigHardwareTable : JTable
    {
        public JConfigHardwareTable()
            : base(JTableNamesParking.ParkingSetting)
        {

        }

        /// <summary>
        /// مجتمع / بازار
        /// </summary>
        public int complex=0;
        /// <summary>
        /// نوع دستگاه
        /// </summary>
        public int TypeDevice=0;
        /// <summary>
        /// مدل
        /// </summary>
        public int ModelDevice=0; 
        /// <summary>
        /// پروتکل ارتباطی
        /// </summary>
        public int CommunicationProtocol=0;
        /// <summary>
        /// شماره پورت
        /// </summary>
        public int NoProtocol=0;
        /// <summary>
        /// نوع DVR
        /// </summary>
        public int TypeDvr=0;
        /// <summary>
        /// مسیر ذخیره سازی عکس
        /// </summary>
        public string AddressSavePic="c:\\";

    }
}
