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
    public partial class JBreakDownForm : Globals.JBaseForm
    {
        //DataTable _dtUnitBuid = new DataTable();
        int _Code;
        JUnitBuildForm tmpJUnitBuild;
        double TotalArea = 0;
        JUnitBuild UnitBuild;
        JUnitBuild[] UnitBuildNew;

        public JBreakDownForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "RealEstate.JBreakDownUnitBuild";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = _Code;            
        }

        public JBreakDownForm()
        {
            InitializeComponent();
            //GetPattern();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "RealEstate.JBreakDownUnitBuild";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        private void Set_Form()
        {     
            JBreakDownUnitBuild tmp = new JBreakDownUnitBuild();
            tmp.GetData(_Code);

            foreach (JUnitBuild UNitBuild in tmp.UnitBuildsBreakdown)
                libGroundsBreakdown.Items.Add(UNitBuild);

            txtDate.Date = tmp.Date;
            txtDescAgg.Text = tmp.Description;
            //_dtUnitBuid = JAggregateUnitBuilds.GetDataTable(_Code);
            //jdgvUnit.DataSource = _dtUnitBuid;
            JUnitBuild tmpUnitBuild = new JUnitBuild(tmp.UnitBuildCode);
            SetUnitBuild(tmpUnitBuild);
            btnAddAgregatedGrands.Visible = false;
            btnDelAgregatedUnit.Visible = false;
        }

        //private void GetPattern()
        //{
        //    _dtUnitBuid.Columns.Add("Code");
        //    _dtUnitBuid.Columns.Add("UnitBuildCode");
        //    _dtUnitBuid.Columns.Add("MarketCode");
        //    _dtUnitBuid.Columns.Add("MarketName");
        //    _dtUnitBuid.Columns.Add("NumberUnitBuild");
        //    jdgvUnit.DataSource = _dtUnitBuid;
        //}

        private void SetUnitBuild(JUnitBuild UnitBuild)
        {
            lblMarket.Text = UnitBuild.MarketName;
            lblBalcon.Text = UnitBuild.Balcon.ToString();
            lblFloor.Text = UnitBuild.FloorCode.ToString();
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
            JSearchUnitForm JSUF = new JSearchUnitForm();
            JSUF.ShowDialog();
            int SelectCode = JSUF.SelectedCode;
            if (SelectCode > 0)
            {
                //this.State = JFormState.Update;
                UnitBuild = new JUnitBuild(SelectCode);
                SetUnitBuild(UnitBuild);
                btnSave.Enabled = true;
            }
        }

        private void btnAddAgregatedGrands_Click(object sender, EventArgs e)
        {
            try
            {
                if (UnitBuild != null)
                {
                    //UnitBuild = new JUnitBuild();
                    //UnitBuild.MarketCode = Convert.ToInt32(jdgvUnit.Rows[0].Cells["MarketCode"].Value);
                    //UnitBuild.Area = TotalArea;
                    JUnitBuild NewUnitBuild = new JUnitBuild();
                    NewUnitBuild.MarketCode = UnitBuild.MarketCode;
                    NewUnitBuild.Area = UnitBuild.Area;
                    tmpJUnitBuild = new JUnitBuildForm(NewUnitBuild);
                    if (tmpJUnitBuild.ShowDialog() == DialogResult.OK)
                    {
                        if (tmpJUnitBuild.DialogResult == DialogResult.OK)
                        {
                            libGroundsBreakdown.Items.Add(tmpJUnitBuild.UnitBuild);
                            TotalArea = TotalArea + tmpJUnitBuild.UnitBuild.Area;
                            labSumArea.Text = TotalArea.ToString();
                        }
                        //TotalArea = TotalArea + tmpJUnitBuild.UnitBuild.Area;
                        ////this.State = JFormState.Update;
                        //DataRow dr = _dtUnitBuid.NewRow();
                        //dr["UnitBuildCode"] = tmpJUnitBuild;
                        //dr["MarketCode"] = tmpJUnitBuild.UnitBuild.MarketCode;
                        //dr["MarketName"] = tmpJUnitBuild.UnitBuild.MarketName;
                        //dr["NumberUnitBuild"] = tmpJUnitBuild.UnitBuild.Number;
                        //_dtUnitBuid.Rows.Add(dr);
                        //jdgvUnit.DataSource = _dtUnitBuid;
                        //btnSave.Enabled = true;
                        //btnSave.Enabled = true;
                    }
                }
                else
                    JMessages.Message("لطفا ابتدا اعیان را برای تفکیک انتخاب کنید ", "", JMessageType.Information);

                //if ((SelectCodes[i] > 0) && !(_dtUnitBuid.Select(" MarketCode <>" + tmpUnitBuild.MarketCode).Length > 0) && !(_dtUnitBuid.Select(" UnitBuildCode =" + tmpUnitBuild.Code).Length > 0))
                //{

                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelAgregatedUnit_Click(object sender, EventArgs e)
        {
            try
            {
                if ((libGroundsBreakdown.SelectedItem == null) && (State == JFormState.Update))
                    return;
                JUnitBuildForm GroundForm = new JUnitBuildForm((JUnitBuild)libGroundsBreakdown.SelectedItem);
                TotalArea -= ((JGround)libGroundsBreakdown.SelectedItem).Area;
                //GroundForm.State = JFormState.ReadOnly;
                GroundForm.ShowDialog();
                if (GroundForm.DialogResult == DialogResult.OK)
                {
                    libGroundsBreakdown.Items.Remove(libGroundsBreakdown.SelectedItem);
                    libGroundsBreakdown.Items.Add(GroundForm.UnitBuild);
                    TotalArea += GroundForm.UnitBuild.Area;
                    labSumArea.Text = TotalArea.ToString();
                }
                else
                    TotalArea += ((JUnitBuild)libGroundsBreakdown.SelectedItem).Area;
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
                if (Convert.ToDouble(labSumArea.Text) > Convert.ToDouble(lblInfra.Text))
                {
                    JMessages.Error(" جمع متراژ اعیان های جدید بزرگتر از اعیان تفکیک شده است", "error");
                    return false;
                }
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error("تاریخ تفکیک را وارد است", "error");
                    return false;
                }
                if (libGroundsBreakdown.Items.Count < 1)
                {
                    JMessages.Error("حداقل دو اعیان جدید را وارد کنید ", "error");
                    return false;
                }
                if (lblMarket.Text == "-")
                {
                    JMessages.Error("اعیان تفکیک شده را وارد کنید", "error");
                    return false;
                }
                #endregion

                JBreakDownUnitBuild tmpBreakDownUnitBuild = new JBreakDownUnitBuild();
                //مجموع مساحت زمین های انتخاب شده برای تفکیک
                //double GroundsArea=0;
                tmpBreakDownUnitBuild.UnitBuildsBreakdown = new JUnitBuild[libGroundsBreakdown.Items.Count];
                int i = 0;
                foreach (JUnitBuild UnitBuildItem in libGroundsBreakdown.Items)
                {
                    tmpBreakDownUnitBuild.UnitBuildsBreakdown[i] = UnitBuildItem;
                    i++;
                }                
                //if (State == JFormState.Update)
                //    tmpBreakDownUnitBuild.GetData(_Code);
                tmpBreakDownUnitBuild.Date = txtDate.Date;
                tmpBreakDownUnitBuild.Description = txtDescAgg.Text;
                tmpBreakDownUnitBuild.UnitBuildCode = UnitBuild.Code;
                JArchive.ClassName = "RealEstate.JBreakDownUnitBuild";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------
                if (this.State != JFormState.Update)
                {
                    //----------Update Archive------------
                    _Code = tmpBreakDownUnitBuild.Insert();
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
                    //tmpBreakDownUnitBuild.Code = _Code;
                    //if (tmpBreakDownUnitBuild.Update())
                    //{
                    //    tmpBreakDownUnitBuild.Code = _Code;
                    //    JArchive.ObjectCode = _Code;
                    //    JArchive.ArchiveList();
                    //    JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                    //    return true;
                    //}
                    //else
                    //    JMessages.Message(" Update Not Successfuly ", "", JMessageType.Error);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void JBreakDownForm_Load(object sender, EventArgs e)
        {
            if (this.State == JFormState.Update)
                Set_Form();                        
            else
            {
                txtDate.Date = JDateTime.Now();
                //GetPattern();
            }
            //jdgvUnit.Columns["UnitBuildCode"].Visible = false;
            //jdgvUnit.Columns["MarketCode"].Visible = false;
        }

    }
}
