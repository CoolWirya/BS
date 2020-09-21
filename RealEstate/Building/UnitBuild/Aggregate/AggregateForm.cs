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

namespace RealEstate
{
    public partial class JAggregateForm : Globals.JBaseForm
    {
        DataTable _dtUnitBuid = new DataTable();
        int _Code;
        JUnitBuildForm tmpJUnitBuild;
        double TotalArea = 0;
        JUnitBuild UnitBuild;

        public JAggregateForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "RealEstate.JAggregateUnitBuild";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = _Code;            
        }

        public JAggregateForm()
        {
            InitializeComponent();
            //GetPattern();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "RealEstate.JAggregateUnitBuild";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        private void Set_Form()
        {
            JAggregateUnitBuild tmp = new JAggregateUnitBuild();
            tmp.GetData(_Code);
            txtDate.Date = tmp.Date;
            txtDescAgg.Text = tmp.Description;
            _dtUnitBuid = JAggregateUnitBuilds.GetDataTable(_Code);
            jdgvUnit.DataSource = _dtUnitBuid;
            JUnitBuild tmpUnitBuild = new JUnitBuild(tmp.UnitBuildCode);
            SetUnitBuild(tmpUnitBuild);
            btnAddAgregatedGrands.Visible = false;
            btnDelAgregatedUnit.Visible = false;
        }

        private void GetPattern()
        {
            _dtUnitBuid.Columns.Add("Code");
            _dtUnitBuid.Columns.Add("UnitBuildCode");
            _dtUnitBuid.Columns.Add("MarketCode");
            _dtUnitBuid.Columns.Add("MarketName");
            _dtUnitBuid.Columns.Add("NumberUnitBuild");
            jdgvUnit.DataSource = _dtUnitBuid;
        }

        private void SetUnitBuild(JUnitBuild UnitBuild)
        {
            lblMarket.Text = UnitBuild.MarketName;
            lblBalcon.Text = UnitBuild.Balcon.ToString();
            lblFloor.Text = (new jMarketFloors(UnitBuild.FloorCode)).Name;
            lblInfra.Text = UnitBuild.Area.ToString();
            lblInfraAbout.Text = UnitBuild.InitialArea.ToString();
            lblDate.Text = JDateTime.FarsiDate(Convert.ToDateTime(UnitBuild.DeliveryDate.Date));
            lblNumPlaquc.Text = UnitBuild.Plaque;
            lblRegPlaque.Text = UnitBuild.PlaqueRegistration;
            lblUnitNumber.Text = UnitBuild.Number;
            lblRent.Text = UnitBuild.InitialRental.ToString();
        }

        private void BtnDefineUnit_Click(object sender, EventArgs e)
        {
            if (jdgvUnit.Rows.Count > 1)
            {
                if (UnitBuild == null)
                {
                    int oldCode = Convert.ToInt32(jdgvUnit.Rows[0].Cells["UnitBuildCode"].Value.ToString());
                    JUnitBuild oldUnitBuild = new JUnitBuild(oldCode);
                    UnitBuild = new JUnitBuild();
                    UnitBuild.MarketCode = oldUnitBuild.MarketCode;// Convert.ToInt32(jdgvUnit.Rows[0].Cells["MarketCode"].Value);
                    UnitBuild.FloorCode = oldUnitBuild.FloorCode;
                    UnitBuild.TypeCode = oldUnitBuild.TypeCode;
                    UnitBuild.UnitJob = oldUnitBuild.UnitJob;
                    UnitBuild.UsageCode = oldUnitBuild.UsageCode;
                    UnitBuild.Area = TotalArea;
                }
                tmpJUnitBuild = new JUnitBuildForm(UnitBuild);
                if (tmpJUnitBuild.ShowDialog() == DialogResult.OK)
                {
                    SetUnitBuild(tmpJUnitBuild.UnitBuild);
                    btnSave.Enabled = true;
                }
            }
            else
                JMessages.Message("لطفا ابتدا حداقل 2 اعیان را برای تجمیع انتخاب کنید ", "", JMessageType.Information);
        }

        private void btnAddAgregatedGrands_Click(object sender, EventArgs e)
        {            
            JSearchUnitForm JSUF = new JSearchUnitForm();
            JSUF.MultiSelect = true;
            JSUF.ShowDialog();
            int[] SelectCodes = JSUF.SelectedCodes;
            JUnitBuild tmpUnitBuild = new JUnitBuild();
            for (int i = 0; i < SelectCodes.Length; i++)
            {
                tmpUnitBuild.GetData(SelectCodes[i]);
                if ((SelectCodes[i] > 0) && !(_dtUnitBuid.Select(" MarketCode <>" + tmpUnitBuild.MarketCode).Length > 0) && !(_dtUnitBuid.Select(" UnitBuildCode =" + tmpUnitBuild.Code).Length > 0))
                {
                    TotalArea = TotalArea + tmpUnitBuild.Area;
                    //this.State = JFormState.Update;
                    DataRow dr = _dtUnitBuid.NewRow();
                    dr["UnitBuildCode"] = SelectCodes[i];
                    dr["MarketCode"] = tmpUnitBuild.MarketCode;
                    dr["MarketName"] = tmpUnitBuild.MarketName;
                    dr["NumberUnitBuild"] = tmpUnitBuild.Number;
                    _dtUnitBuid.Rows.Add(dr);
                    jdgvUnit.DataSource = _dtUnitBuid;
                    btnSave.Enabled = true;
                }
            }
        }

        private void btnDelAgregatedUnit_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvUnit.CurrentRow != null)
                {
                    jdgvUnit.Rows.Remove(jdgvUnit.CurrentRow);
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    btnSave.Enabled = false;
                    this.State = JFormState.Update;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if ((btnSave.Enabled == true) && (State != JFormState.Update))
            {
                if (MessageBox.Show(JLanguages._Text("DoYouWantToSaveChanges"), "Information", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    if (Save())
                        this.Close();
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    this.Close();
            }
            else
                this.Close();
        }

        private bool Save()
        {
            try
            {
                #region CheckControl
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error("تاریخ تجمیع را وارد است", "error");
                    return false;
                }
                if (jdgvUnit.Rows.Count == 0)
                {
                    JMessages.Error("اعیان ها را وارد کنید", "error");
                    return false;
                }
                if (lblMarket.Text == "-")
                {
                    JMessages.Error("اعیان جدید را وارد کنید", "error");
                    return false;
                }
                #endregion
                                                    
                JAggregateUnitBuild tmpJAggregateUnitBuild = new JAggregateUnitBuild();
                if (State == JFormState.Update)
                    tmpJAggregateUnitBuild.GetData(_Code);
                tmpJAggregateUnitBuild.Date = txtDate.Date;
                tmpJAggregateUnitBuild.Description = txtDescAgg.Text;

                JArchive.ClassName = "RealEstate.JAggregateUnitBuild";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------
                if (this.State != JFormState.Update)
                {
                    //----------Update Archive------------
                    _Code = tmpJAggregateUnitBuild.Insert(_dtUnitBuid, UnitBuild);
                    if (_Code > 0)
                    {
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
                }
                else
                {
                    tmpJAggregateUnitBuild.Code =_Code;
                    if (tmpJAggregateUnitBuild.Update())
                    {
                        tmpJAggregateUnitBuild.Code = _Code;
                        JArchive.ObjectCode = _Code;
                        JArchive.ArchiveList();
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message(" Update Not Successfuly ", "", JMessageType.Error);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void JAggregateForm_Load(object sender, EventArgs e)
        {
            if (this.State == JFormState.Update)
                Set_Form();                        
            else
            {
                txtDate.Date = JDateTime.Now();
                GetPattern();
            }
            jdgvUnit.Columns["UnitBuildCode"].Visible = false;
            jdgvUnit.Columns["MarketCode"].Visible = false;
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void jdgvUnit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            JUnitBuildForm UBf = new JUnitBuildForm(Convert.ToInt32(jdgvUnit.CurrentRow.Cells["UnitBuildCode"].Value.ToString()));
            UBf.State = JFormState.ReadOnly;
            UBf.ShowDialog();
        }

    }
}
