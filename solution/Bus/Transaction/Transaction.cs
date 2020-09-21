using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.Transaction
{
    public enum JTransactionErrorType
    {
        UnknownHeader = 1,
        InvalidSizeOfBytes = 2,
        TimeHourOutOfRange = 10,
        TimeMinuteOutOfRange = 11,
        TimeSecondOutOfRange = 12,
        DateYearOutOfRange = 13,
        DateMonthOutOfRange = 14,
        DateDayOutOfRange = 15,
    }

    public enum JTransactionType
    {
        TicketHeader = 1,//بلیط اتوبوس
        TicketData = 2,
        AVLHeder = 100,
        AVLData = 101,
        //DriverLogin = 3 ,
        //DriverLogout = 4 ,
        //StartService = 5 ,
        //EndOfService = 6 ,
    }

    public class JTransactionHeader
    {
        public string IMEI;//8
        public UInt32 busSerial;//4
        public byte[] VERSION;//3

        #region Properties
        public List<JTransactionTicketHeader> TicketHeaders = new List<JTransactionTicketHeader>();
        public List<JTransactionAVLHeader> AVLHeaders = new List<JTransactionAVLHeader>();
        public string Error = "";
        public int ErrorNum = 0;
        #endregion

        public JTransactionHeader()
        {

        }

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            try
            {
                string err = "";
                int errNum = 0;

                // Check SizeOfBytes
                if (pData.Length - pStart < 15)
                {
                    err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":H:" + (pData.Length - pStart).ToString() + "/15";
                    errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
                }
                else
                {
                    byte[] bIMEI = new byte[8];
                    Buffer.BlockCopy(pData, pStart + 0, bIMEI, 0, 8);
                    this.IMEI = BitConverter.ToInt64(bIMEI, 0).ToString();
                    pOldData.AddRange(bIMEI);

                    byte[] bbusSerial = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 8, bbusSerial, 0, 4);
                    this.busSerial = BitConverter.ToUInt32(bbusSerial, 0);

                    byte[] bVERSION = new byte[3];
                    Buffer.BlockCopy(pData, pStart + 12, bVERSION, 0, 3);
                    this.VERSION = bVERSION;
                    pOldData.AddRange(bVERSION);
                }

                return new Tuple<int, string, int, List<byte>>(8 + 4 + 3 + pStart, err, errNum, pOldData);
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return new Tuple<int, string, int, List<byte>>(8 + 4 + 3 + pStart, ex.Message, 1, pOldData);
            }
        }

    }

    //public class JTransactionDriver
    //{
    //    public int Code { get; set; }
    //    public string GsmSerialNumber { get; set; } //len 8
    //    public string Version { get; set; }         //len 3
    //    public string EventDate { get; set; }       //len 3
    //    /// <summary>
    //    /// Bus Code + Device Code Front is 1 AND back is 2 12031-->1203 is bus code and 1 is CardReader Front
    //    /// </summary>
    //    public string DriveCart { get; set; }       //len 4
    //    public int LineNumber { get; set; }         //len 2
    //    public int DeviceNum { get; set; }          //len 3
    //    /// <summary>
    //    /// Uniq Code is Send From Device
    //    /// </summary>
    //    public int SendCode { get; set; }

    //    public bool Process(byte[] pData, int pStart)
    //    {
    //        return false;
    //    }

    //    public int Insert()
    //    {
    //        return 0;
    //    }
    //}

    public class JTransactionTicketHeader
    {
        public DateTime DATE; // 3
        public string DriverSerialCard; // 4
        public uint LineNumber; // 4
        public UInt32 busSerial; // 4

        public List<JTransactionTicket> Tickets = new List<JTransactionTicket>();

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            // Check SizeOfBytes
            if (pData.Length - pStart < 15)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":TH:" + (pData.Length - pStart).ToString() + "/15";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
                byte[] bDate = new byte[3];
                Buffer.BlockCopy(pData, pStart + 0, bDate, 0, 3);
                this.DATE = JTransactions.ConvertBytesToDateTime(bDate);
                pOldData.AddRange(bDate);

                byte[] bDriverSerialCard = new byte[4];
                Buffer.BlockCopy(pData, pStart + 3, bDriverSerialCard, 0, 4);
                this.DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0).ToString();
                pOldData.AddRange(bDriverSerialCard);

                byte[] bLineNumber = new byte[4];
                Buffer.BlockCopy(pData, pStart + 7, bLineNumber, 0, 4);
                this.LineNumber = BitConverter.ToUInt32(bLineNumber, 0);
                try
                {
                    pOldData.AddRange(BitConverter.GetBytes(Convert.ToInt16(this.LineNumber)).Take(2));
                }
                catch
                {
                    pOldData.AddRange(new byte[] { bLineNumber[2], bLineNumber[3] });
                }
                //pOldData.AddRange(bLineNumber);

                byte[] bbusSerial = new byte[4];
                Buffer.BlockCopy(pData, pStart + 11, bbusSerial, 0, 4);
                this.busSerial = BitConverter.ToUInt32(bbusSerial, 0);
                pOldData.AddRange(new byte[] { bbusSerial[1], bbusSerial[2], bbusSerial[3] });
                //pOldData.AddRange(bbusSerial);
            }

            return new Tuple<int, string, int, List<byte>>(3 + 4 + 4 + 4 + pStart, err, errNum, pOldData);
        }
    }

    public class JTransactionTicket
    {
        public uint transactionid;      //4
        public uint PassengerCardSerial;//4
        public uint CardType;           //1
        public int[] Time;              //3
        public uint TicketPrice;	    //2
        public uint RemainPrice;	    //2
        public uint ReaderID;           //1

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            // Check SizeOfBytes
            if (pData.Length - pStart < 15)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":T:" + (pData.Length - pStart).ToString() + "/17";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
                byte[] btransactionid = new byte[4];
                Buffer.BlockCopy(pData, pStart + 0, btransactionid, 0, 4);
                this.transactionid = BitConverter.ToUInt32(btransactionid, 0);

                byte[] bPassengerCardSerial = new byte[4];
                Buffer.BlockCopy(pData, pStart + 4, bPassengerCardSerial, 0, 4);
                this.PassengerCardSerial = BitConverter.ToUInt32(bPassengerCardSerial, 0);
                pOldData.AddRange(bPassengerCardSerial);

                byte[] bCardType = new byte[1];
                Buffer.BlockCopy(pData, pStart + 8, bCardType, 0, 1);
                this.CardType = Convert.ToUInt32(bCardType.First());
                pOldData.AddRange(bCardType);

                byte[] bTime = new byte[3];
                Buffer.BlockCopy(pData, pStart + 9, bTime, 0, 3);
                this.Time = JTransactions.ConvertBytesToTime(bTime);
                pOldData.AddRange(bTime);

                byte[] bTicketPrice = new byte[2];
                Buffer.BlockCopy(pData, pStart + 12, bTicketPrice, 0, 2);
                this.TicketPrice = BitConverter.ToUInt16(bTicketPrice, 0);
                pOldData.AddRange(bTicketPrice);

                byte[] bRemainPrice = new byte[2];
                Buffer.BlockCopy(pData, pStart + 14, bRemainPrice, 0, 2);
                this.RemainPrice = BitConverter.ToUInt16(bRemainPrice, 0);
                pOldData.AddRange(bRemainPrice);

                byte[] bReaderID = new byte[1];
                Buffer.BlockCopy(pData, pStart + 16, bReaderID, 0, 1);
                this.ReaderID = Convert.ToUInt32(bReaderID.First());
            }

            return new Tuple<int, string, int, List<byte>>(4 + 4 + 1 + 3 + 2 + 2 + 1 + pStart, err, errNum, pOldData);
        }

    }

    public class JTransactionTicketOffline
    {
        public UInt64 PassengerID;       //7
        public UInt64 DriverID;          //7    14
        public UInt32 DateTime;      //4      18
        public UInt32 BusID;             //3    21
        public UInt32 LineNumber;        //3    24 
        public UInt32 RemaningPrice;     //3    27
        public UInt16 Price;             //2    29
        public uint CardType;          //0.5    29.5
        public uint ReaderID;          //0.5    30
        public uint CheckSum;           //2     32

        public JTransactionTicketOffline()
        {
        }

        public Tuple<int> SetValueOffline(byte[] pData, int pStart)
        {
            try
            {

                //memcpy(&info.Pasenger_ID, data.data(), 7);
                //index += 7;
                //info.Pasenger_ID = info.Pasenger_ID>>8;

                //memcpy(&info.Driver_ID, data.data()+index, 7);
                //index += 7;
                //info.Driver_ID = info.Driver_ID>>8;

                //memcpy(&info.Datetime, data.data()+index, 4);
                //index += 4;

                //memcpy(&info.Bus_ID, data.data()+index, 3);
                //index += 3;
                //info.Bus_ID = info.Bus_ID>>8;

                //memcpy(&info.Line_Number, data.data()+index, 3);
                //index += 3;
                //info.Line_Number = info.Line_Number>>8;

                //memcpy(&info.RemainingPrice, data.data()+index, 3);
                //index += 3;
                //info.RemainingPrice = info.RemainingPrice>>8;

                //memcpy(&info.Price, data.data()+index, 2);
                //index += 2;

                //memcpy(&tmp8, data.data()+index, 1);
                //info.CardType  = (tmp8 & 0b00001111);
                //info.Reader_ID = (tmp8 & 0b11110000)>>4;


                byte[] bPassengerID = new byte[8];
                Buffer.BlockCopy(pData, pStart + 0, bPassengerID, 0, 7);
                this.PassengerID = BitConverter.ToUInt64(bPassengerID, 0) >> 8;

                byte[] bDriverID = new byte[8];
                Buffer.BlockCopy(pData, pStart + 7, bDriverID, 0, 7);
                this.DriverID = BitConverter.ToUInt64(bDriverID, 0) >> 8;

                byte[] bDataTime = new byte[4];
                Buffer.BlockCopy(pData, pStart + 14, bDataTime, 0, 4);
                this.DateTime = BitConverter.ToUInt32(bDataTime, 0);

                byte[] bBusID = new byte[4];
                Buffer.BlockCopy(pData, pStart + 18, bBusID, 0, 3);
                this.BusID = BitConverter.ToUInt32(bBusID, 0) >> 8;

                byte[] bLineNumber = new byte[4];
                Buffer.BlockCopy(pData, pStart + 21, bLineNumber, 0, 3);
                this.LineNumber = BitConverter.ToUInt32(bLineNumber, 0) >> 8;

                byte[] bRemainPrice = new byte[4];
                Buffer.BlockCopy(pData, pStart + 24, bRemainPrice, 0, 3);
                this.RemaningPrice = BitConverter.ToUInt32(bRemainPrice, 0) >> 8;

                byte[] bPrice = new byte[2];
                Buffer.BlockCopy(pData, pStart + 27, bPrice, 0, 2);
                this.Price = BitConverter.ToUInt16(bPrice, 0);

                byte pCardTypeReaderID = pData[pStart + 29];
                this.CardType = (uint)pCardTypeReaderID & 0x00001111;
                this.ReaderID = ((uint)pCardTypeReaderID & 0x11110000) >> 4;
            }
            catch (Exception ex)
            {
            }

            return new Tuple<int>(7 + 7 + 4 + 3 + 3 + 3 + 2 + 1 + 2 + pStart);
        }


    }

    public class JTransactionAVLHeader
    {
        public DateTime DATE; //3
        public uint SimCharge;//2
        public uint Battryvoltvalue;//2
        public uint GpsAnttena;//1
        public uint GsmAnttena;//1
        public UInt32 busSerial;//4

        public List<JTransactionAVL> AVLs = new List<JTransactionAVL>();

        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            string err = "";
            int errNum = 0;

            // Check SizeOfBytes
            if (pData.Length - pStart < 15)
            {
                err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":AH:" + (pData.Length - pStart).ToString() + "/13";
                errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
            }
            else
            {
                byte[] bDATE = new byte[3];
                Buffer.BlockCopy(pData, pStart + 0, bDATE, 0, 3);
                this.DATE = JTransactions.ConvertBytesToDateTime(bDATE);
                pOldData.AddRange(bDATE);

                byte[] bSimCharge = new byte[2];
                Buffer.BlockCopy(pData, pStart + 3, bSimCharge, 0, 2);
                this.SimCharge = BitConverter.ToUInt16(bSimCharge, 0);
                pOldData.AddRange(bSimCharge);

                byte[] bBattryvoltvalue = new byte[2];
                Buffer.BlockCopy(pData, pStart + 5, bBattryvoltvalue, 0, 2);
                this.Battryvoltvalue = BitConverter.ToUInt16(bBattryvoltvalue, 0);
                pOldData.AddRange(bBattryvoltvalue);

                byte[] bGpsAnttena = new byte[1];
                Buffer.BlockCopy(pData, pStart + 7, bGpsAnttena, 0, 1);
                this.GpsAnttena = Convert.ToUInt32(bGpsAnttena.First());
                pOldData.AddRange(bGpsAnttena);

                byte[] bGsmAnttena = new byte[1];
                Buffer.BlockCopy(pData, pStart + 8, bGsmAnttena, 0, 1);
                this.GsmAnttena = Convert.ToUInt32(bGsmAnttena.First());
                pOldData.AddRange(bGsmAnttena);

                byte[] bbusSerial = new byte[4];
                Buffer.BlockCopy(pData, pStart + 9, bbusSerial, 0, 4);
                this.busSerial = BitConverter.ToUInt32(bbusSerial, 0);
            }

            return new Tuple<int, string, int, List<byte>>(3 + 2 + 2 + 1 + 1 + 4 + pStart, err, errNum, pOldData);
        }
    }

    public class JTransactionAVL
    {
        public uint transactionid;//4
        public int[] Time;//3
        public float Lon;//4
        public float Lat;//4
        public uint Alt;//2
        public uint Speed;//2
        public uint Cource;//1
        public uint Dir;//1


        public JTransactionAVL()
        {
        }
        public Tuple<int, string, int, List<byte>> SetValue(byte[] pData, int pStart, List<byte> pOldData)
        {
            try
            {
                string err = "";
                int errNum = 0;

                // Check SizeOfBytes
                if (pData.Length < pStart + 20)
                {

                    err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":A:" + (pData.Length - pStart).ToString() + "/18";
                    errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
                }
                if (pData.Length - pStart < 15)
                {
                    err = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode().ToString() + ":A:" + (pData.Length - pStart).ToString() + "/18";
                    errNum = JTransactionErrorType.InvalidSizeOfBytes.GetHashCode();
                }
                else
                {
                    byte[] btransactionid = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 0, btransactionid, 0, 4);
                    this.transactionid = BitConverter.ToUInt32(btransactionid, 0);

                    byte[] bTime = new byte[3];
                    Buffer.BlockCopy(pData, pStart + 4, bTime, 0, 3);
                    this.Time = JTransactions.ConvertBytesToTime(bTime);
                    pOldData.AddRange(bTime);

                    float NewLon;
                    byte[] bLon = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 7, bLon, 0, 4);
                    NewLon = BitConverter.ToSingle(bLon, 0);
                    int TempNewLon = (int)Math.Floor(NewLon);
                    //this.Lon = (float)((TempNewLon / 100) + ((TempNewLon % 100) / 60.0) + ((NewLon - TempNewLon) / 3600));// (float)(Math.Floor(TempNewLon / 100.0) + (TempNewLon % 100) / 60.0 + (NewLon - TempNewLon) / 3600.0);
                    if (TempNewLon > 999)
                        this.Lon = NewLon / 100;
                    else
                        this.Lon = NewLon;
                    pOldData.AddRange(bLon);

                    float NewLat;
                    byte[] bLat = new byte[4];
                    Buffer.BlockCopy(pData, pStart + 11, bLat, 0, 4);
                    NewLat = BitConverter.ToSingle(bLat, 0);
                    int TempNewLat = (int)Math.Floor(NewLat);
                    //this.Lat = (float)((TempNewLat / 100) + ((TempNewLat % 100) / 60.0) + ((NewLat - TempNewLat) / 3600));// (float)(Math.Floor(TempNewLat / 100.0) + (TempNewLat % 100) / 60.0 + (NewLat - TempNewLat) / 3600.0);
                    if (TempNewLat > 999)
                        this.Lat = NewLat / 100;
                    else
                        this.Lat = NewLat;
                    pOldData.AddRange(bLat);

                    byte[] bAlt = new byte[2];
                    Buffer.BlockCopy(pData, pStart + 15, bAlt, 0, 2);
                    this.Alt = BitConverter.ToUInt16(bAlt, 0);
                    pOldData.AddRange(bAlt);

                    byte[] bSpeed = new byte[2];
                    Buffer.BlockCopy(pData, pStart + 17, bSpeed, 0, 2);
                    this.Speed = BitConverter.ToUInt16(bSpeed, 0);
                    pOldData.AddRange(bSpeed);

                    if (pData.Length > pStart + 19)
                    {
                        byte[] bCource = new byte[1];
                        Buffer.BlockCopy(pData, pStart + 19, bCource, 0, 1);
                        this.Cource = Convert.ToUInt32(bCource.First());
                        pOldData.AddRange(bCource);
                    }

                    if (pData.Length > pStart + 20)
                    {
                        byte[] bDir = new byte[1];
                        Buffer.BlockCopy(pData, pStart + 20, bDir, 0, 1);
                        this.Dir = Convert.ToUInt32(bDir.First());
                        pOldData.AddRange(bDir);
                    }
                }

                return new Tuple<int, string, int, List<byte>>(4 + 3 + 4 + 4 + 2 + 2 + 1 + 1 + pStart, err, errNum, pOldData);
            }
            catch (Exception ex)
            {
                return new Tuple<int, string, int, List<byte>>(4 + 3 + 4 + 4 + 2 + 2 + 1 + 1 + pStart, ex.Message, 1, pOldData);
            }
        }
        //2.180.16.59	2mb
        public KeyValuePair<string, int> GetClassNameBusNumber(byte[] pData)
        {
            JTransactions t = new JTransactions();
            Tuple<JTransactionHeader, byte[]> item = t.Process(pData);
            if (item != null && item.Item1.AVLHeaders.Count > 0)
            {
                t.ProcessAvlData(pData, 0, false, true);
                KeyValuePair<string, int> K = new KeyValuePair<string, int>("BusManagment.TransactionAVL", (int)item.Item1.AVLHeaders[0].busSerial);
                return K;
            }
            else
            {
                KeyValuePair<string, int> K = new KeyValuePair<string, int>("BusManagment.TransactionAVL", -1);
                return K;
            }
        }
    }

    public class JTransactions
    {
        public Tuple<JTransactionHeader, byte[]> Process(byte[] pData)
        {
            try
            {
                int NextIndex = 0;
                List<byte> OldData = new List<byte>();

                JTransactionHeader TH = new JTransactionHeader();
                Tuple<int, string, int, List<byte>> result = TH.SetValue(pData, 0, OldData);
                if (result.Item3 > 0)
                {
                    TH.Error = result.Item2;
                    TH.ErrorNum = result.Item3;
                    return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                }
                OldData = result.Item4;
                NextIndex = result.Item1;

                while (NextIndex < pData.Length)
                {
                    int _NCode = (int)pData[NextIndex++];
                    if (_NCode == JTransactionType.TicketHeader.GetHashCode())
                    {
                        byte header = 1;
                        OldData.Add(header);
                        JTransactionTicketHeader TTH = new JTransactionTicketHeader();
                        result = TTH.SetValue(pData, NextIndex, OldData);
                        if (result.Item3 > 0)
                        {
                            TH.Error = result.Item2;
                            TH.ErrorNum = result.Item3;
                            return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                        }
                        OldData = result.Item4;
                        NextIndex = result.Item1;

                        TH.TicketHeaders.Add(TTH);
                    }

                    else if (_NCode == JTransactionType.TicketData.GetHashCode())
                    {
                        JTransactionTicket TT = new JTransactionTicket();
                        byte header = 2;
                        OldData.Add(header);
                        result = TT.SetValue(pData, NextIndex, OldData);
                        if (result.Item3 > 0)
                        {
                            TH.Error = result.Item2;
                            TH.ErrorNum = result.Item3;
                            return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                        }
                        OldData = result.Item4;
                        NextIndex = result.Item1;
                        TH.TicketHeaders.Last().Tickets.Add(TT);
                    }

                    else if (_NCode == JTransactionType.AVLHeder.GetHashCode())
                    {
                        JTransactionAVLHeader TAH = new JTransactionAVLHeader();
                        byte header = 100;
                        OldData.Add(header);
                        result = TAH.SetValue(pData, NextIndex, OldData);
                        if (result.Item3 > 0)
                        {
                            TH.Error = result.Item2;
                            TH.ErrorNum = result.Item3;
                            return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                        }
                        OldData = result.Item4;
                        NextIndex = result.Item1;
                        TH.AVLHeaders.Add(TAH);
                    }

                    else if (_NCode == JTransactionType.AVLData.GetHashCode())
                    {
                        JTransactionAVL TA = new JTransactionAVL();
                        byte header = 101;
                        OldData.Add(header);
                        result = TA.SetValue(pData, NextIndex, OldData);
                        if (result.Item3 > 0)
                        {
                            TH.Error = result.Item2;
                            TH.ErrorNum = result.Item3;
                            return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
                        }
                        OldData = result.Item4;
                        NextIndex = result.Item1;
                        TH.AVLHeaders.Last().AVLs.Add(TA);
                    }

                    else
                    {
                        //TH.ErrorNum = 1;

                    }

                }

                return new Tuple<JTransactionHeader, byte[]>(TH, OldData.ToArray());
            }
            catch (Exception ex)
            {

                JSystem.Except.AddException(new Exception("public Tuple<JTransactionHeader, byte[]> Process(byte[] pData) " + ex.Message));
                return null;
            }
        }

        struct BusTicketRecord
        {
            public byte[] Data;
            public Int64 RecordNumber;
        }


        private readonly object listLock = new object();
        public void CheckDataTicket()
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                DataTable dt;
                lock (listLock)
                {
                    mysqlDB.setQuery("Select * from cardinfo_bin order by Code desc LIMIT 0,200");
                    dt = mysqlDB.Query_DataTable();
                    if (dt.Rows.Count > 0 && Transaction.JDeviceDB.MoveTicketRecord(dt.Rows, "", 0, mysqlDB) == true)
                    {
                        //test
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    byte[] Data = (byte[])row["Data"];
                    Int64 RecordNumber = (Int64)row["RecordNumber"];
                    ProcessTicketData(Data, RecordNumber, true);

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                mysqlDB.Dispose();
            }
        }


        public void CheckDataTicketSocket(byte[] Data, long RecordNumber)
        {
            try
            {
                ProcessTicketData(Data, RecordNumber, true);
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }


        public static bool SavePrintInMySql(ClassLibrary.JMySQLDataBase mysqlDB, int Code, int BusNumber, DateTime StartDate, DateTime EndDate, int SendData)
        {
            mysqlDB.setQuery(@"INSERT INTO `getdataticket`(`Code`, `busserial`, `state`, `startdate`, `enddate`, `isSent`, `RowCount`, `RowSent`) 
                               VALUES (" + Code + @"," + BusNumber + @",0,'" + StartDate.Year + "/" + StartDate.Month + @"/" + StartDate.Day + @" " + StartDate.Hour + @":" + StartDate.Minute + @":" + StartDate.Second + @"',
                               '" + EndDate.Year + "/" + EndDate.Month + "/" + EndDate.Day + @" " + EndDate.Hour + @":" + EndDate.Minute + @":" + EndDate.Second + @"'," + SendData + @",0,0)");
            return mysqlDB.Query_Execute() > 0 ? true : false;
        }

        public void CalenderRepairMethod(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("*** Start CalenderRepairMethod " + DateTime.Now.ToLongTimeString()));
            Db.setQuery(@"select BusNumber,cast(Date as date)FDate,(case when ApplyTicketCount = 0 or TicketCount > ApplyTicketCount then 0 else 1 end)SendData
                            from AUTBusPerformanceCalenderReport 
                            where ((TicketCount < ApplyTicketCount) or (ApplyTicketCount = 0) or (TicketCount > ApplyTicketCount)) and RepairOk = 0 and Date < DATEADD(DAY,-2,GETDATE()) 
                            order by Date desc");
            DataTable Dt = Db.Query_DataTable();
            if (Dt != null & Dt.Rows.Count > 0)
            {
                ClassLibrary.JSystem.Except.AddException(new Exception("*** Start CalenderRepairMethod - InsertDailyPrintRequest " + DateTime.Now.ToLongTimeString()));
                int SqlLastInsertCode;
                BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {

                    Db.setQuery(@"delete from AUTPrinterRporte where BusNumber = " + Dt.Rows[i]["BusNumber"].ToString() + @" 
                                  and cast(StartDate as date) = '" + Dt.Rows[i]["FDate"].ToString() + @"' and cast(startdate as time)='00:00:00' and cast(EndDate as time)='23:59:59'");
                    Db.Query_Execute();

                    TransactionPrint.BusNumber = Convert.ToInt32(Dt.Rows[i]["BusNumber"].ToString());
                    TransactionPrint.StartDate = Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00");
                    TransactionPrint.EndDate = Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59");
                    TransactionPrint.TicketCount = 0;
                    TransactionPrint.TicketSent = 0;
                    TransactionPrint.State = 0;
                    TransactionPrint.DailyCode = 0;
                    SqlLastInsertCode = TransactionPrint.Insert();

                    SavePrintInMySql(MySqlDb, SqlLastInsertCode,
                        Convert.ToInt32(Dt.Rows[i]["BusNumber"].ToString()),
                        Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00"),
                        Convert.ToDateTime(Convert.ToDateTime(Dt.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59"), Convert.ToInt32(Dt.Rows[i]["SendData"].ToString()));

                    Db.setQuery(@"update AUTBusPerformanceCalenderReport set RepairOk = ISNULL(RepairOk,0) + 1 where BusNumber = " + Dt.Rows[i]["BusNumber"].ToString() + @"
                    and cast(Date as date) = cast('" + Dt.Rows[i]["FDate"].ToString() + @"' as date)");
                    Db.Query_Execute();

                }
                ClassLibrary.JSystem.Except.AddException(new Exception("*** End CalenderRepairMethod - InsertDailyPrintRequest " + DateTime.Now.ToLongTimeString()));
            }
            ClassLibrary.JSystem.Except.AddException(new Exception("*** End CalenderRepairMethod " + DateTime.Now.ToLongTimeString()));
        }

        public void CalenderRepairFrontAndBackDoorMethod(ClassLibrary.JDataBase Db)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("*** Start CalenderRepairFrontAndBackDoorMethod " + DateTime.Now.ToLongTimeString()));

            Db.setQuery(@"select Code,BusNumber,cast(Date as date)FDate from AUTBusPerformanceCalenderReport a where (a.FrontDoor+a.BackDoor)<>a.TicketCount and Date < DATEADD(DAY,-2,getdate()) order by Date desc");
            DataTable Dt = Db.Query_DataTable();
            if (Dt != null & Dt.Rows.Count > 0)
            {
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    Db.setQuery("EXEC [dbo].[UpdateAUTBusPerformanceCalenderReportFrontAndBackDoor] '" + Dt.Rows[i]["FDate"].ToString() + "'," +
                        Dt.Rows[i]["BusNumber"].ToString() + "," + Dt.Rows[i]["Code"].ToString());
                    Db.Query_Execute();
                }
            }

            ClassLibrary.JSystem.Except.AddException(new Exception("*** End CalenderRepairFrontAndBackDoorMethod " + DateTime.Now.ToLongTimeString()));
        }

        public void ProcessTicketData(byte[] Data, Int64 pRecordNumber, bool pThread)
        {
            BusTicketRecord B = new BusTicketRecord();
            B.Data = Data;
            B.RecordNumber = pRecordNumber;

            if (pThread)
            {
                System.Threading.Thread N = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_CheckDataTicket));
                N.Start(B);
            }
            else
            {
                _CheckDataTicket(B);
            }

        }
        private void _CheckDataTicket(Object B)
        {
            CheckDataTicket(((BusTicketRecord)B).RecordNumber, ((BusTicketRecord)B).Data);
        }
        public void CheckDataTicket(long RecordNumber, byte[] Data)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                Tuple<JTransactionHeader, byte[]> result = Process(Data as byte[]);
                bool isSuccess = true;
                Int64 recordNumber = Convert.ToInt64(RecordNumber);
                if (result.Item1.ErrorNum == 0)
                    if (result.Item1.TicketHeaders != null && result.Item1.TicketHeaders.Count() > 0)
                        foreach (var TH in result.Item1.TicketHeaders)
                        {
                            if (isSuccess == false) break;

                            if (TH.Tickets != null && TH.Tickets.Count() > 0)
                            {
                                DateTime date = TH.DATE;
                                foreach (var Ticket in TH.Tickets)
                                {
                                    DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

                                    isSuccess = Transaction.JTicketTransactions.AddTicketTransaction(TH, Ticket, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION, db);
                                    if (isSuccess == false)
                                    {
                                        ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save Ticket:" +
                                             Ticket.transactionid.ToString() + " " +
                                             TH.busSerial.ToString() + " " +
                                             TH.DATE.ToString()));
                                        //break;
                                    }
                                }
                            }
                        }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                db.Dispose();
            }
        }


        public void CheckDataSQLiteTicket()
        {
            int Code = 0;
            int ArchiveCode = 0;
            byte[] Content = new byte[0];
            JSQLiteDataBase SQLiteDB = null;
            DataTable SQLiteDT = null;

            ClassLibrary.JFile File = new ClassLibrary.JFile();

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery(@"SELECT ac.[Code] ,ac.[Contents],(select top 1 Code From ArchiveInterface where ArchiveCode = ac.[Code]) as ArchiveCode 
                                    FROM [ArchiveContent] ac  where Status=1 and FileExtension like N'.db'");
                DataTable DT = Archivedb.Query_DataTable();
                foreach (DataRow DR in DT.Rows)
                {

                    try
                    {
                        Code = int.Parse(DR["Code"].ToString());
                        Content = (DR["Contents"] as byte[]);
                        ArchiveCode = int.Parse(DR["ArchiveCode"].ToString());

                        string FileName = Guid.NewGuid().ToString() + ".db";

                        File.Content = Content;
                        File.FileName = ClassLibrary.JConfig.appPath + "\\" + FileName;
                        File.Write();

                        JConnection C = new JConnection();

                        SQLiteDB = new JSQLiteDataBase(C.GetSQLiteConnection(File.FileName));

                        SQLiteDB.setQuery("SELECT  * FROM \"cardinfo\";");
                        SQLiteDT = SQLiteDB.Query_DataTable();
                    }
                    catch
                    {
                    }

                    if (SQLiteDT != null)
                    {
                        foreach (DataRow SQLiteDR in SQLiteDT.Rows)
                        {
                            try
                            {

                                bool isSuccess = true;
                                JTransactionTicketHeader TH = new JTransactionTicketHeader();
                                TH.busSerial = uint.Parse(SQLiteDR["BUSSerial"].ToString());
                                TH.DATE = JTransactions.ConvertUintToDateTime(ulong.Parse(SQLiteDR["DateTime"].ToString()));
                                TH.DriverSerialCard = SQLiteDR["DriverSerial"].ToString();
                                TH.LineNumber = uint.Parse(SQLiteDR["LineNumber"].ToString());
                                DateTime date = TH.DATE;

                                JTransactionTicket Ticket = new JTransactionTicket();
                                Ticket.CardType = uint.Parse(SQLiteDR["CardType"].ToString());
                                Ticket.PassengerCardSerial = uint.Parse(SQLiteDR["RFID"].ToString());
                                Ticket.ReaderID = uint.Parse(SQLiteDR["ReaderId"].ToString());
                                Ticket.RemainPrice = uint.Parse(SQLiteDR["RemainPrice"].ToString());
                                Ticket.TicketPrice = uint.Parse(SQLiteDR["Price"].ToString());
                                Ticket.Time = new int[3] { TH.DATE.Hour, TH.DATE.Minute, TH.DATE.Second };
                                Ticket.transactionid = uint.Parse(SQLiteDR["index"].ToString());

                                DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

                                isSuccess = Transaction.JTicketTransactions.AddTicketTransaction(TH, Ticket, Ticket.transactionid, "0"
                                    , TH.busSerial, new byte[] { 1 }, db, ArchiveCode);
                                if (isSuccess)
                                {
                                    db.setQuery(@"INSERT INTO [dbo].[ArchiveContentExtracted]
                                                   ([ArchiveContentCode]
                                                   ,[recordNumber]
                                                   ,[TransactionID]
                                                   ,[LineNumber]
                                                   ,[BusSerial]
                                                   ,[DriverSerialCard]
                                                   ,[PassengerCardSerial]
                                                   ,[CardType]
                                                   ,[EventDate]
                                                   ,[TicketPrice]
                                                   ,[ReaderID]
                                                   ,[RemainPrice]
                                                   ,[IMEI]
                                                   ,[VERSION])
                                             VALUES
                                                   (" + ArchiveCode + @"
                                                   ,'" + SQLiteDR["index"].ToString() + @"'
                                                   ,'" + SQLiteDR["index"].ToString() + @"'
                                                   ,'" + SQLiteDR["LineNumber"].ToString() + @"'
                                                   ,'" + SQLiteDR["BUSSerial"].ToString() + @"'
                                                   ,'" + SQLiteDR["DriverSerial"].ToString() + @"'
                                                   ,'" + SQLiteDR["RFID"].ToString() + @"'
                                                   ,'" + SQLiteDR["CardType"].ToString() + @"'
                                                   ,'" + SQLiteDR["DateTime"].ToString() + @"'
                                                   ,'" + SQLiteDR["Price"].ToString() + @"'
                                                   ,'" + SQLiteDR["ReaderId"].ToString() + @"'
                                                   ,'" + SQLiteDR["RemainPrice"].ToString() + @"'
                                                   ,'0'
                                                   ,'0')");
                                    db.Query_Execute();
                                }
                                else
                                    if (isSuccess == false)
                                    {
                                        ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save Ticket:" +
                                             Ticket.transactionid.ToString() + " " +
                                             TH.busSerial.ToString() + " " +
                                             TH.DATE.ToString()));
                                        //break;
                                    }

                            }//try
                            catch (Exception ex)
                            {
                                ClassLibrary.JSystem.Except.AddException(ex);
                            }
                            finally
                            {
                            }

                        }// FOreach
                    }//IF
                    Archivedb.setQuery("Update ArchiveContent Set Status=2 where Code=" + Code.ToString());
                    Archivedb.Query_Execute();
                    System.IO.File.Delete(File.FileName);
                }//foreach
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
            }
        }




        //Open SqlLite File
        public DataTable OpenSQLiteTicketDataBase(int ArchiveContentCode)
        {
            int Code = 0;
            byte[] Content = new byte[0];
            JSQLiteDataBase SQLiteDB = null;
            DataTable SQLiteDT = null;

            ClassLibrary.JFile File = new ClassLibrary.JFile();

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery("SELECT [Code] ,[Contents] FROM [ArchiveContent]  where Code = " + ArchiveContentCode);
                DataTable DT = Archivedb.Query_DataTable();
                //foreach (DataRow DR in DT.Rows)
                //{

                try
                {
                    Code = int.Parse(DT.Rows[0]["Code"].ToString());
                    Content = (DT.Rows[0]["Contents"] as byte[]);

                    string FileName = Guid.NewGuid().ToString() + ".db";

                    File.Content = Content;
                    File.FileName = ClassLibrary.JConfig.appPath + "\\" + FileName;
                    File.Write();

                    JConnection C = new JConnection();

                    SQLiteDB = new JSQLiteDataBase(C.GetSQLiteConnection(File.FileName));

                    SQLiteDB.setQuery("SELECT  * FROM \"cardinfo\";");
                    SQLiteDT = SQLiteDB.Query_DataTable();
                }
                catch
                {
                    return null;
                }

                if (SQLiteDT != null)
                {
                    return SQLiteDT;
                }
                else
                {
                    return null;
                }//IF
            }//foreach
            //}
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
            }
        }


        public static DataTable OpenSQLiteTicketDataBaseSt(int ArchiveContentCode)
        {
            int Code = 0;
            byte[] Content = new byte[0];
            JSQLiteDataBase SQLiteDB = null;
            DataTable SQLiteDT = null;

            ClassLibrary.JFile File = new ClassLibrary.JFile();

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery("SELECT [Code] ,[Contents] FROM [ArchiveContent]  where Code = " + ArchiveContentCode);
                DataTable DT = Archivedb.Query_DataTable();
                //foreach (DataRow DR in DT.Rows)
                //{

                try
                {
                    Code = int.Parse(DT.Rows[0]["Code"].ToString());
                    Content = (DT.Rows[0]["Contents"] as byte[]);

                    string FileName = Guid.NewGuid().ToString() + ".db";

                    File.Content = Content;
                    File.FileName = ClassLibrary.JConfig.appPath + "\\" + FileName;
                    File.Write();

                    JConnection C = new JConnection();

                    SQLiteDB = new JSQLiteDataBase(C.GetSQLiteConnection(File.FileName));

                    SQLiteDB.setQuery("SELECT  * FROM \"cardinfo\";");
                    SQLiteDT = SQLiteDB.Query_DataTable();
                }
                catch
                {
                    return null;
                }

                if (SQLiteDT != null)
                {
                    return SQLiteDT;
                }
                else
                {
                    return null;
                }//IF
            }//foreach
            //}
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
            }
        }


        public void CheckDataOfflineTicket()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ArchivedDocuments.JArchiveDataBase Archivedb = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                Archivedb.setQuery("SELECT [Code] ,[Contents] FROM [ArchiveContent]  where Status=1 and FileExtension like N'.BUS'");
                DataTable DT = Archivedb.Query_DataTable();
                foreach (DataRow DR in DT.Rows)
                {
                    byte[] Content = (DR["Contents"] as byte[]);
                    int Code = (int)DR["Code"];

                    int i = 0;
                    while (i < Content.Length)
                    {
                        try
                        {
                            JTransactionTicketOffline TransactionTicketOffline = new JTransactionTicketOffline();
                            Tuple<int> result = TransactionTicketOffline.SetValueOffline(Content, i);

                            bool isSuccess = true;
                            JTransactionTicketHeader TH = new JTransactionTicketHeader();
                            TH.busSerial = TransactionTicketOffline.BusID;
                            TH.DATE = JTransactions.ConvertUintToDateTime(TransactionTicketOffline.DateTime);
                            TH.DriverSerialCard = TransactionTicketOffline.DriverID.ToString();
                            TH.LineNumber = TransactionTicketOffline.LineNumber;
                            DateTime date = TH.DATE;

                            JTransactionTicket Ticket = new JTransactionTicket();
                            Ticket.CardType = TransactionTicketOffline.CardType;
                            Ticket.PassengerCardSerial = (uint)TransactionTicketOffline.PassengerID;
                            Ticket.ReaderID = TransactionTicketOffline.ReaderID;
                            Ticket.RemainPrice = TransactionTicketOffline.RemaningPrice;
                            Ticket.TicketPrice = TransactionTicketOffline.Price;
                            Ticket.Time = new int[3] { TH.DATE.Hour, 
                            TH.DATE.Minute, 
                            TH.DATE.Second };
                            Ticket.transactionid = (uint)Code;

                            DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

                            isSuccess = Transaction.JTicketTransactions.AddTicketTransaction(TH, Ticket, Code, "0", TransactionTicketOffline.BusID, new byte[] { 1 }, db);
                            if (isSuccess)
                            {
                            }
                            else
                                if (isSuccess == false)
                                {
                                    ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save Ticket:" +
                                         Ticket.transactionid.ToString() + " " +
                                         TH.busSerial.ToString() + " " +
                                         TH.DATE.ToString()));
                                    //break;
                                }

                        }//try
                        catch (Exception ex)
                        {
                            ClassLibrary.JSystem.Except.AddException(ex);
                        }
                        finally
                        {
                        }

                        i += 32;

                    }// While
                    Archivedb.setQuery("Update ArchiveContent Set Status=2 where Code=" + Code.ToString());
                    Archivedb.Query_Execute();
                }//foreach
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Archivedb.Dispose();
                db.Dispose();
            }
        }

        //Open Bus Offline Files
        public DataTable OpenBusOfflineTicketFile(int ArchiveContentCode)
        {
            DataTable dt = new DataTable();
            dt = null;
            return dt;
        }


        public int UpdateSocketCheckDataAVL(Int64 Code)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("update ClsSocketClientDataManager set IsProceced=1 where code = " + Code);
                return db.Query_Execute();
            }
            finally
            {
                db.Dispose();
            }
        }

        public void SocketCheckDataAVL(JDataBase db)
        {
            try
            {
                return;
                db.setQuery(@"select top 10 * from [ClsSocketClientDataManager] where IsProceced=0 order by GetDate desc");
                DataTable dt = db.Query_DataTable();

                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        ProcessAvlData(row["data"] as byte[], Convert.ToInt64(row["code"]), true, false);
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);
                    }
                    finally
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
            }
        }


        struct BusAvlRecord
        {
            public byte[] Data;
            public Int64 RecordNumber;
            public bool UpdateSocketTable;
        }
        public void ProcessAvlData(byte[] Data, Int64 pRecordNumber, bool pUpdateSocketTable, bool pThread)
        {
            BusAvlRecord B = new BusAvlRecord();
            B.Data = Data;
            B.RecordNumber = pRecordNumber;
            B.UpdateSocketTable = pUpdateSocketTable;

            if (pThread)
            {
                System.Threading.Thread N = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(_ProcessAvlData));
                N.Start(B);
            }
            else
            {
                _ProcessAvlData(B);
            }

        }
        private void _ProcessAvlData(Object pBusAvlRecord)
        {


            byte[] Data = ((BusAvlRecord)pBusAvlRecord).Data;
            Int64 pRecordNumber = ((BusAvlRecord)pBusAvlRecord).RecordNumber;
            bool pUpdateSocketTable = ((BusAvlRecord)pBusAvlRecord).UpdateSocketTable;

            JDataBase _DB = new JDataBase();
            try
            {
                if (pUpdateSocketTable)
                {
                    if (UpdateSocketCheckDataAVL(pRecordNumber) > 0)
                    {
                    }
                }
                Tuple<JTransactionHeader, byte[]> result = Process(Data);
                if (result == null) return;
                bool isSuccess = true;
                Int64 recordNumber = pRecordNumber;
                if (result != null && result.Item1.ErrorNum == 0)
                    if (result.Item1.AVLHeaders != null && result.Item1.AVLHeaders.Count() > 0)
                        foreach (var AH in result.Item1.AVLHeaders)
                        {
                            if (isSuccess == false) break;

                            if (AH.AVLs != null && AH.AVLs.Count() > 0)
                            {
                                DateTime date = AH.DATE;
                                foreach (var AVL in AH.AVLs)
                                {
                                    // We've got new AVL :)
                                    DateTime avlDate = new DateTime(date.Year, date.Month, date.Day, AVL.Time[0], AVL.Time[1], AVL.Time[2]);
                                    if (isSuccess) isSuccess = BusManagment.AVL.JAVLTransactions.AddAVL(AH, AVL, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION, _DB);
                                    if (isSuccess == false)
                                    {
                                        ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save AVL:" +
                                            AVL.transactionid.ToString() + " " +
                                            AH.busSerial.ToString() + " " +
                                            AH.DATE.ToString()));
                                        //break;
                                    }
                                }
                            }
                        }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return;
            }
            finally
            {
                _DB.Dispose();
            }


        }


        public void CheckMySQLDataAVL()
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                // AVL Info
                mysqlDB.setQuery("SELECT * FROM avlinfo_bin ORDER BY `ReciveDate` DESC LIMIT 0 , 20");
                DataTable dt = mysqlDB.Query_DataTable();
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        //db.beginTransaction("avl");
                        Tuple<JTransactionHeader, byte[]> result = Process(row["data"] as byte[]);
                        bool isSuccess = true;
                        Int64 recordNumber = Convert.ToInt64(row["recordNumber"]);
                        if (result.Item1.ErrorNum == 0)
                            if (result.Item1.AVLHeaders != null && result.Item1.AVLHeaders.Count() > 0)
                                foreach (var AH in result.Item1.AVLHeaders)
                                {
                                    if (isSuccess == false) break;

                                    if (AH.AVLs != null && AH.AVLs.Count() > 0)
                                    {
                                        DateTime date = AH.DATE;
                                        foreach (var AVL in AH.AVLs)
                                        {
                                            // We've got new AVL :)
                                            DateTime avlDate = new DateTime(date.Year, date.Month, date.Day, AVL.Time[0], AVL.Time[1], AVL.Time[2]);
                                            if (isSuccess) isSuccess = BusManagment.AVL.JAVLTransactions.AddAVL(AH, AVL, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION, db);
                                            if (isSuccess == false)
                                            {
                                                ClassLibrary.JSystem.Except.AddException(new Exception("Can Not Save AVL:" +
                                                    AVL.transactionid.ToString() + " " +
                                                    AH.busSerial.ToString() + " " +
                                                    AH.DATE.ToString()));
                                                //break;
                                            }
                                        }
                                    }
                                }
                        if (isSuccess)
                        {
                            if (Transaction.JDeviceDB.MoveAVLRecord(row, result.Item1.Error, result.Item1.ErrorNum) == true)
                            {
                                db.Commit();
                                //Transaction.JDeviceDB.SendToOldDatabase(result.Item2);
                            }
                            //else
                            //db.Rollback("avl");
                        }
                        //else
                        //db.Rollback("avl");
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);
                        //db.Rollback("avl");
                    }
                    finally
                    {
                        //if (db.Transaction != null) db.Rollback("avl");
                        //db.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                mysqlDB.Dispose();
                db.Dispose();
            }
        }




        //public void CheckData2()
        //{
        //    ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
        //    try
        //    {
        //        // Card Info
        //        mysqlDB.setQuery("Select * from cardinfo_bin_log");
        //        DataTable dt = mysqlDB.Query_DataTable();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
        //            try
        //            {
        //                //db.beginTransaction("card");
        //                Tuple<JTransactionHeader, byte[]> result = Process(row["data"] as byte[]);
        //                bool isSuccess = true;
        //                Int64 recordNumber = Convert.ToInt64(row["recordNumber"]);
        //                if (result.Item1.ErrorNum == 0)
        //                    if (result.Item1.TicketHeaders != null && result.Item1.TicketHeaders.Count() > 0)
        //                        foreach (var TH in result.Item1.TicketHeaders)
        //                        {
        //                            if (isSuccess == false) break;

        //                            if (TH.Tickets != null && TH.Tickets.Count() > 0)
        //                            {
        //                                DateTime date = TH.DATE;
        //                                foreach (var Ticket in TH.Tickets)
        //                                {
        //                                    // We've got new Ticket ;)
        //                                    DateTime ticketDate = new DateTime(date.Year, date.Month, date.Day, Ticket.Time[0], Ticket.Time[1], Ticket.Time[2]);

        //                                    if (isSuccess) isSuccess = Transaction.JTicketTransactions.AddTicketTransaction2(TH, Ticket, recordNumber, result.Item1.IMEI, result.Item1.busSerial, result.Item1.VERSION, db);
        //                                    if (isSuccess == false) break;
        //                                }
        //                            }
        //                        }
        //                //if (isSuccess)
        //                //{
        //                //    if (Transaction.JDeviceDB.MoveTicketRecord(row, result.Item1.Error, result.Item1.ErrorNum) == true)
        //                //    {
        //                //        db.Commit();
        //                //        Transaction.JDeviceDB.SendToOldDatabase(result.Item2);
        //                //    }
        //                //    else
        //                //        db.Rollback("card");

        //                // Insert to Old Database
        //                //}
        //                //else
        //                //    db.Rollback("card");
        //            }
        //            finally
        //            {
        //                db.Dispose();
        //            }

        //        }
        //    }
        //    catch { }
        //    finally
        //    {
        //        mysqlDB.Dispose();
        //    }
        //}

        public static DateTime ConvertBytesToDateTime(byte[] data)
        {
            try
            {
                byte[] bYear = new byte[1];
                Buffer.BlockCopy(data, 0, bYear, 0, 1);
                int year = bYear.Select(m => Convert.ToInt32(m)).First() + 2000;

                byte[] bMonth = new byte[1];
                Buffer.BlockCopy(data, 1, bMonth, 0, 1);
                int month = bMonth.Select(m => Convert.ToInt32(m)).First();

                byte[] bDay = new byte[1];
                Buffer.BlockCopy(data, 2, bDay, 0, 1);
                int day = bDay.Select(m => Convert.ToInt32(m)).First();

                return new DateTime(year, month, day);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static int[] ConvertBytesToTime(byte[] data)
        {
            try
            {
                byte[] bHour = new byte[1];
                Buffer.BlockCopy(data, 0, bHour, 0, 1);
                int hour = bHour.Select(m => Convert.ToInt32(m)).First();

                byte[] bMinute = new byte[1];
                Buffer.BlockCopy(data, 1, bMinute, 0, 1);
                int minute = bMinute.Select(m => Convert.ToInt32(m)).First();

                byte[] bSecond = new byte[1];
                Buffer.BlockCopy(data, 2, bSecond, 0, 1);
                int second = bSecond.Select(m => Convert.ToInt32(m)).First();

                return new int[] { hour, minute, second };
            }
            catch
            {
                return new int[] { 0, 0, 0 };
            }
        }

        /// <summary>
        /// NMEA Coordinate System To Decimal Coordinate System
        /// </summary>
        /// <param name="d">NMEA Lat/Long value in dd.mmss Format (Example: 36.2533 (Result: 36 + 25.33/60))</param>
        /// <returns>Decimal Lat/Long value in double format.</returns>
        public static double ConvertNMEAToDecimal(double d)
        {
            double o = 0;
            string[] str = d.ToString("00.0000").Split(new char[] { '.', '/' });
            try
            {
                o = Convert.ToDouble(str[1].Substring(0, 2) + "." + str[1].Substring(2, 2));
            }
            catch
            {
                o = Convert.ToDouble(str[1].Substring(0, 2) + "/" + str[1].Substring(2, 2));
            }
            return Convert.ToDouble(str[0]) + (o / 60);
        }

        public static DateTime ConvertUintToDateTime(UInt64 pDateTime)
        {
            UInt64 temp = 0;

            temp = (pDateTime & 63);//second:6
            UInt64 sec = temp;
            temp = (pDateTime & 4032);//minute:6
            UInt64 minute = (temp >> 6);
            temp = (pDateTime & 126976);//hour:5
            UInt64 hour = (temp >> 12);
            temp = (pDateTime & 4063232);//day:5
            UInt64 day = (temp >> 17);
            temp = (pDateTime & 62914560);//month:4
            UInt64 month = (temp >> 22);
            temp = (pDateTime & 4227858432);//year:6
            UInt64 year = (temp >> 26);

            return DateTime.Parse((year + 2000) + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + sec);

        }
    }

    /// <summary>
    /// Send Transaction to Archice Document for Accounting
    /// </summary>
    //public class JCloseTransaction
    //{
    //    public int Code { get; set; }
    //    public string Name { get; set; }
    //    public DateTime CloseDate { get; set; }
    //    public int Closer { get; set; }
    //}
    public class TransactionClass
    {
        //public static int GetHeaderCode(Int64 hIMEI, UInt32 hBusSerial, byte[] hVersion)
        //{
        //    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
        //    try
        //    {
        //        db.setQuery("Select Code From AUTHeaderTransaction where BusSerial=@BusSerial and IMEI=@IMEI and Version=@Version");
        //        db.AddParams("BusSerial", hBusSerial);
        //        db.AddParams("IMEI", hIMEI);
        //        db.AddParams("Version", hVersion);
        //        DataTable dt = db.Query_DataTable();
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            return Convert.ToInt32(dt.Rows[0]["Code"]);
        //        }
        //        db.setQuery("INSERT INTO AUTHeaderTransaction (BusSerial, IMEI, Version) VALUES(@BusSerial, @IMEI, @Version);" +
        //                    " Select @@IDENTITY");
        //        return db.Query_Execute();
        //    }
        //    finally
        //    {
        //        db.Dispose();
        //    }
        //}
    }
}
