using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    public class JPersonContract : JLegal
    {

        #region Property

        public int Code { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractSubjectCode { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode { get; set; }
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// سهم
        /// </summary>
        public float Share { get; set; }
        /// <summary>
        /// کد سهم قدیم
        /// </summary>
        public int OldAssetShare { get; set; }
        /// <summary>
        /// کد سهم جدید
        /// </summary>
        public int NewAssetShare { get; set; }

        #endregion

        #region سازنده

        public JPersonContract()
        {
        }
        public JPersonContract(int pCode)
        {
            Code=pCode;
            GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JPersonContractTable PDT = new JPersonContractTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(pDB);
                if (Code > 0)
                {
                    Histroy.Save(this, PDT, PDT.Code, "Insert");
                    return Code;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
            return 0;
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase pDB)
        {
            JPersonContractTable PDT = new JPersonContractTable();
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
        ///درج گروهی   
        /// </summary>
        /// <returns></returns>
        public bool Insert(DataTable tmpdt,int pContractSubjectCode, int pType, JDataBase db)
        {
            JPersonContractTable PDT = new JPersonContractTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            if (Code > 0 && GetData(Code))
                            {
                                delete(db);
                            }
                            dr.Delete();
                        }
                        else
                        {
                            Code = 0;
                            if (!(dr["Code"] is DBNull))
                                Code = Convert.ToInt32(dr["Code"]);
                            ContractSubjectCode = pContractSubjectCode;
                            PersonCode = Convert.ToInt32(dr["PersonCode"]);
                            Type = pType;
                            if (tmpdt.Columns.IndexOf("Share") >= 0 && !(dr["Share"] is DBNull))
                                Share = (float)Convert.ToDecimal(dr["Share"]);
                            OldAssetShare = 0;
                            if (tmpdt.Columns.IndexOf("fASCode") >= 0 && !(dr["fASCode"] is DBNull))
                                OldAssetShare = Convert.ToInt32(dr["fASCode"]);
                            if (Code == 0 || (Code > 0 && ContractSubjectCode != Convert.ToInt32(dr["ContractSubjectCode"])))
                            {
                                PDT.SetValueProperty(this);
                                Code = PDT.Insert(db);
                                if (Code > 0)
                                {
                                    Histroy.Save(this, PDT, PDT.Code, "Insert");
                                    Code = 0;
                                    OldAssetShare = 0;
                                }
                                else
                                    return false;
                            }
                            else
                                if (Code > 0 && dr.RowState == DataRowState.Modified)
                                {
                                    JTable.SetToClassProperty(this, dr);
                                    this.Type = Type;
                                    this.ContractSubjectCode = pContractSubjectCode;
                                    if (!Update(db))
                                        return false;
                                }
                        }
                    }
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                if (tmpdt != null)
                    tmpdt.AcceptChanges();
                PDT.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable tmpdt, int pContractSubjectCode, int Type, JDataBase db)
        {
            JSubjectContract contract = new JSubjectContract(ContractSubjectCode);
            if (contract.Confirmed)
            {
                return true;
            }
            JPersonContractTable PDT = new JPersonContractTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        //if ((dr.RowState == DataRowState.Added) || ( dr["Code"] == null))
                        //{
                        //    PDT.ContractSubjectCode = pContractSubjectCode;
                        //    PDT.PersonCode = Convert.ToInt32(dr["PersonCode"]);
                        //    PDT.Type = Type;
                        //    PDT.Share = Convert.(dr["Share"]);
                        //    PDT.Code = PDT.Insert(db);
                        //    dr["Code"] = PDT.Code;
                        //    if (PDT.Code < 1)
                        //        return false;
                        //    Histroy.Save(PDT, PDT.Code, "Insert");
                        //}
                
                        
                    }
                tmpdt.AcceptChanges();
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
            JPersonContractTable PDT = new JPersonContractTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete(pDB))
                {
                    if (NewAssetShare > 0)
                    {
                        Finance.JAssetShare AssetShare = new Finance.JAssetShare();
                        AssetShare.GetData(NewAssetShare, pDB);
                        AssetShare.Delete(pDB);
                    }
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

        public static bool CleareAssetShare(int pContractCode, JDataBase pDB)
        {

            string Sql = @"delete 
from finAssetShare where Code in
(
select Ash.Code from finAssetShare ASh inner join finAssetTransfer AT on ASh.TCode = AT.Code
where AT.ObjectCode = " + pContractCode.ToString() + @"
)
and 
PersonCode
not IN 
(
select PersonCode from LegPersonContract where ContractSubjectCode=" + pContractCode.ToString() + ")";
            try
            {
                pDB.setQuery(Sql);
                pDB.Query_Execute();
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
            return false;

        }


        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JPersonContractTable PDT = new JPersonContractTable();
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
        public bool GetData(int pCode)
        {
            return GetData(pCode, null);
        }

        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode, JDataBase pDB)
        {
            JDataBase DB;
            if (pDB == null)
                DB = JGlobal.MainFrame.GetDBO();
            else
                DB = pDB;
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.PersonContract + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                if (pDB == null)
                    DB.Dispose();
            }
            return false;
        }


        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(JDataBase pDB, int pContractSubjectCode, int pPersonCode)
        {
            
            JDataBase DB;
            if (pDB == null)
                DB = JGlobal.MainFrame.GetDBO();
            else
                DB = pDB;
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.PersonContract + " WHERE PersonCode=" + pPersonCode.ToString() +
                    " AND ContractSubjectCode=" + pContractSubjectCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                if (pDB == null)
                    DB.Dispose();
            }
            return false;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllData(int pContractCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                return GetAllData(pContractCode, DB);
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static DataTable GetAllData(int pContractCode,JDataBase pDB)
        {
            JDataBase DB = pDB;
            try
            {
                DB.setQuery("SELECT A.Code,P.Code As PersonCode,Name,'' As PersonShare,Share FROM " + JTableNamesLegal.PersonContract + " A inner join clsAllPerson P on A." + LegPersonPetition.PersonCode + "=P.Code WHERE ContractSubjectCode =" + pContractCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
            }
        }

        public static string GetNameSarghofli2(int pObjectCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"Select STUFF((Select ' و ' + A.Name From
(select (Select Name From clsPerson Where Code=PersonCode)+' ' +(Select Fam From clsPerson Where Code=PersonCode) Name from finAssetShare 
Where TCode in (Select Code From finAssetTransfer Where 
 ACode=(Select Code From finAsset Where ObjectCode=" + pObjectCode + @" And ClassName='RealEstate.JUnitBuild') 
And ParentCode=0 And ClassName='Legal.JSubjectContract' And OwnershipType=2)) A FOR XML PATH('')), 1, 2, '')");
                DataTable dt = DB.Query_DataTable();
                if ((dt != null) && (dt.Rows.Count > 0))
                    return dt.Rows[0][0].ToString();
                else
                    return "";
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
        /// وکلای یک قرارداد هنگامی که قرارداد جهت ویرایش یا مشاهده باز میشود
        /// </summary>
        /// <param name="pContractCode"></param>
        /// <param name="pPersonType"></param>
        /// <returns></returns>
        public static DataTable GetAdvocacyTable(int  pContractCode , int pPersonType)
        {
            string Codes = @"Select  AdCode from dbo.LegPersonContract 
                Where ContractSubjectCode = " + pContractCode + " and PC.Type =" + pPersonType.GetHashCode().ToString();

            string _Query = @"
                Select DISTINCT  PC.Code , PC.ContractSubjectCode ,AT.Person_Code PersonCode
                    ,(Select Name From clsAllPerson Where  Code = AT.Person_Code) AttorneyName
                    ,(select fa_date from StaticDates where En_Date=Cast(StartDate as Date)) 'StartDate',
                    (select fa_date from StaticDates where En_Date=Cast(EndDate as Date)) 'EndDate',
                    (case Ad.Type
                    when 1 then 'اداری'
                    when 2 then 'بلاعزل' End) 'Type'
                    , (Select Name From clsAllPerson Where  Code = Ad.PersonCode) AdvocerName
                    from legAdvocacy Ad inner join LegAdvocate AT on Ad.Code = AT.Advocacy_Code
                    left join LegSubject LS on Ad.Code = LS.Advocacy_Code
                    left join LegAdvocacyFinance AF on Ad.Code = AF.Advocacy_Code 
                   INNER JOIN legPersonContract PC on PC.PersonCode = AT.Person_Code 
                   WHERE  PC.ContractSubjectCode = " + pContractCode + " and PC.Type =" + pPersonType.GetHashCode().ToString();
            //_Query = _Query + " where  Ad.Code IN ( " + Codes + ")";

            JDataBase db = new JDataBase();
            db.setQuery(_Query);
            try
            {
                return db.Query_DataTable();
                //return JAdvocacys.GetAdvocacy(Query);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Dispose();
                return null;
            }
        }

        /// <summary>
        ///  متد اشخاص تعرفه
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllDataTarefe(int pContractSubjectCode, int pType)
        {
            JDataBase db = new JDataBase();
            try
            {
                return GetAllDataTarefe(pContractSubjectCode, pType, db);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Dispose();
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        ///  متد اشخاص تعرفه
        ///  در زمانیکه کد قرارداد خرید صفر است و با متد قبلی نمی توان اشخاص فروشنده را آورد
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllDataTarefeSeller(int pSheetCode)
        {
            JDataBase db = new JDataBase();
            string _Query = @" select 
0 fASCode,PCode Code,PCode PersonCode,(Select Name from clsAllPerson where Code=PCode) Name,Share As PersonShare,Share Share,
'Legal.JSellerContract' AS ClassNameEn, 0 as ContractSubjectCode 
 from estSheet where Code=" + pSheetCode;
            db.setQuery(_Query);
            try
            {
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Dispose();
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        ///  متد اشخاص تعرفه
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllDataTarefe(int pContractSubjectCode, int pType, JDataBase db)
        {
            string pClassName = "";
            if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer)
                pClassName = "Legal.JBuyerContract";
            else
                if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate)
                    pClassName = "Legal.JBuyerContractLegal";
                else
                    if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.Seller)
                        pClassName = "Legal.JSellerContract";
                    else
                        if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate)
                            pClassName = "Legal.JSellerContractLegal";

            string _Query = @"SELECT 0 fASCode,PC.Code Code,AP.Code PersonCode,Name,PC.Share As PersonShare,PC.Share Share,
'" + pClassName + @"' AS ClassNameEn,ContractSubjectCode FROM  LegPersonContract PC
inner join clsAllPerson AP on AP.Code = PC.PersonCode Where PC.ContractSubjectCode= " + pContractSubjectCode + " And Type = " + pType.ToString();            
            db.setQuery(_Query);
            try
            {
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Dispose();
                return null;
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static DataTable GetAllDataType(int pFinanceCode, int pContractSubjectCode, int pType, Finance.JOwnershipType pOwnershipType)
        {
            return GetAllDataType(pFinanceCode, pContractSubjectCode, pType, pOwnershipType, null);
        }
        //public static DataTable GetAllDataType(int pFinanceCode, int pContractSubjectCode, int pType, JDataBase pDB, Finance.JOwnershipType pOwnershipType)
        //{
        //    return GetAllDataType(pFinanceCode, pContractSubjectCode, pType, pOwnershipType, pDB);
        //}

        public static DataTable GetAllDataType(int pFinanceCode, int pContractSubjectCode, int pType, Finance.JOwnershipType pOwnershipType, JDataBase pDB)
        {
            return GetAllDataType(pFinanceCode, pContractSubjectCode, pType, pOwnershipType, pDB, false);
        }

        public static DataTable GetAllDataType(int pFinanceCode, int pContractSubjectCode, int pType, Finance.JOwnershipType pOwnershipType, JDataBase pDB, bool pSelectOldNew)
        {
            JDataBase DB ;
            if (pDB == null)
                DB = JGlobal.MainFrame.GetDBO();
            else
                DB = pDB;
            string pClassName="";
            if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.Seller)
                pClassName = "Legal.JSellerContract";
            else
                if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate)
                    pClassName = "Legal.JSellerContractLegal";
                else
                    if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer)
                        pClassName = "Legal.JBuyerContract";
                    else
                        if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate)
                            pClassName = "Legal.JBuyerContractLegal";
                        else
                            if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.intuition)
                                pClassName = "Legal.JIntuitionContract";

            try
            {
                string Query = "";
                string FieldsSQL = @"SELECT fAS.Code fASCode,PC.Code Code,AP.Code PersonCode,Name,ISNULL((Select Share FROM finAssetShare WHERE Code = PC.OldAssetShare),PC.Share) As PersonShare,PC.Share,'" +
            pClassName + @"' AS ClassNameEn,ContractSubjectCode ";
                if(pContractSubjectCode==0)
                    FieldsSQL = @"SELECT fAS.Code fASCode,0 Code,AP.Code PersonCode,Name,ISNULL(fAS.Share,0) As PersonShare,CAST(0 as float) Share,'" +
            pClassName + @"' AS ClassNameEn,0 ContractSubjectCode";
                
                if (pSelectOldNew)
                    FieldsSQL = FieldsSQL + " ,OldAssetShare, NewAssetShare";
                
                if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.Seller)
                {
                    if (pContractSubjectCode > 0 )//&& pOwnershipType == Finance.JOwnershipType.Definitive)
                    {
                        Query = FieldsSQL+ @"
                                FROM  LegPersonContract PC
                                inner join clsAllPerson AP on AP.Code = PC.PersonCode
                                left join finAssetShare fAS on PC.OldAssetShare = fAS.Code
                                left join finAssetTransfer fAT ON fAT.Code = fAS.TCode
                                where PC.ContractSubjectCode =" + pContractSubjectCode.ToString() +
                                " AND Type = " + pType.ToString();
                    }
                    else
                    {
                        string TempOwnershipType = "";

                        if ((pOwnershipType == Finance.JOwnershipType.Rentals && Finance.JAssetTransfer.HaveGoodWill(pFinanceCode)) || pOwnershipType == Finance.JOwnershipType.Goodwill)
                        {
                            TempOwnershipType = " AND fAT.OwnershipType=" + Finance.JOwnershipType.Goodwill.GetHashCode().ToString();
                        }
                        else
                        {
                            TempOwnershipType = " AND fAT.OwnershipType=" + Finance.JOwnershipType.Definitive.GetHashCode().ToString();
                        }
                        if (pContractSubjectCode > 0)
                        {
                            Query = FieldsSQL + @"
                                FROM  finAssetShare fAS
                                inner join finAssetTransfer fAT ON fAT.Code = fAS.TCode
                                left join LegPersonContract PC on PC.OldAssetShare = fAS.Code AND PC.ContractSubjectCode=" + pContractSubjectCode.ToString() +
                                    @"inner join clsAllPerson AP on AP.Code = fAS.PersonCode
                                WHERE fAS.ACode = " + pFinanceCode.ToString() + " AND fAS.Status<>0  " + TempOwnershipType;
                        }
                        else
                        {
                            Query = FieldsSQL + @"
                                FROM  finAssetShare fAS
                                inner join finAssetTransfer fAT ON fAT.Code = fAS.TCode
                                inner join clsAllPerson AP on AP.Code = fAS.PersonCode
                                WHERE fAS.ACode = " + pFinanceCode.ToString() + " AND fAS.Status<>0  " + TempOwnershipType;
                        }
                    }
                }
                else if (pType != ClassLibrary.Domains.Legal.JPersonPetitionType.Seller)
                {
                    if (pType == ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer && 
                        pContractSubjectCode == 0 && pOwnershipType == Finance.JOwnershipType.Goodwill)
                    {
                        string TempOwnershipType = " fAT.OwnershipType=" + Finance.JOwnershipType.Goodwill.GetHashCode().ToString();
                        Query = FieldsSQL + @"
                                FROM  finAssetShare fAS
                                inner join finAssetTransfer fAT ON fAT.Code = fAS.TCode
                                inner join clsAllPerson AP on AP.Code = fAS.PersonCode
                                WHERE fAS.ACode = " + pFinanceCode.ToString() + " AND fAS.Status<>0  AND " + TempOwnershipType;

                    }
                    else
                    {
                        Query = "SELECT Distinct A.Code,P.Code PersonCode,Name,Share,'"
                            + pClassName + "' AS ClassNameEn,ContractSubjectCode ";

                        if (pSelectOldNew)
                            Query = Query + " ,OldAssetShare, NewAssetShare";

                        Query  =Query +" FROM " + JTableNamesLegal.PersonContract + " A inner join clsAllPerson P on A.PersonCode = P.Code WHERE Type = " + pType.ToString();
                        Query = Query + " And ContractSubjectCode=" + pContractSubjectCode.ToString();
                    }

                }
                DB.setQuery(Query);
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
        /// لیست اشخاص طرف قرارداد
        /// </summary>
        /// <param name="pContractCode"></param>
        /// <param name="pType"></param>
        /// <returns></returns>
        public static DataTable GetPerson(int pContractCode, int pType)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string Query = @"Select PC.Code, P.Code PCode , PC.Type , P.Name  from LegPersonContract PC inner join clsAllPerson P 
                    on PC.PersonCode = P.Code WHERE ContractSubjectCode =  " + pContractCode.ToString();
                if (pType > 0)
                    Query += " AND PC.Type = " + pType.ToString();

                DB.setQuery(Query);
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
        /// لیست مستاجرین یک دارایی
        /// </summary>
        /// <param name="pFinanceCode"></param>
        /// <param name="pDB"></param>
        /// <returns></returns>
        public static DataTable GetRenterList(int pObjectCode, string pClassName, JDataBase pDB)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                if (pDB != null)
                    db = pDB;
//, case LegSubjectContract.Status when " + JContractStatus.Current.GetHashCode().ToString() + "then " + JDataBase.Quote(JLanguages._Text("Current")) +
//                                 when " + JContractStatus.Expired.GetHashCode().ToString() + " then " + JDataBase.Quote(JLanguages._Text("Expired")) + " END ContractStatus " +
                string Query = @" Select LegPersonContract.PersonCode , PersonAddressView.Name, PersonAddressView.Address, PersonAddressView.Tel
                , (SELECT  Fa_Date FROM StaticDates Where EN_Date = Cast(LegSubjectContract.StartDate as Date)) StartDate
                , (SELECT  Fa_Date FROM StaticDates Where EN_Date = Cast(LegSubjectContract.EndDate as Date)) EndDate
                    , case  when  LegSubjectContract.EndDate <GETDATE() then N'تاریخ گذشته'  else  N'جاری'  END ContractStatus , ContractSubjectCode ContractCode from dbo.LegPersonContract 
                    inner join LegSubjectContract On LegPersonContract.ContractSubjectCode = LegSubjectContract.Code
                    inner join LegContractType on LegSubjectContract.Type = LegContractType.Code
                    inner join legContractDynamicTypes on legContractDynamicTypes.Code = LegContractType.ContractType
                    inner join PersonAddressView on LegPersonContract.PersonCode = PersonAddressView.Code
                    where legContractDynamicTypes.AssetTransferType=" + Finance.JOwnershipType.Rentals.GetHashCode().ToString() +
                        " and LegSubjectContract.Confirmed = 'True' " +
                        " and LegSubjectContract.Status IN(" + JContractStatus.Current.GetHashCode().ToString() + ")" +
                        " AND LegSubjectContract.FinanceCode=" +
                        " (Select Code FROM finAsset WHERE ObjectCode=" + pObjectCode.ToString() + " AND ClassName = " + JDataBase.Quote(pClassName) + ")" +
                        " AND LegPersonContract.Type=" + ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer.ToString();
                db.setQuery(Query);
                DataTable table = db.Query_DataTable();
                return table;
            }
            finally
            {
                if (pDB == null)
                    db.Dispose();
            }
        }

        //public static DataTable GetPartiesInfo(int pContractSubjectCode, int pType, JStateContractForm pState, JDataBase pDB)
        //{

        //}



        #endregion

        /// <summary>
        /// لیست فیلدهای اشخاص را بر میگرداند
        /// </summary>
        /// <param name="pCode">کد شخص حقیقی یا حقوقی</param>
        /// <param name="pState">وضعیت شحص حقیقی است یا حقوقی</param>
        /// <returns></returns>
        public static DataTable FieldList(int[] pCode, JPersonTypes pState)
        {                
            JDataBase Db = new JDataBase();
            try
            {
                if (pState == JPersonTypes.LegalPerson)
                {
                    
                    string Sign = "";
                    for (int i = 0; (i < pCode.Length) && ((pCode[i] != 0) || (i == 0)); i++)
                    {
                        Db.setQuery(@"
                             SELECT  MemberList = substring((SELECT ( ', ' + P.Name + ' ' + P.Fam + ' نام پدر' +P.FatherName + ' شماره شناسنامه ' + P.ShSh
                             + ' صادره از ' + isnull((select Name from subdefine where Code=P.Sader ) + ' محل تولد از ' + isnull((select Name from subdefine where Code=P.BirthplaceCode ),'')
                             ) FROM clsSignatureMen SM 
                            left join clsPerson P ON P.Code=SM.SignPCode  
                             where PCode = " + pCode[i].ToString() + " FOR XML PATH( '' ) ), 3, 1000 )");
                        if (Db.Query_DataTable().Rows.Count > 0)
                            Sign = Db.Query_DataTable().Rows[0][0].ToString();
                        else
                            Sign = "";
                        Db.setQuery(@"
                            Select Distinct O.name As 'Organization.Name', O.Subject As 'Organization.Subject',
                            O.RegisterNo As 'Organization.RegisterNo',O.RegisterPlace As 'Organization.RegisterPlace',
                            PAD.address As 'Organization.address',
                            (select Name from subdefine where Code=PAD.Code) AS 'Organization.City',PAD.PostalCode AS 'Organization.PoastalCode',
                            PAD.Tel As 'Organization.Tel',PAD.Fax As 'Organization.Fax'
                            ,PAD.Mobile As 'Organization.Mobile',PAD.Email As 'Organization.Email',
                            O.description As 'Organization.description','" + Sign + @"' As SignatureMen
                            from clsAllPerson AP inner join organization O ON AP.Code=O.Code 
                            inner join clsPersonAddress PAD ON PAD.PCode=O.Code 
                            Where AP.Code = " + pCode[i].ToString());
                        //in " + JDataBase.GetInSQLClause(pCode));                
                        return Db.Query_DataTable();
                        //dt = Db.Query_DataTable();
                    }
                }
                else
                {
                    Db.setQuery(@"
Select Distinct P.Name As 'Person.Name',P.Fam As 'Person.Family',
P.FatherName As 'Person.FatherName',P.ShMeli As 'Person.ShMeli',
PAD.address As 'Person.address',
(select Name from subdefine where Code=PAD.Code) AS 'Person.City',
PAD.PostalCode AS 'Person.PoastalCode',
PAD.Tel As 'Person.Tel',PAD.Fax As 'Person.Fax'
,PAD.Mobile As 'Person.Mobile',PAD.Email As 'Person.Email'
,ShSh As 'Person.ShSh',BthDate  As 'Person.BthDate' from 
clsAllPerson AP inner join clsPerson P ON AP.Code=P.Code 
left join clsPersonAddress PAD ON PAD.PCode=P.Code And PAD.AddressType=" + JAddressTypes.Home.GetHashCode().ToString() +
    " Where AP.Code in " + JDataBase.GetInSQLClause(pCode));
                    return Db.Query_DataTable();
                }
                return null;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }

    #region Classes
    //حقیقی
    public class JSellerContract : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode,JPersonTypes.RealPerson);
        }
    }

    public class JSellerAdvocateContract : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode, JPersonTypes.RealPerson);
        }
    }

    public class JBuyerContract : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode, JPersonTypes.RealPerson);
        }
    }

    public class JBuyerAdvocateContract : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode, JPersonTypes.RealPerson);
        }
    }

    //حقوقی
    public class JSellerContractLegal : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode, JPersonTypes.LegalPerson);
        }
    }

    public class JSellerAdvocateContractLegal : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode, JPersonTypes.LegalPerson);
        }
    }

    public class JBuyerContractLegal : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode, JPersonTypes.LegalPerson);
        }
    }

    public class JBuyerAdvocateContractLegal : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode, JPersonTypes.LegalPerson);
        }
    }

    //شهود
    public class JIntuitionContract : JLegal
    {
        public static DataTable FieldList(int[] pCode)
        {
            return Legal.JPersonContract.FieldList(pCode, JPersonTypes.RealPerson);
        }
    }
    #endregion
}


