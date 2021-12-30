using App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTOs.CategoryDetails
{
    public static class CategoryDetailMapper
    {
        public static IQueryable<CategoryDetailViewModel> ToCategoryDetailViewModel(this IQueryable<CategoryDetail> query)
        {
            return query.Select(e => new CategoryDetailViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                LangId = e.LangId,
                CategoryId = e.CategoryId,
                CreateAt = e.CreateAt,
                CreateBy = e.CreateBy,
                UpdateAt = e.UpdateAt,
                UpdateBy = e.UpdateBy,
            });
            throw new NotImplementedException();
        }
    }
}
