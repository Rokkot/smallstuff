using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CommunicationLayer
{
	public class CommunicatorController
	{
		private CommunicationServiceControlImpl m_CommService = null;
		private string m_sCommServiceStatus = string.Empty;

		public bool StartCommunicationService()
		{
			try
			{
				if (m_CommService != null)
				{
					m_sCommServiceStatus = "Service is running.";
					Logger.WriteInfo(m_sCommServiceStatus, "b1c91a0a-9429-44d5-9e65-a5569d9f50f6");
					return true;
				}


			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "f2b0080a-a92b-4108-be1a-fe56d4323ddc");
			}

			return false;
		}
}
