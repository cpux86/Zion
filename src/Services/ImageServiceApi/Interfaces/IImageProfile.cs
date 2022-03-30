using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessingService.Interfaces
{
    public interface IImageProfile
    {
        IEnumerable<string> AllowedExtensions { get; set; }
        IEnumerable<string> AllowedImagesSize { get; set; }
        int MaxUploadFileSize { get; set; }
        int MaxUploadFileSizeBytes { get; }
        Size OriginalImageSize { get; set; }
        short Quality { get; set; }
    }
}
