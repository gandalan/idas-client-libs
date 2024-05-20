using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Gandalan.IDAS.Crypto
{
    /// <summary>
    /// Klasse für die Ver-/Entschlüsselung von Strings mit AES
    /// </summary>
    public class AESHelper
    {
        /// <summary>
        /// Use AES to encrypt data string. The output string is the encrypted bytes as a base64 string.
        /// The same password must be used to decrypt the string.
        /// </summary>
        /// <param name="data">Clear string to encrypt.</param>
        /// <param name="password">Password used to encrypt the string.</param>
        /// <returns>Encrypted result as Base64 string.</returns>
        public static string EncryptData(string data, string password)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var encBytes = EncryptData(Encoding.UTF8.GetBytes(data), password, PaddingMode.ISO10126);
            return Convert.ToBase64String(encBytes);
        }

        /// <summary>
        /// Decrypt the data string to the original string.  The data must be the base64 string
        /// returned from the EncryptData method.
        /// </summary>
        /// <param name="data">Encrypted data generated from EncryptData method.</param>
        /// <param name="password">Password used to decrypt the string.</param>
        /// <returns>Decrypted string.</returns>
        public static string DecryptData(string data, string password)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var encBytes = Convert.FromBase64String(data);
            var decBytes = DecryptData(encBytes, password, PaddingMode.ISO10126);
            return Encoding.UTF8.GetString(decBytes);
        }

        public static byte[] EncryptData(byte[] data, string password, PaddingMode paddingMode)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var pdb = new PasswordDeriveBytes(password, Encoding.UTF8.GetBytes("Salt"));
            var rm = Aes.Create();
            rm.Padding = paddingMode;
            var encryptor = rm.CreateEncryptor(pdb.GetBytes(16), pdb.GetBytes(16));
            using (var msEncrypt = new MemoryStream())
            {
                using (var encStream = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    encStream.Write(data, 0, data.Length);
                    encStream.FlushFinalBlock();
                    return msEncrypt.ToArray();
                }
            }
        }

        public static byte[] DecryptData(byte[] data, string password, PaddingMode paddingMode)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var pdb = new PasswordDeriveBytes(password, Encoding.UTF8.GetBytes("Salt"));
            var rm = Aes.Create();
            rm.Padding = paddingMode;
            var decryptor = rm.CreateDecryptor(pdb.GetBytes(16), pdb.GetBytes(16));
            using (var msDecrypt = new MemoryStream(data))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    // Decrypted bytes will always be less then encrypted bytes, so len of encrypted data will be big enough for buffer.
                    var fromEncrypt = new byte[data.Length];
                    // Read as many bytes as possible.
                    var read = csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                    if (read < fromEncrypt.Length)
                    {
                        // Return a byte array of proper size.
                        var clearBytes = new byte[read];
                        Buffer.BlockCopy(fromEncrypt, 0, clearBytes, 0, read);
                        return clearBytes;
                    }

                    return fromEncrypt;
                }
            }
        }
    }
}
