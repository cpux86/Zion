using System.Collections.Generic;

namespace ImageProcessingService.Interfaces
{
    public interface IImageProfile
    {
        string Folder { get; }
        int Width { get; }
        int Height { get; }
        IEnumerable<string> AllowedExtensions { get; }
    }
}
