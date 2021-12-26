using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using App.Models.DbContexts;

namespace App.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public Task<Customer> GetByPhoneNumberAsync(string phoneNumber)
        {
            return Entities.SingleOrDefaultAsync(e => e.PhoneNumber.Equals(phoneNumber));
        }
    }
}