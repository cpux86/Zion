using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ImageProcessingService.Interfaces
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile file, IImageProfile profile);
       
    }
}
