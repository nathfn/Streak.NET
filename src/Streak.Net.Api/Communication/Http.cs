using System;
using System.IO;
using System.Net;
using System.Text;
using Streak.Net.Api.Exceptions;
using Streak.Net.Api.Extensions;

namespace Streak.Net.Api.Communication
{
    public class Http
    {
        private readonly string _apiKey;
        private readonly string _apiBaseUrl;

        public Http(string apiKey, string apiBaseUrl)
        {
            _apiKey = apiKey;
            _apiBaseUrl = apiBaseUrl;
        }

        public string Delete(string apiHandle, out int httpStatusCode)
        {
            return CallStreak(apiHandle, "DELETE", out httpStatusCode);
        }

        public string Post(string apiHandle, string requestPayload, out int httpStatusCode)
        {
            return CallStreak(apiHandle, "POST", out httpStatusCode, requestPayload, "application/json");
        }

        public string Get(string apiHandle, out int httpStatusCode)
        {
            return CallStreak(apiHandle, "GET", out httpStatusCode);
        }

        public string Put(string apiHandle, string requestPayload, out int httpStatusCode)
        {
            return CallStreak(apiHandle, "PUT", out httpStatusCode, requestPayload);
        }

        private string CallStreak(string apiHandle, string method, out int httpStatusCode, string requestPayload = null, string requestContentType = "application/x-www-form-urlencoded")
        {
            try
            {
                var request =
                    WebRequest.Create(_apiBaseUrl + apiHandle) as
                        HttpWebRequest;
                request.Method = method;
                request.ContentType = requestContentType;
                var authInfo = _apiKey + ":" + _apiKey;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                request.Headers["Authorization"] = "Basic " + authInfo;
                request.Credentials = new NetworkCredential(_apiKey, _apiKey);
                request.Expect = "application/json";

                // Optional payload
                if (!string.IsNullOrEmpty(requestPayload))
                {
                    var encoder = new UTF8Encoding();
                    var data = encoder.GetBytes(requestPayload);
                    request.ContentLength = data.Length;
                    request.GetRequestStream().Write(data, 0, data.Length);
                }

                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var responseData = reader.ReadToEnd();
                httpStatusCode = response.GetHttpStatusCode();
                return responseData;
            }
            catch (WebException e)
            {
                using (var response = e.Response)
                {
                    using (var data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        throw new StreakApiException("Error in communication with Streak API", e, reader.ReadToEnd(), response.GetHttpStatusCode());
                    }
                }
            }
        }
    }
}
