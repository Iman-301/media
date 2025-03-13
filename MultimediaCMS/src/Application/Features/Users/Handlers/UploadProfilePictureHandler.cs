using Application.Features.Users.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class UploadProfilePictureHandler : IRequestHandler<UploadProfilePictureCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IFileService _fileService;

    public UploadProfilePictureHandler(IUserRepository userRepository, IFileService fileService)
    {
        _userRepository = userRepository;
        _fileService = fileService;
    }

    public async Task<string> Handle(UploadProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user == null) return "User not found.";

        if (request.File == null || request.File.Length == 0)
            return "No file uploaded.";

        var profilePictureUrl = await _fileService.SaveProfilePictureAsync(request.File);
        user.ProfilePictureUrl = profilePictureUrl;

        await _userRepository.UpdateUserAsync(user);
        return profilePictureUrl;
    }
}
