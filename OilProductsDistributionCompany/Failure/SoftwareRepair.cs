using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Failure
{
    public enum JInitialReasons
    {
        /// <summary>
        /// عدم انتخاب
        /// </summary>
        None = 0,
        /// <summary>
        /// جدید الاحداث
        /// </summary>
        NewBuilder = 1,
        /// <summary>
        /// سوختن هارد
        /// </summary>
        BurningDrive = 2,
        /// <summary>
        /// عدم امکان تسویه حساب
        /// </summary>
        InabilityToLiquidate = 3,
        /// <summary>
        /// سایر مشکلات
        /// </summary>
        OtherProblems = 4,

    }

    public enum JInitialAgain
    {
        /// <summary>
        /// عدم انتخاب
        /// </summary>
        None = 0,
        /// <summary>
        /// تغییر تعداد نازل
        /// </summary>
        NumberOfNozzles = 1,
        /// <summary>
        /// تغییر در نوع فراورده
        /// </summary>
        ChangesInTheTypesOfProducts = 2,
        /// <summary>
        /// دیگر
        /// </summary>
        Other = 3,
    }

    /// <summary>
    /// دلایل عدم رفع نقص
    /// </summary>
    public enum JDontFixDefects
    {
        /// <summary>
        /// عدم انتخاب
        /// </summary>
        None = 0,
        /// <summary>
        /// نیاز به قطعه
        /// </summary>
        NeedToTrack = 1,
        /// <summary>
        /// نیاز به بررسی بیشتر
        /// </summary>
        NeedToExamineMore = 2,
        /// <summary>
        /// عدم ارتباط با مرکز
        /// </summary>
        DealingWithCenter = 3,
        /// <summary>
        /// عدم حضور مسئول جایگاه
        /// </summary>
        TheAbsenceOfGasStation = 4,
        /// <summary>
        /// ایراد مکانیکی
        /// </summary>
        MechanicalFault = 5,
        /// <summary>
        /// ایراد نرم افزاری
        /// </summary>
        DeliveredSoftware = 6,
        /// <summary>
        /// سایر موارد
        /// </summary>
        Other = 7,
    }

    public class JSoftwareRepair
    {
        public int Code { get; set; }
        public int MalfunctionCode { get; set; }
        /// <summary>
        /// دلیل اینشیال
        /// </summary>
        public JInitialReasons InitialReasons { get; set; }
        /// <summary>
        /// توضیحات دلیل اینشیال
        /// </summary>
        public string InitialReasonsComment { get; set; }
        /// <summary>
        /// دلایل اینشیال دوباره
        /// </summary>
        public JInitialAgain InitialAgain { get; set; }
        /// <summary>
        /// توضیحات دلایل اینشیال دوباره
        /// </summary>
        public string InitialAgainComment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int NewRPMCode { get; set; }
        /// <summary>
        /// جدول سهمیه
        /// </summary>
        public int TableQuotas { get; set; }
        /// <summary>
        /// جدول قیمت
        /// </summary>
        public int TablePrices { get; set; }
        /// <summary>
        /// ورژن PT
        /// </summary>
        public string PtVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool GSSoftwareANDDashboard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GSSoftwareANDDashboardComment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool RelationshipStatusDataCenter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastTimeConnectingPooler { get; set; }

        /// <summary>
        /// درخواست انجام شد
        /// </summary>
        public bool OperationDone{get;set;}

        /// <summary>
        /// شرح انجام عملیات
        /// </summary>
        public string OperationDescription { get; set; }

        public int Insert()
        {
            JSoftwareRepairTable GH = new JSoftwareRepairTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JSoftwareRepairTable GH = new JSoftwareRepairTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JSoftwareRepairTable GH = new JSoftwareRepairTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JSoftwareRepairTable GH = new JSoftwareRepairTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JSoftwareRepairTable GH = new JSoftwareRepairTable();
            return GH.GetData(this, pCode);
        }

        public bool GetDataByMalfunction(int pMalfunctionCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From [OilSoftwareRepair] Where [MalfunctionCode] = " + pMalfunctionCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    db.DataReader.Close();
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

    }

    public class JSoftwareRepairs
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JSoftwareRepairTable GH = new JSoftwareRepairTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            JSoftwareRepairTable GH = new JSoftwareRepairTable();
            return GH.CreateQuery("");
        }
    }

    public class JSoftwareRepairTable : ClassLibrary.JTable
    {
        public int MalfunctionCode;
        public JInitialReasons InitialReasons;
        public string InitialReasonsComment;
        public JInitialAgain InitialAgain;
        public string InitialAgainComment;
        public int NewRPMCode;
        public int TableQuotas;
        public int TablePrices;
        public string PtVersion;
        public bool GSSoftwareANDDashboard;
        public string GSSoftwareANDDashboardComment;
        public bool RelationshipStatusDataCenter;
        public DateTime LastTimeConnectingPooler;
        public bool OperationDone;
        public string OperationDescription;
        public JSoftwareRepairTable()
            : base("OilSoftwareRepair")
        {
        }
    }

}