using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCommLib
{
    //public class HttpCommunicator
    //{
    //    private TimeSpan m_SendTimeout = TimeSpan.FromSeconds(100);
    //    private TimeSpan m_ReadWriteTimeout = TimeSpan.FromMinutes(5);
    //    private string m_strDestAddress = string.Empty;


    //    #region @cmnt SKislyuk: [09 May 18, 09:29:36]   [180509_092936]
    //    //public byte[] CompressData(DataSet ds)
    //    //{
    //    //try
    //    //{
    //    //byte[] data = null;

    //    //using (MemoryStream memStream = new MemoryStream())
    //    //{
    //    //using (GZipStream zipStream = new GZipStream(memStream, CompressionMode.Compress))
    //    //{
    //    //ds.WriteXml(zipStream, XmlWriteMode.WriteSchema);

    //    //zipStream.Close();
    //    //}

    //    //data = memStream.ToArray();

    //    //memStream.Close();
    //    //}

    //    //return data;
    //    //}
    //    //catch (Exception exp)
    //    //{
    //    //Logger.WriteError(exp, "063dd666-a600-482f-a1d1-0ef38d91a874");
    //    //return null;
    //    //}
    //    //}

    //    //public DataSet DecompressData(byte[] data)
    //    //{
    //    //try
    //    //{
    //    //DataSet ds = new DataSet();

    //    //using (MemoryStream memStream = new MemoryStream(data))
    //    //{
    //    //using (GZipStream unzipStream = new GZipStream(memStream, CompressionMode.Decompress))
    //    //{
    //    //ds.ReadXml(unzipStream, XmlReadMode.ReadSchema);

    //    //unzipStream.Close();
    //    //}

    //    //memStream.Close();
    //    //}

    //    //return ds;
    //    //}
    //    //catch (Exception exp)
    //    //{
    //    //Logger.WriteError(exp, "aecfbb78-bcc1-4df9-b391-3a01a326cacb");
    //    //return null;
    //    //}
    //    //}
    //    #endregion @cmnt SKislyuk: [09 May 18, 09:29:36]   [180509_092936]

    //}

}