using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.DTOs.Categories;
using App.Models.DTOs.CategoryDetails;
using App.EFCore;
using App.Common.Model.DTOs;
using App.Common.Model;
using App.Common.Extensions;
using System.Net.Http;

namespace App.Services
{
    public class CategoryService : BaseService<Category, CategoryCreateRequest, CategoryUpdateRequest, CategoryViewModel, int>, ICategoryService
    {

        public CategoryService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<CategoryService> logger) : base(mapper, unitOffWork, logger)
        {
        }
        public override async Task<CategoryViewModel> CreateAsync(CategoryCreateRequest request)
        {
            if (request == null)
                return null;

            CategoryViewModel result = null;
            await _unitOffWork.DoWorkWithTransaction(async () =>
            {
                var entity = _mapper.Map<Category>(request);

                var countAffect = await _unitOffWork.Repository<Category, int>().CreateAsync(entity);
                if (countAffect == 0)
                {
                    result = null;
                }

                result = _mapper.Map<CategoryViewModel>(entity);
            });

            return result;

        }
        public override async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _unitOffWork.Repository<Category, int>().GetByIdNoTrackingAsync(id, e => e.CategoryDetails.OrderBy(e => e.Lang.Order));
            var result = _mapper.Map<CategoryViewModel>(category);
            return result;
        }
        public async Task<IBasePaging<CategoryDetailViewModel>> GetPagingAsync(IFilterBodyRequest request)
        {
            var query = _mapper.ProjectTo<CategoryDetailViewModel>(_unitOffWork.Repository<CategoryDetail, int>().GetNoTrackingEntities(e => e.Category));

            if (!request.LangId.IsNullOrEmpty())
            {
                query = query.Where(e => e.LangId.ToLower().Equals(request.LangId.ToLower()));
            }

            if (!request.SearchValue.IsNullOrEmpty())
            {
                query = query.Where(e => e.Name.Contains(request.SearchValue));
            }

            return await query.ToPagingAsync(request);
        }
    }
}
