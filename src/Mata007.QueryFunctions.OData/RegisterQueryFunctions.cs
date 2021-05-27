namespace Mata007.QueryFunctions.OData
{
    /// <summary xml:lang="en">
    /// Registration of additional methods into OData query parser
    /// </summary>
    /// <summary xml:lang="cs">
    /// Registrace dodatečnách metod do OData query parseru
    /// </summary>
    public class RegisterQueryFunctions
    {
        /// <summary xml:lang="en">
        /// Registering case and accent insensitive string search methods into OData query parser
        /// </summary>
        /// <summary xml:lang="cs">
        /// Registrace metod pro vyhladávání v řetězcích bez ohledu na velikost písmen a interpunkci do OData query parseru
        /// </summary>
        public static void RegisterStringFuncs()
        {
            var stringFuncs = typeof(StringFuncs);
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs.GetMethod(nameof(StringFuncs.ContainsAI)));
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs.GetMethod(nameof(StringFuncs.StartsWithAI)));
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs.GetMethod(nameof(StringFuncs.EndsWithAI)));
        }
    }
}
