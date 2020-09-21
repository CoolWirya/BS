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
  
    public partial class SaveElectronicCharje :Globals.JBaseForm
    {
        JPElectronic El = new JPElectronic();
        JCardParking Cp;
        public SaveElectronicCharje(int CodeCard)
        {
            InitializeComponent();
            Cp = new JCardParking();
            Cp.GetData(CodeCard);
            



        }
        public void Display()
        {
            GrdData.DataSource = JPElectronic.GetListOfCharje(Cp.Code);
        }
        private void SaveElectronicCharje_Load(object sender, EventArgs e)
        {
            this.Text = "شماره كارت :" + Cp.IDCardParking.ToString();
            GrdData.DataSource  = JPElectronic.GetListOfCharje(Cp.Code);
            GrdUse.DataSource =  JPElectronic.UseAmount(Cp.IDCardParking);
            
            //txtDiv.Text = Cp.ElectronicPay.ToString();
            txtKolUse.Text = JPElectronic.UseKolAmount(Cp.IDCardParking).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JDataBase Jdb = new JDataBase();
            try
            {
               
               
                JPElectronic Jp = new JPElectronic();
                Jp.Amount = txtAmount.MoneyValue;
                Jp.CardId = Cp.Code;
                Jp.DateExpire = TxtDate.Date.Date;

                Jp.DateCreate = Jdb.GetCurrentDateTime().Date;
                
                Jp.Statustransfer = false;
                Jdb.beginTransaction("SaveElectronic");
                if (Jp.Insert(Jdb) != 0)
                {
                    
                    //Cp.ElectronicPay += Jp.Amount;
                    Cp.DateExpire = Jp.DateExpire;
                    if (Cp.Update(Jdb))
                    {
                        Jdb.Commit();
                        Display();
                        JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    }
                    else
                    {
                        Jdb.Rollback("SaveElectronic");
                        JMessages.Message("Insert NOT SucceesFull", "", JMessageType.Information);
                    }

                }
                else
                {
                    Jdb.Rollback("SaveElectronic");
                    JMessages.Message("Insert NOT SucceesFull", "", JMessageType.Information);
                }
            }
            catch
            {
                Jdb.Rollback("SaveElectronic");
                JMessages.Message("Insert NOT SucceesFull", "", JMessageType.Information);
            }
            finally
            {
                Jdb.Dispose();
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
