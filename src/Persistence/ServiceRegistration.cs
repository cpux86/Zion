using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<,>),typeof(GenericRepositoryAsync<,>));

            #endregion

        }
    }
}
