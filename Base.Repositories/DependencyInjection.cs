﻿
using Base.Repositories.Common;
using Base.Repositories.IRepository;
using Base.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repositories;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Interceptors
        //services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

        services.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("MsSQLConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #region Repository
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        #endregion

        return services;
    }
}
