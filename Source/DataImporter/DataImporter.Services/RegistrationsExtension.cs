using Microsoft.Extensions.DependencyInjection;

namespace DataImporter.Services
{
    public static class RegistrationsExtension
    {
        public static IServiceCollection WithCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IGridFromDepthService, GridFromDepthService>();
            services.AddScoped<IFileProcessorService, FileProcessorService>();
            return services;
        }
    }
}
