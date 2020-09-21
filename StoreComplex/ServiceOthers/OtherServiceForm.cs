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

namespace StoreComplex
{
    public partial class JOtherServiceForm : Globals.JBaseForm
    {
        string ClassName;
        int ObjectCode;
        int Code = 0;
        int ContractCode; 
        JOtherService _Service;

        public JOtherServiceForm(int pContractCode, string pClassName, int pObjectCode, int pCode)
        {
            InitializeComponent();
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            ContractCode = pContractCode;
            if (pCode > 0)
            {
                State = ClassLibrary.JFormState.Update;
                Code = pCode;
                _Service = new JOtherService(Code);
                txtDate.Date = _Service.Date;
                txtSerial.Text = _Service.Serial;
                txtTime.Text = JDateTime.GetStringTime(_Service.Date);
                txtCost.Text = _Service.ServiceCost.ToString();
                txtDesc.Text = _Service.Description;
                txtSerial.Text = _Service.Serial;
                cmbDriveTpye.SelectedValue = _Service.ServiceType;
                txtSerial.Text = _Service.Serial;
                JServiceTypes types = new JServiceTypes();
                cmbDriveTpye.BaseCode = JBaseDefine.SCServices;
                types.SetComboBox(cmbDriveTpye, _Service.ServiceType);
            }
            else
            {
                State = JFormState.Insert;
                cmbDriveTpye.SelectedValue = -1;
                if (ClassName == typeof(JSCReceipt).FullName)
                {
                    JSCReceipt recipt = new JSCReceipt(ObjectCode);
                    txtSerial.Text = recipt.Serial;
                    txtDate.Date = recipt.Date;
                    txtTime.Text = JDateTime.GetStringTime(recipt.Date);
                    JServiceTypes types = new JServiceTypes();
                    cmbDriveTpye.BaseCode = JBaseDefine.SCServices;
                    types.SetComboBox(cmbDriveTpye, recipt.DriveType);
                }
                if (ClassName == typeof(JSCTransfer).FullName)
                {
                    JSCTransfer recipt = new JSCTransfer(ObjectCode);
                    txtSerial.Text = recipt.Serial;
                    txtDate.Date = recipt.Date;
                    txtTime.Text = JDateTime.GetStringTime(recipt.Date);
                    JServiceTypes types = new JServiceTypes();
                    cmbDriveTpye.BaseCode = JBaseDefine.SCServices;
                    types.SetComboBox(cmbDriveTpye, recipt.DriveType);
                }
                if (ClassName == typeof(JSCAllowTransfer).FullName)
                {
                    JSCAllowTransfer recipt = new JSCAllowTransfer(ObjectCode);
                    txtSerial.Text = recipt.Serial;
                    txtDate.Date = recipt.Date;
                    txtTime.Text = JDateTime.GetStringTime(recipt.Date);
                    JServiceTypes types = new JServiceTypes();
                    cmbDriveTpye.BaseCode = JBaseDefine.SCServices;
                    types.SetComboBox(cmbDriveTpye, recipt.DriveType);
                }
            }
        }

        private void LoadComboBox()
        {
            JServiceTypes types = new JServiceTypes();
            cmbDriveTpye.BaseCode = JBaseDefine.SCServices;
            types.SetComboBox(cmbDriveTpye, _Service.ServiceType);
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

            JOtherService _Service = new JOtherService(Code);
            _Service.ClassName = ClassName;
            _Service.ServiceCost = txtCost.DecimalValue;
            _Service.Date = JDateTime.GregorianDate(txtDate.Text, txtTime.Text.Replace('.', ':'));
            _Service.ServiceType = (Convert.ToInt32(cmbDriveTpye.SelectedValue));
            _Service.ObjectCode = ObjectCode;
            _Service.Serial = txtSerial.Text;
            _Service.Description = txtDesc.Text;
            _Service.ContractCode = ContractCode;
            if (State == JFormState.Insert)
            {
                if (_Service.Insert() > 0)
                    DialogResult = DialogResult.OK;
            }
            if (State == JFormState.Update)
            {
                if (_Service.Update())
                    DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
