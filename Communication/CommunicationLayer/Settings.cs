using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CommunicationLayer
{
	public class SettingsMngr
	{
		public const string C_BASIC_HTTPBIN_DING = "http";
		public const string C_NET_TCP_BINDING = "net.tcp";

		public SettingsMngr()
		{
#if DEBUG
			try
			{
				SettingsConfig<Settings> s = new SettingsConfig<Settings>(InitSettingObjecForDebugModeSettingFileCreationDelegate);


				//SettingsConfig<Settings>.Instance.InitSettingObjecForDebugModeSettingFileCreation = InitSettingObjecForDebugModeSettingFileCreationDelegate;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "08d9a2db-2bbb-4d92-bc3d-3a57c92594a3");
			}
#endif

		}

		public static Settings GetSettings()
		{
			try
			{
				return SettingsConfig<Settings>.Instance.Settings;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "7b8eaef5-76e7-405a-8562-24107c9f38f1");
			}

			return null;
		}

		public void InitSettingObjecForDebugModeSettingFileCreationDelegate(out Settings _tSettings)
		{
			_tSettings = null;

			try
			{
				_tSettings = new Settings();

				_tSettings.Port = 9085;
				_tSettings.SendTimeout = 3;
				_tSettings.CloseTimeout = 3;
				_tSettings.OpenTimeout = 3;
				_tSettings.ReceiveTimeout = 3;
				_tSettings.ServiceName = @"CommunicationService";
				_tSettings.DNS = @"localhost";
				_tSettings.Binding = C_NET_TCP_BINDING;
				_tSettings.EndPoint = @"CommunicationService";
				_tSettings.MaxConnections = 10;

			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "3dbe1048-a22d-426f-9823-7240a2cf49c9");
			}
		}
	}


	[Serializable]
	public class Settings
	{
		private const int m_ciDefaultTimeoutInMinutes = 3;
		private const int m_ciMaxConnections = 10;
		private const string cstrFormat = "{0}://{1}:{2}/{3}";

		public Settings()
		{
			Port = 9085;
			SendTimeout = m_ciDefaultTimeoutInMinutes;
			CloseTimeout = m_ciDefaultTimeoutInMinutes;
			OpenTimeout = m_ciDefaultTimeoutInMinutes;
			ReceiveTimeout = m_ciDefaultTimeoutInMinutes;
			InactivityTimeout = m_ciDefaultTimeoutInMinutes;
			MaxConnections = m_ciMaxConnections;
			ServiceName = @"CommunicationService";
			DNS = @"localhost";
			Binding = SettingsMngr.C_NET_TCP_BINDING;
			EndPoint = @"Comm";

		}

		public string GetHostBaseAddress()
		{
			return string.Format(cstrFormat, Binding, DNS, Port, ServiceName);
		}

		public string GetEndPointBaseAddress()
		{
			return string.Format(@"{0}\{1}", cstrFormat, Binding, DNS, Port, ServiceName, EndPoint);
		}

		public string Binding { get; set; }
		public string EndPoint { get; set; }
		public string ServiceName { get; set; }
		public string DNS { get; set; }
		public int Port { get; set; }
		public int SendTimeout { get; set; }
		public int CloseTimeout { get; set; }
		public int OpenTimeout { get; set; }
		public int ReceiveTimeout { get; set; }
		public int InactivityTimeout { get; set; }
		public int MaxConnections { get; set; }
	}
}
