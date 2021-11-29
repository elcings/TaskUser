using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Common.Abstract;
using TaskUser.Common.Concrete;

namespace TaskUser.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommon(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IActionInvoker, BaseActionInvoker>();
            return services;
        }
    }
}
