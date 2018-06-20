using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HTTPCommLib
{
    [Serializable]
    public class RequestMessage
    {
        public DateTime TimeStamp { get; set; }
        public HttpStatusCode State { get; set; }
        public int CommandID { get; set; }
        public List<object> CommandParams { get; set; }
        public string CallerName { get; set; }
        public int Vesion { get { return 1; }}
    }

    public static class HTTPHelper
    {
        public const string APPLICATION_JSON = "application/json";
        public const string TEXT_HTML = "text/html";

        public static HttpResponseMessage GetHttpResponseMessage()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent("", Encoding.UTF8, TEXT_HTML),
                StatusCode = System.Net.HttpStatusCode.OK
            };

            return httpResponseMessage;
        }

        public static HttpResponseMessage GetHttpResponseMessage(string _sText)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(_sText, Encoding.UTF8, TEXT_HTML),
                StatusCode = System.Net.HttpStatusCode.OK
            };

            return httpResponseMessage;
        }

        public static HttpResponseMessage GetHttpErrorMessage(string _sText, string _sID)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(string.Format("Error: \"{0}\", ID: {1}", _sText, _sID), Encoding.UTF8, TEXT_HTML),
                StatusCode = HttpStatusCode.InternalServerError
            };

            return httpResponseMessage;
        }

        public static object GetObjectFromJsonString(string _sO)
        {
            return JsonConvert.DeserializeObject(_sO, typeof(RequestMessage));
        }

        public static byte[] ConvertBytesFromObject(object _o)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_o, Formatting.None));

            return dataBytes;
        }

        public static HttpContent GetJsonStringAsHttpContentFromObject(object _o)
        {
            return new StringContent(JsonConvert.SerializeObject(_o, Formatting.None)
                                           , Encoding.UTF8, APPLICATION_JSON);
        }

        public static HttpResponseMessage GetHttpResponseMessage(object _o)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(_o, Formatting.None)
                                           , Encoding.UTF8, APPLICATION_JSON),
                StatusCode = HttpStatusCode.OK
            };

            return httpResponseMessage;
        }

        public static void SetHttpResponseMessage(HttpResponseMessage _httpResponseMessage, object _o)
        {
            SetJsonHttpResponseMessage(_httpResponseMessage, JsonConvert.SerializeObject(_o, Formatting.None));
        }

        public static void SetJsonHttpResponseMessage(HttpResponseMessage _httpResponseMessage, string _json)
        {
           _httpResponseMessage.Content = new StringContent(_json, Encoding.UTF8, APPLICATION_JSON);
           _httpResponseMessage.StatusCode = HttpStatusCode.OK;
        }

        public static void SetTextHttpResponseMessage(HttpResponseMessage _httpResponseMessage, string _sText)
        {
            _httpResponseMessage.Content = new StringContent(_sText, Encoding.UTF8, TEXT_HTML);
            _httpResponseMessage.StatusCode = HttpStatusCode.OK;
        }

        public static HttpResponseMessage SendError(string _sMessage)
        {
            HttpResponseMessage errorResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(_sMessage),
                StatusCode = HttpStatusCode.InternalServerError
            };

            return errorResponseMessage;
        }

        public static HttpResponseMessage GetUnauthorizedResponse()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized
            };
            return responseMessage;
        }
    }
}
