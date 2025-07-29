using HuntAPI.Models;

namespace HuntAPI.Repositories.Interfaces;

public interface IRepository<T> : IDisposable where T : class {
        
            Task<List<T>> GetAll();
            Task<T?> GetByID(int id);
            Task<T> Add(T entity);
            Task<T> Update(T entity);
            Task<T> Delete(int id);

    }



