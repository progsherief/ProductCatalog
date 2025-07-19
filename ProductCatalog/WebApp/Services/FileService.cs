using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebApp.Services
{
    public class FileService:IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            var imagePath = Path.Combine(_environment.WebRootPath,"images",imageName);

            using(var stream = new FileStream(imagePath,FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/images/{imageName}";
        }
    }
}
