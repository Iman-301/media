using MediatR;

public class GetLikesQuery : IRequest<int>
{
    public int PostId { get; set; }
}
