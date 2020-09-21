using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Globals
{
    public enum JReportType
    {
        FastReport = 1,
        WordRepor = 2,
    }
    public class JDynamicReport: JGlobals
    {
        public int Code { get; set; }
        public string Content { get; set; }
        public string FileName { get; set; }
        public string Caption { get; set; }
        public string Action { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatorUserCode { get; set; }
        public int CreatorPostCode { get; set; }
        public DateTime LastUpdate { get; set; }
        public JReportType ReportType { get; set; }

        FastReport.Report Rep = new FastReport.Report();

        public JDynamicReport()
        {
        }

        public int CreateNew(System.Data.DataTable pDT, string pTableName)
        {
            if (ReportType == JReportType.FastReport)
            {
                Rep.RegisterData(pDT, pTableName);
                if (Rep.Design()
                    && ClassLibrary.JMessages.Question("", "") == System.Windows.Forms.DialogResult.Yes)
                {
                    FileName = Rep.FileName;
                    Content = Rep.SaveToString();
                    CreateDate = DateTime.Now;
                    CreatorPostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                    CreatorUserCode = ClassLibrary.JMainFrame.CurrentUserCode;
                    return Insert();
                }
            }
            else
                if (ReportType == JReportType.WordRepor)
                {
                }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (Code == 0)
                return Insert() > 0;
            else
                return Update();
        }
        /// <summary>
        /// درج
        /// </summary>
        /// <returns></returns
        public int Insert()
        {
            JDynamicReportTable DRT = new JDynamicReportTable();
            DRT.SetValueProperty(this);
            Code = DRT.Insert();
            return Code;
        }
        /// <summary>
        /// ویرایش
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JDynamicReportTable DRT = new JDynamicReportTable();
            DRT.SetValueProperty(this);
            return DRT.Update();
        }
        /// <summary>
        /// حذف
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JDynamicReportTable DRT = new JDynamicReportTable();
            DRT.SetValueProperty(this);
            return DRT.Delete();
        }
        /// <summary>
        /// دریافت اطلاعات
        /// </summary>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DB.setQuery("SELECT * FROM dynamicreport WHERE Code=" + pCode.ToString());
            DB.Query_DataReader();
            if (DB.DataReader.Read())
            {
                ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                return true;
            }
            return false;
        }
    }

    public class JDynamicReports : JGlobals
    {
        string Action;
        public JDynamicReport[] Items = new JDynamicReport[0];
        public JDynamicReports(string pAction)
        {
            Action = pAction;
        }

        public void GetDatas()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DB.setQuery("SELECT * FROM dynamicreport WHERE Action="+ClassLibrary.JDataBase.Quote(Action));
            System.Data.DataTable DT = DB.Query_DataTable();
        }
    }
}
