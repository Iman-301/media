using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] AddCommentCommand command)
    {
        var commentId = await _mediator.Send(command);
        return Ok(new { CommentId = commentId });
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetComments(int postId)
    {
        var comments = await _mediator.Send(new GetCommentsQuery { PostId = postId });
        return Ok(comments);
    }
}
