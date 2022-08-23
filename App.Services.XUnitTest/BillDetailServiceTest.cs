using App.Models.Entities;
using App.Models.Mapper;
using App.Repositories.BaseRepository;
using App.Repositories.UnitOffWorks;
using App.Services.XUnitTest.SetupMock;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace App.Services.XUnitTest
{
    public class BillDetailServiceTest
    {
        protected readonly IMapper _mapper;
        protected readonly Mock<IUnitOffWork> _unitOffWork;
        protected readonly Mock<ILogger<BillDetailService>> _logger;
        public BillDetailServiceTest()
        {
            _unitOffWork = new Mock<IUnitOffWork>();
            _logger = new Mock<ILogger<BillDetailService>>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Theory]
        [InlineData(1)]
        [InlineData(123)]
        [InlineData(4)]
        public async Task AuthenticationService_GetByBillIdAsync_IdNotZeroOrNull_ThrowException(int id)
        {
            _unitOffWork.Setup(e => e.Repository<BillDetail, int>().GetNoTrackingEntities()).Returns<IQueryable<BillDetail>>(null);

            var billDetailService = new BillDetailService(_mapper, _unitOffWork.Object, _logger.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => billDetailService.GetByBillIdAsync(id, It.IsAny<string>()));
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task AuthenticationService_GetByBillIdAsync_IdNotZeroOrNull_SuccessAny(int id)
        {
            var data = new List<BillDetail>
            {
                new BillDetail()
                {
                    BillId = 1,
                    Bill = new Bill()
                },
                new BillDetail()
                {
                    BillId = 2,
                    Bill = new Bill()
                }
            }.AsAsyncQueryable();
            var billDetailsRepository = new Mock<IBaseRepository<BillDetail, int>>();
            billDetailsRepository.Setup(e => e.GetNoTrackingEntities()).Returns(data);
            _unitOffWork.Setup(e => e.Repository<BillDetail, int>()).Returns(billDetailsRepository.Object);

            var billDetailService = new BillDetailService(_mapper, _unitOffWork.Object, _logger.Object);
            var result = await billDetailService.GetByBillIdAsync(id, It.IsAny<string>());
            Assert.NotEmpty(result);
        }
        [Theory]
        [InlineData(1)]
        public async Task AuthenticationService_GetByBillIdAsync_IdNotExist_Empty(int id)
        {
            var data = new List<BillDetail>
            {
                new BillDetail()
                {
                    Bill = new Bill()
                }
            }.AsAsyncQueryable();
            var billDetailsRepository = new Mock<IBaseRepository<BillDetail, int>>();
            billDetailsRepository.Setup(e => e.GetNoTrackingEntities()).Returns(data);
            _unitOffWork.Setup(e => e.Repository<BillDetail, int>()).Returns(billDetailsRepository.Object);

            var billDetailService = new BillDetailService(_mapper, _unitOffWork.Object, _logger.Object);
            var result = await billDetailService.GetByBillIdAsync(id, It.IsAny<string>());
            Assert.Empty(result);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(null)]
        public async Task AuthenticationService_GetByBillIdAsync_IdZeroOrNull_Empty(int id)
        {
            var data = new List<BillDetail>
            {
                new BillDetail()
                {
                    Bill = new Bill()
                }
            }.AsAsyncQueryable();
            var billDetailsRepository = new Mock<IBaseRepository<BillDetail, int>>();
            billDetailsRepository.Setup(e => e.GetNoTrackingEntities()).Returns(data);
            _unitOffWork.Setup(e => e.Repository<BillDetail, int>()).Returns(billDetailsRepository.Object);

            var billDetailService = new BillDetailService(_mapper, _unitOffWork.Object, _logger.Object);
            var result = await billDetailService.GetByBillIdAsync(id, It.IsAny<string>());
            Assert.Empty(result);
        }
        [Fact]
        public async Task AuthenticationService_GetByBillIdAsync_IdExist_Success()
        {
            var data = new List<BillDetail>
            {
                new BillDetail()
                {
                    BillId = 1,
                    Bill = new Bill(),
                    Product = new Product()
                    {
                        ProductDetails = new List<ProductDetail>() {
                            new ProductDetail()
                            {
                                ProductId = 1,
                                LangId = "EN"
                            }
                        }
                    }
                }
            }.AsAsyncQueryable();
            var billDetailsRepository = new Mock<IBaseRepository<BillDetail, int>>();
            billDetailsRepository.Setup(e => e.GetNoTrackingEntities()).Returns(data);
            _unitOffWork.Setup(e => e.Repository<BillDetail, int>()).Returns(billDetailsRepository.Object);

            var billDetailService = new BillDetailService(_mapper, _unitOffWork.Object, _logger.Object);
            var result = await billDetailService.GetByBillIdAsync(1, It.IsAny<string>());
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task AuthenticationService_GetAllDTOAsync_NotEmpty()
        {
            var data = new List<BillDetail>
            {
                new BillDetail()
                {
                    BillId = 1,
                    Bill = new Bill(),
                    Product = new Product()
                    {
                        ProductDetails = new List<ProductDetail>() {
                            new ProductDetail()
                            {
                                ProductId = 1,
                                LangId = "EN"
                            }
                        }
                    }
                }
            }.AsAsyncQueryable();
            var billDetailsRepository = new Mock<IBaseRepository<BillDetail, int>>();
            billDetailsRepository.Setup(e => e.GetNoTrackingEntities()).Returns(data);
            _unitOffWork.Setup(e => e.Repository<BillDetail, int>()).Returns(billDetailsRepository.Object);
            var billDetailService = new BillDetailService(_mapper, _unitOffWork.Object, _logger.Object);
            var result = await billDetailService.GetAllDTOAsync();
            Assert.True(data.Count() == result.Count());
        }
    }
}
