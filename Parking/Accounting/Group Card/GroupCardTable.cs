using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JGroupCardTable : JTable
    {
        public JGroupCardTable()
            : base(JTableNamesParking.GroupCard)
        {

        }

        /// <summary>
        /// شماره گروه
        /// </summary>
        public int GroupNumber;
        /// <summary>
        /// عنوان گروه
        /// </summary>
        public string TypeGroup = "";
        /// <summary>
        /// مبلغ اولیه
        /// </summary>
        public decimal FirstAmount;
        /// <summary>
        /// مبلغ ساعت اول به بعد
        /// </summary>
        public decimal SecondAmount;

        /// <summary>
        /// اخذ مبلغ در
        /// </summary>
        public Boolean AmountReceived = false;
        /// <summary>
        ///مجتمع
        /// </summary>
        public int MarketCode = 0;
        /// <summary>
        /// دقايقي كه در نظر گرفته نمي شوند
        /// </summary>
        public int Offers = 0;
        /// <summary>
        /// درصد تخفيف
        /// </summary>
        public int Abate = 0;
        /// <summary>
        /// گرد كردن مبلغ تا چند رقم
        /// </summary>
        public int Round =0;
        /// <summary>
        /// تعداد دفعاتي كه مي توان از كارت در اين گروه استفاده نمود
        /// </summary>
        public int UnitTime = 60;
        /// <summary>
        /// ايا مبناي محاسبه گروه بر اساس دقيقه باشد يا خير
        /// </summary>
        public Boolean PayByDialy = false;
        /// <summary>
        /// پرداخت با كيف پول الكترونيك
        /// </summary>
        public Boolean PayIsElectronic = false;
        /// <summary>
        /// گرد كردن رو به بالا فعال
        /// </summary>
        public Boolean UpRound = false;
        /// <summary>
        /// مبلغ هزينه روزانه
        /// </summary>
        public int DailyPrice;
        /// <summary>
        /// هزينه ساعت اول مجزا محاسبه گردد
        /// </summary>
        public Boolean IsFirstHourApart;
        /// <summary>
        /// /// هزينه روزانه مجزا محاسبه گردد
        /// </summary>
        public Boolean IsDailyApart;
        /// <summary>
        /// /// گروه فعال مي باشد
        /// </summary>
        public Boolean IsActive;

    }
}
