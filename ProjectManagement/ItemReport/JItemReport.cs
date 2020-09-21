using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.ItemReport
{
   public  class JItemReport : ClassLibrary.JSystem
    {
        public const string CLASSNAME = "ProjectManagement.ItemReport.JItemReport";
        public int Code { get; set; }
        public int ItemCode { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal WeightPercentage { get; set; }
        public string ReportDescription { get; set; }
        public int UserCode { get; set; }
 public bool HasPic { get; set; }
        public JItemReport() { }

        public JItemReport(int code) {
            GetData("SELECT * FROM pmItemReport WHERE Code="+code);
        }

        public Boolean GetData(string query)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(query);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Insert");
            if (!hasPermission)
                return 0;
            JItemReportTable AT = new JItemReportTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(0, true);

            return Code;
        }


        public bool Update(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Update");
            if (!hasPermission)
                return false;
            JItemReportTable AT = new JItemReportTable();
            AT.SetValueProperty(this);
            if (AT.Update())
                return true;
            else
                return false;
        }
        public bool Delete(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Delete");
            if (!hasPermission)
                return false;

            JItemReportTable AT = new JItemReportTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

    }
}
