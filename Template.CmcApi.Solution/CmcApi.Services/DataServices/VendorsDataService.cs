using CmcApi.Core.Services;
using CmcApi.Database.Entity;
using CmcApi.Database.Mssql;
using CmcApi.Database.Mssql.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmcApi.Services.DataServices
{
    public class VendorsDataService : BaseService, IVendorsDataService
    {
        protected readonly IBaseRepository<Vendor> localVendorRepos;

        public VendorsDataService(
            IHttpContextAccessor httpContextAccessor,
            IBaseRepository<Vendor> vendorRepos
            ) : base(httpContextAccessor)
        {
            localVendorRepos = vendorRepos;
        }

        public IQueryable<Vendor> FindAll(bool active = true)
        {
            return localVendorRepos.FindAll(active);
        }
    }
}
