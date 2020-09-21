using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using TCCORFID;
using System.Threading;
using System.Globalization;
using ClassLibrary;

namespace Parking
{
    public partial class FrmSetDeviceCaed : Form
    {
        int lastAction = 0;
        public FrmSetDeviceCaed()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void tccoRFID1_OnError(string deviceIP, int errorID, string errorMsg)
        {
            MessageBox.Show(errorMsg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        int stage = 0;
        private void tccoRFID1_OnReceiveCard(string deviceIP, byte[] cardRFID)
        {
            stage = 0;
            txtLogs.Text += "Receive CardID From DeviceIP:" + deviceIP + "\r\n";
            //txtLogs.SelectionStart = txtLogs.SelectionLength - 1;
            txtCardRFID.Text = BytesToHexString(cardRFID);
            FormatCard(tccoRFID.CardReaders[deviceIP].Segments);
            tccoRFID.ReadData(deviceIP);
        }

        private string Add0(string str, int length)
        {
            while (str.Length < length) str = "0" + str;
            return str;
        }

        private string BytesToHexString(byte[] bytes)
        {
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
                str += Add0(Convert.ToString(bytes[i], 16), 2) + " ";
            return str.ToUpper();
        }

        private byte[] HexStringToBytes(string strHexBytes)
        {
            strHexBytes = strHexBytes.Replace("  ", " ").Trim().ToUpper();
            string[] strings = strHexBytes.Split(' ');
            byte[] bytes = new byte[strings.Length];
            for (int i = 0; i < strings.Length; i++)
                bytes[i] = Convert.ToByte(strings[i], 16);
            return bytes;
        }

        
        private void tccoRFID1_OnReceiveCardData(string deviceIP, Segments segments)
        {
            stage++;
            txtLogs.Text += "Receive Card Data From DeviceIP:" + deviceIP + "\r\n";
            if (stage > 1)
            {
                for (int segNo = 0; segNo < 45; segNo++)
                {
                    if (segments[segNo].ReadSuccessfully)
                    {
                        TextBox txt = grbCardData.Controls["txt" + segNo] as TextBox;
                        txt.Text = "";
                        for (int i = 0; i < 16; i++)
                        {
                            string str = Convert.ToString(segments[segNo].Data[i], 16).ToUpper();
                            if (str.Length == 1)
                                str = "0" + str;
                            txt.Text += str + " ";
                        }
                    }
                }
                if (segments[0].ReadSuccessfully && segments[1].ReadSuccessfully && segments[2].ReadSuccessfully)
                {
                    txtIDInCard.Text = BitConverter.ToUInt32(tccoRFID.CardReaders[deviceIP].Segments.GetByteData(0, 4), 0).ToString();
                    txtFNameInCard.Text = tccoRFID.CardReaders[deviceIP].Segments.GetUnicodeString(4, 16);
                    txtLNameInCard.Text = tccoRFID.CardReaders[deviceIP].Segments.GetUnicodeString(20, 21);
                }
                if (chbSaveOnRead.Checked)
                {
                    SaveParkingCardInfo();
                }
                else
                {
                    LoadCardParkingInfo(tccoRFID.CardReaders[deviceIP].Segments);
                }
                if (chbEnd.Checked)
                    tccoRFID.EndSession(deviceIP);
            }
            //Thread.Sleep(200);
        }



        private void tccoRFID1_OnSentData(string deviceIP, Segments segments)
        {
            txtLogs.Text += "Your data saved in DeviceIP:" + deviceIP + "\r\n";

        }

        private void tccoRFID_OnWriteDataSuccessfullyFinish(string deviceIP, Segments segments)
        {
            if (chbFinishAfterSave.Checked && lastAction == 1)
            {
                lastAction = 0;
                tccoRFID.EndSession(deviceIP);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            tccoRFID.Start();
            lstDevices.Items.Clear();
            txtLogs.Clear();
            CreateTextboxes();
        }
        private void CreateTextboxes()
        {
            Random r = new Random();
            for (int segNo = 0; segNo < 45; segNo++)
            {
                TextBox txt = new TextBox();
                txt.Name = "txt" + segNo;
                txt.Width = 250;
                txt.Left = (segNo / 15) * (txt.Width + 40) + 30;
                txt.Top = (segNo % 15) * txt.Height + 10;
                grbCardData.Controls.Add(txt);
                CheckBox chb = new CheckBox();
                chb.Name = "chb" + segNo;
                chb.Left = txt.Left + txt.Width;
                chb.Top = txt.Top;
                chb.Width = 15;
                grbCardData.Controls.Add(chb);
                Label lbl = new Label();
                lbl.Left = txt.Left - 20;
                lbl.Name = "lbl" + segNo;
                lbl.Top = txt.Top + 4;
                lbl.Text = (segNo + 1).ToString() + ":";
                lbl.AutoSize = true;
                grbCardData.Controls.Add(lbl);
                if (r.NextDouble() < 0)
                {
                    txt.Text = "01 23 45 67 89 AB CD EF FE DC BA 98 76 54 32 10";
                    chb.Checked = true;
                }
                if (segNo == 0)
                {
                    grbCardData.Width = 3 * (txt.Width + 40) + 30;
                    grbCardData.Height = 15 * txt.Height + 5;
                }
            }

        }
        private void CreateTextboxes2()
        {
            Random r = new Random();
            for (int partNo = 0; partNo < 15; partNo++)
            {
                GroupBox grb = new GroupBox();
                grb.Name = "grb" + partNo;
                grb.Width = 285; grb.Height = 85;
                grb.Left = partNo % 3 * 290 + 5;
                grb.Top = partNo / 3 * 86 + 10;
                grb.Text = "Partition " + (partNo + 1);
                grbCardData.Controls.Add(grb);
                for (int segNo = 0; segNo < 3; segNo++)
                {
                    TextBox txt = new TextBox();
                    txt.Name = "txtP" + (partNo) + "S" + (segNo);
                    txt.Width = 250;
                    txt.Left = 15;
                    txt.Top = segNo * txt.Height + 18;
                    grb.Controls.Add(txt);
                    CheckBox chb = new CheckBox();
                    chb.Name = "chbP" + (partNo) + "S" + (segNo);
                    chb.Left = txt.Left + txt.Width;
                    chb.Top = txt.Top;
                    chb.Width = 15;
                    grb.Controls.Add(chb);
                    Label lbl = new Label();
                    lbl.Left = 2;
                    lbl.Name = "lblP" + (partNo) + "S" + (segNo);
                    lbl.Top = txt.Top + 4;
                    lbl.Text = (segNo + 1).ToString() + ":";
                    lbl.AutoSize = true;
                    grb.Controls.Add(lbl);
                    if (r.NextDouble() < 0.1)
                    {

                        txt.Text = "01 23 45 67 89 AB CD EF FE DC BA 98 76 54 32 10";
                        chb.Checked = true;
                    }
                }
            }
            grbCardData.Width = 3 * 293;
            grbCardData.Height = 5 * 90;
        }

        private void tccoRFID_OnDeviceConnect(string deviceIP)
        {
            txtLogs.Text += "DeviceIP " + deviceIP + " Connected\r\n";
            if (lstDevices.Items.IndexOfKey(deviceIP) < 0)
                lstDevices.Items.Add(deviceIP, deviceIP, 0);
        }

        private void tccoRFID_OnDeviceDisconnect(string deviceIP)
        {
            txtLogs.Text += "DeviceIP " + deviceIP + " Disconnected\r\n";
            lstDevices.Items.RemoveByKey(deviceIP);
        }

        DateTime dtStart;
        private void btnSend_Click(object sender, EventArgs e)
        {
            lastAction = 2;
            dtStart = DateTime.Now;
            string deviceIP = "";
            if (lstDevices.SelectedItems.Count > 0)
                deviceIP = lstDevices.SelectedItems[0].Name;
            else if (lstDevices.Items.Count == 1)
                deviceIP = lstDevices.Items[0].Name;
            if (deviceIP != "")
            {
                for (int segNo = 0; segNo < 45; segNo++)
                {
                    CheckBox chb = grbCardData.Controls["chb" + segNo] as CheckBox;
                    if (chb.Checked)
                    {
                        TextBox txt = grbCardData.Controls["txt" + segNo] as TextBox;
                        byte[] bytes = HexStringToBytes(txt.Text);
                        if (bytes.Length == 16)
                        {
                            for (int j = 0; j < 16; j++)
                                tccoRFID.CardReaders[deviceIP].Segments[segNo].Data[j] = bytes[j];
                            tccoRFID.CardReaders[deviceIP].Segments[segNo].ForWrite = true;
                        }
                        else
                            tccoRFID.CardReaders[deviceIP].Segments[segNo].ForWrite = false;
                    }
                    else
                        tccoRFID.CardReaders[deviceIP].Segments[segNo].ForWrite = false;
                }
                tccoRFID.WriteData(deviceIP);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string deviceIP = "";
            if (lstDevices.SelectedItems.Count > 0)
                deviceIP = lstDevices.SelectedItems[0].Name;
            else if (lstDevices.Items.Count == 1)
                deviceIP = lstDevices.Items[0].Name;
            if (deviceIP != "")
            {
                for (int segNo = 0; segNo < 45; segNo++)
                {
                    CheckBox chb = grbCardData.Controls["chb" + segNo] as CheckBox;
                    if (chb.Checked)
                    {
                        (grbCardData.Controls["txt" + segNo] as TextBox).Text = "";
                        tccoRFID.CardReaders[deviceIP].Segments[segNo].ForRead = true;
                    }
                    else
                        tccoRFID.CardReaders[deviceIP].Segments[segNo].ForRead = false;
                }
                tccoRFID.ReadData(deviceIP);
            }

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (lstDevices.SelectedItems.Count > 0)
                tccoRFID.EndSession(lstDevices.SelectedItems[0].Name);
            else if (lstDevices.Items.Count == 1)
                tccoRFID.EndSession(lstDevices.Items[0].Name);

        }


        private void btnSetIP_Click(object sender, EventArgs e)
        {
            byte[] p = { 192, 168, 0, 1 };

            System.Net.IPAddress ip = new System.Net.IPAddress(p);//(long)(192 << 24) + (long)(168 << 16) + (long)(2));
            Text = ip.ToString();
            IPAddress newIP, subnet, serverIP;
            bool isIpTrue = true;


            isIpTrue = IPAddress.TryParse(TrimForIP(txtIP.Text), out newIP);
            isIpTrue = isIpTrue & IPAddress.TryParse(TrimForIP(txtSubnet.Text), out subnet);
            isIpTrue = isIpTrue & IPAddress.TryParse(TrimForIP(txtServerIP.Text), out serverIP);
            if (isIpTrue)
            {
                if (lstDevices.SelectedItems.Count > 0)
                    tccoRFID.SetIP(lstDevices.SelectedItems[0].Name, newIP, subnet, serverIP);
                else if (lstDevices.Items.Count == 1)
                    tccoRFID.SetIP(lstDevices.Items[0].Name, newIP, subnet, serverIP);
            }

        }

        private string TrimForIP(string ip)
        {
            string[] bytes = ip.Split('.');
            string ipOut = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                bool canConvert = false;
                for (int j = 0; j < bytes[i].Length; j++)
                {
                    if (bytes[i][j] != '0' || j == bytes[i].Length - 1)
                        canConvert = true;
                    if (canConvert && Char.IsDigit(bytes[i][j]))
                        ipOut += bytes[i][j];
                }
                if (i < bytes.Length - 1)
                    ipOut += ".";
            }
            return ipOut;
        }
        //private StringToIP txtIP.Text.Split('.')

        private void btnSetDateTime_Click(object sender, EventArgs e)
        {
            if (lstDevices.SelectedItems.Count > 0 || lstDevices.Items.Count == 1)
            {
                string date = txtDate.Text.Replace("/", "");
                string time = txtTime.Text.Replace(":", "");
                string dt = "" + date[6] + date[7] + date[4] + date[5] + date[0] + date[1] + date[2] + date[3];
                if (lstDevices.SelectedItems.Count > 0)
                    tccoRFID.SetِDateTime(lstDevices.SelectedItems[0].Name, dt, time);
                else
                    tccoRFID.SetِDateTime(lstDevices.Items[0].Name, dt, time);

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls(this);

        }

        void ClearAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is NumericUpDown)
                    (control as NumericUpDown).Value = (control as NumericUpDown).Minimum;
                else if (control is TextBox)
                    (control as TextBox).Clear();
                else if (control is MaskedTextBox)
                    (control as MaskedTextBox).Clear();
                else if (control.HasChildren)
                    ClearAllControls(control);

            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (lstDevices.SelectedItems.Count > 0)
                tccoRFID.ResetDevice(lstDevices.SelectedItems[0].Name);
            else if (lstDevices.Items.Count == 1)
                tccoRFID.ResetDevice(lstDevices.Items[0].Name);
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            if (lstDevices.SelectedItems.Count > 0)
                tccoRFID.SetVolume(lstDevices.SelectedItems[0].Name, Byte.Parse(txtVolume.Text));
            else if (lstDevices.Items.Count == 1)
                tccoRFID.SetVolume(lstDevices.Items[0].Name, Byte.Parse(txtVolume.Text));
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            for (int segNo = 0; segNo < 45; segNo++)
            {
                if ((grbCardData.Controls["chb" + segNo] as CheckBox).Checked)
                {
                    TextBox txt = grbCardData.Controls["txt" + segNo] as TextBox;
                    txt.Text = "";
                    for (int j = 0; j < 16; j++)
                        txt.Text += txtFill.Text.ToUpper() + " ";
                }
            }
        }

        private void chbSelectAllAddress_CheckedChanged(object sender, EventArgs e)
        {
            for (int segNo = 0; segNo < 45; segNo++)
                (grbCardData.Controls["chb" + segNo] as CheckBox).Checked = chbSelectAllAddress.Checked;
        }

        
        private DateTime PersianDateToDateTime(string pdate)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = Convert.ToInt32(pdate.Substring(0, 4));
            int month = Convert.ToInt32(pdate.Substring(5, 2));
            int day = Convert.ToInt32(pdate.Substring(8, 2));
            int hour, minute, second;
            hour = minute = second = 0;
            if (pdate.Length > 10)
            {
                hour = Convert.ToInt32(pdate.Substring(11, 2));
                minute = Convert.ToInt32(pdate.Substring(14, 2));
                if (pdate.Length > 16)
                    second = Convert.ToInt32(pdate.Substring(17, 2));
            }

            return pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }
        private void SaveParkingCardInfo()
        {
            lastAction = 1;
            string deviceIP = "";
            if (lstDevices.SelectedItems.Count > 0)
                deviceIP = lstDevices.SelectedItems[0].Name;
            else if (lstDevices.Items.Count == 1)
                deviceIP = lstDevices.Items[0].Name;
            if (deviceIP.Length > 0)
            {
                if (txtCardRFID.Text.Length == 0)
                    txtCardRFID.Text = "1";
                //tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ID", Segments.FieldType.UInt32, Convert.ToUInt32(txtCardRFID.Text)); //4
                //tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("FName", Segments.FieldType.String, "کارت", 20); //20
                //tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("LName", Segments.FieldType.String, "پارکینگ", 24);//24
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("GroupNo", Segments.FieldType.Byte, txtGroupNo.Value);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterParkingNo", Segments.FieldType.UInt16, txtEnterParkingNo.Value);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitParkingNo", Segments.FieldType.UInt16, txtExitParkingNo.Value);

                DateTime dt = PersianDateToDateTime(txtEnterDate.Text + " " + txtEnterTime.Text);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateY", Segments.FieldType.Byte, dt.Year - 2000);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateM", Segments.FieldType.Byte, dt.Month);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterDateD", Segments.FieldType.Byte, dt.Day);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeH", Segments.FieldType.Byte, dt.Hour);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeM", Segments.FieldType.Byte, dt.Minute);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("EnterTimeS", Segments.FieldType.Byte, dt.Second);

