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

    public const string ApplicationJson = "application/json";
    public const string TextHTML = "text/html";

    public abstract class EnterpriseBaseController : ApiController
    {
        protected HttpResponseMessage GetHttpResponseMessage()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent("", Encoding.UTF8, TextHTML),
                StatusCode = System.Net.HttpStatusCode.OK
            };

            return httpResponseMessage;
        }

        protected HttpResponseMessage GetHttpResponseMessage(string text)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(text, Encoding.UTF8, TextHTML),
                StatusCode = System.Net.HttpStatusCode.OK
            };

            return httpResponseMessage;
        }
        protected object GetObjectFromJsonString(string sO)
        {
            return JsonConvert.DeserializeObject(sO, typeof(RequestMessage));
        }

        protected HttpContent GetJsonStringAsHttpContentFromObject(object o)
        {
            return new StringContent(JsonConvert.SerializeObject(o, Formatting.None)
                                           , Encoding.UTF8, ApplicationJson);
        }

        protected HttpResponseMessage GetHttpResponseMessage(object o)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(o, Formatting.None)
                                           , Encoding.UTF8, ApplicationJson),
                StatusCode = System.Net.HttpStatusCode.OK
        };

            return httpResponseMessage;
        }

        protected void SetHttpResponseMessage(HttpResponseMessage httpResponseMessage, object o)
        {
            SetJsonHttpResponseMessage(httpResponseMessage, JsonConvert.SerializeObject(o, Formatting.None));
        }

        protected void SetJsonHttpResponseMessage(HttpResponseMessage httpResponseMessage, string json)
        {
            httpResponseMessage.Content = new StringContent(json, Encoding.UTF8, ApplicationJson);
            httpResponseMessage.StatusCode = System.Net.HttpStatusCode.OK;
        }

        protected void SetTextHttpResponseMessage(HttpResponseMessage httpResponseMessage, string text)
        {
            httpResponseMessage.Content = new StringContent(text, Encoding.UTF8, TextHTML);
            httpResponseMessage.StatusCode = System.Net.HttpStatusCode.OK;
        }

        protected HttpResponseMessage SendError(string message)
        {
            HttpResponseMessage errorResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(message),
                StatusCode = HttpStatusCode.InternalServerError
            };

            return errorResponseMessage;
        }

        protected HttpResponseMessage GetUnauthorizedResponse()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized
            };
            return responseMessage;
        }
    }
}
