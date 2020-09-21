using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Device
{
    public static class JDataExtractor
    {
        /// <summary>
        /// FM1100, FM2100, FM2200, FM4100 , FM4200
        /// </summary>
        /// <returns></returns>
        public static AVL.Coordinate.JCoordinate TeltonikaFMv1(byte[] Data)
        {
            DataProtocol.JTeltonikaProtocolV1 protocol = new DataProtocol.JTeltonikaProtocolV1();
            byte pStart = 0;
            byte ByteLength = 0;
            byte[] tempData;
            //IMEI -15
            ByteLength = 15;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.IMEI = System.Text.Encoding.ASCII.GetString(tempData); //GetDecimal(tempData).ToString();
            pStart += ByteLength;
            //Codec ID -1
            ByteLength = 1;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.CodecID = (int)GetDecimal(tempData);
            pStart += ByteLength;
            //Number Of Data -1
            ByteLength = 1;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.NumberOfData = (int)GetDecimal(tempData);
            pStart += ByteLength;
            //TimeStamp -8
            ByteLength =8 ;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.TimeStamp = GetDateTime(tempData, new DateTime(1970, 1, 1));
            pStart += ByteLength;
            //Priority Data -1
            ByteLength =1 ;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.Priority = (byte)GetDecimal(tempData);
            pStart += ByteLength;
            //Longitude -4
            ByteLength = 4;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.Longitude = GetDecimal(tempData);
            pStart += ByteLength;
            //Latitude -4
            ByteLength = 4;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.Latitude = GetDecimal(tempData);
            pStart += ByteLength;
            //Altitude -2
            ByteLength =2 ;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.Altitude = (float)GetDecimal(tempData);
            pStart += ByteLength;
            //Angle -2
            ByteLength =2 ;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.Angle = (int)GetDecimal(tempData);
            pStart += ByteLength;
            //Satellite -1
            ByteLength = 1;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.Satellite = (int)GetDecimal(tempData);
            pStart += ByteLength;
            //Speed -2
            ByteLength = 2;
            tempData = new byte[ByteLength];
            Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
            protocol.Speed = (float)GetDecimal(tempData);
            pStart += ByteLength;

            AVL.Coordinate.JCoordinate coordinate = new Coordinate.JCoordinate();
            coordinate.Altitude = protocol.Altitude;
            coordinate.Angle = protocol.Angle;
            coordinate.lat = (float)protocol.Latitude;
            coordinate.lng =(float) protocol.Longitude;
            coordinate.DeviceSendDateTime = protocol.TimeStamp;
            coordinate.RegisterDateTime = DateTime.Now;
            coordinate.Speed = protocol.Speed;
            coordinate.IMEI = protocol.IMEI;
            AVL.RegisterDevice.JRegisterDevice regdevice = new AVL.RegisterDevice.JRegisterDevice(protocol.IMEI);
            coordinate.DeviceCode = regdevice.Code;
            coordinate.ObjectCode = regdevice.ObjectCode;
            return coordinate;
        }

        //Tarahan Samane Android Aplication
        public static void TSIPAndroidApplication()
        {
            byte[] Data;
            int discarded;
            foreach (System.Data.DataRow dr in AVL.GPSData.TSIPAndroid.JTSIPAndroids.GetDataTable().Rows)
            {
                Data = AVL.Device.DataProtocol.HexEncoding.GetBytes(dr["Data"].ToString(), out discarded);
                DataProtocol.JTSIPAndroidProtocol protocol = new DataProtocol.JTSIPAndroidProtocol();
                byte pStart = 0;
                byte ByteLength = 0;
                byte[] tempData;
                //IMEI -8
                ByteLength = 8;
                tempData = new byte[ByteLength];
                Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
                protocol.IMEI = System.Text.Encoding.ASCII.GetString(tempData); //GetDecimal(tempData).ToString();
                pStart += ByteLength;
                //Longitude -8
                ByteLength = 8;
                tempData = new byte[ByteLength];
                Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
                protocol.Longitude = GetDecimal(tempData);
                pStart += ByteLength;
                //Latitude -8
                ByteLength = 8;
                tempData = new byte[ByteLength];
                Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
                protocol.Latitude = GetDecimal(tempData);
                pStart += ByteLength;
                //datetime -8
                ByteLength = 8;
                tempData = new byte[ByteLength];
                Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
                protocol.datetime = GetDateTime(tempData, new DateTime(1970, 1, 1));
                pStart += ByteLength;
                //Speed -1
                ByteLength = 1;
                tempData = new byte[ByteLength];
                Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
                protocol.Speed = (float)GetDecimal(tempData);
                pStart += ByteLength;
                //curse -1
                ByteLength = 1;
                tempData = new byte[ByteLength];
                Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
                protocol.curse = (int)GetDecimal(tempData);
                pStart += ByteLength;
                //Altitude -8
                ByteLength = 8;
                tempData = new byte[ByteLength];
                Buffer.BlockCopy(Data, pStart, tempData, 0, ByteLength);
                protocol.Altitude = (float)GetDecimal(tempData);
                pStart += ByteLength;

                AVL.Coordinate.JCoordinate coordinate = new Coordinate.JCoordinate();
                coordinate.Altitude = protocol.Altitude;
                coordinate.Angle = protocol.curse;
                coordinate.lat = (float)protocol.Latitude;
                coordinate.lng = (float)protocol.Longitude;
                coordinate.DeviceSendDateTime = protocol.datetime;
                coordinate.RegisterDateTime = DateTime.Now;
                coordinate.Speed = protocol.Speed;
                coordinate.IMEI = protocol.IMEI;
                AVL.RegisterDevice.JRegisterDevice regdevice = new AVL.RegisterDevice.JRegisterDevice(protocol.IMEI);
                coordinate.DeviceCode = regdevice.Code;
                coordinate.ObjectCode = regdevice.ObjectCode;
                coordinate.Insert();
                AVL.GPSData.TSIPAndroid.JTSIPAndroid t = new GPSData.TSIPAndroid.JTSIPAndroid();
                t.Proceced(int.Parse(dr["Code"].ToString()));
            }
        }
        public static DateTime GetDateTime(byte[] data, DateTime First)
        {
            long a = (long)GetDecimal(data);
            DateTime d = First.AddMilliseconds(a);
            return d;
        }
        public static long GetDecimal(byte[] data)
        {
            if (data.Length == 1)
                return (long)data[0];


            if (BitConverter.IsLittleEndian)
                Array.Reverse(data); //need the bytes in the reverse order
            long value = 0;
            if (data.Length == 4)
                value = BitConverter.ToInt32(data, 0);
            else if (data.Length == 2)
            {
                for (int i = 0; i < data.Length; i++)
                    value += (int)(data[i] * Math.Pow(16d, (double)i));
            }
            else
                value = BitConverter.ToInt64(data, 0);

            return value;
        }
    }
}
