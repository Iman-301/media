
using Domain.Entities;
namespace Application.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
}