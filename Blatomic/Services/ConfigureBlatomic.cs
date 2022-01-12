using Blatomic.Services.ColorScheme;
using Blatomic.Services.JS;
using Blatomic.Services.Toasts;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Blatomic.Services
{
    public static class ConfigureBlatomic
    {
        public static IServiceCollection AddBlatomic(this IServiceCollection services, Action<ITheme>? configureTheme = null)
        {
            services.AddBlazoredLocalStorage();
            services.AddTheme(configureTheme);
            services.AddJS();
            services.AddScoped<ToastService>();
            return services;
        }
    }
}
