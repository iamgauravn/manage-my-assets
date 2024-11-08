using manage_my_assets.App;
using manage_my_assets.Models;
using manage_my_assets.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace manage_my_assets.Service.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : AuditableEntity
    {
        protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Delete(T entity)
        {
            //_dbContext.Set<T>().Remove(entity); //hard delete
            entity.IsDeleted = true; //soft delete
            _dbContext.Set<T>().Update(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var response = await _dbContext.Set<T>().FindAsync(id);
            if (response.IsDeleted) //check for soft delete
                return null;
            return response;
        }

        public async Task<T> Insert(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return entity;
        }
    }
}
