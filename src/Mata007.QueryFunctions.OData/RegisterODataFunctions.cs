using Microsoft.AspNet.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using System;
using System.Linq;
using System.Reflection;

namespace Mata007.QueryFunctions.OData
{
    /// <summary xml:lang="en">
    /// Registering other custom method to the OData query parser
    /// </summary>
    /// <summary xml:lang="cs">
    /// Registrace dodatečnách vlastních metod do OData query parseru
    /// </summary>
    public class RegisterODataFunctions
    {
        /// <summary xml:lang="en">
        /// Registering other custom method to the OData query parser
        /// </summary>
        /// <summary xml:lang="cs">
        /// Registrace dodatečné vlastní metody do OData query parseru
        /// </summary>        
        public static void RegisterCustomFunction(MethodInfo methodInfo, string functionName = null)
        {
            var returnType = TypeToReference(methodInfo.ReturnType);
            var args = methodInfo.GetParameters()
                .Select(x => TypeToReference(x.ParameterType))
                .ToArray();
            var signature = new FunctionSignatureWithReturnType(returnType, args);
            ODataUriFunctions.AddCustomUriFunction(functionName ?? methodInfo.Name.ToLower(), signature, methodInfo);
        }

        private static IEdmTypeReference TypeToReference(Type type)
        {
            var primitiveTypeKind = EdmCoreModel.Instance.GetPrimitiveTypeKind(type.Name);
            var isNullable = type.IsClass || Nullable.GetUnderlyingType(type) != null;
            return new EdmPrimitiveTypeReference(
                EdmCoreModel.Instance.GetPrimitiveType(primitiveTypeKind),
                isNullable);
        }
    }
}
