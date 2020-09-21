using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RealEstate;
using ClassLibrary;

namespace Legal
{
    public partial class JGoodwillForm : JBaseContractForm
    {
        enum PropertiesForm
        {
            Rand_to_rent,
        }
        
        public JGoodwillForm()
        {
            InitializeComponent();
        }
        JUnitBuild UnitBuild;


        public JGoodwillForm MakeForm()
        {
            JGoodwillForm form = new JGoodwillForm();
            return form;
        }

        public bool CheckData()
        {
            if (State == JStateContractForm.View) return true;
            //if (txtBaseRent.Text == "")
            //{
            //    JMessages.Information("Please Enter Price", "Information");
            //    return false;
            //}            
            return true;
        }

        public bool ApplyData()
        {
            try
            {
                ContractForms.Contract.GoodwillPrice = Convert.ToDecimal(txtBaseRent.DecimalValue);
                ContractForms.Contract.Job = Convert.ToInt32(cmbJobs.SelectedValue);
                ContractForms.Contract.GoodWillStartDate = txtStartDate.Date;
                ///هزینه های انتقال
                if (rbSeller.Checked)
                    ContractForms.Contract.GoodwillCostsBy = JContractPartiesType.Seller;
                else
                    if (rbBuyer.Checked)
                        ContractForms.Contract.GoodwillCostsBy = JContractPartiesType.Buyer;
                    else
                        if (rbBoth.Checked)
                            ContractForms.Contract.GoodwillCostsBy = JContractPartiesType.Both;
                        else
                            ContractForms.Contract.GoodwillCostsBy = JContractPartiesType.None;

                ///هزینه های حق الزحمه
                if (rbTahrirSeller.Checked)
                    ContractForms.Contract.TahrirByRenter = JContractPartiesType.Seller;
                else
                    if (rbTahrirBuyer.Checked)
                        ContractForms.Contract.TahrirByRenter = JContractPartiesType.Buyer;
                    else
                        if (rbTahrirBoth.Checked)
                            ContractForms.Contract.TahrirByRenter = JContractPartiesType.Both;
                        else
                            ContractForms.Contract.TahrirByRenter = JContractPartiesType.None;

                ContractForms.Contract.GoodwillDesc = txtDesc.Text;
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
            //RealEstate.JAnnualRental tmpJAnnualRental = new RealEstate.JAnnualRental();
            //tmpJAnnualRental.BuildingCode = ContractForms.Contract.Code;
            //tmpJAnnualRental.StartDate = txtStartDate.Date;
            //tmpJAnnualRental.EndDate = ContractForms.Contract.EndDate;
            //tmpJAnnualRental.Price = Convert.ToDecimal(txtBaseRent.Text);
            //tmpJAnnualRental.Description = txtDesc.Text;
            //if (tmpJAnnualRental.Insert(tempdb) > 0)
                return true;
            //else
            //    return false;
        }

        // حذف  
        public bool delete(JDataBase DB)
        {
            //RealEstate.JAnnualRental tmpJAnnualRental = new RealEstate.JAnnualRental();
            //if (tmpJAnnualRental.delete(ContractForms.Contract.Code, txtStartDate.Date, DB))
            //    return false;
            return true;
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
                pDt.Columns.Add("GoodwillPrice");
                pDt.Columns.Add("Job");
                pDt.Columns.Add("GoodwillCostsBy");
                pDt.Columns.Add("GoodwillDesc");
                pDt.Columns.Add("TahrirByRenter");
                pDt.Columns.Add("GoodWillStartDate");

                if (pSetValue)
                {
                    if (pOffline)
                        Fill_Data();

                    pDt.Rows[0]["GoodwillPrice"] = txtBaseRent.Text;
                    pDt.Rows[0]["Job"] = cmbJobs.Text;
                    pDt.Rows[0]["GoodWillStartDate"] = JGeneral.ReverseDate(txtStartDate.Text);
                    switch (ContractForms.Contract.GoodwillCostsBy)
                    {
                        case JContractPartiesType.Both:
                            pDt.Rows[0]["GoodwillCostsBy"] =  " دو طرف ";
                            break;
                        case JContractPartiesType.Buyer:
                            pDt.Rows[0]["GoodwillCostsBy"] = ContractForms.Settings.Items["T2Lable"];
                            break;
                        case JContractPartiesType.Seller:
                            pDt.Rows[0]["GoodwillCostsBy"] = ContractForms.Settings.Items["T1Lable"];
                            break;
                        default:

                            break;
                    }
                    pDt.Rows[0]["GoodwillDesc"] = txtDesc.Text;
                }

                if (pSetValue)
                {
                    switch (ContractForms.Contract.TahrirByRenter)
                    {
                        case JContractPartiesType.Both:
                            pDt.Rows[0]["TahrirByRenter"] = " دو طرف ";
                            break;
                        case JContractPartiesType.Buyer:
                            pDt.Rows[0]["TahrirByRenter"] = ContractForms.Settings.Items["T2Lable"];
                            break;
                        case JContractPartiesType.Seller:
                            pDt.Rows[0]["TahrirByRenter"] = ContractForms.Settings.Items["T1Lable"];
                            break;
                        default:

                            break;
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



        public void SetForm()
        {
            txtBaseRent.Text = JMoney.DecimalToMoney(ContractForms.Contract.GoodwillPrice);
            txtStartDate.Date = ContractForms.Contract.GoodWillStartDate;
            txtDesc.Text = ContractForms.Contract.GoodwillDesc;
            switch (ContractForms.Contract.GoodwillCostsBy)
            {
                case JContractPartiesType.Both:
                    rbBoth.Checked = true;
                    break;
                case JContractPartiesType.Buyer:
                    rbBuyer.Checked = true;
                    break;
                case JContractPartiesType.Seller:
                    rbSeller.Checked = true;
                    break;
                default:
                    rbBoth.Checked = false;
                    rbBuyer.Checked = false;
                    rbSeller.Checked = false;
                    break;
            }
            switch (ContractForms.Contract.TahrirByRenter)
            {
                case JContractPartiesType.Both:
                    rbBoth.Checked = true;
                    break;
                case JContractPartiesType.Buyer:
                    rbBuyer.Checked = true;
                    break;
                case JContractPartiesType.Seller:
                    rbSeller.Checked = true;
                    break;
                default:
                    rbBoth.Checked = false;
                    rbBuyer.Checked = false;
                    rbSeller.Checked = false;
                    break;
            }

            if (State == JStateContractForm.View)
            {
                btnCalc.Enabled = false;
                txtBaseRent.ReadOnly = true;
                grpCosts.Enabled = false;
                grpTahrirCosts.Enabled = false;
                txtDesc.Enabled = false;
                cmbJobs.Enabled = false;
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CheckData())
                if (ApplyData())
                    ContractForms.NextForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ContractForms.BackForm();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (UnitBuild == null)
            {
                ClassLibrary.JMessages.Error("لطفا ابتدا اعیان را انتخاب کنید", "Error");
                return;
            }

            decimal _Rent = JMarketGoodwill.CalcRent(UnitBuild.MarketCode, UnitBuild.InitialRental, txtStartDate.Date);
            if (JContractPropertiesForm.CheckPrperties(this.GetType().FullName, PropertiesForm.Rand_to_rent.ToString(), ContractForms.Contract.ContractType.Code))
            {
                _Rent = Math.Round(_Rent) - Math.Round(_Rent) / 1000;
            }
            else
            {
            }
            txtBaseRent.Text = _Rent.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }

        private void Fill_Data()
        {
            //if (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["JobHasNoChange"])))
            //{
            //    JUnitJobs tempJobs = new JUnitJobs();
            //    tempJobs.SetComboBox(cmbJobs, (new JUnitBuild((new Finance.JAsset(ContractForms.Contract.FinanceCode)).ObjectCode)).UnitJob);
            //    cmbJobs.Enabled = false;
            //}
            JSubBaseDefine nullDeff = new JSubBaseDefine(0);
            nullDeff.Code = -1;
            nullDeff.Name = "-----------";
            //if (!Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["JobHasNoChange"])))
            //{
                JUnitJobs UnitJobs = new JUnitJobs();
                UnitJobs.SetComboBox(cmbJobs, ContractForms.Contract.Job);
            //}
            Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
            UnitBuild = new JUnitBuild(asset.ObjectCode);
            jMarket tempMarket = new RealEstate.jMarket(UnitBuild.MarketCode);

            rbSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
            rbBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();

            rbTahrirSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
            rbTahrirBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();

            /// در صورتی که تاریخ قرارداد تغییر کرده
            if (tmpDate != ContractForms.Contract.Date && this.State == JStateContractForm.Insert)
            {
                txtStartDate.Date = JMarketGoodwill.CalcRentDate(UnitBuild.MarketCode, ContractForms.Contract.Date);
                tmpDate = ContractForms.Contract.Date;
            }
            SetForm();
        }

        DateTime tmpDate =DateTime.MinValue;
        private void JGoodwillForm_VisibleChanged(object sender, EventArgs e)
        {
            try
            {                
                //if (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["JobHasNoChange"])))
                //{
                //    JUnitJobs tempJobs = new JUnitJobs();
                //    tempJobs.SetComboBox(cmbJobs, (new JUnitBuild((new Finance.JAsset(ContractForms.Contract.FinanceCode)).ObjectCode)).UnitJob);
                //    cmbJobs.Enabled = false;
                //}
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";
                //if (!Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["JobHasNoChange"])))
                //{
                    JUnitJobs UnitJobs = new JUnitJobs();
                    UnitJobs.SetComboBox(cmbJobs, ContractForms.Contract.Job);
                //}
                Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
                UnitBuild = new JUnitBuild(asset.ObjectCode);
                jMarket tempMarket = new RealEstate.jMarket(UnitBuild.MarketCode);

                rbSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
                rbBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();

                rbTahrirSeller.Text = ContractForms.Settings.Items["T1Lable"].ToString();
                rbTahrirBuyer.Text = ContractForms.Settings.Items["T2Lable"].ToString();

                /// در صورتی که تاریخ قرارداد تغییر کرده
                if (tmpDate != ContractForms.Contract.Date && this.State == JStateContractForm.Insert)
                {
                    txtStartDate.Date = JMarketGoodwill.CalcRentDate(UnitBuild.MarketCode, ContractForms.Contract.Date);
                    tmpDate = ContractForms.Contract.Date;
                }
                if (ContractForms.Contract.Code > 0)
                {
                    SetForm();
                }

                DataTable dt = RealEstate.JAnnualRental.GetDataTable(UnitBuild.Code,txtStartDate.Date);
                if (dt.Rows.Count > 0)
                    txtBaseRent.Text = dt.Rows[0]["PriceAnnualRental"].ToString();
                else
                    txtBaseRent.Text = "";
            }
            catch
            {
            }
        }

        private void JGoodwillForm_Shown(object sender, EventArgs e)
        {
        }

        public JKeyValue[] GetPropertiesList()
        {
            return JMainFrame.EnumToListBox(typeof(PropertiesForm));
        }

        private void JGoodwillForm_Load(object sender, EventArgs e)
        {
            Finance.JAsset tmp = new Finance.JAsset(ContractForms.Contract.FinanceCode);
            if (tmp.ClassName == "RealEstate.JUnitBuild")
            {
                JUnitBuild tmpUnit = new JUnitBuild(tmp.ObjectCode);
                cmbJobs.SelectedValue = tmpUnit.UnitJob;
            }
        }
    }
}
