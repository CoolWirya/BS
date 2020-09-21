using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legal.Contract.Forms
{
    public partial class ContractFormsList : ClassLibrary.JBaseForm
    {

        private JContractForms _ContractForms;
        public JContractForms ContractForms
        {
            get
            {
                return _ContractForms;
            }
            set
            {
                _ContractForms = value;
                SetContractButton();
            }
        }
        public ContractFormsList()
        {
            InitializeComponent();
        }

        

        private void SetContractButton()
        {
            int TopHight = 5;
            int Count = 0;
            foreach (JBaseContractForm BCF in _ContractForms.Forms)
            {
                Button B = new Button();
                B.Parent = this;
                this.Controls.Add(B);
                B.Text = BCF.Name;
                B.Left = 5;
                B.Top = TopHight;
                TopHight = TopHight + B.Height + 5;
                B.Tag = Count;
                Count++;
                B.Click += new EventHandler(ShowFormClick);
            }
        }

        private void ShowFormClick(object sender, EventArgs e)
        {
            _ContractForms.ShowForm((int)((Button)sender).Tag);
        }

        private void ContractFormsList_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
