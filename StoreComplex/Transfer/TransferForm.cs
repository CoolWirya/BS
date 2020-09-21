using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Legal;

namespace StoreComplex
{
    public partial class JSCTransferForm : Globals.JBaseForm
    {
      int ContractCode;
        int TransferCode;
        JSCTransfer _Transfer;
        public JSCTransferForm(int pPCode, int pContractCode, int pTransferCode)
        {
            InitializeComponent();
            ContractCode = pContractCode;
            TransferCode = pTransferCode;
            _Transfer = new JSCTransfer(TransferCode);
            _Transfer.PCode = pPCode;
            LoadComboBox();
            ShowData();
            if (pTransferCode > 0)
            {
                this.State = ClassLibrary.JFormState.Update;
            }
            else
            {
                cmbDriveTpye.SelectedValue = -1;
                DateTime now = JDateTime.Now();
                txtDate.Date = now;
                txtTime.Text = JDateTime.GetStringTime(now);
                txtSerial.Text = JSCTransfers.GetMaxSerial();
                this.State = ClassLibrary.JFormState.Insert;
            }
        }

        private void LoadComboBox()
        {
            JVanTypes types = new JVanTypes();
            cmbDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
            types.SetComboBox(cmbDriveTpye, _Transfer.DriveType);          

        }
        private void LoadConveyService()
        {
            grdConvey.DataSource = JConveyServices.GetDatatable(0, "StoreComplex.JSCTransfer", TransferCode);
        }
        private void LoadLodingService()
        {
            grdLoading.DataSource = JLoadingServices.GetDatatable(0, "StoreComplex.JSCTransfer", TransferCode, JLoadingServiceType.All);
        }
        private void LoadOtherService()
        {
            grdOtherService.DataSource = JOtherServices.GetDatatable(0, "StoreComplex.JSCTransfer", TransferCode);
        }
        private void LoadTransferGoods()
        {
            grdGoods.DataSource = JSCTransferGoods.GetDatatable(TransferCode);
        }
        private void LoadPrivateTransfers()
        {
             grdPrivateStorage.DataSource = JPrivateTransfers.GetDatatable(TransferCode);
        }
        private void ShowData()
        {
            JServiceTypes services = new JServiceTypes();
            JSubjectContract contract = new JSubjectContract(ContractCode);
            DataTable owner = JPersonContract.GetPerson(ContractCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
            if (owner != null)
                txtOwnerName.Text = owner.Rows[0]["Name"].ToString();
            JSCGood good = new JSCGood();
            good.GetData(contract.SCGood);
            txtgoodType.Text = good.Name;
            txtCode.Text = contract.SCCode;

            txtSerial.Text = _Transfer.Serial;
            txtPelakNo.Text = _Transfer.PelakNo;
            txtDriverName.Text = _Transfer.DriverName;
            txtDate.Date = _Transfer.Date;
            txtTime.Text = JDateTime.GetStringTime(_Transfer.Date);
            cmbDriveTpye.SelectedValue = _Transfer.DriveType;

            LoadLodingService();
            LoadConveyService();
            LoadOtherService();
            LoadTransferGoods();
            LoadPrivateTransfers();
            if (_Transfer.Closed)
                CloseReceipt();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region validate
            if (txtSerial.Text.Trim() == "")
            {
                JMessages.Error("لطفا شماره سریال را وارد کنید.", "خطا");
                return;
            }
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ را وارد کنید.", "خطا");
                return;
            }
            if (txtTime.Text == "")
            {
                JMessages.Error("لطفا ساعت را وارد کنید.", "خطا");
                return;
            }
            #endregion validate

            //JSCTransfer _Transfer = new JSCTransfer(TransferCode);
            _Transfer.ContractCode = ContractCode;
            _Transfer.Date = JDateTime.GregorianDate(txtDate.Text, txtTime.Text.Replace('.', ':'));
            _Transfer.Description = txtDesc.Text;
            _Transfer.DriverName = txtDriverName.Text;
            _Transfer.DriveType = (Convert.ToInt32(cmbDriveTpye.SelectedValue));
            _Transfer.PelakNo = txtPelakNo.Text;
            _Transfer.Serial = txtSerial.Text;
            if (this.State == ClassLibrary.JFormState.Insert)
            {
                if (_Transfer.Insert() > 0)
                {
                    TransferCode = _Transfer.Code;
                    btnSave.Enabled = false;
                    this.State = JFormState.Update;
                }
                else
                {
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "");
                }
            }
            else if (this.State == ClassLibrary.JFormState.Update)
            {
                if (_Transfer.Update())
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            if (!_Transfer.Closed)
                btnSave.Enabled = true;
            else btnSave.Enabled = false;
        }

        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (TransferCode == 0)
                return;
            JSCTransferGoodsForm form = new JSCTransferGoodsForm(ContractCode , TransferCode, 0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTransferGoods();
            }
        }

