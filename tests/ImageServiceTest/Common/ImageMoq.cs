using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageServiceTest.Common
{
    public class ImageMoq
    {
        public static Image GetImageMoq()
        {
            var image = Image.Load("./test.jpg", new JpegDecoder { IgnoreMetadata = true });
            return image;
        }
    }
}
