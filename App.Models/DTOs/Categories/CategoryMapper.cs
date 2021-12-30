using App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTOs.Categories
{
    public static class CategoryMapper
    {
        public static IQueryable<CategoryViewModel> ToCategoryViewModel(this IQueryable<Category> query)
        {
            return query.Select(x => new CategoryViewModel()
            {

            });
        }
    }
}
