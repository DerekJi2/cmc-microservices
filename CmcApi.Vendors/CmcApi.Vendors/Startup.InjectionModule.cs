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
            //services.AddTransient<ILogActionFilter, NLogActionFilter>();

        }
    }
}
