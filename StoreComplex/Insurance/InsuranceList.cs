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
    public partial class JInsuranceList : Globals.JBaseForm
    {
        int ContractCode;
        public JInsuranceList(int pContractCode)
        {
            InitializeComponent();
            ContractCode = pContractCode;
            grdInsurance.DataSource = JInsurances.GetDatatable(ContractCode,0);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            JInsurance insure = new JInsurance();
            if(insure.ShowDialog(ContractCode, 0))
                grdInsurance.DataSource = JInsurances.GetDatatable(ContractCode, 0);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(grdInsurance.SelectedRow["Code"]);
            JInsurance insure = new JInsurance(code);
            if (insure.ShowDialog(ContractCode, code))
                grdInsurance.DataSource = JInsurances.GetDatatable(ContractCode,0);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (JMessages.Question("آیا میخواهید ردیف مورد نظر حذف شود؟", "حذف بیمه") == DialogResult.Yes)
            {
                int code = Convert.ToInt32(grdInsurance.SelectedRow["Code"]);
                JInsurance insure = new JInsurance(code);
                if (insure.Delete())
                    grdInsurance.DataSource = JInsurances.GetDatatable(ContractCode, 0);
            }
        }
    }
}
