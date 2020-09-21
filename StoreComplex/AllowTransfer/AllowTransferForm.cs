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
    public partial class JSCAllowTransferForm : Globals.JBaseForm
    {
        int ContractCode;
        int AllowTransferCode;
        JSCAllowTransfer _AllowTransfer;
        public JSCAllowTransferForm(int pContractCode, int pAllowTransferCode)
        {
            InitializeComponent();
            ContractCode = pContractCode;
            AllowTransferCode = pAllowTransferCode;
            _AllowTransfer = new JSCAllowTransfer(AllowTransferCode);
            LoadComboBox();
            ShowData();
            if (pAllowTransferCode > 0)
            {
                this.State = ClassLibrary.JFormState.Update;
            }
            else
            {
                cmbDriveTpye.SelectedValue = -1;
                DateTime now = JDateTime.Now();
                txtDate.Date = now;
                txtTime.Text = JDateTime.GetStringTime(now);
                this.State = ClassLibrary.JFormState.Insert;
            }
        }

        private void LoadComboBox()
        {
            JVanTypes types = new JVanTypes();
            cmbDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
            types.SetComboBox(cmbDriveTpye, _AllowTransfer.DriveType);          

        }
        private void LoadConveyService()
        {
            grdConvey.DataSource = JConveyServices.GetDatatable(0, "StoreComplex.JSCAllowTransfer", AllowTransferCode);
        }
        private void LoadLodingService()
        {
            grdLoading.DataSource = JLoadingServices.GetDatatable(0, "StoreComplex.JSCAllowTransfer", AllowTransferCode, JLoadingServiceType.All);
        }
        private void LoadOtherService()
        {
            grdOtherService.DataSource = JOtherServices.GetDatatable(0, "StoreComplex.JSCAllowTransfer", AllowTransferCode);
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

            txtSerial.Text = _AllowTransfer.Serial;
            txtPelakNo.Text = _AllowTransfer.PelakNo;
            txtDriverName.Text = _AllowTransfer.DriverName;
            txtDate.Date = _AllowTransfer.Date;
            txtTime.Text = JDateTime.GetStringTime(_AllowTransfer.Date);
            cmbDriveTpye.SelectedValue = _AllowTransfer.DriveType;

            LoadLodingService();
            LoadConveyService();
            LoadOtherService();
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

               JSCAllowTransfer AllowTransfer = new JSCAllowTransfer(AllowTransferCode);
               AllowTransfer.ContractCode = ContractCode;
               AllowTransfer.Date = JDateTime.GregorianDate(txtDate.Text, txtTime.Text.Replace('.', ':'));
               AllowTransfer.Description = txtDesc.Text;
               AllowTransfer.DriverName = txtDriverName.Text;
               AllowTransfer.DriveType = (Convert.ToInt32(cmbDriveTpye.SelectedValue));
               AllowTransfer.PelakNo = txtPelakNo.Text;
               AllowTransfer.Serial = txtSerial.Text;
               if (this.State == ClassLibrary.JFormState.Insert)
               {
                   if (AllowTransfer.Insert() > 0)
                   {
                       AllowTransferCode = AllowTransfer.Code;
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
                   if (AllowTransfer.Update())
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
           private void btnAddLoadingService_Click(object sender, EventArgs e)
           {
               btnSave.PerformClick();
               if (AllowTransferCode == 0)
                   return;
               JLoadingForm form = new JLoadingForm(ContractCode ,"StoreComplex.JSCAllowTransfer", AllowTransferCode, txtSerial.Text, JLoadingServiceType.Loading, 0);
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
               JLoadingForm form = new JLoadingForm(ContractCode, "StoreComplex.JSCAllowTransfer", AllowTransferCode, txtSerial.Text, JLoadingServiceType.Loading, Code);
               if (form.ShowDialog() == DialogResult.OK)
               {
                   LoadLodingService();
               }
           }

           private void btnAddConveyService_Click(object sender, EventArgs e)
           {
               btnSave.PerformClick();
               if (AllowTransferCode == 0)
                   return;
               JConveyForm form = new JConveyForm(ContractCode, "StoreComplex.JSCAllowTransfer", AllowTransferCode, txtSerial.Text, 0);
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
               JConveyForm form = new JConveyForm(ContractCode, "StoreComplex.JSCAllowTransfer", AllowTransferCode, txtSerial.Text, Code);
               if (form.ShowDialog() == DialogResult.OK)
               {
                   LoadConveyService();
               }
           }

           private void btnAddService3_Click(object sender, EventArgs e)
           {
               btnSave.PerformClick();
               if (AllowTransferCode == 0)
                   return;
               JOtherServiceForm form = new JOtherServiceForm(ContractCode, "StoreComplex.JSCAllowTransfer", AllowTransferCode, 0);
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
               JOtherServiceForm form = new JOtherServiceForm(ContractCode, "StoreComplex.JSCAllowTransfer", AllowTransferCode, Code);
               if (form.ShowDialog() == DialogResult.OK)
               {
                   LoadOtherService();
               }
           }
    }
}
