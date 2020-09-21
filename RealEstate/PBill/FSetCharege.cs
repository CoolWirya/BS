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
    public partial class FSetCharege : Globals.JBaseForm
    {
        JChargeBuild Charge;
      

        public FSetCharege(JChargeBuild CurChar)
        {
            InitializeComponent();
            Charge = CurChar;
            txtYearbill.Text = Charge.PeriodCharge.ToString();
            txtfirst.Text = Charge.FirstPeriodCharges.ToString();
            JUnitBuild Build = new JUnitBuild(Charge.CodeUnitBuild);
            this.Text =" واحد تجاری "+ Build.Number.ToString();
            txtBadahi.Text = Charge.GetMaliBuild(Build.MarketCode,Build.Tafsili2);
            txtTafsili.Text = Build.Tafsili2.ToString();

            txtCureentbill.Text = Charge.CurrentCharge.ToString();
            txthint.Text = Charge.Hint;
            txtYaraneh.Text = Charge.Yaraneh.ToString();

        }

        private void FSetCharege_Load(object sender, EventArgs e)
        {

            //JPrintableGhabz PrintedGhabz = new JPrintableGhabz();
            //grdGhabz.DataSource = PrintedGhabz.GetListOfprintedCharch("And[dbo].[RePrintedCharge].[CodeUnitBuild]=" + Charge.CodeUnitBuild);
            //grdBedahi.DataSource = PrintedGhabz.GetListOfprintedCharch("And [dbo].[RePrintedCharge].[CodeUnitBuild]=" + Charge.CodeUnitBuild + "  And  [dbo].[RePrintedCharge].[StatusPay]='False'");
            grdGhabz.DataSource = Charge.GetMaliInformation(Charge.CodeMarket);
        }

        private void BtnChangeCharge_Click(object sender, EventArgs e)
        {
            try
            {
              
                Charge.CurrentCharge = txtCureentbill.MoneyValue;
                Charge.PeriodCharge = txtYearbill.MoneyValue;
                Charge.FirstPeriodCharges = txtfirst.MoneyValue;
                Charge.Yaraneh = txtYaraneh.IntValue;
                Charge.Yaraneh = txtYaraneh.IntValue;
                Charge.Hint = txthint.Text;

             
                int mali = Charge.Code;

                if (Charge.PeriodCharge >= Charge.CurrentCharge)
                {
                    if (!Charge.Save())
                        JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                    else
                        JMessages.Information("اطلاعات ثبت شد", "توجه");
                }
                else
                    JMessages.Warning("مبلغ شارژ قابل پرداخت از شارژ سالانه بيشتر وارد شده ست", "اشتباه در ورود اطلاعات");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);

            }
        }

        private void txtYearbill_TextChanged(object sender, EventArgs e)
        {
            txtCureentbill.Text = txtYearbill.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void grdGhabz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

}

