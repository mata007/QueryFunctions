using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;

namespace Mata007.QueryFunctions.SqlServer
{
    /// <summary xml:lang="en">
    /// Registration of additional methods into Entity Framework
    /// </summary>
    /// <summary xml:lang="cs">
    /// Registrace dodatečnách metod do Entity Frameworku
    /// </summary>
    public class RegisterQueryFunctionsToSqlServerContext
    {
        /// <summary xml:lang="en">
        /// Registering case and accent insensitive string search methods into Entity Framework
        /// </summary>
        /// <summary xml:lang="cs">
        /// Registrace metod pro vyhladávání v řetězcích bez ohledu na velikost písmen a interpunkci do Entity Frameworku
        /// </summary>
        public static void RegisterStringFuncs(ModelBuilder modelBuilder)
        {
            registerContainsAI(modelBuilder);
            registerStartsWithAI(modelBuilder);
            registerEndsWithAI(modelBuilder);
        }

        private static void registerContainsAI(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(StringFuncs).GetMethod(nameof(StringFuncs.ContainsAI)))
                .HasTranslation(e => new LikeExpression(
                    new CollateExpression(e.First(), "latin1_general_ci_ai"),
                    new CollateExpression(
                        SqlFunctionExpression.Create("CONCAT",
                            new SqlExpression[] {
                                new SqlFragmentExpression("'%'"),
                                e.Skip(1).First(),
                                new SqlFragmentExpression("'%'")
                            }, typeof(string), null),
                            "latin1_general_ci_ai"),
                    new SqlFragmentExpression("'\\'"),
                    null
                    )
                );
        }

        private static void registerStartsWithAI(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(StringFuncs).GetMethod(nameof(StringFuncs.StartsWithAI)))
                .HasTranslation(e => new LikeExpression(
                    new CollateExpression(e.First(), "latin1_general_ci_ai"),
                    new CollateExpression(
                        SqlFunctionExpression.Create("CONCAT",
                            new SqlExpression[] {
                                e.Skip(1).First(),
                                new SqlFragmentExpression("'%'")
                            }, typeof(string), null),
                            "latin1_general_ci_ai"),
                    new SqlFragmentExpression("'\\'"),
                    null
                    )
                );
        }

        private static void registerEndsWithAI(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(StringFuncs).GetMethod(nameof(StringFuncs.EndsWithAI)))
                .HasTranslation(e => new LikeExpression(
                    new CollateExpression(e.First(), "latin1_general_ci_ai"),
                    new CollateExpression(
                        SqlFunctionExpression.Create("CONCAT",
                            new SqlExpression[] {
                                new SqlFragmentExpression("'%'"),
                                e.Skip(1).First()
                            }, typeof(string), null),
                            "latin1_general_ci_ai"),
                    new SqlFragmentExpression("'\\'"),
                    null
                    )
                );
        }
    }
}
