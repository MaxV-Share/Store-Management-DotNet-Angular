using App.Models.DTOs;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequest;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class BillService : BaseService<Bill, BillCreateRequest, BillViewModel, int>, IBillService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBillDetailRepository _billDetailRepository;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<BillService> _logger;
        public BillService(IBillRepository repository,
            ILogger<BillService> logger,
            IMapper mapper,
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            UserManager<User> userManager,
            IProductRepository productRepository,
            IBillDetailRepository billDetailRepository) : base(repository, mapper)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _productRepository = productRepository;
            _billDetailRepository = billDetailRepository;
        }

        public async Task<BillViewModel> CreateAsync(BillCreateRequest request)
        {
            try
            {
                await _repository.BeginTransactionAsync();

                var tUserPayment = _userManager.FindByNameAsync(request.UserPaymentUserName);
                var customer = await _customerRepository.GetByPhoneNumberAsync(request.CustomerPhoneNumber);
                if (customer == null && string.IsNullOrEmpty(request.CustomerPhoneNumber))
                {
                    customer = new Customer()
                    {
                        PhoneNumber = request.CustomerPhoneNumber,
                        FullName = request.CustomerFullName,
                        Address = request.CustomerAddress,
                        Birthday = request.CustomerBirthday,
                    };
                    await _customerRepository.CreateAsync(customer);
                }

                var billDetails = new List<BillDetail>();
                foreach (var detail in request.BillDetails)
                {
                    var product = _productRepository.GetByIdAsync(detail.ProductId);
                    billDetails.Add(new BillDetail()
                    {
                        ProductId = detail.ProductId,
                        Price = detail.Price,
                        Quantity = detail.Quantity,
                        DiscountPrice = detail.DiscountPrice,
                    });
                }

                var userPayment = await tUserPayment;
                var bill = new Bill()
                {
                    Customer = customer,
                    DiscountPrice = request.DiscountPrice,
                    TotalPrice = request.TotalPrice,
                    UserPaymentId = userPayment?.Id,
                    BillDetails = billDetails
                };

                await _repository.CreateAsync(bill);

                await _repository.CommitTransactionAsync();

                return _mapper.Map<BillViewModel>(bill);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                await _repository.RollbackTransactionAsync();
                return null;
            }
        }
        public async Task<int> UpdateAsync(int id, BillViewModel request)
        {
            try
            {
                await _repository.BeginTransactionAsync();

                var tUserPayment = _userManager.FindByNameAsync(request.UserPaymentUserName);
                var customer = await _customerRepository.GetByPhoneNumberAsync(request.CustomerPhoneNumber);

                if (customer == null && !string.IsNullOrEmpty(request.CustomerPhoneNumber))
                {
                    customer = new Customer()
                    {
                        PhoneNumber = request.CustomerPhoneNumber,
                        FullName = request.CustomerFullName,
                        Address = request.CustomerAddress,
                        Birthday = request.CustomerBirthday,
                    };
                    await _customerRepository.CreateAsync(customer);
                }

                var billDetailsNew = new List<BillDetail>();
                request.billDetails.Where(e => e.Id == null).ToList().ForEach(e => {
                    billDetailsNew.Add(new BillDetail()
                    {
                        Price = e.Price,
                        ProductId = e.ProductId,
                        Quantity = e.Quantity,
                        DiscountPrice = e.DiscountPrice,
                        BillId = request.Id.Value,
                    });
                });

                var saveNewBillDetail = _billDetailRepository.CreateAsync(billDetailsNew);

                var bill = await _repository.GetQueryableTable()
                                            .Include(e => e.BillDetails.OrderBy(e => e.Id))
                                            .SingleOrDefaultAsync(e => e.Id.Equals(id) && e.Deleted == null);

                var billDetailsOld = request.billDetails.Where(e => e.Id != 0 || e.Id != null).OrderBy(e => e.Id).ToList();

                bill.DiscountPrice = request.DiscountPrice;
                bill.TotalPrice = request.TotalPrice;
                bill.UserPaymentId = (await tUserPayment)?.Id;
                if(customer != null)
                {
                    bill.CustomerId = customer.Id;
                }

                int i = 0;
                foreach(var detail in bill.BillDetails)
                {
                    detail.Price = billDetailsOld[i].Price;
                    detail.Quantity = billDetailsOld[i].Quantity;
                    i++;
                }
                await _repository.UpdateAsync(bill);

                await _repository.CommitTransactionAsync();

                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("object error", request);
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                await _repository.RollbackTransactionAsync();
                throw;
            }
        }

        public override async Task<BillViewModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetNoTrackingEntities()
                                        .Include(e => e.Customer)
                                        .Include(e => e.UserPayment)
                                        .Include(e => e.BillDetails.OrderBy(e => e.Id))
                                        .SingleOrDefaultAsync(e => e.Id.Equals(id) && e.Deleted == null);
            var result = _mapper.Map<BillViewModel>(entity);
            return result;
        }

        public override async Task<IEnumerable<BillViewModel>> GetAllDTOAsync()
        {
            var entities = await _repository.GetQueryableTable()
                                            .Include(e => e.Customer)
                                            .Include(e => e.UserPayment)
                                            .Where(e => e.Deleted == null)
                                            .ToListAsync();
            var result = _mapper.Map<IEnumerable<BillViewModel>>(entities);
            return result;
        }
        public async Task<IEnumerable<BillViewModel>> GetPaging(int pageIndex, int pageSize)
        {
            var entities = await _repository.GetNoTrackingEntities()
                                            .Include(e => e.Customer)
                                            .Include(e => e.UserPayment)
                                            .Where(e => e.Deleted == null)
                                            .OrderBy(e => e.CreateAt)
                                            .Skip((pageIndex - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToListAsync();
            var result = _mapper.Map<List<BillViewModel>>(entities);
            return result;
        }
    }
}
