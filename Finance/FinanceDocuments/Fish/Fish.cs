using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace Finance
{
    public class JFish : JFinance
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره حساب
        /// </summary>
        public string Accountnumber { get; set; }
        /// <summary>
        /// کد بانک
        /// </summary>
        public int Bank_Code { get; set; }
        /// <summary>
        /// کد شعبه
        /// </summary>
        public int branch_Code { get; set; }
        /// <summary>
        /// شماره چک
        /// </summary>
        public string Serial_No { get; set; }
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime PaymentDate { get; set; }
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
        public int ConcernForm { get; set; }

        public int City { get; set; }

        public int State { get; set; }

        public int Acc1 { get; set; }
        public int Acc2 { get; set; }
        public int Acc3 { get; set; }
        public string ConcernSerial { get; set; }

        public int Form { get; set; }
        public int Serial { get; set; }
        public int FormId { get; set; }
        public int ItemNo { get; set; }
        public int CompanyId { get; set; }
        public int FormDtlId { get; set; }
        public int Status { get; set; }
        public int PersonGroup { get; set; }

        #endregion

        #region سازنده

        public JFish()
        {
        }
        public JFish(int pCode)
        {
            Code = pCode;
            GetData(Code);
        }
        #endregion

        public void SendToNamaad()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("Form"); // کد فرم یعنی دریافت پرداخت ابطال و تعدیل NamdFormType
            DT.Columns.Add("PersonGroup"); //گروه شخص بصورت داینامیک که در اصل همان کد پروژه است
            DT.Columns.Add("PersonNo"); // کد تفصیلی شخص
            DT.Columns.Add("MainConcernCode"); //بابت
            DT.Columns.Add("ConncernCode"); // بابت و با مقدار بالایی یکی است
            DT.Columns.Add("ConcernForm"); //  فرم بابت
            DT.Columns.Add("ConcernSerial");//سریال بابت
            DT.Columns.Add("DtlClassCode1");// اقلام دسته
            DT.Columns.Add("DtlClassCode2");// اقلام دسته
            DT.Columns.Add("DtlClassCode3");// اقلام دسته
            DT.Columns.Add("DocNo"); // شماره سند همان شماره چک و شماره فیش است
            DT.Columns.Add("DocDate"); // تاریخ چک یا فیش
            DT.Columns.Add("DocType"); // چک فیش یا تعدیل(قرارداد)
            DT.Columns.Add("Amount"); // مبلغ
            DT.Columns.Add("DescriptionHdr"); // شرح هدر
            DT.Columns.Add("DescriptionDtl");// شرح دیتیل
            DT.Columns.Add("DocProvince"); // استان
            DT.Columns.Add("DocCity"); // شهر
            DT.Columns.Add("DocBankNo"); // بانک
            DT.Columns.Add("DocBranchNo"); //کد شعبه
            DT.Columns.Add("DocBranchName");// نام شعبه
            DT.Columns.Add("DocAccountNo");// شماره حساب
            DT.Columns.Add("ResourceId"); // آی دی منبع منظور ها بانکه یا صندو قها یا تنخواه گردانها
            DT.Columns.Add("EffectDate"); // تاری خو ماثر
            DT.Columns.Add("CreateDate");
            DT.Columns.Add("CreateUser");
            DT.Columns.Add("ChangeDate");
            DT.Columns.Add("ChangeUser");

            DataRow N = DT.NewRow();
            N["Form"] = Legal.NamaadFormType.ResidDaryaft.GetHashCode();
            N["PersonGroup"] = PersonGroup;// برای هر پروژه امکان تعریف یک کد باشد
            N["PersonNo"] = ExporterCode;
            N["MainConcernCode"] = Concern;
            N["ConncernCode"] = Concern;
            N["ConcernForm"] = Form;
            N["ConcernSerial"] = Serial;
            N["DtlClassCode1"] = Acc1;
            N["DtlClassCode2"] = Acc2;
            N["DtlClassCode3"] = Acc3;
            N["DocNo"] = 0;
            N["DocDate"] = JDateTime.FarsiDate(PaymentDate).Replace("/", "").Substring(0, 8);
            N["DocType"] = Legal.NamaadDocType.Fish.GetHashCode();
            N["Amount"] = Price;
            N["DescriptionHdr"] = Description;
            N["DescriptionDtl"] = Description;
            N["DocProvince"] = 0;
            N["DocCity"] = 0;
            N["DocBankNo"] = 0;
            N["DocBranchNo"] = 0;
            N["DocBranchName"] = branch_Code;
            N["DocAccountNo"] = 0;
            N["ResourceId"] = Bank_Code;
            N["EffectDate"] = JDateTime.FarsiDate(Create_Date).Replace("/", "").Substring(0, 8);
            N["CreateDate"] = JDateTime.FarsiDate(DateTime.Now).Replace("/", "").Substring(0, 8);
            N["CreateUser"] = 1;
            N["ChangeDate"] = JDateTime.FarsiDate(DateTime.Now).Replace("/", "").Substring(0, 8);
            N["ChangeUser"] = 1;

            DT.Rows.Add(N);
            
            //baharehsedaqat@gmail.com
            //امور مالی طبقات
            try
            {
                JDataBase DB = new JDataBase();
                SqlCommand insertCommand = new SqlCommand(
                    "Trs_Insert", DB.Connection);
                insertCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter tvpParam = insertCommand.Parameters.AddWithValue(
                    "@List", DT);
                tvpParam.SqlDbType = SqlDbType.Structured;

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(insertCommand);
                adapter.Fill(dt);

                Form = int.Parse(dt.Rows[0]["Form"].ToString());
                Serial = int.Parse(dt.Rows[0]["Serial"].ToString());
                FormId = int.Parse(dt.Rows[0]["FormId"].ToString());
                ItemNo = int.Parse(dt.Rows[0]["ItemNo"].ToString());
                CompanyId = int.Parse(dt.Rows[0]["CompanyId"].ToString());
                FormDtlId = int.Parse(dt.Rows[0]["FormDtlId"].ToString());
                Status = 1;
                Update(DB);
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
    

    private Legal.JDocumentContract FishToDoc(JFish pFish)
        {
            Legal.JDocumentContract doc = new Legal.JDocumentContract();
            doc.ClassName = "Finance.JFish";
            doc.ObjectCode = pFish.Code;
            doc.Price = pFish.Price;
            doc.Number = pFish.Serial_No;
            //JSubBaseDefine Bank = new JSubBaseDefine(pFish.Bank_Code);
            //JSubBaseDefine tmpConcern = new JSubBaseDefine(0, pFish.Concern);
            //doc.Concern = tmpConcern.Name;
            //JSubBaseDefine Branch = new JSubBaseDefine(0, pFish.branch_Code);
            string tmpDate = "";
            string[] str;
            if (DateTime.MinValue != pFish.PaymentDate)
            {
                str = JDateTime.FarsiDate(pFish.PaymentDate).ToString().Split('/');
                tmpDate = str[str.Length - 1].ToString() + "/" + str[str.Length - 2].ToString() + "/" + str[str.Length - 3].ToString();
                //JDateTime.FarsiDate(form.Cheque.Issue_Date).ToString();
            }
            string strDesc = "";
            if (pFish.Description != "")
                strDesc = " توضیحات: " + pFish.Description;
            doc.ContractText = "فیش به شماره " + pFish.Serial_No +
                " مبلغ " + JMoney.StringToMoney(pFish.Price.ToString()) + CurrencyString
                + "(" + JMoney.NumberToString(pFish.Price.ToString()) + CurrencyString + ")" +
//                " بانک " + Bank.Name +
//                " شعبه " + Branch.Name +
//                " تاریخ " + tmpDate +// " بابت " + tmpConcern.Name +
//                " شماره حساب " + pFish.Accountnumber.ToString() +
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
            JFish fish = new JFish(pCode);
            return FishToDoc(fish);
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
                            Bank_Code = Convert.ToInt32(dr["Bank_Code"]);
                            branch_Code = Convert.ToInt32(dr["branch_Code"]);
                            Create_Date = Convert.ToDateTime(dr["Create_Date"]);
                            Price = Convert.ToDecimal(dr["Price"]);
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
            JFishTable PDT = new JFishTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JFish.Insert"))
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
            JFishTable PDT = new JFishTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JFish.Update"))
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
            return delete(DB,pCode);
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
            JFishTable PDT = new JFishTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JFish.Delete"))
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
            JFishTable PDT = new JFishTable();
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
                DB.setQuery("SELECT * FROM " + JTableNamesFinance.Fish + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT * FROM " + JTableNamesFinance.Fish + " WHERE ContractSubjectCode="
                    + pContractSubjectCode.ToString() + " And " + 
                    JPermission.getObjectSql("Finance.JFish.GetDataTable"));
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
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesFinance.Fish + " A inner join clsAllPerson P on A.ExporterCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString()+ " And " + JPermission.getObjectSql("Finance.JFish.GetDataTable"));
                else
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesFinance.Fish + " A inner join clsAllPerson P on A.ReceiverCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString()+ " And " + JPermission.getObjectSql("Finance.JFish.GetDataTable"));
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
    
        //public string GetContractText()
        //{
        //    JSubBaseDefine Bank = new JSubBaseDefine(Bank_Code);
        //    return "فیش به شماره " + this.Serial_No + " مبلغ " + Price.ToString() + " بانک " + Bank.Name + " تاریخ " + JDateTime.FarsiDate(PaymentDate).ToString();
        //}
        public Legal.JDocumentContract ShowDialog(String pPropClassName)
        {
            return ShowDialog(0, 0, pPropClassName,0,0,0,DateTime.Now,0,0,0,0);
        }

        public Legal.JDocumentContract ShowDialog(int pExporter, int pReciver, String pPropClassName, int pLocation, int pForm, int pConcern, DateTime pDate, int pSerial, int pDtl1, int pDtl2, int pDtl3)
        {
            if (this.Code == 0)
            {
                JFishForm form = new JFishForm(pExporter, pReciver);
                form.State = JFormState.Insert;
                form._PersonGroup = pLocation;
                form.txtAcc1.Text = pDtl1.ToString();
                form.txtAcc2.Text = pDtl2.ToString();
                form.txtAcc3.Text = pDtl3.ToString();
                form.cmbForm.SelectedValue = pForm;
                form.txtSerial.Text = pSerial.ToString();
                form.txtDateRecieve.Date = pDate;
                form._ConcernCode = pConcern;
                form.ShowDialog();
                return FishToDoc(form.Fish);
            }
            else
            {
                JFishForm form = new JFishForm(Code);
                form.State = JFormState.Update;
                form.ShowDialog();
                return FishToDoc(form.Fish);
            }
        }
        public DataTable FieldList(int[] pCode)
        {
            string _SelectQuery =
            @"SELECT  " +
             "S.Name As 'Fish.Concern' ," +
             "S2.Name As 'Fish.Bank' ," +
             "S3.Name As 'Fish.Branch' ," +
             "F.Serial_No As 'Fish.Serial_No' ," +
             "F.Create_Date As 'Fish.Create_Date' ," +
             "F.PaymentDate As 'Fish.PaymentDate' ," +
             "F.Price As 'Fish.Price' ," +
             "P1.Name As 'Fish.ReceiverName' ," +
             "P2.Name As 'Fish.ExporterName' ," +
             "F.Accountnumber As 'Fish.Accountnumber' ," +
             "F.Description As 'Fish.Description' " +
             " From " + JTableNamesFinance.Fish +
             " F inner join clsAllPerson P1 on F.ReceiverCode = P1.Code " +
             "  inner join clsAllPerson P2 on F.ExporterCode = P2.Code " +
             "  inner join Subdefine S on F.Concern = S.Code And S.bcode=" + ClassLibrary.JBaseDefine.ConcernType.ToString() +
             "  inner join Subdefine S2 on F.Bank_Code = S2.Code And S2.bcode=" + ClassLibrary.JBaseDefine.BankTypes.ToString() +
             "  inner join Subdefine S3 on F.branch_Code = S3.Code And S3.bcode=" + ClassLibrary.JBaseDefine.BranchTypes.ToString();

            JDataBase Db = new JDataBase();
                Db.setQuery(_SelectQuery + " Where F.Code in " + JDataBase.GetInSQLClause(pCode));
            return Db.Query_DataTable();
        }
    }
    }
