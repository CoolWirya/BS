using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;


namespace Legal
{
    public partial class JContractTarefeForm : JBaseContractForm
    {


        public int DefaultSheetCode;
        private int _SheetCodeSeller;
        DataTable _dtAdSeller = new DataTable();
        DataTable _dtSeller = new DataTable();
        DataTable _dtBuyer = new DataTable();
        DataTable _dtAdBuyer = new DataTable();

        public JContractTarefeForm()
        {
            InitializeComponent();
        }

        private JContractTypeSettings _ContractSettings;

        
        /// <summary>
        /// این تابع برای ساختن و فرستادن فرم بصورت داینامیک استفاده میشود
        /// </summary>
        /// <returns></returns>
        public JContractTarefeForm MakeForm()
        {
            JContractTarefeForm form = new JContractTarefeForm();
            return form;
        }

        #region Methods
        
        // حذف تعرفه 
        public bool delete(JDataBase DB)
        {
            Estates.JGroundSheet tmpSheet = new Estates.JGroundSheet();
            if (!(tmpSheet.UpdateSheet(ContractForms.Contract.Code, DB)))
                return false;
            return true;
        }

        public void Set_Form()
        {
            Set_Form(ContractForms.Contract);
        }


        public void Set_Form(JSubjectContract pContract)
        {
            try
            {
                Set_Setting();
                Finance.JOwnershipType ownerShipSeller = (Finance.JOwnershipType)(Convert.ToInt32(_ContractSettings.Items["T1PersonOwnership"]));
                Finance.JOwnershipType ownerShipBuyer = (Finance.JOwnershipType)(Convert.ToInt32(_ContractSettings.Items["T2PersonOwnership"]));

                if (State != JStateContractForm.View && State != JStateContractForm.Update)
                {
                    Estates.JGroundSheet GSheet = new Estates.JGroundSheet(DefaultSheetCode);

                    if (GSheet.ContractCodeBuy == 0)
                        _dtSeller = JPersonContract.GetAllDataTarefeSeller(DefaultSheetCode);
                    else
                        _dtSeller = JPersonContract.GetAllDataTarefe(GSheet.ContractCodeBuy, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
                    _dtAdSeller = JPersonContract.GetAllDataTarefe(0, ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate);
                    _dtBuyer = JPersonContract.GetAllDataTarefe(0, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
                    _dtAdBuyer = JPersonContract.GetAllDataTarefe(0, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate);
                    jComboBox1.Enabled = DefaultSheetCode == 0;
                    if (DefaultSheetCode != 0)
                    {
                        DataTable dt = (DataTable)(jComboBox1.DataSource);
                        if (dt.Select("Code =" + DefaultSheetCode).Length > 0)
                            jComboBox1.SelectedValue = DefaultSheetCode;
                        else
                        {
                            jComboBox1.Text = "";
                            DefaultSheetCode = 0;
                            lblTarefeSell.Text = "";
                            JMessages.Error(" این تعرفه غیر فعال است ", "");
                        }
                    }
                    //FillBuyer();
                }
                /// در صورتی که فرم در حالت مشاهده باز شد
                else
                {
                    _dtSeller = JPersonContract.GetAllDataTarefe(ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller);
                    _dtBuyer = JPersonContract.GetAllDataTarefe(ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
                    _dtAdBuyer = JPersonContract.GetAllDataTarefe(ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate);
                    _dtAdSeller = JPersonContract.GetAllDataTarefe(ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate);

                    Estates.JGroundSheet tmpJGroundSheet = new Estates.JGroundSheet();
                    DataTable dtSheet = tmpJGroundSheet.ListTarefe(0, 0, ContractForms.Contract.Code, 0, 1);
                    if (dtSheet.Rows.Count > 0)
                    {
                        jComboBox1.SelectedValue = dtSheet.Rows[0]["Code"];
                        lblTarefeSell.Text = " کد تعرفه : " + dtSheet.Rows[0]["Code"].ToString() + "  " + dtSheet.Rows[0]["FullName"].ToString(); ;
                    }
                    dtSheet = tmpJGroundSheet.ListTarefe(0, 0, 0, ContractForms.Contract.Code, 0);
                    if (dtSheet.Rows.Count > 0)
                    {
                        lblTarefeBuy.Text = " کد تعرفه : " + dtSheet.Rows[0]["Code"].ToString() + "  " + dtSheet.Rows[0]["FullName"].ToString(); ;
                        //lblSumSahm.Text = SSahm;// Lottery.JExecLottery.GetSumSahm(Convert.ToInt32(dtSheet.Rows[0]["PCode"]), Convert.ToInt32(dtSheet.Rows[0]["GCode"])).ToString();
                        Estates.JGround newGround = new Estates.JGround(Convert.ToInt32(dtSheet.Rows[0]["GCode"]));
                        txtMainAve.Text = newGround.MainAve;
                        txtSubAve.Text = newGround.SubNo;
                        txtBlockNum.Text = newGround.BlockNum;
                        txtPartNum.Text = newGround.PartNum;
                        txtArea.Text = newGround.Area.ToString();
                        jucPersonBuy.SelectedCode = Convert.ToInt32(dtSheet.Rows[0]["PCode"]);
                        Estates.JUsageGround tmpUsage = new Estates.JUsageGround(newGround.Usage);
                        txtUsage.Text = tmpUsage.Name.ToString();
                    }
                    jdgvBuyer.ReadOnly = true;
                    jdgvAdBuyer.ReadOnly = true;
                    if (State == JStateContractForm.View)
                    {
                        //groupBox1.Enabled = false;
                        btnDelAdBuyer.Enabled = false;
                        btnAddAdBuyer.Enabled = false;
                        btnAddDaSeller.Enabled = false;
                        btnDelAdSeller.Enabled = false;
                    }
                    jdgvAdSeller.ReadOnly = true;

                    if (State == JStateContractForm.Update && ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode())
                    {
                        btnAddBuyer.Enabled = true;
                        btnDelBuyer.Enabled = true;
                    }
                    else
                    {
                        btnAddBuyer.Enabled = false;
                        btnDelBuyer.Enabled = false;
                    }
                }
                jdgvBuyer.DataSource = _dtBuyer;
                jdgvAdBuyer.DataSource = _dtAdBuyer;
                jdgvAdSeller.DataSource = _dtAdSeller;

                inVisibleColumns();

                jdgvAdBuyer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                jdgvAdSeller.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                jdgvBuyer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JSystem.Except.NewException(pContract.ToString(),true);                
            }
        }

        private void Set_Setting()
        {
            try
            {
                _ContractSettings = this.ContractForms.Settings;
                /// ست کرن فرم بر اساس تنظیمات
                this.Text = _ContractSettings.Items["PatiesFormName"].ToString();
                grpAdT2.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T2HasAdvocacy"]));
                btnDelBuyer.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T2AddDelPerson"]));
                btnAddBuyer.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T2AddDelPerson"]));

                if (jdgvBuyer.DataSource != null)
                    jdgvBuyer.Columns["Share"].Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString()));
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        public bool CheckData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                if ((_dtBuyer.Rows.Count == 0) && (_dtAdBuyer.Rows.Count == 0))
                {
                    JMessages.Information(" لطفا خریدار را مشخص کنید", "Information");
                    return false;
                }
                if (_dtSeller.Rows.Count == 0)
                {
                    JMessages.Information(" لطفا تعرفه را مشخص کنید  ", "Information");
                    return false;
                }
                if (Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["Request"])))
                if (!(Estates.JRequestTransferSheet.CheckExistRequest(_SheetCodeSeller)))
                {
                    JMessages.Information(" برای این تعرفه درخواستی تایید نشده است  ", "Information");
                    return false;
                }
                if (DefaultSheetCode == 0)
                {
                    JMessages.Information("  این تعرفه غیر فعال است  ", "Information");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }       

        private void GetPattern()
        {
            try
            {
                _dtSeller = JPersonContract.GetAllDataTarefe(0, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller);
                _dtBuyer = JPersonContract.GetAllDataTarefe(0, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
                _dtAdBuyer = JPersonContract.GetAllDataTarefe(0, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate);
                _dtAdSeller = JPersonContract.GetAllDataTarefe(0, ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate);

                jdgvAdSeller.DataSource = _dtAdSeller;
                jdgvBuyer.DataSource = _dtBuyer;
                jdgvAdBuyer.DataSource = _dtAdBuyer;

                inVisibleColumns();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void inVisibleColumns()
        {
            inVisibleColumn(jdgvAdSeller, "Share", false);
            inVisibleColumn(jdgvAdSeller, "ClassNameEn", false);
            inVisibleColumn(jdgvAdSeller, "ContractSubjectCode", false);
            inVisibleColumn(jdgvAdSeller, "fASCode", false);
            inVisibleColumn(jdgvAdSeller, "PersonShare", false);

            inVisibleColumn(jdgvAdBuyer, "Share", false);
            inVisibleColumn(jdgvAdBuyer, "ClassNameEn", false);
            inVisibleColumn(jdgvAdBuyer, "ContractSubjectCode", false);
            inVisibleColumn(jdgvAdBuyer, "fASCode", false);
            inVisibleColumn(jdgvAdBuyer, "PersonShare", false);

            inVisibleColumn(jdgvBuyer, "Share", false);
            inVisibleColumn(jdgvBuyer, "Area", false);
            inVisibleColumn(jdgvBuyer, "ClassNameEn", false);
            inVisibleColumn(jdgvBuyer, "ContractSubjectCode", false);
            inVisibleColumn(jdgvBuyer, "fASCode", false);
            inVisibleColumn(jdgvBuyer, "Code", false);
            inVisibleColumn(jdgvBuyer, "PersonShare", false);

            if (this.ContractForms.Contract.ContractType.ClassName == "")
            {
                inVisibleColumn(jdgvBuyer, "Share", false);
            }

        }

        private void inVisibleColumn(JDataGrid pGrid, string pName, bool pVisible)
        {
            try
            {
                pGrid.Columns[pName].Visible = pVisible;
            }
            catch
            {
            }
        }

        public bool ApplyData()
        {
            try
            {
                //ContractForms.Contract.SheetGround = Convert.ToInt32(lvTarefe.SelectedValue);
                ContractForms.Contract.T1Person = _dtSeller;
                ContractForms.Contract.T2Person = _dtBuyer;
                _dtBuyer.Rows[0]["Share"] = _dtSeller.Rows[0]["Share"];
                _dtSeller.Rows[0]["PersonShare"] = _dtSeller.Rows[0]["Share"];
                AddAreaShareColumnBuyer(_dtBuyer);
                AddAreaShareColumnSeller(_dtSeller);
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        /// <summary>
        /// افزودن ستون سهم از متراژ
        /// </summary>
        /// <param name="shares"></param>
        private void AddAreaShareColumnBuyer(DataTable shares)
        {
            Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
            foreach (DataRow row in shares.Rows)
            {
                if (!shares.Columns.Contains("AreaShare"))
                    shares.Columns.Add("AreaShare");
                if (asset.ClassName == "Estates.JGround")
                {
                    Estates.JGround ground = new Estates.JGround(asset.ObjectCode);
                    row["AreaShare"] = JGeneral.ReverseNumber(System.Math.Round(ground.Area / 6.00 * System.Convert.ToDouble(row["Share"]), 3).ToString(), '/');
                }
            }
        }
        /// <summary>
        /// افزودن ستون سهم از متراژ
        /// </summary>
        /// <param name="shares"></param>
        private void AddAreaShareColumnSeller(DataTable shares)
        {
            Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
            foreach (DataRow row in shares.Rows)
            {
                if (!shares.Columns.Contains("AreaShare"))
                    shares.Columns.Add("AreaShare");
                if (asset.ClassName == "Estates.JGround")
                {
                    Estates.JGround ground = new Estates.JGround(asset.ObjectCode);
                    row["AreaShare"] = JGeneral.ReverseNumber(Math.Round(ground.Area / 6.00 * Convert.ToDouble(row["Share"]), 3).ToString(), '/');
                }
            }
        }

        public override bool SavePreview(DataTable pDt)
        {
            return SavePreview(pDt, true,false);
        }

        public string GetPersonContractText(int PCode, string pDate)
        {
            JAllPerson AllPers = new JAllPerson(PCode);
            if (AllPers.PersonType == JPersonTypes.LegalPerson)
            {
                JPersonAddress Address = new JPersonAddress(PCode);
                JOrganization Org = new JOrganization(PCode, pDate);
                //if (Org.SignatureList == null)
                //    HasNoSignatureMen = true;
                return "شرکت " + Org.Name + " ثبت شده به شماره " + Org.RegisterNo + " " + Org.RegisterPlaceText +
                    " به نمایندگی " + String.Join(" و ", Org.SignatureListText.ToArray()) +
                    " به آدرس " + Address.FullAddress +
                    " وتلفن " + Address.Tel;
            }
            else
                if (AllPers.PersonType == JPersonTypes.RealPerson)
                {
                    JPerson Person = new JPerson(PCode);
                    JPersonAddress Address = new JPersonAddress(PCode);
                    string strPerson = "";
                    if (Person.Gender)
                        strPerson = "آقای ";
                    else
                        strPerson = "خانم ";
                    strPerson = strPerson + Person.Name + " " + Person.Fam +
                    " فرزند " + Person.FatherName +
                    " به شماره شناسنامه " + Person.ShSh +
                        " و کد ملی " + Person.ShMeli +
                                " صادره از " + Person.SaderText +
                                    " متولد " + JDateTime.FarsiDate(Person.BthDate).Split('/')[0]+
                                        " به نشانی " + Address.FullAddress +
                                            " و تلفن " + Address.Tel;
                    if (Address.Mobile != "" && Address.Mobile != null)
                        strPerson = strPerson + " تلفن همراه " + Address.Mobile;
                    return strPerson;
                }
            return "";
        }

        int SSahm = 0;
        public double SolhPrice(int pCode, float pDong)
        {
            JDataBase DB = new JDataBase();
            try
            {
                Finance.JAsset Asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
                string _SQL = "select * from lotteryResault Where PCode = " + pCode.ToString() + " And GCode=" + Asset.ObjectCode;
                DB.setQuery(_SQL);
                DataTable _DT = DB.Query_DataTable();

                if ((_DT != null) && (_DT.Rows.Count > 0))
                    SSahm = int.Parse(_DT.Rows[0]["SumSahm"].ToString());
                else
                    SSahm = 0;
                
                Estates.JGround Gr = new Estates.JGround(Asset.ObjectCode);

                float _Price = float.Parse(Gr.Cost.ToString()) * pDong / 6;

                return System.Math.Round(SSahm * 500000 - (Convert.ToDouble(SSahm) * 3500000 - _Price));
            }
            finally
            {
                DB.Dispose();
            }
        }

        public override bool SavePreview(DataTable pDt, bool pSetValue)
        {
            return SavePreview(pDt, pSetValue, false);
        }

        public override bool SavePreview(DataTable pDt, bool pSetValue, bool pOffline)
        {
            try
            {
                List<string> tempList = new List<string>();
                List<string> tempList1 = new List<string>();

                pDt.Columns.Add("StrSeller");
                pDt.Columns.Add("T1ShareCount");
                pDt.Columns.Add("T2ShareCount");

                pDt.Columns.Add("T1AreaShare");
                pDt.Columns.Add("T2AreaShare");

                pDt.Columns.Add("T1Area");
                pDt.Columns.Add("T2Area");

                pDt.Columns.Add("PriceSolhTarefe");

                pDt.Columns.Add("SumDongs");

                pDt.Columns.Add("PersonCodeT2");
                pDt.Columns.Add("SumSahm");
                pDt.Columns.Add("NameT2");

                if (pSetValue)
                {
                    if (pOffline)
                    {
                        Fill_Data();
                        ApplyData();
                    }                    
                    /// مشخصاات طرف اول
                    foreach (DataRow dr in _dtSeller.Rows)
                    {
                        tempList.Add(GetPersonContractText((int)dr["PersonCode"], JDateTime.FarsiDate(ContractForms.Contract.Date)));
                    }
                    pDt.Rows[0]["StrSeller"] = String.Join("\r", tempList.ToArray());
                    tempList.Clear();

                    /// میزان سهم طرف اول
                    foreach (DataRow dr in _dtSeller.Rows)
                    {                        
                        tempList.Add(dr["Name"].ToString() + " به نسبت " + dr["Share"].ToString() + JLanguages._Text("DongFrom") + dr["PersonShare"].ToString() + JLanguages._Text("Dong"));
                    }                   
                    
                    pDt.Rows[0]["T1ShareCount"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();

                   
                    /// مشخصاات طرف دوم
                    foreach (DataRow dr in _dtBuyer.Rows)
                    {
                        tempList1.Add(
    JMoney.StringToMoney(SolhPrice(int.Parse(dr["PersonCode"].ToString()), float.Parse(dr["Share"].ToString())).ToString()) + " ریال ");
                        pDt.Rows[0]["PersonCodeT2"] = pDt.Rows[0]["PersonCodeT2"].ToString() + " " + dr["PersonCode"].ToString();
                        pDt.Rows[0]["NameT2"] = pDt.Rows[0]["NameT2"].ToString() + " " + dr["Name"].ToString();
                    } 
                    pDt.Rows[0]["PriceSolhTarefe"] = String.Join(" و ", tempList1.ToArray());
                    tempList.Clear();
                    pDt.Rows[0]["SumSahm"] = SSahm;//lblSumSahm.Text;

                    /// میزان سهم از متراژ طرف اول
                    foreach (DataRow dr in _dtSeller.Rows)
                    {//dr["AreaShare"].ToString()
                        tempList.Add(dr["Name"].ToString() + " به نسبت " + dr["AreaShare"].ToString() + JLanguages._Text("Metr"));// + dr[""].ToString());
                    }
                    pDt.Rows[0]["T1AreaShare"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();

                    foreach (DataRow dr in _dtSeller.Rows)
                    {//dr["AreaShare"].ToString()
                        tempList.Add(dr["AreaShare"].ToString());// + JLanguages._Text("Metr"));// + dr[""].ToString());
                    }
                    pDt.Rows[0]["T1Area"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();

                    /// میزان سهم از متراژ طرف دوم
                    foreach (DataRow dr in _dtBuyer.Rows)
                    {//dr["AreaShare"].ToString()
                        tempList.Add(dr["Name"].ToString() + " به نسبت " + dr["AreaShare"].ToString() + JLanguages._Text("Metr"));// + JLanguages._Text("ShareFrom") + dr[""].ToString());
                    }
                    pDt.Rows[0]["T2AreaShare"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();


                    foreach (DataRow dr in _dtBuyer.Rows)
                    {//dr["AreaShare"].ToString()
                        tempList.Add(dr["AreaShare"].ToString());// + JLanguages._Text("Metr"));// + dr[""].ToString());
                    }
                    pDt.Rows[0]["T2Area"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();

                    /// میزان سهم طرف دوم
                    foreach (DataRow dr in _dtBuyer.Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            tempList.Add(dr["Name"].ToString() + " به نسبت " + dr["Share"].ToString() + JLanguages._Text("Dong"));
                    }
                    pDt.Rows[0]["T2ShareCount"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();
                    pDt.Columns.Add("StrAdSeller");
                    pDt.Columns.Add("StrAdSellerSign");
                    if (pSetValue)
                    {
                        if (_dtAdSeller != null)
                        {
                            foreach (DataRow dr in _dtAdSeller.Rows)
                            {
                                tempList.Add(GetPersonContractText((int)dr["PersonCode"], JDateTime.FarsiDate(ContractForms.Contract.Date)));
                            }
                            pDt.Rows[0]["StrAdSeller"] = String.Join("\r", tempList.ToArray());

                            tempList.Clear();
                            foreach (DataRow dr in _dtAdSeller.Rows)
                            {
                                tempList.Add(GetPersonContractSignText((int)dr["PersonCode"]));
                            }
                            pDt.Rows[0]["StrAdSellerSign"] = String.Join(" \r ", tempList.ToArray());//و
                            tempList.Clear();
                        }
                    }


                }

                pDt.Columns.Add("StrBuyer");
                if (pSetValue)
                {
                    foreach (DataRow dr in _dtBuyer.Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            tempList.Add(GetPersonContractText((int)dr["PersonCode"], JDateTime.FarsiDate(ContractForms.Contract.Date)));
                    }
                    pDt.Rows[0]["StrBuyer"] = String.Join("\r", tempList.ToArray());
                    tempList.Clear();
                }

                pDt.Columns.Add("StrAdBuyer");
                if (pSetValue)
                {
                    if (_dtAdBuyer != null)
                    {
                        foreach (DataRow dr in _dtAdBuyer.Rows)
                        {
                            tempList.Add(GetPersonContractText((int)dr["PersonCode"], JDateTime.FarsiDate(ContractForms.Contract.Date)));
                        }
                        pDt.Rows[0]["StrAdBuyer"] = String.Join("\r", tempList.ToArray());
                        tempList.Clear();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private string GetPersonContractSignText(int PCode)
        {
            JAllPerson AllPers = new JAllPerson(PCode);
            if (AllPers.PersonType == JPersonTypes.LegalPerson)
            {
                JOrganization Org = new JOrganization(PCode);
                return "شرکت " + Org.Name + "\r\n" + " به نمایندگی " + String.Join(" و ", Org.SignatureListText.ToArray());
            }
            else
                if (AllPers.PersonType == JPersonTypes.RealPerson)
                {
                    JPerson Person = new JPerson(PCode);
                    return Person.Name + " " + Person.Fam;
                }
            return "";
        }

        public override bool SaveBack()
        {
            if (isSave)
            {
                isSave = false;
                State = tempState;
            }
            return true;
        }

        public override bool Save(JDataBase tempdb)
        {
            tempState = State;
            try
            {
                {
                    JPersonContract tmpSeller = new JPersonContract();
                    JPersonContract tmpBuyer = new JPersonContract();
                    JPersonContract tmpAdBuyer = new JPersonContract();
                    if (!tmpSeller.Insert(_dtSeller, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, tempdb))
                        return false;
                    if (!tmpBuyer.Insert(_dtBuyer, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, tempdb))
                        return false;
                    if (!tmpAdBuyer.Insert(_dtAdBuyer, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate, tempdb))
                        return false;
                    isSave = true;

                    Estates.JGroundSheet tmpSheet = new Estates.JGroundSheet();
                    if (State == JStateContractForm.Update)
                    {
                        if (!(tmpSheet.UpdateSheet(ContractForms.Contract.Code, tempdb)))
                            return false;
                    }
                    tmpSheet.GetData(_SheetCodeSeller, tempdb);
                    ContractForms.Contract.PreContract = tmpSheet.ContractCodeBuy;
                    tmpSheet.DeActive = 1;
                    tmpSheet.ContractCodeSell = ContractForms.Contract.Code;
                    if (!(tmpSheet.Update(tempdb)))
                        return false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        #endregion

        #region Events

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckData())
                    if (ApplyData())
                        ContractForms.NextForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                ContractForms.BackForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }
        #endregion

        private void btnAddDaSeller_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if ((((_dtSeller.Rows.Count > 0) && (_dtSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtSeller.Rows.Count == 0)) &&
                        (((_dtBuyer.Rows.Count > 0) && (_dtBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtBuyer.Rows.Count == 0)) &&
                        (((_dtAdBuyer.Rows.Count > 0) && (_dtAdBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdBuyer.Rows.Count == 0)) &&
                        (((_dtAdSeller.Rows.Count > 0) && (_dtAdSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdSeller.Rows.Count == 0)))
                    {
                        DataRow dr = _dtAdSeller.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        if (p.SelectedPerson.PersonType == JPersonTypes.RealPerson)
                            dr["ClassNameEn"] = "Legal.JSellerAdvocateContract";
                        else
                            dr["ClassNameEn"] = "Legal.JSellerAdvocateContractLegal";

                        _dtAdSeller.Rows.Add(dr);
                        jdgvAdSeller.DataSource = _dtAdSeller;
                    }
                    else
                        JMessages.Information("Person is Repeated", "Information");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelAdSeller_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvAdSeller.CurrentRow != null)
                    jdgvAdSeller.Rows.Remove(jdgvAdSeller.CurrentRow);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddAdBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();//_ContractSettings.T2PersonType
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if ((((_dtSeller.Rows.Count > 0) && (_dtSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtSeller.Rows.Count == 0)) &&
                        (((_dtBuyer.Rows.Count > 0) && (_dtBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtBuyer.Rows.Count == 0)) &&
                        (((_dtAdBuyer.Rows.Count > 0) && (_dtAdBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdBuyer.Rows.Count == 0)))
                    {
                        DataRow dr = _dtAdBuyer.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        if (p.SelectedPerson.PersonType == JPersonTypes.RealPerson)
                            dr["ClassNameEn"] = "Legal.JBuyerAdvocateContract";
                        else
                            dr["ClassNameEn"] = "Legal.JBuyerAdvocateContractLegal";
                        _dtAdBuyer.Rows.Add(dr);
                        jdgvAdBuyer.DataSource = _dtAdBuyer;
                    }
                    else
                        JMessages.Information("Person is Repeated", "Information");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelAdBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvAdBuyer.CurrentRow != null)
                    jdgvAdBuyer.Rows.Remove(jdgvAdBuyer.CurrentRow);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        private void jdgvAddBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                JPersonTypes pType = (JPersonTypes)(Convert.ToInt32(_ContractSettings.Items["T2PersonType"]));

                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(pType);//_ContractSettings.T2PersonType
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if (p.SelectedPerson.PersonType == JPersonTypes.LegalPerson)
                    {
                        JOrganization lPerson = new JOrganization(p.SelectedPerson.Code);
                        if (lPerson.SignatureMen.Rows.Count == 0)
                        {
                            JMessages.Error("برای این شخص حقوقی اطلاعات صاحبان امضاء وارد نشده است. در صورت عدم ورود این اطلاعات، ایجاد متن قرارداد با مشکل مواجه خواهد شد.", "");
                        }

                    }
                    if (((_dtBuyer.Rows.Count > 0) && (_dtBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtBuyer.Rows.Count == 0))
                    {
                        DataRow dr = _dtBuyer.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        if (p.SelectedPerson.PersonType == JPersonTypes.RealPerson)
                            dr["ClassNameEn"] = "Legal.JBuyerContract";
                        else
                            dr["ClassNameEn"] = "Legal.JBuyerContractLegal";
                        _dtBuyer.Rows.Add(dr);
                        jdgvBuyer.DataSource = _dtBuyer;
                        jdgvBuyer.Columns["Code"].ReadOnly = true;
                        jdgvBuyer.Columns["PersonCode"].ReadOnly = true;
                        jdgvBuyer.Columns["Name"].ReadOnly = true;
                    }
                    else
                        JMessages.Information("Person is Repeated", "Information");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvBuyer.CurrentRow != null)
                {
                    jdgvBuyer.Rows.Remove(jdgvBuyer.CurrentRow);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JContractTarefeForm_Load(object sender, EventArgs e)
        {
            //FillListTarefe();
        }

        private void FillListTarefe()
        {
            if (!(ContractForms.Contract.Confirmed))
            {
                if (ContractForms.Contract.FinanceCode != 0)
                {
                    //lvTarefe.DisplayMember = "FullName";
                    //lvTarefe.ValueMember = "Code";
                    Estates.JGroundSheet tmpJGroundSheet = new Estates.JGroundSheet();
                    Finance.JAsset tmpAsset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
                    //lvTarefe.DataSource = tmpJGroundSheet.ListTarefe(ContractForms.Contract.Code, tmpAsset.ObjectCode);
                    //if (lvTarefe.Items.Count > 0)
                    //    lvTarefe.SelectedIndex = 0;

                    jComboBox1.DisplayMember = "FullName1";
                    jComboBox1.ValueMember = "Code";
                    jComboBox1.DataSource = tmpJGroundSheet.ListTarefe(ContractForms.Contract.Code, tmpAsset.ObjectCode);
                }
            }
        }

        private void Fill_Data()
        {
            try
            {
                //if (ContractForms.Contract.FinanceCode != 0 && _FinanceCode == ContractForms.Contract.FinanceCode)
                //    return;
                _FinanceCode = ContractForms.Contract.FinanceCode;
                FillListTarefe();
                Set_Form();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        int _FinanceCode = 0;
        private void JContractTarefeForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            Fill_Data();
            // پر کردن کد قرارداد قبلی
            Estates.JGroundSheet tmpSheet = new Estates.JGroundSheet();
            tmpSheet.GetData(_SheetCodeSeller);
            ContractForms.Contract.PreContract = tmpSheet.ContractCodeBuy;
        }

        private void FillBuyer()
        {
            try
            {
                if (jComboBox1.Enabled)
                {
                    _SheetCodeSeller = Convert.ToInt32(jComboBox1.SelectedValue);
                    Estates.JGroundSheet tmpJGroundSheet = new Estates.JGroundSheet(_SheetCodeSeller);
                    _dtSeller = JPersonContract.GetAllDataTarefe(tmpJGroundSheet.ContractCodeBuy, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void txtTarefeCode_Leave(object sender, EventArgs e)
        {
            if (txtTarefeCode.Text != "")
                jComboBox1.SelectedValue = Convert.ToInt32(txtTarefeCode.Text);
        }

        private void jComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTarefeSell.Text = ((System.Data.DataRowView)(jComboBox1.SelectedItem)).Row["FullName"].ToString();
            _SheetCodeSeller = Convert.ToInt32(jComboBox1.SelectedValue);
            FillBuyer();
        }
    }
}
