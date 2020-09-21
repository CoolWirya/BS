using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using RealEstate;
using System.Threading;

namespace Parking
{
    public partial class JGroupCardForm : Globals.JBaseForm
    {
        public  BSPTCPClient tcpClient;
        private JGroupCard _JGroupCard;
        public Boolean StateChange = false;

        public JGroupCardForm(JGroupCard Card)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            _FillComboBox();
            cmbComplex.SelectedValue =Convert.ToInt32( Card.MarketCode);
            _JGroupCard = Card;
            if (_JGroupCard.Code == 0)
            {
                State = JFormState.Insert;
            }
            else
            {
                State = JFormState.Update;
                DispalyDate();
            }
          
        }

        private void DispalyDate()
        {
            txtFirstAmount.Text=_JGroupCard.FirstAmount.ToString();
            txtSecondAmount.Text = _JGroupCard.SecondAmount.ToString();
            TxtOffer.Text = _JGroupCard.Offers.ToString();
            TxtRound.Text = _JGroupCard.Round.ToString();
            TxtAbate.Text = _JGroupCard.Abate.ToString();
            cmbComplex.SelectedValue = Convert.ToInt32(_JGroupCard.MarketCode);
            chkinputDisplay.Checked = _JGroupCard.AmountReceived;
            chkMinute.Checked = _JGroupCard.PayByDialy;
            TxtName.Text = _JGroupCard.TypeGroup;
            txtUnitTime.Text =_JGroupCard.UnitTime.ToString();
            chkElectronic.Checked = _JGroupCard.PayIsElectronic;
            chkUpRound.Checked = _JGroupCard.UpRound;
            TxtNumber.Text = _JGroupCard.GroupNumber.ToString();
            chkIsDailyApart.Checked =_JGroupCard.IsDailyApart;
            chkIsFirstHourApart.Checked=_JGroupCard.IsFirstHourApart;
            TxtDailyPrice.Text=_JGroupCard.DailyPrice.ToString();
            chkIsActive.Checked=_JGroupCard.IsActive;
        }

        public Boolean validtion()
        {
            if (_JGroupCard.Find() && State==JFormState.Insert)
            {
                JMessages.Error("گروه تكراري است", "خطا");
                return false;
            }

            if (_JGroupCard.TypeGroup == "")
            {
                JMessages.Error("نام گروه نامشخص است", "خطا");
                TxtName.Focus();
                return false;
            }

            if (_JGroupCard.GroupNumber<0)
            {
                JMessages.Error("شماره گروه نا مشخص است", "خطا");
                TxtName.Focus();
                return false;
            }
            if (_JGroupCard.FirstAmount< 0 )
            {
                JMessages.Error("مبلغ اوليه", "خطا");
                txtFirstAmount.Focus();
                return false;
            }
            if (_JGroupCard.UnitTime < 0)
            {
                JMessages.Error("واحد زماني نا مشخص است", "خطا");
                txtUnitTime.Focus();
                return false;
            }
            if (_JGroupCard.MarketCode < 0)
            {
                JMessages.Error("بازار نا مشخص است", "خطا");
                cmbComplex.Focus();
                return false;
            }
            return true;
        }
        public void _FillComboBox()
        {
            // پر كردن نام مجتمع / بازارها
            try
            {
                DataTable Markets = jMarkets.GetDataTable(0);
                cmbComplex.DisplayMember = estMarket.Title.ToString();
                cmbComplex.ValueMember = estMarket.Code.ToString();
                cmbComplex.DataSource = Markets;
                cmbComplex.SelectedItem = 1;
            }
            catch
            {
            }
            finally
            {
               
            }

        }

