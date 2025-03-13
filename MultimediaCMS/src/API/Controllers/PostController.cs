using Application.Features.Posts.Commands;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] CreatePostCommand command)
        {
            var post = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetPostById), new { postId = post.Id }, post);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = await _mediator.Send(new GetPostByIdQuery(postId));
            return post != null ? Ok(post) : NotFound();
        }

        
        [HttpGet("{postId}/images")]
        public async Task<IActionResult> GetPostImages(int postId)
        {
            var post = await _mediator.Send(new GetPostMediaByTypeQuery(postId, "Image"));
            return post != null ? Ok(post) : NotFound();
        }

      
        [HttpGet("{postId}/videos")]
        public async Task<IActionResult> GetPostVideos(int postId)
        {
            var post = await _mediator.Send(new GetPostMediaByTypeQuery(postId, "Video"));
            return post != null ? Ok(post) : NotFound();
        }
    }
}
