using CmcApi.Core.Entities;
using CmcApi.Core.Services;
using CmcApi.Database.Mssql.Repositories;
using CmcApi.Services.DataServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmcApi.Services
{
    public class BaseDataService<TEntity> : BaseService, IBaseDataService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> myRepos;

        public BaseDataService(
            IHttpContextAccessor httpContextAccessor,
            IBaseRepository<TEntity> repos
            ) : base(httpContextAccessor)
        {
            myRepos = repos;
        }

        public IQueryable<TEntity> FindAll(bool active = true)
        {
            return myRepos.FindAll(active);
        }

        public async Task<TEntity> FindByIdAsync(int id, bool? active = true)
        {
            return await myRepos.FindByIdAsync(id, active);
        }

        public async Task<TEntity> FindByIdWithoutTrackingAsync(int id, bool? active = true)
        {
            return await myRepos.FindByIdWithoutTrackingAsync(id, active);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> CreateAsync(TEntity entity)
        {
            return await myRepos.CreateAsync(entity);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            return await myRepos.UpdateAsync(id, entity);
        }

        /// <summary>
        /// Hard delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(int id)
        {
            return await myRepos.RemoveAsync(id);
        }

        /// <summary>
        /// Soft delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await myRepos.RemoveAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UndeleteAsync(int id)
        {
            return await myRepos.UndeleteAsync(id);
        }

    }
}
