using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddCommentAsync(Comment comment, CancellationToken cancellationToken)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync(cancellationToken);
        return comment.Id;
    }

    public async Task<List<CommentDto>> GetCommentsByPostIdAsync(int postId, CancellationToken cancellationToken)
    {
        return await _context.Comments
            .Where(c => c.PostId == postId)
            .OrderByDescending(c => c.CreatedAt)
            .Select(c => new CommentDto
            {
                Id = c.Id,
                PostId = c.PostId,
                UserId = c.UserId,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync(cancellationToken);
    }
}
