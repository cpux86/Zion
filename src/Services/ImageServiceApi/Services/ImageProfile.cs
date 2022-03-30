using ImageProcessingService.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessingService.Services
{
    public class ImageProfile : IImageProfile
    {
        public const string SectionName = "ImagePrifile";
        private const int mb = 1048576;

        /// <summary>
        /// Максимальный размер загружаемого файла-изображения в мегабайтах
        /// </summary>
        public int MaxUploadFileSize { get; set; }
        /// <summary>
        /// Максимальный размер загружаемого файла-изображения в байтах
        /// </summary>
        public int MaxUploadFileSizeBytes { get => MaxUploadFileSize * mb; }
        /// <summary>
        /// Разрешенные расширения изображений
        /// </summary>
        public IEnumerable<string> AllowedExtensions { get; set; }

        public IEnumerable<string> AllowedImagesSize { get; set; }
        public Size OriginalImageSize { get; set; }
        /// <summary>
        /// Качество
        /// </summary>
        public short Quality { get; set; }
    }
}