        private void btnDelGoods_Click(object sender, EventArgs e)
        {
            if (grdGoods.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            if (JMessages.Question("آیا میخواهید کالای انتخاب شده حذف شود؟", "حذف کالا") == DialogResult.Yes)
            {
                int Code = Convert.ToInt32(grdGoods.SelectedRows[0].Cells["Code"].Value);
                JSCTransferGood service = new JSCTransferGood(Code);
                service.Delete();
                LoadTransferGoods();
            }
        }

        private void btnEditGoods_Click(object sender, EventArgs e)
        {
            if (grdGoods.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            int Code = Convert.ToInt32(grdGoods.SelectedRows[0].Cells["Code"].Value);
            JSCTransferGoodsForm form = new JSCTransferGoodsForm(ContractCode, TransferCode, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTransferGoods();
            }
        }

        private void btnAddConveyService_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (TransferCode == 0)
                return;
            JConveyForm form = new JConveyForm(ContractCode ,"StoreComplex.JSCTransfer", TransferCode, txtSerial.Text, 0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadConveyService();
            }
        }

        private void btnDelConveyService_Click(object sender, EventArgs e)
        {
            if (grdConvey.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            if (JMessages.Question("آیا میخواهید سرویس انتخاب شده حذف شود؟", "حذف سرویس حمل و نقل") == DialogResult.Yes)
            {
                int Code = Convert.ToInt32(grdConvey.SelectedRows[0].Cells["Code"].Value);
                JConveyService service = new JConveyService(Code);
                service.Delete();
                LoadConveyService();
            }
        }

        private void btnEditConveyService_Click(object sender, EventArgs e)
        {
            if (grdConvey.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            int Code = Convert.ToInt32(grdConvey.SelectedRows[0].Cells["Code"].Value);
            JConveyForm form = new JConveyForm(ContractCode, "StoreComplex.JSCTransfer", TransferCode, txtSerial.Text, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadConveyService();
            }
        }

        private void btnAddLoadingService_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (TransferCode == 0)
                return;
            JLoadingForm form = new JLoadingForm(ContractCode, "StoreComplex.JSCTransfer", TransferCode, txtSerial.Text, JLoadingServiceType.Loading, 0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadLodingService();
            }
        }

        private void btnDelLoadingService_Click(object sender, EventArgs e)
        {
            if (grdLoading.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            if (JMessages.Question("آیا میخواهید سرویس انتخاب شده حذف شود؟", "حذف سرویس تخلیه و بارگیری") == DialogResult.Yes)
            {
                int Code = Convert.ToInt32(grdLoading.SelectedRows[0].Cells["Code"].Value);
                JLoadingService service = new JLoadingService(Code);
                service.Delete();
                LoadLodingService();
            }
        }

        private void btnEditLoadingService_Click(object sender, EventArgs e)
        {
            if (grdLoading.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            int Code = Convert.ToInt32(grdLoading.SelectedRows[0].Cells["Code"].Value);
            JLoadingForm form = new JLoadingForm(ContractCode, "StoreComplex.JSCTransfer", TransferCode, txtSerial.Text, JLoadingServiceType.Loading, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadLodingService();
            }
        }

        private void btnAddService3_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (TransferCode == 0)
                return;
            JOtherServiceForm form = new JOtherServiceForm(ContractCode, "StoreComplex.JSCTransfer", TransferCode, 0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadOtherService();
            }
        }

        private void btnDelOtherService_Click(object sender, EventArgs e)
        {
            if (grdOtherService.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            if (JMessages.Question("آیا میخواهید سرویس انتخاب شده حذف شود؟", "حذف سرویس") == DialogResult.Yes)
            {
                int Code = Convert.ToInt32(grdOtherService.SelectedRows[0].Cells["Code"].Value);
                JOtherService service = new JOtherService(Code);
                service.Delete();
                LoadOtherService();
            }
        }

        private void btnEditOtherService_Click(object sender, EventArgs e)
        {
            if (grdOtherService.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            int Code = Convert.ToInt32(grdOtherService.SelectedRows[0].Cells["Code"].Value);
            JOtherServiceForm form = new JOtherServiceForm(ContractCode, "StoreComplex.JSCTransfer", TransferCode, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadOtherService();
            }
        }

        private void CloseReceipt()
        {
            btnSave.Enabled = false;
            btnAddConveyService.Enabled = false;
            btnAddGoods.Enabled = false;
            btnAddLoadingService.Enabled = false;
            btnAddService3.Enabled = false;

            btnDelConveyService.Enabled = false;
            btnDelGoods.Enabled = false;
            btnDelLoadingService.Enabled = false;
            btnDelOtherService.Enabled = false;

            btnEditConveyService.Enabled = false;
            btnEditGoods.Enabled = false;
            btnEditLoadingService.Enabled = false;
            btnEditOtherService.Enabled = false;
            btnCloseReceipt.Enabled = false;

            btnAddPrivate.Enabled = false;
            btnDelPrivate.Enabled = false;
            btnEditPrivate.Enabled = false;
        }
        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("پس از تائید نهایی رسید، قادر به تغییر اطلاعات آن نیستید. آیا میخواهید رسید تائید شود؟", "تائید رسید") == DialogResult.Yes)
            {
                btnSave.PerformClick();
                if (_Transfer.Code == 0)
                    _Transfer.GetData(TransferCode);
                _Transfer.Closed = true;
                if (_Transfer.Update())
                    CloseReceipt();
            }
        }

        private void btnAddPrivate_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (TransferCode == 0)
                return;
            JPrivateTransferForm form = new JPrivateTransferForm(ContractCode, TransferCode, 0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPrivateTransfers();
            }
        }

        private void btnDelPrivate_Click(object sender, EventArgs e)
        {
            if (grdPrivateStorage.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            if (JMessages.Question("آیا میخواهید ردیف مورد نظر حذف شود؟", "حذف تخلیه انبار اختصاصی") == DialogResult.Yes)
            {
                int Code = Convert.ToInt32(grdPrivateStorage.SelectedRows[0].Cells["Code"].Value);
                JPrivateTransfer service = new JPrivateTransfer(Code);
                service.Delete();
                LoadPrivateTransfers();
            }
        }

        private void btnEditPrivate_Click(object sender, EventArgs e)
        {
            if (grdPrivateStorage.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            int Code = Convert.ToInt32(grdPrivateStorage.SelectedRows[0].Cells["Code"].Value);
            JPrivateTransferForm form = new JPrivateTransferForm(ContractCode, TransferCode, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPrivateTransfers();
            }
        }


       
    }
}
