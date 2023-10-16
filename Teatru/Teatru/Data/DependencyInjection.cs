using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teatru.Models;
using Teatru.Data;

namespace Teatru.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IBiletRepository, BileteRepository>();
            services.AddTransient<ISpectacolRepository, SpectacolRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<TeatruContext>(opt => opt
                .UseSqlServer("Server=localhost,1433; Database=BooksDB;User Id=sa; Password=;"));
            return services;
        }
    }
}
