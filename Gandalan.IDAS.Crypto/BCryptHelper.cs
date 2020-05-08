using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Crypto
{
    /// <summary>
    /// Klasse für die Ver-/Entschlüsselung von Strings mit BCrypt
    /// </summary>
    public class BCryptHelper
    {
        /// <summary>
        /// Erzeugt einen BCrypt-Hash eines Strings (OpenBSD-Schmema, generierter Salt)
        /// </summary>
        /// <param name="text">zu hashender String</param>
        /// <returns>gehashtes Ergebnis</returns>
        public static string GetBCryptHash(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }
    }
}
