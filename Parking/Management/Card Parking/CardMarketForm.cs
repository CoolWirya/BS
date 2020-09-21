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
    public partial class CardMarketForm : Globals.JBaseForm
    {
        public int StaticIDCard;
       
        JCardMarket CartMarket;
        private void DisplayData()
        {
            cmbComplex.SelectedValue = Convert.ToInt32(CartMarket.MarketCode);
            cmbGroupCard.SelectedValue = Convert.ToInt32(CartMarket.GroupCard);
            cmbStatusCard.SelectedValue = Convert.ToInt32(CartMarket.StatusCard);
            txtExpireDate.Date = CartMarket.ExpireDate;
            ChkState.Checked = CartMarket.Publish;

        }
        public CardMarketForm(int IDCard)
        {
            InitializeComponent();
            _FillComboBox();
            StaticIDCard = IDCard;
                            
            CartMarket = new JCardMarket();
         System.Data.DataTable Dt=CartMarket.GetMarketCard(IDCard);
         if (Dt.Rows.Count > 0)
         {
             grdMarket.DataSource = Dt;
             State = JFormState.Update;

         }
         else
         {
             State = JFormState.Insert;
         }

          
            
           
        }
        private bool Validtion()
        {
            if (Convert.ToInt32(cmbComplex.SelectedValue) == 0 || Convert.ToInt32(cmbComplex.SelectedValue) == -1)
            {
                string msg = "هیچ مجتمع یا بازاری انتخاب نگردیده است";
                JMessages.Error(msg, "Error");
                cmbComplex.Focus();
                return false;
            }
            if (Convert.ToInt32(cmbStatusCard.SelectedValue) == 0 || Convert.ToInt32(cmbStatusCard.SelectedValue) == -1)
            {
                string msg = "لطفا وضعیت کارت پارکینگ را مشخص نمائید";
                JMessages.Error(msg, "Error");
                cmbStatusCard.Focus();
                return false;
            }

            if (txtExpireDate.Date.ToString() == "")
            {
                string msg = "لطفا تاریخ انقضاء کارت پارکینگ را مشخص نمائید";
                JMessages.Error(msg, "Error");
                txtExpireDate.Focus();
                return false;
            }
            if (Convert.ToInt32(cmbGroupCard.SelectedValue) == 0 || Convert.ToInt32(cmbGroupCard.SelectedValue) == -1)
            {
                string msg = "لطفا گروه کارت را مشخص نمائید";
                JMessages.Error(msg, "Error");
                cmbGroupCard.Focus();
                return false;
            }
            return true;
        }
        public void _FillComboBox()
        {
            try
            {
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";

                // پر كردن نام مجتمع / بازارها
                cmbComplex.DisplayMember = RealEstate.estMarket.Title.ToString();
                cmbComplex.ValueMember = RealEstate.estMarket.Code.ToString();
                cmbComplex.DataSource = RealEstate.jMarkets.GetDataTable(0);
                
                // پرکردن وضعیت کارت
                JStatus JS = new JStatus();
                cmbStatusCard.Items.Clear();
                JS.SetComboBox(cmbStatusCard);

               
              


            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }
        private void CardMarketForm_Load(object sender, EventArgs e)
        {
            JCardParking card = new JCardParking();
            card.GetData(StaticIDCard);
            this.Text = "شماره كارت :" + card.IDCardParking.ToString();   
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            JGroupCard Group = new JGroupCard();
            cmbGroupCard.DataSource = Group.ShowData("", Convert.ToInt32(cmbComplex.SelectedValue));
            cmbGroupCard.DisplayMember = "TypeGroup";
            cmbGroupCard.ValueMember = "Code";
            cmbGroupCard.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CartMarket = new JCardMarket();
                CartMarket.ExpireDate = txtExpireDate.Date;
                CartMarket.ID_Card = StaticIDCard;
                CartMarket.GroupCard = Convert.ToInt32(cmbGroupCard.SelectedValue);
                JCardParking card = new JCardParking();
                if (!card.GetData(StaticIDCard))
                {
                    JMessages.Message("چنين شماره كارتي وجود ندارد", "", JMessageType.Information);
                }
                else
                {
                    CartMarket.CardNumber = card.IDCardParking;
                }
                if (CartMarket.GroupCard == -1 || CartMarket.GroupCard == 0)
                {
                    JMessages.Message("لطفا گروه كارت را وارد كنيد", "", JMessageType.Information);
                    cmbGroupCard.Focus();
                    return;
                }
                CartMarket.MarketCode = Convert.ToInt32(cmbComplex.SelectedValue);
                if (CartMarket.MarketCode == -1 || CartMarket.MarketCode == 0)
                {
                    JMessages.Message("لطفا نام بازار را وارد كنيد", "", JMessageType.Information);
                   cmbComplex.Focus();
                   return;
                }
                CartMarket.StatusCard = Convert.ToInt32(cmbStatusCard.SelectedValue);
                if (CartMarket.StatusCard == -1 || CartMarket.StatusCard == 0)
                {
                    JMessages.Message("لطفا وضعيت كارت را مشخص كنيد", "", JMessageType.Information);
                    cmbStatusCard.Focus();
                    return;
                }
                CartMarket.Publish = ChkState.Checked;
             
             
                if (CartMarket.FindMarketCard(CartMarket.ID_Card, CartMarket.MarketCode) <= 0)
                {
                    
                    CartMarket.Insert();
                    if (CartMarket.Code > 0)
                    {
                        
                        grdMarket.DataSource = CartMarket.GetMarketCard(StaticIDCard);
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    }
                    else
                    {

                        JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
                    }
                }
                else
                {
                    JMessages.Message("براي اين بازار قبلا كارت تعريف شده است", "هشدار", JMessageType.Information);
                }

            }
            catch(Exception Ex)
            {
                JMessages.Message("اجراي برنامه دچار ايراد شده "+Ex.Message, "هشدار", JMessageType.Information);
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (JMessages.Confirm("آيا از حذف كارت پاركينگ برروي  اين بازار مطمئن هستيد", "هشدار") == System.Windows.Forms.DialogResult.Yes)
                {
                    int i = Convert.ToInt32(grdMarket["Code", grdMarket.CurrentRow.Index].Value);
                    if (CartMarket.Delete(i))
                    {
                        grdMarket.DataSource = CartMarket.GetMarketCard(StaticIDCard);
                    }
                }
            }
            catch(Exception Ex)
            {
            }
        }

        private void cmbGroupCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
