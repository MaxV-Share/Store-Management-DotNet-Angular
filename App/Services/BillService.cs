using App.Infrastructures.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.PagingViewModels;
using App.Models.Entities;
using App.Models.Entities.Identities;
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
    public class BillService : BaseService<Bill, BillCreateRequest,  BillUpdateRequest, BillViewModel, int>, IBillService
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
            IBillDetailRepository billDetailRepository, IUnitOffWork unitOffWork) : base(repository, mapper, unitOffWork)
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
            var dateTimeNow = DateTime.Now;
            try
            {
                await _unitOffWork.BeginTransactionAsync();

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
                    await _unitOffWork.SaveChangesAsync();
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
                        CreateAt = dateTimeNow,
                    });
                }

                var userPayment = await tUserPayment;
                var bill = new Bill()
                {
                    Customer = customer,
                    DiscountPrice = request.DiscountPrice,
                    TotalPrice = request.TotalPrice,
                    PaymentAmount = request.PaymentAmount,
                    UserPaymentId = userPayment?.Id,
                    BillDetails = billDetails
                };

                await _repository.CreateAsync(bill);

                var effectedCount = await _unitOffWork.SaveChangesAsync();
                if (effectedCount == 0)
                {   
                    //ToDo: Định nghĩa lại exceptionm
                    throw new Exception();
                }

                var result = _mapper.Map<BillViewModel>(bill);

                await _unitOffWork.CommitTransactionAsync();

                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                await _unitOffWork.RollbackTransactionAsync();
                return null;
            }
        }
        public async Task<int> UpdateAsync(int id, BillViewModel request)
        {
            try
            {
                await _unitOffWork.BeginTransactionAsync();

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
                    await _unitOffWork.SaveChangesAsync();
                }

                var bill = await _repository.GetQueryableTable()
                                            .Include(e => e.BillDetails)
                                            .SingleOrDefaultAsync(e => e.Id.Equals(id));

                bill.DiscountPrice = request.DiscountPrice;
                bill.TotalPrice = request.TotalPrice;
                bill.PaymentAmount = request.PaymentAmount;
                bill.UserPaymentId = (await tUserPayment)?.Id;
                if (customer != null)
                {
                    bill.CustomerId = customer.Id;
                }
                var oldDetailsId = request.billDetails.Select(e => e.Id);
                List<Task> tDeleteDetails = new List<Task>();
                foreach (var detail in bill.BillDetails)
                {
                    if (!request.billDetails.Any(e => e.Id == detail.Id))
                    {
                        tDeleteDetails.Add(_billDetailRepository.DeleteSoftAsync(detail.Id));
                    }
                }

                var billDetailsNew = new List<BillDetail>();
                request.billDetails.ForEach(async e =>
                {

                    var billDetail = new BillDetail();

                    if (e.Id == null) //new BillDetail
                    {
                        billDetail = new BillDetail()
                        {
                            Price = e.Price,
                            ProductId = e.ProductId,
                            Quantity = e.Quantity,
                            DiscountPrice = e.DiscountPrice,
                            BillId = request.Id,
                        };
                    }
                    else // update BillDetail
                    {
                        billDetail = await _billDetailRepository.GetByIdAsync(e.Id);
                        billDetail.Price = e.Price;
                        billDetail.ProductId = e.ProductId;
                        billDetail.Quantity = e.Quantity;
                        billDetail.DiscountPrice = e.DiscountPrice;
                        billDetail.BillId = request.Id;
                    }

                    billDetailsNew.Add(billDetail);
                });
                bill.BillDetails = billDetailsNew;

                await Task.WhenAll(tDeleteDetails);
                await _repository.UpdateAsync(bill);
                var result = await _unitOffWork.SaveChangesAsync();
                await _unitOffWork.CommitTransactionAsync();

                return result;
            }
            catch (Exception)
            {
                await _unitOffWork.RollbackTransactionAsync();
                throw;
            }
        }

        public override async Task<BillViewModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetNoTrackingEntities()
                                        .Include(e => e.Customer)
                                        .Include(e => e.UserPayment)
                                        .Include(e => e.BillDetails.OrderBy(e => e.Id))
                                        .SingleOrDefaultAsync(e => e.Id.Equals(id));
            var result = _mapper.Map<BillViewModel>(entity);
            return result;
        }

        public override async Task<IEnumerable<BillViewModel>> GetAllDTOAsync()
        {
            var entities = await _repository.GetQueryableTable()
                                            .Include(e => e.Customer)
                                            .Include(e => e.UserPayment)
                                            .ToListAsync();
            var result = _mapper.Map<IEnumerable<BillViewModel>>(entities);

            return result;
        }
        public async Task<BillPaging> GetPagingAsync(int pageIndex, int pageSize, string txtSearch)
        {
            var queryable = _repository.GetNoTrackingEntities()
                                        .Include(e => e.Customer)
                                        .Include(e => e.UserPayment)
                                        .OrderBy(e => e.CreateAt);

            var tEntities = queryable.Skip((pageIndex - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();

            var tCountEntities = queryable.CountAsync();

            var result = new BillPaging
            {
                Data = _mapper.Map<List<BillViewModel>>(await tEntities),
                TotalRow = await tCountEntities
            };

            return result;
        }
    }
}
