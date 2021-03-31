using Microsoft.OData.Client;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mata007.QueryFunctions.OData.Client
{
    public static class RegisterODataFunctions
    {
        private static Dictionary<MethodInfo, string> expressionMethodMap;
        static RegisterODataFunctions()
        {
            var assembly = typeof(DataServiceContext).Assembly;
            var typeSystem = assembly.GetType("Microsoft.OData.Client.TypeSystem");
            expressionMethodMap = typeSystem.GetField("expressionMethodMap", BindingFlags.Static | BindingFlags.NonPublic)?.GetValue(null) as Dictionary<MethodInfo, string>;
        }

        public static void RegisterCustomFunction(Type type, string functionName)
        {
            var methodInfo = type.GetMethod(functionName);
            expressionMethodMap.Add(methodInfo, functionName.ToLower());            
        }
    }
}
