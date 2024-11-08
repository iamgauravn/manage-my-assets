using manage_my_assets.Models;

namespace manage_my_assets.Service.Interface
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task RollBackChangesAsync();
        IGenericRepository<T> Repository<T>() where T : AuditableEntity;
    }
}
