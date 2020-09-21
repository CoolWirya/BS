using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Finance
{
    /// <summary>
    /// کلاس سفته
    /// </summary>
    public class JPromissoryNote : JFinance
    {
        
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره 
        /// </summary>
        public string Serial_No { get; set; }
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime Create_Date { get; set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        public Decimal Price { get; set; }
        /// <summary>
        /// کد دریافت کننده
        /// </summary>
        public int ReceiverCode { get; set; }
        /// <summary>
        /// کد صادر کننده
        /// </summary>
        public int ExporterCode { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// بابت
        /// </summary>
        public int Concern { get; set; }

        #endregion

        #region سازنده

        public JPromissoryNote()
        {
        }
        public JPromissoryNote(int pCode)
        {
            Code = pCode;
            GetData(Code);
        }

        #endregion

        /// <summary>
        /// تبدیل کلاس سفته به یک سند قابل استفاده در قرارداد
        /// </summary>
        /// <param name="pCheque"></param>
        /// <returns></returns>
        private Legal.JDocumentContract PromissToDoc(JPromissoryNote PromissoryNote)
        {
            Legal.JDocumentContract doc = new Legal.JDocumentContract();
            doc.ClassName = "Finance.JPromissoryNote";
            doc.ObjectCode = PromissoryNote.Code;
            doc.Price = PromissoryNote.Price;
            doc.Number = PromissoryNote.Serial_No;
            JSubBaseDefine tmpConcern = new JSubBaseDefine(0, PromissoryNote.Concern);
            doc.Concern = tmpConcern.Name;
            string tmpDate = " تاریخ ";
            string[] str;
            if (DateTime.MinValue != PromissoryNote.Create_Date)
            {
                str = JDateTime.FarsiDate(PromissoryNote.Create_Date).ToString().Split('/');
                tmpDate = tmpDate + str[str.Length - 1].ToString() + "/" + str[str.Length - 2].ToString() + "/" + str[str.Length - 3].ToString();
                //JDateTime.FarsiDate(form.Cheque.Issue_Date).ToString();
            }
            else
                tmpDate = " بدون " + tmpDate;

            string strDesc = "";
            if (PromissoryNote.Description != "")
                strDesc = " توضیحات: " + PromissoryNote.Description;
            doc.ContractText = "سفته به شماره " + PromissoryNote.Serial_No +
                " مبلغ " + JMoney.StringToMoney(PromissoryNote.Price.ToString()) + CurrencyString
                + "(" + JMoney.NumberToString(PromissoryNote.Price.ToString()) + CurrencyString + ")"
                + tmpDate +//     " بابت " + tmpConcern.Name +
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
            JPromissoryNote promissNote = new JPromissoryNote(pCode);
            return PromissToDoc(promissNote);
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
                            ReceiverCode = Convert.ToInt32(dr["ReceiverCode"]);
                            ExporterCode = Convert.ToInt32(dr["ExporterCode"]);
                            Description = dr["Description"].ToString();
                            Concern = Convert.ToInt32(dr["Concern"]);
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
            JPromissoryNoteTable PDT = new JPromissoryNoteTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JPromissoryNote.Insert"))
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
            JPromissoryNoteTable PDT = new JPromissoryNoteTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JPromissoryNote.Update"))
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
            JPromissoryNoteTable PDT = new JPromissoryNoteTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JPromissoryNote.Delete"))
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
            JChequesTable PDT = new JChequesTable();
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
                DB.setQuery("SELECT * FROM " + JTableNamesFinance.PromissoryNote + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT * FROM " + JTableNamesFinance.PromissoryNote + " WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JPromissoryNote.GetDataTable"));
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
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesFinance.PromissoryNote + " A inner join clsAllPerson P on A.ExporterCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JPromissoryNote.GetDataTable"));
                else
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesFinance.PromissoryNote + " A inner join clsAllPerson P on A.ReceiverCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JPromissoryNote.GetDataTable"));
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

        public Legal.JDocumentContract ShowDialog(String pPropClassName)
        {
            return ShowDialog(0, 0, pPropClassName);
        }

        public Legal.JDocumentContract ShowDialog(int pExporter, int pReciver, String pPropClassName)
        {
            if (this.Code == 0)
            {
                JPromissoryNoteForm form = new JPromissoryNoteForm(pExporter, pReciver);
                form.State = JFormState.Insert;
                form.ShowDialog();
                return PromissToDoc(form.PromissoryNote);
                
            }
            else
            {
                JPromissoryNoteForm form = new JPromissoryNoteForm(Code);
                form.State = JFormState.Update;
                form.ShowDialog();
                return PromissToDoc(form.PromissoryNote);

                //Legal.JDocumentContract doc = new Legal.JDocumentContract();
                //doc.ClassName = "Finance.JPromissoryNote";
                //doc.ObjectCode = form.PromissoryNote.Code;
                //doc.Price = form.PromissoryNote.Price;
                //doc.Number = form.PromissoryNote.Serial_No;
                //JSubBaseDefine tmpConcern = new JSubBaseDefine(form.PromissoryNote.Concern);
                //doc.Concern = tmpConcern.Name;
                //string tmpDate = "";
                //string[] str;
                //if (DateTime.MinValue != form.PromissoryNote.Create_Date)
                //{
                //    str = JDateTime.FarsiDate(form.PromissoryNote.Create_Date).ToString().Split('/');
                //    tmpDate = " تاریخ " + str[str.Length - 1].ToString() + "/" + str[str.Length - 2].ToString() + "/" + str[str.Length - 3].ToString();
                //    //JDateTime.FarsiDate(form.Cheque.Issue_Date).ToString();
                //}
                //string strDesc = "";
                //if (form.PromissoryNote.Description != "")
                //    strDesc = " توضیحات " + form.PromissoryNote.Description;
                //doc.ContractText = "سفته به شماره " + form.PromissoryNote.Serial_No +
                //    " مبلغ " + form.PromissoryNote.Price.ToString() + " تاریخ " +
                //    tmpDate +
                //    " بابت " + tmpConcern.Name +
                //    strDesc;
                ////doc.ContractText = "سفته به شماره " + form.PromissoryNote.Serial_No + " مبلغ " + form.PromissoryNote.Price.ToString() + " تاریخ " + JDateTime.FarsiDate(form.PromissoryNote.Create_Date).ToString() + " بابت " + tmpConcern.Name;
                //return doc;
            }
        }

        public DataTable FieldList(int[] pCode)
        {
            string _SelectQuery =
            @"SELECT  " +
             "S.Name As 'PromissoryNote.Concern' ," +
             "PN.Serial_No As 'PromissoryNote.Serial_No' ," +
             "PN.Create_Date As 'PromissoryNote.Create_Date' ," +
             "PN.Price As 'PromissoryNote.Price' ," +
             "P1.Name As 'PromissoryNote.ReceiverName' ," +
             "P2.Name As 'PromissoryNote.ExporterName' ," +
             "PN.Description As 'PromissoryNote.Description' ," +
             " From " + JTableNamesFinance.PromissoryNote +
             " PN inner join clsAllPerson P1 on PN.ReceiverCode = P1.Code " +
             " PN inner join clsAllPerson P2 on PN.ExporterCode = P2.Code " +
             " PN inner join Subdefine S on PN.Concern = S.Code And S.bcode= " + ClassLibrary.JBaseDefine.ConcernType.ToString();
            JDataBase Db = new JDataBase();
            Db.setQuery(_SelectQuery + " Where " + JTableNamesFinance.PromissoryNote + ".Code in " + JDataBase.GetInSQLClause(pCode));
            return Db.Query_DataTable();
        }
     }
  }


