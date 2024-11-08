﻿using manage_my_assets.App;
using manage_my_assets.Models;
using manage_my_assets.Service.Interface;

namespace manage_my_assets.Service.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _dbContext;
        private readonly IDictionary<Type, dynamic> _repositories;

        public UnitOfWork(AppDbContext dbContext)
        {
            _repositories = new Dictionary<Type, dynamic>();
        }

        public IGenericRepository<T> Repository<T>() where T : AuditableEntity
        {
            var entityType = typeof(T);

            if (_repositories.ContainsKey(entityType))
            {
                return _repositories[entityType];
            }

            var repositoryType = typeof(GenericRepository<>);

            var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

            if (repository == null)
            {
                throw new NullReferenceException("Repository should not be null");
            }

            _repositories.Add(entityType, repository);

            return (IGenericRepository<T>)repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task RollBackChangesAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }


    }
}
