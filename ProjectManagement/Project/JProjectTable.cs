using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Project
{
    public class JProjectTable : ClassLibrary.JTable
    {
        public string Name ;
        public DateTime StartDate ;
        public DateTime EndDate ;
        public string LocationAddress ;
        public string ProjectDescription;
        public decimal TotalWeight;

        public JProjectTable():base("pmProjects")
        {

        }
    }
}
