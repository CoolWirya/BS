using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Estates
{
    public partial class JUnitBuildForm : ClassLibrary.JBaseForm
    {
        JUnitBuild UnitBuild;
        /// <summary>
        /// میزان دانگ کل یک فروشگاه
        /// </summary>
        int Share = 6;
        //مقدار پیش فرض combobox
        string NullCmbSelected = "-----------";
        public JUnitBuildForm(int pCode)
        {
            InitializeComponent();
            UnitBuild = new JUnitBuild(pCode);
            jPropertyValueUserControl1.ValueObjectCode = pCode;

            ArchiveList.ClassName = "Estates.JUnitBuild";
            ArchiveList.ObjectCode = pCode;
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
            
            _setForm();
            cmbConstructionName.Enabled = false;
        }

        public JUnitBuildForm()
        {
            InitializeComponent();
            UnitBuild = new JUnitBuild();
            _fillComboBox();
        
            ArchiveList.ClassName = "Estates.JUnitBuild";
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
        }

        private void _setForm()
        {
            _fillComboBox();

            jMarket Mark = new jMarket(UnitBuild.MarketCode);
            cmbConstructionName.Text = Mark.Title;

            //JUnitType UnitType = new JUnitType();
            //UnitType.GetData(UnitBuild.TypeCode);
            //cmbType.Text = UnitType.Name;


            txtPlaque.Text = UnitBuild.Plaque;

            txtPlaqueRegistration.Text = UnitBuild.PlaqueRegistration.ToString();

            txtArea.Text = UnitBuild.Area.ToString();

            jMarketFloors Mfs = new jMarketFloors();
            Mfs.GetData(UnitBuild.FloorCode);
            cmbFloor.Text = Mfs.Name;

            txtNumber.Text = UnitBuild.Number;

            jMarketUsage MU = new jMarketUsage();
            MU.GetData(UnitBuild.UsageCode);

            JDefineMarketUsage DMU = new JDefineMarketUsage();
            DMU.GetData(MU.UsageCode);
            cmbUsage.Text = DMU.Name;
            btnSave.Enabled = false;

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
                foreach (JSubBaseDefine city in UnitType.Items)
                {
                    cmbType.Items.Add(city);
                    if (city.Code == this.UnitBuild.TypeCode)
                        cmbType.SelectedItem = (JSubBaseDefine)city;
                }

                JUnitJobs UnitJobs = new JUnitJobs();
                cmbJobs.Items.Clear();
                cmbJobs.Items.Add(nullDeff);
                cmbJobs.SelectedItem = nullDeff;
                foreach (JSubBaseDefine job in UnitJobs.Items)
                {
                    cmbJobs.Items.Add(job);
                    if (job.Code == this.UnitBuild.UnitJob)
                        cmbJobs.SelectedItem = (JSubBaseDefine)job;
                }

                DataTable Markets = jMarkets.GetDataTable(0);
                               
                
                cmbConstructionName.DisplayMember = estMarket.Title.ToString();
                cmbConstructionName.ValueMember = estMarket.Code.ToString();
                cmbConstructionName.DataSource = Markets;
                cmbConstructionName.SelectedItem = null;
                
                
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    
        private void Close_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                if (save())
                {
                    btnSave.Enabled = false;
                }
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

                //نمایش کاربری های  مجتمع بر اساس مجتمع انتخاب شده
                jMarketUsage Usage = new jMarketUsage();
                DataTable UsageTable = Usage.GetDataByMarketCode(CodeMarket);
                cmbUsage.DataSource = UsageTable;
                cmbUsage.DisplayMember = "Name";
                cmbUsage.ValueMember = estMarketUsage.Code.ToString();
                cmbUsage.SelectedItem = null;

                if (UnitBuild.MarketCode == 0 || Convert.ToInt32(cmbConstructionName.SelectedValue) == UnitBuild.MarketCode)
                {
                    jPropertyValueUserControl1.ClassName = "Estates.jMarket";
                    jPropertyValueUserControl1.ObjectCode = Convert.ToInt32(cmbConstructionName.SelectedValue);
                }         

        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (CheckField())
            {
                if (save())
                {
                    Close();
                }
            }
        }

        private bool save()
        {
            try
            {
                object SumShare = UnitBuild.PrimeryOwner.Compute("Sum(" + JPrimaryOwnerBuildTableEnum.Share + ")", "");
                if (SumShare == DBNull.Value)
                    SumShare = 0;
                if (Convert.ToDecimal(SumShare) != Share)
                {
                    JMessages.Error("مجموع میزان سهم برابر با" + Share.ToString() + " نیست", "Error");
                    return false;
                }
                UnitBuild.Area =txtArea.FloatValue;
                UnitBuild.FloorCode = Convert.ToInt32(cmbFloor.SelectedValue);
                UnitBuild.MarketCode = Convert.ToInt32(cmbConstructionName.SelectedValue);
                UnitBuild.Number = txtNumber.Text;
                UnitBuild.Plaque = txtPlaque.Text;
                UnitBuild.PlaqueRegistration = txtPlaqueRegistration.IntValue;
                UnitBuild.UsageCode = Convert.ToInt32(cmbUsage.SelectedValue);
                UnitBuild.TypeCode = Convert.ToInt32(((JSubBaseDefine)cmbType.SelectedItem).Code);
                UnitBuild.UnitJob = ((JSubBaseDefine)cmbJobs.SelectedItem).Code;

                if (this.State == JFormState.Insert)
                {
                     int _code = UnitBuild.Insert();
                    if (_code > 0)
                    {
                        this.State = JFormState.Update;
                        jPropertyValueUserControl1.SaveNew(_code);
                        ArchiveList.ObjectCode = _code;
                        ArchiveList.ArchiveList();
                        return true;
                    }
                }
                else
                    if (this.State == JFormState.Update)
                    {
                        jPropertyValueUserControl1.Save();
                        ArchiveList.ArchiveList();
                        return UnitBuild.Update();

                    }
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
                if (UnitBuild.FindPrimaryOwner(PersonCode))
                {
                    JMessages.Error("PersonExistsInList", "Error");
                    return;
                }
                
                DataRow Row = ((DataTable)dgvPrimeryOwners.DataSource).NewRow();
                if (JFPF.SelectedPerson.PersonType == JPersonTypes.RealPerson)
                {
                    JAllPerson Person = new JAllPerson(PersonCode);
                    Row[JPrimaryOwnerBuildTableEnum.Name.ToString()] = Person.Name;
                    //Row[JPrimaryOwnerBuildTableEnum.fam.ToString()] = Person.Fam;
                    //Row[JPrimaryOwnerBuildTableEnum.shsh.ToString()] = Person.ShSh;
                    Row[JPrimaryOwnerBuildTableEnum.PCode.ToString()] = Person.Code;
                }
                else
                    if (JFPF.SelectedPerson.PersonType == JPersonTypes.LegalPerson)
                    {
                        JOrganization Person = new JOrganization(PersonCode);
                        Row[JPrimaryOwnerBuildTableEnum.Name.ToString()] = Person.Name;
                        //Row[JPrimaryOwnerBuildTableEnum.fam.ToString()] = Person.Managing_Director;
                        //Row[JPrimaryOwnerBuildTableEnum.shsh.ToString()] = Person.RegisterNo;
                        Row[JPrimaryOwnerBuildTableEnum.PCode.ToString()] = Person.Code;
                    }
                Row[JPrimaryOwnerBuildTableEnum.BuildCode.ToString()] = UnitBuild.Code;
                UnitBuild.PrimeryOwner.Rows.Add(Row);
                btnSave.Enabled = true;
            }


        }

        private void JUnitBuildForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvPrimeryOwners.DataSource = UnitBuild.PrimeryOwner;                
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.Code.ToString()].Visible = false;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.Plaque.ToString()].Visible = false;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.PCode.ToString()].Visible = false;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.BuildCode.ToString()].Visible = false;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.AssetShareCode.ToString()].Visible = false;
                dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.Name.ToString()].ReadOnly = true;
                //dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.fam.ToString()].ReadOnly = true;
                //dgvPrimeryOwners.Columns[JPrimaryOwnerBuildTableEnum.shsh.ToString()].ReadOnly = true;
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
            if (cmbUsage.SelectedItem ==null)
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
            if (UnitBuild.PrimeryOwner.Rows.Count == 0)
            {
                JMessages.Error("PleaseEnterAtLeastOnePrimaryOwner", "خطا در ثبت اطلاعات");
                tabPage3.Show();
                return false;
            }
            return true;
            
        }

        private void dgvPrimeryOwners_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void JUnitBuildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled)
            {
                DialogResult result = JMessages.Confirm("DoYouWantToSaveChanges", "SaveChanges");
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
    }
}
