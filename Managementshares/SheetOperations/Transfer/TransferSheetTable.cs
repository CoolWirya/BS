using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JTransferSheetTable :JTable
    {
        #region Properties
        /// <summary>
        /// کد برگه
        /// </summary>
        public int SCode ;
        /// <summary>
        /// فروشنده
        /// </summary>
        public int FPCode ;
        /// <summary>
        /// خریدار
        /// </summary>
        public int SPCode ;
        /// <summary>
        /// تاریخ انتقال
        /// </summary>
        public DateTime TDate ;
        /// <summary>
        /// تعداد سهم انتقال یافته
        /// </summary>
        public int TranSum ;
        /// <summary>
        /// شماره دفتر 
        /// </summary>
        public string ShNote ;
        /// <summary>
        /// شماره ردیف
        /// </summary>
        public int ShIndex ;
        /// <summary>
        /// انتقال بصورت مصالحه 
        /// </summary>
        public bool Mosalehe ;
        /// <summary>
        /// انتقال وکالت
        /// </summary>
        public bool Agent { get; set; }
        /// <summary>
        /// مالیات
        /// </summary>
        public decimal Tax ;
        /// <summary>
        /// مبلغ کل
        /// </summary>
        public decimal Price ;
        /// <summary>
        /// تائید شده (در قرارداد استفاده میشود)
        /// </summary>
        public bool Confirmed;

		public int CompanyCode;
    
        #endregion Properties
		/// <summary>
		/// 
		/// </summary>
        public JTransferSheetTable()
            : base("ShareTransfer")
        {

        }

		//public override int Insert(JDataBase db)
		//{
		//	int Ret = base.Insert(db);
		//	if ( Ret > 0)
		//	{
		//		JDataBase DB = new JDataBase();
		//		JDataBase TDB2 = new JDataBase();
		//		try
		//		{
		//			DB.setQuery("exec SP_PersonAddressViewSharePCode");
		//			DB.Query_Execute(true);

		//			TDB2.setQuery("exec SP_PersonAddressView");
		//			TDB2.Query_Execute(true);
		//		}
		//		finally
		//		{
		//			//db.Dispose();
		//		}
		//	}
		//	return Ret;
		//}
		//public override int Insert(int DefaultValue, JDataBase db, bool pManual, bool isLog)
		//{
		//	return base.Insert(DefaultValue, db, pManual, isLog);
		//}
		public override string ToString()
		{
			return base.ToString();
		}
    }
}
