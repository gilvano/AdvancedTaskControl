using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(int id);
        Task<int> SaveChanges();

        IQueryable<TEntity> GetAllQueryable();
    }
}
