using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JContentTable : JTable
    {
        public JContentTable()
            : base(JTableNameArchive.ContentTable)
        { }
    }

    public enum JContentFields
    {
        Code,
        FileType,
        FileExtension,
        Contents,
        Size,
        ArchiveDate,
        ParentCode,
        LastAccess,
        Status,
        FileText
    }
}
