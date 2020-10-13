using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PhotoAppMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddContact(this IServiceCollection services)
        {
            services.AddTransient<IContactService, ContactService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddBlog(this IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddOffer(this IServiceCollection services)
        {
            services.AddTransient<IOfferService, OfferService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
        public static IServiceCollection AddCategory(this IServiceCollection services)
        {
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
