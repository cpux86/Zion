using Microsoft.AspNetCore.Builder;
namespace ImageProcessingService.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder builder) 
        {
            builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
