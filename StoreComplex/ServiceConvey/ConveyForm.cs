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
    public partial class JConveyForm : Globals.JBaseForm 
    {
        string ClassName;
        int ObjectCode;
        int Code = 0;
        int contractCode = 0;
        JConveyService _Service;
        public JConveyForm(int pContractCode, string pClassName, int pObjectCode, string Serial, int pCode)
        {
            InitializeComponent();
            ClassName = pClassName;
            ObjectCode = pObjectCode;
            contractCode = pContractCode;
            if (pCode > 0)
            {
                State = ClassLibrary.JFormState.Update;
                Code = pCode;
                _Service = new JConveyService(Code);
                txtDate.Date = _Service.Date;
                txtTime.Text = JDateTime.GetStringTime(_Service.Date);
                txtCost.Text = _Service.Cost.ToString();
                txtSerial.Text = _Service.Serial;
                cmbDriveTpye.SelectedValue = _Service.DriveType;
                txtSerial.Text = Serial;
                JVanTypes types = new JVanTypes();
                cmbDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
                types.SetComboBox(cmbDriveTpye, _Service.DriveType);
                txtPelakNo.Text = _Service.PelakNo;
                txtDriverName.Text = _Service.DriverName;
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
                    txtPelakNo.Text = recipt.PelakNo;
                    txtDriverName.Text = recipt.DriverName;
                    JVanTypes types = new JVanTypes();
                    cmbDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
                    types.SetComboBox(cmbDriveTpye, recipt.DriveType);
                }
                if (ClassName == typeof(JSCTransfer).FullName)
                {
                    JSCTransfer recipt = new JSCTransfer(ObjectCode);
                    txtSerial.Text = recipt.Serial;
                    txtDate.Date = recipt.Date;
                    txtTime.Text = JDateTime.GetStringTime(recipt.Date);
                    txtPelakNo.Text = recipt.PelakNo;
                    txtDriverName.Text = recipt.DriverName;
                    JVanTypes types = new JVanTypes();
                    cmbDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
                    types.SetComboBox(cmbDriveTpye, recipt.DriveType);
                }
                if (ClassName == typeof(JSCAllowTransfer).FullName)
                {
                    JSCAllowTransfer recipt = new JSCAllowTransfer(ObjectCode);
                    txtSerial.Text = recipt.Serial;
                    txtDate.Date = recipt.Date;
                    txtTime.Text = JDateTime.GetStringTime(recipt.Date);
                    txtPelakNo.Text = recipt.PelakNo;
                    txtDriverName.Text = recipt.DriverName;
                    JVanTypes types = new JVanTypes();
                    cmbDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
                    types.SetComboBox(cmbDriveTpye, recipt.DriveType);
                }
            }
        }

        private void LoadComboBox()
        {
            JVanTypes types = new JVanTypes();
            cmbDriveTpye.BaseCode = JBaseDefine.SCVanTypes;
            types.SetComboBox(cmbDriveTpye, _Service.DriveType);
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
          
            JConveyService _Service = new JConveyService(Code);
            _Service.ContractCode = contractCode;
            _Service.ClassName = ClassName;
            _Service.Cost = txtCost.DecimalValue;
            _Service.Date = JDateTime.GregorianDate(txtDate.Text, txtTime.Text.Replace('.', ':'));
            _Service.DriveType = (Convert.ToInt32(cmbDriveTpye.SelectedValue));
            _Service.ObjectCode = ObjectCode;
            _Service.Serial = txtSerial.Text;
            _Service.DriverName = txtDriverName.Text;
            _Service.PelakNo = txtPelakNo.Text;
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
