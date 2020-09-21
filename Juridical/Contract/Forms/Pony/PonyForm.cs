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
    public partial class JPonyForm : ClassLibrary.JBaseForm
    {
        //public int _Code;
        JPony pony;
        JSubjectContract contract;
        public JPonyForm(int pContractCode)
        {
            InitializeComponent();
            pony = new JPony();
            pony.GetDataByContractCode(pContractCode);
            pony.ContractSubjectCode = pContractCode;
            contract = new JSubjectContract(pContractCode);
            if (pony.Code > 0)
            {
                State = JFormState.Update;
                Set_Form();
            }
            else
                State = JFormState.Insert;
            Set_Contract();
        }

        public JPonyForm(int pCode, int pContractCode)
        {
            InitializeComponent();
            //_Code = pCode;            
            pony = new JPony(pCode);
            contract = new JSubjectContract(pContractCode);
            State = JFormState.Update;
            Set_Form();
            Set_Contract();
        }
        
        #region Methods
        private void Set_Contract()
        {
            /// اطلاعات قرارداد
            txtContractCode.Text = contract.Code.ToString();
            txtDateContract.Date = contract.Date;
            txtdateEnd.Date = contract.EndDate;
            txtdateStart.Date = contract.StartDate;
            txtDateDeliver.Date = contract.DateDeliver;
            txtDesc.Text = pony.Description;
            txtDate.Date = pony.Create_Date.Date;
        }

        private void Set_Form()
        {
            try
            {
                /// مقداردهی پراپرتی های لیست آرشیو
                jArchivePony.ClassName = "Legal.JPony";
                jArchivePony.SubjectCode = 0;
                jArchivePony.PlaceCode = 0;
                jArchivePony.ObjectCode = pony.Code;

                //JPony pony = new JPony();

                if (pony.Advertisement)
                    chkAdvertisement.Checked = true;
                else
                    chkAdvertisement.Checked = false;
                if (pony.InsuranceOffice)
                    chkInsuranceOffice.Checked = true;
                else
                    chkInsuranceOffice.Checked = false;
                if (pony.LodgerSignature)
                    chkLodgerSignature.Checked = true;
                else
                    chkLodgerSignature.Checked = false;
                if (pony.ManagerSignature)
                    chkManagerSignature.Checked = true;
                else
                    chkManagerSignature.Checked = false;
                if (pony.mayor)
                    chkMayor.Checked = true;
                else
                    chkMayor.Checked = false;
                if (pony.OfficeSignature)
                    chkOfficeSignature.Checked = true;
                else
                    chkOfficeSignature.Checked = false;
                if (pony.Power)
                    chkPower.Checked = true;
                else
                    chkPower.Checked = false;
                if (pony.Price)
                    chkPrice.Checked = true;
                else
                    chkPrice.Checked = false;
                if (pony.PriceMonth)
                    chkPriceMonth.Checked = true;
                else
                    chkPriceMonth.Checked = false;
                if (pony.RenterSignature)
                    chkRenterSignature.Checked = true;
                else
                    chkRenterSignature.Checked = false;
                if (pony.RightStationery)
                    chkRightStationery.Checked = true;
                else
                    chkRightStationery.Checked = false;
                if (pony.Sharj)
                    chkSharj.Checked = true;
                else
                    chkSharj.Checked = false;
                if (pony.TaxOffice)
                    chkTaxOffice.Checked = true;
                else
                    chkTaxOffice.Checked = false;
                if (pony.Telephone)
                    chkTelephone.Checked = true;
                else
                    chkTelephone.Checked = false;               
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool Save()
        {
            try
            {
                pony.ContractSubjectCode = Convert.ToInt32(txtContractCode.Text);
                pony.Create_Date = txtDate.Date;
                pony.Description = txtDesc.Text;
                
                if (chkAdvertisement.Checked)
                    pony.Advertisement = true;
                else
                    pony.Advertisement = false;
                if (chkInsuranceOffice.Checked)
                    pony.InsuranceOffice = true;
                else
                    pony.InsuranceOffice = false;
                if (chkLodgerSignature.Checked)
                    pony.LodgerSignature = true;
                else
                    pony.LodgerSignature = false;
                if (chkManagerSignature.Checked)
                    pony.ManagerSignature = true;
                else
                    pony.ManagerSignature = false;
                if (chkMayor.Checked)
                    pony.mayor = true;
                else
                    pony.mayor = false;
                if (chkOfficeSignature.Checked)
                    pony.OfficeSignature = true;
                else
                    pony.OfficeSignature = false;
                if (chkPower.Checked)
                    pony.Power = true;
                else
                    pony.Power = false;
                if (chkPrice.Checked)
                    pony.Price = true;
                else
                    pony.Price = false;
                if (chkPriceMonth.Checked)
                    pony.PriceMonth = true;
                else
                    pony.PriceMonth = false;
                if (chkRenterSignature.Checked)
                    pony.RenterSignature = true;
                else
                    pony.RenterSignature = false;
                if (chkRightStationery.Checked)
                    pony.RightStationery = true;
                else
                    pony.RightStationery = false;
                if (chkSharj.Checked)
                    pony.Sharj = true;
                else
                    pony.Sharj = false;
                if (chkTaxOffice.Checked)
                    pony.TaxOffice = true;
                else
                    pony.TaxOffice = false;
                if (chkTelephone.Checked)
                    pony.Telephone = true;
                else
                    pony.Telephone = false;

                if (State == JFormState.Insert)
                {
                    pony.Code = pony.Insert();
                }
                else
                    if (State == JFormState.Update)
                        pony.Update();
                if (pony.Code > 0)
                {
                    jArchivePony.ClassName = "Legal.JSubjectContract";
                    jArchivePony.SubjectCode = 0;
                    jArchivePony.PlaceCode = 0;
                    jArchivePony.ObjectCode = pony.ContractSubjectCode;
                    jArchivePony.ArchiveList();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        #endregion

        #region Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    btnSave.Enabled = false;
                    this.State = JFormState.Update;
                }
                else
                    JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                    Close();
                else
                    JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Enabled == true)
                {
                    if (JMessages.Question("DoYouWantToSaveChanges", "Save") == DialogResult.Yes)
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
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        #endregion

        #region Events Modify

        private void chkPriceMonth_CheckedChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

   
        #endregion

    }
}
