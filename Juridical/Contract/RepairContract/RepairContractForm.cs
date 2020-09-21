using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Globals;
using ClassLibrary;

namespace Legal
{
    public partial class JRepairContractForm : Globals.JBaseForm
    {

        private JRepairContract RepContract;
        private JContractTypeSettings _ContractSettings;

        public JRepairContractForm(JRepairContract pRepair)
        {
            InitializeComponent();
            RepContract = pRepair;
            SetForm();

        }

        public JRepairContractForm( int pContractCode)
        {
            InitializeComponent();
            RepContract = new JRepairContract(pContractCode);
            SetForm();
            //checkedListBox1.Items.AddRange(RepContract.Contract.GetNotEdited());
        }
        bool RentContract;
        private void SetForm()
        {
            jdgvSeller.DataSource = RepContract.SellerPersonsContract;
            jdgvBuyer.DataSource = RepContract.BuyerPersonsContract;
            foreach (DataRow row in RepContract.SellerPersonsContract.Rows)
            {
                try
                {
                    if (row.RowState != DataRowState.Deleted)
                        row["PersonShare"] = row["Share"];
                }
                catch (Exception ex)
                {
                }
            } 
            inVisibleColumns();

            _ContractSettings = new JContractTypeSettings();
            _ContractSettings.LoadAll((int)RepContract.Contract.ContractType.Code);
            JContractdefine contractType = new JContractdefine(RepContract.Contract.Type);
            JContractDynamicType dynamicType = new JContractDynamicType(contractType.ContractType);

            cmbDynamicType.DisplayMember = "Title";
            cmbDynamicType.ValueMember = "Code";
            cmbDynamicType.DataSource = JContractDynamicTypes.GetDataTable();
            cmbDynamicType.SelectedValue = contractType.ContractType;

            cmbContractType.DisplayMember = "Title";
            cmbContractType.ValueMember = "Code";
            cmbContractType.DataSource = JContractdefines.GetDataTable(0, contractType.ContractType, null);
            cmbContractType.SelectedValue = contractType.Code;

            if (dynamicType.AssetTransferType == Finance.JOwnershipType.Rentals.GetHashCode())
            {
                tabSellers.Text = "موجرین";
                tabBuyers.Text = "مستاجرین";
                tabControl.TabPages.Remove(TabContracts);
                jdgvSeller.Columns["Share"].Visible = false;
                jdgvSeller.Columns["PersonShare"].Visible = false;
                jdgvBuyer.Columns["Share"].Visible = false;
                RentContract = true;
            }
            RealEstate.JUnitJobs UnitJobs = new RealEstate.JUnitJobs();
            UnitJobs.SetComboBox(cmbJob, RepContract.Contract.Job);

            txtDate.Date = RepContract.Contract.Date;
            txtEndDate.Date = RepContract.Contract.EndDate;
            txtNo.Text = RepContract.Contract.Number;
            txtPrice.Text = RepContract.Contract.Price.ToString();
            txtRent.Text = RepContract.Contract.PriceMonth.ToString();
            txtStartDate.Date = RepContract.Contract.StartDate;
            txtTotalPrice.Text = RepContract.Contract.TotalPrice.ToString();
            cmbContractType.SelectedValue = RepContract.Contract.Type;

            if (RepContract.PreContract > 0)
            {
                btnAddSeller.Enabled = false;
//                btnDelSellers.Enabled = false;
            }
        }


        private void inVisibleColumns()
        {

            inVisibleColumn(jdgvSeller, "ClassNameEn", false);
            inVisibleColumn(jdgvSeller, "ContractSubjectCode", false);
            inVisibleColumn(jdgvSeller, "fASCode", false);
            inVisibleColumn(jdgvSeller, "Code", false);
            inVisibleColumn(jdgvSeller, "OldAssetShare", false);
            inVisibleColumn(jdgvSeller, "NewAssetShare", false);
            jdgvSeller.Columns["Share"].HeaderText = "میزان سهم قابل فروش";
            inVisibleColumn(jdgvBuyer, "ClassNameEn", false);
            inVisibleColumn(jdgvBuyer, "ContractSubjectCode", false);
            inVisibleColumn(jdgvBuyer, "fASCode", false);
            inVisibleColumn(jdgvBuyer, "Code", false);

            inVisibleColumn(jdgvBuyer, "OldAssetShare", false);
            inVisibleColumn(jdgvBuyer, "NewAssetShare", false);

        }

