using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbContextFactory : IDbContextFactory
    {
        protected DbContext _defaultDbContext;
        protected DbContext _dataMiningDbContext;
        public DbContextFactory()
        {
            _defaultDbContext = _defaultDbContext ?? new DefaultDbContext();
        }
        public DbContext GetDefaultDbContext()
        {
            return _defaultDbContext ?? (_defaultDbContext = new DefaultDbContext());
        }
        public DbContext GetDataMiningDbContext()
        {
            return _dataMiningDbContext ?? (_dataMiningDbContext = new DataMiningDbContext());
        }
    }
}
