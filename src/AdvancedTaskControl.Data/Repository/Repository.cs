using AdvancedTaskControl.Business.Interfaces;
using AdvancedTaskControl.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskControl.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MeuDbContext _context;
        protected readonly DbSet<TEntity> entity;

        public Repository(MeuDbContext context)
        {
            _context = context;
            entity = context.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            this.entity.Add(entity);
            await SaveChanges();
        }

        public virtual void Dispose()
        {
            _context?.Dispose();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await entity.ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAllQueryable()
        {
            return entity.AsQueryable();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await entity.FindAsync(id);
        }

        public virtual async Task Remove(int id)
        {
            entity.Remove(await GetById(id));
            await SaveChanges();
        }

        public virtual async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _context.Update(entity);
            await SaveChanges();
        }
    }
}
