using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Gandalan.IDAS.Crypto;

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
    /// Decrypt the data string to the original string. The data must be the base64 string
    /// returned from the <see cref="EncryptData(string,string)"/> method.
    /// </summary>
    /// <param name="data">Encrypted data generated from <see cref="EncryptData(string,string)"/> method.</param>
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

    /// <summary>
    /// Encrypts a byte array using AES encryption with the specified password and padding mode.
    /// The same password and padding mode must be used to decrypt the data.
    /// </summary>
    /// <param name="data">The byte array to encrypt.</param>
    /// <param name="password">The password used for encryption.</param>
    /// <param name="paddingMode">The padding mode to use during encryption.</param>
    /// <returns>A byte array containing the encrypted data.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="data"/> is null or empty, or when <paramref name="password"/> is null.
    /// </exception>
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

    /// <summary>
    /// Decrypts an encrypted byte array back to its original byte array using AES decryption.
    /// The encrypted data must be created using a compatible encryption method, such as
    /// <see cref="EncryptData(byte[], string, PaddingMode)"/>.
    /// </summary>
    /// <param name="data">The encrypted byte array to decrypt.</param>
    /// <param name="password">The password used for decryption, matching the encryption password.</param>
    /// <param name="paddingMode">The padding mode used during encryption.</param>
    /// <returns>A byte array containing the decrypted data.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="data"/> is null or empty, or when <paramref name="password"/> is null.
    /// </exception>
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
