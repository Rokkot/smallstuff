using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Utils;

namespace CommunicationLayer
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class CommunicationServiceControlImpl : IDisposable, ICommunicationServiceControl
	{
		private List<ICustomEventHandler> m_EventSubscribers = null;

		public CommunicationServiceControlImpl()
		{
			m_EventSubscribers = new List<ICustomEventHandler>();
		}

		public void Dispose()
		{
			try
			{
				if (m_EventSubscribers != null)
				{
					m_EventSubscribers.Clear();
				}
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

		public void SubscribeForEvernts()
		{
			try
			{
				if (m_EventSubscribers != null)
				{
					m_EventSubscribers.Add(OperationContext.Current.GetCallbackChannel<ICustomEventHandler>());
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "97f18a98-6aba-4ab7-93a2-ff4e0fe3070e");
			}
		}

		public void UnSubscribeFromEvernts()
		{
			try
			{
				if (m_EventSubscribers != null)
				{
					ICustomEventHandler caller = OperationContext.Current.GetCallbackChannel<ICustomEventHandler>();
					m_EventSubscribers.Remove(caller);
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "b89c3e29-de12-45bb-93fc-7c6bfaa9be58");
			}
		}
	}
}
