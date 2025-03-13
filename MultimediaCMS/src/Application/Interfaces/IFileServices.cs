using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveProfilePictureAsync(IFormFile file);
    }
}
