using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ClassLibrary;
using RealEstate;

namespace Estates
{
    /// <summary>
    /// انواع وضعیت فرم زمین
    /// </summary>
    public enum StateClasses
    {
        /// <summary>
        /// وضعیت عمومی فرم - جدید یا ویرایش
        /// </summary>
        General = 1,
        /// <summary>
        /// تفکیک
        /// </summary>
        ToPartition = 2,
        /// <summary>
        /// افراز
        /// </summary>
        /// 
        BreakDown = 3,
        /// <summary>
        /// تجمیع
        /// </summary>
        Aggregate = 4,
        /// <summary>
        /// این فرم از فرم قبلی ایجاد شده است
        /// </summary>
        Retry,
    }
    public partial class JGroundForm : ClassLibrary.JBaseForm
    {
        public JGround _newGround = new JGround();
        /// <summary>
        /// این فیلد نشان دهنده این است که آیا اطلاعات فرم تغییر کرده است یا نه
        /// </summary>
        public int changed = 0;
        /// <summary>
        /// وضعیت فرم را که توسط کدام کلاس صدا زده شده است را مشخص می کند
        /// </summary>
        public StateClasses stateClass;

        public JGroundForm()
        {
            if (this.DesignMode == true)
                return;
            try
            {
                InitializeComponent();
                InitGridView();
                //_newGround = new JGround();
                ArchiveListEstate.ClassName = _newGround.GetType().FullName;
                jArchiveImageKorooki.ClassName = "JGroundForm.Koroki";
                _FillComboBox();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        public JGroundForm(int pCode)
        {
            try
            {
                InitializeComponent();
                InitGridView();
                _newGround = new JGround(pCode);
                ArchiveListEstate.ClassName = _newGround.GetType().FullName;
                ArchiveListEstate.ObjectCode = _newGround.Code;
                jArchiveImageKorooki.ClassName = "JGroundForm.Koroki";
                jArchiveImageKorooki.ObjectCode = _newGround.Code;
                ArchivedDocuments.JArchiveDocument jArchive = new ArchivedDocuments.JArchiveDocument();
                jArchive.GetData(_newGround.Korooki, false);
                jArchiveImageKorooki.ArchiveCode = jArchive.Code;
                _FillComboBox();
                _ShowData();
                OK.Enabled = false;
                changed = 0;
                _newGround.About.Changed = false;
            }
            catch (Exception ex)
            {
            }

        }

        public JGroundForm(JGround JG)
        {
            InitializeComponent();
            InitGridView();
            _newGround = JG;
            ArchiveListEstate.ClassName = _newGround.GetType().FullName;
            jArchiveImageKorooki.ClassName = "JGroundForm.Koroki";
            jArchiveImageKorooki.ObjectCode = JG.Code;
            jArchiveImageKorooki.ArchiveCode = JG.Korooki;
            _FillComboBox();
            if (JG.MainAve != "")
            {
                _ShowData();
            }
            dgvPrimeryOwner.DataSource = JG.PrimeryOwners;
        }

        private void InitGridView()
        {
            grdContractsDefinit.gridEX1.MouseDown += new MouseEventHandler(grdContractsDefinit_CellClick);
            grdContractsRent.gridEX1.MouseDown += new MouseEventHandler(grdContractsRent_CellClick);
        }
        private void _FillComboBox()
        {
            JLands lands = new JLands();
            foreach (JLand land in lands.Items)
            {
                cmbLand.Items.Add(land);
                if (_newGround.Land != 0 && _newGround.Land == land.Code)
                    cmbLand.SelectedItem = land;
            }
            JUsageGrounds Usages = new JUsageGrounds();
            Usages.GetData();
            foreach (JUsageGround usage in Usages.items)
            {
                cmbUsage.Items.Add(usage);
                if (_newGround.Usage != 0 && _newGround.Usage == usage.Code)
                    cmbUsage.SelectedItem = usage;
            }
            txtArea.Text = Convert.ToString(_newGround.Area);
            JEstateTypes EsType = new JEstateTypes();
            EsType.SetComboBox(cmbEstateType, _newGround.EstateType);
            //foreach (JSubBaseDefine Type in EsType.Items)
            //{
            //    cmbEstateType.Items.Add(Type);
            //    if (_newGround.EstateType != 0 && _newGround.EstateType == Type.Code)
            //        cmbEstateType.SelectedItem = Type;
            //}

            JDocumentTypes DTypes = new JDocumentTypes();
            DTypes.SetComboBox(cmbDocumentType, _newGround.DocumentType);
            //foreach (JSubBaseDefine DType in DTypes.Items)
            //{
            //    cmbDocumentType.Items.Add(DType);
            //    if (_newGround.DocumentType != 0 && _newGround.DocumentType == DType.Code)
            //        cmbDocumentType.SelectedItem=DType;
            //}
        }



        private void JGroundForm_Load(object sender, EventArgs e)
        {
            OK.Enabled = false;
            dgvPrimeryOwner.DataSource = _newGround.PrimeryOwners;
            if (_newGround.PrimeryOwners.Columns.Contains(JPrimaryOwnerField.CodeGround.ToString()))
                dgvPrimeryOwner.Columns[JPrimaryOwnerField.CodeGround.ToString()].Visible = false;
            dgvPrimeryOwner.Columns[JPrimaryOwnerField.Code.ToString()].Visible = false;
            _newGround.About.Changed = false;
            if (this.stateClass == StateClasses.ToPartition)
            {
                btmAddOwner.Enabled = false;
                btnDelOwner.Enabled = false;
                dgvPrimeryOwner.ReadOnly = true;
                cmbLand.Enabled = false;
                txtMainAve.Enabled = false;
            }
            if (this.stateClass == StateClasses.BreakDown)
            {
                txtMainAve.Enabled = false;
                dgvPrimeryOwner.ReadOnly = true;
                btnDelOwner.Enabled = false;
                btmAddOwner.Enabled = false;
                cmbLand.Enabled = false;
            }
            if (this.stateClass == StateClasses.Aggregate)
            {
                btmAddOwner.Enabled = false;
                btnDelOwner.Enabled = false;
                dgvPrimeryOwner.ReadOnly = true;
            }
            if (State == JFormState.Insert)
                foreach (JDefaultOwner owner in JDefaultOwners.GetDefaultOwners())
                {
                    AddPersonToGrid(owner.PCode, owner.Share);
                }
            if (this._newGround.Land != 0 && this.stateClass == StateClasses.Retry)
            {
                txtMainAve.Text = _newGround.MainAve;
                txtSubAve.Text = _newGround.SubNo;
                txtBlockNum.Text = _newGround.BlockNum;
                _FillComboBox();


            }

        }
        private void _ShowData()
        {
            labCode.Text = _newGround.Code.ToString();
            txtMainAve.Text = _newGround.MainAve;
            txtSubAve.Text = _newGround.SubNo;
            //txtSection.Text = _newGround.Section;
            txtBlockNum.Text = _newGround.BlockNum;
            txtPartNum.Text = _newGround.PartNum;
            txtArea.Text = _newGround.Area.ToString();
            txtNorth.Text = _newGround.About.North;
            txtSouth.Text = _newGround.About.South;
            txtWest.Text = _newGround.About.West;
            txtEast.Text = _newGround.About.East;
            txtComment.Text = _newGround.Comment;
            txtCost.Text = _newGround.Cost.ToString();
            txtNumDocument.Text = _newGround.DocumentNumber.ToString();
            chkRightRoot.Checked = _newGround.RightRoot;
            // اگر چنانچه برای اعیان قرارداد ثبت شده باشد مالک اولیه آن را نباید تغییر داد
            //Finance.JAsset Asset = new Finance.JAsset();
            //Asset.GetData("Estates.JGround", _newGround.Code);
            //JRelation tmpJRelation = new JRelation();
            //if (tmpJRelation.CheckRelation("ClassLibrary.AssetShare", Asset.Code))
            //{
            //    btmAddOwner.Enabled = false;
            //    btnDelOwner.Enabled = false;
            //}
            tabControl1.SelectedTab = tabHistory;
            if ((grdContractsDefinit.DataSource != null) && (grdContractsDefinit.DataSource.Rows.Count > 0))
            {
                btmAddOwner.Enabled = false;
                btnDelOwner.Enabled = false;
            }
            tabControl1.SelectedTab = tabMain;

        }

        private void txtNorth_TextChanged(object sender, EventArgs e)
        {
            changed = 1;
            OK.Enabled = true;
            _newGround.About.Changed = true;

        }
        private void AddPersonToGrid(int PersonCode, decimal pShare)
        {
            if (_newGround.FindPrimaryOwner(PersonCode))
            {
                JMessages.Error("PersonExistsInList", "Error");
                return;
            }
            JAllPerson Person = new JAllPerson(PersonCode);

            DataRow Row = ((DataTable)dgvPrimeryOwner.DataSource).NewRow();
            Row[JPrimaryOwnerField.CodeGround.ToString()] = _newGround.Code;
            Row[JPrimaryOwnerField.PCode.ToString()] = PersonCode;
            Row[JPrimaryOwnerField.Share.ToString()] = pShare;
            Row["Name"] = Person.Name;
            _newGround.PrimeryOwners.Rows.Add(Row);
            changed = 1;
            OK.Enabled = true;
        }

        private void btmAddOwner_Click(object sender, EventArgs e)
        {
            int _selectedPersonCode;
            JFindPersonForm FindPerson = new JFindPersonForm();
            if (FindPerson.ShowDialog() == DialogResult.OK)
            {
                _selectedPersonCode = FindPerson.SelectedPersonCode;
                AddPersonToGrid(_selectedPersonCode, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPrimeryOwner_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changed = 1;
            OK.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dgvPrimeryOwner.SelectedRows.Count == 0)
                return;
            dgvPrimeryOwner.Rows.Remove(dgvPrimeryOwner.CurrentRow);
            //            _newGround.PrimeryOwners.Rows.RemoveAt(dgvPrimeryOwner.SelectedRows[0].Index);
            changed = 1;
            OK.Enabled = true;
        }
        private bool _Save()
        {
            try
            {
                if (changed == 1)
                {
                    _newGround.Land = ((JLand)cmbLand.SelectedItem).Code;
                    _newGround.MainAve = txtMainAve.Text;
                    _newGround.SubNo = txtSubAve.Text;
                    //_newGround.Section = txtSection.Text;
                    _newGround.PartNum = txtPartNum.Text;
                    _newGround.BlockNum = txtBlockNum.Text;
                    _newGround.Usage = ((JUsageGround)cmbUsage.SelectedItem).Code;
                    _newGround.Area = txtArea.FloatValue;
                    _newGround.Date = JMainFrame.GlobalDataBase.GetCurrentDateTime();
                    _newGround.Comment = txtComment.Text;
                    _newGround.Person = JMainFrame.CurrentPersonCode;
                    _newGround.About.North = txtNorth.Text;
                    _newGround.About.West = txtWest.Text;
                    _newGround.About.East = txtEast.Text;
                    _newGround.About.South = txtSouth.Text;
                    _newGround.About.Date = JMainFrame.GlobalDataBase.GetCurrentDateTime();
                    _newGround.MakeFromName = "Estates.JPrimaryOwners";
                    if (cmbEstateType.SelectedItem != null)
                    {
                        _newGround.EstateType = Convert.ToInt32(cmbEstateType.SelectedValue);
                    }
                    if (cmbDocumentType.SelectedItem != null)
                    {
                        _newGround.DocumentType = Convert.ToInt32(cmbDocumentType.SelectedValue);
                    }
                    _newGround.RightRoot = chkRightRoot.Checked;
                    if (txtCost.Text != "")
                        _newGround.Cost = Convert.ToDecimal(txtCost.Text);
                    _newGround.DocumentNumber = txtNumDocument.Text;
                    if (this.State == ClassLibrary.JFormState.Insert)
                    {
                        int _Code = _newGround.Insert(null);
                        if (_Code > 0)
                        {
                            ArchiveListEstate.ObjectCode = _Code;
                            jArchiveImageKorooki.ObjectCode = _Code;
                            ArchiveListEstate.ArchiveList();
                            jArchiveImageKorooki.ArchiveImage();
                            labCode.Text = _Code.ToString();
                            return true;
                        }
                    }
                    else if (this.State == ClassLibrary.JFormState.Update)
                    {

                        //MessageUpdateGround Message = new MessageUpdateGround();
                        //Message.ShowDialog();
                        //string pComment = Message.dialogComment;                            
                        _newGround.Code = Convert.ToInt32(labCode.Text);

                        if (_newGround.Update())
                        {
                            ArchiveListEstate.ArchiveList();
                            _newGround.Korooki = jArchiveImageKorooki.ArchiveImage();
                            _newGround.Update();
                            return true;
                        }


                    }
                    else if (this.State == JFormState.None)
                    {
                        this.Close();
                    }
                    return false;
                }
                else
                {
                    ClassLibrary.JMessages.Information("اطلاعات فرم تغییر نکرده است", "خطا در ویرایش اطلاعات");
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }

        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (_CheckControl())
            {
                if (this.State == JFormState.None)
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                if (_Save())
                {
                    State = JFormState.Update;
                    OK.Enabled = false;
                    changed = 0;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {

            if (_CheckControl())
            {
                if (this.State == JFormState.None)
                {
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                if (_Save())
                    Close();
            }
        }
        private bool _CheckControl()
        {
            if (cmbLand.SelectedItem == null)
            {
                JMessages.Error("اراضی مشخص نشده است.", "خطا در ورود اطلاعات");
                tabControl1.SelectedTab = tabMain;
                cmbLand.Focus();
                return false;
            }
            if (cmbUsage.SelectedItem == null)
            {
                JMessages.Error("کاربری مشخص نشده است.", "خطا در ورود اطلاعات");
                tabControl1.SelectedTab = tabMain;
                cmbUsage.Focus();
                return false;
            }
            if (txtMainAve.Text == "")
            {
                JMessages.Error("پلاک اصلی را وارد کنید", "خطا در ورود اطلاعات");
                tabControl1.SelectedTab = tabMain;
                txtMainAve.Focus();
                return false;
            }
            //if (txtSubAve.Text == "")
            //{
            //    JMessages.Error("پلاک فرعی زمین را وارد کنید", "خطادر ورود اطلاعات");
            //    tabControl1.SelectedTab = tabMain;
            //    txtSubAve.Focus();
            //    return false;
            //}

            if (dgvPrimeryOwner.RowCount == 0)
            {
                JMessages.Error("PleaseEnterAtLeastOnePrimaryOwner", "خطا در ثبت اطلاعات");
                tabControl1.SelectedTab = tabPrimaryOwners;
                return false;
            }
            object SumShare = _newGround.PrimeryOwners.Compute("Sum(" + JPrimaryOwnerField.Share + ")", "");
            if (SumShare == DBNull.Value)
                SumShare = 0;
            if (Convert.ToDecimal(SumShare) != JGround.MaxShare)
            {
                JMessages.Error("مجموع میزان سهم برابر با" + JGround.MaxShare.ToString() + " نیست", "Error");
                tabControl1.SelectedTab = tabPrimaryOwners;
                return false;
            }
            if (txtArea.DecimalValue == 0)
            {
                JMessages.Error("مساحت زمین برابر صفر می باشد.", "خطادر ورود اطلاعات");
                tabControl1.SelectedTab = tabMain;
                txtArea.Focus();
                return false;

            }
            return true;

        }

        private void ArchiveListEstate_OnAddFile(object Sender, EventArgs e)
        {
            //if (ArchiveListEstate.ObjectCode == 0)
            //{
            //    JMessages.Error("PleaseSaveChanges", "Error");
            //}
        }

        private void txtMainAve_TextChanged(object sender, EventArgs e)
        {
            changed = 1;
            OK.Enabled = true;
        }

        private void tabControl2_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            if (_newGround.Code != 0)
            {
                AboutuC_Grid.DataSource = JAbout.GetDataTable(_newGround.Code);
                AboutuC_Grid.Columns["Code"].Visible = false;
            }
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
        }

        private void cmbLand_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSection.Text = ((JLand)cmbLand.SelectedItem).Section;
        }

        private void AboutuC_Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                JAbout About = new JAbout();
                About.Delete((int)AboutuC_Grid.SelectedRows[0].Cells["Code"].Value);
                AboutuC_Grid.DataSource = JAbout.GetDataTable(_newGround.Code);
                AboutuC_Grid.Columns["Code"].Visible = false;
                changed = 1;
                OK.Enabled = true;
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dgvPrimeryOwner_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            changed = 1;
            OK.Enabled = true;
        }

        private void JGroundForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.State != JFormState.None)
            {
                if (OK.Enabled)
                {
                    DialogResult result = JMessages.Confirm("DoYouWantToSaveChanges", "SaveChanges");
                    if (result == DialogResult.Yes)
                    {
                        //btnSave.PerformClick();
                        if (_Save())
                        {
                            e.Cancel = false;
                        }
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                        e.Cancel = false;
                }
            }
        }

        private void txtSubAve_Leave(object sender, EventArgs e)
        {
            if (State == JFormState.Insert || State == JFormState.None)
            {
                if (txtMainAve.Text != "" && txtSubAve.Text != "")
                    if (_newGround.Find(txtMainAve.Text, txtSubAve.Text, null))
                        JMessages.Error("اطلاعات زمین تکراری می باشد", "خطا در ورود اطلاعات");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void cmbEstateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OK.Enabled = true;
        }

        private void SetDefinitContractGrid(int pAssetCode)
        {
            grdContractsDefinit.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.Definitive);
            (grdContractsDefinit.DataSource as DataTable).Select("Share <> 0");
            grdContractsDefinit.Columns["StartDate"].Visible = false;
            grdContractsDefinit.Columns["EndDate"].Visible = false;
            grdContractsDefinit.Columns["GoodwillPrice"].Visible = false;
            grdContractsDefinit.Columns["Price"].Visible = false;
            grdContractsDefinit.Columns["PriceMonth"].Visible = false;
        }

        private void SetRentContractGrid(int pAssetCode)
        {
            grdContractsRent.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.Rentals);
            grdContractsRent.Columns["TotalPrice"].Visible = false;
            grdContractsRent.Columns["GoodwillPrice"].Visible = false;
            grdContractsRent.Columns["Share"].Visible = false;
        }
        private List<JAction> CreateActions(int pContractCode, int pPersonCode)
        {
            List<JAction> actions = new List<JAction>();
            /// اکشن مشاهده قرارداد
            if (pContractCode > 0)
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);

                JAction splitter = new JAction("-", "");
                //JAction ReapirAction = new JAction("RepairContract...", "Legal.JRepairContractForm.Show", null, new object[] { contract.Code });
                //actions.Add(ReapirAction);

                ///// تعیین قرارداد جاری
                //JAction SetAsCurrentContract = new JAction("SetAsCurrentContract...", "Legal.JSubjectContract.SetAsCurrentContract", new object[] { contract.FinanceCode, contract.Code, DynamicType.AssetTransferType }, null);
                //actions.Add(SetAsCurrentContract);

                //actions.Add(splitter);

                if (JPermission.CheckPermission("Legal.JGeneralContract.ShowForms", contractDefine.ContractType, JMainFrame.CurrentPostCode, false))
                {
                    JAction ShowWordCurrentContract = OfficeWord.JWordForm.getAction("Legal.JContractForms", pContractCode, true);
                    actions.Add(ShowWordCurrentContract);
                }
                JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { contract.Code });
                actions.Add(CancelAction);

                JAction editContract = new JAction("EditContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
                actions.Add(editContract);

                JAction viewContract = new JAction("viewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, true });
                actions.Add(viewContract);

                actions.Add(splitter);

                JAction HistoryOwner = new JAction("HistoryOwner...", "Estates.Land.Ground.Ground.HistoryOwner.FormHistoryOwner.ShowDialog", null, new object[] { pContractCode,pPersonCode }, true);
                actions.Add(HistoryOwner);

            }
            ///  مشخصات شخص
            int pCode = pPersonCode;
            JAction personAction = new JAction();
            JAllPerson allPerson = new JAllPerson(pCode);
            if (allPerson.PersonType == JPersonTypes.RealPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", new object[] { true }, new object[] { pCode });
            else if (allPerson.PersonType == JPersonTypes.LegalPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", new object[] { true }, new object[] { pCode });
            actions.Add(personAction);
            return actions;
        }

        private List<JAction> CreateOwnersActions(int pContractCode, int pPersonCode)
        {
            List<JAction> actions = new List<JAction>();
            /// اکشن مشاهده قرارداد
            if (pContractCode > 0)
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);
                JAction viewContract = new JAction("ContractInformation...", "Legal.JGeneralContract.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
                actions.Add(viewContract);
            }
            /// اکشن فسخ قرارداد
            if (pContractCode > 0)
            {
                Legal.JSubjectContract contract = new Legal.JSubjectContract(pContractCode);
                Legal.JContractdefine contractDefine = new Legal.JContractdefine(contract.Type);
                Legal.JContractDynamicType DynamicType = new Legal.JContractDynamicType(contractDefine.ContractType);
                JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] { contract.Code });
                actions.Add(CancelAction);
            }
            ///  مشخصات شخص
            int pCode = pPersonCode;
            JAction personAction = new JAction();
            JAllPerson allPerson = new JAllPerson(pCode);
            if (allPerson.PersonType == JPersonTypes.RealPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JPerson.ShowDialog", new object[] { true }, new object[] { pCode });
            else if (allPerson.PersonType == JPersonTypes.LegalPerson)
                personAction = new JAction("PersonInfo...", "ClassLibrary.JOrganization.ShowDialog", new object[] { true }, new object[] { pCode });
            actions.Add(personAction);
            return actions;
            ///  مشخصات تعرفه
            if (pContractCode > 0)
            {
                //JAction viewContract = new JAction("TarefeInformation...", "Estates.JSheetGroundForm.ShowForms", null, new object[] { contractDefine.ContractType, contract.Code, false });
                //actions.Add(viewContract);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Tab History
            if (tabControl1.SelectedTab == tabHistory && grdContractsDefinit.DataSource == null)
            {
                Finance.JAsset Asset = new Finance.JAsset("Estates.JGround", _newGround.Code);
                SetDefinitContractGrid(Asset.Code);
                SetRentContractGrid(Asset.Code);
            }
            #endregion Tab History

            #region Tab Owners
            if (tabControl1.SelectedTab == tabOwners && jDataGridMainContract.DataSource == null)
            {
                /// قطعی
                jDataGridMainContract.DataSource = Finance.JAssetTransfer.GetAssetShare(_newGround.Code, "Estates.JGround", Finance.JOwnershipType.Definitive);
                if (jDataGridMainContract.RowCount > 0)
                {
                    List<JAction> actions = CreateActions(Convert.ToInt32(jDataGridMainContract.Rows[0].Cells["ContractCode"].Value),
                      Convert.ToInt32(jDataGridMainContract.Rows[0].Cells["PCode"].Value));
                    foreach (JAction action in actions)
                    {
                        jDataGridMainContract.AddAction(action);
                        jDataGridMainContract.Columns["ContractCode"].Visible = false;
                    }
                }
            }
            #endregion Tab Owners
        }

        private void jDataGridMainContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (jDataGridMainContract.RowCount > 0)
            {
                jDataGridMainContract.ClearActions();
                List<JAction> actions = CreateOwnersActions(Convert.ToInt32(jDataGridMainContract.Rows[e.RowIndex].Cells["ContractCode"].Value),
                   Convert.ToInt32(jDataGridMainContract.Rows[e.RowIndex].Cells["PCode"].Value));
                foreach (JAction action in actions)
                {
                    jDataGridMainContract.AddAction(action);
                }
            }
        }
        private void run(object sender, EventArgs e)
        {
            JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
            object s = t.run();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_newGround.Code == 0)
                return;
            contextMenuStripContract.Items.Clear();
            EventHandler ClickEvent = new EventHandler(run);

            Finance.JAsset Asset = new Finance.JAsset(_newGround.GetType().FullName, _newGround.Code);

            Legal.JContractNodes CN = new Legal.JContractNodes();
            /// در صورتی که نیاز است هر کدام از اراضی به عنوان یک گروه امول تعریف شود(مانند بازار در اعیان) کد اراضی را به عنوان پارامتر این تابع قرار میدهیم. 
            /// ولی در حال حاضر چون خود زمین به عنوان یک گروه اموال تعریف شده، کد 1 را میفرستیم
            JNode[] _nodes = CN.ContractTree(Finance.JAssetGroup.GroundGroupCode);

            foreach (JNode _node in _nodes)
            {
                ToolStripItem TSI = contextMenuStripContract.Items.Add(_node.Name);
                if (_node.ChildsAction != null)
                {
                    JNode[] _childnodes = (JNode[])_node.ChildsAction.run();
                    foreach (JNode _childnode in _childnodes)
                    {
                        ToolStripItem TSIChild = ((ToolStripMenuItem)TSI).DropDownItems.Add(_childnode.Name, null, ClickEvent);
                        TSIChild.Tag =
                            new JAction("NewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { _childnode.Code, 0, Asset.Code, false });
                    }
                }
            }

            //contextMenuStripContract.Show(this.Left+ ((Button)sender).Left + ((Button)sender).Width / 2,this.Top+ ((Button)sender).Top + ((Button)sender).Height / 2);
            contextMenuStripContract.Show(MousePosition);
        }

        private void grdContractsDefinit_CellClick(object sender, MouseEventArgs e)
        {
            if (grdContractsDefinit.gridEX1.CurrentRow == null) return;
            if (grdContractsDefinit.RowCount > 0)
            {
                grdContractsDefinit.ClearActions();
                List<JAction> actions = CreateActions(Convert.ToInt32(grdContractsDefinit.gridEX1.CurrentRow.Cells["ContractCode"].Value),
                   Convert.ToInt32(grdContractsDefinit.gridEX1.CurrentRow.Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    grdContractsDefinit.AddAction(action);
                }
            }
        }


        private void grdContractsRent_CellClick(object sender, MouseEventArgs e)
        {
            if (grdContractsRent.gridEX1.CurrentRow == null) return;
            if (grdContractsRent.RowCount > 0)
            {
                grdContractsRent.ClearActions();
                List<JAction> actions = CreateActions(Convert.ToInt32(grdContractsRent.gridEX1.CurrentRow.Cells["ContractCode"].Value),
                   Convert.ToInt32(grdContractsRent.gridEX1.CurrentRow.Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    grdContractsRent.AddAction(action);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdContractsDefinit.DataSource = null;
            jDataGridMainContract.DataSource = null;
            tabControl1_SelectedIndexChanged(sender, e);
        }

        private void jDataGridRentalContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (jDataGridRentalContract.RowCount > 0)
            {
                jDataGridRentalContract.ClearActions();
                List<JAction> actions = CreateOwnersActions(Convert.ToInt32(jDataGridRentalContract.Rows[e.RowIndex].Cells["ContractCode"].Value),
                   Convert.ToInt32(jDataGridRentalContract.Rows[e.RowIndex].Cells["PCode"].Value));
                foreach (JAction action in actions)
                {
                    jDataGridRentalContract.AddAction(action);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabOwners;
                //tabControl1_SelectedIndexChanged(null, null);

                DataTable dtInfo = new DataTable();
                dtInfo.Columns.Add("North");
                dtInfo.Columns.Add("South");
                dtInfo.Columns.Add("East");
                dtInfo.Columns.Add("West");
                dtInfo.Columns.Add("Name");
                dtInfo.Columns.Add("Fam");
                dtInfo.Columns.Add("No");
                dtInfo.Columns.Add("Address");
                dtInfo.Columns.Add("Sahm");
                dtInfo.Columns.Add("BargeNo");
                dtInfo.Columns.Add("BlockNum");
                dtInfo.Columns.Add("PartNum");
                dtInfo.Columns.Add("Usage");
                dtInfo.Columns.Add("Area");
                dtInfo.Columns.Add("SubAve");
                dtInfo.Columns.Add("MainAve");
                DataRow dr = dtInfo.NewRow();
                dr["North"] = txtNorth.Text;
                dr["South"] = txtSouth.Text;
                dr["East"] = txtEast.Text;
                dr["West"] = txtWest.Text;
                if ((jDataGridMainContract != null) && (jDataGridMainContract.Rows.Count > 0))
                {
                    JAllPerson tmpallperson = new JAllPerson(Convert.ToInt32(jDataGridMainContract.Rows[0].Cells["PCode"].Value.ToString()));
                    if (tmpallperson.PersonType == JPersonTypes.LegalPerson)
                    {
                        JOrganization tmpOrg = new JOrganization(Convert.ToInt32(jDataGridMainContract.Rows[0].Cells["PCode"].Value.ToString()));
                        dr["Name"] = tmpOrg.Name;
                        dr["No"] = tmpOrg.RegisterNo;
                        dr["Address"] = tmpOrg.Address.FullAddress;
                        dr["Sahm"] = jDataGridMainContract.Rows[0].Cells["Share"].Value.ToString();
                    }
                    else
                    {
                        JPerson tmpPerson = new JPerson(Convert.ToInt32(jDataGridMainContract.Rows[0].Cells["PCode"].Value.ToString()));
                        dr["Name"] = tmpPerson.Name;
                        dr["Fam"] = tmpPerson.Fam;
                        dr["No"] = tmpPerson.ShSh;
                        dr["Address"] = tmpPerson.HomeAddress.FullAddress;
                        //dr["Sahm"] = jDataGridMainContract.Rows[0].Cells["Share"].Value.ToString();
                    }
                }
                dr["BargeNo"] = 1;
                dr["BlockNum"] = txtBlockNum.Text;
                dr["PartNum"] = txtPartNum.Text;
                dr["Usage"] = cmbUsage.Text;
                dr["Area"] = txtArea.Text;
                dr["SubAve"] = txtSubAve.Text;
                dr["MainAve"] = txtMainAve.Text;
                dr["West"] = txtWest.Text;
                dtInfo.Rows.Add(dr);

                for (int i = 0; i < jDataGridMainContract.Rows.Count - 1; i++)
                {
                    dtInfo.ImportRow(dtInfo.Rows[0]);
                    JPerson tmpPerson = new JPerson(Convert.ToInt32(jDataGridMainContract.Rows[i].Cells["PCode"].Value.ToString()));
                    dtInfo.Rows[i]["Name"] = tmpPerson.Name;
                    dtInfo.Rows[i]["Fam"] = tmpPerson.Fam;
                    dtInfo.Rows[i]["No"] = tmpPerson.ShSh;
                    dtInfo.Rows[i]["Address"] = tmpPerson.HomeAddress.FullAddress;
                    dtInfo.Rows[i]["Sahm"] = jDataGridMainContract.Rows[i].Cells["Share"].Value.ToString();
                }

                JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.Ground.GetHashCode());

                dtInfo.TableName = "اطلاعات ";
                DRF.Add(dtInfo);


                DataTable _temp;
                ArchivedDocuments.JArchiveDocument tmpArchive = new ArchivedDocuments.JArchiveDocument();
                DataTable dtArchive = tmpArchive.Retrieve("JGroundForm.Koroki", _newGround.Code);
                if (dtArchive.Rows.Count > 0)
                    _temp = JGrounds.FindKoroki(Convert.ToInt32(dtArchive.Rows[0]["ArchiveCode"]));
                else
                    _temp = JGrounds.FindKoroki(0);
                _temp.TableName = "کروکی ";
                DRF.Add(_temp);

                _temp = Finance.JAssetTransfer.GetAssetShare(_newGround.Code, "Estates.JGround", Finance.JOwnershipType.Definitive);
                _temp.TableName = "مالکین قطعی";
                DRF.Add(_temp);


                DRF.ShowDialog();
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
                //return null;
            }
        }
    }
}
