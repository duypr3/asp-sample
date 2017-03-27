using DAL;
using Services.Interface;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Implementation
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        #region init

        private readonly IBaseRepository<T> _repo;
        protected bool _autoSaveChange = true;
      
        public BaseService(IBaseRepository<T> repo)
        {
            _repo = repo;
        }

        #endregion init

        #region BaseRepository
        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            return _repo.Get(filter, includeProperties);
        }

        public IQueryable<T> GetAll(string s)
        {
            return _repo.GetAll(s);
        }

        public T GetByID(object ID)
        {
            return _repo.GetByID(ID);
        }

        public void Insert(T o)
        {
            _repo.Insert(o);           
        }

        public void Update(T o)
        {
            _repo.Update(o);           
        }

        public void Update(object primaryKey, T o)
        {
            _repo.Update(primaryKey, o);            
        }

        public void Delete(object primaryKey)
        {
            _repo.Delete(primaryKey);            
        }

        public void Delete(T o)
        {
            _repo.Delete(o);           
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            _repo.Delete(filter);            
        }

        #endregion BaseRepository

        public IQueryable<T> GetWithPaging(Expression<Func<T, bool>> filter = null, string includeProperties = "", int take = default(int), int skip = default(int))
        {
            IQueryable<T> query = _repo.Get(filter, includeProperties);
            return query.Take(take).Skip(skip);
        }       
    }
}