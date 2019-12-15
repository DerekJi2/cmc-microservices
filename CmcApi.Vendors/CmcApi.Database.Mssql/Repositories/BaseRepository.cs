using CmcApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CmcApi.Database.Mssql.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        public MssqlDbContext localDbContext { get; set; }

        protected DbSet<TEntity> localDbSet
        {
            get
            {
                return this.localDbContext.Set<TEntity>();
            }
        }

        public BaseRepository(MssqlDbContext dbContext)
        {
            this.localDbContext = dbContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindAll(bool? active = true)
        {
            return localDbSet.Where(entity => !active.HasValue || entity.IsDeleted == !active);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindAllWithoutTracking(bool? active = true)
        {
            return localDbSet
                .AsNoTracking()
                .Where(entity => !active.HasValue || entity.IsDeleted == !active);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindByIdAsync(int id, bool? active = true)
        {
            return await FindAll(active).FirstOrDefaultAsync<TEntity>(entity => entity.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> FindByIdWithoutTrackingAsync(int id, bool? active = true)
        {
            return await FindAllWithoutTracking(active).FirstOrDefaultAsync<TEntity>(entity => entity.Id == id);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> CreateAsync(TEntity entity)
        {
            try
            {
                await localDbSet.AddAsync(entity);
                await localDbContext.SaveChangesAsync();
                return entity.Guid.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create entity.", ex);
            }

        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            try
            {
                localDbSet.Update(entity);
                await localDbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update entity.", ex);
            }
        }

        /// <summary>
        /// Hard delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(int id)
        {
            try
            {
                var entity = await FindByIdAsync(id);
                localDbSet.Remove(entity);
                await localDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Soft delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIdAsync(id);
                entity.IsDeleted = true;
                await UpdateAsync(id, entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UndeleteAsync(int id)
        {
            try
            {
                var entity = await FindByIdAsync(id, false);
                entity.IsDeleted = true;
                await UpdateAsync(id, entity);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
