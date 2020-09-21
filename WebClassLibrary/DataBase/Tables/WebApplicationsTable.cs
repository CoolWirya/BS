using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace WebClassLibrary.DataBase.Tables
{
    public class WebApplicationsTable : JTable
    {
        public WebApplicationsTable()
            : base("WebApplications")
        {
        }

        #region Properties
        public string Name;
        public string ClassName;
        public string ProjectPath;
        public string Nodes;
        public int Ordered;
        public bool Show;
        #endregion
    }
}
