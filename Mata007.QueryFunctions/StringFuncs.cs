using System;
using System.Globalization;

namespace Mata007.QueryFunctions
{
    /// <summary xml:lang="en">
    /// Functions applicable in LINQ queries to allow accent and case insensitive search in strings
    /// </summary>
    /// <summary xml:lang="cs">
    /// Funkce použitelné v LINQ dotazech, které umožňují v řetezcích vyhledávání bez závislosti na velikosti písmen a interpunkce
    /// </summary>
    public static class StringFuncs
    {
        private readonly static CompareInfo invariantCultureCompareInfo = CultureInfo.InvariantCulture.CompareInfo;
        private const CompareOptions aiCompareOptions = CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace;

        /// <summary xml:lang="en">
        /// Determines whether the specified string in parameter <paramref name="text"/> contains the string <paramref name="toFind"/> 
        /// </summary>
        /// <summary xml:lang="cs">
        /// Funkce zjistí jestli v řetězci v parametru <paramref name="text"/> je obsažen řetězec z parametru <paramref name="toFind"/> 
        /// </summary>
        public static bool ContainsAI(this string text, string toFind) =>
            invariantCultureCompareInfo.IndexOf(text, toFind, aiCompareOptions) >= 0;

        /// <summary xml:lang="en">
        /// Determines whether the specified string in parameter <paramref name="text"/> starts with the string <paramref name="toFind"/> 
        /// </summary>
        /// <summary xml:lang="cs">
        /// Funkce zjistí jestli řetěz v parametru <paramref name="text"/> začíná řetězcem z parametru <paramref name="toFind"/> 
        /// </summary>
        public static bool StartsWithAI(this string text, string toFind) =>
            invariantCultureCompareInfo.IsPrefix(text, toFind, aiCompareOptions);

        /// <summary xml:lang="en">
        /// Determines whether the specified string in parameter <paramref name="text"/> ends with the string <paramref name="toFind"/> 
        /// </summary>
        /// <summary xml:lang="cs">
        /// Funkce zjistí jestli řetěz v parametru <paramref name="text"/> končí řetězcem z parametru <paramref name="toFind"/> 
        /// </summary>
        public static bool EndsWithAI(this string text, string toFind) =>
            invariantCultureCompareInfo.IsSuffix(text, toFind, aiCompareOptions);
    }
}
