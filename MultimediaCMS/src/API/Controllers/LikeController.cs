using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/likes")]
[ApiController]
public class LikeController : ControllerBase
{
    private readonly IMediator _mediator;

    public LikeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> ToggleLike([FromBody] ToggleLikeCommand command)
    {
        var isLiked = await _mediator.Send(command);
        return Ok(new { Liked = isLiked });
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetLikes(int postId)
    {
        var likeCount = await _mediator.Send(new GetLikesQuery { PostId = postId });
        return Ok(new { Likes = likeCount });
    }
}
