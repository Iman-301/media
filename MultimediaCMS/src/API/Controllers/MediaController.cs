using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

[Route("api/media")]
[ApiController]
public class MediaController : ControllerBase
{
    private readonly IMediaRepository _mediaRepository;

    public MediaController(IMediaRepository mediaRepository)
    {
        _mediaRepository = mediaRepository;
    }

    [HttpPost("upload/{postId}")]
    public async Task<IActionResult> UploadMedia(int postId,[FromForm] List<IFormFile> files, CancellationToken cancellationToken)
    {
        if (files == null || files.Count == 0)
            return BadRequest("No file provided");

        List<Media> uploadedMedia = await _mediaRepository.UploadMediaAsync(files,postId, cancellationToken);
        return Ok(uploadedMedia);
    }

    [HttpGet("post/{postId}")]
    public async Task<IActionResult> GetMediaByPostId(int postId, CancellationToken cancellationToken)
    {
        List<Media> mediaList = await _mediaRepository.GetMediaByPostIdAsync(postId, cancellationToken);
        return Ok(mediaList);
    }
}