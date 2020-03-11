using System;
using System.IO;
using SoftKeyUtils;
using System.Diagnostics;
using System.Reflection;

namespace AccSoftKeyLicenceFileGanerator
{
    public class SoftLicence : IDisposable
    {
        private byte[] m_btKey = { 28, 128, 239, 116, 18, 144, 163, 1, 101, 50, 199, 212, 113, 248, 72, 107, 90, 217, 67, 150, 87, 225, 59, 47, 134, 124, 20, 77, 129, 84, 225, 142 };
        private byte[] m_btIV = { 158, 60, 125, 88, 113, 115, 2, 142, 85, 169, 224, 199, 199, 228, 194, 151 };
        private const string m_sOne = "23CF91473C0845249660B323E2EE62A";
        private const string m_sTwo = "EFA0725CFFD44124B4CA137B9B91A060";
        private const string m_csLicenceFileName = "acclicence.dat";

        public bool GenerateLicenceFile(string _sPlainText, string _sFolderPath)
        {
            try
            {
                if (string.IsNullOrEmpty(_sPlainText) == true)
                {
                    throw new Exception("The text is empty, 883e5b41-3c6f-4e96-8afb-6ca797b0aa9c");
                }

                if (Directory.Exists(_sFolderPath) == false)
                {
                    throw new Exception(string.Format("The {0} folder does not exist. {1}", _sFolderPath
                                                                , "a6ff0d40-2349-4563-bcb4-0f702330714a"));
                }

                byte[] ba = AESEncription.EncryptStringToBytes(string.Format("{0}{1}{2}"
                                                                                , m_sOne
                                                                                , _sPlainText
                                                                                , m_sTwo)
                                                                    , m_btKey
                                                                    , m_btIV);

                if ((ba != null) && (ba.Length > 0))
                {

                    File.WriteAllBytes(Path.Combine(_sFolderPath, m_csLicenceFileName)
                                        , ba);

                    Process.Start(_sFolderPath);

                    return true;
                }
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "53afb5eb-ac2e-4857-b2a8-52cfb4545dc0");
            }

            return false;
        }

        public bool ValidateLicence()
        {
            try
            {
                string sFolderPath = Assembly.GetExecutingAssembly().Location;

                if (sFolderPath != string.Empty)
                {
                    sFolderPath = Path.GetDirectoryName(sFolderPath);

                    sFolderPath = Path.Combine(sFolderPath, m_csLicenceFileName);

                    if (File.Exists(sFolderPath) == false)
                    {
                        throw new Exception("Cannot find acclicence.dat file in Trimble Enterprise Estimating folder. 883e5b41-3c6f-4e96-8afb-6ca797b0aa9c");
                    }
                }
                else
                {
                    throw new Exception("Cannot find acclicence.dat file in Trimble Enterprise Estimating folder. 19f633d8-17e6-4810-a00b-2c1f2c62973b");
                }

                byte[] ba = File.ReadAllBytes(sFolderPath);

                if ((ba == null) || (ba.Length == 0))
                {
                    throw new Exception("Could not read the acclicence.dat file. 2c0c6c5f-c6cb-406e-beac-725566502b53");
                }

                string sPlainText = AESEncription.DecryptStringFromBytes(ba, m_btKey, m_btIV);

                sPlainText = sPlainText.Replace(m_sOne, "");
                sPlainText = sPlainText.Replace(m_sTwo, "");

                string sComputerMetrics = ComputerMetrics.GetComputerUniqueID();

                return (sComputerMetrics == sPlainText);
            }
            catch (Exception exp)
            {
                Logger.WriteError(exp, "2f6ff5ea-0809-4d14-a6ff-57b112ca4601");
            }

            return false;
        }

        public void Dispose()
        {

        }
    }
}
