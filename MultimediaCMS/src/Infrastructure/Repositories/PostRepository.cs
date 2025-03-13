using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context) => _context = context;

        public async Task<Post?> GetPostByIdAsync(int id) =>
            await _context.Posts
                .Include(p => p.User)
                .Include(p => p.MediaFiles)
                .Include(p => p.Comments)
                .Include(p => p.Likes)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Post>> GetAllPostsAsync() =>
            await _context.Posts.Include(p => p.MediaFiles).ToListAsync();

        public async Task<List<Post>> GetPostsByUserIdAsync(int userId) =>
            await _context.Posts.Where(p => p.UserId == userId).Include(p => p.MediaFiles).ToListAsync();




        public async Task AddPostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

public async Task<Post?> GetPostMediaByTypeAsync(int postId, string mediaType)
{
    var post = await _context.Posts
        .Where(p => p.Id == postId)
        .Include(p => p.MediaFiles)
        .FirstOrDefaultAsync();

    if (post == null) return null;

    // Filter media by type (e.g., "video" or "image")
    post.MediaFiles = post.MediaFiles
        .Where(m => m.Type.Equals(mediaType, StringComparison.OrdinalIgnoreCase))
        .ToList();

    return post;
}


        public async Task UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
       public async Task DeletePostAsync(int postId)
{
    var post = await _context.Posts.FindAsync(postId);
    if (post == null)
        throw new Exception($"Post with ID {postId} not found");

    _context.Posts.Remove(post);
    await _context.SaveChangesAsync();
}

    }
} 