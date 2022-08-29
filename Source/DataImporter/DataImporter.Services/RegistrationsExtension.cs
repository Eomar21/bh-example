using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Services
{
    public static class RegistrationsExtension
    {
        public static IServiceCollection WithCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGridFromDepthService, GridFromDepthService>();
            return services;
        }
    }
}
