using ImageProcessingService.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ImageProcessingService.Services
{
    public class ImageService : IImageService
    {
        public Task<string> SaveImageAsync(IFormFile file, IImageProfile profile)
        {
            
            throw new System.NotImplementedException();
        }
    }
}
