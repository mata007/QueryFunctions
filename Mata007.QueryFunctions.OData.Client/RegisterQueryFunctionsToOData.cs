namespace Mata007.QueryFunctions.OData.Client
{
    public class RegisterQueryFunctionsToODataClient
    {
        public static void RegisterStringFuncs()
        {
            var stringFuncs = typeof(StringFuncs);
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs, nameof(StringFuncs.ContainsAI));
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs, nameof(StringFuncs.StartsWithAI));
            RegisterODataFunctions.RegisterCustomFunction(stringFuncs, nameof(StringFuncs.EndsWithAI));
        }
    }
}
