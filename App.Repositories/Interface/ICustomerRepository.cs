using App.Models.Entities;
using App.Repositories.BaseRepository;
using System.Threading.Tasks;

namespace App.Repositories.Interface
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
        public Task<Customer> GetByPhoneNumberAsync(string phoneNumber);
    }
}