using Application.Dtos;
using MediatR;

public class UpdateUserProfileCommand : IRequest<UserDto>
{
    public int UserId { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? Bio { get; set; }
}