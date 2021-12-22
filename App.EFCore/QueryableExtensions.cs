using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxV.Common.Model.Enums;
using MaxV.Common.Model;
using App.Common.Extensions;

namespace App.EFCore
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> source, FilterRequest filter) where T : class
        {
            if (filter == null || filter.Details.IsNullOrEmpty())
            {
                return source;
            }
            var fields = typeof(T).GetProperties();
            var filters = filter.Details.Where(d => fields.Any(f => string.Equals(d.AttributeName, f.Name, StringComparison.OrdinalIgnoreCase))).Select(e => new FilterDescriptor()
            {
                Field = e.AttributeName,
                Values = e.FilterType == FilterType.In ? e.Value.Split("|") : new string[] { e.Value },
                LogicalOperator = filter.LogicalOperator,
                Operator = e.FilterType,
            }).ToList();
            return source.Where(ExpressionBuilder.Build<T>(filters));
        }
    }
}
