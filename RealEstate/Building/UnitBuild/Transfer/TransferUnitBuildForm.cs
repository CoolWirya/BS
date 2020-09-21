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
    public partial class JTransferUnitBuildForm : JBaseForm
    {

        DataTable _dtSeller = new DataTable();
        DataTable _dtBuyer = new DataTable();
        int _Code;
        int _UnitBuildCode;
        int _AssetCode;
        public bool isConfirmed;
        string _ClassName;

        public JTransferUnitBuildForm(int pAssetCode)
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "RealEstate.JTransferUnitBuild";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            _AssetCode = pAssetCode;
        }

        public JTransferUnitBuildForm(int pCode, int pAssetCode)
        {
            InitializeComponent();
            _Code = pCode;
            _AssetCode = pAssetCode;

            /// مقداردهی پراپرتی های لیست آرشیو
            JArchive.ClassName = "RealEstate.JTransferUnitBuild";
            JArchive.SubjectCode = 0;
            JArchive.PlaceCode = 0;
            JArchive.ObjectCode = _Code;
        }

        private void SetUnitBuild()
        {
            try
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
                    grUnitBuild.Visible = true;
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
                    grUnitBuild.Visible = true;
                    grGround.Visible = true;
                }

                cmbRequestType.DisplayMember = "Title";
                cmbRequestType.ValueMember = "Code";
                cmbRequestType.DataSource = Legal.JContractDynamicTypes.GetDataTable();
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
                JTransferUnitBuild tmp = new JTransferUnitBuild(_Code);
                if (tmp.RequestType.ToString() != "")
                    cmbRequestType.SelectedValue = tmp.RequestType;
                txtNumber.Text = tmp.RequestNumber;
                txtDate.Date = tmp.RequestDate;
                txtDesc.Text = tmp.Description;
                _dtSeller = JTranferPerson.GetAllDataType(_Code, TransferPersonType.Seller);
                jdgvSeller.DataSource = _dtSeller;
                _dtBuyer = JTranferPerson.GetAllDataType(_Code, TransferPersonType.Buyer);
                jdgvBuyer.DataSource = _dtBuyer;
                btnSave.Enabled = false;
                jdgvSeller.Columns["PersonCode"].Visible = false;
                jdgvBuyer.Columns["PersonCode"].Visible = false;
                jdgvSeller.Columns["PersonType"].Visible = false;
                jdgvBuyer.Columns["PersonType"].Visible = false;
                jdgvBuyer.Columns["OldShare"].Visible = false;
                txtPrice.Text = tmp.PriceSell;
                _AssetCode = tmp.AssetCode;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void GetPattern()
        {
            try
            {
                _dtSeller = JTranferPerson.GetAllDataType(0, TransferPersonType.Seller);
                DataTable dt = new DataTable();
                //Finance.JAsset tmp = new Finance.JAsset("RealEstate.JUnitBuild",_UnitBuildCode);
                //_AssetCode = tmp.Code;
                //dt = Finance.JAssetTransfer.GetAssetShare(_UnitBuildCode, "RealEstate.JUnitBuild", Finance.JOwnershipType.Goodwill);
                if (_ClassName == "RealEstate.JUnitBuild")
                    dt = Finance.JAssetTransfer.GetAssetShare(_UnitBuildCode, _ClassName, Finance.JOwnershipType.Goodwill);
                else if (_ClassName == "Estates.JGround")
                    dt = Finance.JAssetTransfer.GetAssetShare(_UnitBuildCode, _ClassName, Finance.JOwnershipType.Definitive);
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow drNew = _dtSeller.NewRow();
                    drNew["PersonCode"] = dr["PCode"];
                    drNew["Name"] = dr["Name"];
                    drNew["OldShare"] = dr["Share"];
                    _dtSeller.Rows.Add(drNew);
                }
                jdgvSeller.DataSource = _dtSeller;
                _dtBuyer = JTranferPerson.GetAllDataType(0, TransferPersonType.Buyer);
                jdgvBuyer.DataSource = _dtBuyer;

                jdgvSeller.Columns["PersonCode"].Visible = false;
                jdgvBuyer.Columns["PersonCode"].Visible = false;
                jdgvSeller.Columns["PersonType"].Visible = false;
                jdgvBuyer.Columns["PersonType"].Visible = false;
                jdgvBuyer.Columns["OldShare"].Visible = false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void jdgvAddBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                //JPersonTypes pType = (JPersonTypes)(Convert.ToInt32(_ContractSettings.Items["T2PersonType"]));

                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();//_ContractSettings.T2PersonType
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if (((_dtBuyer.Rows.Count > 0) && (_dtBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtBuyer.Rows.Count == 0))
                    {
                        DataRow dr = _dtBuyer.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        if (p.SelectedPerson.PersonType == JPersonTypes.RealPerson)
                            dr["ClassNameEn"] = "Legal.JBuyerContract";
                        else
                            dr["ClassNameEn"] = "Legal.JBuyerContractLegal";
                        _dtBuyer.Rows.Add(dr);
                        jdgvBuyer.DataSource = _dtBuyer;
                        jdgvBuyer.Columns["Code"].ReadOnly = true;
                        jdgvBuyer.Columns["PersonCode"].ReadOnly = true;
                        jdgvBuyer.Columns["Name"].ReadOnly = true;
                    }
                    else
                        JMessages.Information("Person is Repeated", "Information");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDelBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvBuyer.CurrentRow != null)
                {
                    jdgvBuyer.Rows.Remove(jdgvBuyer.CurrentRow);
                    TotalShare();
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
                #region CheckControl
                if (isConfirmed)
                {
                    JMessages.Information("این درخواست تایید شده و امکان تغییر نمی باشد", "");
                    return false;
                }
                if (!TotalShare())
                {
                    JMessages.Information("جمع سهام با جمع سهام فروش درست نمیباشد .", "");
                    return false;
                }
                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error("تاریخ را وارد است", "error");
                    return false;
                }
                if (jdgvSeller.Rows.Count == 0)
                {
                    JMessages.Error("فروشنده وجود ندارد", "error");
                    return false;
                }
                if (jdgvBuyer.Rows.Count == 0)
                {
                    JMessages.Error("خریدار ها را وارد کنید", "error");
                    return false;
                }
                if (txtNumber.Text == "-")
                {
                    JMessages.Error("شماره را وارد کنید", "error");
                    return false;
                }
                if ((lblBuyer.Text == "0") || (lbl.Text == "0"))
                {
                    JMessages.Error("سهام را وارد کنید", "error");
                    return false;
                }
                #endregion

                JTransferUnitBuild tmpJTransferUnitBuild = new JTransferUnitBuild(_Code);
                tmpJTransferUnitBuild.RequestNumber = txtNumber.Text;
                tmpJTransferUnitBuild.RequestDate = txtDate.Date;
                tmpJTransferUnitBuild.Description = txtDesc.Text;
                tmpJTransferUnitBuild.PriceSell = txtPrice.Text;
                tmpJTransferUnitBuild.RequestType = Convert.ToInt32(cmbRequestType.SelectedValue);

                JArchive.ClassName = "RealEstate.JTransferUnitBuild";
                JArchive.SubjectCode = 0;
                JArchive.PlaceCode = 0;

                //---------ویرایش------------
                if (this.State != JFormState.Update)
                {
                    tmpJTransferUnitBuild.AssetCode = _AssetCode;
                    //----------Update Archive------------
                    _Code = tmpJTransferUnitBuild.Insert(_dtSeller, _dtBuyer);
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
                    tmpJTransferUnitBuild.Code = _Code;
                    JArchive.ObjectCode = _Code;
                    JArchive.ArchiveList();
                    if (tmpJTransferUnitBuild.Update(_dtSeller, _dtBuyer))
                    {
                        JMessages.Message("Update Successfuly ", "", JMessageType.Information);
                        return true;
                    }
                    else
                        JMessages.Message("Update Not Successfuly", "", JMessageType.Error);
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void JTransferUnitBuildForm_Load(object sender, EventArgs e)
        {
            try
            {
                Finance.JAsset tmpAsset = new Finance.JAsset(_AssetCode);
                _ClassName = tmpAsset.ClassName;
                _UnitBuildCode = tmpAsset.ObjectCode;
                SetUnitBuild();
                if (this.State == JFormState.Update)
                    Set_Form();
                else
                {
                    txtDate.Date = JDateTime.Now();
                    GetPattern();
                }

                if (State == JFormState.ReadOnly)
                {
                    Set_Form();
                    btnSave.Enabled = false;
                    btnSaveClose.Enabled = false;
                    btnPrint.Enabled = false;
                    btnAddBuyer.Enabled = false;
                    btnDelBuyer.Enabled = false;
                    JArchive.EnabledChange = false;

                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnAddBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm();//_ContractSettings.T2PersonType
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if (((_dtBuyer.Rows.Count > 0) && (_dtBuyer.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtBuyer.Rows.Count == 0))
                    {
                        DataRow dr = _dtBuyer.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        _dtBuyer.Rows.Add(dr);
                        jdgvBuyer.DataSource = _dtBuyer;
                        jdgvBuyer.Columns["Code"].ReadOnly = true;
                        jdgvBuyer.Columns["PersonCode"].ReadOnly = true;
                        jdgvBuyer.Columns["Name"].ReadOnly = true;
                    }
                    else
                        JMessages.Information("Person is Repeated", "Information");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private bool TotalShare()
        {
            float ValuePerson = 0;
            float Value = 0;
            float ValueBuyer = 0;
            foreach (DataRow dr in _dtSeller.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    if ((dr["NewShare"].ToString() != "") && ((float)Convert.ToDecimal(dr["OldShare"]) < (float)Convert.ToDecimal(dr["NewShare"])))
                        return false;
                    if (dr["OldShare"].ToString() != "")
                        ValuePerson = ValuePerson + (float)Convert.ToDecimal(dr["OldShare"]);
                    if (dr["NewShare"].ToString() != "")
                        Value = Value + (float)Convert.ToDecimal(dr["NewShare"]);
                }
            }
            if (ValuePerson < Value)
            {
                return false;
            }

            lblSeller.Text = ValuePerson.ToString();
            lbl.Text = Value.ToString();

            foreach (DataRow dr in _dtBuyer.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (dr["NewShare"].ToString() != "")
                        ValueBuyer = ValueBuyer + (float)Convert.ToDecimal(dr["NewShare"]);
                }
            }
            if (Value < ValueBuyer)
                return false;
            lblBuyer.Text = ValueBuyer.ToString();
            return true;
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void jdgvSeller_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!TotalShare())
                //if (State != JStateContractForm.View)
                //if (Convert.ToInt32(lblSeller.Text) < Convert.ToInt32(lbl.Text))
                JMessages.Information("جمع سهام با جمع سهام فروش درست نمیباشد .", "");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Code > 0)
                {
                    JTransferUnitBuild tmp = new JTransferUnitBuild();
                    DataTable[] SubReports = new DataTable[6];

                    SubReports[0] = tmp.GetUnitBuild(_Code, 0);
                    SubReports[0].TableName = "انتقال";

                    DataTable tmpdtSeller = JTranferPerson.GetAllDataByPrint(_Code, TransferPersonType.Seller);
                    SubReports[1] = tmpdtSeller.Select(" NewShare > 0 ").CopyToDataTable();
                    SubReports[1].TableName = " اشخاص فروشنده";

                    SubReports[2] = JTranferPerson.GetAllDataByPrint(_Code, TransferPersonType.Buyer);
                    SubReports[2].TableName = " اشخاص خریدار";

                    SubReports[3] = tmp.GetContract(_Code, _AssetCode);
                    SubReports[3].TableName = " اطلاعات قرارداد";

                    string SellerFullName = "";
                    string SellerName = "";
                    string BuyerFullName = "";
                    string BuyerName = "";
                    string OldShare = "";
                    decimal total = 0;
                    foreach (DataRow dr in tmpdtSeller.Select(" NewShare > 0 ").CopyToDataTable().Rows)
                    {
                        SellerFullName = SellerFullName + " و " + dr["PersonTitle"].ToString() + dr["FullName"].ToString() + " مالک " + dr["OldShare"].ToString() + " دانگ ";
                        SellerName = SellerName + " و " + dr["PersonTitle"].ToString() + dr["Name"].ToString() + " مالک " + dr["OldShare"].ToString() + " دانگ ";
                        total = total + Convert.ToDecimal(dr["NewShare"]);
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
                    dt.Columns.Add("total");
                    dt.Columns.Add("DateNow");
                    DataRow drN = dt.NewRow();
                    SellerFullName = SellerFullName.Remove(1, 1);
                    SellerName = SellerName.Remove(1, 1);
                    BuyerFullName = BuyerFullName.Remove(1, 1);
                    BuyerName = BuyerName.Remove(1, 1);
                    drN["SellerFullName"] = SellerFullName;
                    drN["BuyerFullName"] = BuyerFullName;
                    drN["SellerName"] = SellerName;
                    drN["BuyerName"] = BuyerName;
                    drN["total"] = total;
                    drN["DateNow"] = JDateTime.FarsiDate(DateTime.Now);
                    dt.Rows.Add(drN);

                    SubReports[4] = dt;
                    SubReports[4].TableName = " نام کامل اشخاص";

                    SubReports[5] = JGrounds.GetDataTable(_UnitBuildCode);
                    SubReports[5].TableName = "اطلاعات زمین";


                    JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.Transfer.GetHashCode());
                    if (_ClassName == "Estates.JGround")
                    {

                        //for (int j = 1; j < 5; j++)
                        int j = 5;
                            for (int i = 1; i < SubReports[5].Columns.Count; i++)
                            {
                                if ((SubReports[5].Rows.Count > 0))
                                {
                                    dt.Columns.Add(SubReports[j].Columns[i].Caption);
                                    dt.Rows[0][SubReports[j].Columns[i].Caption] = SubReports[j].Rows[0][SubReports[j].Columns[i].Caption];
                                }
                            }
                        DRF.Add(dt);
                    }
                    else
                        DRF.AddRange(SubReports);
                    DRF.ShowDialog();
                }
                else
                    JMessages.Information(" ابتدا درخواست خود را ذخیره کنید", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }
}