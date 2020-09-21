using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace RealEstate
{
    public partial class JTransferForm : JBaseForm
    {
        //int _UnitBuildCode;
        int _AssetCode;

        public JTransferForm()
        {
            InitializeComponent();
        }

        public JTransferForm(int pAssetCode)
        {
            InitializeComponent();
            _AssetCode = pAssetCode;
        }

        #region Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            try
            {
                Finance.JAsset tmp = new Finance.JAsset(_AssetCode);
                if (tmp.State == Finance.JAssetState.Request)
                {
                    JMessages.Information("لطفا وضعیت درخواست قبلی را مشخص کنبد", "");
                    return;
                }
                if (tmp.State == Finance.JAssetState.Reply)
                {
                    JMessages.Information(" برای این دارائی تایید درخواست زده شده ولی قرارداد صورت نگرفته است", "");
                    return;
                }
                JTransferUnitBuildForm p = new JTransferUnitBuildForm(_AssetCode);
                p.ShowDialog();
                RefeshGrid();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            if (jdgvTransfer.CurrentRow != null)
            {
                if ((Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Confirm"].Value) == false)&&
                    (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Mali"].Value) == false) &&
                    (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Modir"].Value) == false) &&
                    (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Amlak"].Value) == false) &&
                    (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Seller"].Value) == false) &&
                    //(Convert.ToDateTime(jdgvTransfer.CurrentRow.Cells["ConfirmDate"].Value) == DateTime.MinValue) && 
                    (Convert.ToString(jdgvTransfer.CurrentRow.Cells["ConfirmNumber"].Value) == ""))
                {
                    JTransferUnitBuildForm p = new JTransferUnitBuildForm(Convert.ToInt32(jdgvTransfer.CurrentRow.Cells["Code"].Value), _AssetCode);
                    p.State = JFormState.Update;
                    p.ShowDialog();
                    RefeshGrid();
                }
                else
                    JMessages.Information("این درخواست تایید شده و امکان تغییر نمی باشد", "");
            }
            else
                JMessages.Information("لطفا از لیست بالا درخواستی را انتخاب کنبد", "");
        }

        private void btnDelRequest_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvTransfer.CurrentRow != null)
                {
                    if ((Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Confirm"].Value) == false) &&
                        (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Mali"].Value) == false) &&
                        (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Modir"].Value) == false) &&
                        (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Amlak"].Value) == false) &&
                        (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Seller"].Value) == false) &&
                        //(Convert.ToDateTime(jdgvTransfer.CurrentRow.Cells["ConfirmDate"].Value) == DateTime.MinValue) && 
                        (Convert.ToString(jdgvTransfer.CurrentRow.Cells["ConfirmNumber"].Value) == ""))
                    {
                        JTransferUnitBuild tmp = new JTransferUnitBuild(Convert.ToInt32(jdgvTransfer.CurrentRow.Cells["Code"].Value));
                        if (tmp.delete())
                        {
                            JMessages.Information("Deleted Successfuly", "");
                            RefeshGrid();
                        }
                        else
                            JMessages.Error("Deleted Not Successfuly", "");
                    }
                }
                else
                    JMessages.Information("لطفا از لیست بالا درخواستی را انتخاب کنبد", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (jdgvTransfer.CurrentRow != null)
            {
                JTransferConfirmForm p = new JTransferConfirmForm(Convert.ToInt32(jdgvTransfer.CurrentRow.Cells["Code"].Value), _AssetCode);
                p.ShowDialog();
                RefeshGrid();
            }
            else
                JMessages.Information("لطفا از لیست بالا درخواستی را انتخاب کنبد", "");
        }

        private void btnEditConfirm_Click(object sender, EventArgs e)
        {
            if (jdgvTransfer.CurrentRow != null)
            {
                JTransferConfirmForm p = new JTransferConfirmForm(Convert.ToInt32(jdgvTransfer.CurrentRow.Cells["Code"].Value), _AssetCode);
                p.State = JFormState.Update;
                p.ShowDialog();
                RefeshGrid();
            }
            else
                JMessages.Information("لطفا از لیست بالا درخواستی را انتخاب کنبد", "");
        }

        private void btnDelConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvTransfer.CurrentRow != null)
                {
                    //if (Convert.ToBoolean(jdgvTransfer.CurrentRow.Cells["Confirm"].Value) == true)
                    //{

                        JTransferUnitBuild tmp = new JTransferUnitBuild(Convert.ToInt32(jdgvTransfer.CurrentRow.Cells["Code"].Value));
                        Finance.JAsset tmpAsset = new Finance.JAsset(tmp.AssetCode);
                        if (tmpAsset.State != Finance.JAssetState.General)
                        {

                            tmp.Confirm = false;
                            tmp.ConfirmDate = DateTime.MinValue;
                            tmp.ConfirmNumber = "";
                            tmp.Modir = false;
                            tmp.Mali = false;
                            tmp.Amlak = false;
                            tmp.Seller = false;
                            tmp.Price = "";
                            if (tmp.DeleteConfirm())
                            {
                                JMessages.Information("Deleted Successfuly", "");
                                RefeshGrid();
                            }
                            else
                                JMessages.Information("Deleted Not Successfuly", "");
                        }
                        else
                            JMessages.Information("برای این دارائی قرار داد ثبت شده", "");
                    //}
                }
                else
                    JMessages.Information("لطفا از لیست بالا درخواستی را انتخاب کنبد", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        #endregion

        private void JTransferForm_Load(object sender, EventArgs e)
        {
            //Finance.JAsset tmp = new Finance.JAsset("RealEstate.JUnitBuild", _AssetCode);
            //_AssetCode = tmp.Code;
            RefeshGrid();
            jdgvTransfer.Columns["Code"].Visible = false;
            jdgvTransfer.Columns["AssetCode"].Visible = false;
            PermissionConfirm();
            PermissionRequest();
        }

        #region Methods
                
        private void RefeshGrid()
        {
            JTransferUnitBuild p = new JTransferUnitBuild();
            jdgvTransfer.DataSource = p.GetAllData(0, _AssetCode);
        }

        public void PermissionRequest()
        {
            if (JPermission.CheckPermission("RealEstate.JTransferForm.PermissionRequest",false))                
                groupBox2.Visible = true;
        }

        public void PermissionConfirm()
        {
            if (JPermission.CheckPermission("RealEstate.JTransferForm.PermissionConfirm",false))                
                groupBox1.Visible = true;
        }
        #endregion

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvTransfer.CurrentRow != null)
                {
                    JHistory tmpJHistory = new JHistory("RealEstate.JTransferUnitBuild");
                    ClassLibrary.JHistoryForm p = new JHistoryForm(tmpJHistory, Convert.ToInt32(jdgvTransfer.CurrentRow.Cells["Code"].Value));
                    p.ShowDialog();
                }
                else
                    JMessages.Information("لطفا از لیست بالا درخواستی را انتخاب کنبد", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
        }

        private void jdgvTransfer_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (jdgvTransfer.CurrentRow != null)
                {
                    JHistory tmpJHistory = new JHistory("RealEstate.JTransferUnitBuild");
                    if (tmpJHistory.RetrieveHistory(Convert.ToInt32(jdgvTransfer.CurrentRow.Cells["Code"].Value)).Rows.Count > 1)
                        btnHistory.Enabled = true;
                    else
                        btnHistory.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
        }

        private void jdgvTransfer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (jdgvTransfer.CurrentRow != null)
                {
                    JTransferUnitBuildForm p = new JTransferUnitBuildForm(Convert.ToInt32(jdgvTransfer.CurrentRow.Cells["Code"].Value), _AssetCode);
                    p.State = JFormState.ReadOnly;
                    p.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
        }
    }
}
