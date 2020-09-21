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
    public partial class JCancelContractForm : ClassLibrary.JBaseForm
    {
        private int _Code;

        public JCancelContractForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
        }

        #region Methods

        public void Set_Form()
        {
            try
            {
                JSubjectContract tmp = new JSubjectContract(_Code);
                txtdateEnd.Date = tmp.CancelDate;
                txtDesc.Text = tmp.CancelDesc;
                txtReason.Text = tmp.CancelReason;
                lstArchive.ObjectCode = tmp.Code;
                lstArchive.ClassName = tmp.GetType().FullName;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool Save()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.beginTransaction("CancelContract");
                JSubjectContract tmp = new JSubjectContract(_Code, db);
                //tmp.Code = _Code;
                tmp.CancelDate = txtdateEnd.Date;
                tmp.CancelDesc = txtDesc.Text;
                tmp.CancelReason = txtReason.Text;
                //// در صورتی که قرارداد قبلا فسخ شده
                if (tmp.Status == JContractStatus.Canceled)
                {
                    lstArchive.ArchiveList();
                    tmp.Update(db);
                    db.Commit();
                    return true;
                }
                tmp.Status = JContractStatus.Canceled;
                if (tmp.Update(db))
                {

                    if ((Finance.JOwnershipType)tmp.ContractType.AssetTransferType == Finance.JOwnershipType.Definitive)
                    {
                        if (JCancelContract.CancelDefinit(db, _Code))
                        {
                        }
                    }
                    else if ((Finance.JOwnershipType)tmp.ContractType.AssetTransferType == Finance.JOwnershipType.Goodwill)
                    {
                        if (JCancelContract.CancelGoodwill(db, _Code))
                        {
                        }
                    }
                    else if ((Finance.JOwnershipType)tmp.ContractType.AssetTransferType == Finance.JOwnershipType.Rentals)
                    {
                    }
                    else if ((Finance.JOwnershipType)tmp.ContractType.AssetTransferType == Finance.JOwnershipType.GoodwillPeace)
                    {
                    }
                    else if ((Finance.JOwnershipType)tmp.ContractType.AssetTransferType == Finance.JOwnershipType.Other)
                    {
                    }
                    //else
                    //{
                    //    JMessages.Message("Update Not Successfuly ", "", JMessageType.Error);
                    //    db.Rollback("CancelContract");
                    //    return false;
                    //}
                    db.Commit();
                    lstArchive.ObjectCode = tmp.Code;
                    lstArchive.ClassName = tmp.GetType().FullName;
                    lstArchive.ArchiveList();
                    JAction DissolutionAction = new JAction("GetDissolution", tmp.ContractType.ClassName + ".CancelContract", new object[] { tmp.Code }, null);
                    string Comment = (string)DissolutionAction.run();
                    JMessages.Message("ContractDissoluted", "", JMessageType.Information);
                    return true;
                }
                else
                {
                    JMessages.Message("Update Not Successfuly ", "", JMessageType.Error);
                    db.Rollback("CancelContract");
                    return false;
                }
            }
            catch (Exception ex)
            {
                db.Rollback("CancelContract");
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion

        #region Events

        private void DissolutionForm_Load(object sender, EventArgs e)
        {
            try
            {
                Set_Form();                   
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void txtdateEnd_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        #endregion
    }
}
