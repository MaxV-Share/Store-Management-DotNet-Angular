using App.Models.Entities;
using App.Repositories.BaseRepository;

namespace App.Repositories.Interface
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
    }
}
