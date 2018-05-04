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

    public class CommandController : EnterpriseBaseController
    {
        ProcessPOST dlgtPOST = null;

        public ProcessPOST DlgtPOST { get => dlgtPOST; set => dlgtPOST = value; }

        [Route("Command")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            RequestMessage rm = new RequestMessage();

            rm.State = HttpStatusCode.OK;
            rm.TimeStamp = DateTime.Now;

            return GetHttpResponseMessage(rm);
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
                RequestMessage rm = dlgtPOST?.Invoke((RequestMessage)GetObjectFromJsonString(sIn));

                HttpResponseMessage responseMessage = new HttpResponseMessage();
                responseMessage.Content = GetJsonStringAsHttpContentFromObject(rm);
                responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(EnterpriseBaseController.ApplicationJson);
                responseMessage.StatusCode = HttpStatusCode.OK;
                return responseMessage;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "7f357739-b349-4a2d-b3ea-41ba845c9b46");

                HttpResponseMessage errorResponseMessage = new HttpResponseMessage();
                errorResponseMessage.Content = new StringContent(exp.Message);
                errorResponseMessage.StatusCode = HttpStatusCode.InternalServerError;

                return errorResponseMessage;
            }

        }
    }
}
