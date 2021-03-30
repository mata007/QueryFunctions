﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq;

namespace Mata007.QueryFunctions.SqlServer
{
    public class RegisterQueryFunctionsToSqlServerContext
    {
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