        private Boolean Save(JDataBase Jdb)
        {
            try
            {
                _JGroupCard.FirstAmount = txtFirstAmount.MoneyValue;
                _JGroupCard.TypeGroup = TxtName.Text;
                _JGroupCard.SecondAmount = txtSecondAmount.MoneyValue;
                _JGroupCard.AmountReceived = chkinputDisplay.Checked;
                _JGroupCard.MarketCode = Convert.ToInt32(cmbComplex.SelectedValue);
                _JGroupCard.UnitTime = txtUnitTime.IntValue;
                _JGroupCard.Offers = TxtOffer.IntValue;
                _JGroupCard.Round = TxtRound.IntValue;
                _JGroupCard.Abate = TxtAbate.IntValue;
                _JGroupCard.PayByDialy = chkMinute.Checked;
                _JGroupCard.PayIsElectronic = chkElectronic.Checked;
                _JGroupCard.UpRound = chkUpRound.Checked;
                _JGroupCard.GroupNumber = TxtNumber.IntValue;
                _JGroupCard.IsDailyApart = chkIsDailyApart.Checked;
                _JGroupCard.IsFirstHourApart = chkIsFirstHourApart.Checked;
                _JGroupCard.DailyPrice = TxtDailyPrice.IntValue;
                _JGroupCard.IsActive = chkIsActive.Checked;

                if (validtion() == false)
                {
                    return false;
                }
                if (State == JFormState.Insert)
                {
                    if (_JGroupCard.GetDataGroupNumber(_JGroupCard.GroupNumber, _JGroupCard.MarketCode))
                    {
                        JMessages.Error("This Group Number Has Repated","Error");
                        return false;
                    }
                    int _Code = _JGroupCard.Insert(Jdb);

                    if (_Code != 0)
                    {
                        State = JFormState.Update;
                        JMessages.Information("اطلاعات ثبت شد", "توجه");
                        return true;
                    }
                    else
                    {
                        JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                        return false;
                    }
                }
                else
                {
                    if (_JGroupCard.UpdateRole())
                    {
                        DispalyDate();
                        JMessages.Information("اطلاعات ثبت شد", "توجه");
                        return true;
                       

                    }
                    else
                    {
                        JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            
        }
        private Boolean SendDataToGates()
        {
            Boolean Result;
            System.Data.DataTable Dt = JGate.GateMarket(_JGroupCard.MarketCode);
            tcpClient = new BSPTCPClient();
            if (Dt == null) return true;
            for (int J = 0; J < Dt.Rows.Count; J++)
            {
                JGate Gate = new JGate(Convert.ToInt32(Dt.Rows[J]["Code"]));

                tcpClient.Connect(Gate.IpCenter, Convert.ToUInt16(Gate.Port));
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Result = tcpClient.SendData("SetGroupDevice" + "," + Gate.Ip.ToString() + "," + _JGroupCard.GroupNumber.ToString() + "," + _JGroupCard.MarketCode.ToString() + "," + _JGroupCard.MarketCode.ToString() + "," + _JGroupCard.FirstAmount.ToString() + "," + _JGroupCard.UnitTime.ToString() + "," + txtSecondAmount.Text + "," + _JGroupCard.Abate.ToString() + "," + _JGroupCard.PayIsElectronic.ToString() + "," + _JGroupCard.AmountReceived.ToString() + "," + _JGroupCard.Offers.ToString() + "," + _JGroupCard.PayByDialy.ToString() + "," + _JGroupCard.UpRound.ToString() + "," + _JGroupCard.Round.ToString() + "," + _JGroupCard.IsActive.ToString() + "," + _JGroupCard.IsDailyApart.ToString() + "," + _JGroupCard.DailyPrice.ToString() + "," + _JGroupCard.IsFirstHourApart.ToString());
                if (Result == false) return Result;
                //tcpClient.Disconnect();

            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            JDataBase Jdb = new JDataBase();
            try
            {

                Jdb.beginTransaction("SendToDevice");
                if (Save(Jdb))
                {
                    StateChange = true;
                    if (SendDataToGates())
                        Jdb.Commit();

                    else Jdb.Rollback("SendToDevice");
                }
                else
                {
                    Jdb.Rollback("SendToDevice");
                }
            }
            catch
            {
                Jdb.Rollback("SendToDevice");
            }
            finally
            {
                Jdb.Dispose();
            }


       }
        

        private void JGroupCardForm_Load(object sender, EventArgs e)
        {
            cmbComplex.Focus();
            Boolean Result;
            System.Data.DataTable Dt = JGate.GateMarket(_JGroupCard.MarketCode);
            tcpClient = new BSPTCPClient();
            
            if (Dt == null) btnAdd.Enabled = false;
            //for (int J = 0; J < Dt.Rows.Count; J++)
            //{
            //    JGate Gate = new JGate(Convert.ToInt32(Dt.Rows[J]["Code"]));

            //    while (true)
            //    {
            //        if (!tcpClient.IsConnect)
            //        {
            //            tcpClient.Connect(Gate.IpCenter, Convert.ToUInt16(Gate.Port));
            //            Thread.Sleep(TimeSpan.FromSeconds(5));
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
                
            //    Result = tcpClient.SendData("CheckGate" + "," + Gate.Market + "," + Gate.IpCenter);
            //    tcpClient.OnReceiveData += new BSPTCPClient.OnReceiveDataHandler(tcpClient_OnReceiveData);
            //   if (Result == false) btnAdd.Enabled = false;
            //  //  tcpClient.Disconnect();

            //}
            if (State == JFormState.Update)
            {
                TxtNumber.Enabled = false;
                cmbComplex.Enabled = false;
                btnAdd.Enabled = true;
            }
           
           
        }

        private void tcpClient_OnReceiveData(object sender, byte[] bytes, string data)
        {
            if ("GateOK" == data)
                btnAdd.Enabled = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void TxtRound_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        

        private void cmbComplex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string deviceIP = GetDeviceIP();
        //    if (deviceIP.Length > 0 && TxtNumber.DecimalValue <= 100)
        //    {
        //        tccoParking.GetGroupInfo(deviceIP, (byte)TxtNumber.DecimalValue);
        //    }
        //}
        
       

        private void lstDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnDeviceRead_Click(object sender, EventArgs e)
        {

        }

        private void JGroupCardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(tcpClient!=null && tcpClient.IsConnect) tcpClient.Disconnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkMinute_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkinputDisplay_CheckedChanged(object sender, EventArgs e)
        {

        }

        
        
    }
}
