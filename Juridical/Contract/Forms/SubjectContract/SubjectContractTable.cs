using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JSubjectContractTable : JTable
    {
        #region Properties
        /// <summary>
        /// نام کلاس
        /// </summary>
        //public string ClassName;
        /// <summary>
        /// نوع قرارداد
        /// </summary>
        public int Type;
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        public string Number;
        /// <summary>
        /// تاریخ قرارداد
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime DateDeliver;
        /// <summary>
        /// تاریخ شروع قرارداد
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// تاریخ پایان قرارداد
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// محل انجام
        /// </summary>
        public int Location;
        /// <summary>
        /// کد اموال
        /// </summary>
        public int FinanceCode;
        /// <summary>
        /// میزان سهم مشخص گردد
        /// </summary>
        public string FinancePercent;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// تعهدات
        /// </summary>
        public string Guarantee;
        /// <summary>
        /// شرایط
        /// </summary>
        public string Condition;
        /// <summary>
        /// وضعیت فسخ/در حال اجرا
        /// </summary>
        public int Status;
        /// <summary>
        /// اجاره ماهیانه
        /// </summary>
        public decimal PriceMonth;
        /// <summary>
        /// مبلغ شارژ ماهانه
        /// </summary>
        public decimal Sharj;
        /// <summary>
        /// مبلغ قرض الحسنه
        /// </summary>
        public decimal Price;
        /// <summary>
        /// کد فایل
        /// </summary>
        public int FileCode;
        /// <summary>
        /// مبلغ کل قراداد
        /// </summary>
        public decimal TotalPrice;
        /// <summary>
        /// مبلغ نقدی
        /// </summary>
        public decimal RealPrice;
        /// <summary>
        ///تاریخ مبلغ نقدی  
        /// </summary>
        public DateTime RealPriceDate;
        /// <summary>
        /// مبلغ اقساطی
        /// </summary>
        public decimal InstallmentPrice;
        /// <summary>
        /// تاریخ شروع قسط
        /// </summary>
        public int CountPayment;
        /// <summary>
        /// مبلغ الباقی
        /// </summary>
        //public decimal RemainPrice;
        /// <summary>
        /// تاریخ شروع قسط
        /// </summary>
        public DateTime StartpaymentDate;
        /// <summary>
        /// تاریخ پایان قسط
        /// </summary>
        public DateTime EndpaymentDate;
        /// <summary>
        /// مبلغ پرداختی تا کنون
        /// </summary>
        public decimal CostUpToNow;
        /// <summary>
        /// کد حکم دادگاه
        /// </summary>
        public int DecisionCode;
        /// <summary>
        /// توضیحات حکم دادگاه
        /// </summary>
        public string DecisionDesc;
        /// <summary>
        /// تاریخ فسخ قرارداد
        /// </summary>
        public DateTime CancelDate;
        /// <summary>
        /// دلیل فسخ قرارداد
        /// </summary>
        public string CancelReason;
        /// <summary>
        /// توضیح فسخ
        /// </summary>
        public string CancelDesc;
        /// <summary>
        /// امضا فروشنده
        /// </summary>
        public bool ConfirmSeller;
        /// <summary>
        /// امضا خریدار
        /// </summary>
        public bool ConfirmBuyer;
        /// <summary>
        /// امضا شهود
        /// </summary>
        public bool ConfirmIntuition;
        /// <summary>
        /// تائید شده
        /// </summary>
        public bool Confirmed;
        /// <summary>
        /// مبلغ قرارداد سرقفلی
        /// </summary>
        public decimal GoodwillPrice;
        /// <summary>
        /// غیر فعال
        /// </summary>
        public bool Disabled;
        /// <summary>
        /// شغل
        /// </summary>
        public int Job;

        /// مبلغ جریمه طرف اول
        /// </summary>
        public Decimal FineT1;
        /// <summary>
        /// مبلغ جریمه طرف دوم
        /// </summary>
        public Decimal FineT2;
        /// <summary>
        /// هزینه های سرقفلی به عهده؟
        /// </summary>
        public int GoodwillCostsBy;
        /// <summary>
        /// هزینه شارژ بر عهده
        /// </summary>
        public int SharjByRenter;
        
        /// <summary>
        /// توضیحات قرارداد سرقفلی
        /// </summary>
        public string GoodwillDesc;
        /// <summary>
        /// توضیحات قرارداد اجاره
        /// </summary>
        public string RentDesc;
        /// <summary>
        /// تعداد نسخه های قرارداد
        /// </summary>
        public int CopyCount;
        /// <summary>
        /// حق استنکاف
        /// </summary>
        public decimal EstenkafRight;
        /// <summary>
        /// حق فسخ
        /// </summary>
        public decimal PriceCancel;
        /// <summary>
        /// تعداد چکی که در صورت برگشت، قرارداد فسخ میشود
        /// </summary>
        public int ReturnChCount;
        /// <summary>
        /// هزینه های حق التحریر به عهده؟
        /// </summary>
        public JContractPartiesType TahrirByRenter;
        /// <summary>
        ///مبلغ حق التحریر  
        /// </summary>
        public Decimal TahrirPrice;
        /// <summary>
        /// هزینه های مالیات بر مستغلات به عهده؟
        /// </summary>
        public JContractPartiesType TaxByRenter;
        /// <summary>
        /// هزینه های مالیات بر درآمد به عهده؟
        /// </summary>
        public JContractPartiesType IncomeByRenter;
        /// <summary>
        /// مبلغ پایانی
        /// </summary>
        public decimal EndPrice;
        public decimal EndPrice1;
        public decimal EndPrice2;
        /// <summary>
        /// کد انتقال
        /// </summary>
        public int TransferCode;
        /// <summary>
        /// تاریخ شروع سرقفلی
        /// </summary>
        public DateTime GoodWillStartDate;
        /// <summary>
        /// کد قرارداد قبلی
        /// </summary>
        public int PreContract;
        /// <summary>
        ///اصلاح شده 
        /// </summary>
        public int Modified;
        /// <summary>
        /// کد قرارداد انتقال سرقفلی در قرارداد صلح سرقفلی
        /// </summary>
        public int GoodwillParenCode;

        public int EnviromentUsage;
        /// <summary>
        /// نحوه پرداخت در قرارداد مشاعات
        /// </summary>
        public int EnviromentPaymentType;
        /// <summary>
        /// نحوه تسویه حساب در قرارداد مشاعات
        /// </summary>
        public int EnviromentPonyType;
        /// <summary>
        /// مبلغ قرارداد و نحوه پرداخت
        /// </summary>
        public string CostDesc;
        /// <summary>
        /// نوع جریمه - ریال / درصد
        /// </summary>
        public int FineType;
        /// <summary>
        /// عنوان قرارداد
        /// </summary>
        public string ContractTitle;
        /// <summary>
        /// نوع کالا در مجتمع انبارها
        /// </summary>
        public int SCGood;
        /// <summary>
        /// واحد -  مجتمع انبارها
        /// </summary>
        public int SCUnit;
        /// <summary>
        /// مساحت مورد اجاره -  مجتمع انبارها
        /// </summary>
        public decimal SCArea;
        /// <summary>
        /// نوع قرارداد مجتمع انبارها
        /// </summary>
        public int SCContractType;
        /// <summary>
        /// کد قرارداد مجتمع انبارها
        /// </summary>
        public string SCCode;
        /// <summary>
        /// کد انتقال در جدول انتقالات سهام
        /// </summary>
        public int ShareTransferCode;

        public int Form;
        public int Serial;
        public int FormId;
        public int ItemNo;
        public int CompanyId;
        public int FormDtlId;
        public int StatusNamaad;
        public int PersonGroup;
        public int ConncernCode;
        public int DtlClassCode1;
        public int DtlClassCode2;
        public int DtlClassCode3;

        #endregion Properties

        public JSubjectContractTable()
            : base(JTableNamesLegal.SubjectContract, "")
        {
        }
    }

    public enum JSubjectContractEnum
    {
          Code 
      , Type 
      , Number 
      , Date 
      , DateDeliver 
      , StartDate 
      , EndDate 
      , Location 
      , FinanceCode 
      , FinancePercent 
      , Description 
      , Guarantee 
      , Condition 
      , Status 
      , PriceMonth 
      , Sharj 
      , Price 
      , TotalPrice 
      , RealPrice 
      , RealPriceDate 
      , CountPayment 
      , StartpaymentDate 
      , EndpaymentDate 
      , DecisionCode 
      , DecisionDesc 
      , CancelDate 
      , CancelReason 
      , CancelDesc 
      , ConfirmSeller 
      , ConfirmBuyer 
      , ConfirmIntuition 
      , FileCode 
      , Confirmed
      , GoodwillPrice
      , Job
      , TahrirByRenter
      , TahrirPrice
      , TaxByRenter
      , IncomeByRenter
    }
}
