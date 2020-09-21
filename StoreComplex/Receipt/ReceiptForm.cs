using System;
using System.Data;
using System.Windows.Forms;
using ClassLibrary;
using Legal;

namespace StoreComplex
{
    public partial class JSCReceiptForm : Globals.JBaseForm
    {
        int ContractCode;
        int ReceiptCode;
        JSCReceipt _Receipt;
        public JSCReceiptForm(int pPCode, int pContractCode, int pReceiptCode)
        {
            InitializeComponent();
            ContractCode = pContractCode;
            ReceiptCode = pReceiptCode;
            _Receipt = new JSCReceipt(ReceiptCode);
            _Receipt.PCode = pPCode;
            LoadComboBox();
            ShowData();
            if (pReceiptCode > 0)
            {
                this.State = ClassLibrary.JFormState.Update;
            }
            else
            {
                cmbDriveTpye.SelectedValue = -1;
                DateTime now = JDateTime.Now();
                txtDate.Date = now;
                txtTime.Text = JDateTime.GetStringTime(now);
                txtSerial.Text = JSCReceipts.GetMaxSerial();
                this.State = ClassLibrary.JFormState.Insert;
            }
        }

        private void LoadComboBox()
        {
            JVanTypes types = new JVanTypes();
            cmbDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
            types.SetComboBox(cmbDriveTpye, _Receipt.DriveType);          

        }
        private void LoadConveyService()
        {
            grdConvey.DataSource = JConveyServices.GetDatatable(0, "StoreComplex.JSCReceipt", ReceiptCode);
        }
        private void LoadLodingService()
        {
            grdLoading.DataSource = JLoadingServices.GetDatatable(0, "StoreComplex.JSCReceipt", ReceiptCode, JLoadingServiceType.All);
        }
        private void LoadOtherService()
        {
            grdOtherService.DataSource = JOtherServices.GetDatatable(0, "StoreComplex.JSCReceipt", ReceiptCode);
        }
        private void LoadReceiptGoods()
        {
            grdGoods.DataSource = JSCReceiptGoods.GetDataTable( ReceiptCode);
        }
        private void LoadPrivateStorage()
        {
            grdPrivateStorage.DataSource = JPrivateStorages.GetDataTable(ReceiptCode);
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

            txtSerial.Text = _Receipt.Serial;
            txtPelakNo.Text = _Receipt.PelakNo;
            txtDriverName.Text = _Receipt.DriverName;
            txtDate.Date = _Receipt.Date;
            txtTime.Text = JDateTime.GetStringTime(_Receipt.Date);
            cmbDriveTpye.SelectedValue = _Receipt.DriveType;
            //if (_Receipt.StoreType == JStoreType.Box.GetHashCode())
            //    rbBox.Checked = true;
            //if (_Receipt.StoreType == JStoreType.Counting.GetHashCode())
            //    rbCounting.Checked = true;
            //if (_Receipt.StoreType == JStoreType.Meter.GetHashCode())
            //    rbMeter.Checked = true;
            //if (_Receipt.StoreType == JStoreType.Ton.GetHashCode())
            //    rbTon.Checked = true; 
            
            LoadLodingService();
            LoadConveyService();
            LoadOtherService();
            LoadReceiptGoods();
            LoadPrivateStorage();
            if (_Receipt.Closed)
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

            //JSCReceipt _Receipt = new JSCReceipt(ReceiptCode);
            _Receipt.ContractCode = ContractCode;
            _Receipt.Date = JDateTime.GregorianDate(txtDate.Text, txtTime.Text.Replace('.', ':'));
            _Receipt.Description = txtDesc.Text;
            _Receipt.DriverName = txtDriverName.Text;
            _Receipt.DriveType = (Convert.ToInt32(cmbDriveTpye.SelectedValue));
            _Receipt.PelakNo = txtPelakNo.Text;
            _Receipt.Serial = txtSerial.Text;
            //if (rbBox.Checked)
            //    receipt.StoreType = JStoreType.Box.GetHashCode();
            //if (rbCounting.Checked)
            //    receipt.StoreType = JStoreType.Counting.GetHashCode();
            //if (rbMeter.Checked)
            //    receipt.StoreType = JStoreType.Meter.GetHashCode(); 
            //if (rbTon.Checked)
            //    receipt.StoreType = JStoreType.Ton.GetHashCode();
            
            if (this.State == ClassLibrary.JFormState.Insert)
            {
                if (_Receipt.Insert() > 0)
                {
                    ReceiptCode = _Receipt.Code;
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
                if (_Receipt.Update())
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "");
                }
            }
        }

