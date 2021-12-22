using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Models.DTOs.PagingViewModels
{

    public class BasePaging<T>
    {
        private const string _PAGE_NUMBER_BELOW_1 = "Page number cannot be below 1.";
        private const string _PAGE_SIZE_LESS_THAN_1 = "Page size cannot be less than 1.";
        private const string _PAGE_INDEX_OUT_OF_RANGE = "Page index out of range.";
        public int TotalRow { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="_mapper"></param>
        /// <param name="queryable"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task ToPagingAsync<TSource>(IMapper _mapper, IQueryable<TSource> queryable, Expression<Func<TSource, object>> orderBy, int pageIndex, int pageSize)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(pageIndex),
                    actualValue: pageIndex,
                    message: _PAGE_NUMBER_BELOW_1
                );
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(pageSize),
                    actualValue: pageSize,
                    message: _PAGE_SIZE_LESS_THAN_1
                );
            }
            var skip = (pageIndex - 1) * pageSize;
            var data = await queryable.OrderBy(orderBy)
                                   .Skip(skip)
                                   .Take(pageSize)
                                   .ToListAsync();

            TotalRow = await queryable.CountAsync();
            if (TotalRow > 0 && TotalRow <= skip)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(pageSize),
                    actualValue: pageSize,
                    message: _PAGE_INDEX_OUT_OF_RANGE
                );
            }
            PageIndex = pageIndex;
            PageSize = pageSize;
            PageCount = TotalRow > 0 ? (int)Math.Ceiling(TotalRow / (double)pageSize) : 0;
            Data = _mapper.Map<IEnumerable<T>>(data);
        }
    }
}
