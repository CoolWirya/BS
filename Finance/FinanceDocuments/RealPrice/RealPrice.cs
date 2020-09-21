using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Finance
{
    public class JRealPrice : JFinance
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// تاریخ 
        /// </summary>
        public DateTime Create_Date { get; set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        public Decimal Price { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// بابت
        /// </summary>
        public int Concern { get; set; }
        /// <summary>
        /// کد دریافت کننده
        /// </summary>
        public int ReceiverCode { get; set; }
        /// <summary>
        /// کد صادر کننده
        /// </summary>
        public int ExporterCode { get; set; }

        #endregion

        #region سازنده

        public JRealPrice()
        {
        }
        public JRealPrice(int pCode)
        {
            Code = pCode;
            GetData(Code);
        }

        #endregion

        private Legal.JDocumentContract PriceToDoc(JRealPrice pRealPrice)
        {
            if (pRealPrice==null)
                return null;
            Legal.JDocumentContract doc = new Legal.JDocumentContract();
            doc.ClassName = "Finance.JRealPrice";
            doc.ObjectCode = pRealPrice.Code;
            doc.Price = pRealPrice.Price;
            doc.Number = "";

            string tmpDate = "";
            string[] str;
            if (pRealPrice.Create_Date != DateTime.MinValue)
            {
                str = JDateTime.FarsiDate(pRealPrice.Create_Date).ToString().Split('/');
                tmpDate = str[str.Length - 1].ToString() + "/" + str[str.Length - 2].ToString() + "/" + str[str.Length - 3].ToString();
                //JDateTime.FarsiDate(form.Cheque.Issue_Date).ToString();
            }
            string strDesc = "";
            if (pRealPrice.Description != "")
                strDesc = " توضیحات: " + pRealPrice.Description;
            JSubBaseDefine tmpConcern = new JSubBaseDefine(0, pRealPrice.Concern);
            doc.Concern = tmpConcern.Name;
            doc.ContractText = " مبلغ " + JMoney.StringToMoney(pRealPrice.Price.ToString()) + CurrencyString 
                +"(" + JMoney.NumberToString(pRealPrice.Price.ToString()) + CurrencyString + ")"
                + " تاریخ " + tmpDate + //" بابت " + doc.Concern + 
                strDesc;
            return doc;
        }
        /// <summary>
        /// تبدیل کلاس سفته به یک سند قابل استفاده در قرارداد
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Legal.JDocumentContract GetDocumentContract(int pCode)
        {
            JRealPrice realPrice = new JRealPrice(pCode);
            return PriceToDoc(realPrice);
        }

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public bool InsertUpdate(JDataBase pDB, int pContractSubjectCode, DataTable pDt)
        {
            try
            {
                if (pDt != null)
                    foreach (DataRow dr in pDt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            Create_Date = Convert.ToDateTime(dr["Create_Date"]);
                            Price = Convert.ToInt32(dr["Price"]);
                            Description = dr["Description"].ToString();
                            Concern = Convert.ToInt32(dr["Concern"]);
                            ReceiverCode = Convert.ToInt32(dr["ReceiverCode"]);
                            ExporterCode = Convert.ToInt32(dr["ExporterCode"]);
                            Insert(pDB);
                            if (Code <= 0)
                                return false;                            
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            delete(pDB);
                            dr.Delete();
                        }
                    }
                pDt.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        ///درج   
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JRealPriceTable PDT = new JRealPriceTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JRealPrice.Insert"))
                {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    if (Code > 0)
                        Histroy.Save(this, PDT, PDT.Code, "Insert");
                    return Code;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase pDB)
        {
            JRealPriceTable PDT = new JRealPriceTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JRealPrice.Update"))
                {
                    PDT.SetValueProperty(this);
                    return PDT.Update(pDB);
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            return delete(DB, pCode);
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(JDataBase pDB)
        {
            return delete(pDB, -1);
        }
        public bool delete(JDataBase pDB, int pCode)
        {
            if (pCode > 0)
            {
                GetData(pCode);
            }
            JRealPriceTable PDT = new JRealPriceTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JRealPrice.Delete"))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(pDB))
                        return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
            return false;
        }

        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JRealPriceTable PDT = new JRealPriceTable();
            try
            {
                return PDT.DeleteManual(exp, pDB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesFinance.RealPrice + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public DataTable GetAllData(int pContractSubjectCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesFinance.RealPrice + " WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JCheque.GetDataTable"));
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllData(int pContractSubjectCode, int type)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (type == 1)
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesFinance.RealPrice + " A inner join clsAllPerson P on A.ExporterCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JRealPrice.GetDataTable"));
                else
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesFinance.RealPrice + " A inner join clsAllPerson P on A.ReceiverCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JRealPrice.GetDataTable"));
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
        #endregion    

        public DataTable FieldList(int[] pCode)
        {
            string _SelectQuery =
            @"SELECT  " +
             "S.Name As 'Cheque.Concern' ," +
             "S2.Name As 'Cheque.Bank' ," +
             "S3.Name As 'Cheque.Branch' ," +
             "CH.Cheque_No As 'Cheque.Cheque_No' ," +
             "CH.Create_Date As 'Cheque.Create_Date' ," +
             "CH.Issue_Date As 'Cheque.Issue_Date' ," +
             "CH.Price As 'Cheque.Price' ," +
             "P1.Name As 'Cheque.ReceiverName' ," +
             "P2.Name As 'Cheque.ExporterName' ," +
             "CH.Back_Note As 'Cheque.Back_Note' ," +
             "CH.Description As 'Cheque.Description' ," +
             "CH.Return_Date As 'Cheque.Return_Date' ," +
             "CH.Pass_Date As 'Cheque.Pass_Date' " +
             " From " + JTableNamesFinance.Cheques +
             " CH inner join clsAllPerson P1 on CH.ReceiverCode = P1.Code " +
             " inner join clsAllPerson P2 on CH.ExporterCode = P2.Code " +
             " inner join Subdefine S on CH.Concern = S.Code And S.bcode= " + ClassLibrary.JBaseDefine.ConcernType.ToString() +
             " inner join Subdefine S2 on CH.Bank_Code = S2.Code And S2.bcode=" + ClassLibrary.JBaseDefine.BankTypes.ToString() +
             " inner join Subdefine S3 on CH.branch_Code = S3.Code And S3.bcode=" + ClassLibrary.JBaseDefine.BranchTypes.ToString();

            JDataBase Db = new JDataBase();
            Db.setQuery(_SelectQuery + " Where CH.Code in " + JDataBase.GetInSQLClause(pCode));
            return Db.Query_DataTable();
        }

        public Legal.JDocumentContract ShowDialog(String pPropClassName)
        {
            return ShowDialog(0, 0, pPropClassName);
        }

        public Legal.JDocumentContract ShowDialog(int pExporter, int pReciver, String pPropClassName)
        {
            if (this.Code == 0)
            {
                JRealPriceForm form = new JRealPriceForm(pExporter, pReciver);
                form.State = JFormState.Insert;
                form.ShowDialog();
                return PriceToDoc(form.RealPrice);
            }
            else
            {
                JRealPriceForm form = new JRealPriceForm(Code);
                form.State = JFormState.Update;
                form.ShowDialog();
                return PriceToDoc(form.RealPrice);
                //Legal.JDocumentContract doc = new Legal.JDocumentContract();
                //doc.ClassName = "Finance.JRealPrice";
                //doc.ObjectCode = form.RealPrice.Code;
                //doc.Price = form.RealPrice.Price;
                //doc.Number = "";
                //doc.ContractText = " مبلغ " + form.RealPrice.Price.ToString() + " تاریخ " + JDateTime.FarsiDate(form.RealPrice.Create_Date).ToString();
                //JSubBaseDefine tmpConcern = new JSubBaseDefine(0, form.RealPrice.Concern);
                //doc.Concern = tmpConcern.Name;
                //return doc;
            }
        }
        public static JRealPrice Show()
        {
            JRealPriceForm CF = new JRealPriceForm();
            CF.RealPrice = new JRealPrice();
            CF.ShowDialog();
            if (CF.isSave)
                return CF.RealPrice;
            else
                return null;
        }
    }
}
