namespace Mata007.QueryFunctions.OData
{
    public class RegisterQueryFunctions
    {
        public static void RegisterStringFuncs()
        {
            var stringFuncs = typeof(StringFuncs);
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs.GetMethod(nameof(StringFuncs.ContainsAI)));
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs.GetMethod(nameof(StringFuncs.StartsWithAI)));
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs.GetMethod(nameof(StringFuncs.EndsWithAI)));
        }
    }
}
