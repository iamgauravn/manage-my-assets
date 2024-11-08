using manage_my_assets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace manage_my_assets.Service.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task<T> Create(T entity);
        Task<List<T>> Retrieve();
        Task<T> RetrieveByID(int id);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
