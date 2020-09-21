using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legal;
using ClassLibrary;

namespace StoreComplex
{
    public partial class JServiceForm : Globals.JBaseForm
    {
        int ContractCode;
        int ServiceCode;
        string ClassName;
        int ObjectCode;
        int Code = 0;
        public JServiceForm(int contractCode, int serviceCode)
        {
            InitializeComponent();
            ContractCode = contractCode;
            ServiceCode = serviceCode;
            ShowData();
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
            JContractdefine contractType = new JContractdefine(contract.Type);
            txtContractType.Text = contractType.Title;
            txtDate.Date = contract.Date;
            txtCode.Text = contract.SCCode;
            txtArea.Text = contract.SCArea.ToString();
            txtPrice.Text = contract.TotalPrice.ToString();

            if (this.State == JFormState.Insert)
            {
                services.SetComboBox(cmbServiceType, 0);
                txtDate.Date = (new JDataBase()).GetCurrentDateTime();
            }
            else
                if (this.State == JFormState.Update)
                {
                    JSCService service = new JSCService();
                    service.GetData(ServiceCode);
                    txtDate.Date = service.Date;
                    services.SetComboBox(cmbServiceType, service.ServiceType);
                    txtDesc.Text = service.Description;
                    txtServiceCost.Text = service.ServiceCost.ToString();
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDate.Date == DateTime.MinValue)
            {
                ClassLibrary.JMessages.Error("لطفا تاریخ را وارد کنید.", "");
                return;
            }
            if (cmbServiceType.SelectedValue==null)
            {
                ClassLibrary.JMessages.Error("لطفا نوع سرویس را انتخاب کنید.", "");
                return;
            }

            JSCService service = new JSCService();
            service.ContractCode = ContractCode;
            service.Date = txtDate.Date;
            service.Description = txtDesc.Text;
            service.ServiceType = Convert.ToInt32(cmbServiceType.SelectedValue);
            service.ServiceCost = txtServiceCost.DecimalValue;
            bool error = false;
            if (this.State == JFormState.Insert)
            {
                if (service.Insert() > 0)
                {
                    btnSave.Enabled = false;
                    this.State = JFormState.Update;
                }
                else
                    error = true;
            }
            else if (this.State == JFormState.Update)
            {
                if (service.Update())
                {
                    btnSave.Enabled = false;
                }
                else
                    error = true;
            }
            if (error)
            {
                JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "خطا");
            }
        }

        private void btnCAncel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtServiceCost_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
