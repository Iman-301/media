using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Users.Commands;
using Application.Features.Users.Queries;

namespace MultimediaCMS.Presentation.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdateUserProfileCommand command)
    {
        if (id != command.UserId)
            return BadRequest("User ID mismatch.");

        var result = await _mediator.Send(command);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost("{id}/upload-profile-picture")]
    public async Task<IActionResult> UploadProfilePicture(int id, [FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest(new { Message = "No file uploaded." });

        var command = new UploadProfilePictureCommand { UserId = id, File = file };
        var result = await _mediator.Send(command);

        if (result == "User not found.") return NotFound(new { Message = result });
        if (result == "No file uploaded.") return BadRequest(new { Message = result });

        return Ok(new { ProfilePictureUrl = result });
    }
}
