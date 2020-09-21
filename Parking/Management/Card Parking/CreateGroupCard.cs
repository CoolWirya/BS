using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Parking
{
    public partial class CreateGroupCard : Globals.JBaseForm
    {
        JCardParking _JCardParking;
        public CreateGroupCard(int Market)
        {
            InitializeComponent();
            _JCardParking = new JCardParking();
            // پر كردن نام مجتمع / بازارها
            cmbComplex.DisplayMember = RealEstate.estMarket.Title.ToString();
            cmbComplex.ValueMember = RealEstate.estMarket.Code.ToString();
            cmbComplex.DataSource = RealEstate.jMarkets.GetDataTable(0);
            cmbComplex.SelectedValue = Convert.ToInt32(Market);
            cmbComplex.Enabled = false;
        }

        private void CreateGroupCard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            JDataBase Jdb = new JDataBase();
            try
            {
                
                Jdb.beginTransaction("InsertCard");
                int Firs = TxtFirst.IntValue;
                int Last = TxtLast.IntValue;
                JCardMarket Market = new JCardMarket();
                Market.ExpireDate = Convert.ToDateTime("2029/12/29");
                Market.GroupCard = Convert.ToInt32(cmbGroupCard.SelectedValue);
                Market.MarketCode = Convert.ToInt32(cmbComplex.SelectedValue);
                Market.Publish = true;
                Market.StatusCard = 350011;
                for (int i = Firs; Last > i; i++)
                {
                    _JCardParking.Description = "مشتريان";


                    _JCardParking.IDBusinessUnit = 0;
                    _JCardParking.IDCardParking = i;
                    _JCardParking.IDContract = 0;
                    _JCardParking.Market = Convert.ToInt32(cmbComplex.SelectedValue);
                    _JCardParking.EndDateContract = Convert.ToDateTime("2029/12/29");
                    _JCardParking.Number = i.ToString();
                    _JCardParking.StatusCard = false;

                    if (_JCardParking.GetIDCard(_JCardParking.IDCardParking))
                    {
                        Jdb.Rollback("InsertCard");
                        JMessages.Error("كارت شماره " + _JCardParking.IDCardParking + " از قبل در سيستم ثبت شده است ", "هشدار");
                        return;
                    }
                        if (_JCardParking.Insert() <= 0)
                        {
                            Jdb.Rollback("InsertCard");
                            JMessages.Error("در اجراي عمليات مشكلي بروز كرده است", "هشدار");
                            return;
                        }
                        else
                        {
                            Market.ID_Card = _JCardParking.Code;

                            if (Market.Insert(Jdb) <= 0)
                            {
                                Jdb.Rollback("InsertCard");
                                JMessages.Error("در اجراي عمليات مشكلي بروز كرده است", "هشدار");
                                return;
                            }
                           
                        }

                }
                Jdb.Commit();
            }
            catch
            {
            }
            finally
            {
                Jdb.Dispose();
            }
        }

        private void cmbComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            JGroupCard Group = new JGroupCard();
            cmbGroupCard.DataSource = Group.ShowData("", Convert.ToInt32(cmbComplex.SelectedValue));
            cmbGroupCard.DisplayMember = "TypeGroup";
            cmbGroupCard.ValueMember = "Code";
            cmbGroupCard.Text = "";
        }
    }
}
