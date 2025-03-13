using Application.Dtos;
using MediatR;
namespace Application.Features.Users.Queries;
public class GetUserByIdQuery: IRequest<UserDto>
{
    public int Id {get; set;}
    public GetUserByIdQuery(int id)
    {
        Id =id;
        
    }
}