using HTTPCommLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupperService
{
    public class Communicator
    {
        public Communicator()
        {
            
        }
        public static ResponseMessage POSTProc(RequestMessage _Request)
        {
            ResponseMessage rm = new ResponseMessage();
            rm.ReturnObject = "Hello from Service";
            rm.ReturnObjectType = typeof(string);

            return rm;
        }

        public static ResponseMessage GETProc()
        {
            ResponseMessage rm = new ResponseMessage();
            rm.ReturnObject = "Hello from Service";
            rm.ReturnObjectType = typeof(string);

            return rm;
        }
    }
}
