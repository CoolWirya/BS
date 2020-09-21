using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legal;

namespace StoreComplex
{
    public partial class JBillForm : Globals.JBaseForm
    {
        int ContractCode;
        public JBillForm(int contractCode)
        {
            InitializeComponent();
            ContractCode = contractCode;
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
            txtCode.Text = contract.SCCode;
            txtArea.Text = contract.SCArea.ToString();
            txtPrice.Text = contract.TotalPrice.ToString();
            txtFrom.Date = DateTime.Today;
            txtTo.Date = DateTime.Today.AddMonths(1);
        }
        private void GetData()
        {
            jJanusGrid1.bind(JSCContract.GetBill(ContractCode, txtFrom.Date , txtTo.Date));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetData();
        }

    }
}
