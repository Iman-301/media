using MediatR;

public class GetCommentsQuery : IRequest<List<CommentDto>>
{
    public int PostId { get; set; }
}
