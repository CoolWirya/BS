using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{

    public enum NamaadFormType
    {
        ResidDaryaft = 1503,
        EbtalResidDaryaft = 1518,
        TadilBedehkar = 1548,
        TadilBestankar = 1545
    }

    public enum NamaadDocType
    {
        Fish = 1,
        CheckModatDar = 4,
        TadilBedehkar = 40,
        TadilBestankar = 41
    }

    public class JDocumentContract : JLegal
    {

        #region Properties
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractSubjectCode { get; set; }
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// کد شی
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// شماره 
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        public decimal Price { get; set; }

        public int State { get; set; }
        public DateTime LastChangeDate { get; set; }
        public string Description { get; set; }
        public int CancellationType { get; set; }
        public int CancellationCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContractText;
        /// <summary>
        /// بابت
        /// </summary>
        public string Concern;

        #endregion

        #region سازنده

        public JDocumentContract()
        {
        }
        public JDocumentContract(int pCode)
        {
            Code = pCode;
            GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData
        //        public static string Query = @"SELECT * FROM [VDocumentContracts] ";

        public static string Query = @"SELECT Code, [ContractSubjectCode]  ,[ClassName]   ,[ObjectCode],
                				case ClassName 
                  when 'Finance.JCheque' then (Select (select Name collate Persian_100_CI_AI from Trs_View_FormConcern where code=f.ConcernForm)from fincheques f where Code=ObjectCode )  
                  when 'Finance.JFish' then (Select (select Name collate Persian_100_CI_AI from Trs_View_FormConcern where code=f.ConcernForm)from FinFish f where Code=ObjectCode )  

                  --when 'Finance.JPromissoryNote' then (Select (select Name collate Persian_100_CI_AI from Trs_View_Concern where code=f.Concern)from FinPromissoryNote f where Code=ObjectCode )  
                  --when 'Finance.JRealPrice' then (Select (select Name collate Persian_100_CI_AI from Trs_View_Concern where code=f.Concern)from finRealPrice f where Code=ObjectCode )  
                  end as 'Concern',
                (Select text FROM dic where name =ClassName) DocumentType,                
                  case ClassName 
                  when 'Finance.JCheque' then (Select '" + JLanguages._Text("Number") + ": '+Cheque_No+'     " + JLanguages._Text("Cost") + @": ' +CAST( Price as nvarchar(50)) From fincheques where Code=ObjectCode )  
                  when 'Finance.JFish' then (Select '" + JLanguages._Text("Number") + ": '+Serial_No+'     " + JLanguages._Text("Cost") + @": ' +CAST( Price as nvarchar(50)) From FinFish where Code=ObjectCode )  
                  when 'Finance.JPromissoryNote' then (Select '" + JLanguages._Text("Number") + ": '+Serial_No+'     " + JLanguages._Text("Cost") + @": ' +CAST( Price as nvarchar(50)) From FinPromissoryNote where Code=ObjectCode ) 
                  when 'Finance.JRealPrice' then (Select '" + JLanguages._Text("Cost") + @": ' +CAST( Price as nvarchar(50)) From finRealPrice where Code=ObjectCode ) 
                  end as 'Description',
                  case ClassName 
                  when 'Finance.JCheque' then (Select Price From fincheques where Code=ObjectCode )  
                  when 'Finance.JFish' then (Select Price From FinFish where Code=ObjectCode )  
                  when 'Finance.JPromissoryNote' then (Select Price From FinPromissoryNote where Code=ObjectCode ) 
                  when 'Finance.JRealPrice' then (Select Price From finRealPrice where Code=ObjectCode ) 
                  end as 'No/Price',
                  case ClassName 
                  when 'Finance.JCheque' then (Select '" + JLanguages._Text("Number") + ": '+Cheque_No+'     " + JLanguages._Text("Cost") + @": ' +CAST( Price as nvarchar(50)) + ' تاریخ ' + CAST(Issue_Date as nvarchar(50)) + 'بابت' +(Select Name from subdefine where Concern=code) 'Concern' From fincheques where Code=ObjectCode )  
                  when 'Finance.JFish' then (Select '" + JLanguages._Text("Number") + ": '+Serial_No+'     " + JLanguages._Text("Cost") + @": ' +CAST( Price as nvarchar(50)) + ' تاریخ ' + CAST(PaymentDate as nvarchar(50)) + 'بابت' +(Select Name from subdefine where Concern=code) 'Concern' From FinFish where Code=ObjectCode )  
                  when 'Finance.JPromissoryNote' then (Select '" + JLanguages._Text("Number") + ": '+Serial_No+'     " + JLanguages._Text("Cost") + @": ' +CAST( Price as nvarchar(50)) + ' تاریخ ' + CAST(Create_Date as nvarchar(50)) + 'بابت' +(Select Name from subdefine where Concern=code) 'Concern' From FinPromissoryNote where Code=ObjectCode ) 
                  when 'Finance.JRealPrice' then (Select '" + JLanguages._Text("Cost") + @": ' +CAST( Price as nvarchar(50)) + ' تاریخ ' + CAST(Create_Date as nvarchar(50)) + 'بابت' +(Select Name from subdefine where Concern=code) 'Concern' From finRealPrice where Code=ObjectCode ) 
                  end as 'ContractText'
                  FROM [LegDocumentContract]";
        //doc.ContractText = "فیش به شماره " + form.Fish.Serial_No.ToString() + " مبلغ " + form.Fish.Price.ToString() + " بانک " + Bank.Name + " تاریخ " + JDateTime.FarsiDate(form.Fish.PaymentDate).ToString() + " بابت " + tmpConcern.Name;

        //" SELECT * FROM " + JTableNamesContracts.DocumentContract;
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase pDB)
        {
            JDocumentContractTable PDT = new JDocumentContractTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update(pDB))
                {
                    Histroy.Save(this, PDT, PDT.Code, "Update");
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
            JDocumentContractTable PDT = new JDocumentContractTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    JAction action = new JAction("DeleteDocument", ClassName + ".Delete", null, new object[] { ObjectCode });
                    action.run();
                    

                    Histroy.Save(this, PDT, PDT.Code, "Delete");
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
            JDocumentContractTable PDT = new JDocumentContractTable();
            try
            {
                if (PDT.DeleteManual(exp, pDB))
                {
                    JAction action = new JAction("DeleteDocument", ClassName + ".Delete", null, new object[] { ObjectCode });
                    action.run();
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
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                return GetData(pCode, DB);
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetData(int pCode, JDataBase DB)
        {
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.DocumentContract + " WHERE Code=" + pCode.ToString());
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

        #endregion
    }



    public class JDocumentsContract : JLegal
    {
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public bool InsertUpdate(JDataBase pDB, int pContractSubjectCode, DataTable pDt)
        {
            JDocumentContractTable PDT = new JDocumentContractTable();
            try
            {
                if (pDt != null)
                    foreach (DataRow dr in pDt.Rows)
                    {
                        JDocumentContract DC = new JDocumentContract();
                        if (dr.RowState == DataRowState.Added)
                        {
                            DC.ContractSubjectCode = pContractSubjectCode;
                            DC.ClassName = dr["ClassName"].ToString();
                            DC.ObjectCode = Convert.ToInt32(dr["ObjectCode"]);
                            PDT.SetValueProperty(DC);
                            DC.Code = PDT.Insert(pDB);
                            if (DC.Code <= 0)
                                return false;
                            Histroy.Save(this, PDT, PDT.Code, "Insert");
                        }
                        if (dr.RowState == DataRowState.Deleted )
                        {
                            dr.RejectChanges();
                            if ((int)dr["Code"] > 0)
                            {
                                DC.Code = (int)dr["Code"];
                                DC.delete(pDB);
                                dr.Delete();
                                Histroy.Save(this, PDT, PDT.Code, "Delete");
                            }
                        }
                        DC.Dispose();
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
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllData(int pContractSubjectCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                return GetAllData(pContractSubjectCode, Db);
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static bool NamaadSendTo(int pContractSubjectCode)
        {
            DataTable DT1 = GetAllData(pContractSubjectCode);
            foreach (DataRow DR in DT1.Rows)
            {
                string ClassName = DR["ClassName"].ToString();
                switch(ClassName)
                {
                    case "Finance.JCheque":
                        Finance.JCheque C1 = new Finance.JCheque((int)DR["ObjectCode"]);
                        C1.SendToNamaad();
                        break;
                    case "Finance.JFish":
                        Finance.JFish C2 = new Finance.JFish((int)DR["ObjectCode"]);
                        C2.SendToNamaad();
                        break;

                }

            }
            return true;
        }

        public void ShowDialog(int Code)
        {

        }

        public static DataTable GetAllData(int pContractSubjectCode, JDataBase pDB)
        {
            JDataBase DB = pDB;
            if (pDB == null)
                DB = new JDataBase();
            try
            {
                if (pContractSubjectCode == -1)
                    DB.setQuery(JDocumentContract.Query);
                else
                    DB.setQuery(JDocumentContract.Query + " WHERE ContractSubjectCode=" + pContractSubjectCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                if (pDB == null)
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
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesContracts.DocumentContract + " A inner join clsAllPerson P on A.ExporterCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString());
                else
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesContracts.DocumentContract + " A inner join clsAllPerson P on A.ReceiverCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString());
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
    }
}