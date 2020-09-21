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
    public partial class JTransferConfirmForm : JBaseForm
    {
        int _Code;
        int _UnitBuildCode;
        int _AssetCode;
        string _ClassName;
        
        public JTransferConfirmForm(int pAssetCode)
        {
            InitializeComponent();
            _AssetCode = pAssetCode;
            JArchive.ClassName = "RealEstate.JTransferUnitBuild";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
        }

        public JTransferConfirmForm(int pCode, int pAssetCode)
        {
            InitializeComponent();
            _Code = pCode;
            _AssetCode = pAssetCode;
            Set_Form();
            JArchive.ClassName = "RealEstate.JTransferUnitBuild";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = _Code;
        }

        private void SetUnitBuild()
        {
            if (_ClassName == "RealEstate.JUnitBuild")
            {
                JUnitBuild UnitBuild = new JUnitBuild(_UnitBuildCode);
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
                groupBox1.Visible = true;
                grGround.Visible = false;
            }
            if (_ClassName == "Estates.JGround")
            {
                JGround _newGround = new JGround(_UnitBuildCode);
                txtMainAve.Text = _newGround.MainAve;
                txtSubAve.Text = _newGround.SubNo;
                txtBlockNum.Text = _newGround.BlockNum;
                txtPartNum.Text = _newGround.PartNum;
                txtArea.Text = _newGround.Area.ToString();
                JUsageGround tmpUsage = new JUsageGround(_newGround.Usage);
                txtUsage.Text = tmpUsage.Name.ToString();
                groupBox1.Visible = true;
                grGround.Visible = true;
            }
            //JUnitBuild UnitBuild = new JUnitBuild(_UnitBuildCode);
            //lblMarket.Text = UnitBuild.MarketName;
            //lblBalcon.Text = UnitBuild.Balcon.ToString();
            //lblFloor.Text = UnitBuild.FloorCode.ToString();
            //lblInfra.Text = UnitBuild.Area.ToString();
            //lblInfraAbout.Text = UnitBuild.InitialArea.ToString();
            //lblDate.Text = JDateTime.FarsiDate(Convert.ToDateTime(UnitBuild.DeliveryDate.Date));
            //lblNumPlaquc.Text = UnitBuild.Plaque;
            //lblRegPlaque.Text = UnitBuild.PlaqueRegistration;
            //lblUnitNumber.Text = UnitBuild.Number;
            //lblRent.Text = UnitBuild.InitialRental.ToString();
        }

        private void Set_Form()
        {
            JTransferUnitBuild tmpJTransferUnitBuild = new JTransferUnitBuild(_Code);
            txtNumber.Text = tmpJTransferUnitBuild.ConfirmNumber;
            txtDate.Date = tmpJTransferUnitBuild.ConfirmDate;
            txtPrice.Text = tmpJTransferUnitBuild.Price;
            if (tmpJTransferUnitBuild.Amlak)
                chkAmlak.Checked = true;
            else
                chkAmlak.Checked = false;
            if (tmpJTransferUnitBuild.Mali)
                chkMali.Checked = true;
            else
                chkMali.Checked = false;
            if (tmpJTransferUnitBuild.Modir)
                chkModir.Checked = true;
            else
                chkModir.Checked = false;
            if (tmpJTransferUnitBuild.Seller)
                chkSeller.Checked = true;
            else
                chkSeller.Checked = false;
            //if (tmpJTransferUnitBuild.Confirm)
            //    chkConfirm.Checked = true;
            //else
            //    chkConfirm.Checked = false;
            btnSave.Enabled = false;

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
            if (btnSave.Enabled == true)
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
                //#region CheckControl
                //if (txtDate.Date == DateTime.MinValue)
                //{
                //    JMessages.Error("تاریخ را وارد است", "error");
                //    return false;
                //}                
                //if (txtNumber.Text == "-")
                //{
                //    JMessages.Error("شماره را وارد کنید", "error");
                //    return false;
                //}
                //#endregion

                JTransferUnitBuild tmpJTransferUnitBuild = new JTransferUnitBuild(_Code);
                tmpJTransferUnitBuild.ConfirmNumber = txtNumber.Text;
                tmpJTransferUnitBuild.ConfirmDate = txtDate.Date;
                tmpJTransferUnitBuild.Price = txtPrice.Text;
                if (chkAmlak.Checked)
                    tmpJTransferUnitBuild.Amlak = true;
                else
                    tmpJTransferUnitBuild.Amlak = false;
                if (chkMali.Checked)
                    tmpJTransferUnitBuild.Mali = true;
                else
                    tmpJTransferUnitBuild.Mali = false;
                if (chkModir.Checked)
                    tmpJTransferUnitBuild.Modir = true;
                else
                    tmpJTransferUnitBuild.Modir = false;
                if (chkSeller.Checked)
                    tmpJTransferUnitBuild.Seller = true;
                else
                    tmpJTransferUnitBuild.Seller = false;


                JArchive.ClassName = "RealEstate.JTransferUnitBuild";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------                                   
                if (tmpJTransferUnitBuild.UpdateConfirm())
                {
                    JArchive.ObjectCode = _Code;
                    JArchive.ArchiveList();
                    JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    return true;
                }
                else
                    JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void JTransferConfirmForm_Load(object sender, EventArgs e)
        {
            Finance.JAsset tmp = new Finance.JAsset(_AssetCode);
            _UnitBuildCode = tmp.ObjectCode;
            _ClassName = tmp.ClassName;
            SetUnitBuild();
            if (this.State == JFormState.Update)
                Set_Form();
            else
                txtDate.Date = JDateTime.Now();
            jdgvSeller.DataSource = JTranferPerson.GetAllDataType(_Code, TransferPersonType.Seller);
            jdgvBuyer.DataSource = JTranferPerson.GetAllDataType(_Code, TransferPersonType.Buyer);
            jdgvSeller.Columns["PersonCode"].Visible = false;
            jdgvBuyer.Columns["PersonCode"].Visible = false;
            jdgvSeller.Columns["PersonType"].Visible = false;
            jdgvBuyer.Columns["PersonType"].Visible = false;
            jdgvBuyer.Columns["OldShare"].Visible = false;
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_Code > 0)
            {
                JTransferUnitBuild tmp = new JTransferUnitBuild();
                DataTable[] DataTables = new DataTable[5];

                DataTables[0] = tmp.GetUnitBuild(_Code, 0);
                DataTables[0].TableName = "تایید انتقال";

                DataTable tmpdtSeller = JTranferPerson.GetAllDataByPrint(_Code, TransferPersonType.Seller);
                DataTables[1] = tmpdtSeller.Select(" NewShare > 0 ").CopyToDataTable();
                DataTables[1].TableName = " اشخاص فروشنده";

                DataTables[2] = JTranferPerson.GetAllDataByPrint(_Code, TransferPersonType.Buyer);
                DataTables[2].TableName = " اشخاص خریدار";
                
                DataTables[3] = tmp.GetContract(_Code, _AssetCode);
                DataTables[3].TableName = " اطلاعات قرارداد";

                string SellerFullName = "";
                string SellerName = "";
                string BuyerFullName = "";
                string BuyerName = "";
                decimal  Total = 0;
                foreach (DataRow dr in tmpdtSeller.Select(" NewShare > 0 ").CopyToDataTable().Rows)
                {
                    SellerFullName = SellerFullName + " و " + dr["PersonTitle"].ToString() + dr["FullName"].ToString();
                    SellerName = SellerName + " و " + dr["PersonTitle"].ToString() + dr["Name"].ToString() + " مالک " + dr["OldShare"].ToString() + " دانگ ";
                    Total = Total + Convert.ToDecimal(dr["NewShare"]);
                }
                foreach (DataRow dr in JTranferPerson.GetAllDataByPrint(_Code, TransferPersonType.Buyer).Rows)
                {
                    BuyerFullName = BuyerFullName + " و " + dr["PersonTitle"].ToString() + dr["FullName"].ToString();
                    BuyerName = BuyerName + " و " + dr["PersonTitle"].ToString() + dr["Name"].ToString();
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("SellerFullName");
                dt.Columns.Add("BuyerFullName");
                dt.Columns.Add("SellerName");
                dt.Columns.Add("BuyerName");
                dt.Columns.Add("TotalNewShareSeller");
                DataRow drN = dt.NewRow();
                SellerFullName = SellerFullName.Remove(1, 1);
                SellerName = SellerName.Remove(1, 1);
                BuyerFullName = BuyerFullName.Remove(1, 1);
                BuyerName = BuyerName.Remove(1, 1);
                drN["SellerFullName"] = SellerFullName;
                drN["BuyerFullName"] = BuyerFullName;
                drN["SellerName"] = SellerName;
                drN["BuyerName"] = BuyerName;
                drN["TotalNewShareSeller"] = Total.ToString();
                dt.Rows.Add(drN);

                DataTables[4] = dt;
                DataTables[4].TableName = " نام کامل اشخاص";

                JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.ConfirmTransfer.GetHashCode());
                DRF.AddRange(DataTables);
                DRF.ShowDialog();
            }
            else
                JMessages.Information(" ابتدا تایید درخواست خود را ذخیره کنید", "");
        }
    }
}
