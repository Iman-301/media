using Domain.Entities;
using MediatR;

public class AddCommentHandler: IRequestHandler<AddCommentCommand, int>
{
    private readonly ICommentRepository _commentRepository;

    public AddCommentHandler(ICommentRepository commentRepository)
    {
        _commentRepository=commentRepository;
    }
    public async Task<int> Handle (AddCommentCommand request,CancellationToken cancellationToken)
    {
        var comment=new Comment{
            PostId=request.PostId,
            UserId = request.UserId,
            Content = request.Content,
            CreatedAt = DateTime.UtcNow
        };
        return await _commentRepository.AddCommentAsync(comment, cancellationToken);
    }

}