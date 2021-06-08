using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
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
    public class ProductService : BaseService<Product, ProductCreateRequest, ProductViewModel, int>, IProductService
    {
        private readonly ILangRepository _langRepository;
        private readonly IProductDetailRepository _productDetailsRepository;
        private readonly IStorageService _storageService;
        public ProductService(IProductRepository productRepository, IMapper mapper, IProductDetailRepository productDetailsRepository, IStorageService storageService, ILangRepository langRepository) : base(productRepository, mapper)
        {
            _productDetailsRepository = productDetailsRepository;
            _storageService = storageService;
            _langRepository = langRepository;
        }
        public async Task CreateProductAsync(ProductCreateRequest request)
        {
            // Method intentionally left empty.
            await _storageService.SaveFileAsync(request.File.OpenReadStream(), request.File.FileName);
        }
    }
}
