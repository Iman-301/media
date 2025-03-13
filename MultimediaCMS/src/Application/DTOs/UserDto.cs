namespace Application.Dtos;

public class UserDto
{
    public int Id {get; set;}
    public string Username {get; set;}=string.Empty;
    public string Email{get; set;}=string.Empty;
    public string ProfilePictureUrl{get; set;}=string.Empty;
    public string Bio {get; set;}=string.Empty;
}