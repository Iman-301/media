using Application.Dtos;
using Application.Features.Posts.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
namespace Application.Features.Posts.Handlers
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, PostDto>
    {
        private readonly IPostRepository _postRepository;
         private readonly IMediaRepository _mediaRepository;
         private readonly IUserRepository _userRepository; 

        public CreatePostHandler(IPostRepository postRepository, IMediaRepository mediaRepository,IUserRepository userRepository) 
        {
            _postRepository = postRepository;
            _mediaRepository=mediaRepository;
             _userRepository = userRepository;

        }
        public async Task<PostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId);
    if (user == null)
    {
        throw new Exception("User not found.");
    }
            var post = new Post
            {
                Caption = request.Caption,
                UserId = request.UserId,
                MediaFiles=new List<Media>(),
                User=user
                // MediaFiles = request.MediaUrls.Select(url => new Media { Url = url }).ToList()
            };
            

            await _postRepository.AddPostAsync(post);

              if (request.MediaFiles != null && request.MediaFiles.Any())
    {
        var uploadedMedia = await _mediaRepository.UploadMediaAsync(request.MediaFiles, post.Id, cancellationToken);
        post.MediaFiles.AddRange(uploadedMedia);

      
        await _postRepository.UpdatePostAsync(post);
    }

            //   var uploadedMedia = await _mediaRepository.UploadMediaAsync(request.MediaFiles, post.Id, cancellationToken);
            // post.MediaFiles.AddRange(uploadedMedia);





            // foreach (var file in request.MediaFiles)
            // {
            //     string mediaUrl=await _mediaRepository.UploadMediaAsync(file,cancellationToken);
            //     post.MediaFiles.Add(new Media{ Url=mediaUrl, Type=file.ContentType.Contains("image")? "Image": "Video"});
            // }


            return new PostDto
            {
                Id = post.Id,
                Caption = post.Caption,
                UserId = post.UserId,
                MediaUrls = post.MediaFiles.Select(m => m.Url).ToList()
            };
        }
    }
}