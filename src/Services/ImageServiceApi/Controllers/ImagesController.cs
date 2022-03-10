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

namespace ImageProcessingService.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]/")]
    
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IImageProfile _imageProfile;
        private readonly ImageContext _context;
        IWebHostEnvironment _env;
        public ImagesController(IImageService imageService, IImageProfile profile, IWebHostEnvironment env, ImageContext context)
        {
            _imageService = imageService;
            _imageProfile = profile;
            _context = context;
            _env = env;
        }

        //[HttpGet]
        //[Route("files/images/{width}/{height}/{id}")]
        //public async Task<IActionResult> Get(string width, string height, string id)
        //{
        //    Guid imgId;
        //    try
        //    {
        //        imgId = Guid.Parse(id);
        //    }
        //    catch (Exception)
        //    {

        //        return NotFound(new { message = "Not Found" });
        //    }

        //    var result = await _context.FileImages.Where(f => f.Id == imgId).FirstOrDefaultAsync();
        //    byte[] c = result.File;

        //    var t = new MemoryStream(c);
        //    //string file_type = " application/octet-stream";
        //    //string file_name =  $"{Guid.NewGuid()}.jpg";
        //    //return File(t, file_type, file_name);

        //    string file_type = "image/jpeg";
        //    string file_name = $"{Guid.NewGuid()}.jpg";
        //    return File(t, file_type);
        //}

        [HttpPost]
        [Route("api/v{version:apiVersion}/images/")]
        public async Task<IActionResult> UploadImageFile(IFormFile uploadedFile)
        {
            
            if (uploadedFile == null || uploadedFile.Length == 0) throw new BadRequestException("не верный запрос!");


            //using MemoryStream ms = new MemoryStream();
            //Stream stream = uploadedFile.OpenReadStream();
            // определяем тип изображения

            Stream stream = uploadedFile.OpenReadStream();


            try
            {
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

            //var url = new UriBuilder(scheme, host, 5001, "/img/"+result);
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
