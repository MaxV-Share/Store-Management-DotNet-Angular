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
        private readonly string _pathFolder;

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _pathFolder = Path.Combine(webHostEnvironment.WebRootPath, "Files");
        }

        public string GetFileUrl(string fileName)
        {
            return $"/Files/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            if (!Directory.Exists(_pathFolder))
                Directory.CreateDirectory(_pathFolder);

            var filePath = Path.Combine(_pathFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_pathFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}