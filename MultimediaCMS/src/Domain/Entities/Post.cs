namespace Domain.Entities 
{
    public class Post
    {
        public int Id{get; set;}
        public string Caption{get; set;}=string.Empty;
        // public List<Media> MediaFiles{get; set;}=new();
        public List<Media> MediaFiles { get; set; } = new();
        public int UserId{get; set;}
        public required User User{get; set;}=null!;
        public List<Comment> Comments {get; set;}=new();
        public List<Like> Likes {get; set;}=new();
    }
}