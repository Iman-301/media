using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting; // Ensure this is included
using System.Reflection;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register PostgreSQL database
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();  
            services.AddScoped<IPostRepository, PostRepository>(); 
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>(); 
            services.AddScoped<IMediaRepository, MediaRepository>();

            // Register FileService with IWebHostEnvironment
        services.AddScoped<IFileService, FileService>();


            // Register MediatR for CQRS handlers
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
