using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Crypto
{
    /// <summary>
    /// Summary description for HexEncoding.
    /// </summary>
    public class HexEncoding
    {
        #region public Methods
        public static int GetByteCount(string hexString)
        {
            int numHexChars = 0;
            char zeichen;
            // remove all none A-F, 0-9, characters
            for (int index = 0; index < hexString.Length; index++)
            #region Code
            {
                zeichen = hexString[index];
                if (IsHexDigit(zeichen))
                    numHexChars++;
            }
            #endregion
            // if odd number of characters, discard last character
            if (numHexChars % 2 != 0)
                numHexChars--;
            return numHexChars / 2; // 2 characters per byte
        }
        /// <summary>
        /// Creates a byte array from the hexadecimal string. Each two characters are combined
        /// to create one byte. First two hexadecimal characters become first byte in returned array.
        /// Non-hexadecimal characters are ignored. 
        /// </summary>
        /// <param name="hexString">string to convert to byte array</param>
        /// <param name="discarded">number of characters in string ignored</param>
        /// <returns>byte array, in the same left-to-right order as the hexString</returns>
        public static byte[] GetBytes(string hexString, out int discarded)
        {
            discarded = 0;
            string newString = string.Empty;
            char zeichen;
            // remove all none A-F, 0-9, characters
            for (int index = 0; index < hexString.Length; index++)
            #region Code
            {
                zeichen = hexString[index];
                if (IsHexDigit(zeichen))
                    newString += zeichen;
                else
                    discarded++;
            }
            #endregion
            // if odd number of characters, discard last character
            if (newString.Length % 2 != 0)
            #region Code
            {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }
            #endregion

            int byteLength = newString.Length / 2;
            byte[] returnValue = new byte[byteLength];
            string hex;
            int counter = 0;
            for (int index = 0; index < returnValue.Length; index++)
            #region Code
            {
                hex = new String(new Char[] { newString[counter], newString[counter + 1] });
                returnValue[index] = hexToByte(hex);
                counter += 2;
            }
            #endregion
            return returnValue;
        }
        public static string ToString(byte[] bytes)
        {
            string returnValue = string.Empty;
            for (int index = 0; index < bytes.Length; index++)
                returnValue += bytes[index].ToString("X2");
            return returnValue;
        }
        /// <summary>
        /// Determines if given string is in proper hexadecimal string format
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static bool InHexFormat(string hexString)
        {
            bool returnValue = true;
            foreach (char digit in hexString)
            #region Code
            {
                if (!IsHexDigit(digit))
                #region Code
                {
                    returnValue = false;
                    break;
                }
                #endregion
            }
            #endregion
            return returnValue;
        }
        /// <summary>
        /// Returns true is c is a hexadecimal digit (A-F, a-f, 0-9)
        /// </summary>
        /// <param name="zeichen">Character to test</param>
        /// <returns>true if hex digit, false if not</returns>
        public static bool IsHexDigit(Char zeichen)
        {
            bool returnValue = false;
            zeichen = Char.ToUpper(zeichen);
            int numA = ConvertTo<Int32>('A', default(Int32));
            int num1 = ConvertTo<Int32>('0', default(Int32));
            int numChar = ConvertTo<Int32>(zeichen, default(Int32));
            if ((numChar >= numA) && (numChar < (numA + 6)))
                returnValue = true;
            else if ((numChar >= num1) && (numChar < (num1 + 10)))
                returnValue = true;
            return returnValue;
        }
        #endregion

        #region private Methods
        /// <summary>
        /// Converts 1 or 2 character string into equivalant byte value
        /// </summary>
        /// <param name="hex">1 or 2 character string</param>
        /// <returns>byte</returns>
        private static byte hexToByte(string hex)
        {
            if (string.IsNullOrEmpty(hex) || (hex.Length > 2))
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            return byte.Parse(hex, NumberStyles.HexNumber);
        }
        #endregion

        public static T ConvertTo<T>(object value, T defaultValue)
        {
            T obj = defaultValue;
            if (value != null)
            {
                if (value is T)
                {
                    obj = (T)value;
                }
                else
                {
                    Type type = typeof(T);
                    TypeConverter converter1 = TypeDescriptor.GetConverter(value);
                    if (converter1 != null && converter1.CanConvertTo(type))
                    {
                        obj = (T)converter1.ConvertTo(value, type);
                    }
                    else
                    {
                        TypeConverter converter2 = TypeDescriptor.GetConverter(type);
                        if (converter2 != null && converter2.CanConvertFrom(value.GetType()))
                            obj = (T)converter2.ConvertFrom(value);
                    }
                }
            }
            return obj;
        }
    }
}
