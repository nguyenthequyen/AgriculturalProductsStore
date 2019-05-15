using AgriculturalProductsStore.Models.Entity;
using AgriculturalProductsStore.Repository;
using AgriculturalProductsStore.Repository.UnitOfWork;
using AgriculturalProductsStore.Services;
using AgriculturalProductsStore.Services.EmailSender;
using AgriculturalProductsStore.Web.ViewModels.ManagerAccount;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
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
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            //Services
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IUserInforService, UserInforService>();
            services.AddTransient<IUserAddressService, UserAddressService>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<ICategoryService, CategoryService>();
        }

        public static void RegisterRepository(this IServiceCollection services)
        {
            //UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //Repository
            services.AddTransient<IUserInforRepository, UserInforRepository>();
            services.AddTransient<IUserAddressRepository, UserAddressRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }

        [Obsolete]
        public static void RegisterMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<UserAddress, UserAddressViewModel>();
                cfg.CreateMap<UserAddressViewModel, UserAddress>();
            });
        }

    }
}
