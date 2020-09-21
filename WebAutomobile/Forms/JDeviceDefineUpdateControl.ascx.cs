using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AUTOMOBILE.Device;
using System.ComponentModel;

namespace WebAutomobile.Forms
{
    public partial class JDeviceDefineUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadDeviceType();
            _SetForm();
        }

        public void LoadDeviceType()
        {
            cmbDeviceType.Items.Clear();
            var items = new BindingList<KeyValuePair<string, int>>();
            JDeviceType[] e = (JDeviceType[])(Enum.GetValues(typeof(JDeviceType)));
            for (int i = 0; i < e.Length; i++)
            {
                KeyValuePair<string, int> Obj = new KeyValuePair<string, int>
                    (ClassLibrary.JLanguages._Text(e[i].ToString().Replace("_", " ")).ToString(),
                    e[i].GetHashCode());
                items.Add(Obj);
            }
            cmbDeviceType.DataSource = items;
            cmbDeviceType.DataValueField = "value";
            cmbDeviceType.DataTextField = "key";
            cmbDeviceType.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                JDevice Device = new JDevice();
                Device.GetData(Code);
                txtID.Text = Device.ID;
                txtMacNumber.Text = Device.MacAddress;
                txtSimCardNumber.Text = Device.Tel;
                txtIMEI.Text = Device.IMEI;
                txtBarCode.Text = Device.Barcode;
                txtModel.Text = Device.Model;
                cmbDeviceType.SelectedValue = Device.Type.ToString();
            }
        }

        public bool Save()
        {
            JDevice Device = new JDevice();
            Device.Code = Code;
            Device.Type = Convert.ToInt32(cmbDeviceType.SelectedValue);
            Device.Tel = txtSimCardNumber.Text.Trim();
            Device.MacAddress = txtMacNumber.Text.Trim();
            Device.ID = txtID.Text.Trim();
            Device.IMEI = txtIMEI.Text.Trim();
            Device.Barcode = txtBarCode.Text.Trim();
            Device.Model = txtModel.Text.Trim();
            if (Code > 0)
                return Device.Update();
            else
                return Device.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            JDevice Device = new JDevice();
            Device.Code = Code;
            if (Device.Delete())
                WebClassLibrary.JWebManager.RunClientScript("alert('حذف با موفقیت انجام شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('ابتدا باید اتوبوس، نصب یا فک ثبت شده مربوط به این دستگاه حذف شود');", "ConfirmDialog");
        }
    }
}