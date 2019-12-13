using CmcApi.Core.Services;
using CmcApi.Database.Entity;
using System.Linq;

namespace CmcApi.Services.DataServices
{
    public interface IVendorsDataService : IBaseService
    {
        IQueryable<Vendor> FindAll(bool active = true);
    }
}
