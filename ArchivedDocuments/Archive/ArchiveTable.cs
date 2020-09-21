using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JArchiveTable : JTable
    {
        public JArchiveTable()
            : base(JTableNameArchive.ArchiveTable)
        {
        }
        /// <summary>
        /// کد کاربر ارسال کننده
        /// </summary>
        public int ArchiveCode;
        public string ClassName;
        public int ObjectCode;
        public int Owner;
        public string ArchiveDesc;
        public int Status;
        public DateTime ArchiveDate;
        public bool AutoChange;
        public int SubjectCode;
        public int PlaceCode;
    }

    public enum JArchiveFields
    {
        Code,
        ArchiveCode,
        ClassName,
        ObjectCode,
        Owner,
        ArchiveDesc,
        Status,
        ArchiveDate,
        AutoChange,
        SubjectCode,
        PlaceCode, 
        OwnerPostCode, 
        EveryOne, 
        /// <summary>
        ///  این دو فیلد در کامپوننت لیست آرشیوها استفاده میشود
        /// </summary>
        Action,
        JFile
    }
}
