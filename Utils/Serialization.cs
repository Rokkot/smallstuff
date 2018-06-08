using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Utils
{
	public static class Serialization
	{
		public static object DeserializeObject(string _sXml, Type _tp)
		{
			try
			{
				XmlSerializer xs = new XmlSerializer(_tp);


				MemoryStream memoryStream = new MemoryStream(StringToUnicodeByteArray(_sXml));

				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);

				return xs.Deserialize(memoryStream);
			}
			catch (Exception exp)
			{
				Logger.WriteError(exp, "0c627be0-5120-4666-86c5-030b26c2e514");
			}

			return null;
		}

		public static string SerializeObject(object _o)
		{
			try
			{
				String XmlizedString = null;
				MemoryStream memoryStream = new MemoryStream();
				XmlSerializer xs = new XmlSerializer(_o.GetType());

				XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);

				xs.Serialize(xmlTextWriter, _o);
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

		private static Byte[] StringToUnicodeByteArray(string _sXml)
		{
			UnicodeEncoding encoding = new UnicodeEncoding();
			Byte[] byteArray = encoding.GetBytes(_sXml);
			return byteArray;
		}

		private static string UnicodeByteArrayToString(byte[] _characters)
		{
			UnicodeEncoding encoding = new UnicodeEncoding();
			String constructedString = encoding.GetString(_characters);
			return (constructedString);
		}
    }
}
