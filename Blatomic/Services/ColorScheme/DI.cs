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
        public static IServiceCollection AddTheme(this IServiceCollection services)
        {
            services.AddSingleton<ITheme, TwTheme>();
            return services;
        }
    }
}
