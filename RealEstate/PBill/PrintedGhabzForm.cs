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
    public partial class PrintedGhabzForm : JBaseForm
    {
      
        public JPrintableGhabz _prn;
        private void Fillcombo()
        {
            // پر كردن نام مجتمع / بازارها
            CmbComplex.DisplayMember = estMarket.Title.ToString();
            CmbComplex.ValueMember = estMarket.Code.ToString();
            CmbComplex.DataSource = jMarkets.GetDataTable(0);
        }
        public PrintedGhabzForm(JPrintableGhabz Prn)
        {
            InitializeComponent();
            _prn = Prn;
            Fillcombo();
            if (_prn.Code > 0)
            {
                State = JFormState.Update;
                Display();
             
               

            }
            else
            {
                _prn = new JPrintableGhabz();
                State = JFormState.Insert;
            }
          

        }
        public void Display()
        {
          
            txtCode.Text = _prn.Code.ToString();
            txtCodeghabz.Text = _prn.CodeGhabz;
            txtmohlat.Text = JDateTime.FarsiDate(_prn.PaymentDeadline);
            txtmonth.Text=txtmonth.Text;
            txtpriviuosdebt.Text=_prn.PreviousDebt.ToString();
            txtdebt.Text=_prn.debt.ToString();
            txtyaraneh.Text = _prn.Yaraneh.ToString();
            txtmonth.Text = _prn.Month.ToString();
            CmbComplex.SelectedValue = Convert.ToInt32(_prn.CodeMarket);
            JUnitBuild Build = new JUnitBuild(_prn.CodeUnitBuild);
            txtBuild.Text = Build.Plaque;
            if (State == JFormState.Update)
            {
                txtBuild.Enabled = false;
                CmbComplex.Enabled = false;
                txtmonth.Enabled = false;
                txtBuild.Enabled = false;


            }
            
            
        }
        private void PrintedGhabzForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!validtion())
                //{
                //    return;
                //}
               

                if (State == JFormState.Insert)
                {

                    _prn.PaymentDeadline = txtmohlat.Date;
                    _prn.debt =(Int32) txtdebt.MoneyValue;

                    _prn.Yaraneh = (Int32)txtyaraneh.MoneyValue;
                    _prn.PreviousDebt = (Int32)txtpriviuosdebt.MoneyValue;
                    _prn.Month = (Int32)txtmonth.MoneyValue;
                    int code = _prn.insert();
                    if (code != 0)
                    {

                        JMessages.Error("Insert Succefully", "هشدار");
                        this.Close();
                    }
                    else
                    {
                        JMessages.Error("Insert Not Succefuly", "هشدار");
                    }
                }
                else
                {
                    _prn.PaymentDeadline = txtmohlat.Date;
                    _prn.debt = (Int32)txtdebt.MoneyValue;

                
                    if (_prn.Update())
                    {
                        _prn.PaymentDeadline = txtmohlat.Date;
                        _prn.debt = txtdebt.IntValue;
                        _prn.CodeUnitBuild = Convert.ToInt32(txtBuild.Text);
                        _prn.Yaraneh = txtyaraneh.IntValue;
                        _prn.PreviousDebt = txtpriviuosdebt.IntValue;
                         JMessages.Error("Update Succefully", "هشدار");
                        this.Close();

                    }
                    else
                    {
                        JMessages.Error("Update Not Succefuly", "هشدار");
                    }
                }
            }
            catch (Exception Ex)
            {
                JMessages.Error(Ex.Message, "هشدار");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
