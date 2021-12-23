using ImageService.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ImageService.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            throw new System.NotImplementedException();
        }
    }
}
