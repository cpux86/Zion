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
            IImageProfile imageProfile = new Service.ImageProfile();
            Image image = Image.Load(@"C:\C#\Zion\tests\ImageServiceTest\img\test.jpg");
            var res = await _imageService.SaveImageAsync(image,imageProfile);          
        }
    }
}