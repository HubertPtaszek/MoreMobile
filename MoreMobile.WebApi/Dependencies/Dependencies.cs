using Microsoft.AspNetCore.Identity.UI.Services;
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
        }
    }
}