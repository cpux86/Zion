using System;

namespace ImageProcessingService.Model
{
    public class FileImage
    {
        public Guid Id { get; set; }
        public byte[] File { get; set; }
    }
}
