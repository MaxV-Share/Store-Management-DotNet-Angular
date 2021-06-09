using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        Task DeleteFileAsync(string fileName);
    }
}