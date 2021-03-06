using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Application.BusinesLogic;
using TaskUser.Application.Services;

namespace TaskUser.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserBusinessLogic, UserBusinessLogic>();
            services.AddScoped<UserService>();
            services.AddScoped<ICacheService, InMemeoryCacheService>();
            services.AddScoped<IUserLoginAttemptBusinessLogic, UserLoginAttemptBusinessLogic>();
            services.AddScoped<UserLoginAttempService>();
         

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
                cfg.AddExpressionMapping();
            });

            return services;
        }
    }
}
