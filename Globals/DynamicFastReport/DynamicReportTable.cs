using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Globals
{
    public class JDynamicReportTable: ClassLibrary.JTable
    {
        public string Content;
        public string FileName;
        public string Caption;
        public string Action;
        public DateTime CreateDate;
        public int CreatorUserCode;
        public int CreatorPostCode;
        public DateTime LastUpdate;
        public JReportType ReportType;

        public JDynamicReportTable()
            : base("dynamicreport")
        {
        }
    }
}
