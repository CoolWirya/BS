using System;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using MonoCP.Telegram.Types;

namespace TccoTabrizBus
{
   public class NetManager2
    {
        private const string _baseURL = "https://api.telegram.org/bot";
        //private static readonly HttpClient client = new HttpClient();
        private string _token="";
        public NetManager2(string token)
        {
            _token = token;

        }
        public async Task<ResultUpdate> GetUpdate(long offset)
        {            
            ResultUpdate ru=null;
            try
            {
                using (WebResponse webResponse = await WebResponse(_baseURL + _token + "/getUpdates?offset=" + offset,null))
                {
                    ru = Deserializer<ResultUpdate>(webResponse.GetResponseStream());
                }
            }
            catch (Exception er)
            {
            }
            return ru;
        }

        public  void SendMessage(string chatId, string text)
        {
            SendMessage(chatId, text, null);
        }
        public async void SendMessage(string chatId, string text, ReplyKeyboardMarkup keyboard)
        {
            SendMessage m = new SendMessage();
            m.chat_id = chatId;
            m.text = text;
            if (keyboard != null) m.reply_markup = keyboard;
            string json = Serialize<SendMessage>(m);
            
            try
            {
                using (WebResponse webResponse = await WebResponse(_baseURL + _token + "/sendMessage", new System.Text.UTF8Encoding().GetBytes(json)))
                {
                }
            }
            catch (Exception er)
            {
            }
        }

        private async Task<WebResponse> WebResponse(string url,byte[] dataToSend)
        { 
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";

            if (dataToSend != null)
            {
                webRequest.ContentLength = dataToSend.Length;
                using (System.IO.Stream rs = webRequest.GetRequestStream())
                {
                    rs.Write(dataToSend, 0, dataToSend.Length);
                }
            }
            return await webRequest.GetResponseAsync();
        }

        public T Deserializer<T>(System.IO.Stream stream)
        {
            if (stream == null)
                throw new NullReferenceException("Stream can not be null.");
            System.Collections.Generic.List<byte> b = new System.Collections.Generic.List<byte>();
            int temp = -1;
            while ((temp = stream.ReadByte()) != -1)
            {
                b.Add((byte)temp);
            }
            T t = default(T);
            using (System.IO.MemoryStream stream1 = new System.IO.MemoryStream(b.ToArray()))
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
                stream1.Position = 0;
                t = (T)ser.ReadObject(stream1);
            }
            stream.Close();
            return t;
        }

        public string Serialize<T>(T t)
        {
            string data = "";
            using (System.IO.MemoryStream stream1 = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializerSettings dcjss = new System.Runtime.Serialization.Json.DataContractJsonSerializerSettings();
                dcjss.EmitTypeInformation = System.Runtime.Serialization.EmitTypeInformation.Always;
                System.Runtime.Serialization.Json.DataContractJsonSerializer ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T), dcjss);
                ser.WriteObject(stream1, t);
                stream1.Position = 0;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(stream1))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;
        }
    }
}
