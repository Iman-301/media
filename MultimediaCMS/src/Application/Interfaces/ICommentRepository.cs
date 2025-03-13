using Domain.Entities;

public interface ICommentRepository{
    Task<int> AddCommentAsync(Comment comment, CancellationToken cancellationToken);
    Task<List<CommentDto>> GetCommentsByPostIdAsync(int postId, CancellationToken cancellationToken);
}