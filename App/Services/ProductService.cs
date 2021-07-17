using App.Models.DTOs;
using App.Models.DTOs.Paging;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class ProductService : BaseService<Product, ProductCreateRequest, ProductViewModel, int>, IProductService
    {
        private const string FOLDER = "Products";
        private readonly ILangRepository _langRepository;
        private readonly IProductDetailRepository _productDetailsRepository;
        private readonly IStorageService _storageService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository productRepository, 
            IMapper mapper, 
            IProductDetailRepository productDetailsRepository,
            IStorageService storageService, 
            ILangRepository langRepository, 
            ILogger<ProductService> logger,
            ICategoryRepository categoryRepository) : base(productRepository, mapper)
        {
            _productDetailsRepository = productDetailsRepository;
            _storageService = storageService;
            _langRepository = langRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<ProductViewModel> CreateAsync(ProductCreateRequest request)
        {
            if (request == null)
                return null;
            var product = new Product();
            var productDetails = new List<ProductDetail>();
            var oldFileName = request.File?.FileName;
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(oldFileName);
            try
            {
                Task saveFile = null;
                await _repository.BeginTransactionAsync();
                if(oldFileName != null)
                {
                    saveFile = _storageService.SaveFileAsync(request.File.OpenReadStream(), newFileName, FOLDER);
                    product.ImageUrl = Path.Combine(FOLDER, newFileName);
                }

                product.CategoryId = request.CategoryId;
                product.Price = request.Price;
                product.Code = request.Code;
                product = await _repository.CreateAsync(product);

                foreach (var detail in request.ProductDetails)
                {
                    productDetails.Add(new ProductDetail()
                    {
                        Product = product,
                        Name = detail.Name,
                        LangId = detail.LangId,
                        Description = detail.Description,

                    });
                }
                await _productDetailsRepository.CreateAsync(productDetails);

                await _repository.CommitTransactionAsync();
                var result = await GetByIdAsync(product.Id);
                if(saveFile != null)
                    await saveFile;

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                await _repository.RollbackTransactionAsync();
                return null;
            }
        }

        public async Task<int> UpdateAsync(int id, ProductViewModel request)
        {
            var dateTimeNow = DateTime.Now;
            var product = await _repository.GetQueryableTable().Include(e => e.ProductDetails).SingleOrDefaultAsync(e => e.Id == request.Id.Value);
            if (product == null)
                return 0;
            var oldFileName = request.File?.FileName;
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(oldFileName);
            try
            {
                Task saveFile = null;
                await _repository.BeginTransactionAsync();

                if (oldFileName != null)
                {
                    saveFile = _storageService.SaveFileAsync(request.File.OpenReadStream(), newFileName, FOLDER);
                    product.ImageUrl = Path.Combine(FOLDER, newFileName);
                }

                product.CategoryId = request.CategoryId;
                product.Price = request.Price;
                product.Code = request.Code;
                for(int i =0; i < product.ProductDetails.Count; i++)
                {
                    product.ProductDetails[i].Name = request.ProductDetails[i].Name;
                    product.ProductDetails[i].Description = request.ProductDetails[i].Description;
                    product.ProductDetails[i].UpdateAt = dateTimeNow;
                }

                await _repository.UpdateAsync(product);
                if (saveFile != null)
                    await saveFile;

                await _repository.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _repository.RollbackTransactionAsync();
                throw;
            }
            return 0;
        }

        public override async Task<ProductViewModel> GetByIdAsync(int id)
        {
            try
            {
                var product = await _repository.GetNoTrackingEntitiesIdentityResolution().Include(e => e.ProductDetails).ThenInclude(e => e.Lang).SingleOrDefaultAsync(e => e.Id == id);
                product.ProductDetails = product.ProductDetails.OrderBy(e => e.Lang.Order).ToList();
                if (product == null)
                    return null;

                var result = _mapper.Map<ProductViewModel>(product);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ProductDetailPaging> GetPagingAsync(string langId, int pageIndex, int pageSize, string searchText)
        {
            var taskData = _productDetailsRepository.GetQueryableTable()
                                                    .Include(e => e.Lang)
                                                    .Include(e => e.Product)
                                                    .Where(e => e.LangId == langId && (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText) || e.Product.Code.Contains(searchText)))
                                                    .OrderBy(e => e.Name)
                                                    .Skip((pageIndex - 1) * pageSize)
                                                    .Take(pageSize)
                                                    .ToListAsync();

            var taskTotalRow = _productDetailsRepository.GetQueryableTable()
                                                        .CountAsync(e => e.Lang.Id == langId && (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText)));

            var result = new ProductDetailPaging
            {
                TotalRow = await taskTotalRow,
                Data = _mapper.Map<IEnumerable<ProductDetailViewModel>>(await taskData)
            };

            return result;
        }
        public async Task<IEnumerable<ProductDetailViewModel>> GetAllDTOAsync(string langId, string searchText)
        {
            var res = await _productDetailsRepository.GetQueryableTable()
                                                    .Include(e => e.Lang)
                                                    .Include(e => e.Product)
                                                    .Where(e =>
                                                        e.Lang.Id.Equals(langId) &&
                                                        (string.IsNullOrEmpty(searchText) || e.Name.Contains(searchText) || e.Product.Code.Contains(searchText)))
                                                    .ToListAsync();
            
            var result = _mapper.Map<IEnumerable<ProductDetailViewModel>>(res);
            return result;
        }
    }
}
