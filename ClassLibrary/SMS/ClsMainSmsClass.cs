using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.ServiceModel;

namespace ClassLibrary.SMS
{
    public class ClsMainSmsClass
    {
        public static bool SendSms(JDataBase Db, string MessageStr, string Reciver, string ClassName, int ObjectCode = 0)
        {
            if (MessageStr == null | MessageStr == "" | MessageStr.Length == 0)
                return false;
            if (Reciver == null | Reciver == "" | Reciver.Length == 0)
                return false;
            if (ClassName == null | ClassName == "" | ClassName.Length == 0)
                return false;
            Db.setQuery(@"SELECT  [Code]
                                 ,[UrlFromat]
                                 ,[UserName]
                                 ,[PassWord]
                                 ,[Number]
                                 ,[ClassName]
                                 ,[ObjectCode]
                              FROM " + JMainFrame.Server01 + @"erp_tabrizbus.dbo.[SMSPanelSetting]
                              where [ClassName] = N'" + ClassName + @"'
                              and [ObjectCode] = " + ObjectCode);
            System.Data.DataTable Dt = Db.Query_DataTable();

            StringBuilder _StringBuilder = new StringBuilder();
            string[] ReciverMessage = Reciver.Split(',');
            if (Dt != null & Dt.Rows.Count > 0)
            {
                for (int i = 0; i < ReciverMessage.Length; i++)
                {

                    string url = Dt.Rows[0]["UrlFromat"].ToString().Replace("@UserName", Dt.Rows[0]["UserName"].ToString()).Replace("@Password", Dt.Rows[0]["PassWord"].ToString())
                    .Replace("@Message", MessageStr).Replace("@Reciver", ReciverMessage[i].ToString()).Replace("@Number", Dt.Rows[0]["Number"].ToString());

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string StatusReponse = response.StatusCode.ToString();

                }
            }

            return true;
        }


        public static bool SendSmsWebService(JDataBase Db, string MessageStr, string Reciver, string ClassName, int ObjectCode, string PServer)
        {
            if (MessageStr == null | MessageStr == "" | MessageStr.Length == 0)
                return false;
            if (Reciver == null | Reciver == "" | Reciver.Length == 0)
                return false;
            if (ClassName == null | ClassName == "" | ClassName.Length == 0)
                return false;
            Db.setQuery(@"SELECT top 1 [Code]
                                 ,[UrlFromat]
                                 ,[UserName]
                                 ,[PassWord]
                                 ,[Number]
                                 ,[ClassName]
                                 ,[ObjectCode]
                              FROM " + PServer + @"erp_tabrizbus.dbo.[SMSPanelSetting]
                              where [ClassName] = N'" + ClassName + @"'
                              and [ObjectCode] = " + ObjectCode);
            System.Data.DataTable Dt = Db.Query_DataTable();
            //zzz
            if (Dt != null & Dt.Rows.Count > 0)
            {

                string[] ReciverMessage = Reciver.Split(',');
                for (int i = 0; i < ReciverMessage.Length; i++)
                {
                    try
                    {

                        string url = Dt.Rows[0]["UrlFromat"].ToString().Replace("@UserName", Dt.Rows[0]["UserName"].ToString()).Replace("@Password", Dt.Rows[0]["PassWord"].ToString())
                        .Replace("@Message", MessageStr).Replace("@Reciver", ReciverMessage[i].ToString()).Replace("@Number", Dt.Rows[0]["Number"].ToString());

                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                        string StatusReponse = response.StatusCode.ToString();

                        response.Close();

                        System.Threading.Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {

                    }

                }
                return true;
            }

            return false;
        }

        public void SendSMSService(ClassLibrary.JDataBase DB)
        {
            bool res;
            ClassLibrary.JConnection C = new JConnection();
            ClassLibrary.JDataBase SendSMSDB = new JDataBase(C.GetConnection("Server01", 0));
            SendSMSDB.setQuery(@"select SMSSend.Code,Mobile,Text,SMSPanelSetting.ClassName,SMSPanelSetting.ObjectCode from SMSSend left join erp_tabrizbus.dbo.SMSPanelSetting SMSPanelSetting on isnull(SendDevice,1) = SMSPanelSetting.Code where SMSSend.Send = 0");
            System.Data.DataTable Dt = SendSMSDB.Query_DataTable();

            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        try
                        {
                            res = SendSmsWebService(SendSMSDB, Dt.Rows[i]["Text"].ToString(), Dt.Rows[i]["Mobile"].ToString(), Dt.Rows[i]["ClassName"].ToString(), int.Parse(Dt.Rows[i]["ObjectCode"].ToString()), "");
                            SendSMSDB.setQuery(@"update SMSSend set Send = '1',SendDate=getdate(),DeliveryDate=getdate() where Code = " + Dt.Rows[i]["Code"].ToString());
                            SendSMSDB.Query_Execute();
                        }
                        catch
                        {
                            SendSMSDB.setQuery(@"update SMSSend set Send = '2',SendDate=getdate(),DeliveryDate=getdate() where Code = " + Dt.Rows[i]["Code"].ToString());
                            SendSMSDB.Query_Execute();
                        }
                    }
                }
            }
            SendSMSDB.Dispose();
            SendSMSService_Remote(DB);
        }

        public void SendSMSService_Remote(ClassLibrary.JDataBase DB)
        {
            bool res;
            ClassLibrary.JDataBase SendSMSDB = new JDataBase();
            DB.setQuery(@"select SMSSend.Code,Mobile,Text,SMSPanelSetting.ClassName,SMSPanelSetting.ObjectCode from SMSSend left join " + JMainFrame.Server01 + @"erp_tabrizbus.dbo.SMSPanelSetting SMSPanelSetting on isnull(SendDevice,1) = SMSPanelSetting.Code where SMSSend.Send = 0");
            System.Data.DataTable Dt = DB.Query_DataTable();

            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        try
                        {
                            res = SendSmsWebService(SendSMSDB, Dt.Rows[i]["Text"].ToString(), Dt.Rows[i]["Mobile"].ToString(), Dt.Rows[i]["ClassName"].ToString(), int.Parse(Dt.Rows[i]["ObjectCode"].ToString()), JMainFrame.Server01);
                            DB.setQuery(@"update SMSSend set Send = '1',SendDate=getdate(),DeliveryDate=getdate() where Code = " + Dt.Rows[i]["Code"].ToString());
                            DB.Query_Execute();
                        }
                        catch
                        {
                            DB.setQuery(@"update SMSSend set Send = '2',SendDate=getdate(),DeliveryDate=getdate() where Code = " + Dt.Rows[i]["Code"].ToString());
                            DB.Query_Execute();
                        }
                    }
                }
            }
            SendSMSDB.Dispose();
        }

    }
}
