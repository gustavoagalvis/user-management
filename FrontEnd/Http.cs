using System;
using System.IO;
using System.Net;
using System.Text;

namespace FrontEnd
{
    public static class Http
    {

        public static dynamic PostCall(string urlToRequest, string parameters, string method)
        {
            if (String.IsNullOrEmpty(urlToRequest) == false)
            {
                var http = (HttpWebRequest)WebRequest.Create(new Uri(urlToRequest));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = method;
                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(parameters);

                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
                var response = http.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                string contentRead = sr.ReadToEnd();
                return contentRead;
            }
            return null;
        }

        internal static string PostCall(object serviceUrl, string parsedContent, string v)
        {
            throw new NotImplementedException();
        }

        public static dynamic GetCall(string urlToRequest, string method)
        {
            if (String.IsNullOrEmpty(urlToRequest) == false)
            {
                var request = (HttpWebRequest)WebRequest.Create(urlToRequest);
                request.Method = method;
                var response = (HttpWebResponse)request.GetResponse();
                string responseString;
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }
                return responseString;
            }
            return null;
        }

    }
}
