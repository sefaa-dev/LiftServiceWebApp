﻿using LiftServiceWebApp.MapperProfiles;
using LiftServiceWebApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
    
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
                options.AddProfile(typeof(PaymentProfile));
            });

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IPaymentService, IyzicoPaymentService>();    
            //loose coupling
            //services.AddTransient<EmailSender>();


            return services;
        }
    }
}