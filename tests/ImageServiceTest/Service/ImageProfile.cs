using ImageProcessingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceTest.Service
{
    public class ImageProfile : IImageProfile
    {
        public string ImagePath => throw new NotImplementedException();

        public int Width => 1280;

        public int Height => 1024;

        public short Quality => 70;

        public IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".jpeg", ".png", ".gif" };
    }
}
