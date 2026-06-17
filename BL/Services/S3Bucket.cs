using BL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BL.Services;

public class S3Bucket(IConfiguration configuration) : IS3Bucket
{
    private readonly string _bucketName = configuration["AwsS3:BucketName"] ?? "education-platform-bucket";

    public Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        var simulatedUrl = $"https://s3.amazonaws.com/{_bucketName}/{fileName}";
        return Task.FromResult(simulatedUrl);
    }

    public Task DeleteFileAsync(string fileName)
    {
        return Task.CompletedTask;
    }
}