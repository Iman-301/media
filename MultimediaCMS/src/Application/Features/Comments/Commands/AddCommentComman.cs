using MediatR;

public class AddCommentCommand: IRequest<int>
{
    public int PostId{get; set;}
    public int UserId{get; set;}
    public string Content {get; set;}=string.Empty;
}