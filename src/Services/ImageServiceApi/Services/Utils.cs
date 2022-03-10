using System;

namespace ImageProcessingService.Services
{
    public class Utils
    {
        /// <summary>
        /// Генерирует имя файла
        /// </summary>
        /// <returns></returns>
        public static string GenerateFileName()
        {
            return Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
        }
    }
}
