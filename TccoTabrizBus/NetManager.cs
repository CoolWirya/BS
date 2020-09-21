using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml;

namespace TccoTabrizBus
{
    public class NetManager
    {
        private static readonly HttpClient client = new HttpClient();
        private const string WEBSERVICES_ADDRESS = "http://128.140.29.12/services/WebBaseDefineService.asmx",// "http://127.0.0.1/services/WebBaseDefineService.asmx",
            PARAMETER="<{0}>{1}</{0}>";

        //public async Task<string> Request(Dictionary<string, string> values)
        //{
        //    FormUrlEncodedContent content = new FormUrlEncodedContent(values);
        //    //StringContent ss = new StringContent("UserName=&Password=12345");
        //    //StringContent content = new StringContent("");

        //    HttpResponseMessage response = await client.PostAsync(WEBSERVICES_ADDRESS + "/Login", content);
          
        //    string result = await response.Content.ReadAsStringAsync();
        //    return result;
        //}

        public static async Task<string> CallWebService(string webMethod, Dictionary<string, string> values)
        {
            var _url = WEBSERVICES_ADDRESS;
            var _action = "http://tempuri.org/"+webMethod;

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(webMethod,CreateParameters(values));
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            //// begin async call to web request.
            //IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            //// suspend this thread until call is complete. You might want to
            //// do something usefull here like update your UI.
            //asyncResult.AsyncWaitHandle.WaitOne();

            ;

            // get the response from the completed web request.
            string soapResult="";
            try
            {
                using (WebResponse webResponse = await webRequest.GetResponseAsync())
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }
                    //Console.Write(soapResult);
                }
                return ExtractResult(webMethod, soapResult);
            }
            catch (Exception er)
            {
                return er.Message;
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static string CreateParameters(Dictionary<string, string> values)
        {
            string res = "";
            foreach (KeyValuePair<string, string> val in values)
                res += string.Format(PARAMETER,val.Key,val.Value);
            return res;
        }

        private static XmlDocument CreateSoapEnvelope(string webMethod, string parameters)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(
          string.Format(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
<soap:Body>
<{0} xmlns=""http://tempuri.org/"">
{1}
</{0}>
</soap:Body>
</soap:Envelope>",webMethod,parameters));
            return soapEnvelop;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        private static string ExtractResult(string webMethod,string xmlString)
        {
            System.Xml.Linq.XElement str =System.Xml.Linq.XElement.Parse(xmlString);
           return str.Elements().ElementAt(0).//System.Xml.Linq.XName.Get("soap:Body")).ElementAt(0).
                Elements().ElementAt(0).
                Elements().ElementAt(0).Value;
        }
    }
}

