using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using System.Threading.Tasks;

namespace ImageProcessingService.Interfaces
{
    public interface IUploadImageService
    {
        void ImageValidation(Image file);
        Task<string> SaveImageAsync(Image image, IImageProfile profile);
    }
}
