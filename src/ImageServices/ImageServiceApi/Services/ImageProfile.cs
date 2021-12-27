using ImageProcessingService.Interfaces;
using System.Collections.Generic;

namespace ImageProcessingService.Services
{
    public class ImageProfile : IImageProfile
    {
        public string Folder => throw new System.NotImplementedException();

        public int Width => throw new System.NotImplementedException();

        public int Height => throw new System.NotImplementedException();

        public IEnumerable<string> AllowedExtensions => throw new System.NotImplementedException();
    }
}
