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

    public partial class JPartiesForm : JBaseContractForm
    {

        DataTable _dtSeller = new DataTable();
        DataTable _dtAdSeller = new DataTable();
        DataTable _dtBuyer = new DataTable();
        DataTable _dtAdBuyer = new DataTable();
        DataTable _dtintuition = new DataTable();
        private JContractTypeSettings _ContractSettings;
        string StrSeller = "", StrAdSeller = "", StrBuyer = "", StrAdBuyer = "", Strintuition = "", StrShareBuyer = "", StrShareSeller = "";
        bool Flag = true;
        /// <summary>
        /// این تابع برای ساختن و فرستادن فرم بصورت داینامیک استفاده میشود
        /// </summary>
        /// <returns></returns>
        public JPartiesForm MakeForm()
        {
            JPartiesForm form = new JPartiesForm();
            return form;
        }

        #region Methods

        public JPartiesForm()
        {
            InitializeComponent();
        }


        private void GetPattern()
        {
            try
            {
                _dtSeller = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, 0, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType);
                _dtAdSeller = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, 0, ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate, (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType);
                _dtBuyer = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, 0, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType);
                _dtAdBuyer = JPersonContract.GetAdvocacyTable(0, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate.GetHashCode());
//                _dtAdBuyer = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, 0, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate, (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType);
                _dtintuition = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, 0, ClassLibrary.Domains.Legal.JPersonPetitionType.intuition, (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType);
                
                jdgvSeller.DataSource = _dtSeller;
                jdgvAdSeller.DataSource = _dtAdSeller;
                jdgvBuyer.DataSource = _dtBuyer;
                jdgvAdBuyer.DataSource = _dtAdBuyer;
                jdgvintuition.DataSource = _dtintuition;

                inVisibleColumns();

                TotalShare();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }


        private void inVisibleColumns()
        {
            inVisibleColumn(jdgvintuition, "Share", false);
            inVisibleColumn(jdgvintuition, "ClassNameEn", false);
            inVisibleColumn(jdgvintuition, "ClassNameEn", false);

            inVisibleColumn(jdgvAdSeller, "Share", false);
            inVisibleColumn(jdgvAdSeller, "ClassNameEn", false);

            inVisibleColumn(jdgvAdBuyer, "Share", false);
            inVisibleColumn(jdgvAdBuyer, "ClassNameEn", false);

            inVisibleColumn(jdgvSeller, "ClassNameEn", false);
            inVisibleColumn(jdgvSeller, "ContractSubjectCode", false);
            inVisibleColumn(jdgvSeller, "fASCode", false);
            inVisibleColumn(jdgvSeller, "Code", false);

            inVisibleColumn(jdgvBuyer, "ClassNameEn", false);
            inVisibleColumn(jdgvBuyer, "ContractSubjectCode", false);
            inVisibleColumn(jdgvBuyer, "fASCode", false);
            inVisibleColumn(jdgvBuyer, "Code", false);

            if (this.ContractForms.Contract.ContractType.ClassName == "")
            {
                inVisibleColumn(jdgvSeller, "Share", false);
                inVisibleColumn(jdgvSeller, "PersonShare", false);
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

        private bool TotalShare()
        {

            float ValuePerson = 0;
            float Value = 0;
            float ValueBuyer = 0;
            if (this.ContractForms.Settings.Items.Count >0 && Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString())))
            {
                foreach (DataRow dr in _dtSeller.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if ((float)Convert.ToDecimal(dr["PersonShare"]) < (float)Convert.ToDecimal(dr["Share"]))
                            return false;
                        ValuePerson = ValuePerson + (float)Convert.ToDecimal(dr["PersonShare"]);
                        Value = Value + (float)Convert.ToDecimal(dr["Share"]);
                    }
                }
                if (ValuePerson < Value)
                {
                    return false;
                }

                lblSeller.Text = ValuePerson.ToString();
                lbl.Text = Value.ToString();
            }
            if (this.ContractForms.Settings.Items.Count > 0 && Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString())))
            {
                foreach (DataRow dr in _dtBuyer.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if (dr["Share"].ToString() != "")
                            ValueBuyer = ValueBuyer + (float)Convert.ToDecimal(dr["Share"]);
                    }
                }
                if (Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString())))
                    if (Value < ValueBuyer)
                        return false;

                lblBuyer.Text = ValueBuyer.ToString();
            }
            return true;
        }

        private void Set_Setting()
        {
            try
            {
                _ContractSettings = this.ContractForms.Settings;
                /// ست کرن فرم بر اساس تنظیمات
                tabSellers.Text = _ContractSettings.Items["T1Lable"].ToString();
                tabBuyers.Text = _ContractSettings.Items["T2Lable"].ToString();
                this.Text = _ContractSettings.Items["PatiesFormName"].ToString();
                grpAdT1.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T1HasAdvocacy"]));
                grpAdT2.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T2HasAdvocacy"]));
                btnDelBuyer.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T2AddDelPerson"]));
                btnAddBuyer.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T2AddDelPerson"]));
                btnAddSeller.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T1AddDelPerson"]));
                btnDelSeller.Visible = Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["T1AddDelPerson"]));

                jdgvSeller.Columns["Share"].Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString()));
                jdgvSeller.Columns["PersonShare"].Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString()));
                lbSumTitle1.Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString()));
                lbSumTitle2.Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString()));
                lbl.Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString()));
                lblSeller.Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString()));

                jdgvBuyer.Columns["Share"].Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString()));
                lbSumTitle3.Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString()));
                lblBuyer.Visible = Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString()));
                

                if (!Convert.ToBoolean(Convert.ToInt16(_ContractSettings.Items["HasIntuition"])))
                {
                    tabControl.TabPages.Clear();
                    tabControl.TabPages.Add(tabSellers);
                    tabControl.TabPages.Add(tabBuyers);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        public void Set_Form()
        {
            try
            {
                if (_ContractSettings == null)
                    _ContractSettings = this.ContractForms.Settings;
                Finance.JOwnershipType ownerShipSeller = new Finance.JOwnershipType();
                Finance.JOwnershipType ownerShipBuyer = new Finance.JOwnershipType();
                try {
                    ownerShipSeller = (Finance.JOwnershipType)(Convert.ToInt32(_ContractSettings.Items["T1PersonOwnership"]));
                    ownerShipBuyer = (Finance.JOwnershipType)(Convert.ToInt32(_ContractSettings.Items["T2PersonOwnership"]));
                }
                catch
                {

                }

                if (State != JStateContractForm.View && State != JStateContractForm.Update)
                {                    
                    _dtSeller = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, ownerShipSeller);
                    //if (DifIfNotGoodwill1 && _dtSeller.Rows.Count == 0)
                    //    _dtSeller = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, Finance.JOwnershipType.Definitive);

                    _dtAdSeller = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate, ownerShipSeller); 
                    _dtBuyer = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, ownerShipBuyer); // (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType
                    _dtAdBuyer = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate, ownerShipBuyer); //(Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType
                    _dtintuition = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.intuition, (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType);
                }

                    /// در صورتی که فرم در حالت مشاهده باز شد
                else
                {
                    _dtSeller = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, ownerShipSeller, null);  //(Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType
                    //_dtAdSeller = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate, ownerShipSeller); // (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType
                    _dtAdSeller = JPersonContract.GetAdvocacyTable(ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate.GetHashCode());
                    _dtBuyer = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, ownerShipBuyer); // (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType

                    _dtAdBuyer = JPersonContract.GetAdvocacyTable(ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate.GetHashCode());
                    //_dtAdBuyer = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate, ownerShipBuyer); //(Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType
                    _dtintuition = JPersonContract.GetAllDataType(ContractForms.Contract.FinanceCode, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.intuition, (Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType);
                    
                    jdgvSeller.ReadOnly = true;
                    jdgvAdSeller.ReadOnly = true;
                    jdgvBuyer.ReadOnly = true;
                    jdgvAdBuyer.ReadOnly = true;
                    jdgvintuition.ReadOnly = true;

                    btnAddAdBuyer.Enabled = false;
                    if ((State == JStateContractForm.Update) && (!(ContractForms.Contract.Confirmed)))
                        //ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode())
                    {
                        btnAddBuyer.Enabled = true;
                        btnDelBuyer.Enabled = true;
                        jdgvBuyer.ReadOnly = false;
                    }
                    else
                    {
                        btnAddBuyer.Enabled = false;
                        btnDelBuyer.Enabled = false;
                    }
                    btnAddSeller.Enabled = false;
                    btnDelSeller.Enabled = false;
                    btnAddDaSeller.Enabled = false;
                    btnAddintuition.Enabled = false;
                    btnDelAdBuyer.Enabled = false;
                    btnDelAdSeller.Enabled = false;
                    btnDelintuition.Enabled = false;

                }
                jdgvSeller.DataSource = _dtSeller;
                jdgvAdSeller.DataSource = _dtAdSeller;
                jdgvBuyer.DataSource = _dtBuyer;
                jdgvAdBuyer.DataSource = _dtAdBuyer;
                jdgvintuition.DataSource = _dtintuition;

                inVisibleColumns();
                TotalShare();

                jdgvAdBuyer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                try {
                    jdgvAdSeller.Columns["AttorneyName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                catch
                {

                }
                jdgvBuyer.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                jdgvintuition.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                jdgvSeller.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                Set_Setting();
                //--------Hasanzadeh---------
                if ((Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Definitive)
                    if (_dtSeller.Rows.Count < 1)
                    {
                        JMessages.Error(" مالک قطعی برای این دارائی تعریف نشده لطفا ابتدا مالک قطعی را تعریف کنید ", "");
                        Flag = false;
                    }

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
                if (jdgvSeller.Rows.Count == 0)
                {
                    JMessages.Error("لطفا " + _ContractSettings.Items["T1Lable"].ToString() + " را مشخص کنید", "Error");
                    //tabSellers.Show();
                    tabControl.SelectedTab = tabSellers;
                    return false;
                }

                if (jdgvBuyer.Rows.Count == 0)
                {
                    JMessages.Error("لطفا " + _ContractSettings.Items["T2Lable"].ToString() + " را مشخص کنید", "Error");
                    tabControl.SelectedTab = tabBuyers;
                    return false;
                }

                //if (HasNoSignatureMen)
                //{
                //    JMessages.Error("شرکت / شرکتهای انتخاب شده دارای صاحب امضاء نمیباشند", "Error");
                //    return false;
                //}

                if (Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString())))
                {
                    if (Convert.ToDecimal(lbl.Text) <= 0)
                    {
                        JMessages.Error(" مقدار سهم طرف اول را وارد کنید", "خطا");
                        return false;
                    }
                }

                if (Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString())))
                {
                    if (Convert.ToDecimal(lblBuyer.Text) <= 0)
                    {
                        JMessages.Error(" مقدار سهم طرف دوم را وارد کنید", "خطا");
                        return false;
                    }
                }

                if (Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString())))
                    foreach (DataRow dr in _dtBuyer.Rows)
                        if(dr.RowState!= DataRowState.Deleted)
                            if (dr["Share"].ToString() == "0")
                            {
                                JMessages.Error(" مقدار سهم خریدار صفر نمی تواند باشد ", "خطا");
                                return false;
                            }

                if ((lblBuyer.Text == "0")
                    &&
                    Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString()))
                    &&
                    Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString())))
                {
                    JMessages.Error(" مقدار سهم خریدار صفر نمی تواند باشد ", "خطا");
                    return false;
                }

                if (!(Convert.ToDecimal(lbl.Text) == Convert.ToDecimal(lblBuyer.Text))
                    &&
                    Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T1HasValue"].ToString()))
                    &&
                    Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["T2HasValue"].ToString()))
                )
                {
                    JMessages.Error(" مقدار سهم فروخته شده با خرید یکی نیست", "خطا");
                    return false;
                }

                if (!TotalShare())
                {
                    JMessages.Error(" خطا در جمع خرید وفروش سهم ها لطفا مقدار سهم ها را درست وارد کنید .", "خطا");
                    return false;
                }

                /// مالک سرقفلی همان مالک قطعی باشد
                try
                {
                    if (State == JStateContractForm.Insert)
                        if (Convert.ToBoolean(int.Parse(this.ContractForms.Settings.Items["DefinitIsGoodwill"].ToString())))
                        {
                            if (!Finance.JAssetShares.CheckDifinitIsGoodwill(_FinanceCode))
                            {
                                JMessages.Error("مالک قطعی این دارایی باید مالک سرقفلی نیز باشد.", "Error");
                                return false;
                            }
                        }
                }
                catch
                {
                }

                #region Check Block
                foreach (DataRow row in _dtSeller.Rows)
                    if (row.RowState != DataRowState.Deleted)
                    {
                        int pCode = Convert.ToInt32(row["PersonCode"]);
                        if (JDistraint.CheckPersonIsBlock(pCode, ContractForms.Contract.Date))
                        {
                            JAllPerson person = new JAllPerson(pCode);
                            JMessages.Error("این شخص ممنوع المعامله است. امکان ثبت قرارداد وجود ندارد.", person.Name);
                            return false;
                        }
                        float _Share = 0;
                        if(row["Share"].ToString() != "")
                          _Share = Convert.ToInt32(row["Share"]);
                        if (JDistraint.CheckAssetShareIsBlock(_FinanceCode, pCode, _Share, ContractForms.Contract.Date))
                        {
                            JAllPerson person = new JAllPerson(pCode);
                            JMessages.Error("جزئی از دارایی این شخص توقیف شده است. امکان ثبت قرارداد وجود ندارد.", person.Name);
                            return false;
                        }
                    }
                foreach (DataRow row in _dtBuyer.Rows)
                    if (row.RowState != DataRowState.Deleted)
                    {
                        int pCode = Convert.ToInt32(row["PersonCode"]);
                        if (JDistraint.CheckPersonIsBlock(pCode, ContractForms.Contract.Date))
                        {
                            JAllPerson person = new JAllPerson(pCode);
                            JMessages.Error("این شخص ممنوع المعامله است. امکان ثبت قرارداد وجود ندارد.", person.Name);
                            return false;
                        }
                        //if(JDistraint.CheckAssetShareIsBlock()
                    }
                #endregion Check Block
                    
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
                    Estates.JGround ground= new Estates.JGround(asset.ObjectCode);
                    row["AreaShare"] =Math.Round(ground.Area / 6 * Convert.ToDouble(row["Share"]), 2);
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
                    row["AreaShare"] = Math.Round(ground.Area / 6 * Convert.ToDouble(row["PersonShare"]),2);
                }
            }
        }
        public bool ApplyData()
        {
            ContractForms.Contract.T1Person = _dtSeller;
            ContractForms.Contract.T2Person = _dtBuyer;
            AddAreaShareColumnBuyer(_dtBuyer);
            AddAreaShareColumnSeller(_dtSeller);
            DataTable DT = Finance.JComparativeCodes.GetDataMultiTafzili(JDataBase.DataTableToStringtArray(_dtBuyer, "Code"), "ClassLibrary.Person.AllPerson");
            if (DT != null && DT.Rows.Count == 1)
                BuyerTafziliCode = int.Parse(DT.Rows[0]["Value"].ToString());
            return true;
        }
 

        bool HasNoSignatureMen;
        private string GetPersonContractText(int PCode, string pDate)
        {
            JAllPerson AllPers = new JAllPerson(PCode);
            if (AllPers.PersonType == JPersonTypes.LegalPerson)
            {
                JPersonAddress Address = new JPersonAddress(PCode);
                JOrganization Org = new JOrganization(PCode, pDate);
                if (Org.SignatureList == null)
                    HasNoSignatureMen = true;
                return "شرکت "+ Org.Name + " ثبت شده به شماره " + Org.RegisterNo +" "+ Org.RegisterPlaceText +
                    " به نمایندگی " + String.Join(" و ", Org.SignatureListText.ToArray()) +
                    " به آدرس " + Address.FullAddress +
                    " وتلفن " + Address.Tel;
            }
            else
                if (AllPers.PersonType == JPersonTypes.RealPerson)
                {
                    JPerson Person = new JPerson(PCode);
                    JPersonAddress Address = new JPersonAddress(PCode);
                    if (!Person.NonIranian)
                    {
                        string strPerson = "";
                        if (Person.Gender)
                            strPerson = "آقای ";
                        else
                            strPerson = "خانم ";
                        strPerson = strPerson + Person.Name + " " + Person.Fam +
                        " فرزند " + Person.FatherName +
                        " به شماره شناسنامه " + Person.ShSh +
                        " صادره از " + Person.SaderText +
                        " متولد " + Person.BirthplaceCodeText +
                        " و کد ملی " + Person.ShMeli +
                        " و تلفن " + Address.Tel +
                        " به نشانی " + Address.FullAddress;
                        if (Address.Mobile != "" && Address.Mobile != null)
                            strPerson = strPerson + " تلفن همراه " + Address.Mobile;
                        
                        return strPerson;
                    }
                    else
                    {
                        string strPerson = "";
                        if (Person.Gender)
                            strPerson = "آقای ";
                        else
                            strPerson = "خانم ";
                        strPerson = strPerson + Person.Name + " " + Person.Fam +
                        " به شماره شناسایی " + Person.NonIranianSHCode +
                            " و شماره خانوار " + Person.NonIranianFamilyCode +
                                " فرزند " + Person.FatherName +
                                    " صادره از " + Person.SaderText +
                            //" متولد " + Person.BirthplaceCodeText +
                                            " به نشانی " + Address.FullAddress +
                                                " و تلفن " + Address.Tel;
                        if (Address.Mobile != "" && Address.Mobile != null)
                            strPerson = strPerson + " تلفن همراه " + Address.Mobile;
                        return strPerson;
                    }
                }
            return "";
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

        public override bool SavePreview(DataTable pDt)
        {
            return SavePreview(pDt, true, false);
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
                pDt.Columns.Add("StrSeller");
                pDt.Columns.Add("T1ShareCount");
                pDt.Columns.Add("T2ShareCount");
                pDt.Columns.Add("T1AreaShare");
                pDt.Columns.Add("T2AreaShare");
                pDt.Columns.Add("StrSellerSign");
                pDt.Columns.Add("StrNameSarghofli2");
                pDt.Columns.Add("SellerTafziliCode");
                pDt.Columns.Add("BuyerTafziliCode");

                pDt.Rows[0]["SellerTafziliCode"] = SellerTafziliCode;
                pDt.Rows[0]["BuyerTafziliCode"] = BuyerTafziliCode;

                pDt.Columns.Add("SumDongs");
                if (pSetValue)
                {
                    if (pOffline)
                        Fill_Data();

                    // نفر دوم مالک سرقفلی
                    pDt.Rows[0]["StrNameSarghofli2"] = JPersonContract.GetNameSarghofli2(_FinanceCode);

                    /// مشخصاات طرف اول
                    foreach (DataRow dr in _dtSeller.Rows)
                    {
                        tempList.Add(GetPersonContractText((int)dr["PersonCode"], JDateTime.FarsiDate(ContractForms.Contract.Date)));
                    }
                    pDt.Rows[0]["StrSeller"] = String.Join("\r", tempList.ToArray());
                    tempList.Clear();
                    /// امضاء طرف اول
                    foreach (DataRow dr in _dtSeller.Rows)
                    {
                        tempList.Add(GetPersonContractSignText((int)dr["PersonCode"]));
                    }
                    pDt.Rows[0]["StrSellerSign"] = String.Join(" \r ", tempList.ToArray());//و
                    tempList.Clear();

                    /// میزان سهم طرف اول
                    foreach (DataRow dr in _dtSeller.Rows)
                    {
                        tempList.Add(dr["Name"].ToString() + " به نسبت " + dr["Share"].ToString() + JLanguages._Text("DongFrom") + dr["PersonShare"].ToString() + JLanguages._Text("Dong"));
                    }
                    pDt.Rows[0]["T1ShareCount"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();

                    /// میزان سهم از متراژ طرف اول
                    foreach (DataRow dr in _dtSeller.Rows)
                    {
                        if (_dtSeller.Columns.Contains("AreaShare"))
                        tempList.Add(dr["Name"].ToString() + " به نسبت " + dr["AreaShare"].ToString() + JLanguages._Text("Metr"));// + dr[""].ToString());
                    }
                    pDt.Rows[0]["T1AreaShare"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();
                    /// میزان سهم از متراژ طرف دوم
                    foreach (DataRow dr in _dtBuyer.Rows)
                    {
                        if (_dtBuyer.Columns.Contains("AreaShare"))
                        tempList.Add(dr["Name"].ToString() + " به نسبت " + dr["AreaShare"].ToString() + JLanguages._Text("Metr"));// + JLanguages._Text("ShareFrom") + dr[""].ToString());
                    }
                    pDt.Rows[0]["T2AreaShare"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();


                    /// میزان سهم طرف دوم
                    foreach (DataRow dr in _dtBuyer.Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            tempList.Add(dr["Name"].ToString() + " به نسبت " + dr["Share"].ToString() + JLanguages._Text("Dong"));
                    }
                    pDt.Rows[0]["T2ShareCount"] = String.Join(" و ", tempList.ToArray());
                    tempList.Clear();
                    
                    pDt.Rows[0]["SumDongs"] = lbl.Text;
                }

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

                pDt.Columns.Add("StrBuyer");
                pDt.Columns.Add("StrBuyerSign");
                if (pSetValue)
                {
                    foreach (DataRow dr in _dtBuyer.Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            tempList.Add(GetPersonContractText((int)dr["PersonCode"], JDateTime.FarsiDate(ContractForms.Contract.Date)));
                    }
                    pDt.Rows[0]["StrBuyer"] = String.Join("\r", tempList.ToArray());
                    tempList.Clear();
                    foreach (DataRow dr in _dtBuyer.Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            tempList.Add(GetPersonContractSignText((int)dr["PersonCode"]));
                    }
                    pDt.Rows[0]["StrBuyerSign"] = String.Join(" \r ", tempList.ToArray());//و
                    tempList.Clear();
                }

                pDt.Columns.Add("StrAdBuyer");
                pDt.Columns.Add("StrAdBuyerSign");
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
                        if (_dtAdBuyer != null)
                            foreach (DataRow dr in _dtAdBuyer.Rows)
                            {
                                tempList.Add(GetPersonContractSignText((int)dr["PersonCode"]));
                            }
                        pDt.Rows[0]["StrAdBuyerSign"] = String.Join(" \r ", tempList.ToArray());//و
                        tempList.Clear();
                    }
                }

                pDt.Columns.Add("Strintuition");
                pDt.Columns.Add("StrintuitionSign");
                if (pSetValue)
                {
                    foreach (DataRow dr in _dtintuition.Rows)
                    {
                        tempList.Add(GetPersonContractText((int)dr["PersonCode"], JDateTime.FarsiDate(ContractForms.Contract.Date)));
                    }
                    pDt.Rows[0]["Strintuition"] = String.Join("\r", tempList.ToArray());
                    tempList.Clear();
                    foreach (DataRow dr in _dtintuition.Rows)
                    {
                        tempList.Add(GetPersonContractSignText((int)dr["PersonCode"]));
                    }
                    pDt.Rows[0]["StrintuitionSign"] = String.Join(" \r ", tempList.ToArray());//و
                    tempList.Clear();
                }

                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
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
                    JPersonContract tmpAdSeller = new JPersonContract();
                    JPersonContract tmpBuyer = new JPersonContract();
                    JPersonContract tmpAdBuyer = new JPersonContract();
                    JPersonContract tmpIntuition = new JPersonContract();
                    if (!tmpSeller.Insert(_dtSeller, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller, tempdb))
                        return false;
                    if (!tmpAdSeller.Insert(_dtAdSeller, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.SellerAdvocate, tempdb))
                        return false;
                    if (!tmpBuyer.Insert(_dtBuyer, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, tempdb))
                        return false;
                    if (!tmpAdBuyer.Insert(_dtAdBuyer, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.BuyerAdvocate, tempdb))
                        return false;
                    if (!tmpIntuition.Insert(_dtintuition, ContractForms.Contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.intuition, tempdb))
                        return false;
                    isSave = true;
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

        int _FinanceCode = 0;
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if(Flag)
                if (CheckData() && ApplyData())
                {
                    ContractForms.NextForm();
                }
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

        private void jdgvAddBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                JPersonTypes pType = (JPersonTypes)(Convert.ToInt32(_ContractSettings.Items["T2PersonType"]));
               
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(pType);//_ContractSettings.T2PersonType
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    //if ((((_dtSeller.Rows.Count > 0) && (_dtSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtSeller.Rows.Count == 0)) &&
                    //    (((_dtBuyer.Rows.Count > 0) && (_dtBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtBuyer.Rows.Count == 0)) &&
                    //    (((_dtAdBuyer.Rows.Count > 0) && (_dtAdBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdBuyer.Rows.Count == 0)) &&
                    //    (((_dtintuition.Rows.Count > 0) && (_dtintuition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtintuition.Rows.Count == 0)) &&
                    //    (((_dtAdSeller.Rows.Count > 0) && (_dtAdSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdSeller.Rows.Count == 0)))
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
                    TotalShare();
                }
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
                        (((_dtAdBuyer.Rows.Count > 0) && (_dtAdBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdBuyer.Rows.Count == 0)) &&
                        (((_dtintuition.Rows.Count > 0) && (_dtintuition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtintuition.Rows.Count == 0)) &&
                        (((_dtAdSeller.Rows.Count > 0) && (_dtAdSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdSeller.Rows.Count == 0)))
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
                        (((_dtintuition.Rows.Count > 0) && (_dtintuition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtintuition.Rows.Count == 0)) &&
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

        private void btnAddintuition_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(JPersonTypes.RealPerson);//
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    /// جستجوی فرد انتخاب شده در اطلاعات قبلی
                    if ((((_dtSeller.Rows.Count > 0) && (_dtSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtSeller.Rows.Count == 0)) &&
                        (((_dtBuyer.Rows.Count > 0) && (_dtBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtBuyer.Rows.Count == 0)) &&
                        (((_dtAdBuyer.Rows.Count > 0) && (_dtAdBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdBuyer.Rows.Count == 0)) &&
                        (((_dtintuition.Rows.Count > 0) && (_dtintuition.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtintuition.Rows.Count == 0)) &&
                        (((_dtAdSeller.Rows.Count > 0) && (_dtAdSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtAdSeller.Rows.Count == 0)))
                    {
                        DataRow dr = _dtintuition.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        if (p.SelectedPerson.PersonType == JPersonTypes.RealPerson)
                            dr["ClassNameEn"] = "Legal.JIntuitionContract";
                        else
                            dr["ClassNameEn"] = "Legal.JIntuitionContractLegal";
                        //dr["PersonType"] = p.SelectedPerson.PersonType;
                        _dtintuition.Rows.Add(dr);
                        jdgvintuition.DataSource = _dtintuition;
                        //btnSave.Enabled = true;
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

        private void btnDelintuition_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvintuition.CurrentRow != null)
                    jdgvintuition.Rows.Remove(jdgvintuition.CurrentRow);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }

        private void jdgvSeller_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!TotalShare())
            {
                if (State != JStateContractForm.View)
                    //if (Convert.ToInt32(lblSeller.Text) < Convert.ToInt32(lbl.Text))
                    JMessages.Information("جمع سهام با جمع سهام فروش درست نمیباشد .", "");

            }
        }

        private void jdgvBuyer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ContractForms.Contract.Confirmed)
            {
               // btnAddBuyer.Enabled = false;
               // btnDelBuyer.Enabled = false;
                btnAddSeller.Enabled = false;
                btnDelSeller.Enabled = false;
            }
            if (!TotalShare())
                if (State != JStateContractForm.View)

                    //if (Convert.ToInt32(lbl.Text) < Convert.ToInt32(lblBuyer.Text))
                    JMessages.Information("جمع سهام قابل فروش با جمع سهام خرید درست نمیباشد .", "");
        }

        private void Fill_Data()
        {
            try
            {
                if (ContractForms.Contract.FinanceCode != 0 && _FinanceCode == ContractForms.Contract.FinanceCode)
                    return;
                _FinanceCode = ContractForms.Contract.FinanceCode;
                //GetPattern();
                Set_Form();
                if (ContractForms.Contract.Code > 0)
                {

                    JAdvocacy tmp = new JAdvocacy();
                    //بدست آوردن نوع قرارداد از روی ثبت اطلاعات متن فایل قرارداد
                    //برای اینکه نوع قرارداد همان نوع پرسه ها در وکالت است
                    JContractdefine tmpL = new JContractdefine(ContractForms.Contract.Type);
                    foreach (DataRow dr in tmp.ListVicarious(tmpL.ContractType, ContractForms.Contract.FinanceCode).Rows)// );//
                    {
                        DataRow dr1 = _dtAdSeller.NewRow();
                        JAllPerson Allp = new JAllPerson((int)dr["PCode"]);

                        dr1["PersonCode"] = dr["Person_Code"];
                        dr1["Name"] = dr["Name"];
                        //dr1["PersonShare"] = dr["PersonShare"];
                        //dr1["Share"] = 0;
                        if (Allp.PersonType == JPersonTypes.RealPerson)
                            dr1["ClassNameEn"] = "Legal.JSellerAdvocateContract";
                        else
                            dr1["ClassNameEn"] = "Legal.JSellerAdvocateContractLegal";
                        _dtAdSeller.Rows.Add(dr1);
                    }

                    jdgvAdSeller.DataSource = _dtAdSeller;
                    jdgvSeller.Columns["FASCode"].Visible = false;
                    jdgvSeller.Columns["Code"].ReadOnly = true;
                    jdgvSeller.Columns["PersonCode"].ReadOnly = true;
                    jdgvSeller.Columns["PersonShare"].ReadOnly = true;

                }
                TotalShare();
                if (ContractForms.Contract.Code != 0)
                    Set_Form();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        private void JPartiesForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;
            //if (_FinanceCode == ContractForms.Contract.FinanceCode)
                //return;
            Fill_Data();
        }

        private void JPartiesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }

        private void btnAddSeller_Click(object sender, EventArgs e)
        {
            try
            {
                JPersonTypes pType = (JPersonTypes)(Convert.ToInt32(_ContractSettings.Items["T1PersonType"]));

                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(pType);//_ContractSettings.T2PersonType
                if (p.ShowDialog() != DialogResult.OK)
                    return;
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
                    if (((_dtSeller.Rows.Count > 0) && (_dtSeller.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtSeller.Rows.Count == 0))
                    {

                        DataRow dr = _dtSeller.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        if (p.SelectedPerson.PersonType == JPersonTypes.RealPerson)
                            dr["ClassNameEn"] = "Legal.JSellerContract";
                        else
                            dr["ClassNameEn"] = "Legal.JSellerContractLegal";
                        _dtSeller.Rows.Add(dr);
                        jdgvSeller.DataSource = _dtSeller;
                        jdgvSeller.Columns["Code"].ReadOnly = true;
                        jdgvSeller.Columns["PersonCode"].ReadOnly = true;
                        jdgvSeller.Columns["Name"].ReadOnly = true;
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

        private void btnDelSeller_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvSeller.CurrentRow != null)
                {
                    jdgvSeller.Rows.Remove(jdgvSeller.CurrentRow);
                    TotalShare();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private List<JAction> CreateActions(int pPersonCode)
        {
            List<JAction> actions = new List<JAction>();
            ///  مشخصات شخص
            int pCode = pPersonCode;
            JAction personAction = new JAction();
            JAllPerson allPerson = new JAllPerson(pCode);
            if (allPerson.PersonType == JPersonTypes.RealPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", null, new object[] { pCode });
            else if (allPerson.PersonType == JPersonTypes.LegalPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", null, new object[] { pCode });
            actions.Add(personAction);
            return actions;
        }

        private void jdgvSeller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (jdgvSeller.RowCount > 0)
            {
                jdgvSeller.ClearActions();
                List<JAction> actions = CreateActions(Convert.ToInt32(jdgvSeller.Rows[e.RowIndex].Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    jdgvSeller.AddAction(action);
                }
            }
        }

        private void jdgvBuyer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (jdgvBuyer.RowCount > 0)
            {
                jdgvBuyer.ClearActions();
                List<JAction> actions = CreateActions(Convert.ToInt32(jdgvBuyer.Rows[e.RowIndex].Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    jdgvBuyer.AddAction(action);
                }
            }
        }

        private void jdgvSeller_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RefreshAdvocacyT1();
        }

        private void jdgvSeller_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void RefreshAdvocacyT1()
        {
            if (State == JStateContractForm.View || State == JStateContractForm.Update)
                return;

            JAdvocacySubjects currentSubject;
            /// قرارداد انتقال قطعی
            if (ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Definitive.GetHashCode())
                currentSubject = JAdvocacySubjects.DefinitiveContractAT1;

            /// قرارداد انتقال سرقفلی
            else  if (ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Goodwill.GetHashCode())
                currentSubject = JAdvocacySubjects.GoodwillContractAT1;

            /// قرارداد اجاره 
            else if (ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode())
                currentSubject = JAdvocacySubjects.RentContractAT1;

            /// قرارداد صلح سرقفلی
            else if (ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.GoodwillPeace.GetHashCode())
                currentSubject = JAdvocacySubjects.RentGoodwillContract;
            else
                currentSubject = JAdvocacySubjects.AllSubjects;
            DataTable AdvocacyT1 = null;
            foreach (DataRow row in _dtSeller.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;
                int pCode = Convert.ToInt32(row["PersonCode"]);
                if (AdvocacyT1 == null)
                    AdvocacyT1 = JAdvocacys.GetAdvocacy(pCode, ContractForms.Contract.Date, currentSubject, _FinanceCode);
                else
                    AdvocacyT1.Merge(JAdvocacys.GetAdvocacy(pCode, ContractForms.Contract.Date, currentSubject, _FinanceCode));
            }
            jdgvAdSeller.DataSource = AdvocacyT1;
            _dtAdSeller = AdvocacyT1;
        }

        private void jdgvBuyer_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            RefreshAdvocacyT2();
        }

        private void RefreshAdvocacyT2()
        {
            if (State == JStateContractForm.View || State == JStateContractForm.Update)
                return; 
            JAdvocacySubjects currentSubject;
            /// قرارداد انتقال قطعی
            if (ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Definitive.GetHashCode())
                currentSubject = JAdvocacySubjects.DefinitiveContractAT2;

            /// قرارداد انتقال سرقفلی
            if (ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Goodwill.GetHashCode())
                currentSubject = JAdvocacySubjects.GoodwillContractAT2;

            /// قرارداد اجاره 
            if (ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode())
                currentSubject = JAdvocacySubjects.RentContractAT2;

            /// قرارداد صلح سرقفلی
            if (ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.GoodwillPeace.GetHashCode())
                currentSubject = JAdvocacySubjects.RentGoodwillContract;
            else
                currentSubject = JAdvocacySubjects.AllSubjects;
            DataTable AdvocacyT2 = null;
            foreach (DataRow row in _dtBuyer.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;
                int pCode = Convert.ToInt32(row["PersonCode"]);

                if (AdvocacyT2 == null)
                    AdvocacyT2 = JAdvocacys.GetAdvocacy(pCode, ContractForms.Contract.Date, currentSubject, _FinanceCode);
                else
                    AdvocacyT2.Merge(JAdvocacys.GetAdvocacy(pCode, ContractForms.Contract.Date, currentSubject, _FinanceCode));
            }
            jdgvAdBuyer.DataSource = AdvocacyT2;
            _dtAdBuyer = AdvocacyT2;
        }

        private void jdgvBuyer_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void jdgvBuyer_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            RefreshAdvocacyT2();
        }

        private void jdgvSeller_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            RefreshAdvocacyT1();
        }
    }

}
