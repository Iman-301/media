using MediatR;
using Application.Dtos;

public class GetPostMediaByTypeQuery : IRequest<PostDto>
{
    public int PostId { get; set; }
    public string MediaType { get; set; }

    public GetPostMediaByTypeQuery(int postId, string mediaType)
    {
        PostId = postId;
        MediaType = mediaType;
    }
}
