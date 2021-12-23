using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ImageService.Interfaces
{
    public interface IImageService
    {
        Task<string> SaveImageAsync(IFormFile file);
       
    }
}
