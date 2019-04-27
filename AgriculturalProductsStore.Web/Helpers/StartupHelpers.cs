using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository;
using AgriculturalProductsStore.Repository.UnitOfWork;
using AgriculturalProductsStore.Services.EmailSender;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturalProductsStore.Web.Helpers
{
    public static class StartupHelpers
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            //
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IEmailSender, EmailSender>();
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

    }
}
