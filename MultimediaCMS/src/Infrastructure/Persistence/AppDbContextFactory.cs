// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;
// using System;
// using System.IO;

// namespace Infrastructure.Persistence
// {
//     public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
//     {
//         public AppDbContext CreateDbContext(string[] args)
//         {
//             // Find the API project's directory (adjust this if necessary)
//             string basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "API");

//             var configuration = new ConfigurationBuilder()
//                 .SetBasePath(basePath)  // Ensure it looks in the API folder
//                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                 .Build();

//             var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//             optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

//             return new AppDbContext(optionsBuilder.Options);
//         }
//     }
// }
