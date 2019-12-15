using CmcApi.Core.Services;
using CmcApi.Database.Entity;
using CmcApi.Database.Mssql;
using CmcApi.Database.Mssql.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmcApi.Services.DataServices
{
    public class VendorsDataService : BaseDataService<Vendor>, IVendorsDataService
    {
        protected readonly IBaseRepository<Vendor> localVendorRepos;

        public VendorsDataService(
            IHttpContextAccessor httpContextAccessor,
            IBaseRepository<Vendor> vendorRepos
            ) : base(httpContextAccessor, vendorRepos)
        {
            localVendorRepos = vendorRepos;
        }
    }
}
