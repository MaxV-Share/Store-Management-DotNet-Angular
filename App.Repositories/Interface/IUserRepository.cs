using App.Models.Entities.Identities;
using System.Linq;

namespace App.Repositories.Interface
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll(string filter);
    }
}