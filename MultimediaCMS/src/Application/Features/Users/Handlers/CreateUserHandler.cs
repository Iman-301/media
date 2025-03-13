using MediatR;
using Application.Dtos;
using Application.Features.Users.Commands;
using Domain.Entities;
using Application.Interfaces;
namespace Application.Features.Users.Handlers;
using BCrypt.Net;


public class CreateUserHandler: IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    public CreateUserHandler(IUserRepository userRepository)
    {
       _userRepository=userRepository;
    }
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user=new User
        {
            Username=request.Username,
            Email=request.Email,
            PasswordHash=BCrypt.HashPassword(request.Password)
        };
        await _userRepository.AddUserAsync(user);
        return new UserDto{
            Id=user.Id,
            Username=user.Username,
            Email=user.Email
        };
    }
}