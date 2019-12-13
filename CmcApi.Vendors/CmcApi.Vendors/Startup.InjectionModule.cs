using CmcApi.Core.Entities;
using CmcApi.Core.Repositories;
using CmcApi.Core.Services;
using CmcApi.Services.DataServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmcApi.Vendors
{
    public partial class Startup
    {
        public void InejctInfrastructures(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IBaseService, BaseService>();

            //services.AddTransient<ILogActionFilter, NLogActionFilter>();

            services.AddTransient(typeof(IBaseRepository<BaseEntity>), typeof(BaseRepository<BaseEntity>));

            services.AddTransient<IBaseService, BaseService>();

            services.AddTransient<IVendorsDataService, VendorsDataService>();

        }
    }
}
