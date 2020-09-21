using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OilProductsDistributionCompany.Failure
{

    public enum JUrgencies
    {
        Hight = 1,
        Mediume = 2,
        Low = 3,
    }

    public enum JFailureType
    {
        Electrical = 1,
        Mechanical = 2,
        SmartCard = 3,
        RPMNotInstall=4
    }

    public class JTableDamages
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public JFailureType FailureTypeCode { get; set; }
        public int TimeRequiredToRepair { get; set; }
        /// <summary>
        /// تخصص
        /// </summary>
        public string ExpertiseRequired { get; set; }
        /// <summary>
        /// فوریت
        /// </summary>
        public JUrgencies Urgency { get; set; }

        /// <summary>
        /// شماره خرابی 
        /// </summary>
        public int FailureNumber { get; set; }

        /// <summary>
        /// نوع خرابی پیش فرض
        /// </summary>
        public bool DefaultDamage { get; set; }


        public int Insert()
        {
            JTableDamagesTable GH = new JTableDamagesTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool update()
        {
            JTableDamagesTable GH = new JTableDamagesTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JTableDamagesTable GH = new JTableDamagesTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JTableDamagesTable GH = new JTableDamagesTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JTableDamagesTable GH = new JTableDamagesTable();
            return GH.GetData(this, pCode);
        }

        public void SetDefualtToNot()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            db.setQuery(" update dbo.OilTableDamages set dbo.OilTableDamages.DefaultDamage = 0 WHERE dbo.OilTableDamages.DefaultDamage = 1 ");
            db.Query_Execute();
        }
    }

    public class JTableDamageses
    {
        public static DataTable GetData()
        {
            return GetData(0);
        }

        public static DataTable GetData(int pCode)
        {
            JTableDamagesTable GH = new JTableDamagesTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return " SELECT Code,FailureNumber,Name,TimeRequiredToRepair,ExpertiseRequired,"
                  + "  CASE FailureTypeCode WHEN 1 THEN 'Electrical' WHEN 2 THEN 'Mechanical' WHEN 3 THEN 'SmartCard' END AS FailureTypeCode"
                  + " ,CASE urgency WHEN 1 THEN  'Hight'"
                  + " WHEN 2 THEN 'Mediume'"
                  + " WHEN   3 THEN 'Low'END AS urgency"
                  + " FROM dbo.OilTableDamages";
        }

       

    }

    public class JTableDamagesTable : ClassLibrary.JTable
    {
        public string Name;
        public JFailureType FailureTypeCode;
        public int TimeRequiredToRepair;
        /// <summary>
        /// تخصص
        /// </summary>
        public string ExpertiseRequired;
        /// <summary>
        /// فوریت
        /// </summary>
        public JUrgencies Urgency;

        /// <summary>
        /// پیش فرض
        /// </summary>
        public bool DefaultDamage;

        /// <summary>
        /// شماره خرابی 
        /// </summary>
        public int FailureNumber;

        public JTableDamagesTable()
            : base("OilTableDamages")
        {
        }
    }
}
