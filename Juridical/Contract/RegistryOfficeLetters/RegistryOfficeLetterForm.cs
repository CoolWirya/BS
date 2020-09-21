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
using RealEstate;

namespace Legal
{
    public partial class JRegistryOfficeLetterForm : JBaseForm
    {
        JRegistryOfficeLetter officeLetter;
        JSubjectContract contract;
        JAsset asset;
        int _Code;
        int _UnitBuildCode, _ContractCode;

        public JRegistryOfficeLetterForm(int pCode, int pContractCode)
        {
            InitializeComponent();
            _Code = pCode;
            if (pCode == 0)
            {
                officeLetter = new JRegistryOfficeLetter();
                State = JFormState.Insert;
            }
            else
            {
                officeLetter = new JRegistryOfficeLetter(pCode);
                State = JFormState.Update;
                SetForm();
            }
            contract = new JSubjectContract(pContractCode);
            _ContractCode = pContractCode;
            SetContract();
            asset = new JAsset(contract.FinanceCode);
            if (asset.ClassName == "RealEstate.JUnitBuild")
                SetUnitBuild(asset.ObjectCode);
            _UnitBuildCode = asset.ObjectCode;

            ArchiveList.ClassName = "Legal.JRegistryOfficeLetterForm";
            ArchiveList.ObjectCode = pCode;
            ArchiveList.PlaceCode = 0;
            ArchiveList.SubjectCode = 0;
        }

        private void SetForm()
        {
            txtLetterDate.Date = officeLetter.Date;
            txtLetterNo.Text = officeLetter.Number;
            txtRepDate.Date = officeLetter.RepDate;
            txtRepNo.Text = officeLetter.RepNumber;
            txtPrice.Text = officeLetter.Price.ToString();
            btnSave.Enabled = false;
        }
        private void SetUnitBuild(int pUnitCode)
        {
            JUnitBuild UnitBuild = new JUnitBuild(pUnitCode);
            grpUnit.Visible = true;
            lblMarket.Text = UnitBuild.MarketName;
            lblBalcon.Text = UnitBuild.Balcon.ToString();
            lblFloor.Text = UnitBuild.FloorCode.ToString();
            lblInfra.Text = UnitBuild.Area.ToString();
            lblNumPlaquc.Text = UnitBuild.Plaque;
            lblRegPlaque.Text = UnitBuild.PlaqueRegistration;
            lblUnitNumber.Text = UnitBuild.Number;
            lblRent.Text = UnitBuild.InitialRental.ToString();
        }

        private void SetContract()
        {
            lbContractDate.Text = JDateTime.FarsiDate(contract.Date);
            lbContractNo.Text = contract.Number;
            int years = 0;
            if (contract.StartDate != DateTime.MinValue && contract.EndDate != DateTime.MinValue)
            {
                TimeSpan TS = contract.StartDate - contract.EndDate;
                years = TS.Days / 365;
            }
            lbDuration.Text = years.ToString();
            lbGoodwillPrice.Text = JMoney.StringToMoney(contract.GoodwillPrice.ToString());
            lbJob.Text = (new JSubBaseDefine(ClassLibrary.JBaseDefine.UnitJobs, contract.Job)).Name;
            //lbTotalPrice.Text = JMoney.StringToMoney(contract.TotalPrice.ToString());
            //lbTotalPrice.Text = JMoney.StringToMoney(contract.GetLastGoodwillContract().TotalPrice.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Check Controls
            if (txtLetterNo.Text.Trim() == "")
            {
                JMessages.Error("لطفا شماره نامه را وارد کنید", "خطا");
                txtLetterNo.Focus();
                return;
            }
            if (txtLetterDate.Date==DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ نامه را وارد کنید", "خطا");
                txtLetterDate.Focus();
                return;
            }
            #endregion Check Controls
            if (State == JFormState.Insert)
            {
                officeLetter.ContractCode = contract.Code;
                officeLetter.Date = txtLetterDate.Date;
                officeLetter.Number = txtLetterNo.Text;
                officeLetter.RepDate = txtRepDate.Date;
                officeLetter.RepNumber = txtRepNo.Text;
                officeLetter.Price = Convert.ToDecimal(txtPrice.Text);
                _Code = officeLetter.Insert();
                if (_Code > 0)
                {
                    ArchiveList.ObjectCode = _Code;
                    ArchiveList.ArchiveList();
                    State = JFormState.Update;
                    btnSave.Enabled = false;
                }


            }
            if (State == JFormState.Update)
            {
                officeLetter.ContractCode = contract.Code;
                officeLetter.Date = txtLetterDate.Date;
                officeLetter.Number = txtLetterNo.Text;
                officeLetter.RepDate = txtRepDate.Date;
                officeLetter.RepNumber = txtRepNo.Text;
                officeLetter.Price = Convert.ToDecimal(txtPrice.Text);
                if (officeLetter.Update())
                {
                    ArchiveList.ArchiveList();
                    btnSave.Enabled = false;
                }
            }
        }

