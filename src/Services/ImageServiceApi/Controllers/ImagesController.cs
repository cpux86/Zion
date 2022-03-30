using ImageProcessingService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using Shorthand.ImageSharp.WebP;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using Microsoft.AspNetCore.Hosting;
using ImageProcessingService.Infrastructure;
using ImageProcessingService.Model;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ImageProcessingService.Exceptions;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats;
using System.Net;
using ImageProcessingService.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ImageProcessingService.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]/")]
    
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly ImageProfile _imageProfile;
        private readonly ImageContext _context;
        //IWebHostEnvironment _env;
        ILogger _logger;
        public ImagesController(
            IImageService imageService,
            ImageContext context,
            ILogger<ImagesController> logger,
            IOptions<ImageProfile> imageProfileProvider)
        {
            _imageService = imageService;
            _context = context;
            _logger = logger;
            _imageProfile = imageProfileProvider.Value;
        }


        [HttpPost]
        [Route("api/v{version:apiVersion}/images/")]
        public async Task<IActionResult> UploadImageFile(IFormFile uploadedFile)
        {
            // просто логируе все загрузки
            _logger.LogInformation("Upload file {0}", uploadedFile.FileName);
            if (uploadedFile == null || uploadedFile.Length == 0) throw new BadRequestException("не верный запрос!");
            
            Stream stream = uploadedFile.OpenReadStream();

            try
            {
                // определяем тип изображения
                string imgExt = Image.DetectFormat(stream).Name;
                bool isAllowedType = _imageProfile.AllowedExtensions.Any(ext => ext.ToLower() == imgExt.ToLower());
                if (!isAllowedType) throw new BadRequestException("не допустимый тип!");
            }
            catch (Exception e)
            {

                throw new BadRequestException("не верный запрос!");
            }

            
            Validation.ValidateUploadFileSize(uploadedFile.Length, _imageProfile);
            Image image = await Image.LoadAsync(stream);
            Validation.ValidateImageSize(image, _imageProfile);

            var result = await _imageService.SaveImageAsync(image, _imageProfile);

            var host = HttpContext.Request.Host.Host;
            var scheme = HttpContext.Request.Scheme;

            var url = new UriBuilder();
            url.Scheme = scheme;
            url.Host = host;
            url.Path = "/img/" + result;
            if (HttpContext.Request.Host.Port == 5001)
            {
                url.Port = (int)HttpContext.Request.Host.Port;
            }


            return Ok(url.ToString());
        }
    }
}
