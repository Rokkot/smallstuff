﻿using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Utils;

namespace HTTPCommLib
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            try
            {
                HttpConfiguration config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();

                appBuilder.UseWebApi(config);
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "9650ddc5-eaad-4ea9-bb6a-517a6e0e4cf7");
            }
        }
    }

    public class HttpService
    {
        public const string BASE_ADDRESS = "http://localhost:8080/";
        private static object oStartStop = null;


        public static void StartService()
        {
            try
            {
                oStartStop = new object();

                Thread worker = new Thread(HttpService.DoWork);
                worker.Start(oStartStop);
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "85b17c05-a23f-48a2-8f8e-bd906f03724e");
            }
        }

        private static void DoWork(object data)
        {
            try
            {
                lock (data)
                {
                    // Start OWIN host 
                    using (WebApp.Start<Startup>(url: BASE_ADDRESS))
                    {


                        //// Create HttpCient and make a request to api/values 
                        //HttpClient client = new HttpClient();
                        //var response = client.GetAsync(BASE_ADDRESS + "api/values").Result;

                        Monitor.Wait(data);
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "54c51d44-b168-4aa8-b926-9846cc7ac3a3");
            }
        }

        public static void Stop()
        {
            try
            {
                lock (oStartStop)
                {
                    if (oStartStop != null)
                    {
                        Monitor.Pulse(oStartStop);
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "3fe69b77-4fa1-49c8-af7b-fc8b511a0047");
            }
        }
    }
}
