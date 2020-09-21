using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TCCOParking;
using ClassLibrary;
using RealEstate;

namespace Parking
{
    public partial class GateForm :Globals.JBaseForm
    {
        private JGate _Gate;
        private BSPTCPClient tcpClient;
        public Boolean StateChange = false;

        public int TypeGate(int pCode)
        {
            JGate _Gat = new JGate();
            cmbComplex.SelectedValue = Convert.ToInt32(_Gate.Market);
            _Gat.GetData(pCode);
            return _Gat.TypeGate;
        }

        public GateForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Display()
        {
            txtName.Text = _Gate.Name;
           
            CmbTypeGate.SelectedIndex = Convert.ToInt32(_Gate.TypeGate)-1;
            txtIPSystemParking.Text = _Gate.IpSystem;
            TxtIpSubnet.Text = _Gate.SubIp;
            TxtipDevice.Text = _Gate.Ip;
            TxtIpCenter.Text = _Gate.IpCenter;
            TxtIpCamera.Text = _Gate.IpCamera;
            txtReaderName.Text = _Gate.DeviceName;
            Txtport.Text = _Gate.Port.ToString();
            btnOptionDevice.Enabled = true;
            BtnSendGroup.Enabled = true;
            ChkState.Checked = _Gate.State;
           
        }

        private void FillComboBox()
        {
            //
            DataTable Markets = jMarkets.GetDataTable(0);
            cmbComplex.DisplayMember = estMarket.Title.ToString();
            cmbComplex.ValueMember = estMarket.Code.ToString();
            cmbComplex.DataSource = Markets;
            cmbComplex.SelectedItem = 1;
        }

        public GateForm(JGate Gate,int Market)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
           
            FillComboBox();
            cmbComplex.SelectedValue = Market;
            _Gate = Gate;
            
            if (_Gate.Code == 0)
            {
                State = JFormState.Insert;
            }
            else
            {
                State = JFormState.Update;
                Display();
            }
        }

        private Boolean Validate()
        {
            if (txtName.Text == "")
            {
                JMessages.Warning("نام به شكل صحيح وارد نشده است", "توجه");
                txtName.Focus();
                return false;
            }
           string txt= TxtIpCamera.Text;
           if (!_Gate.ConvertToIP(txt))
            {
                JMessages.Warning("Ip دوربين در فرمت استاندارد نيست", "توجه");
                TxtIpCamera.Focus();
                return false;
            }
           txt = TxtIpSubnet.Text;
           if (!_Gate.ConvertToIP(txt))
           {
               JMessages.Warning("Ip زير شبكه در فرمت استاندارد نيست", "توجه");
               TxtIpSubnet.Focus();
               return false;
           }
            txt = TxtipDevice.Text;
           if (!_Gate.ConvertToIP(txt))
           {
               JMessages.Warning("Ip دستگاه در فرمت استاندارد نيست", "توجه");
               TxtipDevice.Focus();
               return false;
           }
            txt = TxtIpCenter.Text;
           if (!_Gate.ConvertToIP(txt))
           {
               JMessages.Warning("Ipمركز در فرمت استاندارد نيست", "توجه");
               TxtIpCenter.Focus();
               return false;
           }
            if (Convert.ToInt32(cmbComplex.SelectedValue) == -1 || Convert.ToInt32(cmbComplex.SelectedValue) == 0)
            {
                JMessages.Warning("نيك بازار را انتخاب كنيد", "توجه");
                cmbComplex.Focus();
                return false;
            }
            if ( (Convert.ToInt32(CmbTypeGate.SelectedIndex))+1 < 0 )
            {
                JMessages.Warning("نوع گيت نا مشخص است", "توجه");
                CmbTypeGate.Focus();
                JMessages.Warning("نوع پورت نا مشخص است", "توجه");
                return false;
            }
            if (Txtport.Text == "")
            {
                return false;
            }
            return true;
        }
        private void Save()
        {
            JDataBase jdb=new JDataBase();
            try
            {
                if (Validate() == false) return;

                _Gate.Market = Convert.ToInt32(cmbComplex.SelectedValue);
                _Gate.TypeGate = Convert.ToInt32(CmbTypeGate.SelectedIndex) + 1;
                _Gate.Name = txtName.Text;
                _Gate.MarketName = cmbComplex.Text;
                _Gate.DeviceName = txtReaderName.Text;
                _Gate.Ip = _Gate.TrimForIP(TxtipDevice.Text);
                _Gate.IpCenter = _Gate.TrimForIP(TxtIpCenter.Text);
                _Gate.SubIp = _Gate.TrimForIP(TxtIpSubnet.Text);
                _Gate.IpCamera = _Gate.TrimForIP(TxtIpCamera.Text);
                _Gate.IpSystem = _Gate.TrimForIP(txtIPSystemParking.Text);
                _Gate.Port = Txtport.IntValue;
                _Gate.State = ChkState.Checked;
                if (State == JFormState.Insert)
                {
                    int _Code = _Gate.Save(jdb,true);

                    if (_Code != 0)
                    {
                        State = JFormState.Update;
                        tcpClient.SendData("SetGate" + "," + _Gate.Ip.ToString() + "," + _Gate.Market.ToString() + "," + _Gate.Market.ToString() + "," + _Gate.TypeGate);
                        _Gate.GetData(_Code);
                        Display();
                        JMessages.Information("اطلاعات ثبت شد", "توجه");
                    }
                    else
                    {
                        JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                    }
                }
                else
                {
                    if (_Gate.Update())
                    {
                        Display();
                        tcpClient.SendData("SetGate" + "," + _Gate.Ip.ToString() + "," + _Gate.Market.ToString() + "," + _Gate.Market.ToString() + "," + _Gate.TypeGate);
                        JMessages.Information("اطلاعات ثبت شد", "توجه");
                    }
                    else
                    {
                        JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                    }
                }
            }
            catch
            {
            }
            finally
            {
                jdb.Dispose();
            }

        }


        
        private void GateForm_Load(object sender, EventArgs e)
        {
            if (State == JFormState.Update)
            {
                tcpClient = new BSPTCPClient();
                tcpClient.Connect(_Gate.IpCenter,Convert.ToUInt16( _Gate.Port));
            }
        }

        private void BtnSendGroup_Click(object sender, EventArgs e)
        {
            
            tcpClient.SendData("SetGate" + "," + _Gate.Ip.ToString() + "," + _Gate.Market.ToString() + "," + _Gate.Market.ToString() + "," + _Gate.TypeGate);
        }

        private void GateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if(tcpClient!=null && tcpClient.IsConnect) tcpClient.Disconnect();
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void BtnApplay_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnOptionDevice_Click(object sender, EventArgs e)
        {
            FrmSettingForm frmOption = new FrmSettingForm(_Gate.Ip,_Gate.IpCenter,_Gate.Port);
            frmOption.ShowDialog();
        }

        

       
    }
}
