using ImageProcessingService.Exceptions;
using ImageProcessingService.Infrastructure;
using ImageProcessingService.Interfaces;
using ImageProcessingService.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessingService.Services
{
    public class UploadImageService : IImageService
    {
        private readonly ImageContext _context;
        //private readonly IImageProfile _profile;
        public UploadImageService(ImageContext context, IImageProfile profile)
        {
            _context = context;
            //_profile = profile;
        }

        public UploadImageService()
        {
            _context = new ImageContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Путь к загруженному файлу, вида /orig/str1/str2/fileName.jpg</returns>
        /// <exception cref="BadRequestException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<string> SaveImageAsync(Image image, IImageProfile imageProfile)
        {
           
            Configuration.Default.ImageFormatsManager.SetDecoder(JpegFormat.Instance, new JpegDecoder() { IgnoreMetadata = true });
            Configuration.Default.ImageFormatsManager.SetDecoder(GifFormat.Instance, new GifDecoder() { IgnoreMetadata = true });
            Configuration.Default.ImageFormatsManager.SetDecoder(PngFormat.Instance, new PngDecoder() { IgnoreMetadata = true });

            //using MemoryStream ms = new MemoryStream();
            
            Resize(image, imageProfile);
            //Crop(image, _profile);


            string fileName = Utils.GenerateFileName();
            // формируем путь к файлу по шаблону /orig/str1/str2/fileName.jpg
            string substr1 = fileName.Substring(0, 2);
            string substr2 = fileName.Substring(2, 2);
            string basePath = $"./wwwroot/img/";
            string path = $"orig/{substr1}/{substr2}";
            string fullPath = Path.Combine(basePath, path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(fullPath);
            }
            string filePath = $"{fullPath}/{fileName}";
            if (File.Exists(filePath)) throw new Exception("ошибка сервера");


            await image.SaveAsync(filePath, new JpegEncoder { Quality = imageProfile.Quality});

            return $"{path}/{fileName}";
        }

        private void Resize(Image image, IImageProfile profile)
        {
            //image.Mutate(x => x.Resize(new Size { Width = _profile.Width }));
            var resizeOptions = new ResizeOptions
            {
                Mode = ResizeMode.Max,
                Size = new Size(profile.OriginalImageSize.Width)
            };
            image.Mutate(action => action.Resize(resizeOptions));
        }

        // Получает обрезанный прямоугольник
        private void Crop(Image image, IImageProfile imageProfile)
        {
            var rectangle = GetCropRectangle(image, imageProfile);
            image.Mutate(action => action.Crop(rectangle));
        }

        private Rectangle GetCropRectangle(IImageInfo image, IImageProfile imageProfile)
        {
            var widthDifference = image.Width - imageProfile.OriginalImageSize.Width;
            var heightDifference = image.Height - imageProfile.OriginalImageSize.Height;
            var x = widthDifference / 2;
            var y = heightDifference / 2;

            return new Rectangle(x, y, imageProfile.OriginalImageSize.Width, imageProfile.OriginalImageSize.Height);
        }

        private void ValidateExtension()
        {

        }




        /// <summary>
        /// Загружает файл во временную папку
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <param name="allowedExtensions"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<string> UploadToTempFolder(IFormFile uploadedFile, IImageProfile allowedExtensions)
        {
            IEnumerable<string> extensionList = allowedExtensions.AllowedExtensions;
            // получаем расширение загружаемого файла
            string extension = Path.GetExtension(uploadedFile.FileName);
            // валидация расширения загружаемого файла
            if (!extensionList.Any(ext => ext == extension))
                throw new System.Exception("не допустимый файл");
            // получаю путь к временному файлу по которому будет загружен файл-изображения
            string tmp = Path.GetTempFileName();
            // загружаю файл по временному пути
            using (var targetStream = File.Create(tmp))
            {
                await uploadedFile.CopyToAsync(targetStream);
            }
            return tmp;
            //this.ValidateExtension();
            throw new System.NotImplementedException();
        }

        public void ImageValidation(Image file)
        {
            throw new NotImplementedException();
        }
    }
}
