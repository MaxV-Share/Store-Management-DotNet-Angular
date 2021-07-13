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
                    categoryDetails.Add(new CategoryDetail()
                    {
                        Category = category,
                        Name = detail.Name,
                        LangId = detail.LangId,
                        Description = detail.Description
                    });
                }
                await _categoryDetailsRepository.CreateAsync(categoryDetails);

                await _categoryRepository.CommitTransactionAsync();

                var result = _mapper.Map<CategoryViewModel>(category);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                await _categoryRepository.RollbackTransactionAsync();
                return null;
            }

        }
        public async Task<int> UpdateAsync(int id, CategoryViewModel request)
        {
            if (id != request.Id)
                return 0;

            var entity = await _categoryRepository.GetByIdAsync(id);
            if (entity == null)
                return 0;

            //entity.ParentId = entity.ParentId;

            for (int i = 0; i < request.categoryDetails.Count; i++)
            {
                entity.CategoryDetails[i].Name = request.categoryDetails[i].Name;
                entity.CategoryDetails[i].Description = request.categoryDetails[i].Description;
            }

            var result = await _repository.UpdateAsync(entity);
            return result;
        }
        public override async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetNoTrackingEntities().Include(e => e.CategoryDetails).ThenInclude(e => e.Lang).SingleOrDefaultAsync(e => e.Id == id);
            var result = _mapper.Map<CategoryViewModel>(category);
            return result;
        }

        public async Task<CategoryDetailPaging> GetPagingAsync(string langId, int pageIndex, int pageSize, string searchText)
        {
            var taskData = _categoryDetailsRepository.GetNoTrackingEntities()
                                                    .Include(e => e.Lang)
                                                    .Include(e => e.Category)
                                                    .Where(e => e.LangId == langId && (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText + "")))
                                                    .OrderBy(e => e.Name)
                                                    .Skip((pageIndex - 1) * pageSize)
                                                    .Take(pageSize)
                                                    .ToListAsync();
            var taskTotalRow = _categoryDetailsRepository.GetQueryableTable()
                                                        .CountAsync(e => e.LangId == langId && (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText + "")));
            var result = new CategoryDetailPaging()
            {
                TotalRow = await taskTotalRow,
                Data = _mapper.Map<IEnumerable<CategoryDetailViewModel>>(await taskData)
            };
            return result;
        }
        public async Task<IEnumerable<CategoryDetailViewModel>> GetAllDTOAsync(string langId, string searchText)
        {
            var res = await _categoryDetailsRepository.GetNoTrackingEntities()
                                                    .Include(e => e.Category)
                                                    .Where(e => e.Lang.Id.Equals(langId) && (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText + "")))
                                                    .ToListAsync();
            var result = _mapper.Map<List<CategoryDetailViewModel>>(res);
            return result;
        }
    }
}
