using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TestSmartcard
{
    class ws_login
    {
        public JObject Call_login(string user_name, string password , string device_id)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://test-vizitori.vizitoriii.ir/api/v1/nfc");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            //httpWebRequest.Headers.Add("Authorization", "Auth");
            JObject obj;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"operation\": \"login\",\"user_name\": \"" + user_name + "\",\"password\": \"" + password + "\",\"device_id\": \"" + device_id + "\",\"token\": \"o$53FsD&CFm^#S\"}";
                streamWriter.Write(json);
            }
            try
            {
                string result;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                obj = JObject.Parse(result);
                httpResponse.Close();
            }
            catch (WebException wex)
            {
                string result;
                using (var streamReader = new StreamReader(wex.Response.GetResponseStream()))
                {
                    result= streamReader.ReadToEnd();
                    //MessageBox.Show(result);
                }
                obj = JObject.Parse(result);
            }
            return obj;
        }
        public string hash_password(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);

            var hashedPassword = ASCIIEncoding.ASCII.GetString(data);
            return data.ToString();
        }

        public JObject Call_card(string card_id, string device_id, string token)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://test-vizitori.vizitoriii.ir/api/v1/nfc");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            //httpWebRequest.Headers.Add("Authorization", "Auth");
            JObject obj;
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"operation\": \"card\",\"card_id\": \"" + card_id + "\",\"device_id\": \"" + device_id + "\",\"token\": \"" + token + "\"}";
                streamWriter.Write(json);
            }
            try
            {
                string result;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                obj = JObject.Parse(result);
                httpResponse.Close();
            }
            catch (WebException wex)
            {
                string result;
                using (var streamReader = new StreamReader(wex.Response.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    //MessageBox.Show(result);
                }
                obj = JObject.Parse(result);
            }
            return obj;
        }
    }
}
