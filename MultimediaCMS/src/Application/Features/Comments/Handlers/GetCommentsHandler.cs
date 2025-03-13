using MediatR;

public class GetCommentsHandler : IRequestHandler<GetCommentsQuery, List<CommentDto>>
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentsHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<CommentDto>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
    {
        return await _commentRepository.GetCommentsByPostIdAsync(request.PostId, cancellationToken);
    }
}
