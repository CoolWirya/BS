using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace Legal
{
    /// <summary>
    /// وضعیت قرارداد
    /// </summary>
    public enum JContractStatus
    {
        None=0,
         /// <summary>
         /// جاری
         /// </summary>
        Current = 1,
        /// <summary>
        /// اتمام
        /// </summary>
        Expired = 2,
        /// <summary>
        /// فسخ شده
        /// </summary>
        Canceled = 3,
        /// <summary>
        /// غیر فعال
        /// </summary>
        Disabled=4,
    }
    /// <summary>
    /// طرفین شامل این فیلدهاست
    /// </summary>
    public enum JContractPartiesType
    {
        Seller = 1 , Buyer = 2, Both = 3, None = 0
    }    
    public class JSubjectContract : JLegal
    {        
        #region Properties

        public int Code { get; set; }
        /// <summary>
        /// نام کلاس
        /// </summary>
        //public string ClassName { get; set; }
        /// <summary>
        /// نوع متن قرارداد
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// تاریخ قرارداد
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime DateDeliver { get; set; }
        /// <summary>
        /// تاریخ شروع قرارداد
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// تاریخ پایان قرارداد
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// محل انجام
        /// </summary>
        public int Location { get; set; }
        /// <summary>
        /// کد اموال
        /// </summary>
        public int FinanceCode { get; set; }
        /// <summary>
        /// میزان سهم مشخص گردد
        /// </summary>
        public string FinancePercent { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// تعهدات
        /// </summary>
        public string Guarantee { get; set; }
        /// <summary>
        /// شرایط
        /// </summary>
        public string Condition { get; set; }
        /// <summary>
        /// وضعیت فسخ/در حال اجرا
        /// </summary>
        public JContractStatus Status { get; set; }
        /// <summary>
        /// اجاره ماهیانه
        /// </summary>
        public decimal PriceMonth { get; set; }
        /// <summary>
        /// مبلغ شارژ ماهانه
        /// </summary>
        public decimal Sharj { get; set; }
        /// <summary>
        /// مبلغ قرض الحسنه
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// کد فایل
        /// </summary>
        public int FileCode { get; set; }
        /// <summary>
        /// مبلغ کل قراداد
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// مبلغ نقدی
        /// </summary>
        public decimal RealPrice { get; set; }        
        /// <summary>
        ///تاریخ مبلغ نقدی  
        /// </summary>
        public DateTime RealPriceDate { get; set; }
        /// <summary>
        /// تعداد اقساط
        /// </summary>
        public int CountPayment { get; set; }
        /// <summary>
        /// مبلغ اقساطی
        /// </summary>
        public decimal InstallmentPrice { get; set; }
        /// <summary>
        /// مبلغ الباقی
        /// </summary>
        //public decimal RemainPrice { get; set; }
        /// <summary>
        /// تاریخ شروع قسط
        /// </summary>
        public DateTime StartpaymentDate { get; set; }
        /// <summary>
        /// تاریخ پایان قسط
        /// </summary>
        public DateTime EndpaymentDate { get; set; }
        /// <summary>
        /// کد حکم دادگاه
        /// </summary>
        public int DecisionCode { get; set; }
        /// <summary>
        /// توضیحات حکم دادگاه
        /// </summary>
        public string DecisionDesc { get; set; }
        /// <summary>
        /// تاریخ فسخ قرارداد
        /// </summary>
        public DateTime CancelDate { get; set; }
        /// <summary>
        /// دلیل فسخ قرارداد
        /// </summary>
        public string CancelReason { get; set; }
        /// <summary>
        /// توضیح فسخ
        /// </summary>
        public string CancelDesc { get; set; }
        /// <summary>
        /// امضا فروشنده
        /// </summary>
        public bool ConfirmSeller { get; set; }
        /// <summary>
        /// امضا خریدار
        /// </summary>
        public bool ConfirmBuyer { get; set; }
        /// <summary>
        /// امضا شهود
        /// </summary>
        public bool ConfirmIntuition { get; set; }
        /// <summary>
        /// تائید شده
        /// </summary>
        public bool Confirmed { get; set; }
        /// <summary>
        /// مبلغ قرارداد سرقفلی
        /// </summary>
        public decimal GoodwillPrice { get; set; }
        /// <summary>
        /// این قرارداد غیر فعال شده و قرارداد جدیدی ثبت شده است
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// حق شارژ بر عهده مستاجر
        /// </summary>
        public JContractPartiesType SharjByRenter { get; set; }
        /// <summary>
        /// مدت قرارداد
        /// </summary>
        public int Duration { get; set; }        
        /// <summary>
        /// نوع قرارداد
        /// </summary>
        public JContractDynamicType ContractType { get; set; }
        /// <summary>
        /// شغل
        /// </summary>
        public int Job { get; set; }
        /// <summary>
        /// طرف اول قرارداد
        /// </summary>
        public DataTable T1Person { get; set; }
        /// <summary>
        /// طرف دوم قرارداد
        /// </summary>
        public DataTable T2Person { get; set; }
        /// <summary>
        /// حق استنکاف
        /// </summary>
        public decimal EstenkafRight { get; set; }
        /// <summary>
        /// حق فسخ
        /// </summary>
        public decimal PriceCancel { get; set; }
        /// <summary>
        /// تعداد چکی که در صورت برگشت، قرارداد فسخ میشود
        /// </summary>
        public int ReturnChCount { get; set; }
        /// <summary>
        /// مبلغ جریمه طرف اول
        /// </summary>
        public Decimal FineT1 { get; set; }
        /// <summary>
        /// مبلغ جریمه طرف دوم
        /// </summary>
        public Decimal FineT2 { get; set; }
        /// <summary>
        /// هزینه های سرقفلی به عهده؟
        /// </summary>
        public JContractPartiesType GoodwillCostsBy { get; set; }
        /// <summary>
        /// توضیحات قرارداد سرقفلی
        /// </summary>
        public string GoodwillDesc { get; set; }
        /// <summary>
        /// توضیحات قرارداد اجاره
        /// </summary>
        public string RentDesc { get; set; }
        /// <summary>
        /// تعداد نسخه های قرارداد
        /// </summary>
        public int CopyCount{ get; set; }
        /// <summary>
        /// هزینه های حق التحریر به عهده؟
        /// </summary>
        public JContractPartiesType TahrirByRenter { get; set; }
        /// <summary>
        ///مبلغ حق التحریر  
        /// </summary>
        public Decimal TahrirPrice { get; set; }
        /// <summary>
        /// هزینه های مالیات بر مستغلات به عهده؟
        /// </summary>
        public JContractPartiesType TaxByRenter { get; set; }
        /// <summary>
        /// هزینه های مالیات بر درآمد به عهده؟
        /// </summary>
        public JContractPartiesType IncomeByRenter { get; set; }
        /// <summary>
        /// مبلغ پایانی
        /// </summary>
        public decimal EndPrice { get; set; }
        public decimal EndPrice1 { get; set; }
        public decimal EndPrice2 { get; set; }
        /// <summary>
        /// مبلغ پرداختی تا کنون
        /// </summary>
        public decimal CostUpToNow { get; set; }
        /// <summary>
        /// کد انتقال
        /// </summary>
        public int TransferCode { get; set; }
        /// <summary>
        /// تاریخ شروع سرقفلی
        /// </summary>
        public DateTime GoodWillStartDate { get; set; }
        /// <summary>
        /// کد قرارداد قبلی
        /// </summary>
        public int PreContract { get; set; }
        /// <summary>
        /// اصلاح شده
        /// </summary>
        public int Modified { get; set; }
        /// <summary>
        /// کد قرارداد انتقال سرقفلی در قرارداد صلح سرقفلی
        /// </summary>
        public int GoodwillParenCode { get; set; }
        /// <summary>
        /// نوع کاربری در قرارداد مشاعات
        /// </summary>
        public int EnviromentUsage { get; set; }
        /// <summary>
        /// نحوه پرداخت در قرارداد مشاعات
        /// </summary>
        public int EnviromentPaymentType { get; set; }
        /// <summary>
        /// نحوه تسویه حساب در قرارداد مشاعات
        /// </summary>
        public int EnviromentPonyType { get; set; }
        /// <summary>
        /// مبلغ قرارداد و نحوه پرداخت
        /// </summary>
        public string CostDesc { get; set; }
        /// <summary>
        /// نوع جریمه - ریال / درصد
        /// </summary>
        public int FineType { get; set; }
        /// <summary>
        /// عنوان قرارداد
        /// </summary>
        public string ContractTitle { get; set; }
        /// <summary>
        /// نوع کالا در مجتمع انبارها
        /// </summary>
        public int SCGood { get; set; }
        /// <summary>
        /// واحد -  مجتمع انبارها
        /// </summary>
        public int SCUnit { get; set; }
        /// <summary>
        /// مساحت مورد اجاره -  مجتمع انبارها
        /// </summary>
        public decimal SCArea { get; set; }
        /// <summary>
        /// نوع قرارداد مجتمع انبارها
        /// </summary>
        public int SCContractType { get; set; } 
        /// <summary>
        /// کد قرارداد مجتمع انبارها
        /// </summary>
        public string SCCode{ get; set; }
        /// <summary>
        /// کد انتقال در جدول انتقالات سهام
        /// </summary>
        public int ShareTransferCode { get; set; }

        public int Form { get; set; }
        public int Serial { get; set; }
        public int FormId { get; set; }
        public int ItemNo { get; set; }
        public int CompanyId { get; set; }
        public int FormDtlId { get; set; }
        public int StatusNamaad { get; set; }
        public int PersonGroup { get; set; }
        public int ConncernCode { get; set; }
        public int DtlClassCode1 { get; set; }
        public int DtlClassCode2 { get; set; }
        public int DtlClassCode3 { get; set; }

        #endregion Properties

        #region سازنده

        public JSubjectContract()
        {
        }

        public JSubjectContract(int pCode, JDataBase pDB)
        {
            Code = pCode;
            if (pCode > 0)
                GetData(Code, pDB);
        }
        public JSubjectContract(int pCode)
            : this(pCode, null)
        {
        }
         
        #endregion

        #region Methods Insert,Update,delete,GetData

        public static string Query = @" SELECT LegSubjectContract.Code, Number ContractNo , Description, Price, PriceMonth, TotalPrice, 
                        RealPrice, GoodwillPrice ,
                        (select Title from legContractDynamicTypes where code=legContractType.ContractType) 'ContractTypeName' 
                        , legContractType.Code TypeCode,
                        Date, StartDate, EndDate, Confirmed, FinanceCode,LegContractType.ContractType,legContractDynamicTypes.AssetTransferType,
                        case Status
                        when 0 then 'هیچکدام'
						when 1 then 'جاری'
						when 2 then 'اتمام' 
						when 3 then 'فسخ شده'
						when 4 then 'غیر فعال'
						end 'Status'
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(Date as Date)) as DateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(StartDate as Date)) as StartDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(EndDate as Date)) as EndDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(StartpaymentDate as Date)) as StartpaymentDateFa
                      , (Select Fa_Date FROM StaticDates Where EN_Date = Cast(EndpaymentDate as Date)) as EndPaymentDateFa
                      , legContractType.ContractType DynamicType
                      , (Select Name from subdefine Where Code=LegSubjectContract.Job) 'JobTitle'
                      , datediff(Month,StartDate ,EndDate) 'MonthDuring' 
                      FROM  " + JTableNamesLegal.SubjectContract +
                      " inner join legContractType  on Type=legContractType.Code " +
                      @" Inner Join legContractDynamicTypes on legContractDynamicTypes.Code = LegContractType.ContractType ";
        public override string ToString()
        {
            return "قرارداد شماره: " + this.Number + " بتاریخ: " + JDateTime.FarsiDate(this.Date);
        }
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JSubjectContractTable PDT = new JSubjectContractTable();
            try
            {
                //if (JPermission.CheckPermission("Legal.JSubjectContract.Insert", ContractType.Code))
                //{
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    //Add Relation
                    JRelation tmpJRelation = new JRelation();
                    tmpJRelation.PrimaryClassName = "ClassLibrary.AssetShare";
                    tmpJRelation.PrimaryObjectCode = PDT.FinanceCode;
                    tmpJRelation.ForeignClassName = "Legal.JSubjectContract";
                    tmpJRelation.ForeignObjectCode = Code;
                    tmpJRelation.Comment = "برای این اموال قرارداد ثبت شده است";
                    if (!tmpJRelation.Insert(pDB))
                        return -1;
                    //Nodes.DataTable.Merge(JSubjectContracts.GetDataTable(Code, Type, pDB));
                    //Nodes.DataTable.Merge(JSubjectContracts.GetDataTable(Code));
                    Histroy.Save(this, PDT, Code, "Insert");
                    return Code;
                //}
                //else
                //    return 0;
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            try
            {
                if (JPermission.CheckPermission("Legal.JSubjectContract.Insert", ContractType.Code))
                {
                    JSubjectContractTable PDT = new JSubjectContractTable();
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert();

                    //Add Relation
                    JRelation tmpJRelation = new JRelation();
                    tmpJRelation.PrimaryClassName = "ClassLibrary.Asset";
                    tmpJRelation.PrimaryObjectCode = PDT.FinanceCode;
                    tmpJRelation.ForeignClassName = "Legal.JSubjectContract";
                    tmpJRelation.ForeignObjectCode = Code;
                    tmpJRelation.Comment = "برای این اموال قرارداد ثبت شده است";
                    if (!tmpJRelation.Insert())
                        return -1;

                    //Nodes.DataTable.Merge(JSubjectContracts.GetDataTable(Code));
                    Histroy.Save(this, PDT, Code, "Insert");
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
                //DB.Dispose();
            }
        }

        /// <summary>
        /// چک کردن مجوز ویرایش پس از تائید قرارداد
        /// </summary>
        /// <returns></returns>
        public bool UpdateAfterConfirmed()
        {
            string msg = "این قرارداد تائید شده. شما مجوز ویرایش آنرا ندارید.";
            //// فقط مدیر سیستم مجوز ویرایش قرارداد پس از تائید آنرا دارد
            //if (JMainFrame.CurrentPostCode != 1)
            //{
            //    JMessages.Error(msg, "AccessDenied");
            //    return false;
            //}
            if (JPermission.CheckPermission("Legal.JSubjectContract.UpdateAfterConfirmed", ContractType.Code, JMainFrame.CurrentPostCode, true, msg))
                return true;
            else
                return false;
        }

        public bool Update()
        {           
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                try
                {
                    return Update(DB);
                }
                finally
                {
                    DB.Dispose();
                }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase pDB)
        {
            JSubjectContractTable PDT = new JSubjectContractTable();
            try
            {
             //if (JPermission.CheckPermission("Legal.JSubjectContract.Update")) // مجوز در موقع نمایش فرم چک میشود
             {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(pDB))
                    {
                        //Nodes.Refreshdata(Nodes.CurrentNode, JSubjectContracts.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    return false;
                }
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
        public bool delete()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {                
                return delete(false, DB);
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
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete(bool pDel,JDataBase pDB)
        {
            JDataBase DB = pDB;
            if(pDB == null)
            {
                DB = new JDataBase();
            }

            if ((!this.Confirmed) || pDel)
            {
                
                try
                {
                    if (JPermission.CheckPermission("Legal.JSubjectContract.Delete", ContractType.Code))
                    {
                        string[] parameters = { "@Item" };
                        string[] values = { "Contract" };
                        string msg = JLanguages._Text("YouWantToDelete?", parameters, values);
                        if (JMessages.Question(msg, "Confirm?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            DB.beginTransaction("ContractDelete");
                            if (!DeletePersonContract(DB))
                            {
                                DB.Rollback("ContractDelete");
                                return false;
                            }

                            JDocumentContract DC = new JDocumentContract();
                            DataTable Data = JDocumentsContract.GetAllData(Code, DB);
                            if(Data != null)
                            foreach (DataRow DR in Data.Rows)
                            {
                                DC.GetData((int)DR["Code"], DB);
                                if (!DC.delete(DB))
                                {
                                    DB.Rollback("ContractDelete");
                                    return false;
                                }
                            }

                            

                            JSubjectContractTable PDT = new JSubjectContractTable();
                            PDT.SetValueProperty(this);
                            if (PDT.Delete(DB))
                            {
                                //Delete Relation
                                JRelation tmpJRelation = new JRelation();
                                if (!tmpJRelation.CheckRelation("Legal.JSubjectContract", Code, DB))
                                    if (!tmpJRelation.Delete("Legal.JSubjectContract", Code, DB))
                                        return false;


                                ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                                AD.DeleteArchive("Legal.JContract", Code, false);
                                DB.Commit();
                                Nodes.Delete(Nodes.CurrentNode);
                                Histroy.Save(this, PDT, PDT.Code, "Delete");
                                return true;
                            }
                            else
                            {
                                DB.Rollback("ContractDelete");
                                return false;
                            }
                        }
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
                    if (pDB == null)
                    {
                        DB.Dispose();
                    }
                }
            }
            else
                JMessages.Error("قرارداد امضاء شده قابل حذف نیست", "Error");
            return false;
        }

        public bool DeletePersonContract(JDataBase pDB)
        {
            DataTable DataTable = JPersonContract.GetAllData(Code,pDB);
            JPersonContract Person = new JPersonContract();
            foreach (DataRow DR in DataTable.Rows)
            {
                Person.GetData((int)DR["Code"], pDB);
                if (!Person.delete(pDB))
                {
                    return false;

                }
            }
            return true;
        }

        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            return GetData(pCode, null);
        }
        public bool GetData(int pCode, JDataBase pDB)
        {
            JDataBase DB ;
            if (pDB == null)
                DB = new JDataBase();
            else
                DB = pDB;
            try
            {
                DB.setQuery(" SELECT *  FROM " + JTableNamesLegal.SubjectContract + 
                    " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    JContractdefine defineType= new JContractdefine(this.Type);
                    if (ContractType != null)
                        ContractType.Dispose();
                    ContractType = new JContractDynamicType(defineType.ContractType);
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
                {
                    DB.DataReader.Dispose();
                    DB.Dispose();
                }
            }
            return false;
        }

        public bool GetData(int pFinanceCode, int PContract)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string Query="SELECT * FROM " + JTableNamesLegal.SubjectContract + " WHERE FinanceCode=" + pFinanceCode.ToString();
                if (PContract > 0)
                    Query = Query + " Status=1 AND Type in (SELECT Code FROM legContractDynamicTypes s where s.AssetTransferType = " + PContract.ToString() + ")";
                DB.setQuery(Query);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    JContractdefine defineType = new JContractdefine(this.Type);
                    ContractType = new JContractDynamicType(defineType.ContractType);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        public static bool SetAsCurrentContract(int pFinanceCode, int pContractCode,int pAssetTransferType)
        {
            if (JMessages.Question("آیا میخواهید قرارداد انتخاب شده به عنوان قرارداد جاری قرار بگیرد؟", "تائید") == System.Windows.Forms.DialogResult.Yes)
            {
                JDataBase db = new JDataBase();
                try
                {
                    if (pAssetTransferType == Finance.JOwnershipType.Goodwill.GetHashCode())
                    {
                        /// همه قراردادهای سرقفلی، غیر فعال میشوند بجز فسخ شده ها
                        db.setQuery("UPDATE legSubjectContract Set Status = 4 Where FinanceCode = " + pFinanceCode.ToString() +
                            " AND Status <> " + JContractStatus.Canceled.GetHashCode().ToString() +
                            @" AND Type IN (SELECT Code From LegContractType WHERE ContractType IN 
                        (Select Code From legContractDynamicTypes WHERE AssetTransferType = 2))
                         UPDATE legSubjectContract Set Status = 1 Where Code =" + pContractCode.ToString());
                        return db.Query_Execute() >= 0;
                    }
                    if (pAssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode())
                    {
                        /// همه قراردادهای اجاره، غیر فعال میشوند بجز فسخ شده ها
                        db.setQuery("UPDATE legSubjectContract Set Status = 2 Where FinanceCode = " + pFinanceCode.ToString() +
                            " AND Status <> " + JContractStatus.Canceled.GetHashCode().ToString() +
                            @" AND Type IN (SELECT Code From LegContractType WHERE ContractType IN 
                        (Select Code From legContractDynamicTypes WHERE AssetTransferType = 3))
                         UPDATE legSubjectContract Set Status = 1 Where Code =" + pContractCode.ToString());
                        return db.Query_Execute() >= 0;
                    }
                }
                finally
                {
                    db.Dispose();
                }
                return false;
            }
            else return false;
        }
        /// <summary>
        /// بازیابی اطلاعات قرارداد قبلی
        /// </summary>
        /// <returns></returns>
        public JSubjectContract GetLastGoodwillContract()
        {
//            string Query = @"SELECT Top 1 * FROM [dbo].[vContracts] VC
//                    Inner join LegPersonContract PC on VC.Code =PC.ContractSubjectCode AND AssetTransferType = 2 
//                    AND VC.FinanceCode = " + FinanceCode.ToString() +
//                 @" AND PC.PersonCode = (Select PCode from estPrimaryOwnerBuild Where BuildCode = (Select ObjectCode from finAsset where ClassName = 'RealEstate.JUnitBuild' and ObjectCode = " + FinanceCode.ToString() + @"))
//                    Order By ContractDate Desc";
            string Query = @"SELECT Top 1 * FROM [dbo].[vContracts] VC
                    WHERE FinanceCode = " + FinanceCode.ToString() + " AND AssetTransferType = "+this.ContractType.AssetTransferType.GetHashCode().ToString()+
                    " Order By ContractDate Desc ";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                DataTable contract = db.Query_DataTable();
                return (new JSubjectContract(Convert.ToInt32(contract.Rows[0]["Code"])));
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


        /// <summary>
        /// جستجو نامه محضر 
        /// </summary>
        /// <returns></returns>
        public DataTable Search(DateTime EndDate)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string Exp = "";
                if (JDateTime.FarsiDate(Date) != "") Exp = Exp + " And Date Between @date And @date1 ";
                DB.Params.Add("@date", Date);
                DB.Params.Add("@date1", EndDate);
                //if (Result != "") Exp = Exp + " And Result Like '%" + Result + "%'";
                //if (Reasons != "") Exp = Exp + " And Like Reasons '%" + Reasons + "%'";
                //if (Subject != "")        Exp = Exp + " And Like Subject '%" + Subject + "%'";
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.SubjectContract + " N inner join legPetition P on P.Code=N.PetitionCode WHERE 1=1 " + Exp);
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

        public bool DisableContract(int pCode, JDataBase pDB)
        {
            GetData(pCode, pDB);
            if (this.Status == JContractStatus.Current)
            {
                Disabled = true;
                Status = JContractStatus.Disabled;
                return Update(pDB);
            }
            return true;
        }
        /// <summary>
        /// آخرین قرارداد بین شرکت و شخص (معمولا قرارداد اولیه تا زمانی 
        /// </summary>
        ///// <returns></returns>
        //public JSubjectContract LastContract()
        //{
        //        if (ContractType.AssetTransferType == Finance.JOwnershipType.Goodwill.GetHashCode())
        //        {
        //            string Query ="SELECT Code FROM LegSubjectContract WHERE 
        //        }
        //        else
        //            return null;
        //}

        public static int SearchLastContract(int pPCode, int pType)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"select Isnull(S.Code,0) 
From EmpPersonnelContract P left join LegSubjectContract S on S.Code=P.ContractCode inner join LegPersonContract PC
 on S.Code=PC.ContractSubjectCode where S.Status=1 And PC.PersonCode=" + pPCode + " And PC.Type=" + pType + " order by EndDate Desc ");
                return Convert.ToInt32(db.Query_ExecutSacler());
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion

        #region Nodes     

        public void ConfirmContract(int pContractType)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Legal.JSubjectContract.ConfirmContract", pContractType))
                {

                    Legal.JConfirmForm confirm = new Legal.JConfirmForm(this.Code);
                    confirm.ShowDialog();
                    if (FinanceCode != 0)
                    {
                        if (confirm.State == JFormState.Confirm)
                        {
                            DB.setQuery(@"update LegSubjectContract set LegSubjectContract.Status=4 where Code in (
                      select SC.Code from LegSubjectContract SC inner join  LegContractType CT on SC.Type = CT.Code inner join 
                      legContractDynamicTypes CDT on CDT.Code=CT.ContractType
                      where CDT.AssetTransferType=3 and SC.FinanceCode=" + FinanceCode.ToString() + " and SC.Code <> " + Code.ToString() + ")");
                            if (DB.Query_Execute() == 0)
                            {
                                DB.setQuery(@"update LegSubjectContract set LegSubjectContract.Status=4 where Code = " + PreContract.ToString());
                                DB.Query_Execute();
                            }
                        }
                    }
                    else
                    {
                        if (confirm.State == JFormState.Confirm)
                        {                            
                            DB.setQuery(@"update LegSubjectContract set LegSubjectContract.Status=4 where Code = " + PreContract.ToString());
                            DB.Query_Execute();
                        }
                    }
                    Nodes.Refreshdata(Nodes.CurrentNode, JSubjectContracts.GetDataTable(Code, Type).Rows[0]);
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// مفاسا حساب قرارداد
        /// </summary>
        public void PonyContract()
        {
            if (JPermission.CheckPermission("Legal.JSubjectContract.PonyContract",ContractType.Code))
            {
                JPonyForm disForm = new JPonyForm(this.Code);
                disForm.ShowDialog();
            }
        }

        /// <summary>
        /// فسخ قرارداد
        /// </summary>
        public void CancelContract()
        {
            if (JPermission.CheckPermission("Legal.JSubjectContract.CancelContract",ContractType.Code))
            {
                if (this.Status != JContractStatus.Current)
                {
                    JMessages.Error("فقط قراردادهای جاری قابل فسخ هستند.", "خطا");
                    return;
                }
                JCancelContractForm disForm = new JCancelContractForm(this.Code);
                disForm.ShowDialog();
            }
        }

        public void SearchDialog()
        {
            if (this.Code == 0)
            {
                JNoticeSearchFrom PE = new JNoticeSearchFrom();
                PE.ShowDialog();
            }
        }
        /// <summary>
        /// ایجاد متن مستقیم قرارداد
        /// </summary>
        #region Hassanzadeh
                
        public void CreateContractPrint()
        {
            try
            {
                //if (!(JPermission.CheckPermission("Estates.JGroundSheet.CreateContractPrint")))
                //    return;

                int _FileCode = 0;

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                OfficeWord.WinWordControl tmpWord = new OfficeWord.WinWordControl();
                foreach (DataRow dr in Nodes.Selected.Rows)// .DefaultView.Rows)
                {
                    //if (ClassLibrary.JAllPerson.CheckCodeMeli(dr["ShMeli"].ToString()))
                    //{
                    tmpSubjectContract.GetData(Convert.ToInt32(dr["Code"]));
                    _FileCode = tmpSubjectContract.FileCode;
                    if (true || _FileCode <= 0)
                    {
                        _FileCode = CreateContract(dr);
                    }

                    tmpWord.GetData(_FileCode);
                    tmpWord.LoadDocument();
                    //tmpWord.Print();
                    //}
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public int CreateContract(DataRow pDr)
        {
            try
            {
                int i = 0;
                DataTable dt = new DataTable();
                dt.Columns.Add("Code", typeof(int));
                dt.Columns.Add("i", typeof(int));

                Legal.JSubjectContract tmpSubjectContract = new Legal.JSubjectContract();
                Legal.JContractdefine tmpJContractdefine = new Legal.JContractdefine();
                Legal.JGeneralContract tmpGeneralContract = new Legal.JGeneralContract(-2, -2);

                DataRow dr = pDr;
                tmpSubjectContract.GetData(Convert.ToInt32(dr["Code"]));
                if (tmpJContractdefine.Code == 0)
                {
                    tmpJContractdefine.GetData(tmpSubjectContract.Type);
                    tmpGeneralContract.LoadForms(tmpJContractdefine.ContractType, tmpSubjectContract.Code, true);
                }
                tmpGeneralContract.GetData(tmpJContractdefine.ContractType, tmpSubjectContract.Code, 0, true);
                tmpGeneralContract.ContractForms.CreateWordContract();

                i++;
                Nodes.StatusStripMain.Items[0].Text = i.ToString();
                System.Windows.Forms.Application.DoEvents();
                JSystem.FreeObjectsDataReaer();
                return tmpGeneralContract.ContractForms.Contract.FileCode;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
        }

        #endregion

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "Legal.JSubjectContract");
            //// بازخوانی وضعیت قرارداد 
            //JContractStatus status = JContractStatus.None;
            //if (pRow["Status"] != null)
            //{
            //    int statusCode = Convert.ToInt32(pRow["Status"]);
            //    if (statusCode == JContractStatus.Current.GetHashCode())
            //        status = JContractStatus.Current;
            //    if (statusCode == JContractStatus.Canceled.GetHashCode())
            //        status = JContractStatus.Canceled;
            //    if (statusCode == JContractStatus.Expired.GetHashCode())
            //        status = JContractStatus.Expired;
            //    if (statusCode == JContractStatus.Disabled.GetHashCode())
            //        status = JContractStatus.Disabled;
            //}
            /////
            Nodes.hidColumns = "Date,StartDate,EndDate,DynamicType,TypeCode,FinanceCode,ContractType,AssetTransferType";
            if ((int)pRow["AssetTransferType"] == Finance.JOwnershipType.Other.GetHashCode())
                Nodes.hidColumns = Nodes.hidColumns + ", Price,PriceMonth, TotalPrice, RealPrice, GoodwillPrice ";
            if (pRow[JSubjectContractEnum.Confirmed.ToString()] != null && (bool)pRow[JSubjectContractEnum.Confirmed.ToString()])
                //node.Icone = JImageIndex.Add.GetHashCode();
                node.Icone = JImageIndex.ConfirmedContract.GetHashCode();
            else
                node.Icone = JImageIndex.Contract.GetHashCode();

            node.Name = JLanguages._Text("Number") + " " + pRow["ContractNo"].ToString();
            try
            {
                node.Hint = JLanguages._Text("Date:") + " " + pRow[LegSubjectContract.DateFa.ToString()] + "\n" +
                           JLanguages._Text("StartDate:") + " " + pRow[LegSubjectContract.StartDateFa.ToString()] + "\n" +
                           JLanguages._Text("EndDate:") + " " + pRow[LegSubjectContract.EndDateFa.ToString()] + "\n" +
                           JLanguages._Text("Status:") + " " + pRow["Status"];

                if (Convert.ToBoolean(pRow["Confirmed"]))
                {
                    //switch (status)
                    //{
                    //    case JContractStatus.Current:
                    //        node.Hint = node.Hint + "\n" + "وضعیت: جاری";
                    //        break;
                    //    case JContractStatus.Canceled:
                    //        node.Hint = node.Hint + "\n" + "وضعیت: فسخ شده";
                    //        break;
                    //    case JContractStatus.Expired:
                    //        node.Hint = node.Hint + "\n" + "وضعیت: منقضی شده";
                    //        break;
                    //    case JContractStatus.Disabled:
                    //        node.Hint = node.Hint + "\n" + "وضعیت: غیر فعال شده";
                    //        break;
                    //}
                }
                else
                    node.Hint = node.Hint + "\n" + "وضعیت: امضاء نشده";
            }
            catch (Exception ex)
            {
                node.Hint = "";
            }
            /// اکشن ویرایش
            //JSubjectContract contract = new JSubjectContract(node.Code);
            JAction editAction = new JAction("Edit...", "Legal.JGeneralContract.ShowForms", null, new object[] { Convert.ToInt32(pRow["DynamicType"]), node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            //if (Convert.ToBoolean(pRow["Confirmed"]))
              //  editAction.Enabled = false;
            /// اکشن مشاهده
            JAction viewAction = new JAction("View...", "Legal.JGeneralContract.ShowForms", null, new object[] { Convert.ToInt32(pRow["DynamicType"]), node.Code, true });
            node.MouseDBClickAction = viewAction;
            node.EnterClickAction = viewAction;

            /// اکشن فسخ قرارداد
            JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { node.Code });
            if (!Convert.ToBoolean(pRow["Confirmed"]))
                CancelAction.Enabled = false;

            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JSubjectContract.delete", null, new object[] { node.Code });
            JAction deleteActionAll = new JAction("DeleteAll...", "Legal.JSubjectContract.delete", new object[] { true , null}, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            
            /// اکشن تائید قرارداد
            JAction confirmAction = new JAction("ConfirmContract...", "Legal.JSubjectContract.ConfirmContract",  new object[] { Convert.ToInt32(pRow["DynamicType"])}, new object[] { node.Code });

            /// اکشن مفاسا حساب قرارداد
            JAction PonyAction = new JAction("Pony...", "Legal.JSubjectContract.PonyContract", null, new object[] { node.Code });

            /// اکشن اصلاح قرارداد
            JAction ReapirAction = new JAction("RepairContract...", "Legal.JRepairContractForm.Show", null, new object[] { node.Code });

            ///نامه های محضر
            JAction OfficeLetters = new JAction("RegistryOfficeLetters...", "Legal.JRegistryOfficeLetter.ShowListForm", new object[] { node.Code }, null);

            ///نامه های محضر
            JAction CancellationContract = new JAction("CancellationContract...", "Legal.Contract.Forms.Documents.JChangeDocumentsForm.Show", null , new object[] { node.Code });

            node.Popup.Insert(OfficeLetters);
            node.Popup.Insert(ReapirAction);
            node.Popup.Insert(PonyAction);
            node.Popup.Insert(CancelAction);
            node.Popup.Insert(confirmAction);
            node.Popup.Insert("-");
            node.Popup.Insert(OfficeWord.JWordForm.getAction("Legal.JContractForms", node.Code, true));
            node.Popup.Insert("-");
            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(viewAction);
            node.Popup.Insert(CancellationContract);
            if(JMainFrame.IsAdmin)
                node.Popup.Insert(deleteActionAll);


            return node;
        }
        #endregion
    }

    public class JSubjectContracts : JSystem
    {
        public JSubjectContracts[] Items = new JSubjectContracts[0];
        //  public String OrderName;
        public JSubjectContracts()
        {
            // OrderName = "Fam";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0,0);
        }
        public static DataTable GetDataTable(int pCode, int pContractType)
        {
            return GetDataTable(pCode, pContractType, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode, int pContractType, JDataBase pDB)
        {
            JDataBase DB;
            if (pDB != null)
                DB = pDB;
            else
                DB = JGlobal.MainFrame.GetDBO();
            try
            {
                JContractDynamicType dynamicType = new JContractDynamicType(pContractType);
                string AssetSQL = 
					@" 		 ,(select top 1 Name from clsAllPerson Where Code in (select lc1.PersonCode from LegPersonContract LC1 where Type=7 and  lc1.ContractSubjectCode = a.Code ) ) NameIn
					,(select top 1 Name from clsAllPerson Where Code in (select lc1.PersonCode from LegPersonContract LC1 where Type=9 and  lc1.ContractSubjectCode = a.Code ) ) NameOut
					,(select Comment from FinAsset where Code = a.FinanceCode) CommentFCode"+

					Finance.JAssetType.GetAssetSQL(dynamicType.ClassName);
                string Query = "SELECT A.* " + AssetSQL + " FROM (" + JSubjectContract.Query + " ) A" +
                                          @" LEFT  Join finAsset on FinanceCode = finAsset.Code WHERE  1=1 ";
                if (pCode != 0)
                    Query = Query + " AND A.Code = " + pCode;
                if (pContractType != 0)
                    Query = Query + "AND ContractType  = " + pContractType.ToString();
                Query = Query + " And " + JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "ContractType");
                /// اضافه کردن اطلاعات دارایی
                DB.setQuery(Query);
                //DB.setQuery(WHERE + " And " + JPermission.getObjectSql("Legal.JContractdefines.GetDataTable" , "legContractType.Code"));
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
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
        /// <returns></returns>
        public static DataTable GetDataTable(Finance.JOwnershipType pOwnershipType, JDataBase pDB)
        {
            JDataBase DB;
            if (pDB != null)
                DB = pDB;
            else
                DB = JGlobal.MainFrame.GetDBO();
            try
            {
                JContractDynamicType dynamicType = new JContractDynamicType(0);
                string AssetSQL = Finance.JAssetType.GetAssetSQL(dynamicType.ClassName);
                string Query = "SELECT A.* " + AssetSQL + " FROM (" + JSubjectContract.Query + " ) A" +
                                          @" LEFT  Join finAsset on FinanceCode = finAsset.Code WHERE  1=1 ";
                Query = Query + " AND AssetTransferType  = " + pOwnershipType.GetHashCode().ToString();
                Query = Query + " AND " + JPermission.getObjectSql("Legal.JContractDynamicTypes.GetDataTable", "ContractType");
                /// اضافه کردن اطلاعات دارایی
                DB.setQuery(Query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }
        /// <summary>
        /// تمام قراردادهای یک دارایی را برمیگرداند  - تائید شده یا تائید نشده
        /// </summary>
        /// <param name="pFinanceCode"></param>
        /// <returns></returns>
        public static DataTable GetFinance(int pFinanceCode, bool pConfirmed)
        {
            string WHERE = "SELECT * FROM " + JTableNamesLegal.SubjectContract;
            if (pFinanceCode != 0)
                WHERE = WHERE + " WHERE " + JSubjectContractEnum.FinanceCode.ToString() + " = " + pFinanceCode.ToString();
            else
                WHERE = WHERE + " WHERE 1=0";
            WHERE = WHERE + " AND " + JSubjectContractEnum.Confirmed.ToString() + "=" + JDataBase.Quote(pConfirmed.ToString());
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(WHERE);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable ContractHistory(int pFinanceCode, Finance.JOwnershipType pAssetTransferType)
        {
            return ContractHistory(pFinanceCode, pAssetTransferType, false);
        }
        public static DataTable ContractHistory(int pFinanceCode, Finance.JOwnershipType pAssetTransferType, bool CurrentContracts)
        {
            int seller = ClassLibrary.Domains.Legal.JPersonPetitionType.Seller.GetHashCode();
            int buyer = ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer.GetHashCode();
            string strSeller = "فروشنده";
            string strBuyer = "خریدار";
            if (pAssetTransferType == Finance.JOwnershipType.Rentals)
            {
                strSeller = "موجر";
                strBuyer = "مستاجر";
            }
            string Query = @" Select   Case  PC.Type when " + seller.ToString() + @" then '" + strSeller + "'  when " +
                                                            buyer.ToString() + @" then '" + strBuyer + @"' else '' end PersonParty
             , PA.Name, PC.Share, Pa.Address, PA.Tel
             , SC.Number ContractNo,
             ( Select Fa_Date from StaticDates Where En_Date =  Cast(SC.Date as Date) )ContractDate,
             ( Select Fa_Date from StaticDates Where En_Date =  Cast(SC.StartDate as Date)) StartDate, 
             ( Select Fa_Date from StaticDates Where En_Date =  Cast(SC.EndDate as Date)) EndDate,
             ( Select Fa_Date from StaticDates Where En_Date =  Cast(SC.DateDeliver as Date)) DateDeliver
             , SC.TotalPrice,(Select Name From subDefine where Code = SC.Job) Job , SC.Price, SC.PriceMonth, SC.GoodwillPrice,
             Case [Status]
	                        when 0 then ''
	                        when 1 then N'جاری'
	                        when 2 then N'اتمام'
	                        when 3 then N'فسخ شده'
	                        when 4 then N'غیر فعال'
	                        else '' end StatusTitle
            , PC.PersonCode ,SC.Code ContractCode           
             , (Select Title From vContracts Where Code = SC.Code ) ContractType
            from LegSubjectContract SC 
	            inner join LegContractType LT on SC.Type = LT.Code 
	            inner join legContractDynamicTypes LDT on LT.ContractType = LDT.Code	
	            inner join LegPersonContract PC on SC.Code= PC.ContractSubjectCode
	            left join PersonAddressView PA on PC .PersonCode = PA.Code where 1=1 ";
            if (pAssetTransferType != Finance.JOwnershipType.None)
                Query = Query + " AND  AssetTransferType =  " + pAssetTransferType.GetHashCode().ToString();
            if (pAssetTransferType != Finance.JOwnershipType.Rentals && pAssetTransferType != Finance.JOwnershipType.GoodwillPeace && pAssetTransferType != Finance.JOwnershipType.Other)
                Query = Query + " AND PC.Share>0 ";
            if (CurrentContracts)
                Query = Query + " AND  Status = 1 ";

            Query = Query + " and SC.FinanceCode = " + pFinanceCode.ToString() +
            " Order by SC.Date , PC.Type ";

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable PersonContractHistory(int pPersonCode)
        {
            int sellerType = ClassLibrary.Domains.Legal.JPersonPetitionType.Seller;
            int buyerType = ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer;
            int buyerAdType = ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate;
            int sellerAdType = ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate;
            int intuitionType = ClassLibrary.Domains.Legal.JPersonPetitionType.intuition;
            JDataBase db = new JDataBase();
            string Query = @"Select 
            Case PC.Type 
	            when " + sellerType.ToString() + @" then 
	            (Select Top 1 SettingValue  from legContractTypeSettings where ContractTypeCode = CDT.Code  and SettingName = 'T1Lable')
	            when " + sellerAdType.ToString() + @" then N'وکیل طرف اول'	
	            when " + buyerType.ToString() + @" then 		
	            (Select Top 1 SettingValue  from legContractTypeSettings where ContractTypeCode = CDT.Code  and SettingName = 'T2Lable')
	            when " + buyerAdType.ToString() + @" then N'وکیل طرف دوم'
	            when " + intuitionType.ToString() + @" then N'شهود'
	            else '' end PersonParty,
                CDT.Title, (Select Fa_date from StaticDates where En_Date = Cast(SC.Date as Date)) ContractDate,SC.Number ContractNo,
                PC.Share ,  Case  SC.Status 
                When 0 then ''
                When 1 then 'جاری'
                When 2 then 'اتمام'
                When 3 then 'فسخ شده'
                When 4 then 'غیر فعال'
                end Status, FA.Comment
	            ,SC.Code ContractCode, FA.ClassName, FA.ObjectCode
            from LegPersonContract  PC
	            inner join legSubjectContract SC on PC.ContractSubjectCode= SC.Code and PC.Type 
                IN(" + sellerType.ToString() + "," + buyerType.ToString() + "," + buyerAdType.ToString() + "," + sellerAdType.ToString() + "," + intuitionType.ToString() + @")
	            inner join LegContractType CT on SC.Type = CT.Code 
	            inner join legContractDynamicTypes CDT on CDT.Code = CT.ContractType
	            inner join finAsset FA on SC.FinanceCode = FA.Code
	            where SC.Confirmed = 1 AND PC.PersonCode = " + pPersonCode.ToString() +
                "Order By SC.Date ";
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// تمام قراردادهای تائید نشده را برمیگرداند
        /// </summary>
        /// <param name="pFinanceCode"></param>
        /// <returns></returns>
        //public static DataTable GetFinance(int pFinanceCode)
        //{
        //    return GetFinance(pFinanceCode, false);
        //}

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetNotice", "Legal.JSubjectContract.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JSubjectContract.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            JAction SearchAction = new JAction("Search...", "Legal.JSubjectContract.SearchDialog", null, null);
            Nodes.GlobalMenuActions.Insert(SearchAction);
            JToolbarNode TNS = new JToolbarNode();
            TNS.Icon = JImageIndex.Search;
            TNS.Hint = "Search...";
            TNS.Click = SearchAction;
            Nodes.AddToolbar(TNS);
            //ListView(OrderName, "");            
        }

        
    }

    public enum DocumentType
    {
        /// <summary>
        /// چک -  -  -  -  -  -  -  - - 
        /// </summary>
        Cheque = 1,
        /// <summary>
        /// سفته
        /// </summary>
        PromissoryNote = 2,
        /// <summary>
        /// فیش
        /// </summary>
        Fish = 3,
    }

    
    /// <summary>
    ///  پیکره بندی قرار داد
    /// </summary>
    public class JContractSettings
    {
        //طرفین قرارداد
        #region Paties
        /// <summary>
        /// عنوان فرم طرفین قرارداد
        /// </summary>
        public string PatiesFormName = "";
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName = "";
        ///// <summary>
        ///// اشخاص حقیق باشد
        ///// </summary>
        //public bool T1HasRealPerson = true;
        ///// <summary>
        ///// اشخاص حقوقی باشد
        ///// </summary>
        //public bool T1HasLegalPerson = true;
        /// <summary>
        /// نوع شخص طرف اول
        /// </summary>
        public JPersonTypes T1PersonType;

        /// <summary>
        /// وکیل داشته باشد
        /// </summary>
        public bool T1HasAdvocacy = true;
        /// <summary>
        /// میزان سهم مشخص گردد
        /// </summary>
        public bool T1HasValue = true;
        /// <summary>
        /// عنوان طرف اول
        /// </summary>
        public string T1Lable = "T1";

        ///// <summary>
        ///// اشخاص حقیق باشد
        ///// </summary>
        //public bool T2HasRealPerson = true;
        ///// <summary>
        ///// اشخاص حقوقی باشد
        ///// </summary>
        //public bool T2HasLegalPerson = true;
        /// <summary>
        /// نوع شخص طرف دوم
        /// </summary>
        public JPersonTypes T2PersonType;
        /// <summary>
        /// وکیل داشته باشد
        /// </summary>
        public bool T2HasAdvocacy = true;
        /// <summary>
        /// میزان سهم مشخص گردد
        /// </summary>
        public bool T2HasValue = true;
        /// <summary>
        /// عنوان طرف دوم
        /// </summary>
        public string T2Lable = "T2";
        /// <summary>
        /// شاهد داشته باشد
        /// </summary>
        public bool HasIntuition = true;
        /// <summary>
        /// شاهد اجباری است 
        /// </summary>
        public bool HasForcedwitness = true;
        /// <summary>
        /// حداقل تعداد شاهد
        /// </summary>
        public int WitnessCount = 0;
        #endregion
    }
   
    ///// <summary>
    ///// طرفین قرارداد
    ///// </summary>
    //class JPartiesToTheContract
    //{
    //    int[] BuyerCode;
    //    int[] SellerCode;
    //}
}
