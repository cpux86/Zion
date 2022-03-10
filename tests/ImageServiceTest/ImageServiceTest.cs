using ImageProcessingService.Interfaces;
using ImageProcessingService.Services;
using ImageServiceTest.Common;
using ImageServiceTest.Service;
using SixLabors.ImageSharp;
using System.Threading.Tasks;
using Xunit;

namespace ImageServiceTest
{
    public class ImageServiceTest
    {
        private readonly UploadImageService _imageService;
        private readonly IImageProfile _imageProfile;
        
        public ImageServiceTest()
        {
            _imageService = new UploadImageService();
            _imageProfile = new Service.ImageProfile();
        }

        [Fact]
        public async void  SaveImageAsync_ImageId()
        {
            await _imageService.SaveImageAsync(ImageMoq.GetImageMoq());          
        }
    }
}