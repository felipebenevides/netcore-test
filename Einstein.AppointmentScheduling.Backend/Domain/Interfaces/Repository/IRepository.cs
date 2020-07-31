using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(Guid id);
        void AddBulk(IEnumerable<TEntity> entities);
        void AddOrUpdate(TEntity entity);
        void Remove(TEntity entity);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
