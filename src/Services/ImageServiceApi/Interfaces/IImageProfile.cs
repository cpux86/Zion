using System.Collections.Generic;

namespace ImageProcessingService.Interfaces
{
    public interface IImageProfile
    {
        string ImagePath { get; }
        int Width { get; }
        int Height { get; }
        int MaxUploadFileSize { get; }
        /// <summary>
        /// Качестово
        /// </summary>
        short Quality { get; }
        /// <summary>
        /// Разрешенные расширения файлов
        /// </summary>
        IEnumerable<string> AllowedExtensions { get; }
    }
}
