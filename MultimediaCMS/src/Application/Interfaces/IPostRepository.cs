using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetPostByIdAsync(int id);
        Task<List<Post>> GetAllPostsAsync();
        Task<List<Post>> GetPostsByUserIdAsync(int userId);
       Task<Post?> GetPostMediaByTypeAsync(int postId, string mediaType);

        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int postId);   
    }
}  