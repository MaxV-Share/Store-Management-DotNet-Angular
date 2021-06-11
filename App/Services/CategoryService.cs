using App.Models.DTOs;
using App.Models.DTOs.Paging;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using MaxV.Helper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class CategoryService : BaseService<Category, CategoryCreateRequest, CategoryViewModel, int>, ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        private readonly ILangRepository _langRepository;
        private readonly ICategoryDetailsRepository _categoryDetailsRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ILangRepository langRepository, ICategoryDetailsRepository categoryDetailsRepository) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
            _langRepository = langRepository;
            _categoryDetailsRepository = categoryDetailsRepository;
        }
        public async Task<CategoryViewModel> CreateAsync(CategoryCreateRequest request)
        {
            if (request == null)
                return null;
            var category = new Category();

            var categoryDetails = new List<CategoryDetail>();
            try
            {
                await _categoryRepository.BeginTransactionAsync();

                category = await _categoryRepository.CreateAsync(category);

                foreach (var detail in request.CategoryDetails)
                {
                    var lang = await _langRepository.GetByIdAsync(detail.LangId);
                    categoryDetails.Add(new CategoryDetail()
                    {
                        Category = category,
                        Name = detail.Name,
                        Lang = lang,
                        Description = detail.Description
                    });
                }
                await _categoryDetailsRepository.CreateAsync(categoryDetails);

                await _categoryRepository.CommitTransactionAsync();
                 
                var result = await GetByIdAsync(category.Id);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                await _categoryRepository.RollbackTransactionAsync();
                return null;
            }

        }
        public async Task<int> PutAsync(int id, CategoryViewModel request)
        {
            if (id != request.Id)
                return 0;

            var entity = await _categoryRepository.GetByIdAsync(request.Id);
            if (entity == null)
                return 0;
            var dateTimeNow = DateTime.UtcNow;

            entity.UpdateAt = dateTimeNow;

            var result = await _repository.UpdateAsync(entity);
            return result;
        }
        public override async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdNoTrackingAsync(id);
            category.CategoryDetails = await _categoryDetailsRepository.GetQueryableTable()
                                                                        .Where(e => e.Category.Id == id)
                                                                        .Include(e => e.Lang)
                                                                        .Include(e => e.Category)
                                                                        .OrderBy(e => e.Lang.Order)
                                                                        .ToListAsync();
            var result = _mapper.Map<CategoryViewModel>(category);
            return result;
        }

        public async Task<CategoryDetailPaging> GetPaging(string langId, int pageIndex, int pageSize, string searchText)
        {
            var taskData = _categoryDetailsRepository.GetQueryableTable()
                                                    .Include(e => e.Lang)
                                                    .Include(e => e.Category)
                                                    .Where(e => e.Lang.Id == langId && e.Name.Contains(searchText + ""))
                                                    .OrderBy(e => e.Name)
                                                    .Skip((pageIndex - 1) * pageSize)
                                                    .Take(pageSize)
                                                    .ToListAsync();
            var taskTotalRow = _categoryDetailsRepository.GetQueryableTable()
                                                        .CountAsync(e => e.Lang.Id == langId && e.Name.Contains(searchText + ""));
            var result = new CategoryDetailPaging()
            {
                TotalRow = await taskTotalRow,
                Data = _mapper.Map<IEnumerable<CategoryDetailViewModel>>(await taskData)
            };
            return result;
        }
        public async Task<IEnumerable<CategoryDetailViewModel>> GetAllDTOAsync(string langId)
        {
            var res = await _categoryDetailsRepository.GetQueryableTable()
                                                    .Include(e => e.Lang)
                                                    .Include(e => e.Category)
                                                    .Where(e => e.Lang.Id.Equals(langId) )
                                                    .ToListAsync();
            var result = _mapper.Map<List<CategoryDetailViewModel>>(res);
            return result;
        }
    }
}
