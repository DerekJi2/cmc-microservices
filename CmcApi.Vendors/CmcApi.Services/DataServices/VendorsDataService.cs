using CmcApi.Core.Repositories;
using CmcApi.Core.Services;
using CmcApi.Database.Entity;
using CmcApi.Database.Mssql;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CmcApi.Services.DataServices
{
    public class VendorsDataService : BaseService, IVendorsDataService
    {
        public VendorsDataService(
            IHttpContextAccessor httpContextAccessor,
            MssqlDbContext dbContext) : base(httpContextAccessor)
        {
        }
    }
}
