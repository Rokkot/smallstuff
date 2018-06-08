using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Utils
{
    public static class Compression
    {
        public static string Compress(string _sData)
        {
            try
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(_sData);

                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (GZipStream gZipStream = new GZipStream(outputStream, CompressionMode.Compress))
                    {
                        gZipStream.Write(inputBytes, 0, inputBytes.Length);
                    }

                    byte[] outputBytes = outputStream.ToArray();

                    return Convert.ToBase64String(outputBytes);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "69f070e7-225f-4f3e-8d22-e449be63458a");
                return string.Empty;
            }
        }

        public static string Decompress(string _sBase64Data)
        {
            try
            {
               byte[] inputBytes = Convert.FromBase64String(_sBase64Data);

                using (MemoryStream inputStream = new MemoryStream(inputBytes))
                {
                    using (GZipStream gZipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        using (StreamReader streamReader = new StreamReader(gZipStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "c3067634-e18c-403c-a980-d93d4a9d117f");
                return string.Empty;
            }
        }
    }
}
