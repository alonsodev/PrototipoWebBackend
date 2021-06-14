using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace ProtoWeb.Infra.CrossCutting.Net.Cryptography
{
    public class Cryptography : ICryptography
    {
        public string EncryptionKey { get; set; }
        public string EncryptionIV { get; set; }

        public Cryptography(string encryptionKey, string encryptionIV)
        {
            EncryptionKey = encryptionKey;
            EncryptionIV = encryptionIV;
        }

        public string EncryptString(string plainText)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            byte[] encrypted;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(EncryptionIV);
                aesAlg.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted).Replace('+', '-').Replace('/', '_');
        }

        public string DecryptString(string cipherTextString)
        {
            if (cipherTextString == null || cipherTextString.Length <= 0)
                throw new ArgumentNullException("cipherText");
            var cipherTextStringFormateado = cipherTextString.Replace('-', '+').Replace('_', '/');
            var cipherText = Convert.FromBase64String(cipherTextStringFormateado);
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(EncryptionIV);
                aesAlg.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
