using Microsoft.Extensions.DependencyInjection;
using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Infrastructure.Repositores;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IOfferRepository, OfferRepository>();
            return services;
        }
    }
}
