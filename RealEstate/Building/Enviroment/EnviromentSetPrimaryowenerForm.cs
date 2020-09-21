using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace RealEstate
{
    public partial class EnviromentSetPrimaryowenerForm :Globals.JBaseForm
    {
        private int PrimayOwner{get;set;}
        private int Person { get; set; }
        private JSetDefultEnviroment DefEnvi = new JSetDefultEnviroment();

        public EnviromentSetPrimaryowenerForm()
        {
            InitializeComponent();
            fillComboBox();
        }

        private void _ٍEnviromentSetPrimaryowenerForm_Load(object sender, EventArgs e)
        {
            
           
        }

        private void fillComboBox()
        {
            cmbMarket.DisplayMember = estMarket.Title.ToString();
            cmbMarket.ValueMember = estMarket.Code.ToString();
            cmbMarket.DataSource = jMarkets.GetDataTable(0);
        }

        public void ShowForm()
        {
            if (JPermission.CheckPermission("RealEstate.EnviromentSetPrimaryowenerForm.ShowForm"))
                ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!DefEnvi.GetData(Convert.ToInt32(cmbMarket.SelectedValue)))
            {
                if (DefEnvi.Person != 0 && DefEnvi.PrimaryOwnerPerson != 0)
                {
                    DefEnvi = new JSetDefultEnviroment();
                    DefEnvi.MarketCode = Convert.ToInt32(cmbMarket.SelectedValue);
                    DefEnvi.Person = Person;
                    DefEnvi.PrimaryOwnerPerson = PrimayOwner;
                    DefEnvi.Insert();
                }
                else
                {
                    JMessages.Message("فيلدها خالي مي باشد", "نكته", JMessageType.Warning);
                }
            }
            else
             {
                if (DefEnvi.Code != 0 && Person != 0 && PrimayOwner != 0)
                {
                     DefEnvi.MarketCode = Convert.ToInt32(cmbMarket.SelectedValue);
                     DefEnvi.Person = Person;
                     DefEnvi.PrimaryOwnerPerson = PrimayOwner;
                     DefEnvi.Update();
                }
                else
                {
                    JMessages.Message("فيلدها خالي مي باشد", "نكته", JMessageType.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JFindPersonForm JFPF = new JFindPersonForm();
            JFPF.ShowDialog();
            if (JFPF.SelectedPerson != null)
            {
                Person = JFPF.SelectedPerson.Code;
                JPerson per = new JPerson(Person);
                txtNamyandeh.Text = per.Name +" "+ per.Fam;
            }
        }

        private void BtnPrimaryOwner_Click(object sender, EventArgs e)
        {
            JFindPersonForm JFPF = new JFindPersonForm();
            JFPF.ShowDialog();
            if (JFPF.SelectedPerson != null)
            {
                PrimayOwner = JFPF.SelectedPerson.Code;
                JPerson per = new JPerson(PrimayOwner);
                txtPrimaryOwner.Text = per.Name+ " " + per.Fam;
            }
        }

        private void cmbMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefEnvi.GetData(Convert.ToInt32(cmbMarket.SelectedValue));
            JPerson Per = new JPerson();
            Per.getData(DefEnvi.Person);
            txtNamyandeh.Text = Per.Name + " " + Per.Fam;
            Per.getData(DefEnvi.PrimaryOwnerPerson);
            txtPrimaryOwner.Text = Per.Name + " " + Per.Fam;
        }

       
    }
}
