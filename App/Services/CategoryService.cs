using App.Infrastructures.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.PagingViewModels;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using MaxV.Helper.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class CategoryService : BaseService<Category, CategoryCreateRequest, CategoryUpdateRequest, CategoryViewModel, int>, ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        private readonly ILangRepository _langRepository;
        private readonly ICategoryDetailsRepository _categoryDetailsRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILangRepository langRepository, ICategoryDetailsRepository categoryDetailsRepository, IUnitOffWork unitOffWork, ILogger<CategoryService> logger) : base(categoryRepository, mapper, unitOffWork, logger)
        {
            _categoryRepository = categoryRepository;
            _langRepository = langRepository;
            _categoryDetailsRepository = categoryDetailsRepository;
        }
        //public async Task<CategoryViewModel> CreateAsync(CategoryCreateRequest request)
        //{
        //    if (request == null)
        //        return null;

        //    var entity = new Category();
        //    var categoryDetails = new List<CategoryDetail>();

        //    try
        //    {
        //        await _unitOffWork.BeginTransactionAsync();

        //        entity = _mapper.Map(request, entity);

        //        entity = await _categoryRepository.CreateAsync(entity);

        //        await _unitOffWork.SaveChangesAsync();

        //        await _unitOffWork.CommitTransactionAsync();

        //        var result = _mapper.Map<CategoryViewModel>(entity);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.StackTrace);
        //        await _unitOffWork.RollbackTransactionAsync();
        //        return null;
        //    }

        //}
        public override async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetNoTrackingEntities()
                                                    .Include(e => e.CategoryDetails)
                                                    .ThenInclude(e => e.Lang)
                                                    .SingleOrDefaultAsync(e => e.Id == id);
            var result = _mapper.Map<CategoryViewModel>(category);
            return result;
        }

        public async Task<CategoryDetailPaging> GetDetailsPagingAsync(string langId, int pageIndex, int pageSize, string searchText)
        {
            var query = _categoryDetailsRepository.GetNoTrackingEntities()
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
            var res = await _categoryDetailsRepository.GetNoTrackingEntities()
                                                    .Include(e => e.Category)
                                                    .Where(e => e.LangId.Equals(langId) && (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText + "")))
                                                    .ToListAsync();
            var result = _mapper.Map<List<CategoryDetailViewModel>>(res);
            return result;
        }
    }
}
