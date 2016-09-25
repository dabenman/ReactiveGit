﻿namespace ReactiveGit.Gui.Core.ExtensionMethods
{
    using System.Text;

    using PCLCrypto;

    /// <summary>
    /// Extension methods related to strings.
    /// </summary>
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Encodes a string into it's MD5 string.
        /// </summary>
        /// <param name="input">The text to encode.</param>
        /// <returns>The encoded string.</returns>
        public static string Md5Encode(this string input)
        {
            // step 1, calculate MD5 hash from input
            IHashAlgorithmProvider hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Md5);
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = hasher.HashData(inputBytes);

            var sb = new StringBuilder();
            foreach (byte character in hash)
            {
                sb.Append(character.ToString("X2"));
            }

            return sb.ToString().ToLowerInvariant();
        }
    }
}