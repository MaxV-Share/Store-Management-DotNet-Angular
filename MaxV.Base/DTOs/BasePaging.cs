using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Common.Model.DTOs;
using App.Common.Model;

namespace App.Common.Model.DTOs
{

    public class BasePaging<T> : IBasePaging<T>
    {
        public Pagination Pagination { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
    public interface IBasePaging<T>
    {
        public Pagination Pagination { get; set; }
        public IEnumerable<T> Data { get; set; }
    }

}
