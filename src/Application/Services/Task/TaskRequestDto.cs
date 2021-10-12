using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Task
{
    public class TaskRequestDto
    {
        /// <summary>
        /// Заголовок, к примеру "Микросхема ШИМ-контроллера"
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Комментарии, к промеру "Шим-контроллер с частоного преобразователя Siemens"
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// URL-адреса изображений искомых товаров
        /// </summary>
        public string[] ProductImagesURLs { get; set; }
    }
}
