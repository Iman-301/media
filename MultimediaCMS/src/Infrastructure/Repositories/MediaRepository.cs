using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

public class MediaRepository : IMediaRepository
{
    private readonly AppDbContext _context;
    private readonly string _mediaStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
    private readonly ILogger<MediaRepository> _logger;

    public MediaRepository(AppDbContext context, ILogger<MediaRepository> logger)
    {
        _context = context;
        _logger = logger;

        if (!Directory.Exists(_mediaStoragePath))
            Directory.CreateDirectory(_mediaStoragePath);
    }

    public async Task<List<Media>> UploadMediaAsync(List<IFormFile> files, int postId, CancellationToken cancellationToken)
    {
        if (files == null || !files.Any())
            throw new ArgumentException("No files provided.");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".mp4", ".mov" };
        List<Media> uploadedMedia = new();

        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            foreach (var file in files)
            {
                if (file.Length == 0)
                    throw new ArgumentException("File is empty.");

                var fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                    throw new ArgumentException($"Invalid file type {fileExtension}. Only images and videos are allowed.");

                string fileName = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(_mediaStoragePath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream, cancellationToken);
                }

                var media = new Media
                {
                    Url = $"/uploads/{fileName}",
                    Type = fileExtension switch
                    {
                        ".jpg" or ".jpeg" or ".png" => "Image",
                        ".mp4" or ".mov" => "Video",
                        _ => "Unknown"
                    },
                    PostId = postId
                };

                _context.MediaFiles.Add(media);
                uploadedMedia.Add(media);
            }

            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(ex, "Error uploading media.");
            throw;
        }

        return uploadedMedia;
    }

    public async Task<List<Media>> GetMediaByPostIdAsync(int postId, CancellationToken cancellationToken)
    {
        return await _context.MediaFiles.Where(m => m.PostId == postId).ToListAsync(cancellationToken);
    }
} 