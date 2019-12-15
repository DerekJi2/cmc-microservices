using CmcApi.Core.Services;
using System.Linq;
using System.Threading.Tasks;

namespace CmcApi.Services
{
    public interface IBaseDataService<TEntity> : IBaseService
    {
        IQueryable<TEntity> FindAll(bool active = true);

        Task<TEntity> FindByIdAsync(int vendorId, bool? active = true);

        Task<TEntity> FindByIdWithoutTrackingAsync(int id, bool? active = true);

        Task<string> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(int id, TEntity entity);

        Task<bool> RemoveAsync(int id);

        Task<bool> SoftDeleteAsync(int id);

        Task<bool> UndeleteAsync(int id);
    }
}