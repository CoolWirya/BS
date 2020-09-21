using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JFanniSubjectForm : JBaseContractForm
    {
        public JFanniSubjectForm()
        {
            InitializeComponent();
            /// مقداردهی پراپرتی های لیست آرشیو
            jArchiveListContract.ClassName = "Legal.JContract";
            jArchiveListContract.SubjectCode = 0;
            jArchiveListContract.PlaceCode = 0;
            SaveOrder = 1;
        }

        public JFanniSubjectForm MakeForm()
        {
            JFanniSubjectForm form = new JFanniSubjectForm();
            return form;
        }

        private void FillCombo()
        {
            try
            {
                cmbSubject.DisplayMember = "Title";
                cmbSubject.ValueMember = "Code";
                cmbSubject.DataSource = JContractdefines.GetDataTable(0, ContractForms.Contract.ContractType.Code, null);
                object copyCount = Globals.JRegistry.Read("Legal.JSubjectContract.DefaultCopyCount");
                txtCopyCount.Value = Convert.ToDecimal(copyCount);
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
                JSubjectContract contract = ContractForms.Contract;
                txtContractNumber.Text = contract.Number;
                txtDate.Date = contract.Date;
                cmbSubject.SelectedValue = ContractForms.Contract.Type;

                txtSubject.Text = contract.Description;
                txtStartDate.Date = contract.StartDate;
                txtEndDate.Date = contract.EndDate;
//                txtFine.Text = contract.FineT2.ToString();
                txtCopyCount.Text = contract.CopyCount.ToString();
                txtCostDesc.Text = contract.CostDesc;
//                cmbPercent.SelectedIndex = contract.FineType;

                if (ContractForms.Contract.Code > 0)
                {
                    jArchiveListContract.ObjectCode = ContractForms.Contract.Code;
                    Finance.JAsset asset = new Finance.JAsset(ContractForms.Contract.FinanceCode);
                }
                
                if (State == JStateContractForm.View)
                {
                    txtContractNumber.ReadOnly = true;
                    txtDate.ReadOnly = true;
                    txtContractNumber.ReadOnly = true;
                    txtDate.ReadOnly = true;
                    txtSubject.ReadOnly = true;
                    txtEndDate.ReadOnly = true;
                    txtStartDate.ReadOnly = true;
                    txtCopyCount.Enabled = false;
//                    cmbPercent.Enabled = false;
                    cmbSubject.Enabled = false;

                    jArchiveListContract.EnabledChange = false;
                    jArchiveListContract.AllowUserAddFile = false;
                    jArchiveListContract.AllowUserAddFromArchive = false;
                    jArchiveListContract.AllowUserAddImage = false;
                    jArchiveListContract.AllowUserDeleteFile = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool CheckData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                if (cmbSubject.SelectedValue == null)
                {
                    JMessages.Error(".لطفا حداقل یک متن برای این نوع قرارداد تعریف کنید", "Error");
                    return false;
                }
                /// در صورتی که قرارداد باید با شماره و تاریخ ثبت شود (در تنظیمات نوع قرارداد مشخص میشود)
                if (txtContractNumber.Enabled)
                {
                    if (txtContractNumber.Text.Trim() == "")
                    {
                        JMessages.Information("لطفا شماره قرارداد را وارد کنید", "Information");
                        txtContractNumber.Focus();
                        return false;
                    }

                    if (txtEndDate.Visible && txtStartDate.Visible)
                        if (DateTime.Compare(txtStartDate.Date, txtEndDate.Date) >= 0)
                        {
                            JMessages.Information("Please Enter Campare Date", "Information");
                            txtStartDate.Focus();
                            return false;
                        }
                    if (txtDate.Date == DateTime.MinValue)
                    {
                        JMessages.Information("Please Enter Date", "Information");
                        txtDate.Focus();
                        return false;
                    }
                    if (txtSubject.Text.Trim()=="")
                    {
                        JMessages.Information("Please Enter Subject", "Information");
                        txtSubject.Focus();
                        return false;
                    }
                    if (txtCostDesc.Text.Trim() == "")
                    {
                        JMessages.Information("لطفا مبلغ قرارداد را وارد کنید", "Information");
                        txtCostDesc.Focus();
                        return false;
                    } 
                    //if (txtStartDate.Visible)
                    //    if (txtStartDate.Date == DateTime.MinValue)
                    //    {
                    //        JMessages.Information("Please Enter StartDate", "Information");
                    //        return false;
                    //    }
                    //if (txtEndDate.Visible)
                    //    if (txtEndDate.Date == DateTime.MinValue)
                    //    {
                    //        JMessages.Information("Please Enter EndDate", "Information");
                    //        return false;
                    //    }
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private bool ApplyData()
        {
            try
            {
                ContractForms.Contract.Type = Convert.ToInt32(cmbSubject.SelectedValue);
                ContractForms.Contract.Number = txtContractNumber.Text.Trim();
                ContractForms.Contract.Date = txtDate.Date;

                ContractForms.Contract.Description = txtSubject.Text;
                ContractForms.Contract.StartDate = txtStartDate.Date;
                ContractForms.Contract.EndDate = txtEndDate.Date;
//                ContractForms.Contract.FineT2 = txtFine.DecimalValue;
                ContractForms.Contract.CopyCount = Convert.ToInt32(txtCopyCount.Value);
                ContractForms.Contract.CostDesc = txtCostDesc.Text;
//                ContractForms.Contract.FineType = cmbPercent.SelectedIndex;
                ContractForms.Contract.Duration = txtDuration.IntValue;

                Globals.JRegistry.Write("Legal.JSubjectContract.DefaultCopyCount", Convert.ToInt32(txtCopyCount.Value));
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
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
                pDt.Columns.Add("ContractNo");
                pDt.Columns.Add("Date");
                pDt.Columns.Add("StringDate");

                pDt.Columns.Add("StartDate");
                pDt.Columns.Add("StringStartDate");
                pDt.Columns.Add("EndDate");
                pDt.Columns.Add("StringEndDate");
                pDt.Columns.Add("ContractSubject");
                pDt.Columns.Add("CopyCount");
                pDt.Columns.Add("CostDesc");
                pDt.Columns.Add("DurationMonths");
                pDt.Columns.Add("T1Title");
                pDt.Columns.Add("T2Title");
                //pDt.Columns.Add("FineType");
                pDt.Columns.Add("FineT1");

                if (pSetValue)
                {

                    if (pOffline)
                        Fill_Data();

                    pDt.Rows[0]["ContractNo"] = txtContractNumber.Text;
                    /// تاریخ به عدد و حروف
                    pDt.Rows[0]["Date"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtDate.Date));
                    pDt.Rows[0]["StringDate"] = JDateTime.StringDate(txtDate.Text);
                    /// تاریخ شروع به عدد و حروف
                    pDt.Rows[0]["StartDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtStartDate.Date));
                    pDt.Rows[0]["StringStartDate"] = JDateTime.StringDate(txtStartDate.Text);
                    /// تاریخ پایان به عدد و حروف
                    pDt.Rows[0]["EndDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtEndDate.Date));
                    pDt.Rows[0]["StringEndDate"] = JDateTime.StringDate(txtEndDate.Text);
                    pDt.Rows[0]["DurationMonths"] = txtDuration.Text;
                    pDt.Rows[0]["ContractSubject"] = txtSubject.Text.Trim();
                    /// عنوان طرف اول و دوم
                    pDt.Rows[0]["T1Title"] = ContractForms.Settings.Items["T1Lable"];
                    pDt.Rows[0]["T2Title"] = ContractForms.Settings.Items["T2Lable"];
                    pDt.Rows[0]["CopyCount"] = txtCopyCount.Value.ToString();
//                    pDt.Rows[0]["FineT1"] = txtFine.Text + " " + cmbPercent.Text;
                    //pDt.Rows[0]["FineType"] = cmbPercent.Text;
                    pDt.Rows[0]["CostDesc"] = txtCostDesc.Text;

                }

                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void Fill_Data()
        {
            try
                {
                    FillCombo();

                    if (ContractForms.Contract.Code > 0)
                    {
                        Set_Form();
                    }
             
//                    txtStartDate.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasStartDate"])));
  //                  lbStartDate.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasStartDate"])));

                    //txtEndDate.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasEndDate"])));
                    //lbEndDate.Visible = (Convert.ToBoolean(Convert.ToInt16(this.ContractForms.Settings.Items["HasEndDate"])));

                    //if (txtEndDate.Date != DateTime.MinValue && txtStartDate.Date != DateTime.MinValue)
                    //{
                    //    TimeSpan TS = txtEndDate.Date - txtStartDate.Date;
                    //    txtDuration.Text = (TS.Days / 30).ToString();
                    //}
                    SetDuration();
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
        }

        private void FanniSubjectForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Fill_Data();
            }
        }

        public override bool Save(JDataBase DB)
        {
            try
            {
                /// ویرایش قرارداد
                tempState = State;
                if (ContractForms.Contract.Code > 0)
                {
                    if (ContractForms.Contract.Update(DB))
                    {
                        jArchiveListContract.ObjectCode = ContractForms.Contract.Code;
                        jArchiveListContract.ArchiveList();
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    ContractForms.Contract.Code = ContractForms.Contract.Insert(DB);
                    if (ContractForms.Contract.Code > 0)
                    {
                        jArchiveListContract.ObjectCode = ContractForms.Contract.Code;
                        jArchiveListContract.ArchiveList();
                        return true;
                    }
                    else
                        return false;
                }
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckData())
                    if (ApplyData())
                        ContractForms.NextForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                ContractForms.BackForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ContractForms.Cancel();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void FanniSubjectForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ContractForms.Cancel(false);
        }
        private void SetDuration()
        {
            if (txtEndDate.Date != DateTime.MinValue && txtStartDate.Date != DateTime.MinValue)
            {
                TimeSpan TS = txtEndDate.Date - txtStartDate.Date;
                txtDuration.Text = (TS.Days / 30).ToString();
            }
        }
        private void txtStartDate_Leave(object sender, EventArgs e)
        {
            SetDuration();
        }


    }
}
