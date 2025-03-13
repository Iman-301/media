using Application.Interfaces; // Ensure this is included
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class LikeRepository : ILikeRepository
{
    private readonly AppDbContext _context;

    public LikeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ToggleLikeAsync(int postId, int userId, CancellationToken cancellationToken)
    {
        var existingLike = await _context.Likes
            .FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId, cancellationToken);

        if (existingLike != null)
        {
            _context.Likes.Remove(existingLike);
            await _context.SaveChangesAsync(cancellationToken);
            return false; // Unlike
        }
        else
        {
            var like = new Like
            {
                PostId = postId,
                UserId = userId
            };

            _context.Likes.Add(like);
            await _context.SaveChangesAsync(cancellationToken);
            return true; // Like
        }
    }

    public async Task<int> GetLikeCountAsync(int postId, CancellationToken cancellationToken)
    {
        return await _context.Likes.CountAsync(l => l.PostId == postId, cancellationToken);
    }
}
