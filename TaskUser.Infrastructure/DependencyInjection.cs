using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Repositories;
using TaskUser.Infrastructure.Data;
using TaskUser.Infrastructure.Data.Repositories;

namespace TaskUser.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFDbContext>(option => {
                option.UseSqlServer(configuration.GetConnectionString("DefaultDBConnection"));
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserLoginAttempRepository, UserLoginAttempRepository>();
            return services;
        }
    }
}
