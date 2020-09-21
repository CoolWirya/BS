using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates.Land
{
    /// <summary>
    /// اراضی
    /// </summary>
    public class JRegion
    {
        /// <summary>
        /// کد اراضی
        /// </summary>
        public int Code;
        /// <summary>
        /// نام
        /// </summary>
        public int Name;
        /// <summary>
        /// پلاک اصلی
        /// </summary>
        public int MainAve;
        /// <summary>
        /// بخش
        /// </summary>
        public int Section;

        /// <summary>
        /// درج یک اراضی
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            return 0;
        }

        /// <summary>
        /// حذف یک اراضی
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return false;
        }

        /// <summary>
        /// ویرایش یک اراضی
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return false;
        }
    }

    /// <summary>
    /// زمین
    /// </summary>
    public class JLand
    {
        /// <summary>
        /// کد قطعه
        /// </summary>
        public int Code;
        /// <summary>
        /// کد اراضی
        /// </summary>
        public int RegionCode;
        /// <summary>
        /// اراضی
        /// </summary>
        public JRegion Region;
        /// <summary>
        /// پلاک فرعی
        /// </summary>
        public int SubNo;
        /// <summary>
        /// شماره بلوک
        /// </summary>
        public int BlockNumber;
        /// <summary>
        /// شماره قطعه
        /// </summary>
        public int PartNumber;
        /// <summary>
        ///کد کاربری 
        /// </summary>
        public int InfoCode;
        /// <summary>
        /// کاربری
        /// </summary>
        public JInfo Info;
        /// <summary>
        /// مساحت
        /// </summary>
        public float Area;

        /// <summary>
        /// درج یک زمین
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            return 0;
        }

        /// <summary>
        /// حذف یک زمین
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return true;
        }

        /// <summary>
        /// ویرایش یک زمین
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return true;
        }
    }
}
