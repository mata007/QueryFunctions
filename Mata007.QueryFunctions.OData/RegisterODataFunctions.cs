using Microsoft.AspNet.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using System;
using System.Linq;

namespace Mata007.QueryFunctions.OData
{
    public class RegisterODataFunctions
    {
        public static void RegisterCustomFunction(Type type, string functionName)
        {
            var methodInfo = type.GetMethod(functionName)!;
            var returnType = TypeToReference(methodInfo.ReturnType);
            var args = methodInfo.GetParameters()
                .Select(x => TypeToReference(x.ParameterType))
                .ToArray();
            var signature = new FunctionSignatureWithReturnType(returnType, args);
            ODataUriFunctions.AddCustomUriFunction(functionName.ToLower(), signature, methodInfo);
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
