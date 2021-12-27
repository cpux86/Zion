using ImageProcessingService.Interfaces;
using ImageProcessingService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ImageProcessingService
{
    public static class DependencyInjection
    {
        public static void AddImageService(this IServiceCollection services)
        {
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IImageProfile, ImageProfile>();
        }
    }
}
