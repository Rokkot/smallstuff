using System;
using System.Net;
using Utils;
using HTTPCommLib;

namespace BackupperService
{
    public enum Commands
    {
        ReloadSettings = 10,
        StartBackupNow = 20,
    }

    public class Communicator
    {
        public Communicator()
        {
            
        }
        public static ResponseMessage POSTProc(RequestMessage _Request)
        {
            try
            {
                if (_Request == null)
                {
                    throw new Exception("The request object is null.");
                }

                switch (_Request.CommandID)
                {
                    case (int)Commands.ReloadSettings:
                        {
                            lock (SettingsManager.Instance)
                            {
                                SettingsManager.Instance.LoadSettings(true);

                            }
                            break;
                        }
                    case (int)Commands.StartBackupNow:
                        {
                            // not implemented
                            break;
                        }
                    default:
                        break;
                }

                ResponseMessage rm = new ResponseMessage(HttpStatusCode.OK, null);

                return rm;
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "24292034-9573-4739-a04d-ae3a5548a82c");

                return GetErrorResponceMessage(exp);
            }
        }

        public static ResponseMessage GETProc()
        {

            try
            {
                ResponseMessage rm = new ResponseMessage(HttpStatusCode.OK, "Hello from Service");

                return rm;
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "1992fe36-45b2-42cb-b17c-3ea1ca49799a");

                return GetErrorResponceMessage(exp);
            }
        }

        public static ResponseMessage GetErrorResponceMessage(Exception _exp)
        {
            try
            {
                ResponseMessage rm = new ResponseMessage(HttpStatusCode.InternalServerError, null);

                if (_exp != null)
                {
                    rm.ReturnObject = _exp.Message;
                    rm.ReturnObjectType = _exp.Message.GetType();
                }
                else
                {
                    rm.ReturnObject = "The exception object is null";
                    rm.ReturnObjectType = typeof(string);
                }

                return rm;
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "f0392e8a-14cf-48a5-a245-6961d8ff9ba4");

                ResponseMessage rm = new ResponseMessage(HttpStatusCode.InternalServerError, _exp.Message);
                return rm;
            }
        }
    }
}
