namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The class provides string extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// The method performs MD5 hashing of the input string
        /// </summary>
        /// <param name="input">the string to hash</param>
        /// <returns>the MD5 hashed string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// The method converts a string to a Boolean value (True or False) 
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>Boolean value, depending on whether string is contained in the array of "true" string values</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// The method converts a string to a variable of type short
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>The result of trying to parse the input string into a short variable (short or null)</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// The method converts a string to a variable of type integer
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>The result of trying to parse the input string into integer (integer or null)</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// The method converts a string to a variable of type long integer
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>The result of trying to parse the input string into long integer (long integer or null)</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// The method converts a string to DateTime type
        /// </summary>
        /// <param name="input">The string to be converted</param>
        /// <returns>The result of trying to parse the input string into DateTime type (DateTime or null)</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// The method capitalizes the string first letter
        /// </summary>
        /// <param name="input">The string to be processed</param>
        /// <returns>The string with its first letter capitalized (if not null nor empty); otherwise - the string itself</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// The method retrieves part of a string included between two substrings - their first occurencies after a given start position
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="startString">The start string</param>
        /// <param name="endString">The end string</param>
        /// <param name="startFrom">Position in the input string from which to start searching</param>
        /// <returns>The substring retrieved, if both start and end string
        ///  are contained in the input string after the start position</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// The method converts an input string from Cyrillic to Latin
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The input string in which the cyrillic letters are converted to Latin letters</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// The method converts an input string from Latin to Cyrillic
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The input string in which the Latin letters are converted to Cyrillic letters</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// The method converts the input string containing an username into valid one 
        /// (only Latin letters, digits 0 to 9 and characters '_', '\', '.')
        /// </summary>
        /// <param name="input">The user name</param>
        /// <returns>The user name converted according to the validation rules</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// The method converts the input string containing file name into a valid one 
        /// (no spaces, using only Latin letters, digits 0 to 9 and characters '_', '-', '.')
        /// </summary>
        /// <param name="input">The file name</param>
        /// <returns>The file name converted according to the validation rules</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// The method gets from the input string a substring of given length (number of characters) 
        /// starting from position 0 
        /// </summary>
        /// <param name="input">The input string</param>
        /// <param name="charsCount">The length of the substring to be retrieved</param>
        /// <returns>The substring retrieved; if the characters count is greater than the string length, returns the input string</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// The method retrieves the file extension in a given file name
        /// </summary>
        /// <param name="fileName">String containing the file name</param>
        /// <returns>The file extension in a string; empty string, if no file extension was found.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// The method retrieves the type of content according to the given file name extension
        /// </summary>
        /// <param name="fileExtension">A string containing the file name extension</param>
        /// <returns>A String containing the type of the content</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// The method converts a string to a byte array of characters using block copy through a buffer
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>A byte array corresponding to the characters in the string </returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}