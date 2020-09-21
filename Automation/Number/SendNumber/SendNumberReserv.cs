using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Number.SendNumber
{
    class JSendNumberReserve
    {
        int Code;
        int SendNumberCode;
        int StartNumber;
        int EndNumber;

    }

    class JSendNumbersReserve
    {
        JSendNumberReserve[] Items = new JSendNumberReserve[0];

        public JSendNumbersReserve(int pSendNumberCode)
        {
        }
        /// <summary>
        /// یک شماره را دریافت وبررسی میکند در رزرو هست یا نه
        /// در صورت رزرو بودن یک شماره دیگر بر میگرداند در غیر اینصورت
        /// خود شماره را بر میگرداند و در هر صورت این شماره را در جدول
        /// آخرین شماره دبیرخانه تغییر می دهد
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        int GetFreeNumber(int Number)
        {
            return 0;
        }

        /// <summary>
        /// برگشت یک نامه
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        int BackNumber(int Number)
        {
            return 0;
        }

        int ConfirmNumber(int Number)
        {
            return 0;
        }
        /// <summary>
        /// بررسی شماره ها واصلاح خودکار اشتباهات احتمالی
        /// </summary>
        /// <returns></returns>
        Boolean RepairNumbers()
        {
            return true;
        }
    }
}
