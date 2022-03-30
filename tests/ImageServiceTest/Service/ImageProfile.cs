using ImageProcessingService.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public int MaxUploadFileSize => throw new NotImplementedException();

        public IEnumerable<string> AllowedImagesSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int MaxUploadFileSizeBytes => throw new NotImplementedException();

        public Size OriginalImageSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IEnumerable<string> IImageProfile.AllowedExtensions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IImageProfile.MaxUploadFileSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        short IImageProfile.Quality { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
