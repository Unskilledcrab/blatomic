using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Services.ColorScheme
{
    public static class ConfigureTheme
    {
        public static IServiceCollection AddTheme(this IServiceCollection services, Action<ITheme>? configureTheme = null)
        {
            var theme = new TwTheme();

            if (configureTheme != null)
            {
                configureTheme(theme);
            }
            services.AddSingleton<ITheme>(theme);
            services.AddScoped<ThemeService>();
            return services;
        }
    }
}
