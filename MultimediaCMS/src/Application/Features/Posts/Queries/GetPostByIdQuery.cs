using MediatR;
using Application.Dtos;

public class GetPostByIdQuery: IRequest<PostDto>
{
    public int PostId {get; set;}

    public GetPostByIdQuery(int postId)
    {
        PostId= postId;
    }
}