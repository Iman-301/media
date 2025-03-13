using Domain.Entities;
public interface ILikeRepository
{
    Task<bool> ToggleLikeAsync(int postId,int userId,CancellationToken cancellationToken);
    Task<int> GetLikeCountAsync(int postId, CancellationToken cancellationToken);
}