using manage_my_assets.App;
using manage_my_assets.Models;
using manage_my_assets.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace manage_my_assets.Service.Implementation
{
    public class BaseService<T> : IBaseService<T> where T : AuditableEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _dbContext;

        public BaseService(AppDbContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task<T> Create(T entity)
        {
            if (entity is AuditableEntity auditableEntity)
            {
                auditableEntity.SetAuditableProperties();
            }

            await _unitOfWork.Repository<T>().Insert(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _unitOfWork.Repository<T>().GetById(id);
            if (entity == null) return false;

            _unitOfWork.Repository<T>().Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> Retrieve()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> RetrieveByID(int id)
        {
            return await _unitOfWork.Repository<T>().GetById(id);
        }

        public async Task<T> Update(int id, T entity)
        {
            var existingEntity = await _unitOfWork.Repository<T>().GetById(id);
            if (existingEntity == null) return null;

            if (existingEntity is AuditableEntity auditableEntity)
            {
                auditableEntity.UpdateAuditableProperties();
            }

            // Assuming a method to update entity properties from the provided entity
            _unitOfWork.Repository<T>().Update(existingEntity);
            await _unitOfWork.SaveChangesAsync();

            return existingEntity;
        }
    }
}
