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
    public partial class JReportForm : ClassLibrary.JBaseForm
    {

        DataTable _DtReport;
        public JReportForm()
        {
            InitializeComponent();
        }
        
        private string WhereReoprt()
        {
            string Str = "";

            if (Convert.ToInt32(cmbGroup.SelectedValue) != -1)
                Str = Str + " And BillType = " + cmbGroup.SelectedValue;
            if (txtSerial.Text != "")
                Str = Str + " And Serial >= " + txtSerial.Text;
            if (txtSerial1.Text != "")
                Str = Str + " And Serial <= " + txtSerial1.Text;

            if (txtTankhah.Text != "")
                Str = Str + " And TankhahCode >= " + txtTankhah.Text;
            if (txtTankhah1.Text != "")
                Str = Str + " And TankhahCode <= " + txtTankhah1.Text;

            if (txtDoc.Text != "")
                Str = Str + " And DocNumber >= " + txtDoc.Text;
            if (txtDoc1.Text != "")
                Str = Str + " And DocNumber <= " + txtDoc1.Text;

            if(txtAnbar.Text != "")
                Str = Str + " And S.Number >= " + txtAnbar.Text;
            if (txtAnbar1.Text != "")
                Str = Str + " And S.Number <= " + txtAnbar1.Text;

            if (txtDate.Date != DateTime.MinValue)
                Str = Str + " And Cast(RegDate as date) >= Cast('" + txtDate.Date.ToShortDateString() + "' as date)";
            if (txtDate1.Date != DateTime.MinValue)
                Str = Str + " And Cast(RegDate as date) <= Cast('" + txtDate1.Date.ToShortDateString() + "' as date)";

            if (jucPersonBuyer.SelectedCode != 0)
                Str = Str + " And Buyer=" + jucPersonBuyer.SelectedCode;
            if (jucPersonSeller.SelectedCode != 0)
            {
                Str = Str + " And Seller=" + jucPersonSeller.SelectedCode;
                Str = Str + @" And ((select CommercialCode from organization Where Code=Buyer) <> '' Or 
(select ShMeli from clsPerson Where Code=Buyer) <> '')  ";
            }

            if (groupBox4.Enabled == true)
            {
                if ((rbNaghd.Checked) && (rbNNaghd.Checked) && (rbTogether.Checked))
                    Str = Str + " And StatePay in (0,1,2) ";
                else if ((rbNaghd.Checked) && (rbNNaghd.Checked))
                    Str = Str + " And StatePay in (0,1) ";
                else if ((rbNaghd.Checked) && (rbTogether.Checked))
                    Str = Str + " And StatePay in (0,2) ";
                else if ((rbNNaghd.Checked) && (rbTogether.Checked))
                    Str = Str + " And StatePay in (1,2) ";
                else if (rbNaghd.Checked)
                    Str = Str + " And StatePay = 0";
                else if (rbNNaghd.Checked)
                    Str = Str + " And StatePay = 1";
                else if (rbTogether.Checked)
                    Str = Str + " And StatePay = 2";
            }

            if (chklistGoods.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chklistGoods.Items.Count; i++)
                    if (chklistGoods.GetItemChecked(i))
                        CodeGH = CodeGH +  ((ClassLibrary.JKeyValue)(chklistGoods.Items[i])).Value.ToString() + ",";
                if (CodeGH != "")
                    Str = Str + " And StoreBillGoodsList.Code in (select Code from StoreBillGoodsList Where ObjectCode in (" + CodeGH + "0))";
                //Str = Str + " And Dt.Code in (" + CodeGH  + "'0')";                
            }

            if (chklistCreator.CheckedItems.Count > 0)
            {
                string CodeGH = "";
                for (int i = 0; i < chklistCreator.Items.Count; i++)
                    if (chklistCreator.GetItemChecked(i))
                        if (((ClassLibrary.JKeyValue)(chklistCreator.Items[i])).Value.ToString() != "-1")
                            CodeGH = CodeGH + ((ClassLibrary.JKeyValue)(chklistCreator.Items[i])).Value.ToString() + ",";
                if (CodeGH != "")
                    Str = Str + " And Creator in (" + CodeGH + "0)";
            }

            //if(Convert.ToInt32(cmbCreator.SelectedValue) != -1)
            //    Str = Str + " And Creator = " + cmbCreator.SelectedValue.ToString();
            return Str;
        }

        public void TotalPrice()
        {
            decimal Sum = 0;

            foreach (DataRow dr in jJanusGridReport.DefaultView.Rows)
            {
                if (dr["TotalPriceTax"].ToString() != "")
                    Sum = Sum + Convert.ToDecimal(dr["TotalPriceTax"]);
            }
            lblTotal.Text = JGeneral.MoneyStr(Math.Round(Sum, 0).ToString());
            //JMessages.Information(JGeneral.MoneyStr(Sum.ToString()), " جمع کل ");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                string _StrHaving = " having 1=1 ";
                if (txtPrice.Text != "")
                    _StrHaving = _StrHaving + "  And  SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price+StoreBillGoodsList.Tax+StoreBillGoodsList.Duty) >= " + txtPrice.Text;
                if (txtPrice1.Text != "")
                    _StrHaving = _StrHaving + "  And SUM(StoreBillGoodsList.[COUNT]*StoreBillGoodsList.Price+StoreBillGoodsList.Tax+StoreBillGoodsList.Duty) <= " + txtPrice1.Text;

                if (rbSeller.Checked)
                {
                    jucPersonSeller.SelectedCode = 120000000;
                    jucPersonBuyer.SelectedCode = 0;
                }
                if ((rbBuyer.Checked))
                {
                    jucPersonBuyer.SelectedCode = 120000000;
                    jucPersonSeller.SelectedCode = 0;
                }

                if ((rbEmtenae.Checked))
                {
                    jucPersonBuyer.SelectedCode = 0;
                    jucPersonSeller.SelectedCode = 0;
                }

                if (chkDetails.Checked)
                    _DtReport = JBillGoodss.SearchTotalDetails(WhereReoprt());
                else if ((rbSeller.Checked) || (rbBuyer.Checked))
                    _DtReport = JBillGoodss.SearchEmtena(WhereReoprt(), _StrHaving);//SearchTotal
                else if (rbTadarokat.Checked)
                {
                    _DtReport = JBillGoodss.SearchTadarokat(WhereReoprt());
                    for (int i = _DtReport.Rows.Count; i < 24; i++)
                        _DtReport.Rows.Add(0, "", 0, 0, 0, 0, 0, 0, "");
                }
                else if (rbEmtenae.Checked)
                    _DtReport = JBillGoodss.SearchEmtena(WhereReoprt() + "  And isnull((select (ShMeli) from clsPerson Where Code=Buyer),'') =''  And isnull((select (ShenaseMeli) from organization Where Code=Buyer),'') ='' ", "");
                else
                    _DtReport = JBillGoodss.Search(WhereReoprt() + _StrHaving);

                jJanusGridReport.DataSource = _DtReport;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JReportForm_Load(object sender, EventArgs e)
        {
            
            DataTable _dtGoods = JGoods.GetDataTable(0);

            JKeyValue[] L = new JKeyValue[_dtGoods.Rows.Count];
            int count = 0;
            foreach (DataRow dr in _dtGoods.Rows)
            {
                L[count] = new JKeyValue();
                L[count].Key = dr["Name"].ToString();
                L[count].Value = dr["Code"];
                count++;
            }
            chklistGoods.Items.AddRange(L);

            JGoodsGroups tmpGoodsGroup = new JGoodsGroups();            
            tmpGoodsGroup.SetComboBox(cmbGroup, -1);

            //cmbCreator.DisplayMember = "Name";
            //cmbCreator.ValueMember = "Code";
            //cmbCreator.DataSource = JBillGoodss.CreatorsBill();

            DataTable _dtCreator = JBillGoodss.CreatorsBill();
            L = new JKeyValue[_dtCreator.Rows.Count];
            count = 0;
            foreach (DataRow dr in _dtCreator.Rows)
            {
                L[count] = new JKeyValue();
                L[count].Key = dr["Name"].ToString();
                L[count].Value = dr["Code"];
                count++;
            }
            chklistCreator.Items.AddRange(L);

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtinfo = new DataTable();
                dtinfo.Columns.Add("Year");
                dtinfo.Columns.Add("Month");
                dtinfo.Columns.Add("Season");
                dtinfo.Columns.Add("TotalPriceWord");
                dtinfo.Columns.Add("SumTotalPrice", typeof(Decimal));
                dtinfo.Columns.Add("SumTax", typeof(Decimal));
                dtinfo.Columns.Add("SumDuty", typeof(Decimal));
                dtinfo.Columns.Add("TotalPriceTax", typeof(Decimal));
                dtinfo.Columns.Add("SumTaxDuty", typeof(Decimal));
                dtinfo.Columns.Add("StartDate");
                dtinfo.Columns.Add("EndDate");
                dtinfo.Columns.Add("DateNow");

                string str = "";
                string Year = "";
                string StartDate = "";
                string EndDate = "";
                string TotalPriceWord = "";

                if (txtDate.Date != DateTime.MinValue)
                    Year = (JDateTime.FarsiDate(txtDate.Date).Split('/'))[0];
                if (txtDate.Date != DateTime.MinValue)
                    StartDate = JDateTime.FarsiDate(txtDate.Date);
                if (txtDate1.Date != DateTime.MinValue)
                    EndDate = JDateTime.FarsiDate(txtDate1.Date);

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
                int Tax = 0;
                int Duty = 0;
                foreach (DataRow dr in _DtReport.Rows)
                {
                    if (dr["Returned"].ToString() == "*")
                    {
                        if (dr["TotalPrice"].ToString() != "")
                            Sum = Sum - Convert.ToDecimal(dr["TotalPrice"]);
                        if (dr["Tax"].ToString() != "")
                            Tax = Tax - Convert.ToInt32(dr["Tax"]);
                        if (dr["Duty"].ToString() != "")
                            Duty = Duty - Convert.ToInt32(dr["Duty"]);
                        if (dr["TotalPriceTax"].ToString() != "")
                            SumTax = SumTax - Convert.ToDecimal(dr["TotalPriceTax"]);
                    }
                    else
                    {
                        if (dr["TotalPrice"].ToString() != "")
                            Sum = Sum + Convert.ToDecimal(dr["TotalPrice"]);
                        if (dr["Tax"].ToString() != "")
                            Tax = Tax + Convert.ToInt32(dr["Tax"]);
                        if (dr["Duty"].ToString() != "")
                            Duty = Duty + Convert.ToInt32(dr["Duty"]);
                        if (dr["TotalPriceTax"].ToString() != "")
                            SumTax = SumTax + Convert.ToDecimal(dr["TotalPriceTax"]);
                    }
                }
                JGeneral tmp = new JGeneral();
                TotalPriceWord = tmp.GetStringNumber((Math.Round(SumTax,0)).ToString());

                dtinfo.Rows.Add(Year,txtMah.Text, str, TotalPriceWord, Sum, Tax, Duty, SumTax, Tax + Duty, StartDate, EndDate ,JDateTime.FarsiDate(DateTime.Now));

                DataTable dtListGoods = JBillListGoods.GetDataTable(0);
                    dtListGoods.TableName = " لیست کالاها ";
                JDynamicReportForm DRF = new JDynamicReportForm(JReportDesignCodes.BillGoods.GetHashCode());
                DRF.Add(_DtReport);
                DRF.Add(dtListGoods);
                dtinfo.TableName = "اطلاعات پایه";
                DRF.Add(dtinfo);
                DRF.ShowDialog();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                
            }
        }

        private void jJanusGridReport_OnRowDBClick(object Sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (groupBox1.Visible == true)
                groupBox1.Visible = false;
            else
                groupBox1.Visible = true;
        }

        private void jJanusGridReport_OnRowSelectionClick(object Sender, EventArgs e)
        {
            TotalPrice();
        }

        private void rbEmtenae_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEmtenae.Checked)
            {

                groupBox4.Enabled = false;
            }
            else
                groupBox4.Enabled = true;
        }
    }
}
