using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Finance;
using Estates;
using System.Data.SqlClient;

namespace Legal
{
    public partial class JConfirmForm : JBaseForm
    {
        private int ContractCode;
        private JSubjectContract contract;
        public int _ConcernCode = 0;

        public JConfirmForm(int pCode)
        {
            InitializeComponent();
            ContractCode = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            lstImages.ClassName = "Legal.JContract";
            lstImages.SubjectCode = 0;
            lstImages.PlaceCode = 0;
            lstImages.ObjectCode = ContractCode;

        }

        public JConfirmForm()
        {
        }

        public void Show(DataTable DT)
        {
            try {
                int i = int.Parse(DT.Rows[0]["Code"].ToString());
                JConfirmForm F = new JConfirmForm(i);
                F.ShowDialog();
            }
            catch
            {

            }
        }

        private bool CheckControls()
        {
            if (!chkBuyer.Checked || !chkSeller.Checked)
            {
                JMessages.Error("برای تائید قرارداد، امضاء طرف اول و دوم اجباری است.", "Error");
                return false;
            }
            //if (lstImages.FileCount == 0)
            //{
            //    JMessages.Error("لطفا تصویر امضاء شده قرارداد را اضافه کنید.", "Error");
            //    return false;
            //}

            return true;
        }

        private bool Save()
        {
            if (!CheckControls())
                return false;
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                #region Set Values
                JSubjectContract contract = new JSubjectContract(ContractCode);
                if (chkBuyer.Checked)
                    contract.ConfirmBuyer = true;
                if (chkSeller.Checked)
                    contract.ConfirmSeller = true;
                if (chkView.Checked)
                    contract.ConfirmIntuition = true;
                contract.Status = JContractStatus.Current;
                bool notConfirmed = !contract.Confirmed;
                contract.Confirmed = true;
                #endregion Set Values

                JContractdefine defineType = new JContractdefine(contract.Type);
                JContractDynamicType type = new JContractDynamicType(defineType.ContractType);
                Finance.JAsset asset = new JAsset(contract.FinanceCode);
                JOwnershipType _type = JOwnershipType.None;

                /// در صورتی که قرارداد قبلا تائید نشده است، دارایی ها مقدار میگیرند
                db.beginTransaction("ConfirmContract");
                int transferCode = 0;
                if (notConfirmed)
                {
                    bool transfered = false;
                    #region Transfer
                    JTransferAssetAfterContract TransferAssetAfterContract = new JTransferAssetAfterContract();
                    /// انتقال قطعی
                    if (type.AssetTransferType == JOwnershipType.Definitive.GetHashCode())
                    {
                        #region Transfer Sheet
                        /// انتقال سهام
                        if (asset.ClassName == "ManagementShares.JShareSheet")
                        {
                            ManagementShares.JTransferSheet transfer = new ManagementShares.JTransferSheet(contract.ShareTransferCode);
                            transfer.Confirmed = true;
                            ManagementShares.JShareSheet sheet = new ManagementShares.JShareSheet(asset.ObjectCode);
                            DataTable contractBuyers = JPersonContract.GetAllDataType(contract.FinanceCode, contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, (Finance.JOwnershipType)contract.ContractType.AssetTransferType, db);
                            int t = 0;
                            int transferResultCode = sheet.TransferSheet(transfer.TranSum, Convert.ToInt32(contractBuyers.Rows[0]["PersonCode"]), transfer, db, true, ref t);
                            if (transferResultCode == 0)
                            {
                            }
                            else
                            {
                                transfer.Update(db);
                            }
                        }
                        #endregion Transfer Sheet
                        transferCode = TransferAssetAfterContract.TransferDefinite(contract, db);
                        _type = JOwnershipType.Definitive;
                        transfered = true;
                    }
                    else
                        /// انتقال سرقفلی
                        if (type.AssetTransferType == JOwnershipType.Goodwill.GetHashCode())
                    {
                        transferCode = TransferAssetAfterContract.TransferGoodwill(contract, 0, 0, db, null, null, Finance.JOwnershipType.Goodwill);
                        _type = JOwnershipType.Goodwill;
                        transfered = true;

                    }
                    else
                            /// انتقال صلح سرقفلی
                            if (type.AssetTransferType == JOwnershipType.GoodwillPeace.GetHashCode())
                    {
                        _type = JOwnershipType.GoodwillPeace;
                        /// فقط وضعیت قرارداد به امضاء شده تغییر میابد
                        /// 
                        transfered = true;

                    }
                    else if (type.AssetTransferType == JOwnershipType.Rentals.GetHashCode())
                    /// انتقال اجاره
                    /// فقط وضعیت قرارداد به امضاء شده تغییر میابد
                    /// 
                    {
                        _type = JOwnershipType.Rentals;
                        transfered = true;
                    }
                    else if (type.AssetTransferType == JOwnershipType.Personel.GetHashCode())
                    /// انتقال خاص
                    /// فقط وضعیت قرارداد به امضاء شده تغییر میابد
                    /// 
                    {
                        transfered = true;
                    }
                    else if (type.AssetTransferType == JOwnershipType.Other.GetHashCode())
                    /// انتقال خاص
                    /// فقط وضعیت قرارداد به امضاء شده تغییر میابد
                    /// 
                    {
                        transfered = true;
                    }

                    /// اگر انتقال صورت گرفته و یا نوع قرارداد از انواع بدون انتقال مانند اجاره است
                    if (transferCode > 0 || transfered)
                    {
                        JAssetTransfer AssetTransfer = TransferAssetAfterContract._AsstTransfer;
                        if (AssetTransfer != null && AssetTransfer.ParentCode > 0)
                        {
                            JAction Act = new JAction("DisableContract", AssetTransfer.ClassName + ".DisableContract", new object[] { AssetTransfer.ObjectCode, db }, null);
                            transfered = (bool)Act.run();
                        }
                    }

                    #endregion Transfer

                    #region Save In Relation
                    if (transfered)
                    {
                        /// ثبت در جدول ارتباطات
                        //Add Relation
                        if (TransferAssetAfterContract._AsstTransfer != null)
                        {
                            JRelation tmpJRelation = new JRelation();
                            tmpJRelation.PrimaryClassName = "Finance.JAsset";
                            tmpJRelation.PrimaryObjectCode = contract.FinanceCode;
                            tmpJRelation.ForeignClassName = "Legal.JSubjectContract";
                            tmpJRelation.ForeignObjectCode = ContractCode;
                            tmpJRelation.Comment = "ارتباط دارد" + ContractCode + " این اموال با قرارداد شماره ";
                            if (!tmpJRelation.Insert(db))
                            {
                                db.Rollback("ConfirmContract");
                                return false;
                            }
                        }
                    }
                    else
                    {
                        db.Rollback("ConfirmContract");
                        return false;
                    }
                    #endregion Save In Relation

                    if (!SendToNamaad())
                    {
                        db.Rollback("ConfirmContract");
                        return false;
                    }
                    Legal.JDocumentsContract.NamaadSendTo(ContractCode);
                }

                //Hassanzadeh
                if (JContractFormsOrder.CheckForm(contract.Type, "Legal.JContractTarefeForm"))
                {
                    Estates.JGroundSheet tmpJGroundSheet = new JGroundSheet();
                    DataTable dtSheet = tmpJGroundSheet.ListTarefe(0, 0, 0, contract.Code, 0, db);
                    if (dtSheet.Rows.Count == 0)
                    {
                        dtSheet = tmpJGroundSheet.ListTarefe(0, 0, contract.Code, 0, 1, db);
                        if (dtSheet.Rows.Count > 0)
                        {
                            JPersonContract tmpPContract = new JPersonContract();
                            DataTable dtPerson = JPersonContract.GetAllDataTarefe(contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, db);
                            if (dtPerson.Rows.Count == 0)
                                dtPerson = JPersonContract.GetAllDataTarefe(contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate, db);
                            tmpJGroundSheet.Parent = Convert.ToInt32(dtSheet.Rows[0]["Code"]);
                            tmpJGroundSheet.GCode = Convert.ToInt32(dtSheet.Rows[0]["GCode"]);
                            tmpJGroundSheet.PCode = Convert.ToInt32(dtPerson.Rows[0]["PersonCode"]);
                            tmpJGroundSheet.ContractCodeBuy = contract.Code;
                            tmpJGroundSheet.CreateDate = DateTime.Now;
                            tmpJGroundSheet.Creator = JMainFrame.CurrentPostCode; ;
                            tmpJGroundSheet.NumPrint = 0;
                            tmpJGroundSheet.State = 1;
                            tmpJGroundSheet.DeActive = 0;
                            tmpJGroundSheet.Area = (float)Convert.ToDecimal(dtSheet.Rows[0]["Area"]);
                            tmpJGroundSheet.Share = (float)Convert.ToDecimal(dtSheet.Rows[0]["Share"]);
                            if (tmpJGroundSheet.Insert(db) < 1)
                            {
                                db.Rollback("ConfirmContract");
                                return false;
                            }
                        }
                    }
                }
                contract.TransferCode = transferCode;
                if (contract.Update(db))
                {
                    if (_type != JOwnershipType.None)
                    {
                        JFinAssetLog FLog = new JFinAssetLog(asset.Code, asset.ClassName, asset.ObjectCode, (JOwnershipType)_type, db);
                        FLog.save(db);
                    }

                    if (!Legal.JDocumentsForm.SaveFinDocument(db, ContractCode))
                    {
                        db.Rollback("ConfirmContract");
                        JMessages.Error(" خطا", "");
                        return false;
                    }

                    if (db.Commit())
                    {
                        lstImages.ArchiveList();
                    }
                    else
                    {
                        db.Rollback("ConfirmContract");
                        JMessages.Error(" خطا", "");
                        return false;
                    }

                    int i = 0;
                    DataTable dt = JPersonContract.GetAllDataTarefe(ContractCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);

                    int BuyerTafziliCode = 0;
                    DataTable DT = Finance.JComparativeCodes.GetDataMultiTafzili(JDataBase.DataTableToStringtArray(dt, "Code"), "ClassLibrary.Person.AllPerson");
                    if (DT != null && DT.Rows.Count == 1)
                        BuyerTafziliCode = int.Parse(DT.Rows[0]["Value"].ToString());

                    if (int.TryParse(comboBox1.SelectedValue.ToString(), out i) && i > 0 && BuyerTafziliCode == 0)
                    {
                        foreach (DataRow dr in DT.Rows)
                        {
                            try
                            {
                                JComparativeCode p = new JComparativeCode();
                                p.ClassName = "ClassLibrary.Person.AllPerson";
                                p.ObjectCode = int.Parse(dr["pCode"].ToString());
                                p.Comment = "ثبت تفصیلی حسابداری از سیستم قراردادها";
                                p.CreatorPostCode = JMainFrame.CurrentPostCode;
                                p.CreatorUserCode = JMainFrame.CurrentUserCode;
                                p.DivideType = 0;
                                p.State = 1;
                                p.Status = 1;
                                p.Value = i;
                                p.Insert();
                            }
                            catch
                            {

                            }
                        }
                    }
                    return true;
                }
                else
                {
                    db.Rollback("ConfirmContract");
                    JMessages.Error(" خطا", "");
                    return false;
                }
            }

            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("ConfirmContract");
                JMessages.Error(" خطا", "");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool SendToNamaad()
        {
            //DataTable DT = new DataTable();
            //DT.Columns.Add("Form"); // کد فرم یعنی دریافت پرداخت ابطال و تعدیل NamdFormType
            //DT.Columns.Add("PersonGroup"); //گروه شخص بصورت داینامیک که در اصل همان کد پروژه است
            //DT.Columns.Add("PersonNo"); // کد تفصیلی شخص
            //DT.Columns.Add("MainConcernCode"); //بابت
            //DT.Columns.Add("ConncernCode"); // بابت و با مقدار بالایی یکی است
            //DT.Columns.Add("ConcernForm"); //  فرم بابت
            //DT.Columns.Add("ConcernSerial");//سریال بابت
            //DT.Columns.Add("DtlClassCode1");// اقلام دسته
            //DT.Columns.Add("DtlClassCode2");// اقلام دسته
            //DT.Columns.Add("DtlClassCode3");// اقلام دسته
            //DT.Columns.Add("DocNo"); // شماره سند همان شماره چک و شماره فیش است
            //DT.Columns.Add("DocDate"); // تاریخ چک یا فیش
            //DT.Columns.Add("DocType"); // چک فیش یا تعدیل(قرارداد)
            //DT.Columns.Add("Amount"); // مبلغ
            //DT.Columns.Add("DescriptionHdr"); // شرح هدر
            //DT.Columns.Add("DescriptionDtl");// شرح دیتیل
            //DT.Columns.Add("DocProvince"); // استان
            //DT.Columns.Add("DocCity"); // شهر
            //DT.Columns.Add("DocBankNo"); // بانک
            //DT.Columns.Add("DocBranchNo"); //کد شعبه
            //DT.Columns.Add("DocBranchName");// نام شعبه
            //DT.Columns.Add("DocAccountNo");// شماره حساب
            //DT.Columns.Add("ResourceId"); // آی دی منبع منظور ها بانکه یا صندو قها یا تنخواه گردانها
            //DT.Columns.Add("EffectDate"); // تاری خو ماثر
            //DT.Columns.Add("CreateDate");
            //DT.Columns.Add("CreateUser");
            //DT.Columns.Add("ChangeDate");
            //DT.Columns.Add("ChangeUser");

            //DataRow N = DT.NewRow();
            //N["Form"] = Legal.NamaadFormType.TadilBedehkar.GetHashCode();
            //N["PersonGroup"] = 0;//--------------------// برای هر پروژه امکان تعریف یک کد باشد
            //N["PersonNo"] = 0;//----------------
            //N["MainConcernCode"] = 0;//-----------------
            //N["ConncernCode"] = 0;//---------------------
            //N["ConcernForm"] = 4;//ثابت است
            //N["ConcernSerial"] = contract.Number;//شماره قرارداد
            //N["DtlClassCode1"] = 0;//-----------------
            //N["DtlClassCode2"] = 0;
            //N["DtlClassCode3"] = 0;
            //N["DocNo"] = 0;
            //N["DocDate"] = 0;
            //N["DocType"] = Legal.NamaadDocType.TadilBedehkar.GetHashCode();
            //N["Amount"] = contract.Price;
            //N["DescriptionHdr"] = "قرارداد شماره " + contract.Number + " به تاریخ " + JDateTime.FarsiDate(contract.Date);
            //N["DescriptionDtl"] = "قرارداد شماره " + contract.Number + " به تاریخ " + JDateTime.FarsiDate(contract.Date);
            //N["DocProvince"] = 0;
            //N["DocCity"] = 0;
            //N["DocBankNo"] = 0;
            //N["DocBranchNo"] = 0;
            //N["DocBranchName"] = 0;
            //N["DocAccountNo"] = 0;
            //N["ResourceId"] = 0;
            //N["EffectDate"] = JDateTime.FarsiDate(contract.Date).Replace("/", "").Substring(0, 8);
            //N["CreateDate"] = JDateTime.FarsiDate(DateTime.Now.Date).Replace("/", "").Substring(0, 8);
            //N["CreateUser"] = 1;
            //N["ChangeDate"] = JDateTime.FarsiDate(DateTime.Now.Date).Replace("/", "").Substring(0, 8);
            //N["ChangeUser"] = 1;

            //DT.Rows.Add(N);

            JDataBase DB = new JDataBase();
            try
            {
                SqlCommand insertCommand = new SqlCommand(
                    "Trs_Insert", DB.Connection);
                insertCommand.CommandType = CommandType.StoredProcedure;
                //SqlParameter tvpParam = insertCommand.Parameters.AddWithValue(
                //    "@List", DT);
                //tvpParam.SqlDbType = SqlDbType.Structured;

                //DataRow N = DT.NewRow();
                int PersonNo = 0;
                try
                {
                    DB.setQuery("select top 1 PersonCode from LegPersonContract where ContractSubjectCode=" + contract.Code + " and Type=9");
                    DataTable DT = DB.Query_DataTable();
                    if (DT.Rows.Count == 1)
                        PersonNo = (int)DT.Rows[0]["PersonCode"];
                }
                catch
                {

                }
                finally
                {
                }

                insertCommand.Parameters.AddWithValue("Form", Legal.NamaadFormType.TadilBedehkar.GetHashCode());
                insertCommand.Parameters.AddWithValue("PersonGroup", contract.PersonGroup);//--------------------// برای هر پروژه امکان تعریف یک کد باشد
                insertCommand.Parameters.AddWithValue("PersonNo", PersonNo);//----------------
                insertCommand.Parameters.AddWithValue("MainConcernCode", contract.ConncernCode);//-----------------
                insertCommand.Parameters.AddWithValue("ConncernCode", contract.ConncernCode);//---------------------
                insertCommand.Parameters.AddWithValue("ConcernForm", 4);//ثابت است
                insertCommand.Parameters.AddWithValue("ConcernSerial", contract.Number);//شماره قرارداد
                insertCommand.Parameters.AddWithValue("DtlClassCode1", contract.DtlClassCode1);//-----------------
                insertCommand.Parameters.AddWithValue("DtlClassCode2", contract.DtlClassCode1);
                insertCommand.Parameters.AddWithValue("DtlClassCode3", contract.DtlClassCode1);
                insertCommand.Parameters.AddWithValue("DocNo", 0);
                insertCommand.Parameters.AddWithValue("DocDate", 0);
                insertCommand.Parameters.AddWithValue("DocType", Legal.NamaadDocType.TadilBedehkar.GetHashCode());
                insertCommand.Parameters.AddWithValue("Amount", contract.TotalPrice);
                insertCommand.Parameters.AddWithValue("DescriptionHdr", "قرارداد شماره " + contract.Number + " به تاریخ " + JDateTime.FarsiDate(contract.Date));
                insertCommand.Parameters.AddWithValue("DescriptionDtl", "قرارداد شماره " + contract.Number + " به تاریخ " + JDateTime.FarsiDate(contract.Date));
                insertCommand.Parameters.AddWithValue("DocProvince", 0);
                insertCommand.Parameters.AddWithValue("DocCity", 0);
                insertCommand.Parameters.AddWithValue("DocBankNo", 0);
                insertCommand.Parameters.AddWithValue("DocBranchNo", 0);
                insertCommand.Parameters.AddWithValue("DocBranchName", 0);
                insertCommand.Parameters.AddWithValue("DocAccountNo", 0);
                insertCommand.Parameters.AddWithValue("ResourceId", 0);
                insertCommand.Parameters.AddWithValue("EffectDate", JDateTime.FarsiDate(contract.Date).Replace("/", "").Substring(0, 8));
                insertCommand.Parameters.AddWithValue("CreateDate", JDateTime.FarsiDate(DateTime.Now.Date).Replace("/", "").Substring(0, 8));
                insertCommand.Parameters.AddWithValue("CreateUser", 1);
                insertCommand.Parameters.AddWithValue("ChangeDate", JDateTime.FarsiDate(DateTime.Now.Date).Replace("/", "").Substring(0, 8));
                insertCommand.Parameters.AddWithValue("ChangeUser", 1);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(insertCommand);
                adapter.Fill(dt);

                contract.Form = int.Parse(dt.Rows[0]["Form"].ToString());
                contract.Serial = int.Parse(dt.Rows[0]["Serial"].ToString());
                contract.FormId = int.Parse(dt.Rows[0]["FormId"].ToString());
                contract.ItemNo = int.Parse(dt.Rows[0]["ItemNo"].ToString());
                contract.CompanyId = int.Parse(dt.Rows[0]["CompanyId"].ToString());
                contract.FormDtlId = int.Parse(dt.Rows[0]["FormDtlId"].ToString());
                contract.StatusNamaad = 1;
                contract.Update();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
            return true;
        }

    #region Events

    private void chkSeller_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkBuyer_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

      #endregion

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.State = JFormState.Confirm;
                Close();
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (int.TryParse(comboBox1.SelectedValue.ToString(), out i) && i > 0)
            {
                if (Save())
                {
                    btnSave.Enabled = false;
                    this.State = JFormState.Update;
                }
                else
                    JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
            }
            else
            {
                JMessages.Message("کد تفصیلی را وارد کنید ", "", JMessageType.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (JMessages.Question("DoYouWantToSaveChanges", "Save") == DialogResult.Yes)
                    if (Save())
                    {
                        this.State = JFormState.Confirm;
                        this.Close();
                    }
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    this.Close();
            }
            else
            {
                this.State = JFormState.Confirm;
                this.Close();
            }
        }

        private void JConfirmForm_Load(object sender, EventArgs e)
        {
            contract = new JSubjectContract(ContractCode);
            if (contract.ConfirmBuyer)
                chkBuyer.Checked = true;
            if (contract.ConfirmSeller)
                chkSeller.Checked = true;
            if (contract.ConfirmIntuition)
                chkView.Checked = true;


            JDataBase DB = new JDataBase();
            DB.setQuery("select PersonNo,PersonName,PersonGroup from Trs_View_PersonInGroup where PersonGroup=112 order by PersonName ");
            comboBox1.DataSource = DB.Query_DataTable();
            comboBox1.ValueMember = "PersonNo";
            comboBox1.DisplayMember = "PersonName";
            comboBox1.DroppedDown = true;
            DB.Dispose();

            DataTable dt = JPersonContract.GetAllDataTarefe(ContractCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
            string name = string.Join(",", JDataBase.DataTableToStringtArray(dt, "name"));
            label1.Text = name;

            int BuyerTafziliCode = 0;
            DataTable DT = Finance.JComparativeCodes.GetDataMultiTafzili(JDataBase.DataTableToStringtArray(dt, "Code"), "ClassLibrary.Person.AllPerson");
            if (DT != null && DT.Rows.Count == 1)
                BuyerTafziliCode = int.Parse(DT.Rows[0]["Value"].ToString());

            if (BuyerTafziliCode > 0)
            {
                comboBox1.SelectedValue = BuyerTafziliCode.ToString();
                comboBox1.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
                comboBox1.SelectedValue = -1;
            }

            chkSeller.Text = "امضاء " + contract.ContractType.ContractSettings.Items["T1Lable"].ToString();
            chkBuyer.Text = "امضاء " + contract.ContractType.ContractSettings.Items["T2Lable"].ToString();
        }

    }
}

