using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class CategoryService : BaseService<Category, CategoryRequest, CategoryNonRequest>, ICategoryService
    {
        public readonly ICategoryRepository _CategoryRepository;
        public CategoryService(ICategoryRepository saleRepository, IMapper mapper) : base(saleRepository, mapper)
        {
            _CategoryRepository = saleRepository;
        }
        public async Task<CategoryNonRequest> PostAsync(CategoryRequest request)
        {
            //if (request == null)
                return null;
            //Category obj = new Category()
            //{
            //    Name = request.Name
            //};
            //var response = await _CategoryRepository.CreateAsync(obj);
            //var result = _mapper.Map<CategoryNonRequest>(response);
            //return result;
        }
        public async Task<int> PutAsync(int id, CategoryNonRequest request)
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
    }
}
