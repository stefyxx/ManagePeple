using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.DAL.Context
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _table;
        public BaseRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public virtual TEntity? FindById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity Add(TEntity entity)
        {
            TEntity inserted = _context.Set<TEntity>().Add(entity).Entity;
            _context.SaveChanges();
            return inserted;
        }

        public virtual void Remove(TEntity entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
        }
    }
}
