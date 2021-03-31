using System;

namespace Mata007.QueryFunctions
{
    /// <summary>
    /// Funkce použitelné LINQ dotazech
    /// </summary>
    public static class StringFuncs
    {
        private static Exception ShouldBeTranslatedException =>
            new Exception("Should be translated to SQL");

        /// <summary>
        /// Zjistí jestli řetězec <paramref name="text"/> obsahuje řetězec <paramref name="toFind"/> 
        /// </summary>
        public static bool ContainsAI(this string text, string toFind) =>
            throw ShouldBeTranslatedException;

        /// <summary>
        /// Zjistí jestli řetězec <paramref name="text"/> začíná řetězecem <paramref name="toFind"/> 
        /// </summary>
        public static bool StartsWithAI(this string text, string toFind) =>
            throw ShouldBeTranslatedException;

        /// <summary>
        /// Zjistí jestli řetězec <paramref name="text"/> končí řetězecem <paramref name="toFind"/> 
        /// </summary>
        public static bool EndsWithAI(this string text, string toFind) =>
            throw ShouldBeTranslatedException;
    }
}
