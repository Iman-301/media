using MediatR;

public class ToggleLikeHandler : IRequestHandler<ToggleLikeCommand, bool>
{
    private readonly ILikeRepository _likeRepository;

    public ToggleLikeHandler(ILikeRepository likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task<bool> Handle(ToggleLikeCommand request, CancellationToken cancellationToken)
    {
        return await _likeRepository.ToggleLikeAsync(request.PostId, request.UserId, cancellationToken);
    }
}
