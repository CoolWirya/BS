using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JRequestArchiveListTable : JTable
    {
        public JRequestArchiveListTable()
            : base("ArchiveRequestList")
        {
        }

        /// <summary>
        /// در درخواست 
        /// </summary>
        public int RequestCode;
        /// <summary>
        /// کد آرشیو 
        /// </summary>
        public int ArchiveCode;
        /// <summary>
        /// وضعیت 
        /// </summary>
        public int Status;
        /// <summary>
        /// کد پست تایید کننده 
        /// </summary>
        public int Confirm_Post_Code;
        /// <summary>
        /// عنوان تایید کننده 
        /// </summary>
        public string Confirm_Full_Title;
        /// <summary>
        /// کد  تایید کننده 
        /// </summary>
        public int Confirm_User_Code;
        /// <summary>
        ///  تاریخ شروع
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        ///  تاریخ پایان
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        ///  توضیحات
        /// </summary>
        public string Description;
    }
}
