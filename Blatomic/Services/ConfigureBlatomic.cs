using Blatomic.Services.ColorScheme;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blatomic.Services
{
    public static class ConfigureBlatomic
    {
        public static IServiceCollection AddBlatomic(this IServiceCollection services)
        {
            services.AddTheme();

            return services;
        }
    }
}
