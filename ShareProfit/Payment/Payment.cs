using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;


namespace ShareProfit
{
    public class JPayment : JBase
    {

        public JPayment()
        {
        }
        public int Code { get; set; }
        public int DocCode { get; set; }
        public int SheetNo { get; set; }
        public int PCode { get; set; }
        public int erpPCode { get; set; }
        public int ManagementsharesNo { get; set; }
        public string PayDate { get; set; }
        public decimal PayCost { get; set; }
        public string PayDesc { get; set; }
        public string RegName { get; set; }
        public int CourseCode { get; set; }
        /// <summary>
        /// تعداد آیتهای (سهم های) پرداختی به جای سود
        /// </summary>
        public decimal PayCount { get; set; }
        /// <summary>
        /// ملبغ پایه هر آیتم پرداختی
        /// </summary>
        public decimal BaseCost { get; set; }

        public int insert()
        {
            int mCode = 0;
            // if (Code == 0)
            {
                JDataBase db = JGlobal.MainFrame.GetDBO();
                string InsertCommand =
                                  @"DECLARE @MaxCode int 
                                  SET @MaxCode= ISNULL((SELECT MAX(code) FROM sahampayment),0) + 1

                                  INSERT INTO sahampayment ([code], [doccode], [sheetno], [pcode], [stockno], [coursecode] ,[paydate], [paycost],
                                       [paydesc], [regname], [erpPCode], [PayCount], [BaseCost])
                                  VALUES( @MaxCode," + this.DocCode.ToString() + " ," + this.SheetNo.ToString() +
                                  ", " + this.PCode.ToString() + ", " + this.ManagementsharesNo.ToString() + ", " + this.CourseCode.ToString() + ", " + JDataBase.Quote(this.PayDate) +
                                  ", " + this.PayCost.ToString() + ", " + JDataBase.Quote(this.PayDesc) + ", " + JDataBase.Quote(this.RegName) + ", " + this.erpPCode.ToString() +
                                  ", " + this.PayCount.ToString() + ", " + this.BaseCost.ToString() + " )" +
                                  " SELECT @MaxCode";
                try
                {
                    db.setQuery(@InsertCommand);
                    mCode = int.Parse(db.Query_ExecutSacler().ToString());

                    this.Code = mCode;
                }
                finally
                {
                    db.Dispose();
                }
            }
            return mCode;
        }

		public void delete(int pCourseCode , int pDocCode)
		{
			{
				JDataBase db = JGlobal.MainFrame.GetDBO();
				string InsertCommand =
								  @"Delete from sahampayment where DocCode=" + pDocCode.ToString()+
								  " AND CourseCode="+pCourseCode.ToString();
				try
				{
					db.setQuery(@InsertCommand);
					db.Query_ExecutSacler();
					JHistory H = new JHistory("ShareProfit.JPayment.Delete");
					H.ObjectCode = pDocCode;
					H.Save("Delete Document Course" + pCourseCode.ToString(), "ShareProfit.JPayment.Delete", pDocCode);

					Globals.Property.JProperty P = new Globals.Property.JProperty();
					P.DeleteDataByValueObjectCode(db, "ManagementShares.JCourseForm", pCourseCode, pDocCode);

				}
				finally
				{
					db.Dispose();
				}
			}
		}
		
		public int update()
        {
            int mCode = 0;
            JDataBase db = JGlobal.MainFrame.GetDBO();
            string UpdateCommand = @"UPDATE sahampayment SET [paydate] = " + JDataBase.Quote(PayDate) + ", [paycost]=" + PayCost.ToString() +
                                       " ,[paydesc]=" + JDataBase.Quote(PayDesc) + ",[regname]=" + JDataBase.Quote(RegName) +
                                       " WHERE Stockno=" + ManagementsharesNo.ToString() + " AND coursecode=" + CourseCode.ToString() +
                                       " AND pcode=" + PCode.ToString() + " AND sheetno=" + SheetNo.ToString();
            try
            {
                db.setQuery(UpdateCommand);
                mCode = db.Query_Execute();
                db.Dispose();
                this.Code = mCode;
            }
            finally
            {
                db.Dispose();
            }
            return mCode;
        }

        /// <summary>
        /// جزئیات پرداخت
        /// </summary>
        /// <param name="pAz"></param>
        /// <param name="pEla"></param>
        /// <param name="CourseCode"></param>
        /// <returns></returns>
        public static DataTable SelectPayDetails(int SheetCode, int CourseCode, int CompanyCode , string SheetTable)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            string Query = @"

select  ss.Code SheetCode , sn.Code,
								(select Cost from sahamcourse where Code=ss.CourseCode ) CourseCost,
								isnull( (select sum(paycost) from sahampayment where coursecode=ss.CourseCode and stockno=sn.code group by stockno),0) SumPayCost		,
								(select Cost from sahamcourse where Code=ss.CourseCode ) -
								isnull( (select sum(paycost) from sahampayment where coursecode=ss.CourseCode and stockno=sn.code group by stockno),0) PayRemain
								,(select Cost from sahamcourse where Code=ss.CourseCode ) -
isnull( (select sum(paycost) from sahampayment where coursecode=ss.CourseCode and stockno=sn.code group by stockno),0) PeymentNow
								,'' Description
								 from SahamNumber sn
								inner join SahamSheet ss
								on sn.Code >= ss.Az and sn.Code<=ss.Ela
								where ss.code={0} and coursecode={1} 
								group by ss.coursecode,sn.code,ss.code

";

			db.setQuery(string.Format(@Query, new object[] { SheetCode , CourseCode }));
            try
            {
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }


		public static DataTable PayDetailsPerson(int pCode, int CourseCode)
		{
			JDataBase db = JGlobal.MainFrame.GetDBO();
			string Query = @"
								select 
								ss.ShareCount * (select Cost from sahamcourse where Code=ss.CourseCode ) Cost,
								isnull( (select sum(paycost) from sahampayment where coursecode=ss.CourseCode and sheetno=ss.code),0) PayCost

								 from SahamSheet ss
								
								where ss.pcode=" + pCode + " and coursecode=" + CourseCode;
								
			db.setQuery(Query);
			try
			{
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Sheetno"], "ShareProfit.JPayment");
            node.Name = "ShareProfit.JPayment";
            node.Hint = JLanguages._Text("JPayment");
            node.Icone = JImageIndex.Default.GetHashCode();
            node.Code = (int)pRow["Sheetno"];

            /// اکشن جدید
            JAction newAction = new JAction("New...", "ShareProfit.JPayment.ShowDialog", new object[] { (int)pRow["CourseCode"] },null);

            /// اکشن ویرایش
			JAction editAction = new JAction("Edit...", "ShareProfit.JPayment.ShowDialog", new object[] { (int)pRow["CourseCode"], (int)pRow["DocCode"], (int)pRow["SheetNo"], (int)pRow["PCode"] }, null);

            /// اکشن حذف
            JAction delAction = new JAction("Delete...", "ShareProfit.JPayment.delete", new object[] { (int)pRow["CourseCode"], (int)pRow["DocCode"] },null);
            node.DeleteClickAction = editAction;

            ///لیست اسناد
            node.MouseDBClickAction = editAction;

            node.Popup.Insert(newAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(delAction);

            return node;
        }

        public static int GetMaxDocCode()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT isnull(MAX(doccode),0)+1 FROM sahampayment");
                return (int)db.Query_DataTable().Rows[0][0];
            }
            finally
            {
                db.Dispose();
            }
        }

        public void ShowDialog(int pCourseCode, int pDocCode,int pSheetNo,int pPCode)
        {
			JPaymentForm PF = new JPaymentForm(pCourseCode, pDocCode, pSheetNo, pPCode);
            PF.ShowDialog();
        }

        public void ShowDialog(int pCourseCode)
        {
            JPaymentForm PF = new JPaymentForm(pCourseCode);
            PF.ShowDialog();
        }

        public DataTable GetByDocCode(int pDocCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string Query = @"

select SP.stockno Code,PayCost,SheetNo,PayDate
from 
SahamPayment SP 
where SP.DocCode={0}
";

                DB.setQuery(string.Format(@Query, new object[] { pDocCode }));

                //DB.setQuery("select * from SahamPayment WHERE DocCode=" + pDocCode.ToString());
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

    }

    public class JPayments : JSystem
    {

        private int CourseCode;

        public JPayments(int pCourseCode)
        {
            CourseCode = pCourseCode;
        }

        public DataTable GetDataTable()
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"
select Sheetno,MIN(S.Az) Az,MAX(S.Ela) Ela,S.ShareCount,cast(C.Cost*S.ShareCount as bigint) Cost,cast(sum(paycost) as bigint) paycost,doccode,(select SharePCode from SharePCodeSheet SPS where CompanyCode=S.CompanyCode and SPS.PersonCode=SP.pcode) SharePCode,SP.pCode,(select name from clsallperson cp where cp.code = sp.pcode ) name,paydate,paydesc,regname,SP.coursecode,
(select top 1 Fa_Date from StaticDates where EN_date=cast(getdate() as date)) Nowdate
,sp.Bankname,sp.HesabNumber,sp.Description
from sahampayment sp
inner join SahamSheet S on SP.sheetno=S.Code
inner join sahamcourse C ON C.Code=sp.coursecode 
where SP.coursecode={0}
group by Sheetno,SP.pCode,paydate,paydesc,regname,SP.coursecode,doccode,sp.Bankname,sp.HesabNumber,sp.Description,s.CompanyCode,S.ShareCount,C.Cost";
                db.setQuery(string.Format(query, CourseCode));
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
            return null;
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetCourses", "ShareProfit.JPayment.GetNode");
            Nodes.DataTable = GetDataTable();


            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Click = new JAction("New...", "ShareProfit.JPayment.ShowDialog", new object[] { CourseCode },null);

            Nodes.AddToolbar(TN);
        }

    }
}
