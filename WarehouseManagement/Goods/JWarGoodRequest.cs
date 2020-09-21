using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WarehouseManagement.Goods
{

    /// <summary>
    /// درخواست یک کالا از انبار
    /// </summary>
    public class JWarGoodRequest
    {

        #region Properties
        public int Code { get; set; }
        public int WarCode { get; set; }
        public DateTime RequestDate { get; set; }
        public int UserCode { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }

        /// <summary>
        /// تامین شد !
        /// </summary>
        public bool IsSupply { get; set; }

        /// <summary>
        /// تاریخ تامین
        /// </summary>
        public DateTime SupplyDate { get; set; }

        /// <summary>
        /// دریافت شد !
        /// </summary>
        public bool IsReceive { get; set; }

        /// <summary>
        /// تاریخ دریافت
        /// </summary>
        public DateTime ReceiveDate { get; set; }

        #endregion Properties

        #region Methods
        public int Insert()
        {
            JWarGoodRequestTable GH = new JWarGoodRequestTable();
            GH.SetValueProperty(this);
            int result = GH.Insert();

            return result;
        }

        public bool Update()
        {
            JWarGoodRequestTable GH = new JWarGoodRequestTable();
            GH.SetValueProperty(this);
            bool result = GH.Update();

            return result;
        }

        public bool Delete()
        {
            JWarGoodRequestTable GH = new JWarGoodRequestTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JWarGoodRequestTable GH = new JWarGoodRequestTable();
            return GH.Find(pCode);
        }

        public static int FindByClassNameObjectCode(string ClassName, int ObjectCode)
        {
            #region Find WarGoodRequest
            ClassLibrary.JDataBase JDB = new ClassLibrary.JDataBase();
            JDB.setQuery(@"SELECT Code FROM WarGoodRequest WHERE ClassName='" + ClassName + "' AND ObjectCode=" + ObjectCode );
            DataTable Dt = JDB.Query_DataTable();
            int WarGoodRequest_Code = 0;
            if (Dt != null && Dt.Rows.Count != 0 && Dt.Rows[0]["Code"] != null && !string.IsNullOrEmpty(Dt.Rows[0]["Code"].ToString()))
            {
                WarGoodRequest_Code = int.Parse(Dt.Rows[0]["Code"].ToString());
            }

            #endregion Find WarGoodRequest

            return WarGoodRequest_Code;
        }

        public bool GetData(int pCode)
        {
            JWarGoodRequestTable GH = new JWarGoodRequestTable();
            return GH.GetData(this, pCode);
        }

        public static string GetWebQuery()
        {
            string Query =
            @"SELECT  [WarGoodRequest].[Code]
                      ,[WarCode]
                      ,[RequestDate]
                      ,[UserCode]
                      ,[ClassName]
                      ,[ObjectCode]
                      ,[IsSupply]
                      ,[SupplyDate]
                      ,[IsReceive]
                      ,[ReceiveDate]
                  FROM [ERP_Sepad].[dbo].[WarGoodRequest]
                      LEFT JOIN WarWarehouse WWH ON (WWH.Code = WarCode)
                 Where " + ClassLibrary.JPermission.getObjectSql("WarehouseManagement.Warehouse.JWarehousees", "WWH.Code");
            return Query;
        }

        #endregion Methods

    }

    public class JWarGoodRequestTable : ClassLibrary.JTable
    {

        public int WarCode;

        public DateTime RequestDate;

        public int UserCode;

        public string ClassName;

        public int ObjectCode;

        /// <summary>
        /// !تامین شد
        /// </summary>
        public bool IsSupply;

        /// <summary>
        /// تاریخ تامین
        /// </summary>
        public DateTime SupplyDate;

        /// <summary>
        /// دریافت شد !
        /// </summary>
        public bool IsReceive;

        /// <summary>
        /// تاریخ دریافت
        /// </summary>
        public DateTime ReceiveDate;

        public JWarGoodRequestTable()
            : base("WarGoodRequest") { }
    }

}
