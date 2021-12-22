using App.Models.Entities;
using App.Repositories.BaseRepository;

namespace App.Repositories.Interface
{
    public interface IFunctionRepository : IBaseRepository<Function, string>
    {
    }
}
