using System;
using System.Security.Cryptography;
using System.Text;

namespace Gandalan.IDAS.Crypto
{
    public class SHA1Helper
    {
        /// <summary>
        /// Erzeugt einen SHA1-Hash eines Strings
        /// </summary>
        /// <param name="text">zu hashender String</param>
        /// <returns>gehashtes Ergebnis</returns>
        public static string GetSHA1Hash(string text)
        {
            string result = null;

            using (var hash = SHA1.Create()) 
            {
                string temp = null;

                var arrayData = Encoding.ASCII.GetBytes(text);
                var arrayResult = hash.ComputeHash(arrayData);
                for (int i = 0; i < arrayResult.Length; i++)
                {
                    temp = Convert.ToString(arrayResult[i], 16);
                    if (temp.Length == 1)
                        temp = "0" + temp;
                    result += temp;
                }
            }

            return result;
        }
    }
}
