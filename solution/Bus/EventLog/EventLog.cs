using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace BusManagment.EventLog
{

    public class JEventLog
    {

        public enum EventLogType
        {
            ShutDown_EventType = 1,
            DriverLogin_EventType = 2,
            DriverLogout_EventType = 3,
            SosLogin_EventType = 4,
            SosLogout_EventType = 5,
            MaintenanceLogin_EventType = 6,
            MaintenanceLogout_EventType = 7,
            SHOOTINGGALLERYLogin_EventType = 8,
            SHOOTINGGALLERYLogout_EventType = 9,
            CarWashLogin_EventType = 10,
            CarWashLogout_EventType = 11,
            PassengerControllerLogin_EventType = 12,
            PassengerControllerLogout_EventType = 13,
            DriverCintrollerLogin_EventType = 14,
            DriverCintrollerLogout_EventType = 15,
            DriverManagerLogin_EventType = 16,
            DriverManagerLogout_EventType = 17,
            LineChangerLogin_EventType = 18,
            LineChangerLogout_EventType = 19,
            CardChargerLogin_EventType = 20,
            CardChargerLogout_EventType = 21,
            Bus_OwnerLogin_EventType = 22,
            Bus_OwnerLogout_EventType = 23,
            CardDistrobuterLogin_EventType = 24,
            CardDistrobuterLogout_EventType = 25,
            PassingStation_EventType = 26,
            PassingStationTicket_EventType = 27
        }

        public void EventLogProcess(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            try
            {
                DriversLoginLogoutProcess(Db, MySqlDb);
            }
            catch (Exception e) { ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString())); }

            try
            {
                BusPassingStationProcess(Db, MySqlDb);
            }
            catch (Exception e) { ClassLibrary.JSystem.Except.AddException(new Exception(e.Message.ToString() + DateTime.Now.ToLongTimeString())); }
        }
        public void BusPassingStationProcess(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase MySqlDb)
        {

            MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
            where `EventType` in (" + EventLogType.PassingStation_EventType.GetHashCode() + "," + EventLogType.PassingStationTicket_EventType.GetHashCode() + ") and `IsProcessed` Is NULL Order by `Code` desc");
            DataTable Dt = MySqlDb.Query_DataTable();
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        byte[] pData = (byte[])Dt.Rows[i]["data"];

                        UInt32 BusNumber = 0;
                        byte[] bBusNumber = new byte[4];
                        Buffer.BlockCopy(pData, 0, bBusNumber, 0, 4);
                        BusNumber = BitConverter.ToUInt32(bBusNumber, 0);

                        UInt32 DriverSerialCard = 0;
                        byte[] bDriverSerialCard = new byte[4];
                        Buffer.BlockCopy(pData, 4, bDriverSerialCard, 0, 4);
                        DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0);

                        UInt32 StationCode = 0;
                        byte[] bStationCode = new byte[4];
                        Buffer.BlockCopy(pData, 8, bStationCode, 0, 4);
                        StationCode = BitConverter.ToUInt32(bStationCode, 0);

                        if (Dt.Rows[i]["EventType"].ToString() == EventLogType.PassingStation_EventType.GetHashCode().ToString())
                        {
                            Db.setQuery(@"INSERT INTO [dbo].[AutBusPassingStations]
                                               ([EventDate]
                                               ,[BusNumber]
                                               ,[StationCode]
                                               ,[DriverCardSerial]
                                               ,[DriverPersonCode]
                                               ,[FirstStation]
                                               ,[LastStation]
                                               ,[InsertDate])
                                         VALUES
                                               ('" + Dt.Rows[i]["EventDateTime"].ToString() + @"'
                                               ," + Dt.Rows[i]["BusNumber"].ToString() + @"
                                               ," + StationCode + @"
                                               ," + DriverSerialCard + @"
                                               ,ISNULL((select PCode from Cards where RfidNumber = " + DriverSerialCard + @"),0)
                                               ,(select case 
                                                (select Priority from AUTLineStation where StationCode = " + StationCode + @" and LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from AUTBus where BUSNumber = " + Dt.Rows[i]["BusNumber"].ToString() + @")))
                                                when 1 then 1 else 0 end as FirstStation)
                                               ,(select case when 
                                                (select Priority from AUTLineStation where StationCode = " + StationCode + @" and LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from AUTBus where BUSNumber =  " + Dt.Rows[i]["BusNumber"].ToString() + @")))
                                                =
                                                (select max(Priority) from AUTLineStation where LineCode = 
                                                (select Code from AUTLine where LineNumber = (select LastLineNumber from AUTBus where BUSNumber =  " + Dt.Rows[i]["BusNumber"].ToString() + @")))
                                                then 1 else 0 end as LastStation)
                                               ,getdate())");
                        }
                        else if (Dt.Rows[i]["EventType"].ToString() == EventLogType.PassingStationTicket_EventType.GetHashCode().ToString())
                        {

                            UInt32 TicketCount = 0;
                            byte[] bTicketCount = new byte[4];
                            Buffer.BlockCopy(pData, 12, bTicketCount, 0, 4);
                            TicketCount = BitConverter.ToUInt32(bTicketCount, 0);

                            Db.setQuery(@"INSERT INTO [dbo].[AutBusPassingStationTicket]
                                               ([EventDate]
                                               ,[BusNumber]
                                               ,[StationCode]
                                               ,[DriverCardSerial]
                                               ,[DriverPersonCode]
                                               ,[TicketCount]
                                               ,[InsertDate])
                                         VALUES
                                               ('" + Dt.Rows[i]["EventDateTime"].ToString() + @"'
                                               ," + Dt.Rows[i]["BusNumber"].ToString() + @"
                                               ," + StationCode + @"
                                               ," + DriverSerialCard + @"
                                               ,ISNULL((select PCode from Cards where RfidNumber = " + DriverSerialCard + @"),0)
                                               ," + TicketCount + @"
                                               ,getdate())");

                        }
                        if (Db.Query_Execute() > 0)
                        {
                            MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1 WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                            MySqlDb.Query_Execute();
                        }
                    }
                }
            }

        }

        public void DriversLoginLogoutProcess(ClassLibrary.JDataBase Db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            MySqlDb.setQuery(@"SELECT `Code`,`EventType`,`EventDateTime`,`data`,`BusNumber`,`IsProcessed` FROM `eventlog` 
            where `EventType` in (" + EventLogType.DriverLogin_EventType.GetHashCode() + "," + EventLogType.DriverLogout_EventType.GetHashCode() + ") and `IsProcessed` Is NULL Order by `Code` desc");
            DataTable Dt = MySqlDb.Query_DataTable();
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (Dt.Rows[i]["EventType"].ToString() == EventLogType.DriverLogin_EventType.GetHashCode().ToString())
                        {
                            //byte[] pData = GetBytes(Dt.Rows[i]["data"].ToString());
                            byte[] pData = (byte[])Dt.Rows[i]["data"];

                            UInt32 BusNumber = 0;
                            byte[] bBusNumber = new byte[4];
                            Buffer.BlockCopy(pData, 0, bBusNumber, 0, 4);
                            BusNumber = BitConverter.ToUInt32(bBusNumber, 0);

                            UInt32 DriverSerialCard = 0;
                            byte[] bDriverSerialCard = new byte[4];
                            Buffer.BlockCopy(pData, 4, bDriverSerialCard, 0, 4);
                            DriverSerialCard = BitConverter.ToUInt32(bDriverSerialCard, 0);

                            Db.setQuery(@"INSERT INTO [dbo].[AUTDriversLoginLogout]
                                           ([Date]
                                           ,[BusNumber]
                                           ,[DriverCardSerial]
                                           ,[DriverPersonCode]
                                           ,[LoginTime]
                                           ,[LogoutTime]
                                           ,[InsertDate])
                                     VALUES
                                           (cast ('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as date)
                                           ," + Dt.Rows[i]["BusNumber"].ToString() + @"
                                           ," + DriverSerialCard + @"
                                           ,ISNULL((select PCode from Cards where RfidNumber = " + DriverSerialCard + @"),0)
                                           ,cast ('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as time)
                                           ,NULL
                                           ,getdate())");
                        }
                        else if (Dt.Rows[i]["EventType"].ToString() == EventLogType.DriverLogout_EventType.GetHashCode().ToString())
                        {
                            Db.setQuery(@"UPDATE [dbo].[AUTDriversLoginLogout] Set [LogoutTime] = cast ('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as time)
                                          where BusNumber = " + Dt.Rows[i]["BusNumber"].ToString() + @" and Date = cast ('" + Dt.Rows[i]["EventDateTime"].ToString() + @"' as date)");
                        }
                        if (Db.Query_Execute() > 0)
                        {
                            MySqlDb.setQuery(@"UPDATE `eventlog` SET `IsProcessed`=1 WHERE `Code` = " + Dt.Rows[i]["Code"].ToString());
                            MySqlDb.Query_Execute();
                        }
                    }
                }
            }
        }

    }
}
