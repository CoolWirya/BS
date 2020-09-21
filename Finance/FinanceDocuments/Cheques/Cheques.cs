using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;
using System.Data.SqlClient;

namespace Finance
{
    public class JCheque : JFinance
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد بانک
        /// </summary>
        public int Bank_Code { get; set; }
        /// <summary>
        ///  شعبه
        /// </summary>
        public int branch_Code { get; set; }
        /// <summary>
        /// کد شعبه
        /// </summary>
        public int branch_Number { get; set; }
        /// <summary>
        /// شماره چک
        /// </summary>
        public string Cheque_No { get; set; }
        /// <summary>
        /// تاریخ تحویل
        /// </summary>
        public DateTime Create_Date { get; set; }
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime Issue_Date { get; set; }
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
        /// پشت نویسی
        /// </summary>
        public string Back_Note { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// تاریخ برگشت
        /// </summary>
        public DateTime Return_Date { get; set; }
        /// <summary>
        /// تاریخ پاس
        /// </summary>
        public DateTime Pass_Date { get; set; }
        /// <summary>
        /// بابت
        /// </summary>
        public int Concern { get; set; }
        /// <summary>
        /// شماره حساب
        /// </summary>
        public string AccountNo { get; set; }
        #endregion

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
        #region سازنده

        public JCheque()
        {
        }
        public JCheque(int pCode)
        {
            Code = pCode;
            GetData(Code);
        }
        #endregion

        /// <summary>
        /// تبدیل کلاس چک به یک سند قابل استفاده در قرارداد
        /// </summary>
        /// <param name="pCheque"></param>
        /// <returns></returns>
        public Legal.JDocumentContract ChequeToDoc(JCheque pCheque)
        {
            if (pCheque == null)
                return null;

            JDataBase DB = new JDataBase();
            DB.setQuery("select Code,Name from dbo.Trs_View_Banks where Code = "+pCheque.Bank_Code);
            DataTable DT = DB.Query_DataTable();
            string BankName = "";
            if (DT.Rows.Count >= 1)
                BankName = DT.Rows[0]["Name"].ToString();

            DB.setQuery("select * from Trs_View_FormConcern where Code = " + pCheque.ConcernForm);
            DT = DB.Query_DataTable();
            string ConcernName = "";
            if (DT.Rows.Count >= 1)
                ConcernName = DT.Rows[0]["Name"].ToString();
            DB.Dispose();

            Legal.JDocumentContract DocumentContract = new Legal.JDocumentContract();
            DocumentContract.ClassName = "Finance.JCheque";
            DocumentContract.ObjectCode = pCheque.Code;
            DocumentContract.Price = pCheque.Price;
            DocumentContract.Number = pCheque.Cheque_No;
            DocumentContract.Concern = ConcernName;
            JSubBaseDefine Branch = new JSubBaseDefine(0, pCheque.branch_Code);
            string tmpDate = " تاریخ ";
            string[] str;
            if (DateTime.MinValue != pCheque.Issue_Date)
            {
                str = JDateTime.FarsiDate(pCheque.Issue_Date).ToString().Split('/');
                tmpDate = tmpDate + str[str.Length - 1].ToString() + "/" + str[str.Length - 2].ToString() + "/" + str[str.Length - 3].ToString();
                //JDateTime.FarsiDate(pCheque.Issue_Date).ToString();
            }
            else
                tmpDate = "";// " بدون " + tmpDate;
            string strDesc = "";
            if (pCheque.Description != "")
                strDesc = " توضیحات: " + pCheque.Description;
            DocumentContract.ContractText = "- چک به شماره " + pCheque.Cheque_No +
                " مبلغ " + JMoney.StringToMoney(pCheque.Price.ToString()) + CurrencyString +
                "(" + JMoney.NumberToString(pCheque.Price.ToString()) + CurrencyString + ")" +
                " بانک " + BankName +
                " شعبه " + Branch.Name +
                tmpDate;

            if (pCheque.AccountNo.ToString().Length > 1)
                DocumentContract.ContractText +=
                " شماره حساب " + pCheque.AccountNo.ToString(); //" بابت " + tmpConcern.Name +                
            DocumentContract.ContractText += strDesc;
            return DocumentContract;
        }
        /// <summary>
        /// تبدیل کلاس چک به یک سند قابل استفاده در قرارداد
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Legal.JDocumentContract GetDocumentContract(int pCode)
        {
            JCheque pCheque = new JCheque(pCode);
            return ChequeToDoc(pCheque);
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
                            Cheque_No = (dr["Cheque_No"]).ToString();
                            Create_Date = Convert.ToDateTime(dr["Create_Date"]);
                            Issue_Date = Convert.ToDateTime(dr["Issue_Date"]);
                            Price = Convert.ToInt32(dr["Price"]);
                            ReceiverCode = Convert.ToInt32(dr["ReceiverCode"]);
                            ExporterCode = Convert.ToInt32(dr["ExporterCode"]);
                            Back_Note = dr["Back_Note"].ToString();
                            Description = dr["Description"].ToString();
                            Return_Date = Convert.ToDateTime(dr["Return_Date"]);
                            Pass_Date = Convert.ToDateTime(dr["Pass_Date"]);
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
            JChequesTable PDT = new JChequesTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JCheque.Insert"))
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
            JChequesTable PDT = new JChequesTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JCheque.Update"))
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
            JChequesTable PDT = new JChequesTable();
            try
            {
                if (JPermission.CheckPermission("Finance.JCheque.Delete"))
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
                DB.setQuery("SELECT * FROM " + JTableNamesFinance.Cheques + " WHERE Code=" + pCode.ToString());
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
                DB.setQuery("SELECT * FROM " + JTableNamesFinance.Cheques + " WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JCheque.GetDataTable"));
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
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesFinance.Cheques + " A inner join clsAllPerson P on A.ExporterCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JCheque.GetDataTable"));
                else
                    DB.setQuery("SELECT A.Code,P.Code PersonCode,Name,PersonType FROM " + JTableNamesFinance.Cheques + " A inner join clsAllPerson P on A.ReceiverCode = P.Code WHERE ContractSubjectCode=" + pContractSubjectCode.ToString() + " And " + JPermission.getObjectSql("Finance.JCheque.GetDataTable"));
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
            //DataTable tmpdt = new DataTable();
            //tmpdt = Db.Query_DataTable();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("name");
            //dt.Columns.Add("text");
            //for (int i = 0; i < tmpdt.Columns.Count; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["name"] = tmpdt.Columns[i].Caption;
            //    dr["text"] = JLanguages._Text(tmpdt.Columns[i].Caption);
            //    dt.Rows.Add(dr);
            //}
            //return tmpdt;
        }

        //public string GetContractText()
        //{
        //   JSubBaseDefine Bank = new JSubBaseDefine(Bank_Code);
        //   return   "چک به شماره " + this.Cheque_No + " مبلغ " + Price.ToString() + " بانک " + Bank.Name + " تاریخ " + JDateTime.FarsiDate(Issue_Date).ToString();
        //}

        public Legal.JDocumentContract ShowDialog(String pPropClassName)
        {
            return ShowDialog(0, 0, pPropClassName, 0, 0, 0, DateTime.Now, 0, 0, 0, 0);
        }


        //pExporter, pReciever, pPropClassName, pLocation,pForm,pDate,pSerial,pDtl1,pDtl2,pDtl3
        public Legal.JDocumentContract ShowDialog(int pExporter, int pReciver, String pPropClassName, int pLocation, int pForm, int pConcern
            , DateTime pDate, int pSerial
            , int pDtl1, int pDtl2, int pDtl3)
        {
            if (this.Code == 0)
            {
                JChequesForm form = new JChequesForm(pExporter, pReciver);
                form.State = JFormState.Insert;
                if (pPropClassName.Length > 0)
                    form.PropertyClassName = pPropClassName;
                form._PersonGroup = pLocation;
                form.txtAcc1.Text = pDtl1.ToString();
                form.txtAcc2.Text = pDtl2.ToString();
                form.txtAcc3.Text = pDtl3.ToString();
                form.cmbForm.SelectedValue = pForm;
                form.txtSerial.Text = pSerial.ToString();
                form.txtDateRecieve.Date = pDate;
                form._ConcernCode = pConcern;
                form.ShowDialog();
                return ChequeToDoc(form.Cheque);
            }
            else
            {
                JChequesForm form = new JChequesForm(Code);
                form.State = JFormState.Update;
                if (pPropClassName.Length > 0)
                    form.PropertyClassName = pPropClassName;
                form.ShowDialog();
                return ChequeToDoc(form.Cheque);
            }
        }
        public static JCheque Show()
        {
            JChequesForm CF = new JChequesForm();
            CF.Cheque = new JCheque();
            CF.ShowDialog();
            if (CF.isSave)
                return CF.Cheque;
            else
                return null;
        }

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
            N["DocNo"] = Cheque_No;
            N["DocDate"] = JDateTime.FarsiDate(Issue_Date).Replace("/", "").Substring(0, 8);
            N["DocType"] = Legal.NamaadDocType.CheckModatDar.GetHashCode();
            N["Amount"] = Price;
            N["DescriptionHdr"] = Description;
            N["DescriptionDtl"] = Description;
            N["DocProvince"] = State;
            N["DocCity"] = City;
            N["DocBankNo"] = Bank_Code;
            N["DocBranchNo"] = branch_Number;
            N["DocBranchName"] = branch_Code;
            N["DocAccountNo"] = Cheque_No;
            N["ResourceId"] = 0;
            N["EffectDate"] = JDateTime.FarsiDate(Create_Date).Replace("/", "").Substring(0, 8);
            N["CreateDate"] = JDateTime.FarsiDate(DateTime.Now.Date).Replace("/", "").Substring(0, 8);
            N["CreateUser"] = 1;
            N["ChangeDate"] = JDateTime.FarsiDate(DateTime.Now.Date).Replace("/", "").Substring(0, 8);
            N["ChangeUser"] = 1;

            DT.Rows.Add(N);

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
    }

    public class JCheques : JCheque
    {

        public List<Legal.JDocumentContract> ShowDialog(String pPropClassName)
        {
            return ShowDialog(0, 0, pPropClassName, 0, 0, 0, DateTime.Now, 0, 0, 0, 0);
        }


        public List<Legal.JDocumentContract> ShowDialog(int pExporter, int pReciver, String pPropClassName, int pLocation, int pForm, int pConcern
    , DateTime pDate, int pSerial
    , int pDtl1, int pDtl2, int pDtl3)

        {
            JSeriChequesForm form = new JSeriChequesForm(pExporter, pReciver);
            form.State = JFormState.Insert;
            if (pPropClassName.Length > 0)
                form.PropertyClassName = pPropClassName;
            form._PersonGroup = pLocation;
            form.txtAcc1.Text = pDtl1.ToString();
            form.txtAcc2.Text = pDtl2.ToString();
            form.txtAcc3.Text = pDtl3.ToString();
            form.cmbForm.SelectedValue = pForm;
            form.txtSerial.Text = pSerial.ToString();
            form.txtDateRecieve.Date = pDate;
            form._ConcernCode = pConcern;
            form.ShowDialog();
            return form.docs;
        }
        public static JCheque Show()
        {
            JSeriChequesForm CF = new JSeriChequesForm();
            CF.Cheque = new JCheque();
            CF.ShowDialog();
            if (CF.isSave)
                return CF.Cheque;
            else
                return null;
        }
    }
}