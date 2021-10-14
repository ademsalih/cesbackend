using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace TelstarLogistics.Services
{
    public class ExternalSystemsService
    {
        public const string DATA = @"";
        public string getRoutes(string baseUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.ContentLength = Int64.MaxValue;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
                using (StreamReader responseReader = new StreamReader(webStream))
                {
                    string response = responseReader.ReadToEnd();
                    Console.Out.WriteLine(response);
                }

                return DATA;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}