using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public interface IS3Bucket
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
    Task DeleteFileAsync(string fileName);
}