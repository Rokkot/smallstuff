using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Xml.Serialization;

using Utils;

namespace RunAs
{
	public class ConfigurationManager
	{
		public static string GetConfigurationFile(AppConfigBase configBase, bool bWriteMode)
		{
			string strAppDataFile = string.Empty;

			try
			{
				AppSettingsReader asReader = new AppSettingsReader();

				try
				{
					string sConfigSectionName = configBase.GetConfigSectionName();

					if (sConfigSectionName == string.Empty)
					{
						throw new Exception("The configuration section name is empty.");
					}

					strAppDataFile = (string)asReader.GetValue(sConfigSectionName, typeof(string));
				}
				catch(Exception exp)
				{
					Logger.ThrowException(exp, "650e7340-f0ba-4128-ade9-c8ad59404317");
					//throw new Exception(exp.Message + "650e7340-f0ba-4128-ade9-c8ad59404317");
				}

				int i = strAppDataFile.IndexOf(':');

				if (i == -1)
				{
					string strBaseDirectory;
					strBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

					strAppDataFile = strBaseDirectory + strAppDataFile;
				}

			}
			catch (Exception exp)
			{
				Logger.ThrowException(exp, "a0abae8c-61dc-48c5-b4c6-89fabd0da4f6");
			}

			return strAppDataFile;
		}

		public static AppConfigBase GetConfiguration(AppConfigBase configBase)
		{
			try
			{
				if (configBase.GetType() == typeof(AppConfigBase))
				{
					string strErrMessage = "The function GetConfiguration could not be used for the type AppConfigBase";
					Debug.Assert(false, strErrMessage);
					throw new Exception(strErrMessage);
				}

				return GetConfigurationImpl(configBase);
			}
			catch (Exception exp)
			{
				Logger.ThrowException(exp, "f33d438c-bde2-4b8a-b9c5-cd98434c9dce");
			}

			return null;
		}

		internal static AppConfigBase GetConfigurationImpl(AppConfigBase configBase)
		{
			try
			{
				string strAppDataFile = GetConfigurationFile(configBase, false);

				if (strAppDataFile == String.Empty)
				{
					return null;
				}

				XmlSerializer serializer = new XmlSerializer(configBase.GetType());

				object obj = null;

				if (!File.Exists(strAppDataFile))
				{
					if (configBase.GetType() == typeof(AppConfigBase))
					{
						throw new Exception(String.Format("Could not find AppConfigBase config file: {0}", strAppDataFile));
					}
					return configBase;
				}

				using (StreamReader sr = new StreamReader(strAppDataFile))
				{
					obj = serializer.Deserialize(sr);
				}
				return (AppConfigBase)obj;
			}
			catch (Exception exp)
			{
				Logger.ThrowException(exp, "98745257-7e53-4561-b698-92f057aec0b4");
			}

			return null;
		}

		public static void WriteConfiguration(AppConfigBase configBase)
		{
			try
			{
				if (configBase.GetType() == typeof(AppConfigBase))
				{
					string strErrMessage = "The function WriteConfiguration could not be used for the type AppConfigBase";
					Debug.Assert(false, strErrMessage);
					throw new Exception(strErrMessage);
				}

				string strAppDataFile = GetConfigurationFile(configBase, true);
				if (strAppDataFile == String.Empty)
				{
					return;
				}

				XmlSerializer serializer = new XmlSerializer(configBase.GetType());

				using (TextWriter writer = new StreamWriter(strAppDataFile))
				{
					serializer.Serialize(writer, configBase);
				}
			}
			catch (Exception exp)
			{
				Logger.ThrowException(exp, "a485d266-6a6c-46a8-a546-e424956e09e3");
			}
		}
	}

	public abstract class AppConfigBase
	{
		public abstract string GetConfigSectionName();
	}
}
