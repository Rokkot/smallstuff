using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace AppRunnerService
{
	public static class Serialization
	{
		public static object DeserializeObject(string pXmlizedString, Type tp)
		{
			try
			{
				XmlSerializer xs = new XmlSerializer(tp);


				MemoryStream memoryStream = new MemoryStream(StringToUnicodeByteArray(pXmlizedString));

				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);

				return xs.Deserialize(memoryStream);
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "0c627be0-5120-4666-86c5-030b26c2e514");
			}

			return null;
		}

		public static string SerializeObject(object pObject)
		{
			try
			{
				String XmlizedString = null;
				MemoryStream memoryStream = new MemoryStream();
				XmlSerializer xs = new XmlSerializer(pObject.GetType());

				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);

				xs.Serialize(xmlTextWriter, pObject);
				memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

				XmlizedString = UnicodeByteArrayToString(memoryStream.ToArray());

				return XmlizedString;
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "b7fa6cfe-1fef-47cb-8eec-de7e72672eb3");
			}

			return string.Empty;
		}

		private static Byte[] StringToUnicodeByteArray(string pXmlString)
		{
			UnicodeEncoding encoding = new UnicodeEncoding();
			Byte[] byteArray = encoding.GetBytes(pXmlString);
			return byteArray;
		}

		private static string UnicodeByteArrayToString(byte[] characters)
		{
			UnicodeEncoding encoding = new UnicodeEncoding();
			String constructedString = encoding.GetString(characters);
			return (constructedString);
		}
	}
}
