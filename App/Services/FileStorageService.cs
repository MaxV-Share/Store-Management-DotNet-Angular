using App.Services.Interface;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class FileStorageService : IStorageService
    {
        private readonly string _pathRootFolder;

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _pathRootFolder = Path.Combine(webHostEnvironment.WebRootPath, "Files");
        }

        public string GetFileUrl(string fileName)
        {
            return $"/Files/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName, string folder = "")
        {
            var path = string.IsNullOrEmpty(folder) ? _pathRootFolder : Path.Combine(_pathRootFolder, folder);

            if (!Directory.Exists(Path.Combine(path)))
                Directory.CreateDirectory(path);

            var filePath = Path.Combine(path, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_pathRootFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}