        private void txtSerial_TextChanged(object sender, EventArgs e)
        {
            if (!_Receipt.Closed)
                btnSave.Enabled = true;
            else btnSave.Enabled = false;
        }

        private void grdGoods_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!_Receipt.Closed)
                btnSave.Enabled = true;
            else btnSave.Enabled = false;
        }

        private void jDataGrid3_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (!_Receipt.Closed)
                btnSave.Enabled = true;
            else btnSave.Enabled = false;           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (ReceiptCode == 0)
                return;
            JSCReceiptGoodsForm form = new JSCReceiptGoodsForm(ReceiptCode, 0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadReceiptGoods();
            }
        }


        private void btnAddLoadingService_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (ReceiptCode == 0)
                return;
            JLoadingForm form = new JLoadingForm(ContractCode, "StoreComplex.JSCReceipt", ReceiptCode, txtSerial.Text, JLoadingServiceType.Loading, 0);
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
            JLoadingForm form = new JLoadingForm(ContractCode ,"StoreComplex.JSCReceipt", ReceiptCode, txtSerial.Text, JLoadingServiceType.Loading, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadLodingService();
            }
        }

        private void btnAddConveyService_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (ReceiptCode == 0)
                return;
            JConveyForm form = new JConveyForm(ContractCode ,"StoreComplex.JSCReceipt", ReceiptCode, txtSerial.Text, 0);
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
            JConveyForm form = new JConveyForm(ContractCode, "StoreComplex.JSCReceipt", ReceiptCode, txtSerial.Text, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadConveyService();
            }
        }

        private void btnAddService3_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (ReceiptCode == 0)
                return;
            JOtherServiceForm form = new JOtherServiceForm(ContractCode, "StoreComplex.JSCReceipt", ReceiptCode, 0);
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
            JOtherServiceForm form = new JOtherServiceForm(ContractCode, "StoreComplex.JSCReceipt", ReceiptCode, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadOtherService();
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
                JSCReceiptGood service = new JSCReceiptGood(Code);
                service.Delete();
                LoadReceiptGoods();
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
            JSCReceiptGoodsForm form = new JSCReceiptGoodsForm(ReceiptCode, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadReceiptGoods();
            }
        }

        private void CloseReceipt()
        {
            btnSave.Enabled = false;
            btnAddConveyService.Enabled = false;
            btnAddFactor.Enabled = false;
            btnAddGoods.Enabled = false;
            btnAddLoadingService.Enabled = false;
            btnAddService3.Enabled = false;
            btnAddPrivate.Enabled = false;

            btnDelConveyService.Enabled = false;
            btnDelFactor.Enabled = false;
            btnDelGoods.Enabled = false;
            btnDelLoadingService.Enabled = false;
            btnDelOtherService.Enabled = false;
            btnDelPrivate.Enabled = false;

            btnEditConveyService.Enabled = false;
            btnEditFactor.Enabled = false;
            btnEditGoods.Enabled = false;
            btnEditLoadingService.Enabled = false;
            btnEditOtherService.Enabled = false;
            btnEditPrivate.Enabled = false;

            btnCloseReceipt.Enabled = false;
        }

        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("پس از تائید نهایی رسید، قادر به تغییر اطلاعات آن نیستید. آیا میخواهید رسید تائید شود؟", "تائید رسید") == DialogResult.Yes)
            {
                btnSave.PerformClick();
                if (_Receipt.Code == 0)
                    _Receipt.GetData(ReceiptCode);
                _Receipt.Closed = true;
                if (_Receipt.Update())
                    CloseReceipt();
            }
        }

        private void btnNewPrivate_Click(object sender, EventArgs e)
        {
            btnSave.PerformClick();
            if (ReceiptCode == 0)
                return;
            JPrivateStorageForm form = new JPrivateStorageForm(ReceiptCode, 0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPrivateStorage();
            }
        }

        private void btnDelPrivate_Click(object sender, EventArgs e)
        {
            if (grdPrivateStorage.SelectedRows.Count == 0)
            {
                JMessages.Error("موردی انتخاب نشده است", "");
                return;
            }
            if (JMessages.Question("آیا میخواهید ردیف انتخاب شده حذف شود؟", "حذف اجاره") == DialogResult.Yes)
            {
                int Code = Convert.ToInt32(grdPrivateStorage.SelectedRows[0].Cells["Code"].Value);
                JPrivateStorage service = new JPrivateStorage(Code);
                service.Delete();
                LoadPrivateStorage();
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
            JPrivateStorageForm form = new JPrivateStorageForm(ReceiptCode, Code);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPrivateStorage();
            }
        }
    }
}
