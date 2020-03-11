using System;
using System.IO;
using System.Security.Cryptography;
using SoftKeyUtils;

namespace AccSoftKeyLicenceFileGanerator
{
    public static class AESEncription
    {
        public static bool GenerateStrongKey(out byte[] _btKey, out byte[] _btIV)
        {
            _btKey = null;
            _btIV = null;

            try
            {
                using (AesManaged newAes = new AesManaged())
                {
                    newAes.KeySize = 512;

                    newAes.GenerateKey();
                    newAes.GenerateIV();
                    _btKey = newAes.Key;
                    _btIV = newAes.IV;
                }

                return true;
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "6b76eca4-7b91-4e61-bac6-b42aa7b07dbc");
            }

            return false;
        }

        public static byte[] EncryptStringToBytes(string _sPlainText, byte[] _btKey, byte[] _btIV)
        {
            try
            {
                // Check arguments. 
                if (string.IsNullOrEmpty(_sPlainText) == true)
                {
                    throw new Exception("The text is empty. 137850ac-1d05-40b1-8d9d-b758f59f57ed");
                }

                if ((_btKey == null)
                    || (_btKey.Length <= 0))
                {
                    throw new Exception("The key is empty. 2fbb05cb-21e6-445c-a50d-e74cadefcccf");
                }

                if ((_btIV == null)
                    || (_btIV.Length <= 0))
                {
                    throw new Exception("The IV is empty. d743df72-abf8-40c1-98ec-496d4176b0d8");
                }

                byte[] encrypted = null;

                // Create an AesManaged object 
                // with the specified key and IV. 
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = _btKey;
                    aesAlg.IV = _btIV;

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption. 
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {

                                //Write all data to the stream.
                                swEncrypt.Write(_sPlainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                // Return the encrypted bytes from the memory stream. 
                return encrypted;
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "e9aa6223-76ff-4010-bdb5-a35a41603152");
            }
            return null;
        }

        public static string DecryptStringFromBytes(byte[] _btCipherText, byte[] _btKey, byte[] _btIV)
        {
            try
            {
                // Check arguments. 
                if ((_btCipherText == null)
                    || (_btCipherText.Length <= 0))
                {
                    throw new Exception("The cipher text is empty. 5593e1cf-16cd-4b6d-bef7-ed2993357946");
                }


                if ((_btKey == null)
                    || (_btKey.Length <= 0))
                {
                    throw new Exception("The key is empty.be0345c4-7acf-479d-a237-a0d4e00ecfd7");
                }

                if ((_btIV == null)
                    || (_btIV.Length <= 0))
                {
                    throw new Exception("The IV is empty.7e123b56-683f-431b-9a0e-a6402b8ca29b");
                }

                // Declare the string used to hold 
                // the decrypted text. 
                string plaintext = null;

                // Create an AesManaged object 
                // with the specified key and IV. 
                using (AesManaged aesAlg = new AesManaged())
                {
                    aesAlg.Key = _btKey;
                    aesAlg.IV = _btIV;

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption. 
                    using (MemoryStream msDecrypt = new MemoryStream(_btCipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {

                                // Read the decrypted bytes from the decrypting stream 
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }

                }

                return plaintext;
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "b12a9703-e964-4e58-9867-794f40e5ebc1");
            }

            return string.Empty;
        }

    }
}
