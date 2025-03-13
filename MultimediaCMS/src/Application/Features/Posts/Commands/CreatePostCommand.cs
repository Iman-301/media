using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
namespace Application.Features.Posts.Commands;
public class CreatePostCommand : IRequest<PostDto>
{
    public string Caption {get; set;}=string.Empty;
    public List<IFormFile> MediaFiles { get; set; } = new(); 
    // public List<string> MediaUrls {get; set;}=new();
    public int UserId{get; set;}
} 