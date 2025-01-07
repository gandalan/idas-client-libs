using System;
using System.ComponentModel;
using System.Globalization;

namespace Gandalan.IDAS.Crypto;

/// <summary>
/// Summary description for HexEncoding.
/// </summary>
public class HexEncoding
{
    /// <summary>
    /// Calculates the number of bytes represented by a hexadecimal string, ignoring non-hexadecimal characters.
    /// If the number of valid hexadecimal characters is odd, the last character is discarded.
    /// </summary>
    /// <param name="hexString">The hexadecimal string to analyze.</param>
    /// <returns>
    /// The number of bytes represented by the valid hexadecimal characters in the string.
    /// Each byte is represented by two hexadecimal characters.
    /// </returns>
    public static int GetByteCount(string hexString)
    {
        var numHexChars = 0;
        // remove all none A-F, 0-9, characters
        foreach (var zeichen in hexString)
        {
            if (IsHexDigit(zeichen))
            {
                numHexChars++;
            }
        }

        // if odd number of characters, discard last character
        if (numHexChars % 2 != 0)
        {
            numHexChars--;
        }

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
        var newString = string.Empty;
        // remove all none A-F, 0-9, characters
        foreach (var zeichen in hexString)
        {
            if (IsHexDigit(zeichen))
            {
                newString += zeichen;
            }
            else
            {
                discarded++;
            }
        }

        // if odd number of characters, discard last character
        if (newString.Length % 2 != 0)
        {
            discarded++;
            newString = newString.Substring(0, newString.Length - 1);
        }

        var byteLength = newString.Length / 2;
        var returnValue = new byte[byteLength];
        var counter = 0;
        for (var index = 0; index < returnValue.Length; index++)
        {
            var hex = new string([newString[counter], newString[counter + 1]]);
            returnValue[index] = hexToByte(hex);
            counter += 2;
        }

        return returnValue;
    }

    /// <summary>
    /// Converts a byte array to a hexadecimal string representation, where each byte is represented as two uppercase hexadecimal characters.
    /// </summary>
    /// <param name="bytes">The byte array to convert.</param>
    /// <returns>
    /// A string containing the hexadecimal representation of the byte array.
    /// Each byte is represented by two characters in uppercase.
    /// </returns>
    public static string ToString(byte[] bytes)
    {
        var returnValue = string.Empty;
        foreach (var t in bytes)
        {
            returnValue += t.ToString("X2");
        }

        return returnValue;
    }

    /// <summary>
    /// Determines if given string is in proper hexadecimal string format
    /// </summary>
    public static bool InHexFormat(string hexString)
    {
        var returnValue = true;
        foreach (var digit in hexString)
        {
            if (!IsHexDigit(digit))
            {
                returnValue = false;
                break;
            }
        }

        return returnValue;
    }

    /// <summary>
    /// Returns <see langword="true"/> is c is a hexadecimal digit (A-F, a-f, 0-9)
    /// </summary>
    /// <param name="zeichen">Character to test</param>
    /// <returns><see langword="true"/> if hex digit, <see langword="false"/> if not</returns>
    public static bool IsHexDigit(char zeichen)
    {
        var returnValue = false;
        zeichen = char.ToUpper(zeichen);
        var numA = ConvertTo<int>('A', default);
        var num1 = ConvertTo<int>('0', default);
        var numChar = ConvertTo<int>(zeichen, default);
        if (numChar >= numA && numChar < numA + 6)
        {
            returnValue = true;
        }
        else if (numChar >= num1 && numChar < num1 + 10)
        {
            returnValue = true;
        }

        return returnValue;
    }

    /// <summary>
    /// Converts 1 or 2 character string into equivalent byte value
    /// </summary>
    /// <param name="hex">1 or 2 character string</param>
    /// <returns>byte</returns>
    private static byte hexToByte(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length > 2)
        {
            throw new ArgumentException("hex must be 1 or 2 characters in length", nameof(hex));
        }

        return byte.Parse(hex, NumberStyles.HexNumber);
    }

    /// <summary>
    /// Converts an object to a specified type, returning a default value if the conversion is not possible.
    /// </summary>
    /// <typeparam name="T">The target type to which the object should be converted.</typeparam>
    /// <param name="value">The object to convert.</param>
    /// <param name="defaultValue">The default value to return if the conversion is not possible.</param>
    /// <returns>
    /// The converted value of type <typeparamref name="T"/> if the conversion succeeds;
    /// otherwise, <paramref name="defaultValue"/>.
    /// </returns>
    public static T ConvertTo<T>(object value, T defaultValue)
    {
        var obj = defaultValue;
        if (value != null)
        {
            if (value is T t)
            {
                obj = t;
            }
            else
            {
                var type = typeof(T);
                var converter1 = TypeDescriptor.GetConverter(value);
                if (converter1 != null && converter1.CanConvertTo(type))
                {
                    obj = (T)converter1.ConvertTo(value, type);
                }
                else
                {
                    var converter2 = TypeDescriptor.GetConverter(type);
                    if (converter2 != null && converter2.CanConvertFrom(value.GetType()))
                    {
                        obj = (T)converter2.ConvertFrom(value);
                    }
                }
            }
        }

        return obj;
    }
}
