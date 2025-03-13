using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

public class GetPostMediaByTypeHandler : IRequestHandler<GetPostMediaByTypeQuery, PostDto>
{
    private readonly IPostRepository _postRepository;

    public GetPostMediaByTypeHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostDto?> Handle(GetPostMediaByTypeQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetPostMediaByTypeAsync(request.PostId, request.MediaType);

        if (post == null) return null;

        return new PostDto
        {
            Id = post.Id,
            Caption = post.Caption,
            UserId = post.UserId,
            MediaUrls = post.MediaFiles.Select(m => m.Url).ToList()
        };
    }
}
