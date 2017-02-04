using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepository
    {
        internal MasterDbContext context;
        internal DbSet<TEntity> dbSet;

        public EFRepository(MasterDbContext context)
        {
            if (context != null)
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();
            }
            else
            {
                throw new ArgumentNullException("MasterDbContext");
            }
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

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

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(long id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual void Update(object primaryKey, TEntity entityToUpdate)
        {
            TEntity dbEntity = this.SingleOrDefault(primaryKey);
            PropertyInfo[] infors = entityToUpdate.GetType().GetProperties();
            foreach (var propertyInfo in infors)
            {
                var propertyType = propertyInfo.PropertyType;

                if (
                    (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                    || ((propertyType.FullName.IndexOf("dora.Entities") > -1 && propertyType.BaseType.FullName.ToLower().IndexOf("enum") == -1))
                    )
                    continue;

                object value = propertyInfo.GetValue(entityToUpdate);
                if (propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(dbEntity, value);
                }
            }
            this.Update(dbEntity);
        }

        public TEntity Find(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }

        public TEntity SingleOrDefault(object primaryKey)
        {
            return dbSet.Find(primaryKey);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().AsEnumerable().ToList();
        }
    }
}
