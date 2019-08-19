using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegistrationAndManagementSystem.Helpers
{
    public static class Cryptography
    {
        public static string Encrypt(string clearText)
        {
            string hash = "MyEncryptionKey2546KD57as72BO";
            string cipherText = "";
            byte[] data = Encoding.UTF8.GetBytes(clearText);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    cipherText = Convert.ToBase64String(results, 0, results.Length);
                }
            }
            return cipherText;
        }

        public static string Decrypt(string cipherText)
        {
            string hash = "MyEncryptionKey2546KD57as72BO";
            string clearText = "";
            byte[] data = Convert.FromBase64String(cipherText);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    clearText = Encoding.UTF8.GetString(results);
                }
            }
            return clearText;
        }
    }
}
