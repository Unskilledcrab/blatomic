using Microsoft.Extensions.DependencyInjection;

namespace Blatomic.Services.JS
{
    public static class ConfigureJS
    {
        public static IServiceCollection AddJS(this IServiceCollection services)
        {
            services.AddTransient<ClipboardService>();
            services.AddTransient<ElementService>();
            return services;
        }
    }
}
