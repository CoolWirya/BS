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

namespace Legal
{
    public partial class JContractDynamicTypeForm : JBaseForm
    {
        private DataTable FormPropertiesDT;
        private string CurrentFormName;

        private JContractDynamicType _DynamicType = new JContractDynamicType();
        public JContractDynamicTypeForm()
        {
            InitializeComponent();
            LoadComboBox();
            LoadForms();
            btnOK.Enabled = true;
            jDefinePropertyUserControl1.ClassName = "Legal.JContractDynamicTypeForm";

            InitFormPropertiesDT(0);
        }

        public JContractDynamicTypeForm(int pCode)
        {
            State = JFormState.Update;
            InitializeComponent();
            LoadForms(false);
            _DynamicType.GetData(pCode);
            LoadComboBox();
            ShowData();
            EnableEdit();

            jDefinePropertyUserControl1.ObjectCode = pCode;
            jDefinePropertyUserControl1.ClassName = "Legal.JContractDynamicTypeForm";

            InitFormPropertiesDT(pCode);
        }

        private void InitFormPropertiesDT(int pCode)
        {
            JContractPropertiesForm ContarctForms = new JContractPropertiesForm();
            FormPropertiesDT = ContarctForms.GetDataTable(pCode);
        }

        private void LoadTexts()
        {
            grdTexts.DataSource = JContractdefines.GetDataTable(0, _DynamicType.Code, null);
            grdTexts.ReadOnly = true;
            grdTexts.Columns["ContractType"].Visible = false;
            grdTexts.Columns["FileCode"].Visible = false;
        }
        private void ShowData()
        {
            txtTitle.Text = _DynamicType.Title;
            cmbTransfetType.Text = JLanguages._Text(Enum.GetName(typeof(Finance.JOwnershipType), _DynamicType.AssetTransferType));
            LoadTexts();
            chTransferAsset.Checked = _DynamicType.TransferAsst;
            if (_DynamicType.PrtClassName != null)
                cmbClassName.SelectedValue = _DynamicType.PrtClassName;
            if (_DynamicType.PrtObjectCode != null)
                cmbObjectCode.SelectedValue = _DynamicType.PrtObjectCode;
            if (State == JFormState.Update)
            {
                #region Fill CheckListBox if Update

                _DynamicType.ContractForms.LoadAll(_DynamicType.Code);
                _DynamicType.ContractSettings.LoadAll(_DynamicType.Code);

                int i = 0;
                foreach (JContractFormsOrder orderForm in _DynamicType.ContractForms.Items)
                {
                    chListForms.Items.Add(orderForm);
                    chListForms.SetItemChecked(i++, orderForm.Show);
                }
                #endregion Fill CheckListBox

                #region Load Settings
                try
                {
                    chT1HasAdvocacy.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["T1HasAdvocacy"]);
                    chHasIntuition.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["HasIntuition"]);
                    chT1HasValue.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["T1HasValue"]);
                    chT2HasAdvocacy.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["T2HasAdvocacy"]);
                    chT2HasValue.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["T2HasValue"]);
                    txtPatiesFormName.Text = _DynamicType.ContractSettings.Items["PatiesFormName"].ToString();
                    txtT1Lable.Text = _DynamicType.ContractSettings.Items["T1Lable"].ToString();
                    txtT2Lable.Text = _DynamicType.ContractSettings.Items["T2Lable"].ToString();
                    txtWitnessCount.Text = _DynamicType.ContractSettings.Items["WitnessCount"].ToString();
                    cmbT1PersonType.SelectedIndex = Convert.ToInt32(_DynamicType.ContractSettings.Items["T1PersonType"]);
                    cmbT2PersonType.SelectedIndex = Convert.ToInt32(_DynamicType.ContractSettings.Items["T2PersonType"]);
                    chHasStartDate.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["HasStartDate"]);
                    chHasEndDate.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["HasEndDate"]);
                    chHasDeliverDate.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["HasDeliverDate"]);
                    //chJob.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["JobHasNoChange"]);


                    cmbPerson1Ownership.Text = ClassLibrary.JLanguages._Text(System.Enum.GetName(typeof(Finance.JOwnershipType), System.Convert.ToInt32(_DynamicType.ContractSettings.Items["T1PersonOwnership"].ToString())));
                    cmbPerson2Ownership.Text = JLanguages._Text(Enum.GetName(typeof(Finance.JOwnershipType), Convert.ToInt32(_DynamicType.ContractSettings.Items["T2PersonOwnership"].ToString())));
                    //cmbPerson2Ownership.SelectedValue= Convert.ToInt32(_DynamicType.ContractSettings.Items["T2PersonOwnership"].ToString());

                    chT1AddDelPerson.Checked = Convert.ToBoolean(Convert.ToInt16(_DynamicType.ContractSettings.Items["T1AddDelPerson"]));
                    chT2AddDelPerson.Checked = Convert.ToBoolean(Convert.ToInt16(_DynamicType.ContractSettings.Items["T2AddDelPerson"]));

                    //chDifinitGoodwill1.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["DifIfNotGoodwill1"]);
                    //chDifinitGoodwill2.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["DifIfNotGoodwill2"]);
                    chDefinitIsGoodwill.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["DefinitIsGoodwill"]);
                    chEstenkafRight.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["HasEstenkafRight"]);
                    chPriceCancel.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["HasPriceCancel"]);
                    chRequest.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["Request"]);
                    chNoContract.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["NoContract"]);
                    chkNoFinance.Checked = ConvertToBoolean(_DynamicType.ContractSettings.Items["NoFinance"]);
                }
                catch (Exception ex)
                {
                    JMessages.Error("خطا در خواندن تنظیمات", "");
                }
                #endregion Load Settings

                #region Show Default Prices
                txtRealPercent.Text = _DynamicType.RealPercent.ToString();
                txtPrice.Text = _DynamicType.AllPrice.ToString();
                txtInstallmentPercent.Text = _DynamicType.InstallmentPercent.ToString();
                txtInstallmentCount.Text = _DynamicType.InstallmentCount.ToString();
                txtEndPricePercent.Text = _DynamicType.EndPricePercent.ToString();
                #endregion Show Default Prices
            }
        }

        private bool ConvertToBoolean(object pBool)
        {
            try
            {
                if (pBool == null)
                    return false;
                return Convert.ToBoolean(Convert.ToInt32(pBool.ToString()));
            }
            catch
            {
                return false;
            }
        }

        public void LoadComboBox()
        {
            foreach (JAssetType type in JAsset.GetAssetType())
            {
                cmbAssetType.Items.Add(type);
                if (type.ClassName == _DynamicType.ClassName)
                    cmbAssetType.SelectedItem = type;
            }
            /// انواع مالکیت
            cmbTransfetType.DisplayMember = "name";
            cmbTransfetType.ValueMember = "value";
            cmbTransfetType.DataSource = ClassLibrary.JMainFrame.EnumToListBox(typeof(Finance.JOwnershipType));
            /// انواع مالکیت اشخاص 1
            cmbPerson1Ownership.DisplayMember = "name";
            cmbPerson1Ownership.ValueMember = "value";
            cmbPerson1Ownership.DataSource = ClassLibrary.JMainFrame.EnumToListBox(typeof(Finance.JOwnershipType)); //JPersonOwnerShips

            /// انواع مالکیت اشخاص 2
            cmbPerson2Ownership.DisplayMember = "name";
            cmbPerson2Ownership.ValueMember = "value";
            cmbPerson2Ownership.DataSource = ClassLibrary.JMainFrame.EnumToListBox(typeof(Finance.JOwnershipType)); //JPersonOwnerShips       

            cmbClassName.DataSource = Globals.Property.JProperties.GetAllProperties();
            cmbClassName.DisplayMember = "FaClassName";
            cmbClassName.ValueMember = "ClassName";

            if (cmbClassName.SelectedValue != null)
            {
                cmbObjectCode.DataSource = Globals.Property.JProperties.GetAllObjectCode(cmbClassName.SelectedValue.ToString());
                cmbObjectCode.DisplayMember = "ObjectCode";
                cmbObjectCode.ValueMember = "ObjectCode";
            }

            #region chAssetGroup

            DataTable _DT = new DataTable();
            if (_DynamicType.Code > 0)
            {
                JContractTypeGroups ContractsGroup = new JContractTypeGroups(_DynamicType.Code);
                _DT = ContractsGroup.GetData(null);
            }

            JAssetGroup AssetGroup = new JAssetGroup();
            DataTable DTAssetGroup = AssetGroup.GetDataTable();
            foreach (DataRow _DR in DTAssetGroup.Rows)
            {
                JAssetGroup _AssetGroup = new JAssetGroup();
                JTable.SetToClassProperty(_AssetGroup, _DR);
                if (_DynamicType.Code > 0)
                {
                    chBoxAssetGroup.Items.Add(_AssetGroup, _DT.Select("FinanceGroup = " + _DR["Code"].ToString()).Length > 0);
                }
                else
                {
                    chBoxAssetGroup.Items.Add(_AssetGroup);
                }

            }
            #endregion


        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadForms()
        {
            LoadForms(true);
        }

        private void LoadForms(bool pSetInListBox)
        {
            #region Fill CheckListBox if Insert
            //if (State == JFormState.Insert)
            {
                // فرم موضوع قرارداد
                JContractFormsOrder subjectForm = new JContractFormsOrder();
                subjectForm.FormName = "Legal.JSubjectContractForm";
                subjectForm.Show = true;
                _DynamicType.ContractForms.Items.Add(subjectForm);

                // فرم تعرفه قرارداد
                JContractFormsOrder TarefeForm = new JContractFormsOrder();
                TarefeForm.FormName = "Legal.JContractTarefeForm";
                TarefeForm.Show = false;
                _DynamicType.ContractForms.Items.Add(TarefeForm);

                //فرم طرفین قرارداد
                JContractFormsOrder partiesForm = new JContractFormsOrder();
                partiesForm.FormName = "Legal.JPartiesForm";
                partiesForm.Show = true;
                _DynamicType.ContractForms.Items.Add(partiesForm);

                //تعهدات و شروط قرارداد
                JContractFormsOrder commForm = new JContractFormsOrder();
                commForm.FormName = "Legal.JCommitmentsForm";
                commForm.Show = true;
                _DynamicType.ContractForms.Items.Add(commForm);

                //مبالغ قرارداد
                JContractFormsOrder priceForm = new JContractFormsOrder();
                priceForm.FormName = "Legal.JContractPriceForm";
                priceForm.Show = true;
                _DynamicType.ContractForms.Items.Add(priceForm);

                //فرم اجاره
                JContractFormsOrder rentForm = new JContractFormsOrder();
                rentForm.FormName = "Legal.JRentForm";
                rentForm.Show = true;
                _DynamicType.ContractForms.Items.Add(rentForm);

                //فرم اجاره مشاعات
                JContractFormsOrder envForm = new JContractFormsOrder();
                envForm.FormName = "Legal.JEnviromentForm";
                envForm.Show = true;
                _DynamicType.ContractForms.Items.Add(envForm);

                // فرم حکم دادگاه
                JContractFormsOrder desicionForm = new JContractFormsOrder();
                desicionForm.FormName = "Legal.JDecisionForm1";
                desicionForm.Show = true;
                _DynamicType.ContractForms.Items.Add(desicionForm);

                ///فرم صلح سرقفلی
                JContractFormsOrder goodwillForm = new JContractFormsOrder();
                goodwillForm.FormName = "Legal.JGoodwillForm";
                goodwillForm.Show = true;
                _DynamicType.ContractForms.Items.Add(goodwillForm);

                /// اسناد مالی قرارداد
                JContractFormsOrder docForm = new JContractFormsOrder();
                docForm.FormName = "Legal.JDocumentsForm";
                docForm.Show = true;
                _DynamicType.ContractForms.Items.Add(docForm);

                /// اسناد ویژگیهای
                JContractFormsOrder JPropertiesForm = new JContractFormsOrder();
                JPropertiesForm.FormName = "Legal.JPropertiesForm";
                JPropertiesForm.Show = true;
                _DynamicType.ContractForms.Items.Add(JPropertiesForm);

                /// متن قرارداد
                JContractFormsOrder amentForm = new JContractFormsOrder();
                amentForm.FormName = "Legal.JAmendmentForm";
                amentForm.Show = true;
                _DynamicType.ContractForms.Items.Add(amentForm);


                /// اطلاعات حقوقی
                //JContractFormsOrder legalForm = new JContractFormsOrder();
                //legalForm.FormName = "Legal.LegalForm";
                //legalForm.Show = true;
                //_DynamicType.ContractForms.Items.Add(legalForm);

                /// فرم قرارداد فنی
                JContractFormsOrder fanniForm = new JContractFormsOrder();
                fanniForm.FormName = "Legal.JFanniSubjectForm";
                fanniForm.Show = true;
                _DynamicType.ContractForms.Items.Add(fanniForm);

                /// فرم قرارداد مجتمع انبارها
                JContractFormsOrder csConractForm = new JContractFormsOrder();
                csConractForm.FormName = "Legal.SCContractForm";
                csConractForm.Show = true;
                _DynamicType.ContractForms.Items.Add(csConractForm);

                /// فرم قرارداد انتقال سهام
                JContractFormsOrder csShareTransferFrom = new JContractFormsOrder();
                csShareTransferFrom.FormName = "Legal.JContractTransferShareForm";
                csShareTransferFrom.Show = true;
                _DynamicType.ContractForms.Items.Add(csShareTransferFrom);

                /// فرم نهایی
                JContractFormsOrder tempForm = new JContractFormsOrder();
                tempForm.FormName = "Legal.JFinishForm";
                tempForm.Show = true;
                _DynamicType.ContractForms.Items.Add(tempForm);

                int i = 0;
                if (pSetInListBox)
                    foreach (JContractFormsOrder orderForm in _DynamicType.ContractForms.Items)
                    {
                        chListForms.Items.Add(orderForm);
                        chListForms.SetItemChecked(i++, true);
                    }
            }

            #endregion Fill CheckListBox
        }

        public bool SaveFormsOrder(JDataBase pDB)
        {
            if (!(JPermission.CheckPermission("Legal.JContractDynamicTypeForm.SaveFormsOrder", _DynamicType.Code)))
                return false;
            JDataBase db;
            if (pDB == null)
                db = new JDataBase();
            else
                db = pDB;
            try
            {
                /// مقدار دهی فرمها بر اساس انتخاب کاربر در لیست
                #region Set Form Orders
                for (int i = 0; i < chListForms.Items.Count; i++)
                {
                    _DynamicType.ContractForms.Items[i] = (JContractFormsOrder)chListForms.Items[i];
                    _DynamicType.ContractForms.Items[i].ShowOrder = i;
                    _DynamicType.ContractForms.Items[i].Show = chListForms.GetItemChecked(i);
                }
                #endregion Set Form Orders
                if (_DynamicType.ContractForms.UpdateAll(db, _DynamicType.Code))
                {
                    btnSaveForms.Enabled = false;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region Check Controls
            if (chListForms.CheckedItems.Count == 0)
            {
                JMessages.Error("لطفا حداقل یک فرم را انتخاب کنید", "Error");
                tabControl1.SelectedTab = tabForms;
                return;
            }
            if (txtTitle.Text.Trim() == "")
            {
                string[] parameters = { "@Value" };
                string[] values = { "Title" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                tabControl1.SelectedTab = tabContract;
                txtTitle.Focus();
                return;
            }
            if (txtRealPercent.IntValue !=0 && txtInstallmentPercent.IntValue !=0 &&  txtEndPricePercent.IntValue != 0)
                if (txtRealPercent.IntValue + txtInstallmentPercent.IntValue + txtEndPricePercent.IntValue != 100)
                {
                    JMessages.Error("لطفا مبالغ پیش فرض را بصورت صحیح وارد کنید.", "Error");
                    tabControl1.SelectedTab = tabPrices;
                    return;
                }
            //if (cmbAssetType.SelectedIndex == -1)
            //{
            //    string[] parameters = { "@Value" };
            //    string[] values = { "مورد قرارداد" };
            //    string msg = JLanguages._Text("PleaseEnter", parameters, values);
            //    JMessages.Error(msg, "Error");
            //    tabControl1.SelectedTab = tabContract;
            //    cmbAssetType.Focus();
            //    return;
            //}
            if (cmbTransfetType.SelectedIndex == -1)
            {
                string[] parameters = { "@Value" };
                string[] values = { "نوع ثبت اموال" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                tabControl1.SelectedTab = tabContract;
                cmbTransfetType.Focus();
                return;
            }
            if (cmbT1PersonType.SelectedIndex == -1)
            {
                string[] parameters = { "@Value" };
                string[] values = { "نوع شخص طرف اول" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                tabControl1.SelectedTab = tabSettings;
                cmbT1PersonType.Focus();
                return;
            }
            if (cmbT2PersonType.SelectedIndex == -1)
            {
                string[] parameters = { "@Value" };
                string[] values = { "نوع شخص طرف دوم" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                tabControl1.SelectedTab = tabSettings;
                cmbT2PersonType.Focus();
                return;
            }
            #endregion Check Controls

            _DynamicType.Title = txtTitle.Text;
            _DynamicType.AssetTransferType = (int)((ClassLibrary.JKeyValue)cmbTransfetType.SelectedItem).Value;
            if (cmbAssetType.SelectedItem != null)
                _DynamicType.ClassName = ((JAssetType)cmbAssetType.SelectedItem).ClassName;
            else
                _DynamicType.ClassName = "";
            _DynamicType.TransferAsst = chTransferAsset.Checked;
            if (cmbClassName.SelectedValue != null)
            {
                _DynamicType.PrtClassName = cmbClassName.SelectedValue.ToString();
            }
            _DynamicType.PrtObjectCode = Convert.ToInt32(cmbObjectCode.SelectedValue);

            _DynamicType.AllPrice = txtPrice.MoneyValue;
            _DynamicType.EndPricePercent = txtEndPricePercent.IntValue;
            _DynamicType.InstallmentPercent = txtInstallmentPercent.IntValue;
            _DynamicType.InstallmentCount = txtInstallmentCount.IntValue;
            _DynamicType.RealPercent = txtRealPercent.IntValue;
            /// مقداردهی تنظیمات
            #region Set Settings
            _DynamicType.ContractSettings.Items["T1HasAdvocacy"] = chT1HasAdvocacy.Checked;
            _DynamicType.ContractSettings.Items["HasEstenkafRight"] = chEstenkafRight.Checked;
            _DynamicType.ContractSettings.Items["HasPriceCancel"] = chPriceCancel.Checked;
            _DynamicType.ContractSettings.Items["HasIntuition"] = chHasIntuition.Checked;
            _DynamicType.ContractSettings.Items["T1HasValue"] = chT1HasValue.Checked;
            _DynamicType.ContractSettings.Items["T2HasAdvocacy"] = chT2HasAdvocacy.Checked;
            _DynamicType.ContractSettings.Items["T2HasValue"] = chT2HasValue.Checked;
            _DynamicType.ContractSettings.Items["PatiesFormName"] = txtPatiesFormName.Text;
            _DynamicType.ContractSettings.Items["T1Lable"] = txtT1Lable.Text;
            _DynamicType.ContractSettings.Items["T2Lable"] = txtT2Lable.Text;
            _DynamicType.ContractSettings.Items["WitnessCount"] = txtWitnessCount.Text;
            _DynamicType.ContractSettings.Items["T1PersonType"] = cmbT1PersonType.SelectedIndex;
            _DynamicType.ContractSettings.Items["T2PersonType"] = cmbT2PersonType.SelectedIndex;
            _DynamicType.ContractSettings.Items["HasStartDate"] = chHasStartDate.Checked;
            _DynamicType.ContractSettings.Items["HasEndDate"] = chHasEndDate.Checked;
            _DynamicType.ContractSettings.Items["HasDeliverDate"] = chHasDeliverDate.Checked;
           // _DynamicType.ContractSettings.Items["JobHasNoChange"] = chJob.Checked;
            

            _DynamicType.ContractSettings.Items["T1PersonOwnership"] = (int)((ClassLibrary.JKeyValue)cmbPerson1Ownership.SelectedItem).Value;
            _DynamicType.ContractSettings.Items["T2PersonOwnership"] = (int)((ClassLibrary.JKeyValue)cmbPerson2Ownership.SelectedItem).Value; /// cmbPerson2Ownership.SelectedIndex;

            _DynamicType.ContractSettings.Items["T1AddDelPerson"] = chT1AddDelPerson.Checked;
            _DynamicType.ContractSettings.Items["T2AddDelPerson"] = chT2AddDelPerson.Checked;

            //_DynamicType.ContractSettings.Items["DifIfNotGoodwill1"] = chDifinitGoodwill1.Checked;
            //_DynamicType.ContractSettings.Items["DifIfNotGoodwill2"] = chDifinitGoodwill2.Checked;
            _DynamicType.ContractSettings.Items["DefinitIsGoodwill"] = chDefinitIsGoodwill.Checked;
            _DynamicType.ContractSettings.Items["Request"] = chRequest.Checked;
            _DynamicType.ContractSettings.Items["NoContract"] = chNoContract.Checked;
            _DynamicType.ContractSettings.Items["NoFinance"] = chkNoFinance.Checked;
            #endregion Set Settings

            /// مقدار دهی فرمها بر اساس انتخاب کاربر در لیست
            #region Set Form Orders
            for (int i = 0; i < chListForms.Items.Count; i++)
            {
                _DynamicType.ContractForms.Items[i] = (JContractFormsOrder)chListForms.Items[i];
                _DynamicType.ContractForms.Items[i].ShowOrder = i;
                _DynamicType.ContractForms.Items[i].Show = chListForms.GetItemChecked(i);
            }

            #endregion Set Form Orders

            if (State == JFormState.Insert)
            {
                _DynamicType.Insert();
                if (_DynamicType.Code > 0)
                {
                    jDefinePropertyUserControl1.ObjectCode = _DynamicType.Code;
                    jDefinePropertyUserControl1.AcceptChanges();
                }
                DialogResult = DialogResult.OK;
            }
            if (State == JFormState.Update)
            {
                _DynamicType.Update();
                jDefinePropertyUserControl1.AcceptChanges();
                DialogResult = DialogResult.OK;
            }
            if (DialogResult == DialogResult.OK)
                SaveContractGroup();

            JContractPropertiesForm ContratcP = new JContractPropertiesForm();
            ContratcP.CheckinDataTable(FormPropertiesDT, _DynamicType.Code);
        }

        private void SaveContractGroup()
        {
            JDataBase Db = new JDataBase();
            try
            {
                int[] _Codes = new int[chBoxAssetGroup.CheckedItems.Count];
                int count = 0;
                foreach (object Obj in chBoxAssetGroup.CheckedItems)
                {
                    _Codes[count] = ((JAssetGroup)Obj).Code;
                    count++;
                }
                JContractTypeGroups ContractTG = new JContractTypeGroups(_DynamicType.Code);
                ContractTG.Save(_Codes, Db);
            }
            finally
            {
                Db.Dispose();
            }

        }


        private void btnCacnel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (chListForms.SelectedIndex == -1) return;
            int i = chListForms.SelectedIndex;
            object o = chListForms.SelectedItem;
            bool check = chListForms.GetItemChecked(i);

            if (i > 0)
            {
                chListForms.Items.RemoveAt(i);
                chListForms.Items.Insert(i - 1, o);
                chListForms.SelectedIndex = i - 1;
                chListForms.SetItemChecked(i - 1, check);
            }

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            // Down
            if (chListForms.SelectedIndex == -1) return;
            int i = chListForms.SelectedIndex;
            object o = chListForms.SelectedItem;
            bool check = chListForms.GetItemChecked(i);

            if (i < chListForms.Items.Count - 1)
            {
                chListForms.Items.RemoveAt(i);
                chListForms.Items.Insert(i + 1, o);
                chListForms.SelectedIndex = i + 1;
                chListForms.SetItemChecked(i + 1, check);
            }
        }

        private void chHasIntuition_CheckedChanged(object sender, EventArgs e)
        {
            lbWittness.Enabled = chHasIntuition.Checked;
            txtWitnessCount.Enabled = chHasIntuition.Checked;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            Text = JLanguages._Text("ContractType") + " " + txtTitle.Text;
        }

        private void cmbAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void cmbPerson1Ownership_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    chDifinitGoodwill1.Enabled = (System.Enum.GetName(typeof(Finance.JOwnershipType), (int)((ClassLibrary.JKeyValue)cmbPerson1Ownership.SelectedItem).Value) == Finance.JOwnershipType.Goodwill.ToString());
        //}

        //private void cmbPerson2Ownership_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    chDifinitGoodwill2.Enabled = (System.Enum.GetName(typeof(Finance.JOwnershipType), (int)((ClassLibrary.JKeyValue)cmbPerson2Ownership.SelectedItem).Value) == Finance.JOwnershipType.Goodwill.ToString());
        //}

        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbObjectCode.DataSource = Globals.Property.JProperties.GetAllObjectCode(cmbClassName.SelectedValue.ToString());

        }

        private void btnEditText_Click(object sender, EventArgs e)
        {
            if (grdTexts.Rows.Count > 0)
            {
                if (grdTexts.SelectedRows.Count > 0)
                {
                    JContractdefine contractText = new JContractdefine(Convert.ToInt32(grdTexts.SelectedRows[0].Cells[0].Value));
                    contractText.ShowDialog();
                    LoadTexts();
                }
                else
                {
                    JMessages.Error("لطفا یک سطر را انتخاب کنید", "Error");
                    return;
                }
            }
        }

        private void btnDelText_Click(object sender, EventArgs e)
        {
            if (grdTexts.Rows.Count > 0)
            {
                if (grdTexts.SelectedRows.Count > 0)
                {
                    JContractdefine contractText = new JContractdefine(Convert.ToInt32(grdTexts.SelectedRows[0].Cells[0].Value));
                    contractText.delete();
                    LoadTexts();
                }
                else
                {
                    JMessages.Error("لطفا یک سطر را انتخاب کنید", "Error");
                    return;
                }
            }

        }

        private void btnNewText_Click(object sender, EventArgs e)
        {
            JContractdefine contractText = new JContractdefine();
            contractText.ContractType = _DynamicType.Code;
            contractText.ShowDialog();
            LoadTexts();
        }
        /// <summary>
        /// دکمه تائید ویرایش فقط برای مدیر سیستم فعال است
        /// </summary>
        public void EnableEdit()
        {
            if (JPermission.CheckPermission("", 0, JMainFrame.CurrentPostCode, false))
            {
                btnOK.Enabled = true;
            }
        }

        public void SaveContractProperties()
        {
            if (JPermission.CheckPermission("Legal.JContractDynamicTypeForm.SaveContractProperties"))
                if (_DynamicType.Code > 0)
                    if (jDefinePropertyUserControl1.AcceptChanges())
                        JMessages.Information("ویژگی های قرارداد ثبت شد.", "");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveContractProperties();
        }

        private void chListForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                chkPropertiesForm.Items.Clear();
                if (chListForms.SelectedIndex > -1)
                {
                    CurrentFormName = ((JContractFormsOrder)chListForms.SelectedItem).FormName;
                    JAction Act = new JAction("GetFormProperties", CurrentFormName + ".GetPropertiesList");
                    object Ret = Act.run();
                    if (Ret is JKeyValue[])
                    {
                        chkPropertiesForm.Items.AddRange((JKeyValue[])Ret);
                    }

                    for (int i = 0; i < chkPropertiesForm.Items.Count;i++ )
                    {
                        string _PropertiesName = (string)((JKeyValue)chkPropertiesForm.Items[i]).Value;
                        DataRow[] Rows = FormPropertiesDT.Select("FormName = "
                            + JDataBase.Quote(CurrentFormName, false) + " AND ProPertiesName="
                            + JDataBase.Quote(_PropertiesName, false));
                        if (Rows.Length == 1 && Convert.ToBoolean(Rows[0]["Value"]) == true)
                        {
                            chkPropertiesForm.SetItemChecked(i, true);
                        }
                    }

                }
            }
            catch
            {
            }
        }

        private void chkPropertiesForm_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                string PropertiesName = (string)((JKeyValue)chkPropertiesForm.SelectedItem).Value;
                if (e.NewValue == CheckState.Checked)
                {
                    DataRow[] ROWs = FormPropertiesDT.Select("FormName = " + JDataBase.Quote(CurrentFormName, false) + " AND ProPertiesName=" + JDataBase.Quote(PropertiesName, false));
                    if (ROWs.Length == 1)
                    {
                        DataRow _row = ROWs[0];
                        _row["FormName"] = CurrentFormName;
                        _row["ProPertiesName"] = PropertiesName;
                        _row["ContractTypeCode"] = _DynamicType.Code;
                        _row["Value"] = true;
                    }
                    else
                    {
                        DataRow _row = FormPropertiesDT.NewRow();
                        _row["FormName"] = CurrentFormName;
                        _row["ProPertiesName"] = PropertiesName;
                        _row["ContractTypeCode"] = _DynamicType.Code;
                        _row["Value"] = true;
                        FormPropertiesDT.Rows.Add(_row);
                    }
                }
                else
                {
                    DataRow[] ROWs = FormPropertiesDT.Select("FormName = " + JDataBase.Quote(CurrentFormName, false) + " AND ProPertiesName=" + JDataBase.Quote(PropertiesName, false));
                    foreach (DataRow _row in ROWs)
                    {
                        _row["Value"] = false;
                    }
                }
            }
            catch
            {
            }
        }

        private void btnSaveForms_Click(object sender, EventArgs e)
        {
            SaveFormsOrder(null);
        }

        private void chListForms_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnSaveForms.Enabled = true;
        }

        private void textEdit2_TextChanged(object sender, EventArgs e)
        {
            LBSumPercent.Text =
                (int.Parse(txtEndPricePercent.Text) +
                int.Parse(txtInstallmentPercent.Text) +
                int.Parse(txtRealPercent.Text)).ToString();
        }
    }
}
