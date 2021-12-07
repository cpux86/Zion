using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UploadController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> UploadImageFile()
        {
            var request =  HttpContext.Request;
            if (!request.HasFormContentType || !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) || string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
            {
                return new UnsupportedMediaTypeResult();
            }
            var reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body);
            var section = await reader.ReadNextSectionAsync();

            var fileName = Path.GetRandomFileName();
            var saveToPath = Path.Combine(Path.GetTempPath(), fileName);

            using (var targetStream = System.IO.File.Create(saveToPath))
            {
                await section.Body.CopyToAsync(targetStream);
            }

            return Ok();
        }
    }
}
