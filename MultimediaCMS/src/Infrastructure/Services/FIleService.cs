using Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveProfilePictureAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            // Ensure web root path exists
            var webRootPath = _environment.WebRootPath;
            if (string.IsNullOrEmpty(webRootPath))
            {
                webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            }

            var uploadsFolder = Path.Combine(webRootPath, "uploads", "profile-pics");
            Directory.CreateDirectory(uploadsFolder); // Ensure folder exists

            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return the relative path to access the image
            return $"/uploads/profile-pics/{fileName}";
        }
    }
}
