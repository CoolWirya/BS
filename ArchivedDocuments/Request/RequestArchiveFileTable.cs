using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JRequestArchiveFileTable : JTable
    {
        public JRequestArchiveFileTable()
            : base("ArchiveRequest")
        {
        }

        /// <summary>
        /// کد پست درخواست کننده 
        /// </summary>
        public int Requester_Post_Code;
        /// <summary>
        /// عنوان درخواست کننده 
        /// </summary>
        public string Requester_Full_Title;
        /// <summary>
        /// کد درخواست کننده 
        /// </summary>
        public int Requester_User_Code;
        /// <summary>
        /// تاریخ درخواست  
        /// </summary>
        public DateTime RequestDate;
        /// <summary>
        /// وضعیت 
        /// </summary>
        //public int Status;
    }
}
