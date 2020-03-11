using System;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SoftKeyUtils
{
    public static class CryptoUtils
    {
        /// <summary>
		/// Calculates the SHA1 checksum.
		/// </summary>
		/// <returns></returns>
		public static string CalculateChecksumSHA512(byte[] _byteArray)
        {
            try
            {
                if ((_byteArray != null)
                    && (_byteArray.Length > 0))
                {
                    using (SHA512Managed sha512 = new SHA512Managed())
                    {
                        byte[] hash = sha512.ComputeHash(_byteArray);

                        return BitConverter.ToString(hash).Replace("-", String.Empty);
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "7c8e978f-7c2b-4a11-99e0-bc5d3244ad0f");
            }

            return string.Empty;
        }

        public static string CalculateChecksumSHA512(string _sText)
        {
            try
            {
                if (string.IsNullOrEmpty(_sText) != true)
                {
                    return CalculateChecksumSHA512(ObjectToByteArray(_sText));
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "c9a918b2-7ac2-444b-a0c8-9e43a6af0fff");
            }

            return string.Empty;
        }

        /// <summary>
		/// Objects to byte array.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns></returns>
		private static byte[] ObjectToByteArray(Object obj)
        {
            try
            {
                if (obj == null)
                {
                    return null;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(ms, obj);

                    return ms.ToArray();
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "8b40c1a8-f4b4-4d23-8d60-be301b7497b1");
            }

            return null;
        }
    }
}
