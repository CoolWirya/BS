using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace Finance
{
    #region ENUMs
    /// <summary>
    /// انواع مالکیت
    /// </summary>
    public enum JOwnershipType
    {
        //قطعی
        Definitive = 1,
        //سرقفلی
        Goodwill = 2,
        //صلح سرقفلی
        GoodwillPeace = 4,
        //اجاره
        Rentals = 3,
        //سایر
        Other =99,
        // هیچ کدام
        None = 0,
        //پرسنلی
        Personel = 5
    }

    public enum JPersonOwnerShips
    {
        //مالک قطعی
        DefinitiveOwner = 1,
        //مالک سرقفلی
        GoodwillOwner = 2,
        //غیره
        Other = 99,
    }

    /// <summary>
    /// نوع تقیسات - صحیح یا اعشاری
    /// </summary>
    public enum JDivideType
    {
        IntegerDivide = 1,
        DecimalDivide = 2,
    }
    /// <summary>
    /// حالت دارایی (قابل انتقال و ...)
    /// </summary>
    public enum JAssetState
    {
         /// <summary>
         /// عادی
         /// </summary>
        General = 0,
        /// <summary>
        /// درخواست انتقال
        /// </summary>
        Request = 1,
        /// <summary>
        /// موافقت شده
        /// </summary>
        Reply = 2
    }
    public enum JStatusType
    {
        /// <summary>
        /// غیر فعال
        /// </summary>
        Inactive = 0,
        /// <summary>
        /// فعال
        /// </summary>
        Active = 1,
        /// <summary>
        /// ممنوع المعامله
        /// </summary>
        Block = 2,
    }

    public enum JGroupType
    {
        /// <summary>
        /// زمین
        /// </summary>
        Ground = 1,
        /// <summary>
        /// سهام
        /// </summary>
        Saham = 2,
    }
    #endregion ENUMs

    /// <summary>
    /// کلاس انواع دارایی
    /// </summary>
    public class JAssetType : JFinance
    {
        public JAssetType()
        {
        }
        public JAssetType(string pClassName)
        {
            this.ClassName = pClassName;
        }
        /// <summary>
        /// نام کلاس 
        /// </summary>
        public string ClassName
        {
            get;
            set;
        }
        
        /// <summary>
        /// نام فارسی
        /// </summary>
        public string FarsiName
        {
            get;
            set;
        }
        public override string ToString()
        {
            return FarsiName;
        }

        /// <summary>
        /// بر اساس نام کلاس اطلاعات مربوط به آن کلاس را برمیگرداند
        /// </summary>
        /// <param name="pClassName"></param>
        /// <returns></returns>
        public static string GetAssetSQL(string pClassName)
        {
            string Query = "";

            if (pClassName == "RealEstate.JUnitBuild")
            {
                Query = @" 
         ,(Select  M.Title FROM  dbo.estUnitBuild  UB Inner Join estMarket M on UB.MarketCode = M.Code AND UB.Code = finAsset.ObjectCode AND finAsset.ClassName = " + JDataBase.Quote(pClassName) + @") Market,
         (Select  MF.Name From dbo.estUnitBuild UB inner join estMarketFloors MF on UB.FloorCode = MF.Code and UB.Code  = finAsset.ObjectCode AND finAsset.ClassName = " + JDataBase.Quote(pClassName) + @") Floor ,
         (Select  Plaque FROM  dbo.estUnitBuild Where dbo.estUnitBuild.Code =  finAsset.ObjectCode AND finAsset.ClassName = " + JDataBase.Quote(pClassName) + @") Plaque,
         (Select  Number FROM  dbo.estUnitBuild Where dbo.estUnitBuild.Code =  finAsset.ObjectCode AND finAsset.ClassName = " + JDataBase.Quote(pClassName) + @") UnitNo,
         (Select  PlaqueRegistration FROM  dbo.estUnitBuild Where dbo.estUnitBuild.Code =  finAsset.ObjectCode AND finAsset.ClassName = " + JDataBase.Quote(pClassName) + @") PlaqueRegistration,
         (Select  Area FROM  dbo.estUnitBuild Where dbo.estUnitBuild.Code =  finAsset.ObjectCode AND finAsset.ClassName = " + JDataBase.Quote(pClassName) + @") Area ";
            }
            return Query;
        }

    
    }
    /// <summary>
    /// تعریف دارائی
    /// </summary>
    public class JAsset: JFinance
    {
        #region Property
        /// <summary>
        /// کد دارائی
        /// </summary>
        public int Code { get; set; }

        ///// <summary>
        /////کد دارائی قبلی 
        ///// </summary>
        ////public int ParentCode { get; set; }

        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// کد شی
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// کد پست ایجاد کننده
        /// </summary>
        public int CreatorPostCode { get; set; }
        /// <summary>
        /// کد کاربر ایجاد کننده
        /// </summary>
        public int CreatorUserCode { get; set; }
        /// <summary>
        /// حداکثر تعداد
        /// </summary>
        public decimal MaxCount { get; set; }
        /// <summary>
        /// روش تقسیم
        /// </summary>
        public JDivideType DivideType { get; set; }
        /// <summary>
        /// ارزش
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// وضعیت دارایی
        /// </summary>
        public JStatusType Status { get; set; }
        /// <summary>
        /// در صورتی که صحیح باشد، فعال بودن همه سهمها چک میشود
        /// </summary>
        public bool CheckAssetShares {    get;   set; }
        /// <summary>
        /// کد گروه جدول Asset
        /// </summary>
        public int GroupCode { get; set; }
        /// <summary>
        /// حالت دارایی (قابل انتقال و ...)
        /// </summary>
        public JAssetState State { get; set; }
        /// <summary>
        /// چک میکند که آیا تمام اموال  جز دارایی فعال باشد
        /// </summary>
        public bool AllSharesAreActive
        {
            get
            {
                if (this.CheckAssetShares)
                {
                    try
                    {
                        /// در صورتی که تعداد سهم های غیر فعال صفر بود صحیح برمیگرداند
                        DataTable inactiveShares = JAssetShares.GetInActiveShares(this.Code);
                        if (inactiveShares.Rows.Count == 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion       

        #region Constructor
        public JAsset()
        {
        }
        public JAsset(int pCode)
        {
            GetData(pCode);
        }
        public JAsset(int pCode,JDataBase pDB)
        {
            GetData(pCode, pDB);
        }
        public JAsset(string pClassName, int pObjectCode)
            : this(pClassName, pObjectCode, null)
        {
        }

        public JAsset(string pClassName, int pObjectCode,  JDataBase pDB)
        {
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            GetData(pClassName, pObjectCode, pDB);
        }
        #endregion Constructor

        #region ChangeData
        public int Insert()
        {
            return Insert(null);
        }

        public int Insert(ClassLibrary.JDataBase pDB)
        {
            if (!Find(ClassName, ObjectCode, pDB))
            {
                this.Status = JStatusType.Active;
                CreatorPostCode = ClassLibrary.JMainFrame.CurrentPostCode;
                CreatorUserCode = ClassLibrary.JMainFrame.CurrentUserCode;
                JAssetTable AT = new JAssetTable();
                AT.SetValueProperty(this);
                Code = AT.Insert(pDB);
                if (Code > 0) { return Code; }
            }
            else
            {
                return GetCode(ClassName, ObjectCode, pDB);
            }
            return 0;
        }

        public bool Delete()
        {
            return Delete(null);
        }
        public bool Delete(ClassLibrary.JDataBase pDB)
        {
            Legal.JSubjectContract contract = new Legal.JSubjectContract();
            if (contract.GetData(Code, 0))
                JMessages.Error("برای این دارایی قرارداد ثبت شده است. حذف امکانپذیر نیست", "حذف دارایی");
            JAssetTransfer transfer = new JAssetTransfer();
            transfer.DeleteAll(this.Code, pDB);
            JAssetTable AT = new JAssetTable();
            AT.SetValueProperty(this);
            return AT.Delete(pDB);
        }

        public bool Update()
        {
            return Update(null);
        }
        public bool Update(ClassLibrary.JDataBase pDB)
        {
            JAssetTable AT = new JAssetTable();
            AT.SetValueProperty(this);
            return AT.Update(pDB);
        }

        public bool Active(JDataBase pDB)
        {
            this.Status = JStatusType.Active;
            return this.Update(pDB);
        }

        public bool DeActive()
        {
            return DeActive(null);
        }
        public bool DeActive(JDataBase pDB)
        {
            this.Status = JStatusType.Inactive;
            return this.Update(pDB);
        }
        public bool DeActive(JDataBase pDB, bool DeActiveShares, bool DeActiveAsset)
        {
            string sql = "";
            if (DeActiveAsset)
                sql += " UPDATE finAsset SET Status = " + JStatusType.Inactive.GetHashCode() + " WHERE Code = " + this.Code;
            sql += " UPDATE finAssetShare SET Status = " + JStatusType.Inactive.GetHashCode() + " WHERE ACode = " + this.Code;
            pDB.setQuery(sql);
            return pDB.Query_Execute() >= 0;
        }

        #endregion
        public bool ChangeState(JAssetState pState, JDataBase pDB)
        {
            this.State = pState;
            return this.Update(pDB);
        }

        #region Find,GetData
        /// <summary>
        /// چک میکند که آیا قرارداد تائید نشده ای برای این دارایی ثبت شده یا خیر
        /// </summary>
        /// <returns></returns>
        public bool HasUnConfirmedContract()
        {
            DataTable dt = Legal.JSubjectContracts.GetFinance(this.Code, false);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 1)
                  JMessages.Error(" کد قرارداد " + dt.Rows[1]["Code"] + " و شماره قرارداد " + dt.Rows[1]["Number"] + " تایید نشده است", "");
                return true;
            }
            else
                return false;
        }
        public bool GetData(int pCode)
        {
            return GetData(pCode, null);
        }
        public bool GetData(int pCode, JDataBase pDB)
        {
            JAssetTable AT = new JAssetTable();
            System.Data.DataTable DT = AT.Query(" Code=" + pCode.ToString(), pDB);
            if (DT.Rows.Count == 1)
            {
                return ClassLibrary.JTable.SetToClassProperty(this, DT.Rows[0]);
            }
            return false;
        }

        public bool GetData(string pClassName, int pObjectCode)
        {
            return GetData(pClassName, pObjectCode, null);
        }
        public bool GetData(string pClassName, int pObjectCode, JDataBase pDB)
        {
            JAssetTable AT = new JAssetTable();
            System.Data.DataTable DT = AT.Query(" ClassName=" + ClassLibrary.JDataBase.Quote(pClassName)
                + " AND ObjectCode =" + pObjectCode.ToString(), pDB);
            if (DT.Rows.Count == 1)
            {
                return ClassLibrary.JTable.SetToClassProperty(this, DT.Rows[0]);
            }
            return false;
        }

        public string GetSQLAssetPerson(int pPCode, bool pCheckPermission = true)
        {

            string Query = @"
            Select top 100 percent * from (Select  finAsset.Code,finAsset.ClassName AClassName, (Select ClassNameFa From ClassNames where ClassName = finAsset.ClassName ) AssetType
	                , finAsset.Comment FinanceComment, finAsset.Value  AssetCost
	                ,finAssetTransfer.ClassName TClassName ,  (Select ClassNameFa From ClassNames where ClassName = finAssetTransfer.ClassName ) TransferType ,
	                Case  OwnershipType 
	                when 1 then N'قطعی'
	                when 2 then N'سرقفلی'
	                else '' end OwnershipType
	                , finAssetTransfer.Comment  TransferComment
	                , finAssetShare.Share Share , finAssetShare.PersonCode PersonCode
                    , finAssetTransfer.ObjectCode TransferObjectCode, finAsset.ObjectCode FinanceObjectCode, GroupCode
	                 from dbo.finAsset 
	                inner Join  dbo.finAssetTransfer on finAsset.Code = finAssetTransfer.ACode
	                inner Join  dbo.finAssetShare on finAssetTransfer.Code = finAssetShare.TCode
                    and finAssetShare.Status = 1	
	             )A  WHERE 1=1 ";
            if (pPCode > 0)
            {
                Query = Query + " AND PersonCode = " + pPCode.ToString();
            }
            if (pCheckPermission)
                Query = Query + " AND " + JPermission.getObjectSql("Finance.JAsset.Find", "GroupCode");

            return Query;
        }

        public DataTable GetAssetPerson(int pPCode, bool pCheckPermission = true)
        {
            if (pPCode <= 0)
                return null;


            JDataBase db = new JDataBase();
            try
            {
                string Query = GetSQLAssetPerson(pPCode, pCheckPermission);
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Find(string pClassName, int pObjectCode,JDataBase pDb)
        {
            JAssetTable AT = new JAssetTable();
            System.Data.DataTable DT = AT.Query(" ClassName=" + ClassLibrary.JDataBase.Quote(pClassName)
                + " AND ObjectCode =" + pObjectCode.ToString(),pDb);
            return DT.Rows.Count > 0;
        }

        public int GetCode(string pClassName, int pObjectCode)
        {
            return GetCode(pClassName, pObjectCode, null);
        }
        public int GetCode(string pClassName, int pObjectCode, JDataBase pDB)
        {
            JAssetTable AT = new JAssetTable();
            System.Data.DataTable DT = AT.Query(" ClassName=" + ClassLibrary.JDataBase.Quote(pClassName)
                + " AND ObjectCode =" + pObjectCode.ToString(), pDB);
            if (DT.Rows.Count == 1)
            {
                ClassLibrary.JTable.SetToClassProperty(this, DT.Rows[0]);
                return (int)DT.Rows[0]["Code"];
            }
            return 0;
        }

        public static string Query = 
@" SELECT * FROM (
SELECT 
 (
                 Select distinct substring((Select ','+
               
               (select Name from clsAllPerson Where Code = ST1.PersonCode)
               
                 AS [text()]
                From dbo.FinAssetShare ST1
                Where ST1.ACode = ST2.ACode AND ST1.Status=1
                ORDER BY ST1.ACode
                For XML PATH ('')),2, 1000) [Students]
                From dbo.FinAssetShare ST2
                where ST2.ACode = FA.Code and st2.Status=1 
                 ) +'-'+Comment Comment,
                 FA.[Code]
                  , Case [Status]
                  when 0 then  " + JDataBase.Quote(JLanguages._Text(JStatusType.Inactive.ToString())) +
                  @"when 1 then " + JDataBase.Quote(JLanguages._Text(JStatusType.Active.ToString())) +
                  @"when 2 then " + JDataBase.Quote(JLanguages._Text(JStatusType.Block.ToString())) +
                  @" end StatusName
                 ,(Select top 1  [text] from dic where name=ClassName) AssetType
                 ,[ClassName],[ObjectCode],[CreatorPostCode] ,[CreatorUserCode] ,[Status] ,[MaxCount] ,[DivideType] 
                 ,[Value] as PrimaryWorth,GroupCode                 
                  FROM [finAsset] FA) AS FA";

        public DataTable Find()
        {
            return Find(0);
        }

        public DataTable Find(int pContractTypeCode)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();
            string Where = "";
            try
            {
                if (Comment != "") Where = " And " + finAsset.Comment + " Like N'% " + Comment + "%'";
                if (ObjectCode != 0) Where = " And " + finAsset.ObjectCode + "=" + ObjectCode;
                if (ClassName != "")
                {
                    Where = Where + " And " + finAsset.ClassName + "=N'" + ClassName + "'";// ClassName;
                }
                if (pContractTypeCode > 0)
                {
                    Where += @" AND FA.Code IN (select T.Code from legContractTypeGroup G 
                                inner join FinAssetGroup A on G.FinanceGroup = A.Code
                                inner join finAsset T on A.Code = T.GroupCode
                                where G.DynamicCode = " + pContractTypeCode.ToString() + ")";
                }
                Where = Where + " And " + JPermission.getObjectSql("Finance.JAsset.Find", "FA.GroupCode");

                tempdb.setQuery(JAsset.Query + "  where Status = " + Finance.JStatusType.Active.GetHashCode().ToString() + Where);
                return tempdb.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                tempdb.Dispose();
            }
        }

        public DataTable Search(int[] Filter)
        {
            JDataBase tempdb = JGlobal.MainFrame.GetDBO();

            string Where = "";
            if (Filter.Length > 0)
                Where = Where + " AND ObjectCode IN " + JDataBase.GetInSQLClause(Filter);
            try
            {
                if (Comment != null && Comment != "")
                    Where = Where + " And " + finAsset.Comment + "=" + Comment;
                if (ObjectCode != 0)
                    Where = Where + " And " + finAsset.ObjectCode + "=" + ObjectCode;
                if (ClassName != null && ClassName != "")
                {
                    Where = Where + " And " + finAsset.ClassName + "=" + JDataBase.Quote(ClassName);// ClassName;
                }
                tempdb.setQuery(JAsset.Query + " where 1=1 " + Where);
                return tempdb.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                tempdb.Dispose();
            }
        }

        public static List<JAssetType> GetAssetType()
        {
            JDataBase DB = new JDataBase();
            List<JAssetType> aTypes = new List<JAssetType>();
            try
            {
                //isnull((SELECT TEXT FROM dic WHERE Name=ClassName),ClassName) lang 
                DB.setQuery("SELECT ClassName FROM finAsset GROUP BY ClassName");
                DataTable table = DB.Query_DataTable();
                foreach (DataRow row in table.Rows)
                {
                    JAssetType aType = new JAssetType();
                    aType.ClassName = row["ClassName"].ToString();
                    aType.FarsiName = JLanguages._Text(row["ClassName"].ToString());
                    aTypes.Add(aType);
                }
                return aTypes;
            }
            finally
            {
                DB.Dispose();
            }
        }



        #endregion
    }

   
   
}
