using AutoMapper;
using MaxV.Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Models.DTOs.PagingViewModels
{

    public class BasePaging<T> : IBasePaging<T>
    {
        public int TotalRow { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
    public interface IBasePaging<T>
    {
        public int TotalRow { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Data { get; set; }
    }

}
