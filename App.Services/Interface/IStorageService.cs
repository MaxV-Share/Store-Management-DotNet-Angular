using System.IO;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName, string folder = "");

        Task DeleteFileAsync(string fileName);
    }
}