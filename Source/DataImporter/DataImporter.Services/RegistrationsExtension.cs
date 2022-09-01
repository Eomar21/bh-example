using Microsoft.Extensions.DependencyInjection;

namespace DataImporter.Services
{
    public static class RegistrationsExtension
    {
        public static IServiceCollection WithCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IVolumeProcessorService, VolumeProcessorService>();
            services.AddScoped<IFileProcessorService, FileProcessorService>();
            return services;
        }
    }
}