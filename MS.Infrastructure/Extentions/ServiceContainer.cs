using MS.Infrastructure.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.Infrastructure.Services.Categories;
using MS.Infrastructure.Services.Users;
using MS.Infrastructure.Services;
using MS.Infrastructure.Services.Stores;
using MS.Infrastructure.Services.Products;

namespace MS.Infrastructure.Extentions
{
    public static class ServiceContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //services.AddTransient<IFileService, FileService>();
         
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IStoreService, StoreService>();








            return services;
        }
    }
}
