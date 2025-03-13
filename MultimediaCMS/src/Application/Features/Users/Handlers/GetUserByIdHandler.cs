using MediatR;
using Application.Dtos;
using Application.Interfaces;
using Application.Features.Users.Queries;

namespace MultimediaCMS.Application.Users.Handlers;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            ProfilePictureUrl = user.ProfilePictureUrl,
            Bio = user.Bio
        };
    }
}