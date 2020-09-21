using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    /// <summary>
    /// کلاس سفته
    /// </summary>
    public class JPromissoryNote : JLegal
    {
        
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره 
        /// </summary>
        public int Serial_No { get; set; }
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

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public bool InsertUpdate(JDataBase pDB, int pContractSubjectCode, DataTable pDt)
        {
            JChequesTable PDT = new JChequesTable();
            try
            {
                if (pDt != null)
                    foreach (DataRow dr in pDt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            //ContractSubjectCode = pContractSubjectCode;
                            //Bank_Code = Convert.ToInt32(dr["Bank_Code"]);
                            //branch_Code = Convert.ToInt32(dr["branch_Code"]);
                            //Cheque_No = Convert.ToInt32(dr["Cheque_No"]);
                            Create_Date = Convert.ToDateTime(dr["Create_Date"]);
                            //Issue_Date = Convert.ToDateTime(dr["Issue_Date"]);
                            Price = Convert.ToInt32(dr["Price"]);
                            ReceiverCode = Convert.ToInt32(dr["ReceiverCode"]);
                            ExporterCode = Convert.ToInt32(dr["ExporterCode"]);
                            //Back_Note = dr["Back_Note"].ToString();
                            Description = dr["Description"].ToString();
                            //Return_Date = Convert.ToDateTime(dr["Return_Date"]);
                            //Pass_Date = Convert.ToDateTime(dr["Pass_Date"]);
                            Concern = Convert.ToInt32(dr["Concern"]);
                            PDT.SetValueProperty(this);
                            Code = PDT.Insert(pDB);
                            if (Code <= 0)
                                return false;
                            Histroy.Save(PDT, PDT.Code, "Insert");
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
                PDT.Dispose();
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
                PDT.SetValueProperty(this);
                return PDT.Insert(pDB);
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
                PDT.SetValueProperty(this);
                return PDT.Update(pDB);
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
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    return true;
                }
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
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.PromissoryNote + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.PromissoryNote + " WHERE ContractSubjectCode=" + pContractSubjectCode.ToString());
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
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesContracts.PromissoryNote + " A inner join clsAllPerson P on A.ExporterCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString());
                else
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesContracts.PromissoryNote + " A inner join clsAllPerson P on A.ReceiverCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString());
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
        #endregion    }
    }
}
