using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Init
        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;
        protected bool _autoSaveChange = true;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public BaseRepository(DbContext dbContext, bool autoSaveChange)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _autoSaveChange = autoSaveChange;
        }
        #endregion

        #region Implementation

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

        public virtual T GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll(string includeProperties = "")
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        public virtual void Update(object primaryKey, T entity)
        {
            T dbEntity = this.GetByID(primaryKey);
            this.Update(dbEntity);
        }

        public virtual void Delete(object id)
        {
            T entity = _dbSet.Find(id);
            Delete(entity);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }
        public virtual void Delete(Expression<Func<T, bool>> filter)
        {
            var objects = _dbSet.Where<T>(filter).AsEnumerable();
            foreach (var e in objects)
            {
                this.Delete(e);
            }
        }

        #endregion
    }
}