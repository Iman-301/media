using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.Commands
{
    public class UploadProfilePictureCommand : IRequest<string>
    {
        public int UserId { get; set; }
        public IFormFile? File { get; set; }
    }
}
