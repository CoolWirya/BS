using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreComplex
{
    public partial class JLoadingForm : Globals.JBaseForm
    {
        string ClassName;
        int ObjectCode;
        JLoadingServiceType LoadingType;
        int Code = 0;
        int contractCode = 0;
        public JLoadingForm(int pContractCode, string pClassName, int pObjectCode, string Serial, JLoadingServiceType pLoadingType, int pCode)
        {
            InitializeComponent();
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            LoadingType = pLoadingType;
            contractCode = pContractCode;
            cmbLocation.DataSource = JSCStorages.GetDatatable(0);
            cmbLocation.DisplayMember = "Title";
            cmbLocation.ValueMember = "Code";
            if (pCode > 0)
            {
                State = ClassLibrary.JFormState.Update;
                Code = pCode;
                JLoadingService service = new JLoadingService(Code);
                txtDate.Date = service.Date;
                txtTime.Text = JDateTime.GetStringTime(service.Date);
                txtCost.Text = service.Cost.ToString();
                txtSerial.Text = service.Serial;
                txtWorkerCount.Text = service.WorkerCount.ToString();
                txtWorkerDuration.Text = service.WorkerDuration.ToString();
                cmbLocation.SelectedValue = service.Location;
                txtSerial.Text = Serial;
            }
            else
            {
                State = JFormState.Insert;
                if (ClassName == typeof(JSCReceipt).FullName)
                {
                    JSCReceipt recipt = new JSCReceipt(ObjectCode);
                    txtSerial.Text = recipt.Serial;
                    txtDate.Date = recipt.Date;
                    txtTime.Text = JDateTime.GetStringTime(recipt.Date);
                }
                if (ClassName == typeof(JSCTransfer).FullName)
                {
                    JSCTransfer recipt = new JSCTransfer(ObjectCode);
                    txtSerial.Text = recipt.Serial;
                    txtDate.Date = recipt.Date;
                    txtTime.Text = JDateTime.GetStringTime(recipt.Date);
                }
                if (ClassName == typeof(JSCAllowTransfer).FullName)
                {
                    JSCAllowTransfer recipt = new JSCAllowTransfer(ObjectCode);
                    txtSerial.Text = recipt.Serial;
                    txtDate.Date = recipt.Date;
                    txtTime.Text = JDateTime.GetStringTime(recipt.Date);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtCost.DecimalValue == 0)
            {
                JMessages.Error("لطفاً مبلغ را وارد کنید.", "خطا");
                return;
            }

            if (txtDate.Date == DateTime.MinValue)
            {
                ClassLibrary.JMessages.Error("لطفا تاریخ را وارد کنید.", "");
                return;
            }
            JLoadingService service = new JLoadingService(Code);
            service.ClassName = ClassName;
            service.Cost = txtCost.DecimalValue;
            service.ContractCode = contractCode;
            service.Date = JDateTime.GregorianDate(txtDate.Text, txtTime.Text.Replace('.', ':'));
            service.Location = (int)cmbLocation.SelectedValue;
            service.ObjectCode = ObjectCode;
            service.Serial = txtSerial.Text;
            service.Type = LoadingType.GetHashCode();
            service.WorkerCount = txtWorkerCount.IntValue;
            service.WorkerDuration = txtWorkerDuration.IntValue;
            if (State == JFormState.Insert)
            {
                if (service.Insert() > 0)
                    DialogResult = DialogResult.OK;
            }
            if (State == JFormState.Update)
            {
                if (service.Update())
                    DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
