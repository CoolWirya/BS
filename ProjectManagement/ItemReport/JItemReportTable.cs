using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.ItemReport
{
    public class JItemReportTable : ClassLibrary.JTable
    {

        public int ItemCode;
        public DateTime RegisterDate;
        public decimal WeightPercentage;
        public string ReportDescription;
        public int UserCode;
        public bool HasPic;
        public JItemReportTable():base("pmItemReport")
        {

        }
    }
}
