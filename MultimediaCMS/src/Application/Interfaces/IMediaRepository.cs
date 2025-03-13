using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IMediaRepository
    {
        Task<List<Media>> UploadMediaAsync(List<IFormFile> files,int postId, CancellationToken cancellationToken);
        Task<List<Media>> GetMediaByPostIdAsync(int postId, CancellationToken cancellationToken);
    }
} 