        private void inVisibleColumn(ClassLibrary.JDataGrid pGrid, string pName, bool pVisible)
        {
            try
            {
                pGrid.Columns[pName].Visible = pVisible;
            }
            catch
            {
            }
        }


        private void btnAddBuyer_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JPersonTypes pType = (ClassLibrary.JPersonTypes)(Convert.ToInt32(_ContractSettings.Items["T2PersonType"]));

                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(pType);//_ContractSettings.T2PersonType
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if (((RepContract.BuyerPersonsContract.Rows.Count > 0) && (RepContract.BuyerPersonsContract.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (RepContract.BuyerPersonsContract.Rows.Count == 0))
                    {

                        DataRow dr = RepContract.BuyerPersonsContract.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        if (p.SelectedPerson.PersonType == ClassLibrary.JPersonTypes.RealPerson)
                            dr["ClassNameEn"] = "Legal.JBuyerContract";
                        else
                            dr["ClassNameEn"] = "Legal.JBuyerContractLegal";
                        RepContract.BuyerPersonsContract.Rows.Add(dr);
                        jdgvBuyer.DataSource = RepContract.BuyerPersonsContract;
                        jdgvBuyer.Columns["Code"].ReadOnly = true;
                        jdgvBuyer.Columns["PersonCode"].ReadOnly = true;
                        jdgvBuyer.Columns["Name"].ReadOnly = true;
                    }
                    else
                        ClassLibrary.JMessages.Information("Person is Repeated", "Information");
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
        }

        private bool TotalShare()
        {

            float ValuePerson = 0;
            float Value = 0;
            float ValueBuyer = 0;
            if (Convert.ToBoolean(int.Parse(_ContractSettings.Items["T1HasValue"].ToString())))
            {
                foreach (DataRow dr in RepContract.BuyerPersonsContract.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if ((float)Convert.ToDecimal(dr["PersonShare"]) < (float)Convert.ToDecimal(dr["Share"]))
                            return false;
                        ValuePerson = ValuePerson + (float)Convert.ToDecimal(dr["PersonShare"]);
                        Value = Value + (float)Convert.ToDecimal(dr["Share"]);
                    }
                }
                if (ValuePerson < Value)
                {
                    return false;
                }

                lblSeller.Text = ValuePerson.ToString();
                lbl.Text = Value.ToString();
            }
            if (Convert.ToBoolean(int.Parse(_ContractSettings.Items["T2HasValue"].ToString())))
            {
                foreach (DataRow dr in RepContract.BuyerPersonsContract.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        if (dr["Share"].ToString() != "")
                            ValueBuyer = ValueBuyer + (float)Convert.ToDecimal(dr["Share"]);
                    }
                }
                if (Convert.ToBoolean(int.Parse(_ContractSettings.Items["T1HasValue"].ToString())))
                    if (Value < ValueBuyer)
                        return false;

                lblBuyer.Text = ValueBuyer.ToString();
            }
            return true;
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
                ClassLibrary.JSystem.Except.AddException(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvSeller.CurrentRow != null)
                {
                    jdgvSeller.Rows.Remove(jdgvSeller.CurrentRow);
                    TotalShare();
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JPersonTypes pType = (ClassLibrary.JPersonTypes)(Convert.ToInt32(_ContractSettings.Items["T1PersonType"]));

                ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(pType);//_ContractSettings.T2PersonType
                p.ShowDialog();
                if (p.SelectedPerson != null)
                {
                    if (((RepContract.SellerPersonsContract.Rows.Count > 0) && (RepContract.SellerPersonsContract.Select("PersonCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (RepContract.SellerPersonsContract.Rows.Count == 0))
                    {

                        DataRow dr = RepContract.SellerPersonsContract.NewRow();
                        dr["PersonCode"] = p.SelectedPerson.Code;
                        dr["Name"] = p.SelectedPerson.Name;
                        if (p.SelectedPerson.PersonType == ClassLibrary.JPersonTypes.RealPerson)
                            dr["ClassNameEn"] = "Legal.JSellerContract";
                        else
                            dr["ClassNameEn"] = "Legal.JSellerContractLegal";
                        RepContract.SellerPersonsContract.Rows.Add(dr);
                        jdgvSeller.DataSource = RepContract.SellerPersonsContract;
                        jdgvSeller.Columns["Code"].ReadOnly = true;
                        jdgvSeller.Columns["PersonCode"].ReadOnly = true;
                        jdgvSeller.Columns["Name"].ReadOnly = true;
                    }
                    else
                        ClassLibrary.JMessages.Information("Person is Repeated", "Information");
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region CheckData
            try
            {
                if (!RentContract && (jdgvBuyer.CurrentRow.Cells["Share"].Value.ToString() == ""
                    || jdgvSeller.CurrentRow.Cells["Share"].Value.ToString() == ""
                    || jdgvSeller.CurrentRow.Cells["PersonShare"].Value.ToString() == ""))
                {
                    JMessages.Error("لطفا میزان همه سهم ها را وارد کنید", "خطا");
                    return;
                }
            }
            catch { }

            if (!RentContract && (Convert.ToDecimal(((DataTable)jdgvSeller.DataSource).Compute("SUM(Share)", "")) > 6
                || Convert.ToDecimal(((DataTable)jdgvSeller.DataSource).Compute("SUM(PersonShare)", "")) > 6
                || Convert.ToDecimal(((DataTable)jdgvBuyer.DataSource).Compute("SUM(Share)", "")) > 6))
            {
                ClassLibrary.JMessages.Error("لطفا میزان سهم ها را بصورت صحیح وارد کنید", "");
                return;
            }
            if (!RentContract && grdNextContracts.Rows.Count>0 && tabControl.SelectedTab != TabContracts)
            {
                ClassLibrary.JMessages.Error("لطفا قرارداد بعدی را انتخاب کنید", "");
                return;
            }

            //if (RepContract.Contract.ContractType.AssetTransferType != Finance.JOwnershipType.Goodwill.GetHashCode())
            //{
            //    ClassLibrary.JMessages.Error("فقط قراردادهای سرقفلی قابل اصلاح هستند", "");
            //    return;
            //}
            
            #endregion CheckData

            RepContract.Contract.Date = txtDate.Date;
            RepContract.Contract.EndDate = txtEndDate.Date;
            RepContract.Contract.Number = txtNo.Text;
            RepContract.Contract.Price = txtPrice.DecimalValue;
            RepContract.Contract.PriceMonth = txtRent.DecimalValue;
            RepContract.Contract.StartDate = txtStartDate.Date;
            RepContract.Contract.TotalPrice = txtTotalPrice.DecimalValue;
            RepContract.Contract.Job = Convert.ToInt32(cmbJob.SelectedValue);

            if (RepContract.SavePersonContract())
            {
                if (!RentContract)
                {
                    JDataBase pDB = new JDataBase();
                    try
                    { JPersonContract.CleareAssetShare(RepContract.Contract.Code, pDB); }
                    finally
                    {
                        pDB.DisConnect();
                    }
                }

                ClassLibrary.JMessages.Information("اصلاحات قرارداد ثبت شد.", "");
                if (grdNextContracts.Rows.Count > 0 && grdNextContracts.CurrentRow != null && !RentContract)
                {
                     //DataTable _BuyerPersonsContract = JPersonContract.GetAllDataType(RepContract.Contract.FinanceCode, RepContract.Contract.Code,
                     //    ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer, 
                     //    (Finance.JOwnershipType)RepContract.Contract.ContractType.AssetTransferType, null, true);
                    DataTable _BuyerPersonsContract = RepContract.GetNextSellers();
                    int next = Convert.ToInt32(grdNextContracts.CurrentRow.Cells["ContractCode"].Value);
                    JRepairContract repair = new JRepairContract(next, _BuyerPersonsContract, RepContract.Contract.TransferCode);
                    repair.PreContract = RepContract.Contract.Code;
                    repair.Show();
                }
                else
                {
                }
                Close();
            }
            else
            {
                ClassLibrary.JMessages.Information("ثبت اصلاحات با مشکل مواجه شده است", "خطا");
                Close();
            }
        }

        public void Show()
        {
            if (JPermission.CheckPermission("Legal.JRepairContractForm.Show", RepContract.Contract.ContractType.Code))                    
                ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == TabContracts && grdNextContracts.DataSource==null )
            {
                grdNextContracts.DataSource = RepContract.NextContracts();
            }
        }

        private void btnRepairAll_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("آیا میخواهید همه قراردادهای این دارایی از ابتدا اصلاح شود؟", "") == DialogResult.Yes)
                if (RepContract.RepairAll())
                    Close();
        }


    }
}
