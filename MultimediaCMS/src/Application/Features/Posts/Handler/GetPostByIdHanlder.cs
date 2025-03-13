 using Application.Dtos;

using Application.Interfaces;
using MediatR;

namespace Application.Features.Posts.Handlers;

public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, PostDto>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetPostByIdAsync(request.PostId);
        if (post == null) return null!;

        return new PostDto
        {
            Id = post.Id,
            Caption = post.Caption,
            UserId = post.UserId,
            MediaUrls = post.MediaFiles.Select(m => m.Url).ToList()
        };
    }
} 