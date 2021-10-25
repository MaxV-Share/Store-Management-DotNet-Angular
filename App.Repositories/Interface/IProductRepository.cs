using App.Models.Entities;
using App.Repositories.BaseRepository;

namespace App.Repositories.Interface
{
    public interface IProductRepository : IBaseRepository<Product, int>
    {
    }
}
