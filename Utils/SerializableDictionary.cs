using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class SerializableDictionary<K, T>
    {
        private string m_sDataFileName = string.Empty;

        private Dictionary<K, T> m_dictData = null;
        private bool m_bIsDataLoaded = false;

        public SerializableDictionary()
        {
            if (m_dictData == null)
            {
                m_dictData = new Dictionary<K, T>();
            }

            m_sDataFileName = string.Format("{0}.dat", typeof(T).Name);
        }

        public T this[K _sKey]
        {
            get
            {
                if (ContainsKey(_sKey) == false)
                {
                    m_dictData.Add(_sKey, default(T));
                }

                return (m_dictData.ContainsKey(_sKey)) ? m_dictData[_sKey] : default(T);
            }
        }

        public T GetValue(K _sKey)
        {
            return (m_dictData.ContainsKey(_sKey)) ? m_dictData[_sKey] : default(T);
        }

        public bool ContainsKey(K _sKey)
        {
            return m_dictData.ContainsKey(_sKey);
        }

        public void LoadData()
        {
            LoadData(false);
        }

        private string GetFilePath()
        {
            try
            {
                string sMyDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                string sAssemblyPath = Path.Combine(sMyDocsPath, Assembly.GetEntryAssembly().GetName().Name);

                if (Directory.Exists(sAssemblyPath) == false)
                {
                    Directory.CreateDirectory(sAssemblyPath);
                }

                sAssemblyPath = Path.Combine(sAssemblyPath, m_sDataFileName);
                return sAssemblyPath;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "feeddb4c-cc64-4556-b237-714ab60069fd");
                return string.Empty;
            }
        }

        private void LoadData(bool _bReload)
        {
            try
            {
                if (((m_dictData != null) && (m_bIsDataLoaded == true))
                    && (_bReload == false))
                {
                    return;
                }

                string sDataFilePath = GetFilePath();

                if (File.Exists(sDataFilePath))
                {
                    string sData = Compression.Decompress(File.ReadAllText(sDataFilePath));

                    m_dictData = (Dictionary<K, T>)JsonConvert.DeserializeObject(sData, typeof(Dictionary<K, T>));

                    m_bIsDataLoaded = true;
                }
                else
                {
                    Logger.WriteErrorLogOnly("The data file {0} not found.", "8dcf0421-d278-4220-885a-cde09bd3f531");
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "089c9cf5-d69f-42d9-8d10-688009765d9e");

                throw new Exception("Failed to read configuration file.");
            }
        }

        public void Add(K _sKey, T _tValue)
        {
            if (m_dictData.ContainsKey(_sKey) == true)
            {
                m_dictData[_sKey] = _tValue;
            }
            else
            {
                m_dictData.Add(_sKey, _tValue);
            }
        }

        public void Delete(K _sKey)
        {
            if (m_dictData.ContainsKey(_sKey) == true)
            {
                m_dictData.Remove(_sKey);
            }
        }

        public bool SaveData()
        {
            string sBkNamePath = Path.GetTempFileName();
            bool bRetVal = false;
            string sAssemblyPath = GetFilePath();

            try
            {
                if (File.Exists(sAssemblyPath) == true)
                {
                    File.Delete(sBkNamePath);

                    File.Move(sAssemblyPath, sBkNamePath);
                }

                string sData = JsonConvert.SerializeObject(m_dictData, Formatting.Indented);

                File.WriteAllText(sAssemblyPath, Compression.Compress(sData));

                bRetVal = true;
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "d86cc203-6581-40db-bf76-884db529868d");
            }
            finally
            {
                if (bRetVal == true)
                {
                    File.Delete(sBkNamePath);
                }
                else
                {
                    File.Delete(sAssemblyPath);

                    File.Move(sBkNamePath, sAssemblyPath);
                }
            }

            return bRetVal;
        }
    }
}
