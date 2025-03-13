using Application.Dtos;
using Application.Interfaces;
using MediatR;

public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, UserDto>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserProfileHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user == null) return null;

        user.ProfilePictureUrl = request.ProfilePictureUrl ?? user.ProfilePictureUrl;
        user.Bio = request.Bio ?? user.Bio;

        await _userRepository.UpdateUserAsync(user);

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