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
    public partial class JSubjectContractForm : JBaseContractForm
    {

        int _FinanceCode;
        public JSubjectContractForm()
        {
            InitializeComponent();

            //JMessages.Information(ContractForms.Contract.Code.ToString(), "");

            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveListContract.ClassName = "Legal.JContract";
            jArchiveListContract.SubjectCode = 0;
            jArchiveListContract.PlaceCode = 0;
            SaveOrder = 1;
        }
  
        /// <summary>
        /// این تابع برای ساختن و فرستادن فرم بصورت داینامیک استفاده میشود
        /// </summary>
        /// <returns></returns>
        public JSubjectContractForm MakeForm()
        {
            JSubjectContractForm form = new JSubjectContractForm();
            return form;
        }

        #region Methods

        private void FillCombo()
        {
            try
            {
                //cmbLocation.DisplayMember = "name";
                //cmbLocation.ValueMember = "Code";
                //cmbLocation.DataSource = (new JOrganizations()).GetOrganization(0);

                JContractLocations locations = new JContractLocations();
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";
                cmbLocation.BaseCode = JBaseDefineLegal.ContractLocations;
                try
                {
                    //خواندن محل انجام قرارداد پیشفرض از رجیستری
                    object loc = Globals.JRegistry.Read("Legal.JSubjectContract.DefaultLocation");
                    locations.SetComboBox(cmbLocation, ContractForms.Contract.Location);
                    if (this.State == JStateContractForm.Insert)
                        cmbLocation.SelectedValue = loc;

                    object copyCount = Globals.JRegistry.Read("Legal.JSubjectContract.DefaultCopyCount");
                    txtCopycount.Value = Convert.ToDecimal(copyCount);
                }
                catch
                {
                }
                

                cmbSubject.DisplayMember = "Title";
                cmbSubject.ValueMember = "Code";
                cmbSubject.DataSource = JContractdefines.GetDataTable(0, ContractForms.Contract.ContractType.Code, null);
                //ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("Legal.ContractType"));
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void Set_Form()
        {
            try
            {
                JSubjectContract tmp = ContractForms.Contract;
                cmbSubject.SelectedValue = ContractForms.Contract.Type;
                txtContractNumber.Text = tmp.Number;
                txtDate.Date = tmp.Date;
                txtDateDeliver.Date = tmp.DateDeliver;
                txtdateStart.Date = tmp.StartDate;
                txtdateEnd.Date = tmp.EndDate;
                txtContractTitle.Text = tmp.ContractTitle;
                //cmbLocation.SelectedValue = tmp.Location;
                txtInfo.Text = tmp.Description;
                txtCopycount.Text = ContractForms.Contract.CopyCount.ToString();

                if (ContractForms.Contract.Code > 0)
                {
                    jArchiveListContract.ObjectCode = ContractForms.Contract.Code;
                    Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
                    SetCommentText(asset.ClassName, asset.ObjectCode);
                    _FinanceCode = asset.Code;
                }

                if (ContractForms.Contract.FinanceCode > 0)
                {
                    Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
                    SetCommentText(asset.ClassName, asset.ObjectCode);
                    _FinanceCode = ContractForms.Contract.FinanceCode;
                }

                if (State == JStateContractForm.View)
                {
                    txtbSubjectComment.ReadOnly = true;
                    txtContractNumber.ReadOnly = true;
                    txtDate.ReadOnly = true;
                    txtDateDeliver.ReadOnly = true;
                    txtdateEnd.ReadOnly = true;
                    txtdateStart.ReadOnly = true;
                    txtInfo.ReadOnly = true;

                    cmbLocation.Enabled = false;
                    cmbSubject.Enabled = false;
                    txtCopycount.Enabled = false;

                    jArchiveListContract.AllowUserAddFile = false;
                    jArchiveListContract.AllowUserAddFromArchive = false;
                    jArchiveListContract.AllowUserAddImage = false;
                    jArchiveListContract.AllowUserDeleteFile = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private bool ApplyData()
        {
            try
            {
                ApplyDataSet = true;
                ContractForms.Contract.FinanceCode = _FinanceCode;
                if ((Finance.JOwnershipType)ContractForms.Contract.ContractType.AssetTransferType == Finance.JOwnershipType.Rentals)
                {
                    if (State == JStateContractForm.Insert)
                        if (JTransferAssetAfterContract.AssetHasRentContract(ContractForms.Contract.FinanceCode, txtdateStart.Date))
                        {
                            if (JMessages.Question("این دارایی دارای قرارداد اجاره فعال است. امکان ثبت قرارداد اجاره جدید وجود ندارد. ", "قرارداد اجاره فعال") != DialogResult.Yes)
                                return false;
                        }
                }
                ContractForms.Contract.Type = Convert.ToInt32(cmbSubject.SelectedValue);
                ContractForms.Contract.Number = txtContractNumber.Text.Trim();
                ContractForms.Contract.Date = txtDate.Date;
                ContractForms.Contract.DateDeliver = txtDateDeliver.Date;
                ContractForms.Contract.StartDate = txtdateStart.Date;
                ContractForms.Contract.EndDate = txtdateEnd.Date;
                ContractForms.Contract.Location = Convert.ToInt32(cmbLocation.SelectedValue);// Convert.ToInt32(cmbLocation.SelectedValue);
                ContractForms.Contract.Description = txtInfo.Text.Trim();
                ContractForms.Contract.CopyCount = Convert.ToInt32(txtCopycount.Value);
                ContractForms.Contract.ContractTitle = txtContractTitle.Text;
                ContractForms.Contract.PersonGroup = GroupCode;

                Globals.JRegistry.Write("Legal.JSubjectContract.DefaultLocation", Convert.ToInt32(cmbLocation.SelectedValue));
                Globals.JRegistry.Write("Legal.JSubjectContract.DefaultCopyCount", Convert.ToInt32(txtCopycount.Value));
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error("با مدیر سیستم تماس بگیرید", "خطا");
                return false;
            }
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
                pDt.Columns.Add("Type");
                pDt.Columns.Add("TitleContract");
                pDt.Columns.Add("ContractNo");
                pDt.Columns.Add("Date");
                pDt.Columns.Add("StringDate");

                pDt.Columns.Add("DateDeliver");
                pDt.Columns.Add("StringDateDeliver");

                pDt.Columns.Add("StartDate");
                pDt.Columns.Add("StringStartDate");

                pDt.Columns.Add("EndDate");
                pDt.Columns.Add("StringEndDate");
                
                pDt.Columns.Add("Location");
                pDt.Columns.Add("FinanceCode");
                pDt.Columns.Add("Description");
                pDt.Columns.Add("Guarantee");
                pDt.Columns.Add("Condition");

                pDt.Columns.Add("T1Title");
                pDt.Columns.Add("T2Title");
                pDt.Columns.Add("CopyCount");

                pDt.Columns.Add("DateNow");

                if (pSetValue)
                {
                    if (pOffline)
                        Fill_Data();

                    pDt.Rows[0]["Type"] = cmbSubject.Text;
                    pDt.Rows[0]["TitleContract"] = txtContractTitle.Text;

                    //((ClassLibrary.JKeyValue)(cmbSubject.SelectedValue)).Value
                    pDt.Rows[0]["ContractNo"] = txtContractNumber.Text.Trim();
                    /// تاریخ به عدد و حروف
                    pDt.Rows[0]["Date"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtDate.Date));
                    pDt.Rows[0]["DateNow"] = JGeneral.ReverseDate(JDateTime.FarsiDate(DateTime.Now));
                    pDt.Rows[0]["StringDate"] = JDateTime.StringDate(txtDate.Text);
                    /// تاریخ تحویل به عدد و حروف
                    pDt.Rows[0]["DateDeliver"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtDateDeliver.Date));
                    pDt.Rows[0]["StringDateDeliver"] = JDateTime.StringDate(txtDateDeliver.Text);
                    /// تاریخ شروع به عدد و حروف
                    pDt.Rows[0]["StartDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtdateStart.Date));
                    pDt.Rows[0]["StringStartDate"] = JDateTime.StringDate(txtdateStart.Text);
                    /// تاریخ پایان به عدد و حروف
                    pDt.Rows[0]["EndDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtdateEnd.Date));
                    pDt.Rows[0]["StringEndDate"] = JDateTime.StringDate(txtdateEnd.Text);

                    pDt.Rows[0]["Location"] = cmbLocation.Text;
                    pDt.Rows[0]["FinanceCode"] = _FinanceCode;
                    pDt.Rows[0]["Description"] = txtInfo.Text.Trim();
                    /// عنوان طرف اول و دوم
                    pDt.Rows[0]["T1Title"] = ContractForms.Settings.Items["T1Lable"];
                    pDt.Rows[0]["T2Title"] = ContractForms.Settings.Items["T2Lable"];
                    pDt.Rows[0]["CopyCount"] = txtCopycount.Value.ToString();
                }

                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public override bool Save(JDataBase DB)
        {
            try
            {
                /// ویرایش قرارداد
                tempState = State;
                if (tempState == JStateContractForm.Insert)
                {
                    if (ContractForms.Contract.Code != 0)
                        ContractForms.Contract.PreContract = ContractForms.Contract.Code;
                    ContractForms.Contract.Code = 0;
                }
                if (ContractForms.Contract.Code > 0)
                {
                    if (ContractForms.Contract.Update(DB))
                    {
                        jArchiveListContract.ObjectCode = ContractForms.Contract.Code;
                        jArchiveListContract.ArchiveList();
                        return true;
                    }
                    else
                        return false;
                }
                else
                {                    
                    ContractForms.Contract.Code = ContractForms.Contract.Insert(DB);
                    if (ContractForms.Contract.Code > 0)
                    {
                        jArchiveListContract.ObjectCode = ContractForms.Contract.Code;
                        jArchiveListContract.ArchiveList();
                        return true;
                    }
                    else
                        return false;
                }
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

        public bool CheckData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                btmSearchGround_Click(null, null);

                if (!(Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["NoFinance"]))))
                if (_FinanceCode <= 0)
                {
                    JMessages.Information("Please Enter FinanceCode", "Information");
                    return false;
                }
                if (cmbSubject.SelectedValue == null)
                {
                    JMessages.Information("Please Enter Subject", "Information");
                    return false;
                }
                /// در صورتی که قرارداد باید با شماره و تاریخ ثبت شود (در تنظیمات نوع قرارداد مشخص میشود)
                if (txtContractNumber.Enabled)
                {
                    if (txtContractNumber.Text.Trim() == "")
                    {
                        JMessages.Information("لطفا شماره قرارداد را وارد کنید", "Information");
                        return false;
                    }
                   
                    if (txtdateEnd.Visible && txtdateStart.Visible)
                        if (DateTime.Compare(txtdateStart.Date, txtdateEnd.Date) >= 0)
                        {
                            JMessages.Information("Please Enter Campare Date", "Information");
                            return false;
                        }
                    if (txtDate.Date.Date == DateTime.MinValue)
                    {
                        JMessages.Information("Please Enter Date", "Information");
                        return false;
                    }
                    //if (txtDateDeliver.Visible)
                    //    if (txtDateDeliver.Date == DateTime.MinValue)
                    //{
                    //    JMessages.Information("Please Enter DateDeliver", "Information");
                    //    return false;
                    //}
                    if (txtdateStart.Visible)
                        if (txtdateStart.Date == DateTime.MinValue)
                        {
                            JMessages.Information("Please Enter StartDate", "Information");
                            return false;
                        }
                    if (txtdateEnd.Visible)
                        if (txtdateEnd.Date == DateTime.MinValue)
                        {
                            JMessages.Information("Please Enter EndDate", "Information");
                            return false;
                        }
                    if (cmbSubject.SelectedValue == null)
                    {
                        JMessages.Information("Please Enter Subject", "Information");
                        return false;
                    }
                    if (cmbLocation.SelectedItem == null)
                    {
                        JMessages.Information("Please Enter Location", "Information");
                        return false;
                    }
                    if (!(Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["NoFinance"]))))
                    if (JDistraint.CheckAssetIsBlock(_FinanceCode, txtDate.Date))
                    {
                        JMessages.Error("این دارایی توقیف شده است. امکان ثبت قرارداد وجود ندارد", "خطا");
                        return false;
                    }                    
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error("با مدیر سیستم تماس بگیرید", "خطا");
                return false;
            }
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAssetCode"></param>
        private void SetCommentText(string pClassName, int pObjectCode)
        {
            JAction CommentAction = new JAction("GetAssetType", pClassName + ".GetAssetComment", new object[] { pObjectCode }, null);
            string Comment = (string)CommentAction.run();

            JAction unitAction = new JAction("GetAssetType", pClassName + ".GetAssetUnit");
            string unit = (string)unitAction.run();

            //lblMaxCount.Text = " حداکثر" + JLanguages._Text(unit);
            //txtMaxCount.Text = tmp.MaxCount.ToString();
            txtbSubjectComment.Text = Comment;

        }

        private void btmSearchGround_Click(object sender, EventArgs e)
        {
            try
            {
                JContractdefine contractDefine = new JContractdefine(Convert.ToInt32(cmbSubject.SelectedValue));
                JContractDynamicType dynamicContract = new JContractDynamicType(contractDefine.ContractType);
                if ((_FinanceCode == 0) && ((!(Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["NoFinance"]))))))
                {
                    Finance.JAssetSearchForm searchForm = new Finance.JAssetSearchForm(false, dynamicContract.ClassName, dynamicContract.Code);
                    if (searchForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    _FinanceCode = searchForm._Code;
                }

                Finance.JAsset asset = new Finance.JAsset(_FinanceCode);
                if (asset.HasUnConfirmedContract() && (!(JContractFormsOrder.CheckForm(contractDefine.ContractType, "Legal.JContractTarefeForm"))) && (State != JStateContractForm.Update))
                {
                    _FinanceCode = 0;
                    JMessages.Error("برای این دارایی قرارداد تائید نشده ثبت شده است. لطفاً ابتدا قرارداد قبلی را تائید کنید.", "Error");
                    return;
                }
                /////////////////////////////////////////
                /// اگر قرارداد انتقال بود چک میکند که درخواست انتقال پاسخ داده شده یا خیر
                if ((dynamicContract.AssetTransferType == Finance.JOwnershipType.Goodwill.GetHashCode())
                    ||(dynamicContract.AssetTransferType == Finance.JOwnershipType.Definitive.GetHashCode())
                    || (dynamicContract.AssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode()))
                    try
                    {
                        if (Convert.ToBoolean(Convert.ToInt16(dynamicContract.ContractSettings.Items["Request"])))
                        {
                            if (asset.State == Finance.JAssetState.General)
                            {
                                _FinanceCode = 0;
                                JMessages.Error("برای این دارایی، درخواست انتقال نشده است. لطفا ابتدا فرم درخواست انتقال را پر کنید.", "Error");
                                return;
                            }
                            if (asset.State == Finance.JAssetState.Request)
                            {
                                _FinanceCode = 0;
                                JMessages.Error("با درخواست انتقال این دارایی موافقت نشده است", "Error");
                                return;
                            }
                        }
                    }
                    catch
                    {
                    }
                ///////////////////////////////////////

                //_FinanceCode = p._Code;
                if (asset.Code > 0)
                {
                    SetCommentText(asset.ClassName, asset.ObjectCode);
                    _FinanceCode = asset.Code;
                }
                txtCopycount.Focus();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

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
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ContractForms.Cancel();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void Fill_Data()
        {
            try
            {
                    FillCombo();
                  
                    if (ContractForms.Contract.Code > 0)
                    {
                        Set_Form();
                        //State = JStateContractForm.Change;
                        btmSearchGround.Enabled = false;

                        //Hassanzadeh
                        if (State == JStateContractForm.Insert)
                        {
                            txtdateStart.Date = DateTime.MinValue;
                            txtdateEnd.Date = DateTime.MinValue;
                            txtDate.Date = DateTime.Now;
                            txtContractNumber.Text = "0";
                            txtInfo.Text = "";
                        }
                    }
                    else
                    {
                        if (ContractForms.Contract.FinanceCode > 0)
                        {
                            Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
                            SetCommentText(asset.ClassName, asset.ObjectCode);
                            _FinanceCode = ContractForms.Contract.FinanceCode;
                        }

                    }
                    txtdateStart.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasStartDate"])));
                    lbStartDate.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasStartDate"])));

                    txtdateEnd.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasEndDate"])));
                    lbEndDate.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasEndDate"])));

                    txtDateDeliver.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasDeliverDate"])));
                    lbDeliverDate.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasDeliverDate"])));
                    
                    bool noContract = Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["NoContract"]));
                    bool noFinance = Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["NoFinance"]));
                    btmSearchGround.Enabled = !noFinance;
                
                    if (noContract)
                    {
                        foreach (Control ctrl in groupBox1.Controls)
                            ctrl.Enabled = !noContract;
                    }

                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
        }

        private void JSubjectContractForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Fill_Data();
                
            }
        }

        private void JSubjectContractForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }

        private void JSubjectContractForm_Load(object sender, EventArgs e)
        {
            txtContractNumber.Focus();
        }

        private void JSubjectContractForm_Shown(object sender, EventArgs e)
        {
            txtContractNumber.Focus();
        }
        //private void txtPartShare_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Convert.ToInt32(txtPartShare.Text) > Convert.ToInt32(txtMaxCount.Text))
        //        {
        //            txtPartShare.Text = "";
        //            JMessages.Information("مقدار ورودی بیشتر از حداکثر است", "");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //    }
        //}
    }
}
