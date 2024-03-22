﻿
using Base.Repositories.Common;
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
        //services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IRoleRepository, RoleRepository>();
        //services.AddScoped<IItemRepository, ItemRepository>();
        //services.AddScoped<ILocationRepository, LocationRepository>();
        //services.AddScoped<IRouteRepository, RouteRepository>();
        //services.AddScoped<ITripRepository, TripRepository>();
        //services.AddScoped<IBillRepository, BillRepository>();
        //services.AddScoped<IPackageRepository, PackageRepository>();
        #endregion

        return services;
    }
}
