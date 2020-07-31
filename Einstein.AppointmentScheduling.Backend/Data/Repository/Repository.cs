using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppointmentSchedulingDBContext _context;
        protected DbSet<TEntity> DbSet;

        public Repository(AppointmentSchedulingDBContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        private void Add(TEntity entity)
        {
            DbSet.Add(entity);
            SaveChanges();
        }

        public void AddBulk(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
            SaveChanges();
        }

        public void AddOrUpdate(TEntity entity)
        {
            if (entity == null)
                return;

            if (entity.Id == null || entity.Id == Guid.Empty)
                Add(entity);
            else
                Update(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await DbSet.ToListAsync();
            return result;
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            SaveChanges();
        }

        private void Update(TEntity entity)
        {
            DbSet.Update(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
