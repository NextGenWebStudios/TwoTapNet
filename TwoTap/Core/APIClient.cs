using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TwoTap.Core.Models;
using TwoTap.Core.Helpers;

namespace TwoTap.Core
{
    public abstract class APIClient
    {
        protected enum HttpMethod
        {
            GET,
            POST
        }

        protected abstract void AddDefaultParams(Dictionary<string, string> parms);
        protected abstract string GetApiUrl();

        protected void Request<T>(string url, HttpMethod httpMethod, Func<T, bool> callback)
        {
            Request<T>(url, httpMethod, null, callback);
        }

        protected void Request<T>(string url, HttpMethod httpMethod, string data, Func<T, bool> callback)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = httpMethod.ToString();
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.AllowReadStreamBuffering = false;

            if (data != null)
            {
                byte[] bytes = UTF8Encoding.UTF8.GetBytes(data.ToString());
                httpWebRequest.ContentLength = bytes.Length;
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

            // Get the web response
            string result = string.Empty;
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            // Convert result to object
            T singleObj = JsonConvert.DeserializeObject<T>(result);
            if (singleObj != null)
            {
                callback(singleObj);
            }
        }

        private T RequestSingle<T>(string url, HttpMethod httpMethod) where T : IResponseAbstract
        {
            return RequestSingle<T>(url, httpMethod, "");
        }

        private T RequestSingle<T>(string url, HttpMethod httpMethod, string data) where T : IResponseAbstract
        {
            string result = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = httpMethod.ToString();

            if (!string.IsNullOrEmpty(data))
            {
                byte[] bytes = UTF8Encoding.UTF8.GetBytes(data);
                httpWebRequest.ContentLength = bytes.Length;
                httpWebRequest.ContentType = "application/json";
                using (Stream stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                    stream.Close();
                }
            }

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            T response = Activator.CreateInstance<T>();
            response.HandleResult(result);

            return response;
        }

        protected void GetMultiple<T>(string endpoint, Func<T, bool> callback)
        {
            GetMultiple<T>(endpoint, null, false, callback);
        }

        protected void GetMultiple<T>(string endpoint, bool unauthenticated, Func<T, bool> callback)
        {
            GetMultiple<T>(endpoint, null, unauthenticated, callback);
        }

        protected void GetMultiple<T>(string endpoint, Dictionary<string, string> parameters, Func<T, bool> callback)
        {
            GetMultiple<T>(endpoint, parameters, false, callback);
        }

        protected void GetMultiple<T>(string endpoint, Dictionary<string, string> parameters, bool unauthenticated, Func<T, bool> callback)
        {
            string serializedParameters = GenerateParams(parameters);
            Request<T>(string.Format("{0}/{1}?{2}", GetApiUrl(), endpoint, serializedParameters), HttpMethod.GET, callback);
        }

        protected T GetSingle<T>(string endpoint) where T : IResponseAbstract
        {
            return GetSingle<T>(endpoint, null);
        }

        protected T GetSingle<T>(string endpoint, Dictionary<string, string> parameters) where T : IResponseAbstract
        {
            string serializedParameters = GenerateParams(parameters);
            return RequestSingle<T>(string.Format("{0}/{1}?{2}", GetApiUrl(), endpoint,  serializedParameters), HttpMethod.GET);
        }

        protected T PostSingle<T>(string endpoint, IRequestAbstract request) where T : IResponseAbstract
        {
            return PostSingle<T>(endpoint, request, null);
        }

        protected T PostSingle<T>(string endpoint, IRequestAbstract request, Dictionary<string, string> parameters) where T : IResponseAbstract
        {
            string serializedParameters = GenerateParams(parameters);
            var data = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { Formatting = Formatting.None, ContractResolver = new JsonLowerCaseUnderscoreContractResolver() });
            return RequestSingle<T>(string.Format("{0}/{1}?{2}", GetApiUrl(), endpoint, serializedParameters), HttpMethod.POST, data);
        }

        private string GenerateParams(Dictionary<string, string> parameters)
        {
            var allParameters = new Dictionary<string, string>();

            // Get default params
            AddDefaultParams(allParameters);

            // Add endpoint params
            if (parameters != null)
            {
                MergeDictionary(allParameters, parameters);
            }

            // Serialize params
            string serializedParameters = "";
            if (allParameters.Any())
            {
                serializedParameters = SerializeDictionary(allParameters);
            }
            return serializedParameters;
        }

        private void MergeDictionary(Dictionary<string, string> dest, Dictionary<string, string> src)
        {
            foreach (var key in src.Keys)
            {
                dest[key] = src[key];
            }
        }

        private string SerializeDictionary(Dictionary<string, string> dictionary)
        {
            StringBuilder parameters = new StringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in dictionary)
            {
                parameters.Append(keyValuePair.Key + "=" + keyValuePair.Value + "&");
            }
            return parameters.Remove(parameters.Length - 1, 1).ToString();
        }
    }
}
