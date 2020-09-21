using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementShares.ShareMessage
{
    public class JShareMessageTable :JTable
    {
        public JShareMessageTable()
            : base("ShareMessage")
        {
        }
        /// <summary>
        /// کد فرستنده
        /// </summary>
        public int SenderCode ;
        /// <summary>
        /// کد گیرنده
        /// </summary>
        public int ReceiverCode ;
        /// <summary>
        /// تاریخ
        /// </summary>
        public string sDate ;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime mDate ;
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title ;
        /// <summary>
        /// متن
        /// </summary>
        public string Body ;
        /// <summary>
        /// نوع
        /// </summary>
        public int Type ;
        /// <summary>
        /// خوانده شده
        /// </summary>
        public bool IsRead;
    }
}