                dt = PersianDateToDateTime(txtExitDate.Text + " " + txtExitTime.Text);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateY", Segments.FieldType.Byte, dt.Year - 2000);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateM", Segments.FieldType.Byte, dt.Month);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitDateD", Segments.FieldType.Byte, dt.Day);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitTimeH", Segments.FieldType.Byte, dt.Hour);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExitTimeM", Segments.FieldType.Byte, dt.Minute);

                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ParkingCost", Segments.FieldType.UInt32, txtCost.Value);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsCarInParking", Segments.FieldType.Boolean, chbIsEnter.Checked);


                dt = PersianDateToDateTime(txtExpireDate.Text);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateY", Segments.FieldType.Byte, dt.Year - 2000);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateM", Segments.FieldType.Byte, dt.Month);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("ExpireDateD", Segments.FieldType.Byte, dt.Day);

                dt = PersianDateToDateTime(txtTreatyExpireDate.Text);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateY", Segments.FieldType.Byte, dt.Year - 2000);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateM", Segments.FieldType.Byte, dt.Month);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyExpireDateD", Segments.FieldType.Byte, dt.Day);

                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("IsCardActive", Segments.FieldType.Boolean, chbIsCardActive.Checked);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("PersonnelCode", Segments.FieldType.UInt32, txtPersonnelCode.Value);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("AssetCode", Segments.FieldType.UInt32, txtAssetCode.Value);
                tccoRFID.CardReaders[deviceIP].Segments.AddFieldWithValue("TreatyCode", Segments.FieldType.UInt32, txtTreatyCode.Value);
                tccoRFID.WriteData(deviceIP);
            }
        }

        public bool FormatCard(Segments Seg)
        {
            try
            {
                //Seg.AddFieldWithValue("ID", Segments.FieldType.UInt32, 0); //4
                //Seg.AddFieldWithValue("FName", Segments.FieldType.String, "کارت", 20); //20
                //Seg.AddFieldWithValue("LName", Segments.FieldType.String, "پارکینگ", 24);//24
                Seg.AddField("GroupNo", Segments.FieldType.Byte);
                Seg.AddField("EnterParkingNo", Segments.FieldType.UInt16);
                Seg.AddField("ExitParkingNo", Segments.FieldType.UInt16);
                Seg.AddField("EnterDateY", Segments.FieldType.Byte);
                Seg.AddField("EnterDateM", Segments.FieldType.Byte);
                Seg.AddField("EnterDateD", Segments.FieldType.Byte);
                Seg.AddField("EnterTimeH", Segments.FieldType.Byte);
                Seg.AddField("EnterTimeM", Segments.FieldType.Byte);
                Seg.AddField("EnterTimeS", Segments.FieldType.Byte);
                Seg.AddField("ExitDateY", Segments.FieldType.Byte);
                Seg.AddField("ExitDateM", Segments.FieldType.Byte);
                Seg.AddField("ExitDateD", Segments.FieldType.Byte);
                Seg.AddField("ExitTimeH", Segments.FieldType.Byte);
                Seg.AddField("ExitTimeM", Segments.FieldType.Byte);
                Seg.AddField("ParkingCost", Segments.FieldType.UInt32);
                Seg.AddField("Charge", Segments.FieldType.Charge);
                Seg.AddField("IsCarInParking", Segments.FieldType.Boolean);
                Seg.AddField("ExpireDateY", Segments.FieldType.Byte);
                Seg.AddField("ExpireDateM", Segments.FieldType.Byte);
                Seg.AddField("ExpireDateD", Segments.FieldType.Byte);
                Seg.AddField("TreatyExpireDateY", Segments.FieldType.Byte);
                Seg.AddField("TreatyExpireDateM", Segments.FieldType.Byte);
                Seg.AddField("TreatyExpireDateD", Segments.FieldType.Byte);
                Seg.AddField("IsCardActive", Segments.FieldType.Boolean);

                Seg.AddField("PersonnelCode", Segments.FieldType.UInt32);
                Seg.AddField("AssetCode", Segments.FieldType.UInt32);
                Seg.AddField("TreatyCode", Segments.FieldType.UInt32);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void LoadCardParkingInfo(Segments segments)
        {
            try
            {
                byte a = (byte)segments.GetFieldValue("GroupNo");
                txtGroupNo.Value = Convert.ToDecimal(a);
                txtEnterParkingNo.Value = Convert.ToDecimal(segments.GetFieldValue("EnterParkingNo"));
                txtExitParkingNo.Value = Convert.ToDecimal(segments.GetFieldValue("ExitParkingNo"));
                int year = Convert.ToInt32(segments.GetFieldValue("EnterDateY")) + 2000;
                int month = Convert.ToInt32(segments.GetFieldValue("EnterDateM"));
                int day = Convert.ToInt32(segments.GetFieldValue("EnterDateD"));
                int hour = Convert.ToInt32(segments.GetFieldValue("EnterTimeH"));
                int minute = Convert.ToInt32(segments.GetFieldValue("EnterTimeM"));
                int second = Convert.ToInt32(segments.GetFieldValue("EnterTimeS"));
                if (year + month + day > 0)
                {
                    try
                    {
                        txtEnterDate.Text = TrimDate(new DateTime(year, month, day, hour, minute, second));
                        txtEnterTime.Text = TrimTime(new DateTime(year, month, day, hour, minute, second));
                    }
                    catch { }
                }

                year = Convert.ToInt32(segments.GetFieldValue("ExitDateY")) + 2000;
                month = Convert.ToInt32(segments.GetFieldValue("ExitDateM"));
                day = Convert.ToInt32(segments.GetFieldValue("ExitDateD"));
                hour = Convert.ToInt32(segments.GetFieldValue("ExitTimeH"));
                minute = Convert.ToInt32(segments.GetFieldValue("ExitTimeM"));
                if (year + month + day > 0)
                {
                    try
                    {
                        txtExitDate.Text = TrimDate(new DateTime(year, month, day, hour, minute, second));
                        txtExitTime.Text = TrimTime(new DateTime(year, month, day, hour, minute, second)).Substring(0, 5);
                    }
                    catch { }
                }
                txtCost.Value = Convert.ToDecimal(segments.GetFieldValue("ParkingCost"));
                //txtCharge.ResetText();
                txtCharge.Value = Convert.ToDecimal(segments.GetFieldValue("Charge"));
                //txtCharge.Refresh();
                //txtCharge.ResumeLayout();
                chbIsCardActive.Checked = (bool)segments.GetFieldValue("IsCarInParking");

                year = Convert.ToInt32(segments.GetFieldValue("ExpireDateY")) + 2000;
                month = Convert.ToInt32(segments.GetFieldValue("ExpireDateM"));
                day = Convert.ToInt32(segments.GetFieldValue("ExpireDateD"));
                if (year + month + day > 0)
                    try
                    {
                        txtExpireDate.Text = TrimDate(new DateTime(year, month, day, 0, 0, 0));
                    }
                    catch { }

                year = Convert.ToInt32(segments.GetFieldValue("TreatyExpireDateY")) + 2000;
                month = Convert.ToInt32(segments.GetFieldValue("TreatyExpireDateM"));
                day = Convert.ToInt32(segments.GetFieldValue("TreatyExpireDateD"));
                if (year + month + day > 0)
                    txtTreatyExpireDate.Text = TrimDate(new DateTime(year, month, day, 0, 0, 0));
                chbIsCardActive.Checked = (bool)segments.GetFieldValue("IsCardActive");
                txtPersonnelCode.Value = Convert.ToDecimal(segments.GetFieldValue("PersonnelCode"));
                txtAssetCode.Value = Convert.ToDecimal(segments.GetFieldValue("AssetCode"));
                txtTreatyCode.Value = Convert.ToDecimal(segments.GetFieldValue("TreatyCode"));
            }
            catch (Exception e)
            {
            }

        }

        private string TrimDate(DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(dt);
            int month = pc.GetMonth(dt);
            int day = pc.GetDayOfMonth(dt);
            string str = year.ToString() + "/";
            if (month < 10)
                str += "0";
            str += month.ToString() + "/";
            if (day < 10)
                str += "0";
            str += day.ToString();
            return str;
        }

        private string TrimTime(DateTime dt)
        {

            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;
            string str = "";
            if (hour < 10)
                str += "0";
            str += hour.ToString() + ":";
            if (minute < 10)
                str += "0";
            str += minute.ToString() + ":";
            if (second < 10)
                str += "0";
            str += second.ToString();
            return str;
        }

        private void btnSaveParkingCard_Click(object sender, EventArgs e)
        {
            SaveParkingCardInfo();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLogs.Text = "";
        }

        private void FrmSetDeviceCaed_FormClosing(object sender, FormClosingEventArgs e)
        {
            tccoRFID.Disconnect();
        }





    }
}

