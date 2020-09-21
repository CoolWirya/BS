using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementShares.ShareMessage
{
    public class JShareMessage
    {
        #region Properties
        public int Code {get;set;}
        /// <summary>
        /// کد فرستنده
        /// </summary>
        public int SenderCode {get;set;}
        /// <summary>
        /// کد گیرنده
        /// </summary>
        public int ReceiverCode {get;set;}
        /// <summary>
        /// تاریخ
        /// </summary>
        public string sDate {get;set;}
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime mDate {get;set;}
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title {get;set;}
        /// <summary>
        /// متن
        /// </summary>
        public string Body {get;set;}
        /// <summary>
        /// نوع
        /// </summary>
        public int Type {get;set;}
        /// <summary>
        /// خوانده شده
        /// </summary>
        public bool IsRead { get; set; }
        #endregion Properties

        public bool Insert()
        {
            JShareMessageTable table = new JShareMessageTable();
            try
            {
                table.SetValueProperty(this);
                Code = table.Insert();
                return Code > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
    }
}
