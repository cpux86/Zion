using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Application
{
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Добовляет компонетны урованя приложения
        /// </summary>
        /// <param name="service"></param>
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
