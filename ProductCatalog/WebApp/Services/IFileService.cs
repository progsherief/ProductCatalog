// WebApp/Services/IFileService.cs
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile imageFile);
    }
}
