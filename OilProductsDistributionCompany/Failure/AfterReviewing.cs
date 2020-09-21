using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Failure
{
    public class JAfterReviewing
    {
        public int Code { get; set; }

        public int MalfunctionCode { get; set; }
        /// <summary>
        /// رفع نواقص
        /// </summary>
        public bool FixDefects { get; set; }
        /// <summary>
        /// دلایل عدم رفع نوافص
        /// </summary>
        public JDontFixDefects DontFixDefects { get; set; }
        /// <summary>
        /// توضیحات عدم رفع نقص
        /// </summary>
        public string DontFixDefectsComment { get; set; }
        /// <summary>
        /// پرسنل فنی پشتیبان
        /// </summary>
        public int RepresentativeSupplierCode { get; set; }
        /// <summary>
        /// تاریخ ورود
        /// </summary>
        public DateTime InputDateTime { get; set; }
        /// <summary>
        /// تاریخ خروج
        /// </summary>
        public DateTime OutPutDateTime { get; set; }
        /// <summary>
        /// مدیر جایگاه
        /// </summary>
        public int GasStationManagerCode { get; set; }
        /// <summary>
        /// ساعت تایید مدیر
        /// </summary>
        public DateTime GasStationManagerConfirmation { get; set; }
    
    
        public int Insert()
        {
            JAfterReviewingTable GH = new JAfterReviewingTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JAfterReviewingTable GH = new JAfterReviewingTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JAfterReviewingTable GH = new JAfterReviewingTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JAfterReviewingTable GH = new JAfterReviewingTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JAfterReviewingTable GH = new JAfterReviewingTable();
            return GH.GetData(this, pCode);
        }

        public bool GetDataByMalfunction(int pMalfunctionCode)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From [OilAfterReviewing] Where [MalfunctionCode] = " + pMalfunctionCode.ToString());
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

    public class JAfterReviewings
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JAfterReviewingTable GH = new JAfterReviewingTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            JAfterReviewingTable GH = new JAfterReviewingTable();
            return GH.CreateQuery("");
        }
    }

    public class JAfterReviewingTable : ClassLibrary.JTable
    {
        public int MalfunctionCode;
        public bool FixDefects;
        public JDontFixDefects DontFixDefects;
        public string DontFixDefectsComment;
        public int RepresentativeSupplierCode;
        public DateTime InputDateTime;
        public DateTime OutPutDateTime;
        public int GasStationManagerCode;
        public DateTime GasStationManagerConfirmation;

        public JAfterReviewingTable()
            : base("OilAfterReviewing")
        {
        }
    }

}
