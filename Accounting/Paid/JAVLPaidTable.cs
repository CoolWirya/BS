using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Paid
{
    //مروبوط به جدول پرداختی ها
    public class JAVLPaidTable : ClassLibrary.JTable
    {
        public int factorCode;
        public int userCode;
        //مقدار آن یکی از مقادیر فهرست
        //InvoiceStateEnum
        public int State;
        //مبلغ
        public decimal Price;
        public DateTime registerDateTime;
        //شماره فیش یا شماره رهگیری درگاه
        public string invoiceNumber;
        //نوع پرداخت
        //دستی با فیش بانک M
        //با درگاه G
        public string type;

        public DateTime documentDateTime;
        public string bankName;
        //شعبه بانک
        public string branch;
        //شماره درخواست
        public long OrderId;
        /// <summary>
        /// مخصوص درگاه اینترنتی. آیدی مرجع
        /// </summary>
        public string RefId;
        /// <summary>
        /// مخصوص درگاه اینترنتی. کد مرجع
        /// </summary>
        public string ResCode;
        /// <summary>
        /// مخصوص درگاه اینترنتی. آی دی فیش فروش
        /// </summary>
        public string SaleOrderId;
        /// <summary>
        /// مخصوص درگاه اینترنتی. مرجع فروش
        /// </summary>
        public string SaleReferenceId;
        public JAVLPaidTable()
            : base("AVLPaid")
        {

        }
    }
}
