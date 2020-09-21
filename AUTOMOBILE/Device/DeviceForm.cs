using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AUTOMOBILE.Device
{
    public partial class DeviceForm : ClassLibrary.JBaseForm
    {
        private int Code;
        public DeviceForm()
        {
            InitializeComponent();
            State = ClassLibrary.JFormState.Insert;
            SetDefault();
        }

        public void Delete()
        {
            if (MessageBox.Show("آیا تمایل دارید مورد انتخاب شده حذف گردد", "اخطار!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                JDevice objAutoDefine = new JDevice();
                objAutoDefine.Code = Code;
                if (objAutoDefine.Delete())
                {

                    ClassLibrary.JSystem.Nodes.Delete(ClassLibrary.JSystem.Nodes.CurrentNode);
                    Close();
                }
                else
                {
                    MessageBox.Show("پردازش با خطا مواجه شد");
                }                
            }
            else
            {
                Close();
            }
        }
      

        public DeviceForm(int PCode)
        {
            InitializeComponent();
            Code = PCode;
            SetDefault();
            Load1(PCode);
            State = ClassLibrary.JFormState.Update;
        }

        private void Load1(int pCode)
        {
            JDevice Auto = new JDevice();
            Auto.GetData(pCode);
            txtID.Text = Auto.ID;
            txtMac.Text = Auto.MacAddress;
            txtTel.Text = Auto.Tel;
            txtIMEI.Text = Auto.IMEI;
            cmbType.SelectedValue = Auto.Type;

        }

        private void _setCmbType()
        {
            cmbType.Items.Clear();
            var items = new BindingList<KeyValuePair<string, int>>();
            JDeviceType[] e = (JDeviceType[])(Enum.GetValues(typeof(JDeviceType)));
            for (int i = 0; i < e.Length; i++)
            {
                KeyValuePair<string, int> Obj = new KeyValuePair<string, int>
                    (ClassLibrary.JLanguages._Text(e[i].ToString().Replace("_", " ")).ToString(),
                    e[i].GetHashCode());
                items.Add(Obj);
            }
            cmbType.DataSource = items;
            cmbType.ValueMember = "value";
            cmbType.DisplayMember = "key";
        }

        private void SetData(JDevice Auto)
        {
            Auto.Code = Code;
            Auto.Type = (int)cmbType.SelectedValue;
            Auto.Tel = txtTel.Text.Trim();
            Auto.MacAddress = txtMac.Text.Trim();
            Auto.ID = txtID.Text.Trim();
            Auto.IMEI = txtIMEI.Text.Trim();
        }


        private void SetDefault()
        {
            _setCmbType();
        }

        private bool Validation()
        {
            bool result = true;

            if (cmbType.SelectedValue == null)
            {
                MessageBox.Show("نوع را مشخص کنید");
                cmbType.Focus();
                result = false;
            }

            if (result && (txtTel.Text == null || txtTel.Text.Trim() == string.Empty))
            {
                MessageBox.Show("تلفن را مشخص کنید");
                txtTel.Focus();
                result = false;
            }

            if (result && (txtID.Text == null || txtID.Text.Trim() == string.Empty))
            {
                MessageBox.Show("آی دی را مشخص کنید");
                txtID.Focus();
                result = false;
            }

            if (result && (txtMac.Text == null || txtMac.Text.Trim() == string.Empty))
            {
                MessageBox.Show("مک آدرس را مشخص کنید");
                txtMac.Focus();
                result = false;
            }

            return result;
        }
       

        private int Save()
        {            
            JDevice objAutoDefine = new JDevice();
            SetData(objAutoDefine);
            if (State == ClassLibrary.JFormState.Insert)
                Code = objAutoDefine.Insert();
            else
                if (State == ClassLibrary.JFormState.Update)
                    objAutoDefine.Update();
            State = ClassLibrary.JFormState.Update;

            ClassLibrary.JSystem.Nodes.RefreshDataTableButton();
            return Code;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Save();
                Close();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                Save();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}
