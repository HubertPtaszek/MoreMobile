﻿using Microsoft.AspNetCore.Identity.UI.Services;
using MoreMobile.Application.Services;
using MoreMobile.Data.Repositories;

namespace MoreMobile.WebApi.Dependencies
{
    public static class Dependencies
    {
        public static void AddDependencies(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IServiceTypeService, ServiceTypeService>();
            builder.Services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            builder.Services.AddScoped<IWarrantyService, WarrantyService>();
            builder.Services.AddScoped<IWarrantyRepository, WarrantyRepository>();
            builder.Services.AddScoped<IVisitDateRepository, VisitDateRepository>();
            builder.Services.AddScoped<IVisitDateService, VisitDateService>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddTransient<SMSReminderService>();
        }
    }
}