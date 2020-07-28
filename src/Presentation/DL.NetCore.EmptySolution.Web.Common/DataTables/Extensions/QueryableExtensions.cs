using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace DL.NetCore.EmptySolution.Web.Common.DataTables.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, IEnumerable<IColumn> columns)
        {
            Expression expression = source.Expression;
            bool firstTime = true;

            var sortedColumns = columns
                .Where(x => x.IsSortable && x.Sort != null)
                .OrderBy(x => x.Sort.Order);

            foreach (var sortedColumn in sortedColumns)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, sortedColumn.Field);
                var lambda = Expression.Lambda(selector, parameter);
                var method = sortedColumn.Sort.Direction == SortDirection.Descending
                    ? firstTime ? "OrderByDescending" : "ThenByDescending"
                    : firstTime ? "OrderBy" : "ThenBy";

                expression = Expression.Call(
                    typeof(Queryable), 
                    method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, 
                    Expression.Quote(lambda)
                );

                firstTime = false;
            }
            return firstTime 
                ? source
                : source.Provider.CreateQuery<T>(expression);
        }

        public static IQueryable<T> GlobalFilterBy<T>(this IQueryable<T> source, ISearch search, IEnumerable<IColumn> columns)
        {
            if (search == null || String.IsNullOrWhiteSpace(search.Value))
            {
                return source;
            }

            var searchableColumns = columns
                .Where(x => x.IsSearchable);
            if (!searchableColumns.Any())
            {
                return source;
            }

            Expression predicateBody = null;
            var parameter = Expression.Parameter(typeof(T), "x");

            foreach (var column in searchableColumns)
            {
                // We want to build
                //  x.Field != default 
                //  && x.Field.ToString().IndexOf(search.Value, StringComparison.InvariantCultureIgnoreCase) >= 0
                // for each searchable column
                var selector = Expression.PropertyOrField(parameter, column.Field);

                var left = Expression.NotEqual(
                    selector,
                    Expression.Default(selector.Type)
                );

                var toString = Expression.Call(
                    selector,
                    selector.Type.GetMethod("ToString", System.Type.EmptyTypes)
                );

                var indexOf = Expression.Call(
                    toString,
                    typeof(string).GetMethod("IndexOf", new Type[] { typeof(string), typeof(StringComparison) }),
                    Expression.Constant(search.Value),
                    Expression.Constant(StringComparison.InvariantCultureIgnoreCase)
                );

                var right = Expression.GreaterThanOrEqual(
                    indexOf,
                    Expression.Constant(0)
                );

                var andExpression = Expression.AndAlso(left, right);

                predicateBody = predicateBody == null
                    ? andExpression
                    : Expression.OrElse(predicateBody, andExpression);
            }

            if (predicateBody == null)
            {
                return source;
            }

            var lambda = Expression.Lambda<Func<T, bool>>(predicateBody, parameter);

            var whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { source.ElementType },
                source.Expression,
                lambda
            );

            return source.Provider.CreateQuery<T>(whereCallExpression);
        }
    }
}
