using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JSubjectPlacesTable : JTable
    {
        public int Code;
        public int PlaceCode;
        public int SubjectCode;

        public JSubjectPlacesTable()
            : base("ArchiveSubjectPlace")
        {
        }
    }
}
