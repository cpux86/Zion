using ImageProcessingService.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ImageProcessingService.Services
{
    public class ImageProfile : IImageProfile
    {
        readonly IConfiguration _config;
        private const int mb = 1048576;

        public ImageProfile(IConfiguration config)
        {
            _config = config;
           //IConfigurationSection conf = _config.GetSection("OriginalImageSize");
           AllowedExtensions = _config["AllowedExtensions"]?.Replace(" ", "").Split(",");
        }
        
        
        public string ImagePath => throw new System.NotImplementedException();

        public int Width => int.Parse(_config["OriginalImageSize:Width"]);

        public int Height => int.Parse(_config["OriginalImageSize:Height"]);
        /// <summary>
        /// Максимальный размер загружаемого файла-изображения
        /// </summary>
        public int MaxUploadFileSize => int.Parse(_config["MaxUploadFileSize"]) * mb;

        public IEnumerable<string> AllowedExtensions { get; }
        // Качество 
        public short Quality => short.Parse(_config["Quality"]);
    }
}
