using App.Models.DTOs;
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
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class CategoriesService : BaseService<Category, CategoryCR, CategoryVm, int>, ICategoriesService
    {
        public readonly ICategoriesRepository _categoryRepository;
        private readonly ILangRepository _langRepository;
        private readonly ICategoryDetailsRepository _categoryDetailsRepository;
        public CategoriesService(ICategoriesRepository saleRepository, IMapper mapper, ILangRepository langRepository, ICategoryDetailsRepository categoryDetailsRepository) : base(saleRepository, mapper)
        {
            _categoryRepository = saleRepository;
            _langRepository = langRepository;
            _categoryDetailsRepository = categoryDetailsRepository;
        }
        public async Task<CategoryVm> CreateAsync(CategoryCR request)
        {
            var result = new CategoryVm();
            if (request == null)
                return null;
            try
            {
                var category = new Category();

                var categoryDetails = new List<CategoryDetail>();

                await _categoryRepository.BeginTransactionAsync();

                category = await _categoryRepository.CreateAsync(category);
                //throw new Exception();
                foreach (var detail in request.CategoryDetails)
                {
                    var lang = await _langRepository.GetByIdAsync(detail.LangId);
                    categoryDetails.Add(new CategoryDetail()
                    {
                        Category = category,
                        Name = detail.Name,
                        Lang = lang
                    });
                }
                await _categoryDetailsRepository.CreateAsync(categoryDetails);

                await _categoryRepository.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _categoryRepository.RollbackTransactionAsync();
            }
            //Category obj = new Category()
            //{
            //    Name = request.Name
            //};
            //var response = await _CategoryRepository.CreateAsync(obj);
            //var result = _mapper.Map<CategoryNonRequest>(response);
            return result;
        }
        public async Task<int> PutAsync(int id, CategoryVm request)
        {
            //if (id != request.Id)
            //    return 0;

            //var entity = await _CategoryRepository.GetByIdAsync(request.Id);
            //if (entity == null)
            //    return 0;
            //var dateTimeNow = DateTime.UtcNow;

            //entity.Parent = request.Name;
            //entity.UpdateAt = dateTimeNow;

            //var result = await _repository.UpdateAsync(entity);
            //return result;
            return 0;
        }
        public override async Task<CategoryVm> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdNoTrackingAsync(id);
            category.CategoryDetails = await _categoryDetailsRepository.GetQueryableTable()
                                                                        .Include(e => e.Lang)
                                                                        .Where(e => e.Category.Id == id)
                                                                        .OrderBy(e => e.Lang.Order)
                                                                        .ToListAsync();
            var result = _mapper.Map<CategoryVm>(category);
            return result;
        }

        public async Task<List<CategoryDetailVm>> GetPaging(string langId, int pageIndex, int pageSize, string searchText)
        {
            var res = await _categoryDetailsRepository.GetQueryableTable()
                                                    .Include(e => e.Lang)
                                                    .Include(e => e.Category)
                                                    .Where(e => e.Lang.Id == langId && e.Name.Contains(searchText + ""))
                                                    .Skip((pageIndex - 1) * pageSize)
                                                    .Take(pageSize)
                                                    .ToListAsync();
            var result = _mapper.Map<List<CategoryDetailVm>>(res);
            return result;
        }
    }
}
