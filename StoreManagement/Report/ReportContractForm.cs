using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreManagement
{
    public partial class JReportContractForm : JBaseForm
    {
        DataTable _DtReport;

        public JReportContractForm()
        {
            InitializeComponent();
        }

        private string WhereReoprt()
        {
            string Str = "";

            if (txtDate.Date != DateTime.MinValue)
                Str = Str + " And P.PayDate >= Cast('" + txtDate.Date.ToShortDateString() + "' as date)";
            if (txtDate1.Date != DateTime.MinValue)
                Str = Str + " And P.PayDate <= Cast('" + txtDate1.Date.ToShortDateString() + "' as date)";

            if (jucPersonBuyer.SelectedCode != 0)
                Str = Str + " And  LegPersonContract.Type=9 And LegPersonContract.PersonCode = " + jucPersonBuyer.SelectedCode;
            if (jucPersonSeller.SelectedCode != 0)
                Str = Str + " And  LegPersonContract.Type=7 And LegPersonContract.PersonCode=" + jucPersonSeller.SelectedCode;
            return Str;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            _DtReport = JPaymentContracts.Find(WhereReoprt());
            jJanusGridReport.DataSource = _DtReport;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtinfo = new DataTable();
                dtinfo.Columns.Add("Year");
                dtinfo.Columns.Add("Season");
                dtinfo.Columns.Add("TotalPriceWord");
                dtinfo.Columns.Add("SumTotalPrice", typeof(Decimal));
                dtinfo.Columns.Add("SumTax" ,typeof(Decimal));
                dtinfo.Columns.Add("SumDuty", typeof(Decimal));
                dtinfo.Columns.Add("TotalPriceTax", typeof(Decimal));
                dtinfo.Columns.Add("TotalPay", typeof(Decimal));
                dtinfo.Columns.Add("TotalTaxMaksore", typeof(Decimal));

                string str = "";
                string Year = "";
                string TotalPriceWord = "";

                if (txtDate.Date != DateTime.MinValue)
                    Year = (JDateTime.FarsiDate(txtDate.Date).Split('/'))[0];

                if (chkSpring.Checked)
                    str = str + " بهار - ";
                if (chkete.Checked)
                    str = str + " تابستان - ";
                if (chkAutomn.Checked)
                    str = str + " پاییز - ";
                if (chkHiver.Checked)
                    str = str + " زمستان - ";

                decimal SumTax = 0;
                decimal Sum = 0;
                decimal Tax = 0;
                decimal Duty = 0;
                decimal TotalPay = 0;
                decimal TotalTaxMaksore = 0;
                foreach (DataRow dr in _DtReport.Rows)
                {
                    if (dr["Pay"].ToString() != "")
                        TotalPay = TotalPay + Convert.ToDecimal(dr["Pay"]);
                    if (dr["TotalPrice"].ToString() != "")
                        Sum = Sum + Convert.ToDecimal(dr["TotalPrice"]);
                    if (dr["Tax"].ToString() != "")
                        Tax = Tax + Convert.ToDecimal(dr["Tax"]);
                    if (dr["Duty"].ToString() != "")
                        Duty = Duty + Convert.ToDecimal(dr["Duty"]);
                    if (dr["TaxMaksore"].ToString() != "")
                        TotalTaxMaksore = TotalTaxMaksore + Convert.ToDecimal(dr["TaxMaksore"]);
                    //if (dr["TotalPriceTax"].ToString() != "")
                    SumTax = SumTax + Convert.ToDecimal(dr["Pay"]) + Convert.ToDecimal(dr["Tax"]) + Convert.ToDecimal(dr["Duty"]);
                }
                JGeneral tmp = new JGeneral();
                TotalPriceWord = tmp.GetStringNumber((SumTax).ToString());

                dtinfo.Rows.Add(Year, str, TotalPriceWord, Sum, Tax, Duty, SumTax, TotalPay, TotalTaxMaksore);

                JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.BillGoods.GetHashCode());
                DRF.Add(_DtReport);
                dtinfo.TableName = "اطلاعات پایه";
                DRF.Add(dtinfo);
                DRF.ShowDialog();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
    }
}
