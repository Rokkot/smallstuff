using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using Utils;

namespace CommunicationLayer
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class CommunicationService : IDisposable, ICommunicationService
	{
		private List<ICustomEventHandler> m_EventSubscribers = null;
		private System.Threading.Timer m_SysTimer = null;
		private const int m_ciInterval = 60000 * 5; // 5 min


		public CommunicationService()
		{
			m_EventSubscribers = new List<ICustomEventHandler>();
		}

		public void Dispose()
		{
			try
			{
				StopPingTimer();

				if (m_EventSubscribers != null)
				{
					m_EventSubscribers.Clear();
				}

				if (m_SysTimer != null)
				{
					m_SysTimer.Dispose();
					m_SysTimer = null;
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

				//for test
				if (_data != null)
				{
					switch (_data.CommandID)
					{
						case 1:
							StartPingTimer((int)_data.CommandParams[0]);
							break;
						default:
							StopPingTimer();
							break;
					}
				}

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

		public void RaiseCustomEvent(string _sData)
		{
			try
			{
				int i = 0;
				ICustomEventHandler item = null;

				while (i < m_EventSubscribers.Count)
				{
					try
					{
						item = m_EventSubscribers[i];

						item.CustomEventRaised(_sData);

						i++;
					}
					catch (Exception e)
					{
						Logger.WriteErrorLogOnly(e, "91551953-65e1-4afa-aed1-e15add1f2962");

						m_EventSubscribers.Remove(item);
					}
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "2b62c6da-e5e0-49ac-b9f8-847d5e039b83");
			}
		}

		private void StartPingTimer()
		{
			StartPingTimer(m_ciInterval);
		}

		private void StartPingTimer(int _iInterval)
		{
			try
			{
				if (m_SysTimer == null)
				{
					m_SysTimer = new Timer(new TimerCallback(SystemTimerCallback)
													, null
													, _iInterval
													, _iInterval);
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "de65ac74-db54-4b79-a073-13c6df1696a5");
			}
		}

		private void StopPingTimer()
		{
			try
			{
				if (m_SysTimer != null)
				{
					m_SysTimer.Dispose();
					m_SysTimer = null;
				}
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "a32a7e92-8276-4468-b466-8f5845c28c73");
			}
		}

		private void SystemTimerCallback(object state)
		{
			try
			{
#if DEBUG
				RaiseCustomEvent("Hello World! " + DateTime.Now.ToLongTimeString());
#else
				RaiseCustomEvent(null);
#endif
			}
			catch (Exception exp)
			{
				StopPingTimer();
				Logger.WriteError(exp, "ea2e2208-6d70-4e3a-b833-94060d889597");
			}
		}
	}
}
