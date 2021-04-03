using System;
using System.Globalization;

namespace Mata007.QueryFunctions
{
    /// <summary>
    /// Functions applicable in LINQ queries to allow accent and case insensitive search in strings
    /// </summary>
    public static class StringFuncs
    {
        private readonly static CompareInfo invariantCultureCompareInfo = CultureInfo.InvariantCulture.CompareInfo;
        private const CompareOptions aiCompareOptions = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;

        /// <summary>
        /// Determines whether the specified string in parameter <paramref name="text"/> contains the string <paramref name="toFind"/> 
        /// </summary>
        public static bool ContainsAI(this string text, string toFind) =>
            invariantCultureCompareInfo.IndexOf(text, toFind, aiCompareOptions) >= 0;

        /// <summary>
        /// Determines whether the specified string in parameter <paramref name="text"/> starts with the string <paramref name="toFind"/> 
        /// </summary>
        public static bool StartsWithAI(this string text, string toFind) =>
            invariantCultureCompareInfo.IsPrefix(text, toFind, aiCompareOptions);

        /// <summary>
        /// Determines whether the specified string in parameter <paramref name="text"/> ends with the string <paramref name="toFind"/> 
        /// </summary>
        public static bool EndsWithAI(this string text, string toFind) =>
            invariantCultureCompareInfo.IsSuffix(text, toFind, aiCompareOptions);
    }
}
