using System;
using System.Collections.Generic;
using System.ServiceModel;
using Utils;

namespace CommunicationLayer
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class HttpCommunicationService : IDisposable, IHttpCommunicationService
	{
		public HttpCommunicationService()
		{
		}

		public void Dispose()
		{
			try
			{
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "69513df6-b661-4ca2-a1a7-d616f8cbbe81");
			}
		}

		public bool ExecuteCommand(CommandData _data)
		{
			bool bRetCode = false;

			try
			{
				// execute command here
				// ...
				//

				// if command executed successfully return true
				bRetCode = true;

				return bRetCode;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "516c34b8-7d47-4b40-bad9-deed19f0ea17");
			}

			return bRetCode;
		}

		public List<StatusInfo> GetStatusInfo()
		{
			try
			{
				List<StatusInfo> info = new List<StatusInfo>();

				// gather and return info
				// ....
				//

				return info;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "516c34b8-7d47-4b40-bad9-deed19f0ea17");
			}

			return null;
		}

		public bool IsRunning()
		{
			return true;
		}
	}
}
