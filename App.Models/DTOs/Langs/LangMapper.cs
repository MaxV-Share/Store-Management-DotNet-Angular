using App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTOs.Langs
{
    public static class LangMapper
    {
        public static IQueryable<LangViewModel> ToLangViewModel(this IQueryable<Lang> query)
        {
            return query.Select(x => new LangViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreateAt = x.CreateAt,
                CreateBy = x.CreateBy,
                Order = x.Order,
                UpdateAt = x.UpdateAt,
                UpdateBy = x.UpdateBy,
            });
        }
    }
}
