namespace Application.Dtos;
public class PostDto
{
    public int Id {get; set;}
    public string Caption{get; set;}=string.Empty;
    public List<string> MediaUrls {get; set;}=new();
    public int UserId {get; set;}
}