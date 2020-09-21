using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{

    public class JEmployeeInfoTable : JTable
    {
        public JEmployeeInfoTable()
            : base("EmpEmployee")
        {
        }

        #region Property

        /// <summary>
        /// کد شخص 
        /// </summary>
        public int pCode;
        /// <summary>
        /// کد عنوان شغلی
        /// </summary>
        public int JobTitleCode;
        /// <summary>
        /// کد عنوان پست
        /// </summary>
        public int PostTitleCode;
        /// <summary>
        /// شماره پرسنلی 
        /// </summary>
        public int PersonNumber;
        /// <summary>
        /// شماره کارت 
        /// </summary>
        public int PersonCart;
       /// <summary>
        /// فعال 
        /// </summary>
        public bool Active;
        /// <summary>
        /// فعالیت کد
        /// </summary>
        public int Activity;
        /// <summary>
        /// بخش
        /// </summary>
        public int Sector;
        /// <summary>
        /// مدرک
        /// </summary>
        public int id_maghta;
        /// <summary>
        /// رشته
        /// </summary>
        public int id_cource;
        /// <summary>
        /// محل دریافت
        /// </summary>
        public string graduatedPlace;
        /// <summary>
        /// تاریخ دریافت
        /// </summary>
        public DateTime graduatedDate;
        /// <summary>
        /// گواینامه پایه 1
        /// </summary>
        public bool firstDrivingCard;
        /// <summary>
        /// گواینامه پایه 2
        /// </summary>
        public bool secondDrivingCard;
        /// <summary>
        /// گواینامه موتور
        /// </summary>
        public bool motorCard;
        /// <summary>
        /// سربازی
        /// </summary>
        public int id_militay;
        /// <summary>
        /// علت معافیت
        /// </summary>
        public string moafReson;
        /// <summary>
        /// محل خدمت
        /// </summary>
        public string servicePlace;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ServiceStart;
        /// <summary>
        /// 
        /// </summary>
        public DateTime ServiceEnd;
        /// <summary>
        /// سابقه جبهه
        /// </summary>
        public string warExpereience;
        /// <summary>
        /// 
        /// </summary>
        public string basigmembership;
        /// <summary>
        /// خانواده شهید
        /// </summary>
        public bool ShahidFamily;
        /// <summary>
        /// نوع جانبازی
        /// </summary>
        public string janbazikind;
        /// <summary>
        /// درصد جانبازی
        /// </summary>
        public decimal janbazPercent;
        /// <summary>
        /// وضعیت مسکن
        /// </summary>
        public int id_maskan;
        /// <summary>
        /// 
        /// </summary>
        public bool azadefamily;
        /// <summary>
        /// جانبازی
        /// </summary>
        public bool janbaz;
        /// <summary>
        /// 
        /// </summary>
        public int nesbatShahid;
        /// <summary>
        /// 
        /// </summary>
        public int nesbatJanbaz;
        /// <summary>
        /// 
        /// </summary>
        public int nesbatAzade;
        /// <summary>
        /// شماره بیمه
        /// </summary>
        public string bimeNom;
        /// <summary>
        /// شماره گواهینامه
        /// </summary>
        public string drivingcartNo;
        /// <summary>
        /// 
        /// </summary>
        public DateTime lastSanavet;
        /// <summary>
        /// 
        /// </summary>
        public DateTime employeeDate;
        /// <summary>
        /// 
        /// </summary>
        public int id_delayGroup;
        /// <summary>
        /// 
        /// </summary>
        public string accountnumber;
        /// <summary>
        /// 
        /// </summary>
        public int id_bank;
        /// <summary>
        /// 
        /// </summary>
        public string id_parvandeh;
        /// <summary>
        /// 
        /// </summary>
        public int CompanyCode;
        #endregion

    }
}