        private void txtLetterNo_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void LoadPersond()
        {
            jdgvSeller.DataSource = JRegistryOfficeLetters.GetAllDataByPrint(contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Seller);
            jdgvBuyer.DataSource = JRegistryOfficeLetters.GetAllDataByPrint(contract.Code, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
        }
        private void JRegistryOfficeLetterForm_Load(object sender, EventArgs e)
        {
            LoadPersond();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Code > 0)
                {
                    DataTable[] SubReports = new DataTable[4];

                    SubReports[0] = JUnitBuilds.GetDataTable(_UnitBuildCode);
                    SubReports[0].TableName = "اطلاعات اعیان";

                    SubReports[1] = JSubjectContracts.GetDataTable(contract.Code, 0);
                    SubReports[1].TableName = " اطلاعات قرارداد";

                    SubReports[2] = JRegistryOfficeLetters.GetListByCode(_Code);
                    SubReports[2].TableName = " اطلاعات نامه محضر";

                    string SellerFullName = "";
                    string SellerName = "";
                    string BuyerFullName = "";
                    string BuyerName = "";
                    foreach (DataRow dr in ((DataTable)(jdgvSeller.DataSource)).Rows)
                    {
                        SellerFullName = SellerFullName + " و " + dr["PersonTitle"].ToString() + dr["FullName"].ToString();
                        SellerName = SellerName + " و " + dr["PersonTitle"].ToString() + dr["Name"].ToString();
                    }
                    foreach (DataRow dr in ((DataTable)(jdgvBuyer.DataSource)).Rows)
                    {
                        BuyerFullName = BuyerFullName + " و " + dr["PersonTitle"].ToString() + dr["FullName"].ToString();
                        BuyerName = BuyerName + " و " + dr["PersonTitle"].ToString() + dr["Name"].ToString();
                    }
                    DataTable dt = new DataTable();
                    dt.Columns.Add("SellerFullName");
                    dt.Columns.Add("BuyerFullName");
                    dt.Columns.Add("SellerName");
                    dt.Columns.Add("BuyerName");
                    DataRow drN = dt.NewRow();
                    SellerFullName = SellerFullName.Remove(1, 1);
                    SellerName = SellerName.Remove(1, 1);
                    BuyerFullName = BuyerFullName.Remove(1, 1);
                    BuyerName = BuyerName.Remove(1, 1);
                    drN["SellerFullName"] = SellerFullName;
                    drN["BuyerFullName"] = BuyerFullName;
                    drN["SellerName"] = SellerName;
                    drN["BuyerName"] = BuyerName;
                    dt.Rows.Add(drN);

                    SubReports[3] = dt;
                    SubReports[3].TableName = " نام کامل اشخاص";

                    JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.OfficeLetter.GetHashCode());
                    DRF.AddRange(SubReports);
                    DRF.ShowDialog();
                }
                else
                    JMessages.Information(" ابتدا درخواست خود را ذخیره کنید", "");
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
                //return null;
            }
        }

    }
}
