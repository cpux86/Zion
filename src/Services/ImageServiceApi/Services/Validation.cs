using ImageProcessingService.Interfaces;
using SixLabors.ImageSharp;
using ImageProcessingService.Exceptions;

namespace ImageProcessingService.Services
{
    public class Validation
    {
        public static void ValidateUploadFileSize(long fileSize, IImageProfile profile)
        {
            if (fileSize > profile.MaxUploadFileSizeBytes) throw new BadRequestException("недопустимый размер файла");
        }
        public static void ValidateImageSize(IImageInfo image, IImageProfile profile)
        {
            // если загружаемый файл слишком мал, в 10 раза меньше чем нужен
            if (image.Width < profile.OriginalImageSize.Width / 10 || image.Height < profile.OriginalImageSize.Height / 10)
            {
                throw new BadRequestException("недопустимый размер изображения");
            }
        }
    }
}
