using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageProcessingService.Interfaces
{
    public interface IImageService : IUploadImageService
    {
        //Task<string> UploadToTempFolder(IFormFile uploadedFile, IImageProfile allowedExtensions);
       
    }
}
