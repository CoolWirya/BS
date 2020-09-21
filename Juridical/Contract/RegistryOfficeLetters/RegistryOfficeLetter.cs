using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Legal
{
    /// <summary>
    /// نامه های محضر
    /// </summary>
    public class JRegistryOfficeLetter
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date{ get; set; }
        /// <summary>
        /// شماره
        /// </summary>
        public string Number{ get; set; }
        /// <summary>
        /// تاریخ نامه محضر
        /// </summary>
        public DateTime RepDate{ get; set; }
        /// <summary>
        /// شماره نامه محضر
        /// </summary>
        public string RepNumber{ get; set; }
        /// <summary>
        /// مبلغ سرقفلی
        /// </summary>
        public decimal Price { get; set; }
        #endregion Properties

        public JRegistryOfficeLetter()
        {
        }
        public JRegistryOfficeLetter(int pCode)
        {
            GetData(pCode);
        }
        /// <summary>
        /// نمایش فرم لیست نامه ها
        /// </summary>
        public void ShowListForm(int pContractCode)
        {
            if (JPermission.CheckPermission("Legal.JRegistryOfficeLetter.ShowListForm"))
            {
                JRegistryOfficeLetterListForm listForm = new JRegistryOfficeLetterListForm(pContractCode);
                listForm.ShowDialog();
            }
        }
        public int Insert()
        {
            JRegistryOfficeLetterTable letterTable = new JRegistryOfficeLetterTable();
            letterTable.SetValueProperty(this);
            return letterTable.Insert();
        }

        public bool Update()
        {
            JRegistryOfficeLetterTable letterTable = new JRegistryOfficeLetterTable();
            letterTable.SetValueProperty(this);
            return letterTable.Update();
        }
        public bool Delete()
        {
            JRegistryOfficeLetterTable letterTable = new JRegistryOfficeLetterTable();
            letterTable.SetValueProperty(this);
            return letterTable.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Query = " select * from legRegistryOfficeLetters where Code=" + pCode;
            try
            {
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
            return false;
        }

    }

    public class JRegistryOfficeLetters
    {
        public static DataTable GetList(int pContractCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string Query = @"Select Code, ContractCode,
                (SELECT Fa_date From StaticDates Where En_Date = Cast([Date] as Date)) Date , Number, 
                (SELECT Fa_date From StaticDates Where En_Date = Cast(RepDate as Date)) OfficeLetterDate , RepNumber  OfficeLetterNo 
                from legRegistryOfficeLetters";
                if (pContractCode > 0)
                    Query = Query + " WHERE ContractCode = " + pContractCode;
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        public static DataTable GetListByCode(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string Query = @"Select Code, ContractCode,
                (SELECT Fa_date From StaticDates Where En_Date = Cast(Date as Date)) Date , Number, 
                (SELECT Fa_date From StaticDates Where En_Date = Cast(RepDate as Date)) OfficeLetterDate , RepNumber  OfficeLetterNo ,Price
                from legRegistryOfficeLetters";
                if (pCode > 0)
                    Query = Query + " WHERE Code = " + pCode;
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllDataByPrint(int pContractSubjectCode, int pType)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(@"SELECT P.Name,T.PersonCode,P.PersonTitle,P.FullName FROM legpersoncontract
T inner join PersonAddressView P On P.Code=T.PersonCode 
WHERE T.Type = " + pType.GetHashCode().ToString() + " And T.ContractSubjectCode=" + pContractSubjectCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
    
}
