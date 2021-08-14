using App.Infrastructures.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.Imports;
using App.Models.DTOs.PagingViewModels;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class ProductService : BaseService<Product, ProductCreateRequest, ProductUpdateRequest, ProductViewModel, int>, IProductService
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
            ICategoryRepository categoryRepository, IUnitOffWork unitOffWork, ILogger<ProductService> logger) : base(productRepository, mapper, unitOffWork, logger)
        {
            _productDetailsRepository = productDetailsRepository;
            _storageService = storageService;
            _langRepository = langRepository;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public override async Task<ProductViewModel> CreateAsync(ProductCreateRequest request)
        {
            if (request == null)
                return null;
            var product = new Product();
            var productDetails = new List<ProductDetail>();
            var oldFileName = request.File?.FileName;
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(oldFileName);
            _mapper.Map(request, product);
            try
            {
                Task saveFile = null;
                await _unitOffWork.BeginTransactionAsync();


                if (oldFileName != null)
                {
                    saveFile = _storageService.SaveFileAsync(request.File.OpenReadStream(), newFileName, FOLDER);
                    product.ImageUrl = Path.Combine(FOLDER, newFileName);
                }

                await _repository.CreateAsync(product);

                var effectedCount = await _unitOffWork.SaveChangesAsync();
                if (effectedCount == 0)
                {
                    // TODO: định nghĩa lại exception
                    throw new Exception();
                }
                var result = _mapper.Map<ProductViewModel>(product);
                if (saveFile != null)
                    await saveFile;

                await _unitOffWork.CommitTransactionAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                await _unitOffWork.RollbackTransactionAsync();
                return null;
            }
        }

        public async Task<int> UpdateAsync(int id, ProductViewModel request)
        {
            var dateTimeNow = DateTime.Now;
            var product = await _repository.GetQueryableTable().Include(e => e.ProductDetails).SingleOrDefaultAsync(e => e.Id == id);
            if (product == null)
                return 0;
            var oldFileName = request.File?.FileName;
            var newFileName = Guid.NewGuid().ToString() + Path.GetExtension(oldFileName);
            try
            {
                Task saveFile = null;
                await _unitOffWork.BeginTransactionAsync();

                if (oldFileName != null)
                {
                    saveFile = _storageService.SaveFileAsync(request.File.OpenReadStream(), newFileName, FOLDER);
                    product.ImageUrl = Path.Combine(FOLDER, newFileName);
                }

                product.CategoryId = request.CategoryId;
                product.Price = request.Price;
                product.Code = request.Code;
                for (int i = 0; i < product.ProductDetails.Count; i++)
                {
                    product.ProductDetails[i].Name = request.ProductDetails[i].Name;
                    product.ProductDetails[i].Description = request.ProductDetails[i].Description;
                    product.ProductDetails[i].UpdateAt = dateTimeNow;
                }

                await _repository.UpdateAsync(product);

                var result = await _unitOffWork.SaveChangesAsync();

                if (saveFile != null)
                    await saveFile;

                await _unitOffWork.CommitTransactionAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                await _unitOffWork.RollbackTransactionAsync();
                throw;
            }
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
            catch
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
        public async Task ImportProducts(IFormFile file)
        {
            var stream = new MemoryStream();
            file.CopyTo(stream);
            stream.Position = 0;
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                int i = 0;
                while (reader.Read()) //Each row of the file
                {
                    if (i > 0)
                    {
                        await _unitOffWork.BeginTransactionAsync();

                        var productCode = reader.GetValue(0).ToString();
                        var product = await _repository.GetQueryableTable().SingleOrDefaultAsync(e => e.Code == productCode);
                        // Trường hợp không tồn tại
                        if (product == null)
                        {
                            // Tạo mới product và insert vào
                            product = new Product()
                            {
                                Code = reader.GetValue(0).ToString(),
                                Price = double.Parse(reader.GetValue(1).ToString()),
                                ProductDetails = new List<ProductDetail>()
                            };
                            product.ProductDetails.Add(
                                    new ProductDetail()
                                    {
                                        ProductId = product.Id,
                                        LangId = reader.GetValue(2).ToString(),
                                        Name = reader.GetValue(3).ToString()
                                    });
                            // Gọi hàm insert database 
                            await _repository.CreateAsync(product);
                        }
                        else
                        {
                            // Trường hợp đã tồn tại Product
                            // Update price
                            product.Price = double.Parse(reader.GetValue(1).ToString());
                            // Lấy danh sách chi tiết Product
                            // Tìm ngôn ngữ hiện tại của dòng trong excel đã tồn tại trong detail hay chưa
                            var productDetail = await _productDetailsRepository.GetQueryableTable()
                                                                                .Where(e => e.ProductId == product.Id && e.LangId == reader.GetValue(2).ToString())
                                                                                .SingleOrDefaultAsync();

                            if (productDetail == null)
                            {
                                // Nếu chưa thì tạo mới và insert vào
                                productDetail = new ProductDetail
                                {
                                    ProductId = product.Id,
                                    LangId = reader.GetValue(2).ToString(),
                                    Name = reader.GetValue(3).ToString()
                                };
                                await _productDetailsRepository.CreateAsync(productDetail);
                            }
                            else
                            {
                                // Nếu có thì update lại giá trị
                                productDetail.ProductId = product.Id;
                                productDetail.LangId = reader.GetValue(2).ToString();
                                productDetail.Name = reader.GetValue(3).ToString();
                                await _productDetailsRepository.UpdateAsync(productDetail);
                            }
                            await _repository.UpdateAsync(product);
                        }
                        await _unitOffWork.SaveChangesAsync();

                        await _unitOffWork.CommitTransactionAsync();
                    }
                    i++;
                }
            }
        }
    }
}
