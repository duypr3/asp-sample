using Entity;
using System;
using System.Data.Entity;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Init

        private DbContext _dbContext;

        public UnitOfWork(IDbContextFactory contextFactory)
        {
            _dbContext = contextFactory.GetDefaultDbContext();
        }

        #endregion Init

        #region Repositories

        private IBaseRepository<Student> _studentRepository;
        private IBaseRepository<Class> _classRepository;
        private IBaseRepository<Login> _loginRepository;

        private IBaseRepository<Student> StudentRepository
        {
            get { return _studentRepository ?? (_studentRepository = new BaseRepository<Student>(_dbContext)); }
        }

        private IBaseRepository<Class> ClassRepository
        {
            get { return _classRepository ?? (_classRepository = new BaseRepository<Class>(_dbContext)); }
        }
        private IBaseRepository<Login> LoginRepository
        {
            get { return _loginRepository ?? (_loginRepository = new BaseRepository<Login>(_dbContext)); }
        }
        public IBaseRepository<T> GetRepository<T>()
        {
            var type = typeof(T);
            if (type == typeof(Student)) return StudentRepository as IBaseRepository<T>;
            else if (type == typeof(Class)) return ClassRepository as IBaseRepository<T>;
            else if (type == typeof(Login)) return LoginRepository as IBaseRepository<T>;

            return null;
        }
        public DbContext GetDbContext()
        {
            return _dbContext;
        }
        #endregion Repositories

        //#region Dispose

        /*private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }*/

        //#endregion Dispose

        /* Dispose Repository ???????????????????///
         public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch 
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
         */
    }
}