using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entertainment
{
    public class JNewsTable:JTable
    {

        public JNewsTable()
            : base("EntNews")
        { }

        #region Properties
        public DateTime Date;
        public string Title;
        public string Body;
        public int ArchiveCode;
        #endregion
    }
}
