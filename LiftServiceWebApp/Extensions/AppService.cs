using LiftServiceWebApp.MapperProfiles;
using LiftServiceWebApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftServiceWebApp.Extensions
{
    public static class AppServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(options =>
            {
                options.AddProfile(typeof(AccountProfile));
            });

            services.AddTransient<IEmailSender, EmailSender>();
          //loose coupling
            //services.AddTransient<EmailSender>();


            return services;
        }
    }
}