using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Utils;

namespace HTTPCommLib
{
    public delegate RequestMessage ProcessPOST(RequestMessage request);
    public delegate RequestMessage ProcessGet();

    public class CommandController : ApiController
    {
        private static ProcessPOST dlgtPOST = null;

        private static ProcessGet dlgtGet = null;

        public static ProcessPOST DlgtPOST { get => dlgtPOST; set => dlgtPOST = value; }

        public static ProcessGet DlgGet { get => dlgtGet; set => dlgtGet = value; }

        [Route("Command")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                RequestMessage rm = new RequestMessage();

                // SKislyuk 5/4/2018 2:19:32 PM
                // Process Get request
                rm = DlgGet?.Invoke();

                return HTTPHelper.GetHttpResponseMessage(rm);
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "9d168b63-ed34-49c1-80fb-ddbc4cfffafe");
                return HTTPHelper.GetHttpErrorMessage(exp.Message, "9d168b63-ed34-49c1-80fb-ddbc4cfffafe");
            }
        }

        [Route("Command")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        { 
            try
            {
                string sIn = await Request.Content.ReadAsStringAsync();

                // SKislyuk 5/4/2018 2:19:32 PM
                // Process Post request
                RequestMessage rm = DlgtPOST?.Invoke((RequestMessage)HTTPHelper.GetObjectFromJsonString(sIn));

                HttpResponseMessage responseMessage = new HttpResponseMessage();
                responseMessage.Content = HTTPHelper.GetJsonStringAsHttpContentFromObject(rm);
                responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(HTTPHelper.APPLICATION_JSON);
                responseMessage.StatusCode = HttpStatusCode.OK;
                return responseMessage;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "7f357739-b349-4a2d-b3ea-41ba845c9b46");
                return HTTPHelper.GetHttpErrorMessage(exp.Message, "7f357739-b349-4a2d-b3ea-41ba845c9b46");
            }

        }
    }
}
