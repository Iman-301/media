namespace Domain.Entities
{
    public class Media{
        public int Id{get; set;}
        public string Url{get; set;}=string.Empty;
        public string Type {get; set;}=string.Empty;
        public int PostId{get; set;}
        public Post Post{get; set;}=null!;

    }
}