using MediatR;

public class ToggleLikeCommand : IRequest<bool>
{
    public int PostId { get; set; }
    public int UserId { get; set; }
}
