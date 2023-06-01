using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

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
                throw new ArgumentNullException("data");
            if (password == null)
                throw new ArgumentNullException("password");
            byte[] encBytes = EncryptData(Encoding.UTF8.GetBytes(data), password, PaddingMode.ISO10126);
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
                throw new ArgumentNullException("data");
            if (password == null)
                throw new ArgumentNullException("password");
            byte[] encBytes = Convert.FromBase64String(data);
            byte[] decBytes = DecryptData(encBytes, password, PaddingMode.ISO10126);
            return Encoding.UTF8.GetString(decBytes);
        }

        public static byte[] EncryptData(byte[] data, string password, PaddingMode paddingMode)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentNullException("data");
            if (password == null)
                throw new ArgumentNullException("password");
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, Encoding.UTF8.GetBytes("Salt"));
            var rm = Aes.Create();
            rm.Padding = paddingMode;
            ICryptoTransform encryptor = rm.CreateEncryptor(pdb.GetBytes(16), pdb.GetBytes(16));
            using (MemoryStream msEncrypt = new MemoryStream())
            using (CryptoStream encStream = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                encStream.Write(data, 0, data.Length);
                encStream.FlushFinalBlock();
                return msEncrypt.ToArray();
            }
        }

        public static byte[] DecryptData(byte[] data, string password, PaddingMode paddingMode)
        {
            if (data == null || data.Length == 0)
                throw new ArgumentNullException("data");
            if (password == null)
                throw new ArgumentNullException("password");
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, Encoding.UTF8.GetBytes("Salt"));
            var rm = Aes.Create();
            rm.Padding = paddingMode;
            ICryptoTransform decryptor = rm.CreateDecryptor(pdb.GetBytes(16), pdb.GetBytes(16));
            using (MemoryStream msDecrypt = new MemoryStream(data))
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                // Decrypted bytes will always be less then encrypted bytes, so len of encrypted data will be big enouph for buffer.
                byte[] fromEncrypt = new byte[data.Length];
                // Read as many bytes as possible.
                int read = csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                if (read < fromEncrypt.Length)
                {
                    // Return a byte array of proper size.
                    byte[] clearBytes = new byte[read];
                    Buffer.BlockCopy(fromEncrypt, 0, clearBytes, 0, read);
                    return clearBytes;
                }
                return fromEncrypt;
            }
        }

        private const string CHAR1 = "BFHKPQVXY2346789";
        private const string CHAR2 = "0123456789ABCDEF";

        static string encode(byte[] data)
        {
            string temp = HexEncoding.ToString(data);
            string result = "";
            for (int i = 0; i < temp.Length; i++)
            {
                result += CHAR1[CHAR2.IndexOf(temp[i])];
            }

            return result;
        }

        static byte[] decode(string encoded)
        {
            string temp = "";
            for (int i = 0; i < encoded.Length; i++)
            {
                temp += CHAR2[CHAR1.IndexOf(encoded[i])];
            }
            int b;
            byte[] result = HexEncoding.GetBytes(temp, out b);
            return result;
        }

    }
}
