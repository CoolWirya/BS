using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Estates;
using OfficeWord;

namespace RealEstate
{
    public partial class JUnitBuildForm : ClassLibrary.JBaseForm
    {
        public JUnitBuild UnitBuild;
        bool _State = false;
        /// <summary>
        /// در وضعیت تجمیع فرم باز شود و ذخیره نشود
        /// </summary>
        /// <param name="pState"></param>
        public JUnitBuildForm(JUnitBuild pUnitBuild)
        {
            InitializeComponent();
            InitGridView();
            _State = true;
            //UnitBuild = new JUnitBuild();  
            UnitBuild = pUnitBuild;
           // UnitBuild.Area = pUnitBuild.Area;
            //UnitBuild.MarketCode = pUnitBuild.MarketCode;            
            _fillComboBox();
            try
            {
                _setForm();
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// میزان دانگ کل یک فروشگاه
        /// </summary>
        //مقدار پیش فرض combobox
       // string NullCmbSelected = "-----------";

        public JUnitBuildForm(int pCode)
        {
            InitializeComponent();
            InitGridView();
            UnitBuild = new JUnitBuild(pCode);
            jPropertyValueUserControl1.ValueObjectCode = pCode;

            ArchiveList.ClassName = "RealEstate.JUnitBuild";
            ArchiveList.ObjectCode = pCode;
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
            try
            {
                _setForm();
            }
            catch (Exception ex)
            {
            }
            cmbConstructionName.Enabled = false;
            btnok.Enabled = false;
        }
        /// <summary>
        /// این کانستراکتور برای حالتی طراحی شده است که کد مجتمع به عنوان پیشفرض داده شود
        /// </summary>
        /// <param name="TempValue"></param>
        /// <param name="pConstructionCode"></param>
        public JUnitBuildForm(int TempValue, int pConstructionCode)
        {
            InitializeComponent();
            InitGridView();
            UnitBuild = new JUnitBuild();
            _fillComboBox();

            if (pConstructionCode > 0)
            {
                jMarket Mark = new jMarket(pConstructionCode);
                cmbConstructionName.Text = Mark.Title;
                cmbConstructionName.Enabled = false;
            }
            ArchiveList.ClassName = "RealEstate.JUnitBuild";
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
            btnok.Enabled = false;
        }

        public JUnitBuildForm()
        {
            InitializeComponent();
            InitGridView();
            UnitBuild = new JUnitBuild();
            _fillComboBox();

            ArchiveList.ClassName = "RealEstate.JUnitBuild";
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
            btnok.Enabled = false;
        }

        private void InitGridView()
        {

            //grdContractsDefinit.gridEX1.Click += new EventHandler(grdContractsDefinit_CellClick);
            //grdContractsGoodwill.gridEX1.Click += new EventHandler(grdContractsGoodwill_CellClick);
            //grdGoodwillAndRent.gridEX1.Click += new EventHandler(grdGoodwillAndRent_CellClick);
            //grdOtherContracts.gridEX1.Click += new EventHandler(grdOtherContracts_CellClick);

            grdContractsRent.gridEX1.MouseDown += new MouseEventHandler(grdRentContracs_MouseDown);
            grdContractsDefinit.gridEX1.MouseDown += new MouseEventHandler(grdContractsDefinit_CellClick);
            grdContractsGoodwill.gridEX1.MouseDown += new MouseEventHandler(grdContractsGoodwill_CellClick);
            grdGoodwillAndRent.gridEX1.MouseDown += new MouseEventHandler(grdGoodwillAndRent_CellClick);
            grdOtherContracts.gridEX1.MouseDown += new MouseEventHandler(grdOtherContracts_CellClick);
        }

        void grdRentContracs_MouseDown(object sender, MouseEventArgs e)
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

        private void _setForm()
        {
            _fillComboBox();

            jMarket Mark = new jMarket(UnitBuild.MarketCode);
            cmbConstructionName.Text = Mark.Title;
            cmbConstructionName.SelectedValue = Mark.Code;

            txtPlaque.Text = UnitBuild.Plaque;

            if (UnitBuild.PlaqueRegistration != null)
                txtPlaqueRegistration.Text = UnitBuild.PlaqueRegistration.ToString();

            txtArea.Text = UnitBuild.Area.ToString();
            txtPrice.Text = UnitBuild.Price.ToString();
            txtBalcon.Text = UnitBuild.Balcon.ToString();
            txtInitialRental.Text = (decimal.Round(UnitBuild.InitialRental, 0)).ToString();
            txtTafsiliSepad.Text = UnitBuild.Tafsili1.ToString();
            txtTafsiliBazar.Text = UnitBuild.Tafsili2.ToString();

            txtInitialArea.Text = UnitBuild.InitialArea.ToString();

            jMarketFloors Mfs = new jMarketFloors();
            Mfs.GetData(UnitBuild.FloorCode);
            cmbFloor.Text = Mfs.Name;

            JMarketFaz Mfaz = new JMarketFaz();
            Mfaz.GetData(UnitBuild.Faz);
            cmbFaz.Text = Mfaz.Title;

            txtNumber.Text = UnitBuild.Number;
            txtDesc.Text = UnitBuild.UDesc;
            jMarketUsage MU = new jMarketUsage();
            MU.GetData(UnitBuild.UsageCode);

            JDefineMarketUsage DMU = new JDefineMarketUsage();
            DMU.GetData(MU.UsageCode);
            cmbUsage.Text = DMU.Name;
            btnSave.Enabled = false;
            txtDeliveryDate.Date = UnitBuild.DeliveryDate;

            // پر کردن اطلاعات زمین
            txtGroundCodeMain.Text = UnitBuild.GroundCode.ToString();
            //FillGround(Convert.ToInt32(txtGroundCodeMain.Text));
            // اگر چنانچه برای اعیان قرارداد ثبت شده باشد مالک اولیه آن را نباید تغییر داد
            Finance.JAsset Asset = new Finance.JAsset();
            Asset.GetData("RealEstate.JUnitBuild", UnitBuild.Code);
            JRelation tmpJRelation = new JRelation();
            if (tmpJRelation.CheckRelation("ClassLibrary.AssetShare", Asset.Code))
            //Relation.PrimaryClassName + "='Legal.JSubjectContract' And " + 
            //    Relation.ForeignClassName + "='RealEstate.JUnitBuild'" 
            {
                AddPrimaryOwners.Enabled = false;
                DelPrimaryOwners.Enabled = false;
            }
            //this.Text = cmbConstructionName.Text + "شماره واحد : " + txtNumber.Text + " شماره شناسایی: " + txtPlaque.Text;
        }

        private void _fillComboBox()
        {
            try
            {
                JUnitTypes UnitType = new JUnitTypes();
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";

                cmbType.Items.Clear();
                cmbType.Items.Add(nullDeff);
                cmbType.SelectedItem = nullDeff;
                UnitType.SetComboBox(cmbType, this.UnitBuild.TypeCode);
                //foreach (JSubBaseDefine city in UnitType.Items)
                //{
                //    cmbType.Items.Add(city);
                //    if (city.Code == this.UnitBuild.TypeCode)
                //        cmbType.SelectedItem = (JSubBaseDefine)city;
                //}

                JUnitJobs UnitJobs = new JUnitJobs();
                cmbJobs.Items.Clear();
                cmbJobs.Items.Add(nullDeff);
                cmbJobs.SelectedItem = nullDeff;
                UnitJobs.SetComboBox(cmbJobs, this.UnitBuild.UnitJob);
                //foreach (JSubBaseDefine job in UnitJobs.Items)
                //{
                //    cmbJobs.Items.Add(job);
                //    if (job.Code == this.UnitBuild.UnitJob)
                //        cmbJobs.SelectedItem = (JSubBaseDefine)job;
                //}
                DataTable Markets = jMarkets.GetDataTable(0);
                cmbConstructionName.DisplayMember = estMarket.Title.ToString();
                cmbConstructionName.ValueMember = estMarket.Code.ToString();
                cmbConstructionName.DataSource = Markets;
                //cmbConstructionName.SelectedItem = null;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            //if (btnSave.Enabled == true)
            {
                //if (MessageBox.Show(JLanguages._Text("DoYouWantToSaveChanges"), "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //  if (save())
                //    {
                //        DialogResult = DialogResult.OK;
                //        this.Close();
                //    }
                //    else
                //        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                //else
                this.Close();
                //}
                //else
                //{
                //    this.Close();
                //    DialogResult = DialogResult.Cancel;
                //}
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                if (save())
                {
                    if (_State)
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    btnSave.Enabled = false;
                }
                else
                    JMessages.Error(" خطا در عملیات ", "");
            }
        }



        private void cmbConstructionName_SelectedIndexChanged(object sender, EventArgs e)
        {

            //نمایش طبقات مجتمع بر اساس مجتمع انتخاب شده
            int CodeMarket = Convert.ToInt32(cmbConstructionName.SelectedValue);
            jMarketFloors Floor = new jMarketFloors();
            DataTable TableFloor = Floor.GetDataByMarketCode(CodeMarket);

            cmbFloor.DataSource = TableFloor;
            cmbFloor.DisplayMember = estMarketFloors.Name.ToString();
            cmbFloor.ValueMember = estMarketFloors.Code.ToString();
            cmbFloor.Text = "";
            //cmbFloor.SelectedItem = null;

            //نمایش فازهای مجتمع بر اساس مجتمع انتخاب شده
            JMarketFaz Faz = new JMarketFaz();
            DataTable TableFaz = Faz.GetDataByMarketCode(CodeMarket);

            cmbFaz.DataSource = TableFloor;
            cmbFaz.DisplayMember = estMarketFaz.Title.ToString();
            cmbFaz.ValueMember = estMarketFloors.Code.ToString();
            cmbFaz.Text = "";
            //cmbFloor.SelectedItem = null;

            //نمایش کاربری های  مجتمع بر اساس مجتمع انتخاب شده
            jMarketUsage Usage = new jMarketUsage();
            DataTable UsageTable = Usage.GetDataByMarketCode(CodeMarket);
            cmbUsage.DataSource = UsageTable;
            cmbUsage.DisplayMember = "Name";
            cmbUsage.ValueMember = estMarketUsage.Code.ToString();
            cmbUsage.SelectedItem = null;

            if (UnitBuild.MarketCode == 0 || Convert.ToInt32(cmbConstructionName.SelectedValue) == UnitBuild.MarketCode)
            {
                jPropertyValueUserControl1.ClassName = "RealEstate.jMarket";
                jPropertyValueUserControl1.ObjectCode = Convert.ToInt32(cmbConstructionName.SelectedValue);
            }

        }


        private bool save()
        {
            try
            {
                object SumShare = UnitBuild.PrimeryOwner.Compute("Sum(" + JPrimaryOwnerBuildTableEnum.Share + ")", "");
                if (SumShare == DBNull.Value)
                    SumShare = 0;
                if (Convert.ToDecimal(SumShare) != JUnitBuild.MaxShareCount)
                {
                    JMessages.Error("مجموع میزان سهم برابر با" + JUnitBuild.MaxShareCount.ToString() + " نیست", "Error");
                    tabControl1.SelectedTab = tabPage3;
                    return false;
                }
                UnitBuild.Area = txtArea.FloatValue;
                UnitBuild.Price = txtPrice.FloatValue;
                UnitBuild.FloorCode = Convert.ToInt32(cmbFloor.SelectedValue);
                //UnitBuild.Faz = Convert.ToInt32(cmbFaz.SelectedValue);
                UnitBuild.MarketCode = Convert.ToInt32(cmbConstructionName.SelectedValue);
                UnitBuild.Number = txtNumber.Text;
                UnitBuild.Plaque = txtPlaque.Text;
                UnitBuild.PlaqueRegistration = txtPlaqueRegistration.Text;
                UnitBuild.UsageCode = Convert.ToInt32(cmbUsage.SelectedValue);
                UnitBuild.TypeCode = Convert.ToInt32(cmbType.SelectedValue);
                UnitBuild.UnitJob = Convert.ToInt32(cmbJobs.SelectedValue);
                UnitBuild.InitialArea = Convert.ToDouble(txtInitialArea.FloatValue);
                UnitBuild.InitialRental = Convert.ToDecimal(txtInitialRental.FloatValue);
                UnitBuild.DeliveryDate = txtDeliveryDate.Date;
                UnitBuild.UDesc = txtDesc.Text;
                UnitBuild.Balcon = txtBalcon.DecimalValue;
                if (txtTafsiliBazar.Text != "")
                {
                    UnitBuild.Tafsili2 = txtTafsiliBazar.IntValue;
                }
                if (txtTafsiliSepad.Text != "")
                {
                    UnitBuild.Tafsili1 = txtTafsiliSepad.IntValue;
                }
                if (txtGroundCodeMain.Text != "")
                    UnitBuild.GroundCode = txtGroundCodeMain.IntValue;
                //وضعیتی که فرم از قسمت تجمیع باز می شود
                if (!_State)
                {
                    JDataBase DB = new JDataBase();
                    DB.beginTransaction("UnitBuildSave");
                    try
                    {
                        if (this.State == JFormState.Insert)
                        {
                            int _code = UnitBuild.Insert(DB);
                            if (_code > 0)
                            {
                                this.State = JFormState.Update;
                                jPropertyValueUserControl1.ValueObjectCode = _code;
                                jPropertyValueUserControl1.Save(DB);

                                ArchiveList.ObjectCode = _code;
                                ArchiveList.ArchiveList();
                                DB.Commit();
                                return true;
                            }
                            DB.Rollback("UnitBuildSave");
                        }
                        else
                        {
                            if (this.State == JFormState.Update)
                            {
                                jPropertyValueUserControl1.Save(DB);
                                ArchiveList.ArchiveList();
                                bool Res = UnitBuild.Update();
                                if (Res)
                                    DB.Commit();
                                else
                                {
                                    DB.Rollback("UnitBuildSave");
                                    JMessages.Error(" خطا در ویرایش اطلاعات ", "");
                                }
                                return Res;
                            }
                            DB.Rollback("UnitBuildSave");
                            JMessages.Error(" خطا در ویرایش اطلاعات ", "");
                        }
                    }
                    finally
                    {
                        DB.Dispose();
                    }
                }
                else
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void AddPrimaryOwners_Click(object sender, EventArgs e)
        {
            JFindPersonForm JFPF = new JFindPersonForm();
            JFPF.ShowDialog();
            if (JFPF.SelectedPerson != null)
            {
                int PersonCode = JFPF.SelectedPerson.Code;
                AddPersonToGrid(PersonCode, 0);
            }
        }

        private void AddPersonToGrid(int PersonCode, decimal pShare)
        {
            if (UnitBuild.FindPrimaryOwner(PersonCode))
            {
                JMessages.Error("PersonExistsInList", "Error");
                return;
            }

            DataRow Row = ((DataTable)dgvPrimeryOwners.DataSource).NewRow();
            JAllPerson Person = new JAllPerson(PersonCode);
            Row[JPrimaryOwnerBuildTableEnum.Name.ToString()] = Person.Name;
            Row[JPrimaryOwnerBuildTableEnum.PCode.ToString()] = Person.Code;
            Row[JPrimaryOwnerBuildTableEnum.Share.ToString()] = pShare;

            Row[JPrimaryOwnerBuildTableEnum.BuildCode.ToString()] = UnitBuild.Code;
            UnitBuild.PrimeryOwner.Rows.Add(Row);
            btnSave.Enabled = true;
        }

        private void JUnitBuildForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (State == JFormState.Update)
                    ChangeNumber();
                tabControl1.TabPages.Remove(tpGround);
                dgvPrimeryOwners.DataSource = UnitBuild.PrimeryOwner;
                dgvPrimeryOwners.Columns["Code"].Visible = false;
                dgvPrimeryOwners.Columns["Code"].ReadOnly = true;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.Plaque.ToString()].Visible = false;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.BuildCode.ToString()].Visible = false;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.Name.ToString()].ReadOnly = true;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.PCode.ToString()].ReadOnly = true;
                btnSave.Enabled = false;

                if (State == JFormState.Insert && ((DataTable)dgvPrimeryOwners.DataSource).Rows.Count==0)
                    foreach (JDefaultOwner owner in JDefaultOwners.GetDefaultOwners())
                    {
                        AddPersonToGrid(owner.PCode, owner.Share);
                    }
                btnok.Enabled = false;

                if (_State == true)
                {
                    tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage2"]);
                    tabControl1.TabPages.Remove(tabControl1.TabPages["tabPage5"]);
                    tabControl1.TabPages.Remove(tabControl1.TabPages["tabOwners"]);
                    //tabControl1.TabPages.Remove(tabControl1.TabPages["tpGround"]);
                    tabControl1.TabPages.Remove(tabControl1.TabPages["tabHistory"]);
                    btnok.Enabled = false;
                    txtSearch.Enabled = false;
                    txtArea.Text = UnitBuild.Area.ToString();
                    cmbConstructionName.SelectedValue = UnitBuild.MarketCode;
                    cmbConstructionName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        private void txtPlaque_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void DelPrimaryOwners_Click(object sender, EventArgs e)
        {
            if (dgvPrimeryOwners.RowCount == 0)
                return;
            dgvPrimeryOwners.Rows.Remove(dgvPrimeryOwners.CurrentRow);
            btnSave.Enabled = true;
        }

        private bool CheckField()
        {
            try
            {
                //if ((_State == true) && (UnitBuild.Area <= Convert.ToDouble(txtArea.Text)))
                //{
                //    JMessages.Error("متراژ اعیان جدید از جمع متراژ اعیان های قبلی نمی تواند کمتر باشد", "خطا در ثبت اطلاعات");
                //    return false;
                //}
                if (cmbConstructionName.SelectedItem == null)
                {
                    JMessages.Error("لطفا مجتمع را انتخاب کنید", "خطا در ثبت اطلاعات");
                    return false;
                }
                if (cmbType.SelectedItem == null)
                {
                    JMessages.Error("لطفا نوع واحد را انتخاب کنید", "خطا در ثبت اطلاعات");
                    return false;
                }
                if (cmbFloor.SelectedItem == null)
                {
                    JMessages.Error("لطفا طبقه را انتخاب کنید", "خطا در ثبت اطلاعات");
                    return false;
                }
                //if (cmbFaz.SelectedItem == null)
                //{
                //    JMessages.Error("لطفا فاز را انتخاب کنید", "خطا در ثبت اطلاعات");
                //    return false;
                //}
                if (cmbUsage.SelectedItem == null)
                {
                    JMessages.Error("کاربری را مشخص کنید", "خطا در ثبت اطلاعات");
                    return false;
                }
                if (txtPlaque.Text == "")
                {
                    JMessages.Error("لطفا شماره شناسایی را وارد کنید", "خطا در ثبت اطلاعات");
                    txtPlaque.Focus();
                    return false;
                }

                if (txtArea.FloatValue == 0 && txtInitialArea.FloatValue == 0)
                {
                    JMessages.Error("لطفا یکی از متراژها را وارد کنید", "خطا در ثبت اطلاعات");
                    txtArea.Focus();
                    return false;
                }
                if (UnitBuild.PrimeryOwner.Rows.Count == 0)
                {
                    JMessages.Error("PleaseEnterAtLeastOnePrimaryOwner", "خطا در ثبت اطلاعات");
                    tabControl1.SelectedTab = tabPage3;
                    //tabPage3.Show();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void dgvPrimeryOwners_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void JUnitBuildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (btnSave.Enabled && !_State)
            {
                DialogResult result = JMessages.Confirm("DoYouWantToSaveChanges?", "SaveChanges");
                if (result == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    Close();
                    return;
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

        private void jPropertyValueUserControl1_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPlaque_Leave(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void txtPlaqueRegistration_Leave(object sender, EventArgs e)
        {
            if (State == JFormState.Insert)
                if (cmbConstructionName.SelectedItem != null && txtPlaqueRegistration.Text != "")
                    if (UnitBuild.Find(txtPlaqueRegistration.Text, (int)((DataRowView)cmbConstructionName.SelectedItem)["Code"]))
                    {
                        JMessages.Error("این واحد قبلا ثبت شده است", "خطا در ثبت اطلاعات");
                    }
        }
        /// <summary>
        /// چک کردن مشخصات زمین
        /// </summary>
        /// <param name="Ground"></param>
        /// <returns></returns>
        private bool CheckGround(int Ground)
        {
            Finance.JAsset Asset = new Finance.JAsset("Estates.JGround", Ground);
            if (Asset.Code == 0)
            {
                JMessages.Error("مشخصات این دارایی در سیستم مو جود نیست", "خطا");
                return false;
            }
            return true;
        }
        /// <summary>
        /// جستجوی زمین
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroundMainSearch_Click(object sender, EventArgs e)
        {
            Estates.JSearchGroundForm JSGF = new Estates.JSearchGroundForm();
            JSGF.ShowDialog();
            //FillGround(JSGF.Code);
        }
        /// <summary>
        /// پر کردن اطلاعات زمین
        /// </summary>
        /// <param name="pCode"></param>
        private void FillGround(int pCode)
        {
            if (JUnitBuild.FindGround(pCode, UnitBuild.Code))
            {
                if (pCode > 0)
                    if (CheckGround(pCode))
                    {
                        txtGroundCodeMain.Text = pCode.ToString();
                        //نمایش اطلاعات زمین تفکیکی
                        JGround GroundMain = new JGround(pCode);
                        labArea.Text = GroundMain.Area.ToString();
                        labBlockNum.Text = GroundMain.BlockNum.ToString();
                        labLand.Text = (new JLand(GroundMain.Land)).Name;
                        labPartNum.Text = GroundMain.PartNum.ToString();
                        labSection.Text = GroundMain.Section;
                        labSubAve.Text = GroundMain.SubNo;
                        labUsage.Text = (new JUsageGround(GroundMain.Usage)).Name;
                        labMainAve.Text = GroundMain.MainAve;
                        labNorth.Text = GroundMain.About.North;
                        labSouth.Text = GroundMain.About.South;
                        labWest.Text = GroundMain.About.West;
                        labEast.Text = GroundMain.About.East;
                        labSection.Text = GroundMain.Section;
                    }
            }
            else
                JMessages.Error("این زمین برای اعیان دیگری انتخاب شده است", "خطا");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JSearchUnitForm JSUF = new JSearchUnitForm();
            JSUF.ShowDialog();
            int SelectCode = JSUF.SelectedCode;
            if (SelectCode > 0)
            {
                this.State = JFormState.Update;
                UnitBuild = new JUnitBuild(SelectCode);
                jPropertyValueUserControl1.ValueObjectCode = SelectCode;

                ArchiveList.ClassName = "RealEstate.JUnitBuild";
                ArchiveList.ObjectCode = SelectCode;
                ArchiveList.PlaceCode = 0;
                ArchiveList.SubjectCode = 0;
                try
                {
                    _setForm();
                }
                catch (Exception ex)
                {
                }
                cmbConstructionName.Enabled = false;
                btnok.Enabled = false;

            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            JSearchUnitForm JSUF = new JSearchUnitForm();
            JSUF.ShowDialog();
            int SelectCode = JSUF.SelectedCode;
            if (SelectCode > 0)
            {
                this.State = JFormState.Update;
                UnitBuild = new JUnitBuild(SelectCode);
                jPropertyValueUserControl1.ValueObjectCode = SelectCode;

                ArchiveList.ClassName = "RealEstate.JUnitBuild";
                ArchiveList.ObjectCode = SelectCode;
                ArchiveList.PlaceCode = 0;
                ArchiveList.SubjectCode = 0;
                
                grdContractsDefinit.DataSource = null;
                grdContractsGoodwill.DataSource = null;
                grdContractsRent.DataSource = null;
                grdGoodwillAndRent.DataSource = null; 
                grdOtherContracts.DataSource = null;

                jDataGridGoodWillContract.DataSource = null;
                jDataGridMainContract.DataSource = null;
                jDataGridRentalContract.DataSource = null;
                try
                {
                    _setForm();
                }
                catch (Exception ex)
                {
                }
                cmbConstructionName.Enabled = false;
                btnok.Enabled = false;

            }
        }

        private void txtTafsiliSepad_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtTafsiliBazar_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void jDataGridRentalContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (jDataGridRentalContract.RowCount > 0)
            {
                jDataGridRentalContract.ClearActions();
                List<JAction> actions = CreateOwnersActions(Convert.ToInt32(jDataGridRentalContract.Rows[e.RowIndex].Cells["ContractCode"].Value),
                  Convert.ToInt32(jDataGridRentalContract.Rows[e.RowIndex].Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    jDataGridRentalContract.AddAction(action);
                }
            }
        }

        private void jDataGridGoodWillContract_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (jDataGridGoodWillContract.RowCount > 0)
            {
                jDataGridGoodWillContract.ClearActions();
                List<JAction> actions = CreateOwnersActions(Convert.ToInt32(jDataGridGoodWillContract.Rows[e.RowIndex].Cells["ContractCode"].Value),
                   Convert.ToInt32(jDataGridGoodWillContract.Rows[e.RowIndex].Cells["PCode"].Value));
                 foreach (JAction action in actions)
                 {
                     jDataGridGoodWillContract.AddAction(action);
                 }
            }
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
                //actions.Add(splitter);
                JAction ReapirAction = new JAction("RepairContract...", "Legal.JRepairContractForm.Show", null, new object[] { contract.Code });
                actions.Add(ReapirAction);

                /// تعیین قرارداد جاری
                JAction SetAsCurrentContract = new JAction("SetAsCurrentContract...", "Legal.JSubjectContract.SetAsCurrentContract", new object[] { contract.FinanceCode, contract.Code, DynamicType.AssetTransferType }, null);
                actions.Add(SetAsCurrentContract);

                actions.Add(splitter);

                if (JPermission.CheckPermission("Legal.JGeneralContract.ShowForms", contractDefine.ContractType, JMainFrame.CurrentPostCode,false))
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
                JAction CancelAction = new JAction("Dissolution...", "Legal.JSubjectContract.CancelContract", null, new object[] {  contract.Code});
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
        }

        private void SetGoodwillContractGrid(int pAssetCode)
        {
            grdContractsGoodwill.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.Goodwill);
            (grdContractsGoodwill.DataSource as DataTable).Select("Share <> 0");
            grdContractsGoodwill.Columns["StartDate"].Visible = false;
            grdContractsGoodwill.Columns["EndDate"].Visible = false;
            //grdContractsGoodwill.Columns["GoodwillPrice"].Visible = false;
            grdContractsGoodwill.Columns["Price"].Visible = false;
            grdContractsGoodwill.Columns["PriceMonth"].Visible = false;
        }

        private void SetRentContractGrid(int pAssetCode)
        {
            grdContractsRent.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.Rentals);
            grdContractsRent.Columns["TotalPrice"].Visible = false;
            grdContractsRent.Columns["GoodwillPrice"].Visible = false;
            grdContractsRent.Columns["Share"].Visible = false;
        }

        private void SetDefinitContractGrid(int pAssetCode)
        {
            grdContractsDefinit.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode , Finance.JOwnershipType.Definitive);
            (grdContractsDefinit.DataSource as DataTable).Select("Share <> 0");
            grdContractsDefinit.Columns["StartDate"].Visible = false;
            grdContractsDefinit.Columns["EndDate"].Visible = false;
            grdContractsDefinit.Columns["GoodwillPrice"].Visible = false;
            grdContractsDefinit.Columns["Price"].Visible = false;
            grdContractsDefinit.Columns["PriceMonth"].Visible = false;
        }

        private void SetGoodwillAndRentContractGrid(int pAssetCode)
        {
            grdGoodwillAndRent.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.GoodwillPeace);
            (grdGoodwillAndRent.DataSource as DataTable).Select("Share <> 0");
            grdGoodwillAndRent.Columns["StartDate"].Visible = false;
            grdGoodwillAndRent.Columns["EndDate"].Visible = false;
            grdGoodwillAndRent.Columns["GoodwillPrice"].Visible = false;
            grdGoodwillAndRent.Columns["Price"].Visible = false;
            grdGoodwillAndRent.Columns["PriceMonth"].Visible = false;
        }

        private void SetOtherContractGrid(int pAssetCode)
        {
            grdOtherContracts.DataSource = Legal.JSubjectContracts.ContractHistory(pAssetCode, Finance.JOwnershipType.Other);
            (grdOtherContracts.DataSource as DataTable).Select("Share <> 0");
            grdOtherContracts.Columns["StartDate"].Visible = false;
            grdOtherContracts.Columns["EndDate"].Visible = false;
            grdOtherContracts.Columns["GoodwillPrice"].Visible = false;
            grdOtherContracts.Columns["Price"].Visible = false;
            grdOtherContracts.Columns["PriceMonth"].Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Tab History
            if (tabControl1.SelectedTab == tabHistory1 && grdContractsGoodwill.DataSource == null)
            {
                Finance.JAsset Asset = new Finance.JAsset("RealEstate.JUnitBuild", UnitBuild.Code);

                SetDefinitContractGrid(Asset.Code);

                SetGoodwillContractGrid(Asset.Code);

                SetRentContractGrid(Asset.Code);

                SetGoodwillAndRentContractGrid(Asset.Code);

                SetOtherContractGrid(Asset.Code);
             
            }
            #endregion Tab History

            #region Tab Owners
            if (tabControl1.SelectedTab == tabOwners && jDataGridMainContract.DataSource == null)
            {
                /// قطعی
                jDataGridMainContract.DataSource = Finance.JAssetTransfer.GetAssetShare(UnitBuild.Code, "RealEstate.JUnitBuild", Finance.JOwnershipType.Definitive);
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

                /// مالکین سرقفلی
                jDataGridGoodWillContract.DataSource = Finance.JAssetTransfer.GetAssetShare(UnitBuild.Code, "RealEstate.JUnitBuild", Finance.JOwnershipType.Goodwill);
                if (jDataGridGoodWillContract.RowCount > 0)
                {
                    List<JAction> actions = CreateActions(Convert.ToInt32(jDataGridGoodWillContract.Rows[0].Cells["ContractCode"].Value),
                      Convert.ToInt32(jDataGridGoodWillContract.Rows[0].Cells["PCode"].Value));
                    foreach (JAction action in actions)
                    {
                        jDataGridGoodWillContract.AddAction(action);
                        jDataGridGoodWillContract.Columns["ContractCode"].Visible = false;
                    }
                }
                /// مستاجرین
                jDataGridRentalContract.DataSource = Legal.JPersonContract.GetRenterList(UnitBuild.Code, "RealEstate.JUnitBuild", null);
                if (jDataGridRentalContract.RowCount > 0)
                {
                    List<JAction> actions = CreateActions(Convert.ToInt32(jDataGridRentalContract.Rows[0].Cells["ContractCode"].Value),
                      Convert.ToInt32(jDataGridRentalContract.Rows[0].Cells["PersonCode"].Value));
                    foreach (JAction action in actions)
                    {
                        jDataGridRentalContract.AddAction(action);
                        jDataGridRentalContract.Columns["ContractCode"].Visible = false;
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

        private void grdContractsGoodwill_CellClick(object sender, MouseEventArgs e)
        {
            if (grdContractsGoodwill.gridEX1.CurrentRow == null) return;
            if (grdContractsGoodwill.RowCount > 0)
            {
                grdContractsGoodwill.Focus();
                grdContractsGoodwill.ClearActions();
                List<JAction> actions = CreateActions(
                     Convert.ToInt32(grdContractsGoodwill.gridEX1.CurrentRow.Cells["ContractCode"].Value),
                   Convert.ToInt32(grdContractsGoodwill.gridEX1.CurrentRow.Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    grdContractsGoodwill.AddAction(action);
                }
            }
        }


        private void grdGoodwillAndRent_CellClick(object sender, MouseEventArgs e)
        {
            if (grdGoodwillAndRent.gridEX1.CurrentRow == null) return;
            if (grdGoodwillAndRent.RowCount > 0)
            {
                grdGoodwillAndRent.ClearActions();
                List<JAction> actions = CreateActions(Convert.ToInt32(grdGoodwillAndRent.gridEX1.CurrentRow.Cells["ContractCode"].Value),
                   Convert.ToInt32(grdGoodwillAndRent.gridEX1.CurrentRow.Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    grdGoodwillAndRent.AddAction(action);
                }
            }
        }

        private void grdOtherContracts_CellClick(object sender, MouseEventArgs e)
        {
            if (grdOtherContracts.gridEX1.CurrentRow == null) return;
            if (grdOtherContracts.RowCount > 0)
            {
                grdOtherContracts.ClearActions();
                List<JAction> actions = CreateActions(Convert.ToInt32(grdOtherContracts.gridEX1.CurrentRow.Cells["ContractCode"].Value),
                   Convert.ToInt32(grdOtherContracts.gridEX1.CurrentRow.Cells["PersonCode"].Value));
                foreach (JAction action in actions)
                {
                    grdOtherContracts.AddAction(action);
                }
            }
        }

        public void ChangeNumber()
        {
            if (JPermission.CheckPermission("RealEstate.JUnitBuildForm.ChangeNumber", UnitBuild.MarketCode, JMainFrame.CurrentPostCode, false))
                txtNumber.ReadOnly = false;
            else
                txtNumber.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UnitBuild.Code == 0)
                return;
            contextMenuStripContract.Items.Clear();
            EventHandler ClickEvent = new EventHandler(run);

            Finance.JAsset Asset = new Finance.JAsset(UnitBuild.GetType().FullName, UnitBuild.Code);

            Legal.JContractNodes CN = new Legal.JContractNodes();
            JNode[] _nodes = CN.ContractTree(UnitBuild.MarketCode);

            foreach (JNode _node in _nodes)
            {
                ToolStripItem TSI = contextMenuStripContract.Items.Add(_node.Name);
                if (_node.ChildsAction != null)
                {
                    JNode[] _childnodes = (JNode[])_node.ChildsAction.run();
                    foreach (JNode _childnode in _childnodes)
                    {
                        int tafsili = 0;
                        int.TryParse(txtTafsiliSepad.Text, out tafsili);

                        ToolStripItem TSIChild = ((ToolStripMenuItem)TSI).DropDownItems.Add(_childnode.Name, null, ClickEvent);
                        TSIChild.Tag =
                            new JAction("NewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { _childnode.Code, 0, Asset.Code, false, 0, (int)cmbConstructionName.SelectedValue, tafsili });
                    }
                }
            }

            //contextMenuStripContract.Show(this.Left+ ((Button)sender).Left + ((Button)sender).Width / 2,this.Top+ ((Button)sender).Top + ((Button)sender).Height / 2);
            contextMenuStripContract.Show(MousePosition);
        }

        private void run(object sender, EventArgs e)
        {
            JAction t = (JAction)((System.Windows.Forms.ToolStripItem)sender).Tag;
            object s = t.run();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdContractsDefinit.DataSource = null;
            grdContractsGoodwill.DataSource = null;
            grdContractsRent.DataSource = null;
            grdGoodwillAndRent.DataSource = null;
            grdOtherContracts.DataSource = null;

            jDataGridGoodWillContract.DataSource = null;
            jDataGridMainContract.DataSource = null;
            jDataGridRentalContract.DataSource = null;

            tabControl1_SelectedIndexChanged(sender, e);
        }

    }
}
