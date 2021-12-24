using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.PagingViewModels;
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

            var entity = new Category();
            var categoryDetails = new List<CategoryDetail>();
            CategoryViewModel result = null;
            await _unitOffWork.DoWorkWithTransaction(async () =>
            {
                entity = _mapper.Map(request, entity);

                await _unitOffWork.Repository<Category, int>().CreateAsync(entity);

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

        public async Task<CategoryDetailPaging> GetPagingAsync(string langId, int pageIndex, int pageSize, string searchText)
        {
            var query = _unitOffWork.CategoryDetailRepository.GetNoTrackingEntities()
                                                    .Include(e => e.Lang)
                                                    .Include(e => e.Category)
                                                    .Where(e => e.LangId == langId && (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText + "")));
            var result = new CategoryDetailPaging();
            await result.ToPagingAsync(_mapper, query, x => x.Name, pageIndex, pageSize);
            return result;
        }

        //public async Task<CategoryPaging> GetPagingWithMultilangAsync(int pageIndex, int pageSize, string searchText)
        //{
        //    var query = _categoryRepository.GetNoTrackingEntities()
        //                                            .Include(e => e.CategoryDetails)
        //                                            .Where(e => string.IsNullOrEmpty(searchText) || !e.CategoryDetails.Where(ee => ee.Name.Contains(searchText)).Any());

        //    var result = new CategoryPaging();
        //    await result.ToPagingAsync(_mapper, query, e => e.Id, pageIndex, pageSize);

        //    return result;
        //}

        public async Task<IEnumerable<CategoryDetailViewModel>> GetAllDTOAsync(string langId, string searchText)
        {
            var res = await _unitOffWork.CategoryDetailRepository.GetNoTrackingEntities()
                                                    .Include(e => e.Category)
                                                    .Where(e => e.LangId.Equals(langId) && (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText + "")))
                                                    .ToListAsync();
            var result = _mapper.Map<List<CategoryDetailViewModel>>(res);
            return result;
        }
    }
}
